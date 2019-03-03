<Query Kind="Statements">
  <Connection>
    <ID>44519755-4bb6-4147-830f-1876785da784</ID>
    <Persist>true</Persist>
    <Server>otbsqlserver</Server>
    <Database>NorthWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
</Query>

Products.Where(p=>p.UnitsInStock>2)
	.Select(x=>new{Id=x.ProductID,ProductStockName=x.ProductName,x.UnitPrice,TotalStock=x.UnitsInStock,IsAlive=!x.Discontinued})
	.Dump();