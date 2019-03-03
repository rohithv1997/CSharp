<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

var result1=(from e in Employees
	where e.Gender=='F'
	select new{e.ContactID,e.EmployeeID,e.ManagerID});
	
var result2=(from r in result1
		join m in Employees on r.ManagerID equals m.EmployeeID into managertemp
	from m in managertemp.DefaultIfEmpty()
		select new{ec=r.ContactID,eid=r.EmployeeID,mid=m.EmployeeID,mc=m.ContactID});
	
var result3=(from r in result2
		join c1 in Contacts on r.ec equals c1.ContactID into c1temp
	from c1 in c1temp.DefaultIfEmpty()
		select new{Employee_Name=c1.FirstName+" "+c1.LastName,r.eid,r.mid,r.mc});
	
var result4=(from r in result3
		join c2 in Contacts on r.mc equals c2.ContactID into c2temp
	from c2 in c2temp.DefaultIfEmpty()
		select new{EmployeeID=r.eid,r.Employee_Name,ManagerID=r.mid,Manager_Name=c2.FirstName+" "+c2.LastName});

result4.Dump();
