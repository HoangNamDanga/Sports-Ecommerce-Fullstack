using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSport24hNews.Application.Query.Model.PremierLeagueStanding
{
    public class PremierLeaguesModel
    {
        public decimal TeamId { get; set; }  // Giữ nguyên vì decimal có thể chứa giá trị lớn và chính xác

        public byte? RankPosition { get; set; }  // Giữ nguyên, RankPosition thường là một số dương nhỏ

        public string TeamName { get; set; } = null!;  // Giữ nguyên

        public short? MatchesPlayed { get; set; }  // Sửa từ byte? thành short? để có thể chứa số lớn hơn (trong trường hợp số trận rất cao)

        public short? Wins { get; set; }  // Sửa từ byte? thành short? vì có thể có số thắng lớn

        public short? Draws { get; set; }  // Sửa từ byte? thành short? vì có thể có số hòa lớn

        public short? Losses { get; set; }  // Sửa từ byte? thành short? vì có thể có số thua lớn

        public short? GoalsFor { get; set; }  // Sửa từ byte? thành short? vì số bàn thắng có thể lớn

        public short? GoalsAgainst { get; set; }  // Sửa từ byte? thành short? vì số bàn thua có thể lớn

        public short? GoalDifference { get; set; }  // Sửa từ byte? thành short? để có thể chứa giá trị âm

        public short? Points { get; set; }  // Sửa từ byte? thành short? vì điểm số có thể lớn hơn byte
    }
}
