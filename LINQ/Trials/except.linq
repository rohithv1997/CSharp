<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

Contacts.Select(x=>x.ContactID).Except(Employees.Select(e=>e.ContactID))

(from c in Contacts
select c.ContactID).Except(from e in Employees
							select e.ContactID)
					.Dump();