using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dodo.Domain.Models;
using Dodo.EFDataAccess;
using Dodo.Service.Services.Abstract;
using Dodo.Domain.Models.Types;

namespace Dodo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
	    private readonly ITodoService todoService;

        public TodosController(ITodoService todoService)
        {
	        this.todoService = todoService;
        }

        // GET: api/Todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            return await todoService.ListAllAsync();
        }

		[HttpGet("/category/{category}")]
		public async Task<ActionResult<IEnumerable<Todo>>> GetTodos(TodoCategory category)
		{
			if(!Enum.TryParse<TodoCategory>($"{category}", out TodoCategory outCategory))
			{
				return NotFound();
			}

			return await todoService.ListByCategoryAsync(category);
		}

		// GET: api/Todos/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Todo>> GetTodo(int id)
		{
			var todo = await todoService.GetItemByAsync(t => t.Id == id);

			if (todo == null)
			{
				return NotFound();
			}

			return todo;
		}

		// PUT: api/Todos/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutTodo(int id, Todo todo)
		{
			if (id != todo.Id)
			{
				return BadRequest();
			}

			try
			{
				await todoService.UpdateAsync(todo);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!(await todoService.TodoExistsAsync(id)))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Todos
		[HttpPost]
		public async Task<ActionResult<Todo>> PostTodo(Todo todo)
		{
			await todoService.AddItemAsync(todo);

			return CreatedAtAction("GetTodo", new { id = todo.Id }, todo);
		}

		// DELETE: api/Todos/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Todo>> DeleteTodo(int id)
		{
			Todo todo = await todoService.GetItemByAsync(t => t.Id == id);

			if (todo is null)
			{
				return NotFound();
			}

			await todoService.RemoveItemAsync(todo);

			return todo;
		}
    }
}
