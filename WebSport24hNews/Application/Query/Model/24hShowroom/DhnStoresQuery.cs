using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Model._24hStore
{
    public class DhnStoresQuery
    {

        public decimal Id { get; set; }

        public string? StoreName { get; set; }


        public string? Address { get; set; }


        public string? PhoneNumber { get; set; }


        public string? Attribute1 { get; set; } // location vị trí cửa hàng vD: HN HCM

    }
}
