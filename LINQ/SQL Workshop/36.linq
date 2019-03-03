<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

CreditCards.Select(x=>x.CardType).Distinct().Dump();

(from cc in CreditCards
group cc by cc.CardType into cctemp
select cctemp.Key).Dump();