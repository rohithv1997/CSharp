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

(from e in Employees 
orderby e.ReportsToChildren.Count() descending
select new{e.EmployeeID,ChildrenCount=e.ReportsToChildren.Count()}).ToList().First().Dump();