using ContactPage.frameworks.Data;
using ContactPage.frameworks.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using ProductMS.Framework;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ContactPage.frameworks
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _dbContext;
        private IServiceProvider serviceProvider { get; set; }
        private readonly ILogger _logger;
        //private IDbContextTransaction? _transaction = null;

        //#region Constructor        

        public UnitOfWork(DbContext dbContext, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger("logs");
        }
        //#endregion

        //#region  Methods

        //public IEnumerable<TEntity> Exec<TEntity>(string query, params object[] parameters)
        //{
        //    FormattableString sql = FormattableStringFactory.Create(query, parameters);
        //    List<TEntity> entities = _dbContext.Database.SqlQuery<TEntity>(sql).ToList();
        //    return entities.Select(i => i).AsEnumerable();
        //}

        //public void BeginTransaction()
        //{
        //    _transaction = _dbContext.Database.BeginTransaction();
        //}


        //public int Commit()
        //{
        //    lock (_lock)
        //    {
        //        try
        //        {
        //            int result = _dbContext.SaveChanges();
        //            _transaction.Commit();
        //            return result;
        //        }
        //        catch
        //        {
        //            _transaction.Rollback();
        //            return 0;
        //        }
        //        finally
        //        {

        //        }
        //    }
        //}

        //private static readonly object _lock = new();


        public async Task<int> CommitAsync()
        {

            try
            {
                int result = await _dbContext.SaveChangesAsync();
                return result;
            }
            finally
            {

            }

        }

        //public int CommitTransaction()
        //{
        //    lock (_lock)
        //    {
        //        try
        //        {
        //            int result = _dbContext.SaveChangesAsync().Result;
        //            _transaction.Commit();
        //            return result;
        //        }
        //        finally
        //        {

        //        }
        //    }
        //}

        // "Employee-നെ database-ൽ access ചെയ്യാൻ വേണ്ട Repository എനിക്ക് ഉണ്ടാക്കി തരൂ." -- Example for understanding !! 
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity
        {
            object? instance = serviceProvider.GetService(typeof(TEntity));
            //  ഉപയോഗിച്ച് type കണ്ടെത്തുകയും
            Type instanceType = instance.GetType();
            MethodInfo setMethod = GetType().GetTypeInfo().GetMethod("CreateRepository").MakeGenericMethod(typeof(TEntity), instanceType);
            //Reflection ഉപയോഗിച്ച് CreateRepository() method കണ്ടെത്തി execute ചെയ്യുകയും,
            IRepository<TEntity>? repository = (IRepository<TEntity>?)setMethod.Invoke(this, new object[] { });
            //IRepository<TEntity> ആയി repository return ചെയ്യുകയും ചെയ്യുന്നു."
            return repository;
        }

        public virtual object CreateRepository<TContract, TEntity>() where TContract : IEntity where TEntity : class, TContract
        {
            Repository<TContract, TEntity> repository = new(_dbContext, _logger);
            return repository;
        }

        //public void Rollback()
        //{
        //    _transaction.Rollback();
        //}
        //#endregion

        #region IDisposable         
        /// <summary>
        /// The disposed value
        /// </summary>
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                //// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                //// TODO: set large fields to null.

                disposedValue = true;
            }
        }

        //// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        //// ~UnitOfWork() {
        ////   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        ////   Dispose(false);
        //// }

        //// This code added to correctly implement the disposable pattern.

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            //// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            //// TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
