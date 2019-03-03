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

Products.Where(p=>p.UnitPrice>3.00m && 	p.UnitsInStock>0 && !p.Discontinued)
	.Select(x=>new{Id=x.ProductID,Name=x.ProductName,x.UnitPrice,TotalStock=x.UnitsInStock,IsAlive=!x.Discontinued})
	.Dump();