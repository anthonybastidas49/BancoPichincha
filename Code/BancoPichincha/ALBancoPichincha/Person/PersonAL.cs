using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALBancoPichincha;
using ELBancoPichincha;

namespace ALBancoPichincha.Person
{
    public class PersonAL
    {
        private _IBancoPichincha<PERSON> interfaceObj;
        public PersonAL()
        {
            interfaceObj = new AllModel<PERSON>();
        }
        public IEnumerable<PERSON> getAll()
        {
            try
            {
                return interfaceObj.GetAll();
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }
        public PERSON getByID(int id)
        {
            try
            {
                return interfaceObj.GetByID(id);
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }
        public void delete(int id)
        {
            try
            {
                interfaceObj.Delete(id);
                interfaceObj.Save();
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }
        public void update(PERSON person)
        {
            try
            {
                interfaceObj.Update(person);
                interfaceObj.Save();
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }
        public PERSON create(PERSON person)
        {
            try
            {
                PERSON personCreated = interfaceObj.Insert(person);
                interfaceObj.Save();
                return personCreated;
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }
    }
}
