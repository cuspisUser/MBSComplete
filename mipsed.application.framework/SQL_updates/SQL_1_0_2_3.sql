
/****** Object:  StoredProcedure [dbo].[spStanjeSkladista]    Script Date: 29.11.2016. 15:44:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Davor Bursać
-- Create date: 2016-11-04
-- Description:	Procedura za report crpStanjeSkladistaGrupe (main report spStanjeSkladista)
-- =============================================

create PROCEDURE [dbo].[spStanjeSkladista]
(    
	  @idSkladista int ,
	  @datum nvarchar(10),
	  @order nvarchar (50)
)
as
begin	

declare @sqlString nvarchar (max)

select @sqlString = 'SELECT distinct  TOP (100) PERCENT 
	dbo.MT_Skladista.ID AS ID_Skladiste, 
	dbo.MT_Skladista.Naziv AS Skladiste, 
	dbo.PROIZVOD.idGrupa AS GrupaProizvod, 
	dbo.PROIZVOD.IDPROIZVOD, 
	dbo.PROIZVOD.NAZIVPROIZVOD AS Proizvod, 
	CAST(0 AS Decimal(18, 4)) AS BasePrice, 
	(SELECT top 1 Kolicina FROM MT_SkladisteStavke where ID_Proizvod = PROIZVOD.IDPROIZVOD and MT_SkladisteStavke.TS <= '''+ @datum + ''' order by ID desc) as Kolicina,
	(SELECT top 1 Stanje FROM MT_SkladisteStavke where ID_Proizvod = PROIZVOD.IDPROIZVOD and MT_SkladisteStavke.TS <= '''+ @datum + ''' order by ID desc) as Stanje,
	(SELECT top 1 Saldo FROM MT_SkladisteStavke where ID_Proizvod = PROIZVOD.IDPROIZVOD and MT_SkladisteStavke.TS <= '''+ @datum + ''' order by ID desc) as Saldo,	
	CAST(NULL AS datetime) AS Datum, 
	dbo.PROIZVOD.idGrupa
	
FROM dbo.MT_SkladisteStavke 
	LEFT OUTER JOIN dbo.MT_PrimkaStavke ON dbo.MT_SkladisteStavke.ID_PrimkaStavke = dbo.MT_PrimkaStavke.ID 
	LEFT OUTER JOIN dbo.MT_IzdatnicaStavka ON dbo.MT_SkladisteStavke.ID_IzdatnicaStavke = dbo.MT_IzdatnicaStavka.ID 
	INNER JOIN dbo.MT_Skladista ON dbo.MT_SkladisteStavke.ID_Skladista = dbo.MT_Skladista.ID 
	INNER JOIN dbo.JEDINICAMJERE ON dbo.MT_PrimkaStavke.ID_JedinicaMjere = dbo.JEDINICAMJERE.IDJEDINICAMJERE 
	INNER JOIN dbo.PROIZVOD ON dbo.MT_SkladisteStavke.ID_Proizvod = dbo.PROIZVOD.IDPROIZVOD
	
WHERE MT_SkladisteStavke.ID_Skladista = '''+ cast(@idSkladista as nvarchar(5)) + '''
	and PROIZVOD.idGrupa is NOT NULL 
	and MT_SkladisteStavke.Kolicina > 0 
	and MT_SkladisteStavke.TS <= '''+ @datum + 	'''
group by  MT_SkladisteStavke.ID, MT_Skladista.id, MT_Skladista.Naziv, PROIZVOD.idGrupa, PROIZVOD.IDPROIZVOD, PROIZVOD.NAZIVPROIZVOD, MT_SkladisteStavke.Kolicina, JEDINICAMJERE.NAZIVJEDINICAMJERE, MT_SkladisteStavke.Saldo, JEDINICAMJERE.IDJEDINICAMJERE, MT_Skladista.TS, MT_SkladisteStavke.Kolicina
order by ' + @order 

	exec(@sqlString)
end
GO


/****** Object:  StoredProcedure [dbo].[spStanjeSkladistaGrupe]    Script Date: 29.11.2016. 15:44:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Davor Bursać
-- Create date: 2016-10-26
-- Description:	Procedura za subreport crpStanjeSkladistaGrupe (main report spStanjeSkladista)
-- =============================================

CREATE PROCEDURE [dbo].[spStanjeSkladistaGrupe]
(     
	  @idSkladista int ,
	  @datum nvarchar(10)
)
as
begin	
	 Select 
	 MT_GrupeProizvoda.Naziv, 

	 --Kolicina
	  cast(sum(MT_SkladisteStavke.Kolicina) as decimal(18,1))  as Kolicina, 
	
	--Iznos
 	cast(SUM(MT_SkladisteStavke.Saldo)as decimal(18,2)) As Iznos  --UKOLIKO IMA VISE SALDA, TREBA DOHVATITI ONAJ ZADNJI
	--SUM(MT_SkladisteStavke.Saldo / MT_SkladisteStavke.Kolicina) As Iznos
	
	From MT_SkladisteStavke 
		Inner Join PROIZVOD as product On MT_SkladisteStavke.ID_Proizvod = product.IDPROIZVOD
		Inner Join MT_Skladista On MT_SkladisteStavke.ID_Skladista = MT_Skladista.ID
		Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	
	WHERE MT_SkladisteStavke.ID_Skladista = @idSkladista 
		and product.idGrupa is NOT NULL 
		and MT_SkladisteStavke.Kolicina > 0 
		and MT_SkladisteStavke.TS = @datum
	
	group by  MT_GrupeProizvoda.Naziv
end
GO

GO
Begin
Alter table Konto Add Aktivan bit NOT NULL Default 1, Godina int NOT NULL Default 2016
End
GO

BEGIN TRANSACTION;
UPDATE Konto Set NAZIVKONTO = 'Subvencije' Where IDKONTO = '35';
IF @@ROWCOUNT = 0
BEGIN
  Insert Into Konto Values ('35', 'Subvencije', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Subvencije trgovačkim društvima u javnom sektoru' Where IDKONTO = '351';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('351', 'Subvencije trgovačkim društvima u javnom sektoru', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Subvencije trgovačkim društvima , zadrugama, poljoprivrednicima i obrtnicima izvan javnog sektora' Where IDKONTO = '352';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('352', 'Subvencije trgovačkim društvima , zadrugama, poljoprivrednicima i obrtnicima izvan javnog sektora', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Subvencije trgovačkim društvima, zadrugama, poljoprivrednicima i obrtnicima iz EU sredstava' Where IDKONTO = '353';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('353', 'Subvencije trgovačkim društvima, zadrugama, poljoprivrednicima i obrtnicima iz EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Potraživanja za pomoći temeljem prijenosa EU sredstava' Where IDKONTO = '1638';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('1638', 'Potraživanja za pomoći temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Prijenosi između proračunskih korisnika istog proračuna' Where IDKONTO = '369';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('369', 'Prijenosi između proračunskih korisnika istog proračuna', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekuće donacije iz EU sredstava' Where IDKONTO = '3813';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('3813', 'Tekuće donacije iz EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalne donacije iz EU sredstava posebno se prate donacije ostvarene iz EU izvora' Where IDKONTO = '3823';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('3823', 'Kapitalne donacije iz EU sredstava posebno se prate donacije ostvarene iz EU izvora', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalne pomoći iz EU sredstava' Where IDKONTO = '3864';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('3864', 'Kapitalne pomoći iz EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Prijenosi između proračunskih korisnika istog proračuna' Where IDKONTO = '639';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('639', 'Prijenosi između proračunskih korisnika istog proračuna', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalni prijenosi između proračunskih korisnika istog proračuna' Where IDKONTO = '6392';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('6392', 'Kapitalni prijenosi između proračunskih korisnika istog proračuna', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalni prijenosi između proračunskih korisnika istog proračuna temeljem prijenosa EU sredstava' Where IDKONTO = '6394';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('6394', 'Kapitalni prijenosi između proračunskih korisnika istog proračuna temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Potraživanja proračuna od proračunskih korisnika za povrat u nadležni proračun i osnovni račun' Where IDKONTO = '1294';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('1294', 'Potraživanja proračuna od proračunskih korisnika za povrat u nadležni proračun i osnovni račun', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Potraživanja proračuna od proračunskih korisnika za povrat u nadležni proračun' Where IDKONTO = '12941';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('12941', 'Potraživanja proračuna od proračunskih korisnika za povrat u nadležni proračun', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Potraživanja za tekuće pomoći iz proračuna JLP(R)S temeljem prijenosa EU sredstava' Where IDKONTO = '16383';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('16383', 'Potraživanja za tekuće pomoći iz proračuna JLP(R)S temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Potraživanja za kapitalne pomoći iz proračuna JLP(R)S temeljem prijenosa EU sredstava' Where IDKONTO = '16384';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('16384', 'Potraživanja za kapitalne pomoći iz proračuna JLP(R)S temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Potraživanja za tekuće pomoći od proračunskog korisnika drugog proračuna temeljem prijenosa EU sredstava' Where IDKONTO = '16385';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('16385', 'Potraživanja za tekuće pomoći od proračunskog korisnika drugog proračuna temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Potraživanja za kapitalne pomoći od proračunskog korisnika drugog proračuna temeljem prijenosa EU sredstava' Where IDKONTO = '16386';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('16386', 'Potraživanja za kapitalne pomoći od proračunskog korisnika drugog proračuna temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Potraživanja za tekuće pomoći od izvanproračunskog korisnika temeljem prijenosa EU sredstava' Where IDKONTO = '16387';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('16387', 'Potraživanja za tekuće pomoći od izvanproračunskog korisnika temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Potraživanja za kapitalne pomoći od izvanproračunskog korisnika temeljem prijenosa EU sredstava' Where IDKONTO = '16388';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('16388', 'Potraživanja za kapitalne pomoći od izvanproračunskog korisnika temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	Update KONTO Set Aktivan = 0 Where IDKONTO = '1671'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '16711'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '16712'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '16714'
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Obveze za subvencije trgovačkim društvima, zadrugama, poljoprivrednicima i obrtnicima izvan javnog sektora' Where IDKONTO = '2352';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('2352', 'Obveze za subvencije trgovačkim društvima, zadrugama, poljoprivrednicima i obrtnicima izvan javnog sektora', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Obveze za subvencije trgovačkim društvima i zadrugama izvan javnog sektora' Where IDKONTO = '23522';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('23522', 'Obveze za subvencije trgovačkim društvima i zadrugama izvan javnog sektora', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Obveze za subvencije trgovačkim društvima, zadrugama, poljoprivrednicima i obrtnicima iz EU sredstava' Where IDKONTO = '2353';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('2353', 'Obveze za subvencije trgovačkim društvima, zadrugama, poljoprivrednicima i obrtnicima iz EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Obveze za subvencije trgovačkim društvima, zadrugama, poljoprivrednicima i obrtnicima iz EU sredstava' Where IDKONTO = '23531';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('23531', 'Obveze za subvencije trgovačkim društvima, zadrugama, poljoprivrednicima i obrtnicima iz EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	Update KONTO Set Aktivan = 0 Where IDKONTO = '236'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '2365'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '23651'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '23652'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '23653'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '23654'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '23655'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '23656'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '23657'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '23658'
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Obveze za naknade građanima i kućanstvima na temelju osiguranja iz EU sredstava' Where IDKONTO = '23715';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('23715', 'Obveze za naknade građanima i kućanstvima na temelju osiguranja iz EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Obveze za ostale naknade građanima i kućanstvima iz EU sredstava' Where IDKONTO = '23723';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('23723', 'Obveze za ostale naknade građanima i kućanstvima iz EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Obveze za kapitalne pomoći kreditnim i ostalim financijskim institucijama te trgovačkim društvima i zadrugama izvan javnog sektora' Where IDKONTO = '23862';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('23862', 'Obveze za kapitalne pomoći kreditnim i ostalim financijskim institucijama te trgovačkim društvima i zadrugama izvan javnog sektora', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Obveze za kapitalne pomoći subjektima izvan općeg proračuna iz EU sredstava' Where IDKONTO = '23864';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('23864', 'Obveze za kapitalne pomoći subjektima izvan općeg proračuna iz EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Subvencije trgovačkim društvima i zadrugama, poljoprivrednicima i obrtnicima izvan javnog sektora' Where IDKONTO = '352';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('352', 'Subvencije trgovačkim društvima i zadrugama, poljoprivrednicima i obrtnicima izvan javnog sektora', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Subvencije trgovačkim društvima i zadrugama izvan javnog sektora' Where IDKONTO = '3522';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('3522', 'Subvencije trgovačkim društvima i zadrugama izvan javnog sektora', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Subvencije zadrugama' Where IDKONTO = '35222';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('35222', 'Subvencije zadrugama', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Subvencije trgovačkim društvima, zadrugama, poljoprivrednicima i obrtnicima iz EU sredstava' Where IDKONTO = '353';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('353', 'Subvencije trgovačkim društvima, zadrugama, poljoprivrednicima i obrtnicima iz EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Subvencije trgovačkim društvima, zadrugama, poljoprivrednicima i obrtnicima iz EU sredstava' Where IDKONTO = '3531';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('3531', 'Subvencije trgovačkim društvima, zadrugama, poljoprivrednicima i obrtnicima iz EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Subvencije trgovačkim društvima, zadrugama, poljoprivrednicima i obrtnicima iz EU sredstava' Where IDKONTO = '35311';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('35311', 'Subvencije trgovačkim društvima, zadrugama, poljoprivrednicima i obrtnicima iz EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	Update KONTO Set Aktivan = 0 Where IDKONTO = '3671'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '36711'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '36712'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '36714'
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Prijenosi proračunskim korisnicima iz nadležnog proračuna za financiranje rashoda poslovanja' Where IDKONTO = '3672';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('3672', 'Prijenosi proračunskim korisnicima iz nadležnog proračuna za financiranje rashoda poslovanja', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Prijenosi proračunskim korisnicima iz nadležnog proračuna za financiranje rashoda poslovanja' Where IDKONTO = '36721';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('36721', 'Prijenosi proračunskim korisnicima iz nadležnog proračuna za financiranje rashoda poslovanja', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Prijenosi proračunskim korisnicima iz nadležnog proračuna za nabavu nefinancijske imovine' Where IDKONTO = '3673';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('3673', 'Prijenosi proračunskim korisnicima iz nadležnog proračuna za nabavu nefinancijske imovine', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Prijenosi proračunskim korisnicima iz nadležnog proračuna za nabavu nefinancijske imovine' Where IDKONTO = '36731';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('36731', 'Prijenosi proračunskim korisnicima iz nadležnog proračuna za nabavu nefinancijske imovine', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Prijenosi proračunskim korisnicima iz nadležnog proračuna za financijsku imovinu i otplatu zajmova i osnovni račun' Where IDKONTO = '3674';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('3674', 'Prijenosi proračunskim korisnicima iz nadležnog proračuna za financijsku imovinu i otplatu zajmova i osnovni račun', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Prijenosi proračunskim korisnicima iz nadležnog proračuna za financijsku imovinu i otplatu zajmova' Where IDKONTO = '36741';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('36741', 'Prijenosi proračunskim korisnicima iz nadležnog proračuna za financijsku imovinu i otplatu zajmova', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Prijenosi između proračunskih korisnika istog proračuna' Where IDKONTO = '369';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('369', 'Prijenosi između proračunskih korisnika istog proračuna', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekući prijenosi između proračunskih korisnika istog proračuna i osnovni računi' Where IDKONTO = '3691';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('3691', 'Tekući prijenosi između proračunskih korisnika istog proračuna i osnovni računi', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekući prijenosi između proračunskih korisnika istog proračuna' Where IDKONTO = '36911';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('36911', 'Tekući prijenosi između proračunskih korisnika istog proračuna', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalni prijenosi između proračunskih korisnika istog proračuna i osnovni račun' Where IDKONTO = '3692';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('3692', 'Kapitalni prijenosi između proračunskih korisnika istog proračuna i osnovni račun', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalni prijenosi između proračunskih korisnika istog proračuna' Where IDKONTO = '36921';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('36921', 'Kapitalni prijenosi između proračunskih korisnika istog proračuna', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekući prijenosi između proračunskih korisnika istog proračuna temeljem prijenosa EU sredstava' Where IDKONTO = '3693';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('3693', 'Tekući prijenosi između proračunskih korisnika istog proračuna temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekući prijenosi između proračunskih korisnika istog proračuna temeljem prijenosa EU sredstava' Where IDKONTO = '36931';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('36931', 'Tekući prijenosi između proračunskih korisnika istog proračuna temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalni prijenosi između proračunskih korisnika istog proračuna temeljem prijenosa EU sredstava i osnovni račun' Where IDKONTO = '3694';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('3694', 'Kapitalni prijenosi između proračunskih korisnika istog proračuna temeljem prijenosa EU sredstava i osnovni račun', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalni prijenosi između proračunskih korisnika istog proračuna temeljem prijenosa EU sredstava' Where IDKONTO = '36941';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('36941', 'Kapitalni prijenosi između proračunskih korisnika istog proračuna temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Naknade građanima i kućanstvima na temelju osiguranja iz EU sredstava' Where IDKONTO = '3715';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('3715', 'Naknade građanima i kućanstvima na temelju osiguranja iz EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Naknade građanima i kućanstvima na temelju osiguranja iz EU sredstava' Where IDKONTO = '37151';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('37151', 'Naknade građanima i kućanstvima na temelju osiguranja iz EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Naknade građanima i kućanstvima iz EU sredstava i osnovni račun' Where IDKONTO = '3723';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('3723', 'Naknade građanima i kućanstvima iz EU sredstava i osnovni račun', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Naknade građanima i kućanstvima iz EU sredstava' Where IDKONTO = '37231';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('37231', 'Naknade građanima i kućanstvima iz EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekuće donacije iz EU sredstava' Where IDKONTO = '3813';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('3813', 'Tekuće donacije iz EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekuće donacije iz EU sredstava' Where IDKONTO = '38131';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('38131', 'Tekuće donacije iz EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalne donacije iz EU sredstava' Where IDKONTO = '3823';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('3823', 'Kapitalne donacije iz EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalne donacije iz EU sredstava' Where IDKONTO = '38231';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('38231', 'Kapitalne donacije iz EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekuće pomoći iz državnog proračuna proračunskim korisnicima proračuna JLP(R)S' Where IDKONTO = '63612';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('63612', 'Tekuće pomoći iz državnog proračuna proračunskim korisnicima proračuna JLP(R)S', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekuće pomoći proračunskim korisnicima iz proračuna JLP(R)S koji im nije nadležan' Where IDKONTO = '63613';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('63613', 'Tekuće pomoći proračunskim korisnicima iz proračuna JLP(R)S koji im nije nadležan', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	Update KONTO Set Aktivan = 0 Where IDKONTO = '63611'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '63621'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '9671'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '96711'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '96712'
	Update KONTO Set Aktivan = 0 Where IDKONTO = '96714'
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalne pomoći iz državnog proračuna proračunskim korisnicima proračuna JLP(R)S' Where IDKONTO = '63622';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('63622', 'Kapitalne pomoći iz državnog proračuna proračunskim korisnicima proračuna JLP(R)S', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalne pomoći proračunskim korisnicima iz proračuna JLP(R)S koji im nije nadležan' Where IDKONTO = '63623';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('63623', 'Kapitalne pomoći proračunskim korisnicima iz proračuna JLP(R)S koji im nije nadležan', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Pomoći  temeljem prijenosa EU sredstava' Where IDKONTO = '638';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('638', 'Pomoći  temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekuće pomoći  temeljem prijenosa EU sredstava' Where IDKONTO = '6381';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('6381', 'Tekuće pomoći  temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalne pomoći  temeljem prijenosa EU sredstava' Where IDKONTO = '6382';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('6382', 'Kapitalne pomoći  temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekuće pomoći iz proračuna JLP(R)S temeljem prijenosa EU sredstava' Where IDKONTO = '63812';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('63812', 'Tekuće pomoći iz proračuna JLP(R)S temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekuće pomoći od proračunskog korisnika drugog proračuna temeljem prijenosa EU sredstava' Where IDKONTO = '63813';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('63813', 'Tekuće pomoći od proračunskog korisnika drugog proračuna temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekuće pomoći od izvanproračunskog korisnika temeljem prijenosa EU sredstava' Where IDKONTO = '63814';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('63814', 'Tekuće pomoći od izvanproračunskog korisnika temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalne pomoći iz proračuna JLP(R)S temeljem prijenosa EU sredstava' Where IDKONTO = '63822';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('63822', 'Kapitalne pomoći iz proračuna JLP(R)S temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalne pomoći od proračunskog korisnika drugog proračuna temeljem prijenosa EU sredstava' Where IDKONTO = '63823';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('63823', 'Kapitalne pomoći od proračunskog korisnika drugog proračuna temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalne pomoći od izvanproračunskog korisnika temeljem prijenosa EU sredstava' Where IDKONTO = '63824';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('63824', 'Kapitalne pomoći od izvanproračunskog korisnika temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Prijenosi između proračunskih korisnika istog proračuna' Where IDKONTO = '639';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('639', 'Prijenosi između proračunskih korisnika istog proračuna', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekući prijenosi između proračunskih korisnika istog proračuna' Where IDKONTO = '6391';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('6391', 'Tekući prijenosi između proračunskih korisnika istog proračuna', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekući prijenosi između proračunskih korisnika istog proračuna' Where IDKONTO = '63911';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('63911', 'Tekući prijenosi između proračunskih korisnika istog proračuna', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalni prijenosi između proračunskih korisnika istog proračuna' Where IDKONTO = '6392';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('6392', 'Kapitalni prijenosi između proračunskih korisnika istog proračuna', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalni prijenosi između proračunskih korisnika istog proračuna' Where IDKONTO = '63921';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('63921', 'Kapitalni prijenosi između proračunskih korisnika istog proračuna', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekući prijenosi između proračunskih korisnika istog proračuna temeljem prijenosa EU sredstava' Where IDKONTO = '6393';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('6393', 'Tekući prijenosi između proračunskih korisnika istog proračuna temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekući prijenosi između proračunskih korisnika istog proračuna temeljem prijenosa EU sredstava' Where IDKONTO = '63931';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('63931', 'Tekući prijenosi između proračunskih korisnika istog proračuna temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalni prijenosi između proračunskih korisnika istog proračuna temeljem prijenosa EU sredstava' Where IDKONTO = '6394';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('6394', 'Kapitalni prijenosi između proračunskih korisnika istog proračuna temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalni prijenosi između proračunskih korisnika istog proračuna temeljem prijenosa EU sredstava' Where IDKONTO = '63941';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('63941', 'Kapitalni prijenosi između proračunskih korisnika istog proračuna temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Pomoći temeljem prijenosa EU sredstava' Where IDKONTO = '9638';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('9638', 'Pomoći temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekuće pomoći iz proračuna JLP(R)S temeljem prijenosa EU sredstava' Where IDKONTO = '96383';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('96383', 'Tekuće pomoći iz proračuna JLP(R)S temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalne pomoći iz proračuna JLP(R)S temeljem prijenosa EU sredstava' Where IDKONTO = '96384';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('96384', 'Kapitalne pomoći iz proračuna JLP(R)S temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekuće pomoći od proračunskog korisnika drugog proračuna temeljem prijenosa EU sredstava' Where IDKONTO = '96385';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('96385', 'Tekuće pomoći od proračunskog korisnika drugog proračuna temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalne pomoći od proračunskog korisnika drugog proračuna temeljem prijenosa EU sredstava' Where IDKONTO = '96386';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('96386', 'Kapitalne pomoći od proračunskog korisnika drugog proračuna temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Tekuće pomoći od izvanproračunskog korisnika temeljem prijenosa EU sredstava' Where IDKONTO = '96387';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('96387', 'Tekuće pomoći od izvanproračunskog korisnika temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;

BEGIN TRANSACTION;
	UPDATE Konto Set NAZIVKONTO = 'Kapitalne pomoći od izvanproračunskog korisnika temeljem prijenosa EU sredstava' Where IDKONTO = '96387';
IF @@ROWCOUNT = 0
BEGIN
	Insert Into Konto Values ('96387', 'Kapitalne pomoći od izvanproračunskog korisnika temeljem prijenosa EU sredstava', 1, 1, 2016);
END
COMMIT TRANSACTION;
GO


--db 7.12.2016
/****** Object:  Table [dbo].[MT_Inventura]    Script Date: 7.12.2016. 8:59:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MT_Inventura](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DatumInventure] [date] NOT NULL,
	[IDSKladiste] [int] NOT NULL,
	[IDGodina] [smallint] NOT NULL,
	[TS] [datetime] NOT NULL,
 CONSTRAINT [PK_MT_Inventura] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[MT_Inventura]  WITH CHECK ADD  CONSTRAINT [FK_MT_Inventura_GODINE] FOREIGN KEY([IDGodina])
REFERENCES [dbo].[GODINE] ([IDGODINE])
GO

ALTER TABLE [dbo].[MT_Inventura] CHECK CONSTRAINT [FK_MT_Inventura_GODINE]
GO

ALTER TABLE [dbo].[MT_Inventura]  WITH CHECK ADD  CONSTRAINT [FK_MT_Inventura_MT_Skladista] FOREIGN KEY([IDSKladiste])
REFERENCES [dbo].[MT_Skladista] ([ID])
GO

ALTER TABLE [dbo].[MT_Inventura] CHECK CONSTRAINT [FK_MT_Inventura_MT_Skladista]
GO


--db 7.12.2016
/****** Object:  Table [dbo].[MT_InventuraStavka]    Script Date: 7.12.2016. 9:00:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MT_InventuraStavka](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Inventura] [int] NOT NULL,
	[ID_Proizvod] [int] NOT NULL,
	[KolicinaZaliha] [decimal](16, 4) NULL,
	[StvarnaKolicina] [decimal](16, 4) NULL,
 CONSTRAINT [PK_MT_IntenturaStavka] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MT_InventuraStavka]  WITH CHECK ADD  CONSTRAINT [FK_MT_InventuraStavka_MT_Inventura] FOREIGN KEY([ID_Inventura])
REFERENCES [dbo].[MT_Inventura] ([ID]) 
GO
ALTER TABLE [dbo].[MT_InventuraStavka] CHECK CONSTRAINT [FK_MT_InventuraStavka_MT_Inventura]
GO

ALTER TABLE [dbo].[MT_InventuraStavka]  WITH CHECK ADD  CONSTRAINT [FK_MT_InventuraStavka_PROIZVOD] FOREIGN KEY([ID_Proizvod])
REFERENCES [dbo].[PROIZVOD] ([IDPROIZVOD]) 
GO
ALTER TABLE [dbo].[MT_InventuraStavka] CHECK CONSTRAINT [FK_MT_InventuraStavka_PROIZVOD]
GO


--21.12.2016 --> dodavanje i punjenje kolone IDGodine u MT_Primke i MT_Izdatnice, dodavanje relacije (FK) na tablicu Godine
alter table mt_izdatnica 
	add IDGodina smallint NULL
go

update MT_Izdatnica 
	set IDGodina = 2016
go

alter table mt_primka 
	add IDGodina smallint NULL
go

update MT_Primka
	set IDGodina = 2016
go

alter table mt_izdatnica
ADD CONSTRAINT FK_MT_Izdatnica_Godina FOREIGN KEY(IDGodina) REFERENCES Godine(IDGodine)

alter table mt_primka
ADD CONSTRAINT FK_MT_Primka_Godina FOREIGN KEY(IDGodina) REFERENCES Godine(IDGodine)

