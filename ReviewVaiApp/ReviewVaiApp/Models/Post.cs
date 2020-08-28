using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewVaiApp.Models
{
	public class Post
	{
		public long Id { get; set; }
		public string PostTitle { get; set; }
		public bool IsOfferOrPlanned { get; set; }
		public bool IsRecommended { get; set; }
	
		public RestaurantOrPalce RestaurantOrPalce { get; set; }
	
		public ApplicationUser ApplicationUser { get; set; }
		public int ApplicationUserId { get; set; }
		public List<Tag> Tags { get; set; }
		public List<Reaction> Reactions { get; set; }
		public List<Photo> Photos { get; set; }
		public DateTime? TimePosted { get; set; }
		public string PostBody { get; set; }
		
		public int FoodOrTravel { get; set; }
		public Stars Stars { get; set; }
	}
}