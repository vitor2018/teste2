using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;
using API.Persistence;

namespace API.Controllers
{
    [RoutePrefix("api/Produtos")]
    public class ProdutosController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new LojaEntities());

        [Route("", Name = "GetProduto")]
        [ResponseType(typeof(IEnumerable<Produtos>))]
        [HttpGet]
        public IHttpActionResult GetProdutos([FromUri]string q, [FromUri]int page)
        {
            IEnumerable<Produtos> produtos = unitOfWork.Produtos.FindByPage(c => c.NM_Descricao.Contains(q), page, 30);
            if (produtos == null)
            {
                return NotFound();
            }

            return Ok(produtos);
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