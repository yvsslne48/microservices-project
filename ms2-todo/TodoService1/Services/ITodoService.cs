using TodoService1.DTOs.Todo;

namespace TodoService1.Services
{
    public interface ITodoService
    {
        Task<List<TodoindexDTOResponse>> GetAllAsync();
        Task<TodoAddDTOResponse> AddAsync(TodoAddDTORequest request);
        Task UpdateAsync(int id, TodoUpdateDTORequest request);
        Task DeleteAsync(int id);
    }
}
