<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

(from soh in SalesOrderHeaders
	join cc in CreditCards on soh.CreditCardID equals cc.CreditCardID into cctemp
from cc in cctemp.DefaultIfEmpty()
	select new{RoundedOffTotalDue=(int)(soh.TotalDue+1),soh.SalesOrderID,cc.CardType})
.Dump();