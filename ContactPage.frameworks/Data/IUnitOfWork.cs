using ContactPage.frameworks.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.frameworks.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IEnumerable<TEntity> Exec<TEntity>(string query, params object[] parameters);
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity;
        void BeginTransaction();
        int Commit();
        Task<int> CommitAsync();
        void Rollback();
        void Dispose(bool disposing);
    }
}
