using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELBancoPichincha;
using ALBancoPichincha.Account;

namespace BLBancoPichincha.Account
{
    public class AccountBL
    {
        private readonly AccountAL dal;
        public AccountBL()
        {
            dal = new AccountAL();
        }
        public IEnumerable<ACCOUNT> getAll()
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
        public ACCOUNT getByID(int id)
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
        public void update(ACCOUNT account)
        {
            try
            {
                dal.update(account);
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
                return dal.create(account);
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }
    }
}
