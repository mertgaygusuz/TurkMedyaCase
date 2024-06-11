using System.Collections.Generic;

namespace TurkMedyaAPI.Models
{
    public class NewsData
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public List<Section> Data { get; set; }
    }

    public class Section
    {
        public string SectionType { get; set; }
        public string RepeatType { get; set; }
        public int ItemCountInRow { get; set; }
        public bool LazyLoadingEnabled { get; set; }
        public bool TitleVisible { get; set; }
        public string Title { get; set; }
        public string TitleColor { get; set; }
        public string TitleBgColor { get; set; }
        public string SectionBgColor { get; set; }
        public List<NewsItem> ItemList { get; set; }
        public int TotalRecords { get; set; }
    }
}
