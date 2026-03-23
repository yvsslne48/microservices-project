using TodoService1.Enum;

namespace TodoService1.DTOs.Todo
{
    public class TodoindexDTOResponse
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public DateTime DateLimite { get; set; }
        public State State { get; set; }
    }
}
