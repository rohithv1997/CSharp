<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

(from sp in SalesPersons
	join st in SalesTerritories on sp.TerritoryID equals st.TerritoryID into territorytemp
from st in territorytemp.DefaultIfEmpty()
	select new{sp.SalesPersonID,Territory_Name=st.Name})
	.Dump();