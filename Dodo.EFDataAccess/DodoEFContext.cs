using System;
using System.Collections.Generic;
using System.Text;
using Dodo.Domain.Models;
using Dodo.Domain.Models.Types;
using Microsoft.EntityFrameworkCore;

namespace Dodo.EFDataAccess
{
	public class DodoEFContext : DbContext
	{
		public DodoEFContext(DbContextOptions<DodoEFContext> options) : base(options)
		{
			
		}

		public DbSet<Todo> Todos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Todo>().HasData(new List<Todo>
			{
				new Todo() { Id = 1, IsCompleted = false, Content = "0TestTestTestTest TestTest", Category = TodoCategory.Todo, CreatedDate = DateTimeOffset.Now},
				new Todo() { Id = 2, IsCompleted = false, Content = "1TestTestTestTest TestTest", Category = TodoCategory.Todo, CreatedDate = DateTimeOffset.Now},
				new Todo() { Id = 3, IsCompleted = false, Content = "2TestTestTestTest TestTest", Category = TodoCategory.Todo, CreatedDate = DateTimeOffset.Now},
				new Todo() { Id = 4, IsCompleted = false, Content = "3TestTestTestTest TestTest", Category = TodoCategory.Todo, CreatedDate = DateTimeOffset.Now}
			});

			base.OnModelCreating(modelBuilder);
		}
	}
}
