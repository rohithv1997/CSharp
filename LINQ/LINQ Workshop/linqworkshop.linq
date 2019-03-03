//7
(from e in Employees
join m in Employees on e.ReportsTo equals m.EmployeeID
where (DateTime.Now.Year-((DateTime)m.BirthDate).Year)>30
select new{m.FirstName,m.LastName,Age=(DateTime.Now.Year-(Convert.ToDateTime(m.BirthDate).Year))})
.Distinct()
.Dump();

//8
var list=Employees.Join(Employees,e=>e.ReportsTo,m=>m.EmployeeID,(e,m)=>m.EmployeeID).Distinct().ToList();
var result=Employees.Where(e=>!(list.Contains(e.EmployeeID)) &&  e.Salary<25000).Select(x=>x).Count().Dump();

//9
var array=new List<int>(){5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
var result=(from l in array
			where l<5
			select l).Dump();
			
//10
var array1=new List<int>(){5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
var array2=new List<int>(){1, 2, 10, 6};
var result=(from a in array1
	from b in array2
	where a<b
	select new{a,b}).Distinct().Dump();
	
//11
Products.Where(p=>p.UnitPrice>3.00m && 	p.UnitsInStock>0 && !p.Discontinued)
	.Select(x=>new{Id=x.ProductID,Name=x.ProductName,x.UnitPrice,TotalStock=x.UnitsInStock,IsAlive=!x.Discontinued})
	.Dump();
	
//12
Products.Where(p=>p.UnitsInStock>2)
	.Select(x=>new{Id=x.ProductID,ProductStockName=x.ProductName,x.UnitPrice,TotalStock=x.UnitsInStock,IsAlive=!x.Discontinued})
	.Dump();
	
//13
var array=new List<int>(){5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
array.Sort();
array.Dump();

//14
(from e in Employees
join m in Employees on e.ReportsTo equals m.EmployeeID
select new{m.FirstName,m.LastName}).Distinct().Dump();

//15

//16

//17
var array=new List<int>(){5, 4, 1, 3, 9, 8, 6,6,6,7, 7, 2, 0};
array.Sort();
var x=(from l in array
	where l>5
	select l).FirstOrDefault();

var y=(from l in array
where l>x
select l).FirstOrDefault();
(from l in array where l==y select l).Dump();

//18
(from e in Employees 
orderby e.ReportsToChildren.Count() descending
select new{e.EmployeeID,ChildrenCount=e.ReportsToChildren.Count()}).ToList().First().Dump();

//19
(from od in OrderDetails
join o in Orders on od.OrderID equals o.OrderID
join p in Products on od.ProductID equals p.ProductID
where p.UnitPrice>100
orderby o.OrderDate
select o).First().Dump();

//20
(from c in Customers
join o in Orders on c.CustomerID equals o.CustomerID
join od in OrderDetails on o.OrderID equals od.OrderID
group od by c.CustomerID into ctemp
where ctemp.Sum(o=>((double)(o.UnitPrice*o.Quantity)-(o.Discount*o.Quantity)))>50000
select new{ctemp.Key,Sum=ctemp.Sum(o=>((double)(o.UnitPrice*o.Quantity)-(o.Discount*o.Quantity)))}).Dump();

//21
(from c in Customers
join o in Orders on c.CustomerID equals o.CustomerID
join od in OrderDetails on o.OrderID equals od.OrderID
group od by c.CustomerID into ctemp
orderby ctemp.Sum(o=>((double)(o.Discount*o.Quantity))) descending
select new{ctemp.Key,Sum=ctemp.Sum(o=>((double)(o.Discount*o.Quantity)))}).First().Dump();
