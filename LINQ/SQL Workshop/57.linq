<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

var result1=(from eph1 in EmployeePayHistories
	join eph2 in EmployeePayHistories on eph1.EmployeeID equals eph2.EmployeeID into jtemp
	from jt in jtemp where eph1.RateChangeDate<jt.RateChangeDate
	group jt by new{eph1.EmployeeID,eph1.RateChangeDate} into jointemp
	select new{jointemp.Key.EmployeeID,jointemp.Key.RateChangeDate,varieddate=jointemp.Min(x=>x.RateChangeDate)})
	.OrderBy(x=>x.EmployeeID);
	
var result2=(from r1 in result1
	join eph3 in EmployeePayHistories on new{a=r1.EmployeeID,r1.RateChangeDate} equals new{a=eph3.EmployeeID,eph3.RateChangeDate}
	select new{r1.EmployeeID,r1.RateChangeDate,CTC=((double)eph3.Rate*(double)eph3.PayFrequency*8d*(r1.varieddate-r1.RateChangeDate).TotalDays)})
	.OrderBy(x=>x.EmployeeID);
	
var T1= EmployeePayHistories.GroupBy(x=>x.EmployeeID)
		.Select(e=>new{EmployeeID=e.Key,RateChangeDate=e.Max(x=>x.RateChangeDate)})
		.OrderBy(x=>x.EmployeeID);

var result3=(from T in T1
	join eph4 in EmployeePayHistories on new{a=T.EmployeeID,T.RateChangeDate} equals new{a=eph4.EmployeeID,eph4.RateChangeDate}
	select new{T.EmployeeID,T.RateChangeDate,CTC=((double)eph4.Rate*(double)eph4.PayFrequency*8d*(DateTime.Now.Date-T.RateChangeDate).TotalDays)})
	.OrderBy(x=>x.EmployeeID);
	
var result4=(from r2 in result2 select r2).Concat(from r3 in result3 select r3)
	.Select(x=>x)
	.OrderBy(x=>x.EmployeeID);
	
var result5=result4.GroupBy(x=>x.EmployeeID)
	.Select(tmp=>new{EmployeeID=tmp.Key,TotalCTC=tmp.Sum(x=>x.CTC)});
	
var result6=(from r in result5
	join e in Employees on r.EmployeeID equals e.EmployeeID
	join c in Contacts on e.ContactID equals c.ContactID
	select new{e.EmployeeID,Name=c.FirstName+" "+c.LastName,r.TotalCTC})
	.OrderBy(x=>x.EmployeeID)
	.Dump();
	