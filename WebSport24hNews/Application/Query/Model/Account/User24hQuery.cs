namespace WebSport24hNews.Application.Query.Model.Account
{
    public class User24hQuery
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
