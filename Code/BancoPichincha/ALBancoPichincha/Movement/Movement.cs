using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELBancoPichincha;

namespace ALBancoPichincha.Movement
{
    public class MovementAL
    {
        private _IBancoPichincha<MOVEMENT> interfaceObj;
        public MovementAL()
        {
            interfaceObj = new AllModel<MOVEMENT>();
        }
        public IEnumerable<MOVEMENT> getAll()
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
        public MOVEMENT getByID(int id)
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
        public void update(MOVEMENT movement)
        {
            try
            {
                interfaceObj.Update(movement);
                interfaceObj.Save();
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }
        public MOVEMENT create(MOVEMENT movement)
        {
            try
            {
                MOVEMENT movementCreated = interfaceObj.Insert(movement);
                interfaceObj.Save();
                return movementCreated;
            }
            catch (Exception e)
            {
                Console.Error.Write(e.Message);
                throw e;
            }
        }
    }
}
