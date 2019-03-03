<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

Employees.Where(x=>x.Title.StartsWith("Production Technician"))
	.Select(emp=>new{AverageVacationHours=Employees.Average(emp2=>emp2.VacationHours),SumOfSickLeaveHours=Employees.Sum(x=>x.SickLeaveHours)})
	.Distinct()
	.Dump();
	
(from employee in Employees
	where employee.Title.Contains("Production Technician")
	select new{AverageVacationHours=Employees.Average(emp2=>emp2.VacationHours),SumOfSickLeaveHours=Employees.Sum(x=>x.SickLeaveHours)})
	.Distinct()
	.Dump();