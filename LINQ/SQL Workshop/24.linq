<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

Currencies.Where(x=>x.Name.Contains("Dollar")).Select(x=>x).Dump();

(from c in Currencies
where c.Name.Contains("Dollar")
select c).Dump();