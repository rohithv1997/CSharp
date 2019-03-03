<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

SalesPersons.Where(x=>x.Bonus==SalesPersons.Max(y=>y.Bonus)).Select(x=>x).Dump();

SalesPersons.Select(x=>x.Bonus).Max().Dump();

SalesPersons.OrderByDescending(x=>x.Bonus).Select(x=>x).First().Dump();