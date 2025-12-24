using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using WebSport24hNews.Application.Command.Modell._24hVideos;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hVideos
{
    public class Create24hVideoCommandAdmin : ICommandBase<decimal>
    {
        public CreateVideoCommand videoCommand { get; set;}
    }
    public class Create24hVideoCommandAdminHandler : IRequestBaseHandler<Create24hVideoCommandAdmin, decimal>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Create24hVideoCommandAdminHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<decimal> Handle(Create24hVideoCommandAdmin request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new BaseException("Yêu cầu không hợp lệ!");

            var userId = _authorizeExtension.GetUser().Id;

            var videoId = ExtractVideoId(request.videoCommand.YoutubeUrl);
            if (string.IsNullOrEmpty(videoId))
                throw new BaseException("YoutubeUrl không hợp lệ!");

            // Kiểm tra tồn tại video (chạy tuần tự)
            var existed = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<Video>(
                v => v.EmbedUrl != null && v.EmbedUrl.Contains(videoId), cancellationToken);

            if (existed != null)
                throw new BaseException("Video đã tồn tại trong hệ thống!");

            // Chuẩn bị đối tượng Video
            var video = _mapper.Map<Video>(request.videoCommand);
            video.EmbedUrl = $"https://www.youtube.com/embed/{videoId}";
            video.ThumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
            video.Slug = GenerateSlug(request.videoCommand.Title);
            video.ViewCount = 0;
            video.CreateBy = userId;
            video.CreateDate = Extension.Now();

            // Thêm video và SaveChanges tuần tự
            await _repositoryService.AddAsync(video, cancellationToken);
            var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;

            if (!saveResult)
                throw new BaseException("Lưu video thất bại");

            return video.Id;
        }



        private string? ExtractVideoId(string url)
        {
            var regex = new Regex(@"(?:youtu\.be\/|youtube\.com\/watch\?v=)([a-zA-Z0-9_-]{11})");
            var match = regex.Match(url);
            return match.Success ? match.Groups[1].Value : null;
        }


        private string GenerateSlug(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return "";

            // 1. Loại bỏ dấu tiếng Việt
            string normalized = title.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var c in normalized)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            // 2. Chuyển thành slug
            string slug = sb.ToString().ToLower();
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", ""); // Loại bỏ ký tự đặc biệt
            slug = Regex.Replace(slug, @"\s+", "-");         // Chuyển khoảng trắng thành dấu gạch ngang
            slug = Regex.Replace(slug, @"-+", "-");          // Loại bỏ dấu gạch ngang lặp

            slug = slug.Trim('-');

            // 3. Ghép với định danh ID ngẫu nhiên
            var id = new Random().Next(100000, 999999);
            return $"{id}-{slug}-d{id}.html";
        }
    }
}
