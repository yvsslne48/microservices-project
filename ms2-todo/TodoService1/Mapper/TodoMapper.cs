using TodoService1.DTOs;
using TodoService1.DTOs.Todo;
using TodoService1.Enum;
using TodoService1.Model;

namespace TodoService1.Mapper
{
    public static class TodoMapper
    {
        public static Todo ToEntity(TodoAddDTORequest dto)
        {
            return new Todo
            {
                Titre = dto.Titre,
                Description = dto.Description,
                DateLimite = dto.DateLimite,
                State = dto.State
            };
        }

        public static TodoAddDTOResponse ToAddResponse(Todo todo)
        {
            return new TodoAddDTOResponse
            {
                Id = todo.Id,
                Titre = todo.Titre,
                Description = todo.Description,
                DateLimite = todo.DateLimite,
                State = todo.State
            };
        }

        public static TodoindexDTOResponse ToIndexResponse(Todo todo)
        {
            return new TodoindexDTOResponse
            {
                Id = todo.Id,
                Titre = todo.Titre,
                DateLimite = todo.DateLimite,
                State = todo.State
            };
        }
    }
}