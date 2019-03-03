<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

SalesOrderDetails.Where(sod=>sod.LineTotal>5000)
	.GroupBy(sod=>sod.SalesOrderID)
	.Select(sodtemp=>new{SalesOrderID=sodtemp.Key,min=sodtemp.Min(x=>x.OrderQty),max=sodtemp.Max(x=>x.OrderQty)})
	.Dump();



(from sod in SalesOrderDetails
where sod.LineTotal>5000
group sod by sod.SalesOrderID into sodtemp
select new{SalesOrderID=sodtemp.Key,min=sodtemp.Min(x=>x.OrderQty),max=sodtemp.Max(x=>x.OrderQty)})
	.Dump();
	
