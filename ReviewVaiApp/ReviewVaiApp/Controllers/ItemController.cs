using ReviewVaiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReviewVaiApp.Controllers
{
    public class ItemController : ApiController
    {
		private ApplicationDbContext db = new ApplicationDbContext();

		public IHttpActionResult GetItems()
		{
			var items = db.Items.ToList();
			if (items == null)
			{
				return BadRequest();
			}
			return Ok(items);
		}

	}
}
