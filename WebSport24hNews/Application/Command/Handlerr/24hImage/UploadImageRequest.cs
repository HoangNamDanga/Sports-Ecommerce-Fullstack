using System.ComponentModel.DataAnnotations;

namespace WebSport24hNews.Application.Command.Handlerr._24hImage
{
    public class UploadImageRequest
    {
        [Required]
        public IFormFile File { get; set; }
    }
}
