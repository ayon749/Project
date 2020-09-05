using ReviewVaiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Helpers;
using System.Data.Entity.Validation;

namespace ReviewVaiApp.Controllers
{    [Authorize]
	public class ReviewController : ApiController
	{
		private ApplicationDbContext db = new ApplicationDbContext();
		//[Route("Get-Review-post")]
		[HttpGet]
		public IHttpActionResult GetReviewPosts()
		{
			var posts = db.Posts.Include(p => p.Stars).Include(r => r.RestaurantOrPalce.ApplicationUser).Include(p => p.Items).Include(p => p.Tags).ToList();

			//if (posts == null)
			//{
			//	return NotFound();
			//}
			foreach (Post post in posts)
			{
				var reactions = db.Reactions.Where(p => p.PostId == post.Id).ToList();
				var photos = db.Photos.Where(p => p.PostId == post.Id).ToList();



			}


			return Ok(posts);
			//string jason = JsonConvert.SerializeObject(posts, Formatting.Indented);
			//return posts.AsQueryable();
		}
		//[Route("Review/Review-Post-By-Id/{id}")]
		//[Route("{id}/ReviewPost",Name="Review-Post")]
		public IHttpActionResult GetReviewPost(long id)
		{
			var post = db.Posts.Include(p => p.Stars).Include(r => r.RestaurantOrPalce.ApplicationUser).Include(p => p.Items).Include(p => p.Tags).First(p => p.Id == id);
			var reactions = db.Reactions.Where(p => p.PostId == id).ToList();
			var photos = db.Photos.Where(p => p.PostId == id).ToList();


			return Ok(post);

		}
		[HttpGet]
		//[Route("{id:alpha}")]
		public IHttpActionResult ReviewPostByUserId(string id)
		{
			var posts = db.Posts.Include(p => p.Stars).Include(r => r.RestaurantOrPalce.ApplicationUser).Include(p => p.Items).Include(p => p.Tags).Where(p => p.ApplicationUserId == id).ToList();
			foreach (Post post in posts)
			{
				var reactions = db.Reactions.Where(p => p.PostId == post.Id).ToList();
				var photos = db.Photos.Where(p => p.PostId == post.Id).ToList();
			}


			return Ok(posts);

		}

		

		[HttpPost]
		public IHttpActionResult PostReviewPost(Post post)
		{
			
			string json = JsonConvert.SerializeObject(post, Formatting.Indented);
			var model = JsonConvert.DeserializeObject<Post>(json);
			
			var errors = ModelState.Values.SelectMany(v => v.Errors);
			
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			try
			{

				db.Posts.Add(model);
				db.SaveChanges();
			}
			catch (DbEntityValidationException e)
			{
				foreach (var eve in e.EntityValidationErrors)
				{
					Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
						eve.Entry.Entity.GetType().Name, eve.Entry.State);
					foreach (var ve in eve.ValidationErrors)
					{
						Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
							ve.PropertyName, ve.ErrorMessage);
					}
				}
				throw;
			}
			return Created(new Uri(Request.RequestUri + "/" + model.Id), model);
		}
		[HttpGet]
		public IHttpActionResult GetComment(long id)
		{
			var commnet = db.PostComments.Where(c => c.PostId == id).ToList();
			return Ok(commnet);
		}
		public IHttpActionResult PostAComment(PostComment postComment)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			db.PostComments.Add(postComment);
			db.SaveChanges();
			return Created(new Uri(Request.RequestUri + "/" + postComment.Id), postComment);
		}
	}
}
