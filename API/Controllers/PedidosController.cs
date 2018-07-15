using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;
using API.Persistence;
using API.Util;

namespace API.Controllers
{
    [RoutePrefix("api/Pedidos")]
    public class PedidosController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new LojaEntities());

        [Route("Filtro", Name = "Filtro")]
        [ResponseType(typeof(List<SP_LOJA_SEL_PEDIDOS_Result>))]
        [HttpPost]
        public IHttpActionResult PostFiltro([FromBody]FiltroPedidos filtro)
        {
            try
            {
                Parametros parametros = new Parametros("SP_LOJA_SEL_PEDIDOS");
                parametros.Add("ID_Cliente", filtro?.ID_Cliente ?? 0);
                parametros.Add("NR_Pedido", filtro?.NR_Pedido ?? 0);                
                var dtInicial = filtro?.DT_EntregaInicial ?? null;
                if (dtInicial != null && dtInicial != DateTime.MinValue)
                {                    
                    parametros.Add("DT_EntregaInicial", filtro.DT_EntregaInicial.ToShortDateString());
                }
                else
                {
                    parametros.Add("DT_EntregaInicial", "");
                }
                var dtFinal = filtro?.DT_EntregaFinal ?? null;
                if (dtFinal != null && dtFinal != DateTime.MinValue)
                {
                    parametros.Add("DT_EntregaFinal", filtro.DT_EntregaFinal.ToShortDateString());
                }
                else
                {
                    parametros.Add("DT_EntregaFinal", "");                    
                }                
                return Ok(unitOfWork.Sp_Sel_Pedidos.Proc_Retorno(parametros.ToText(), parametros.GetParametros()).ToList());
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

        [Route("Create", Name = "Create")]
        [ResponseType(typeof(Pedidos))]
        [HttpPost]
        public IHttpActionResult PostPedidos(Pedidos pedido)
        {
            try
            {
                List<ItensPedidos> itens = pedido.ItensPedidos.ToList();
                pedido.ItensPedidos.Clear();
                unitOfWork.Pedidos.Add(pedido);
                unitOfWork.Complete();
                itens.ForEach(i =>
                {
                    i.ID_Pedido = pedido.ID_Pedido;
                    unitOfWork.ItensPedidos.Add(i);
                    unitOfWork.Complete();
                });
                return Ok("");
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }            
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