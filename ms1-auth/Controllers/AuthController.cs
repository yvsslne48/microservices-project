using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ms1_auth.Data;
using ms1_auth.DTOs;
using ms1_auth.Models;
using ms1_auth.Services;

namespace ms1_auth.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly JwtService _jwtService;

    public AuthController(AppDbContext db, JwtService jwtService)
    {
        _db = db;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        // Vérifier si le login existe déjà
        var exists = await _db.Users.AnyAsync(u => u.Login == dto.Login);
        if (exists)
            return BadRequest(new { message = "Ce login est déjà utilisé." });

        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Login = dto.Login,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return Ok(new { message = "Utilisateur créé avec succès." });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Login == dto.Login);

        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return Unauthorized(new { message = "Login ou mot de passe incorrect." });

        var token = _jwtService.GenerateToken(user);

        return Ok(new { token });
    }
}