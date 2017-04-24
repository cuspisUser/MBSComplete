using Deklarit;
using Deklarit.Data;
using Deklarit.Utils;
using Hlp;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
    
namespace Placa
{
    public class OBRACUNDataAdapter : IDataAdapter, IOBRACUNDataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private bool _Gxremove179;
        private bool _Gxremove199;
        private bool _Gxremove214;
        private bool _Gxremove235;
        private bool _Gxremove257;
        private bool _Gxremove281;
        private bool _Gxremove296;
        private bool _Gxremove317;
        private ReadWriteCommand cmObracunDoprinosiSelect2;
        private ReadWriteCommand cmObracunElementiSelect2;
        private ReadWriteCommand cmOBRACUNKreditiSelect2;
        private ReadWriteCommand cmOBRACUNOBRACUNLevel1ObracunIzuzeceSelect2;
        private ReadWriteCommand cmOBRACUNOBRACUNLevel1ObracunKrizniSelect2;
        private ReadWriteCommand cmOBRACUNObustaveSelect2;
        private ReadWriteCommand cmObracunOlaksiceSelect2;
        private ReadWriteCommand cmObracunPoreziSelect2;
        private ReadWriteCommand cmObracunRadniciSelect2;
        private ReadWriteCommand cmOBRACUNSelect1;
        private ReadWriteCommand cmOBRACUNSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__DATUMISPLATEOriginal;
        private object m__DATUMOBRACUNASTAZAOriginal;
        private object m__faktooOriginal;
        private object m__GODINAISPLATEOriginal;
        private object m__GODINAOBRACUNAOriginal;
        private object m__ISKORISTENOOOOriginal;
        private object m__ISPLACENOKASAOriginal;
        private object m__IZNOSIZUZECAOriginal;
        private object m__IZNOSOBUSTAVEOriginal;
        private object m__IZNOSOLAKSICEOriginal;
        private object m__KOREKCIJAPRIREZAOriginal;
        private object m__MJESECISPLATEOriginal;
        private object m__MJESECNIFONDSATIOBRACUNOriginal;
        private object m__MJESECOBRACUNAOriginal;
        private object m__MOIZUZECEOriginal;
        private object m__MOOLAKSICAOriginal;
        private object m__MZIZUZECEOriginal;
        private object m__MZOLAKSICAOriginal;
        private object m__OBRACUNATAOBUSTAVAUKUNAMAOriginal;
        private object m__OBRACUNATAOLAKSICAOriginal;
        private object m__OBRACUNATIDOPRINOSOriginal;
        private object m__OBRACUNATIKUNSKIIZNOSOriginal;
        private object m__OBRACUNATIPOREZOriginal;
        private object m__OBRACUNATIPRIREZOriginal;
        private object m__OBRACUNAVAJOBUSTAVEOriginal;
        private object m__OBRACUNSKAOSNOVICAOriginal;
        private object m__OBRACUNSKIKOEFICIJENTOriginal;
        private object m__OBRFIKSNIHOriginal;
        private object m__OBRIZNOSOriginal;
        private object m__OBRIZNOSRATEKREDITOROriginal;
        private object m__OBRKREDITNIHOriginal;
        private object m__OBRMOKREDITOROriginal;
        private object m__OBRMZKREDITOROriginal;
        private object m__OBROPISPLACANJAKREDITOROriginal;
        private object m__OBRPOKREDITOROriginal;
        private object m__OBRPOSTOTAKOriginal;
        private object m__OBRPOSTOTNIHOriginal;
        private object m__OBRPZKREDITOROriginal;
        private object m__OBRSATIOriginal;
        private object m__OBRSATNICAOriginal;
        private object m__OBRSIFRAOPISAPLACANJAKREDITOROriginal;
        private object m__ODBITAKPRIJEKOREKCIJEOriginal;
        private object m__OPISPLACANJAIZUZECEOriginal;
        private object m__OPISPLACANJAOLAKSICAOriginal;
        private object m__OSNOVICADOPRINOSOriginal;
        private object m__OSNOVICAKRIZNIOriginal;
        private object m__OSNOVICAPOREZOriginal;
        private object m__OSNOVICAPRETHODNAOriginal;
        private object m__OSNOVICAUKUPNAOriginal;
        private object m__OSNOVNIOOOriginal;
        private object m__POIZUZECEOriginal;
        private object m__POOLAKSICAOriginal;
        private object m__POREZKRIZNIOriginal;
        private object m__POREZPRETHODNIOriginal;
        private object m__POREZUKUPNOOriginal;
        private object m__POSTOTAKOBUSTAVEOriginal;
        private object m__PRIMATELJIZUZECE1Original;
        private object m__PRIMATELJIZUZECE2Original;
        private object m__PRIMATELJIZUZECE3Original;
        private object m__PZIZUZECEOriginal;
        private object m__PZOLAKSICAOriginal;
        private object m__RADNIKOBRACUNOSNOVICAOriginal;
        private object m__SALDOKASAOriginal;
        private object m__SIFRAOPCINESTANOVANJAOriginal;
        private object m__SIFRAOPISAPLACANJAIZUZECEOriginal;
        private object m__SIFRAOPISAPLACANJAOLAKSICAOriginal;
        private object m__SVRHAOBRACUNAOriginal;
        private object m__TEKUCIIZUZECEOriginal;
        private object m__tjednifondsatiobracunOriginal;
        private object m__UKUPNIZNOSKREDITAOriginal;
        private object m__VBDIIZUZECEOriginal;
        private object m__VECOTPLACENOBROJRATAOriginal;
        private object m__VECOTPLACENOUKUPNIIZNOSOriginal;
        private object m__VRSTAOBRACUNAOriginal;
        private object m__ZAKLJOriginal;
        private readonly string m_SelectString9 = "TM1.[IDOBRACUN], TM1.[VRSTAOBRACUNA], TM1.[MJESECOBRACUNA], TM1.[GODINAOBRACUNA], TM1.[MJESECISPLATE], TM1.[GODINAISPLATE], TM1.[DATUMISPLATE], TM1.[tjednifondsatiobracun], TM1.[MJESECNIFONDSATIOBRACUN], TM1.[OSNOVNIOO], TM1.[OBRACUNSKAOSNOVICA], TM1.[DATUMOBRACUNASTAZA], TM1.[OBRPOSTOTNIH], TM1.[OBRFIKSNIH], TM1.[OBRKREDITNIH], TM1.[ZAKLJ], TM1.[SVRHAOBRACUNA]";
        private string m_SubSelTopString10;
        private string m_SubSelTopString11;
        private string m_SubSelTopString12;
        private string m_SubSelTopString13;
        private string m_SubSelTopString137;
        private string m_SubSelTopString292;
        private string m_SubSelTopString61;
        private string m_SubSelTopString62;
        private string m_SubSelTopString74;
        private string m_WhereString;
        private IDataReader ObracunDoprinosiSelect2;
        private IDataReader ObracunElementiSelect2;
        private IDataReader OBRACUNKreditiSelect2;
        private IDataReader OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2;
        private IDataReader OBRACUNOBRACUNLevel1ObracunKrizniSelect2;
        private IDataReader OBRACUNObustaveSelect2;
        private IDataReader ObracunOlaksiceSelect2;
        private IDataReader ObracunPoreziSelect2;
        private IDataReader ObracunRadniciSelect2;
        private IDataReader OBRACUNSelect1;
        private IDataReader OBRACUNSelect4;
        private OBRACUNDataSet OBRACUNSet;
        private short RcdFound10;
        private short RcdFound11;
        private short RcdFound12;
        private short RcdFound13;
        private short RcdFound137;
        private short RcdFound292;
        private short RcdFound61;
        private short RcdFound62;
        private short RcdFound74;
        private short RcdFound9;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private OBRACUNDataSet.OBRACUNRow rowOBRACUN;
        private OBRACUNDataSet.ObracunDoprinosiRow rowObracunDoprinosi;
        private OBRACUNDataSet.ObracunElementiRow rowObracunElementi;
        private OBRACUNDataSet.OBRACUNKreditiRow rowOBRACUNKrediti;
        private OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow rowOBRACUNOBRACUNLevel1ObracunIzuzece;
        private OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow rowOBRACUNOBRACUNLevel1ObracunKrizni;
        private OBRACUNDataSet.OBRACUNObustaveRow rowOBRACUNObustave;
        private OBRACUNDataSet.ObracunOlaksiceRow rowObracunOlaksice;
        private OBRACUNDataSet.ObracunPoreziRow rowObracunPorezi;
        private OBRACUNDataSet.ObracunRadniciRow rowObracunRadnici;
        private string scmdbuf;
        private StatementType sMode10;
        private StatementType sMode11;
        private StatementType sMode12;
        private StatementType sMode13;
        private StatementType sMode137;
        private StatementType sMode292;
        private StatementType sMode61;
        private StatementType sMode62;
        private StatementType sMode74;
        private StatementType sMode9;

        public event ObracunDoprinosiUpdateEventHandler ObracunDoprinosiUpdated;

        public event ObracunDoprinosiUpdateEventHandler ObracunDoprinosiUpdating;

        public event ObracunElementiUpdateEventHandler ObracunElementiUpdated;

        public event ObracunElementiUpdateEventHandler ObracunElementiUpdating;

        public event OBRACUNKreditiUpdateEventHandler OBRACUNKreditiUpdated;

        public event OBRACUNKreditiUpdateEventHandler OBRACUNKreditiUpdating;

        public event OBRACUNOBRACUNLevel1ObracunIzuzeceUpdateEventHandler OBRACUNOBRACUNLevel1ObracunIzuzeceUpdated;

        public event OBRACUNOBRACUNLevel1ObracunIzuzeceUpdateEventHandler OBRACUNOBRACUNLevel1ObracunIzuzeceUpdating;

        public event OBRACUNOBRACUNLevel1ObracunKrizniUpdateEventHandler OBRACUNOBRACUNLevel1ObracunKrizniUpdated;

        public event OBRACUNOBRACUNLevel1ObracunKrizniUpdateEventHandler OBRACUNOBRACUNLevel1ObracunKrizniUpdating;

        public event OBRACUNObustaveUpdateEventHandler OBRACUNObustaveUpdated;

        public event OBRACUNObustaveUpdateEventHandler OBRACUNObustaveUpdating;

        public event ObracunOlaksiceUpdateEventHandler ObracunOlaksiceUpdated;

        public event ObracunOlaksiceUpdateEventHandler ObracunOlaksiceUpdating;

        public event ObracunPoreziUpdateEventHandler ObracunPoreziUpdated;

        public event ObracunPoreziUpdateEventHandler ObracunPoreziUpdating;

        public event ObracunRadniciUpdateEventHandler ObracunRadniciUpdated;

        public event ObracunRadniciUpdateEventHandler ObracunRadniciUpdating;

        public event OBRACUNUpdateEventHandler OBRACUNUpdated;

        public event OBRACUNUpdateEventHandler OBRACUNUpdating;

        private void AddRowObracun()
        {
            this.OBRACUNSet.OBRACUN.AddOBRACUNRow(this.rowOBRACUN);
        }

        private void AddRowObracundoprinosi()
        {
            this.OBRACUNSet.ObracunDoprinosi.AddObracunDoprinosiRow(this.rowObracunDoprinosi);
        }

        private void AddRowObracunelementi()
        {
            this.OBRACUNSet.ObracunElementi.AddObracunElementiRow(this.rowObracunElementi);
        }

        private void AddRowObracunkrediti()
        {
            this.OBRACUNSet.OBRACUNKrediti.AddOBRACUNKreditiRow(this.rowOBRACUNKrediti);
        }

        private void AddRowObracunobracunlevel1obracunizuzece()
        {
            this.OBRACUNSet.OBRACUNOBRACUNLevel1ObracunIzuzece.AddOBRACUNOBRACUNLevel1ObracunIzuzeceRow(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece);
        }

        private void AddRowObracunobracunlevel1obracunkrizni()
        {
            this.OBRACUNSet.OBRACUNOBRACUNLevel1ObracunKrizni.AddOBRACUNOBRACUNLevel1ObracunKrizniRow(this.rowOBRACUNOBRACUNLevel1ObracunKrizni);
        }

        private void AddRowObracunobustave()
        {
            this.OBRACUNSet.OBRACUNObustave.AddOBRACUNObustaveRow(this.rowOBRACUNObustave);
        }

        private void AddRowObracunolaksice()
        {
            this.OBRACUNSet.ObracunOlaksice.AddObracunOlaksiceRow(this.rowObracunOlaksice);
        }

        private void AddRowObracunporezi()
        {
            this.OBRACUNSet.ObracunPorezi.AddObracunPoreziRow(this.rowObracunPorezi);
        }

        private void AddRowObracunradnici()
        {
            this.OBRACUNSet.ObracunRadnici.AddObracunRadniciRow(this.rowObracunRadnici);
        }

        private void AfterConfirmObracun()
        {
            this.OnOBRACUNUpdating(new OBRACUNEventArgs(this.rowOBRACUN, this.Gx_mode));
        }

        private void AfterConfirmObracundoprinosi()
        {
            this.OnObracunDoprinosiUpdating(new ObracunDoprinosiEventArgs(this.rowObracunDoprinosi, this.Gx_mode));
        }

        private void AfterConfirmObracunelementi()
        {
            this.OnObracunElementiUpdating(new ObracunElementiEventArgs(this.rowObracunElementi, this.Gx_mode));
        }

        private void AfterConfirmObracunkrediti()
        {
            this.OnOBRACUNKreditiUpdating(new OBRACUNKreditiEventArgs(this.rowOBRACUNKrediti, this.Gx_mode));
        }

        private void AfterConfirmObracunobracunlevel1obracunizuzece()
        {
            this.OnOBRACUNOBRACUNLevel1ObracunIzuzeceUpdating(new OBRACUNOBRACUNLevel1ObracunIzuzeceEventArgs(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece, this.Gx_mode));
        }

        private void AfterConfirmObracunobracunlevel1obracunkrizni()
        {
            this.OnOBRACUNOBRACUNLevel1ObracunKrizniUpdating(new OBRACUNOBRACUNLevel1ObracunKrizniEventArgs(this.rowOBRACUNOBRACUNLevel1ObracunKrizni, this.Gx_mode));
        }

        private void AfterConfirmObracunobustave()
        {
            this.OnOBRACUNObustaveUpdating(new OBRACUNObustaveEventArgs(this.rowOBRACUNObustave, this.Gx_mode));
        }

        private void AfterConfirmObracunolaksice()
        {
            this.OnObracunOlaksiceUpdating(new ObracunOlaksiceEventArgs(this.rowObracunOlaksice, this.Gx_mode));
        }

        private void AfterConfirmObracunporezi()
        {
            this.OnObracunPoreziUpdating(new ObracunPoreziEventArgs(this.rowObracunPorezi, this.Gx_mode));
        }

        private void AfterConfirmObracunradnici()
        {
            this.OnObracunRadniciUpdating(new ObracunRadniciEventArgs(this.rowObracunRadnici, this.Gx_mode));
        }

        private void CheckDeleteErrorsObracun()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDENTIFIKATOROBRASCA] FROM [RSMA] WITH (NOLOCK) WHERE [IDOBRACUN] = @IDOBRACUN ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["IDOBRACUN"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RSMAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RSMA" }));
            }
            reader.Close();
        }

        private void CheckExtendedTableObracun()
        {
            if ((string.Compare(this.rowOBRACUN.VRSTAOBRACUNA.TrimEnd(new char[] { ' ' }), "PL".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) != 0) && (string.Compare(this.rowOBRACUN.VRSTAOBRACUNA.TrimEnd(new char[] { ' ' }), "DD".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) != 0))
            {
                throw new VRSTAOBRACUNAOutOfRangeException("Field VRSTAOBRACUNA is out of range");
            }
        }

        private void CheckExtendedTableObracundoprinosi()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [VBDIDOPRINOS], [ZRNDOPRINOS], [NAZIVDOPRINOS], [IDVRSTADOPRINOS], [STOPA], [MODOPRINOS], [PODOPRINOS], [MZDOPRINOS], [PZDOPRINOS], [PRIMATELJDOPRINOS1], [PRIMATELJDOPRINOS2], [SIFRAOPISAPLACANJADOPRINOS], [OPISPLACANJADOPRINOS], [MINDOPRINOS], [MAXDOPRINOS] FROM [DOPRINOS] WITH (NOLOCK) WHERE [IDDOPRINOS] = @IDDOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDDOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new DOPRINOSForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DOPRINOS") }));
            }
            this.rowObracunDoprinosi["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowObracunDoprinosi["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
            this.rowObracunDoprinosi["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
            this.rowObracunDoprinosi["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3));
            this.rowObracunDoprinosi["STOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4));
            this.rowObracunDoprinosi["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
            this.rowObracunDoprinosi["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
            this.rowObracunDoprinosi["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
            this.rowObracunDoprinosi["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
            this.rowObracunDoprinosi["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
            this.rowObracunDoprinosi["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
            this.rowObracunDoprinosi["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
            this.rowObracunDoprinosi["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12));
            this.rowObracunDoprinosi["MINDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 13));
            this.rowObracunDoprinosi["MAXDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 14));
            reader.Close();
            if (!this.rowObracunDoprinosi.IsIDVRSTADOPRINOSNull())
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVVRSTADOPRINOS] FROM [VRSTADOPRINOS] WITH (NOLOCK) WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
                }
                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDVRSTADOPRINOS"]));
                IDataReader reader2 = command2.FetchData();
                if (!command2.HasMoreRows)
                {
                    reader2.Close();
                    throw new VRSTADOPRINOSForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("VRSTADOPRINOS") }));
                }
                this.rowObracunDoprinosi["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                reader2.Close();
            }
            else
            {
                this.rowObracunDoprinosi["NAZIVVRSTADOPRINOS"] = "";
            }
        }

        private void CheckExtendedTableObracunelementi()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVELEMENT], [IDVRSTAELEMENTA], [ZBRAJASATEUFONDSATI], [IDOSNOVAOSIGURANJA] FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new ELEMENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ELEMENT") }));
            }
            this.rowObracunElementi["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowObracunElementi["IDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 1));
            this.rowObracunElementi["ZBRAJASATEUFONDSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 2));
            this.rowObracunElementi["IDOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetStringNE(reader, 3));
            reader.Close();
            if (!this.rowObracunElementi.IsIDVRSTAELEMENTANull())
            {
                ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVVRSTAELEMENT] FROM [VRSTAELEMENT] WITH (NOLOCK) WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA ", false);
                if (command3.IDbCommand.Parameters.Count == 0)
                {
                    command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
                }
                command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDVRSTAELEMENTA"]));
                IDataReader reader3 = command3.FetchData();
                if (!command3.HasMoreRows)
                {
                    reader3.Close();
                    throw new VRSTAELEMENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("VRSTAELEMENT") }));
                }
                this.rowObracunElementi["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0));
                reader3.Close();
            }
            else
            {
                this.rowObracunElementi["NAZIVVRSTAELEMENT"] = "";
            }
            if (!this.rowObracunElementi.IsIDOSNOVAOSIGURANJANull() && (this.rowObracunElementi.IDOSNOVAOSIGURANJA.Length != 0))
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVOSNOVAOSIGURANJA], [RAZDOBLJESESMIJEPREKLAPATI] FROM [OSNOVAOSIGURANJA] WITH (NOLOCK) WHERE [IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
                }
                command2.SetParameterString(0, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDOSNOVAOSIGURANJA"]));
                IDataReader reader2 = command2.FetchData();
                if (!command2.HasMoreRows && (string.Compare("".TrimEnd(new char[] { ' ' }), StringUtil.RTrim(this.rowObracunElementi.IDOSNOVAOSIGURANJA).TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) != 0))
                {
                    reader2.Close();
                    throw new OSNOVAOSIGURANJAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OSNOVAOSIGURANJA") }));
                }
                this.rowObracunElementi["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                this.rowObracunElementi["RAZDOBLJESESMIJEPREKLAPATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader2, 1));
                reader2.Close();
            }
            else
            {
                this.rowObracunElementi["NAZIVOSNOVAOSIGURANJA"] = "";
                this.rowObracunElementi["RAZDOBLJESESMIJEPREKLAPATI"] = false;
            }
        }

        private void CheckExtendedTableObracunkrediti()
        {
            this.StandaloneModalObracunkrediti();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVKREDITOR], [VBDIKREDITOR], [ZRNKREDITOR], [PRIMATELJKREDITOR1], [PRIMATELJKREDITOR2], [PRIMATELJKREDITOR3] FROM [KREDITOR] WITH (NOLOCK) WHERE [IDKREDITOR] = @IDKREDITOR ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKREDITOR", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["IDKREDITOR"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new KREDITORForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KREDITOR") }));
            }
            this.rowOBRACUNKrediti["NAZIVKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowOBRACUNKrediti["VBDIKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
            this.rowOBRACUNKrediti["ZRNKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
            this.rowOBRACUNKrediti["PRIMATELJKREDITOR1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
            this.rowOBRACUNKrediti["PRIMATELJKREDITOR2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
            this.rowOBRACUNKrediti["PRIMATELJKREDITOR3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
            reader.Close();
        }

        private void CheckExtendedTableObracunobracunlevel1obracunkrizni()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVKRIZNIPOREZ], [KRIZNISTOPA], [MOKRIZNI], [POKRIZNI], [MZKRIZNI], [PZKRIZNI], [PRIMATELJKRIZNI1], [PRIMATELJKRIZNI2], [PRIMATELJKRIZNI3], [SIFRAOPISAPLACANJAKRIZNI], [OPISPLACANJAKRIZNI], [VBDIKRIZNI], [ZRNKRIZNI] FROM [KRIZNIPOREZ] WITH (NOLOCK) WHERE [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDKRIZNIPOREZ"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new KRIZNIPOREZForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KRIZNIPOREZ") }));
            }
            this.rowOBRACUNOBRACUNLevel1ObracunKrizni["NAZIVKRIZNIPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowOBRACUNOBRACUNLevel1ObracunKrizni["KRIZNISTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            this.rowOBRACUNOBRACUNLevel1ObracunKrizni["MOKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
            this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
            this.rowOBRACUNOBRACUNLevel1ObracunKrizni["MZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
            this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
            this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PRIMATELJKRIZNI1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
            this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PRIMATELJKRIZNI2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
            this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PRIMATELJKRIZNI3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
            this.rowOBRACUNOBRACUNLevel1ObracunKrizni["SIFRAOPISAPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
            this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OPISPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
            this.rowOBRACUNOBRACUNLevel1ObracunKrizni["VBDIKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
            this.rowOBRACUNOBRACUNLevel1ObracunKrizni["ZRNKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12));
            reader.Close();
        }

        private void CheckExtendedTableObracunobustave()
        {
            this.StandaloneModalObracunobustave();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVOBUSTAVA], [MOOBUSTAVA], [POOBUSTAVA], [MZOBUSTAVA], [PZOBUSTAVA], [VBDIOBUSTAVA], [ZRNOBUSTAVA], [PRIMATELJOBUSTAVA1], [PRIMATELJOBUSTAVA2], [PRIMATELJOBUSTAVA3], [SIFRAOPISAPLACANJAOBUSTAVA], [OPISPLACANJAOBUSTAVA], [VRSTAOBUSTAVE] FROM [OBUSTAVA] WITH (NOLOCK) WHERE [IDOBUSTAVA] = @IDOBUSTAVA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBUSTAVA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IDOBUSTAVA"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new OBUSTAVAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OBUSTAVA") }));
            }
            this.rowOBRACUNObustave["NAZIVOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowOBRACUNObustave["MOOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
            this.rowOBRACUNObustave["POOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
            this.rowOBRACUNObustave["MZOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
            this.rowOBRACUNObustave["PZOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
            this.rowOBRACUNObustave["VBDIOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
            this.rowOBRACUNObustave["ZRNOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
            this.rowOBRACUNObustave["PRIMATELJOBUSTAVA1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
            this.rowOBRACUNObustave["PRIMATELJOBUSTAVA2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
            this.rowOBRACUNObustave["PRIMATELJOBUSTAVA3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
            this.rowOBRACUNObustave["SIFRAOPISAPLACANJAOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
            this.rowOBRACUNObustave["OPISPLACANJAOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
            this.rowOBRACUNObustave["VRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 12));
            reader.Close();
            if (!this.rowOBRACUNObustave.IsVRSTAOBUSTAVENull())
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVVRSTAOBUSTAVE] FROM [VRSTEOBUSTAVA] WITH (NOLOCK) WHERE [VRSTAOBUSTAVE] = @VRSTAOBUSTAVE ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
                }
                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["VRSTAOBUSTAVE"]));
                IDataReader reader2 = command2.FetchData();
                if (!command2.HasMoreRows)
                {
                    reader2.Close();
                    throw new VRSTEOBUSTAVAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("VRSTEOBUSTAVA") }));
                }
                this.rowOBRACUNObustave["NAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                reader2.Close();
            }
            else
            {
                this.rowOBRACUNObustave["NAZIVVRSTAOBUSTAVE"] = "";
            }
        }

        private void CheckExtendedTableObracunolaksice()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVOLAKSICE], [IDGRUPEOLAKSICA], [IDTIPOLAKSICE], [VBDIOLAKSICA], [ZRNOLAKSICA], [PRIMATELJOLAKSICA1], [PRIMATELJOLAKSICA2], [PRIMATELJOLAKSICA3] FROM [OLAKSICE] WITH (NOLOCK) WHERE [IDOLAKSICE] = @IDOLAKSICE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOLAKSICE", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDOLAKSICE"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new OLAKSICEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OLAKSICE") }));
            }
            this.rowObracunOlaksice["NAZIVOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            this.rowObracunOlaksice["IDGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader2, 1));
            this.rowObracunOlaksice["IDTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader2, 2));
            this.rowObracunOlaksice["VBDIOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 3));
            this.rowObracunOlaksice["ZRNOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 4));
            this.rowObracunOlaksice["PRIMATELJOLAKSICA1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 5));
            this.rowObracunOlaksice["PRIMATELJOLAKSICA2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 6));
            this.rowObracunOlaksice["PRIMATELJOLAKSICA3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 7));
            reader2.Close();
            if (!this.rowObracunOlaksice.IsIDGRUPEOLAKSICANull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVGRUPEOLAKSICA], [MAXIMALNIIZNOSGRUPE] FROM [GRUPEOLAKSICA] WITH (NOLOCK) WHERE [IDGRUPEOLAKSICA] = @IDGRUPEOLAKSICA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDGRUPEOLAKSICA"]));
                IDataReader reader = command.FetchData();
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new GRUPEOLAKSICAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("GRUPEOLAKSICA") }));
                }
                this.rowObracunOlaksice["NAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowObracunOlaksice["MAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
                reader.Close();
            }
            else
            {
                this.rowObracunOlaksice["NAZIVGRUPEOLAKSICA"] = "";
                this.rowObracunOlaksice["MAXIMALNIIZNOSGRUPE"] = 0;
            }
            if (!this.rowObracunOlaksice.IsIDTIPOLAKSICENull())
            {
                ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVTIPOLAKSICE] FROM [TIPOLAKSICE] WITH (NOLOCK) WHERE [IDTIPOLAKSICE] = @IDTIPOLAKSICE ", false);
                if (command3.IDbCommand.Parameters.Count == 0)
                {
                    command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
                }
                command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDTIPOLAKSICE"]));
                IDataReader reader3 = command3.FetchData();
                if (!command3.HasMoreRows)
                {
                    reader3.Close();
                    throw new TIPOLAKSICEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("TIPOLAKSICE") }));
                }
                this.rowObracunOlaksice["NAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0));
                reader3.Close();
            }
            else
            {
                this.rowObracunOlaksice["NAZIVTIPOLAKSICE"] = "";
            }
        }

        private void CheckExtendedTableObracunporezi()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], [MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ] FROM [POREZ] WITH (NOLOCK) WHERE [IDPOREZ] = @IDPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["IDPOREZ"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new POREZForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("POREZ") }));
            }
            this.rowObracunPorezi["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowObracunPorezi["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            this.rowObracunPorezi["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
            this.rowObracunPorezi["MOPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
            this.rowObracunPorezi["POPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
            this.rowObracunPorezi["MZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
            this.rowObracunPorezi["PZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
            this.rowObracunPorezi["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
            this.rowObracunPorezi["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
            this.rowObracunPorezi["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
            this.rowObracunPorezi["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
            reader.Close();
        }

        private void CheckExtendedTableObracunradnici()
        {
            ReadWriteCommand command6 = this.connDefault.GetCommand("SELECT [PREZIME], [IME], [ulica], [mjesto], [kucnibroj], [JMBG], [DATUMRODJENJA], [TEKUCI], [SIFRAOPISAPLACANJANETO], [OPISPLACANJANETO], [BROJMIROVINSKOG], [BROJZDRAVSTVENOG], [MBO], [POSTOTAKOSLOBODJENJAODPOREZA], [KOEFICIJENT], [AKTIVAN], [DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], [TJEDNIFONDSATI], [TJEDNIFONDSATISTAZ], [GODINESTAZA], [MJESECISTAZA], [DANISTAZA], [DATUMPRESTANKARADNOGODNOSA], [ZBIRNINETO], [UZIMAUOBZIROSNOVICEDOPRINOSA], [IDIPIDENT], [OIB], [IDBANKE], [IDBENEFICIRANI], [IDTITULA], [IDRADNOMJESTO], [IDSTRUKA], [IDORGDIO], [OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, [OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, [POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, [TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (command6.IDbCommand.Parameters.Count == 0)
            {
                command6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDRADNIK"]));
            IDataReader reader6 = command6.FetchData();
            if (!command6.HasMoreRows)
            {
                reader6.Close();
                throw new RADNIKForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RADNIK") }));
            }
            this.rowObracunRadnici["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 0));
            this.rowObracunRadnici["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 1));
            this.rowObracunRadnici["ulica"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 2));
            this.rowObracunRadnici["mjesto"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 3));
            this.rowObracunRadnici["kucnibroj"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 4));
            this.rowObracunRadnici["JMBG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 5));
            this.rowObracunRadnici["DATUMRODJENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader6, 6));
            this.rowObracunRadnici["TEKUCI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 7));
            this.rowObracunRadnici["SIFRAOPISAPLACANJANETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 8));
            this.rowObracunRadnici["OPISPLACANJANETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 9));
            this.rowObracunRadnici["BROJMIROVINSKOG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 10));
            this.rowObracunRadnici["BROJZDRAVSTVENOG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 11));
            this.rowObracunRadnici["MBO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 12));
            this.rowObracunRadnici["POSTOTAKOSLOBODJENJAODPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader6, 13));
            this.rowObracunRadnici["KOEFICIJENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader6, 14));
            this.rowObracunRadnici["AKTIVAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader6, 15));
            this.rowObracunRadnici["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader6, 0x10));
            this.rowObracunRadnici["TJEDNIFONDSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader6, 0x11));
            this.rowObracunRadnici["TJEDNIFONDSATISTAZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader6, 0x12));
            this.rowObracunRadnici["GODINESTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader6, 0x13));
            this.rowObracunRadnici["MJESECISTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader6, 20));
            this.rowObracunRadnici["DANISTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader6, 0x15));
            this.rowObracunRadnici["DATUMPRESTANKARADNOGODNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader6, 0x16));
            this.rowObracunRadnici["ZBIRNINETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader6, 0x17));
            this.rowObracunRadnici["UZIMAUOBZIROSNOVICEDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader6, 0x18));
            this.rowObracunRadnici["IDIPIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader6, 0x19));
            this.rowObracunRadnici["OIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 0x1a));
            this.rowObracunRadnici["IDBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader6, 0x1b));
            this.rowObracunRadnici["IDBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 0x1c));
            this.rowObracunRadnici["IDTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader6, 0x1d));
            this.rowObracunRadnici["IDRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader6, 30));
            this.rowObracunRadnici["IDSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader6, 0x1f));
            this.rowObracunRadnici["IDORGDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader6, 0x20));
            this.rowObracunRadnici["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 0x21));
            this.rowObracunRadnici["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 0x22));
            this.rowObracunRadnici["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader6, 0x23));
            this.rowObracunRadnici["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader6, 0x24));
            this.rowObracunRadnici["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader6, 0x25));
            reader6.Close();
            if (!this.rowObracunRadnici.IsIDBANKENull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVBANKE1], [NAZIVBANKE2], [NAZIVBANKE3], [VBDIBANKE], [ZRNBANKE] FROM [BANKE] WITH (NOLOCK) WHERE [IDBANKE] = @IDBANKE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDBANKE"]));
                IDataReader reader = command.FetchData();
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new BANKEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("BANKE") }));
                }
                this.rowObracunRadnici["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowObracunRadnici["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowObracunRadnici["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowObracunRadnici["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowObracunRadnici["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                reader.Close();
            }
            else
            {
                this.rowObracunRadnici["NAZIVBANKE1"] = "";
                this.rowObracunRadnici["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowObracunRadnici["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowObracunRadnici["VBDIBANKE"] = "";
                this.rowObracunRadnici["ZRNBANKE"] = "";
            }
            if (!this.rowObracunRadnici.IsIDBENEFICIRANINull())
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVBENEFICIRANI], [BROJPRIZNATIHMJESECI] FROM [BENEFICIRANI] WITH (NOLOCK) WHERE [IDBENEFICIRANI] = @IDBENEFICIRANI ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
                }
                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDBENEFICIRANI"]));
                IDataReader reader2 = command2.FetchData();
                if (!command2.HasMoreRows)
                {
                    reader2.Close();
                    throw new BENEFICIRANIForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("BENEFICIRANI") }));
                }
                this.rowObracunRadnici["NAZIVBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                this.rowObracunRadnici["BROJPRIZNATIHMJESECI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader2, 1));
                reader2.Close();
            }
            else
            {
                this.rowObracunRadnici["NAZIVBENEFICIRANI"] = "";
                this.rowObracunRadnici["BROJPRIZNATIHMJESECI"] = 0;
            }
            if (!this.rowObracunRadnici.IsIDTITULANull())
            {
                ReadWriteCommand command12 = this.connDefault.GetCommand("SELECT [NAZIVTITULA] FROM [TITULA] WITH (NOLOCK) WHERE [IDTITULA] = @IDTITULA ", false);
                if (command12.IDbCommand.Parameters.Count == 0)
                {
                    command12.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
                }
                command12.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDTITULA"]));
                IDataReader reader12 = command12.FetchData();
                if (!command12.HasMoreRows && (0 != this.rowObracunRadnici.IDTITULA))
                {
                    reader12.Close();
                    throw new TITULAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("TITULA") }));
                }
                this.rowObracunRadnici["NAZIVTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader12, 0));
                reader12.Close();
            }
            else
            {
                this.rowObracunRadnici["NAZIVTITULA"] = "";
            }
            if (!this.rowObracunRadnici.IsIDRADNOMJESTONull())
            {
                ReadWriteCommand command7 = this.connDefault.GetCommand("SELECT [NAZIVRADNOMJESTO] FROM [RADNOMJESTO] WITH (NOLOCK) WHERE [IDRADNOMJESTO] = @IDRADNOMJESTO ", false);
                if (command7.IDbCommand.Parameters.Count == 0)
                {
                    command7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
                }
                command7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDRADNOMJESTO"]));
                IDataReader reader7 = command7.FetchData();
                if (!command7.HasMoreRows && (0 != this.rowObracunRadnici.IDRADNOMJESTO))
                {
                    reader7.Close();
                    throw new RADNOMJESTOForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RADNOMJESTO") }));
                }
                this.rowObracunRadnici["NAZIVRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader7, 0));
                reader7.Close();
            }
            else
            {
                this.rowObracunRadnici["NAZIVRADNOMJESTO"] = "";
            }
            if (!this.rowObracunRadnici.IsIDSTRUKANull())
            {
                ReadWriteCommand command11 = this.connDefault.GetCommand("SELECT [NAZIVSTRUKA] FROM [STRUKA] WITH (NOLOCK) WHERE [IDSTRUKA] = @IDSTRUKA ", false);
                if (command11.IDbCommand.Parameters.Count == 0)
                {
                    command11.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
                }
                command11.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDSTRUKA"]));
                IDataReader reader11 = command11.FetchData();
                if (!command11.HasMoreRows && (0 != this.rowObracunRadnici.IDSTRUKA))
                {
                    reader11.Close();
                    throw new STRUKAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("STRUKA") }));
                }
                this.rowObracunRadnici["NAZIVSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader11, 0));
                reader11.Close();
            }
            else
            {
                this.rowObracunRadnici["NAZIVSTRUKA"] = "";
            }
            if (!this.rowObracunRadnici.IsIDORGDIONull())
            {
                ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT [ORGANIZACIJSKIDIO] FROM [ORGDIO] WITH (NOLOCK) WHERE [IDORGDIO] = @IDORGDIO ", false);
                if (command5.IDbCommand.Parameters.Count == 0)
                {
                    command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
                }
                command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDORGDIO"]));
                IDataReader reader5 = command5.FetchData();
                if (!command5.HasMoreRows && (0 != this.rowObracunRadnici.IDORGDIO))
                {
                    reader5.Close();
                    throw new ORGDIOForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ORGDIO") }));
                }
                this.rowObracunRadnici["ORGANIZACIJSKIDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader5, 0));
                reader5.Close();
            }
            else
            {
                this.rowObracunRadnici["ORGANIZACIJSKIDIO"] = "";
            }
            if (!this.rowObracunRadnici.IsOPCINARADAIDOPCINENull())
            {
                ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, [PRIREZ] AS OPCINARADAPRIREZ FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINARADAIDOPCINE ", false);
                if (command3.IDbCommand.Parameters.Count == 0)
                {
                    command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
                }
                command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["OPCINARADAIDOPCINE"]));
                IDataReader reader3 = command3.FetchData();
                if (!command3.HasMoreRows)
                {
                    reader3.Close();
                    throw new OPCINAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OPCINA") }));
                }
                this.rowObracunRadnici["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0));
                this.rowObracunRadnici["OPCINARADAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader3, 1));
                reader3.Close();
            }
            else
            {
                this.rowObracunRadnici["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowObracunRadnici["OPCINARADAPRIREZ"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowObracunRadnici.IsOPCINASTANOVANJAIDOPCINENull())
            {
                ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, [PRIREZ] AS OPCINASTANOVANJAPRIREZ FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINASTANOVANJAIDOPCINE ", false);
                if (command4.IDbCommand.Parameters.Count == 0)
                {
                    command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
                }
                command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["OPCINASTANOVANJAIDOPCINE"]));
                IDataReader reader4 = command4.FetchData();
                if (!command4.HasMoreRows)
                {
                    reader4.Close();
                    throw new OPCINAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OPCINA") }));
                }
                this.rowObracunRadnici["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader4, 0));
                this.rowObracunRadnici["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader4, 1));
                reader4.Close();
            }
            else
            {
                this.rowObracunRadnici["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowObracunRadnici["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowObracunRadnici.IsRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSANull())
            {
                ReadWriteCommand command8 = this.connDefault.GetCommand("SELECT [NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA FROM [SKUPPOREZAIDOPRINOSA] WITH (NOLOCK) WHERE [IDSKUPPOREZAIDOPRINOSA] = @RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA ", false);
                if (command8.IDbCommand.Parameters.Count == 0)
                {
                    command8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", DbType.Int32));
                }
                command8.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]));
                IDataReader reader8 = command8.FetchData();
                if (!command8.HasMoreRows)
                {
                    reader8.Close();
                    throw new SKUPPOREZAIDOPRINOSAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("SKUPPOREZAIDOPRINOSA") }));
                }
                this.rowObracunRadnici["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader8, 0));
                reader8.Close();
            }
            else
            {
                this.rowObracunRadnici["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowObracunRadnici.IsPOTREBNASTRUCNASPREMAIDSTRUCNASPREMANull())
            {
                ReadWriteCommand command9 = this.connDefault.GetCommand("SELECT [NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA FROM [STRUCNASPREMA] WITH (NOLOCK) WHERE [IDSTRUCNASPREMA] = @POTREBNASTRUCNASPREMAIDSTRUCNASPREMA ", false);
                if (command9.IDbCommand.Parameters.Count == 0)
                {
                    command9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POTREBNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
                }
                command9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"]));
                IDataReader reader9 = command9.FetchData();
                if (!command9.HasMoreRows && (0 != this.rowObracunRadnici.POTREBNASTRUCNASPREMAIDSTRUCNASPREMA))
                {
                    reader9.Close();
                    throw new STRUCNASPREMAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("STRUCNASPREMA") }));
                }
                this.rowObracunRadnici["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader9, 0));
                reader9.Close();
            }
            else
            {
                this.rowObracunRadnici["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowObracunRadnici.IsTRENUTNASTRUCNASPREMAIDSTRUCNASPREMANull())
            {
                ReadWriteCommand command10 = this.connDefault.GetCommand("SELECT [NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA FROM [STRUCNASPREMA] WITH (NOLOCK) WHERE [IDSTRUCNASPREMA] = @TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA ", false);
                if (command10.IDbCommand.Parameters.Count == 0)
                {
                    command10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
                }
                command10.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"]));
                IDataReader reader10 = command10.FetchData();
                if (!command10.HasMoreRows && (0 != this.rowObracunRadnici.TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA))
                {
                    reader10.Close();
                    throw new STRUCNASPREMAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("STRUCNASPREMA") }));
                }
                this.rowObracunRadnici["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader10, 0));
                reader10.Close();
            }
            else
            {
                this.rowObracunRadnici["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if ((!this.rowOBRACUN.IsDATUMOBRACUNASTAZANull() && !this.rowOBRACUN.IstjednifondsatiobracunNull()) && !this.rowObracunRadnici.IsBROJPRIZNATIHMJESECINull())
            {
                this.rowObracunRadnici.POSTOTAKNASTAZ = placa.PovecanjeKoeficijentaZaStaz(this.rowObracunRadnici.IDRADNIK, this.rowOBRACUN.DATUMOBRACUNASTAZA, new decimal(this.rowOBRACUN.tjednifondsatiobracun), this.rowObracunRadnici.BROJPRIZNATIHMJESECI, Configuration.ConnectionString.ToString());
            }
        }

        private void CheckOptimisticConcurrencyObracun()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOBRACUN], [VRSTAOBRACUNA], [MJESECOBRACUNA], [GODINAOBRACUNA], [MJESECISPLATE], [GODINAISPLATE], [DATUMISPLATE], [tjednifondsatiobracun], [MJESECNIFONDSATIOBRACUN], [OSNOVNIOO], [OBRACUNSKAOSNOVICA], [DATUMOBRACUNASTAZA], [OBRPOSTOTNIH], [OBRFIKSNIH], [OBRKREDITNIH], [ZAKLJ], [SVRHAOBRACUNA] FROM [OBRACUN] WITH (UPDLOCK) WHERE [IDOBRACUN] = @IDOBRACUN ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["IDOBRACUN"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new OBRACUNDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("OBRACUN") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__VRSTAOBRACUNAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MJESECOBRACUNAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__GODINAOBRACUNAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MJESECISPLATEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__GODINAISPLATEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__DATUMISPLATEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 6)))) || ((!this.m__tjednifondsatiobracunOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 7))) || !this.m__MJESECNIFONDSATIOBRACUNOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 8)))) || (!this.m__OSNOVNIOOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 9))) || !this.m__OBRACUNSKAOSNOVICAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 10))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__DATUMOBRACUNASTAZAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 11)))) || ((!this.m__OBRPOSTOTNIHOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 12))) || !this.m__OBRFIKSNIHOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 13)))) || (!this.m__OBRKREDITNIHOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 14))) || !this.m__ZAKLJOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 15))))))
                {
                    this._Condition = true;
                }
                if (this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__SVRHAOBRACUNAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x10))))
                {
                    reader.Close();
                    throw new OBRACUNDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("OBRACUN") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyObracundoprinosi()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOBRACUN], [IDRADNIK], [OBRACUNATIDOPRINOS], [OSNOVICADOPRINOS], [IDDOPRINOS] FROM [ObracunDoprinosi] WITH (UPDLOCK) WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDDOPRINOS] = @IDDOPRINOS ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDOBRACUN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDRADNIK"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDDOPRINOS"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new ObracunDoprinosiDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("ObracunDoprinosi") }));
                }
                if ((!command.HasMoreRows || !this.m__OBRACUNATIDOPRINOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2)))) || !this.m__OSNOVICADOPRINOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3))))
                {
                    reader.Close();
                    throw new ObracunDoprinosiDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("ObracunDoprinosi") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyObracunelementi()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOBRACUN], [IDRADNIK], [ELEMENTRAZDOBLJEOD], [ELEMENTRAZDOBLJEDO], [OBRSATI], [OBRSATNICA], [OBRIZNOS], [OBRPOSTOTAK], [IDELEMENT] FROM [ObracunElementi] WITH (UPDLOCK) WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDELEMENT] = @IDELEMENT AND [ELEMENTRAZDOBLJEOD] = @ELEMENTRAZDOBLJEOD AND [ELEMENTRAZDOBLJEDO] = @ELEMENTRAZDOBLJEDO ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ELEMENTRAZDOBLJEOD", DbType.Date));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ELEMENTRAZDOBLJEDO", DbType.Date));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDOBRACUN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDRADNIK"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDELEMENT"]));
                command.SetParameterDateObject(3, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["ELEMENTRAZDOBLJEOD"]));
                command.SetParameterDateObject(4, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["ELEMENTRAZDOBLJEDO"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new ObracunElementiDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("ObracunElementi") }));
                }
                if ((!command.HasMoreRows || !this.m__OBRSATIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4)))) || ((!this.m__OBRSATNICAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 5))) || !this.m__OBRIZNOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 6)))) || !this.m__OBRPOSTOTAKOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 7)))))
                {
                    reader.Close();
                    throw new ObracunElementiDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("ObracunElementi") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyObracunkrediti()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOBRACUN], [IDRADNIK], [DATUMUGOVORA], [OBRSIFRAOPISAPLACANJAKREDITOR], [OBROPISPLACANJAKREDITOR], [OBRMOKREDITOR], [OBRPOKREDITOR], [OBRMZKREDITOR], [OBRPZKREDITOR], [OBRIZNOSRATEKREDITOR], [OBRACUNATIKUNSKIIZNOS], [VECOTPLACENOBROJRATA], [VECOTPLACENOUKUPNIIZNOS], [UKUPNIZNOSKREDITA], [IDKREDITOR] FROM [OBRACUNKrediti] WITH (UPDLOCK) WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDKREDITOR] = @IDKREDITOR AND [DATUMUGOVORA] = @DATUMUGOVORA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKREDITOR", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMUGOVORA", DbType.Date));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["IDOBRACUN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["IDRADNIK"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["IDKREDITOR"]));
                command.SetParameterDateObject(3, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["DATUMUGOVORA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new OBRACUNKreditiDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("OBRACUNKrediti") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OBRSIFRAOPISAPLACANJAKREDITOROriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OBROPISPLACANJAKREDITOROriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OBRMOKREDITOROriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OBRPOKREDITOROriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OBRMZKREDITOROriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OBRPZKREDITOROriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8)))) || ((!this.m__OBRIZNOSRATEKREDITOROriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 9))) || !this.m__OBRACUNATIKUNSKIIZNOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 10)))) || (!this.m__VECOTPLACENOBROJRATAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 11))) || !this.m__VECOTPLACENOUKUPNIIZNOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 12))))))
                {
                    this._Condition = true;
                }
                if (this._Condition || !this.m__UKUPNIZNOSKREDITAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 13))))
                {
                    reader.Close();
                    throw new OBRACUNKreditiDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("OBRACUNKrediti") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyObracunobracunlevel1obracunizuzece()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOBRACUN], [IDRADNIK], [IDOBRACUNIZUZECE], [PRIMATELJIZUZECE1], [PRIMATELJIZUZECE2], [PRIMATELJIZUZECE3], [SIFRAOPISAPLACANJAIZUZECE], [OPISPLACANJAIZUZECE], [VBDIIZUZECE], [TEKUCIIZUZECE], [MOIZUZECE], [POIZUZECE], [MZIZUZECE], [PZIZUZECE], [IZNOSIZUZECA] FROM [OBRACUNOBRACUNLevel1ObracunIzuzece] WITH (UPDLOCK) WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDOBRACUNIZUZECE] = @IDOBRACUNIZUZECE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUNIZUZECE", DbType.Guid));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDOBRACUN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDRADNIK"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDOBRACUNIZUZECE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new OBRACUNOBRACUNLevel1ObracunIzuzeceDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("OBRACUNOBRACUNLevel1ObracunIzuzece") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJIZUZECE1Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJIZUZECE2Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJIZUZECE3Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__SIFRAOPISAPLACANJAIZUZECEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPISPLACANJAIZUZECEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__VBDIIZUZECEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__TEKUCIIZUZECEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MOIZUZECEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__POIZUZECEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MZIZUZECEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PZIZUZECEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 13)))) || !this.m__IZNOSIZUZECAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 14))))
                {
                    reader.Close();
                    throw new OBRACUNOBRACUNLevel1ObracunIzuzeceDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("OBRACUNOBRACUNLevel1ObracunIzuzece") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyObracunobracunlevel1obracunkrizni()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOBRACUN], [IDRADNIK], [OSNOVICAKRIZNI], [POREZKRIZNI], [OSNOVICAPRETHODNA], [OSNOVICAUKUPNA], [POREZPRETHODNI], [POREZUKUPNO], [IDKRIZNIPOREZ] FROM [OBRACUNOBRACUNLevel1ObracunKrizni] WITH (UPDLOCK) WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDOBRACUN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDRADNIK"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDKRIZNIPOREZ"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new OBRACUNOBRACUNLevel1ObracunKrizniDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("OBRACUNOBRACUNLevel1ObracunKrizni") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !this.m__OSNOVICAKRIZNIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2)))) || ((!this.m__POREZKRIZNIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3))) || !this.m__OSNOVICAPRETHODNAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4)))) || (!this.m__OSNOVICAUKUPNAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 5))) || !this.m__POREZPRETHODNIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 6))))))
                {
                    this._Condition = true;
                }
                if (this._Condition || !this.m__POREZUKUPNOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 7))))
                {
                    reader.Close();
                    throw new OBRACUNOBRACUNLevel1ObracunKrizniDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("OBRACUNOBRACUNLevel1ObracunKrizni") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyObracunobustave()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOBRACUN], [IDRADNIK], [IZNOSOBUSTAVE], [POSTOTAKOBUSTAVE], [OBRACUNATAOBUSTAVAUKUNAMA], [ISPLACENOKASA], [SALDOKASA], [IDOBUSTAVA] FROM [OBRACUNObustave] WITH (UPDLOCK) WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDOBUSTAVA] = @IDOBUSTAVA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBUSTAVA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IDOBRACUN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IDRADNIK"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IDOBUSTAVA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new OBRACUNObustaveDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("OBRACUNObustave") }));
                }
                if ((!command.HasMoreRows || !this.m__IZNOSOBUSTAVEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2)))) || ((!this.m__POSTOTAKOBUSTAVEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3))) || !this.m__OBRACUNATAOBUSTAVAUKUNAMAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4)))) || (!this.m__ISPLACENOKASAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 5))) || !this.m__SALDOKASAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 6))))))
                {
                    reader.Close();
                    throw new OBRACUNObustaveDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("OBRACUNObustave") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyObracunolaksice()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOBRACUN], [IDRADNIK], [MZOLAKSICA], [PZOLAKSICA], [MOOLAKSICA], [POOLAKSICA], [SIFRAOPISAPLACANJAOLAKSICA], [OPISPLACANJAOLAKSICA], [IZNOSOLAKSICE], [OBRACUNATAOLAKSICA], [IDOLAKSICE] FROM [ObracunOlaksice] WITH (UPDLOCK) WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDOLAKSICE] = @IDOLAKSICE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOLAKSICE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDOBRACUN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDRADNIK"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDOLAKSICE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new ObracunOlaksiceDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("ObracunOlaksice") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MZOLAKSICAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PZOLAKSICAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MOOLAKSICAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__POOLAKSICAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__SIFRAOPISAPLACANJAOLAKSICAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPISPLACANJAOLAKSICAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7)))) || (!this.m__IZNOSOLAKSICEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 8))) || !this.m__OBRACUNATAOLAKSICAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 9)))))
                {
                    reader.Close();
                    throw new ObracunOlaksiceDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("ObracunOlaksice") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyObracunporezi()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOBRACUN], [IDRADNIK], [OBRACUNATIPOREZ], [OSNOVICAPOREZ], [IDPOREZ] FROM [ObracunPorezi] WITH (UPDLOCK) WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDPOREZ] = @IDPOREZ ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["IDOBRACUN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["IDRADNIK"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["IDPOREZ"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new ObracunPoreziDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("ObracunPorezi") }));
                }
                if ((!command.HasMoreRows || !this.m__OBRACUNATIPOREZOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2)))) || !this.m__OSNOVICAPOREZOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3))))
                {
                    reader.Close();
                    throw new ObracunPoreziDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("ObracunPorezi") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyObracunradnici()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOBRACUN], [SIFRAOPCINESTANOVANJA], [OBRACUNSKIKOEFICIJENT], [ISKORISTENOOO], [OBRACUNATIPRIREZ], [faktoo], [RADNIKOBRACUNOSNOVICA], [KOREKCIJAPRIREZA], [ODBITAKPRIJEKOREKCIJE], [OBRACUNAVAJOBUSTAVE], [IDRADNIK] FROM [ObracunRadnici] WITH (UPDLOCK) WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDOBRACUN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDRADNIK"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new ObracunRadniciDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("ObracunRadnici") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__SIFRAOPCINESTANOVANJAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!this.m__OBRACUNSKIKOEFICIJENTOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))) || !this.m__ISKORISTENOOOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3)))) || (!this.m__OBRACUNATIPRIREZOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4))) || !this.m__faktooOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 5))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__RADNIKOBRACUNOSNOVICAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 6)))) || ((!this.m__KOREKCIJAPRIREZAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 7))) || !this.m__ODBITAKPRIJEKOREKCIJEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 8)))) || !this.m__OBRACUNAVAJOBUSTAVEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 9)))))
                {
                    reader.Close();
                    throw new ObracunRadniciDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("ObracunRadnici") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowObracun()
        {
            this.rowOBRACUN = this.OBRACUNSet.OBRACUN.NewOBRACUNRow();
        }

        private void CreateNewRowObracundoprinosi()
        {
            this.rowObracunDoprinosi = this.OBRACUNSet.ObracunDoprinosi.NewObracunDoprinosiRow();
        }

        private void CreateNewRowObracunelementi()
        {
            this.rowObracunElementi = this.OBRACUNSet.ObracunElementi.NewObracunElementiRow();
        }

        private void CreateNewRowObracunkrediti()
        {
            this.rowOBRACUNKrediti = this.OBRACUNSet.OBRACUNKrediti.NewOBRACUNKreditiRow();
        }

        private void CreateNewRowObracunobracunlevel1obracunizuzece()
        {
            this.rowOBRACUNOBRACUNLevel1ObracunIzuzece = this.OBRACUNSet.OBRACUNOBRACUNLevel1ObracunIzuzece.NewOBRACUNOBRACUNLevel1ObracunIzuzeceRow();
        }

        private void CreateNewRowObracunobracunlevel1obracunkrizni()
        {
            this.rowOBRACUNOBRACUNLevel1ObracunKrizni = this.OBRACUNSet.OBRACUNOBRACUNLevel1ObracunKrizni.NewOBRACUNOBRACUNLevel1ObracunKrizniRow();
        }

        private void CreateNewRowObracunobustave()
        {
            this.rowOBRACUNObustave = this.OBRACUNSet.OBRACUNObustave.NewOBRACUNObustaveRow();
        }

        private void CreateNewRowObracunolaksice()
        {
            this.rowObracunOlaksice = this.OBRACUNSet.ObracunOlaksice.NewObracunOlaksiceRow();
        }

        private void CreateNewRowObracunporezi()
        {
            this.rowObracunPorezi = this.OBRACUNSet.ObracunPorezi.NewObracunPoreziRow();
        }

        private void CreateNewRowObracunradnici()
        {
            this.rowObracunRadnici = this.OBRACUNSet.ObracunRadnici.NewObracunRadniciRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyObracun();
            this.ProcessNestedLevelObracunradnici();
            this.AfterConfirmObracun();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [OBRACUN]  WHERE [IDOBRACUN] = @IDOBRACUN", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["IDOBRACUN"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsObracun();
            }
            this.OnOBRACUNUpdated(new OBRACUNEventArgs(this.rowOBRACUN, StatementType.Delete));
            this.rowOBRACUN.Delete();
            this.sMode9 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode9;
        }

        private void DeleteObracundoprinosi()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyObracundoprinosi();
            this.OnDeleteControlsObracundoprinosi();
            this.AfterConfirmObracundoprinosi();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [ObracunDoprinosi]  WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDDOPRINOS] = @IDDOPRINOS", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDOBRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDRADNIK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDDOPRINOS"]));
            command.ExecuteStmt();
            this.OnObracunDoprinosiUpdated(new ObracunDoprinosiEventArgs(this.rowObracunDoprinosi, StatementType.Delete));
            this.rowObracunDoprinosi.Delete();
            this.sMode11 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode11;
        }

        private void DeleteObracunelementi()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyObracunelementi();
            this.OnDeleteControlsObracunelementi();
            this.AfterConfirmObracunelementi();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [ObracunElementi]  WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDELEMENT] = @IDELEMENT AND [ELEMENTRAZDOBLJEOD] = @ELEMENTRAZDOBLJEOD AND [ELEMENTRAZDOBLJEDO] = @ELEMENTRAZDOBLJEDO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ELEMENTRAZDOBLJEOD", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ELEMENTRAZDOBLJEDO", DbType.Date));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDOBRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDRADNIK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDELEMENT"]));
            command.SetParameterDateObject(3, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["ELEMENTRAZDOBLJEOD"]));
            command.SetParameterDateObject(4, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["ELEMENTRAZDOBLJEDO"]));
            command.ExecuteStmt();
            this.OnObracunElementiUpdated(new ObracunElementiEventArgs(this.rowObracunElementi, StatementType.Delete));
            this.rowObracunElementi.Delete();
            this.sMode62 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode62;
        }

        private void DeleteObracunkrediti()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyObracunkrediti();
            this.OnDeleteControlsObracunkrediti();
            this.AfterConfirmObracunkrediti();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [OBRACUNKrediti]  WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDKREDITOR] = @IDKREDITOR AND [DATUMUGOVORA] = @DATUMUGOVORA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKREDITOR", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMUGOVORA", DbType.Date));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["IDOBRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["IDRADNIK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["IDKREDITOR"]));
            command.SetParameterDateObject(3, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["DATUMUGOVORA"]));
            command.ExecuteStmt();
            this.OnOBRACUNKreditiUpdated(new OBRACUNKreditiEventArgs(this.rowOBRACUNKrediti, StatementType.Delete));
            this.rowOBRACUNKrediti.Delete();
            this.sMode74 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode74;
        }

        private void DeleteObracunobracunlevel1obracunizuzece()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyObracunobracunlevel1obracunizuzece();
            this.AfterConfirmObracunobracunlevel1obracunizuzece();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [OBRACUNOBRACUNLevel1ObracunIzuzece]  WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDOBRACUNIZUZECE] = @IDOBRACUNIZUZECE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUNIZUZECE", DbType.Guid));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDOBRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDRADNIK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDOBRACUNIZUZECE"]));
            command.ExecuteStmt();
            this.OnOBRACUNOBRACUNLevel1ObracunIzuzeceUpdated(new OBRACUNOBRACUNLevel1ObracunIzuzeceEventArgs(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece, StatementType.Delete));
            this.rowOBRACUNOBRACUNLevel1ObracunIzuzece.Delete();
            this.sMode292 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode292;
        }

        private void DeleteObracunobracunlevel1obracunkrizni()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyObracunobracunlevel1obracunkrizni();
            this.OnDeleteControlsObracunobracunlevel1obracunkrizni();
            this.AfterConfirmObracunobracunlevel1obracunkrizni();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [OBRACUNOBRACUNLevel1ObracunKrizni]  WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDOBRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDRADNIK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDKRIZNIPOREZ"]));
            command.ExecuteStmt();
            this.OnOBRACUNOBRACUNLevel1ObracunKrizniUpdated(new OBRACUNOBRACUNLevel1ObracunKrizniEventArgs(this.rowOBRACUNOBRACUNLevel1ObracunKrizni, StatementType.Delete));
            this.rowOBRACUNOBRACUNLevel1ObracunKrizni.Delete();
            this.sMode137 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode137;
        }

        private void DeleteObracunobustave()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyObracunobustave();
            this.OnDeleteControlsObracunobustave();
            this.AfterConfirmObracunobustave();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [OBRACUNObustave]  WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDOBUSTAVA] = @IDOBUSTAVA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBUSTAVA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IDOBRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IDRADNIK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IDOBUSTAVA"]));
            command.ExecuteStmt();
            this.OnOBRACUNObustaveUpdated(new OBRACUNObustaveEventArgs(this.rowOBRACUNObustave, StatementType.Delete));
            this.rowOBRACUNObustave.Delete();
            this.sMode61 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode61;
        }

        private void DeleteObracunolaksice()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyObracunolaksice();
            this.OnDeleteControlsObracunolaksice();
            this.AfterConfirmObracunolaksice();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [ObracunOlaksice]  WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDOLAKSICE] = @IDOLAKSICE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOLAKSICE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDOBRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDRADNIK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDOLAKSICE"]));
            command.ExecuteStmt();
            this.OnObracunOlaksiceUpdated(new ObracunOlaksiceEventArgs(this.rowObracunOlaksice, StatementType.Delete));
            this.rowObracunOlaksice.Delete();
            this.sMode13 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode13;
        }

        private void DeleteObracunporezi()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyObracunporezi();
            this.OnDeleteControlsObracunporezi();
            this.AfterConfirmObracunporezi();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [ObracunPorezi]  WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDPOREZ] = @IDPOREZ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["IDOBRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["IDRADNIK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["IDPOREZ"]));
            command.ExecuteStmt();
            this.OnObracunPoreziUpdated(new ObracunPoreziEventArgs(this.rowObracunPorezi, StatementType.Delete));
            this.rowObracunPorezi.Delete();
            this.sMode12 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode12;
        }

        private void DeleteObracunradnici()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyObracunradnici();
            this.OnDeleteControlsObracunradnici();
            this.ProcessNestedLevelObracunobracunlevel1obracunizuzece();
            this.ProcessNestedLevelObracunobracunlevel1obracunkrizni();
            this.ProcessNestedLevelObracunkrediti();
            this.ProcessNestedLevelObracunelementi();
            this.ProcessNestedLevelObracunobustave();
            this.ProcessNestedLevelObracunolaksice();
            this.ProcessNestedLevelObracunporezi();
            this.ProcessNestedLevelObracundoprinosi();
            this.AfterConfirmObracunradnici();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [ObracunRadnici]  WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDOBRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDRADNIK"]));
            command.ExecuteStmt();
            this.OnObracunRadniciUpdated(new ObracunRadniciEventArgs(this.rowObracunRadnici, StatementType.Delete));
            this.rowObracunRadnici.Delete();
            this.sMode10 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode10;
        }

        public virtual int Fill(OBRACUNDataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, this.fillDataParameters[0].Value.ToString());
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.OBRACUNSet = dataSet;
                    this.LoadChildObracun(0, -1);
                    dataSet.AcceptChanges();
                }
                finally
                {
                    this.Cleanup();
                }
            }
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.OBRACUNSet = (OBRACUNDataSet) dataSet;
            if (this.OBRACUNSet != null)
            {
                return this.Fill(this.OBRACUNSet);
            }
            this.OBRACUNSet = new OBRACUNDataSet();
            this.Fill(this.OBRACUNSet);
            dataSet.Merge(this.OBRACUNSet);
            return 0;
        }

        public virtual int Fill(OBRACUNDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["IDOBRACUN"]));
        }

        public virtual int Fill(OBRACUNDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["IDOBRACUN"]));
        }

        public virtual int Fill(OBRACUNDataSet dataSet, string iDOBRACUN)
        {
            if (!this.FillByIDOBRACUN(dataSet, iDOBRACUN))
            {
                throw new OBRACUNNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OBRACUN") }));
            }
            return 0;
        }

        public virtual bool FillByIDOBRACUN(OBRACUNDataSet dataSet, string iDOBRACUN)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OBRACUNSet = dataSet;
            this.rowOBRACUN = this.OBRACUNSet.OBRACUN.NewOBRACUNRow();
            this.rowOBRACUN.IDOBRACUN = iDOBRACUN;
            try
            {
                this.LoadByIDOBRACUN(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound9 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(OBRACUNDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OBRACUNSet = dataSet;
            try
            {
                this.LoadChildObracun(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType)
        {
            DataTable[] array = new DataTable[dataSet.Tables.Count + 1];
            dataSet.Tables.CopyTo(array, dataSet.Tables.Count);
            return array;
        }

        private void GetByPrimaryKey()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOBRACUN], [VRSTAOBRACUNA], [MJESECOBRACUNA], [GODINAOBRACUNA], [MJESECISPLATE], [GODINAISPLATE], [DATUMISPLATE], [tjednifondsatiobracun], [MJESECNIFONDSATIOBRACUN], [OSNOVNIOO], [OBRACUNSKAOSNOVICA], [DATUMOBRACUNASTAZA], [OBRPOSTOTNIH], [OBRFIKSNIH], [OBRKREDITNIH], [ZAKLJ], [SVRHAOBRACUNA] FROM [OBRACUN] WITH (NOLOCK) WHERE [IDOBRACUN] = @IDOBRACUN ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["IDOBRACUN"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound9 = 1;
                this.rowOBRACUN["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowOBRACUN["VRSTAOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowOBRACUN["MJESECOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowOBRACUN["GODINAOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowOBRACUN["MJESECISPLATE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowOBRACUN["GODINAISPLATE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowOBRACUN["DATUMISPLATE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 6));
                this.rowOBRACUN["tjednifondsatiobracun"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 7));
                this.rowOBRACUN["MJESECNIFONDSATIOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 8));
                this.rowOBRACUN["OSNOVNIOO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 9));
                this.rowOBRACUN["OBRACUNSKAOSNOVICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 10));
                this.rowOBRACUN["DATUMOBRACUNASTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 11));
                this.rowOBRACUN["OBRPOSTOTNIH"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 12));
                this.rowOBRACUN["OBRFIKSNIH"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 13));
                this.rowOBRACUN["OBRKREDITNIH"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 14));
                this.rowOBRACUN["ZAKLJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 15));
                this.rowOBRACUN["SVRHAOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x10));
                this.sMode9 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode9;
            }
            else
            {
                this.RcdFound9 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDOBRACUN";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOBRACUNSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OBRACUN] WITH (NOLOCK) ", false);
            this.OBRACUNSelect1 = this.cmOBRACUNSelect1.FetchData();
            if (this.OBRACUNSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OBRACUNSelect1.GetInt32(0);
            }
            this.OBRACUNSelect1.Close();
            return this.recordCount;
        }

        public virtual int GetRecordCount()
        {
            int internalRecordCount;
            try
            {
                this.InitializeMembers();
                internalRecordCount = this.GetInternalRecordCount();
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCount;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound9 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__PRIMATELJIZUZECE1Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIMATELJIZUZECE2Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIMATELJIZUZECE3Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__SIFRAOPISAPLACANJAIZUZECEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OPISPLACANJAIZUZECEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__VBDIIZUZECEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__TEKUCIIZUZECEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MOIZUZECEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POIZUZECEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MZIZUZECEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PZIZUZECEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IZNOSIZUZECAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove317 = false;
            this._Condition = false;
            this.RcdFound292 = 0;
            this.m_SubSelTopString292 = "";
            this.m__OSNOVICAKRIZNIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POREZKRIZNIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSNOVICAPRETHODNAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSNOVICAUKUPNAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POREZPRETHODNIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POREZUKUPNOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove296 = false;
            this.RcdFound137 = 0;
            this.m_SubSelTopString137 = "";
            this.m__OBRSATIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRSATNICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRIZNOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRPOSTOTAKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove281 = false;
            this.RcdFound62 = 0;
            this.m_SubSelTopString62 = "";
            this.m__IZNOSOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POSTOTAKOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRACUNATAOBUSTAVAUKUNAMAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ISPLACENOKASAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SALDOKASAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove257 = false;
            this.RcdFound61 = 0;
            this.m_SubSelTopString61 = "";
            this.m__OBRSIFRAOPISAPLACANJAKREDITOROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBROPISPLACANJAKREDITOROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRMOKREDITOROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRPOKREDITOROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRMZKREDITOROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRPZKREDITOROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRIZNOSRATEKREDITOROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRACUNATIKUNSKIIZNOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__VECOTPLACENOBROJRATAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__VECOTPLACENOUKUPNIIZNOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__UKUPNIZNOSKREDITAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove235 = false;
            this.RcdFound74 = 0;
            this.m_SubSelTopString74 = "";
            this.m__MZOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PZOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MOOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SIFRAOPISAPLACANJAOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OPISPLACANJAOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IZNOSOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRACUNATAOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove214 = false;
            this.RcdFound13 = 0;
            this.m_SubSelTopString13 = "";
            this.m__OBRACUNATIPOREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSNOVICAPOREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove199 = false;
            this.RcdFound12 = 0;
            this.m_SubSelTopString12 = "";
            this.m__OBRACUNATIDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSNOVICADOPRINOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove179 = false;
            this.RcdFound11 = 0;
            this.m_SubSelTopString11 = "";
            this.m__SIFRAOPCINESTANOVANJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRACUNSKIKOEFICIJENTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ISKORISTENOOOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRACUNATIPRIREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__faktooOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__RADNIKOBRACUNOSNOVICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KOREKCIJAPRIREZAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ODBITAKPRIJEKOREKCIJEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRACUNAVAJOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.RcdFound10 = 0;
            this.m_SubSelTopString10 = "";
            this.m__VRSTAOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MJESECOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__GODINAOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MJESECISPLATEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__GODINAISPLATEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DATUMISPLATEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__tjednifondsatiobracunOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MJESECNIFONDSATIOBRACUNOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSNOVNIOOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRACUNSKAOSNOVICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DATUMOBRACUNASTAZAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRPOSTOTNIHOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRFIKSNIHOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRKREDITNIHOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZAKLJOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SVRHAOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.OBRACUNSet = new OBRACUNDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertObracun()
        {
            this.CheckOptimisticConcurrencyObracun();
            this.CheckExtendedTableObracun();
            this.AfterConfirmObracun();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [OBRACUN] ([IDOBRACUN], [VRSTAOBRACUNA], [MJESECOBRACUNA], [GODINAOBRACUNA], [MJESECISPLATE], [GODINAISPLATE], [DATUMISPLATE], [tjednifondsatiobracun], [MJESECNIFONDSATIOBRACUN], [OSNOVNIOO], [OBRACUNSKAOSNOVICA], [DATUMOBRACUNASTAZA], [OBRPOSTOTNIH], [OBRFIKSNIH], [OBRKREDITNIH], [ZAKLJ], [SVRHAOBRACUNA]) VALUES (@IDOBRACUN, @VRSTAOBRACUNA, @MJESECOBRACUNA, @GODINAOBRACUNA, @MJESECISPLATE, @GODINAISPLATE, @DATUMISPLATE, @tjednifondsatiobracun, @MJESECNIFONDSATIOBRACUN, @OSNOVNIOO, @OBRACUNSKAOSNOVICA, @DATUMOBRACUNASTAZA, @OBRPOSTOTNIH, @OBRFIKSNIH, @OBRKREDITNIH, @ZAKLJ, @SVRHAOBRACUNA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBRACUNA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECOBRACUNA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAOBRACUNA", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECISPLATE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAISPLATE", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMISPLATE", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@tjednifondsatiobracun", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECNIFONDSATIOBRACUN", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVNIOO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNSKAOSNOVICA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMOBRACUNASTAZA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRPOSTOTNIH", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRFIKSNIH", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRKREDITNIH", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAKLJ", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SVRHAOBRACUNA", DbType.String, 100));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["IDOBRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["VRSTAOBRACUNA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["MJESECOBRACUNA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["GODINAOBRACUNA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["MJESECISPLATE"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["GODINAISPLATE"]));
            command.SetParameterDateObject(6, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["DATUMISPLATE"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["tjednifondsatiobracun"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["MJESECNIFONDSATIOBRACUN"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OSNOVNIOO"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OBRACUNSKAOSNOVICA"]));
            command.SetParameterDateObject(11, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["DATUMOBRACUNASTAZA"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OBRPOSTOTNIH"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OBRFIKSNIH"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OBRKREDITNIH"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["ZAKLJ"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["SVRHAOBRACUNA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new OBRACUNDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnOBRACUNUpdated(new OBRACUNEventArgs(this.rowOBRACUN, StatementType.Insert));
            this.ProcessLevelObracun();
        }

        private void InsertObracundoprinosi()
        {
            this.CheckOptimisticConcurrencyObracundoprinosi();
            this.CheckExtendedTableObracundoprinosi();
            this.AfterConfirmObracundoprinosi();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [ObracunDoprinosi] ([VBDIDOPRINOS], [ZRNDOPRINOS], [NAZIVDOPRINOS], [IDVRSTADOPRINOS], [NAZIVVRSTADOPRINOS], [STOPA], [MODOPRINOS], [PODOPRINOS], [MZDOPRINOS], [PZDOPRINOS], [PRIMATELJDOPRINOS1], [PRIMATELJDOPRINOS2], [SIFRAOPISAPLACANJADOPRINOS], [OPISPLACANJADOPRINOS], [IDOBRACUN], [IDRADNIK], [OBRACUNATIDOPRINOS], [OSNOVICADOPRINOS], [IDDOPRINOS]) VALUES (@VBDIDOPRINOS, @ZRNDOPRINOS, @NAZIVDOPRINOS, @IDVRSTADOPRINOS, @NAZIVVRSTADOPRINOS, @STOPA, @MODOPRINOS, @PODOPRINOS, @MZDOPRINOS, @PZDOPRINOS, @PRIMATELJDOPRINOS1, @PRIMATELJDOPRINOS2, @SIFRAOPISAPLACANJADOPRINOS, @OPISPLACANJADOPRINOS, @IDOBRACUN, @IDRADNIK, @OBRACUNATIDOPRINOS, @OSNOVICADOPRINOS, @IDDOPRINOS)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIDOPRINOS", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNDOPRINOS", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVDOPRINOS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTADOPRINOS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STOPA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MODOPRINOS", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PODOPRINOS", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZDOPRINOS", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZDOPRINOS", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJDOPRINOS1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJDOPRINOS2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJADOPRINOS", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJADOPRINOS", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNATIDOPRINOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICADOPRINOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["VBDIDOPRINOS"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["ZRNDOPRINOS"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["NAZIVDOPRINOS"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDVRSTADOPRINOS"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["NAZIVVRSTADOPRINOS"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["STOPA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["MODOPRINOS"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["PODOPRINOS"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["MZDOPRINOS"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["PZDOPRINOS"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["PRIMATELJDOPRINOS1"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["PRIMATELJDOPRINOS2"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["SIFRAOPISAPLACANJADOPRINOS"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["OPISPLACANJADOPRINOS"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDOBRACUN"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDRADNIK"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["OBRACUNATIDOPRINOS"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["OSNOVICADOPRINOS"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDDOPRINOS"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new ObracunDoprinosiDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnObracunDoprinosiUpdated(new ObracunDoprinosiEventArgs(this.rowObracunDoprinosi, StatementType.Insert));
        }

        private void InsertObracunelementi()
        {
            this.CheckOptimisticConcurrencyObracunelementi();
            this.CheckExtendedTableObracunelementi();
            this.AfterConfirmObracunelementi();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [ObracunElementi] ([NAZIVELEMENT], [IDVRSTAELEMENTA], [NAZIVVRSTAELEMENT], [IDOBRACUN], [IDRADNIK], [ELEMENTRAZDOBLJEOD], [ELEMENTRAZDOBLJEDO], [OBRSATI], [OBRSATNICA], [OBRIZNOS], [OBRPOSTOTAK], [IDELEMENT]) VALUES (@NAZIVELEMENT, @IDVRSTAELEMENTA, @NAZIVVRSTAELEMENT, @IDOBRACUN, @IDRADNIK, @ELEMENTRAZDOBLJEOD, @ELEMENTRAZDOBLJEDO, @OBRSATI, @OBRSATNICA, @OBRIZNOS, @OBRPOSTOTAK, @IDELEMENT)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVELEMENT", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTAELEMENT", DbType.String, 0x19));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ELEMENTRAZDOBLJEOD", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ELEMENTRAZDOBLJEDO", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRSATI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRSATNICA", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRPOSTOTAK", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["NAZIVELEMENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDVRSTAELEMENTA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["NAZIVVRSTAELEMENT"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDOBRACUN"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDRADNIK"]));
            command.SetParameterDateObject(5, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["ELEMENTRAZDOBLJEOD"]));
            command.SetParameterDateObject(6, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["ELEMENTRAZDOBLJEDO"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["OBRSATI"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["OBRSATNICA"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["OBRIZNOS"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["OBRPOSTOTAK"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDELEMENT"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new ObracunElementiDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnObracunElementiUpdated(new ObracunElementiEventArgs(this.rowObracunElementi, StatementType.Insert));
        }

        private void InsertObracunkrediti()
        {
            this.CheckOptimisticConcurrencyObracunkrediti();
            this.CheckExtendedTableObracunkrediti();
            this.AfterConfirmObracunkrediti();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [OBRACUNKrediti] ([NAZIVKREDITOR], [VBDIKREDITOR], [ZRNKREDITOR], [PRIMATELJKREDITOR1], [PRIMATELJKREDITOR2], [PRIMATELJKREDITOR3], [IDOBRACUN], [IDRADNIK], [DATUMUGOVORA], [OBRSIFRAOPISAPLACANJAKREDITOR], [OBROPISPLACANJAKREDITOR], [OBRMOKREDITOR], [OBRPOKREDITOR], [OBRMZKREDITOR], [OBRPZKREDITOR], [OBRIZNOSRATEKREDITOR], [OBRACUNATIKUNSKIIZNOS], [VECOTPLACENOBROJRATA], [VECOTPLACENOUKUPNIIZNOS], [UKUPNIZNOSKREDITA], [IDKREDITOR]) VALUES (@NAZIVKREDITOR, @VBDIKREDITOR, @ZRNKREDITOR, @PRIMATELJKREDITOR1, @PRIMATELJKREDITOR2, @PRIMATELJKREDITOR3, @IDOBRACUN, @IDRADNIK, @DATUMUGOVORA, @OBRSIFRAOPISAPLACANJAKREDITOR, @OBROPISPLACANJAKREDITOR, @OBRMOKREDITOR, @OBRPOKREDITOR, @OBRMZKREDITOR, @OBRPZKREDITOR, @OBRIZNOSRATEKREDITOR, @OBRACUNATIKUNSKIIZNOS, @VECOTPLACENOBROJRATA, @VECOTPLACENOUKUPNIIZNOS, @UKUPNIZNOSKREDITA, @IDKREDITOR)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVKREDITOR", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIKREDITOR", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNKREDITOR", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKREDITOR1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKREDITOR2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKREDITOR3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMUGOVORA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRSIFRAOPISAPLACANJAKREDITOR", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBROPISPLACANJAKREDITOR", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRMOKREDITOR", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRPOKREDITOR", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRMZKREDITOR", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRPZKREDITOR", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRIZNOSRATEKREDITOR", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNATIKUNSKIIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VECOTPLACENOBROJRATA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VECOTPLACENOUKUPNIIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UKUPNIZNOSKREDITA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKREDITOR", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["NAZIVKREDITOR"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["VBDIKREDITOR"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["ZRNKREDITOR"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["PRIMATELJKREDITOR1"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["PRIMATELJKREDITOR2"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["PRIMATELJKREDITOR3"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["IDOBRACUN"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["IDRADNIK"]));
            command.SetParameterDateObject(8, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["DATUMUGOVORA"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRSIFRAOPISAPLACANJAKREDITOR"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBROPISPLACANJAKREDITOR"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRMOKREDITOR"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRPOKREDITOR"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRMZKREDITOR"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRPZKREDITOR"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRIZNOSRATEKREDITOR"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRACUNATIKUNSKIIZNOS"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["VECOTPLACENOBROJRATA"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["VECOTPLACENOUKUPNIIZNOS"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["UKUPNIZNOSKREDITA"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["IDKREDITOR"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new OBRACUNKreditiDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnOBRACUNKreditiUpdated(new OBRACUNKreditiEventArgs(this.rowOBRACUNKrediti, StatementType.Insert));
        }

        private void InsertObracunobracunlevel1obracunizuzece()
        {
            this.CheckOptimisticConcurrencyObracunobracunlevel1obracunizuzece();
            this.AfterConfirmObracunobracunlevel1obracunizuzece();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [OBRACUNOBRACUNLevel1ObracunIzuzece] ([IDOBRACUN], [IDRADNIK], [IDOBRACUNIZUZECE], [PRIMATELJIZUZECE1], [PRIMATELJIZUZECE2], [PRIMATELJIZUZECE3], [SIFRAOPISAPLACANJAIZUZECE], [OPISPLACANJAIZUZECE], [VBDIIZUZECE], [TEKUCIIZUZECE], [MOIZUZECE], [POIZUZECE], [MZIZUZECE], [PZIZUZECE], [IZNOSIZUZECA]) VALUES (@IDOBRACUN, @IDRADNIK, @IDOBRACUNIZUZECE, @PRIMATELJIZUZECE1, @PRIMATELJIZUZECE2, @PRIMATELJIZUZECE3, @SIFRAOPISAPLACANJAIZUZECE, @OPISPLACANJAIZUZECE, @VBDIIZUZECE, @TEKUCIIZUZECE, @MOIZUZECE, @POIZUZECE, @MZIZUZECE, @PZIZUZECE, @IZNOSIZUZECA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUNIZUZECE", DbType.Guid));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJIZUZECE1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJIZUZECE2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJIZUZECE3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAIZUZECE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAIZUZECE", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIIZUZECE", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TEKUCIIZUZECE", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOIZUZECE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POIZUZECE", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZIZUZECE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZIZUZECE", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZNOSIZUZECA", DbType.Currency));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDOBRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDRADNIK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDOBRACUNIZUZECE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PRIMATELJIZUZECE1"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PRIMATELJIZUZECE2"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PRIMATELJIZUZECE3"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["SIFRAOPISAPLACANJAIZUZECE"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["OPISPLACANJAIZUZECE"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["VBDIIZUZECE"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["TEKUCIIZUZECE"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["MOIZUZECE"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["POIZUZECE"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["MZIZUZECE"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PZIZUZECE"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IZNOSIZUZECA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new OBRACUNOBRACUNLevel1ObracunIzuzeceDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnOBRACUNOBRACUNLevel1ObracunIzuzeceUpdated(new OBRACUNOBRACUNLevel1ObracunIzuzeceEventArgs(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece, StatementType.Insert));
        }

        private void InsertObracunobracunlevel1obracunkrizni()
        {
            this.CheckOptimisticConcurrencyObracunobracunlevel1obracunkrizni();
            this.CheckExtendedTableObracunobracunlevel1obracunkrizni();
            this.AfterConfirmObracunobracunlevel1obracunkrizni();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [OBRACUNOBRACUNLevel1ObracunKrizni] ([NAZIVKRIZNIPOREZ], [KRIZNISTOPA], [MOKRIZNI], [POKRIZNI], [MZKRIZNI], [PZKRIZNI], [PRIMATELJKRIZNI1], [PRIMATELJKRIZNI2], [SIFRAOPISAPLACANJAKRIZNI], [OPISPLACANJAKRIZNI], [PRIMATELJKRIZNI3], [VBDIKRIZNI], [ZRNKRIZNI], [IDOBRACUN], [IDRADNIK], [OSNOVICAKRIZNI], [POREZKRIZNI], [OSNOVICAPRETHODNA], [OSNOVICAUKUPNA], [POREZPRETHODNI], [POREZUKUPNO], [IDKRIZNIPOREZ]) VALUES (@NAZIVKRIZNIPOREZ, @KRIZNISTOPA, @MOKRIZNI, @POKRIZNI, @MZKRIZNI, @PZKRIZNI, @PRIMATELJKRIZNI1, @PRIMATELJKRIZNI2, @SIFRAOPISAPLACANJAKRIZNI, @OPISPLACANJAKRIZNI, @PRIMATELJKRIZNI3, @VBDIKRIZNI, @ZRNKRIZNI, @IDOBRACUN, @IDRADNIK, @OSNOVICAKRIZNI, @POREZKRIZNI, @OSNOVICAPRETHODNA, @OSNOVICAUKUPNA, @POREZPRETHODNI, @POREZUKUPNO, @IDKRIZNIPOREZ)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVKRIZNIPOREZ", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KRIZNISTOPA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOKRIZNI", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POKRIZNI", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZKRIZNI", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZKRIZNI", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAKRIZNI", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAKRIZNI", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIKRIZNI", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNKRIZNI", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICAKRIZNI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POREZKRIZNI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICAPRETHODNA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICAUKUPNA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POREZPRETHODNI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POREZUKUPNO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["NAZIVKRIZNIPOREZ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["KRIZNISTOPA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["MOKRIZNI"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POKRIZNI"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["MZKRIZNI"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PZKRIZNI"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PRIMATELJKRIZNI1"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PRIMATELJKRIZNI2"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["SIFRAOPISAPLACANJAKRIZNI"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OPISPLACANJAKRIZNI"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PRIMATELJKRIZNI3"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["VBDIKRIZNI"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["ZRNKRIZNI"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDOBRACUN"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDRADNIK"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OSNOVICAKRIZNI"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POREZKRIZNI"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OSNOVICAPRETHODNA"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OSNOVICAUKUPNA"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POREZPRETHODNI"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POREZUKUPNO"]));
            command.SetParameter(0x15, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDKRIZNIPOREZ"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new OBRACUNOBRACUNLevel1ObracunKrizniDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnOBRACUNOBRACUNLevel1ObracunKrizniUpdated(new OBRACUNOBRACUNLevel1ObracunKrizniEventArgs(this.rowOBRACUNOBRACUNLevel1ObracunKrizni, StatementType.Insert));
        }

        private void InsertObracunobustave()
        {
            this.CheckOptimisticConcurrencyObracunobustave();
            this.CheckExtendedTableObracunobustave();
            this.AfterConfirmObracunobustave();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [OBRACUNObustave] ([NAZIVOBUSTAVA], [MOOBUSTAVA], [POOBUSTAVA], [MZOBUSTAVA], [PZOBUSTAVA], [VBDIOBUSTAVA], [ZRNOBUSTAVA], [PRIMATELJOBUSTAVA1], [PRIMATELJOBUSTAVA2], [PRIMATELJOBUSTAVA3], [SIFRAOPISAPLACANJAOBUSTAVA], [OPISPLACANJAOBUSTAVA], [VRSTAOBUSTAVE], [NAZIVVRSTAOBUSTAVE], [IDOBRACUN], [IDRADNIK], [IZNOSOBUSTAVE], [POSTOTAKOBUSTAVE], [OBRACUNATAOBUSTAVAUKUNAMA], [ISPLACENOKASA], [SALDOKASA], [IDOBUSTAVA]) VALUES (@NAZIVOBUSTAVA, @MOOBUSTAVA, @POOBUSTAVA, @MZOBUSTAVA, @PZOBUSTAVA, @VBDIOBUSTAVA, @ZRNOBUSTAVA, @PRIMATELJOBUSTAVA1, @PRIMATELJOBUSTAVA2, @PRIMATELJOBUSTAVA3, @SIFRAOPISAPLACANJAOBUSTAVA, @OPISPLACANJAOBUSTAVA, @VRSTAOBUSTAVE, @NAZIVVRSTAOBUSTAVE, @IDOBRACUN, @IDRADNIK, @IZNOSOBUSTAVE, @POSTOTAKOBUSTAVE, @OBRACUNATAOBUSTAVAUKUNAMA, @ISPLACENOKASA, @SALDOKASA, @IDOBUSTAVA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOBUSTAVA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOOBUSTAVA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POOBUSTAVA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZOBUSTAVA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZOBUSTAVA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIOBUSTAVA", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNOBUSTAVA", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOBUSTAVA1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOBUSTAVA2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOBUSTAVA3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAOBUSTAVA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAOBUSTAVA", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTAOBUSTAVE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZNOSOBUSTAVE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTOTAKOBUSTAVE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNATAOBUSTAVAUKUNAMA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ISPLACENOKASA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SALDOKASA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBUSTAVA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["NAZIVOBUSTAVA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["MOOBUSTAVA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["POOBUSTAVA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["MZOBUSTAVA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["PZOBUSTAVA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["VBDIOBUSTAVA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["ZRNOBUSTAVA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["PRIMATELJOBUSTAVA1"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["PRIMATELJOBUSTAVA2"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["PRIMATELJOBUSTAVA3"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["SIFRAOPISAPLACANJAOBUSTAVA"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["OPISPLACANJAOBUSTAVA"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["VRSTAOBUSTAVE"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["NAZIVVRSTAOBUSTAVE"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IDOBRACUN"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IDRADNIK"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IZNOSOBUSTAVE"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["POSTOTAKOBUSTAVE"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["OBRACUNATAOBUSTAVAUKUNAMA"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["ISPLACENOKASA"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["SALDOKASA"]));
            command.SetParameter(0x15, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IDOBUSTAVA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new OBRACUNObustaveDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnOBRACUNObustaveUpdated(new OBRACUNObustaveEventArgs(this.rowOBRACUNObustave, StatementType.Insert));
        }

        private void InsertObracunolaksice()
        {
            this.CheckOptimisticConcurrencyObracunolaksice();
            this.CheckExtendedTableObracunolaksice();
            this.AfterConfirmObracunolaksice();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [ObracunOlaksice] ([NAZIVOLAKSICE], [IDGRUPEOLAKSICA], [NAZIVGRUPEOLAKSICA], [MAXIMALNIIZNOSGRUPE], [VBDIOLAKSICA], [PRIMATELJOLAKSICA1], [PRIMATELJOLAKSICA2], [PRIMATELJOLAKSICA3], [IDTIPOLAKSICE], [NAZIVTIPOLAKSICE], [ZRNOLAKSICA], [IDOBRACUN], [IDRADNIK], [MZOLAKSICA], [PZOLAKSICA], [MOOLAKSICA], [POOLAKSICA], [SIFRAOPISAPLACANJAOLAKSICA], [OPISPLACANJAOLAKSICA], [IZNOSOLAKSICE], [OBRACUNATAOLAKSICA], [IDOLAKSICE]) VALUES (@NAZIVOLAKSICE, @IDGRUPEOLAKSICA, @NAZIVGRUPEOLAKSICA, @MAXIMALNIIZNOSGRUPE, @VBDIOLAKSICA, @PRIMATELJOLAKSICA1, @PRIMATELJOLAKSICA2, @PRIMATELJOLAKSICA3, @IDTIPOLAKSICE, @NAZIVTIPOLAKSICE, @ZRNOLAKSICA, @IDOBRACUN, @IDRADNIK, @MZOLAKSICA, @PZOLAKSICA, @MOOLAKSICA, @POOLAKSICA, @SIFRAOPISAPLACANJAOLAKSICA, @OPISPLACANJAOLAKSICA, @IZNOSOLAKSICE, @OBRACUNATAOLAKSICA, @IDOLAKSICE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOLAKSICE", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVGRUPEOLAKSICA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MAXIMALNIIZNOSGRUPE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIOLAKSICA", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOLAKSICA1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOLAKSICA2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOLAKSICA3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVTIPOLAKSICE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNOLAKSICA", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZOLAKSICA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZOLAKSICA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOOLAKSICA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POOLAKSICA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAOLAKSICA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAOLAKSICA", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZNOSOLAKSICE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNATAOLAKSICA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOLAKSICE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["NAZIVOLAKSICE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDGRUPEOLAKSICA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["NAZIVGRUPEOLAKSICA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["MAXIMALNIIZNOSGRUPE"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["VBDIOLAKSICA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["PRIMATELJOLAKSICA1"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["PRIMATELJOLAKSICA2"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["PRIMATELJOLAKSICA3"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDTIPOLAKSICE"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["NAZIVTIPOLAKSICE"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["ZRNOLAKSICA"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDOBRACUN"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDRADNIK"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["MZOLAKSICA"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["PZOLAKSICA"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["MOOLAKSICA"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["POOLAKSICA"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["SIFRAOPISAPLACANJAOLAKSICA"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["OPISPLACANJAOLAKSICA"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IZNOSOLAKSICE"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["OBRACUNATAOLAKSICA"]));
            command.SetParameter(0x15, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDOLAKSICE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new ObracunOlaksiceDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnObracunOlaksiceUpdated(new ObracunOlaksiceEventArgs(this.rowObracunOlaksice, StatementType.Insert));
        }

        private void InsertObracunporezi()
        {
            this.CheckOptimisticConcurrencyObracunporezi();
            this.CheckExtendedTableObracunporezi();
            this.AfterConfirmObracunporezi();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [ObracunPorezi] ([NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], [MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ], [IDOBRACUN], [IDRADNIK], [OBRACUNATIPOREZ], [OSNOVICAPOREZ], [IDPOREZ]) VALUES (@NAZIVPOREZ, @STOPAPOREZA, @POREZMJESECNO, @MOPOREZ, @POPOREZ, @MZPOREZ, @PZPOREZ, @PRIMATELJPOREZ1, @PRIMATELJPOREZ2, @SIFRAOPISAPLACANJAPOREZ, @OPISPLACANJAPOREZ, @IDOBRACUN, @IDRADNIK, @OBRACUNATIPOREZ, @OSNOVICAPOREZ, @IDPOREZ)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPOREZ", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STOPAPOREZA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POREZMJESECNO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POPOREZ", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZPOREZ", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJPOREZ1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJPOREZ2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAPOREZ", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNATIPOREZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICAPOREZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["NAZIVPOREZ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["STOPAPOREZA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["POREZMJESECNO"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["MOPOREZ"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["POPOREZ"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["MZPOREZ"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["PZPOREZ"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["PRIMATELJPOREZ1"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["PRIMATELJPOREZ2"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["SIFRAOPISAPLACANJAPOREZ"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["OPISPLACANJAPOREZ"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["IDOBRACUN"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["IDRADNIK"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["OBRACUNATIPOREZ"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["OSNOVICAPOREZ"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["IDPOREZ"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new ObracunPoreziDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnObracunPoreziUpdated(new ObracunPoreziEventArgs(this.rowObracunPorezi, StatementType.Insert));
        }

        private void InsertObracunradnici()
        {
            this.CheckOptimisticConcurrencyObracunradnici();
            this.CheckExtendedTableObracunradnici();
            this.AfterConfirmObracunradnici();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [ObracunRadnici] ([KOEFICIJENT], [IDIPIDENT], [IDOBRACUN], [SIFRAOPCINESTANOVANJA], [OBRACUNSKIKOEFICIJENT], [ISKORISTENOOO], [OBRACUNATIPRIREZ], [faktoo], [RADNIKOBRACUNOSNOVICA], [KOREKCIJAPRIREZA], [ODBITAKPRIJEKOREKCIJE], [OBRACUNAVAJOBUSTAVE], [IDRADNIK]) VALUES (@KOEFICIJENT, @IDIPIDENT, @IDOBRACUN, @SIFRAOPCINESTANOVANJA, @OBRACUNSKIKOEFICIJENT, @ISKORISTENOOO, @OBRACUNATIPRIREZ, @faktoo, @RADNIKOBRACUNOSNOVICA, @KOREKCIJAPRIREZA, @ODBITAKPRIJEKOREKCIJE, @OBRACUNAVAJOBUSTAVE, @IDRADNIK)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KOEFICIJENT", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPCINESTANOVANJA", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNSKIKOEFICIJENT", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ISKORISTENOOO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNATIPRIREZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@faktoo", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNIKOBRACUNOSNOVICA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KOREKCIJAPRIREZA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODBITAKPRIJEKOREKCIJE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNAVAJOBUSTAVE", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["KOEFICIJENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDIPIDENT"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDOBRACUN"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["SIFRAOPCINESTANOVANJA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["OBRACUNSKIKOEFICIJENT"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["ISKORISTENOOO"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["OBRACUNATIPRIREZ"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["faktoo"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["RADNIKOBRACUNOSNOVICA"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["KOREKCIJAPRIREZA"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["ODBITAKPRIJEKOREKCIJE"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["OBRACUNAVAJOBUSTAVE"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDRADNIK"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new ObracunRadniciDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnObracunRadniciUpdated(new ObracunRadniciEventArgs(this.rowObracunRadnici, StatementType.Insert));
            this.ProcessLevelObracunradnici();
        }

        private void LoadByIDOBRACUN(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OBRACUNSet.EnforceConstraints;
            this.OBRACUNSet.OBRACUNOBRACUNLevel1ObracunIzuzece.BeginLoadData();
            this.OBRACUNSet.OBRACUNOBRACUNLevel1ObracunKrizni.BeginLoadData();
            this.OBRACUNSet.ObracunElementi.BeginLoadData();
            this.OBRACUNSet.OBRACUNObustave.BeginLoadData();
            this.OBRACUNSet.OBRACUNKrediti.BeginLoadData();
            this.OBRACUNSet.ObracunOlaksice.BeginLoadData();
            this.OBRACUNSet.ObracunPorezi.BeginLoadData();
            this.OBRACUNSet.ObracunDoprinosi.BeginLoadData();
            this.OBRACUNSet.ObracunRadnici.BeginLoadData();
            this.OBRACUNSet.OBRACUN.BeginLoadData();
            this.ScanByIDOBRACUN(startRow, maxRows);
            this.OBRACUNSet.OBRACUNOBRACUNLevel1ObracunIzuzece.EndLoadData();
            this.OBRACUNSet.OBRACUNOBRACUNLevel1ObracunKrizni.EndLoadData();
            this.OBRACUNSet.ObracunElementi.EndLoadData();
            this.OBRACUNSet.OBRACUNObustave.EndLoadData();
            this.OBRACUNSet.OBRACUNKrediti.EndLoadData();
            this.OBRACUNSet.ObracunOlaksice.EndLoadData();
            this.OBRACUNSet.ObracunPorezi.EndLoadData();
            this.OBRACUNSet.ObracunDoprinosi.EndLoadData();
            this.OBRACUNSet.ObracunRadnici.EndLoadData();
            this.OBRACUNSet.OBRACUN.EndLoadData();
            this.OBRACUNSet.EnforceConstraints = enforceConstraints;
            if (this.OBRACUNSet.OBRACUN.Count > 0)
            {
                this.rowOBRACUN = this.OBRACUNSet.OBRACUN[this.OBRACUNSet.OBRACUN.Count - 1];
            }
        }

        private void LoadChildObracun(int startRow, int maxRows)
        {
            this.CreateNewRowObracun();
            bool enforceConstraints = this.OBRACUNSet.EnforceConstraints;
            this.OBRACUNSet.OBRACUNOBRACUNLevel1ObracunIzuzece.BeginLoadData();
            this.OBRACUNSet.OBRACUNOBRACUNLevel1ObracunKrizni.BeginLoadData();
            this.OBRACUNSet.ObracunElementi.BeginLoadData();
            this.OBRACUNSet.OBRACUNObustave.BeginLoadData();
            this.OBRACUNSet.OBRACUNKrediti.BeginLoadData();
            this.OBRACUNSet.ObracunOlaksice.BeginLoadData();
            this.OBRACUNSet.ObracunPorezi.BeginLoadData();
            this.OBRACUNSet.ObracunDoprinosi.BeginLoadData();
            this.OBRACUNSet.ObracunRadnici.BeginLoadData();
            this.OBRACUNSet.OBRACUN.BeginLoadData();
            this.ScanStartObracun(startRow, maxRows);
            this.OBRACUNSet.OBRACUNOBRACUNLevel1ObracunIzuzece.EndLoadData();
            this.OBRACUNSet.OBRACUNOBRACUNLevel1ObracunKrizni.EndLoadData();
            this.OBRACUNSet.ObracunElementi.EndLoadData();
            this.OBRACUNSet.OBRACUNObustave.EndLoadData();
            this.OBRACUNSet.OBRACUNKrediti.EndLoadData();
            this.OBRACUNSet.ObracunOlaksice.EndLoadData();
            this.OBRACUNSet.ObracunPorezi.EndLoadData();
            this.OBRACUNSet.ObracunDoprinosi.EndLoadData();
            this.OBRACUNSet.ObracunRadnici.EndLoadData();
            this.OBRACUNSet.OBRACUN.EndLoadData();
            this.OBRACUNSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildObracundoprinosi()
        {
            this.CreateNewRowObracundoprinosi();
            this.ScanStartObracundoprinosi();
        }

        private void LoadChildObracunelementi()
        {
            this.CreateNewRowObracunelementi();
            this.ScanStartObracunelementi();
        }

        private void LoadChildObracunkrediti()
        {
            this.CreateNewRowObracunkrediti();
            this.ScanStartObracunkrediti();
        }

        private void LoadChildObracunobracunlevel1obracunizuzece()
        {
            this.CreateNewRowObracunobracunlevel1obracunizuzece();
            this.ScanStartObracunobracunlevel1obracunizuzece();
        }

        private void LoadChildObracunobracunlevel1obracunkrizni()
        {
            this.CreateNewRowObracunobracunlevel1obracunkrizni();
            this.ScanStartObracunobracunlevel1obracunkrizni();
        }

        private void LoadChildObracunobustave()
        {
            this.CreateNewRowObracunobustave();
            this.ScanStartObracunobustave();
        }

        private void LoadChildObracunolaksice()
        {
            this.CreateNewRowObracunolaksice();
            this.ScanStartObracunolaksice();
        }

        private void LoadChildObracunporezi()
        {
            this.CreateNewRowObracunporezi();
            this.ScanStartObracunporezi();
        }

        private void LoadChildObracunradnici()
        {
            this.CreateNewRowObracunradnici();
            this.ScanStartObracunradnici();
        }

        private void LoadDataObracun(int maxRows)
        {
            int num = 0;
            if (this.RcdFound9 != 0)
            {
                this.ScanLoadObracun();
                while ((this.RcdFound9 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowObracun();
                    this.CreateNewRowObracun();
                    this.ScanNextObracun();
                }
            }
            if (num > 0)
            {
                this.RcdFound9 = 1;
            }
            this.ScanEndObracun();
            if (this.OBRACUNSet.OBRACUN.Count > 0)
            {
                this.rowOBRACUN = this.OBRACUNSet.OBRACUN[this.OBRACUNSet.OBRACUN.Count - 1];
            }
        }

        private void LoadDataObracundoprinosi()
        {
            while (this.RcdFound11 != 0)
            {
                this.LoadRowObracundoprinosi();
                this.CreateNewRowObracundoprinosi();
                this.ScanNextObracundoprinosi();
            }
            this.ScanEndObracundoprinosi();
        }

        private void LoadDataObracunelementi()
        {
            while (this.RcdFound62 != 0)
            {
                this.LoadRowObracunelementi();
                this.CreateNewRowObracunelementi();
                this.ScanNextObracunelementi();
            }
            this.ScanEndObracunelementi();
        }

        private void LoadDataObracunkrediti()
        {
            while (this.RcdFound74 != 0)
            {
                this.StandaloneModalObracunkrediti();
                this.LoadRowObracunkrediti();
                this.CreateNewRowObracunkrediti();
                this.ScanNextObracunkrediti();
            }
            this.ScanEndObracunkrediti();
        }

        private void LoadDataObracunobracunlevel1obracunizuzece()
        {
            while (this.RcdFound292 != 0)
            {
                this.LoadRowObracunobracunlevel1obracunizuzece();
                this.CreateNewRowObracunobracunlevel1obracunizuzece();
                this.ScanNextObracunobracunlevel1obracunizuzece();
            }
            this.ScanEndObracunobracunlevel1obracunizuzece();
        }

        private void LoadDataObracunobracunlevel1obracunkrizni()
        {
            while (this.RcdFound137 != 0)
            {
                this.LoadRowObracunobracunlevel1obracunkrizni();
                this.CreateNewRowObracunobracunlevel1obracunkrizni();
                this.ScanNextObracunobracunlevel1obracunkrizni();
            }
            this.ScanEndObracunobracunlevel1obracunkrizni();
        }

        private void LoadDataObracunobustave()
        {
            while (this.RcdFound61 != 0)
            {
                this.StandaloneModalObracunobustave();
                this.LoadRowObracunobustave();
                this.CreateNewRowObracunobustave();
                this.ScanNextObracunobustave();
            }
            this.ScanEndObracunobustave();
        }

        private void LoadDataObracunolaksice()
        {
            while (this.RcdFound13 != 0)
            {
                this.LoadRowObracunolaksice();
                this.CreateNewRowObracunolaksice();
                this.ScanNextObracunolaksice();
            }
            this.ScanEndObracunolaksice();
        }

        private void LoadDataObracunporezi()
        {
            while (this.RcdFound12 != 0)
            {
                this.LoadRowObracunporezi();
                this.CreateNewRowObracunporezi();
                this.ScanNextObracunporezi();
            }
            this.ScanEndObracunporezi();
        }

        private void LoadDataObracunradnici()
        {
            while (this.RcdFound10 != 0)
            {
                this.LoadRowObracunradnici();
                this.CreateNewRowObracunradnici();
                this.ScanNextObracunradnici();
            }
            this.ScanEndObracunradnici();
        }

        private void LoadRowObracun()
        {
            this.AddRowObracun();
        }

        private void LoadRowObracundoprinosi()
        {
            this.AddRowObracundoprinosi();
        }

        private void LoadRowObracunelementi()
        {
            this.AddRowObracunelementi();
        }

        private void LoadRowObracunkrediti()
        {
            this.AddRowObracunkrediti();
        }

        private void LoadRowObracunobracunlevel1obracunizuzece()
        {
            this.AddRowObracunobracunlevel1obracunizuzece();
        }

        private void LoadRowObracunobracunlevel1obracunkrizni()
        {
            this.AddRowObracunobracunlevel1obracunkrizni();
        }

        private void LoadRowObracunobustave()
        {
            this.AddRowObracunobustave();
        }

        private void LoadRowObracunolaksice()
        {
            this.AddRowObracunolaksice();
        }

        private void LoadRowObracunporezi()
        {
            this.AddRowObracunporezi();
        }

        private void LoadRowObracunradnici()
        {
            this.OnLoadActionsObracunradnici();
            this.AddRowObracunradnici();
        }

        private void OnDeleteControlsObracundoprinosi()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [VBDIDOPRINOS], [ZRNDOPRINOS], [NAZIVDOPRINOS], [IDVRSTADOPRINOS], [STOPA], [MODOPRINOS], [PODOPRINOS], [MZDOPRINOS], [PZDOPRINOS], [PRIMATELJDOPRINOS1], [PRIMATELJDOPRINOS2], [SIFRAOPISAPLACANJADOPRINOS], [OPISPLACANJADOPRINOS], [MINDOPRINOS], [MAXDOPRINOS] FROM [DOPRINOS] WITH (NOLOCK) WHERE [IDDOPRINOS] = @IDDOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDDOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowObracunDoprinosi["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowObracunDoprinosi["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowObracunDoprinosi["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowObracunDoprinosi["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3));
                this.rowObracunDoprinosi["STOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4));
                this.rowObracunDoprinosi["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowObracunDoprinosi["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowObracunDoprinosi["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowObracunDoprinosi["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowObracunDoprinosi["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowObracunDoprinosi["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
                this.rowObracunDoprinosi["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
                this.rowObracunDoprinosi["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12));
                this.rowObracunDoprinosi["MINDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 13));
                this.rowObracunDoprinosi["MAXDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 14));
            }
            reader.Close();
            if (!this.rowObracunDoprinosi.IsIDVRSTADOPRINOSNull())
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVVRSTADOPRINOS] FROM [VRSTADOPRINOS] WITH (NOLOCK) WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
                }
                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDVRSTADOPRINOS"]));
                IDataReader reader2 = command2.FetchData();
                if (command2.HasMoreRows)
                {
                    this.rowObracunDoprinosi["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                }
                reader2.Close();
            }
            else
            {
                this.rowObracunDoprinosi["NAZIVVRSTADOPRINOS"] = "";
            }
        }

        private void OnDeleteControlsObracunelementi()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVELEMENT], [IDVRSTAELEMENTA], [ZBRAJASATEUFONDSATI], [IDOSNOVAOSIGURANJA] FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowObracunElementi["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowObracunElementi["IDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 1));
                this.rowObracunElementi["ZBRAJASATEUFONDSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 2));
                this.rowObracunElementi["IDOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetStringNE(reader, 3));
            }
            reader.Close();
            if (!this.rowObracunElementi.IsIDVRSTAELEMENTANull())
            {
                ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVVRSTAELEMENT] FROM [VRSTAELEMENT] WITH (NOLOCK) WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA ", false);
                if (command3.IDbCommand.Parameters.Count == 0)
                {
                    command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
                }
                command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDVRSTAELEMENTA"]));
                IDataReader reader3 = command3.FetchData();
                if (command3.HasMoreRows)
                {
                    this.rowObracunElementi["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0));
                }
                reader3.Close();
            }
            else
            {
                this.rowObracunElementi["NAZIVVRSTAELEMENT"] = "";
            }
            if (!this.rowObracunElementi.IsIDOSNOVAOSIGURANJANull() && (this.rowObracunElementi.IDOSNOVAOSIGURANJA.Length != 0))
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVOSNOVAOSIGURANJA], [RAZDOBLJESESMIJEPREKLAPATI] FROM [OSNOVAOSIGURANJA] WITH (NOLOCK) WHERE [IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
                }
                command2.SetParameterString(0, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDOSNOVAOSIGURANJA"]));
                IDataReader reader2 = command2.FetchData();
                if (command2.HasMoreRows)
                {
                    this.rowObracunElementi["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                    this.rowObracunElementi["RAZDOBLJESESMIJEPREKLAPATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader2, 1));
                }
                reader2.Close();
            }
            else
            {
                this.rowObracunElementi["NAZIVOSNOVAOSIGURANJA"] = "";
                this.rowObracunElementi["RAZDOBLJESESMIJEPREKLAPATI"] = false;
            }
        }

        private void OnDeleteControlsObracunkrediti()
        {
            this.StandaloneModalObracunkrediti();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVKREDITOR], [VBDIKREDITOR], [ZRNKREDITOR], [PRIMATELJKREDITOR1], [PRIMATELJKREDITOR2], [PRIMATELJKREDITOR3] FROM [KREDITOR] WITH (NOLOCK) WHERE [IDKREDITOR] = @IDKREDITOR ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKREDITOR", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["IDKREDITOR"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowOBRACUNKrediti["NAZIVKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowOBRACUNKrediti["VBDIKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowOBRACUNKrediti["ZRNKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowOBRACUNKrediti["PRIMATELJKREDITOR1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowOBRACUNKrediti["PRIMATELJKREDITOR2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowOBRACUNKrediti["PRIMATELJKREDITOR3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
            }
            reader.Close();
        }

        private void OnDeleteControlsObracunobracunlevel1obracunkrizni()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVKRIZNIPOREZ], [KRIZNISTOPA], [MOKRIZNI], [POKRIZNI], [MZKRIZNI], [PZKRIZNI], [PRIMATELJKRIZNI1], [PRIMATELJKRIZNI2], [PRIMATELJKRIZNI3], [SIFRAOPISAPLACANJAKRIZNI], [OPISPLACANJAKRIZNI], [VBDIKRIZNI], [ZRNKRIZNI] FROM [KRIZNIPOREZ] WITH (NOLOCK) WHERE [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDKRIZNIPOREZ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["NAZIVKRIZNIPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["KRIZNISTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["MOKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["MZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PRIMATELJKRIZNI1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PRIMATELJKRIZNI2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PRIMATELJKRIZNI3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["SIFRAOPISAPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OPISPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["VBDIKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["ZRNKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12));
            }
            reader.Close();
        }

        private void OnDeleteControlsObracunobustave()
        {
            this.StandaloneModalObracunobustave();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVOBUSTAVA], [MOOBUSTAVA], [POOBUSTAVA], [MZOBUSTAVA], [PZOBUSTAVA], [VBDIOBUSTAVA], [ZRNOBUSTAVA], [PRIMATELJOBUSTAVA1], [PRIMATELJOBUSTAVA2], [PRIMATELJOBUSTAVA3], [SIFRAOPISAPLACANJAOBUSTAVA], [OPISPLACANJAOBUSTAVA], [VRSTAOBUSTAVE] FROM [OBUSTAVA] WITH (NOLOCK) WHERE [IDOBUSTAVA] = @IDOBUSTAVA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBUSTAVA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IDOBUSTAVA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowOBRACUNObustave["NAZIVOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowOBRACUNObustave["MOOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowOBRACUNObustave["POOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowOBRACUNObustave["MZOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowOBRACUNObustave["PZOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowOBRACUNObustave["VBDIOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowOBRACUNObustave["ZRNOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowOBRACUNObustave["PRIMATELJOBUSTAVA1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowOBRACUNObustave["PRIMATELJOBUSTAVA2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowOBRACUNObustave["PRIMATELJOBUSTAVA3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowOBRACUNObustave["SIFRAOPISAPLACANJAOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
                this.rowOBRACUNObustave["OPISPLACANJAOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
                this.rowOBRACUNObustave["VRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 12));
            }
            reader.Close();
            if (!this.rowOBRACUNObustave.IsVRSTAOBUSTAVENull())
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVVRSTAOBUSTAVE] FROM [VRSTEOBUSTAVA] WITH (NOLOCK) WHERE [VRSTAOBUSTAVE] = @VRSTAOBUSTAVE ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
                }
                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["VRSTAOBUSTAVE"]));
                IDataReader reader2 = command2.FetchData();
                if (command2.HasMoreRows)
                {
                    this.rowOBRACUNObustave["NAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                }
                reader2.Close();
            }
            else
            {
                this.rowOBRACUNObustave["NAZIVVRSTAOBUSTAVE"] = "";
            }
        }

        private void OnDeleteControlsObracunolaksice()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVOLAKSICE], [IDGRUPEOLAKSICA], [IDTIPOLAKSICE], [VBDIOLAKSICA], [ZRNOLAKSICA], [PRIMATELJOLAKSICA1], [PRIMATELJOLAKSICA2], [PRIMATELJOLAKSICA3] FROM [OLAKSICE] WITH (NOLOCK) WHERE [IDOLAKSICE] = @IDOLAKSICE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOLAKSICE", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDOLAKSICE"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowObracunOlaksice["NAZIVOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                this.rowObracunOlaksice["IDGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader2, 1));
                this.rowObracunOlaksice["IDTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader2, 2));
                this.rowObracunOlaksice["VBDIOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 3));
                this.rowObracunOlaksice["ZRNOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 4));
                this.rowObracunOlaksice["PRIMATELJOLAKSICA1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 5));
                this.rowObracunOlaksice["PRIMATELJOLAKSICA2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 6));
                this.rowObracunOlaksice["PRIMATELJOLAKSICA3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 7));
            }
            reader2.Close();
            if (!this.rowObracunOlaksice.IsIDGRUPEOLAKSICANull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVGRUPEOLAKSICA], [MAXIMALNIIZNOSGRUPE] FROM [GRUPEOLAKSICA] WITH (NOLOCK) WHERE [IDGRUPEOLAKSICA] = @IDGRUPEOLAKSICA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDGRUPEOLAKSICA"]));
                IDataReader reader = command.FetchData();
                if (command.HasMoreRows)
                {
                    this.rowObracunOlaksice["NAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                    this.rowObracunOlaksice["MAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
                }
                reader.Close();
            }
            else
            {
                this.rowObracunOlaksice["NAZIVGRUPEOLAKSICA"] = "";
                this.rowObracunOlaksice["MAXIMALNIIZNOSGRUPE"] = 0;
            }
            if (!this.rowObracunOlaksice.IsIDTIPOLAKSICENull())
            {
                ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVTIPOLAKSICE] FROM [TIPOLAKSICE] WITH (NOLOCK) WHERE [IDTIPOLAKSICE] = @IDTIPOLAKSICE ", false);
                if (command3.IDbCommand.Parameters.Count == 0)
                {
                    command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
                }
                command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDTIPOLAKSICE"]));
                IDataReader reader3 = command3.FetchData();
                if (command3.HasMoreRows)
                {
                    this.rowObracunOlaksice["NAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0));
                }
                reader3.Close();
            }
            else
            {
                this.rowObracunOlaksice["NAZIVTIPOLAKSICE"] = "";
            }
        }

        private void OnDeleteControlsObracunporezi()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], [MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ] FROM [POREZ] WITH (NOLOCK) WHERE [IDPOREZ] = @IDPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["IDPOREZ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowObracunPorezi["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowObracunPorezi["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
                this.rowObracunPorezi["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
                this.rowObracunPorezi["MOPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowObracunPorezi["POPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowObracunPorezi["MZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowObracunPorezi["PZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowObracunPorezi["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowObracunPorezi["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowObracunPorezi["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowObracunPorezi["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
            }
            reader.Close();
        }

        private void OnDeleteControlsObracunradnici()
        {
            ReadWriteCommand command6 = this.connDefault.GetCommand("SELECT [PREZIME], [IME], [ulica], [mjesto], [kucnibroj], [JMBG], [DATUMRODJENJA], [TEKUCI], [SIFRAOPISAPLACANJANETO], [OPISPLACANJANETO], [BROJMIROVINSKOG], [BROJZDRAVSTVENOG], [MBO], [POSTOTAKOSLOBODJENJAODPOREZA], [KOEFICIJENT], [AKTIVAN], [DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], [TJEDNIFONDSATI], [TJEDNIFONDSATISTAZ], [GODINESTAZA], [MJESECISTAZA], [DANISTAZA], [DATUMPRESTANKARADNOGODNOSA], [ZBIRNINETO], [UZIMAUOBZIROSNOVICEDOPRINOSA], [IDIPIDENT], [OIB], [IDBANKE], [IDBENEFICIRANI], [IDTITULA], [IDRADNOMJESTO], [IDSTRUKA], [IDORGDIO], [OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, [OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, [POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, [TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (command6.IDbCommand.Parameters.Count == 0)
            {
                command6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDRADNIK"]));
            IDataReader reader6 = command6.FetchData();
            if (command6.HasMoreRows)
            {
                this.rowObracunRadnici["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 0));
                this.rowObracunRadnici["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 1));
                this.rowObracunRadnici["ulica"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 2));
                this.rowObracunRadnici["mjesto"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 3));
                this.rowObracunRadnici["kucnibroj"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 4));
                this.rowObracunRadnici["JMBG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 5));
                this.rowObracunRadnici["DATUMRODJENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader6, 6));
                this.rowObracunRadnici["TEKUCI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 7));
                this.rowObracunRadnici["SIFRAOPISAPLACANJANETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 8));
                this.rowObracunRadnici["OPISPLACANJANETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 9));
                this.rowObracunRadnici["BROJMIROVINSKOG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 10));
                this.rowObracunRadnici["BROJZDRAVSTVENOG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 11));
                this.rowObracunRadnici["MBO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 12));
                this.rowObracunRadnici["POSTOTAKOSLOBODJENJAODPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader6, 13));
                this.rowObracunRadnici["KOEFICIJENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader6, 14));
                this.rowObracunRadnici["AKTIVAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader6, 15));
                this.rowObracunRadnici["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader6, 0x10));
                this.rowObracunRadnici["TJEDNIFONDSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader6, 0x11));
                this.rowObracunRadnici["TJEDNIFONDSATISTAZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader6, 0x12));
                this.rowObracunRadnici["GODINESTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader6, 0x13));
                this.rowObracunRadnici["MJESECISTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader6, 20));
                this.rowObracunRadnici["DANISTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader6, 0x15));
                this.rowObracunRadnici["DATUMPRESTANKARADNOGODNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader6, 0x16));
                this.rowObracunRadnici["ZBIRNINETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader6, 0x17));
                this.rowObracunRadnici["UZIMAUOBZIROSNOVICEDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader6, 0x18));
                this.rowObracunRadnici["IDIPIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader6, 0x19));
                this.rowObracunRadnici["OIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 0x1a));
                this.rowObracunRadnici["IDBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader6, 0x1b));
                this.rowObracunRadnici["IDBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 0x1c));
                this.rowObracunRadnici["IDTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader6, 0x1d));
                this.rowObracunRadnici["IDRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader6, 30));
                this.rowObracunRadnici["IDSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader6, 0x1f));
                this.rowObracunRadnici["IDORGDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader6, 0x20));
                this.rowObracunRadnici["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 0x21));
                this.rowObracunRadnici["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 0x22));
                this.rowObracunRadnici["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader6, 0x23));
                this.rowObracunRadnici["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader6, 0x24));
                this.rowObracunRadnici["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader6, 0x25));
            }
            reader6.Close();
            if (!this.rowObracunRadnici.IsIDBANKENull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVBANKE1], [NAZIVBANKE2], [NAZIVBANKE3], [VBDIBANKE], [ZRNBANKE] FROM [BANKE] WITH (NOLOCK) WHERE [IDBANKE] = @IDBANKE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDBANKE"]));
                IDataReader reader = command.FetchData();
                if (command.HasMoreRows)
                {
                    this.rowObracunRadnici["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                    this.rowObracunRadnici["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                    this.rowObracunRadnici["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                    this.rowObracunRadnici["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                    this.rowObracunRadnici["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                }
                reader.Close();
            }
            else
            {
                this.rowObracunRadnici["NAZIVBANKE1"] = "";
                this.rowObracunRadnici["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowObracunRadnici["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowObracunRadnici["VBDIBANKE"] = "";
                this.rowObracunRadnici["ZRNBANKE"] = "";
            }
            if (!this.rowObracunRadnici.IsIDBENEFICIRANINull())
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVBENEFICIRANI], [BROJPRIZNATIHMJESECI] FROM [BENEFICIRANI] WITH (NOLOCK) WHERE [IDBENEFICIRANI] = @IDBENEFICIRANI ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
                }
                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDBENEFICIRANI"]));
                IDataReader reader2 = command2.FetchData();
                if (command2.HasMoreRows)
                {
                    this.rowObracunRadnici["NAZIVBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                    this.rowObracunRadnici["BROJPRIZNATIHMJESECI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader2, 1));
                }
                reader2.Close();
            }
            else
            {
                this.rowObracunRadnici["NAZIVBENEFICIRANI"] = "";
                this.rowObracunRadnici["BROJPRIZNATIHMJESECI"] = 0;
            }
            if (!this.rowObracunRadnici.IsIDTITULANull())
            {
                ReadWriteCommand command12 = this.connDefault.GetCommand("SELECT [NAZIVTITULA] FROM [TITULA] WITH (NOLOCK) WHERE [IDTITULA] = @IDTITULA ", false);
                if (command12.IDbCommand.Parameters.Count == 0)
                {
                    command12.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
                }
                command12.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDTITULA"]));
                IDataReader reader12 = command12.FetchData();
                if (command12.HasMoreRows)
                {
                    this.rowObracunRadnici["NAZIVTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader12, 0));
                }
                reader12.Close();
            }
            else
            {
                this.rowObracunRadnici["NAZIVTITULA"] = "";
            }
            if (!this.rowObracunRadnici.IsIDRADNOMJESTONull())
            {
                ReadWriteCommand command7 = this.connDefault.GetCommand("SELECT [NAZIVRADNOMJESTO] FROM [RADNOMJESTO] WITH (NOLOCK) WHERE [IDRADNOMJESTO] = @IDRADNOMJESTO ", false);
                if (command7.IDbCommand.Parameters.Count == 0)
                {
                    command7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
                }
                command7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDRADNOMJESTO"]));
                IDataReader reader7 = command7.FetchData();
                if (command7.HasMoreRows)
                {
                    this.rowObracunRadnici["NAZIVRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader7, 0));
                }
                reader7.Close();
            }
            else
            {
                this.rowObracunRadnici["NAZIVRADNOMJESTO"] = "";
            }
            if (!this.rowObracunRadnici.IsIDSTRUKANull())
            {
                ReadWriteCommand command11 = this.connDefault.GetCommand("SELECT [NAZIVSTRUKA] FROM [STRUKA] WITH (NOLOCK) WHERE [IDSTRUKA] = @IDSTRUKA ", false);
                if (command11.IDbCommand.Parameters.Count == 0)
                {
                    command11.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
                }
                command11.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDSTRUKA"]));
                IDataReader reader11 = command11.FetchData();
                if (command11.HasMoreRows)
                {
                    this.rowObracunRadnici["NAZIVSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader11, 0));
                }
                reader11.Close();
            }
            else
            {
                this.rowObracunRadnici["NAZIVSTRUKA"] = "";
            }
            if (!this.rowObracunRadnici.IsIDORGDIONull())
            {
                ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT [ORGANIZACIJSKIDIO] FROM [ORGDIO] WITH (NOLOCK) WHERE [IDORGDIO] = @IDORGDIO ", false);
                if (command5.IDbCommand.Parameters.Count == 0)
                {
                    command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
                }
                command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDORGDIO"]));
                IDataReader reader5 = command5.FetchData();
                if (command5.HasMoreRows)
                {
                    this.rowObracunRadnici["ORGANIZACIJSKIDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader5, 0));
                }
                reader5.Close();
            }
            else
            {
                this.rowObracunRadnici["ORGANIZACIJSKIDIO"] = "";
            }
            if (!this.rowObracunRadnici.IsOPCINARADAIDOPCINENull())
            {
                ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, [PRIREZ] AS OPCINARADAPRIREZ FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINARADAIDOPCINE ", false);
                if (command3.IDbCommand.Parameters.Count == 0)
                {
                    command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
                }
                command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["OPCINARADAIDOPCINE"]));
                IDataReader reader3 = command3.FetchData();
                if (command3.HasMoreRows)
                {
                    this.rowObracunRadnici["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0));
                    this.rowObracunRadnici["OPCINARADAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader3, 1));
                }
                reader3.Close();
            }
            else
            {
                this.rowObracunRadnici["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowObracunRadnici["OPCINARADAPRIREZ"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowObracunRadnici.IsOPCINASTANOVANJAIDOPCINENull())
            {
                ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, [PRIREZ] AS OPCINASTANOVANJAPRIREZ FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINASTANOVANJAIDOPCINE ", false);
                if (command4.IDbCommand.Parameters.Count == 0)
                {
                    command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
                }
                command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["OPCINASTANOVANJAIDOPCINE"]));
                IDataReader reader4 = command4.FetchData();
                if (command4.HasMoreRows)
                {
                    this.rowObracunRadnici["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader4, 0));
                    this.rowObracunRadnici["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader4, 1));
                }
                reader4.Close();
            }
            else
            {
                this.rowObracunRadnici["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowObracunRadnici["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowObracunRadnici.IsRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSANull())
            {
                ReadWriteCommand command8 = this.connDefault.GetCommand("SELECT [NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA FROM [SKUPPOREZAIDOPRINOSA] WITH (NOLOCK) WHERE [IDSKUPPOREZAIDOPRINOSA] = @RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA ", false);
                if (command8.IDbCommand.Parameters.Count == 0)
                {
                    command8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", DbType.Int32));
                }
                command8.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]));
                IDataReader reader8 = command8.FetchData();
                if (command8.HasMoreRows)
                {
                    this.rowObracunRadnici["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader8, 0));
                }
                reader8.Close();
            }
            else
            {
                this.rowObracunRadnici["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowObracunRadnici.IsPOTREBNASTRUCNASPREMAIDSTRUCNASPREMANull())
            {
                ReadWriteCommand command9 = this.connDefault.GetCommand("SELECT [NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA FROM [STRUCNASPREMA] WITH (NOLOCK) WHERE [IDSTRUCNASPREMA] = @POTREBNASTRUCNASPREMAIDSTRUCNASPREMA ", false);
                if (command9.IDbCommand.Parameters.Count == 0)
                {
                    command9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POTREBNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
                }
                command9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"]));
                IDataReader reader9 = command9.FetchData();
                if (command9.HasMoreRows)
                {
                    this.rowObracunRadnici["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader9, 0));
                }
                reader9.Close();
            }
            else
            {
                this.rowObracunRadnici["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowObracunRadnici.IsTRENUTNASTRUCNASPREMAIDSTRUCNASPREMANull())
            {
                ReadWriteCommand command10 = this.connDefault.GetCommand("SELECT [NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA FROM [STRUCNASPREMA] WITH (NOLOCK) WHERE [IDSTRUCNASPREMA] = @TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA ", false);
                if (command10.IDbCommand.Parameters.Count == 0)
                {
                    command10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
                }
                command10.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"]));
                IDataReader reader10 = command10.FetchData();
                if (command10.HasMoreRows)
                {
                    this.rowObracunRadnici["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader10, 0));
                }
                reader10.Close();
            }
            else
            {
                this.rowObracunRadnici["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if ((!this.rowOBRACUN.IsDATUMOBRACUNASTAZANull() && !this.rowOBRACUN.IstjednifondsatiobracunNull()) && !this.rowObracunRadnici.IsBROJPRIZNATIHMJESECINull())
            {
                this.rowObracunRadnici.POSTOTAKNASTAZ = placa.PovecanjeKoeficijentaZaStaz(this.rowObracunRadnici.IDRADNIK, this.rowOBRACUN.DATUMOBRACUNASTAZA, new decimal(this.rowOBRACUN.tjednifondsatiobracun), this.rowObracunRadnici.BROJPRIZNATIHMJESECI, Configuration.ConnectionString.ToString());
            }
        }

        private void OnLoadActionsObracunradnici()
        {
            if ((!this.rowOBRACUN.IsDATUMOBRACUNASTAZANull() && !this.rowOBRACUN.IstjednifondsatiobracunNull()) && !this.rowObracunRadnici.IsBROJPRIZNATIHMJESECINull())
            {
                this.rowObracunRadnici.POSTOTAKNASTAZ = placa.PovecanjeKoeficijentaZaStaz(this.rowObracunRadnici.IDRADNIK, this.rowOBRACUN.DATUMOBRACUNASTAZA, new decimal(this.rowOBRACUN.tjednifondsatiobracun), this.rowObracunRadnici.BROJPRIZNATIHMJESECI, Configuration.ConnectionString.ToString());
            }
        }

        private void OnObracunDoprinosiUpdated(ObracunDoprinosiEventArgs e)
        {
            if (this.ObracunDoprinosiUpdated != null)
            {
                ObracunDoprinosiUpdateEventHandler obracunDoprinosiUpdatedEvent = this.ObracunDoprinosiUpdated;
                if (obracunDoprinosiUpdatedEvent != null)
                {
                    obracunDoprinosiUpdatedEvent(this, e);
                }
            }
        }

        private void OnObracunDoprinosiUpdating(ObracunDoprinosiEventArgs e)
        {
            if (this.ObracunDoprinosiUpdating != null)
            {
                ObracunDoprinosiUpdateEventHandler obracunDoprinosiUpdatingEvent = this.ObracunDoprinosiUpdating;
                if (obracunDoprinosiUpdatingEvent != null)
                {
                    obracunDoprinosiUpdatingEvent(this, e);
                }
            }
        }

        private void OnObracunElementiUpdated(ObracunElementiEventArgs e)
        {
            if (this.ObracunElementiUpdated != null)
            {
                ObracunElementiUpdateEventHandler obracunElementiUpdatedEvent = this.ObracunElementiUpdated;
                if (obracunElementiUpdatedEvent != null)
                {
                    obracunElementiUpdatedEvent(this, e);
                }
            }
        }

        private void OnObracunElementiUpdating(ObracunElementiEventArgs e)
        {
            if (this.ObracunElementiUpdating != null)
            {
                ObracunElementiUpdateEventHandler obracunElementiUpdatingEvent = this.ObracunElementiUpdating;
                if (obracunElementiUpdatingEvent != null)
                {
                    obracunElementiUpdatingEvent(this, e);
                }
            }
        }

        private void OnOBRACUNKreditiUpdated(OBRACUNKreditiEventArgs e)
        {
            if (this.OBRACUNKreditiUpdated != null)
            {
                OBRACUNKreditiUpdateEventHandler oBRACUNKreditiUpdatedEvent = this.OBRACUNKreditiUpdated;
                if (oBRACUNKreditiUpdatedEvent != null)
                {
                    oBRACUNKreditiUpdatedEvent(this, e);
                }
            }
        }

        private void OnOBRACUNKreditiUpdating(OBRACUNKreditiEventArgs e)
        {
            if (this.OBRACUNKreditiUpdating != null)
            {
                OBRACUNKreditiUpdateEventHandler oBRACUNKreditiUpdatingEvent = this.OBRACUNKreditiUpdating;
                if (oBRACUNKreditiUpdatingEvent != null)
                {
                    oBRACUNKreditiUpdatingEvent(this, e);
                }
            }
        }

        private void OnOBRACUNOBRACUNLevel1ObracunIzuzeceUpdated(OBRACUNOBRACUNLevel1ObracunIzuzeceEventArgs e)
        {
            if (this.OBRACUNOBRACUNLevel1ObracunIzuzeceUpdated != null)
            {
                OBRACUNOBRACUNLevel1ObracunIzuzeceUpdateEventHandler handler = this.OBRACUNOBRACUNLevel1ObracunIzuzeceUpdated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnOBRACUNOBRACUNLevel1ObracunIzuzeceUpdating(OBRACUNOBRACUNLevel1ObracunIzuzeceEventArgs e)
        {
            if (this.OBRACUNOBRACUNLevel1ObracunIzuzeceUpdating != null)
            {
                OBRACUNOBRACUNLevel1ObracunIzuzeceUpdateEventHandler handler = this.OBRACUNOBRACUNLevel1ObracunIzuzeceUpdating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnOBRACUNOBRACUNLevel1ObracunKrizniUpdated(OBRACUNOBRACUNLevel1ObracunKrizniEventArgs e)
        {
            if (this.OBRACUNOBRACUNLevel1ObracunKrizniUpdated != null)
            {
                OBRACUNOBRACUNLevel1ObracunKrizniUpdateEventHandler handler = this.OBRACUNOBRACUNLevel1ObracunKrizniUpdated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnOBRACUNOBRACUNLevel1ObracunKrizniUpdating(OBRACUNOBRACUNLevel1ObracunKrizniEventArgs e)
        {
            if (this.OBRACUNOBRACUNLevel1ObracunKrizniUpdating != null)
            {
                OBRACUNOBRACUNLevel1ObracunKrizniUpdateEventHandler handler = this.OBRACUNOBRACUNLevel1ObracunKrizniUpdating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnOBRACUNObustaveUpdated(OBRACUNObustaveEventArgs e)
        {
            if (this.OBRACUNObustaveUpdated != null)
            {
                OBRACUNObustaveUpdateEventHandler oBRACUNObustaveUpdatedEvent = this.OBRACUNObustaveUpdated;
                if (oBRACUNObustaveUpdatedEvent != null)
                {
                    oBRACUNObustaveUpdatedEvent(this, e);
                }
            }
        }

        private void OnOBRACUNObustaveUpdating(OBRACUNObustaveEventArgs e)
        {
            if (this.OBRACUNObustaveUpdating != null)
            {
                OBRACUNObustaveUpdateEventHandler oBRACUNObustaveUpdatingEvent = this.OBRACUNObustaveUpdating;
                if (oBRACUNObustaveUpdatingEvent != null)
                {
                    oBRACUNObustaveUpdatingEvent(this, e);
                }
            }
        }

        private void OnObracunOlaksiceUpdated(ObracunOlaksiceEventArgs e)
        {
            if (this.ObracunOlaksiceUpdated != null)
            {
                ObracunOlaksiceUpdateEventHandler obracunOlaksiceUpdatedEvent = this.ObracunOlaksiceUpdated;
                if (obracunOlaksiceUpdatedEvent != null)
                {
                    obracunOlaksiceUpdatedEvent(this, e);
                }
            }
        }

        private void OnObracunOlaksiceUpdating(ObracunOlaksiceEventArgs e)
        {
            if (this.ObracunOlaksiceUpdating != null)
            {
                ObracunOlaksiceUpdateEventHandler obracunOlaksiceUpdatingEvent = this.ObracunOlaksiceUpdating;
                if (obracunOlaksiceUpdatingEvent != null)
                {
                    obracunOlaksiceUpdatingEvent(this, e);
                }
            }
        }

        private void OnObracunPoreziUpdated(ObracunPoreziEventArgs e)
        {
            if (this.ObracunPoreziUpdated != null)
            {
                ObracunPoreziUpdateEventHandler obracunPoreziUpdatedEvent = this.ObracunPoreziUpdated;
                if (obracunPoreziUpdatedEvent != null)
                {
                    obracunPoreziUpdatedEvent(this, e);
                }
            }
        }

        private void OnObracunPoreziUpdating(ObracunPoreziEventArgs e)
        {
            if (this.ObracunPoreziUpdating != null)
            {
                ObracunPoreziUpdateEventHandler obracunPoreziUpdatingEvent = this.ObracunPoreziUpdating;
                if (obracunPoreziUpdatingEvent != null)
                {
                    obracunPoreziUpdatingEvent(this, e);
                }
            }
        }

        private void OnObracunRadniciUpdated(ObracunRadniciEventArgs e)
        {
            if (this.ObracunRadniciUpdated != null)
            {
                ObracunRadniciUpdateEventHandler obracunRadniciUpdatedEvent = this.ObracunRadniciUpdated;
                if (obracunRadniciUpdatedEvent != null)
                {
                    obracunRadniciUpdatedEvent(this, e);
                }
            }
        }

        private void OnObracunRadniciUpdating(ObracunRadniciEventArgs e)
        {
            if (this.ObracunRadniciUpdating != null)
            {
                ObracunRadniciUpdateEventHandler obracunRadniciUpdatingEvent = this.ObracunRadniciUpdating;
                if (obracunRadniciUpdatingEvent != null)
                {
                    obracunRadniciUpdatingEvent(this, e);
                }
            }
        }

        private void OnOBRACUNUpdated(OBRACUNEventArgs e)
        {
            if (this.OBRACUNUpdated != null)
            {
                OBRACUNUpdateEventHandler oBRACUNUpdatedEvent = this.OBRACUNUpdated;
                if (oBRACUNUpdatedEvent != null)
                {
                    oBRACUNUpdatedEvent(this, e);
                }
            }
        }

        private void OnOBRACUNUpdating(OBRACUNEventArgs e)
        {
            if (this.OBRACUNUpdating != null)
            {
                OBRACUNUpdateEventHandler oBRACUNUpdatingEvent = this.OBRACUNUpdating;
                if (oBRACUNUpdatingEvent != null)
                {
                    oBRACUNUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelObracun()
        {
            this.sMode9 = this.Gx_mode;
            this.ProcessNestedLevelObracunradnici();
            this.Gx_mode = this.sMode9;
        }

        private void ProcessLevelObracunradnici()
        {
            this.sMode10 = this.Gx_mode;
            this.ProcessNestedLevelObracundoprinosi();
            this.ProcessNestedLevelObracunporezi();
            this.ProcessNestedLevelObracunolaksice();
            this.ProcessNestedLevelObracunkrediti();
            this.ProcessNestedLevelObracunobustave();
            this.ProcessNestedLevelObracunelementi();
            this.ProcessNestedLevelObracunobracunlevel1obracunkrizni();
            this.ProcessNestedLevelObracunobracunlevel1obracunizuzece();
            this.Gx_mode = this.sMode10;
        }

        private void ProcessNestedLevelObracundoprinosi()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.OBRACUNSet.ObracunDoprinosi.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowObracunDoprinosi = (OBRACUNDataSet.ObracunDoprinosiRow) current;
                    if (Helpers.IsRowChanged(this.rowObracunDoprinosi))
                    {
                        bool flag = false;
                        if (this.rowObracunDoprinosi.RowState != DataRowState.Deleted)
                        {
                            flag = (string.Compare(this.rowObracunDoprinosi.IDOBRACUN.TrimEnd(new char[] { ' ' }), this.rowObracunRadnici.IDOBRACUN.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0) && (this.rowObracunDoprinosi.IDRADNIK == this.rowObracunRadnici.IDRADNIK);
                        }
                        else
                        {
                            flag = this.rowObracunDoprinosi["IDOBRACUN", DataRowVersion.Original].Equals(this.rowObracunRadnici.IDOBRACUN) && this.rowObracunDoprinosi["IDRADNIK", DataRowVersion.Original].Equals(this.rowObracunRadnici.IDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowObracundoprinosi();
                            if (this.rowObracunDoprinosi.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertObracundoprinosi();
                            }
                            else
                            {
                                if (this._Gxremove179)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteObracundoprinosi();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateObracundoprinosi();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ProcessNestedLevelObracunelementi()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.OBRACUNSet.ObracunElementi.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowObracunElementi = (OBRACUNDataSet.ObracunElementiRow) current;
                    if (Helpers.IsRowChanged(this.rowObracunElementi))
                    {
                        bool flag = false;
                        if (this.rowObracunElementi.RowState != DataRowState.Deleted)
                        {
                            this.rowObracunElementi["ELEMENTRAZDOBLJEOD"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowObracunElementi["ELEMENTRAZDOBLJEOD"])));
                            this.rowObracunElementi["ELEMENTRAZDOBLJEDO"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowObracunElementi["ELEMENTRAZDOBLJEDO"])));
                        }
                        if (this.rowObracunElementi.RowState != DataRowState.Deleted)
                        {
                            flag = (string.Compare(this.rowObracunElementi.IDOBRACUN.TrimEnd(new char[] { ' ' }), this.rowObracunRadnici.IDOBRACUN.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0) && (this.rowObracunElementi.IDRADNIK == this.rowObracunRadnici.IDRADNIK);
                        }
                        else
                        {
                            flag = this.rowObracunElementi["IDOBRACUN", DataRowVersion.Original].Equals(this.rowObracunRadnici.IDOBRACUN) && this.rowObracunElementi["IDRADNIK", DataRowVersion.Original].Equals(this.rowObracunRadnici.IDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowObracunelementi();
                            if (this.rowObracunElementi.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertObracunelementi();
                            }
                            else
                            {
                                if (this._Gxremove281)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteObracunelementi();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateObracunelementi();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ProcessNestedLevelObracunkrediti()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.OBRACUNSet.OBRACUNKrediti.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowOBRACUNKrediti = (OBRACUNDataSet.OBRACUNKreditiRow) current;
                    if (Helpers.IsRowChanged(this.rowOBRACUNKrediti))
                    {
                        bool flag = false;
                        if (this.rowOBRACUNKrediti.RowState != DataRowState.Deleted)
                        {
                            this.rowOBRACUNKrediti["DATUMUGOVORA"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["DATUMUGOVORA"])));
                        }
                        if (this.rowOBRACUNKrediti.RowState != DataRowState.Deleted)
                        {
                            flag = (string.Compare(this.rowOBRACUNKrediti.IDOBRACUN.TrimEnd(new char[] { ' ' }), this.rowObracunRadnici.IDOBRACUN.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0) && (this.rowOBRACUNKrediti.IDRADNIK == this.rowObracunRadnici.IDRADNIK);
                        }
                        else
                        {
                            flag = this.rowOBRACUNKrediti["IDOBRACUN", DataRowVersion.Original].Equals(this.rowObracunRadnici.IDOBRACUN) && this.rowOBRACUNKrediti["IDRADNIK", DataRowVersion.Original].Equals(this.rowObracunRadnici.IDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowObracunkrediti();
                            if (this.rowOBRACUNKrediti.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertObracunkrediti();
                            }
                            else
                            {
                                if (this._Gxremove235)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteObracunkrediti();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateObracunkrediti();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ProcessNestedLevelObracunobracunlevel1obracunizuzece()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.OBRACUNSet.OBRACUNOBRACUNLevel1ObracunIzuzece.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowOBRACUNOBRACUNLevel1ObracunIzuzece = (OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow) current;
                    if (Helpers.IsRowChanged(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece))
                    {
                        bool flag = false;
                        if (this.rowOBRACUNOBRACUNLevel1ObracunIzuzece.RowState != DataRowState.Deleted)
                        {
                            flag = (string.Compare(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece.IDOBRACUN.TrimEnd(new char[] { ' ' }), this.rowObracunRadnici.IDOBRACUN.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0) && (this.rowOBRACUNOBRACUNLevel1ObracunIzuzece.IDRADNIK == this.rowObracunRadnici.IDRADNIK);
                        }
                        else
                        {
                            flag = this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDOBRACUN", DataRowVersion.Original].Equals(this.rowObracunRadnici.IDOBRACUN) && this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDRADNIK", DataRowVersion.Original].Equals(this.rowObracunRadnici.IDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowObracunobracunlevel1obracunizuzece();
                            if (this.rowOBRACUNOBRACUNLevel1ObracunIzuzece.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertObracunobracunlevel1obracunizuzece();
                            }
                            else
                            {
                                if (this._Gxremove317)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteObracunobracunlevel1obracunizuzece();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateObracunobracunlevel1obracunizuzece();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ProcessNestedLevelObracunobracunlevel1obracunkrizni()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.OBRACUNSet.OBRACUNOBRACUNLevel1ObracunKrizni.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowOBRACUNOBRACUNLevel1ObracunKrizni = (OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow) current;
                    if (Helpers.IsRowChanged(this.rowOBRACUNOBRACUNLevel1ObracunKrizni))
                    {
                        bool flag = false;
                        if (this.rowOBRACUNOBRACUNLevel1ObracunKrizni.RowState != DataRowState.Deleted)
                        {
                            flag = (string.Compare(this.rowOBRACUNOBRACUNLevel1ObracunKrizni.IDOBRACUN.TrimEnd(new char[] { ' ' }), this.rowObracunRadnici.IDOBRACUN.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0) && (this.rowOBRACUNOBRACUNLevel1ObracunKrizni.IDRADNIK == this.rowObracunRadnici.IDRADNIK);
                        }
                        else
                        {
                            flag = this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDOBRACUN", DataRowVersion.Original].Equals(this.rowObracunRadnici.IDOBRACUN) && this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDRADNIK", DataRowVersion.Original].Equals(this.rowObracunRadnici.IDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowObracunobracunlevel1obracunkrizni();
                            if (this.rowOBRACUNOBRACUNLevel1ObracunKrizni.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertObracunobracunlevel1obracunkrizni();
                            }
                            else
                            {
                                if (this._Gxremove296)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteObracunobracunlevel1obracunkrizni();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateObracunobracunlevel1obracunkrizni();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ProcessNestedLevelObracunobustave()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.OBRACUNSet.OBRACUNObustave.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowOBRACUNObustave = (OBRACUNDataSet.OBRACUNObustaveRow) current;
                    if (Helpers.IsRowChanged(this.rowOBRACUNObustave))
                    {
                        bool flag = false;
                        if (this.rowOBRACUNObustave.RowState != DataRowState.Deleted)
                        {
                            flag = (string.Compare(this.rowOBRACUNObustave.IDOBRACUN.TrimEnd(new char[] { ' ' }), this.rowObracunRadnici.IDOBRACUN.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0) && (this.rowOBRACUNObustave.IDRADNIK == this.rowObracunRadnici.IDRADNIK);
                        }
                        else
                        {
                            flag = this.rowOBRACUNObustave["IDOBRACUN", DataRowVersion.Original].Equals(this.rowObracunRadnici.IDOBRACUN) && this.rowOBRACUNObustave["IDRADNIK", DataRowVersion.Original].Equals(this.rowObracunRadnici.IDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowObracunobustave();
                            if (this.rowOBRACUNObustave.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertObracunobustave();
                            }
                            else
                            {
                                if (this._Gxremove257)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteObracunobustave();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateObracunobustave();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ProcessNestedLevelObracunolaksice()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.OBRACUNSet.ObracunOlaksice.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowObracunOlaksice = (OBRACUNDataSet.ObracunOlaksiceRow) current;
                    if (Helpers.IsRowChanged(this.rowObracunOlaksice))
                    {
                        bool flag = false;
                        if (this.rowObracunOlaksice.RowState != DataRowState.Deleted)
                        {
                            flag = (string.Compare(this.rowObracunOlaksice.IDOBRACUN.TrimEnd(new char[] { ' ' }), this.rowObracunRadnici.IDOBRACUN.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0) && (this.rowObracunOlaksice.IDRADNIK == this.rowObracunRadnici.IDRADNIK);
                        }
                        else
                        {
                            flag = this.rowObracunOlaksice["IDOBRACUN", DataRowVersion.Original].Equals(this.rowObracunRadnici.IDOBRACUN) && this.rowObracunOlaksice["IDRADNIK", DataRowVersion.Original].Equals(this.rowObracunRadnici.IDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowObracunolaksice();
                            if (this.rowObracunOlaksice.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertObracunolaksice();
                            }
                            else
                            {
                                if (this._Gxremove214)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteObracunolaksice();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateObracunolaksice();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ProcessNestedLevelObracunporezi()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.OBRACUNSet.ObracunPorezi.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowObracunPorezi = (OBRACUNDataSet.ObracunPoreziRow) current;
                    if (Helpers.IsRowChanged(this.rowObracunPorezi))
                    {
                        bool flag = false;
                        if (this.rowObracunPorezi.RowState != DataRowState.Deleted)
                        {
                            flag = (string.Compare(this.rowObracunPorezi.IDOBRACUN.TrimEnd(new char[] { ' ' }), this.rowObracunRadnici.IDOBRACUN.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0) && (this.rowObracunPorezi.IDRADNIK == this.rowObracunRadnici.IDRADNIK);
                        }
                        else
                        {
                            flag = this.rowObracunPorezi["IDOBRACUN", DataRowVersion.Original].Equals(this.rowObracunRadnici.IDOBRACUN) && this.rowObracunPorezi["IDRADNIK", DataRowVersion.Original].Equals(this.rowObracunRadnici.IDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowObracunporezi();
                            if (this.rowObracunPorezi.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertObracunporezi();
                            }
                            else
                            {
                                if (this._Gxremove199)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteObracunporezi();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateObracunporezi();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ProcessNestedLevelObracunradnici()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.OBRACUNSet.ObracunRadnici.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowObracunRadnici = (OBRACUNDataSet.ObracunRadniciRow) current;
                    if (Helpers.IsRowChanged(this.rowObracunRadnici))
                    {
                        bool flag = false;
                        if (this.rowObracunRadnici.RowState != DataRowState.Deleted)
                        {
                            flag = string.Compare(this.rowObracunRadnici.IDOBRACUN.TrimEnd(new char[] { ' ' }), this.rowOBRACUN.IDOBRACUN.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0;
                        }
                        else
                        {
                            flag = this.rowObracunRadnici["IDOBRACUN", DataRowVersion.Original].Equals(this.rowOBRACUN.IDOBRACUN);
                        }
                        if (flag)
                        {
                            this.ReadRowObracunradnici();
                            if (this.rowObracunRadnici.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertObracunradnici();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteObracunradnici();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateObracunradnici();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ReadRowObracun()
        {
            this.Gx_mode = Mode.FromRowState(this.rowOBRACUN.RowState);
            if (this.rowOBRACUN.RowState != DataRowState.Deleted)
            {
                this.rowOBRACUN["DATUMISPLATE"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowOBRACUN["DATUMISPLATE"])));
                this.rowOBRACUN["DATUMOBRACUNASTAZA"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowOBRACUN["DATUMOBRACUNASTAZA"])));
            }
            if (this.rowOBRACUN.RowState != DataRowState.Added)
            {
                this.m__VRSTAOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["VRSTAOBRACUNA", DataRowVersion.Original]);
                this.m__MJESECOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["MJESECOBRACUNA", DataRowVersion.Original]);
                this.m__GODINAOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["GODINAOBRACUNA", DataRowVersion.Original]);
                this.m__MJESECISPLATEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["MJESECISPLATE", DataRowVersion.Original]);
                this.m__GODINAISPLATEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["GODINAISPLATE", DataRowVersion.Original]);
                this.m__DATUMISPLATEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["DATUMISPLATE", DataRowVersion.Original]);
                this.m__tjednifondsatiobracunOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["tjednifondsatiobracun", DataRowVersion.Original]);
                this.m__MJESECNIFONDSATIOBRACUNOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["MJESECNIFONDSATIOBRACUN", DataRowVersion.Original]);
                this.m__OSNOVNIOOOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OSNOVNIOO", DataRowVersion.Original]);
                this.m__OBRACUNSKAOSNOVICAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OBRACUNSKAOSNOVICA", DataRowVersion.Original]);
                this.m__DATUMOBRACUNASTAZAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["DATUMOBRACUNASTAZA", DataRowVersion.Original]);
                this.m__OBRPOSTOTNIHOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OBRPOSTOTNIH", DataRowVersion.Original]);
                this.m__OBRFIKSNIHOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OBRFIKSNIH", DataRowVersion.Original]);
                this.m__OBRKREDITNIHOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OBRKREDITNIH", DataRowVersion.Original]);
                this.m__ZAKLJOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["ZAKLJ", DataRowVersion.Original]);
                this.m__SVRHAOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["SVRHAOBRACUNA", DataRowVersion.Original]);
            }
            else
            {
                this.m__VRSTAOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["VRSTAOBRACUNA"]);
                this.m__MJESECOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["MJESECOBRACUNA"]);
                this.m__GODINAOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["GODINAOBRACUNA"]);
                this.m__MJESECISPLATEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["MJESECISPLATE"]);
                this.m__GODINAISPLATEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["GODINAISPLATE"]);
                this.m__DATUMISPLATEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["DATUMISPLATE"]);
                this.m__tjednifondsatiobracunOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["tjednifondsatiobracun"]);
                this.m__MJESECNIFONDSATIOBRACUNOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["MJESECNIFONDSATIOBRACUN"]);
                this.m__OSNOVNIOOOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OSNOVNIOO"]);
                this.m__OBRACUNSKAOSNOVICAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OBRACUNSKAOSNOVICA"]);
                this.m__DATUMOBRACUNASTAZAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["DATUMOBRACUNASTAZA"]);
                this.m__OBRPOSTOTNIHOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OBRPOSTOTNIH"]);
                this.m__OBRFIKSNIHOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OBRFIKSNIH"]);
                this.m__OBRKREDITNIHOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OBRKREDITNIH"]);
                this.m__ZAKLJOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["ZAKLJ"]);
                this.m__SVRHAOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUN["SVRHAOBRACUNA"]);
            }
            this._Gxremove = this.rowOBRACUN.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowOBRACUN = (OBRACUNDataSet.OBRACUNRow) DataSetUtil.CloneOriginalDataRow(this.rowOBRACUN);
            }
        }

        private void ReadRowObracundoprinosi()
        {
            this.Gx_mode = Mode.FromRowState(this.rowObracunDoprinosi.RowState);
            if (this.rowObracunDoprinosi.RowState != DataRowState.Added)
            {
                this.m__OBRACUNATIDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["OBRACUNATIDOPRINOS", DataRowVersion.Original]);
                this.m__OSNOVICADOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["OSNOVICADOPRINOS", DataRowVersion.Original]);
            }
            else
            {
                this.m__OBRACUNATIDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["OBRACUNATIDOPRINOS"]);
                this.m__OSNOVICADOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["OSNOVICADOPRINOS"]);
            }
            this._Gxremove179 = this.rowObracunDoprinosi.RowState == DataRowState.Deleted;
            if (this._Gxremove179)
            {
                this.rowObracunDoprinosi = (OBRACUNDataSet.ObracunDoprinosiRow) DataSetUtil.CloneOriginalDataRow(this.rowObracunDoprinosi);
            }
        }

        private void ReadRowObracunelementi()
        {
            this.Gx_mode = Mode.FromRowState(this.rowObracunElementi.RowState);
            if (this.rowObracunElementi.RowState != DataRowState.Added)
            {
                this.m__OBRSATIOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunElementi["OBRSATI", DataRowVersion.Original]);
                this.m__OBRSATNICAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunElementi["OBRSATNICA", DataRowVersion.Original]);
                this.m__OBRIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunElementi["OBRIZNOS", DataRowVersion.Original]);
                this.m__OBRPOSTOTAKOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunElementi["OBRPOSTOTAK", DataRowVersion.Original]);
            }
            else
            {
                this.m__OBRSATIOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunElementi["OBRSATI"]);
                this.m__OBRSATNICAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunElementi["OBRSATNICA"]);
                this.m__OBRIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunElementi["OBRIZNOS"]);
                this.m__OBRPOSTOTAKOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunElementi["OBRPOSTOTAK"]);
            }
            this._Gxremove281 = this.rowObracunElementi.RowState == DataRowState.Deleted;
            if (this._Gxremove281)
            {
                this.rowObracunElementi = (OBRACUNDataSet.ObracunElementiRow) DataSetUtil.CloneOriginalDataRow(this.rowObracunElementi);
            }
        }

        private void ReadRowObracunkrediti()
        {
            this.Gx_mode = Mode.FromRowState(this.rowOBRACUNKrediti.RowState);
            if (this.rowOBRACUNKrediti.RowState != DataRowState.Added)
            {
                this.m__OBRSIFRAOPISAPLACANJAKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRSIFRAOPISAPLACANJAKREDITOR", DataRowVersion.Original]);
                this.m__OBROPISPLACANJAKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBROPISPLACANJAKREDITOR", DataRowVersion.Original]);
                this.m__OBRMOKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRMOKREDITOR", DataRowVersion.Original]);
                this.m__OBRPOKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRPOKREDITOR", DataRowVersion.Original]);
                this.m__OBRMZKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRMZKREDITOR", DataRowVersion.Original]);
                this.m__OBRPZKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRPZKREDITOR", DataRowVersion.Original]);
                this.m__OBRIZNOSRATEKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRIZNOSRATEKREDITOR", DataRowVersion.Original]);
                this.m__OBRACUNATIKUNSKIIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRACUNATIKUNSKIIZNOS", DataRowVersion.Original]);
                this.m__VECOTPLACENOBROJRATAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["VECOTPLACENOBROJRATA", DataRowVersion.Original]);
                this.m__VECOTPLACENOUKUPNIIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["VECOTPLACENOUKUPNIIZNOS", DataRowVersion.Original]);
                this.m__UKUPNIZNOSKREDITAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["UKUPNIZNOSKREDITA", DataRowVersion.Original]);
            }
            else
            {
                this.m__OBRSIFRAOPISAPLACANJAKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRSIFRAOPISAPLACANJAKREDITOR"]);
                this.m__OBROPISPLACANJAKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBROPISPLACANJAKREDITOR"]);
                this.m__OBRMOKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRMOKREDITOR"]);
                this.m__OBRPOKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRPOKREDITOR"]);
                this.m__OBRMZKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRMZKREDITOR"]);
                this.m__OBRPZKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRPZKREDITOR"]);
                this.m__OBRIZNOSRATEKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRIZNOSRATEKREDITOR"]);
                this.m__OBRACUNATIKUNSKIIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRACUNATIKUNSKIIZNOS"]);
                this.m__VECOTPLACENOBROJRATAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["VECOTPLACENOBROJRATA"]);
                this.m__VECOTPLACENOUKUPNIIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["VECOTPLACENOUKUPNIIZNOS"]);
                this.m__UKUPNIZNOSKREDITAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["UKUPNIZNOSKREDITA"]);
            }
            this._Gxremove235 = this.rowOBRACUNKrediti.RowState == DataRowState.Deleted;
            if (this._Gxremove235)
            {
                this.rowOBRACUNKrediti = (OBRACUNDataSet.OBRACUNKreditiRow) DataSetUtil.CloneOriginalDataRow(this.rowOBRACUNKrediti);
            }
        }

        private void ReadRowObracunobracunlevel1obracunizuzece()
        {
            this.Gx_mode = Mode.FromRowState(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece.RowState);
            if (this.rowOBRACUNOBRACUNLevel1ObracunIzuzece.RowState != DataRowState.Added)
            {
                this.m__PRIMATELJIZUZECE1Original = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PRIMATELJIZUZECE1", DataRowVersion.Original]);
                this.m__PRIMATELJIZUZECE2Original = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PRIMATELJIZUZECE2", DataRowVersion.Original]);
                this.m__PRIMATELJIZUZECE3Original = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PRIMATELJIZUZECE3", DataRowVersion.Original]);
                this.m__SIFRAOPISAPLACANJAIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["SIFRAOPISAPLACANJAIZUZECE", DataRowVersion.Original]);
                this.m__OPISPLACANJAIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["OPISPLACANJAIZUZECE", DataRowVersion.Original]);
                this.m__VBDIIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["VBDIIZUZECE", DataRowVersion.Original]);
                this.m__TEKUCIIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["TEKUCIIZUZECE", DataRowVersion.Original]);
                this.m__MOIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["MOIZUZECE", DataRowVersion.Original]);
                this.m__POIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["POIZUZECE", DataRowVersion.Original]);
                this.m__MZIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["MZIZUZECE", DataRowVersion.Original]);
                this.m__PZIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PZIZUZECE", DataRowVersion.Original]);
                this.m__IZNOSIZUZECAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IZNOSIZUZECA", DataRowVersion.Original]);
            }
            else
            {
                this.m__PRIMATELJIZUZECE1Original = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PRIMATELJIZUZECE1"]);
                this.m__PRIMATELJIZUZECE2Original = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PRIMATELJIZUZECE2"]);
                this.m__PRIMATELJIZUZECE3Original = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PRIMATELJIZUZECE3"]);
                this.m__SIFRAOPISAPLACANJAIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["SIFRAOPISAPLACANJAIZUZECE"]);
                this.m__OPISPLACANJAIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["OPISPLACANJAIZUZECE"]);
                this.m__VBDIIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["VBDIIZUZECE"]);
                this.m__TEKUCIIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["TEKUCIIZUZECE"]);
                this.m__MOIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["MOIZUZECE"]);
                this.m__POIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["POIZUZECE"]);
                this.m__MZIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["MZIZUZECE"]);
                this.m__PZIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PZIZUZECE"]);
                this.m__IZNOSIZUZECAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IZNOSIZUZECA"]);
            }
            this._Gxremove317 = this.rowOBRACUNOBRACUNLevel1ObracunIzuzece.RowState == DataRowState.Deleted;
            if (this._Gxremove317)
            {
                this.rowOBRACUNOBRACUNLevel1ObracunIzuzece = (OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow) DataSetUtil.CloneOriginalDataRow(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece);
            }
        }

        private void ReadRowObracunobracunlevel1obracunkrizni()
        {
            this.Gx_mode = Mode.FromRowState(this.rowOBRACUNOBRACUNLevel1ObracunKrizni.RowState);
            if (this.rowOBRACUNOBRACUNLevel1ObracunKrizni.RowState != DataRowState.Added)
            {
                this.m__OSNOVICAKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OSNOVICAKRIZNI", DataRowVersion.Original]);
                this.m__POREZKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POREZKRIZNI", DataRowVersion.Original]);
                this.m__OSNOVICAPRETHODNAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OSNOVICAPRETHODNA", DataRowVersion.Original]);
                this.m__OSNOVICAUKUPNAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OSNOVICAUKUPNA", DataRowVersion.Original]);
                this.m__POREZPRETHODNIOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POREZPRETHODNI", DataRowVersion.Original]);
                this.m__POREZUKUPNOOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POREZUKUPNO", DataRowVersion.Original]);
            }
            else
            {
                this.m__OSNOVICAKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OSNOVICAKRIZNI"]);
                this.m__POREZKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POREZKRIZNI"]);
                this.m__OSNOVICAPRETHODNAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OSNOVICAPRETHODNA"]);
                this.m__OSNOVICAUKUPNAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OSNOVICAUKUPNA"]);
                this.m__POREZPRETHODNIOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POREZPRETHODNI"]);
                this.m__POREZUKUPNOOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POREZUKUPNO"]);
            }
            this._Gxremove296 = this.rowOBRACUNOBRACUNLevel1ObracunKrizni.RowState == DataRowState.Deleted;
            if (this._Gxremove296)
            {
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni = (OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow) DataSetUtil.CloneOriginalDataRow(this.rowOBRACUNOBRACUNLevel1ObracunKrizni);
            }
        }

        private void ReadRowObracunobustave()
        {
            this.Gx_mode = Mode.FromRowState(this.rowOBRACUNObustave.RowState);
            if (this.rowOBRACUNObustave.RowState != DataRowState.Added)
            {
                this.m__IZNOSOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IZNOSOBUSTAVE", DataRowVersion.Original]);
                this.m__POSTOTAKOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["POSTOTAKOBUSTAVE", DataRowVersion.Original]);
                this.m__OBRACUNATAOBUSTAVAUKUNAMAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["OBRACUNATAOBUSTAVAUKUNAMA", DataRowVersion.Original]);
                this.m__ISPLACENOKASAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["ISPLACENOKASA", DataRowVersion.Original]);
                this.m__SALDOKASAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["SALDOKASA", DataRowVersion.Original]);
            }
            else
            {
                this.m__IZNOSOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IZNOSOBUSTAVE"]);
                this.m__POSTOTAKOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["POSTOTAKOBUSTAVE"]);
                this.m__OBRACUNATAOBUSTAVAUKUNAMAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["OBRACUNATAOBUSTAVAUKUNAMA"]);
                this.m__ISPLACENOKASAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["ISPLACENOKASA"]);
                this.m__SALDOKASAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["SALDOKASA"]);
            }
            this._Gxremove257 = this.rowOBRACUNObustave.RowState == DataRowState.Deleted;
            if (this._Gxremove257)
            {
                this.rowOBRACUNObustave = (OBRACUNDataSet.OBRACUNObustaveRow) DataSetUtil.CloneOriginalDataRow(this.rowOBRACUNObustave);
            }
        }

        private void ReadRowObracunolaksice()
        {
            this.Gx_mode = Mode.FromRowState(this.rowObracunOlaksice.RowState);
            if (this.rowObracunOlaksice.RowState != DataRowState.Added)
            {
                this.m__MZOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["MZOLAKSICA", DataRowVersion.Original]);
                this.m__PZOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["PZOLAKSICA", DataRowVersion.Original]);
                this.m__MOOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["MOOLAKSICA", DataRowVersion.Original]);
                this.m__POOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["POOLAKSICA", DataRowVersion.Original]);
                this.m__SIFRAOPISAPLACANJAOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["SIFRAOPISAPLACANJAOLAKSICA", DataRowVersion.Original]);
                this.m__OPISPLACANJAOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["OPISPLACANJAOLAKSICA", DataRowVersion.Original]);
                this.m__IZNOSOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IZNOSOLAKSICE", DataRowVersion.Original]);
                this.m__OBRACUNATAOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["OBRACUNATAOLAKSICA", DataRowVersion.Original]);
            }
            else
            {
                this.m__MZOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["MZOLAKSICA"]);
                this.m__PZOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["PZOLAKSICA"]);
                this.m__MOOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["MOOLAKSICA"]);
                this.m__POOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["POOLAKSICA"]);
                this.m__SIFRAOPISAPLACANJAOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["SIFRAOPISAPLACANJAOLAKSICA"]);
                this.m__OPISPLACANJAOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["OPISPLACANJAOLAKSICA"]);
                this.m__IZNOSOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IZNOSOLAKSICE"]);
                this.m__OBRACUNATAOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["OBRACUNATAOLAKSICA"]);
            }
            this._Gxremove214 = this.rowObracunOlaksice.RowState == DataRowState.Deleted;
            if (this._Gxremove214)
            {
                this.rowObracunOlaksice = (OBRACUNDataSet.ObracunOlaksiceRow) DataSetUtil.CloneOriginalDataRow(this.rowObracunOlaksice);
            }
        }

        private void ReadRowObracunporezi()
        {
            this.Gx_mode = Mode.FromRowState(this.rowObracunPorezi.RowState);
            if (this.rowObracunPorezi.RowState != DataRowState.Added)
            {
                this.m__OBRACUNATIPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["OBRACUNATIPOREZ", DataRowVersion.Original]);
                this.m__OSNOVICAPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["OSNOVICAPOREZ", DataRowVersion.Original]);
            }
            else
            {
                this.m__OBRACUNATIPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["OBRACUNATIPOREZ"]);
                this.m__OSNOVICAPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["OSNOVICAPOREZ"]);
            }
            this._Gxremove199 = this.rowObracunPorezi.RowState == DataRowState.Deleted;
            if (this._Gxremove199)
            {
                this.rowObracunPorezi = (OBRACUNDataSet.ObracunPoreziRow) DataSetUtil.CloneOriginalDataRow(this.rowObracunPorezi);
            }
        }

        private void ReadRowObracunradnici()
        {
            this.Gx_mode = Mode.FromRowState(this.rowObracunRadnici.RowState);
            if (this.rowObracunRadnici.RowState != DataRowState.Added)
            {
                this.m__SIFRAOPCINESTANOVANJAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["SIFRAOPCINESTANOVANJA", DataRowVersion.Original]);
                this.m__OBRACUNSKIKOEFICIJENTOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["OBRACUNSKIKOEFICIJENT", DataRowVersion.Original]);
                this.m__ISKORISTENOOOOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["ISKORISTENOOO", DataRowVersion.Original]);
                this.m__OBRACUNATIPRIREZOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["OBRACUNATIPRIREZ", DataRowVersion.Original]);
                this.m__faktooOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["faktoo", DataRowVersion.Original]);
                this.m__RADNIKOBRACUNOSNOVICAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["RADNIKOBRACUNOSNOVICA", DataRowVersion.Original]);
                this.m__KOREKCIJAPRIREZAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["KOREKCIJAPRIREZA", DataRowVersion.Original]);
                this.m__ODBITAKPRIJEKOREKCIJEOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["ODBITAKPRIJEKOREKCIJE", DataRowVersion.Original]);
                this.m__OBRACUNAVAJOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["OBRACUNAVAJOBUSTAVE", DataRowVersion.Original]);
            }
            else
            {
                this.m__SIFRAOPCINESTANOVANJAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["SIFRAOPCINESTANOVANJA"]);
                this.m__OBRACUNSKIKOEFICIJENTOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["OBRACUNSKIKOEFICIJENT"]);
                this.m__ISKORISTENOOOOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["ISKORISTENOOO"]);
                this.m__OBRACUNATIPRIREZOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["OBRACUNATIPRIREZ"]);
                this.m__faktooOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["faktoo"]);
                this.m__RADNIKOBRACUNOSNOVICAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["RADNIKOBRACUNOSNOVICA"]);
                this.m__KOREKCIJAPRIREZAOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["KOREKCIJAPRIREZA"]);
                this.m__ODBITAKPRIJEKOREKCIJEOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["ODBITAKPRIJEKOREKCIJE"]);
                this.m__OBRACUNAVAJOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["OBRACUNAVAJOBUSTAVE"]);
            }
            this._Gxremove = this.rowObracunRadnici.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowObracunRadnici = (OBRACUNDataSet.ObracunRadniciRow) DataSetUtil.CloneOriginalDataRow(this.rowObracunRadnici);
            }
        }

        private void ScanByIDOBRACUN(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDOBRACUN] = @IDOBRACUN";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString9 + "  FROM [OBRACUN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOBRACUN]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString9, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOBRACUN] ) AS DK_PAGENUM   FROM [OBRACUN] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString9 + " FROM [OBRACUN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOBRACUN] ";
            }
            this.cmOBRACUNSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOBRACUNSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmOBRACUNSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
            }
            this.cmOBRACUNSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["IDOBRACUN"]));
            this.OBRACUNSelect4 = this.cmOBRACUNSelect4.FetchData();
            this.RcdFound9 = 0;
            this.ScanLoadObracun();
            this.LoadDataObracun(maxRows);
            if (this.RcdFound9 > 0)
            {
                this.SubLvlScanStartObracunradnici(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDOBRACUNObracun(this.cmObracunRadniciSelect2);
                this.SubLvlFetchObracunradnici();
                this.SubLoadDataObracunradnici();
                this.SubLvlScanStartObracundoprinosi(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDOBRACUNObracun(this.cmObracunDoprinosiSelect2);
                this.SubLvlFetchObracundoprinosi();
                this.SubLoadDataObracundoprinosi();
                this.SubLvlScanStartObracunporezi(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDOBRACUNObracun(this.cmObracunPoreziSelect2);
                this.SubLvlFetchObracunporezi();
                this.SubLoadDataObracunporezi();
                this.SubLvlScanStartObracunolaksice(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDOBRACUNObracun(this.cmObracunOlaksiceSelect2);
                this.SubLvlFetchObracunolaksice();
                this.SubLoadDataObracunolaksice();
                this.SubLvlScanStartObracunkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDOBRACUNObracun(this.cmOBRACUNKreditiSelect2);
                this.SubLvlFetchObracunkrediti();
                this.SubLoadDataObracunkrediti();
                this.SubLvlScanStartObracunobustave(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDOBRACUNObracun(this.cmOBRACUNObustaveSelect2);
                this.SubLvlFetchObracunobustave();
                this.SubLoadDataObracunobustave();
                this.SubLvlScanStartObracunelementi(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDOBRACUNObracun(this.cmObracunElementiSelect2);
                this.SubLvlFetchObracunelementi();
                this.SubLoadDataObracunelementi();
                this.SubLvlScanStartObracunobracunlevel1obracunkrizni(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDOBRACUNObracun(this.cmOBRACUNOBRACUNLevel1ObracunKrizniSelect2);
                this.SubLvlFetchObracunobracunlevel1obracunkrizni();
                this.SubLoadDataObracunobracunlevel1obracunkrizni();
                this.SubLvlScanStartObracunobracunlevel1obracunizuzece(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDOBRACUNObracun(this.cmOBRACUNOBRACUNLevel1ObracunIzuzeceSelect2);
                this.SubLvlFetchObracunobracunlevel1obracunizuzece();
                this.SubLoadDataObracunobracunlevel1obracunizuzece();
            }
        }

        private void ScanEndObracun()
        {
            this.OBRACUNSelect4.Close();
        }

        private void ScanEndObracundoprinosi()
        {
            this.ObracunDoprinosiSelect2.Close();
        }

        private void ScanEndObracunelementi()
        {
            this.ObracunElementiSelect2.Close();
        }

        private void ScanEndObracunkrediti()
        {
            this.OBRACUNKreditiSelect2.Close();
        }

        private void ScanEndObracunobracunlevel1obracunizuzece()
        {
            this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2.Close();
        }

        private void ScanEndObracunobracunlevel1obracunkrizni()
        {
            this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2.Close();
        }

        private void ScanEndObracunobustave()
        {
            this.OBRACUNObustaveSelect2.Close();
        }

        private void ScanEndObracunolaksice()
        {
            this.ObracunOlaksiceSelect2.Close();
        }

        private void ScanEndObracunporezi()
        {
            this.ObracunPoreziSelect2.Close();
        }

        private void ScanEndObracunradnici()
        {
            this.ObracunRadniciSelect2.Close();
        }

        private void ScanLoadObracun()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmOBRACUNSelect4.HasMoreRows)
            {
                this.RcdFound9 = 1;
                this.rowOBRACUN["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNSelect4, 0));
                this.rowOBRACUN["VRSTAOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNSelect4, 1));
                this.rowOBRACUN["MJESECOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNSelect4, 2));
                this.rowOBRACUN["GODINAOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNSelect4, 3));
                this.rowOBRACUN["MJESECISPLATE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNSelect4, 4));
                this.rowOBRACUN["GODINAISPLATE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNSelect4, 5));
                this.rowOBRACUN["DATUMISPLATE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.OBRACUNSelect4, 6));
                this.rowOBRACUN["tjednifondsatiobracun"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.OBRACUNSelect4, 7));
                this.rowOBRACUN["MJESECNIFONDSATIOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.OBRACUNSelect4, 8));
                this.rowOBRACUN["OSNOVNIOO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNSelect4, 9));
                this.rowOBRACUN["OBRACUNSKAOSNOVICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNSelect4, 10));
                this.rowOBRACUN["DATUMOBRACUNASTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.OBRACUNSelect4, 11));
                this.rowOBRACUN["OBRPOSTOTNIH"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.OBRACUNSelect4, 12));
                this.rowOBRACUN["OBRFIKSNIH"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.OBRACUNSelect4, 13));
                this.rowOBRACUN["OBRKREDITNIH"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.OBRACUNSelect4, 14));
                this.rowOBRACUN["ZAKLJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.OBRACUNSelect4, 15));
                this.rowOBRACUN["SVRHAOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNSelect4, 0x10));
            }
        }

        private void ScanLoadObracundoprinosi()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmObracunDoprinosiSelect2.HasMoreRows)
            {
                this.RcdFound11 = 1;
                this.rowObracunDoprinosi["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunDoprinosiSelect2, 0));
                this.rowObracunDoprinosi["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunDoprinosiSelect2, 1));
                this.rowObracunDoprinosi["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunDoprinosiSelect2, 2));
                this.rowObracunDoprinosi["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunDoprinosiSelect2, 3));
                this.rowObracunDoprinosi["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunDoprinosiSelect2, 4));
                this.rowObracunDoprinosi["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunDoprinosiSelect2, 5));
                this.rowObracunDoprinosi["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunDoprinosiSelect2, 6));
                this.rowObracunDoprinosi["STOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunDoprinosiSelect2, 7));
                this.rowObracunDoprinosi["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunDoprinosiSelect2, 8));
                this.rowObracunDoprinosi["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunDoprinosiSelect2, 9));
                this.rowObracunDoprinosi["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunDoprinosiSelect2, 10));
                this.rowObracunDoprinosi["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunDoprinosiSelect2, 11));
                this.rowObracunDoprinosi["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunDoprinosiSelect2, 12));
                this.rowObracunDoprinosi["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunDoprinosiSelect2, 13));
                this.rowObracunDoprinosi["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunDoprinosiSelect2, 14));
                this.rowObracunDoprinosi["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunDoprinosiSelect2, 15));
                this.rowObracunDoprinosi["OBRACUNATIDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunDoprinosiSelect2, 0x10));
                this.rowObracunDoprinosi["OSNOVICADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunDoprinosiSelect2, 0x11));
                this.rowObracunDoprinosi["MINDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunDoprinosiSelect2, 0x12));
                this.rowObracunDoprinosi["MAXDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunDoprinosiSelect2, 0x13));
                this.rowObracunDoprinosi["IDDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunDoprinosiSelect2, 20));
                this.rowObracunDoprinosi["MINDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunDoprinosiSelect2, 0x12));
                this.rowObracunDoprinosi["MAXDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunDoprinosiSelect2, 0x13));
            }
        }

        private void ScanLoadObracunelementi()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmObracunElementiSelect2.HasMoreRows)
            {
                this.RcdFound62 = 1;
                this.rowObracunElementi["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunElementiSelect2, 0));
                this.rowObracunElementi["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunElementiSelect2, 1));
                this.rowObracunElementi["ELEMENTRAZDOBLJEOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.ObracunElementiSelect2, 2));
                this.rowObracunElementi["ELEMENTRAZDOBLJEDO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.ObracunElementiSelect2, 3));
                this.rowObracunElementi["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunElementiSelect2, 4));
                this.rowObracunElementi["RAZDOBLJESESMIJEPREKLAPATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.ObracunElementiSelect2, 5));
                this.rowObracunElementi["OBRSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunElementiSelect2, 6));
                this.rowObracunElementi["OBRSATNICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunElementiSelect2, 7));
                this.rowObracunElementi["OBRIZNOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunElementiSelect2, 8));
                this.rowObracunElementi["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunElementiSelect2, 9));
                this.rowObracunElementi["IDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.ObracunElementiSelect2, 10));
                this.rowObracunElementi["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunElementiSelect2, 11));
                this.rowObracunElementi["OBRPOSTOTAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunElementiSelect2, 12));
                this.rowObracunElementi["ZBRAJASATEUFONDSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.ObracunElementiSelect2, 13));
                this.rowObracunElementi["IDELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunElementiSelect2, 14));
                this.rowObracunElementi["IDOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetStringNE(this.ObracunElementiSelect2, 15));
                this.rowObracunElementi["ZBRAJASATEUFONDSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.ObracunElementiSelect2, 13));
                this.rowObracunElementi["IDOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetStringNE(this.ObracunElementiSelect2, 15));
                this.rowObracunElementi["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunElementiSelect2, 4));
                this.rowObracunElementi["RAZDOBLJESESMIJEPREKLAPATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.ObracunElementiSelect2, 5));
            }
        }

        private void ScanLoadObracunkrediti()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmOBRACUNKreditiSelect2.HasMoreRows)
            {
                this.RcdFound74 = 1;
                this.rowOBRACUNKrediti["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNKreditiSelect2, 0));
                this.rowOBRACUNKrediti["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OBRACUNKreditiSelect2, 1));
                this.rowOBRACUNKrediti["DATUMUGOVORA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.OBRACUNKreditiSelect2, 2));
                this.rowOBRACUNKrediti["NAZIVKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNKreditiSelect2, 3));
                this.rowOBRACUNKrediti["VBDIKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNKreditiSelect2, 4));
                this.rowOBRACUNKrediti["ZRNKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNKreditiSelect2, 5));
                this.rowOBRACUNKrediti["PRIMATELJKREDITOR1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNKreditiSelect2, 6));
                this.rowOBRACUNKrediti["PRIMATELJKREDITOR2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNKreditiSelect2, 7));
                this.rowOBRACUNKrediti["PRIMATELJKREDITOR3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNKreditiSelect2, 8));
                this.rowOBRACUNKrediti["OBRSIFRAOPISAPLACANJAKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNKreditiSelect2, 9));
                this.rowOBRACUNKrediti["OBROPISPLACANJAKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNKreditiSelect2, 10));
                this.rowOBRACUNKrediti["OBRMOKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNKreditiSelect2, 11));
                this.rowOBRACUNKrediti["OBRPOKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNKreditiSelect2, 12));
                this.rowOBRACUNKrediti["OBRMZKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNKreditiSelect2, 13));
                this.rowOBRACUNKrediti["OBRPZKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNKreditiSelect2, 14));
                this.rowOBRACUNKrediti["OBRIZNOSRATEKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNKreditiSelect2, 15));
                this.rowOBRACUNKrediti["OBRACUNATIKUNSKIIZNOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNKreditiSelect2, 0x10));
                this.rowOBRACUNKrediti["VECOTPLACENOBROJRATA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNKreditiSelect2, 0x11));
                this.rowOBRACUNKrediti["VECOTPLACENOUKUPNIIZNOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNKreditiSelect2, 0x12));
                this.rowOBRACUNKrediti["UKUPNIZNOSKREDITA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNKreditiSelect2, 0x13));
                this.rowOBRACUNKrediti["IDKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OBRACUNKreditiSelect2, 20));
            }
        }

        private void ScanLoadObracunobracunlevel1obracunizuzece()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmOBRACUNOBRACUNLevel1ObracunIzuzeceSelect2.HasMoreRows)
            {
                this.RcdFound292 = 1;
                this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2, 0));
                this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2, 1));
                this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDOBRACUNIZUZECE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetGuid(this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2, 2));
                this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PRIMATELJIZUZECE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2, 3));
                this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PRIMATELJIZUZECE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2, 4));
                this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PRIMATELJIZUZECE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2, 5));
                this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["SIFRAOPISAPLACANJAIZUZECE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2, 6));
                this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["OPISPLACANJAIZUZECE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2, 7));
                this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["VBDIIZUZECE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2, 8));
                this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["TEKUCIIZUZECE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2, 9));
                this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["MOIZUZECE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2, 10));
                this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["POIZUZECE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2, 11));
                this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["MZIZUZECE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2, 12));
                this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PZIZUZECE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2, 13));
                this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IZNOSIZUZECA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2, 14));
            }
        }

        private void ScanLoadObracunobracunlevel1obracunkrizni()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmOBRACUNOBRACUNLevel1ObracunKrizniSelect2.HasMoreRows)
            {
                this.RcdFound137 = 1;
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 0));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 1));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["NAZIVKRIZNIPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 2));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["KRIZNISTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 3));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["MOKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 4));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 5));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["MZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 6));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 7));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PRIMATELJKRIZNI1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 8));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PRIMATELJKRIZNI2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 9));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PRIMATELJKRIZNI3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 10));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["SIFRAOPISAPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 11));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OPISPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 12));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["VBDIKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 13));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["ZRNKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 14));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OSNOVICAKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 15));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POREZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 0x10));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OSNOVICAPRETHODNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 0x11));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OSNOVICAUKUPNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 0x12));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POREZPRETHODNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 0x13));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POREZUKUPNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 20));
                this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDKRIZNIPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2, 0x15));
            }
        }

        private void ScanLoadObracunobustave()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmOBRACUNObustaveSelect2.HasMoreRows)
            {
                this.RcdFound61 = 1;
                this.rowOBRACUNObustave["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNObustaveSelect2, 0));
                this.rowOBRACUNObustave["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OBRACUNObustaveSelect2, 1));
                this.rowOBRACUNObustave["NAZIVOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNObustaveSelect2, 2));
                this.rowOBRACUNObustave["MOOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNObustaveSelect2, 3));
                this.rowOBRACUNObustave["POOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNObustaveSelect2, 4));
                this.rowOBRACUNObustave["MZOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNObustaveSelect2, 5));
                this.rowOBRACUNObustave["PZOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNObustaveSelect2, 6));
                this.rowOBRACUNObustave["VBDIOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNObustaveSelect2, 7));
                this.rowOBRACUNObustave["ZRNOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNObustaveSelect2, 8));
                this.rowOBRACUNObustave["PRIMATELJOBUSTAVA1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNObustaveSelect2, 9));
                this.rowOBRACUNObustave["PRIMATELJOBUSTAVA2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNObustaveSelect2, 10));
                this.rowOBRACUNObustave["PRIMATELJOBUSTAVA3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNObustaveSelect2, 11));
                this.rowOBRACUNObustave["SIFRAOPISAPLACANJAOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNObustaveSelect2, 12));
                this.rowOBRACUNObustave["OPISPLACANJAOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNObustaveSelect2, 13));
                this.rowOBRACUNObustave["VRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.OBRACUNObustaveSelect2, 14));
                this.rowOBRACUNObustave["NAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBRACUNObustaveSelect2, 15));
                this.rowOBRACUNObustave["IZNOSOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNObustaveSelect2, 0x10));
                this.rowOBRACUNObustave["POSTOTAKOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNObustaveSelect2, 0x11));
                this.rowOBRACUNObustave["OBRACUNATAOBUSTAVAUKUNAMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNObustaveSelect2, 0x12));
                this.rowOBRACUNObustave["ISPLACENOKASA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNObustaveSelect2, 0x13));
                this.rowOBRACUNObustave["SALDOKASA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OBRACUNObustaveSelect2, 20));
                this.rowOBRACUNObustave["IDOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OBRACUNObustaveSelect2, 0x15));
            }
        }

        private void ScanLoadObracunolaksice()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmObracunOlaksiceSelect2.HasMoreRows)
            {
                this.RcdFound13 = 1;
                this.rowObracunOlaksice["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunOlaksiceSelect2, 0));
                this.rowObracunOlaksice["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunOlaksiceSelect2, 1));
                this.rowObracunOlaksice["NAZIVOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunOlaksiceSelect2, 2));
                this.rowObracunOlaksice["IDGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunOlaksiceSelect2, 3));
                this.rowObracunOlaksice["NAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunOlaksiceSelect2, 4));
                this.rowObracunOlaksice["MAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunOlaksiceSelect2, 5));
                this.rowObracunOlaksice["IDTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunOlaksiceSelect2, 6));
                this.rowObracunOlaksice["NAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunOlaksiceSelect2, 7));
                this.rowObracunOlaksice["VBDIOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunOlaksiceSelect2, 8));
                this.rowObracunOlaksice["ZRNOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunOlaksiceSelect2, 9));
                this.rowObracunOlaksice["PRIMATELJOLAKSICA1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunOlaksiceSelect2, 10));
                this.rowObracunOlaksice["PRIMATELJOLAKSICA2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunOlaksiceSelect2, 11));
                this.rowObracunOlaksice["PRIMATELJOLAKSICA3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunOlaksiceSelect2, 12));
                this.rowObracunOlaksice["MZOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunOlaksiceSelect2, 13));
                this.rowObracunOlaksice["PZOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunOlaksiceSelect2, 14));
                this.rowObracunOlaksice["MOOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunOlaksiceSelect2, 15));
                this.rowObracunOlaksice["POOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunOlaksiceSelect2, 0x10));
                this.rowObracunOlaksice["SIFRAOPISAPLACANJAOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunOlaksiceSelect2, 0x11));
                this.rowObracunOlaksice["OPISPLACANJAOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunOlaksiceSelect2, 0x12));
                this.rowObracunOlaksice["IZNOSOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunOlaksiceSelect2, 0x13));
                this.rowObracunOlaksice["OBRACUNATAOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunOlaksiceSelect2, 20));
                this.rowObracunOlaksice["IDOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunOlaksiceSelect2, 0x15));
            }
        }

        private void ScanLoadObracunporezi()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmObracunPoreziSelect2.HasMoreRows)
            {
                this.RcdFound12 = 1;
                this.rowObracunPorezi["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunPoreziSelect2, 0));
                this.rowObracunPorezi["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunPoreziSelect2, 1));
                this.rowObracunPorezi["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunPoreziSelect2, 2));
                this.rowObracunPorezi["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunPoreziSelect2, 3));
                this.rowObracunPorezi["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunPoreziSelect2, 4));
                this.rowObracunPorezi["MOPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunPoreziSelect2, 5));
                this.rowObracunPorezi["POPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunPoreziSelect2, 6));
                this.rowObracunPorezi["MZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunPoreziSelect2, 7));
                this.rowObracunPorezi["PZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunPoreziSelect2, 8));
                this.rowObracunPorezi["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunPoreziSelect2, 9));
                this.rowObracunPorezi["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunPoreziSelect2, 10));
                this.rowObracunPorezi["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunPoreziSelect2, 11));
                this.rowObracunPorezi["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunPoreziSelect2, 12));
                this.rowObracunPorezi["OBRACUNATIPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunPoreziSelect2, 13));
                this.rowObracunPorezi["OSNOVICAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunPoreziSelect2, 14));
                this.rowObracunPorezi["IDPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunPoreziSelect2, 15));
            }
        }

        private void ScanLoadObracunradnici()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmObracunRadniciSelect2.HasMoreRows)
            {
                this.RcdFound10 = 1;
                this.rowObracunRadnici["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0));
                this.rowObracunRadnici["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 1));
                this.rowObracunRadnici["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 2));
                this.rowObracunRadnici["ulica"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 3));
                this.rowObracunRadnici["mjesto"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 4));
                this.rowObracunRadnici["kucnibroj"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 5));
                this.rowObracunRadnici["JMBG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 6));
                this.rowObracunRadnici["DATUMRODJENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.ObracunRadniciSelect2, 7));
                this.rowObracunRadnici["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 8));
                this.rowObracunRadnici["OPCINARADAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunRadniciSelect2, 9));
                this.rowObracunRadnici["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 10));
                this.rowObracunRadnici["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunRadniciSelect2, 11));
                this.rowObracunRadnici["SIFRAOPCINESTANOVANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 12));
                this.rowObracunRadnici["NAZIVBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 13));
                this.rowObracunRadnici["BROJPRIZNATIHMJESECI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.ObracunRadniciSelect2, 14));
                this.rowObracunRadnici["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 15));
                this.rowObracunRadnici["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x10));
                this.rowObracunRadnici["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x11));
                this.rowObracunRadnici["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x12));
                this.rowObracunRadnici["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x13));
                this.rowObracunRadnici["TEKUCI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 20));
                this.rowObracunRadnici["SIFRAOPISAPLACANJANETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x15));
                this.rowObracunRadnici["OPISPLACANJANETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x16));
                this.rowObracunRadnici["BROJMIROVINSKOG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x17));
                this.rowObracunRadnici["BROJZDRAVSTVENOG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x18));
                this.rowObracunRadnici["MBO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x19));
                this.rowObracunRadnici["POSTOTAKOSLOBODJENJAODPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunRadniciSelect2, 0x1a));
                this.rowObracunRadnici["KOEFICIJENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunRadniciSelect2, 0x1b));
                this.rowObracunRadnici["OBRACUNSKIKOEFICIJENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunRadniciSelect2, 0x1c));
                this.rowObracunRadnici["NAZIVRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x1d));
                this.rowObracunRadnici["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 30));
                this.rowObracunRadnici["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x1f));
                this.rowObracunRadnici["NAZIVSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x20));
                this.rowObracunRadnici["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x21));
                this.rowObracunRadnici["AKTIVAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.ObracunRadniciSelect2, 0x22));
                this.rowObracunRadnici["ISKORISTENOOO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunRadniciSelect2, 0x23));
                this.rowObracunRadnici["OBRACUNATIPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunRadniciSelect2, 0x24));
                this.rowObracunRadnici["faktoo"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunRadniciSelect2, 0x25));
                this.rowObracunRadnici["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.ObracunRadniciSelect2, 0x26));
                this.rowObracunRadnici["TJEDNIFONDSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunRadniciSelect2, 0x27));
                this.rowObracunRadnici["TJEDNIFONDSATISTAZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunRadniciSelect2, 40));
                this.rowObracunRadnici["GODINESTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.ObracunRadniciSelect2, 0x29));
                this.rowObracunRadnici["MJESECISTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.ObracunRadniciSelect2, 0x2a));
                this.rowObracunRadnici["DANISTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.ObracunRadniciSelect2, 0x2b));
                this.rowObracunRadnici["DATUMPRESTANKARADNOGODNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.ObracunRadniciSelect2, 0x2c));
                this.rowObracunRadnici["NAZIVTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x2d));
                this.rowObracunRadnici["ZBIRNINETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.ObracunRadniciSelect2, 0x2e));
                this.rowObracunRadnici["UZIMAUOBZIROSNOVICEDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.ObracunRadniciSelect2, 0x2f));
                this.rowObracunRadnici["ORGANIZACIJSKIDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x30));
                this.rowObracunRadnici["IDIPIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunRadniciSelect2, 0x31));
                this.rowObracunRadnici["OIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 50));
                this.rowObracunRadnici["RADNIKOBRACUNOSNOVICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunRadniciSelect2, 0x33));
                this.rowObracunRadnici["KOREKCIJAPRIREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunRadniciSelect2, 0x34));
                this.rowObracunRadnici["ODBITAKPRIJEKOREKCIJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunRadniciSelect2, 0x35));
                this.rowObracunRadnici["OBRACUNAVAJOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.ObracunRadniciSelect2, 0x36));
                this.rowObracunRadnici["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunRadniciSelect2, 0x37));
                this.rowObracunRadnici["IDBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunRadniciSelect2, 0x38));
                this.rowObracunRadnici["IDBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x39));
                this.rowObracunRadnici["IDTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunRadniciSelect2, 0x3a));
                this.rowObracunRadnici["IDRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunRadniciSelect2, 0x3b));
                this.rowObracunRadnici["IDSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunRadniciSelect2, 60));
                this.rowObracunRadnici["IDORGDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunRadniciSelect2, 0x3d));
                this.rowObracunRadnici["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x3e));
                this.rowObracunRadnici["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x3f));
                this.rowObracunRadnici["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunRadniciSelect2, 0x40));
                this.rowObracunRadnici["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunRadniciSelect2, 0x41));
                this.rowObracunRadnici["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunRadniciSelect2, 0x42));
                this.rowObracunRadnici["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 1));
                this.rowObracunRadnici["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 2));
                this.rowObracunRadnici["ulica"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 3));
                this.rowObracunRadnici["mjesto"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 4));
                this.rowObracunRadnici["kucnibroj"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 5));
                this.rowObracunRadnici["JMBG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 6));
                this.rowObracunRadnici["DATUMRODJENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.ObracunRadniciSelect2, 7));
                this.rowObracunRadnici["TEKUCI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 20));
                this.rowObracunRadnici["SIFRAOPISAPLACANJANETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x15));
                this.rowObracunRadnici["OPISPLACANJANETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x16));
                this.rowObracunRadnici["BROJMIROVINSKOG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x17));
                this.rowObracunRadnici["BROJZDRAVSTVENOG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x18));
                this.rowObracunRadnici["MBO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x19));
                this.rowObracunRadnici["POSTOTAKOSLOBODJENJAODPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunRadniciSelect2, 0x1a));
                this.rowObracunRadnici["AKTIVAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.ObracunRadniciSelect2, 0x22));
                this.rowObracunRadnici["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.ObracunRadniciSelect2, 0x26));
                this.rowObracunRadnici["TJEDNIFONDSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunRadniciSelect2, 0x27));
                this.rowObracunRadnici["TJEDNIFONDSATISTAZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunRadniciSelect2, 40));
                this.rowObracunRadnici["GODINESTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.ObracunRadniciSelect2, 0x29));
                this.rowObracunRadnici["MJESECISTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.ObracunRadniciSelect2, 0x2a));
                this.rowObracunRadnici["DANISTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.ObracunRadniciSelect2, 0x2b));
                this.rowObracunRadnici["DATUMPRESTANKARADNOGODNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.ObracunRadniciSelect2, 0x2c));
                this.rowObracunRadnici["ZBIRNINETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.ObracunRadniciSelect2, 0x2e));
                this.rowObracunRadnici["UZIMAUOBZIROSNOVICEDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.ObracunRadniciSelect2, 0x2f));
                this.rowObracunRadnici["OIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 50));
                this.rowObracunRadnici["IDBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunRadniciSelect2, 0x38));
                this.rowObracunRadnici["IDBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x39));
                this.rowObracunRadnici["IDTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunRadniciSelect2, 0x3a));
                this.rowObracunRadnici["IDRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunRadniciSelect2, 0x3b));
                this.rowObracunRadnici["IDSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunRadniciSelect2, 60));
                this.rowObracunRadnici["IDORGDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunRadniciSelect2, 0x3d));
                this.rowObracunRadnici["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x3e));
                this.rowObracunRadnici["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x3f));
                this.rowObracunRadnici["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunRadniciSelect2, 0x40));
                this.rowObracunRadnici["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunRadniciSelect2, 0x41));
                this.rowObracunRadnici["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ObracunRadniciSelect2, 0x42));
                this.rowObracunRadnici["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 15));
                this.rowObracunRadnici["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x10));
                this.rowObracunRadnici["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x11));
                this.rowObracunRadnici["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x12));
                this.rowObracunRadnici["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x13));
                this.rowObracunRadnici["NAZIVBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 13));
                this.rowObracunRadnici["BROJPRIZNATIHMJESECI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.ObracunRadniciSelect2, 14));
                this.rowObracunRadnici["NAZIVTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x2d));
                this.rowObracunRadnici["NAZIVRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x1d));
                this.rowObracunRadnici["NAZIVSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x20));
                this.rowObracunRadnici["ORGANIZACIJSKIDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x30));
                this.rowObracunRadnici["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 8));
                this.rowObracunRadnici["OPCINARADAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunRadniciSelect2, 9));
                this.rowObracunRadnici["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 10));
                this.rowObracunRadnici["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ObracunRadniciSelect2, 11));
                this.rowObracunRadnici["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x21));
                this.rowObracunRadnici["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 0x1f));
                this.rowObracunRadnici["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ObracunRadniciSelect2, 30));
            }
        }

        private void ScanNextObracun()
        {
            this.cmOBRACUNSelect4.HasMoreRows = this.OBRACUNSelect4.Read();
            this.RcdFound9 = 0;
            this.ScanLoadObracun();
        }

        private void ScanNextObracundoprinosi()
        {
            this.cmObracunDoprinosiSelect2.HasMoreRows = this.ObracunDoprinosiSelect2.Read();
            this.RcdFound11 = 0;
            this.ScanLoadObracundoprinosi();
        }

        private void ScanNextObracunelementi()
        {
            this.cmObracunElementiSelect2.HasMoreRows = this.ObracunElementiSelect2.Read();
            this.RcdFound62 = 0;
            this.ScanLoadObracunelementi();
        }

        private void ScanNextObracunkrediti()
        {
            this.cmOBRACUNKreditiSelect2.HasMoreRows = this.OBRACUNKreditiSelect2.Read();
            this.RcdFound74 = 0;
            this.ScanLoadObracunkrediti();
        }

        private void ScanNextObracunobracunlevel1obracunizuzece()
        {
            this.cmOBRACUNOBRACUNLevel1ObracunIzuzeceSelect2.HasMoreRows = this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2.Read();
            this.RcdFound292 = 0;
            this.ScanLoadObracunobracunlevel1obracunizuzece();
        }

        private void ScanNextObracunobracunlevel1obracunkrizni()
        {
            this.cmOBRACUNOBRACUNLevel1ObracunKrizniSelect2.HasMoreRows = this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2.Read();
            this.RcdFound137 = 0;
            this.ScanLoadObracunobracunlevel1obracunkrizni();
        }

        private void ScanNextObracunobustave()
        {
            this.cmOBRACUNObustaveSelect2.HasMoreRows = this.OBRACUNObustaveSelect2.Read();
            this.RcdFound61 = 0;
            this.ScanLoadObracunobustave();
        }

        private void ScanNextObracunolaksice()
        {
            this.cmObracunOlaksiceSelect2.HasMoreRows = this.ObracunOlaksiceSelect2.Read();
            this.RcdFound13 = 0;
            this.ScanLoadObracunolaksice();
        }

        private void ScanNextObracunporezi()
        {
            this.cmObracunPoreziSelect2.HasMoreRows = this.ObracunPoreziSelect2.Read();
            this.RcdFound12 = 0;
            this.ScanLoadObracunporezi();
        }

        private void ScanNextObracunradnici()
        {
            this.cmObracunRadniciSelect2.HasMoreRows = this.ObracunRadniciSelect2.Read();
            this.RcdFound10 = 0;
            this.ScanLoadObracunradnici();
        }

        private void ScanStartObracun(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString9 + "  FROM [OBRACUN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOBRACUN]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString9, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOBRACUN] ) AS DK_PAGENUM   FROM [OBRACUN] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString9 + " FROM [OBRACUN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOBRACUN] ";
            }
            this.cmOBRACUNSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.OBRACUNSelect4 = this.cmOBRACUNSelect4.FetchData();
            this.RcdFound9 = 0;
            this.ScanLoadObracun();
            this.LoadDataObracun(maxRows);
            if (this.RcdFound9 > 0)
            {
                this.SubLvlScanStartObracunradnici(this.m_WhereString, startRow, maxRows);
                this.SetParametersObracunObracun(this.cmObracunRadniciSelect2);
                this.SubLvlFetchObracunradnici();
                this.SubLoadDataObracunradnici();
                this.SubLvlScanStartObracundoprinosi(this.m_WhereString, startRow, maxRows);
                this.SetParametersObracunObracun(this.cmObracunDoprinosiSelect2);
                this.SubLvlFetchObracundoprinosi();
                this.SubLoadDataObracundoprinosi();
                this.SubLvlScanStartObracunporezi(this.m_WhereString, startRow, maxRows);
                this.SetParametersObracunObracun(this.cmObracunPoreziSelect2);
                this.SubLvlFetchObracunporezi();
                this.SubLoadDataObracunporezi();
                this.SubLvlScanStartObracunolaksice(this.m_WhereString, startRow, maxRows);
                this.SetParametersObracunObracun(this.cmObracunOlaksiceSelect2);
                this.SubLvlFetchObracunolaksice();
                this.SubLoadDataObracunolaksice();
                this.SubLvlScanStartObracunkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersObracunObracun(this.cmOBRACUNKreditiSelect2);
                this.SubLvlFetchObracunkrediti();
                this.SubLoadDataObracunkrediti();
                this.SubLvlScanStartObracunobustave(this.m_WhereString, startRow, maxRows);
                this.SetParametersObracunObracun(this.cmOBRACUNObustaveSelect2);
                this.SubLvlFetchObracunobustave();
                this.SubLoadDataObracunobustave();
                this.SubLvlScanStartObracunelementi(this.m_WhereString, startRow, maxRows);
                this.SetParametersObracunObracun(this.cmObracunElementiSelect2);
                this.SubLvlFetchObracunelementi();
                this.SubLoadDataObracunelementi();
                this.SubLvlScanStartObracunobracunlevel1obracunkrizni(this.m_WhereString, startRow, maxRows);
                this.SetParametersObracunObracun(this.cmOBRACUNOBRACUNLevel1ObracunKrizniSelect2);
                this.SubLvlFetchObracunobracunlevel1obracunkrizni();
                this.SubLoadDataObracunobracunlevel1obracunkrizni();
                this.SubLvlScanStartObracunobracunlevel1obracunizuzece(this.m_WhereString, startRow, maxRows);
                this.SetParametersObracunObracun(this.cmOBRACUNOBRACUNLevel1ObracunIzuzeceSelect2);
                this.SubLvlFetchObracunobracunlevel1obracunizuzece();
                this.SubLoadDataObracunobracunlevel1obracunizuzece();
            }
        }

        private void ScanStartObracundoprinosi()
        {
            this.cmObracunDoprinosiSelect2 = this.connDefault.GetCommand("SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[VBDIDOPRINOS], T1.[ZRNDOPRINOS], T1.[NAZIVDOPRINOS], T1.[IDVRSTADOPRINOS], T1.[NAZIVVRSTADOPRINOS], T1.[STOPA], T1.[MODOPRINOS], T1.[PODOPRINOS], T1.[MZDOPRINOS], T1.[PZDOPRINOS], T1.[PRIMATELJDOPRINOS1], T1.[PRIMATELJDOPRINOS2], T1.[SIFRAOPISAPLACANJADOPRINOS], T1.[OPISPLACANJADOPRINOS], T1.[OBRACUNATIDOPRINOS], T1.[OSNOVICADOPRINOS], T2.[MINDOPRINOS], T2.[MAXDOPRINOS], T1.[IDDOPRINOS] FROM ([ObracunDoprinosi] T1 WITH (NOLOCK) INNER JOIN [DOPRINOS] T2 WITH (NOLOCK) ON T2.[IDDOPRINOS] = T1.[IDDOPRINOS]) WHERE T1.[IDOBRACUN] = @IDOBRACUN and T1.[IDRADNIK] = @IDRADNIK ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDDOPRINOS] ", false);
            if (this.cmObracunDoprinosiSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmObracunDoprinosiSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                this.cmObracunDoprinosiSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmObracunDoprinosiSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDOBRACUN"]));
            this.cmObracunDoprinosiSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDRADNIK"]));
            this.ObracunDoprinosiSelect2 = this.cmObracunDoprinosiSelect2.FetchData();
            this.RcdFound11 = 0;
            this.ScanLoadObracundoprinosi();
        }

        private void ScanStartObracunelementi()
        {
            this.cmObracunElementiSelect2 = this.connDefault.GetCommand("SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[ELEMENTRAZDOBLJEOD], T1.[ELEMENTRAZDOBLJEDO], T3.[NAZIVOSNOVAOSIGURANJA], T3.[RAZDOBLJESESMIJEPREKLAPATI], T1.[OBRSATI], T1.[OBRSATNICA], T1.[OBRIZNOS], T1.[NAZIVELEMENT], T1.[IDVRSTAELEMENTA], T1.[NAZIVVRSTAELEMENT], T1.[OBRPOSTOTAK], T2.[ZBRAJASATEUFONDSATI], T1.[IDELEMENT], T2.[IDOSNOVAOSIGURANJA] FROM (([ObracunElementi] T1 WITH (NOLOCK) INNER JOIN [ELEMENT] T2 WITH (NOLOCK) ON T2.[IDELEMENT] = T1.[IDELEMENT]) LEFT JOIN [OSNOVAOSIGURANJA] T3 WITH (NOLOCK) ON T3.[IDOSNOVAOSIGURANJA] = T2.[IDOSNOVAOSIGURANJA]) WHERE T1.[IDOBRACUN] = @IDOBRACUN and T1.[IDRADNIK] = @IDRADNIK ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDELEMENT], T1.[ELEMENTRAZDOBLJEOD], T1.[ELEMENTRAZDOBLJEDO] ", false);
            if (this.cmObracunElementiSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmObracunElementiSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                this.cmObracunElementiSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmObracunElementiSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDOBRACUN"]));
            this.cmObracunElementiSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDRADNIK"]));
            this.ObracunElementiSelect2 = this.cmObracunElementiSelect2.FetchData();
            this.RcdFound62 = 0;
            this.ScanLoadObracunelementi();
        }

        private void ScanStartObracunkrediti()
        {
            this.cmOBRACUNKreditiSelect2 = this.connDefault.GetCommand("SELECT [IDOBRACUN], [IDRADNIK], [DATUMUGOVORA], [NAZIVKREDITOR], [VBDIKREDITOR], [ZRNKREDITOR], [PRIMATELJKREDITOR1], [PRIMATELJKREDITOR2], [PRIMATELJKREDITOR3], [OBRSIFRAOPISAPLACANJAKREDITOR], [OBROPISPLACANJAKREDITOR], [OBRMOKREDITOR], [OBRPOKREDITOR], [OBRMZKREDITOR], [OBRPZKREDITOR], [OBRIZNOSRATEKREDITOR], [OBRACUNATIKUNSKIIZNOS], [VECOTPLACENOBROJRATA], [VECOTPLACENOUKUPNIIZNOS], [UKUPNIZNOSKREDITA], [IDKREDITOR] FROM [OBRACUNKrediti] WITH (NOLOCK) WHERE [IDOBRACUN] = @IDOBRACUN and [IDRADNIK] = @IDRADNIK ORDER BY [IDOBRACUN], [IDRADNIK], [IDKREDITOR], [DATUMUGOVORA] ", false);
            if (this.cmOBRACUNKreditiSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmOBRACUNKreditiSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                this.cmOBRACUNKreditiSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmOBRACUNKreditiSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["IDOBRACUN"]));
            this.cmOBRACUNKreditiSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["IDRADNIK"]));
            this.OBRACUNKreditiSelect2 = this.cmOBRACUNKreditiSelect2.FetchData();
            this.RcdFound74 = 0;
            this.ScanLoadObracunkrediti();
        }

        private void ScanStartObracunobracunlevel1obracunizuzece()
        {
            this.cmOBRACUNOBRACUNLevel1ObracunIzuzeceSelect2 = this.connDefault.GetCommand("SELECT [IDOBRACUN], [IDRADNIK], [IDOBRACUNIZUZECE], [PRIMATELJIZUZECE1], [PRIMATELJIZUZECE2], [PRIMATELJIZUZECE3], [SIFRAOPISAPLACANJAIZUZECE], [OPISPLACANJAIZUZECE], [VBDIIZUZECE], [TEKUCIIZUZECE], [MOIZUZECE], [POIZUZECE], [MZIZUZECE], [PZIZUZECE], [IZNOSIZUZECA] FROM [OBRACUNOBRACUNLevel1ObracunIzuzece] WITH (NOLOCK) WHERE [IDOBRACUN] = @IDOBRACUN and [IDRADNIK] = @IDRADNIK ORDER BY [IDOBRACUN], [IDRADNIK], [IDOBRACUNIZUZECE] ", false);
            if (this.cmOBRACUNOBRACUNLevel1ObracunIzuzeceSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmOBRACUNOBRACUNLevel1ObracunIzuzeceSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                this.cmOBRACUNOBRACUNLevel1ObracunIzuzeceSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmOBRACUNOBRACUNLevel1ObracunIzuzeceSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDOBRACUN"]));
            this.cmOBRACUNOBRACUNLevel1ObracunIzuzeceSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDRADNIK"]));
            this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2 = this.cmOBRACUNOBRACUNLevel1ObracunIzuzeceSelect2.FetchData();
            this.RcdFound292 = 0;
            this.ScanLoadObracunobracunlevel1obracunizuzece();
        }

        private void ScanStartObracunobracunlevel1obracunkrizni()
        {
            this.cmOBRACUNOBRACUNLevel1ObracunKrizniSelect2 = this.connDefault.GetCommand("SELECT [IDOBRACUN], [IDRADNIK], [NAZIVKRIZNIPOREZ], [KRIZNISTOPA], [MOKRIZNI], [POKRIZNI], [MZKRIZNI], [PZKRIZNI], [PRIMATELJKRIZNI1], [PRIMATELJKRIZNI2], [PRIMATELJKRIZNI3], [SIFRAOPISAPLACANJAKRIZNI], [OPISPLACANJAKRIZNI], [VBDIKRIZNI], [ZRNKRIZNI], [OSNOVICAKRIZNI], [POREZKRIZNI], [OSNOVICAPRETHODNA], [OSNOVICAUKUPNA], [POREZPRETHODNI], [POREZUKUPNO], [IDKRIZNIPOREZ] FROM [OBRACUNOBRACUNLevel1ObracunKrizni] WITH (NOLOCK) WHERE [IDOBRACUN] = @IDOBRACUN and [IDRADNIK] = @IDRADNIK ORDER BY [IDOBRACUN], [IDRADNIK], [IDKRIZNIPOREZ] ", false);
            if (this.cmOBRACUNOBRACUNLevel1ObracunKrizniSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmOBRACUNOBRACUNLevel1ObracunKrizniSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                this.cmOBRACUNOBRACUNLevel1ObracunKrizniSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmOBRACUNOBRACUNLevel1ObracunKrizniSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDOBRACUN"]));
            this.cmOBRACUNOBRACUNLevel1ObracunKrizniSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDRADNIK"]));
            this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2 = this.cmOBRACUNOBRACUNLevel1ObracunKrizniSelect2.FetchData();
            this.RcdFound137 = 0;
            this.ScanLoadObracunobracunlevel1obracunkrizni();
        }

        private void ScanStartObracunobustave()
        {
            this.cmOBRACUNObustaveSelect2 = this.connDefault.GetCommand("SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[NAZIVOBUSTAVA], T1.[MOOBUSTAVA], T1.[POOBUSTAVA], T1.[MZOBUSTAVA], T1.[PZOBUSTAVA], T1.[VBDIOBUSTAVA], T1.[ZRNOBUSTAVA], T1.[PRIMATELJOBUSTAVA1], T1.[PRIMATELJOBUSTAVA2], T1.[PRIMATELJOBUSTAVA3], T1.[SIFRAOPISAPLACANJAOBUSTAVA], T1.[OPISPLACANJAOBUSTAVA], T1.[VRSTAOBUSTAVE], T1.[NAZIVVRSTAOBUSTAVE], T1.[IZNOSOBUSTAVE], T1.[POSTOTAKOBUSTAVE], T1.[OBRACUNATAOBUSTAVAUKUNAMA], T1.[ISPLACENOKASA], T1.[SALDOKASA], T1.[IDOBUSTAVA] FROM ([OBRACUNObustave] T1 WITH (NOLOCK) INNER JOIN [OBUSTAVA] T2 WITH (NOLOCK) ON T2.[IDOBUSTAVA] = T1.[IDOBUSTAVA]) WHERE T1.[IDOBRACUN] = @IDOBRACUN and T1.[IDRADNIK] = @IDRADNIK ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDOBUSTAVA] ", false);
            if (this.cmOBRACUNObustaveSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmOBRACUNObustaveSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                this.cmOBRACUNObustaveSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmOBRACUNObustaveSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IDOBRACUN"]));
            this.cmOBRACUNObustaveSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IDRADNIK"]));
            this.OBRACUNObustaveSelect2 = this.cmOBRACUNObustaveSelect2.FetchData();
            this.RcdFound61 = 0;
            this.ScanLoadObracunobustave();
        }

        private void ScanStartObracunolaksice()
        {
            this.cmObracunOlaksiceSelect2 = this.connDefault.GetCommand("SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[NAZIVOLAKSICE], T1.[IDGRUPEOLAKSICA], T1.[NAZIVGRUPEOLAKSICA], T1.[MAXIMALNIIZNOSGRUPE], T1.[IDTIPOLAKSICE], T1.[NAZIVTIPOLAKSICE], T1.[VBDIOLAKSICA], T1.[ZRNOLAKSICA], T1.[PRIMATELJOLAKSICA1], T1.[PRIMATELJOLAKSICA2], T1.[PRIMATELJOLAKSICA3], T1.[MZOLAKSICA], T1.[PZOLAKSICA], T1.[MOOLAKSICA], T1.[POOLAKSICA], T1.[SIFRAOPISAPLACANJAOLAKSICA], T1.[OPISPLACANJAOLAKSICA], T1.[IZNOSOLAKSICE], T1.[OBRACUNATAOLAKSICA], T1.[IDOLAKSICE] FROM ([ObracunOlaksice] T1 WITH (NOLOCK) INNER JOIN [OLAKSICE] T2 WITH (NOLOCK) ON T2.[IDOLAKSICE] = T1.[IDOLAKSICE]) WHERE T1.[IDOBRACUN] = @IDOBRACUN and T1.[IDRADNIK] = @IDRADNIK ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDOLAKSICE] ", false);
            if (this.cmObracunOlaksiceSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmObracunOlaksiceSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                this.cmObracunOlaksiceSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmObracunOlaksiceSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDOBRACUN"]));
            this.cmObracunOlaksiceSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDRADNIK"]));
            this.ObracunOlaksiceSelect2 = this.cmObracunOlaksiceSelect2.FetchData();
            this.RcdFound13 = 0;
            this.ScanLoadObracunolaksice();
        }

        private void ScanStartObracunporezi()
        {
            this.cmObracunPoreziSelect2 = this.connDefault.GetCommand("SELECT [IDOBRACUN], [IDRADNIK], [NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], [MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ], [OBRACUNATIPOREZ], [OSNOVICAPOREZ], [IDPOREZ] FROM [ObracunPorezi] WITH (NOLOCK) WHERE [IDOBRACUN] = @IDOBRACUN and [IDRADNIK] = @IDRADNIK ORDER BY [IDOBRACUN], [IDRADNIK], [IDPOREZ] ", false);
            if (this.cmObracunPoreziSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmObracunPoreziSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                this.cmObracunPoreziSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmObracunPoreziSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["IDOBRACUN"]));
            this.cmObracunPoreziSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["IDRADNIK"]));
            this.ObracunPoreziSelect2 = this.cmObracunPoreziSelect2.FetchData();
            this.RcdFound12 = 0;
            this.ScanLoadObracunporezi();
        }

        private void ScanStartObracunradnici()
        {
            string statement = " SELECT T1.[IDOBRACUN], T2.[PREZIME], T2.[IME], T2.[ulica], T2.[mjesto], T2.[kucnibroj], T2.[JMBG], T2.[DATUMRODJENJA], T9.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T9.[PRIREZ] AS OPCINARADAPRIREZ, T10.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T10.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T1.[SIFRAOPCINESTANOVANJA], T4.[NAZIVBENEFICIRANI], T4.[BROJPRIZNATIHMJESECI], T3.[NAZIVBANKE1], T3.[NAZIVBANKE2], T3.[NAZIVBANKE3], T3.[VBDIBANKE], T3.[ZRNBANKE], T2.[TEKUCI], T2.[SIFRAOPISAPLACANJANETO], T2.[OPISPLACANJANETO], T2.[BROJMIROVINSKOG], T2.[BROJZDRAVSTVENOG], T2.[MBO], T2.[POSTOTAKOSLOBODJENJAODPOREZA], T1.[KOEFICIJENT], T1.[OBRACUNSKIKOEFICIJENT], T6.[NAZIVRADNOMJESTO], T13.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T12.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T7.[NAZIVSTRUKA], T11.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[AKTIVAN], T1.[ISKORISTENOOO], T1.[OBRACUNATIPRIREZ], T1.[faktoo], T2.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], T2.[TJEDNIFONDSATI], T2.[TJEDNIFONDSATISTAZ], T2.[GODINESTAZA], T2.[MJESECISTAZA], T2.[DANISTAZA], T2.[DATUMPRESTANKARADNOGODNOSA], T5.[NAZIVTITULA], T2.[ZBIRNINETO], T2.[UZIMAUOBZIROSNOVICEDOPRINOSA], T8.[ORGANIZACIJSKIDIO], T1.[IDIPIDENT], T2.[OIB], T1.[RADNIKOBRACUNOSNOVICA], T1.[KOREKCIJAPRIREZA], T1.[ODBITAKPRIJEKOREKCIJE], T1.[OBRACUNAVAJOBUSTAVE], T1.[IDRADNIK], T2.[IDBANKE], T2.[IDBENEFICIRANI], T2.[IDTITULA], T2.[IDRADNOMJESTO], T2.[IDSTRUKA], T2.[IDORGDIO], T2.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, T2.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, T2.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, T2.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, T2.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]  AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((([ObracunRadnici] T1 WITH (NOLOCK) INNER JOIN [RADNIK] T2 WITH (NOLOCK) ON T2.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [BANKE] T3 WITH (NOLOCK) ON T3.[IDBANKE] = T2.[IDBANKE]) INNER JOIN [BENEFICIRANI] T4 WITH (NOLOCK) ON T4.[IDBENEFICIRANI] = T2.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T5 WITH (NOLOCK) ON T5.[IDTITULA] = T2.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T6 WITH (NOLOCK) ON T6.[IDRADNOMJESTO] = T2.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T7 WITH (NOLOCK) ON T7.[IDSTRUKA] = T2.[IDSTRUKA]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = T2.[IDORGDIO]) INNER JOIN [OPCINA] T9 WITH (NOLOCK) ON T9.[IDOPCINE] = T2.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T10 WITH (NOLOCK) ON T10.[IDOPCINE] = T2.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T11 WITH (NOLOCK) ON T11.[IDSKUPPOREZAIDOPRINOSA] = T2.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T12 WITH (NOLOCK) ON T12.[IDSTRUCNASPREMA] = T2.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T13 WITH (NOLOCK) ON T13.[IDSTRUCNASPREMA] = T2.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE T1.[IDOBRACUN] = @IDOBRACUN ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK] ";
            this.cmObracunRadniciSelect2 = this.connDefault.GetCommand(statement, false);
            if (this.cmObracunRadniciSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmObracunRadniciSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
            }
            this.cmObracunRadniciSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDOBRACUN"]));
            this.ObracunRadniciSelect2 = this.cmObracunRadniciSelect2.FetchData();
            this.RcdFound10 = 0;
            this.ScanLoadObracunradnici();
        }

        private void SetParametersIDOBRACUNObracun(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["IDOBRACUN"]));
        }

        private void SetParametersObracunObracun(ReadWriteCommand m_Command)
        {
        }

        private void SkipNextObracundoprinosi()
        {
            this.cmObracunDoprinosiSelect2.HasMoreRows = this.ObracunDoprinosiSelect2.Read();
            this.RcdFound11 = 0;
            if (this.cmObracunDoprinosiSelect2.HasMoreRows)
            {
                this.RcdFound11 = 1;
            }
        }

        private void SkipNextObracunelementi()
        {
            this.cmObracunElementiSelect2.HasMoreRows = this.ObracunElementiSelect2.Read();
            this.RcdFound62 = 0;
            if (this.cmObracunElementiSelect2.HasMoreRows)
            {
                this.RcdFound62 = 1;
            }
        }

        private void SkipNextObracunkrediti()
        {
            this.cmOBRACUNKreditiSelect2.HasMoreRows = this.OBRACUNKreditiSelect2.Read();
            this.RcdFound74 = 0;
            if (this.cmOBRACUNKreditiSelect2.HasMoreRows)
            {
                this.RcdFound74 = 1;
            }
        }

        private void SkipNextObracunobracunlevel1obracunizuzece()
        {
            this.cmOBRACUNOBRACUNLevel1ObracunIzuzeceSelect2.HasMoreRows = this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2.Read();
            this.RcdFound292 = 0;
            if (this.cmOBRACUNOBRACUNLevel1ObracunIzuzeceSelect2.HasMoreRows)
            {
                this.RcdFound292 = 1;
            }
        }

        private void SkipNextObracunobracunlevel1obracunkrizni()
        {
            this.cmOBRACUNOBRACUNLevel1ObracunKrizniSelect2.HasMoreRows = this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2.Read();
            this.RcdFound137 = 0;
            if (this.cmOBRACUNOBRACUNLevel1ObracunKrizniSelect2.HasMoreRows)
            {
                this.RcdFound137 = 1;
            }
        }

        private void SkipNextObracunobustave()
        {
            this.cmOBRACUNObustaveSelect2.HasMoreRows = this.OBRACUNObustaveSelect2.Read();
            this.RcdFound61 = 0;
            if (this.cmOBRACUNObustaveSelect2.HasMoreRows)
            {
                this.RcdFound61 = 1;
            }
        }

        private void SkipNextObracunolaksice()
        {
            this.cmObracunOlaksiceSelect2.HasMoreRows = this.ObracunOlaksiceSelect2.Read();
            this.RcdFound13 = 0;
            if (this.cmObracunOlaksiceSelect2.HasMoreRows)
            {
                this.RcdFound13 = 1;
            }
        }

        private void SkipNextObracunporezi()
        {
            this.cmObracunPoreziSelect2.HasMoreRows = this.ObracunPoreziSelect2.Read();
            this.RcdFound12 = 0;
            if (this.cmObracunPoreziSelect2.HasMoreRows)
            {
                this.RcdFound12 = 1;
            }
        }

        private void SkipNextObracunradnici()
        {
            this.cmObracunRadniciSelect2.HasMoreRows = this.ObracunRadniciSelect2.Read();
            this.RcdFound10 = 0;
            if (this.cmObracunRadniciSelect2.HasMoreRows)
            {
                this.RcdFound10 = 1;
            }
        }

        private void StandaloneModalObracunkrediti()
        {
            this.rowOBRACUNKrediti.BRRATADOSADA = decimal.Zero;
            this.rowOBRACUNKrediti.DOSADAOBUSTAVLJENO = decimal.Zero;
        }

        private void StandaloneModalObracunobustave()
        {
            this.rowOBRACUNObustave.OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE = decimal.Zero;
            this.rowOBRACUNObustave.OBUSTAVLJENODOSADABROJRATA = decimal.Zero;
            this.rowOBRACUNObustave.OBUSTAVLJENODOSADA = decimal.Zero;
        }

        private void SubLoadDataObracundoprinosi()
        {
            while (this.RcdFound11 != 0)
            {
                this.LoadRowObracundoprinosi();
                this.CreateNewRowObracundoprinosi();
                this.ScanNextObracundoprinosi();
            }
            this.ScanEndObracundoprinosi();
        }

        private void SubLoadDataObracunelementi()
        {
            while (this.RcdFound62 != 0)
            {
                this.LoadRowObracunelementi();
                this.CreateNewRowObracunelementi();
                this.ScanNextObracunelementi();
            }
            this.ScanEndObracunelementi();
        }

        private void SubLoadDataObracunkrediti()
        {
            while (this.RcdFound74 != 0)
            {
                this.LoadRowObracunkrediti();
                this.CreateNewRowObracunkrediti();
                this.ScanNextObracunkrediti();
            }
            this.ScanEndObracunkrediti();
        }

        private void SubLoadDataObracunobracunlevel1obracunizuzece()
        {
            while (this.RcdFound292 != 0)
            {
                this.LoadRowObracunobracunlevel1obracunizuzece();
                this.CreateNewRowObracunobracunlevel1obracunizuzece();
                this.ScanNextObracunobracunlevel1obracunizuzece();
            }
            this.ScanEndObracunobracunlevel1obracunizuzece();
        }

        private void SubLoadDataObracunobracunlevel1obracunkrizni()
        {
            while (this.RcdFound137 != 0)
            {
                this.LoadRowObracunobracunlevel1obracunkrizni();
                this.CreateNewRowObracunobracunlevel1obracunkrizni();
                this.ScanNextObracunobracunlevel1obracunkrizni();
            }
            this.ScanEndObracunobracunlevel1obracunkrizni();
        }

        private void SubLoadDataObracunobustave()
        {
            while (this.RcdFound61 != 0)
            {
                this.LoadRowObracunobustave();
                this.CreateNewRowObracunobustave();
                this.ScanNextObracunobustave();
            }
            this.ScanEndObracunobustave();
        }

        private void SubLoadDataObracunolaksice()
        {
            while (this.RcdFound13 != 0)
            {
                this.LoadRowObracunolaksice();
                this.CreateNewRowObracunolaksice();
                this.ScanNextObracunolaksice();
            }
            this.ScanEndObracunolaksice();
        }

        private void SubLoadDataObracunporezi()
        {
            while (this.RcdFound12 != 0)
            {
                this.LoadRowObracunporezi();
                this.CreateNewRowObracunporezi();
                this.ScanNextObracunporezi();
            }
            this.ScanEndObracunporezi();
        }

        private void SubLoadDataObracunradnici()
        {
            while (this.RcdFound10 != 0)
            {
                this.LoadRowObracunradnici();
                this.CreateNewRowObracunradnici();
                this.ScanNextObracunradnici();
            }
            this.ScanEndObracunradnici();
        }

        private void SubLvlFetchObracundoprinosi()
        {
            this.CreateNewRowObracundoprinosi();
            this.ObracunDoprinosiSelect2 = this.cmObracunDoprinosiSelect2.FetchData();
            this.RcdFound11 = 0;
            this.ScanLoadObracundoprinosi();
        }

        private void SubLvlFetchObracunelementi()
        {
            this.CreateNewRowObracunelementi();
            this.ObracunElementiSelect2 = this.cmObracunElementiSelect2.FetchData();
            this.RcdFound62 = 0;
            this.ScanLoadObracunelementi();
        }

        private void SubLvlFetchObracunkrediti()
        {
            this.CreateNewRowObracunkrediti();
            this.OBRACUNKreditiSelect2 = this.cmOBRACUNKreditiSelect2.FetchData();
            this.RcdFound74 = 0;
            this.ScanLoadObracunkrediti();
        }

        private void SubLvlFetchObracunobracunlevel1obracunizuzece()
        {
            this.CreateNewRowObracunobracunlevel1obracunizuzece();
            this.OBRACUNOBRACUNLevel1ObracunIzuzeceSelect2 = this.cmOBRACUNOBRACUNLevel1ObracunIzuzeceSelect2.FetchData();
            this.RcdFound292 = 0;
            this.ScanLoadObracunobracunlevel1obracunizuzece();
        }

        private void SubLvlFetchObracunobracunlevel1obracunkrizni()
        {
            this.CreateNewRowObracunobracunlevel1obracunkrizni();
            this.OBRACUNOBRACUNLevel1ObracunKrizniSelect2 = this.cmOBRACUNOBRACUNLevel1ObracunKrizniSelect2.FetchData();
            this.RcdFound137 = 0;
            this.ScanLoadObracunobracunlevel1obracunkrizni();
        }

        private void SubLvlFetchObracunobustave()
        {
            this.CreateNewRowObracunobustave();
            this.OBRACUNObustaveSelect2 = this.cmOBRACUNObustaveSelect2.FetchData();
            this.RcdFound61 = 0;
            this.ScanLoadObracunobustave();
        }

        private void SubLvlFetchObracunolaksice()
        {
            this.CreateNewRowObracunolaksice();
            this.ObracunOlaksiceSelect2 = this.cmObracunOlaksiceSelect2.FetchData();
            this.RcdFound13 = 0;
            this.ScanLoadObracunolaksice();
        }

        private void SubLvlFetchObracunporezi()
        {
            this.CreateNewRowObracunporezi();
            this.ObracunPoreziSelect2 = this.cmObracunPoreziSelect2.FetchData();
            this.RcdFound12 = 0;
            this.ScanLoadObracunporezi();
        }

        private void SubLvlFetchObracunradnici()
        {
            this.CreateNewRowObracunradnici();
            this.ObracunRadniciSelect2 = this.cmObracunRadniciSelect2.FetchData();
            this.RcdFound10 = 0;
            this.ScanLoadObracunradnici();
        }

        private void SubLvlScanStartObracundoprinosi(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString11 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDOBRACUN]  FROM [OBRACUN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDOBRACUN] )";
                    this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[VBDIDOPRINOS], T1.[ZRNDOPRINOS], T1.[NAZIVDOPRINOS], T1.[IDVRSTADOPRINOS], T1.[NAZIVVRSTADOPRINOS], T1.[STOPA], T1.[MODOPRINOS], T1.[PODOPRINOS], T1.[MZDOPRINOS], T1.[PZDOPRINOS], T1.[PRIMATELJDOPRINOS1], T1.[PRIMATELJDOPRINOS2], T1.[SIFRAOPISAPLACANJADOPRINOS], T1.[OPISPLACANJADOPRINOS], T1.[OBRACUNATIDOPRINOS], T1.[OSNOVICADOPRINOS], T3.[MINDOPRINOS], T3.[MAXDOPRINOS], T1.[IDDOPRINOS] FROM (([ObracunDoprinosi] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString11 + "  TMX ON TMX.[IDOBRACUN] = T1.[IDOBRACUN]) INNER JOIN [DOPRINOS] T3 WITH (NOLOCK) ON T3.[IDDOPRINOS] = T1.[IDDOPRINOS]) ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDDOPRINOS]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDOBRACUN], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOBRACUN]  ) AS DK_PAGENUM   FROM [OBRACUN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString11 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[VBDIDOPRINOS], T1.[ZRNDOPRINOS], T1.[NAZIVDOPRINOS], T1.[IDVRSTADOPRINOS], T1.[NAZIVVRSTADOPRINOS], T1.[STOPA], T1.[MODOPRINOS], T1.[PODOPRINOS], T1.[MZDOPRINOS], T1.[PZDOPRINOS], T1.[PRIMATELJDOPRINOS1], T1.[PRIMATELJDOPRINOS2], T1.[SIFRAOPISAPLACANJADOPRINOS], T1.[OPISPLACANJADOPRINOS], T1.[OBRACUNATIDOPRINOS], T1.[OSNOVICADOPRINOS], T3.[MINDOPRINOS], T3.[MAXDOPRINOS], T1.[IDDOPRINOS] FROM (([ObracunDoprinosi] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString11 + "  TMX ON TMX.[IDOBRACUN] = T1.[IDOBRACUN]) INNER JOIN [DOPRINOS] T3 WITH (NOLOCK) ON T3.[IDDOPRINOS] = T1.[IDDOPRINOS]) ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDDOPRINOS]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString11 = "[OBRACUN]";
                this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[VBDIDOPRINOS], T1.[ZRNDOPRINOS], T1.[NAZIVDOPRINOS], T1.[IDVRSTADOPRINOS], T1.[NAZIVVRSTADOPRINOS], T1.[STOPA], T1.[MODOPRINOS], T1.[PODOPRINOS], T1.[MZDOPRINOS], T1.[PZDOPRINOS], T1.[PRIMATELJDOPRINOS1], T1.[PRIMATELJDOPRINOS2], T1.[SIFRAOPISAPLACANJADOPRINOS], T1.[OPISPLACANJADOPRINOS], T1.[OBRACUNATIDOPRINOS], T1.[OSNOVICADOPRINOS], T3.[MINDOPRINOS], T3.[MAXDOPRINOS], T1.[IDDOPRINOS] FROM (([ObracunDoprinosi] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString11 + "  TM1 WITH (NOLOCK) ON TM1.[IDOBRACUN] = T1.[IDOBRACUN]) INNER JOIN [DOPRINOS] T3 WITH (NOLOCK) ON T3.[IDDOPRINOS] = T1.[IDDOPRINOS])" + this.m_WhereString + " ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDDOPRINOS] ";
            }
            this.cmObracunDoprinosiSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartObracunelementi(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString62 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDOBRACUN]  FROM [OBRACUN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDOBRACUN] )";
                    this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[ELEMENTRAZDOBLJEOD], T1.[ELEMENTRAZDOBLJEDO], T4.[NAZIVOSNOVAOSIGURANJA], T4.[RAZDOBLJESESMIJEPREKLAPATI], T1.[OBRSATI], T1.[OBRSATNICA], T1.[OBRIZNOS], T1.[NAZIVELEMENT], T1.[IDVRSTAELEMENTA], T1.[NAZIVVRSTAELEMENT], T1.[OBRPOSTOTAK], T3.[ZBRAJASATEUFONDSATI], T1.[IDELEMENT], T3.[IDOSNOVAOSIGURANJA] FROM ((([ObracunElementi] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString62 + "  TMX ON TMX.[IDOBRACUN] = T1.[IDOBRACUN]) INNER JOIN [ELEMENT] T3 WITH (NOLOCK) ON T3.[IDELEMENT] = T1.[IDELEMENT]) LEFT JOIN [OSNOVAOSIGURANJA] T4 WITH (NOLOCK) ON T4.[IDOSNOVAOSIGURANJA] = T3.[IDOSNOVAOSIGURANJA]) ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDELEMENT], T1.[ELEMENTRAZDOBLJEOD], T1.[ELEMENTRAZDOBLJEDO]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDOBRACUN], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOBRACUN]  ) AS DK_PAGENUM   FROM [OBRACUN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString62 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[ELEMENTRAZDOBLJEOD], T1.[ELEMENTRAZDOBLJEDO], T4.[NAZIVOSNOVAOSIGURANJA], T4.[RAZDOBLJESESMIJEPREKLAPATI], T1.[OBRSATI], T1.[OBRSATNICA], T1.[OBRIZNOS], T1.[NAZIVELEMENT], T1.[IDVRSTAELEMENTA], T1.[NAZIVVRSTAELEMENT], T1.[OBRPOSTOTAK], T3.[ZBRAJASATEUFONDSATI], T1.[IDELEMENT], T3.[IDOSNOVAOSIGURANJA] FROM ((([ObracunElementi] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString62 + "  TMX ON TMX.[IDOBRACUN] = T1.[IDOBRACUN]) INNER JOIN [ELEMENT] T3 WITH (NOLOCK) ON T3.[IDELEMENT] = T1.[IDELEMENT]) LEFT JOIN [OSNOVAOSIGURANJA] T4 WITH (NOLOCK) ON T4.[IDOSNOVAOSIGURANJA] = T3.[IDOSNOVAOSIGURANJA]) ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDELEMENT], T1.[ELEMENTRAZDOBLJEOD], T1.[ELEMENTRAZDOBLJEDO]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString62 = "[OBRACUN]";
                this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[ELEMENTRAZDOBLJEOD], T1.[ELEMENTRAZDOBLJEDO], T4.[NAZIVOSNOVAOSIGURANJA], T4.[RAZDOBLJESESMIJEPREKLAPATI], T1.[OBRSATI], T1.[OBRSATNICA], T1.[OBRIZNOS], T1.[NAZIVELEMENT], T1.[IDVRSTAELEMENTA], T1.[NAZIVVRSTAELEMENT], T1.[OBRPOSTOTAK], T3.[ZBRAJASATEUFONDSATI], T1.[IDELEMENT], T3.[IDOSNOVAOSIGURANJA] FROM ((([ObracunElementi] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString62 + "  TM1 WITH (NOLOCK) ON TM1.[IDOBRACUN] = T1.[IDOBRACUN]) INNER JOIN [ELEMENT] T3 WITH (NOLOCK) ON T3.[IDELEMENT] = T1.[IDELEMENT]) LEFT JOIN [OSNOVAOSIGURANJA] T4 WITH (NOLOCK) ON T4.[IDOSNOVAOSIGURANJA] = T3.[IDOSNOVAOSIGURANJA])" + this.m_WhereString + " ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDELEMENT], T1.[ELEMENTRAZDOBLJEOD], T1.[ELEMENTRAZDOBLJEDO] ";
            }
            this.cmObracunElementiSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartObracunkrediti(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString74 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDOBRACUN]  FROM [OBRACUN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDOBRACUN] )";
                    this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[DATUMUGOVORA], T1.[NAZIVKREDITOR], T1.[VBDIKREDITOR], T1.[ZRNKREDITOR], T1.[PRIMATELJKREDITOR1], T1.[PRIMATELJKREDITOR2], T1.[PRIMATELJKREDITOR3], T1.[OBRSIFRAOPISAPLACANJAKREDITOR], T1.[OBROPISPLACANJAKREDITOR], T1.[OBRMOKREDITOR], T1.[OBRPOKREDITOR], T1.[OBRMZKREDITOR], T1.[OBRPZKREDITOR], T1.[OBRIZNOSRATEKREDITOR], T1.[OBRACUNATIKUNSKIIZNOS], T1.[VECOTPLACENOBROJRATA], T1.[VECOTPLACENOUKUPNIIZNOS], T1.[UKUPNIZNOSKREDITA], T1.[IDKREDITOR] FROM ([OBRACUNKrediti] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString74 + "  TMX ON TMX.[IDOBRACUN] = T1.[IDOBRACUN]) ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDKREDITOR], T1.[DATUMUGOVORA]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDOBRACUN], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOBRACUN]  ) AS DK_PAGENUM   FROM [OBRACUN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString74 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[DATUMUGOVORA], T1.[NAZIVKREDITOR], T1.[VBDIKREDITOR], T1.[ZRNKREDITOR], T1.[PRIMATELJKREDITOR1], T1.[PRIMATELJKREDITOR2], T1.[PRIMATELJKREDITOR3], T1.[OBRSIFRAOPISAPLACANJAKREDITOR], T1.[OBROPISPLACANJAKREDITOR], T1.[OBRMOKREDITOR], T1.[OBRPOKREDITOR], T1.[OBRMZKREDITOR], T1.[OBRPZKREDITOR], T1.[OBRIZNOSRATEKREDITOR], T1.[OBRACUNATIKUNSKIIZNOS], T1.[VECOTPLACENOBROJRATA], T1.[VECOTPLACENOUKUPNIIZNOS], T1.[UKUPNIZNOSKREDITA], T1.[IDKREDITOR] FROM ([OBRACUNKrediti] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString74 + "  TMX ON TMX.[IDOBRACUN] = T1.[IDOBRACUN]) ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDKREDITOR], T1.[DATUMUGOVORA]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString74 = "[OBRACUN]";
                this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[DATUMUGOVORA], T1.[NAZIVKREDITOR], T1.[VBDIKREDITOR], T1.[ZRNKREDITOR], T1.[PRIMATELJKREDITOR1], T1.[PRIMATELJKREDITOR2], T1.[PRIMATELJKREDITOR3], T1.[OBRSIFRAOPISAPLACANJAKREDITOR], T1.[OBROPISPLACANJAKREDITOR], T1.[OBRMOKREDITOR], T1.[OBRPOKREDITOR], T1.[OBRMZKREDITOR], T1.[OBRPZKREDITOR], T1.[OBRIZNOSRATEKREDITOR], T1.[OBRACUNATIKUNSKIIZNOS], T1.[VECOTPLACENOBROJRATA], T1.[VECOTPLACENOUKUPNIIZNOS], T1.[UKUPNIZNOSKREDITA], T1.[IDKREDITOR] FROM ([OBRACUNKrediti] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString74 + "  TM1 WITH (NOLOCK) ON TM1.[IDOBRACUN] = T1.[IDOBRACUN])" + this.m_WhereString + " ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDKREDITOR], T1.[DATUMUGOVORA] ";
            }
            this.cmOBRACUNKreditiSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartObracunobracunlevel1obracunizuzece(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString292 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDOBRACUN]  FROM [OBRACUN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDOBRACUN] )";
                    this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDOBRACUNIZUZECE], T1.[PRIMATELJIZUZECE1], T1.[PRIMATELJIZUZECE2], T1.[PRIMATELJIZUZECE3], T1.[SIFRAOPISAPLACANJAIZUZECE], T1.[OPISPLACANJAIZUZECE], T1.[VBDIIZUZECE], T1.[TEKUCIIZUZECE], T1.[MOIZUZECE], T1.[POIZUZECE], T1.[MZIZUZECE], T1.[PZIZUZECE], T1.[IZNOSIZUZECA] FROM ([OBRACUNOBRACUNLevel1ObracunIzuzece] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString292 + "  TMX ON TMX.[IDOBRACUN] = T1.[IDOBRACUN]) ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDOBRACUNIZUZECE]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDOBRACUN], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOBRACUN]  ) AS DK_PAGENUM   FROM [OBRACUN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString292 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDOBRACUNIZUZECE], T1.[PRIMATELJIZUZECE1], T1.[PRIMATELJIZUZECE2], T1.[PRIMATELJIZUZECE3], T1.[SIFRAOPISAPLACANJAIZUZECE], T1.[OPISPLACANJAIZUZECE], T1.[VBDIIZUZECE], T1.[TEKUCIIZUZECE], T1.[MOIZUZECE], T1.[POIZUZECE], T1.[MZIZUZECE], T1.[PZIZUZECE], T1.[IZNOSIZUZECA] FROM ([OBRACUNOBRACUNLevel1ObracunIzuzece] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString292 + "  TMX ON TMX.[IDOBRACUN] = T1.[IDOBRACUN]) ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDOBRACUNIZUZECE]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString292 = "[OBRACUN]";
                this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDOBRACUNIZUZECE], T1.[PRIMATELJIZUZECE1], T1.[PRIMATELJIZUZECE2], T1.[PRIMATELJIZUZECE3], T1.[SIFRAOPISAPLACANJAIZUZECE], T1.[OPISPLACANJAIZUZECE], T1.[VBDIIZUZECE], T1.[TEKUCIIZUZECE], T1.[MOIZUZECE], T1.[POIZUZECE], T1.[MZIZUZECE], T1.[PZIZUZECE], T1.[IZNOSIZUZECA] FROM ([OBRACUNOBRACUNLevel1ObracunIzuzece] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString292 + "  TM1 WITH (NOLOCK) ON TM1.[IDOBRACUN] = T1.[IDOBRACUN])" + this.m_WhereString + " ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDOBRACUNIZUZECE] ";
            }
            this.cmOBRACUNOBRACUNLevel1ObracunIzuzeceSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartObracunobracunlevel1obracunkrizni(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString137 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDOBRACUN]  FROM [OBRACUN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDOBRACUN] )";
                    this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[NAZIVKRIZNIPOREZ], T1.[KRIZNISTOPA], T1.[MOKRIZNI], T1.[POKRIZNI], T1.[MZKRIZNI], T1.[PZKRIZNI], T1.[PRIMATELJKRIZNI1], T1.[PRIMATELJKRIZNI2], T1.[PRIMATELJKRIZNI3], T1.[SIFRAOPISAPLACANJAKRIZNI], T1.[OPISPLACANJAKRIZNI], T1.[VBDIKRIZNI], T1.[ZRNKRIZNI], T1.[OSNOVICAKRIZNI], T1.[POREZKRIZNI], T1.[OSNOVICAPRETHODNA], T1.[OSNOVICAUKUPNA], T1.[POREZPRETHODNI], T1.[POREZUKUPNO], T1.[IDKRIZNIPOREZ] FROM ([OBRACUNOBRACUNLevel1ObracunKrizni] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString137 + "  TMX ON TMX.[IDOBRACUN] = T1.[IDOBRACUN]) ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDKRIZNIPOREZ]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDOBRACUN], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOBRACUN]  ) AS DK_PAGENUM   FROM [OBRACUN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString137 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[NAZIVKRIZNIPOREZ], T1.[KRIZNISTOPA], T1.[MOKRIZNI], T1.[POKRIZNI], T1.[MZKRIZNI], T1.[PZKRIZNI], T1.[PRIMATELJKRIZNI1], T1.[PRIMATELJKRIZNI2], T1.[PRIMATELJKRIZNI3], T1.[SIFRAOPISAPLACANJAKRIZNI], T1.[OPISPLACANJAKRIZNI], T1.[VBDIKRIZNI], T1.[ZRNKRIZNI], T1.[OSNOVICAKRIZNI], T1.[POREZKRIZNI], T1.[OSNOVICAPRETHODNA], T1.[OSNOVICAUKUPNA], T1.[POREZPRETHODNI], T1.[POREZUKUPNO], T1.[IDKRIZNIPOREZ] FROM ([OBRACUNOBRACUNLevel1ObracunKrizni] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString137 + "  TMX ON TMX.[IDOBRACUN] = T1.[IDOBRACUN]) ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDKRIZNIPOREZ]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString137 = "[OBRACUN]";
                this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[NAZIVKRIZNIPOREZ], T1.[KRIZNISTOPA], T1.[MOKRIZNI], T1.[POKRIZNI], T1.[MZKRIZNI], T1.[PZKRIZNI], T1.[PRIMATELJKRIZNI1], T1.[PRIMATELJKRIZNI2], T1.[PRIMATELJKRIZNI3], T1.[SIFRAOPISAPLACANJAKRIZNI], T1.[OPISPLACANJAKRIZNI], T1.[VBDIKRIZNI], T1.[ZRNKRIZNI], T1.[OSNOVICAKRIZNI], T1.[POREZKRIZNI], T1.[OSNOVICAPRETHODNA], T1.[OSNOVICAUKUPNA], T1.[POREZPRETHODNI], T1.[POREZUKUPNO], T1.[IDKRIZNIPOREZ] FROM ([OBRACUNOBRACUNLevel1ObracunKrizni] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString137 + "  TM1 WITH (NOLOCK) ON TM1.[IDOBRACUN] = T1.[IDOBRACUN])" + this.m_WhereString + " ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDKRIZNIPOREZ] ";
            }
            this.cmOBRACUNOBRACUNLevel1ObracunKrizniSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartObracunobustave(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString61 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDOBRACUN]  FROM [OBRACUN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDOBRACUN] )";
                    this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[NAZIVOBUSTAVA], T1.[MOOBUSTAVA], T1.[POOBUSTAVA], T1.[MZOBUSTAVA], T1.[PZOBUSTAVA], T1.[VBDIOBUSTAVA], T1.[ZRNOBUSTAVA], T1.[PRIMATELJOBUSTAVA1], T1.[PRIMATELJOBUSTAVA2], T1.[PRIMATELJOBUSTAVA3], T1.[SIFRAOPISAPLACANJAOBUSTAVA], T1.[OPISPLACANJAOBUSTAVA], T1.[VRSTAOBUSTAVE], T1.[NAZIVVRSTAOBUSTAVE], T1.[IZNOSOBUSTAVE], T1.[POSTOTAKOBUSTAVE], T1.[OBRACUNATAOBUSTAVAUKUNAMA], T1.[ISPLACENOKASA], T1.[SALDOKASA], T1.[IDOBUSTAVA] FROM (([OBRACUNObustave] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString61 + "  TMX ON TMX.[IDOBRACUN] = T1.[IDOBRACUN]) INNER JOIN [OBUSTAVA] T3 WITH (NOLOCK) ON T3.[IDOBUSTAVA] = T1.[IDOBUSTAVA]) ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDOBUSTAVA]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDOBRACUN], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOBRACUN]  ) AS DK_PAGENUM   FROM [OBRACUN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString61 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[NAZIVOBUSTAVA], T1.[MOOBUSTAVA], T1.[POOBUSTAVA], T1.[MZOBUSTAVA], T1.[PZOBUSTAVA], T1.[VBDIOBUSTAVA], T1.[ZRNOBUSTAVA], T1.[PRIMATELJOBUSTAVA1], T1.[PRIMATELJOBUSTAVA2], T1.[PRIMATELJOBUSTAVA3], T1.[SIFRAOPISAPLACANJAOBUSTAVA], T1.[OPISPLACANJAOBUSTAVA], T1.[VRSTAOBUSTAVE], T1.[NAZIVVRSTAOBUSTAVE], T1.[IZNOSOBUSTAVE], T1.[POSTOTAKOBUSTAVE], T1.[OBRACUNATAOBUSTAVAUKUNAMA], T1.[ISPLACENOKASA], T1.[SALDOKASA], T1.[IDOBUSTAVA] FROM (([OBRACUNObustave] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString61 + "  TMX ON TMX.[IDOBRACUN] = T1.[IDOBRACUN]) INNER JOIN [OBUSTAVA] T3 WITH (NOLOCK) ON T3.[IDOBUSTAVA] = T1.[IDOBUSTAVA]) ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDOBUSTAVA]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString61 = "[OBRACUN]";
                this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[NAZIVOBUSTAVA], T1.[MOOBUSTAVA], T1.[POOBUSTAVA], T1.[MZOBUSTAVA], T1.[PZOBUSTAVA], T1.[VBDIOBUSTAVA], T1.[ZRNOBUSTAVA], T1.[PRIMATELJOBUSTAVA1], T1.[PRIMATELJOBUSTAVA2], T1.[PRIMATELJOBUSTAVA3], T1.[SIFRAOPISAPLACANJAOBUSTAVA], T1.[OPISPLACANJAOBUSTAVA], T1.[VRSTAOBUSTAVE], T1.[NAZIVVRSTAOBUSTAVE], T1.[IZNOSOBUSTAVE], T1.[POSTOTAKOBUSTAVE], T1.[OBRACUNATAOBUSTAVAUKUNAMA], T1.[ISPLACENOKASA], T1.[SALDOKASA], T1.[IDOBUSTAVA] FROM (([OBRACUNObustave] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString61 + "  TM1 WITH (NOLOCK) ON TM1.[IDOBRACUN] = T1.[IDOBRACUN]) INNER JOIN [OBUSTAVA] T3 WITH (NOLOCK) ON T3.[IDOBUSTAVA] = T1.[IDOBUSTAVA])" + this.m_WhereString + " ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDOBUSTAVA] ";
            }
            this.cmOBRACUNObustaveSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartObracunolaksice(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString13 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDOBRACUN]  FROM [OBRACUN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDOBRACUN] )";
                    this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[NAZIVOLAKSICE], T1.[IDGRUPEOLAKSICA], T1.[NAZIVGRUPEOLAKSICA], T1.[MAXIMALNIIZNOSGRUPE], T1.[IDTIPOLAKSICE], T1.[NAZIVTIPOLAKSICE], T1.[VBDIOLAKSICA], T1.[ZRNOLAKSICA], T1.[PRIMATELJOLAKSICA1], T1.[PRIMATELJOLAKSICA2], T1.[PRIMATELJOLAKSICA3], T1.[MZOLAKSICA], T1.[PZOLAKSICA], T1.[MOOLAKSICA], T1.[POOLAKSICA], T1.[SIFRAOPISAPLACANJAOLAKSICA], T1.[OPISPLACANJAOLAKSICA], T1.[IZNOSOLAKSICE], T1.[OBRACUNATAOLAKSICA], T1.[IDOLAKSICE] FROM (([ObracunOlaksice] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString13 + "  TMX ON TMX.[IDOBRACUN] = T1.[IDOBRACUN]) INNER JOIN [OLAKSICE] T3 WITH (NOLOCK) ON T3.[IDOLAKSICE] = T1.[IDOLAKSICE]) ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDOLAKSICE]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDOBRACUN], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOBRACUN]  ) AS DK_PAGENUM   FROM [OBRACUN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString13 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[NAZIVOLAKSICE], T1.[IDGRUPEOLAKSICA], T1.[NAZIVGRUPEOLAKSICA], T1.[MAXIMALNIIZNOSGRUPE], T1.[IDTIPOLAKSICE], T1.[NAZIVTIPOLAKSICE], T1.[VBDIOLAKSICA], T1.[ZRNOLAKSICA], T1.[PRIMATELJOLAKSICA1], T1.[PRIMATELJOLAKSICA2], T1.[PRIMATELJOLAKSICA3], T1.[MZOLAKSICA], T1.[PZOLAKSICA], T1.[MOOLAKSICA], T1.[POOLAKSICA], T1.[SIFRAOPISAPLACANJAOLAKSICA], T1.[OPISPLACANJAOLAKSICA], T1.[IZNOSOLAKSICE], T1.[OBRACUNATAOLAKSICA], T1.[IDOLAKSICE] FROM (([ObracunOlaksice] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString13 + "  TMX ON TMX.[IDOBRACUN] = T1.[IDOBRACUN]) INNER JOIN [OLAKSICE] T3 WITH (NOLOCK) ON T3.[IDOLAKSICE] = T1.[IDOLAKSICE]) ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDOLAKSICE]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString13 = "[OBRACUN]";
                this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[NAZIVOLAKSICE], T1.[IDGRUPEOLAKSICA], T1.[NAZIVGRUPEOLAKSICA], T1.[MAXIMALNIIZNOSGRUPE], T1.[IDTIPOLAKSICE], T1.[NAZIVTIPOLAKSICE], T1.[VBDIOLAKSICA], T1.[ZRNOLAKSICA], T1.[PRIMATELJOLAKSICA1], T1.[PRIMATELJOLAKSICA2], T1.[PRIMATELJOLAKSICA3], T1.[MZOLAKSICA], T1.[PZOLAKSICA], T1.[MOOLAKSICA], T1.[POOLAKSICA], T1.[SIFRAOPISAPLACANJAOLAKSICA], T1.[OPISPLACANJAOLAKSICA], T1.[IZNOSOLAKSICE], T1.[OBRACUNATAOLAKSICA], T1.[IDOLAKSICE] FROM (([ObracunOlaksice] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString13 + "  TM1 WITH (NOLOCK) ON TM1.[IDOBRACUN] = T1.[IDOBRACUN]) INNER JOIN [OLAKSICE] T3 WITH (NOLOCK) ON T3.[IDOLAKSICE] = T1.[IDOLAKSICE])" + this.m_WhereString + " ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDOLAKSICE] ";
            }
            this.cmObracunOlaksiceSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartObracunporezi(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString12 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDOBRACUN]  FROM [OBRACUN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDOBRACUN] )";
                    this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[NAZIVPOREZ], T1.[STOPAPOREZA], T1.[POREZMJESECNO], T1.[MOPOREZ], T1.[POPOREZ], T1.[MZPOREZ], T1.[PZPOREZ], T1.[PRIMATELJPOREZ1], T1.[PRIMATELJPOREZ2], T1.[SIFRAOPISAPLACANJAPOREZ], T1.[OPISPLACANJAPOREZ], T1.[OBRACUNATIPOREZ], T1.[OSNOVICAPOREZ], T1.[IDPOREZ] FROM ([ObracunPorezi] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString12 + "  TMX ON TMX.[IDOBRACUN] = T1.[IDOBRACUN]) ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDPOREZ]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDOBRACUN], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOBRACUN]  ) AS DK_PAGENUM   FROM [OBRACUN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString12 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[NAZIVPOREZ], T1.[STOPAPOREZA], T1.[POREZMJESECNO], T1.[MOPOREZ], T1.[POPOREZ], T1.[MZPOREZ], T1.[PZPOREZ], T1.[PRIMATELJPOREZ1], T1.[PRIMATELJPOREZ2], T1.[SIFRAOPISAPLACANJAPOREZ], T1.[OPISPLACANJAPOREZ], T1.[OBRACUNATIPOREZ], T1.[OSNOVICAPOREZ], T1.[IDPOREZ] FROM ([ObracunPorezi] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString12 + "  TMX ON TMX.[IDOBRACUN] = T1.[IDOBRACUN]) ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDPOREZ]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString12 = "[OBRACUN]";
                this.scmdbuf = "SELECT T1.[IDOBRACUN], T1.[IDRADNIK], T1.[NAZIVPOREZ], T1.[STOPAPOREZA], T1.[POREZMJESECNO], T1.[MOPOREZ], T1.[POPOREZ], T1.[MZPOREZ], T1.[PZPOREZ], T1.[PRIMATELJPOREZ1], T1.[PRIMATELJPOREZ2], T1.[SIFRAOPISAPLACANJAPOREZ], T1.[OPISPLACANJAPOREZ], T1.[OBRACUNATIPOREZ], T1.[OSNOVICAPOREZ], T1.[IDPOREZ] FROM ([ObracunPorezi] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString12 + "  TM1 WITH (NOLOCK) ON TM1.[IDOBRACUN] = T1.[IDOBRACUN])" + this.m_WhereString + " ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK], T1.[IDPOREZ] ";
            }
            this.cmObracunPoreziSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartObracunradnici(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString10 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDOBRACUN]  FROM [OBRACUN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDOBRACUN] )";
                    this.scmdbuf = "";
                    this.scmdbuf = this.scmdbuf + "SELECT T1.[IDOBRACUN], T3.[PREZIME], T3.[IME], T3.[ulica], T3.[mjesto], T3.[kucnibroj], T3.[JMBG], T3.[DATUMRODJENJA], T10.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T10.[PRIREZ] AS OPCINARADAPRIREZ, T11.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T11.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T1.[SIFRAOPCINESTANOVANJA], T5.[NAZIVBENEFICIRANI], T5.[BROJPRIZNATIHMJESECI], T4.[NAZIVBANKE1], T4.[NAZIVBANKE2], T4.[NAZIVBANKE3], T4.[VBDIBANKE], T4.[ZRNBANKE], T3.[TEKUCI], T3.[SIFRAOPISAPLACANJANETO], T3.[OPISPLACANJANETO], T3.[BROJMIROVINSKOG], T3.[BROJZDRAVSTVENOG], T3.[MBO], T3.[POSTOTAKOSLOBODJENJAODPOREZA], T1.[KOEFICIJENT], T1.[OBRACUNSKIKOEFICIJENT], T7.[NAZIVRADNOMJESTO], T14.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T13.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T8.[NAZIVSTRUKA], T12.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T3.[AKTIVAN], T1.[ISKORISTENOOO], T1.[OBRACUNATIPRIREZ], T1.[faktoo], T3.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], T3.[TJEDNIFONDSATI], T3.[TJEDNIFONDSATISTAZ], T3.[GODINESTAZA], T3.[MJESECISTAZA], T3.[DANISTAZA], T3.[DATUMPRESTANKARADNOGODNOSA], T6.[NAZIVTITULA], T3.[ZBIRNINETO], T3.[UZIMAUOBZIROSNOVICEDOPRINOSA], T9.[ORGANIZACIJSKIDIO], T1.[IDIPIDENT], T3.[OIB], T1.[RADNIKOBRACUNOSNOVICA], T1.[KOREKCIJAPRIREZA], T1.[ODBITAKPRIJEKOREKCIJE], T1.[OBRACUNAVAJOBUSTAVE], T1.[IDRADNIK], T3.[IDBANKE], T3.[IDBENEFICIRANI], T3.[IDTITULA], T3.[IDRADNOMJESTO], T3.[IDSTRUKA], T3.[IDORGDIO], T3.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, T3.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, T3.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, T3.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, T3.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]";
                    this.scmdbuf = this.scmdbuf + " AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM ((((((((((((([ObracunRadnici] T1 WITH (NOLOCK) INNER JOIN  ";
                    this.scmdbuf = this.scmdbuf + this.m_SubSelTopString10 + "  TMX ON TMX.[IDOBRACUN] = T1.[IDOBRACUN]) INNER JOIN [RADNIK] T3 WITH (NOLOCK) ON T3.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [BANKE] T4 WITH (NOLOCK) ON T4.[IDBANKE] = T3.[IDBANKE]) INNER JOIN [BENEFICIRANI] T5 WITH (NOLOCK) ON T5.[IDBENEFICIRANI] = T3.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T6 WITH (NOLOCK) ON T6.[IDTITULA] = T3.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T7 WITH (NOLOCK) ON T7.[IDRADNOMJESTO] = T3.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T8 WITH (NOLOCK) ON T8.[IDSTRUKA] = T3.[IDSTRUKA]) LEFT JOIN [ORGDIO] T9 WITH (NOLOCK) ON T9.[IDORGDIO] = T3.[IDORGDIO]) INNER JOIN [OPCINA] T10 WITH (NOLOCK) ON T10.[IDOPCINE] = T3.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T11 WITH (NOLOCK) ON T11.[IDOPCINE] = T3.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T12 WITH (NOLOCK) ON T12.[IDSKUPPOREZAIDOPRINOSA] = T3.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T13 WITH (NOLOCK) ON T13.[IDSTRUCNASPREMA] = T3.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T14 WITH (NOLOCK) ON T14.[IDSTRUCNASPREMA] = T3.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDOBRACUN], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOBRACUN]  ) AS DK_PAGENUM   FROM [OBRACUN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString10 = string.Concat(strArray);
                    this.scmdbuf = "";
                    this.scmdbuf = this.scmdbuf + "SELECT T1.[IDOBRACUN], T3.[PREZIME], T3.[IME], T3.[ulica], T3.[mjesto], T3.[kucnibroj], T3.[JMBG], T3.[DATUMRODJENJA], T10.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T10.[PRIREZ] AS OPCINARADAPRIREZ, T11.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T11.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T1.[SIFRAOPCINESTANOVANJA], T5.[NAZIVBENEFICIRANI], T5.[BROJPRIZNATIHMJESECI], T4.[NAZIVBANKE1], T4.[NAZIVBANKE2], T4.[NAZIVBANKE3], T4.[VBDIBANKE], T4.[ZRNBANKE], T3.[TEKUCI], T3.[SIFRAOPISAPLACANJANETO], T3.[OPISPLACANJANETO], T3.[BROJMIROVINSKOG], T3.[BROJZDRAVSTVENOG], T3.[MBO], T3.[POSTOTAKOSLOBODJENJAODPOREZA], T1.[KOEFICIJENT], T1.[OBRACUNSKIKOEFICIJENT], T7.[NAZIVRADNOMJESTO], T14.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T13.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T8.[NAZIVSTRUKA], T12.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T3.[AKTIVAN], T1.[ISKORISTENOOO], T1.[OBRACUNATIPRIREZ], T1.[faktoo], T3.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], T3.[TJEDNIFONDSATI], T3.[TJEDNIFONDSATISTAZ], T3.[GODINESTAZA], T3.[MJESECISTAZA], T3.[DANISTAZA], T3.[DATUMPRESTANKARADNOGODNOSA], T6.[NAZIVTITULA], T3.[ZBIRNINETO], T3.[UZIMAUOBZIROSNOVICEDOPRINOSA], T9.[ORGANIZACIJSKIDIO], T1.[IDIPIDENT], T3.[OIB], T1.[RADNIKOBRACUNOSNOVICA], T1.[KOREKCIJAPRIREZA], T1.[ODBITAKPRIJEKOREKCIJE], T1.[OBRACUNAVAJOBUSTAVE], T1.[IDRADNIK], T3.[IDBANKE], T3.[IDBENEFICIRANI], T3.[IDTITULA], T3.[IDRADNOMJESTO], T3.[IDSTRUKA], T3.[IDORGDIO], T3.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, T3.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, T3.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, T3.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, T3.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]";
                    this.scmdbuf = this.scmdbuf + " AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM ((((((((((((([ObracunRadnici] T1 WITH (NOLOCK) INNER JOIN  ";
                    this.scmdbuf = this.scmdbuf + this.m_SubSelTopString10 + "  TMX ON TMX.[IDOBRACUN] = T1.[IDOBRACUN]) INNER JOIN [RADNIK] T3 WITH (NOLOCK) ON T3.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [BANKE] T4 WITH (NOLOCK) ON T4.[IDBANKE] = T3.[IDBANKE]) INNER JOIN [BENEFICIRANI] T5 WITH (NOLOCK) ON T5.[IDBENEFICIRANI] = T3.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T6 WITH (NOLOCK) ON T6.[IDTITULA] = T3.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T7 WITH (NOLOCK) ON T7.[IDRADNOMJESTO] = T3.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T8 WITH (NOLOCK) ON T8.[IDSTRUKA] = T3.[IDSTRUKA]) LEFT JOIN [ORGDIO] T9 WITH (NOLOCK) ON T9.[IDORGDIO] = T3.[IDORGDIO]) INNER JOIN [OPCINA] T10 WITH (NOLOCK) ON T10.[IDOPCINE] = T3.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T11 WITH (NOLOCK) ON T11.[IDOPCINE] = T3.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T12 WITH (NOLOCK) ON T12.[IDSKUPPOREZAIDOPRINOSA] = T3.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T13 WITH (NOLOCK) ON T13.[IDSTRUCNASPREMA] = T3.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T14 WITH (NOLOCK) ON T14.[IDSTRUCNASPREMA] = T3.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString10 = "[OBRACUN]";
                this.scmdbuf = "";
                this.scmdbuf = this.scmdbuf + "SELECT T1.[IDOBRACUN], T3.[PREZIME], T3.[IME], T3.[ulica], T3.[mjesto], T3.[kucnibroj], T3.[JMBG], T3.[DATUMRODJENJA], T10.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T10.[PRIREZ] AS OPCINARADAPRIREZ, T11.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T11.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T1.[SIFRAOPCINESTANOVANJA], T5.[NAZIVBENEFICIRANI], T5.[BROJPRIZNATIHMJESECI], T4.[NAZIVBANKE1], T4.[NAZIVBANKE2], T4.[NAZIVBANKE3], T4.[VBDIBANKE], T4.[ZRNBANKE], T3.[TEKUCI], T3.[SIFRAOPISAPLACANJANETO], T3.[OPISPLACANJANETO], T3.[BROJMIROVINSKOG], T3.[BROJZDRAVSTVENOG], T3.[MBO], T3.[POSTOTAKOSLOBODJENJAODPOREZA], T1.[KOEFICIJENT], T1.[OBRACUNSKIKOEFICIJENT], T7.[NAZIVRADNOMJESTO], T14.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T13.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T8.[NAZIVSTRUKA], T12.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T3.[AKTIVAN], T1.[ISKORISTENOOO], T1.[OBRACUNATIPRIREZ], T1.[faktoo], T3.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], T3.[TJEDNIFONDSATI], T3.[TJEDNIFONDSATISTAZ], T3.[GODINESTAZA], T3.[MJESECISTAZA], T3.[DANISTAZA], T3.[DATUMPRESTANKARADNOGODNOSA], T6.[NAZIVTITULA], T3.[ZBIRNINETO], T3.[UZIMAUOBZIROSNOVICEDOPRINOSA], T9.[ORGANIZACIJSKIDIO], T1.[IDIPIDENT], T3.[OIB], T1.[RADNIKOBRACUNOSNOVICA], T1.[KOREKCIJAPRIREZA], T1.[ODBITAKPRIJEKOREKCIJE], T1.[OBRACUNAVAJOBUSTAVE], T1.[IDRADNIK], T3.[IDBANKE], T3.[IDBENEFICIRANI], T3.[IDTITULA], T3.[IDRADNOMJESTO], T3.[IDSTRUKA], T3.[IDORGDIO], T3.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, T3.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, T3.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, T3.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, T3.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]";
                this.scmdbuf = this.scmdbuf + " AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM ((((((((((((([ObracunRadnici] T1 WITH (NOLOCK) INNER JOIN  ";
                this.scmdbuf = this.scmdbuf + this.m_SubSelTopString10 + "  TM1 WITH (NOLOCK) ON TM1.[IDOBRACUN] = T1.[IDOBRACUN]) INNER JOIN [RADNIK] T3 WITH (NOLOCK) ON T3.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [BANKE] T4 WITH (NOLOCK) ON T4.[IDBANKE] = T3.[IDBANKE]) INNER JOIN [BENEFICIRANI] T5 WITH (NOLOCK) ON T5.[IDBENEFICIRANI] = T3.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T6 WITH (NOLOCK) ON T6.[IDTITULA] = T3.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T7 WITH (NOLOCK) ON T7.[IDRADNOMJESTO] = T3.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T8 WITH (NOLOCK) ON T8.[IDSTRUKA] = T3.[IDSTRUKA]) LEFT JOIN [ORGDIO] T9 WITH (NOLOCK) ON T9.[IDORGDIO] = T3.[IDORGDIO]) INNER JOIN [OPCINA] T10 WITH (NOLOCK) ON T10.[IDOPCINE] = T3.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T11 WITH (NOLOCK) ON T11.[IDOPCINE] = T3.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T12 WITH (NOLOCK) ON T12.[IDSKUPPOREZAIDOPRINOSA] = T3.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T13 WITH (NOLOCK) ON T13.[IDSTRUCNASPREMA] = T3.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T14 WITH (NOLOCK) ON T14.[IDSTRUCNASPREMA] = T3.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA])" + this.m_WhereString + " ORDER BY T1.[IDOBRACUN], T1.[IDRADNIK] ";
            }
            this.cmObracunRadniciSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.OBRACUNSet = (OBRACUNDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.OBRACUNSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.OBRACUNSet.OBRACUN.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        OBRACUNDataSet.OBRACUNRow current = (OBRACUNDataSet.OBRACUNRow) enumerator.Current;
                        this.rowOBRACUN = current;
                        if (Helpers.IsRowChanged(this.rowOBRACUN))
                        {
                            this.ReadRowObracun();
                            if (this.rowOBRACUN.RowState == DataRowState.Added)
                            {
                                this.InsertObracun();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateObracun();
                            }
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                dataSet.AcceptChanges();
                this.connDefault.Commit();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        private void UpdateObracun()
        {
            this.CheckOptimisticConcurrencyObracun();
            this.CheckExtendedTableObracun();
            this.AfterConfirmObracun();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [OBRACUN] SET [VRSTAOBRACUNA]=@VRSTAOBRACUNA, [MJESECOBRACUNA]=@MJESECOBRACUNA, [GODINAOBRACUNA]=@GODINAOBRACUNA, [MJESECISPLATE]=@MJESECISPLATE, [GODINAISPLATE]=@GODINAISPLATE, [DATUMISPLATE]=@DATUMISPLATE, [tjednifondsatiobracun]=@tjednifondsatiobracun, [MJESECNIFONDSATIOBRACUN]=@MJESECNIFONDSATIOBRACUN, [OSNOVNIOO]=@OSNOVNIOO, [OBRACUNSKAOSNOVICA]=@OBRACUNSKAOSNOVICA, [DATUMOBRACUNASTAZA]=@DATUMOBRACUNASTAZA, [OBRPOSTOTNIH]=@OBRPOSTOTNIH, [OBRFIKSNIH]=@OBRFIKSNIH, [OBRKREDITNIH]=@OBRKREDITNIH, [ZAKLJ]=@ZAKLJ, [SVRHAOBRACUNA]=@SVRHAOBRACUNA  WHERE [IDOBRACUN] = @IDOBRACUN", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBRACUNA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECOBRACUNA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAOBRACUNA", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECISPLATE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAISPLATE", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMISPLATE", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@tjednifondsatiobracun", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECNIFONDSATIOBRACUN", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVNIOO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNSKAOSNOVICA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMOBRACUNASTAZA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRPOSTOTNIH", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRFIKSNIH", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRKREDITNIH", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAKLJ", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SVRHAOBRACUNA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["VRSTAOBRACUNA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["MJESECOBRACUNA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["GODINAOBRACUNA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["MJESECISPLATE"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["GODINAISPLATE"]));
            command.SetParameterDateObject(5, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["DATUMISPLATE"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["tjednifondsatiobracun"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["MJESECNIFONDSATIOBRACUN"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OSNOVNIOO"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OBRACUNSKAOSNOVICA"]));
            command.SetParameterDateObject(10, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["DATUMOBRACUNASTAZA"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OBRPOSTOTNIH"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OBRFIKSNIH"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["OBRKREDITNIH"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["ZAKLJ"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["SVRHAOBRACUNA"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowOBRACUN["IDOBRACUN"]));
            command.ExecuteStmt();
            this.OnOBRACUNUpdated(new OBRACUNEventArgs(this.rowOBRACUN, StatementType.Update));
            this.ProcessLevelObracun();
        }

        private void UpdateObracundoprinosi()
        {
            this.CheckOptimisticConcurrencyObracundoprinosi();
            this.CheckExtendedTableObracundoprinosi();
            this.AfterConfirmObracundoprinosi();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [ObracunDoprinosi] SET [VBDIDOPRINOS]=@VBDIDOPRINOS, [ZRNDOPRINOS]=@ZRNDOPRINOS, [NAZIVDOPRINOS]=@NAZIVDOPRINOS, [IDVRSTADOPRINOS]=@IDVRSTADOPRINOS, [NAZIVVRSTADOPRINOS]=@NAZIVVRSTADOPRINOS, [STOPA]=@STOPA, [MODOPRINOS]=@MODOPRINOS, [PODOPRINOS]=@PODOPRINOS, [MZDOPRINOS]=@MZDOPRINOS, [PZDOPRINOS]=@PZDOPRINOS, [PRIMATELJDOPRINOS1]=@PRIMATELJDOPRINOS1, [PRIMATELJDOPRINOS2]=@PRIMATELJDOPRINOS2, [SIFRAOPISAPLACANJADOPRINOS]=@SIFRAOPISAPLACANJADOPRINOS, [OPISPLACANJADOPRINOS]=@OPISPLACANJADOPRINOS, [OBRACUNATIDOPRINOS]=@OBRACUNATIDOPRINOS, [OSNOVICADOPRINOS]=@OSNOVICADOPRINOS  WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDDOPRINOS] = @IDDOPRINOS", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIDOPRINOS", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNDOPRINOS", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVDOPRINOS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTADOPRINOS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STOPA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MODOPRINOS", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PODOPRINOS", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZDOPRINOS", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZDOPRINOS", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJDOPRINOS1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJDOPRINOS2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJADOPRINOS", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJADOPRINOS", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNATIDOPRINOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICADOPRINOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["VBDIDOPRINOS"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["ZRNDOPRINOS"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["NAZIVDOPRINOS"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDVRSTADOPRINOS"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["NAZIVVRSTADOPRINOS"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["STOPA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["MODOPRINOS"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["PODOPRINOS"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["MZDOPRINOS"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["PZDOPRINOS"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["PRIMATELJDOPRINOS1"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["PRIMATELJDOPRINOS2"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["SIFRAOPISAPLACANJADOPRINOS"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["OPISPLACANJADOPRINOS"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["OBRACUNATIDOPRINOS"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["OSNOVICADOPRINOS"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDOBRACUN"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDRADNIK"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowObracunDoprinosi["IDDOPRINOS"]));
            command.ExecuteStmt();
            this.OnObracunDoprinosiUpdated(new ObracunDoprinosiEventArgs(this.rowObracunDoprinosi, StatementType.Update));
        }

        private void UpdateObracunelementi()
        {
            this.CheckOptimisticConcurrencyObracunelementi();
            this.CheckExtendedTableObracunelementi();
            this.AfterConfirmObracunelementi();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [ObracunElementi] SET [NAZIVELEMENT]=@NAZIVELEMENT, [IDVRSTAELEMENTA]=@IDVRSTAELEMENTA, [NAZIVVRSTAELEMENT]=@NAZIVVRSTAELEMENT, [OBRSATI]=@OBRSATI, [OBRSATNICA]=@OBRSATNICA, [OBRIZNOS]=@OBRIZNOS, [OBRPOSTOTAK]=@OBRPOSTOTAK  WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDELEMENT] = @IDELEMENT AND [ELEMENTRAZDOBLJEOD] = @ELEMENTRAZDOBLJEOD AND [ELEMENTRAZDOBLJEDO] = @ELEMENTRAZDOBLJEDO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVELEMENT", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTAELEMENT", DbType.String, 0x19));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRSATI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRSATNICA", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRPOSTOTAK", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ELEMENTRAZDOBLJEOD", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ELEMENTRAZDOBLJEDO", DbType.Date));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["NAZIVELEMENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDVRSTAELEMENTA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["NAZIVVRSTAELEMENT"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["OBRSATI"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["OBRSATNICA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["OBRIZNOS"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["OBRPOSTOTAK"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDOBRACUN"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDRADNIK"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["IDELEMENT"]));
            command.SetParameterDateObject(10, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["ELEMENTRAZDOBLJEOD"]));
            command.SetParameterDateObject(11, RuntimeHelpers.GetObjectValue(this.rowObracunElementi["ELEMENTRAZDOBLJEDO"]));
            command.ExecuteStmt();
            this.OnObracunElementiUpdated(new ObracunElementiEventArgs(this.rowObracunElementi, StatementType.Update));
        }

        private void UpdateObracunkrediti()
        {
            this.CheckOptimisticConcurrencyObracunkrediti();
            this.CheckExtendedTableObracunkrediti();
            this.AfterConfirmObracunkrediti();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [OBRACUNKrediti] SET [NAZIVKREDITOR]=@NAZIVKREDITOR, [VBDIKREDITOR]=@VBDIKREDITOR, [ZRNKREDITOR]=@ZRNKREDITOR, [PRIMATELJKREDITOR1]=@PRIMATELJKREDITOR1, [PRIMATELJKREDITOR2]=@PRIMATELJKREDITOR2, [PRIMATELJKREDITOR3]=@PRIMATELJKREDITOR3, [OBRSIFRAOPISAPLACANJAKREDITOR]=@OBRSIFRAOPISAPLACANJAKREDITOR, [OBROPISPLACANJAKREDITOR]=@OBROPISPLACANJAKREDITOR, [OBRMOKREDITOR]=@OBRMOKREDITOR, [OBRPOKREDITOR]=@OBRPOKREDITOR, [OBRMZKREDITOR]=@OBRMZKREDITOR, [OBRPZKREDITOR]=@OBRPZKREDITOR, [OBRIZNOSRATEKREDITOR]=@OBRIZNOSRATEKREDITOR, [OBRACUNATIKUNSKIIZNOS]=@OBRACUNATIKUNSKIIZNOS, [VECOTPLACENOBROJRATA]=@VECOTPLACENOBROJRATA, [VECOTPLACENOUKUPNIIZNOS]=@VECOTPLACENOUKUPNIIZNOS, [UKUPNIZNOSKREDITA]=@UKUPNIZNOSKREDITA  WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDKREDITOR] = @IDKREDITOR AND [DATUMUGOVORA] = @DATUMUGOVORA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVKREDITOR", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIKREDITOR", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNKREDITOR", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKREDITOR1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKREDITOR2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKREDITOR3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRSIFRAOPISAPLACANJAKREDITOR", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBROPISPLACANJAKREDITOR", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRMOKREDITOR", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRPOKREDITOR", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRMZKREDITOR", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRPZKREDITOR", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRIZNOSRATEKREDITOR", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNATIKUNSKIIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VECOTPLACENOBROJRATA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VECOTPLACENOUKUPNIIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UKUPNIZNOSKREDITA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKREDITOR", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMUGOVORA", DbType.Date));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["NAZIVKREDITOR"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["VBDIKREDITOR"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["ZRNKREDITOR"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["PRIMATELJKREDITOR1"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["PRIMATELJKREDITOR2"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["PRIMATELJKREDITOR3"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRSIFRAOPISAPLACANJAKREDITOR"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBROPISPLACANJAKREDITOR"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRMOKREDITOR"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRPOKREDITOR"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRMZKREDITOR"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRPZKREDITOR"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRIZNOSRATEKREDITOR"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["OBRACUNATIKUNSKIIZNOS"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["VECOTPLACENOBROJRATA"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["VECOTPLACENOUKUPNIIZNOS"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["UKUPNIZNOSKREDITA"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["IDOBRACUN"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["IDRADNIK"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["IDKREDITOR"]));
            command.SetParameterDateObject(20, RuntimeHelpers.GetObjectValue(this.rowOBRACUNKrediti["DATUMUGOVORA"]));
            command.ExecuteStmt();
            this.OnOBRACUNKreditiUpdated(new OBRACUNKreditiEventArgs(this.rowOBRACUNKrediti, StatementType.Update));
        }

        private void UpdateObracunobracunlevel1obracunizuzece()
        {
            this.CheckOptimisticConcurrencyObracunobracunlevel1obracunizuzece();
            this.AfterConfirmObracunobracunlevel1obracunizuzece();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [OBRACUNOBRACUNLevel1ObracunIzuzece] SET [PRIMATELJIZUZECE1]=@PRIMATELJIZUZECE1, [PRIMATELJIZUZECE2]=@PRIMATELJIZUZECE2, [PRIMATELJIZUZECE3]=@PRIMATELJIZUZECE3, [SIFRAOPISAPLACANJAIZUZECE]=@SIFRAOPISAPLACANJAIZUZECE, [OPISPLACANJAIZUZECE]=@OPISPLACANJAIZUZECE, [VBDIIZUZECE]=@VBDIIZUZECE, [TEKUCIIZUZECE]=@TEKUCIIZUZECE, [MOIZUZECE]=@MOIZUZECE, [POIZUZECE]=@POIZUZECE, [MZIZUZECE]=@MZIZUZECE, [PZIZUZECE]=@PZIZUZECE, [IZNOSIZUZECA]=@IZNOSIZUZECA  WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDOBRACUNIZUZECE] = @IDOBRACUNIZUZECE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJIZUZECE1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJIZUZECE2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJIZUZECE3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAIZUZECE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAIZUZECE", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIIZUZECE", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TEKUCIIZUZECE", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOIZUZECE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POIZUZECE", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZIZUZECE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZIZUZECE", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZNOSIZUZECA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUNIZUZECE", DbType.Guid));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PRIMATELJIZUZECE1"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PRIMATELJIZUZECE2"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PRIMATELJIZUZECE3"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["SIFRAOPISAPLACANJAIZUZECE"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["OPISPLACANJAIZUZECE"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["VBDIIZUZECE"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["TEKUCIIZUZECE"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["MOIZUZECE"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["POIZUZECE"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["MZIZUZECE"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["PZIZUZECE"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IZNOSIZUZECA"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDOBRACUN"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDRADNIK"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece["IDOBRACUNIZUZECE"]));
            command.ExecuteStmt();
            this.OnOBRACUNOBRACUNLevel1ObracunIzuzeceUpdated(new OBRACUNOBRACUNLevel1ObracunIzuzeceEventArgs(this.rowOBRACUNOBRACUNLevel1ObracunIzuzece, StatementType.Update));
        }

        private void UpdateObracunobracunlevel1obracunkrizni()
        {
            this.CheckOptimisticConcurrencyObracunobracunlevel1obracunkrizni();
            this.CheckExtendedTableObracunobracunlevel1obracunkrizni();
            this.AfterConfirmObracunobracunlevel1obracunkrizni();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [OBRACUNOBRACUNLevel1ObracunKrizni] SET [NAZIVKRIZNIPOREZ]=@NAZIVKRIZNIPOREZ, [KRIZNISTOPA]=@KRIZNISTOPA, [MOKRIZNI]=@MOKRIZNI, [POKRIZNI]=@POKRIZNI, [MZKRIZNI]=@MZKRIZNI, [PZKRIZNI]=@PZKRIZNI, [PRIMATELJKRIZNI1]=@PRIMATELJKRIZNI1, [PRIMATELJKRIZNI2]=@PRIMATELJKRIZNI2, [SIFRAOPISAPLACANJAKRIZNI]=@SIFRAOPISAPLACANJAKRIZNI, [OPISPLACANJAKRIZNI]=@OPISPLACANJAKRIZNI, [PRIMATELJKRIZNI3]=@PRIMATELJKRIZNI3, [VBDIKRIZNI]=@VBDIKRIZNI, [ZRNKRIZNI]=@ZRNKRIZNI, [OSNOVICAKRIZNI]=@OSNOVICAKRIZNI, [POREZKRIZNI]=@POREZKRIZNI, [OSNOVICAPRETHODNA]=@OSNOVICAPRETHODNA, [OSNOVICAUKUPNA]=@OSNOVICAUKUPNA, [POREZPRETHODNI]=@POREZPRETHODNI, [POREZUKUPNO]=@POREZUKUPNO  WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVKRIZNIPOREZ", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KRIZNISTOPA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOKRIZNI", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POKRIZNI", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZKRIZNI", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZKRIZNI", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAKRIZNI", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAKRIZNI", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIKRIZNI", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNKRIZNI", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICAKRIZNI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POREZKRIZNI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICAPRETHODNA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICAUKUPNA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POREZPRETHODNI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POREZUKUPNO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["NAZIVKRIZNIPOREZ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["KRIZNISTOPA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["MOKRIZNI"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POKRIZNI"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["MZKRIZNI"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PZKRIZNI"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PRIMATELJKRIZNI1"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PRIMATELJKRIZNI2"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["SIFRAOPISAPLACANJAKRIZNI"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OPISPLACANJAKRIZNI"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["PRIMATELJKRIZNI3"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["VBDIKRIZNI"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["ZRNKRIZNI"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OSNOVICAKRIZNI"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POREZKRIZNI"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OSNOVICAPRETHODNA"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["OSNOVICAUKUPNA"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POREZPRETHODNI"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["POREZUKUPNO"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDOBRACUN"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDRADNIK"]));
            command.SetParameter(0x15, RuntimeHelpers.GetObjectValue(this.rowOBRACUNOBRACUNLevel1ObracunKrizni["IDKRIZNIPOREZ"]));
            command.ExecuteStmt();
            this.OnOBRACUNOBRACUNLevel1ObracunKrizniUpdated(new OBRACUNOBRACUNLevel1ObracunKrizniEventArgs(this.rowOBRACUNOBRACUNLevel1ObracunKrizni, StatementType.Update));
        }

        private void UpdateObracunobustave()
        {
            this.CheckOptimisticConcurrencyObracunobustave();
            this.CheckExtendedTableObracunobustave();
            this.AfterConfirmObracunobustave();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [OBRACUNObustave] SET [NAZIVOBUSTAVA]=@NAZIVOBUSTAVA, [MOOBUSTAVA]=@MOOBUSTAVA, [POOBUSTAVA]=@POOBUSTAVA, [MZOBUSTAVA]=@MZOBUSTAVA, [PZOBUSTAVA]=@PZOBUSTAVA, [VBDIOBUSTAVA]=@VBDIOBUSTAVA, [ZRNOBUSTAVA]=@ZRNOBUSTAVA, [PRIMATELJOBUSTAVA1]=@PRIMATELJOBUSTAVA1, [PRIMATELJOBUSTAVA2]=@PRIMATELJOBUSTAVA2, [PRIMATELJOBUSTAVA3]=@PRIMATELJOBUSTAVA3, [SIFRAOPISAPLACANJAOBUSTAVA]=@SIFRAOPISAPLACANJAOBUSTAVA, [OPISPLACANJAOBUSTAVA]=@OPISPLACANJAOBUSTAVA, [VRSTAOBUSTAVE]=@VRSTAOBUSTAVE, [NAZIVVRSTAOBUSTAVE]=@NAZIVVRSTAOBUSTAVE, [IZNOSOBUSTAVE]=@IZNOSOBUSTAVE, [POSTOTAKOBUSTAVE]=@POSTOTAKOBUSTAVE, [OBRACUNATAOBUSTAVAUKUNAMA]=@OBRACUNATAOBUSTAVAUKUNAMA, [ISPLACENOKASA]=@ISPLACENOKASA, [SALDOKASA]=@SALDOKASA  WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDOBUSTAVA] = @IDOBUSTAVA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOBUSTAVA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOOBUSTAVA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POOBUSTAVA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZOBUSTAVA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZOBUSTAVA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIOBUSTAVA", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNOBUSTAVA", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOBUSTAVA1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOBUSTAVA2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOBUSTAVA3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAOBUSTAVA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAOBUSTAVA", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTAOBUSTAVE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZNOSOBUSTAVE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTOTAKOBUSTAVE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNATAOBUSTAVAUKUNAMA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ISPLACENOKASA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SALDOKASA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBUSTAVA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["NAZIVOBUSTAVA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["MOOBUSTAVA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["POOBUSTAVA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["MZOBUSTAVA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["PZOBUSTAVA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["VBDIOBUSTAVA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["ZRNOBUSTAVA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["PRIMATELJOBUSTAVA1"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["PRIMATELJOBUSTAVA2"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["PRIMATELJOBUSTAVA3"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["SIFRAOPISAPLACANJAOBUSTAVA"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["OPISPLACANJAOBUSTAVA"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["VRSTAOBUSTAVE"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["NAZIVVRSTAOBUSTAVE"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IZNOSOBUSTAVE"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["POSTOTAKOBUSTAVE"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["OBRACUNATAOBUSTAVAUKUNAMA"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["ISPLACENOKASA"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["SALDOKASA"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IDOBRACUN"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IDRADNIK"]));
            command.SetParameter(0x15, RuntimeHelpers.GetObjectValue(this.rowOBRACUNObustave["IDOBUSTAVA"]));
            command.ExecuteStmt();
            this.OnOBRACUNObustaveUpdated(new OBRACUNObustaveEventArgs(this.rowOBRACUNObustave, StatementType.Update));
        }

        private void UpdateObracunolaksice()
        {
            this.CheckOptimisticConcurrencyObracunolaksice();
            this.CheckExtendedTableObracunolaksice();
            this.AfterConfirmObracunolaksice();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [ObracunOlaksice] SET [NAZIVOLAKSICE]=@NAZIVOLAKSICE, [IDGRUPEOLAKSICA]=@IDGRUPEOLAKSICA, [NAZIVGRUPEOLAKSICA]=@NAZIVGRUPEOLAKSICA, [MAXIMALNIIZNOSGRUPE]=@MAXIMALNIIZNOSGRUPE, [VBDIOLAKSICA]=@VBDIOLAKSICA, [PRIMATELJOLAKSICA1]=@PRIMATELJOLAKSICA1, [PRIMATELJOLAKSICA2]=@PRIMATELJOLAKSICA2, [PRIMATELJOLAKSICA3]=@PRIMATELJOLAKSICA3, [IDTIPOLAKSICE]=@IDTIPOLAKSICE, [NAZIVTIPOLAKSICE]=@NAZIVTIPOLAKSICE, [ZRNOLAKSICA]=@ZRNOLAKSICA, [MZOLAKSICA]=@MZOLAKSICA, [PZOLAKSICA]=@PZOLAKSICA, [MOOLAKSICA]=@MOOLAKSICA, [POOLAKSICA]=@POOLAKSICA, [SIFRAOPISAPLACANJAOLAKSICA]=@SIFRAOPISAPLACANJAOLAKSICA, [OPISPLACANJAOLAKSICA]=@OPISPLACANJAOLAKSICA, [IZNOSOLAKSICE]=@IZNOSOLAKSICE, [OBRACUNATAOLAKSICA]=@OBRACUNATAOLAKSICA  WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDOLAKSICE] = @IDOLAKSICE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOLAKSICE", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVGRUPEOLAKSICA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MAXIMALNIIZNOSGRUPE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIOLAKSICA", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOLAKSICA1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOLAKSICA2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOLAKSICA3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVTIPOLAKSICE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNOLAKSICA", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZOLAKSICA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZOLAKSICA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOOLAKSICA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POOLAKSICA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAOLAKSICA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAOLAKSICA", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZNOSOLAKSICE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNATAOLAKSICA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOLAKSICE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["NAZIVOLAKSICE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDGRUPEOLAKSICA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["NAZIVGRUPEOLAKSICA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["MAXIMALNIIZNOSGRUPE"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["VBDIOLAKSICA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["PRIMATELJOLAKSICA1"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["PRIMATELJOLAKSICA2"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["PRIMATELJOLAKSICA3"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDTIPOLAKSICE"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["NAZIVTIPOLAKSICE"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["ZRNOLAKSICA"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["MZOLAKSICA"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["PZOLAKSICA"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["MOOLAKSICA"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["POOLAKSICA"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["SIFRAOPISAPLACANJAOLAKSICA"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["OPISPLACANJAOLAKSICA"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IZNOSOLAKSICE"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["OBRACUNATAOLAKSICA"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDOBRACUN"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDRADNIK"]));
            command.SetParameter(0x15, RuntimeHelpers.GetObjectValue(this.rowObracunOlaksice["IDOLAKSICE"]));
            command.ExecuteStmt();
            this.OnObracunOlaksiceUpdated(new ObracunOlaksiceEventArgs(this.rowObracunOlaksice, StatementType.Update));
        }

        private void UpdateObracunporezi()
        {
            this.CheckOptimisticConcurrencyObracunporezi();
            this.CheckExtendedTableObracunporezi();
            this.AfterConfirmObracunporezi();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [ObracunPorezi] SET [NAZIVPOREZ]=@NAZIVPOREZ, [STOPAPOREZA]=@STOPAPOREZA, [POREZMJESECNO]=@POREZMJESECNO, [MOPOREZ]=@MOPOREZ, [POPOREZ]=@POPOREZ, [MZPOREZ]=@MZPOREZ, [PZPOREZ]=@PZPOREZ, [PRIMATELJPOREZ1]=@PRIMATELJPOREZ1, [PRIMATELJPOREZ2]=@PRIMATELJPOREZ2, [SIFRAOPISAPLACANJAPOREZ]=@SIFRAOPISAPLACANJAPOREZ, [OPISPLACANJAPOREZ]=@OPISPLACANJAPOREZ, [OBRACUNATIPOREZ]=@OBRACUNATIPOREZ, [OSNOVICAPOREZ]=@OSNOVICAPOREZ  WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK AND [IDPOREZ] = @IDPOREZ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPOREZ", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STOPAPOREZA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POREZMJESECNO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POPOREZ", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZPOREZ", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJPOREZ1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJPOREZ2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAPOREZ", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNATIPOREZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICAPOREZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["NAZIVPOREZ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["STOPAPOREZA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["POREZMJESECNO"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["MOPOREZ"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["POPOREZ"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["MZPOREZ"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["PZPOREZ"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["PRIMATELJPOREZ1"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["PRIMATELJPOREZ2"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["SIFRAOPISAPLACANJAPOREZ"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["OPISPLACANJAPOREZ"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["OBRACUNATIPOREZ"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["OSNOVICAPOREZ"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["IDOBRACUN"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["IDRADNIK"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowObracunPorezi["IDPOREZ"]));
            command.ExecuteStmt();
            this.OnObracunPoreziUpdated(new ObracunPoreziEventArgs(this.rowObracunPorezi, StatementType.Update));
        }

        private void UpdateObracunradnici()
        {
            this.CheckOptimisticConcurrencyObracunradnici();
            this.CheckExtendedTableObracunradnici();
            this.AfterConfirmObracunradnici();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [ObracunRadnici] SET [KOEFICIJENT]=@KOEFICIJENT, [IDIPIDENT]=@IDIPIDENT, [SIFRAOPCINESTANOVANJA]=@SIFRAOPCINESTANOVANJA, [OBRACUNSKIKOEFICIJENT]=@OBRACUNSKIKOEFICIJENT, [ISKORISTENOOO]=@ISKORISTENOOO, [OBRACUNATIPRIREZ]=@OBRACUNATIPRIREZ, [faktoo]=@faktoo, [RADNIKOBRACUNOSNOVICA]=@RADNIKOBRACUNOSNOVICA, [KOREKCIJAPRIREZA]=@KOREKCIJAPRIREZA, [ODBITAKPRIJEKOREKCIJE]=@ODBITAKPRIJEKOREKCIJE, [OBRACUNAVAJOBUSTAVE]=@OBRACUNAVAJOBUSTAVE  WHERE [IDOBRACUN] = @IDOBRACUN AND [IDRADNIK] = @IDRADNIK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KOEFICIJENT", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPCINESTANOVANJA", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNSKIKOEFICIJENT", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ISKORISTENOOO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNATIPRIREZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@faktoo", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNIKOBRACUNOSNOVICA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KOREKCIJAPRIREZA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODBITAKPRIJEKOREKCIJE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNAVAJOBUSTAVE", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["KOEFICIJENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDIPIDENT"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["SIFRAOPCINESTANOVANJA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["OBRACUNSKIKOEFICIJENT"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["ISKORISTENOOO"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["OBRACUNATIPRIREZ"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["faktoo"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["RADNIKOBRACUNOSNOVICA"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["KOREKCIJAPRIREZA"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["ODBITAKPRIJEKOREKCIJE"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["OBRACUNAVAJOBUSTAVE"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDOBRACUN"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowObracunRadnici["IDRADNIK"]));
            command.ExecuteStmt();
            this.OnObracunRadniciUpdated(new ObracunRadniciEventArgs(this.rowObracunRadnici, StatementType.Update));
            this.ProcessLevelObracunradnici();
        }

        public System.Data.MissingMappingAction MissingMappingAction
        {
            get
            {
                return System.Data.MissingMappingAction.Passthrough;
            }
            set
            {
            }
        }

        System.Data.MissingSchemaAction MissingSchemaAction
        {
            get
            {
                return System.Data.MissingSchemaAction.Ignore;
            }
            set
            {
            }
        }

        System.Data.MissingMappingAction System.Data.IDataAdapter.MissingMappingAction
        {
            get
            {
                return System.Data.MissingMappingAction.Passthrough;
            }
            set
            {
            }
        }

        System.Data.MissingSchemaAction System.Data.IDataAdapter.MissingSchemaAction
        {
            get
            {
                return System.Data.MissingSchemaAction.Ignore;
            }
            set
            {
            }
        }

        ITableMappingCollection System.Data.IDataAdapter.TableMappings
        {
            get
            {
                return new DataTableMappingCollection();
            }
        }

        ITableMappingCollection TableMappings
        {
            get
            {
                return new DataTableMappingCollection();
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return this.daCurrentTransaction;
            }
            set
            {
                this.daCurrentTransaction = value;
            }
        }

        [Serializable]
        public class BANKEForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public BANKEForeignKeyNotFoundException()
            {
            }

            public BANKEForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected BANKEForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BANKEForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BENEFICIRANIForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public BENEFICIRANIForeignKeyNotFoundException()
            {
            }

            public BENEFICIRANIForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected BENEFICIRANIForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BENEFICIRANIForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DOPRINOSForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public DOPRINOSForeignKeyNotFoundException()
            {
            }

            public DOPRINOSForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected DOPRINOSForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOPRINOSForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ELEMENTForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public ELEMENTForeignKeyNotFoundException()
            {
            }

            public ELEMENTForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected ELEMENTForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ELEMENTForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GRUPEOLAKSICAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public GRUPEOLAKSICAForeignKeyNotFoundException()
            {
            }

            public GRUPEOLAKSICAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected GRUPEOLAKSICAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GRUPEOLAKSICAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class KREDITORForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public KREDITORForeignKeyNotFoundException()
            {
            }

            public KREDITORForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected KREDITORForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KREDITORForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class KRIZNIPOREZForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public KRIZNIPOREZForeignKeyNotFoundException()
            {
            }

            public KRIZNIPOREZForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected KRIZNIPOREZForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KRIZNIPOREZForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OBRACUNDataChangedException : DataChangedException
        {
            public OBRACUNDataChangedException()
            {
            }

            public OBRACUNDataChangedException(string message) : base(message)
            {
            }

            protected OBRACUNDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OBRACUNDataLockedException : DataLockedException
        {
            public OBRACUNDataLockedException()
            {
            }

            public OBRACUNDataLockedException(string message) : base(message)
            {
            }

            protected OBRACUNDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ObracunDoprinosiDataChangedException : DataChangedException
        {
            public ObracunDoprinosiDataChangedException()
            {
            }

            public ObracunDoprinosiDataChangedException(string message) : base(message)
            {
            }

            protected ObracunDoprinosiDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunDoprinosiDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ObracunDoprinosiDataLockedException : DataLockedException
        {
            public ObracunDoprinosiDataLockedException()
            {
            }

            public ObracunDoprinosiDataLockedException(string message) : base(message)
            {
            }

            protected ObracunDoprinosiDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunDoprinosiDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ObracunDoprinosiDuplicateKeyException : DuplicateKeyException
        {
            public ObracunDoprinosiDuplicateKeyException()
            {
            }

            public ObracunDoprinosiDuplicateKeyException(string message) : base(message)
            {
            }

            protected ObracunDoprinosiDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunDoprinosiDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class ObracunDoprinosiEventArgs : EventArgs
        {
            private OBRACUNDataSet.ObracunDoprinosiRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public ObracunDoprinosiEventArgs(OBRACUNDataSet.ObracunDoprinosiRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OBRACUNDataSet.ObracunDoprinosiRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        public delegate void ObracunDoprinosiUpdateEventHandler(object sender, OBRACUNDataAdapter.ObracunDoprinosiEventArgs e);

        [Serializable]
        public class OBRACUNDuplicateKeyException : DuplicateKeyException
        {
            public OBRACUNDuplicateKeyException()
            {
            }

            public OBRACUNDuplicateKeyException(string message) : base(message)
            {
            }

            protected OBRACUNDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ObracunElementiDataChangedException : DataChangedException
        {
            public ObracunElementiDataChangedException()
            {
            }

            public ObracunElementiDataChangedException(string message) : base(message)
            {
            }

            protected ObracunElementiDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunElementiDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ObracunElementiDataLockedException : DataLockedException
        {
            public ObracunElementiDataLockedException()
            {
            }

            public ObracunElementiDataLockedException(string message) : base(message)
            {
            }

            protected ObracunElementiDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunElementiDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ObracunElementiDuplicateKeyException : DuplicateKeyException
        {
            public ObracunElementiDuplicateKeyException()
            {
            }

            public ObracunElementiDuplicateKeyException(string message) : base(message)
            {
            }

            protected ObracunElementiDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunElementiDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class ObracunElementiEventArgs : EventArgs
        {
            private OBRACUNDataSet.ObracunElementiRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public ObracunElementiEventArgs(OBRACUNDataSet.ObracunElementiRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OBRACUNDataSet.ObracunElementiRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        public delegate void ObracunElementiUpdateEventHandler(object sender, OBRACUNDataAdapter.ObracunElementiEventArgs e);

        public class OBRACUNEventArgs : EventArgs
        {
            private OBRACUNDataSet.OBRACUNRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public OBRACUNEventArgs(OBRACUNDataSet.OBRACUNRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OBRACUNDataSet.OBRACUNRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        [Serializable]
        public class OBRACUNKreditiDataChangedException : DataChangedException
        {
            public OBRACUNKreditiDataChangedException()
            {
            }

            public OBRACUNKreditiDataChangedException(string message) : base(message)
            {
            }

            protected OBRACUNKreditiDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNKreditiDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OBRACUNKreditiDataLockedException : DataLockedException
        {
            public OBRACUNKreditiDataLockedException()
            {
            }

            public OBRACUNKreditiDataLockedException(string message) : base(message)
            {
            }

            protected OBRACUNKreditiDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNKreditiDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OBRACUNKreditiDuplicateKeyException : DuplicateKeyException
        {
            public OBRACUNKreditiDuplicateKeyException()
            {
            }

            public OBRACUNKreditiDuplicateKeyException(string message) : base(message)
            {
            }

            protected OBRACUNKreditiDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNKreditiDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class OBRACUNKreditiEventArgs : EventArgs
        {
            private OBRACUNDataSet.OBRACUNKreditiRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public OBRACUNKreditiEventArgs(OBRACUNDataSet.OBRACUNKreditiRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OBRACUNDataSet.OBRACUNKreditiRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        public delegate void OBRACUNKreditiUpdateEventHandler(object sender, OBRACUNDataAdapter.OBRACUNKreditiEventArgs e);

        [Serializable]
        public class OBRACUNNotFoundException : DataNotFoundException
        {
            public OBRACUNNotFoundException()
            {
            }

            public OBRACUNNotFoundException(string message) : base(message)
            {
            }

            protected OBRACUNNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OBRACUNOBRACUNLevel1ObracunIzuzeceDataChangedException : DataChangedException
        {
            public OBRACUNOBRACUNLevel1ObracunIzuzeceDataChangedException()
            {
            }

            public OBRACUNOBRACUNLevel1ObracunIzuzeceDataChangedException(string message) : base(message)
            {
            }

            protected OBRACUNOBRACUNLevel1ObracunIzuzeceDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNOBRACUNLevel1ObracunIzuzeceDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OBRACUNOBRACUNLevel1ObracunIzuzeceDataLockedException : DataLockedException
        {
            public OBRACUNOBRACUNLevel1ObracunIzuzeceDataLockedException()
            {
            }

            public OBRACUNOBRACUNLevel1ObracunIzuzeceDataLockedException(string message) : base(message)
            {
            }

            protected OBRACUNOBRACUNLevel1ObracunIzuzeceDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNOBRACUNLevel1ObracunIzuzeceDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OBRACUNOBRACUNLevel1ObracunIzuzeceDuplicateKeyException : DuplicateKeyException
        {
            public OBRACUNOBRACUNLevel1ObracunIzuzeceDuplicateKeyException()
            {
            }

            public OBRACUNOBRACUNLevel1ObracunIzuzeceDuplicateKeyException(string message) : base(message)
            {
            }

            protected OBRACUNOBRACUNLevel1ObracunIzuzeceDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNOBRACUNLevel1ObracunIzuzeceDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class OBRACUNOBRACUNLevel1ObracunIzuzeceEventArgs : EventArgs
        {
            private OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public OBRACUNOBRACUNLevel1ObracunIzuzeceEventArgs(OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        public delegate void OBRACUNOBRACUNLevel1ObracunIzuzeceUpdateEventHandler(object sender, OBRACUNDataAdapter.OBRACUNOBRACUNLevel1ObracunIzuzeceEventArgs e);

        [Serializable]
        public class OBRACUNOBRACUNLevel1ObracunKrizniDataChangedException : DataChangedException
        {
            public OBRACUNOBRACUNLevel1ObracunKrizniDataChangedException()
            {
            }

            public OBRACUNOBRACUNLevel1ObracunKrizniDataChangedException(string message) : base(message)
            {
            }

            protected OBRACUNOBRACUNLevel1ObracunKrizniDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNOBRACUNLevel1ObracunKrizniDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OBRACUNOBRACUNLevel1ObracunKrizniDataLockedException : DataLockedException
        {
            public OBRACUNOBRACUNLevel1ObracunKrizniDataLockedException()
            {
            }

            public OBRACUNOBRACUNLevel1ObracunKrizniDataLockedException(string message) : base(message)
            {
            }

            protected OBRACUNOBRACUNLevel1ObracunKrizniDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNOBRACUNLevel1ObracunKrizniDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OBRACUNOBRACUNLevel1ObracunKrizniDuplicateKeyException : DuplicateKeyException
        {
            public OBRACUNOBRACUNLevel1ObracunKrizniDuplicateKeyException()
            {
            }

            public OBRACUNOBRACUNLevel1ObracunKrizniDuplicateKeyException(string message) : base(message)
            {
            }

            protected OBRACUNOBRACUNLevel1ObracunKrizniDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNOBRACUNLevel1ObracunKrizniDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class OBRACUNOBRACUNLevel1ObracunKrizniEventArgs : EventArgs
        {
            private OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public OBRACUNOBRACUNLevel1ObracunKrizniEventArgs(OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        public delegate void OBRACUNOBRACUNLevel1ObracunKrizniUpdateEventHandler(object sender, OBRACUNDataAdapter.OBRACUNOBRACUNLevel1ObracunKrizniEventArgs e);

        [Serializable]
        public class OBRACUNObustaveDataChangedException : DataChangedException
        {
            public OBRACUNObustaveDataChangedException()
            {
            }

            public OBRACUNObustaveDataChangedException(string message) : base(message)
            {
            }

            protected OBRACUNObustaveDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNObustaveDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OBRACUNObustaveDataLockedException : DataLockedException
        {
            public OBRACUNObustaveDataLockedException()
            {
            }

            public OBRACUNObustaveDataLockedException(string message) : base(message)
            {
            }

            protected OBRACUNObustaveDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNObustaveDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OBRACUNObustaveDuplicateKeyException : DuplicateKeyException
        {
            public OBRACUNObustaveDuplicateKeyException()
            {
            }

            public OBRACUNObustaveDuplicateKeyException(string message) : base(message)
            {
            }

            protected OBRACUNObustaveDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNObustaveDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class OBRACUNObustaveEventArgs : EventArgs
        {
            private OBRACUNDataSet.OBRACUNObustaveRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public OBRACUNObustaveEventArgs(OBRACUNDataSet.OBRACUNObustaveRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OBRACUNDataSet.OBRACUNObustaveRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        public delegate void OBRACUNObustaveUpdateEventHandler(object sender, OBRACUNDataAdapter.OBRACUNObustaveEventArgs e);

        [Serializable]
        public class ObracunOlaksiceDataChangedException : DataChangedException
        {
            public ObracunOlaksiceDataChangedException()
            {
            }

            public ObracunOlaksiceDataChangedException(string message) : base(message)
            {
            }

            protected ObracunOlaksiceDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunOlaksiceDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ObracunOlaksiceDataLockedException : DataLockedException
        {
            public ObracunOlaksiceDataLockedException()
            {
            }

            public ObracunOlaksiceDataLockedException(string message) : base(message)
            {
            }

            protected ObracunOlaksiceDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunOlaksiceDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ObracunOlaksiceDuplicateKeyException : DuplicateKeyException
        {
            public ObracunOlaksiceDuplicateKeyException()
            {
            }

            public ObracunOlaksiceDuplicateKeyException(string message) : base(message)
            {
            }

            protected ObracunOlaksiceDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunOlaksiceDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class ObracunOlaksiceEventArgs : EventArgs
        {
            private OBRACUNDataSet.ObracunOlaksiceRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public ObracunOlaksiceEventArgs(OBRACUNDataSet.ObracunOlaksiceRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OBRACUNDataSet.ObracunOlaksiceRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        public delegate void ObracunOlaksiceUpdateEventHandler(object sender, OBRACUNDataAdapter.ObracunOlaksiceEventArgs e);

        [Serializable]
        public class ObracunPoreziDataChangedException : DataChangedException
        {
            public ObracunPoreziDataChangedException()
            {
            }

            public ObracunPoreziDataChangedException(string message) : base(message)
            {
            }

            protected ObracunPoreziDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunPoreziDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ObracunPoreziDataLockedException : DataLockedException
        {
            public ObracunPoreziDataLockedException()
            {
            }

            public ObracunPoreziDataLockedException(string message) : base(message)
            {
            }

            protected ObracunPoreziDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunPoreziDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ObracunPoreziDuplicateKeyException : DuplicateKeyException
        {
            public ObracunPoreziDuplicateKeyException()
            {
            }

            public ObracunPoreziDuplicateKeyException(string message) : base(message)
            {
            }

            protected ObracunPoreziDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunPoreziDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class ObracunPoreziEventArgs : EventArgs
        {
            private OBRACUNDataSet.ObracunPoreziRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public ObracunPoreziEventArgs(OBRACUNDataSet.ObracunPoreziRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OBRACUNDataSet.ObracunPoreziRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        public delegate void ObracunPoreziUpdateEventHandler(object sender, OBRACUNDataAdapter.ObracunPoreziEventArgs e);

        [Serializable]
        public class ObracunRadniciDataChangedException : DataChangedException
        {
            public ObracunRadniciDataChangedException()
            {
            }

            public ObracunRadniciDataChangedException(string message) : base(message)
            {
            }

            protected ObracunRadniciDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunRadniciDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ObracunRadniciDataLockedException : DataLockedException
        {
            public ObracunRadniciDataLockedException()
            {
            }

            public ObracunRadniciDataLockedException(string message) : base(message)
            {
            }

            protected ObracunRadniciDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunRadniciDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ObracunRadniciDuplicateKeyException : DuplicateKeyException
        {
            public ObracunRadniciDuplicateKeyException()
            {
            }

            public ObracunRadniciDuplicateKeyException(string message) : base(message)
            {
            }

            protected ObracunRadniciDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunRadniciDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class ObracunRadniciEventArgs : EventArgs
        {
            private OBRACUNDataSet.ObracunRadniciRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public ObracunRadniciEventArgs(OBRACUNDataSet.ObracunRadniciRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OBRACUNDataSet.ObracunRadniciRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        public delegate void ObracunRadniciUpdateEventHandler(object sender, OBRACUNDataAdapter.ObracunRadniciEventArgs e);

        public delegate void OBRACUNUpdateEventHandler(object sender, OBRACUNDataAdapter.OBRACUNEventArgs e);

        [Serializable]
        public class OBUSTAVAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public OBUSTAVAForeignKeyNotFoundException()
            {
            }

            public OBUSTAVAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected OBUSTAVAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBUSTAVAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OLAKSICEForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public OLAKSICEForeignKeyNotFoundException()
            {
            }

            public OLAKSICEForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected OLAKSICEForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OLAKSICEForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OPCINAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public OPCINAForeignKeyNotFoundException()
            {
            }

            public OPCINAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected OPCINAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OPCINAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ORGDIOForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public ORGDIOForeignKeyNotFoundException()
            {
            }

            public ORGDIOForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected ORGDIOForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ORGDIOForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSNOVAOSIGURANJAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public OSNOVAOSIGURANJAForeignKeyNotFoundException()
            {
            }

            public OSNOVAOSIGURANJAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected OSNOVAOSIGURANJAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSNOVAOSIGURANJAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class POREZForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public POREZForeignKeyNotFoundException()
            {
            }

            public POREZForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected POREZForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public POREZForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public RADNIKForeignKeyNotFoundException()
            {
            }

            public RADNIKForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected RADNIKForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNOMJESTOForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public RADNOMJESTOForeignKeyNotFoundException()
            {
            }

            public RADNOMJESTOForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected RADNOMJESTOForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNOMJESTOForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RSMAInvalidDeleteException : InvalidDeleteException
        {
            public RSMAInvalidDeleteException()
            {
            }

            public RSMAInvalidDeleteException(string message) : base(message)
            {
            }

            protected RSMAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSMAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SKUPPOREZAIDOPRINOSAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public SKUPPOREZAIDOPRINOSAForeignKeyNotFoundException()
            {
            }

            public SKUPPOREZAIDOPRINOSAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected SKUPPOREZAIDOPRINOSAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SKUPPOREZAIDOPRINOSAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class STRUCNASPREMAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public STRUCNASPREMAForeignKeyNotFoundException()
            {
            }

            public STRUCNASPREMAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected STRUCNASPREMAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRUCNASPREMAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class STRUKAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public STRUKAForeignKeyNotFoundException()
            {
            }

            public STRUKAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected STRUKAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRUKAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPOLAKSICEForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public TIPOLAKSICEForeignKeyNotFoundException()
            {
            }

            public TIPOLAKSICEForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected TIPOLAKSICEForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPOLAKSICEForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TITULAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public TITULAForeignKeyNotFoundException()
            {
            }

            public TITULAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected TITULAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TITULAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VRSTADOPRINOSForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public VRSTADOPRINOSForeignKeyNotFoundException()
            {
            }

            public VRSTADOPRINOSForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected VRSTADOPRINOSForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTADOPRINOSForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VRSTAELEMENTForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public VRSTAELEMENTForeignKeyNotFoundException()
            {
            }

            public VRSTAELEMENTForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected VRSTAELEMENTForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTAELEMENTForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VRSTAOBRACUNAOutOfRangeException : UserException
        {
            public VRSTAOBRACUNAOutOfRangeException()
            {
            }

            public VRSTAOBRACUNAOutOfRangeException(string message) : base(message)
            {
            }

            protected VRSTAOBRACUNAOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTAOBRACUNAOutOfRangeException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VRSTEOBUSTAVAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public VRSTEOBUSTAVAForeignKeyNotFoundException()
            {
            }

            public VRSTEOBUSTAVAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected VRSTEOBUSTAVAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTEOBUSTAVAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

