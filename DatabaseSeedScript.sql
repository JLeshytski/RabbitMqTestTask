
CREATE DATABASE [RabbitMqTestTask]
GO

CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[DepartmentAddress] [varchar](15) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Currency] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transactions_Currency]  DEFAULT ((1)) FOR [Currency]
GO

ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transactions_Status]  DEFAULT ((1)) FOR [Status]
GO

CREATE  PROCEDURE [dbo].[Transaction_Add] @ClientId INT, @DepartmentAddress VARCHAR(15), @Amount DECIMAL(18,2), @Currency INT
AS
INSERT INTO Transactions(ClientId, DepartmentAddress, Amount, Currency) VALUES(@ClientId, @DepartmentAddress, @Amount, @Currency);
SELECT SCOPE_IDENTITY()
RETURN
GO

CREATE  PROCEDURE [dbo].[Transaction_GetAllByClient] @ClientId INT, @DepartmentAddress VARCHAR(15)
AS 
SELECT * FROM Transactions WHERE ClientId = @ClientId AND DepartmentAddress = @DepartmentAddress
RETURN
GO

CREATE  PROCEDURE [dbo].[Transaction_GetById] @Id INT
AS 
SELECT TOP 1 * FROM Transactions WHERE Id = @Id
RETURN
GO
