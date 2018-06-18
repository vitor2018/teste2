/*CREATE TABLE ITENSPEDIDOS*/
IF NOT EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'LOJA')
BEGIN
CREATE DATABASE [Loja]
END
USE Loja
GO
IF (OBJECT_ID('ItensPedidos')) > 0
BEGIN
	DROP TABLE [ItensPedidos]
END;
CREATE TABLE ItensPedidos(
	ID_ItensPedido INT NOT NULL IDENTITY(1,1),	
	ID_Pedido INT NOT NULL,
	ID_Produto INT NOT NULL,
	NR_Quantidade DECIMAL(5,2) NOT NULL,
	NR_Valor DECIMAL(16,2) NOT NULL,
	NR_ValorTotal DECIMAL(16,2) NOT NULL	
)

/*PRIMARY KEY*/
ALTER TABLE [dbo].[ItensPedidos] ADD CONSTRAINT [PK_ItensPedidos] PRIMARY KEY CLUSTERED([ID_ItensPedido] ASC)

/*FOREIGN KEY*/
ALTER TABLE [dbo].[ItensPedidos] ADD CONSTRAINT FK_ItensPedidos_Pedidos FOREIGN KEY (ID_Pedido) REFERENCES Pedidos (ID_Pedido)

/*FOREIGN KEY*/
ALTER TABLE [dbo].[ItensPedidos] ADD CONSTRAINT FK_ItensPedidos_Produtos FOREIGN KEY (ID_Produto) REFERENCES Produtos (ID_Produto)

/*INDEX*/
CREATE INDEX ix_ItensPedidos ON ItensPedidos(ID_ItensPedido)

/*COMENTÁRIOS*/
EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'ID do Item de Pedido' , 
                                @level0type=N'SCHEMA',
                                @level0name=N'dbo', 
                                @level1type=N'TABLE',
                                @level1name=N'ItensPedidos', 
                                @level2type=N'COLUMN',
                                @level2name=N'ID_ItensPedido'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'ID do Pedido' , 
                                @level0type=N'SCHEMA',
                                @level0name=N'dbo', 
                                @level1type=N'TABLE',
                                @level1name=N'ItensPedidos', 
                                @level2type=N'COLUMN',
                                @level2name=N'ID_Pedido'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'ID do Produto' , 
                                @level0type=N'SCHEMA',
                                @level0name=N'dbo', 
                                @level1type=N'TABLE',
                                @level1name=N'ItensPedidos', 
                                @level2type=N'COLUMN',
                                @level2name=N'ID_Produto'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Quantidade do Produto do Pedido' , 
                                @level0type=N'SCHEMA',
                                @level0name=N'dbo', 
                                @level1type=N'TABLE',
                                @level1name=N'ItensPedidos', 
                                @level2type=N'COLUMN',
                                @level2name=N'NR_Quantidade'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Valor do Pedido' , 
                                @level0type=N'SCHEMA',
                                @level0name=N'dbo', 
                                @level1type=N'TABLE',
                                @level1name=N'ItensPedidos', 
                                @level2type=N'COLUMN',
                                @level2name=N'NR_Valor'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Valor Total do Pedido' , 
                                @level0type=N'SCHEMA',
                                @level0name=N'dbo', 
                                @level1type=N'TABLE',
                                @level1name=N'ItensPedidos', 
                                @level2type=N'COLUMN',
                                @level2name=N'NR_ValorTotal'