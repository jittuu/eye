using System.Data;
using System.Threading.Tasks;
using Eye.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eye.Web.ViewComponents
{
    public class PostList : ViewComponent
    {
        IDbConnection _conn;
        public PostList(IDbConnection conn)
        {
            _conn = conn;
        }

        public async Task<IViewComponentResult> InvokeAsync(int shopId)
        {
            var posts = await new AllPostByShopIdQuery(_conn).Run(shopId);
            return View(posts);
        }
    }
}
