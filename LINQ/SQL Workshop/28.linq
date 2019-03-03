<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

SalesOrderDetails.GroupBy(x=>x.ProductID)
	.Where(sodtemp=>sodtemp.Sum(x=>x.LineTotal)>10000)
	.Select(sodtemp=>new{ProductID=sodtemp.Key,SumTotal=sodtemp.Sum(x=>x.LineTotal)})
	.Dump();
	
(from sod in SalesOrderDetails
group sod by sod.ProductID into sodtemp
where sodtemp.Sum(x=>x.LineTotal)>10000
select new{ProductID=sodtemp.Key,SumTotal=sodtemp.Sum(x=>x.LineTotal)})
	.Dump();