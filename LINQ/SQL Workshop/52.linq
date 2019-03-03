<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

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
		
	