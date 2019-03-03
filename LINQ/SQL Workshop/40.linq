<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

Employees.AsEnumerable()
	.Select(x=>new{x.EmployeeID,Month=x.HireDate.ToString("MMMM"),Year=x.HireDate.Year})
	.ToList()
	.Dump();
	
(from e in Employees
select new{e.EmployeeID,Month=e.HireDate,Year=e.HireDate})
	.ToList()
	.Select(x=>new{x.EmployeeID,Month=x.Month.ToString("MMMM"),Year=x.Year.ToString("yyyy")})
	.Dump();