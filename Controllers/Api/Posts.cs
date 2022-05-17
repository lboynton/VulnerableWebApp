using System.Linq;
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
    }
}
