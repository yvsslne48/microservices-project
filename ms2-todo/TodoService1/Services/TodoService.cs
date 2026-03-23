using TodoService1.DTOs.Todo;
using TodoService1.Mapper;
using TodoService1.Repositories;

namespace TodoService1.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TodoindexDTOResponse>> GetAllAsync()
        {
            var todos = await _repository.GetAllAsync();
            return todos.Select(TodoMapper.ToIndexResponse).ToList();
        }

        public async Task<TodoAddDTOResponse> AddAsync(TodoAddDTORequest request)
        {
            var entity = TodoMapper.ToEntity(request);
            var result = await _repository.AddAsync(entity);
            return TodoMapper.ToAddResponse(result);
        }

        public async Task UpdateAsync(int id, TodoUpdateDTORequest request)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Todo not found");

            existing.Titre = request.Titre;
            existing.Description = request.Description;
            existing.DateLimite = request.DateLimite;
            existing.State = request.State;

            await _repository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
