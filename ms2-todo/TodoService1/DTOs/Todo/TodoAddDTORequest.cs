using TodoService1.Enum;

namespace TodoService1.DTOs.Todo
{
    public class TodoAddDTORequest
    {
        public string Titre { get; set; }
        public string Description { get; set; }
        public DateTime DateLimite { get; set; }
        public State State { get; set; } //string for todo mapper (convertire on string)

    }
}
