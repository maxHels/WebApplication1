using AngleSharp.Parser.Html;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
    public class HTMLParser
    {
        public List<PostTitle> GetPostTitle(string HTML)
        {
            List<PostTitle> posts = new List<PostTitle>();

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(HTML);

            var postsLists = htmlDoc.DocumentNode.Descendants("ul")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("post-list")).ToList();
            List<HtmlNode> postsInUl = new List<HtmlNode>();

            foreach(var ul in postsLists)
            {
                var postList = htmlDoc.DocumentNode.Descendants("article").ToList();
                foreach(var p in postsLists)
                {
                    postsInUl.Add(p);
                }
            }

            foreach(var p in postsInUl)
            {
                string src = p.Descendants("img").ToList()[0].GetAttributeValue("src", "");
                string title = p.Descendants("header").ToList()[0]
                    .Descendants("a").ToList()[0]
                    .GetAttributeValue("title", "");
                string url = p.Descendants("a").ToList()[0].GetAttributeValue("href", "");
                var posted = p.Descendants("header").ToList()[0]
                    .Descendants("span").ToList()[0]
                    .InnerText;
                posts.Add(new PostTitle(title, src, posted, url));
            }

            return posts;
        }
    }
}
