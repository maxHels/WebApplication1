using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
    public class PostParser
    {
        public async Task<List<Post>> PostsAsync(string URL)
        {
            List<Post> posts = new List<Post>();

            var htmlDoc = await new PageLoader().LoadHtmlDocumentAsync(URL);

            var postsLists = htmlDoc.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("post-content hr-bold")).ToList();
            var elements = postsLists[0].ChildNodes.ToList();
            foreach(var el in elements)
            {
                if (el.OriginalName != "#text" && el.OriginalName != "#comment")
                {
                    if (el.OriginalName == "figure")
                    {
                        if (el.InnerHtml.Contains("img"))
                        {
                            string src = el.Descendants("img").ToList()[0].GetAttributeValue("src", "");
                            posts.Add(new Post("image", src));
                        }
                    }
                    else if(el.OriginalName == "p" && el.InnerHtml.Contains("img"))
                    {
                        if(el.InnerText!="")
                            posts.Add(new Post(el.OriginalName, el.InnerText));
                        string src = el.Descendants("img").ToList()[0].GetAttributeValue("src", "");
                        posts.Add(new Post("image", src));
                    }
                    else
                    {
                        posts.Add(new Post(el.OriginalName, el.InnerHtml));
                    }
                }
            }

            return posts;
        }
    }
}
