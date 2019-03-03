<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

var Result=(from soh in SalesOrderHeaders
			where soh.OrderDate==Convert.ToDateTime("2004-06-04")
			select soh)
			.Dump();
			
SalesOrderHeaders.Where(soh=>soh.OrderDate==Convert.ToDateTime("2004-06-04"))
				.Dump();