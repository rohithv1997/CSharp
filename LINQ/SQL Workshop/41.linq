<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

Contacts.Where(x=>x.LastName.EndsWith("an") && x.LastName.Length==3)
	.Select(c=>new{c.FirstName,c.LastName})
	.Dump();

(from con in Contacts
where con.LastName.EndsWith("an") && con.LastName.Length==3
select new{con.FirstName,con.LastName})
	.Dump();