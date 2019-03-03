<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

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