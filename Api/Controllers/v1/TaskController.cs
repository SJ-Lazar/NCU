using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private static List<TaskDTO> tasks = new List<TaskDTO>
        {
            new TaskDTO { TaskID = 1, Title = "Task 1", Description = "Description 1", Status = "In Progress", Priority = "High" },
            new TaskDTO { TaskID = 2, Title = "Task 2", Description = "Description 2", Status = "To-do", Priority = "Medium" },
            // Add more tasks as needed
        };

    [HttpGet]
    public IActionResult GetTasks()
    {
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public IActionResult GetTask(int id)
    {
        var task = tasks.Find(t => t.TaskID == id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]
    public IActionResult AddTask(TaskDTO task)
    {
        task.TaskID = tasks.Count + 1; // Generate ID (replace with proper ID generation)
        tasks.Add(task);
        return CreatedAtAction(nameof(GetTask), new { id = task.TaskID }, task);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, TaskDTO updatedTask)
    {
        var taskIndex = tasks.FindIndex(t => t.TaskID == id);
        if (taskIndex == -1)
        {
            return NotFound();
        }
        updatedTask.TaskID = id;
        tasks[taskIndex] = updatedTask;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var task = tasks.Find(t => t.TaskID == id);
        if (task == null)
        {
            return NotFound();
        }
        tasks.Remove(task);
        return NoContent();
    }
}

