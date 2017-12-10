



create view ViewContact
as with Contact
as
(
	select ClientId, COUNT(*)as ContactNum from dbo.ClientContact group by ClientId
),
Information
as
(
		select ClientId, COUNT(*)as InfoNum from dbo.ClientInformation group by ClientId

	),
	join_2 (Id, ClientName, ContactNum, InfoNum)
	as
	(
	select m.Id, m.ClientName,  c.ContactNum, I.InfoNum
	from dbo.ClientData m with(nolock)
	join Information I with(nolock) on m.Id = I.ClientId
	join Contact c with(nolock)	on m.Id =  c.ClientId
	)

	select Id as ClientId, ClientName, ContactNum, InfoNum  from join_2