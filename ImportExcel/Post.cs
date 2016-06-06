using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportExcel
{
    public class Post
    {
        public int Id { get; set; }

        public string ShopName { get; set; }

        public string ItemName { get; set; }

        public DateTime PostedDate { get; set; }

        public int TotalLikes { get; set; }

        public int Shares { get; set; }

        public int Price { get; set; }

        public int PreOrderDays { get; set; }

        public string PhotoName { get; set; }

        public string PostURL { get; set; }

    }
}
