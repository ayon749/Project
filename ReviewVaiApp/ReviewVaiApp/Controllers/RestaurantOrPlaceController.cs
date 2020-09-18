using ReviewVaiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReviewVaiApp.Controllers
{
    public class RestaurantOrPlaceController : ApiController
    {
		private ApplicationDbContext db = new ApplicationDbContext();

		public IHttpActionResult GetRestaurantOrPlaces()
		{

			var restaurantOrPlaces = db.RestaurantOrPlaces.ToList();

			//foreach(var restaurant in restaurantOrPlaces)
			//{
			//	var id=restaurant.ApplicationUser.Id
			//}

			if (restaurantOrPlaces==null)
			{
				return BadRequest();
			}
			return Ok(restaurantOrPlaces);
		}
	}
}
