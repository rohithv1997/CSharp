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

var array=new List<int>(){5, 4, 1, 3, 9, 8, 6,6,6,7, 7, 2, 0};
array.Sort();
var x=(from l in array
	where l>5
	select l).FirstOrDefault();
	
var y=(from l in array
where l>x
select l).FirstOrDefault();

(from l in array where l==y select l).Dump();