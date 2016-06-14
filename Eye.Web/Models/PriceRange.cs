using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eye.Web.Models
{
    public class PriceRange
    {
        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }

        public string Range => string.Format("{0}k-{1}k", MinPrice/1000, (MaxPrice + 1)/1000);

        public int Total { get; set; }
    }
}
