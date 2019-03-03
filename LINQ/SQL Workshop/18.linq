<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

SalesOrderHeaders.OrderByDescending(soh=>soh.TotalDue)
	.Select(x=>new{x.SalesOrderID,x.TotalDue})
	.Dump();
	
(from soh in SalesOrderHeaders
orderby soh.TotalDue descending
select new{soh.SalesOrderID,soh.TotalDue})
	.Dump();