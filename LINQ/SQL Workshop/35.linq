<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

SalesOrderHeaders.Where(soh=>soh.TotalDue>5000)
	.GroupBy(soh=>soh.SalesOrderID)
	.Select(sohtemp=>new{SalesOrderID=sohtemp.Key,Average_Value=sohtemp.Average(x=>x.TotalDue)})
	.Dump();

(from soh in SalesOrderHeaders
where soh.TotalDue>5000
group soh by soh.SalesOrderID into sohtemp
select new{SalesOrderID=sohtemp.Key,Average_Value=sohtemp.Average(x=>x.TotalDue)})
	.Dump();