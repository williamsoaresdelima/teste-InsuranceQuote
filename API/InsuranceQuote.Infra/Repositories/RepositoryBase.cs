using InsuranceQuote.Domain.Interfaces;
using InsuranceQuote.Infra.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace InsuranceQuote.Infra.Repositories
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {

        private bool disposed = false;

        ContextDb db = new ContextDb();

        public async Task<int> AddAsync(T entity)
        {
            await db.Set<T>().AddAsync(entity);
            await db.SaveChangesAsync();

            PropertyInfo[] properties = entity.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                var attribute = Attribute.GetCustomAttribute(property, typeof(KeyAttribute)) as KeyAttribute;

                if (attribute != null)
                    return await Task.FromResult(int.Parse(property.GetValue(entity).ToString()));
            }

            return await Task.FromResult(0);
        }
        public async Task<bool> AddRangeAsync(List<T> entity)
        {
            try
            {
                db.Set<T>().AddRangeAsync(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool UpdateRange(List<T> entity)
        {
            try
            {
                foreach (var item in entity)
                {
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            await db.SaveChangesAsync();
        }


        public bool DeleteRange(List<T> entity)
        {
            if (entity is null)
                throw new Exception("Entity to be deleted is null.");

            db.Set<T>().RemoveRange(entity);
            db.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await db.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id)
        {
            var find = await db.Set<T>().FindAsync(id);
            db.Entry(find).State = EntityState.Detached;
            return find;
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                ContextDb db2 = new ContextDb();
                db2.Entry(entity).State = EntityState.Modified;
                await db2.SaveChangesAsync();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    db.Dispose();

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}