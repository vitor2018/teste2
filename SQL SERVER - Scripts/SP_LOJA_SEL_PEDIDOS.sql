IF OBJECT_ID('SP_LOJA_SEL_PEDIDOS') > 0
BEGIN
	DROP PROCEDURE [dbo].[SP_LOJA_SEL_PEDIDOS]
END;
GO
CREATE PROCEDURE [dbo].[SP_LOJA_SEL_PEDIDOS]
(
	@ID_Cliente AS INT = 0,
	@NR_Pedido AS INT = 0,
	@DT_EntregaInicial AS CHAR(10) = '',
	@DT_EntregaFinal AS CHAR(10) = ''
)
AS
BEGIN
	SELECT DISTINCT P.ID_Pedido,
		C.NM_Cliente,
		P.NR_Valor		
	FROM Pedidos P
	LEFT JOIN Clientes C WITH(NOLOCK)
		ON C.ID_Cliente = P.ID_Cliente
	WHERE
		(ISNULL(@NR_Pedido, 0) = 0 OR P.ID_Pedido = @NR_Pedido)
		AND (ISNULL(@ID_Cliente, 0) = 0 OR P.ID_Cliente = @ID_Cliente)
		AND (ISNULL(@DT_EntregaInicial, '') = '' OR CONVERT(DATE, @DT_EntregaInicial) <= CONVERT(DATE, P.DT_Entrega))
		AND (ISNULL(@DT_EntregaFinal, '') = '' OR CONVERT(DATE, P.DT_Entrega) <= CONVERT(DATE, @DT_EntregaFinal))
	ORDER BY C.NM_Cliente
END;