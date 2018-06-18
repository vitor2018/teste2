using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;
using API.Persistence;

namespace API.Controllers
{
    [RoutePrefix("api/Clientes")]
    public class ClientesController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new LojaEntities());

        [Route("", Name = "GetCliente")]
        [ResponseType(typeof(IEnumerable<Clientes>))]
        [HttpGet]
        public HttpResponseMessage GetClientes([FromUri]string q, [FromUri]int page)
        {
            IEnumerable<Clientes> clientes = unitOfWork.Clientes.FindByPage(c => c.NM_Cliente.Contains(q), page, 30);
            if (clientes == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, new Exception(""));
            }
            return Request.CreateResponse(HttpStatusCode.OK, clientes, MediaTypeHeaderValue.Parse("application/json"));            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}