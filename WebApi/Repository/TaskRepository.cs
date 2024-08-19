using WebApi.Context;
using WebApi.ITaskRepository;
using WebApi.Models;

namespace WebApi.Repository
{
    public class TaskRepository : ITask
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context;
        }

        public Tasks GetTasksById(int id)
        {
            return _context.Tasks.Find(id);
        }

        public IEnumerable<Tasks> GetAllTasks()
        {
            return _context.Tasks.ToList();
        }

        public void AddTasks(Tasks task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTasks(Tasks task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTasks(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        // SubTask-related methods
        public SubTask AddSubTask(SubTask subTask)
        {
            _context.SubTasks.Add(subTask);
            _context.SaveChanges();
            return subTask;
        }

        public IEnumerable<SubTask> GetSubTasksByTaskId(int taskId)
        {
            return _context.SubTasks.Where(st => st.TaskId == taskId).ToList();
        }
    }
}