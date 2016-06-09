using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Eye.Web.Models;
using System.Data;

namespace Eye.Web.Controllers
{
    public class ShopsController : Controller
    {
        private IDbConnection _conn;
        public ShopsController(IDbConnection conn)
        {
            _conn = conn;
        }

        public async Task<IActionResult> Index()
        {
            var shops = await new AllShopsQuery(_conn).Run();
            return View(shops.OrderByDescending(s => s.TotalLikes));
        }
    }
}
