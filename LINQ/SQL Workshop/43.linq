<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

Employees.Select(e=>e.Title).Distinct().Count().Dump();

(from e in Employees
select new{Count=e.Title})
	.Distinct()
	.Count()
	.Dump();