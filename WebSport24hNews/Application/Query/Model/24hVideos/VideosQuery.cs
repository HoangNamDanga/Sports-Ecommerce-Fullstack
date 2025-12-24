using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Model._24hVideos
{
    public class VideosQuery
    {
        public decimal Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string? EmbedUrl { get; set; }

        public string? ThumbnailUrl { get; set; }

        public decimal? TeamId { get; set; }

        public decimal? LeagueId { get; set; }

        public decimal? AuthorId { get; set; }

        public string? Duration { get; set; }

        public DateTime? PublishedAt { get; set; }

        public string? Slug { get; set; }

        public decimal? ViewCount { get; set; }

        public decimal CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal? LastUpdateBy { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
