using System.Runtime.Serialization;

namespace WebSport24hNews.HoangNam.Core.Infrastructure
{
    public class BaseSearchModel
    {
        [DataMember]
        public string? KeySearch { get; set; }

        [DataMember]
        public string? Sort { get; set; }

        [DataMember]
        public bool? IsOrder { get; set; } = true;


        [DataMember]
        public bool? Active { get; set; }

        [DataMember]
        public int Skip { get; set; }

        [DataMember]
        public int Take { get; set; }

        [DataMember]
        public bool isAll { get; set; } = false;
    }
}
