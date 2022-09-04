using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Newtonsoft.Json;

namespace WebApi.Entities
{

    public class AnimeSearch
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string EnglishTitle { get; set; }
        public int? Episode { get; set; }
        public string? MediaGenre { get; set; }
        public string? Status { get; set; }
        public string? BroadcastDay { get; set; }
        public TimeSpan? BroadcastTime { get; set; }
    }
    public class Anime
    {
       // [SimpleField(IsKey = true, IsFilterable = true)]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        
        public string? EnglishTitle { get; set; }
        
        public int? Episode { get; set; }
        public string? MediaGenre { get; set; }
        public string? Status { get; set; }
        public string? BroadcastDay { get; set; }
        public TimeSpan? BroadcastTime { get; set; }
    }
}
