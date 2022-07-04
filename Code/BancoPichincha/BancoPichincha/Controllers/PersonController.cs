using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLBancoPichincha.Person;
using ELBancoPichincha;

namespace BancoPichincha.Controllers
{
    [RoutePrefix("/person")]
    public class PersonController : ApiController
    {
        private readonly PersonBL controller = new PersonBL();
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<PERSON> people = controller.getAll();
                var resultado = new
                {
                    people = people,
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
        public IHttpActionResult Get(int id)
        {
            try
            {
                PERSON person = controller.getByID(id);
                var resultado = new
                {
                    person = person
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
        public IHttpActionResult Post(PERSON value)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                PERSON person = controller.create(value);
                var resultado = new
                {
                    message = "Registro Creado Exitosamente",
                    person = person
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
        public IHttpActionResult Put(PERSON value)
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
