﻿using TurkMedyaAPI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TurkMedyaAPI.Services
{
    public class NewsService : INewsService
    {
        private readonly HttpClient _httpClient;

        public NewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<NewsItem>> GetNewsItems(int page, int pageSize, string category, string keyword) //HomeControllerdan gelen isteğe göre anahtar ya da kategori girildiyse onları filtreliyorum ve sayfa geçişi için kullanıyorum.
        {
            var response = await _httpClient.GetStringAsync("https://www.turkmedya.com.tr/anasayfa.json");
            var newsData = JsonConvert.DeserializeObject<NewsData>(response);

            var filteredNews = newsData.Data[0].ItemList;

            if (!string.IsNullOrEmpty(category))
            {
                filteredNews = filteredNews.FindAll(n => n.Category.Title.Equals(category, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                filteredNews = filteredNews.FindAll(n => n.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase));
            }

            return filteredNews
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public async Task<NewsItem> GetNewsDetail(string itemId) //HomeControllerdan gelen isteğe göre ilgili detayı buluyor eğer yoksa null gönderiyor.
        {
            var response = await _httpClient.GetStringAsync("https://www.turkmedya.com.tr/detay.json");
            var newsDetail = JsonConvert.DeserializeObject<NewsDetail>(response);

            if (newsDetail.Data.NewsDetail.ItemId == itemId)
            {
                return newsDetail.Data.NewsDetail;
            }
            return null;
        }

    }
}
