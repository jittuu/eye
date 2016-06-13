using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Eye.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Eye.Web.Controllers
{
    public class PostsController : Controller
    {
        IDbConnection _conn;
        AzureStorageOption _azureStorageOption;

        public PostsController(IDbConnection conn, IOptions<AzureStorageOption> azureStorageOption)
        {
            _conn = conn;
            _azureStorageOption = azureStorageOption.Value;
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

        [HttpGet]
        public IActionResult New(int shopId)
        {
            ViewBag.shopId = shopId;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(Post post, int shopId, IFormFile photoUpload)
        {
            if (!this.ModelState.IsValid)
            {
                return View();
            }

            var shop = await _conn.GetShopByIdAsync(shopId);

            post.ShopId = shopId;
            post.ShopName = shop.Name;

            if(photoUpload != null)
            {
                post.ImageContainer = shop.ImageContainer;
                post.PhotoName = Guid.NewGuid().ToString("N");
                var ext = photoUpload.FileName.Split('.').Last();
                var upload = new UploadFileToBlobAction() {
                    ConnectionString = _azureStorageOption.ConnectionString,
                    FileName = post.ImageContainer + "/" + post.PhotoName + "." + ext,
                    File = photoUpload
                };

                await upload.RunAsync();
            }

            var saved = await new SaveNewPostAction(_conn).RunAsync(post);
            if (saved < 1)
            {
                return StatusCode(500);
            }

            return RedirectToAction("Details", "Shops", new { id = shopId });
        }
    }
}
