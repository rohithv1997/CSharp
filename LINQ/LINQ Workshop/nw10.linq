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

var array1=new List<int>(){5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
var array2=new List<int>(){1, 2, 10, 6};
var result=(from a in array1
	from b in array2
	where a<b
	select new{a,b}).Distinct().Dump();