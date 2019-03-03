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
join st in SalesTerritories on soh.TerritoryID equals st.TerritoryID
select new{soh.OrderDate,st.Name,soh.SalesOrderID})
	.ToList()
	.Select(x=>new{OrderDate=x.OrderDate.ToString("dd/MM/yyyy"),TerritoryName=x.Name,SalesOrderID=x.SalesOrderID})
	.Dump();