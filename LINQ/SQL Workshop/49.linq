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
where soh.OrderDate.Month==5 && soh.OrderDate.Year==2004
join st in SalesTerritories on soh.TerritoryID equals st.TerritoryID
select new{soh.SalesOrderID,st.Name})
	.Dump();
	
SalesOrderHeaders.Where(x=>(x.OrderDate.Month==5 && x.OrderDate.Year==2004))
	.Join(SalesTerritories,
		soh1=>soh1.TerritoryID,
		st2=>st2.TerritoryID,
		(soh,st)=>new{ SalesOrderID=soh.SalesOrderID,TerritoryName=st.Name})
	.Dump();