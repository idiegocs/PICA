if exists(select * from sys.objects where type = N'U' and name = 'KALLSONYS_SHIPMENT')
begin
	drop table KALLSONYS_SHIPMENT
end
go
create table KALLSONYS_SHIPMENT
(
	ORDERID		numeric(18,0) not null, --> PRIMARY KEY
	FNAME		nvarchar(50) not null,
	LNAME		nvarchar(50) not null,
	STREET		nvarchar(50) not null,
	CITY		nvarchar(50) not null,
	[STATE]		nvarchar(50) not null,
	ZIPCODE		nvarchar(50) null,
	Estado		nvarchar(50) not null
)
go
alter table KALLSONYS_SHIPMENT
add constraint PK_EnvioKallSonys
primary key (ORDERID);
go
