using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FJR3IO_HFT_2023242.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected MotorcycleDbContext ctx;

        protected Repository(MotorcycleDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Read(id);
            if (entity != null)
            {
                ctx.Set<T>().Remove(entity);
                ctx.SaveChanges();
            }
        }

        public abstract T Read(int id);

        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public abstract void Update(T item);
    }
}
