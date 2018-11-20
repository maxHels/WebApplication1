using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> Get(string pageGuid)
        {
            var url = "http://35.196.212.207/"+pageGuid;

            var postsTemlates = await new PostParser().PostsAsync(url);
            return postsTemlates;
        }
    }
}