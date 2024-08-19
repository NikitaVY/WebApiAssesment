using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ITaskRepository;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITask _taskRepository;

        public TaskController(ITask taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Tasks> GetTasksById(int id)
        {
            var task = _taskRepository.GetTasksById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tasks>> GetAllTasks()
        {
            var tasks = _taskRepository.GetAllTasks();
            return Ok(tasks);
        }

        [HttpPost]
        public ActionResult<Tasks> AddTasks(Tasks task)
        {
            _taskRepository.AddTasks(task);
            return CreatedAtAction(nameof(GetTasksById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTasks(int id, Tasks task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _taskRepository.UpdateTasks(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTasks(int id)
        {
            _taskRepository.DeleteTasks(id);
            return NoContent();
        }
    }
}
