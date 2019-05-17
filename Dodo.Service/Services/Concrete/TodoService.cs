using System;
using Dodo.Domain.Models;
using Dodo.EFDataAccess;
using Dodo.Service.Services.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dodo.Domain.Models.Types;

namespace Dodo.Service.Services.Concrete
{
	public class TodoService : ITodoService
	{
		private DodoEFContext context;

		public TodoService(DodoEFContext context)
		{
			this.context = context;
		}

		public async Task<List<Todo>> ListAllAsync()
		{
			return await context.Todos.OrderByDescending(x => x.Id).ToListAsync();
		}

		public async Task AddItemAsync(Todo item)
		{
			item.CreatedDate = DateTimeOffset.Now;

			await context.Todos.AddAsync(item);
			await context.SaveChangesAsync();
		}

		public async Task RemoveItemAsync(Todo todo)
		{
			context.Todos.Remove(todo);
			await context.SaveChangesAsync();
		}

		public async Task<Todo> GetItemByAsync(Expression<Func<Todo, bool>> callback)
		{
			return await context.Todos.FirstOrDefaultAsync(callback);
		}

		public async Task UpdateAsync(Todo item)
		{
			context.Entry(item).State = EntityState.Modified;
			await context.SaveChangesAsync();
		}

		public async Task<bool> TodoExistsAsync(int id)
		{
			return await context.Todos.AnyAsync(t => t.Id == id);
		}

		public async Task<List<Todo>> ListByCategoryAsync(TodoCategory todoCategory)
		{
			return await context.Todos.Where(t => t.Category == todoCategory).ToListAsync();
		}
	}
}
