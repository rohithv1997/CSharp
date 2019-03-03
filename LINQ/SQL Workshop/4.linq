<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

SalesOrderDetails.Where(sod=>sod.LineTotal>2000).Dump();

var Result=(from sod in SalesOrderDetails
where sod.LineTotal>2000
			select sod
			)
		.Dump();