<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

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