using System;

namespace API.Models
{
    public class FiltroPedidos
    {
        public int ID_Cliente { get; set; }
        public int NR_Pedido { get; set; }
        public DateTime DT_EntregaInicial { get; set; }
        public DateTime DT_EntregaFinal { get; set; }
    }
}