using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.Web
{
    public class Shop
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TotalLikes { get; set; }

        public DateTimeOffset LastPostedDate { get; set; }

        public bool IsPreOrder { get; set; }

        public bool IsOnStock { get; set; }

        public bool IsPrePaid { get; set; }

        public string PageURL { get; set; }

        public string ImageContainer { get; set; }
    }
}
