using Loja.Flexigrid;
using Loja.Models;
using Loja.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Loja.Controllers
{
    public class HomeController : Controller
    {
        #region Actions
        public ActionResult Consulta()
        {
            ViewBag.URL_CLIENTES = WebConfigurationManager.AppSettings["URL_CLIENTES"];
            ViewBag.URL_PEDIDOS_FILTRO = WebConfigurationManager.AppSettings["URL_PEDIDOS_FILTRO"];
            return View();
        }

        public ActionResult Pedido()
        {
            ViewBag.URL_CLIENTES = WebConfigurationManager.AppSettings["URL_CLIENTES"];
            ViewBag.URL_PEDIDOS_CREATE = WebConfigurationManager.AppSettings["URL_PEDIDOS_CREATE"];
            ViewBag.URL_PRODUTOS = WebConfigurationManager.AppSettings["URL_PRODUTOS"];
            return View();
        }
        #endregion
        #region Methods
        [HttpPost]
        public JsonResult FiltraPedidos(int page, int rp, string sortname, string sortorder, string query)
        {
            try
            {
                FiltroPedidos filtro = JsonConvert.DeserializeObject<FiltroPedidos>(query);
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Pedidos/Filtro", filtro).Result;                
                List<ResultPedidos> result = response.Content.ReadAsAsync<List<ResultPedidos>>().Result;

                if (!string.IsNullOrEmpty(sortname))
                {
                    if (sortorder.Equals("desc"))
                    {
                        switch (sortname)
                        {
                            case "_ID_Pedido":
                                result = result.OrderByDescending(x => x.ID_Pedido).ToList();
                                break;
                            case "_NM_Cliente":
                                result = result.OrderByDescending(x => string.IsNullOrEmpty(x.NM_Cliente) ? "CONSUMIDOR GENÉRICO" : x.NM_Cliente).ToList();
                                break;
                            case "_NR_Valor":
                                result = result.OrderByDescending(x => x.NR_Valor).ToList();
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (sortname)
                        {
                            case "_ID_Pedido":
                                result = result.OrderBy(x => x.ID_Pedido).ToList();
                                break;
                            case "_NM_Cliente":
                                result = result.OrderBy(x => string.IsNullOrEmpty(x.NM_Cliente) ? "CONSUMIDOR GENÉRICO" : x.NM_Cliente).ToList();
                                break;
                            case "_NR_Valor":
                                result = result.OrderBy(x => x.NR_Valor).ToList();
                                break;
                            default:
                                break;
                        }
                    }
                }

                var viewModel = new GridPedidos(result.Skip((page - 1) * rp).Take(page * rp).ToList())
                {
                    total = result.Count,
                    page = page
                };

                return Json(viewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    isSuccess = false,
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}