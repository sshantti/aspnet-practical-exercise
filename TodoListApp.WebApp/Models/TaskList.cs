using System.ComponentModel.DataAnnotations;

namespace TodoListApp.WebApp.Models
{
    public class TaskList
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; } = string.Empty;
        public List<TaskItem> Tasks { get; set; } = [];
    }
}
