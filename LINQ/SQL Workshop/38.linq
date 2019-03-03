<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

SalesOrderHeaders.Select(soh=>new{soh.SalesOrderNumber,soh.TotalDue,DayOfOrder=soh.OrderDate.DayOfWeek
	,Weekday=(int)soh.OrderDate.DayOfWeek}).Dump();
	
(from soh in SalesOrderHeaders 
select new{soh.SalesOrderNumber,soh.TotalDue,DayOfOrder=soh.OrderDate.DayOfWeek
	,Weekday=(int)soh.OrderDate.DayOfWeek})
	.Dump();