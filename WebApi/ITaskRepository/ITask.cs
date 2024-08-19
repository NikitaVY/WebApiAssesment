using System.Text.Json.Serialization;
using WebApi.Models;

namespace WebApi.ITaskRepository
{
    public interface ITask
    {
        Tasks GetTasksById(int id);
        IEnumerable<Tasks> GetAllTasks();
        void AddTasks(Tasks task);
        void UpdateTasks(Tasks task);
        void DeleteTasks(int id);

        // SubTask-related methods
        SubTask AddSubTask(SubTask subTask);
        IEnumerable<SubTask> GetSubTasksByTaskId(int taskId);
    }
}
