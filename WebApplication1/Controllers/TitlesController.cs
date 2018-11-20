using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostTitle>>> Get()
        {
            var url = "http://35.196.212.207/";

            var postsTemlates = await new HTMLParser().GetAllPostTitleAsync(url);
            return postsTemlates;
        }

        [HttpGet("getByTag")]
        public async Task<ActionResult<IEnumerable<PostTitle>>> GetTitlesByTagAsync(string category)
        {
            string url = "http://35.196.212.207/tag/" + category;
            var postsTemlates = await new HTMLParser().GetPostTitlesByTagAsync(url);
            return postsTemlates;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
