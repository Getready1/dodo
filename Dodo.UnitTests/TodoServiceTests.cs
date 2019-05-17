using Dodo.Domain.Models;
using Dodo.Service.Services.Abstract;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Dodo.UnitTests
{
	[TestFixture]
	public class TodoServiceTests
	{
		private Mock<ITodoService> todoService;

		[SetUp]
		public void Setup()
		{
			todoService = new Mock<ITodoService>();
			todoService.Setup(x => x.ListAllAsync()).ReturnsAsync(new List<Todo>
			{
				new Todo() { Id = 1, Content = "Test", IsCompleted = false },
				new Todo() { Id = 2, Content = "Test1", IsCompleted = false },
				new Todo() { Id = 3, Content = "Test2", IsCompleted = false }
			});
		}

	}
}
