namespace WebSport24hNews.Application.Command.Modell.Account
{
    public class RefreshTokenResponse
    {
        public string AccessToken { get; set; }
        public string? fullName { get; set; }
        public string? RefreshToken { get; set; } // Có thể trả về Refresh Token mới (Rotation)
    }
}
