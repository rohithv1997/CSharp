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

(from od in OrderDetails
join o in Orders on od.OrderID equals o.OrderID
join p in Products on od.ProductID equals p.ProductID
where p.UnitPrice>100
orderby o.OrderDate
select o).First().Dump();