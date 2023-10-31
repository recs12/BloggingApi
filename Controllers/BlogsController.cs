using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggingApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly BloggingContext _context;

        public BlogsController(BloggingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            return _context.Blogs.ToList();
        }

        [HttpPost]
        public ActionResult<Blog> Post(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = blog.BlogId }, blog);
        }
    }
}



