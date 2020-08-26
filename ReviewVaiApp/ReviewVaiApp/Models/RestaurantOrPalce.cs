using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewVaiApp.Models
{
	public class RestaurantOrPalce
	{
		public int Id { get; set; }
		public int TotalRecommendation { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
		public int ApplicationUserId { get; set; }
		public int TotalReviews { get; set; }
		public Byte RestOrPlace { get; set; }

	}
}