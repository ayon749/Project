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
using System.Data.Entity.Migrations;

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
				var comments = db.PostComments.Where(p => p.PostId == post.Id).ToList();



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
			var comments = db.PostComments.Where(p => p.PostId == id).ToList();


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
				var comments = db.PostComments.Where(p => p.PostId == post.Id).ToList();
			}


			return Ok(posts);

		}

		

		[HttpPost]
		public IHttpActionResult PostReviewPost(Post post)
		{
			if (!User.Identity.IsAuthenticated)
			{
				return BadRequest();
			}
			var userName = User.Identity.Name;
			string json = JsonConvert.SerializeObject(post, Formatting.Indented);
			var model = JsonConvert.DeserializeObject<Post>(json);
			model.TimePosted = DateTime.Now;
			
			var errors = ModelState.Values.SelectMany(v => v.Errors);
			
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			try
			{
				var items = model.Items;
				List<Item> itemss = new List<Item>();
				if (items != null)
				{
					foreach (var item in items)
					{
						var aItem = item;
						var itemInDb = db.Items.Where(i => i.Id == item.Id).SingleOrDefault();
						if (itemInDb == null)
						{
							db.Items.Add(item);
						}
						itemss.Add(itemInDb);
					}
				}
				var tags = model.Tags;
				List<Tag> tagss = new List<Tag>();
				if(tags!=null)
				{
				foreach(var tag in tags)
				{
					var tagInDb=db.Tags.Where(i => i.Id == tag.Id).SingleOrDefault();
					if (tagInDb == null)
					{
						db.Tags.Add(tag);
					}
					tagss.Add(tagInDb);
				}
				}
				var restaurantInDb = db.RestaurantOrPlaces.Where(i => i.Id == model.RestaurantOrPalceId).SingleOrDefault();
				if (restaurantInDb == null)
				{
					db.RestaurantOrPlaces.Add(model.RestaurantOrPalce);
				}
				model.RestaurantOrPalce = restaurantInDb;

				//db.Items.AddOrUpdate(items.ToArray());
				model.Tags = tagss;
				model.Items = itemss;
				db.Posts.Add(model);
				//db.Items.AddOrUpdate(items.ToArray());
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
		[HttpPut]
		public IHttpActionResult UpdatePost(long id, Post post)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			var postInDb = db.Posts.Include(p => p.Stars).Include(r => r.RestaurantOrPalce.ApplicationUser).Include(p => p.Items).Include(p => p.Tags).Include(p=>p.Photos).First(p => p.Id == id);
			if (postInDb == null)
			{
				return NotFound();
			}
			var reactions = db.Reactions.Where(p => p.PostId == id).ToList();
			var photos = db.Photos.Where(p => p.PostId == id).ToList();
			foreach (var item in photos)
			{
				db.Entry(item).State = EntityState.Deleted;
			}
			var comments = db.PostComments.Where(p => p.PostId == id).ToList();
			postInDb.FoodOrTravel = post.FoodOrTravel;
			postInDb.IsOfferOrPlanned = post.IsOfferOrPlanned;
			postInDb.IsRecommended = post.IsRecommended;
			postInDb.Items = post.Items;
			postInDb.Photos = post.Photos;
			postInDb.PostBody = post.PostBody;
			postInDb.PostTitle = post.PostTitle;
			postInDb.RestaurantOrPalceId = post.RestaurantOrPalceId;
			postInDb.Stars = post.Stars;
			postInDb.Tags = post.Tags;
			
			db.SaveChanges();


			return Ok();
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
			postComment.TimeStamp = DateTime.Now;
			db.PostComments.Add(postComment);
			db.SaveChanges();
			return Created(new Uri(Request.RequestUri + "/" + postComment.Id), postComment);
		}
		[HttpGet]
		public IHttpActionResult GetReaction(long id)
		{
			var post = db.Posts.FirstOrDefault(p => p.Id == id);
			var reactions = db.Reactions.Where(p => p.PostId == post.Id).ToList();
			return Ok(reactions);
		}
		[HttpPost]
		public IHttpActionResult CreateReaction(Reaction reaction)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			db.Reactions.Add(reaction);
			db.SaveChanges();
			return Created(new Uri(Request.RequestUri + "/" + reaction.Id), reaction);

		}
		[HttpPut]
		public IHttpActionResult UpdateReaction(long id,Reaction reaction)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			var reactionInDB = db.Reactions.SingleOrDefault(i => i.Id == id);
			if (reactionInDB == null)
			{
				return NotFound();
			}
			reactionInDB.IsHelpfull = reaction.IsHelpfull;
			reactionInDB.IsLiked = reaction.IsLiked;
			reactionInDB.PostId = reaction.PostId;
			reactionInDB.ApplicationUserId = reaction.ApplicationUserId;
			db.SaveChanges();


			return Ok();
		}
		[HttpDelete]
		public IHttpActionResult DeleteReaction(long id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			var reaction = db.Reactions.SingleOrDefault(i => i.Id == id);
			if (reaction == null)
			{
				return NotFound();
			}
			db.Reactions.Remove(reaction);
			db.SaveChanges();
			return Ok();
		}
		[HttpGet]
		public IHttpActionResult GetRepliesInAComment(long id)
		{
			var replay = db.SubComments.Include(u=>u.ApplicationUser).Where(i => i.PostCommentId == id).ToList();
			return Ok(replay);
		}
		[HttpPost]
		public IHttpActionResult PostAReplayAComment(SubComment subComment)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			subComment.TimeStamp = DateTime.Now;
			db.SubComments.Add(subComment);
			db.SaveChanges();
			return Created(new Uri(Request.RequestUri + "/" + subComment.Id), subComment);
			
		}
		[HttpGet]
		public IHttpActionResult GetACommentReactions(long id)
		{
			var reaction = db.CommentReactions.Where(i => i.PostCommentId == id).ToList();
			if (reaction == null)
			{
				return NotFound();
			}
			return Ok(reaction);
		}
		[HttpGet]
		public IHttpActionResult GetACommentReaction(long id)
		{
			var reaction = db.CommentReactions.Where(i => i.Id == id).FirstOrDefault();
			if(reaction==null)
			{
				return NotFound();
			}
			return Ok(reaction);
		}
		[HttpPost]
		public IHttpActionResult PostACommentReaction(CommentReaction commentReaction)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			db.CommentReactions.Add(commentReaction);
			db.SaveChanges();
			return Created(new Uri(Request.RequestUri + "/" + commentReaction.Id), commentReaction);
		}
		[HttpGet]
		public IHttpActionResult GetAReplyReactions(long id)
		{
			var reaction = db.ReplyReactions.Where(i => i.SubCommentId == id).ToList();
			if (reaction == null)
			{
				return NotFound();
			}

			return Ok(reaction);
		}
		[HttpGet]
		public IHttpActionResult GetAReplyReaction(long id)
		{
			var reaction = db.ReplyReactions.Where(i => i.Id == id).FirstOrDefault();
			if(reaction==null)
			{
				return NotFound();
			}

			return Ok(reaction);
		}
		[HttpPost]
		public IHttpActionResult PostAReplyReaction(ReplyReaction replyReaction)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			db.ReplyReactions.Add(replyReaction);
			db.SaveChanges();
			return Created(new Uri(Request.RequestUri + "/" + replyReaction.Id), replyReaction);
		}
	}
}
