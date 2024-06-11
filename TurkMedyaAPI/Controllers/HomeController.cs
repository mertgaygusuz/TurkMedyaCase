using Microsoft.AspNetCore.Mvc;
using TurkMedyaAPI.Services;
using System.Threading.Tasks;

namespace TurkMedyaAPI.Controllers
{
    public class HomeController: Controller
    {
        private readonly INewsService _newsService;

        public HomeController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IActionResult> Index(int page = 1, string category = "", string keyword = "")
        {
            int pageSize = 5;
            var newsItems = await _newsService.GetNewsItems(page, pageSize, category, keyword);
            ViewBag.CurrentPage = page;
            ViewBag.Category = category;
            ViewBag.Keyword = keyword;
            return View(newsItems);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var newsItem = await _newsService.GetNewsDetail(id);
            return View(newsItem);
        }
    }
}
