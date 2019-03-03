<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

CreditCards.Where(cc=>cc.CardType=="Vista" && cc.ExpYear==2006).Dump();

(from cc in CreditCards
where cc.CardType=="Vista" && cc.ExpYear==2006
select cc ).Dump();