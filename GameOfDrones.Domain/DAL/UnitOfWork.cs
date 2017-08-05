using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Domain.DAL
{
    public class UnitOfWork : IDisposable
    {
        private GameOfDronesContext context { get; set; }

        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork()
        {
            context = new GameOfDronesContext();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepository<T>;
            }
            IRepository<T> repo = new Repository<T>(context);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch(DbEntityValidationException ex)
            {
                var errors = ex.EntityValidationErrors;
                var error1 = errors.FirstOrDefault().ValidationErrors.Select(x => new { x.PropertyName, x.ErrorMessage });
            }

            
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
