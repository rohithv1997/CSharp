<Query Kind="Statements">
  <Connection>
    <ID>6bc231d2-6bc6-4a0d-a178-139819cb8301</ID>
    <Persist>true</Persist>
    <Server>.\SQL2016</Server>
    <Database>AdventureWorks</Database>
  </Connection>
</Query>

SalesTerritories.Where(st=>new string[]{"Canada","France","Germany"}.Contains(st.Name))
				.Dump();
				
(from st in SalesTerritories
where new string[]{"Canada","France","Germany"}.Contains(st.Name)
select st).Dump();