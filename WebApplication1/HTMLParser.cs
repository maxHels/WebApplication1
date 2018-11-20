using AngleSharp.Parser.Html;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
    public class HTMLParser
    {
        public List<PostTitle> GetAllPostTitle(string HTML)
        {
            List<PostTitle> posts = new List<PostTitle>();

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(HTML);
            var postsLists = htmlDoc.DocumentNode.Descendants("ul")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("post-list")).ToList();
            posts = GetPosts(postsLists);

            return posts;
        }

        /*public async Task<List<PostTitle>> GetPostTitlesByTagAsync(string URL)
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(URL);


        }

        private List<PostTitle> GetBigPostTitles(HtmlDocument doc)
        {

        }*/

        private List<PostTitle> GetPosts(List<HtmlNode> postsList)
        {
            List<HtmlNode> postsInUl = new List<HtmlNode>();
            List<PostTitle> posts = new List<PostTitle>();

            postsInUl = PostsInUls(postsList);

            posts = getPost(postsInUl);

            return posts;
        }

        private List<HtmlNode> PostsInUls(List<HtmlNode> uls)
        {
            List<HtmlNode> postsInUl = new List<HtmlNode>();
            foreach (var ul in uls)
            {
                foreach (var article in ul.Descendants("article").ToList())
                {
                    postsInUl.Add(article);
                }
            }
            return postsInUl;
        }

        private List<PostTitle> getPost(List<HtmlNode> postsInUl)
        {
            List<PostTitle> posts = new List<PostTitle>();

            foreach (var p in postsInUl)
            {
                string src = "";
                var img = p.Descendants("img").ToList();
                if(img.Count != 0)
                    src = img[0].GetAttributeValue("src", "");
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
