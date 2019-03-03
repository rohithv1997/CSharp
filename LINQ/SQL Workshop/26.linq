<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

SalesPersons.Where(sp=>sp.SalesQuota!=null)
	.Select( x=>new{x.SalesPersonID,x.TerritoryID,x.SalesQuota})
	.Dump();
	
(from sp in SalesPersons
where sp.SalesQuota!=null
select new{sp.SalesPersonID,sp.TerritoryID,sp.SalesQuota})
	.Dump();