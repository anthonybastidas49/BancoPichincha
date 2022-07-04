using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELBancoPichincha;
using ALBancoPichincha.Customer;

namespace BLBancoPichincha.Customer
{
    public class CustomerBL
    {
        private readonly CustomerAL dal;
        public CustomerBL()
        {
            dal = new CustomerAL();
        }
        public IEnumerable<CUSTOMER> getAll()
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
        public CUSTOMER getByID(int id)
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
        public void update(CUSTOMER customer)
        {
            try
            {
                dal.update(customer);
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
                return dal.create(customer);
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }
    }
}
