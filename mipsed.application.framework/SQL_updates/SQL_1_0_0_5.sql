GO
/****** Object:  StoredProcedure [dbo].[sp_Opomene]    Script Date: 03/31/2016 14:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_Opomene]
(
@IDPARTNER as INT,
@godina AS INT
) AS
BEGIN
SELECT            distinct 	(
(Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDPARTNER = PARTNER.IDPARTNER
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) And IDKONTO Not Like '9%' and POTRAZUJE > 0) -

(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDPARTNER = PARTNER.IDPARTNER
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) And IDKONTO Not Like '9%' and DUGUJE > 0) * -1

)  AS Otvoreno,

Case When dbo.PARTNER.Ucenik = 1 
	Then
	(
		Case When (Select ImeRoditelj From UF_Ucenik Where UF_Ucenik.OIB = dbo.PARTNER.PARTNEROIB) IS NOT NULL then
		(Select ImeRoditelj + ' ' + PrezimeRoditelj From UF_Ucenik Where UF_Ucenik.OIB = dbo.PARTNER.PARTNEROIB)
		Else
		(Select Ime + ' ' + Prezime From UF_Ucenik Where UF_Ucenik.OIB = dbo.PARTNER.PARTNEROIB) End
	)
	Else
	(dbo.PARTNER.NazivPartner) End AS NazivPartner,
Case When dbo.PARTNER.Ucenik = 1 
	Then
	(
		Case When (Select OIBRoditelj From UF_Ucenik Where UF_Ucenik.OIB = dbo.PARTNER.PARTNEROIB) IS NOT NULL then
		(Select OIBRoditelj From UF_Ucenik Where UF_Ucenik.OIB = dbo.PARTNER.PARTNEROIB)
		Else
		(Select OIB From UF_Ucenik Where UF_Ucenik.OIB = dbo.PARTNER.PARTNEROIB) End
	)
	Else
	(dbo.PARTNER.PARTNEROIB) End AS MB,
dbo.PARTNER.PartnerMjesto,
dbo.PARTNER.PartnerUlica,
dbo.GKSTAVKA.IDKONTO as Konto,

(select korisnik1naziv from dbo.KORISNIK) AS KorisnikNaziv,
(select KORISNIK1ADRESA from dbo.KORISNIK) as KorisnikAdresa,
(select KORISNIK1MJESTO from dbo.KORISNIK) as KorisnikGrad,
(select KORISNIKOIB from dbo.KORISNIK) as KorisnikOib,
(select PREZIMEIMEOVLASTENEOSOBE from dbo.KORISNIK) as ImePrezimeOvlastene
FROM   dbo.GKSTAVKA
INNER JOIN dbo.DOKUMENT ON dbo.GKSTAVKA.IDDOKUMENT = dbo.DOKUMENT.IDDOKUMENT
INNER JOIN dbo.KONTO ON dbo.GKSTAVKA.IDKONTO = dbo.KONTO.IDKONTO
INNER JOIN dbo.PARTNER ON dbo.GKSTAVKA.IDPARTNER = dbo.PARTNER.IDPARTNER
WHERE   dbo.partner.IDPARTNER = @IDPARTNER
AND GKSTAVKA.IDKONTO like '1%' AND ( GKSTAVKA.IDKONTO NOT LIKE '9%')
AND ABS(DBO.GKSTAVKA.DUGUJE - DBO.GKSTAVKA.POTRAZUJE) - DBO.GKSTAVKA.ZATVORENIIZNOS > 0
END

GO
Begin
Alter table DDRADNIK Add Aktivan bit NOT NULL default 1
End

GO
Begin
Alter table DDRADNIK Alter Column DDJMBG nvarchar(13) NULL
End