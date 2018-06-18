using API.Core.Repositories;
using System;

namespace API.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IClientesRepository Clientes { get; }
        IItensPedidosRepository ItensPedidos { get; }
        IPedidosRepository Pedidos { get; }
        IProdutosRepository Produtos { get; }        
        int Complete();
    }
}