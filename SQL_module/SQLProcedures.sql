use SalesOrders
--1
create proc dbo.sp_CreateTable
	as
	create table dbo.tb_Results(
	SalesOrderID int not null identity(1,1),
	CustomerID int not null,
	WarehouseCode nvarchar(20),
	SalesDate datetime,
	TotalAmt decimal(25,6),
	PaidAmt decimal(25,6))

exec dbo.sp_CreateTable

drop proc dbo.sp_CreateTable

--2
create proc dbo.sp_AlterTableAddKeys
		as
		alter table dbo.tb_Results add constraint PK_Result primary key (SalesOrderID),
		constraint FK_Result_Customer foreign key (CustomerID) references dbo.Customer (CustomerID)

exec dbo.sp_AlterTableAddKeys

drop proc dbo.sp_AlterTableAddKeys

--3
create proc dbo.sp_SelectInsert
	as
	insert into dbo.tb_Results (CustomerId, SalesDate, WarehouseCode, TotalAmt, PaidAmt)
	select dbo.Customer.CustomerId, dbo.SalesOrder.SalesDate, dbo.Warehouse.WarehouseCode, dbo.SalesOrder.TotalAmt, dbo.SalesOrder.PaidAmt from dbo.Customer inner join  dbo.SalesOrder
		on dbo.Customer.CustomerID = dbo.SalesOrder.CustomerID inner join dbo.Warehouse on dbo.SalesOrder.WarehouseID = dbo.Warehouse.WarehouseID
		where dbo.Customer.State in('IL', 'NY', 'MO')

exec dbo.sp_SelectInsert

drop proc dbo.sp_SelectInsert

--4
create proc dbo.sp_UpdateDelete
	as
	begin
		delete dbo.tb_Results
			where PaidAmt = TotalAmt
		update dbo.tb_Results
			set PaidAmt = 100
			where TotalAmt - PaidAmt > 100
	end

exec dbo.sp_UpdateDelete

drop proc dbo.sp_UpdateDelete

--5
create proc dbo.sp_GetInfoByCustomer
	as
	select top 7 dbo.Customer.CustomerID, dbo.Customer.Name, count(*) as 'Count', sum(dbo.SalesOrder.TotalAmt) as 'TotalAmt', sum(dbo.SalesOrder.UnpaidAmt) as 'TotalUnpaid'
		from dbo.Customer inner join dbo.SalesOrder on dbo.Customer.CustomerID = dbo.SalesOrder.CustomerID
		group by dbo.Customer.CustomerID, dbo.Customer.Name
		order by count(*) desc, dbo.Customer.CustomerID

exec dbo.sp_GetInfoByCustomer

drop proc dbo.sp_GetInfoByCustomer

--6
create proc dbo.sp_GetInfoByUnpaidCustomer
	as
	select dbo.Customer.CustomerID, dbo.Customer.Name, count(*) as 'Count', sum(dbo.SalesOrder.TotalAmt) as 'TotalAmt', sum(dbo.SalesOrder.UnpaidAmt) as 'TotalUnpaid'
		from dbo.Customer inner join dbo.SalesOrder on dbo.Customer.CustomerID = dbo.SalesOrder.CustomerID
		group by dbo.Customer.CustomerID, dbo.Customer.Name
		having sum(dbo.SalesOrder.UnpaidAmt) > 0

exec dbo.sp_GetInfoByUnpaidCustomer

drop proc dbo.sp_GetInfoByUnpaidCustomer

--7
create proc dbo.sp_GetAverageSalesOrderAmt
	@avgTotalAmt decimal(25,6) out
	as
	select @avgTotalAmt = avg(TotalAmt) from dbo.SalesOrder

declare @avgTotal decimal(25,6)
exec dbo.sp_GetAverageSalesOrderAmt @avgTotal out
select @avgTotal

drop proc dbo.sp_GetAverageSalesOrderAmt

--8
create proc dbo.sp_DropTable
		as
		drop table dbo.tb_Results

exec dbo.sp_DropTable

drop proc dbo.sp_DropTable

select * from dbo.tb_Results

select * from dbo.SalesOrder
