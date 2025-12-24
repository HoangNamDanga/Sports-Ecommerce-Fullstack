namespace WebSport24hNews.Application.Command.Modell.Account
{
    public class LoginUser24hResponse
    {
        public bool IsAuthenticated { get; set; }
        public string Message { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public string? Fullname { get; set; }
    }
}
