<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

Stores.Select(so=>new{so.CustomerID,Name=so.Name.Substring(0,15),so.SalesPersonID})
	.Dump();


(from so in Stores
select new{so.CustomerID,Name=so.Name.Substring(0,15),so.SalesPersonID})
	.Dump();
	
