﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewVaiApp.Models
{
	public class Reaction
	{
		public long Id { get; set; }
		public Post Post { get; set; }
		public long PostId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
		public string ApplicationUserId { get; set; }
		public int IsLiked { get; set; }
		public int IsHelpfull { get; set; }
	}
}