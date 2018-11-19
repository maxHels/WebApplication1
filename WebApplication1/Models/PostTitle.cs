using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PostTitle
    {
        public string Title { get; set; }
        public string PhotoURL { get; set; }
        public string Published { get; set; }
        public string URL { get; set; }

        public PostTitle(string title, string photoURL, string published, string url)
        {
            Title = title;
            PhotoURL = photoURL;
            Published = published;
            URL = url;
        }
    }
}
