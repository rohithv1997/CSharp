<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

SalesPersons.Where(sp=>new int?[]{2,4}.Contains(sp.TerritoryID))
	.Select(x=>new{x.SalesPersonID,x.TerritoryID})
	.Dump();
	
(from sp in SalesPersons
where new int?[]{2,4}.Contains(sp.TerritoryID)
select new{sp.SalesPersonID,sp.TerritoryID})
	.Dump();