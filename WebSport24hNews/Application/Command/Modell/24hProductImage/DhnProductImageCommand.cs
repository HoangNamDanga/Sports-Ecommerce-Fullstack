namespace WebSport24hNews.Application.Command.Handlerr._24hProductImage
{
    //Không dùng đối với upload ảnh và create ảnh
    public class DhnProductImageCommand
    {
        public decimal Id { get; set; }


        public decimal? ProductId { get; set; }


        public string? ImageUrl { get; set; }


        public string? IsThumbnail { get; set; }


        public decimal? DisplayOrder { get; set; }


        public string? AltText { get; set; }

        public string? Attribute1 { get; set; }

        public string? Attribute2 { get; set; }

        public decimal CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal? LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
