<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

(from e in Employees
join m in Employees on e.ManagerID equals m.EmployeeID
select new{EmployeeID=e.EmployeeID,Employee_Title=e.Title,ManagerID=m.EmployeeID,Manager_Title=m.Title}).Dump();

(from e in Employees
join m in Employees on e.ManagerID equals m.EmployeeID
join c1 in Contacts on e.ContactID equals c1.ContactID
join c2 in Contacts on m.ContactID equals c2.ContactID
select new{EmployeeID=e.EmployeeID,Employee_FName=c1.FirstName,ManagerID=m.EmployeeID,Manager_FName=c2.FirstName}).Dump();

(from e in Employees
	join m in Employees on e.ManagerID equals m.EmployeeID
	join epay1 in EmployeePayHistories on e.EmployeeID equals epay1.EmployeeID
	join epay2 in EmployeePayHistories on m.EmployeeID equals epay2.EmployeeID
	orderby e.ManagerID
	select new{EmployeeID=e.EmployeeID,Employee_Monthly_Salary=epay1.Rate*9*30*epay1.PayFrequency,
		ManagerID=m.EmployeeID,Manager_Monthly_Salary=epay2.Rate*9*30*epay2.PayFrequency}).Dump();
	
var result=(from e in Employees
	join m in Employees on e.ManagerID equals m.EmployeeID
	join c in Contacts on m.ContactID equals c.ContactID
	select new{EmployeeID=e.EmployeeID,ContactID=m.ContactID,ManagerID=m.EmployeeID,Manager_Name=c.FirstName+" "+c.LastName});
result.GroupBy(r=>r.Manager_Name)
	.Select(x=>new{ManagerName=x.Key,EmployeeCount=x.Count()})
	.Dump();
	
	
(from employee in Employees
	join manager in Employees on employee.ManagerID equals manager.EmployeeID into ManagerTemp
from manager in ManagerTemp.DefaultIfEmpty()
	select new{employee.EmployeeID,ManagerID=(int?)manager.EmployeeID}).Dump();
	
	
(from salesperson in SalesPersons
	join salesterritory in SalesTerritories on salesperson.TerritoryID equals salesterritory.TerritoryID into TerritoryTemp
from salesterritory in TerritoryTemp.DefaultIfEmpty()
	select new{salesperson.SalesPersonID,SalesTerritoryName=salesterritory.Name??"*Not Provided*"}).Dump();
	

(from customer in Customers
	join address in Address on customer.AddressID equals address.AddressID into AddressTemp
from address in AddressTemp.DefaultIfEmpty()
	join state in State on address.StateID equals state.StateID into StateTemp
from state in StateTemp.DefaultIfEmpty()
	join country in Country on state.CountryID equals country.CountryID into CountryTemp
from country in CountryTemp.DefaultIfEmpty()
select new{customer.CustomerID,address.AddressLine1,State=state.Name,Country=country.Name}).Dump();

	
