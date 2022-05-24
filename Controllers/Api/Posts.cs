using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VulnerableWebApp.Models;

namespace VulnerableWebApp.Controllers.Api
{
    [ApiController]
    [Route("/api/posts")]
    public class Posts : ControllerBase
    {
        private readonly BlogContext _context;

        public Posts(BlogContext context)
        {
            _context = context;
        }

        public IQueryable<Post> GetPosts()
        {
            return _context.Posts;
        }

        [HttpGet("{id}")]
        public Post GetPost(string id)
        {
            return _context.Posts.FromSqlRaw("Select * from Posts where Id = " + id).FirstOrDefault();
        }
        
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post post)
        {
            Console.WriteLine("POSTing here");
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }
    }
}
