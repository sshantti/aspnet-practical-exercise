using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoListApp.WebApp.Models;

namespace TodoListApp.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
