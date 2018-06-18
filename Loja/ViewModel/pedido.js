function PedidoViewModel() {
    var self = this;
    self.ID_Pedido = 0;
    self.ID_Cliente = ko.observable(0);
    self.NR_Valor = ko.observable(0);
    self.DT_Entrega = ko.observable();
    self.ItensPedidos = ko.observableArray();
    self.addItem = function () {
        var idProduto = $("#ID_Produto").select2("data")[0];
        var result = validaCamposItem(self.ItensPedidos(), idProduto === undefined ? "" : idProduto.ID_Produto);
        if (result === "") {            
            var valor = (parseFloat($("#NR_Quantidade").val()) * $("#ID_Produto").select2("data")[0].NR_Valor).toFixed(2);
            self.ItensPedidos.push({
                ID_ItensPedido: 0,
                ID_Pedido: 0,
                ID_Produto: $("#ID_Produto").select2("data")[0].ID_Produto,
                NM_Produto: $("#ID_Produto").select2("data")[0].NM_Descricao,
                NR_Quantidade: parseFloat($("#NR_Quantidade").val()),
                NR_Valor: parseFloat($("#ID_Produto").select2("data")[0].NR_Valor),
                NR_ValorTotal: parseFloat(valor).toFixed(2)
            });
            self.NR_Valor(parseFloat(parseFloat(self.NR_Valor()) + parseFloat(valor)).toFixed(2));
        } else {
            swal("Erro", result, "error");
        }
    };
    self.removeItem = function (item) {
        self.NR_Valor(parseFloat(parseFloat(self.NR_Valor()) - parseFloat(item.NR_ValorTotal)).toFixed(2));
        self.ItensPedidos.remove(item);
    };
};