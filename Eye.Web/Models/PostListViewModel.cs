using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eye.Web.Models
{
    public class PostListViewModel
    {
        public IEnumerable<Post> Posts { get; set; }

        public int? NextPage { get; set; }

        public int? PrevPage { get; set; }
    }
}