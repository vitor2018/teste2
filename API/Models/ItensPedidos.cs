//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItensPedidos
    {
        public int ID_ItensPedido { get; set; }
        public int ID_Pedido { get; set; }
        public int ID_Produto { get; set; }
        public decimal NR_Quantidade { get; set; }
        public decimal NR_Valor { get; set; }
        public decimal NR_ValorTotal { get; set; }
    
        public virtual Pedidos Pedidos { get; set; }
        public virtual Produtos Produtos { get; set; }
    }
}
