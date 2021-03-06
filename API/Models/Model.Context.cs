﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class LojaEntities : DbContext
    {
        public LojaEntities()
            : base("name=LojaEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<ItensPedidos> ItensPedidos { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }
    
        public virtual ObjectResult<SP_LOJA_SEL_PEDIDOS_Result> SP_LOJA_SEL_PEDIDOS(Nullable<int> iD_Cliente, Nullable<int> nR_Pedido, string dT_EntregaInicial, string dT_EntregaFinal)
        {
            var iD_ClienteParameter = iD_Cliente.HasValue ?
                new ObjectParameter("ID_Cliente", iD_Cliente) :
                new ObjectParameter("ID_Cliente", typeof(int));
    
            var nR_PedidoParameter = nR_Pedido.HasValue ?
                new ObjectParameter("NR_Pedido", nR_Pedido) :
                new ObjectParameter("NR_Pedido", typeof(int));
    
            var dT_EntregaInicialParameter = dT_EntregaInicial != null ?
                new ObjectParameter("DT_EntregaInicial", dT_EntregaInicial) :
                new ObjectParameter("DT_EntregaInicial", typeof(string));
    
            var dT_EntregaFinalParameter = dT_EntregaFinal != null ?
                new ObjectParameter("DT_EntregaFinal", dT_EntregaFinal) :
                new ObjectParameter("DT_EntregaFinal", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_LOJA_SEL_PEDIDOS_Result>("SP_LOJA_SEL_PEDIDOS", iD_ClienteParameter, nR_PedidoParameter, dT_EntregaInicialParameter, dT_EntregaFinalParameter);
        }
    }
}
