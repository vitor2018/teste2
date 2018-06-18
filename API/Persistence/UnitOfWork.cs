using API.Core;
using API.Core.Repositories;
using API.Models;
using API.Persistence.Repositories;

namespace API.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LojaEntities _context;

        public UnitOfWork(LojaEntities context)
        {
            _context = context;
            Clientes = new ClientesRepository(_context);
            ItensPedidos = new ItensPedidosRepository(_context);
            Pedidos = new PedidosRepository(_context);
            Produtos = new ProdutosRepository(_context);            
            Sp_Sel_Pedidos = new Sp_Loja_Sel_Pedidos<SP_LOJA_SEL_PEDIDOS_Result>(_context);
        }

        public IClientesRepository Clientes { get; private set; }
        public IItensPedidosRepository ItensPedidos { get; private set; }
        public IPedidosRepository Pedidos { get; private set; }
        public IProdutosRepository Produtos { get; private set; }        
        public IProcedureRepository<SP_LOJA_SEL_PEDIDOS_Result> Sp_Sel_Pedidos { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}