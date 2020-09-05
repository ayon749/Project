using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewVaiApp.Models
{
	public class SubComment
	{
		public long Id { get; set; }
		public PostComment PostComment { get; set; }
		public long PostCommentId { get; set; }
		public string Text { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
		public DateTime TimeStamp { get; set; }
	}
}