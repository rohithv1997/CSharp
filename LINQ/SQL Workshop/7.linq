<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

SalesOrderDetails.Select(sod=>new{Order_Id=sod.SalesOrderID,Order_Quantity=sod.OrderQty,
								Unit_Price=sod.UnitPrice,Total_Cost=sod.OrderQty*sod.UnitPrice})
				.Dump();
				
(from sod in SalesOrderDetails
select new{Order_Id=sod.SalesOrderID,Order_Quantity=sod.OrderQty,
		Unit_Price=sod.UnitPrice,Total_Cost=sod.OrderQty*sod.UnitPrice})
	.Dump();