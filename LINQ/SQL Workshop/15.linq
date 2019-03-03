<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

SalesOrderHeaders.AsEnumerable()
	.Select(soh=>new{SalesOrderID=soh.SalesOrderID,Territory_Name=soh.TerritoryID,
								Month=soh.OrderDate.ToString("MMMM"),Year=soh.OrderDate.Year})
								.ToList()
								.Dump();
								
var Result=(from soh in SalesOrderHeaders
select new{SalesOrderID=soh.SalesOrderID,Territory_Name=soh.TerritoryID,
		Month=soh.OrderDate,Year=soh.OrderDate.Year})
		.ToList();
	Result.Select(x=>new{x.SalesOrderID,x.Territory_Name,Month=x.Month.ToString("MMMM"),x.Year})
	.Dump();