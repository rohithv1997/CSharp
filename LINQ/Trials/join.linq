<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

var Result=(from emp in Employees 
			join contact in Contacts
			on emp.ContactID equals contact.ContactID
			join eph in EmployeePayHistories
			on emp.EmployeeID equals eph.EmployeeID
			select new{contact.FirstName,contact.LastName,emp.Title,eph.Rate})
			.Dump();