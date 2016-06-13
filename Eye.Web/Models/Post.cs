using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.Web.Models
{
    public class Post
    {
        private static string _blobContainerPath = "https://kanoakstats.blob.core.windows.net/images";

        public int Id { get; set; }

        public int ShopId { get; set; }

        public string ShopName { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public DateTime PostedDate { get; set; }

        [Required]
        public int TotalLikes { get; set; }

        [Required]
        public int Shares { get; set; }

        [Required]
        public int Price { get; set; }

        public int PreOrderDays { get; set; }

        public string PhotoName { get; set; }

        [Required]
        public string PostURL { get; set; }

        public string ImageContainer { get; set; }

        public string PhotoFullPath()
        {
            return string.Format("{0}/{1}/{2}.jpg", _blobContainerPath, ImageContainer, PhotoName);
        }
    }
}
