<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

SalesOrderHeaders.Max(x=>x.TotalDue).Dump();
SalesOrderHeaders.Min(x=>x.TotalDue).Dump();
SalesOrderHeaders.Average(x=>x.TotalDue).Dump();

(from soh in SalesOrderHeaders
select soh.TotalDue).Max().Dump();
(from soh in SalesOrderHeaders
select soh.TotalDue).Min().Dump();
(from soh in SalesOrderHeaders
select soh.TotalDue).Average().Dump();