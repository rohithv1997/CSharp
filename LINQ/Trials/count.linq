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


Employees.Select(x=>x).Dump();

Employees.GroupBy(e=>e.ManagerID)
		.OrderByDescending(x=>x.Count())
		.Select(x=>new{x.Key,z=x.Count()})
		.First()
		.Dump();
		
(from e in Employees
group e by e.ManagerID into etemp
orderby etemp.Count() descending
select new{etemp.Key,count=etemp.Count()})
	.First()
	.Dump();