--Name: Scott Diddams
--File: SQLEx06.sql
--Date: 16 Feb 21

use SQLEX06;

go
drop table if exists productlines;
go
create table productlines(
	productLine varchar(50) not null
	Constraint PK_productlines primary key,
	textDescription varchar(max),
	htmlDescription varchar(50),
	image varchar(50)
	);

bulk insert productlines from 'C:\Users\ASUS\MSSA2021\ISTA420\Excercises\SQLEx06\ProductLines.csv'
	with
	(
	rowterminator = '\n',
	fieldterminator = ',',
	firstrow = 1,
	format = 'csv'
	);

--select * from productlines;

drop table if exists products;
go
create table products(
	productCode varchar(50) not null
	Constraint PK_products primary key,
	productName varchar(max),
	productLine varchar(max),
	productScale varchar(max),
	productVendor varchar(max),
	productDescription varchar(max),
	quantityInStock int,
	buyPrice decimal,
	MSRP decimal
	);

bulk insert products from 'C:\Users\ASUS\MSSA2021\ISTA420\Excercises\SQLEx06\products.csv'
	with
	(
	rowterminator = '\n',
	fieldterminator = ',',
	firstrow = 1,
	format = 'csv'
	);

--select * from products;

drop table if exists orderdetails;
go
create table orderdetails(
	orderNumber int not null,
	productCode varchar(50) not null
	Constraint FK_orderdetails foreign key references products(productCode),
	quantityOrdered decimal(10,2),
	priceEach decimal(10,2),
	orderLineNumber int,
	primary key (orderNumber,productCode)
	);

bulk insert orderdetails from 'C:\Users\ASUS\MSSA2021\ISTA420\Excercises\SQLEx06\orderdetails.csv'
	with
	(
	rowterminator = '\n',
	fieldterminator = ',',
	firstrow = 1,
	format = 'csv'
	);

--select * from orderdetails;

drop table if exists orders;
go
create table orders(
	orderNumber int not null,
	orderdate date,
	requiredDate date,
	shippedDate varchar(max),
	status varchar(max),
	comments varchar(max),
	customerNumber int,
	primary key (orderNumber)
	);

bulk insert orders from 'C:\Users\ASUS\MSSA2021\ISTA420\Excercises\SQLEx06\orders.csv'
	with
	(
	rowterminator = '\n',
	fieldterminator = ',',
	firstrow = 1,
	format = 'csv'
	);

--select * from orders;

drop table if exists customers;
go
create table customers(
	customerNumber int not null,
	customerName varchar(max),
	contactLastName varchar(max),
	contactFirstName varchar(max),
	phone varchar(max),
	addressLine1 varchar(max),
	addressLine2 varchar(max),
	city varchar(max),
	state varchar(max),
	postalcode varchar(max),
	country varchar(max),
	salesRepEmployeeNumber varchar(50),
	creditLimit decimal,
	primary key (customerNumber)
	);

bulk insert customers from 'C:\Users\ASUS\MSSA2021\ISTA420\Excercises\SQLEx06\customers.csv'
	with
	(
	rowterminator = '\n',
	fieldterminator = ',',
	firstrow = 1,
	format = 'csv'
	);

--select * from customers;

drop table if exists employees;
go
create table employees(
	employeeNumber varchar(50) not null,
	lastName varchar(50),
	firstName varchar(50),
	extension varchar(50),
	email varchar(50),
	officeCode varchar(50),
	repotsTo varchar(50),
	jobTitle varchar(50),
	primary key (employeeNumber)
	);

bulk insert employees from 'C:\Users\ASUS\MSSA2021\ISTA420\Excercises\SQLEx06\Employees.csv'
	with
	(
	rowterminator = '\n',
	fieldterminator = ',',
	firstrow = 1,
	format = 'csv'
	);

--select * from employees;

drop table if exists offices;
go
create table offices(
	officeCode int not null,
	city varchar(max),
	phone varchar(max),
	addressLine1 varchar(max),
	addressLine2 varchar(max),
	state varchar(max),
	country varchar(max),
	postalCode varchar(max),
	territory varchar(max)
	primary key (officeCode)
	);

bulk insert offices from 'C:\Users\ASUS\MSSA2021\ISTA420\Excercises\SQLEx06\offices.csv'
	with
	(
	rowterminator = '\n',
	fieldterminator = ',',
	firstrow = 1,
	format = 'csv'
	);

--select * from offices;

drop table if exists payments;
go
create table payments(
	customerNumber int not null
	Constraint FK_payments foreign key references customers(customerNumber),
	checkNumber varChar(50),
	paymentDate varchar(max),
	amount decimal,
	primary key (customerNumber,checkNumber)
	);

bulk insert payments from 'C:\Users\ASUS\MSSA2021\ISTA420\Excercises\SQLEx06\payments.csv'
	with
	(
	rowterminator = '\n',
	fieldterminator = ',',
	firstrow = 1,
	format = 'csv'
	);

--select * from payments;

select distinct count(productCode) as productcount from dbo.products

--returns 110

select customerName, city from customers
	where salesRepEmployeeNumber = 'NULL';

--returns 22 customers

select firstName +' '+ lastName as name, jobTitle from employees
	where jobtitle like '%VP%' or jobtitle like '%manager%';

--returns 5 employees

select orderNumber, sum(priceEach*quantityOrdered) as total from orderDetails
	where (priceEach*quantityOrdered) > 5000
	group by orderNumber;

--returns 257 orders

select c.customerName, e.firstName +' '+ e.lastName as rep from customers as c
	join employees as e on c.salesRepEmployeeNumber = e.employeeNumber
	where salesRepEmployeeNumber != 'NULL';

--returns 100 cust-rep pairs

select sum(od.priceEach*od.quantityOrdered) as total
	from orderDetails as od join orders as o on od.orderNumber = o.orderNumber
	where o.customerNumber = 
		(select customerNumber from customers where customerName = 'Atelier graphique')

--returns $24,160

select o.orderDate,sum(od.priceEach*od.quantityOrdered) as total
	from orderDetails as od join orders as o on od.orderNumber = o.orderNumber
	group by o.orderDate
	order by o.orderDate;

--returns 265 lines

select p.productName from products as p
where p.productCode not in (select productCode from orderdetails);

--returns 1985 Toyota Supra

select o.customerNumber, sum(od.priceEach*od.quantityOrdered) as total
	from orderDetails as od join orders as o on od.orderNumber = o.orderNumber
	group by o.customerNumber;

--returns 98 lines

with cte as
(select p.productName, od.orderNumber from products as p join orderdetails as od
on od.productCode = p.productCode)

select o.orderdate, c.productName
	from orders as o join cte as c on o.ordernumber = c.ordernumber
	order by o.orderdate;

--returns 2996 lines

with cte as
(select p.productName, od.orderNumber from products as p join orderdetails as od
on od.productCode = p.productCode)

select o.orderdate, c.productName
	from orders as o join cte as c on o.ordernumber = c.ordernumber
	where c.productName = '1940 Ford Pickup Truck'
	order by o.orderdate;

--returns 28 Lines


with cte as
(select o.customerNumber, od.orderNumber, sum(od.priceEach*od.quantityOrdered) as total 
from orderDetails as od join orders as o on o.orderNumber = od.orderNumber
	group by o.customerNumber, od.orderNumber)

select c.customerName, ct.orderNumber, ct.total from customers as c
	join cte as ct on c.customerNumber = ct.customerNumber
	where ct.total > 25000
	group by c.customerName, ct.orderNumber, ct.total;

--returns 213 lines

with cte as
(select o.customerNumber, od.orderNumber, sum(od.priceEach*od.quantityOrdered) as total 
from orderDetails as od join orders as o on o.orderNumber = od.orderNumber
	group by o.customerNumber, od.orderNumber)

select e.lastName, e.firstName, ct.orderNumber, (ct.total*0.05) as commission
	from ((customers as c
	join cte as ct on c.customerNumber = ct.customerNumber) 
	join employees as e on e.employeeNumber = c.salesRepEmployeeNumber)
	group by c.salesRepEmployeeNumber, ct.orderNumber, ct.total,e.lastName, e.firstName
	order by e.lastName;

--326 lines

select datediff(day, min(orderDate), max(orderdate)) from orders;

--876

select avg(datediff(day,orderdate, shippeddate)) as avgDiff, customerNumber
	from orders
	where shippeddate != 'NULL'
	group by customerNumber;

--98 results