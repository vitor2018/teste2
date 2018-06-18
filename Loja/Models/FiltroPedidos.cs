namespace Loja.Models
{
    public class FiltroPedidos
    {
        public int ID_Cliente { get; set; }
        public int NR_Pedido { get; set; }
        public string DT_EntregaInicial { get; set; }
        public string DT_EntregaFinal { get; set; }
    }
}