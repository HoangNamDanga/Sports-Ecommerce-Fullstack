using System.ComponentModel.DataAnnotations;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hImage
{
    public class UploadProductImageDTO
    {
        public decimal Id { get; set; }
        [Required]
        public decimal ProductId { get; set; }
        [Required]
        public IFormFile Image { get; set; } = default!;
        public bool IsThumbnail { get; set; } = false;
        public decimal? DisplayOrder { get; set; }
        public string? AltText { get; set; }
    }
}
