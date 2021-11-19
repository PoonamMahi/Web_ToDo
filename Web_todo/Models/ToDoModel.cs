using System;
namespace Web_todo.Models
{
    public class ToDoModel
    {
            public int Id { get; set; }
            public DateTime ToDoDate { get; set; }
            public string Title { get; set; }
            public bool IsCompleted { get; set; }
    }
    
}
