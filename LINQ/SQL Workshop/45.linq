<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

(from soh in SalesOrderHeaders
	join sod in SalesOrderDetails on soh.SalesOrderID equals sod.SalesOrderID into sodtemp
from sod in sodtemp.DefaultIfEmpty()
	select new{OrderID=soh.SalesOrderID,sod.ProductID,soh.OrderDate})
	.Dump();