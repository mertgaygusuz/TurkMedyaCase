using System;

namespace TurkMedyaAPI.Models
{
    public class NewsItem
    {
        public string ItemId { get; set; }
        public string Title { get; set; }
        public string ShortText { get; set; }
        public string FullPath { get; set; }
        public string ImageUrl { get; set; }
        public string PublishDate { get; set; }
        public Category Category { get; set; }
    }

    public class Category
    {
        public string CategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
    }
}
