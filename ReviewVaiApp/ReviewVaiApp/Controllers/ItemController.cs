﻿using ReviewVaiApp.Models;
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
		[HttpPost]
		public IHttpActionResult PostItem(Item item)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			item.Timestamp = DateTime.Now;
			db.Items.Add(item);
			db.SaveChanges();
			return Created(new Uri(Request.RequestUri + "/" + item.Id), item);
		}

	}
}
