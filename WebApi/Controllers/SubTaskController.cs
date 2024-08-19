using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ITaskRepository;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubTaskController : ControllerBase
    {
        private readonly ITask _taskRepository;

        public SubTaskController(ITask tasksRepository)
        {
            _taskRepository = tasksRepository;
        }

        [HttpPost]
        public ActionResult<SubTask> AddSubTask(SubTask subTask)
        {
            var addedSubTask = _taskRepository.AddSubTask(subTask);
            return CreatedAtAction(nameof(GetSubTasksByTaskId), new { id = subTask.TaskId }, addedSubTask);
        }

        [HttpGet("tasks/{taskId}")]
        public ActionResult<IEnumerable<SubTask>> GetSubTasksByTaskId(int taskId)
        {
            var subTasks = _taskRepository.GetSubTasksByTaskId(taskId);
            return Ok(subTasks);
        }
    }
}
