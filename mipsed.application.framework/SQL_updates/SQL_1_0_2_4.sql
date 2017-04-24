
   --Update poreza Branimir
 
 insert into .[dbo].[POREZ] 
 values ('12','Porez 24%','17500','24','68','1880-','34','311116-5800008-16883','Porez i prirez','na dohodak','33','Uplata poreza i prireza')

 insert into .[dbo].[POREZ] 
 values ('13','Porez 36%','999999','36','68','1880-','34','311116-5800008-16883','Porez i prirez','na dohodak','33','Uplata poreza i prireza')

  insert into .[dbo].[POREZ] 
 values ('14','Porez 24% na Drugi dohodak 2017','999999','24','68','1945-','34','32809923710','Porez i prirez','na drugi dohodak','08','Uplata poreza i prireza')
   --dodavanje skupina poreza Branimir
 

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA] 
 values ('130','Mirovinsko I  stup (od 01.01.2017.)')
 
 insert into .[dbo].[SKUPPOREZAIDOPRINOSA] 
 values ('131','Mirovinsko I i II stup (od 01.01.2017.)')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA] 
 values ('132','Mirovinsko I  stup - novozap. (od 01.01.2017.)')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA] 
 values ('133','Mirovinsko I i II stup - novozap. (od 01.01.2017.)')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA] 
 values ('134','Mladi do 30 godina (od 01.01.2017.)')

 --dodavanje poreza u skupinu Branimir

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA1] 
 values ('130','12')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA1] 
 values ('130','13')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA1] 
 values ('131','12')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA1] 
 values ('131','13')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA1] 
 values ('132','12')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA1] 
 values ('132','13')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA1] 
 values ('133','12')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA1] 
 values ('133','13')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA1] 
 values ('134','12')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA1] 
 values ('134','13')

 --dodavanje doprinosa
 
 insert into .[dbo].[SKUPPOREZAIDOPRINOSA2] 
 values ('130','3')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA2] 
 values ('130','4')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA2] 
 values ('130','5')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA2] 
 values ('130','7')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA2] 
 values ('131','1')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA2] 
 values ('131','2')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA2] 
 values ('131','4')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA2] 
 values ('131','5')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA2] 
 values ('131','7')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA2] 
 values ('132','3')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA2] 
 values ('133','1')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA2] 
 values ('133','2')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA2] 
 values ('134','1')

 insert into .[dbo].[SKUPPOREZAIDOPRINOSA2] 
 values ('134','2')

 --Update tablice radnik da poveže nove skupine

  update.[dbo].[RADNIK] set [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] = 130 where [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] = 107
  update.[dbo].[RADNIK] set [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] = 131 where [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] = 108
  update.[dbo].[RADNIK] set [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] = 132 where [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] = 109
  update.[dbo].[RADNIK] set [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] = 133 where [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] = 110
  update.[dbo].[RADNIK] set [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] = 134 where [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] = 111

  --Update osobnih odbitaka Branimir
 insert into .[dbo].[OSOBNIODBITAK] 
 values ('999','Osnovni osobni odbitak od 2017','1.52')

 insert into .[dbo].[OSOBNIODBITAK] 
 values ('998','Uzdržavani član od 2017','0.7')

 insert into .[dbo].[OSOBNIODBITAK] 
 values ('997','Prvo dijete od 2017','0.7')

 insert into .[dbo].[OSOBNIODBITAK] 
 values ('996','Drugo dijete od 2017','1.0')

 insert into .[dbo].[OSOBNIODBITAK] 
 values ('995','Treće dijete od 2017','1.40')

 insert into .[dbo].[OSOBNIODBITAK] 
 values ('994','Četvrto dijete od 2017','1.90')

 insert into .[dbo].[OSOBNIODBITAK] 
 values ('993','Peto dijete od 2017','2.50')

 insert into .[dbo].[OSOBNIODBITAK] 
 values ('992','Dodatak za djelomičnu invalidnost od 2017','0.40')

 insert into .[dbo].[OSOBNIODBITAK] 
 values ('991','Dodatak za 100% invalidnost od 2017','1.50')

 update.[dbo].[RADNIKOdbitak] set [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] = 999 where [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK]=1

 update.[dbo].[RADNIKOdbitak] set [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] = 998 where [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK]=2

 update.[dbo].[RADNIKOdbitak] set [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] = 997 where [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK]=3

 update.[dbo].[RADNIKOdbitak] set [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] = 996 where [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK]=4

 update.[dbo].[RADNIKOdbitak] set [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] = 995 where [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK]=5

 update.[dbo].[RADNIKOdbitak] set [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] = 994 where [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK]=6

 update.[dbo].[RADNIKOdbitak] set [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] = 993 where [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK]=7

 update.[dbo].[RADNIKOdbitak] set [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] = 992 where [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK]=8

 update.[dbo].[RADNIKOdbitak] set [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] = 991 where [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK]=9

--Dodavanje novih skupina u DD

  insert into .[dbo].[DDKATEGORIJA] values ('990','UGOVOR O DJELU 2017','3')

  insert into .[dbo].[DDKATEGORIJA] values ('989','UGOVOR O DJELU - UMIROVLJENICI 2017','4')

  insert into .[dbo].[DDKATEGORIJA] values ('988','AUTORSKI HONORAR znanstvenika,stručnjak,novin.2017','6')

  insert into .[dbo].[DDKATEGORIJA] values ('987','AUTORSKI HONORAR umjetnika 2017','5')

  insert into .[dbo].[DDKATEGORIJA] values ('986','ČLANOVI SKUPŠT.,NADZOR.ODBORA,POVJEREN.,KOMIS.2017','3')

  insert into .[dbo].[DDKATEGORIJA] values ('985','ČLANOVI SKUPŠT.NADZOR.ODOBORA, POVJER-UMIROV.2017','4')

  insert into .[dbo].[DDKATEGORIJA] values ('984','OSTALI PRIMICI FIZIČKIH OSOBA 2017','3')

  insert into .[dbo].[DDKATEGORIJA] values ('983','OSTALI PRIMICI FIZIČKIH OSOBA-UMIROVLJ.2017','4')

  insert into .[dbo].[DDKATEGORIJA] values ('982','ČLANOVI BIRAČKIH ODBORA 2017','3')

  insert into .[dbo].[DDKATEGORIJA] values ('981','ČLANOVI BIRAČKIH ODBORA -UMIROVLJENICI 2017','4')

--dodavanje poreza 24% u skupine dd

  insert into .[dbo].[DDKATEGORIJALevel1] values ('990','14','68','1945-')
  insert into .[dbo].[DDKATEGORIJALevel1] values ('989','14','68','1945-')
  insert into .[dbo].[DDKATEGORIJALevel1] values ('988','14','68','1945-')
  insert into .[dbo].[DDKATEGORIJALevel1] values ('987','14','68','1945-')
  insert into .[dbo].[DDKATEGORIJALevel1] values ('986','14','68','1945-')
  insert into .[dbo].[DDKATEGORIJALevel1] values ('985','14','68','1945-')
  insert into .[dbo].[DDKATEGORIJALevel1] values ('984','14','68','1945-')
  insert into .[dbo].[DDKATEGORIJALevel1] values ('983','14','68','1945-')
  insert into .[dbo].[DDKATEGORIJALevel1] values ('982','14','68','1945-')
  insert into .[dbo].[DDKATEGORIJALevel1] values ('981','14','68','1945-')

--dodavanje doprinosa za zdravstvo i MIO za drugi dohodak 

  insert into .[dbo].[DOPRINOS] values ('990','Osnovno zdravstveno osiguranje-DRUGI DOHODAK 2017','1','7.50','68','8540-','34','313218-5790001-15018','Državni proračun RH','Doprinos za zdravstv','08','Uplata doprinosa za zdravstvo','1001005','1863000160','2812,95','0')
    insert into .[dbo].[DOPRINOS] values ('989','Mirovinsko osiguranje I stup - DRUGI DOHODAK 2017','2','7.50','68','8176-','34','311116-5790001-15018','Državni proračun RH','Doprinos za MIO I','08','Uplata doprinosa za MIO I stup','1001005','1863000160','0','48222')
	insert into .[dbo].[DOPRINOS] values ('988','Mirovinsko osiguranje II stup - DRUGI DOHODAK 2017','2','2.50','68','2291-','34','311116-5790001-15018','Državni proračun RH','Doprinos za MIO II','08','Uplata doprinosa za MIO II stup','1001005','1700036001','0','48222')
	insert into .[dbo].[DOPRINOS] values ('987','Mirovinsko osiguranje (samo I stup)-DRUGI DOH.2017','2','10','68','8176-','34','311116-5790001-15018','Državni proračun RH','Doprinos za MIO I','08','Uplata doprinosa za MIO I stup','1001005','1863000160','0','48222')


--povezivanje doprinosa za DD

       insert into .[dbo].[DDKATEGORIJALevel3] values ('981','989','1')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('981','988','1')
    insert into .[dbo].[DDKATEGORIJALevel3] values ('981','987','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('981','990','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('982','989','1')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('982','988','1')
    insert into .[dbo].[DDKATEGORIJALevel3] values ('982','987','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('982','990','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('983','989','1')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('983','988','1')
    insert into .[dbo].[DDKATEGORIJALevel3] values ('983','987','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('983','990','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('984','989','1')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('984','988','1')
    insert into .[dbo].[DDKATEGORIJALevel3] values ('984','987','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('984','990','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('985','989','1')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('985','988','1')
    insert into .[dbo].[DDKATEGORIJALevel3] values ('985','987','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('985','990','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('986','989','1')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('986','988','1')
    insert into .[dbo].[DDKATEGORIJALevel3] values ('986','987','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('986','990','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('987','989','1')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('987','988','1')
    insert into .[dbo].[DDKATEGORIJALevel3] values ('987','987','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('987','990','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('988','989','1')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('988','988','1')
    insert into .[dbo].[DDKATEGORIJALevel3] values ('988','987','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('988','990','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('989','989','1')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('989','988','1')
    insert into .[dbo].[DDKATEGORIJALevel3] values ('989','987','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('989','990','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('990','989','1')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('990','988','1')
    insert into .[dbo].[DDKATEGORIJALevel3] values ('990','987','0')
	insert into .[dbo].[DDKATEGORIJALevel3] values ('990','990','0')

	--dodavanje izdataka u DD

	insert into .[dbo].[DDKATEGORIJAIzdaci] values ('988','1')
	insert into .[dbo].[DDKATEGORIJAIzdaci] values ('987','1')
	insert into .[dbo].[DDKATEGORIJAIzdaci] values ('987','2')
go

--30.12.2016
--Alter procedure za DNR
ALTER PROCEDURE [dbo].[sp_DNR]
(
@Godina as int,
@OdMjeseca as int,
@DoMjeseca as int
) AS
BEGIN

Select DDOBRACUN.DDOBRACUNIDOBRACUN, DDOBRACUN.DDDATUMOBRACUNA As NadnevakIsplate, DDOBRACUNRadnici.DDIDRADNIK As IDRADNIK,
(DDRADNIK.DDIME + ' ' + DDRADNIK.DDPREZIME) As ImePrezime, (DDRADNIK.DDADRESA + ' ' + DDRADNIK.DDKUCNIBROJ + ', ' + DDRADNIK.DDMJESTO) As Adresa,
(DDRADNIK.DDOIB) As OIB,
(Select Coalesce(SUM(DDIZNOS),0) From DDOBRACUNRadniciVrstePosla 
Where DDOBRACUNRadniciVrstePosla.DDIDRADNIK = DDOBRACUNRadnici.DDIDRADNIK And SUBSTRING(DDOBRACUN.DDOBRACUNIDOBRACUN, 0, 5) = @Godina
And SUBSTRING(DDOBRACUNRadniciVrstePosla.DDOBRACUNIDOBRACUN, 6, 2) = SUBSTRING(DDOBRACUNRadnici.DDOBRACUNIDOBRACUN, 6, 2)
And DDOBRACUNRadniciVrstePosla.DDOBRACUNIDOBRACUN = DDOBRACUN.DDOBRACUNIDOBRACUN) AS IznosPrimitka,
(Select Coalesce(Sum(Case
	When DDOBRACUNRadniciDoprinosi.IDVRSTADOPRINOS = 2 And (DDOBRACUNRadniciDoprinosi.IDDOPRINOS In(8,10,987,989))
	Then DDOBRACUNRadniciDoprinosi.DDOBRACUNATIDOPRINOS
	Else 0
	End), 0) 
	From DDOBRACUNRadniciDoprinosi
	Where DDOBRACUNRadniciDoprinosi.DDOBRACUNIDOBRACUN = DDOBRACUN.DDOBRACUNIDOBRACUN 
	And IDVRSTADOPRINOS = 2 and DDOBRACUNRadniciDoprinosi.DDIDRADNIK = DDOBRACUNRadnici.DDIDRADNIK) As PrviStup,
(Select Coalesce(Sum(Case
	When DDOBRACUNRadniciDoprinosi.IDVRSTADOPRINOS = 2 And (DDOBRACUNRadniciDoprinosi.IDDOPRINOS In(9,988))
	Then DDOBRACUNRadniciDoprinosi.DDOBRACUNATIDOPRINOS
	Else 0
	End), 0)
	From DDOBRACUNRadniciDoprinosi
	Where DDOBRACUNRadniciDoprinosi.DDOBRACUNIDOBRACUN = DDOBRACUN.DDOBRACUNIDOBRACUN 
	And IDVRSTADOPRINOS = 2 and DDOBRACUNRadniciDoprinosi.DDIDRADNIK = DDOBRACUNRadnici.DDIDRADNIK) As DrugiStup, 0 As OsobniOdbitak, 
(Select Coalesce(SUM(DDOSNOVICAPOREZ), 0) From DDOBRACUNRadniciPorezi Where DDOBRACUNRadniciPorezi.DDOBRACUNIDOBRACUN = DDOBRACUN.DDOBRACUNIDOBRACUN 
	And DDOBRACUNRadniciPorezi.DDIDRADNIK = DDOBRACUNRadnici.DDIDRADNIK) As PoreznaOsnovica,
(Select Coalesce(SUM(DDOBRACUNATIPOREZ), 0) + DDOBRACUNRadnici.DDOBRACUNATIPRIREZ From DDOBRACUNRadniciPorezi 
	Where DDOBRACUNRadniciPorezi.DDOBRACUNIDOBRACUN = DDOBRACUN.DDOBRACUNIDOBRACUN And DDOBRACUNRadniciPorezi.DDIDRADNIK = DDOBRACUNRadnici.DDIDRADNIK) As PorezPrirez,
(Select Case
	When DDOBRACUN.DDRSM IS NULL OR LEN(DDOBRACUN.DDRSM) < 5
	Then Cast('2015-01-01' As DATETIME)
	Else CAST('20' + CAST(SUBSTRING(DDOBRACUN.DDRSM, 1, 2) As Nvarchar(2)) + '-' + CAST(MONTH(CAST(SUBSTRING(DDOBRACUN.DDRSM, 3, 3) As Int)) AS Nvarchar(2)) + '-' + 
		 CAST(DAY(CAST(SUBSTRING(DDOBRACUN.DDRSM, 3, 3) As Int)) As Nvarchar(2)) As DATETIME)
	End) As NadnevakUplate
From DDOBRACUN
Inner Join DDOBRACUNRadnici On DDOBRACUN.DDOBRACUNIDOBRACUN = DDOBRACUNRadnici.DDOBRACUNIDOBRACUN
Inner Join DDRADNIK On DDOBRACUNRadnici.DDIDRADNIK = DDRADNIK.DDIDRADNIK
Where SUBSTRING(DDOBRACUN.DDOBRACUNIDOBRACUN, 0, 5) = @Godina 
And SUBSTRING(DDOBRACUN.DDOBRACUNIDOBRACUN, 6, 2) BETWEEN @OdMjeseca AND @DoMjeseca
Order by DDOBRACUNRadnici.DDIDRADNIK
END
go

  update [dbo].[Doprinos] set zrndoprinos='1550100001'  where IDDOPRINOS = 990
  update [dbo].[Doprinos] set pzdoprinos=''  where IDDOPRINOS > 986
  update [dbo].[Doprinos] set podoprinos='8540-'  where IDDOPRINOS = 990

/****** Object:  StoredProcedure [dbo].[spGrupaPrimka]    Script Date: 11.1.2017. 9:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Davor Bursać
-- Create date: 2017-01-11
-- Description:	Procedura za subreport crpStanjeSkladistaGrupe (main report spStanjeSkladista)
-- =============================================

alter PROCEDURE [dbo].[spGrupaPrimka]
(     
	  @idPrimke int 
)
as
begin	
	 Select 
	 MT_GrupeProizvoda.Naziv as Naziv, 

	 --Kolicina
	  cast(sum(primstav.Kolicina) as decimal(18,4))  as Kolicina, 
	
	--Iznos
 	cast(SUM(primstav.CijenaPDV * primstav.Kolicina)as decimal(18,4)) As Iznos  --UKOLIKO IMA VISE SALDA, TREBA DOHVATITI ONAJ ZADNJI
	--SUM(MT_SkladisteStavke.Saldo / MT_SkladisteStavke.Kolicina) As Iznos
	
	From MT_Primka prim
		inner join MT_PrimkaStavke primstav on prim.ID = primstav.ID_Primke --primka --> primka stavke
		inner join MT_SkladisteStavke ss on ss.ID_PrimkaStavke = primstav.ID
		Inner Join PROIZVOD as product On ss.ID_Proizvod = product.IDPROIZVOD
		--Inner Join MT_Skladista On MT_SkladisteStavke.ID_Skladista = MT_Skladista.ID
		Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	
	WHERE prim.ID = @idPrimke 
		--and product.idGrupa is NOT NULL 
		and ss.Kolicina > 0 
		--and ss.TS = @datum
	
	group by  prim.SifraPrimke, MT_GrupeProizvoda.Naziv
end
go



/****** Object:  StoredProcedure [dbo].[spGrupaIzdatnica]    Script Date: 11.1.2017. 9:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Davor Bursać
-- Create date: 2017-01-11
-- Description:	Procedura za subreport crpIzdatnicaGrupqa (main report crpIzdatnica)
-- =============================================

alter PROCEDURE [dbo].[spGrupaIzdatnica]
(     
	  @idIzdatnice int 
)
as
begin	
		 Select 
	 MT_GrupeProizvoda.Naziv as Naziv, 

	 --Kolicina
	  cast(sum(izdstav.Kolicina) as decimal(18,4))  as Kolicina, 
	
	--Iznos
 	cast(SUM(izdstav.UkupanIznos)as decimal(18,4)) As Iznos  --UKOLIKO IMA VISE SALDA, TREBA DOHVATITI ONAJ ZADNJI
	--SUM(MT_SkladisteStavke.Saldo / MT_SkladisteStavke.Kolicina) As Iznos
	
	From MT_Izdatnica izd
		inner join MT_IzdatnicaStavka izdstav on izd.ID = izdstav.ID_Izdatnice --izdatnica --> izdatnica stavke
		inner join MT_SkladisteStavke ss on ss.ID_IzdatnicaStavke = izdstav.ID
		Inner Join PROIZVOD as product On ss.ID_Proizvod = product.IDPROIZVOD
		--Inner Join MT_Skladista On MT_SkladisteStavke.ID_Skladista = MT_Skladista.ID
		Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	
	WHERE izd.ID = @idIzdatnice 
		--and product.idGrupa is NOT NULL 
		and ss.Kolicina > 0 
		--and ss.TS = @datum
	
	group by  izd.Sifra, MT_GrupeProizvoda.Naziv
end
go

 --Object:  StoredProcedure [dbo].[sp_DohvatiProizvodeZaSaldoKartice]    Script Date: 13.01.2017 8:26:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Davor Bursać
-- Create date: 2016-10-21
-- Description:	Procedura za dohvat Proizvoda za report Saldo kartice 
-- =============================================
alter procedure [dbo].[sp_DohvatiProizvodeZaSaldoKartice]
(
	  @datumOd date,
	  @datumDo date,	  
	  @idSkladista int = NULL
)
as

	if @idSkladista is NULL
	Begin
	select distinct
	proizvod.idproizvod 
	from PROIZVOD proizvod 
	inner join mt_skladistestavke on MT_SkladisteStavke.ID_Proizvod = PROIZVOD.IDPROIZVOD   
	WHERE MT_SkladisteStavke.TS between @datumOd and @datumDo 
	 order by proizvod.IDPROIZVOD
	End

	if @idSkladista is not NULL
	Begin
	select distinct 
	proizvod.idproizvod 
	from PROIZVOD proizvod 
	inner join mt_skladistestavke on MT_SkladisteStavke.ID_Proizvod = PROIZVOD.IDPROIZVOD 
	WHERE MT_SkladisteStavke.TS between @datumOd and @datumDo and mt_skladistestavke.id_skladista = @idSkladista
	 order by proizvod.IDPROIZVOD
	End


return

--exec sp_DohvatiProizvodeZaSaldoKartice '2016-06-01','2016-06-30',1


/****** Object:  StoredProcedure [dbo].[spUlazIzlazSaldoKartica]    Script Date: 13.01.2017 8:27:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Davor Bursać
-- Create date: 2016-10-24
-- Description:	Procedura za report crpSaldoKartica
-- =============================================

alter procedure [dbo].[spUlazIzlazSaldoKartica]
(
	  @DatumOD date,
	  @DatumDO date,
	  @Skladiste int = NULL
)
as
BEGIN
	--crpSaldoKartica
	if @Skladiste is NULL
	Select Distinct 
		PROIZVOD.IDPROIZVOD AS ID, 
		PROIZVOD.NAZIVPROIZVOD AS Proizvod, 
		(select Sum(MT_PrimkaStavke.Kolicina) from mt_primkastavke	
		Inner Join MT_primka On MT_primkastavke.ID_primke = MT_primka.ID
		Where MT_primkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD And Cast(MT_primka.DatumNastajanja As date) Between @DatumOd And @DatumDo)	As KolicinaUlaz, 
		(select SUM(MT_PrimkaStavke.CijenaPDV*MT_PrimkaStavke.Kolicina)from mt_primkastavke	
		Inner Join MT_primka On MT_primkastavke.ID_primke = MT_primka.ID
		Where MT_primkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD And Cast(MT_primka.DatumNastajanja As date) Between @DatumOd And @DatumDo)  As CijenaUlaz, 
		
		(Select ISNULL(SUM(MT_IzdatnicaStavka.Kolicina), 0) From MT_IzdatnicaStavka 
		Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
		Where MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD And Cast(MT_Izdatnica.DatumNastajanja As date) Between @DatumOd And @DatumDo) As KolicinaIzlaz, 
		
		(Select ISNULL(SUM(MT_IzdatnicaStavka.NabavnaCijena*MT_IzdatnicaStavka.Kolicina), 0) From MT_IzdatnicaStavka 
		Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
		Where MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD And Cast(MT_Izdatnica.DatumNastajanja As date) Between @DatumOd And @DatumDo) As CijenaIzlaz,
	
		'' as NazivSkladista		

	From PROIZVOD
		Inner Join MT_PrimkaStavke On PROIZVOD.IDPROIZVOD = MT_PrimkaStavke.ID_Proizvoda 
		Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
		inner join MT_Skladista on MT_Skladista.ID = MT_Primka.ID_Skladista
	Where Cast(DatumNastajanja As date) Between @DatumOd And @DatumDo
	GROUP BY PROIZVOD.IDPROIZVOD, PROIZVOD.NAZIVPROIZVOD, MT_Skladista.Naziv

	ELSE

	Select Distinct 
		PROIZVOD.IDPROIZVOD AS ID, 
		PROIZVOD.NAZIVPROIZVOD AS Proizvod, 
		Sum(MT_PrimkaStavke.Kolicina) As KolicinaUlaz, 
		SUM(MT_PrimkaStavke.CijenaPDV*MT_PrimkaStavke.Kolicina)  As CijenaUlaz, 
		
		(Select ISNULL(SUM(MT_IzdatnicaStavka.Kolicina), 0) From MT_IzdatnicaStavka 
		Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
		Where MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD And Cast(MT_Izdatnica.DatumNastajanja As date)  Between @DatumOd And @DatumDo and MT_Izdatnica.ID_Skladista = @Skladiste) As KolicinaIzlaz, 
		
		(Select ISNULL(SUM(MT_IzdatnicaStavka.NabavnaCijena*MT_IzdatnicaStavka.Kolicina), 0) From MT_IzdatnicaStavka 
		Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
		Where MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD And Cast(MT_Izdatnica.DatumNastajanja As date) Between @DatumOd And @DatumDo and MT_Izdatnica.ID_Skladista = @Skladiste) As CijenaIzlaz,

		MT_Skladista.Naziv as NazivSkladista		
	
	From PROIZVOD
		Inner Join MT_PrimkaStavke On PROIZVOD.IDPROIZVOD = MT_PrimkaStavke.ID_Proizvoda 
		Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
		inner join MT_Skladista on MT_Skladista.ID = MT_Primka.ID_Skladista
	Where Cast(DatumNastajanja As date) Between @DatumOd And @DatumDo and MT_Primka.ID_Skladista = @Skladiste
	GROUP BY PROIZVOD.IDPROIZVOD, PROIZVOD.NAZIVPROIZVOD, MT_Skladista.Naziv
END

--exec spUlazIzlazSaldoKartica '2016-04-01', '2016-04-30', 2

-- Object:  StoredProcedure [dbo].[sp_DohvatiProizvodeZaSaldoKartice]    Script Date: 13.01.2017 8:26:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--alter jer se mijenjao ulazni parametar
ALTER PROCEDURE [dbo].[spUlazIzlazGrupaIzdatnica]
(
      @datumOd date,
	  @datumDo date,
	  @skladiste int = NULL
)
AS 	

    BEGIN

	IF @skladiste is NULL
	Begin
	Select Distinct MT_GrupeProizvoda.Naziv,
	(Select SUM(MT_IzdatnicaStavka.UkupanIznos) From MT_IzdatnicaStavka
	Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD
	Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
	Where PROIZVOD.idGrupa = product.idGrupa
	And Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @datumDo And idGrupa is NOT NULL) As Iznos
	From MT_IzdatnicaStavka 
	Inner Join PROIZVOD as product On MT_IzdatnicaStavka.ID_Proizvoda = product.IDPROIZVOD
	Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
	Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	Where Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @datumDo And product.idGrupa is NOT NULL
	End
	IF @skladiste is Not NULL
	Begin
	Select Distinct MT_GrupeProizvoda.Naziv,
	(Select SUM(MT_IzdatnicaStavka.UkupanIznos) From MT_IzdatnicaStavka
	Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD
	Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
	Where PROIZVOD.idGrupa = product.idGrupa
	And MT_Izdatnica.ID_Skladista =  @skladiste And Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @datumDo And idGrupa is NOT NULL) As Iznos
	From MT_IzdatnicaStavka 
	Inner Join PROIZVOD as product On MT_IzdatnicaStavka.ID_Proizvoda = product.IDPROIZVOD
	Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
	Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	Where MT_Izdatnica.ID_Skladista =  @skladiste
	And Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @datumDo And product.idGrupa is NOT NULL
	End
    END
RETURN
go


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--alter jer se mijenjao ulazni parametar
ALTER PROCEDURE [dbo].[spUlazIzlazGrupaPrimka]
(
      @datumOd date,
	  @datumDo date,
	  @skladiste int = NULL
)
AS 	

	IF @skladiste is NULL
	Begin
	Select Distinct MT_GrupeProizvoda.Naziv,
	(Select SUM(MT_PrimkaStavke.CijenaPDV * MT_PrimkaStavke.Kolicina) From MT_PrimkaStavke
	Inner Join PROIZVOD On MT_PrimkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD
	Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
	Where PROIZVOD.idGrupa = product.idGrupa
	And Cast(MT_Primka.DatumNastajanja As Date) Between @datumOd And @datumDo And idGrupa is NOT NULL) As Iznos
	From MT_PrimkaStavke 
	Inner Join PROIZVOD as product On MT_PrimkaStavke.ID_Proizvoda = product.IDPROIZVOD
	Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
	Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	Where Cast(MT_Primka.DatumNastajanja As Date) Between @datumOd And @datumDo And product.idGrupa is NOT NULL
    End

	IF @skladiste is NOT NULL
	Begin
	Select Distinct MT_GrupeProizvoda.Naziv,
	(Select SUM(MT_PrimkaStavke.CijenaPDV * MT_PrimkaStavke.Kolicina) From MT_PrimkaStavke
	Inner Join PROIZVOD On MT_PrimkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD
	Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
	Where PROIZVOD.idGrupa = product.idGrupa
	And MT_Primka.ID_Skladista =  @skladiste And Cast(MT_Primka.DatumNastajanja As Date) Between @datumOd And @datumDo And idGrupa is NOT NULL) As Iznos
	From MT_PrimkaStavke 
	Inner Join PROIZVOD as product On MT_PrimkaStavke.ID_Proizvoda = product.IDPROIZVOD
	Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
	Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	Where Cast(MT_Primka.DatumNastajanja As Date) Between @datumOd And @datumDo And product.idGrupa is NOT NULL
	And MT_Primka.ID_Skladista =  @skladiste
    End
RETURN
go


/****** Object:  StoredProcedure [dbo].[spUlazIzlazSaldoGrupe]    Script Date: 13.01.2017 8:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Davor Bursać
-- Create date: 2016-10-24
-- Description:	Procedura za report crpSaldoGrupe
-- =============================================

alter procedure [dbo].[spUlazIzlazSaldoGrupe]
(
	  @DatummOD1 date,
	  @DatummDO2 date,
	  @Skladistee3 int = NULL
)
as
BEGIN
	--ukoliko NIJE odabrano neko skladište
	IF @Skladistee3 is NULL
	--crpSaldoGrupa
	Select Distinct 
	MT_GrupeProizvoda.ID , 
	MT_GrupeProizvoda.Naziv, 
	
		(select isnull( sum(MT_PrimkaStavke.Kolicina),0) from MT_PrimkaStavke
		Inner Join PROIZVOD On MT_PrimkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD
		Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
		Where PROIZVOD.idGrupa = product.idGrupa And idGrupa is NOT NULL and Cast(MT_Primka.DatumNastajanja As date) Between @DatummOD1 And @DatummDO2)  as kolicinaulaz,


		(Select isnull(SUM(MT_PrimkaStavke.CijenaPDV * MT_PrimkaStavke.Kolicina),0) From MT_PrimkaStavke
		Inner Join PROIZVOD On MT_PrimkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD
		Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
		Where PROIZVOD.idGrupa = product.idGrupa And idGrupa is NOT NULL and Cast(MT_Primka.DatumNastajanja As date) Between @DatummOD1 And @DatummDO2)  As CijenaUlaz,
	 	
		(select isnull(sum(MT_IzdatnicaStavka.Kolicina),0) from MT_IzdatnicaStavka
		Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD
		Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
		Where PROIZVOD.idGrupa = product.idGrupa And idGrupa is NOT NULL and Cast(MT_izdatnica.DatumNastajanja As date) Between @DatummOD1 And @DatummDO2) 	As KolicinaIzlaz ,
		
	    (Select isnull(SUM(MT_IzdatnicaStavka.NabavnaCijena * MT_IzdatnicaStavka.Kolicina),0) From MT_IzdatnicaStavka
		Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD
		Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
		Where PROIZVOD.idGrupa = product.idGrupa And idGrupa is NOT NULL  And Cast(MT_Izdatnica.DatumNastajanja As date) Between @DatummOD1 And @DatummDO2) As CijenaIzlaz
	
		From MT_PrimkaStavke 
	    Inner Join PROIZVOD as product On MT_PrimkaStavke.ID_Proizvoda = product.IDPROIZVOD
	    Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
	    Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	    Inner Join MT_IzdatnicaStavka On MT_IzdatnicaStavka.ID_Proizvoda = product.IDPROIZVOD
	    Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
		WHERE product.idGrupa is NOT NULL 
ELSE
	Select Distinct 
	MT_GrupeProizvoda.ID , 
	MT_GrupeProizvoda.Naziv, 
	
		(select isnull(sum(MT_PrimkaStavke.Kolicina),0) from MT_PrimkaStavke
		Inner Join PROIZVOD On MT_PrimkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD
		Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
		Where PROIZVOD.idGrupa = product.idGrupa And idGrupa is NOT NULL and Cast(MT_Primka.DatumNastajanja As date) Between @DatummOD1 And @DatummDO2 and MT_Primka.ID_Skladista = @Skladistee3)  as kolicinaulaz,

		(Select isnull(SUM(MT_PrimkaStavke.CijenaPDV * MT_PrimkaStavke.Kolicina),0) From MT_PrimkaStavke
		Inner Join PROIZVOD On MT_PrimkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD
		Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
		Where PROIZVOD.idGrupa = product.idGrupa And idGrupa is NOT NULL and Cast(MT_Primka.DatumNastajanja As date) Between @DatummOD1 And @DatummDO2 and MT_Primka.ID_Skladista = @Skladistee3) As CijenaUlaz,
	 	
		(select isnull(sum(MT_IzdatnicaStavka.Kolicina),0) from MT_IzdatnicaStavka
		Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD
		Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
		Where PROIZVOD.idGrupa = product.idGrupa And idGrupa is NOT NULL and Cast(MT_izdatnica.DatumNastajanja As date) Between @DatummOD1 And @DatummDO2 and MT_Izdatnica.ID_Skladista = @Skladistee3) As KolicinaIzlaz,
	
		(Select isnull(SUM(MT_IzdatnicaStavka.NabavnaCijena * MT_IzdatnicaStavka.Kolicina),0) From MT_IzdatnicaStavka
		Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD
		Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
		Where PROIZVOD.idGrupa = product.idGrupa And idGrupa is NOT NULL  And Cast(MT_Izdatnica.DatumNastajanja As date) Between @DatummOD1 And @DatummDO2 and MT_Izdatnica.ID_Skladista = @Skladistee3) As CijenaIzlaz
	
		From MT_PrimkaStavke 
	    Inner Join PROIZVOD as product On MT_PrimkaStavke.ID_Proizvoda = product.IDPROIZVOD
	    Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
	    Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	    Inner Join MT_IzdatnicaStavka On MT_IzdatnicaStavka.ID_Proizvoda = product.IDPROIZVOD
    	Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
		WHERE product.idGrupa is NOT NULL 
END
go




/****** Object:  StoredProcedure [dbo].[spStanjeSkladista]    Script Date: 13.1.2017. 10:28:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Davor Bursać
-- Create date: 2016-11-04
-- Description:	Procedura za report crpStanjeSkladistaGrupe (main report spStanjeSkladista)
-- =============================================

ALTER PROCEDURE [dbo].[spStanjeSkladista]
(    
	  @idSkladista int ,
	  @datum date,
	  @order nvarchar (50)
)
as
begin	
select derived1.* from 
(
select  distinct TOP (100) PERCENT 
	dbo.MT_Skladista.ID AS ID_Skladiste, 
	dbo.MT_Skladista.Naziv AS Skladiste, 
	dbo.PROIZVOD.idGrupa AS GrupaProizvod, 
	dbo.PROIZVOD.IDPROIZVOD, 
	dbo.PROIZVOD.NAZIVPROIZVOD AS Proizvod, 
	CAST(0 AS Decimal(18, 4)) AS BasePrice, 	 
	
	(Select Top 1 Stanje From MT_SkladisteStavke Where TS <= @datum And ID_Proizvod = PROIZVOD.IDPROIZVOD And ID_Skladista =  @idSkladista  Order by TS desc, RedniBrojDan desc) as KolicinaX, 	
	(SELECT top 1 Stanje FROM MT_SkladisteStavke where ID_Proizvod = PROIZVOD.IDPROIZVOD and MT_SkladisteStavke.TS <= @datum  order by ID desc) as Stanje,		
	(Select Top 1 Saldo From MT_SkladisteStavke Where TS <= @datum  And ID_Proizvod = PROIZVOD.IDPROIZVOD And ID_Skladista =  @idSkladista  Order by TS desc, RedniBrojDan desc)  as Saldo,	
	CAST(NULL AS datetime) AS Datum, 
	dbo.PROIZVOD.idGrupa
	
FROM dbo.MT_SkladisteStavke
	LEFT OUTER JOIN dbo.MT_PrimkaStavke ON dbo.MT_SkladisteStavke.ID_PrimkaStavke = dbo.MT_PrimkaStavke.ID 
	LEFT OUTER JOIN dbo.MT_IzdatnicaStavka ON dbo.MT_SkladisteStavke.ID_IzdatnicaStavke = dbo.MT_IzdatnicaStavka.ID 
	INNER JOIN dbo.MT_Skladista ON dbo.MT_SkladisteStavke.ID_Skladista = dbo.MT_Skladista.ID 
	INNER JOIN dbo.JEDINICAMJERE ON dbo.MT_PrimkaStavke.ID_JedinicaMjere = dbo.JEDINICAMJERE.IDJEDINICAMJERE 
	INNER JOIN dbo.PROIZVOD ON dbo.MT_SkladisteStavke.ID_Proizvod = dbo.PROIZVOD.IDPROIZVOD
	
WHERE MT_SkladisteStavke.ID_Skladista = @idSkladista
	and PROIZVOD.idGrupa is NOT NULL 
	and MT_SkladisteStavke.Kolicina > 0 
	and MT_SkladisteStavke.TS <=  @datum 
group by  MT_SkladisteStavke.ID, MT_Skladista.id, MT_Skladista.Naziv, PROIZVOD.idGrupa, PROIZVOD.IDPROIZVOD, PROIZVOD.NAZIVPROIZVOD, JEDINICAMJERE.NAZIVJEDINICAMJERE, MT_SkladisteStavke.Saldo, JEDINICAMJERE.IDJEDINICAMJERE, MT_Skladista.TS, MT_SkladisteStavke.Kolicina

) 
as derived1

order by  
		case 
			when @order = 'PROIZVOD.IDPROIZVOD' then cast(derived1.IDPROIZVOD as nvarchar(50))
			when @order = 'PROIZVOD.NAZIVPROIZVOD' then cast(derived1.Proizvod as nvarchar(50))
			else cast(derived1.KolicinaX as nvarchar(50))
		end
end
go


--alter vStanjeDokumenti
ALTER VIEW [dbo].[vStanjeDokumenti]
AS
SELECT        'Primka' AS Vrsta, SifraPrimke AS Sifra, DatumNastajanja AS Datum, sklad .Naziv AS Skladiste, NetoPrimke AS Neto, BrutoPrimke AS Bruto, PDVPrimke AS PDV, 
                         CASE WHEN sklad .Porez = 1 THEN (BrutoPrimke - NetoPrimke) ELSE 0 END AS PDVNE, CASE WHEN sklad .Porez = 1 THEN (NetoPrimke + PDVPrimke - BrutoPrimke) ELSE 0 END AS PDVDA, NULL 
                         AS UkupanIznos, sklad .ID AS ID_Skladista, sklad.ID_MjestoTroska
FROM            MT_Primka INNER JOIN
                         MT_Skladista sklad ON MT_Primka.ID_Skladista = sklad.ID
UNION
SELECT        'Izdatnica' AS Vrsta, MT_Izdatnica.Sifra, DatumNastajanja AS Datum, sklad .Naziv AS Skladiste, NULL AS Neto, NULL AS Bruto, NULL AS PDV, NULL AS PDVNE, NULL AS PDVDA, UkupanIznos, 
                         sklad.ID AS ID_Skladista, sklad.ID_MjestoTroska
FROM            MT_Izdatnica INNER JOIN
                         MT_Skladista sklad ON MT_Izdatnica.ID_Skladista = sklad.ID
GO
			
			
--alter spMjestoTroskaIspis
/****** Object:  StoredProcedure [dbo].[spMjestoTroskaIspis]    Script Date: 16.1.2017. 7:55:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spMjestoTroskaIspis]
(
      @datumOd nvarchar(10),
	  @dateumDo nvarchar(10),
	  @skladiste int = NULL, 
	  @mjestoTroska int
)
AS 		
    BEGIN
	IF @skladiste is NULL
		Begin
			Select Distinct MT_GrupeProizvoda.Naziv,
			(Select NAZIVMJESTOTROSKA From MJESTOTROSKA Where IDMJESTOTROSKA = @mjestoTroska) As MjestoTroska,
			(Select SUM(MT_IzdatnicaStavka.UkupanIznos) From MT_IzdatnicaStavka
			Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD
			Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
			Where PROIZVOD.idGrupa = product.idGrupa And MT_Izdatnica.MjestoTroska = @mjestoTroska
			And Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @dateumDo And idGrupa is NOT NULL) As Iznos,
			(Select SUM(MT_IzdatnicaStavka.Kolicina) From MT_IzdatnicaStavka
			Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD
			Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
			Where PROIZVOD.idGrupa = product.idGrupa And MT_Izdatnica.MjestoTroska = @mjestoTroska
			And Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @dateumDo And idGrupa is NOT NULL) As Kolicina
			From MT_IzdatnicaStavka 
			Inner Join PROIZVOD as product On MT_IzdatnicaStavka.ID_Proizvoda = product.IDPROIZVOD
			Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
			Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
			Where Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @dateumDo And product.idGrupa is NOT NULL And MT_Izdatnica.MjestoTroska = @mjestoTroska
		End
	IF @skladiste is Not NULL
		Begin
			Select Distinct MT_GrupeProizvoda.Naziv,
			(Select NAZIVMJESTOTROSKA From MJESTOTROSKA Where IDMJESTOTROSKA = @mjestoTroska) As MjestoTroska,
			(Select SUM(MT_IzdatnicaStavka.UkupanIznos) From MT_IzdatnicaStavka
			Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD
			Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
			Where PROIZVOD.idGrupa = product.idGrupa And MT_Izdatnica.MjestoTroska = @mjestoTroska
			And MT_Izdatnica.ID_Skladista =  @skladiste And Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @dateumDo And idGrupa is NOT NULL) As Iznos,
			(Select SUM(MT_IzdatnicaStavka.Kolicina) From MT_IzdatnicaStavka
			Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD
			Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
			Where PROIZVOD.idGrupa = product.idGrupa And MT_Izdatnica.MjestoTroska = @mjestoTroska
			And Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @dateumDo And idGrupa is NOT NULL) As Kolicina
			From MT_IzdatnicaStavka 
			Inner Join PROIZVOD as product On MT_IzdatnicaStavka.ID_Proizvoda = product.IDPROIZVOD
			Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
			Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
			Where MT_Izdatnica.ID_Skladista =  @skladiste
			And Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @dateumDo And product.idGrupa is NOT NULL And MT_Izdatnica.MjestoTroska = @mjestoTroska
		End
    END
RETURN
go


/****** Object:  Table [dbo].[MT_Inventura]    Script Date: 16.1.2017. 10:05:55 ******/
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


/****** Object:  Table [dbo].[MT_InventuraStavka]    Script Date: 16.1.2017. 10:06:33 ******/
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


/****** Object:  StoredProcedure [dbo].[spInventurnaLista]    Script Date: 16.01.2017 14:38:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Davor Bursać
-- Create date: 2017-01-16
-- Description:	Procedura za report crpInventurnaLista 
-- =============================================
create PROCEDURE [dbo].[spInventurnaLista]
(    
	  @idSkladista int,
	  @datum date,
	  @order nvarchar (50),
	  @PrikazKolicina bit
)
as
begin	
	if(@PrikazKolicina <> 0)
		begin
			select derived1.* from 
			(
			select  distinct TOP (100) PERCENT 
				dbo.MT_Skladista.ID AS ID_Skladiste, 
				dbo.MT_Skladista.Naziv AS Skladiste, 
				dbo.PROIZVOD.idGrupa AS GrupaProizvod, 
				dbo.PROIZVOD.IDPROIZVOD  As idproizvod, 
				dbo.PROIZVOD.NAZIVPROIZVOD AS Proizvod, 
				CAST(0 AS Decimal(18, 4)) AS BasePrice, 	 
			
				(Select Top 1 Stanje From MT_SkladisteStavke Where TS <= @datum And mt_skladistestavke.ID_Proizvod = proizvod.IDProizvod And ID_Skladista =  @idSkladista  Order by TS desc, RedniBrojDan desc) as KolicinaX,
				(SELECT top 1 Stanje FROM MT_SkladisteStavke where ID_Proizvod = PROIZVOD.IDPROIZVOD and MT_SkladisteStavke.TS <= @datum  order by ID desc) as Stanje,
				(Select Top 1 Saldo From MT_SkladisteStavke Where TS <= @datum  And ID_Proizvod = PROIZVOD.IDProizvod And ID_Skladista =  @idSkladista  Order by TS desc, RedniBrojDan desc) as Saldo,				
				CAST(NULL AS datetime) AS Datum, 
				dbo.PROIZVOD.idGrupa
	
			FROM dbo.MT_SkladisteStavke
				LEFT OUTER JOIN dbo.MT_PrimkaStavke ON dbo.MT_SkladisteStavke.ID_PrimkaStavke = dbo.MT_PrimkaStavke.ID 
				LEFT OUTER JOIN dbo.MT_IzdatnicaStavka ON dbo.MT_SkladisteStavke.ID_IzdatnicaStavke = dbo.MT_IzdatnicaStavka.ID 
				INNER JOIN dbo.MT_Skladista ON dbo.MT_SkladisteStavke.ID_Skladista = dbo.MT_Skladista.ID 
				INNER JOIN dbo.JEDINICAMJERE ON dbo.MT_PrimkaStavke.ID_JedinicaMjere = dbo.JEDINICAMJERE.IDJEDINICAMJERE 
				INNER JOIN dbo.PROIZVOD ON dbo.MT_SkladisteStavke.ID_Proizvod = dbo.PROIZVOD.IDPROIZVOD
	
			WHERE MT_SkladisteStavke.ID_Skladista = @idSkladista
				and PROIZVOD.idGrupa is NOT NULL 
				and MT_SkladisteStavke.Kolicina > 0 
				and MT_SkladisteStavke.TS <=  @datum 
			group by  MT_SkladisteStavke.ID, MT_Skladista.id, MT_Skladista.Naziv, PROIZVOD.idGrupa, PROIZVOD.IDPROIZVOD, PROIZVOD.NAZIVPROIZVOD, JEDINICAMJERE.NAZIVJEDINICAMJERE, MT_SkladisteStavke.Saldo, JEDINICAMJERE.IDJEDINICAMJERE, MT_Skladista.TS, MT_SkladisteStavke.Kolicina

			) 
			as derived1

			order by  
					case 
						when @order = 'PROIZVOD.IDPROIZVOD' then cast(derived1.IDPROIZVOD as nvarchar(50))
						when @order = 'PROIZVOD.NAZIVPROIZVOD' then cast(derived1.Proizvod as nvarchar(50))
						else cast(derived1.KolicinaX as nvarchar(50))
					end
		end
	else --ovaj je za IF gore
		begin
			select derived1.* from 
			(
			select  distinct TOP (100) PERCENT 
				dbo.MT_Skladista.ID AS ID_Skladiste, 
				dbo.MT_Skladista.Naziv AS Skladiste, 
				dbo.PROIZVOD.idGrupa AS GrupaProizvod, 
				dbo.PROIZVOD.IDPROIZVOD, 
				dbo.PROIZVOD.NAZIVPROIZVOD AS Proizvod, 
				CAST(0 AS Decimal(18, 4)) AS BasePrice,
					 
				'' as KolicinaX,
				(SELECT top 1 Stanje FROM MT_SkladisteStavke where ID_Proizvod = PROIZVOD.IDPROIZVOD and MT_SkladisteStavke.TS <= @datum  order by ID desc) as Stanje,
				(SELECT top 1 Saldo FROM MT_SkladisteStavke where ID_Proizvod = PROIZVOD.IDPROIZVOD and MT_SkladisteStavke.TS <= @datum  order by ID desc) as Saldo,	
				CAST(NULL AS datetime) AS Datum, 
				dbo.PROIZVOD.idGrupa
	
			FROM dbo.MT_SkladisteStavke
				LEFT OUTER JOIN dbo.MT_PrimkaStavke ON dbo.MT_SkladisteStavke.ID_PrimkaStavke = dbo.MT_PrimkaStavke.ID 
				LEFT OUTER JOIN dbo.MT_IzdatnicaStavka ON dbo.MT_SkladisteStavke.ID_IzdatnicaStavke = dbo.MT_IzdatnicaStavka.ID 
				INNER JOIN dbo.MT_Skladista ON dbo.MT_SkladisteStavke.ID_Skladista = dbo.MT_Skladista.ID 
				INNER JOIN dbo.JEDINICAMJERE ON dbo.MT_PrimkaStavke.ID_JedinicaMjere = dbo.JEDINICAMJERE.IDJEDINICAMJERE 
				INNER JOIN dbo.PROIZVOD ON dbo.MT_SkladisteStavke.ID_Proizvod = dbo.PROIZVOD.IDPROIZVOD
	
			WHERE MT_SkladisteStavke.ID_Skladista = @idSkladista
				and PROIZVOD.idGrupa is NOT NULL 
				and MT_SkladisteStavke.Kolicina > 0 
				and MT_SkladisteStavke.TS <=  @datum 
			group by  MT_SkladisteStavke.ID, MT_Skladista.id, MT_Skladista.Naziv, PROIZVOD.idGrupa, PROIZVOD.IDPROIZVOD, PROIZVOD.NAZIVPROIZVOD, JEDINICAMJERE.NAZIVJEDINICAMJERE, MT_SkladisteStavke.Saldo, JEDINICAMJERE.IDJEDINICAMJERE, MT_Skladista.TS, MT_SkladisteStavke.Kolicina

			) 
			as derived1

			order by  
					case 
						when @order = 'PROIZVOD.IDPROIZVOD' then cast(derived1.IDPROIZVOD as nvarchar(50))
						when @order = 'PROIZVOD.NAZIVPROIZVOD' then cast(derived1.Proizvod as nvarchar(50))
						else cast(derived1.KolicinaX as nvarchar(50))
					end
		end
end


/****** Object:  StoredProcedure [dbo].[sp_DDDoprinosiNA]    Script Date: 17.1.2017. 15:47:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sp_DDDoprinosiNA]	
(
	@IDObracun nvarchar(15),
	@IDRadnik int
)
AS
BEGIN
	select dop.*, 
	vp.DDIZNOS
	from DDOBRACUNRadniciDoprinosi dop
		left join DDOBRACUNRadniciVrstePosla vp on vp.DDIDRADNIK = dop.DDIDRADNIK
	where dop.DDOBRACUNIDOBRACUN = @IDObracun and dop.DDIDRADNIK = @IDRadnik and IDVRSTADOPRINOS = 1 and vp.DDOBRACUNIDOBRACUN = @IDObracun
END


--db - 18.01.2017
/****** Object:  View [dbo].[v_DDDoprinosNA]    Script Date: 18.1.2017. 9:27:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_DDDoprinosNA]
AS
SELECT        dbo.DDOBRACUN.DDOBRACUNIDOBRACUN, dbo.DDOBRACUNRadnici.DDIDRADNIK, dbo.DDOBRACUNRadnici.DDOBRACUNATIPDV, dbo.DDOBRACUNRadniciDDKrizniPorez.DDPOREZKRIZNI, 
                         dbo.DDOBRACUNRadniciDoprinosi.IDDOPRINOS, dbo.DDOBRACUNRadniciDoprinosi.NAZIVDOPRINOS, dbo.DDOBRACUN.DDDATUMOBRACUNA, dbo.DDOBRACUNRadniciDoprinosi.IDVRSTADOPRINOS, 
                         dbo.DDOBRACUNRadniciVrstePosla.DDIZNOS, dbo.DDRADNIK.DDOIB, dbo.DDOBRACUNRadnici.DDOBRACUNATIPRIREZ, dbo.DDRADNIK.DDPREZIME, dbo.DDRADNIK.DDIME
FROM            dbo.DDOBRACUN INNER JOIN
                         dbo.DDOBRACUNRadnici ON dbo.DDOBRACUN.DDOBRACUNIDOBRACUN = dbo.DDOBRACUNRadnici.DDOBRACUNIDOBRACUN INNER JOIN
                         dbo.DDRADNIK ON dbo.DDOBRACUNRadnici.DDIDRADNIK = dbo.DDRADNIK.DDIDRADNIK LEFT OUTER JOIN
                         dbo.DDOBRACUNRadniciVrstePosla ON dbo.DDOBRACUN.DDOBRACUNIDOBRACUN = dbo.DDOBRACUNRadniciVrstePosla.DDOBRACUNIDOBRACUN AND 
                         dbo.DDOBRACUNRadnici.DDIDRADNIK = dbo.DDOBRACUNRadniciVrstePosla.DDIDRADNIK LEFT OUTER JOIN
                         dbo.DDOBRACUNRadniciPorezi ON dbo.DDOBRACUN.DDOBRACUNIDOBRACUN = dbo.DDOBRACUNRadniciPorezi.DDOBRACUNIDOBRACUN AND 
                         dbo.DDOBRACUNRadnici.DDIDRADNIK = dbo.DDOBRACUNRadniciPorezi.DDIDRADNIK LEFT OUTER JOIN
                         dbo.DDOBRACUNRadniciIzdaci ON dbo.DDOBRACUNRadnici.DDOBRACUNIDOBRACUN = dbo.DDOBRACUNRadniciIzdaci.DDOBRACUNIDOBRACUN AND 
                         dbo.DDOBRACUNRadnici.DDIDRADNIK = dbo.DDOBRACUNRadniciIzdaci.DDIDRADNIK LEFT OUTER JOIN
                         dbo.DDOBRACUNRadniciDoprinosi ON dbo.DDOBRACUNRadnici.DDIDRADNIK = dbo.DDOBRACUNRadniciDoprinosi.DDIDRADNIK AND 
                         dbo.DDOBRACUN.DDOBRACUNIDOBRACUN = dbo.DDOBRACUNRadniciDoprinosi.DDOBRACUNIDOBRACUN LEFT OUTER JOIN
                         dbo.DDOBRACUNRadniciDDKrizniPorez ON dbo.DDOBRACUNRadnici.DDOBRACUNIDOBRACUN = dbo.DDOBRACUNRadniciDDKrizniPorez.DDOBRACUNIDOBRACUN AND 
                         dbo.DDOBRACUNRadnici.DDIDRADNIK = dbo.DDOBRACUNRadniciDDKrizniPorez.DDIDRADNIK

GO

--19.11.2017
alter table [dbo].[Element]
add VrstaPrimanja nvarchar(5)  null


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spUlazIzlazSaldoKartica]
(
	  @DatumOD date,
	  @DatumDO date,
	  @Skladiste int = NULL
)
as
BEGIN
	--crpSaldoKartica
	if @Skladiste is not NULL
		Select Distinct 
			PROIZVOD.IDPROIZVOD AS ID, 
			PROIZVOD.NAZIVPROIZVOD AS Proizvod, 
			Sum(MT_PrimkaStavke.Kolicina) As KolicinaUlaz, 
			SUM(MT_PrimkaStavke.CijenaPDV*MT_PrimkaStavke.Kolicina)  As CijenaUlaz, 
		
			(Select ISNULL(SUM(MT_IzdatnicaStavka.Kolicina), 0) From MT_IzdatnicaStavka 
			Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
			Where MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD And Cast(MT_Izdatnica.DatumNastajanja As date)  Between @DatumOd And @DatumDo and MT_Izdatnica.ID_Skladista = @Skladiste) As KolicinaIzlaz, 
		
			(Select ISNULL(SUM(MT_IzdatnicaStavka.NabavnaCijena*MT_IzdatnicaStavka.Kolicina), 0) From MT_IzdatnicaStavka 
			Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
			Where MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD And Cast(MT_Izdatnica.DatumNastajanja As date) Between @DatumOd And @DatumDo and MT_Izdatnica.ID_Skladista = @Skladiste) As CijenaIzlaz,

			MT_Skladista.Naziv as NazivSkladista		
	
		From PROIZVOD
			Inner Join MT_PrimkaStavke On PROIZVOD.IDPROIZVOD = MT_PrimkaStavke.ID_Proizvoda 
			Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
			inner join MT_Skladista on MT_Skladista.ID = MT_Primka.ID_Skladista
		Where Cast(DatumNastajanja As date) Between @DatumOd And @DatumDo and MT_Primka.ID_Skladista = @Skladiste
		GROUP BY PROIZVOD.IDPROIZVOD, PROIZVOD.NAZIVPROIZVOD, MT_Skladista.Naziv
	ELSE
		Select Distinct 
			PROIZVOD.IDPROIZVOD AS ID, 
			PROIZVOD.NAZIVPROIZVOD AS Proizvod, 
			(select Sum(MT_PrimkaStavke.Kolicina) from mt_primkastavke	
			Inner Join MT_primka On MT_primkastavke.ID_primke = MT_primka.ID
			Where MT_primkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD And Cast(MT_primka.DatumNastajanja As date) Between @DatumOd And @DatumDo)	As KolicinaUlaz, 
			(select SUM(MT_PrimkaStavke.CijenaPDV*MT_PrimkaStavke.Kolicina)from mt_primkastavke	
			Inner Join MT_primka On MT_primkastavke.ID_primke = MT_primka.ID
			Where MT_primkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD And Cast(MT_primka.DatumNastajanja As date) Between @DatumOd And @DatumDo)  As CijenaUlaz, 
		
			(Select ISNULL(SUM(MT_IzdatnicaStavka.Kolicina), 0) From MT_IzdatnicaStavka 
			Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
			Where MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD And Cast(MT_Izdatnica.DatumNastajanja As date) Between @DatumOd And @DatumDo) As KolicinaIzlaz, 
		
			(Select ISNULL(SUM(MT_IzdatnicaStavka.NabavnaCijena*MT_IzdatnicaStavka.Kolicina), 0) From MT_IzdatnicaStavka 
			Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
			Where MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD And Cast(MT_Izdatnica.DatumNastajanja As date) Between @DatumOd And @DatumDo) As CijenaIzlaz,
	
			'' as NazivSkladista		

		From PROIZVOD
			Inner Join MT_PrimkaStavke On PROIZVOD.IDPROIZVOD = MT_PrimkaStavke.ID_Proizvoda 
			Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
			inner join MT_Skladista on MT_Skladista.ID = MT_Primka.ID_Skladista
		Where Cast(DatumNastajanja As date) Between @DatumOd And @DatumDo
		GROUP BY PROIZVOD.IDPROIZVOD, PROIZVOD.NAZIVPROIZVOD, MT_Skladista.Naziv	
END 



/****** Object:  Table [dbo].[VrstaOsobnihPrimanja]    Script Date: 13.5.2016. 10:11:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VrstaOsobnihPrimanja](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sifra] [nvarchar](5) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[TS] [datetime] NOT NULL,
 CONSTRAINT [PK_VrstaOsobnihPrimanja] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

Begin
	Insert Into VrstaOsobnihPrimanja (Sifra, Name, TS) Values 
	('100', 'Osobno primanje isplaćeno u cijelosti', '2016-05-13'),
	('110', 'Isplata dijela osobnog primanja', '2016-05-13'),
	('120', 'Osobno primanje umanjeno za zaštičeni dio', '2016-05-13'),
	('130', 'Ugovor o djelu', '2016-05-13'),
	('140', 'Rad za vrijeme školovanja', '2016-05-13'),
	('150', 'Isplata dividende', '2016-05-13'),
	('160', 'Naknada članova Upravnog vijeća, Skupština, Nadzornih odbora', '2016-05-13'),
	('170', 'Primanja od iznajmljivanja turističkih kapaciteta', '2016-05-13'),
	('180', 'Najam', '2016-05-13'),
	('190', 'Prijevoz', '2016-05-13'),
	('200', 'Službeni put', '2016-05-13'),
	('210', 'Terenski dodatak', '2016-05-13'),
	('220', 'Naknada za odvojeni život', '2016-05-13'),
	('230', 'Naknada za bolovanje', '2016-05-13'),
	('240', 'Naknada za korištenje privatnog automobila u službene svrhe', '2016-05-13'),
	('250', 'Naknada za prekovremeni rad, bonusi, stimulacije, ostale nagrade', '2016-05-13'),
	('260', 'Regres', '2016-05-13'),
	('270', 'Božićnica, uskrsnica', '2016-05-13'),
	('280', 'Dječji dar', '2016-05-13'),
	('290', 'Stipendije, pomoć studentima/učenicima za opremu, knjige i obitelj zaposlenika', '2016-05-13'),
	('300', 'Pomoć u slučaju stupanja u brak, smrt zaposlenika/člana obitelji zaposlenika', '2016-05-13'),
	('310', 'pomoć u slučaju rođenja djeteta', '2016-05-13'),
	('320', 'Otpremnina', '2016-05-13'),
	('399', 'Ostala osobna primanja', '2016-05-13')
End
GO

Begin
	Update ELEMENT Set VrstaPrimanja = 100 where IDELEMENT in( 1,10,11,12,63,65,1001,1002,1003,1004)
	Update ELEMENT Set VrstaPrimanja = 250 where IDELEMENT in( 2,3,4,5,6,7,8,9,13,15,16,53)
	Update ELEMENT Set VrstaPrimanja = 300 where idelement = 17
	Update ELEMENT Set vrstaprimanja = 130 where idelement = 18
	Update ELEMENT Set vrstaprimanja = 110 where idelement = 19
	Update ELEMENT Set vrstaprimanja = 399 where idelement in ( 20,56)
	Update ELEMENT Set vrstaprimanja = 320 where idelement in ( 21,55,57)
	Update ELEMENT Set vrstaprimanja = 230 where idelement in ( 50,51,61,62,64)
	Update ELEMENT Set vrstaprimanja = 190 where idelement = 52
	Update ELEMENT Set vrstaprimanja = 270 where idelement = 54
	Update ELEMENT Set vrstaprimanja = 260 where idelement = 58
	Update ELEMENT Set vrstaprimanja = 250 where idelement = 60
End
GO
