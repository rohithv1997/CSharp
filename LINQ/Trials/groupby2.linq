<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

var Result=(from employee in Employees
			group employee by employee.ManagerID into EmployeeTemp
			where EmployeeTemp.Count()>10
			select new{ManagerID=EmployeeTemp.Key,EmployeeCount=EmployeeTemp.Select(x=>x).Count()});
Result.Dump();