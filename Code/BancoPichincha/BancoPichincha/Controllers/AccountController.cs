using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLBancoPichincha.Account;
using ELBancoPichincha;

namespace BancoPichincha.Controllers
{
    [RoutePrefix("cuentas")]
    public class AccountController : ApiController
    {
        private readonly AccountBL controller = new AccountBL();
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<ACCOUNT> account = controller.getAll();
                var resultado = new
                {
                    account = account,
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
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                ACCOUNT account = controller.getByID(id);
                var resultado = new
                {
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

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(ACCOUNT value)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                ACCOUNT account = controller.create(value);
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

        [HttpPut]
        [Route("")]
        public IHttpActionResult Put(ACCOUNT value)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                controller.update(value);
                var resultado = new
                {
                    message = "Registro Actualizado Exitosamente"
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

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                controller.delete(id);
                var resultado = new
                {
                    message = "Registro eliminado exitosamente"
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
