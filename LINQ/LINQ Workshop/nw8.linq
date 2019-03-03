<Query Kind="Statements">
  <Connection>
    <ID>44519755-4bb6-4147-830f-1876785da784</ID>
    <Persist>true</Persist>
    <Server>otbsqlserver</Server>
    <Database>NorthWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
</Query>

var list=Employees.Join(Employees,e=>e.ReportsTo,m=>m.EmployeeID,(e,m)=>m.EmployeeID).Distinct().ToList();
var result=Employees.Where(e=>!(list.Contains(e.EmployeeID)) &&  e.Salary<25000).Select(x=>x).Count().Dump();
