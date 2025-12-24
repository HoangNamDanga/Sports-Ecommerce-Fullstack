using Dapper;
using System.Data;

namespace WebSport24hNews.HoangNam.Core.Infrastructure
{
    public interface IDapperCore : IDisposable
    {
        Task<T1> QueryFirstOrDefaultAsync<T1>(string sp = "", object parms = null, CommandType commandType = CommandType.Text);

        T1 QueryFirst<T1>(string sp = "", object parm = null, CommandType commandType = CommandType.Text);

        Task<IEnumerable<T1>> QueryAsync<T1>(string sp = "", object parms = null, CommandType commandType = CommandType.Text, int commandTimeout = 0);

        IEnumerable<T1> Query<T1>(string sp = "", object parms = null, CommandType commandType = CommandType.Text);

        Task<SqlMapper.GridReader> QueryMultipleAsync(string sp = "", object parms = null, CommandType commandType = CommandType.Text);

        SqlMapper.GridReader QueryMultiple(string sp = "", object parms = null, CommandType commandType = CommandType.Text);

        Task<int> ExecuteAsync(string sql, object parameters = null, CommandType commandType = CommandType.Text); // ✅ Thêm dòng này

        Task<T> TransactionSmartDapperAwaitAsync<T>(Func<Task<T>> func, CancellationToken cancellationToken = default, bool configure = false);
    }
}
