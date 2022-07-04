using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELBancoPichincha;
using ALBancoPichincha.Account;
using ALBancoPichincha.Movement;

namespace BLBancoPichincha.Movement
{
    public class MovementBL
    {
        private readonly AccountAL accountDal;
        private readonly MovementAL movementDal;
        public MovementBL()
        {
            accountDal = new AccountAL();
            movementDal = new MovementAL();
        }
        public MOVEMENT create(MOVEMENT movement) 
        {
            try
            {
                ACCOUNT account = accountDal.getByID(movement.ID_ACCOUNT);
                List<MOVEMENT> movimientos = movementDal.getAll().ToList().FindAll(x => movement.DATE >= x.DATE && movement.ID_ACCOUNT.Equals(x.ID_ACCOUNT));
                decimal dailySummation = (decimal)movimientos.Sum(x => x.VALUE);
                movement.INITIAL_BALANCE = account.INITIAL_BALANCE;
                if (dailySummation >= account.LIMIT)
                {
                    throw new Exception("Cupo diario excedido");
                }
                if (movement.TYPE.Equals("C"))
                {
                    account.INITIAL_BALANCE = (decimal)(account.INITIAL_BALANCE + movement.VALUE); 
                } else
                {
                    if (account.INITIAL_BALANCE < movement.VALUE) {
                        throw new Exception("Saldo no disponible");
                    }
                    account.INITIAL_BALANCE = (decimal)(account.INITIAL_BALANCE - movement.VALUE);
                }
                movement.BALANCE = account.INITIAL_BALANCE;
                accountDal.update(account);
                return movementDal.create(movement);
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }
        public IEnumerable<MOVEMENT> getRange(int start, int end , int idAccount)
        {
            try
            {
                return movementDal.getAll().ToList().FindAll(x => x.DATE >= start && x.DATE <= end && x.ID_ACCOUNT.Equals(idAccount));
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }
    }
}
