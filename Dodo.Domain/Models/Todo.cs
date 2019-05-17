using System;
using System.Collections.Generic;
using System.Text;
using Dodo.Domain.Models.Types;

namespace Dodo.Domain.Models
{
	public class Todo
	{
		public int Id { get; set; }
		public string Content { get; set; }
		public bool IsCompleted { get; set; }
		public TodoCategory Category { get; set; }
		public DateTimeOffset CreatedDate { get; set; }
	}
}
