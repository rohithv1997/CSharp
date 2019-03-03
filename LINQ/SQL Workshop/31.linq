<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

Stores.Where(s=>s.Name.Contains("Bike")).Dump();

(from s in Stores
where s.Name.Contains("Bike")
select s)
	.Dump();