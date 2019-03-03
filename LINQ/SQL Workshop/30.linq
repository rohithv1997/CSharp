<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

SalesPersons.OrderByDescending(s=>s.Bonus)
   .Take(3)
   .Dump();

(from s in SalesPersons
	orderby s.Bonus descending
	select s).Take(3).Dump();