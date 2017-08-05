using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Domain.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private GameOfDronesContext context { get; set; }
        private DbSet<T> _objectSet;

        public Repository(GameOfDronesContext context)
        {
            this.context = context;
            _objectSet = context.Set<T>();
        }

        public IQueryable<T> GetAll(Func<T, bool> predicate = null)
        {
            if (predicate != null)
            {
                return _objectSet.Where(predicate).AsQueryable<T>();
            }
            return _objectSet.AsQueryable<T>();
        }

        public T Get(Func<T, bool> predicate)
        {
            return _objectSet.FirstOrDefault(predicate);
        }

        public Boolean Exist(Func<T, bool> predicate)
        {
            return _objectSet.Where(predicate).Any();
        }

        public void Add(T entity)
        {
            _objectSet.Add(entity);
        }

        public void Update(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Attach(T entity)
        {
            _objectSet.Attach(entity);
        }

        public void Delete(T entity)
        {
            _objectSet.Remove(entity);
        }
    }
}
