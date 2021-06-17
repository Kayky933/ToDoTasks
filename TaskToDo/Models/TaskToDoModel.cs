using System;

namespace TaskToDo.Models
{
    public class TaskToDoModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Active { get; set; }
    }
}
