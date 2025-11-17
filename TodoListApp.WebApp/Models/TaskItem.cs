using System.ComponentModel.DataAnnotations;

namespace TodoListApp.WebApp.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? DueDate { get; set; }

        public int TaskListId { get; set; }
        public TaskList TaskList { get; set; } = null!;
    }
}
