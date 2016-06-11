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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var shops = await new AllShopsQuery(_conn).Run();
            return View(shops.OrderByDescending(s => s.TotalLikes));
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(Shop shop)
        {
            if (!this.ModelState.IsValid)
            {
                return View();
            }

            shop.ImageContainer = Guid.NewGuid().ToString("N");
            shop.CreatedAt = DateTimeOffset.UtcNow;
            shop.CreatedBy = User.Identity.Name;

            var saved = await new SaveNewShopAction(_conn).RunAsync(shop);
            if (saved < 1)
            {
                return StatusCode(500);
            }

            TempData["alert-msg"] = string.Format("New Shop ({0}) is saved successfully.", shop.Name);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Shop shop)
        {
            if (!this.ModelState.IsValid)
            {
                ViewBag.Id = shop.Id;
                return View();
            }

            var saved = await new UpdateShopAction(_conn).RunAsync(shop);
            if (saved < 1)
            {
                return StatusCode(500);
            }

            TempData["alert-msg"] = string.Format("Shop ({0}) is updated successfully.", shop.Name);

            return RedirectToAction("Index");

        }
    }
}
