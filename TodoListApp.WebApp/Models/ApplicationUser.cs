using Microsoft.AspNetCore.Identity;

namespace TodoListApp.WebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<TaskList> TodoLists { get; set; } = [];
        public ICollection<TaskItem> AssignedItems { get; set; } = [];
    }
}
