create table Countries
(
id uniqueidentifier not null primary key,
nameCountry nvarchar(50) not null unique
) 
go
create table Cities
(
id uniqueidentifier not null primary key,
nameCity nvarchar(50) not null,
countryId uniqueidentifier not null,
CONSTRAINT [FK_Cities_ToCountries] FOREIGN KEY ([countryId]) REFERENCES [dbo].[Countries] ([Id])
)
go
create table Streets
(
id uniqueidentifier not null primary key,
nameStreet nvarchar(50) not null,
cityId uniqueidentifier not null,
CONSTRAINT [FK_Streets_ToCities] FOREIGN KEY ([cityId]) REFERENCES [dbo].[Cities] ([Id])
)
