using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Post
    {
        public string DisplayAs { get; set; }
        public string ElementValue { get; set; }

        public Post(string displayAs, string elementValue)
        {
            DisplayAs = displayAs;
            ElementValue = elementValue;
        }
    }
}
