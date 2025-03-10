using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.Abstract;
using Data.Concrete;

namespace Data.Repository
{
    public class GenericRepository<T> : IRepositoryDal<T> where T : class
    {
        Context context = new Context();    
        DbSet<T> _object;   

        public GenericRepository() 
        {
            _object = context.Set<T>(); 
        }

        public void Add(T entity)
        {
            var nesnee = context.Entry(entity);
            nesnee.State = EntityState.Added;
            context.SaveChanges();

        }

        public void AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            var nesnesil = context.Entry(entity);
            nesnesil.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().SingleOrDefault(filter);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? _object.ToList() : _object.Where(filter).ToList();  
        }

        public void Update(T entity)
        {
            var nesneguncelle = context.Entry(entity);
            nesneguncelle.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
