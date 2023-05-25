using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;

namespace Template_4335.Class
{
    public abstract class EntityService<TEntity>
        where TEntity : Entity
    {
        protected ApplicationContext _context;
        protected DbSet<TEntity> _dbSet;

        protected EntityService(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual bool Create(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);

                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public virtual IQueryable<TEntity> ReadAsQueryable()
        {
            return _dbSet.AsQueryable();
        }
    }
}