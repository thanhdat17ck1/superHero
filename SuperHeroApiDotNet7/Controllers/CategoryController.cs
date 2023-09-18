using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SuperHeroApiDotNet7.Entity.Blog;
using SuperHeroApiDotNet7.Models;
using System.Net.WebSockets;

namespace SuperHeroApiDotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;
        public CategoryController(DataContext context) {
            _context = context;
        }

        [HttpPost("SaveCategory")]
        public ActionResult SaveCategory(CategoryEntity request)
        {           
            CategoryModel model = new CategoryModel(_context);
            var result = model.PostCategory(request);
            return Ok(200);
        }

        [HttpPost("SavePost")]
        public ActionResult SavePost(PostEntity request)
        {
            PostModel model = new PostModel(_context);
            var result = model.SavePost(request);
            return Ok(200);
        }

    }
}
