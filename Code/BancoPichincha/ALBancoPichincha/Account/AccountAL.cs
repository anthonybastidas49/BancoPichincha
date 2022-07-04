using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELBancoPichincha;

namespace ALBancoPichincha.Account
{
    public class AccountAL
    {
        private _IBancoPichincha<ACCOUNT> interfaceObj;
        public AccountAL()
        {
            interfaceObj = new AllModel<ACCOUNT>();
        }
        public IEnumerable<ACCOUNT> getAll()
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
        public ACCOUNT getByID(int id)
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
        public void update(ACCOUNT account)
        {
            try
            {
                interfaceObj.Update(account);
                interfaceObj.Save();
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }
        public ACCOUNT create(ACCOUNT account)
        {
            try
            {
                ACCOUNT accountCreated = interfaceObj.Insert(account);
                interfaceObj.Save();
                return accountCreated;
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }
    }
}
