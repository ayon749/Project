﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewVaiApp.Models
{
	public class RestaurantOrPalce
	{
		public long Id { get; set; }
		public int TotalRecommendation { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
		
		public int TotalReviews { get; set; }
		public int RestOrPlace { get; set; }
		public string Location { get; set; }

	}
}