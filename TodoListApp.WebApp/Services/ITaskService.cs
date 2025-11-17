using TodoListApp.WebApp.Models;

namespace TodoListApp.WebApp.Services
{
    public interface ITaskService
    {
        Task<List<TaskList>> GetUserListsAsync(string userId);
        Task<TaskList?> GetListByIdAsync(int id, string userId);
        Task CreateListAsync(TaskList list);
        Task UpdateListAsync(TaskList list);
        Task DeleteListAsync(int id, string userId);

        Task<List<TaskItem>> GetListTasksAsync(int listId, string userId);
        Task<TaskItem?> GetTaskByIdAsync(int id, string userId);
        Task CreateTaskAsync(TaskItem task);
        Task UpdateTaskAsync(TaskItem task);
        Task DeleteTaskAsync(int id, string userId);
    }
}
