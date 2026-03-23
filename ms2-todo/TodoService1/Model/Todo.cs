using TodoService1.Enum;

namespace TodoService1.Model
{
    public class Todo
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public DateTime DateLimite { get; set; }
        public State State { get; set; }
    }
}
