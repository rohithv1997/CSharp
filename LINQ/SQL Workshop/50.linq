<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

(from l in Locations
where l.CostRate>12
orderby l.CostRate descending
select l).Dump();

Locations.Where(x=>x.CostRate>12)
		.OrderByDescending(x=>x.CostRate)
		.Select(x=>x)
		.Dump();