using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Interfaces;
using Todo.Domain.Entities;
using Todo.Infrastructure.Interfaces;

namespace Todo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTasksController : ControllerBase
    {
        private readonly ITodoTasksService _taskService;

        public TodoTasksController(ITodoTasksService taskService)
        {
            _taskService = taskService;
        }

       

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllAsync();
            return Ok(tasks);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] ToDoTask task)
        {
            await _taskService.CreateAsync(task);
            return CreatedAtAction(nameof(CreateTask), new { id = task.Id }, task);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteAsync(id);
            return NoContent();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody] ToDoTask task)
        {
            await _taskService.UpdateAsync(task);
            return Ok();
        }

        [HttpPut("done/{id}")]
        public async Task<IActionResult> MarkTaskAsDone(int id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            task.IsDone = true;
            await _taskService.UpdateAsync(task);
            return NoContent();
        }

        [HttpPut("undone/{id}")]
        public async Task<IActionResult> MarkTaskAsUndone(int id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            task.IsDone = false;
            await _taskService.UpdateAsync(task);
            return NoContent();
        }

    }
}
