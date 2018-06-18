/*CREATE TABLE PEDIDOS*/
IF NOT EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'LOJA')
BEGIN
CREATE DATABASE [Loja]
END
USE Loja
GO
IF (OBJECT_ID('Pedidos')) > 0
BEGIN
	DROP TABLE [Pedidos]
END;
CREATE TABLE Pedidos(
	ID_Pedido INT NOT NULL IDENTITY(1,1),	
	ID_Cliente INT NULL,
	NR_Valor DECIMAL(16,2) NOT NULL,
	DT_Entrega DATETIME NOT NULL
)

/*PRIMARY KEY*/
ALTER TABLE [dbo].[Pedidos] ADD CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED([ID_Pedido] ASC)

/*FOREIGN KEY*/
ALTER TABLE [dbo].[Pedidos] ADD CONSTRAINT FK_Pedidos_Clientes FOREIGN KEY (ID_Cliente) REFERENCES Clientes (ID_Cliente)

/*INDEX*/
CREATE INDEX ix_Pedidos ON Pedidos(ID_Pedido)

/*COMENTÁRIOS*/
EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'ID do Pedido' , 
                                @level0type=N'SCHEMA',
                                @level0name=N'dbo', 
                                @level1type=N'TABLE',
                                @level1name=N'Pedidos', 
                                @level2type=N'COLUMN',
                                @level2name=N'ID_Pedido'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'ID do Cliente' , 
                                @level0type=N'SCHEMA',
                                @level0name=N'dbo', 
                                @level1type=N'TABLE',
                                @level1name=N'Pedidos', 
                                @level2type=N'COLUMN',
                                @level2name=N'ID_Cliente'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Valor do Pedido' , 
                                @level0type=N'SCHEMA',
                                @level0name=N'dbo', 
                                @level1type=N'TABLE',
                                @level1name=N'Pedidos', 
                                @level2type=N'COLUMN',
                                @level2name=N'NR_Valor'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Data de Entrega do Pedido' , 
                                @level0type=N'SCHEMA',
                                @level0name=N'dbo', 
                                @level1type=N'TABLE',
                                @level1name=N'Pedidos', 
                                @level2type=N'COLUMN',
                                @level2name=N'DT_Entrega'