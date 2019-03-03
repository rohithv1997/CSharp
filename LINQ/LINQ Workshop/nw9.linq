<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

var array=new List<int>(){5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
var result=(from l in array
			where l<5
			select l).Dump();
