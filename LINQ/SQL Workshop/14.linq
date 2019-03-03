<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

SalesOrderHeaders.Where(soh=>soh.ShipDate>Convert.ToDateTime("2004-07-12")).Dump();

(from soh in SalesOrderHeaders
where soh.ShipDate>Convert.ToDateTime("2004-07-12")
select soh).Dump();