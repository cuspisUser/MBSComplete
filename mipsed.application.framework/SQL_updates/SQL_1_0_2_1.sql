/****** Object:  View [dbo].[vPrimkaDobavljac]    Script Date: 26.9.2016. 14:58:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[vPrimkaDobavljac]
AS
SELECT        'Primka' AS Vrsta, dbo.MT_Primka.SifraPrimke AS Sifra, dbo.MT_Primka.DatumNastajanja AS Datum, dbo.MT_Skladista.Naziv AS Skladiste, 
                         dbo.MT_Primka.NetoPrimke AS Neto, dbo.MT_Primka.BrutoPrimke AS Bruto, dbo.MT_Primka.PDVPrimke AS PDV, 
                         CASE WHEN MT_Skladista.Porez = 1 THEN (BrutoPrimke - NetoPrimke) ELSE 0 END AS PDVNE, 
                         CASE WHEN MT_Skladista.Porez = 1 THEN (NetoPrimke + PDVPrimke - BrutoPrimke) ELSE 0 END AS PDVDA, NULL AS UkupanIznos, dbo.MT_Primka.ID_Partnera, 
                         dbo.PARTNER.NAZIVPARTNER
FROM            dbo.MT_Primka INNER JOIN
                         dbo.MT_Skladista ON dbo.MT_Primka.ID_Skladista = dbo.MT_Skladista.ID INNER JOIN
                         dbo.PARTNER ON dbo.MT_Primka.ID_Partnera = dbo.PARTNER.IDPARTNER

GO