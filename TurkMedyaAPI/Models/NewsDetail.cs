namespace TurkMedyaAPI.Models
{
    public class NewsDetail
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public DetailData Data { get; set; }
    }

    public class DetailData
    {
        public NewsItem NewsDetail { get; set; }
    }
}
