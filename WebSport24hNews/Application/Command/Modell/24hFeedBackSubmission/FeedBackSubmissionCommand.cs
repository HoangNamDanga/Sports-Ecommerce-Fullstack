using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSport24hNews.Application.Command.Modell._24hFeedBackSubmission
{
    public class FeedBackSubmissionCommand
    {

        public decimal Id { get; set; }


        public string? FullName { get; set; }


        public string? Email { get; set; }


        public string? FeedbackContent { get; set; }


        public string? Status { get; set; }


        public decimal CreateBy { get; set; }


        public DateTime CreateDate { get; set; }


        public decimal? LastUpdateBy { get; set; }


        public DateTime LastUpdateDate { get; set; }


        public decimal? VideoId { get; set; }


        public decimal? ArticleId { get; set; }
    }
}
