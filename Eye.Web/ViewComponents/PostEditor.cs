using System;
using System.Data;
using System.Threading.Tasks;
using Eye.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eye.Web.ViewComponents
{
    public class PostEditor : ViewComponent
    {
        IDbConnection _conn;
        public PostEditor(IDbConnection conn)
        {
            _conn = conn;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {
            if(id != null)
            {
                var post = await _conn.GetPostByIdAsync(id.Value);
                post.PostedDateStr = post.PostedDate.ToString("dd-MM-yy");

                ViewBag.action = "Edit";
                return View(post);
            }

            ViewBag.action = "New";
            return View();
        }
    }
}
