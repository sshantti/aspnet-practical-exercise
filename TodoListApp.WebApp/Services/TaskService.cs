using Microsoft.EntityFrameworkCore;
using TodoListApp.WebApp.Data;
using TodoListApp.WebApp.Models;

namespace TodoListApp.WebApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
            _ = InitializeTestDataAsync(); // Используем discard для асинхронной инициализации
        }

        private async Task InitializeTestDataAsync()
        {
            try
            {
                // Проверяем, есть ли уже данные для demo-user
                var demoUserId = "demo-user";
                if (!await _context.TaskLists.AnyAsync(l => l.UserId == demoUserId))
                {
                    var demoList = new TaskList
                    {
                        Title = "My First Task List",
                        Description = "This is a sample task list to get you started",
                        UserId = demoUserId,
                        CreatedDate = DateTime.UtcNow
                    };

                    _context.TaskLists.Add(demoList);

                    // Добавим несколько демо-задач
                    var demoTask1 = new TaskItem
                    {
                        Title = "Complete project setup",
                        Description = "Finish setting up the Task Manager application",
                        IsCompleted = false,
                        CreatedDate = DateTime.UtcNow,
                        DueDate = DateTime.UtcNow.AddDays(1),
                        TaskList = demoList
                    };

                    var demoTask2 = new TaskItem
                    {
                        Title = "Learn ASP.NET Core",
                        Description = "Study MVC pattern and Entity Framework",
                        IsCompleted = true,
                        CreatedDate = DateTime.UtcNow.AddDays(-1),
                        DueDate = DateTime.UtcNow.AddDays(-1),
                        TaskList = demoList
                    };

                    _context.TaskItems.Add(demoTask1);
                    _context.TaskItems.Add(demoTask2);

                    await _context.SaveChangesAsync();
                    Console.WriteLine("Test data initialized successfully");
                }
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database update error initializing test data: {dbEx.Message}");
            }
            catch (InvalidOperationException ioEx)
            {
                Console.WriteLine($"Invalid operation error initializing test data: {ioEx.Message}");
            }
        }

        public async Task<List<TaskList>> GetUserListsAsync(string userId)
        {
            try
            {
                return await _context.TaskLists
                    .Where(l => l.UserId == userId)
                    .Include(l => l.Tasks)
                    .OrderBy(l => l.Title)
                    .ToListAsync();
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error in GetUserListsAsync: {dbEx.Message}");
                return new List<TaskList>();
            }
            catch (InvalidOperationException ioEx)
            {
                Console.WriteLine($"Invalid operation in GetUserListsAsync: {ioEx.Message}");
                return new List<TaskList>();
            }
        }

        public async Task<TaskList?> GetListByIdAsync(int id, string userId)
        {
            try
            {
                return await _context.TaskLists
                    .Include(l => l.Tasks)
                    .FirstOrDefaultAsync(l => l.Id == id && l.UserId == userId);
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error in GetListByIdAsync: {dbEx.Message}");
                return null;
            }
            catch (InvalidOperationException ioEx)
            {
                Console.WriteLine($"Invalid operation in GetListByIdAsync: {ioEx.Message}");
                return null;
            }
        }

        public async Task CreateListAsync(TaskList list)
        {
            try
            {
                list.CreatedDate = DateTime.UtcNow;
                _context.TaskLists.Add(list);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error creating list: {dbEx.Message}");
                throw new Exception("Could not create task list", dbEx);
            }
            catch (InvalidOperationException ioEx)
            {
                Console.WriteLine($"Invalid operation creating list: {ioEx.Message}");
                throw new Exception("Could not create task list", ioEx);
            }
        }

        public async Task UpdateListAsync(TaskList list)
        {
            try
            {
                _context.TaskLists.Update(list);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error updating list: {dbEx.Message}");
                throw new Exception("Could not update task list", dbEx);
            }
            catch (InvalidOperationException ioEx)
            {
                Console.WriteLine($"Invalid operation updating list: {ioEx.Message}");
                throw new Exception("Could not update task list", ioEx);
            }
        }

        public async Task DeleteListAsync(int id, string userId)
        {
            try
            {
                var list = await GetListByIdAsync(id, userId);
                if (list != null)
                {
                    var tasks = await _context.TaskItems
                        .Where(t => t.TaskListId == id)
                        .ToListAsync();

                    _context.TaskItems.RemoveRange(tasks);
                    _context.TaskLists.Remove(list);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error deleting list: {dbEx.Message}");
                throw new Exception("Could not delete task list", dbEx);
            }
            catch (InvalidOperationException ioEx)
            {
                Console.WriteLine($"Invalid operation deleting list: {ioEx.Message}");
                throw new Exception("Could not delete task list", ioEx);
            }
        }

        public async Task<List<TaskItem>> GetListTasksAsync(int listId, string userId)
        {
            try
            {
                return await _context.TaskItems
                    .Where(t => t.TaskListId == listId && t.TaskList.UserId == userId)
                    .OrderBy(t => t.IsCompleted)
                    .ThenBy(t => t.DueDate)
                    .ToListAsync();
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error in GetListTasksAsync: {dbEx.Message}");
                return new List<TaskItem>();
            }
            catch (InvalidOperationException ioEx)
            {
                Console.WriteLine($"Invalid operation in GetListTasksAsync: {ioEx.Message}");
                return new List<TaskItem>();
            }
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int id, string userId)
        {
            try
            {
                return await _context.TaskItems
                    .Include(t => t.TaskList)
                    .FirstOrDefaultAsync(t => t.Id == id && t.TaskList.UserId == userId);
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error in GetTaskByIdAsync: {dbEx.Message}");
                return null;
            }
            catch (InvalidOperationException ioEx)
            {
                Console.WriteLine($"Invalid operation in GetTaskByIdAsync: {ioEx.Message}");
                return null;
            }
        }

        public async Task CreateTaskAsync(TaskItem task)
        {
            try
            {
                task.CreatedDate = DateTime.UtcNow;
                _context.TaskItems.Add(task);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error creating task: {dbEx.Message}");
                throw new Exception("Could not create task", dbEx);
            }
            catch (InvalidOperationException ioEx)
            {
                Console.WriteLine($"Invalid operation creating task: {ioEx.Message}");
                throw new Exception("Could not create task", ioEx);
            }
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            try
            {
                _context.TaskItems.Update(task);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error updating task: {dbEx.Message}");
                throw new Exception("Could not update task", dbEx);
            }
            catch (InvalidOperationException ioEx)
            {
                Console.WriteLine($"Invalid operation updating task: {ioEx.Message}");
                throw new Exception("Could not update task", ioEx);
            }
        }

        public async Task DeleteTaskAsync(int id, string userId)
        {
            try
            {
                var task = await GetTaskByIdAsync(id, userId);
                if (task != null)
                {
                    _context.TaskItems.Remove(task);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database error deleting task: {dbEx.Message}");
                throw new Exception("Could not delete task", dbEx);
            }
            catch (InvalidOperationException ioEx)
            {
                Console.WriteLine($"Invalid operation deleting task: {ioEx.Message}");
                throw new Exception("Could not delete task", ioEx);
            }
        }
    }
}
