<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

SalesOrderHeaders.GroupBy(sd=>sd.ShipDate)
				.Select(c=>new{ShipDate=c.Key,SalesCount=c.Count(),Sum=c.Sum(t=>t.TotalDue)})
				.Dump();