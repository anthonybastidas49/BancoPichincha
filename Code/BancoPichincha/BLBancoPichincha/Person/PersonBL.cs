using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELBancoPichincha;
using ALBancoPichincha.Person;

namespace BLBancoPichincha.Person
{
    public class PersonBL
    {
        private readonly PersonAL dal;
        public PersonBL()
        {
            dal = new PersonAL();
        }
        public IEnumerable<PERSON> getAll()
        {
            try
            {
                return dal.getAll();
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
                return dal.getByID(id);
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
                dal.delete(id);
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
                dal.update(person);
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
                return dal.create(person);
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }

    }
}
