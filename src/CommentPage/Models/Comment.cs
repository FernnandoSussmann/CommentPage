using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentPage.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Commentary { get; set; }
        public int Main { get; set; }

    }
}
