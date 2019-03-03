<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

SalesOrderHeaders.Where(soh=>soh.OrderDate==Convert.ToDateTime("2001-07-01") && soh.TotalDue>10000)
				.Select(x=>new{Order_Number=x.SalesOrderID,x.OrderDate,x.Status,TotalCost=x.TotalDue})
				.Dump();
				
				
(from soh in SalesOrderHeaders
where soh.OrderDate==Convert.ToDateTime("2001-07-01") && soh.TotalDue>10000
select new{Order_Number=soh.SalesOrderID,soh.OrderDate,soh.Status,TotalCost=soh.TotalDue})
	.Dump();