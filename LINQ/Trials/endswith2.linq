<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

var Result=(from contact in Contacts
			where contact.FirstName.EndsWith("y")
			select new{contact.FirstName,contact.LastName}
			).Dump();