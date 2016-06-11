using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.Web.Models
{
    public class Shop
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int TotalLikes { get; set; }

        [Required]
        public DateTimeOffset LastPostedDate { get; set; }

        public bool IsPreOrder { get; set; }

        public bool IsOnStock { get; set; }

        public bool IsPrePaid { get; set; }

        [Required]
        public string PageURL { get; set; }

        public string ImageContainer { get; set; }

        public int TotalPosts { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string CreatedBy { get; set; }

    }
}
