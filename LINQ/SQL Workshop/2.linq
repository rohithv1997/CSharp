<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

var Result=from cc in CreditCards 
			select new{Credit_Card_ID=cc.CreditCardID,Credit_Card_Type=cc.CardType,Credit_Card_Number=cc.CardNumber,
						Expiry_Year=cc.ExpYear};					
Result.Dump();

CreditCards.Select(cc=>new{Credit_Card_ID=cc.CreditCardID,Credit_Card_Type=cc.CardType,Credit_Card_Number=cc.CardNumber,
						Expiry_Year=cc.ExpYear})
			.Dump();