<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

SalesTerritories.Where(st=>st.TerritoryID==1)
				.Select(salest=>new{salest.Name,salest.CountryRegionCode,salest.SalesYTD})
				.Dump();
	
(from st in SalesTerritories
where st.TerritoryID==1
select new{st.Name,st.CountryRegionCode,st.SalesYTD})
	.Dump();