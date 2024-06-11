using Microsoft.AspNetCore.Mvc;
using TurkMedyaAPI.Services;
using System.Threading.Tasks;

namespace TurkMedyaAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsService _newsService;

        public HomeController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IActionResult> Index(int page = 1, string category = "", string keyword = "") // Bu mettotta sayfa geçişleri ve ilgili kategorileri, anahtar kelimeyi Index kısmından gönderip Servis katmanına iletiyorum.
        {
            int pageSize = 5;
            var newsItems = await _newsService.GetNewsItems(page, pageSize, category, keyword);
            ViewBag.CurrentPage = page;
            ViewBag.Category = category;
            ViewBag.Keyword = keyword;
            return View(newsItems);
        }

        public async Task<IActionResult> Detail(string id) //Bu metotta Index.cshtml kısmında tıklanan haberin itemIdsini alıp Servis katmanındaki ilgili metoda gönderiyorum.
        {
            var newsDetail = await _newsService.GetNewsDetail(id);
            return View(newsDetail);
        }
    }
}
