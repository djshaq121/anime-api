namespace WebApi.Entities
{
    public class Anime
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string EnglishTitle { get; set; }
        public int? Episode { get; set; }
        public string? MediaGenre { get; set; }
        public string? Status { get; set; }
        public string? BroadcastDay { get; set; }
        public TimeSpan? BroadcastTime { get; set; }
    }
}
