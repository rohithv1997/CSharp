<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

Customers.Where(c=>c.TerritoryID==4)
		.Select(c=>new{ c.CustomerID,c.AccountNumber}).Dump();
//Result.Dump();

var Result=(from c in Customers
			where c.TerritoryID==4
			select new{c.CustomerID,c.AccountNumber})
			.Dump();