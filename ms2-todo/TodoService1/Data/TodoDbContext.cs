using Microsoft.EntityFrameworkCore;
using TodoService1.Model;

namespace TodoService1.Data
{
        public class TodoDbContext : DbContext //Héritage
    {
            public TodoDbContext(DbContextOptions<TodoDbContext> options) //Constructeur
                : base(options)
            {
            }
            public DbSet<Todo> Todos { get; set; }
        }
}

