using Microsoft.AspNetCore.Mvc;
using System;
using TaskToDo.Contracts;
using TaskToDo.Models;
using TaskToDo.Repository;

namespace TaskToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskToDoController : ControllerBase
    {
        private readonly TaskRepository taskRepo;

        public TaskToDoController()
        {
            taskRepo = new TaskRepository();
        }

        // GET: api/TaskToDo
        [HttpGet]
        public IActionResult GetTaskToDo()
        {
            var taskList = taskRepo.Listar();
            return Ok(taskList);
        }

        // GET: api/TaskToDo/5
        [HttpGet("{id}")]
        public IActionResult GetTaskToDo(Guid id)
        {
            var taskToDo = taskRepo.Consultar(id, null);

            if (taskToDo == null)
            {
                return NotFound();
            }

            return Ok(taskToDo);
        }

        // PUT: api/TaskToDo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutTaskToDo(Guid id, [FromBody] TaskToDoModel taskModel)
        {
            var response = taskRepo.Alterar(taskModel, id);
            if (!response)
                return BadRequest();

            return Ok();
        }

        // POST: api/TaskToDo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostTaskToDo(TaskToDoContract taskToDo)
        {
            var taskModel = new TaskToDoModel() { Id = Guid.NewGuid(), Active = true, Nome = taskToDo.Nome };
            taskRepo.Adicionar(taskModel);

            return Ok(taskModel);
        }

        // DELETE: api/TaskToDo/5
        [HttpDelete("{id}")]
        public void DeleteTaskToDo(Guid id)
        {
            taskRepo.Excluir(id);
        }
    }
}
