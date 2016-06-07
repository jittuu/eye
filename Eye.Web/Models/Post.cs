using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.Web
{
    public class Post
    {
        private static string _blobContainerPath = "https://kanoakstats.blob.core.windows.net/images";

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

        public string ImageContainer { get; set; }

        public string PhotoFullPath()
        {
            return string.Format("{0}/{1}/{2}.jpg", _blobContainerPath, ImageContainer, PhotoName);
        }
    }
}
