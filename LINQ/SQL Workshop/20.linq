<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

SalesOrderHeaders.OrderBy(soh=>soh.TotalDue)
	.Select(x=>new{x.SalesOrderNumber,x.TotalDue})
	.Dump();
	
(from soh in SalesOrderHeaders
orderby soh.TotalDue
select new{soh.SalesOrderNumber,soh.TotalDue})
	.Dump();