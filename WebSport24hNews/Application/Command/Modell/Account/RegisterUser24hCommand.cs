using System.ComponentModel.DataAnnotations;

namespace WebSport24hNews.Application.Command.Modell.Account
{
    public class RegisterUser24hCommand
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage ="First name must be at least {2}, and maxium {1} characters")]
        public string Username { get; set; }
        public string Password { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Full name must be at least {2}, and maxium {1} characters")]
        public string? Fullname { get; set; }
        public string? Phone { get; set; } // Thêm Phone nếu cần
        public string? Role { get; set; } = "User"; // Mặc định là User
    }
}
