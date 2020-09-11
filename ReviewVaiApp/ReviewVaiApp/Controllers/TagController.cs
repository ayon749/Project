using ReviewVaiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReviewVaiApp.Controllers
{
    public class TagController : ApiController
    {
		private ApplicationDbContext db = new ApplicationDbContext();
		public IHttpActionResult GetTags()
		{
			var tags = db.Tags.ToList();
			if (tags == null)
			{
				return BadRequest();
			}
			return Ok(tags);

		}
	}
}
