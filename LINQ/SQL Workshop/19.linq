<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

SalesOrderHeaders.Where(soh=>soh.TotalDue<2000)
	.Select(x=>new{x.SalesOrderID,x.TaxAmt})
	.Dump();
	
(from soh in SalesOrderHeaders
where soh.TotalDue<2000
select new{soh.SalesOrderID,soh.TaxAmt})
	.Dump();