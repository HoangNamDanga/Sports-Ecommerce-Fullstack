using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Data.Common;
using System.Linq.Expressions;
using WebSport24hNews.HoangNam.Core.Infrastructure;

namespace WebSport24hNews.HoangNam.Service.Repository
{
    public interface IRepositoryService : IDapperCore, IDisposable
    {
        IQueryable<T> Table<T>() where T : class, IAggregateRoot;

        IQueryable<T> Where<T>(Expression<Func<T, bool>> predicate) where T : class, IAggregateRoot;

        IQueryable<T> WhereTracking<T>(Expression<Func<T, bool>> predicate) where T : class, IAggregateRoot;

        Task<T> AddAsync<T>(T entity, CancellationToken cancellationToken = default(CancellationToken)) where T : class, IAggregateRoot;

        EntityEntry<T> Update<T>(T entity) where T : class, IAggregateRoot;

        void Update<T>(IEnumerable<T> entity) where T : class, IAggregateRoot;

        EntityEntry<T> Delete<T>(T entity) where T : class, IAggregateRoot;

        void Delete<T>(IEnumerable<T> entity) where T : class, IAggregateRoot;

        Task<int> SaveChangesConfigureAwaitAsync(CancellationToken cancellationToken = default(CancellationToken), bool configure = false);

        Task<T> TransactionSmartAwaitAsync<T>(Func<Task<T>> func, CancellationToken cancellationToken = default(CancellationToken), bool configure = false);

        int SaveChanges();

        Task AddAsync<T>(IEnumerable<T> entity, CancellationToken cancellationToken = default(CancellationToken)) where T : class, IAggregateRoot;

        Task<T?> FirstOrDefaultAsNoTrackingAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken)) where T : class, IAggregateRoot;

        Task<T?> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken)) where T : class, IAggregateRoot;

        T? FirstOrDefault<T>(Expression<Func<T, bool>> predicate) where T : class, IAggregateRoot;

        Task<int> UpdateOrInsertEntities<T>(List<T> updatedEntities, Expression<Func<T, bool>> condition, Func<T, T, bool> isEqual, bool save = true) where T : class, IAggregateRoot;

        DbConnection GetDbConnection();

        void UpdateReadOnly<T>(IEnumerable<T> values) where T : class, IAggregateRoot;

        void UpdateReadOnly<T>(T values) where T : class, IAggregateRoot;

        Task<int> ExecuteUpdateAsync<T>(Expression<Func<T, bool>> where, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls, CancellationToken cancellationToken = default(CancellationToken)) where T : class, IAggregateRoot;

        int ExecuteUpdate<T>(Expression<Func<T, bool>> where, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls) where T : class, IAggregateRoot;

        Task<int> ExecuteDeleteAsync<T>(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default(CancellationToken)) where T : class, IAggregateRoot;

        int ExecuteDelete<T>(Expression<Func<T, bool>> where) where T : class, IAggregateRoot;
    }
}
