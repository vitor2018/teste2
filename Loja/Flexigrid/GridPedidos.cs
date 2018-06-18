using Loja.Models;
using System.Collections.Generic;

namespace Loja.Flexigrid
{
    public class GridPedidos : FlexiGridObject
    {
        public GridPedidos(List<ResultPedidos> pedidos)
        {
            pedidos.ForEach(p => {
                Add(p);
            });            
        }

        public void Add(ResultPedidos item)
        {
            var row = new FlexiGridRow()
            {
                id = item.ID_Pedido.ToString(),
                cell = GetPropertyList(item)
            };

            row.cell["_ID_Pedido"] = $"<span style='cursor: pointer; word-wrap: break-word; white-space: normal; line-height: 1.2;'>{item.ID_Pedido}</span>";
            row.cell["_NM_Cliente"] = $"<span style='cursor: pointer; word-wrap: break-word; white-space: normal; line-height: 1.2;'>{item.NM_Cliente ?? "CONSUMIDOR GENÉRICO"}</span>";
            row.cell["_NR_Valor"] = $"<span style='cursor: pointer; word-wrap: break-word; white-space: normal; line-height: 1.2;'>{item.NR_Valor:C}</span>";
            rows.Add(row);
        }
    }
}