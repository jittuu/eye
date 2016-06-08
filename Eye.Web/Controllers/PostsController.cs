using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Eye.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eye.Web.Controllers
{
    public class PostsController : Controller
    {
        IDbConnection _conn;

        public PostsController(IDbConnection conn)
        {
            _conn = conn;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var pageNo = page ?? 1;
            var pageSize = 50;

            var posts = await new AllPostQuery(_conn).Run();
            var pageCount = (int)posts.Count() / pageSize;
            var vm = new PostListViewModel() { Posts = posts.Skip((pageNo - 1) * pageSize).Take(pageSize) };
            if (pageNo > 1)
            {
                vm.PrevPage = pageNo - 1;
            }
            if (pageCount > pageNo)
            {
                vm.NextPage = pageNo + 1;
            }

            return View(vm);
        }
    }
}
