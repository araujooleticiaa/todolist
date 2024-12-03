using Application.DTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskItemControllers : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;
        public TaskItemControllers(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        [HttpPost]
        public async Task<ActionResult<TaskItem>> Post([FromBody] CreateTaskItemRequest request)
        {
            try
            {
                var taskItem = new TaskItem(request.Title, request.Description, request.DueDate, request.Status, request.Properties, request.Comments, request.ProjectId);

                var result = await _taskItemService.CreateTaskItem(taskItem);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id:Guid}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                var result = _taskItemService.DeleteTaskItem(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public ActionResult UpdateTaskItem([FromBody] TaskItem taskItem, [FromRoute] Guid id)
        {
            try
            {
                var result = _taskItemService.UpdateTaskItem(taskItem);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
