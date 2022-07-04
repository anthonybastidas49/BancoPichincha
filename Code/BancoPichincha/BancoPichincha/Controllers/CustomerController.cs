using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using BLBancoPichincha.Customer;
using ELBancoPichincha;

namespace BancoPichincha.Controllers
{
    [RoutePrefix("clientes")]
    public class CustomerController : ApiController
    {
        private readonly CustomerBL controller = new CustomerBL();
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<CUSTOMER> customer = controller.getAll();
                var resultado = new
                {
                    customer = customer,
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
                CUSTOMER customer = controller.getByID(id);
                var resultado = new
                {
                    customer = customer
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
        public IHttpActionResult Post(CUSTOMER value)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                CUSTOMER customer = controller.create(value);
                var resultado = new
                {
                    message = "Registro Creado Exitosamente",
                    customer = customer
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
        public IHttpActionResult Put(CUSTOMER value)
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
