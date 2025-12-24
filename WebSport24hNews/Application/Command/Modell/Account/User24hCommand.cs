using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Modell.Account
{
    public class User24hCommand
    {
        public decimal Id { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public bool? Inactive { get; set; }

        public string? Role { get; set; }

        public string? Phone { get; set; }

        public string? Fullname { get; set; }

        public DateTime? Modifydate { get; set; }

        public string? Modifyby { get; set; }

        public DateTime? Createdate { get; set; }
        public string? Createby { get; set; }

        public string? Tokenactive { get; set; }

        public DateTime? Dateactive { get; set; }

        public string? Codeactive { get; set; }

        public DateTime? Datecodeactive { get; set; }

        public string? Center { get; set; }

        public bool? Addgoogle { get; set; }

        public decimal? Empid { get; set; }
    }
}
