using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ListInPost:Post
    {
        public List<string> Items;

        public ListInPost(string displayAs, string elementValue, List<string> items) : base(displayAs, elementValue)
        {
            Items = items;
        }
    }
}
