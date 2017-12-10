declare @Clientid	int
  declare @id int 
  set @id = 10

  while @id < =100
  begin
	insert into dbo.ClientContact
	(ClientId, Occupation, ClientName,ClientEmail,ClientMobile,ClientPhone)
	select @Clientid, concat('Occupation@',convert(varchar(2),@id)),
	concat('ClientName@',convert(varchar(2),@id)),
	concat('ClientEmail',convert(varchar(2),@id),'@email.com'),
	concat('098843280',convert(varchar(2),@id)),
	concat('0325782',convert(varchar(2),@id))

	insert into dbo.ClientInformation
	(ClientId, BankName,BankCode,BranchBankCode, AccountName, AccountNo)
	select @Clientid,
	concat('BankName@',convert(varchar(2),@id)),
	(100+@id),
	(1100+@id),
	concat('AccountName@',convert(varchar(2),@id)),
	concat('ANo123456@',convert(varchar(2),@id))
	Set @id = @id +1

  end