using Dapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using Serilog;
using System.Data.Common;
using System.Data;
using System.Linq.Expressions;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.Models;
using Npgsql;
using Microsoft.Data.SqlClient;
using Serilog.Context;

namespace WebSport24hNews.HoangNam.Service.Repository
{
    public class RepositoryService : IRepositoryService, IDapperCore, IDisposable
    {
        private readonly HoangNamWebContext _context;

        private readonly string _connectionstring;

        private readonly DbConnection _sqlConnection;

        private bool _disposed = false;

        public DatabaseFacade Database => _context.Database;

        public RepositoryService(HoangNamWebContext context)
        {
            _context = new HoangNamWebContext();
            _connectionstring = _context.Database.GetConnectionString() ?? throw new ArgumentNullException("GetConnectionString is null !");
            if (context.Database.IsOracle())
            {
                _sqlConnection = new OracleConnection(_connectionstring);
            }
            else if (context.Database.IsNpgsql())
            {
                _sqlConnection = new NpgsqlConnection(_connectionstring);
            }
            else
            {
                if (!context.Database.IsSqlServer())
                {
                    throw new ArgumentException("Not database config !");
                }

                _sqlConnection = new SqlConnection(_connectionstring);
            }

            LogExtension.Information("DbContext init...");
        }

        private void LogChange(string message = "")
        {
            if (Extension.Env != Environments.Production)
            {
                if (!message.IsNullOrEmpty())
                {
                    LogExtension.Information(message);
                }

                IEnumerable<EntityEntry> source = _context.ChangeTracker.Entries();
                int value = source.Count((EntityEntry e) => e.State == EntityState.Added);
                int value2 = source.Count((EntityEntry e) => e.State == EntityState.Modified);
                int value3 = source.Count((EntityEntry e) => e.State == EntityState.Deleted);
                LogExtension.Information($"Entities Added : {value}, Modified : {value2}, Deleted : {value3}");
            }
        }

        public IQueryable<T> Table<T>() where T : class, IAggregateRoot
        {
            DbSet<T> dbSet = _context.Set<T>();
            return dbSet.AsQueryable().AsNoTracking();
        }

        public virtual async Task<T> AddAsync<T>(T entity, CancellationToken cancellationToken = default(CancellationToken)) where T : class, IAggregateRoot
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (entity == null)
            {
                throw new BaseException("entity");
            }

            DbSet<T> _dbSet = _context.Set<T>();
            return (await _dbSet.AddAsync(entity, cancellationToken)).Entity;
        }

        public virtual EntityEntry<T> Delete<T>(T entity) where T : class, IAggregateRoot
        {
            if (entity == null)
            {
                throw new BaseException("entity");
            }

            DbSet<T> dbSet = _context.Set<T>();
            return dbSet.Remove(entity);
        }

        public virtual EntityEntry<T> Update<T>(T entity) where T : class, IAggregateRoot
        {
            if (entity == null)
            {
                throw new BaseException("entity");
            }

            DbSet<T> dbSet = _context.Set<T>();
            return dbSet.Update(entity);
        }

        public IQueryable<T> Where<T>(Expression<Func<T, bool>> predicate) where T : class, IAggregateRoot
        {
            IQueryable<T> source = _context.Set<T>().AsQueryable();
            return source.AsNoTracking().Where(predicate);
        }

        public async Task<IQueryable<T>> WhereAsync<T>(Expression<Func<T, bool>> predicate) where T : class, IAggregateRoot
        {
            IQueryable<T> _query = _context.Set<T>().AsQueryable();
            return await Task.FromResult(_query.AsNoTracking().Where(predicate));
        }

        public IQueryable<T> WhereTracking<T>(Expression<Func<T, bool>> predicate) where T : class, IAggregateRoot
        {
            IQueryable<T> source = _context.Set<T>().AsQueryable().AsTracking();
            return source.Where(predicate);
        }

        public async Task<IQueryable<T>> WhereTrackingAsync<T>(Expression<Func<T, bool>> predicate) where T : class, IAggregateRoot
        {
            IQueryable<T> _query = _context.Set<T>().AsQueryable().AsTracking();
            return await Task.FromResult(_query.Where(predicate));
        }

        public T? FirstOrDefault<T>(Expression<Func<T, bool>> predicate) where T : class, IAggregateRoot
        {
            IQueryable<T> source = _context.Set<T>().AsQueryable().AsTracking();
            return source.FirstOrDefault(predicate);
        }

        public async Task<T?> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken)) where T : class, IAggregateRoot
        {
            IQueryable<T> _query = _context.Set<T>().AsTracking();
            return await _query.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<T?> FirstOrDefaultAsNoTrackingAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken)) where T : class, IAggregateRoot
        {
            IQueryable<T> _query = _context.Set<T>().AsQueryable();
            return await _query.AsNoTracking().FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<int> SaveChangesConfigureAwaitAsync(CancellationToken cancellationToken = default(CancellationToken), bool configure = false)
        {
            LogChange("Before SaveChanges !");
            int res = await _context.SaveChangesAsync().ConfigureAwait(configure);
            LogChange("After SaveChanges !");
            return res;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void UpdateReadOnly<T>(IEnumerable<T> values) where T : class, IAggregateRoot
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            _context.Entry(values).State = EntityState.Modified;
        }

        public void UpdateReadOnly<T>(T values) where T : class, IAggregateRoot
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            _context.Entry(values).State = EntityState.Modified;
        }

        public async Task<T> TransactionSmartAwaitAsync<T>(
            Func<Task<T>> func,
            CancellationToken cancellationToken = default,
            bool configure = false)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            await using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
            using (LogContext.PushProperty("TransactionContext", transaction.TransactionId))
            {
                try
                {
                    Log.Information("----- Begin transaction {TransactionId} - {date}", transaction.TransactionId, DateTime.UtcNow);

                    T result = await func(); // 👈 func phải chạy tuần tự và không gọi song song EF Core

                    await _context.SaveChangesAsync(cancellationToken); // Đảm bảo Save sau xử lý
                    await transaction.CommitAsync(cancellationToken);

                    Log.Information("----- Commit transaction {TransactionId} - {date}", transaction.TransactionId, DateTime.UtcNow);
                    return result;
                }
                catch (Exception e)
                {
                    Log.Error(e, "Error during transaction");

                    await transaction.RollbackAsync(cancellationToken);

                    if (_context.ChangeTracker.HasChanges())
                        _context.ChangeTracker.Clear();

                    throw;
                }
            }
        }

        public async Task<T> TransactionSmartDapperAwaitAsync<T>(Func<Task<T>> func, CancellationToken cancellationToken = default(CancellationToken), bool configure = false)
        {
            if (func == null)
            {
                throw new ArgumentNullException("func");
            }

            try
            {
                _context.Database.CreateExecutionStrategy();
                T response = default(T);
                DbTransaction transaction = await _sqlConnection.BeginTransactionAsync();
                T result;
                try
                {
                    if (transaction == null)
                    {
                        throw new ArgumentNullException("transaction");
                    }

                    try
                    {
                        Log.Information("----- Begin transaction - {date}", Extension.Now());
                        response = await func();
                        Log.Information("----- Commit transaction - {date}", Extension.Now());
                        await transaction.CommitAsync(cancellationToken);
                    }
                    catch (Exception e2)
                    {
                        LogExtension.Information(e2.GetType().ToString());
                        Log.Error(e2.Message);
                        await transaction.RollbackAsync(cancellationToken);
                        if (e2.GetType() != typeof(OracleException) || e2.GetType() != typeof(DbUpdateException))
                        {
                            throw;
                        }

                        throw new BaseException(e2.Message);
                    }
                    finally
                    {
                        await transaction.DisposeAsync();
                    }

                    result = response;
                }
                finally
                {
                    if (transaction != null)
                    {
                        await transaction.DisposeAsync();
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                LogExtension.Information(e.GetType().ToString());
                Log.Error(e.Message);
                if (e.GetType() != typeof(OracleException) || e.GetType() != typeof(DbUpdateException))
                {
                    throw;
                }

                throw new BaseException(e.Message);
            }
        }

        public async Task AddAsync<T>(IEnumerable<T> entity, CancellationToken cancellationToken = default(CancellationToken)) where T : class, IAggregateRoot
        {
            if (entity == null)
            {
                throw new BaseException("entity");
            }

            DbSet<T> _dbSet = _context.Set<T>();
            await _dbSet.AddRangeAsync(entity, cancellationToken);
        }

        public void Update<T>(IEnumerable<T> entity) where T : class, IAggregateRoot
        {
            if (entity == null)
            {
                throw new BaseException("entity");
            }

            DbSet<T> dbSet = _context.Set<T>();
            dbSet.UpdateRange(entity);
        }

        public void Delete<T>(IEnumerable<T> entity) where T : class, IAggregateRoot
        {
            if (entity == null)
            {
                throw new BaseException("entity");
            }

            DbSet<T> dbSet = _context.Set<T>();
            dbSet.RemoveRange(entity);
        }

        public async Task<T1> QueryFirstOrDefaultAsync<T1>(string sp, object parms, CommandType commandType = CommandType.Text)
        {
            DbConnection connection = _sqlConnection;
            CommandType? commandType2 = commandType;
            return await connection.QueryFirstOrDefaultAsync<T1>(sp, parms, null, null, commandType2);
        }

        public T1 QueryFirst<T1>(string sp, object parms, CommandType commandType = CommandType.Text)
        {
            DbConnection sqlConnection = _sqlConnection;
            CommandType? commandType2 = commandType;
            return sqlConnection.QueryFirst<T1>(sp, parms, null, null, commandType2);
        }



        //Phần root
        //public async Task<IEnumerable<T1>> QueryAsync<T1>(string sp, object parms, CommandType commandType = CommandType.Text)
        //{
        //    DbConnection connection = _sqlConnection;
        //    CommandType? commandType2 = commandType;
        //    return await connection.QueryAsync<T1>(sp, parms, null, null, commandType2);
        //}




        //Cập nhật chữ ký và triển khai của QueryAsync


        public IEnumerable<T1> Query<T1>(string sp, object parms, CommandType commandType = CommandType.Text)
        {
            DbConnection sqlConnection = _sqlConnection;
            CommandType? commandType2 = commandType;
            return sqlConnection.Query<T1>(sp, parms, null, buffered: true, null, commandType2);
        }

        public async Task<SqlMapper.GridReader> QueryMultipleAsync(string sp, object parms, CommandType commandType = CommandType.Text)
        {
            DbConnection connection = _sqlConnection;
            CommandType? commandType2 = commandType;
            return await connection.QueryMultipleAsync(sp, parms, null, null, commandType2);
        }

        public async Task<int> ExecuteUpdateAsync<T>(Expression<Func<T, bool>> where, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls, CancellationToken cancellationToken = default(CancellationToken)) where T : class, IAggregateRoot
        {
            IQueryable<T> _query = _context.Set<T>().AsQueryable();
            return await _query.Where(where).ExecuteUpdateAsync(setPropertyCalls, cancellationToken);
        }

        public async Task<int> ExecuteAsync(string sql, object parameters = null, CommandType commandType = CommandType.Text)
        {
            return await _sqlConnection.ExecuteAsync(sql, parameters, commandType: commandType);
        }

        public int ExecuteUpdate<T>(Expression<Func<T, bool>> where, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls) where T : class, IAggregateRoot
        {
            IQueryable<T> source = _context.Set<T>().AsQueryable();
            return source.Where(where).ExecuteUpdate(setPropertyCalls);
        }

        public async Task<int> ExecuteDeleteAsync<T>(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default(CancellationToken)) where T : class, IAggregateRoot
        {
            IQueryable<T> _query = _context.Set<T>().AsQueryable();
            return await _query.Where(where).ExecuteDeleteAsync(cancellationToken);
        }

        public int ExecuteDelete<T>(Expression<Func<T, bool>> where) where T : class, IAggregateRoot
        {
            IQueryable<T> source = _context.Set<T>().AsQueryable();
            return source.Where(where).ExecuteDelete();
        }

        public SqlMapper.GridReader QueryMultiple(string sp, object parms, CommandType commandType = CommandType.Text)
        {
            DbConnection sqlConnection = _sqlConnection;
            CommandType? commandType2 = commandType;
            return sqlConnection.QueryMultiple(sp, parms, null, null, commandType2);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Log.Information("Dispose DbContext !");
                _sqlConnection?.Dispose();
                _disposed = true;
            }
        }

        public DbConnection GetDbConnection()
        {
            return _sqlConnection;
        }

        public void CommitTransaction(IDbContextTransaction transaction, CancellationToken cancellationToken, bool configure)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }

            try
            {
                _context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction(transaction);
                throw;
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        public void RollbackTransaction(IDbContextTransaction transaction)
        {
            try
            {
                transaction?.Rollback();
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction, CancellationToken cancellationToken, bool configure)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }

            try
            {
                await transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await RollbackTransaction(transaction, cancellationToken);
                throw;
            }
            finally
            {
                if (transaction != null)
                {
                    await transaction.DisposeAsync();
                }
            }
        }

        public async Task RollbackTransaction(IDbContextTransaction transaction, CancellationToken cancellationToken)
        {
            try
            {
                if (transaction != null)
                {
                    await transaction.RollbackAsync(cancellationToken);
                }
            }
            finally
            {
                if (transaction != null)
                {
                    await transaction.DisposeAsync();
                }
            }
        }

        public async Task<int> UpdateOrInsertEntities<T>(List<T> updatedEntities, Expression<Func<T, bool>> condition, Func<T, T, bool> isEqual, bool save) where T : class, IAggregateRoot
        {
            if (condition == null)
            {
                throw new ArgumentNullException("condition");
            }

            DbSet<T> _dbSet = _context.Set<T>();
            List<T> existingEntities = await _dbSet.AsNoTracking().Where(condition).ToListAsync();
            if (existingEntities.AnyList())
            {
                if (!updatedEntities.AnyList())
                {
                    _dbSet.RemoveRange(existingEntities);
                }
                else if (isEqual != null)
                {
                    IEnumerable<T> entitiesToDelete = existingEntities.Where((T db) => !updatedEntities.Any((T updated) => isEqual(updated, db)));
                    if (entitiesToDelete.AnyList())
                    {
                        _dbSet.RemoveRange(entitiesToDelete);
                    }
                }
            }

            if (updatedEntities.AnyList())
            {
                foreach (T updatedEntity in updatedEntities)
                {
                    T existingEntity = existingEntities.FirstOrDefault((T db) => isEqual != null && isEqual(updatedEntity, db));
                    if (existingEntity != null)
                    {
                        _dbSet.Update(updatedEntity);
                    }
                    else
                    {
                        await _dbSet.AddAsync(updatedEntity);
                    }
                }
            }

            return (!save) ? (-1) : (await _context.SaveChangesAsync());
        }

        public async Task<IEnumerable<T1>> QueryAsync<T1>(string sp = "", object parms = null, CommandType commandType = CommandType.Text, int commandTimeout = 0)
        {
            DbConnection connection = _sqlConnection;
            CommandType? commandType2 = commandType;

            // Đảm bảo kết nối đã được mở trước khi thực hiện truy vấn nếu cần (tùy thuộc vào cách bạn quản lý kết nối)
            // Nếu bạn luôn mở kết nối trong constructor hoặc nơi khác, bạn có thể bỏ qua dòng này.
            // if (connection.State != ConnectionState.Open)
            // {
            //     await connection.OpenAsync();
            // }

            // Truyền commandTimeout vào vị trí đúng của Dapper's QueryAsync
            // Cú pháp Dapper.QueryAsync: (sql, param, transaction, commandTimeout, commandType)
            return await connection.QueryAsync<T1>(sp, parms, transaction: null, commandTimeout: commandTimeout, commandType: commandType2);
        }
    }
}
