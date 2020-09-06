﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewVaiApp.Models
{
	public class PostComment
	{
		public long Id { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
		
		public Post Post { get; set; }
		public long PostId { get; set; }
		public string Text { get; set; }
	
		public DateTime TimeStamp { get; set; }
	}
}