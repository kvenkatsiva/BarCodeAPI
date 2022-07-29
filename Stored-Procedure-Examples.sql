CREATE TABLE [dbo].[tbl_CreateBarCode] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
	[Guid_Id]			 NVARCHAR(200)  Null,
    [BarCode]            NVARCHAR (50)  NULL,
    [BarCodeDescription] NVARCHAR (100) NULL,
    [BarCodePack]        INT            NULL,
    [BarCodeCreatedDate] DATETIME       DEFAULT (getdate()) NULL,
    [Created_Date]       DATETIME       DEFAULT (getdate()) NULL,
    [Active]             INT            NULL,
	[Type]               NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE PROCEDURE usp_GetBarCodeList
as
begin
select * from tbl_CreateBarCode;
end


CREATE PROCEDURE usp_InsertBarCode
(
@Id INT,           
@Guid_Id NVARCHAR(200), 
@BarCode NVARCHAR(50), 
@BarCodeDescription NVARCHAR(100),
@BarCodePack INT,           
@BarCodeCreatedDate DATETIME,      
@Created_Date DATETIME,      
@Active INT,           
@Type NVARCHAR(50) 
)
as
begin
if(@Type ='Insert')
begin try
Insert into tbl_CreateBarCode(Id,Guid_Id,BarCode,BarCodeDescription,BarCodePack,BarCodeCreatedDate,Created_Date,Active,Type)
Values
(@Id,@Guid_Id,@BarCode,@BarCodeDescription,@BarCodePack,GETDATE(),GETDATE(),@Active,@Type);             

Select "Saved Successfully as Response
end Try
end
begin catch
Select ERROR_MESSAGE() as Response
end catch


CREATE PROCEDURE usp_UpdateBarCode
(           
@Guid_Id NVARCHAR(200), 
@BarCode NVARCHAR(50), 
@BarCodeDescription NVARCHAR(100),
@BarCodePack INT,           
@BarCodeCreatedDate DATETIME,      
@Created_Date DATETIME,      
@Active INT,           
@Type NVARCHAR(50), 
@Id INT          
) 

as
begin
if(@Type ='Update')
begin try
Update tbl_CreateBarCode set Guid_Id=@Guid_Id,
BarCode=@BarCode,
BarCodeDescription=@BarCodeDescription,
BarCodePack=@BarCodePack,
BarCodeCreatedDate=GETDATE(),
Created_Date=GETDATE(),
Active=@Active,
Type=@Type where Id=@Id
            
Select 'Updated Successfully' as Response

end Try

begin catch
Select ERROR_MESSAGE() as Response
end catch
end

CREATE PROCEDURE usp_DeleteBarCode
(
@Id INT, 
@Type NVARCHAR(50)           
)
as
begin
if(@Type ='Delete')
begin try
Delete from tbl_CreateBarCode where Id=@Id;
             
Select 'Deleted Successfully' as Response

end Try

begin catch
Select ERROR_MESSAGE() as Response

end catch
end


set identity_insert tbl_CreateBarCode off;
INSERT INTO tbl_CreateBarCode(Guid_Id,BarCode,BarCodeDescription,BarCodePack,BarCodeCreatedDate,Created_Date,Active,Type) VALUES 
('5fc32d8d-fe01-4acb-b059-7fc1f9e0d093','SHIVA00000001','SHIVA ENTERPRISE PVT LTD',10,'2022-07-25','2022-07-25',0,'get'),
('f670d0c5-04f7-4dbc-9a1e-1ef62a729066','SHIVA00000002','SHIVA ENTERPRISE PVT LTD',10,'2022-07-25','2022-07-25',0,'get'),
('559d582d-b6d4-4d99-a090-28488b1dcebd','SHIVA00000003','SHIVA ENTERPRISE PVT LTD',10,'2022-07-25','2022-07-25',0,'get'),
('96a49bd5-7fb5-455d-a93c-1b75f97ddf8f','SHIVA00000004','SHIVA ENTERPRISE PVT LTD',10,'2022-07-25','2022-07-25',0,'get'),
('5a36113a-1119-4e38-856a-ecdade8b2bc4','SHIVA00000005','SHIVA ENTERPRISE PVT LTD',10,'2022-07-25','2022-07-25',0,'get'),
('130ed8f6-b2a4-41b5-ab1e-5d332392c3f7','SHIVA00000006','SHIVA ENTERPRISE PVT LTD',10,'2022-07-25','2022-07-25',0,'get'),
('6baa4a04-12f1-42b5-ac6d-0989f0f3b520','SHIVA00000007','SHIVA ENTERPRISE PVT LTD',10,'2022-07-25','2022-07-25',0,'get'),
('27a926f5-f207-4a08-8994-1e537c119d36','SHIVA00000008','SHIVA ENTERPRISE PVT LTD',10,'2022-07-25','2022-07-25',0,'get'),
('8d02ac84-e172-45dc-806b-8a3ed9eecb4a','SHIVA00000009','SHIVA ENTERPRISE PVT LTD',10,'2022-07-25','2022-07-25',0,'get'),
('916612b4-4c1c-4277-b60c-e7fcf61bcd16','SHIVA00000010','SHIVA ENTERPRISE PVT LTD',10,'2022-07-25','2022-07-25',0,'get')


USE [SudhaEnterprise]
GO
DECLARE	@return_value int
EXEC	@return_value = [dbo].[usp_GetBarCodeList]
SELECT	'Return Value' = @return_value
GO

USE [SudhaEnterprise] 
GO  
DECLARE	@return_value int
EXEC  @return_value = [dbo].[usp_GetBarCodeList]  
SELECT	'Return Value' = @return_value
GO  