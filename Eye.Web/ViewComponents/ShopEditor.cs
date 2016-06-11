using System.Data;
using System.Threading.Tasks;
using Eye.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eye.Web.ViewComponents
{
    public class ShopEditor : ViewComponent
    {
        IDbConnection _conn;
        public ShopEditor(IDbConnection conn)
        {
            _conn = conn;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {
            if(id != null)
            {
                var shop = await _conn.GetShopByIdAsync(id.Value);

                ViewBag.action = "Edit";
                return View(shop);
            }

            ViewBag.action = "New";
            return View();
        }
    }
}
