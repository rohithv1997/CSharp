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
join m in Employees on e.ReportsTo equals m.EmployeeID
where (DateTime.Now.Year-((DateTime)m.BirthDate).Year)>30
select new{m.FirstName,m.LastName,Age=(DateTime.Now.Year-(Convert.ToDateTime(m.BirthDate).Year))})
.Distinct()
.Dump();