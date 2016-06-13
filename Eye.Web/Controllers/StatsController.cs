using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Eye.Web.Models;
using Microsoft.AspNetCore.Mvc;


namespace Eye.Web.Controllers
{
    public class StatsController : Controller
    {
        IDbConnection _conn;
        public StatsController(IDbConnection conn)
        {
            _conn = conn;
        }

        public async Task<IActionResult> PriceRange()
        {
            var data = await new PriceRangeQuery(_conn).RunAsync(minPrice: 2999, maxPrice: 30000);
            return Json(data);
        }
    }
}
