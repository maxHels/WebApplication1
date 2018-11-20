using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class PageLoader
    {
        public async Task<HtmlDocument> LoadHtmlDocumentAsync(string URL)
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(URL);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            return htmlDoc;
        } 
    }
}
