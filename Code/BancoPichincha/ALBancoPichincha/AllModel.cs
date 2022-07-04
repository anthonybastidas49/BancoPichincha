using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALBancoPichincha;
using ELBancoPichincha;
using System.Data.Entity;
namespace ALBancoPichincha
{
    public class AllModel<T> : _IBancoPichincha<T> where T : class
    {
        private BancoPichinchaEntities1 _context;
        private IDbSet<T> dbEntity;
        public AllModel()
        {
            _context = new BancoPichinchaEntities1();
            dbEntity = _context.Set<T>();
        }
        public void Delete(int id)
        {
            try
            {
                T model = dbEntity.Find(id);
                dbEntity.Remove(model);
            }catch(Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return dbEntity.ToList();
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }

        }

        public T GetByID(int id)
        {
            try
            {
                return dbEntity.Find(id);
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }

        public T Insert(T entity)
        {
            try
            {
                return dbEntity.Add(entity);
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
