<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

Departments.Where(dept=>dept.DepartmentID==1 || dept.DepartmentID==14 ||  dept.DepartmentID==6 ||  dept.DepartmentID==3 )
			.Select(x=>x.GroupName)
			.Dump();
			

Departments.Where(deptids=>new int[]{1,3,6,14}.Contains(deptids.DepartmentID))
			.Select(x=>x.GroupName).
			Dump();