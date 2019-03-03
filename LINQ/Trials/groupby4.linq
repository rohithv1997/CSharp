<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

var result=((from soh in SalesOrderHeaders
			group soh by soh.ShipDate into sohtemp
			orderby sohtemp.Key
			select new{ShipDate=sohtemp.Key,DailyCount=sohtemp.Select(x=>x).Count(),Sum=sohtemp.Select(x=>x.TotalDue).Sum()}))
			.Dump();
			