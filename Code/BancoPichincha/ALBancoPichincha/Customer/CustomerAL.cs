using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELBancoPichincha;

namespace ALBancoPichincha.Customer
{
    public class CustomerAL
    {
        private _IBancoPichincha<CUSTOMER> interfaceObj;
        public CustomerAL()
        {
            interfaceObj = new AllModel<CUSTOMER>();
        }
        public IEnumerable<CUSTOMER> getAll()
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
        public CUSTOMER getByID(int id)
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
        public void update(CUSTOMER customer)
        {
            try
            {
                interfaceObj.Update(customer);
                interfaceObj.Save();
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }
        public CUSTOMER create(CUSTOMER customer)
        {
            try
            {
                CUSTOMER customerCreated = interfaceObj.Insert(customer);
                interfaceObj.Save();
                return customerCreated;
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }

    }
}
