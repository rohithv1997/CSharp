<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

Employees.GroupBy(e=>e.ManagerID)
	.Select(emp=>new {MID=emp.Key,ECount=emp.Count()})
	.Where(ec=>ec.ECount>10)
	.Dump();