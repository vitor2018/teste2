/*CREATE TABLE PRODUTOS*/
IF NOT EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'LOJA')
BEGIN
CREATE DATABASE [Loja]
END
USE Loja
GO
IF (OBJECT_ID('Produtos')) > 0
BEGIN
	DROP TABLE [Produtos]
END;
CREATE TABLE Produtos(
	ID_Produto INT NOT NULL IDENTITY(1,1),	
	NM_Descricao VARCHAR(150) NOT NULL,
	NR_Valor DECIMAL(16,2) NOT NULL
)

/*PRIMARY KEY*/
ALTER TABLE [dbo].[Produtos] ADD CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED([ID_Produto] ASC)

/*INDEX*/
CREATE INDEX ix_Produtos ON Produtos(ID_Produto)

/*COMENTÁRIOS*/
EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'ID do Produto' , 
                                @level0type=N'SCHEMA',
                                @level0name=N'dbo', 
                                @level1type=N'TABLE',
                                @level1name=N'Produtos', 
                                @level2type=N'COLUMN',
                                @level2name=N'ID_Produto'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Descricao do Produto' , 
                                @level0type=N'SCHEMA',
                                @level0name=N'dbo', 
                                @level1type=N'TABLE',
                                @level1name=N'Produtos', 
                                @level2type=N'COLUMN',
                                @level2name=N'NM_Descricao'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Valor do Produto' , 
                                @level0type=N'SCHEMA',
                                @level0name=N'dbo', 
                                @level1type=N'TABLE',
                                @level1name=N'Produtos', 
                                @level2type=N'COLUMN',
                                @level2name=N'NR_Valor'

INSERT INTO PRODUTOS(NM_DESCRICAO, NR_VALOR)
VALUES('LIVRO CLEAN CODE', 29.99)
GO
INSERT INTO PRODUTOS(NM_DESCRICAO, NR_VALOR)
VALUES('LIVRO DE C#', 19.99)
GO
INSERT INTO PRODUTOS(NM_DESCRICAO, NR_VALOR)
VALUES('LIVRO DE JAVA', 9.99)