using MagniUniveristy.Models.Interface;
using MagniUniveristy.Models.ViewModel;
using System;
using System.Data.Entity;
using System.Linq;

namespace MagniUniveristy.DAL.Repositories
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        protected CollegeContext _context;

        public BaseRepository(CollegeContext context)
        {
            if (context == null)
                throw new ArgumentNullException("unitOfWork");

            _context = context; 
        }

        public T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> List()
        {
            return _context.Set<T>();
        }

        public ValidationViewModel Add(T item, ValidationViewModel validation)
        {
            try
            {
                _context.Set<T>().Add(item);
                _context.SaveChanges();

                validation.Success = true;
            }
            catch (Exception ex)
            {
                validation.Message = ex.Message;
                validation.Success = false;
            }

            return validation;            
        }

        public ValidationViewModel Remove(T item, ValidationViewModel validation)
        {
            try
            {                
                _context.Entry(item).State = EntityState.Deleted;
                _context.Set<T>().Remove(item);
                _context.SaveChanges();

                validation.Success = true;
            }
            catch (Exception ex)
            {
                validation.Message = ex.Message;
                validation.Success = false;
            }

            return validation;            
        }

        public ValidationViewModel Edit(T item, ValidationViewModel validation)
        {
            try
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();

                validation.Success = true;
            }
            catch (Exception ex)
            {
                validation.Message = ex.Message;
                validation.Success = false;
            }

            return validation;
            
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}