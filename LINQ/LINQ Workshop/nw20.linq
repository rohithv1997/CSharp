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

(from c in Customers
join o in Orders on c.CustomerID equals o.CustomerID
join od in OrderDetails on o.OrderID equals od.OrderID
group od by c.CustomerID into ctemp
where ctemp.Sum(o=>((double)(o.UnitPrice*o.Quantity)-(o.Discount*o.Quantity)))>50000
select new{ctemp.Key,Sum=ctemp.Sum(o=>((double)(o.UnitPrice*o.Quantity)-(o.Discount*o.Quantity)))}).Dump();