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
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostTitle>>> Get()
        {
            /*List<string> PostTitles = new List<string>();
            List<string> PostContent = new List<string>();
            List<string> PostImages = new List<string>();
            List<PostTitle> Titles = new List<PostTitle>(); 

            DBCommandsExecutor executor = new DBCommandsExecutor();
            //PostContent = (List<string>)executor.GetStringListResult("SELECT * FROM wp_posts WHERE post_status='publish' AND post_type='post' LIMIT 30;", "post_content");
            PostTitles = (List<string>)executor.GetStringListResult("SELECT * FROM wp_posts WHERE post_status='publish' AND post_type='post' LIMIT 30;", "post_title");

            /*foreach(var cont in PostContent)
            {
                var titleUrl = new HTMLParser().GetPostTitle(cont);
                PostImages.Add(titleUrl);
            }

            for(int i = 0; i < PostTitles.Count; i++)
            {
                Titles.Add(new PostTitle(PostTitles[i], PostImages[i]));
            }

            //var htmlParser = new HTMLParser();
            //htmlParser.GetPostTitle(PostContent[1]);

            PostImages = (List<string>)executor.GetStringListResult("SELECT * FROM wp_posts WHERE post_status='publish' AND post_type='post' LIMIT 30;", "post_title");

            return Titles;*/

            var url = "http://35.196.212.207/";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var postsTemlates = new HTMLParser().GetPostTitle(html);
            return postsTemlates;
        }

        [HttpGet("GetTitles")]
        public ActionResult<IEnumerable<string>> GetTitles(int count)
        {
            List<string> titles = new List<string>();
            DBCommandsExecutor executor = new DBCommandsExecutor();
            titles = (List<string>)executor.GetStringListResult("SELECT * FROM wp_posts WHERE post_status='publish' AND post_type='post' LIMIT "+count.ToString()+";", "post_title");
            return titles;
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
