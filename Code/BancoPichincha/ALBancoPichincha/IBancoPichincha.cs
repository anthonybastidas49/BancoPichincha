using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELBancoPichincha;

namespace ALBancoPichincha
{
    public interface _IBancoPichincha<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        T Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();
    }
}
