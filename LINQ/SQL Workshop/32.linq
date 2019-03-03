<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

SalesOrderHeaders.GroupBy(soh=>soh.OrderDate)
	.Select(sohtemp=>new{OrderDate=sohtemp.Key,Sum=sohtemp.Sum(x=>x.TotalDue)})
	.Dump();



(from soh in SalesOrderHeaders
group soh by soh.OrderDate into sohtemp
select new{OrderDate=sohtemp.Key,Sum=sohtemp.Sum(x=>x.TotalDue)})
	.Dump();