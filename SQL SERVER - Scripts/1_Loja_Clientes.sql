/*CREATE TABLE CLIENTES*/
IF NOT EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'LOJA')
BEGIN
CREATE DATABASE [Loja]
END
USE Loja
GO
IF (OBJECT_ID('Clientes')) > 0
BEGIN
	DROP TABLE [Clientes]
END;
CREATE TABLE Clientes(
	ID_Cliente INT NOT NULL IDENTITY(1,1),	
	NM_Cliente VARCHAR(150) NOT NULL,
	NR_CPF VARCHAR(14) NOT NULL
)

/*PRIMARY KEY*/
ALTER TABLE [dbo].[Clientes] ADD CONSTRAINT PK_CLIENTES PRIMARY KEY CLUSTERED ([ID_Cliente] ASC)

/*INDEX*/
CREATE INDEX ix_Clientes ON Clientes(ID_Cliente)

/*COMENTÁRIOS*/
EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'ID do Cliente' , 
                                @level0type=N'SCHEMA',
                                @level0name=N'dbo', 
                                @level1type=N'TABLE',
                                @level1name=N'Clientes', 
                                @level2type=N'COLUMN',
                                @level2name=N'ID_Cliente'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Nome do Cliente' , 
                                @level0type=N'SCHEMA',
                                @level0name=N'dbo', 
                                @level1type=N'TABLE',
                                @level1name=N'Clientes', 
                                @level2type=N'COLUMN',
                                @level2name=N'NM_Cliente'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Número do CPF do Cliente' , 
                                @level0type=N'SCHEMA',
                                @level0name=N'dbo', 
                                @level1type=N'TABLE',
                                @level1name=N'Clientes', 
                                @level2type=N'COLUMN',
                                @level2name=N'NR_CPF'

INSERT INTO CLIENTES(NM_CLIENTE, NR_CPF)
VALUES('BILL GATES', '999.999.999-99')
GO
INSERT INTO CLIENTES(NM_CLIENTE, NR_CPF)
VALUES('STEVE JOBS', '999.999.999-99')
GO
INSERT INTO CLIENTES(NM_CLIENTE, NR_CPF)
VALUES('MARK ZUCKERBERG', '999.999.999-99')