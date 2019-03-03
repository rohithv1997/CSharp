<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

//1
var Result=from c in Customers select c;
Result.Dump();

Customers.Dump();

//2
var Result=from cc in CreditCards 
			select new{Credit_Card_ID=cc.CreditCardID,Credit_Card_Type=cc.CardType,Credit_Card_Number=cc.CardNumber,
						Expiry_Year=cc.ExpYear};					
Result.Dump();

CreditCards.Select(cc=>new{Credit_Card_ID=cc.CreditCardID,Credit_Card_Type=cc.CardType,Credit_Card_Number=cc.CardNumber,
						Expiry_Year=cc.ExpYear})
			.Dump();

//3
Customers.Where(c=>c.TerritoryID==4)
		.Select(c=>new{ c.CustomerID,c.AccountNumber}).Dump();
		
var Result=(from c in Customers
			where c.TerritoryID==4
			select new{c.CustomerID,c.AccountNumber})
			.Dump();

//4
SalesOrderDetails.Where(sod=>sod.LineTotal>2000).Dump();

var Result=(from sod in SalesOrderDetails
	where sod.LineTotal>2000
			select sod
			)
		.Dump();

//5
SalesOrderDetails.Where(sod=>sod.ProductID==843).Dump();

var Result=(from sod in SalesOrderDetails
			where sod.ProductID==843
			select sod).Dump();
			
//6
var Result=(from soh in SalesOrderHeaders
			where soh.OrderDate==Convert.ToDateTime("2004-06-04")
			select soh)
			.Dump();
			
SalesOrderHeaders.Where(soh=>soh.OrderDate==Convert.ToDateTime("2004-06-04"))
				.Dump();
				
//7
SalesOrderDetails.Select(sod=>new{Order_Id=sod.SalesOrderID,Order_Quantity=sod.OrderQty,
								Unit_Price=sod.UnitPrice,Total_Cost=sod.OrderQty*sod.UnitPrice})
				.Dump();
				
(from sod in SalesOrderDetails
select new{Order_Id=sod.SalesOrderID,Order_Quantity=sod.OrderQty,
		Unit_Price=sod.UnitPrice,Total_Cost=sod.OrderQty*sod.UnitPrice})
	.Dump();
	
//8
SalesOrderHeaders.Where(soh=>soh.TotalDue>=2000 && soh.TotalDue<=3000)
				.Dump();
				
(from soh in SalesOrderHeaders
where soh.TotalDue>=2000 && soh.TotalDue<=3000
select soh).Dump();

//9
SalesTerritories.Where(st=>st.TerritoryID==1)
				.Select(salest=>new{salest.Name,salest.CountryRegionCode,salest.SalesYTD})
				.Dump();
	
(from st in SalesTerritories
where st.TerritoryID==1
select new{st.Name,st.CountryRegionCode,st.SalesYTD})
	.Dump();
	
//10
SalesOrderHeaders.Where(soh=>soh.TaxAmt>10000)
				.Dump();
				
(from soh in SalesOrderHeaders
where soh.TaxAmt>10000
select soh)
	.Dump();

//11
SalesTerritories.Where(st=>new string[]{"Canada","France","Germany"}.Contains(st.Name))
				.Dump();
				
(from st in SalesTerritories
where new string[]{"Canada","France","Germany"}.Contains(st.Name)
select st).Dump();

//12
SalesPersons.Where(sp=>new int?[]{2,4}.Contains(sp.TerritoryID))
	.Select(x=>new{x.SalesPersonID,x.TerritoryID})
	.Dump();
	
(from sp in SalesPersons
where new int?[]{2,4}.Contains(sp.TerritoryID)
select new{sp.SalesPersonID,sp.TerritoryID})
	.Dump();
	
//13
CreditCards.Where(cc=>cc.CardType=="Vista" && cc.ExpYear==2006).Dump();

(from cc in CreditCards
where cc.CardType=="Vista" && cc.ExpYear==2006
select cc ).Dump();

//14
SalesOrderHeaders.Where(soh=>soh.ShipDate>Convert.ToDateTime("2004-07-12")).Dump();

(from soh in SalesOrderHeaders
where soh.ShipDate>Convert.ToDateTime("2004-07-12")
select soh).Dump();

//15
SalesOrderHeaders.AsEnumerable()
	.Select(soh=>new{SalesOrderID=soh.SalesOrderID,Territory_Name=soh.TerritoryID,
								Month=soh.OrderDate.ToString("MMMM"),Year=soh.OrderDate.Year})
								.ToList()
								.Dump();
								
var Result=(from soh in SalesOrderHeaders
select new{SalesOrderID=soh.SalesOrderID,Territory_Name=soh.TerritoryID,
		Month=soh.OrderDate,Year=soh.OrderDate.Year})
		.ToList();
	Result.Select(x=>new{x.SalesOrderID,x.Territory_Name,Month=x.Month.ToString("MMMM"),x.Year})
	.Dump();

//16
SalesOrderHeaders.Where(soh=>soh.OrderDate==Convert.ToDateTime("2001-07-01") && soh.TotalDue>10000)
				.Select(x=>new{Order_Number=x.SalesOrderID,x.OrderDate,x.Status,TotalCost=x.TotalDue})
				.Dump();
				
				
(from soh in SalesOrderHeaders
where soh.OrderDate==Convert.ToDateTime("2001-07-01") && soh.TotalDue>10000
select new{Order_Number=soh.SalesOrderID,soh.OrderDate,soh.Status,TotalCost=soh.TotalDue})
	.Dump();

//17
SalesOrderHeaders.Where(soh=>(soh.OnlineOrderFlag)).Dump();

(from soh in SalesOrderHeaders
where soh.OnlineOrderFlag==true
select soh).Dump();

//18
SalesOrderHeaders.OrderByDescending(soh=>soh.TotalDue)
	.Select(x=>new{x.SalesOrderID,x.TotalDue})
	.Dump();
	
(from soh in SalesOrderHeaders
orderby soh.TotalDue descending
select new{soh.SalesOrderID,soh.TotalDue})
	.Dump();
	
//19
SalesOrderHeaders.Where(soh=>soh.TotalDue<2000)
	.Select(x=>new{x.SalesOrderID,x.TaxAmt})
	.Dump();
	
(from soh in SalesOrderHeaders
where soh.TotalDue<2000
select new{soh.SalesOrderID,soh.TaxAmt})
	.Dump();
	
//20
SalesOrderHeaders.OrderBy(soh=>soh.TotalDue)
	.Select(x=>new{x.SalesOrderNumber,x.TotalDue})
	.Dump();
	
(from soh in SalesOrderHeaders
orderby soh.TotalDue
select new{soh.SalesOrderNumber,soh.TotalDue})
	.Dump();
	
//21
SalesOrderHeaders.Max(x=>x.TotalDue).Dump();
SalesOrderHeaders.Min(x=>x.TotalDue).Dump();
SalesOrderHeaders.Average(x=>x.TotalDue).Dump();

(from soh in SalesOrderHeaders
select soh.TotalDue).Max().Dump();
(from soh in SalesOrderHeaders
select soh.TotalDue).Min().Dump();
(from soh in SalesOrderHeaders
select soh.TotalDue).Average().Dump();

//22
SalesOrderHeaders.Sum(x=>x.TotalDue).Dump();

(from soh in SalesOrderHeaders
select soh.TotalDue).Sum().Dump();

//23
SalesOrderHeaders.Where(x=>x.OrderDate.Year==2001)
			.OrderByDescending(x=>x.TotalDue)
			.Take(5)
			.Select(x=>new{x.SalesOrderID})
			.Dump();
			
(from soh in SalesOrderHeaders
	where soh.OrderDate.Year==2001
	orderby soh.TotalDue descending
	select new{soh.SalesOrderID})
	.Take(5).Dump();

//24
Currencies.Where(x=>x.Name.Contains("Dollar")).Select(x=>x).Dump();

(from c in Currencies
where c.Name.Contains("Dollar")
select c).Dump();

//25
Currencies.Where(x=>x.Name.StartsWith("N")).Select(x=>x).Dump();

(from c in Currencies
where c.Name.StartsWith("N")
select c).Dump();

//26
SalesPersons.Where(sp=>sp.SalesQuota!=null)
	.Select( x=>new{x.SalesPersonID,x.TerritoryID,x.SalesQuota})
	.Dump();
	
(from sp in SalesPersons
where sp.SalesQuota!=null
select new{sp.SalesPersonID,sp.TerritoryID,sp.SalesQuota})
	.Dump();
	
//27

//28
SalesOrderDetails.GroupBy(x=>x.ProductID)
	.Where(sodtemp=>sodtemp.Sum(x=>x.LineTotal)>10000)
	.Select(sodtemp=>new{ProductID=sodtemp.Key,SumTotal=sodtemp.Sum(x=>x.LineTotal)})
	.Dump();
	
(from sod in SalesOrderDetails
group sod by sod.ProductID into sodtemp
where sodtemp.Sum(x=>x.LineTotal)>10000
select new{ProductID=sodtemp.Key,SumTotal=sodtemp.Sum(x=>x.LineTotal)})
	.Dump();
	
//29

//30
SalesPersons.OrderByDescending(s=>s.Bonus)
   .Take(3)
   .Dump();

(from s in SalesPersons
	orderby s.Bonus descending
	select s).Take(3).Dump();

//31
Stores.Where(s=>s.Name.Contains("Bike")).Dump();

(from s in Stores
where s.Name.Contains("Bike")
select s)
	.Dump();

//32
SalesOrderHeaders.GroupBy(soh=>soh.OrderDate)
	.Select(sohtemp=>new{OrderDate=sohtemp.Key,Sum=sohtemp.Sum(x=>x.TotalDue)})
	.Dump();



(from soh in SalesOrderHeaders
group soh by soh.OrderDate into sohtemp
select new{OrderDate=sohtemp.Key,Sum=sohtemp.Sum(x=>x.TotalDue)})
	.Dump();
	
//33

//34
SalesOrderDetails.Where(sod=>sod.LineTotal>5000)
	.GroupBy(sod=>sod.SalesOrderID)
	.Select(sodtemp=>new{SalesOrderID=sodtemp.Key,min=sodtemp.Min(x=>x.OrderQty),max=sodtemp.Max(x=>x.OrderQty)})
	.Dump();

(from sod in SalesOrderDetails
where sod.LineTotal>5000
group sod by sod.SalesOrderID into sodtemp
select new{SalesOrderID=sodtemp.Key,min=sodtemp.Min(x=>x.OrderQty),max=sodtemp.Max(x=>x.OrderQty)})
	.Dump();

//35
SalesOrderHeaders.Where(soh=>soh.TotalDue>5000)
	.GroupBy(soh=>soh.SalesOrderID)
	.Select(sohtemp=>new{SalesOrderID=sohtemp.Key,Average_Value=sohtemp.Average(x=>x.TotalDue)})
	.Dump();

(from soh in SalesOrderHeaders
where soh.TotalDue>5000
group soh by soh.SalesOrderID into sohtemp
select new{SalesOrderID=sohtemp.Key,Average_Value=sohtemp.Average(x=>x.TotalDue)})
	.Dump();

//36
CreditCards.Select(x=>x.CardType).Distinct().Dump();

(from cc in CreditCards
group cc by cc.CardType into cctemp
select cctemp.Key).Dump();

//37
Stores.Select(so=>new{so.CustomerID,Name=so.Name.Substring(0,15),so.SalesPersonID})
	.Dump();

(from so in Stores
select new{so.CustomerID,Name=so.Name.Substring(0,15),so.SalesPersonID})
	.Dump();

//38
SalesOrderHeaders.Select(soh=>new{soh.SalesOrderNumber,soh.TotalDue,DayOfOrder=soh.OrderDate.DayOfWeek
	,Weekday=(int)soh.OrderDate.DayOfWeek}).Dump();
	
(from soh in SalesOrderHeaders 
select new{soh.SalesOrderNumber,soh.TotalDue,DayOfOrder=soh.OrderDate.DayOfWeek
	,Weekday=(int)soh.OrderDate.DayOfWeek})
	.Dump();
	
//39

//40
Employees.AsEnumerable()
	.Select(x=>new{x.EmployeeID,Month=x.HireDate.ToString("MMMM"),Year=x.HireDate.Year})
	.ToList()
	.Dump();
	
(from e in Employees
select new{e.EmployeeID,Month=e.HireDate,Year=e.HireDate})
	.ToList()
	.Select(x=>new{x.EmployeeID,Month=x.Month.ToString("MMMM"),Year=x.Year.ToString("yyyy")})
	.Dump();
	
//41
Contacts.Where(x=>x.LastName.EndsWith("an") && x.LastName.Length==3)
	.Select(c=>new{c.FirstName,c.LastName})
	.Dump();

(from con in Contacts
where con.LastName.EndsWith("an") && con.LastName.Length==3
select new{con.FirstName,con.LastName})
	.Dump();

//42
Employees.Where(x=>x.Title.StartsWith("Production Technician"))
	.Select(emp=>new{AverageVacationHours=Employees.Average(emp2=>emp2.VacationHours),SumOfSickLeaveHours=Employees.Sum(x=>x.SickLeaveHours)})
	.Distinct()
	.Dump();
	
(from employee in Employees
	where employee.Title.Contains("Production Technician")
	select new{AverageVacationHours=Employees.Average(emp2=>emp2.VacationHours),SumOfSickLeaveHours=Employees.Sum(x=>x.SickLeaveHours)})
	.Distinct()
	.Dump();

//43
Employees.Select(e=>e.Title).Distinct().Count().Dump();

(from e in Employees
select new{Count=e.Title})
	.Distinct()
	.Count()
	.Dump();
	
//44
(from sp in SalesPersons
	join st in SalesTerritories on sp.TerritoryID equals st.TerritoryID into territorytemp
from st in territorytemp.DefaultIfEmpty()
	select new{sp.SalesPersonID,Territory_Name=st.Name??"***"})
	.Dump();
	
//45
(from soh in SalesOrderHeaders
	join sod in SalesOrderDetails on soh.SalesOrderID equals sod.SalesOrderID into sodtemp
from sod in sodtemp.DefaultIfEmpty()
	select new{OrderID=soh.SalesOrderID,sod.ProductID,soh.OrderDate})
	.Dump();

//46
(from sp in SalesPersons
	join st in SalesTerritories on sp.TerritoryID equals st.TerritoryID into territorytemp
from st in territorytemp.DefaultIfEmpty()
	select new{sp.SalesPersonID,Territory_Name=st.Name})
	.Dump();

//47
(from soh in SalesOrderHeaders
	join cc in CreditCards on soh.CreditCardID equals cc.CreditCardID into cctemp
from cc in cctemp.DefaultIfEmpty()
	select new{RoundedOffTotalDue=(int)(soh.TotalDue+1),soh.SalesOrderID,cc.CardType})
.Dump();

//48
(from soh in SalesOrderHeaders
join st in SalesTerritories on soh.TerritoryID equals st.TerritoryID
select new{soh.OrderDate,st.Name,soh.SalesOrderID})
	.ToList()
	.Select(x=>new{OrderDate=x.OrderDate.ToString("dd/MM/yyyy"),TerritoryName=x.Name,SalesOrderID=x.SalesOrderID})
	.Dump();

//49
(from soh in SalesOrderHeaders
where soh.OrderDate.Month==5 && soh.OrderDate.Year==2004
join st in SalesTerritories on soh.TerritoryID equals st.TerritoryID
select new{soh.SalesOrderID,st.Name})
	.Dump();
	
SalesOrderHeaders.Where(x=>(x.OrderDate.Month==5 && x.OrderDate.Year==2004))
	.Join(SalesTerritories,
		soh1=>soh1.TerritoryID,
		st2=>st2.TerritoryID,
		(soh,st)=>new{ SalesOrderID=soh.SalesOrderID,TerritoryName=st.Name})
	.Dump();
	
//50
(from l in Locations
where l.CostRate>12
orderby l.CostRate descending
select l).Dump();

Locations.Where(x=>x.CostRate>12)
		.OrderByDescending(x=>x.CostRate)
		.Select(x=>x)
		.Dump();
		
//51
var result1=(from e in Employees
	where e.Gender=='F'
	select new{e.ContactID,e.EmployeeID,e.ManagerID});
	
var result2=(from r in result1
		join m in Employees on r.ManagerID equals m.EmployeeID into managertemp
	from m in managertemp.DefaultIfEmpty()
		select new{ec=r.ContactID,eid=r.EmployeeID,mid=m.EmployeeID,mc=m.ContactID});
	
var result3=(from r in result2
		join c1 in Contacts on r.ec equals c1.ContactID into c1temp
	from c1 in c1temp.DefaultIfEmpty()
		select new{Employee_Name=c1.FirstName+" "+c1.LastName,r.eid,r.mid,r.mc});
	
var result4=(from r in result3
		join c2 in Contacts on r.mc equals c2.ContactID into c2temp
	from c2 in c2temp.DefaultIfEmpty()
		select new{EmployeeID=r.eid,r.Employee_Name,ManagerID=r.mid,Manager_Name=c2.FirstName+" "+c2.LastName});

result4.Dump();

//52
var result1=(from e in Employees
	where e.MaritalStatus=='S' && e.Gender=='M' && e.BirthDate.Year<1980
	join ea in EmployeeAddresses on e.EmployeeID equals ea.EmployeeID
	join a in Addresses on ea.AddressID equals a.AddressID
	join sp in StateProvinces on a.StateProvinceID equals sp.StateProvinceID
	join c in CountryRegions on sp.CountryRegionCode equals c.CountryRegionCode
	join con in Contacts on e.ContactID equals con.ContactID
	orderby e.EmployeeID
	select new{e.EmployeeID,EmployeeName=con.FirstName+" "+con.LastName,
		a.AddressLine1,AddressLine2=a.AddressLine2??" ",a.City,
		StateProvinceName=sp.Name,
		Country=c.Name
		}).Dump();
		
//53
var result1=Employees.GroupBy(emp=>emp.ManagerID)
					.OrderByDescending(x=>x.Count())
					.Select(emp=>new{emp.Key,count=emp.Count()});

(from r in result1
	join m in Employees on r.Key equals m.EmployeeID
	join c in Contacts on m.ContactID equals c.ContactID
	select new{m.EmployeeID,Name=c.FirstName+" "+c.LastName})
	.First()
	.Dump();

//54
var result1=Employees.Where(x=>x.Gender=='F')
					.GroupBy(emp=>emp.ManagerID)
					.OrderByDescending(x=>x.Count())
					.Select(emp=>new{emp.Key,count=emp.Count()});

(from r in result1
	join m in Employees on r.Key equals m.EmployeeID
	join c in Contacts on m.ContactID equals c.ContactID
	select new{m.EmployeeID,Name=c.FirstName+" "+c.LastName})
	.First()
	.Dump();

//55
(from emp in Employees
	join ea in EmployeeAddresses on emp.EmployeeID equals ea.EmployeeID
	join a in Addresses on ea.AddressID equals a.AddressID
	join sp in StateProvinces on a.StateProvinceID equals sp.StateProvinceID
	select new{emp.EmployeeID,sp.Name})
	.GroupBy(x=>x.Name)
	.Select(det=>new{StateName=det.Key,Count=det.Count()})
	.Dump();

//56
var result1=EmployeePayHistories.GroupBy(x=>x.EmployeeID)
								.Select(x=>new{x.Key,date=x.Max(y=>y.RateChangeDate)});
var result2=(from r in result1
	join eph in EmployeePayHistories on r.Key equals eph.EmployeeID
	where eph.RateChangeDate==r.date
	select new{eph.EmployeeID,CTC=eph.Rate*eph.PayFrequency*9*365});

var result3=result2.OrderByDescending(x=>x.CTC)
	.Select(x=>x)
	.Take(2).Skip(1);
	
(from r in result3
	join e in Employees on r.EmployeeID equals e.EmployeeID
	join c in Contacts on e.ContactID equals c.ContactID
	select new{e.EmployeeID,Name=c.FirstName+" "+c.LastName,r.CTC}).Dump();

//57
var result1=(from eph1 in EmployeePayHistories
	join eph2 in EmployeePayHistories on eph1.EmployeeID equals eph2.EmployeeID into jtemp
	from jt in jtemp where eph1.RateChangeDate<jt.RateChangeDate
	group jt by new{eph1.EmployeeID,eph1.RateChangeDate} into jointemp
	select new{jointemp.Key.EmployeeID,jointemp.Key.RateChangeDate,varieddate=jointemp.Min(x=>x.RateChangeDate)})
	.OrderBy(x=>x.EmployeeID);
	
var result2=(from r1 in result1
	join eph3 in EmployeePayHistories on new{a=r1.EmployeeID,r1.RateChangeDate} equals new{a=eph3.EmployeeID,eph3.RateChangeDate}
	select new{r1.EmployeeID,r1.RateChangeDate,CTC=((double)eph3.Rate*(double)eph3.PayFrequency*8d*(r1.varieddate-r1.RateChangeDate).TotalDays)})
	.OrderBy(x=>x.EmployeeID);
	
var T1= EmployeePayHistories.GroupBy(x=>x.EmployeeID)
		.Select(e=>new{EmployeeID=e.Key,RateChangeDate=e.Max(x=>x.RateChangeDate)})
		.OrderBy(x=>x.EmployeeID);

var result3=(from T in T1
	join eph4 in EmployeePayHistories on new{a=T.EmployeeID,T.RateChangeDate} equals new{a=eph4.EmployeeID,eph4.RateChangeDate}
	select new{T.EmployeeID,T.RateChangeDate,CTC=((double)eph4.Rate*(double)eph4.PayFrequency*8d*(DateTime.Now.Date-T.RateChangeDate).TotalDays)})
	.OrderBy(x=>x.EmployeeID);
	
var result4=(from r2 in result2 select r2).Concat(from r3 in result3 select r3)
	.Select(x=>x)
	.OrderBy(x=>x.EmployeeID);
	
var result5=result4.GroupBy(x=>x.EmployeeID)
	.Select(tmp=>new{EmployeeID=tmp.Key,TotalCTC=tmp.Sum(x=>x.CTC)});
	
var result6=(from r in result5
	join e in Employees on r.EmployeeID equals e.EmployeeID
	join c in Contacts on e.ContactID equals c.ContactID
	select new{e.EmployeeID,Name=c.FirstName+" "+c.LastName,r.TotalCTC})
	.OrderBy(x=>x.EmployeeID)
	.Dump();
	

