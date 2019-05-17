using Dodo.Domain.Models;
using Dodo.Domain.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dodo.Service.Services.Abstract
{
	public interface ITodoService
	{
		Task<List<Todo>> ListByCategoryAsync(TodoCategory todoCategory);
		Task<List<Todo>> ListAllAsync();
		Task AddItemAsync(Todo item);
		Task RemoveItemAsync(Todo todo);
		Task<Todo> GetItemByAsync(Expression<Func<Todo, bool>> callback);
		Task UpdateAsync(Todo item);
		Task<bool> TodoExistsAsync(int id);
	}
}
