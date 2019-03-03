<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

var result1=EmployeePayHistories.GroupBy(x=>x.EmployeeID)
								.Select(x=>new{x.Key,date=x.Max(y=>y.RateChangeDate)});
var result2=(from r in result1
	join eph in EmployeePayHistories on r.Key equals eph.EmployeeID
	where eph.RateChangeDate==r.date
	select new{eph.EmployeeID,CTC=eph.Rate*eph.PayFrequency*9*365});

var result3=result2.OrderByDescending(x=>x.CTC)
	.Select(x=>x)
	.Take(2).Skip(1);
	
(from r in result3
	join e in Employees on r.EmployeeID equals e.EmployeeID
	join c in Contacts on e.ContactID equals c.ContactID
	select new{e.EmployeeID,Name=c.FirstName+" "+c.LastName,r.CTC}).Dump();
