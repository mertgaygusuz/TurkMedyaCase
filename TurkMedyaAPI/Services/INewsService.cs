using TurkMedyaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TurkMedyaAPI.Services
{
    public interface INewsService
    {
        Task<List<NewsItem>> GetNewsItems(int page, int pageSize, string category, string keyword);
        Task<NewsItem> GetNewsDetail(string itemId);
    }
}
