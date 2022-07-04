using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ELBancoPichincha;
using BLBancoPichincha.Movement;

namespace BancoPichincha.Controllers
{
    [RoutePrefix("movimientos")]
    public class MovementController : ApiController
    {
        private readonly MovementBL controller = new MovementBL();
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(MOVEMENT value)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                MOVEMENT account = controller.create(value);
                var resultado = new
                {
                    message = "Registro Creado Exitosamente",
                    account = account
                };
                return Ok(resultado);

            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                var result = new
                {
                    error = e.Message
                };
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetRange(int start, int end, int idAccount)
        {
            try
            {
                IEnumerable<MOVEMENT> movimientos = controller.getRange(start, end, idAccount);
                var resultado = new
                {
                    message = "Movimientos",
                    movimientos = movimientos
                };
                return Ok(resultado);

            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                var result = new
                {
                    error = e.Message
                };
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
    }
}
