namespace Placa
{
    using Deklarit;
    using Deklarit.Data;
    using Deklarit.Utils;
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

    public class DDOBRACUNDataAdapter : IDataAdapter, IDDOBRACUNDataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private bool _Gxremove102;
        private bool _Gxremove117;
        private bool _Gxremove73;
        private bool _Gxremove79;
        private bool _Gxremove84;
        private ReadWriteCommand cmDDOBRACUNRadniciDDKrizniPorezSelect2;
        private ReadWriteCommand cmDDOBRACUNRadniciDoprinosiSelect2;
        private ReadWriteCommand cmDDOBRACUNRadniciIzdaciSelect2;
        private ReadWriteCommand cmDDOBRACUNRadniciPoreziSelect2;
        private ReadWriteCommand cmDDOBRACUNRadniciSelect2;
        private ReadWriteCommand cmDDOBRACUNRadniciVrstePoslaSelect2;
        private ReadWriteCommand cmDDOBRACUNSelect1;
        private ReadWriteCommand cmDDOBRACUNSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DDOBRACUNRadniciDDKrizniPorezSelect2;
        private IDataReader DDOBRACUNRadniciDoprinosiSelect2;
        private IDataReader DDOBRACUNRadniciIzdaciSelect2;
        private IDataReader DDOBRACUNRadniciPoreziSelect2;
        private IDataReader DDOBRACUNRadniciSelect2;
        private IDataReader DDOBRACUNRadniciVrstePoslaSelect2;
        private IDataReader DDOBRACUNSelect1;
        private IDataReader DDOBRACUNSelect4;
        private DDOBRACUNDataSet DDOBRACUNSet;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__DDDATUMOBRACUNAOriginal;
        private object m__DDIZNOSOriginal;
        private object m__DDOBRACUNATIDOPRINOSOriginal;
        private object m__DDOBRACUNATIIZDATAKOriginal;
        private object m__DDOBRACUNATIPDVOriginal;
        private object m__DDOBRACUNATIPOREZOriginal;
        private object m__DDOBRACUNATIPRIREZOriginal;
        private object m__DDOPISOBRACUNOriginal;
        private object m__DDOSNOVICADOPRINOSOriginal;
        private object m__DDOSNOVICAKRIZNIOriginal;
        private object m__DDOSNOVICAPOREZOriginal;
        private object m__DDOSNOVICAPRETHODNAOriginal;
        private object m__DDOSNOVICAUKUPNAOriginal;
        private object m__DDPOREZKRIZNIOriginal;
        private object m__DDPOREZPRETHODNIOriginal;
        private object m__DDPOREZUKUPNOOriginal;
        private object m__DDRSMOriginal;
        private object m__DDSATIOriginal;
        private object m__DDSATNICAOriginal;
        private object m__DDSIFRAOPCINESTANOVANJAOriginal;
        private object m__DDZAKLJUCANOriginal;
        private object m__IDKATEGORIJAOriginal;
        private readonly string m_SelectString166 = "TM1.[DDOBRACUNIDOBRACUN], TM1.[DDOPISOBRACUN], TM1.[DDDATUMOBRACUNA], TM1.[DDZAKLJUCAN], TM1.[DDRSM]";
        private string m_SubSelTopString173;
        private string m_SubSelTopString174;
        private string m_SubSelTopString175;
        private string m_SubSelTopString176;
        private string m_SubSelTopString177;
        private string m_SubSelTopString178;
        private string m_WhereString;
        private short RcdFound166;
        private short RcdFound173;
        private short RcdFound174;
        private short RcdFound175;
        private short RcdFound176;
        private short RcdFound177;
        private short RcdFound178;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private DDOBRACUNDataSet.DDOBRACUNRow rowDDOBRACUN;
        private DDOBRACUNDataSet.DDOBRACUNRadniciRow rowDDOBRACUNRadnici;
        private DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow rowDDOBRACUNRadniciDDKrizniPorez;
        private DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow rowDDOBRACUNRadniciDoprinosi;
        private DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow rowDDOBRACUNRadniciIzdaci;
        private DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow rowDDOBRACUNRadniciPorezi;
        private DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow rowDDOBRACUNRadniciVrstePosla;
        private string scmdbuf;
        private StatementType sMode166;
        private StatementType sMode173;
        private StatementType sMode174;
        private StatementType sMode175;
        private StatementType sMode176;
        private StatementType sMode177;
        private StatementType sMode178;

        public event DDOBRACUNRadniciDDKrizniPorezUpdateEventHandler DDOBRACUNRadniciDDKrizniPorezUpdated;

        public event DDOBRACUNRadniciDDKrizniPorezUpdateEventHandler DDOBRACUNRadniciDDKrizniPorezUpdating;

        public event DDOBRACUNRadniciDoprinosiUpdateEventHandler DDOBRACUNRadniciDoprinosiUpdated;

        public event DDOBRACUNRadniciDoprinosiUpdateEventHandler DDOBRACUNRadniciDoprinosiUpdating;

        public event DDOBRACUNRadniciIzdaciUpdateEventHandler DDOBRACUNRadniciIzdaciUpdated;

        public event DDOBRACUNRadniciIzdaciUpdateEventHandler DDOBRACUNRadniciIzdaciUpdating;

        public event DDOBRACUNRadniciPoreziUpdateEventHandler DDOBRACUNRadniciPoreziUpdated;

        public event DDOBRACUNRadniciPoreziUpdateEventHandler DDOBRACUNRadniciPoreziUpdating;

        public event DDOBRACUNRadniciUpdateEventHandler DDOBRACUNRadniciUpdated;

        public event DDOBRACUNRadniciUpdateEventHandler DDOBRACUNRadniciUpdating;

        public event DDOBRACUNRadniciVrstePoslaUpdateEventHandler DDOBRACUNRadniciVrstePoslaUpdated;

        public event DDOBRACUNRadniciVrstePoslaUpdateEventHandler DDOBRACUNRadniciVrstePoslaUpdating;

        public event DDOBRACUNUpdateEventHandler DDOBRACUNUpdated;

        public event DDOBRACUNUpdateEventHandler DDOBRACUNUpdating;

        private void AddRowDdobracun()
        {
            this.DDOBRACUNSet.DDOBRACUN.AddDDOBRACUNRow(this.rowDDOBRACUN);
        }

        private void AddRowDdobracunradnici()
        {
            this.DDOBRACUNSet.DDOBRACUNRadnici.AddDDOBRACUNRadniciRow(this.rowDDOBRACUNRadnici);
        }

        private void AddRowDdobracunradniciddkrizniporez()
        {
            this.DDOBRACUNSet.DDOBRACUNRadniciDDKrizniPorez.AddDDOBRACUNRadniciDDKrizniPorezRow(this.rowDDOBRACUNRadniciDDKrizniPorez);
        }

        private void AddRowDdobracunradnicidoprinosi()
        {
            this.DDOBRACUNSet.DDOBRACUNRadniciDoprinosi.AddDDOBRACUNRadniciDoprinosiRow(this.rowDDOBRACUNRadniciDoprinosi);
        }

        private void AddRowDdobracunradniciizdaci()
        {
            this.DDOBRACUNSet.DDOBRACUNRadniciIzdaci.AddDDOBRACUNRadniciIzdaciRow(this.rowDDOBRACUNRadniciIzdaci);
        }

        private void AddRowDdobracunradniciporezi()
        {
            this.DDOBRACUNSet.DDOBRACUNRadniciPorezi.AddDDOBRACUNRadniciPoreziRow(this.rowDDOBRACUNRadniciPorezi);
        }

        private void AddRowDdobracunradnicivrsteposla()
        {
            this.DDOBRACUNSet.DDOBRACUNRadniciVrstePosla.AddDDOBRACUNRadniciVrstePoslaRow(this.rowDDOBRACUNRadniciVrstePosla);
        }

        private void AfterConfirmDdobracun()
        {
            this.OnDDOBRACUNUpdating(new DDOBRACUNEventArgs(this.rowDDOBRACUN, this.Gx_mode));
        }

        private void AfterConfirmDdobracunradnici()
        {
            this.OnDDOBRACUNRadniciUpdating(new DDOBRACUNRadniciEventArgs(this.rowDDOBRACUNRadnici, this.Gx_mode));
        }

        private void AfterConfirmDdobracunradniciddkrizniporez()
        {
            this.OnDDOBRACUNRadniciDDKrizniPorezUpdating(new DDOBRACUNRadniciDDKrizniPorezEventArgs(this.rowDDOBRACUNRadniciDDKrizniPorez, this.Gx_mode));
        }

        private void AfterConfirmDdobracunradnicidoprinosi()
        {
            this.OnDDOBRACUNRadniciDoprinosiUpdating(new DDOBRACUNRadniciDoprinosiEventArgs(this.rowDDOBRACUNRadniciDoprinosi, this.Gx_mode));
        }

        private void AfterConfirmDdobracunradniciizdaci()
        {
            this.OnDDOBRACUNRadniciIzdaciUpdating(new DDOBRACUNRadniciIzdaciEventArgs(this.rowDDOBRACUNRadniciIzdaci, this.Gx_mode));
        }

        private void AfterConfirmDdobracunradniciporezi()
        {
            this.OnDDOBRACUNRadniciPoreziUpdating(new DDOBRACUNRadniciPoreziEventArgs(this.rowDDOBRACUNRadniciPorezi, this.Gx_mode));
        }

        private void AfterConfirmDdobracunradnicivrsteposla()
        {
            this.OnDDOBRACUNRadniciVrstePoslaUpdating(new DDOBRACUNRadniciVrstePoslaEventArgs(this.rowDDOBRACUNRadniciVrstePosla, this.Gx_mode));
        }

        private void CheckExtendedTableDdobracunradnici()
        {
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [DDPREZIME], [DDIME], [OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, [DDPDVOBVEZNIK], [DDDRUGISTUP], [DDOIB], [DDZRN], [IDBANKE], [OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE FROM [DDRADNIK] WITH (NOLOCK) WHERE [DDIDRADNIK] = @DDIDRADNIK ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDIDRADNIK"]));
            IDataReader reader3 = command3.FetchData();
            if (!command3.HasMoreRows)
            {
                reader3.Close();
                throw new DDRADNIKForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DDRADNIK") }));
            }
            this.rowDDOBRACUNRadnici["DDPREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0));
            this.rowDDOBRACUNRadnici["DDIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 1));
            this.rowDDOBRACUNRadnici["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 2));
            this.rowDDOBRACUNRadnici["DDPDVOBVEZNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader3, 3));
            this.rowDDOBRACUNRadnici["DDDRUGISTUP"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader3, 4));
            this.rowDDOBRACUNRadnici["DDOIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 5));
            this.rowDDOBRACUNRadnici["DDZRN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 6));
            this.rowDDOBRACUNRadnici["IDBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader3, 7));
            this.rowDDOBRACUNRadnici["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 8));
            reader3.Close();
            if (!this.rowDDOBRACUNRadnici.IsOPCINASTANOVANJAIDOPCINENull())
            {
                ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, [PRIREZ] AS OPCINASTANOVANJAPRIREZ, [VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, [ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINASTANOVANJAIDOPCINE ", false);
                if (command4.IDbCommand.Parameters.Count == 0)
                {
                    command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
                }
                command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["OPCINASTANOVANJAIDOPCINE"]));
                IDataReader reader4 = command4.FetchData();
                if (!command4.HasMoreRows)
                {
                    reader4.Close();
                    throw new OPCINAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OPCINA") }));
                }
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader4, 0));
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader4, 1));
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader4, 2));
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader4, 3));
                reader4.Close();
            }
            else
            {
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowDDOBRACUNRadnici.IsIDBANKENull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVBANKE1], [NAZIVBANKE2], [NAZIVBANKE3], [VBDIBANKE], [ZRNBANKE] FROM [BANKE] WITH (NOLOCK) WHERE [IDBANKE] = @IDBANKE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["IDBANKE"]));
                IDataReader reader = command.FetchData();
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new BANKEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("BANKE") }));
                }
                this.rowDDOBRACUNRadnici["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowDDOBRACUNRadnici["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowDDOBRACUNRadnici["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowDDOBRACUNRadnici["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowDDOBRACUNRadnici["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                reader.Close();
            }
            else
            {
                this.rowDDOBRACUNRadnici["NAZIVBANKE1"] = "";
                this.rowDDOBRACUNRadnici["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowDDOBRACUNRadnici["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowDDOBRACUNRadnici["VBDIBANKE"] = "";
                this.rowDDOBRACUNRadnici["ZRNBANKE"] = "";
            }
            if (!this.rowDDOBRACUNRadnici.IsOPCINARADAIDOPCINENull())
            {
                ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINARADANAZIVOPCINE FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINARADAIDOPCINE ", false);
                if (command5.IDbCommand.Parameters.Count == 0)
                {
                    command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
                }
                command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["OPCINARADAIDOPCINE"]));
                IDataReader reader5 = command5.FetchData();
                if (!command5.HasMoreRows)
                {
                    reader5.Close();
                    throw new OPCINAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OPCINA") }));
                }
                this.rowDDOBRACUNRadnici["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader5, 0));
                reader5.Close();
            }
            else
            {
                this.rowDDOBRACUNRadnici["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVKATEGORIJA], [IDKOLONAIDD] FROM [DDKATEGORIJA] WITH (NOLOCK) WHERE [IDKATEGORIJA] = @IDKATEGORIJA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["IDKATEGORIJA"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new DDKATEGORIJAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DDKATEGORIJA") }));
            }
            this.rowDDOBRACUNRadnici["NAZIVKATEGORIJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            this.rowDDOBRACUNRadnici["IDKOLONAIDD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader2, 1));
            reader2.Close();
        }

        private void CheckExtendedTableDdobracunradniciddkrizniporez()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVKRIZNIPOREZ], [KRIZNISTOPA], [MOKRIZNI], [POKRIZNI], [MZKRIZNI], [PZKRIZNI], [PRIMATELJKRIZNI1], [PRIMATELJKRIZNI2], [PRIMATELJKRIZNI3], [SIFRAOPISAPLACANJAKRIZNI], [OPISPLACANJAKRIZNI], [VBDIKRIZNI], [ZRNKRIZNI] FROM [KRIZNIPOREZ] WITH (NOLOCK) WHERE [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["IDKRIZNIPOREZ"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new KRIZNIPOREZForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KRIZNIPOREZ") }));
            }
            this.rowDDOBRACUNRadniciDDKrizniPorez["NAZIVKRIZNIPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowDDOBRACUNRadniciDDKrizniPorez["KRIZNISTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            this.rowDDOBRACUNRadniciDDKrizniPorez["MOKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
            this.rowDDOBRACUNRadniciDDKrizniPorez["POKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
            this.rowDDOBRACUNRadniciDDKrizniPorez["MZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
            this.rowDDOBRACUNRadniciDDKrizniPorez["PZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
            this.rowDDOBRACUNRadniciDDKrizniPorez["PRIMATELJKRIZNI1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
            this.rowDDOBRACUNRadniciDDKrizniPorez["PRIMATELJKRIZNI2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
            this.rowDDOBRACUNRadniciDDKrizniPorez["PRIMATELJKRIZNI3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
            this.rowDDOBRACUNRadniciDDKrizniPorez["SIFRAOPISAPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
            this.rowDDOBRACUNRadniciDDKrizniPorez["OPISPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
            this.rowDDOBRACUNRadniciDDKrizniPorez["VBDIKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
            this.rowDDOBRACUNRadniciDDKrizniPorez["ZRNKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12));
            reader.Close();
        }

        private void CheckExtendedTableDdobracunradnicidoprinosi()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVDOPRINOS], [IDVRSTADOPRINOS], [MODOPRINOS], [PODOPRINOS], [MZDOPRINOS], [PZDOPRINOS], [PRIMATELJDOPRINOS1], [PRIMATELJDOPRINOS2], [SIFRAOPISAPLACANJADOPRINOS], [OPISPLACANJADOPRINOS], [VBDIDOPRINOS], [ZRNDOPRINOS], [STOPA] FROM [DOPRINOS] WITH (NOLOCK) WHERE [IDDOPRINOS] = @IDDOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["IDDOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new DOPRINOSForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DOPRINOS") }));
            }
            this.rowDDOBRACUNRadniciDoprinosi["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowDDOBRACUNRadniciDoprinosi["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 1));
            this.rowDDOBRACUNRadniciDoprinosi["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
            this.rowDDOBRACUNRadniciDoprinosi["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
            this.rowDDOBRACUNRadniciDoprinosi["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
            this.rowDDOBRACUNRadniciDoprinosi["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
            this.rowDDOBRACUNRadniciDoprinosi["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
            this.rowDDOBRACUNRadniciDoprinosi["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
            this.rowDDOBRACUNRadniciDoprinosi["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
            this.rowDDOBRACUNRadniciDoprinosi["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
            this.rowDDOBRACUNRadniciDoprinosi["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
            this.rowDDOBRACUNRadniciDoprinosi["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
            this.rowDDOBRACUNRadniciDoprinosi["STOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 12));
            reader.Close();
            if (!this.rowDDOBRACUNRadniciDoprinosi.IsIDVRSTADOPRINOSNull())
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVVRSTADOPRINOS] FROM [VRSTADOPRINOS] WITH (NOLOCK) WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
                }
                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["IDVRSTADOPRINOS"]));
                IDataReader reader2 = command2.FetchData();
                if (!command2.HasMoreRows)
                {
                    reader2.Close();
                    throw new VRSTADOPRINOSForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("VRSTADOPRINOS") }));
                }
                this.rowDDOBRACUNRadniciDoprinosi["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                reader2.Close();
            }
            else
            {
                this.rowDDOBRACUNRadniciDoprinosi["NAZIVVRSTADOPRINOS"] = "";
            }
        }

        private void CheckExtendedTableDdobracunradniciizdaci()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDNAZIVIZDATKA], [DDPOSTOTAKIZDATKA] FROM [DDIZDATAK] WITH (NOLOCK) WHERE [DDIDIZDATAK] = @DDIDIZDATAK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDIDIZDATAK"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new DDIZDATAKForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DDIZDATAK") }));
            }
            this.rowDDOBRACUNRadniciIzdaci["DDNAZIVIZDATKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowDDOBRACUNRadniciIzdaci["DDPOSTOTAKIZDATKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            reader.Close();
        }

        private void CheckExtendedTableDdobracunradniciporezi()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVPOREZ], [POREZMJESECNO], [STOPAPOREZA], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ] FROM [POREZ] WITH (NOLOCK) WHERE [IDPOREZ] = @IDPOREZ ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["IDPOREZ"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new POREZForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("POREZ") }));
            }
            this.rowDDOBRACUNRadniciPorezi["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            this.rowDDOBRACUNRadniciPorezi["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader2, 1));
            this.rowDDOBRACUNRadniciPorezi["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader2, 2));
            this.rowDDOBRACUNRadniciPorezi["MZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 3));
            this.rowDDOBRACUNRadniciPorezi["PZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 4));
            this.rowDDOBRACUNRadniciPorezi["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 5));
            this.rowDDOBRACUNRadniciPorezi["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 6));
            this.rowDDOBRACUNRadniciPorezi["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 7));
            this.rowDDOBRACUNRadniciPorezi["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 8));
            reader2.Close();
            if (!this.rowDDOBRACUNRadnici.IsIDKATEGORIJANull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDPOPOREZ], [DDMOPOREZ] FROM [DDKATEGORIJALevel1] WITH (NOLOCK) WHERE [IDKATEGORIJA] = @IDKATEGORIJA AND [IDPOREZ] = @IDPOREZ ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
                }
                command.SetParameter(0, this.rowDDOBRACUNRadnici.IDKATEGORIJA);
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["IDPOREZ"]));
                IDataReader reader = command.FetchData();
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new DDKATEGORIJALevel1ForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DDKATEGORIJALevel1") }));
                }
                this.rowDDOBRACUNRadniciPorezi["DDPOPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowDDOBRACUNRadniciPorezi["DDMOPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                reader.Close();
            }
            else
            {
                this.rowDDOBRACUNRadniciPorezi["DDPOPOREZ"] = "";
                this.rowDDOBRACUNRadniciPorezi["DDMOPOREZ"] = "";
            }
        }

        private void CheckExtendedTableDdobracunradnicivrsteposla()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDNAZIVVRSTAPOSLA] FROM [DDVRSTEPOSLA] WITH (NOLOCK) WHERE [DDIDVRSTAPOSLA] = @DDIDVRSTAPOSLA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDVRSTAPOSLA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDIDVRSTAPOSLA"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new DDVRSTEPOSLAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DDVRSTEPOSLA") }));
            }
            this.rowDDOBRACUNRadniciVrstePosla["DDNAZIVVRSTAPOSLA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            reader.Close();
        }

        private void CheckOptimisticConcurrencyDdobracun()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDOBRACUNIDOBRACUN], [DDOPISOBRACUN], [DDDATUMOBRACUNA], [DDZAKLJUCAN], [DDRSM] FROM [DDOBRACUN] WITH (UPDLOCK) WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDOBRACUNIDOBRACUN"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DDOBRACUNDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DDOBRACUN") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDOPISOBRACUNOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__DDDATUMOBRACUNAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 2))) || !this.m__DDZAKLJUCANOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 3)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDRSMOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4)))))
                {
                    reader.Close();
                    throw new DDOBRACUNDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DDOBRACUN") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyDdobracunradnici()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDOBRACUNIDOBRACUN], [DDOBRACUNATIPRIREZ], [DDOBRACUNATIPDV], [DDSIFRAOPCINESTANOVANJA], [DDIDRADNIK], [IDKATEGORIJA] FROM [DDOBRACUNRadnici] WITH (UPDLOCK) WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN AND [DDIDRADNIK] = @DDIDRADNIK ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDOBRACUNIDOBRACUN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDIDRADNIK"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DDOBRACUNRadniciDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DDOBRACUNRadnici") }));
                }
                if ((!command.HasMoreRows || !this.m__DDOBRACUNATIPRIREZOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1)))) || ((!this.m__DDOBRACUNATIPDVOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDSIFRAOPCINESTANOVANJAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || !this.m__IDKATEGORIJAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 5)))))
                {
                    reader.Close();
                    throw new DDOBRACUNRadniciDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DDOBRACUNRadnici") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyDdobracunradniciddkrizniporez()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [DDOSNOVICAKRIZNI], [DDPOREZKRIZNI], [DDOSNOVICAPRETHODNA], [DDOSNOVICAUKUPNA], [DDPOREZPRETHODNI], [DDPOREZUKUPNO], [IDKRIZNIPOREZ] FROM [DDOBRACUNRadniciDDKrizniPorez] WITH (UPDLOCK) WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN AND [DDIDRADNIK] = @DDIDRADNIK AND [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDOBRACUNIDOBRACUN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDIDRADNIK"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["IDKRIZNIPOREZ"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DDOBRACUNRadniciDDKrizniPorezDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DDOBRACUNRadniciDDKrizniPorez") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !this.m__DDOSNOVICAKRIZNIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2)))) || ((!this.m__DDPOREZKRIZNIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3))) || !this.m__DDOSNOVICAPRETHODNAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4)))) || (!this.m__DDOSNOVICAUKUPNAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 5))) || !this.m__DDPOREZPRETHODNIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 6))))))
                {
                    this._Condition = true;
                }
                if (this._Condition || !this.m__DDPOREZUKUPNOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 7))))
                {
                    reader.Close();
                    throw new DDOBRACUNRadniciDDKrizniPorezDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DDOBRACUNRadniciDDKrizniPorez") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyDdobracunradnicidoprinosi()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [DDOBRACUNATIDOPRINOS], [DDOSNOVICADOPRINOS], [IDDOPRINOS] FROM [DDOBRACUNRadniciDoprinosi] WITH (UPDLOCK) WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN AND [DDIDRADNIK] = @DDIDRADNIK AND [IDDOPRINOS] = @IDDOPRINOS ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["DDOBRACUNIDOBRACUN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["DDIDRADNIK"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["IDDOPRINOS"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DDOBRACUNRadniciDoprinosiDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DDOBRACUNRadniciDoprinosi") }));
                }
                if ((!command.HasMoreRows || !this.m__DDOBRACUNATIDOPRINOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2)))) || !this.m__DDOSNOVICADOPRINOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3))))
                {
                    reader.Close();
                    throw new DDOBRACUNRadniciDoprinosiDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DDOBRACUNRadniciDoprinosi") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyDdobracunradniciizdaci()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [DDOBRACUNATIIZDATAK], [DDIDIZDATAK] FROM [DDOBRACUNRadniciIzdaci] WITH (UPDLOCK) WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN AND [DDIDRADNIK] = @DDIDRADNIK AND [DDIDIZDATAK] = @DDIDIZDATAK ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDOBRACUNIDOBRACUN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDIDRADNIK"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDIDIZDATAK"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DDOBRACUNRadniciIzdaciDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DDOBRACUNRadniciIzdaci") }));
                }
                if (!command.HasMoreRows || !this.m__DDOBRACUNATIIZDATAKOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))))
                {
                    reader.Close();
                    throw new DDOBRACUNRadniciIzdaciDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DDOBRACUNRadniciIzdaci") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyDdobracunradniciporezi()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [DDOBRACUNATIPOREZ], [DDOSNOVICAPOREZ], [IDPOREZ] FROM [DDOBRACUNRadniciPorezi] WITH (UPDLOCK) WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN AND [DDIDRADNIK] = @DDIDRADNIK AND [IDPOREZ] = @IDPOREZ ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDOBRACUNIDOBRACUN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDIDRADNIK"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["IDPOREZ"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DDOBRACUNRadniciPoreziDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DDOBRACUNRadniciPorezi") }));
                }
                if ((!command.HasMoreRows || !this.m__DDOBRACUNATIPOREZOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2)))) || !this.m__DDOSNOVICAPOREZOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3))))
                {
                    reader.Close();
                    throw new DDOBRACUNRadniciPoreziDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DDOBRACUNRadniciPorezi") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyDdobracunradnicivrsteposla()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [DDSATI], [DDSATNICA], [DDIZNOS], [DDIDVRSTAPOSLA] FROM [DDOBRACUNRadniciVrstePosla] WITH (UPDLOCK) WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN AND [DDIDRADNIK] = @DDIDRADNIK AND [DDIDVRSTAPOSLA] = @DDIDVRSTAPOSLA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDVRSTAPOSLA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDOBRACUNIDOBRACUN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDIDRADNIK"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDIDVRSTAPOSLA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DDOBRACUNRadniciVrstePoslaDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DDOBRACUNRadniciVrstePosla") }));
                }
                if ((!command.HasMoreRows || !this.m__DDSATIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2)))) || (!this.m__DDSATNICAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3))) || !this.m__DDIZNOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4)))))
                {
                    reader.Close();
                    throw new DDOBRACUNRadniciVrstePoslaDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DDOBRACUNRadniciVrstePosla") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowDdobracun()
        {
            this.rowDDOBRACUN = this.DDOBRACUNSet.DDOBRACUN.NewDDOBRACUNRow();
        }

        private void CreateNewRowDdobracunradnici()
        {
            this.rowDDOBRACUNRadnici = this.DDOBRACUNSet.DDOBRACUNRadnici.NewDDOBRACUNRadniciRow();
        }

        private void CreateNewRowDdobracunradniciddkrizniporez()
        {
            this.rowDDOBRACUNRadniciDDKrizniPorez = this.DDOBRACUNSet.DDOBRACUNRadniciDDKrizniPorez.NewDDOBRACUNRadniciDDKrizniPorezRow();
        }

        private void CreateNewRowDdobracunradnicidoprinosi()
        {
            this.rowDDOBRACUNRadniciDoprinosi = this.DDOBRACUNSet.DDOBRACUNRadniciDoprinosi.NewDDOBRACUNRadniciDoprinosiRow();
        }

        private void CreateNewRowDdobracunradniciizdaci()
        {
            this.rowDDOBRACUNRadniciIzdaci = this.DDOBRACUNSet.DDOBRACUNRadniciIzdaci.NewDDOBRACUNRadniciIzdaciRow();
        }

        private void CreateNewRowDdobracunradniciporezi()
        {
            this.rowDDOBRACUNRadniciPorezi = this.DDOBRACUNSet.DDOBRACUNRadniciPorezi.NewDDOBRACUNRadniciPoreziRow();
        }

        private void CreateNewRowDdobracunradnicivrsteposla()
        {
            this.rowDDOBRACUNRadniciVrstePosla = this.DDOBRACUNSet.DDOBRACUNRadniciVrstePosla.NewDDOBRACUNRadniciVrstePoslaRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDdobracun();
            this.ProcessNestedLevelDdobracunradnici();
            this.AfterConfirmDdobracun();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DDOBRACUN]  WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDOBRACUNIDOBRACUN"]));
            command.ExecuteStmt();
            this.OnDDOBRACUNUpdated(new DDOBRACUNEventArgs(this.rowDDOBRACUN, StatementType.Delete));
            this.rowDDOBRACUN.Delete();
            this.sMode166 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode166;
        }

        private void DeleteDdobracunradnici()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDdobracunradnici();
            this.OnDeleteControlsDdobracunradnici();
            this.ProcessNestedLevelDdobracunradniciddkrizniporez();
            this.ProcessNestedLevelDdobracunradniciporezi();
            this.ProcessNestedLevelDdobracunradnicidoprinosi();
            this.ProcessNestedLevelDdobracunradniciizdaci();
            this.ProcessNestedLevelDdobracunradnicivrsteposla();
            this.AfterConfirmDdobracunradnici();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DDOBRACUNRadnici]  WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN AND [DDIDRADNIK] = @DDIDRADNIK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDIDRADNIK"]));
            command.ExecuteStmt();
            this.OnDDOBRACUNRadniciUpdated(new DDOBRACUNRadniciEventArgs(this.rowDDOBRACUNRadnici, StatementType.Delete));
            this.rowDDOBRACUNRadnici.Delete();
            this.sMode173 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode173;
        }

        private void DeleteDdobracunradniciddkrizniporez()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDdobracunradniciddkrizniporez();
            this.OnDeleteControlsDdobracunradniciddkrizniporez();
            this.AfterConfirmDdobracunradniciddkrizniporez();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DDOBRACUNRadniciDDKrizniPorez]  WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN AND [DDIDRADNIK] = @DDIDRADNIK AND [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDIDRADNIK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["IDKRIZNIPOREZ"]));
            command.ExecuteStmt();
            this.OnDDOBRACUNRadniciDDKrizniPorezUpdated(new DDOBRACUNRadniciDDKrizniPorezEventArgs(this.rowDDOBRACUNRadniciDDKrizniPorez, StatementType.Delete));
            this.rowDDOBRACUNRadniciDDKrizniPorez.Delete();
            this.sMode178 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode178;
        }

        private void DeleteDdobracunradnicidoprinosi()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDdobracunradnicidoprinosi();
            this.OnDeleteControlsDdobracunradnicidoprinosi();
            this.AfterConfirmDdobracunradnicidoprinosi();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DDOBRACUNRadniciDoprinosi]  WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN AND [DDIDRADNIK] = @DDIDRADNIK AND [IDDOPRINOS] = @IDDOPRINOS", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["DDIDRADNIK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["IDDOPRINOS"]));
            command.ExecuteStmt();
            this.OnDDOBRACUNRadniciDoprinosiUpdated(new DDOBRACUNRadniciDoprinosiEventArgs(this.rowDDOBRACUNRadniciDoprinosi, StatementType.Delete));
            this.rowDDOBRACUNRadniciDoprinosi.Delete();
            this.sMode176 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode176;
        }

        private void DeleteDdobracunradniciizdaci()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDdobracunradniciizdaci();
            this.OnDeleteControlsDdobracunradniciizdaci();
            this.AfterConfirmDdobracunradniciizdaci();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DDOBRACUNRadniciIzdaci]  WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN AND [DDIDRADNIK] = @DDIDRADNIK AND [DDIDIZDATAK] = @DDIDIZDATAK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDIDRADNIK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDIDIZDATAK"]));
            command.ExecuteStmt();
            this.OnDDOBRACUNRadniciIzdaciUpdated(new DDOBRACUNRadniciIzdaciEventArgs(this.rowDDOBRACUNRadniciIzdaci, StatementType.Delete));
            this.rowDDOBRACUNRadniciIzdaci.Delete();
            this.sMode175 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode175;
        }

        private void DeleteDdobracunradniciporezi()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDdobracunradniciporezi();
            this.OnDeleteControlsDdobracunradniciporezi();
            this.AfterConfirmDdobracunradniciporezi();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DDOBRACUNRadniciPorezi]  WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN AND [DDIDRADNIK] = @DDIDRADNIK AND [IDPOREZ] = @IDPOREZ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDIDRADNIK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["IDPOREZ"]));
            command.ExecuteStmt();
            this.OnDDOBRACUNRadniciPoreziUpdated(new DDOBRACUNRadniciPoreziEventArgs(this.rowDDOBRACUNRadniciPorezi, StatementType.Delete));
            this.rowDDOBRACUNRadniciPorezi.Delete();
            this.sMode177 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode177;
        }

        private void DeleteDdobracunradnicivrsteposla()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDdobracunradnicivrsteposla();
            this.OnDeleteControlsDdobracunradnicivrsteposla();
            this.AfterConfirmDdobracunradnicivrsteposla();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DDOBRACUNRadniciVrstePosla]  WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN AND [DDIDRADNIK] = @DDIDRADNIK AND [DDIDVRSTAPOSLA] = @DDIDVRSTAPOSLA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDVRSTAPOSLA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDIDRADNIK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDIDVRSTAPOSLA"]));
            command.ExecuteStmt();
            this.OnDDOBRACUNRadniciVrstePoslaUpdated(new DDOBRACUNRadniciVrstePoslaEventArgs(this.rowDDOBRACUNRadniciVrstePosla, StatementType.Delete));
            this.rowDDOBRACUNRadniciVrstePosla.Delete();
            this.sMode174 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode174;
        }


        public virtual int Fill(DDOBRACUNDataSet dataSet)
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
                    this.DDOBRACUNSet = dataSet;
                    this.LoadChildDdobracun(0, -1);
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
            this.DDOBRACUNSet = (DDOBRACUNDataSet) dataSet;
            if (this.DDOBRACUNSet != null)
            {
                return this.Fill(this.DDOBRACUNSet);
            }
            this.DDOBRACUNSet = new DDOBRACUNDataSet();
            this.Fill(this.DDOBRACUNSet);
            dataSet.Merge(this.DDOBRACUNSet);
            return 0;
        }

        public virtual int Fill(DDOBRACUNDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["DDOBRACUNIDOBRACUN"]));
        }

        public virtual int Fill(DDOBRACUNDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["DDOBRACUNIDOBRACUN"]));
        }

        public virtual int Fill(DDOBRACUNDataSet dataSet, string dDOBRACUNIDOBRACUN)
        {
            if (!this.FillByDDOBRACUNIDOBRACUN(dataSet, dDOBRACUNIDOBRACUN))
            {
                throw new DDOBRACUNNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DDOBRACUN") }));
            }
            return 0;
        }

        public virtual bool FillByDDOBRACUNIDOBRACUN(DDOBRACUNDataSet dataSet, string dDOBRACUNIDOBRACUN)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDOBRACUNSet = dataSet;
            this.rowDDOBRACUN = this.DDOBRACUNSet.DDOBRACUN.NewDDOBRACUNRow();
            this.rowDDOBRACUN.DDOBRACUNIDOBRACUN = dDOBRACUNIDOBRACUN;
            try
            {
                this.LoadByDDOBRACUNIDOBRACUN(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound166 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(DDOBRACUNDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDOBRACUNSet = dataSet;
            try
            {
                this.LoadChildDdobracun(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDOBRACUNIDOBRACUN], [DDOPISOBRACUN], [DDDATUMOBRACUNA], [DDZAKLJUCAN], [DDRSM] FROM [DDOBRACUN] WITH (NOLOCK) WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDOBRACUNIDOBRACUN"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound166 = 1;
                this.rowDDOBRACUN["DDOBRACUNIDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowDDOBRACUN["DDOPISOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowDDOBRACUN["DDDATUMOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 2));
                this.rowDDOBRACUN["DDZAKLJUCAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 3));
                this.rowDDOBRACUN["DDRSM"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.sMode166 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode166;
            }
            else
            {
                this.RcdFound166 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "DDOBRACUNIDOBRACUN";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDOBRACUNSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [DDOBRACUN] WITH (NOLOCK) ", false);
            this.DDOBRACUNSelect1 = this.cmDDOBRACUNSelect1.FetchData();
            if (this.DDOBRACUNSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.DDOBRACUNSelect1.GetInt32(0);
            }
            this.DDOBRACUNSelect1.Close();
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
            this.RcdFound166 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__DDOSNOVICAKRIZNIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDPOREZKRIZNIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDOSNOVICAPRETHODNAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDOSNOVICAUKUPNAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDPOREZPRETHODNIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDPOREZUKUPNOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove117 = false;
            this._Condition = false;
            this.RcdFound178 = 0;
            this.m_SubSelTopString178 = "";
            this.m__DDOBRACUNATIPOREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDOSNOVICAPOREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove102 = false;
            this.RcdFound177 = 0;
            this.m_SubSelTopString177 = "";
            this.m__DDOBRACUNATIDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDOSNOVICADOPRINOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove84 = false;
            this.RcdFound176 = 0;
            this.m_SubSelTopString176 = "";
            this.m__DDOBRACUNATIIZDATAKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove79 = false;
            this.RcdFound175 = 0;
            this.m_SubSelTopString175 = "";
            this.m__DDSATIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDSATNICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDIZNOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove73 = false;
            this.RcdFound174 = 0;
            this.m_SubSelTopString174 = "";
            this.m__DDOBRACUNATIPRIREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDOBRACUNATIPDVOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDSIFRAOPCINESTANOVANJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDKATEGORIJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.RcdFound173 = 0;
            this.m_SubSelTopString173 = "";
            this.m__DDOPISOBRACUNOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDDATUMOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDZAKLJUCANOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDRSMOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.DDOBRACUNSet = new DDOBRACUNDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertDdobracun()
        {
            this.CheckOptimisticConcurrencyDdobracun();
            this.AfterConfirmDdobracun();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DDOBRACUN] ([DDOBRACUNIDOBRACUN], [DDOPISOBRACUN], [DDDATUMOBRACUNA], [DDZAKLJUCAN], [DDRSM]) VALUES (@DDOBRACUNIDOBRACUN, @DDOPISOBRACUN, @DDDATUMOBRACUNA, @DDZAKLJUCAN, @DDRSM)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOPISOBRACUN", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDDATUMOBRACUNA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDZAKLJUCAN", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDRSM", DbType.String, 4));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDOPISOBRACUN"]));
            command.SetParameterDateObject(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDDATUMOBRACUNA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDZAKLJUCAN"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDRSM"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DDOBRACUNDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDDOBRACUNUpdated(new DDOBRACUNEventArgs(this.rowDDOBRACUN, StatementType.Insert));
            this.ProcessLevelDdobracun();
        }

        private void InsertDdobracunradnici()
        {
            this.CheckOptimisticConcurrencyDdobracunradnici();
            this.CheckExtendedTableDdobracunradnici();
            this.AfterConfirmDdobracunradnici();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DDOBRACUNRadnici] ([OPCINASTANOVANJAIDOPCINE], [IDKOLONAIDD], [DDOBRACUNIDOBRACUN], [DDOBRACUNATIPRIREZ], [DDOBRACUNATIPDV], [DDSIFRAOPCINESTANOVANJA], [DDIDRADNIK], [IDKATEGORIJA]) VALUES (@OPCINASTANOVANJAIDOPCINE, @IDKOLONAIDD, @DDOBRACUNIDOBRACUN, @DDOBRACUNATIPRIREZ, @DDOBRACUNATIPDV, @DDSIFRAOPCINESTANOVANJA, @DDIDRADNIK, @IDKATEGORIJA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNATIPRIREZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNATIPDV", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDSIFRAOPCINESTANOVANJA", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["OPCINASTANOVANJAIDOPCINE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["IDKOLONAIDD"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDOBRACUNATIPRIREZ"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDOBRACUNATIPDV"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDSIFRAOPCINESTANOVANJA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDIDRADNIK"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["IDKATEGORIJA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DDOBRACUNRadniciDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDDOBRACUNRadniciUpdated(new DDOBRACUNRadniciEventArgs(this.rowDDOBRACUNRadnici, StatementType.Insert));
            this.ProcessLevelDdobracunradnici();
        }

        private void InsertDdobracunradniciddkrizniporez()
        {
            this.CheckOptimisticConcurrencyDdobracunradniciddkrizniporez();
            this.CheckExtendedTableDdobracunradniciddkrizniporez();
            this.AfterConfirmDdobracunradniciddkrizniporez();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DDOBRACUNRadniciDDKrizniPorez] ([NAZIVKRIZNIPOREZ], [KRIZNISTOPA], [MOKRIZNI], [POKRIZNI], [MZKRIZNI], [PZKRIZNI], [PRIMATELJKRIZNI1], [PRIMATELJKRIZNI2], [PRIMATELJKRIZNI3], [SIFRAOPISAPLACANJAKRIZNI], [OPISPLACANJAKRIZNI], [VBDIKRIZNI], [ZRNKRIZNI], [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [DDOSNOVICAKRIZNI], [DDPOREZKRIZNI], [DDOSNOVICAPRETHODNA], [DDOSNOVICAUKUPNA], [DDPOREZPRETHODNI], [DDPOREZUKUPNO], [IDKRIZNIPOREZ]) VALUES (@NAZIVKRIZNIPOREZ, @KRIZNISTOPA, @MOKRIZNI, @POKRIZNI, @MZKRIZNI, @PZKRIZNI, @PRIMATELJKRIZNI1, @PRIMATELJKRIZNI2, @PRIMATELJKRIZNI3, @SIFRAOPISAPLACANJAKRIZNI, @OPISPLACANJAKRIZNI, @VBDIKRIZNI, @ZRNKRIZNI, @DDOBRACUNIDOBRACUN, @DDIDRADNIK, @DDOSNOVICAKRIZNI, @DDPOREZKRIZNI, @DDOSNOVICAPRETHODNA, @DDOSNOVICAUKUPNA, @DDPOREZPRETHODNI, @DDPOREZUKUPNO, @IDKRIZNIPOREZ)", false);
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
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAKRIZNI", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAKRIZNI", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIKRIZNI", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNKRIZNI", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOSNOVICAKRIZNI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPOREZKRIZNI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOSNOVICAPRETHODNA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOSNOVICAUKUPNA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPOREZPRETHODNI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPOREZUKUPNO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["NAZIVKRIZNIPOREZ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["KRIZNISTOPA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["MOKRIZNI"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["POKRIZNI"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["MZKRIZNI"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["PZKRIZNI"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["PRIMATELJKRIZNI1"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["PRIMATELJKRIZNI2"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["PRIMATELJKRIZNI3"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["SIFRAOPISAPLACANJAKRIZNI"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["OPISPLACANJAKRIZNI"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["VBDIKRIZNI"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["ZRNKRIZNI"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDIDRADNIK"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDOSNOVICAKRIZNI"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDPOREZKRIZNI"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDOSNOVICAPRETHODNA"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDOSNOVICAUKUPNA"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDPOREZPRETHODNI"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDPOREZUKUPNO"]));
            command.SetParameter(0x15, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["IDKRIZNIPOREZ"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DDOBRACUNRadniciDDKrizniPorezDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDDOBRACUNRadniciDDKrizniPorezUpdated(new DDOBRACUNRadniciDDKrizniPorezEventArgs(this.rowDDOBRACUNRadniciDDKrizniPorez, StatementType.Insert));
        }

        private void InsertDdobracunradnicidoprinosi()
        {
            this.CheckOptimisticConcurrencyDdobracunradnicidoprinosi();
            this.CheckExtendedTableDdobracunradnicidoprinosi();
            this.AfterConfirmDdobracunradnicidoprinosi();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DDOBRACUNRadniciDoprinosi] ([NAZIVDOPRINOS], [IDVRSTADOPRINOS], [NAZIVVRSTADOPRINOS], [MODOPRINOS], [PODOPRINOS], [MZDOPRINOS], [PZDOPRINOS], [PRIMATELJDOPRINOS1], [PRIMATELJDOPRINOS2], [SIFRAOPISAPLACANJADOPRINOS], [OPISPLACANJADOPRINOS], [VBDIDOPRINOS], [ZRNDOPRINOS], [STOPA], [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [DDOBRACUNATIDOPRINOS], [DDOSNOVICADOPRINOS], [IDDOPRINOS]) VALUES (@NAZIVDOPRINOS, @IDVRSTADOPRINOS, @NAZIVVRSTADOPRINOS, @MODOPRINOS, @PODOPRINOS, @MZDOPRINOS, @PZDOPRINOS, @PRIMATELJDOPRINOS1, @PRIMATELJDOPRINOS2, @SIFRAOPISAPLACANJADOPRINOS, @OPISPLACANJADOPRINOS, @VBDIDOPRINOS, @ZRNDOPRINOS, @STOPA, @DDOBRACUNIDOBRACUN, @DDIDRADNIK, @DDOBRACUNATIDOPRINOS, @DDOSNOVICADOPRINOS, @IDDOPRINOS)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVDOPRINOS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTADOPRINOS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MODOPRINOS", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PODOPRINOS", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZDOPRINOS", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZDOPRINOS", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJDOPRINOS1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJDOPRINOS2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJADOPRINOS", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJADOPRINOS", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIDOPRINOS", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNDOPRINOS", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STOPA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNATIDOPRINOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOSNOVICADOPRINOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["NAZIVDOPRINOS"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["IDVRSTADOPRINOS"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["NAZIVVRSTADOPRINOS"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["MODOPRINOS"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["PODOPRINOS"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["MZDOPRINOS"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["PZDOPRINOS"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["PRIMATELJDOPRINOS1"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["PRIMATELJDOPRINOS2"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["SIFRAOPISAPLACANJADOPRINOS"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["OPISPLACANJADOPRINOS"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["VBDIDOPRINOS"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["ZRNDOPRINOS"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["STOPA"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["DDIDRADNIK"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["DDOBRACUNATIDOPRINOS"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["DDOSNOVICADOPRINOS"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["IDDOPRINOS"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DDOBRACUNRadniciDoprinosiDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDDOBRACUNRadniciDoprinosiUpdated(new DDOBRACUNRadniciDoprinosiEventArgs(this.rowDDOBRACUNRadniciDoprinosi, StatementType.Insert));
        }

        private void InsertDdobracunradniciizdaci()
        {
            this.CheckOptimisticConcurrencyDdobracunradniciizdaci();
            this.CheckExtendedTableDdobracunradniciizdaci();
            this.AfterConfirmDdobracunradniciizdaci();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DDOBRACUNRadniciIzdaci] ([DDPOSTOTAKIZDATKA], [DDNAZIVIZDATKA], [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [DDOBRACUNATIIZDATAK], [DDIDIZDATAK]) VALUES (@DDPOSTOTAKIZDATKA, @DDNAZIVIZDATKA, @DDOBRACUNIDOBRACUN, @DDIDRADNIK, @DDOBRACUNATIIZDATAK, @DDIDIZDATAK)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPOSTOTAKIZDATKA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDNAZIVIZDATKA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNATIIZDATAK", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDPOSTOTAKIZDATKA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDNAZIVIZDATKA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDIDRADNIK"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDOBRACUNATIIZDATAK"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDIDIZDATAK"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DDOBRACUNRadniciIzdaciDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDDOBRACUNRadniciIzdaciUpdated(new DDOBRACUNRadniciIzdaciEventArgs(this.rowDDOBRACUNRadniciIzdaci, StatementType.Insert));
        }

        private void InsertDdobracunradniciporezi()
        {
            this.CheckOptimisticConcurrencyDdobracunradniciporezi();
            this.CheckExtendedTableDdobracunradniciporezi();
            this.AfterConfirmDdobracunradniciporezi();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DDOBRACUNRadniciPorezi] ([NAZIVPOREZ], [STOPAPOREZA], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ], [DDPOPOREZ], [DDMOPOREZ], [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [DDOBRACUNATIPOREZ], [DDOSNOVICAPOREZ], [IDPOREZ]) VALUES (@NAZIVPOREZ, @STOPAPOREZA, @MZPOREZ, @PZPOREZ, @PRIMATELJPOREZ1, @PRIMATELJPOREZ2, @SIFRAOPISAPLACANJAPOREZ, @OPISPLACANJAPOREZ, @DDPOPOREZ, @DDMOPOREZ, @DDOBRACUNIDOBRACUN, @DDIDRADNIK, @DDOBRACUNATIPOREZ, @DDOSNOVICAPOREZ, @IDPOREZ)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPOREZ", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STOPAPOREZA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZPOREZ", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJPOREZ1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJPOREZ2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAPOREZ", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPOPOREZ", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDMOPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNATIPOREZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOSNOVICAPOREZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["NAZIVPOREZ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["STOPAPOREZA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["MZPOREZ"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["PZPOREZ"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["PRIMATELJPOREZ1"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["PRIMATELJPOREZ2"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["SIFRAOPISAPLACANJAPOREZ"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["OPISPLACANJAPOREZ"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDPOPOREZ"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDMOPOREZ"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDIDRADNIK"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDOBRACUNATIPOREZ"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDOSNOVICAPOREZ"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["IDPOREZ"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DDOBRACUNRadniciPoreziDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDDOBRACUNRadniciPoreziUpdated(new DDOBRACUNRadniciPoreziEventArgs(this.rowDDOBRACUNRadniciPorezi, StatementType.Insert));
        }

        private void InsertDdobracunradnicivrsteposla()
        {
            this.CheckOptimisticConcurrencyDdobracunradnicivrsteposla();
            this.CheckExtendedTableDdobracunradnicivrsteposla();
            this.AfterConfirmDdobracunradnicivrsteposla();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DDOBRACUNRadniciVrstePosla] ([DDNAZIVVRSTAPOSLA], [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [DDSATI], [DDSATNICA], [DDIZNOS], [DDIDVRSTAPOSLA]) VALUES (@DDNAZIVVRSTAPOSLA, @DDOBRACUNIDOBRACUN, @DDIDRADNIK, @DDSATI, @DDSATNICA, @DDIZNOS, @DDIDVRSTAPOSLA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDNAZIVVRSTAPOSLA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDSATI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDSATNICA", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDVRSTAPOSLA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDNAZIVVRSTAPOSLA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDIDRADNIK"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDSATI"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDSATNICA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDIZNOS"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDIDVRSTAPOSLA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DDOBRACUNRadniciVrstePoslaDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDDOBRACUNRadniciVrstePoslaUpdated(new DDOBRACUNRadniciVrstePoslaEventArgs(this.rowDDOBRACUNRadniciVrstePosla, StatementType.Insert));
        }

        private void LoadByDDOBRACUNIDOBRACUN(int startRow, int maxRows)
        {
            bool enforceConstraints = this.DDOBRACUNSet.EnforceConstraints;
            this.DDOBRACUNSet.DDOBRACUNRadniciDDKrizniPorez.BeginLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadniciPorezi.BeginLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadniciDoprinosi.BeginLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadniciIzdaci.BeginLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadniciVrstePosla.BeginLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadnici.BeginLoadData();
            this.DDOBRACUNSet.DDOBRACUN.BeginLoadData();
            this.ScanByDDOBRACUNIDOBRACUN(startRow, maxRows);
            try
            {
                this.DDOBRACUNSet.DDOBRACUNRadniciDDKrizniPorez.EndLoadData();
            }
            catch { }
            this.DDOBRACUNSet.DDOBRACUNRadniciPorezi.EndLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadniciDoprinosi.EndLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadniciIzdaci.EndLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadniciVrstePosla.EndLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadnici.EndLoadData();
            this.DDOBRACUNSet.DDOBRACUN.EndLoadData();
            try
            {
                this.DDOBRACUNSet.EnforceConstraints = enforceConstraints;
            }
            catch { }
            if (this.DDOBRACUNSet.DDOBRACUN.Count > 0)
            {
                this.rowDDOBRACUN = this.DDOBRACUNSet.DDOBRACUN[this.DDOBRACUNSet.DDOBRACUN.Count - 1];
            }
        }

        private void LoadChildDdobracun(int startRow, int maxRows)
        {
            this.CreateNewRowDdobracun();
            bool enforceConstraints = this.DDOBRACUNSet.EnforceConstraints;
            this.DDOBRACUNSet.DDOBRACUNRadniciDDKrizniPorez.BeginLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadniciPorezi.BeginLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadniciDoprinosi.BeginLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadniciIzdaci.BeginLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadniciVrstePosla.BeginLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadnici.BeginLoadData();
            this.DDOBRACUNSet.DDOBRACUN.BeginLoadData();
            this.ScanStartDdobracun(startRow, maxRows);
            this.DDOBRACUNSet.DDOBRACUNRadniciDDKrizniPorez.EndLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadniciPorezi.EndLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadniciDoprinosi.EndLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadniciIzdaci.EndLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadniciVrstePosla.EndLoadData();
            this.DDOBRACUNSet.DDOBRACUNRadnici.EndLoadData();
            this.DDOBRACUNSet.DDOBRACUN.EndLoadData();
            this.DDOBRACUNSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildDdobracunradnici()
        {
            this.CreateNewRowDdobracunradnici();
            this.ScanStartDdobracunradnici();
        }

        private void LoadChildDdobracunradniciddkrizniporez()
        {
            this.CreateNewRowDdobracunradniciddkrizniporez();
            this.ScanStartDdobracunradniciddkrizniporez();
        }

        private void LoadChildDdobracunradnicidoprinosi()
        {
            this.CreateNewRowDdobracunradnicidoprinosi();
            this.ScanStartDdobracunradnicidoprinosi();
        }

        private void LoadChildDdobracunradniciizdaci()
        {
            this.CreateNewRowDdobracunradniciizdaci();
            this.ScanStartDdobracunradniciizdaci();
        }

        private void LoadChildDdobracunradniciporezi()
        {
            this.CreateNewRowDdobracunradniciporezi();
            this.ScanStartDdobracunradniciporezi();
        }

        private void LoadChildDdobracunradnicivrsteposla()
        {
            this.CreateNewRowDdobracunradnicivrsteposla();
            this.ScanStartDdobracunradnicivrsteposla();
        }

        private void LoadDataDdobracun(int maxRows)
        {
            int num = 0;
            if (this.RcdFound166 != 0)
            {
                this.ScanLoadDdobracun();
                while ((this.RcdFound166 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowDdobracun();
                    this.CreateNewRowDdobracun();
                    this.ScanNextDdobracun();
                }
            }
            if (num > 0)
            {
                this.RcdFound166 = 1;
            }
            this.ScanEndDdobracun();
            if (this.DDOBRACUNSet.DDOBRACUN.Count > 0)
            {
                this.rowDDOBRACUN = this.DDOBRACUNSet.DDOBRACUN[this.DDOBRACUNSet.DDOBRACUN.Count - 1];
            }
        }

        private void LoadDataDdobracunradnici()
        {
            while (this.RcdFound173 != 0)
            {
                this.LoadRowDdobracunradnici();
                this.CreateNewRowDdobracunradnici();
                this.ScanNextDdobracunradnici();
            }
            this.ScanEndDdobracunradnici();
        }

        private void LoadDataDdobracunradniciddkrizniporez()
        {
            while (this.RcdFound178 != 0)
            {
                this.LoadRowDdobracunradniciddkrizniporez();
                this.CreateNewRowDdobracunradniciddkrizniporez();
                this.ScanNextDdobracunradniciddkrizniporez();
            }
            this.ScanEndDdobracunradniciddkrizniporez();
        }

        private void LoadDataDdobracunradnicidoprinosi()
        {
            while (this.RcdFound176 != 0)
            {
                this.LoadRowDdobracunradnicidoprinosi();
                this.CreateNewRowDdobracunradnicidoprinosi();
                this.ScanNextDdobracunradnicidoprinosi();
            }
            this.ScanEndDdobracunradnicidoprinosi();
        }

        private void LoadDataDdobracunradniciizdaci()
        {
            while (this.RcdFound175 != 0)
            {
                this.LoadRowDdobracunradniciizdaci();
                this.CreateNewRowDdobracunradniciizdaci();
                this.ScanNextDdobracunradniciizdaci();
            }
            this.ScanEndDdobracunradniciizdaci();
        }

        private void LoadDataDdobracunradniciporezi()
        {
            while (this.RcdFound177 != 0)
            {
                this.LoadRowDdobracunradniciporezi();
                this.CreateNewRowDdobracunradniciporezi();
                this.ScanNextDdobracunradniciporezi();
            }
            this.ScanEndDdobracunradniciporezi();
        }

        private void LoadDataDdobracunradnicivrsteposla()
        {
            while (this.RcdFound174 != 0)
            {
                this.LoadRowDdobracunradnicivrsteposla();
                this.CreateNewRowDdobracunradnicivrsteposla();
                this.ScanNextDdobracunradnicivrsteposla();
            }
            this.ScanEndDdobracunradnicivrsteposla();
        }

        private void LoadRowDdobracun()
        {
            this.AddRowDdobracun();
        }

        private void LoadRowDdobracunradnici()
        {
            this.AddRowDdobracunradnici();
        }

        private void LoadRowDdobracunradniciddkrizniporez()
        {
            this.AddRowDdobracunradniciddkrizniporez();
        }

        private void LoadRowDdobracunradnicidoprinosi()
        {
            this.AddRowDdobracunradnicidoprinosi();
        }

        private void LoadRowDdobracunradniciizdaci()
        {
            this.AddRowDdobracunradniciizdaci();
        }

        private void LoadRowDdobracunradniciporezi()
        {
            this.AddRowDdobracunradniciporezi();
        }

        private void LoadRowDdobracunradnicivrsteposla()
        {
            this.AddRowDdobracunradnicivrsteposla();
        }

        private void OnDDOBRACUNRadniciDDKrizniPorezUpdated(DDOBRACUNRadniciDDKrizniPorezEventArgs e)
        {
            if (this.DDOBRACUNRadniciDDKrizniPorezUpdated != null)
            {
                DDOBRACUNRadniciDDKrizniPorezUpdateEventHandler dDOBRACUNRadniciDDKrizniPorezUpdatedEvent = this.DDOBRACUNRadniciDDKrizniPorezUpdated;
                if (dDOBRACUNRadniciDDKrizniPorezUpdatedEvent != null)
                {
                    dDOBRACUNRadniciDDKrizniPorezUpdatedEvent(this, e);
                }
            }
        }

        private void OnDDOBRACUNRadniciDDKrizniPorezUpdating(DDOBRACUNRadniciDDKrizniPorezEventArgs e)
        {
            if (this.DDOBRACUNRadniciDDKrizniPorezUpdating != null)
            {
                DDOBRACUNRadniciDDKrizniPorezUpdateEventHandler dDOBRACUNRadniciDDKrizniPorezUpdatingEvent = this.DDOBRACUNRadniciDDKrizniPorezUpdating;
                if (dDOBRACUNRadniciDDKrizniPorezUpdatingEvent != null)
                {
                    dDOBRACUNRadniciDDKrizniPorezUpdatingEvent(this, e);
                }
            }
        }

        private void OnDDOBRACUNRadniciDoprinosiUpdated(DDOBRACUNRadniciDoprinosiEventArgs e)
        {
            if (this.DDOBRACUNRadniciDoprinosiUpdated != null)
            {
                DDOBRACUNRadniciDoprinosiUpdateEventHandler dDOBRACUNRadniciDoprinosiUpdatedEvent = this.DDOBRACUNRadniciDoprinosiUpdated;
                if (dDOBRACUNRadniciDoprinosiUpdatedEvent != null)
                {
                    dDOBRACUNRadniciDoprinosiUpdatedEvent(this, e);
                }
            }
        }

        private void OnDDOBRACUNRadniciDoprinosiUpdating(DDOBRACUNRadniciDoprinosiEventArgs e)
        {
            if (this.DDOBRACUNRadniciDoprinosiUpdating != null)
            {
                DDOBRACUNRadniciDoprinosiUpdateEventHandler dDOBRACUNRadniciDoprinosiUpdatingEvent = this.DDOBRACUNRadniciDoprinosiUpdating;
                if (dDOBRACUNRadniciDoprinosiUpdatingEvent != null)
                {
                    dDOBRACUNRadniciDoprinosiUpdatingEvent(this, e);
                }
            }
        }

        private void OnDDOBRACUNRadniciIzdaciUpdated(DDOBRACUNRadniciIzdaciEventArgs e)
        {
            if (this.DDOBRACUNRadniciIzdaciUpdated != null)
            {
                DDOBRACUNRadniciIzdaciUpdateEventHandler dDOBRACUNRadniciIzdaciUpdatedEvent = this.DDOBRACUNRadniciIzdaciUpdated;
                if (dDOBRACUNRadniciIzdaciUpdatedEvent != null)
                {
                    dDOBRACUNRadniciIzdaciUpdatedEvent(this, e);
                }
            }
        }

        private void OnDDOBRACUNRadniciIzdaciUpdating(DDOBRACUNRadniciIzdaciEventArgs e)
        {
            if (this.DDOBRACUNRadniciIzdaciUpdating != null)
            {
                DDOBRACUNRadniciIzdaciUpdateEventHandler dDOBRACUNRadniciIzdaciUpdatingEvent = this.DDOBRACUNRadniciIzdaciUpdating;
                if (dDOBRACUNRadniciIzdaciUpdatingEvent != null)
                {
                    dDOBRACUNRadniciIzdaciUpdatingEvent(this, e);
                }
            }
        }

        private void OnDDOBRACUNRadniciPoreziUpdated(DDOBRACUNRadniciPoreziEventArgs e)
        {
            if (this.DDOBRACUNRadniciPoreziUpdated != null)
            {
                DDOBRACUNRadniciPoreziUpdateEventHandler dDOBRACUNRadniciPoreziUpdatedEvent = this.DDOBRACUNRadniciPoreziUpdated;
                if (dDOBRACUNRadniciPoreziUpdatedEvent != null)
                {
                    dDOBRACUNRadniciPoreziUpdatedEvent(this, e);
                }
            }
        }

        private void OnDDOBRACUNRadniciPoreziUpdating(DDOBRACUNRadniciPoreziEventArgs e)
        {
            if (this.DDOBRACUNRadniciPoreziUpdating != null)
            {
                DDOBRACUNRadniciPoreziUpdateEventHandler dDOBRACUNRadniciPoreziUpdatingEvent = this.DDOBRACUNRadniciPoreziUpdating;
                if (dDOBRACUNRadniciPoreziUpdatingEvent != null)
                {
                    dDOBRACUNRadniciPoreziUpdatingEvent(this, e);
                }
            }
        }

        private void OnDDOBRACUNRadniciUpdated(DDOBRACUNRadniciEventArgs e)
        {
            if (this.DDOBRACUNRadniciUpdated != null)
            {
                DDOBRACUNRadniciUpdateEventHandler dDOBRACUNRadniciUpdatedEvent = this.DDOBRACUNRadniciUpdated;
                if (dDOBRACUNRadniciUpdatedEvent != null)
                {
                    dDOBRACUNRadniciUpdatedEvent(this, e);
                }
            }
        }

        private void OnDDOBRACUNRadniciUpdating(DDOBRACUNRadniciEventArgs e)
        {
            if (this.DDOBRACUNRadniciUpdating != null)
            {
                DDOBRACUNRadniciUpdateEventHandler dDOBRACUNRadniciUpdatingEvent = this.DDOBRACUNRadniciUpdating;
                if (dDOBRACUNRadniciUpdatingEvent != null)
                {
                    dDOBRACUNRadniciUpdatingEvent(this, e);
                }
            }
        }

        private void OnDDOBRACUNRadniciVrstePoslaUpdated(DDOBRACUNRadniciVrstePoslaEventArgs e)
        {
            if (this.DDOBRACUNRadniciVrstePoslaUpdated != null)
            {
                DDOBRACUNRadniciVrstePoslaUpdateEventHandler dDOBRACUNRadniciVrstePoslaUpdatedEvent = this.DDOBRACUNRadniciVrstePoslaUpdated;
                if (dDOBRACUNRadniciVrstePoslaUpdatedEvent != null)
                {
                    dDOBRACUNRadniciVrstePoslaUpdatedEvent(this, e);
                }
            }
        }

        private void OnDDOBRACUNRadniciVrstePoslaUpdating(DDOBRACUNRadniciVrstePoslaEventArgs e)
        {
            if (this.DDOBRACUNRadniciVrstePoslaUpdating != null)
            {
                DDOBRACUNRadniciVrstePoslaUpdateEventHandler dDOBRACUNRadniciVrstePoslaUpdatingEvent = this.DDOBRACUNRadniciVrstePoslaUpdating;
                if (dDOBRACUNRadniciVrstePoslaUpdatingEvent != null)
                {
                    dDOBRACUNRadniciVrstePoslaUpdatingEvent(this, e);
                }
            }
        }

        private void OnDDOBRACUNUpdated(DDOBRACUNEventArgs e)
        {
            if (this.DDOBRACUNUpdated != null)
            {
                DDOBRACUNUpdateEventHandler dDOBRACUNUpdatedEvent = this.DDOBRACUNUpdated;
                if (dDOBRACUNUpdatedEvent != null)
                {
                    dDOBRACUNUpdatedEvent(this, e);
                }
            }
        }

        private void OnDDOBRACUNUpdating(DDOBRACUNEventArgs e)
        {
            if (this.DDOBRACUNUpdating != null)
            {
                DDOBRACUNUpdateEventHandler dDOBRACUNUpdatingEvent = this.DDOBRACUNUpdating;
                if (dDOBRACUNUpdatingEvent != null)
                {
                    dDOBRACUNUpdatingEvent(this, e);
                }
            }
        }

        private void OnDeleteControlsDdobracunradnici()
        {
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [DDPREZIME], [DDIME], [OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, [DDPDVOBVEZNIK], [DDDRUGISTUP], [DDOIB], [DDZRN], [IDBANKE], [OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE FROM [DDRADNIK] WITH (NOLOCK) WHERE [DDIDRADNIK] = @DDIDRADNIK ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDIDRADNIK"]));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                this.rowDDOBRACUNRadnici["DDPREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0));
                this.rowDDOBRACUNRadnici["DDIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 1));
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 2));
                this.rowDDOBRACUNRadnici["DDPDVOBVEZNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader3, 3));
                this.rowDDOBRACUNRadnici["DDDRUGISTUP"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader3, 4));
                this.rowDDOBRACUNRadnici["DDOIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 5));
                this.rowDDOBRACUNRadnici["DDZRN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 6));
                this.rowDDOBRACUNRadnici["IDBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader3, 7));
                this.rowDDOBRACUNRadnici["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 8));
            }
            reader3.Close();
            if (!this.rowDDOBRACUNRadnici.IsOPCINASTANOVANJAIDOPCINENull())
            {
                ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, [PRIREZ] AS OPCINASTANOVANJAPRIREZ, [VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, [ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINASTANOVANJAIDOPCINE ", false);
                if (command4.IDbCommand.Parameters.Count == 0)
                {
                    command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
                }
                command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["OPCINASTANOVANJAIDOPCINE"]));
                IDataReader reader4 = command4.FetchData();
                if (command4.HasMoreRows)
                {
                    this.rowDDOBRACUNRadnici["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader4, 0));
                    this.rowDDOBRACUNRadnici["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader4, 1));
                    this.rowDDOBRACUNRadnici["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader4, 2));
                    this.rowDDOBRACUNRadnici["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader4, 3));
                }
                reader4.Close();
            }
            else
            {
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowDDOBRACUNRadnici.IsIDBANKENull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVBANKE1], [NAZIVBANKE2], [NAZIVBANKE3], [VBDIBANKE], [ZRNBANKE] FROM [BANKE] WITH (NOLOCK) WHERE [IDBANKE] = @IDBANKE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["IDBANKE"]));
                IDataReader reader = command.FetchData();
                if (command.HasMoreRows)
                {
                    this.rowDDOBRACUNRadnici["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                    this.rowDDOBRACUNRadnici["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                    this.rowDDOBRACUNRadnici["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                    this.rowDDOBRACUNRadnici["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                    this.rowDDOBRACUNRadnici["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                }
                reader.Close();
            }
            else
            {
                this.rowDDOBRACUNRadnici["NAZIVBANKE1"] = "";
                this.rowDDOBRACUNRadnici["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowDDOBRACUNRadnici["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowDDOBRACUNRadnici["VBDIBANKE"] = "";
                this.rowDDOBRACUNRadnici["ZRNBANKE"] = "";
            }
            if (!this.rowDDOBRACUNRadnici.IsOPCINARADAIDOPCINENull())
            {
                ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINARADANAZIVOPCINE FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINARADAIDOPCINE ", false);
                if (command5.IDbCommand.Parameters.Count == 0)
                {
                    command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
                }
                command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["OPCINARADAIDOPCINE"]));
                IDataReader reader5 = command5.FetchData();
                if (command5.HasMoreRows)
                {
                    this.rowDDOBRACUNRadnici["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader5, 0));
                }
                reader5.Close();
            }
            else
            {
                this.rowDDOBRACUNRadnici["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVKATEGORIJA], [IDKOLONAIDD] FROM [DDKATEGORIJA] WITH (NOLOCK) WHERE [IDKATEGORIJA] = @IDKATEGORIJA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["IDKATEGORIJA"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowDDOBRACUNRadnici["NAZIVKATEGORIJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                this.rowDDOBRACUNRadnici["IDKOLONAIDD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader2, 1));
            }
            reader2.Close();
        }

        private void OnDeleteControlsDdobracunradniciddkrizniporez()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVKRIZNIPOREZ], [KRIZNISTOPA], [MOKRIZNI], [POKRIZNI], [MZKRIZNI], [PZKRIZNI], [PRIMATELJKRIZNI1], [PRIMATELJKRIZNI2], [PRIMATELJKRIZNI3], [SIFRAOPISAPLACANJAKRIZNI], [OPISPLACANJAKRIZNI], [VBDIKRIZNI], [ZRNKRIZNI] FROM [KRIZNIPOREZ] WITH (NOLOCK) WHERE [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["IDKRIZNIPOREZ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowDDOBRACUNRadniciDDKrizniPorez["NAZIVKRIZNIPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowDDOBRACUNRadniciDDKrizniPorez["KRIZNISTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
                this.rowDDOBRACUNRadniciDDKrizniPorez["MOKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowDDOBRACUNRadniciDDKrizniPorez["POKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowDDOBRACUNRadniciDDKrizniPorez["MZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowDDOBRACUNRadniciDDKrizniPorez["PZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowDDOBRACUNRadniciDDKrizniPorez["PRIMATELJKRIZNI1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowDDOBRACUNRadniciDDKrizniPorez["PRIMATELJKRIZNI2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowDDOBRACUNRadniciDDKrizniPorez["PRIMATELJKRIZNI3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowDDOBRACUNRadniciDDKrizniPorez["SIFRAOPISAPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowDDOBRACUNRadniciDDKrizniPorez["OPISPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
                this.rowDDOBRACUNRadniciDDKrizniPorez["VBDIKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
                this.rowDDOBRACUNRadniciDDKrizniPorez["ZRNKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12));
            }
            reader.Close();
        }

        private void OnDeleteControlsDdobracunradnicidoprinosi()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVDOPRINOS], [IDVRSTADOPRINOS], [MODOPRINOS], [PODOPRINOS], [MZDOPRINOS], [PZDOPRINOS], [PRIMATELJDOPRINOS1], [PRIMATELJDOPRINOS2], [SIFRAOPISAPLACANJADOPRINOS], [OPISPLACANJADOPRINOS], [VBDIDOPRINOS], [ZRNDOPRINOS], [STOPA] FROM [DOPRINOS] WITH (NOLOCK) WHERE [IDDOPRINOS] = @IDDOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["IDDOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowDDOBRACUNRadniciDoprinosi["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowDDOBRACUNRadniciDoprinosi["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 1));
                this.rowDDOBRACUNRadniciDoprinosi["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowDDOBRACUNRadniciDoprinosi["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowDDOBRACUNRadniciDoprinosi["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowDDOBRACUNRadniciDoprinosi["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowDDOBRACUNRadniciDoprinosi["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowDDOBRACUNRadniciDoprinosi["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowDDOBRACUNRadniciDoprinosi["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowDDOBRACUNRadniciDoprinosi["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowDDOBRACUNRadniciDoprinosi["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
                this.rowDDOBRACUNRadniciDoprinosi["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
                this.rowDDOBRACUNRadniciDoprinosi["STOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 12));
            }
            reader.Close();
            if (!this.rowDDOBRACUNRadniciDoprinosi.IsIDVRSTADOPRINOSNull())
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVVRSTADOPRINOS] FROM [VRSTADOPRINOS] WITH (NOLOCK) WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
                }
                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["IDVRSTADOPRINOS"]));
                IDataReader reader2 = command2.FetchData();
                if (command2.HasMoreRows)
                {
                    this.rowDDOBRACUNRadniciDoprinosi["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                }
                reader2.Close();
            }
            else
            {
                this.rowDDOBRACUNRadniciDoprinosi["NAZIVVRSTADOPRINOS"] = "";
            }
        }

        private void OnDeleteControlsDdobracunradniciizdaci()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDNAZIVIZDATKA], [DDPOSTOTAKIZDATKA] FROM [DDIZDATAK] WITH (NOLOCK) WHERE [DDIDIZDATAK] = @DDIDIZDATAK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDIDIZDATAK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowDDOBRACUNRadniciIzdaci["DDNAZIVIZDATKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowDDOBRACUNRadniciIzdaci["DDPOSTOTAKIZDATKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            }
            reader.Close();
        }

        private void OnDeleteControlsDdobracunradniciporezi()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVPOREZ], [POREZMJESECNO], [STOPAPOREZA], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ] FROM [POREZ] WITH (NOLOCK) WHERE [IDPOREZ] = @IDPOREZ ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["IDPOREZ"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowDDOBRACUNRadniciPorezi["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                this.rowDDOBRACUNRadniciPorezi["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader2, 1));
                this.rowDDOBRACUNRadniciPorezi["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader2, 2));
                this.rowDDOBRACUNRadniciPorezi["MZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 3));
                this.rowDDOBRACUNRadniciPorezi["PZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 4));
                this.rowDDOBRACUNRadniciPorezi["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 5));
                this.rowDDOBRACUNRadniciPorezi["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 6));
                this.rowDDOBRACUNRadniciPorezi["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 7));
                this.rowDDOBRACUNRadniciPorezi["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 8));
            }
            reader2.Close();
            if (!this.rowDDOBRACUNRadnici.IsIDKATEGORIJANull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDPOPOREZ], [DDMOPOREZ] FROM [DDKATEGORIJALevel1] WITH (NOLOCK) WHERE [IDKATEGORIJA] = @IDKATEGORIJA AND [IDPOREZ] = @IDPOREZ ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
                }
                command.SetParameter(0, this.rowDDOBRACUNRadnici.IDKATEGORIJA);
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["IDPOREZ"]));
                IDataReader reader = command.FetchData();
                if (command.HasMoreRows)
                {
                    this.rowDDOBRACUNRadniciPorezi["DDPOPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                    this.rowDDOBRACUNRadniciPorezi["DDMOPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                }
                reader.Close();
            }
            else
            {
                this.rowDDOBRACUNRadniciPorezi["DDPOPOREZ"] = "";
                this.rowDDOBRACUNRadniciPorezi["DDMOPOREZ"] = "";
            }
        }

        private void OnDeleteControlsDdobracunradnicivrsteposla()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDNAZIVVRSTAPOSLA] FROM [DDVRSTEPOSLA] WITH (NOLOCK) WHERE [DDIDVRSTAPOSLA] = @DDIDVRSTAPOSLA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDVRSTAPOSLA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDIDVRSTAPOSLA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowDDOBRACUNRadniciVrstePosla["DDNAZIVVRSTAPOSLA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void ProcessLevelDdobracun()
        {
            this.sMode166 = this.Gx_mode;
            this.ProcessNestedLevelDdobracunradnici();
            this.Gx_mode = this.sMode166;
        }

        private void ProcessLevelDdobracunradnici()
        {
            this.sMode173 = this.Gx_mode;
            this.ProcessNestedLevelDdobracunradnicivrsteposla();
            this.ProcessNestedLevelDdobracunradniciizdaci();
            this.ProcessNestedLevelDdobracunradnicidoprinosi();
            this.ProcessNestedLevelDdobracunradniciporezi();
            this.ProcessNestedLevelDdobracunradniciddkrizniporez();
            this.Gx_mode = this.sMode173;
        }

        private void ProcessNestedLevelDdobracunradnici()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.DDOBRACUNSet.DDOBRACUNRadnici.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowDDOBRACUNRadnici = (DDOBRACUNDataSet.DDOBRACUNRadniciRow) current;
                    if (Helpers.IsRowChanged(this.rowDDOBRACUNRadnici))
                    {
                        bool flag = false;
                        if (this.rowDDOBRACUNRadnici.RowState != DataRowState.Deleted)
                        {
                            flag = string.Compare(this.rowDDOBRACUNRadnici.DDOBRACUNIDOBRACUN.TrimEnd(new char[] { ' ' }), this.rowDDOBRACUN.DDOBRACUNIDOBRACUN.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0;
                        }
                        else
                        {
                            flag = this.rowDDOBRACUNRadnici["DDOBRACUNIDOBRACUN", DataRowVersion.Original].Equals(this.rowDDOBRACUN.DDOBRACUNIDOBRACUN);
                        }
                        if (flag)
                        {
                            this.ReadRowDdobracunradnici();
                            if (this.rowDDOBRACUNRadnici.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertDdobracunradnici();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteDdobracunradnici();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateDdobracunradnici();
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

        private void ProcessNestedLevelDdobracunradniciddkrizniporez()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.DDOBRACUNSet.DDOBRACUNRadniciDDKrizniPorez.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowDDOBRACUNRadniciDDKrizniPorez = (DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow) current;
                    if (Helpers.IsRowChanged(this.rowDDOBRACUNRadniciDDKrizniPorez))
                    {
                        bool flag = false;
                        if (this.rowDDOBRACUNRadniciDDKrizniPorez.RowState != DataRowState.Deleted)
                        {
                            flag = (string.Compare(this.rowDDOBRACUNRadniciDDKrizniPorez.DDOBRACUNIDOBRACUN.TrimEnd(new char[] { ' ' }), this.rowDDOBRACUNRadnici.DDOBRACUNIDOBRACUN.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0) && (this.rowDDOBRACUNRadniciDDKrizniPorez.DDIDRADNIK == this.rowDDOBRACUNRadnici.DDIDRADNIK);
                        }
                        else
                        {
                            flag = this.rowDDOBRACUNRadniciDDKrizniPorez["DDOBRACUNIDOBRACUN", DataRowVersion.Original].Equals(this.rowDDOBRACUNRadnici.DDOBRACUNIDOBRACUN) && this.rowDDOBRACUNRadniciDDKrizniPorez["DDIDRADNIK", DataRowVersion.Original].Equals(this.rowDDOBRACUNRadnici.DDIDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowDdobracunradniciddkrizniporez();
                            if (this.rowDDOBRACUNRadniciDDKrizniPorez.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertDdobracunradniciddkrizniporez();
                            }
                            else
                            {
                                if (this._Gxremove117)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteDdobracunradniciddkrizniporez();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateDdobracunradniciddkrizniporez();
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

        private void ProcessNestedLevelDdobracunradnicidoprinosi()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.DDOBRACUNSet.DDOBRACUNRadniciDoprinosi.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowDDOBRACUNRadniciDoprinosi = (DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow) current;
                    if (Helpers.IsRowChanged(this.rowDDOBRACUNRadniciDoprinosi))
                    {
                        bool flag = false;
                        if (this.rowDDOBRACUNRadniciDoprinosi.RowState != DataRowState.Deleted)
                        {
                            flag = (string.Compare(this.rowDDOBRACUNRadniciDoprinosi.DDOBRACUNIDOBRACUN.TrimEnd(new char[] { ' ' }), this.rowDDOBRACUNRadnici.DDOBRACUNIDOBRACUN.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0) && (this.rowDDOBRACUNRadniciDoprinosi.DDIDRADNIK == this.rowDDOBRACUNRadnici.DDIDRADNIK);
                        }
                        else
                        {
                            flag = this.rowDDOBRACUNRadniciDoprinosi["DDOBRACUNIDOBRACUN", DataRowVersion.Original].Equals(this.rowDDOBRACUNRadnici.DDOBRACUNIDOBRACUN) && this.rowDDOBRACUNRadniciDoprinosi["DDIDRADNIK", DataRowVersion.Original].Equals(this.rowDDOBRACUNRadnici.DDIDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowDdobracunradnicidoprinosi();
                            if (this.rowDDOBRACUNRadniciDoprinosi.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertDdobracunradnicidoprinosi();
                            }
                            else
                            {
                                if (this._Gxremove84)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteDdobracunradnicidoprinosi();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateDdobracunradnicidoprinosi();
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

        private void ProcessNestedLevelDdobracunradniciizdaci()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.DDOBRACUNSet.DDOBRACUNRadniciIzdaci.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowDDOBRACUNRadniciIzdaci = (DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow) current;
                    if (Helpers.IsRowChanged(this.rowDDOBRACUNRadniciIzdaci))
                    {
                        bool flag = false;
                        if (this.rowDDOBRACUNRadniciIzdaci.RowState != DataRowState.Deleted)
                        {
                            flag = (string.Compare(this.rowDDOBRACUNRadniciIzdaci.DDOBRACUNIDOBRACUN.TrimEnd(new char[] { ' ' }), this.rowDDOBRACUNRadnici.DDOBRACUNIDOBRACUN.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0) && (this.rowDDOBRACUNRadniciIzdaci.DDIDRADNIK == this.rowDDOBRACUNRadnici.DDIDRADNIK);
                        }
                        else
                        {
                            flag = this.rowDDOBRACUNRadniciIzdaci["DDOBRACUNIDOBRACUN", DataRowVersion.Original].Equals(this.rowDDOBRACUNRadnici.DDOBRACUNIDOBRACUN) && this.rowDDOBRACUNRadniciIzdaci["DDIDRADNIK", DataRowVersion.Original].Equals(this.rowDDOBRACUNRadnici.DDIDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowDdobracunradniciizdaci();
                            if (this.rowDDOBRACUNRadniciIzdaci.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertDdobracunradniciizdaci();
                            }
                            else
                            {
                                if (this._Gxremove79)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteDdobracunradniciizdaci();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateDdobracunradniciizdaci();
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

        private void ProcessNestedLevelDdobracunradniciporezi()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.DDOBRACUNSet.DDOBRACUNRadniciPorezi.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowDDOBRACUNRadniciPorezi = (DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow) current;
                    if (Helpers.IsRowChanged(this.rowDDOBRACUNRadniciPorezi))
                    {
                        bool flag = false;
                        if (this.rowDDOBRACUNRadniciPorezi.RowState != DataRowState.Deleted)
                        {
                            flag = (string.Compare(this.rowDDOBRACUNRadniciPorezi.DDOBRACUNIDOBRACUN.TrimEnd(new char[] { ' ' }), this.rowDDOBRACUNRadnici.DDOBRACUNIDOBRACUN.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0) && (this.rowDDOBRACUNRadniciPorezi.DDIDRADNIK == this.rowDDOBRACUNRadnici.DDIDRADNIK);
                        }
                        else
                        {
                            flag = this.rowDDOBRACUNRadniciPorezi["DDOBRACUNIDOBRACUN", DataRowVersion.Original].Equals(this.rowDDOBRACUNRadnici.DDOBRACUNIDOBRACUN) && this.rowDDOBRACUNRadniciPorezi["DDIDRADNIK", DataRowVersion.Original].Equals(this.rowDDOBRACUNRadnici.DDIDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowDdobracunradniciporezi();
                            if (this.rowDDOBRACUNRadniciPorezi.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertDdobracunradniciporezi();
                            }
                            else
                            {
                                if (this._Gxremove102)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteDdobracunradniciporezi();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateDdobracunradniciporezi();
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

        private void ProcessNestedLevelDdobracunradnicivrsteposla()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.DDOBRACUNSet.DDOBRACUNRadniciVrstePosla.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowDDOBRACUNRadniciVrstePosla = (DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow) current;
                    if (Helpers.IsRowChanged(this.rowDDOBRACUNRadniciVrstePosla))
                    {
                        bool flag = false;
                        if (this.rowDDOBRACUNRadniciVrstePosla.RowState != DataRowState.Deleted)
                        {
                            flag = (string.Compare(this.rowDDOBRACUNRadniciVrstePosla.DDOBRACUNIDOBRACUN.TrimEnd(new char[] { ' ' }), this.rowDDOBRACUNRadnici.DDOBRACUNIDOBRACUN.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0) && (this.rowDDOBRACUNRadniciVrstePosla.DDIDRADNIK == this.rowDDOBRACUNRadnici.DDIDRADNIK);
                        }
                        else
                        {
                            flag = this.rowDDOBRACUNRadniciVrstePosla["DDOBRACUNIDOBRACUN", DataRowVersion.Original].Equals(this.rowDDOBRACUNRadnici.DDOBRACUNIDOBRACUN) && this.rowDDOBRACUNRadniciVrstePosla["DDIDRADNIK", DataRowVersion.Original].Equals(this.rowDDOBRACUNRadnici.DDIDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowDdobracunradnicivrsteposla();
                            if (this.rowDDOBRACUNRadniciVrstePosla.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertDdobracunradnicivrsteposla();
                            }
                            else
                            {
                                if (this._Gxremove73)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteDdobracunradnicivrsteposla();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateDdobracunradnicivrsteposla();
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

        private void ReadRowDdobracun()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDDOBRACUN.RowState);
            if (this.rowDDOBRACUN.RowState != DataRowState.Deleted)
            {
                this.rowDDOBRACUN["DDDATUMOBRACUNA"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDDATUMOBRACUNA"])));
            }
            if (this.rowDDOBRACUN.RowState != DataRowState.Added)
            {
                this.m__DDOPISOBRACUNOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDOPISOBRACUN", DataRowVersion.Original]);
                this.m__DDDATUMOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDDATUMOBRACUNA", DataRowVersion.Original]);
                this.m__DDZAKLJUCANOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDZAKLJUCAN", DataRowVersion.Original]);
                this.m__DDRSMOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDRSM", DataRowVersion.Original]);
            }
            else
            {
                this.m__DDOPISOBRACUNOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDOPISOBRACUN"]);
                this.m__DDDATUMOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDDATUMOBRACUNA"]);
                this.m__DDZAKLJUCANOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDZAKLJUCAN"]);
                this.m__DDRSMOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDRSM"]);
            }
            this._Gxremove = this.rowDDOBRACUN.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowDDOBRACUN = (DDOBRACUNDataSet.DDOBRACUNRow) DataSetUtil.CloneOriginalDataRow(this.rowDDOBRACUN);
            }
        }

        private void ReadRowDdobracunradnici()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDDOBRACUNRadnici.RowState);
            if (this.rowDDOBRACUNRadnici.RowState != DataRowState.Added)
            {
                this.m__DDOBRACUNATIPRIREZOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDOBRACUNATIPRIREZ", DataRowVersion.Original]);
                this.m__DDOBRACUNATIPDVOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDOBRACUNATIPDV", DataRowVersion.Original]);
                this.m__DDSIFRAOPCINESTANOVANJAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDSIFRAOPCINESTANOVANJA", DataRowVersion.Original]);
                this.m__IDKATEGORIJAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["IDKATEGORIJA", DataRowVersion.Original]);
            }
            else
            {
                this.m__DDOBRACUNATIPRIREZOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDOBRACUNATIPRIREZ"]);
                this.m__DDOBRACUNATIPDVOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDOBRACUNATIPDV"]);
                this.m__DDSIFRAOPCINESTANOVANJAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDSIFRAOPCINESTANOVANJA"]);
                this.m__IDKATEGORIJAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["IDKATEGORIJA"]);
            }
            this._Gxremove = this.rowDDOBRACUNRadnici.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowDDOBRACUNRadnici = (DDOBRACUNDataSet.DDOBRACUNRadniciRow) DataSetUtil.CloneOriginalDataRow(this.rowDDOBRACUNRadnici);
            }
        }

        private void ReadRowDdobracunradniciddkrizniporez()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDDOBRACUNRadniciDDKrizniPorez.RowState);
            if (this.rowDDOBRACUNRadniciDDKrizniPorez.RowState != DataRowState.Added)
            {
                this.m__DDOSNOVICAKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDOSNOVICAKRIZNI", DataRowVersion.Original]);
                this.m__DDPOREZKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDPOREZKRIZNI", DataRowVersion.Original]);
                this.m__DDOSNOVICAPRETHODNAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDOSNOVICAPRETHODNA", DataRowVersion.Original]);
                this.m__DDOSNOVICAUKUPNAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDOSNOVICAUKUPNA", DataRowVersion.Original]);
                this.m__DDPOREZPRETHODNIOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDPOREZPRETHODNI", DataRowVersion.Original]);
                this.m__DDPOREZUKUPNOOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDPOREZUKUPNO", DataRowVersion.Original]);
            }
            else
            {
                this.m__DDOSNOVICAKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDOSNOVICAKRIZNI"]);
                this.m__DDPOREZKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDPOREZKRIZNI"]);
                this.m__DDOSNOVICAPRETHODNAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDOSNOVICAPRETHODNA"]);
                this.m__DDOSNOVICAUKUPNAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDOSNOVICAUKUPNA"]);
                this.m__DDPOREZPRETHODNIOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDPOREZPRETHODNI"]);
                this.m__DDPOREZUKUPNOOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDPOREZUKUPNO"]);
            }
            this._Gxremove117 = this.rowDDOBRACUNRadniciDDKrizniPorez.RowState == DataRowState.Deleted;
            if (this._Gxremove117)
            {
                this.rowDDOBRACUNRadniciDDKrizniPorez = (DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow) DataSetUtil.CloneOriginalDataRow(this.rowDDOBRACUNRadniciDDKrizniPorez);
            }
        }

        private void ReadRowDdobracunradnicidoprinosi()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDDOBRACUNRadniciDoprinosi.RowState);
            if (this.rowDDOBRACUNRadniciDoprinosi.RowState != DataRowState.Added)
            {
                this.m__DDOBRACUNATIDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["DDOBRACUNATIDOPRINOS", DataRowVersion.Original]);
                this.m__DDOSNOVICADOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["DDOSNOVICADOPRINOS", DataRowVersion.Original]);
            }
            else
            {
                this.m__DDOBRACUNATIDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["DDOBRACUNATIDOPRINOS"]);
                this.m__DDOSNOVICADOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["DDOSNOVICADOPRINOS"]);
            }
            this._Gxremove84 = this.rowDDOBRACUNRadniciDoprinosi.RowState == DataRowState.Deleted;
            if (this._Gxremove84)
            {
                this.rowDDOBRACUNRadniciDoprinosi = (DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow) DataSetUtil.CloneOriginalDataRow(this.rowDDOBRACUNRadniciDoprinosi);
            }
        }

        private void ReadRowDdobracunradniciizdaci()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDDOBRACUNRadniciIzdaci.RowState);
            if (this.rowDDOBRACUNRadniciIzdaci.RowState != DataRowState.Added)
            {
                this.m__DDOBRACUNATIIZDATAKOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDOBRACUNATIIZDATAK", DataRowVersion.Original]);
            }
            else
            {
                this.m__DDOBRACUNATIIZDATAKOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDOBRACUNATIIZDATAK"]);
            }
            this._Gxremove79 = this.rowDDOBRACUNRadniciIzdaci.RowState == DataRowState.Deleted;
            if (this._Gxremove79)
            {
                this.rowDDOBRACUNRadniciIzdaci = (DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow) DataSetUtil.CloneOriginalDataRow(this.rowDDOBRACUNRadniciIzdaci);
            }
        }

        private void ReadRowDdobracunradniciporezi()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDDOBRACUNRadniciPorezi.RowState);
            if (this.rowDDOBRACUNRadniciPorezi.RowState != DataRowState.Added)
            {
                this.m__DDOBRACUNATIPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDOBRACUNATIPOREZ", DataRowVersion.Original]);
                this.m__DDOSNOVICAPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDOSNOVICAPOREZ", DataRowVersion.Original]);
            }
            else
            {
                this.m__DDOBRACUNATIPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDOBRACUNATIPOREZ"]);
                this.m__DDOSNOVICAPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDOSNOVICAPOREZ"]);
            }
            this._Gxremove102 = this.rowDDOBRACUNRadniciPorezi.RowState == DataRowState.Deleted;
            if (this._Gxremove102)
            {
                this.rowDDOBRACUNRadniciPorezi = (DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow) DataSetUtil.CloneOriginalDataRow(this.rowDDOBRACUNRadniciPorezi);
            }
        }

        private void ReadRowDdobracunradnicivrsteposla()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDDOBRACUNRadniciVrstePosla.RowState);
            if (this.rowDDOBRACUNRadniciVrstePosla.RowState != DataRowState.Added)
            {
                this.m__DDSATIOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDSATI", DataRowVersion.Original]);
                this.m__DDSATNICAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDSATNICA", DataRowVersion.Original]);
                this.m__DDIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDIZNOS", DataRowVersion.Original]);
            }
            else
            {
                this.m__DDSATIOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDSATI"]);
                this.m__DDSATNICAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDSATNICA"]);
                this.m__DDIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDIZNOS"]);
            }
            this._Gxremove73 = this.rowDDOBRACUNRadniciVrstePosla.RowState == DataRowState.Deleted;
            if (this._Gxremove73)
            {
                this.rowDDOBRACUNRadniciVrstePosla = (DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow) DataSetUtil.CloneOriginalDataRow(this.rowDDOBRACUNRadniciVrstePosla);
            }
        }

        private void ScanByDDOBRACUNIDOBRACUN(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString166 + "  FROM [DDOBRACUN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[DDOBRACUNIDOBRACUN]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString166, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[DDOBRACUNIDOBRACUN] ) AS DK_PAGENUM   FROM [DDOBRACUN] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString166 + " FROM [DDOBRACUN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[DDOBRACUNIDOBRACUN] ";
            }
            this.cmDDOBRACUNSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmDDOBRACUNSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDOBRACUNSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
            }
            this.cmDDOBRACUNSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDOBRACUNIDOBRACUN"]));
            this.DDOBRACUNSelect4 = this.cmDDOBRACUNSelect4.FetchData();
            this.RcdFound166 = 0;
            this.ScanLoadDdobracun();
            this.LoadDataDdobracun(maxRows);
            if (this.RcdFound166 > 0)
            {
                this.SubLvlScanStartDdobracunradnici(this.m_WhereString, startRow, maxRows);
                this.SetParametersDDOBRACUNIDOBRACUNDdobracun(this.cmDDOBRACUNRadniciSelect2);
                this.SubLvlFetchDdobracunradnici();
                this.SubLoadDataDdobracunradnici();
                this.SubLvlScanStartDdobracunradnicivrsteposla(this.m_WhereString, startRow, maxRows);
                this.SetParametersDDOBRACUNIDOBRACUNDdobracun(this.cmDDOBRACUNRadniciVrstePoslaSelect2);
                this.SubLvlFetchDdobracunradnicivrsteposla();
                this.SubLoadDataDdobracunradnicivrsteposla();
                this.SubLvlScanStartDdobracunradniciizdaci(this.m_WhereString, startRow, maxRows);
                this.SetParametersDDOBRACUNIDOBRACUNDdobracun(this.cmDDOBRACUNRadniciIzdaciSelect2);
                this.SubLvlFetchDdobracunradniciizdaci();
                this.SubLoadDataDdobracunradniciizdaci();
                this.SubLvlScanStartDdobracunradnicidoprinosi(this.m_WhereString, startRow, maxRows);
                this.SetParametersDDOBRACUNIDOBRACUNDdobracun(this.cmDDOBRACUNRadniciDoprinosiSelect2);
                this.SubLvlFetchDdobracunradnicidoprinosi();
                this.SubLoadDataDdobracunradnicidoprinosi();
                this.SubLvlScanStartDdobracunradniciporezi(this.m_WhereString, startRow, maxRows);
                this.SetParametersDDOBRACUNIDOBRACUNDdobracun(this.cmDDOBRACUNRadniciPoreziSelect2);
                this.SubLvlFetchDdobracunradniciporezi();
                this.SubLoadDataDdobracunradniciporezi();
                this.SubLvlScanStartDdobracunradniciddkrizniporez(this.m_WhereString, startRow, maxRows);
                this.SetParametersDDOBRACUNIDOBRACUNDdobracun(this.cmDDOBRACUNRadniciDDKrizniPorezSelect2);
                this.SubLvlFetchDdobracunradniciddkrizniporez();
                this.SubLoadDataDdobracunradniciddkrizniporez();
            }
        }

        private void ScanEndDdobracun()
        {
            this.DDOBRACUNSelect4.Close();
        }

        private void ScanEndDdobracunradnici()
        {
            this.DDOBRACUNRadniciSelect2.Close();
        }

        private void ScanEndDdobracunradniciddkrizniporez()
        {
            this.DDOBRACUNRadniciDDKrizniPorezSelect2.Close();
        }

        private void ScanEndDdobracunradnicidoprinosi()
        {
            this.DDOBRACUNRadniciDoprinosiSelect2.Close();
        }

        private void ScanEndDdobracunradniciizdaci()
        {
            this.DDOBRACUNRadniciIzdaciSelect2.Close();
        }

        private void ScanEndDdobracunradniciporezi()
        {
            this.DDOBRACUNRadniciPoreziSelect2.Close();
        }

        private void ScanEndDdobracunradnicivrsteposla()
        {
            this.DDOBRACUNRadniciVrstePoslaSelect2.Close();
        }

        private void ScanLoadDdobracun()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDDOBRACUNSelect4.HasMoreRows)
            {
                this.RcdFound166 = 1;
                this.rowDDOBRACUN["DDOBRACUNIDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNSelect4, 0));
                this.rowDDOBRACUN["DDOPISOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNSelect4, 1));
                this.rowDDOBRACUN["DDDATUMOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.DDOBRACUNSelect4, 2));
                this.rowDDOBRACUN["DDZAKLJUCAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.DDOBRACUNSelect4, 3));
                this.rowDDOBRACUN["DDRSM"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNSelect4, 4));
            }
        }

        private void ScanLoadDdobracunradnici()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDDOBRACUNRadniciSelect2.HasMoreRows)
            {
                this.RcdFound173 = 1;
                this.rowDDOBRACUNRadnici["DDOBRACUNIDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 0));
                this.rowDDOBRACUNRadnici["DDPREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 1));
                this.rowDDOBRACUNRadnici["DDIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 2));
                this.rowDDOBRACUNRadnici["NAZIVKATEGORIJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 3));
                this.rowDDOBRACUNRadnici["DDOBRACUNATIPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciSelect2, 4));
                this.rowDDOBRACUNRadnici["DDOBRACUNATIPDV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciSelect2, 5));
                this.rowDDOBRACUNRadnici["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 6));
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 7));
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 8));
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciSelect2, 9));
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 10));
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 11));
                this.rowDDOBRACUNRadnici["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 12));
                this.rowDDOBRACUNRadnici["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 13));
                this.rowDDOBRACUNRadnici["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 14));
                this.rowDDOBRACUNRadnici["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 15));
                this.rowDDOBRACUNRadnici["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 0x10));
                this.rowDDOBRACUNRadnici["DDPDVOBVEZNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.DDOBRACUNRadniciSelect2, 0x11));
                this.rowDDOBRACUNRadnici["DDDRUGISTUP"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.DDOBRACUNRadniciSelect2, 0x12));
                this.rowDDOBRACUNRadnici["DDSIFRAOPCINESTANOVANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 0x13));
                this.rowDDOBRACUNRadnici["IDKOLONAIDD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDOBRACUNRadniciSelect2, 20));
                this.rowDDOBRACUNRadnici["DDOIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 0x15));
                this.rowDDOBRACUNRadnici["DDZRN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 0x16));
                this.rowDDOBRACUNRadnici["DDIDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDOBRACUNRadniciSelect2, 0x17));
                this.rowDDOBRACUNRadnici["IDBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDOBRACUNRadniciSelect2, 0x18));
                this.rowDDOBRACUNRadnici["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 0x19));
                this.rowDDOBRACUNRadnici["IDKATEGORIJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDOBRACUNRadniciSelect2, 0x1a));
                this.rowDDOBRACUNRadnici["DDPREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 1));
                this.rowDDOBRACUNRadnici["DDIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 2));
                this.rowDDOBRACUNRadnici["DDPDVOBVEZNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.DDOBRACUNRadniciSelect2, 0x11));
                this.rowDDOBRACUNRadnici["DDDRUGISTUP"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.DDOBRACUNRadniciSelect2, 0x12));
                this.rowDDOBRACUNRadnici["DDOIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 0x15));
                this.rowDDOBRACUNRadnici["DDZRN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 0x16));
                this.rowDDOBRACUNRadnici["IDBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDOBRACUNRadniciSelect2, 0x18));
                this.rowDDOBRACUNRadnici["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 0x19));
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 8));
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciSelect2, 9));
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 10));
                this.rowDDOBRACUNRadnici["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 11));
                this.rowDDOBRACUNRadnici["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 12));
                this.rowDDOBRACUNRadnici["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 13));
                this.rowDDOBRACUNRadnici["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 14));
                this.rowDDOBRACUNRadnici["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 15));
                this.rowDDOBRACUNRadnici["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 0x10));
                this.rowDDOBRACUNRadnici["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 6));
                this.rowDDOBRACUNRadnici["NAZIVKATEGORIJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciSelect2, 3));
            }
        }

        private void ScanLoadDdobracunradniciddkrizniporez()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDDOBRACUNRadniciDDKrizniPorezSelect2.HasMoreRows)
            {
                this.RcdFound178 = 1;
                this.rowDDOBRACUNRadniciDDKrizniPorez["DDOBRACUNIDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 0));
                this.rowDDOBRACUNRadniciDDKrizniPorez["DDIDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 1));
                this.rowDDOBRACUNRadniciDDKrizniPorez["NAZIVKRIZNIPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 2));
                this.rowDDOBRACUNRadniciDDKrizniPorez["KRIZNISTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 3));
                this.rowDDOBRACUNRadniciDDKrizniPorez["MOKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 4));
                this.rowDDOBRACUNRadniciDDKrizniPorez["POKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 5));
                this.rowDDOBRACUNRadniciDDKrizniPorez["MZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 6));
                this.rowDDOBRACUNRadniciDDKrizniPorez["PZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 7));
                this.rowDDOBRACUNRadniciDDKrizniPorez["PRIMATELJKRIZNI1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 8));
                this.rowDDOBRACUNRadniciDDKrizniPorez["PRIMATELJKRIZNI2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 9));
                this.rowDDOBRACUNRadniciDDKrizniPorez["PRIMATELJKRIZNI3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 10));
                this.rowDDOBRACUNRadniciDDKrizniPorez["SIFRAOPISAPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 11));
                this.rowDDOBRACUNRadniciDDKrizniPorez["OPISPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 12));
                this.rowDDOBRACUNRadniciDDKrizniPorez["VBDIKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 13));
                this.rowDDOBRACUNRadniciDDKrizniPorez["ZRNKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 14));
                this.rowDDOBRACUNRadniciDDKrizniPorez["DDOSNOVICAKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 15));
                this.rowDDOBRACUNRadniciDDKrizniPorez["DDPOREZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 0x10));
                this.rowDDOBRACUNRadniciDDKrizniPorez["DDOSNOVICAPRETHODNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 0x11));
                this.rowDDOBRACUNRadniciDDKrizniPorez["DDOSNOVICAUKUPNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 0x12));
                this.rowDDOBRACUNRadniciDDKrizniPorez["DDPOREZPRETHODNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 0x13));
                this.rowDDOBRACUNRadniciDDKrizniPorez["DDPOREZUKUPNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 20));
                this.rowDDOBRACUNRadniciDDKrizniPorez["IDKRIZNIPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDOBRACUNRadniciDDKrizniPorezSelect2, 0x15));
            }
        }

        private void ScanLoadDdobracunradnicidoprinosi()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDDOBRACUNRadniciDoprinosiSelect2.HasMoreRows)
            {
                this.RcdFound176 = 1;
                this.rowDDOBRACUNRadniciDoprinosi["DDOBRACUNIDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDoprinosiSelect2, 0));
                this.rowDDOBRACUNRadniciDoprinosi["DDIDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDOBRACUNRadniciDoprinosiSelect2, 1));
                this.rowDDOBRACUNRadniciDoprinosi["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDoprinosiSelect2, 2));
                this.rowDDOBRACUNRadniciDoprinosi["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDOBRACUNRadniciDoprinosiSelect2, 3));
                this.rowDDOBRACUNRadniciDoprinosi["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDoprinosiSelect2, 4));
                this.rowDDOBRACUNRadniciDoprinosi["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDoprinosiSelect2, 5));
                this.rowDDOBRACUNRadniciDoprinosi["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDoprinosiSelect2, 6));
                this.rowDDOBRACUNRadniciDoprinosi["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDoprinosiSelect2, 7));
                this.rowDDOBRACUNRadniciDoprinosi["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDoprinosiSelect2, 8));
                this.rowDDOBRACUNRadniciDoprinosi["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDoprinosiSelect2, 9));
                this.rowDDOBRACUNRadniciDoprinosi["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDoprinosiSelect2, 10));
                this.rowDDOBRACUNRadniciDoprinosi["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDoprinosiSelect2, 11));
                this.rowDDOBRACUNRadniciDoprinosi["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDoprinosiSelect2, 12));
                this.rowDDOBRACUNRadniciDoprinosi["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDoprinosiSelect2, 13));
                this.rowDDOBRACUNRadniciDoprinosi["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciDoprinosiSelect2, 14));
                this.rowDDOBRACUNRadniciDoprinosi["STOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciDoprinosiSelect2, 15));
                this.rowDDOBRACUNRadniciDoprinosi["DDOBRACUNATIDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciDoprinosiSelect2, 0x10));
                this.rowDDOBRACUNRadniciDoprinosi["DDOSNOVICADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciDoprinosiSelect2, 0x11));
                this.rowDDOBRACUNRadniciDoprinosi["IDDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDOBRACUNRadniciDoprinosiSelect2, 0x12));
            }
        }

        private void ScanLoadDdobracunradniciizdaci()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDDOBRACUNRadniciIzdaciSelect2.HasMoreRows)
            {
                this.RcdFound175 = 1;
                this.rowDDOBRACUNRadniciIzdaci["DDOBRACUNIDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciIzdaciSelect2, 0));
                this.rowDDOBRACUNRadniciIzdaci["DDIDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDOBRACUNRadniciIzdaciSelect2, 1));
                this.rowDDOBRACUNRadniciIzdaci["DDNAZIVIZDATKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciIzdaciSelect2, 2));
                this.rowDDOBRACUNRadniciIzdaci["DDPOSTOTAKIZDATKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciIzdaciSelect2, 3));
                this.rowDDOBRACUNRadniciIzdaci["DDOBRACUNATIIZDATAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciIzdaciSelect2, 4));
                this.rowDDOBRACUNRadniciIzdaci["DDIDIZDATAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDOBRACUNRadniciIzdaciSelect2, 5));
            }
        }

        private void ScanLoadDdobracunradniciporezi()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDDOBRACUNRadniciPoreziSelect2.HasMoreRows)
            {
                this.RcdFound177 = 1;
                this.rowDDOBRACUNRadniciPorezi["DDOBRACUNIDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciPoreziSelect2, 0));
                this.rowDDOBRACUNRadniciPorezi["DDIDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDOBRACUNRadniciPoreziSelect2, 1));
                this.rowDDOBRACUNRadniciPorezi["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciPoreziSelect2, 2));
                this.rowDDOBRACUNRadniciPorezi["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciPoreziSelect2, 3));
                this.rowDDOBRACUNRadniciPorezi["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciPoreziSelect2, 4));
                this.rowDDOBRACUNRadniciPorezi["DDPOPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciPoreziSelect2, 5));
                this.rowDDOBRACUNRadniciPorezi["DDMOPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciPoreziSelect2, 6));
                this.rowDDOBRACUNRadniciPorezi["MZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciPoreziSelect2, 7));
                this.rowDDOBRACUNRadniciPorezi["PZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciPoreziSelect2, 8));
                this.rowDDOBRACUNRadniciPorezi["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciPoreziSelect2, 9));
                this.rowDDOBRACUNRadniciPorezi["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciPoreziSelect2, 10));
                this.rowDDOBRACUNRadniciPorezi["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciPoreziSelect2, 11));
                this.rowDDOBRACUNRadniciPorezi["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciPoreziSelect2, 12));
                this.rowDDOBRACUNRadniciPorezi["DDOBRACUNATIPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciPoreziSelect2, 13));
                this.rowDDOBRACUNRadniciPorezi["DDOSNOVICAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciPoreziSelect2, 14));
                this.rowDDOBRACUNRadniciPorezi["IDPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDOBRACUNRadniciPoreziSelect2, 15));
                this.rowDDOBRACUNRadniciPorezi["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciPoreziSelect2, 3));
            }
        }

        private void ScanLoadDdobracunradnicivrsteposla()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDDOBRACUNRadniciVrstePoslaSelect2.HasMoreRows)
            {
                this.RcdFound174 = 1;
                this.rowDDOBRACUNRadniciVrstePosla["DDOBRACUNIDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciVrstePoslaSelect2, 0));
                this.rowDDOBRACUNRadniciVrstePosla["DDIDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDOBRACUNRadniciVrstePoslaSelect2, 1));
                this.rowDDOBRACUNRadniciVrstePosla["DDNAZIVVRSTAPOSLA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDOBRACUNRadniciVrstePoslaSelect2, 2));
                this.rowDDOBRACUNRadniciVrstePosla["DDSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciVrstePoslaSelect2, 3));
                this.rowDDOBRACUNRadniciVrstePosla["DDSATNICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciVrstePoslaSelect2, 4));
                this.rowDDOBRACUNRadniciVrstePosla["DDIZNOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDOBRACUNRadniciVrstePoslaSelect2, 5));
                this.rowDDOBRACUNRadniciVrstePosla["DDIDVRSTAPOSLA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDOBRACUNRadniciVrstePoslaSelect2, 6));
            }
        }

        private void ScanNextDdobracun()
        {
            this.cmDDOBRACUNSelect4.HasMoreRows = this.DDOBRACUNSelect4.Read();
            this.RcdFound166 = 0;
            this.ScanLoadDdobracun();
        }

        private void ScanNextDdobracunradnici()
        {
            this.cmDDOBRACUNRadniciSelect2.HasMoreRows = this.DDOBRACUNRadniciSelect2.Read();
            this.RcdFound173 = 0;
            this.ScanLoadDdobracunradnici();
        }

        private void ScanNextDdobracunradniciddkrizniporez()
        {
            this.cmDDOBRACUNRadniciDDKrizniPorezSelect2.HasMoreRows = this.DDOBRACUNRadniciDDKrizniPorezSelect2.Read();
            this.RcdFound178 = 0;
            this.ScanLoadDdobracunradniciddkrizniporez();
        }

        private void ScanNextDdobracunradnicidoprinosi()
        {
            this.cmDDOBRACUNRadniciDoprinosiSelect2.HasMoreRows = this.DDOBRACUNRadniciDoprinosiSelect2.Read();
            this.RcdFound176 = 0;
            this.ScanLoadDdobracunradnicidoprinosi();
        }

        private void ScanNextDdobracunradniciizdaci()
        {
            this.cmDDOBRACUNRadniciIzdaciSelect2.HasMoreRows = this.DDOBRACUNRadniciIzdaciSelect2.Read();
            this.RcdFound175 = 0;
            this.ScanLoadDdobracunradniciizdaci();
        }

        private void ScanNextDdobracunradniciporezi()
        {
            this.cmDDOBRACUNRadniciPoreziSelect2.HasMoreRows = this.DDOBRACUNRadniciPoreziSelect2.Read();
            this.RcdFound177 = 0;
            this.ScanLoadDdobracunradniciporezi();
        }

        private void ScanNextDdobracunradnicivrsteposla()
        {
            this.cmDDOBRACUNRadniciVrstePoslaSelect2.HasMoreRows = this.DDOBRACUNRadniciVrstePoslaSelect2.Read();
            this.RcdFound174 = 0;
            this.ScanLoadDdobracunradnicivrsteposla();
        }

        private void ScanStartDdobracun(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString166 + "  FROM [DDOBRACUN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[DDOBRACUNIDOBRACUN]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString166, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[DDOBRACUNIDOBRACUN] ) AS DK_PAGENUM   FROM [DDOBRACUN] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString166 + " FROM [DDOBRACUN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[DDOBRACUNIDOBRACUN] ";
            }
            this.cmDDOBRACUNSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.DDOBRACUNSelect4 = this.cmDDOBRACUNSelect4.FetchData();
            this.RcdFound166 = 0;
            this.ScanLoadDdobracun();
            this.LoadDataDdobracun(maxRows);
            if (this.RcdFound166 > 0)
            {
                this.SubLvlScanStartDdobracunradnici(this.m_WhereString, startRow, maxRows);
                this.SetParametersDdobracunDdobracun(this.cmDDOBRACUNRadniciSelect2);
                this.SubLvlFetchDdobracunradnici();
                this.SubLoadDataDdobracunradnici();
                this.SubLvlScanStartDdobracunradnicivrsteposla(this.m_WhereString, startRow, maxRows);
                this.SetParametersDdobracunDdobracun(this.cmDDOBRACUNRadniciVrstePoslaSelect2);
                this.SubLvlFetchDdobracunradnicivrsteposla();
                this.SubLoadDataDdobracunradnicivrsteposla();
                this.SubLvlScanStartDdobracunradniciizdaci(this.m_WhereString, startRow, maxRows);
                this.SetParametersDdobracunDdobracun(this.cmDDOBRACUNRadniciIzdaciSelect2);
                this.SubLvlFetchDdobracunradniciizdaci();
                this.SubLoadDataDdobracunradniciizdaci();
                this.SubLvlScanStartDdobracunradnicidoprinosi(this.m_WhereString, startRow, maxRows);
                this.SetParametersDdobracunDdobracun(this.cmDDOBRACUNRadniciDoprinosiSelect2);
                this.SubLvlFetchDdobracunradnicidoprinosi();
                this.SubLoadDataDdobracunradnicidoprinosi();
                this.SubLvlScanStartDdobracunradniciporezi(this.m_WhereString, startRow, maxRows);
                this.SetParametersDdobracunDdobracun(this.cmDDOBRACUNRadniciPoreziSelect2);
                this.SubLvlFetchDdobracunradniciporezi();
                this.SubLoadDataDdobracunradniciporezi();
                this.SubLvlScanStartDdobracunradniciddkrizniporez(this.m_WhereString, startRow, maxRows);
                this.SetParametersDdobracunDdobracun(this.cmDDOBRACUNRadniciDDKrizniPorezSelect2);
                this.SubLvlFetchDdobracunradniciddkrizniporez();
                this.SubLoadDataDdobracunradniciddkrizniporez();
            }
        }

        private void ScanStartDdobracunradnici()
        {
            this.cmDDOBRACUNRadniciSelect2 = this.connDefault.GetCommand("SELECT T1.[DDOBRACUNIDOBRACUN], T2.[DDPREZIME], T2.[DDIME], T6.[NAZIVKATEGORIJA], T1.[DDOBRACUNATIPRIREZ], T1.[DDOBRACUNATIPDV], T5.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, T3.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T3.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T3.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T3.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T4.[NAZIVBANKE1], T4.[NAZIVBANKE2], T4.[NAZIVBANKE3], T4.[VBDIBANKE], T4.[ZRNBANKE], T2.[DDPDVOBVEZNIK], T2.[DDDRUGISTUP], T1.[DDSIFRAOPCINESTANOVANJA], T1.[IDKOLONAIDD], T2.[DDOIB], T2.[DDZRN], T1.[DDIDRADNIK], T2.[IDBANKE], T2.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, T1.[IDKATEGORIJA] FROM ((((([DDOBRACUNRadnici] T1 WITH (NOLOCK) INNER JOIN [DDRADNIK] T2 WITH (NOLOCK) ON T2.[DDIDRADNIK] = T1.[DDIDRADNIK]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = T2.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [BANKE] T4 WITH (NOLOCK) ON T4.[IDBANKE] = T2.[IDBANKE]) INNER JOIN [OPCINA] T5 WITH (NOLOCK) ON T5.[IDOPCINE] = T2.[OPCINARADAIDOPCINE]) INNER JOIN [DDKATEGORIJA] T6 WITH (NOLOCK) ON T6.[IDKATEGORIJA] = T1.[IDKATEGORIJA]) WHERE T1.[DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK] ", false);
            if (this.cmDDOBRACUNRadniciSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDOBRACUNRadniciSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
            }
            this.cmDDOBRACUNRadniciSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDOBRACUNIDOBRACUN"]));
            this.DDOBRACUNRadniciSelect2 = this.cmDDOBRACUNRadniciSelect2.FetchData();
            this.RcdFound173 = 0;
            this.ScanLoadDdobracunradnici();
        }

        private void ScanStartDdobracunradniciddkrizniporez()
        {
            this.cmDDOBRACUNRadniciDDKrizniPorezSelect2 = this.connDefault.GetCommand("SELECT [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [NAZIVKRIZNIPOREZ], [KRIZNISTOPA], [MOKRIZNI], [POKRIZNI], [MZKRIZNI], [PZKRIZNI], [PRIMATELJKRIZNI1], [PRIMATELJKRIZNI2], [PRIMATELJKRIZNI3], [SIFRAOPISAPLACANJAKRIZNI], [OPISPLACANJAKRIZNI], [VBDIKRIZNI], [ZRNKRIZNI], [DDOSNOVICAKRIZNI], [DDPOREZKRIZNI], [DDOSNOVICAPRETHODNA], [DDOSNOVICAUKUPNA], [DDPOREZPRETHODNI], [DDPOREZUKUPNO], [IDKRIZNIPOREZ] FROM [DDOBRACUNRadniciDDKrizniPorez] WITH (NOLOCK) WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN and [DDIDRADNIK] = @DDIDRADNIK ORDER BY [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [IDKRIZNIPOREZ] ", false);
            if (this.cmDDOBRACUNRadniciDDKrizniPorezSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDOBRACUNRadniciDDKrizniPorezSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                this.cmDDOBRACUNRadniciDDKrizniPorezSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
            }
            this.cmDDOBRACUNRadniciDDKrizniPorezSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDOBRACUNIDOBRACUN"]));
            this.cmDDOBRACUNRadniciDDKrizniPorezSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDIDRADNIK"]));
            this.DDOBRACUNRadniciDDKrizniPorezSelect2 = this.cmDDOBRACUNRadniciDDKrizniPorezSelect2.FetchData();
            this.RcdFound178 = 0;
            this.ScanLoadDdobracunradniciddkrizniporez();
        }

        private void ScanStartDdobracunradnicidoprinosi()
        {
            this.cmDDOBRACUNRadniciDoprinosiSelect2 = this.connDefault.GetCommand("SELECT T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[NAZIVDOPRINOS], T1.[IDVRSTADOPRINOS], T1.[NAZIVVRSTADOPRINOS], T1.[MODOPRINOS], T1.[PODOPRINOS], T1.[MZDOPRINOS], T1.[PZDOPRINOS], T1.[PRIMATELJDOPRINOS1], T1.[PRIMATELJDOPRINOS2], T1.[SIFRAOPISAPLACANJADOPRINOS], T1.[OPISPLACANJADOPRINOS], T1.[VBDIDOPRINOS], T1.[ZRNDOPRINOS], T1.[STOPA], T1.[DDOBRACUNATIDOPRINOS], T1.[DDOSNOVICADOPRINOS], T1.[IDDOPRINOS] FROM ([DDOBRACUNRadniciDoprinosi] T1 WITH (NOLOCK) INNER JOIN [DOPRINOS] T2 WITH (NOLOCK) ON T2.[IDDOPRINOS] = T1.[IDDOPRINOS]) WHERE T1.[DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN and T1.[DDIDRADNIK] = @DDIDRADNIK ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[IDDOPRINOS] ", false);
            if (this.cmDDOBRACUNRadniciDoprinosiSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDOBRACUNRadniciDoprinosiSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                this.cmDDOBRACUNRadniciDoprinosiSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
            }
            this.cmDDOBRACUNRadniciDoprinosiSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["DDOBRACUNIDOBRACUN"]));
            this.cmDDOBRACUNRadniciDoprinosiSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["DDIDRADNIK"]));
            this.DDOBRACUNRadniciDoprinosiSelect2 = this.cmDDOBRACUNRadniciDoprinosiSelect2.FetchData();
            this.RcdFound176 = 0;
            this.ScanLoadDdobracunradnicidoprinosi();
        }

        private void ScanStartDdobracunradniciizdaci()
        {
            this.cmDDOBRACUNRadniciIzdaciSelect2 = this.connDefault.GetCommand("SELECT [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [DDNAZIVIZDATKA], [DDPOSTOTAKIZDATKA], [DDOBRACUNATIIZDATAK], [DDIDIZDATAK] FROM [DDOBRACUNRadniciIzdaci] WITH (NOLOCK) WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN and [DDIDRADNIK] = @DDIDRADNIK ORDER BY [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [DDIDIZDATAK] ", false);
            if (this.cmDDOBRACUNRadniciIzdaciSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDOBRACUNRadniciIzdaciSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                this.cmDDOBRACUNRadniciIzdaciSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
            }
            this.cmDDOBRACUNRadniciIzdaciSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDOBRACUNIDOBRACUN"]));
            this.cmDDOBRACUNRadniciIzdaciSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDIDRADNIK"]));
            this.DDOBRACUNRadniciIzdaciSelect2 = this.cmDDOBRACUNRadniciIzdaciSelect2.FetchData();
            this.RcdFound175 = 0;
            this.ScanLoadDdobracunradniciizdaci();
        }

        private void ScanStartDdobracunradniciporezi()
        {
            this.cmDDOBRACUNRadniciPoreziSelect2 = this.connDefault.GetCommand("SELECT T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[NAZIVPOREZ], T2.[POREZMJESECNO], T1.[STOPAPOREZA], T1.[DDPOPOREZ], T1.[DDMOPOREZ], T1.[MZPOREZ], T1.[PZPOREZ], T1.[PRIMATELJPOREZ1], T1.[PRIMATELJPOREZ2], T1.[SIFRAOPISAPLACANJAPOREZ], T1.[OPISPLACANJAPOREZ], T1.[DDOBRACUNATIPOREZ], T1.[DDOSNOVICAPOREZ], T1.[IDPOREZ] FROM ([DDOBRACUNRadniciPorezi] T1 WITH (NOLOCK) INNER JOIN [POREZ] T2 WITH (NOLOCK) ON T2.[IDPOREZ] = T1.[IDPOREZ]) WHERE T1.[DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN and T1.[DDIDRADNIK] = @DDIDRADNIK ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[IDPOREZ] ", false);
            if (this.cmDDOBRACUNRadniciPoreziSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDOBRACUNRadniciPoreziSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                this.cmDDOBRACUNRadniciPoreziSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
            }
            this.cmDDOBRACUNRadniciPoreziSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDOBRACUNIDOBRACUN"]));
            this.cmDDOBRACUNRadniciPoreziSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDIDRADNIK"]));
            this.DDOBRACUNRadniciPoreziSelect2 = this.cmDDOBRACUNRadniciPoreziSelect2.FetchData();
            this.RcdFound177 = 0;
            this.ScanLoadDdobracunradniciporezi();
        }

        private void ScanStartDdobracunradnicivrsteposla()
        {
            this.cmDDOBRACUNRadniciVrstePoslaSelect2 = this.connDefault.GetCommand("SELECT [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [DDNAZIVVRSTAPOSLA], [DDSATI], [DDSATNICA], [DDIZNOS], [DDIDVRSTAPOSLA] FROM [DDOBRACUNRadniciVrstePosla] WITH (NOLOCK) WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN and [DDIDRADNIK] = @DDIDRADNIK ORDER BY [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [DDIDVRSTAPOSLA] ", false);
            if (this.cmDDOBRACUNRadniciVrstePoslaSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDOBRACUNRadniciVrstePoslaSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                this.cmDDOBRACUNRadniciVrstePoslaSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
            }
            this.cmDDOBRACUNRadniciVrstePoslaSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDOBRACUNIDOBRACUN"]));
            this.cmDDOBRACUNRadniciVrstePoslaSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDIDRADNIK"]));
            this.DDOBRACUNRadniciVrstePoslaSelect2 = this.cmDDOBRACUNRadniciVrstePoslaSelect2.FetchData();
            this.RcdFound174 = 0;
            this.ScanLoadDdobracunradnicivrsteposla();
        }

        private void SetParametersDdobracunDdobracun(ReadWriteCommand m_Command)
        {
        }

        private void SetParametersDDOBRACUNIDOBRACUNDdobracun(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDOBRACUNIDOBRACUN"]));
        }

        private void SkipNextDdobracunradnici()
        {
            this.cmDDOBRACUNRadniciSelect2.HasMoreRows = this.DDOBRACUNRadniciSelect2.Read();
            this.RcdFound173 = 0;
            if (this.cmDDOBRACUNRadniciSelect2.HasMoreRows)
            {
                this.RcdFound173 = 1;
            }
        }

        private void SkipNextDdobracunradniciddkrizniporez()
        {
            this.cmDDOBRACUNRadniciDDKrizniPorezSelect2.HasMoreRows = this.DDOBRACUNRadniciDDKrizniPorezSelect2.Read();
            this.RcdFound178 = 0;
            if (this.cmDDOBRACUNRadniciDDKrizniPorezSelect2.HasMoreRows)
            {
                this.RcdFound178 = 1;
            }
        }

        private void SkipNextDdobracunradnicidoprinosi()
        {
            this.cmDDOBRACUNRadniciDoprinosiSelect2.HasMoreRows = this.DDOBRACUNRadniciDoprinosiSelect2.Read();
            this.RcdFound176 = 0;
            if (this.cmDDOBRACUNRadniciDoprinosiSelect2.HasMoreRows)
            {
                this.RcdFound176 = 1;
            }
        }

        private void SkipNextDdobracunradniciizdaci()
        {
            this.cmDDOBRACUNRadniciIzdaciSelect2.HasMoreRows = this.DDOBRACUNRadniciIzdaciSelect2.Read();
            this.RcdFound175 = 0;
            if (this.cmDDOBRACUNRadniciIzdaciSelect2.HasMoreRows)
            {
                this.RcdFound175 = 1;
            }
        }

        private void SkipNextDdobracunradniciporezi()
        {
            this.cmDDOBRACUNRadniciPoreziSelect2.HasMoreRows = this.DDOBRACUNRadniciPoreziSelect2.Read();
            this.RcdFound177 = 0;
            if (this.cmDDOBRACUNRadniciPoreziSelect2.HasMoreRows)
            {
                this.RcdFound177 = 1;
            }
        }

        private void SkipNextDdobracunradnicivrsteposla()
        {
            this.cmDDOBRACUNRadniciVrstePoslaSelect2.HasMoreRows = this.DDOBRACUNRadniciVrstePoslaSelect2.Read();
            this.RcdFound174 = 0;
            if (this.cmDDOBRACUNRadniciVrstePoslaSelect2.HasMoreRows)
            {
                this.RcdFound174 = 1;
            }
        }

        private void SubLoadDataDdobracunradnici()
        {
            while (this.RcdFound173 != 0)
            {
                this.LoadRowDdobracunradnici();
                this.CreateNewRowDdobracunradnici();
                this.ScanNextDdobracunradnici();
            }
            this.ScanEndDdobracunradnici();
        }

        private void SubLoadDataDdobracunradniciddkrizniporez()
        {
            while (this.RcdFound178 != 0)
            {
                this.LoadRowDdobracunradniciddkrizniporez();
                this.CreateNewRowDdobracunradniciddkrizniporez();
                this.ScanNextDdobracunradniciddkrizniporez();
            }
            this.ScanEndDdobracunradniciddkrizniporez();
        }

        private void SubLoadDataDdobracunradnicidoprinosi()
        {
            while (this.RcdFound176 != 0)
            {
                this.LoadRowDdobracunradnicidoprinosi();
                this.CreateNewRowDdobracunradnicidoprinosi();
                this.ScanNextDdobracunradnicidoprinosi();
            }
            this.ScanEndDdobracunradnicidoprinosi();
        }

        private void SubLoadDataDdobracunradniciizdaci()
        {
            while (this.RcdFound175 != 0)
            {
                this.LoadRowDdobracunradniciizdaci();
                this.CreateNewRowDdobracunradniciizdaci();
                this.ScanNextDdobracunradniciizdaci();
            }
            this.ScanEndDdobracunradniciizdaci();
        }

        private void SubLoadDataDdobracunradniciporezi()
        {
            while (this.RcdFound177 != 0)
            {
                this.LoadRowDdobracunradniciporezi();
                this.CreateNewRowDdobracunradniciporezi();
                this.ScanNextDdobracunradniciporezi();
            }
            this.ScanEndDdobracunradniciporezi();
        }

        private void SubLoadDataDdobracunradnicivrsteposla()
        {
            while (this.RcdFound174 != 0)
            {
                this.LoadRowDdobracunradnicivrsteposla();
                this.CreateNewRowDdobracunradnicivrsteposla();
                this.ScanNextDdobracunradnicivrsteposla();
            }
            this.ScanEndDdobracunradnicivrsteposla();
        }

        private void SubLvlFetchDdobracunradnici()
        {
            this.CreateNewRowDdobracunradnici();
            this.DDOBRACUNRadniciSelect2 = this.cmDDOBRACUNRadniciSelect2.FetchData();
            this.RcdFound173 = 0;
            this.ScanLoadDdobracunradnici();
        }

        private void SubLvlFetchDdobracunradniciddkrizniporez()
        {
            this.CreateNewRowDdobracunradniciddkrizniporez();
            this.DDOBRACUNRadniciDDKrizniPorezSelect2 = this.cmDDOBRACUNRadniciDDKrizniPorezSelect2.FetchData();
            this.RcdFound178 = 0;
            this.ScanLoadDdobracunradniciddkrizniporez();
        }

        private void SubLvlFetchDdobracunradnicidoprinosi()
        {
            this.CreateNewRowDdobracunradnicidoprinosi();
            this.DDOBRACUNRadniciDoprinosiSelect2 = this.cmDDOBRACUNRadniciDoprinosiSelect2.FetchData();
            this.RcdFound176 = 0;
            this.ScanLoadDdobracunradnicidoprinosi();
        }

        private void SubLvlFetchDdobracunradniciizdaci()
        {
            this.CreateNewRowDdobracunradniciizdaci();
            this.DDOBRACUNRadniciIzdaciSelect2 = this.cmDDOBRACUNRadniciIzdaciSelect2.FetchData();
            this.RcdFound175 = 0;
            this.ScanLoadDdobracunradniciizdaci();
        }

        private void SubLvlFetchDdobracunradniciporezi()
        {
            this.CreateNewRowDdobracunradniciporezi();
            this.DDOBRACUNRadniciPoreziSelect2 = this.cmDDOBRACUNRadniciPoreziSelect2.FetchData();
            this.RcdFound177 = 0;
            this.ScanLoadDdobracunradniciporezi();
        }

        private void SubLvlFetchDdobracunradnicivrsteposla()
        {
            this.CreateNewRowDdobracunradnicivrsteposla();
            this.DDOBRACUNRadniciVrstePoslaSelect2 = this.cmDDOBRACUNRadniciVrstePoslaSelect2.FetchData();
            this.RcdFound174 = 0;
            this.ScanLoadDdobracunradnicivrsteposla();
        }

        private void SubLvlScanStartDdobracunradnici(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString173 = "(SELECT TOP " + maxRows.ToString() + " TM1.[DDOBRACUNIDOBRACUN]  FROM [DDOBRACUN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[DDOBRACUNIDOBRACUN] )";
                    this.scmdbuf = "SELECT T1.[DDOBRACUNIDOBRACUN], T3.[DDPREZIME], T3.[DDIME], T7.[NAZIVKATEGORIJA], T1.[DDOBRACUNATIPRIREZ], T1.[DDOBRACUNATIPDV], T6.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, T4.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T4.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T4.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T4.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T5.[NAZIVBANKE1], T5.[NAZIVBANKE2], T5.[NAZIVBANKE3], T5.[VBDIBANKE], T5.[ZRNBANKE], T3.[DDPDVOBVEZNIK], T3.[DDDRUGISTUP], T1.[DDSIFRAOPCINESTANOVANJA], T1.[IDKOLONAIDD], T3.[DDOIB], T3.[DDZRN], T1.[DDIDRADNIK], T3.[IDBANKE], T3.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, T1.[IDKATEGORIJA] FROM (((((([DDOBRACUNRadnici] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString173 + "  TMX ON TMX.[DDOBRACUNIDOBRACUN] = T1.[DDOBRACUNIDOBRACUN]) INNER JOIN [DDRADNIK] T3 WITH (NOLOCK) ON T3.[DDIDRADNIK] = T1.[DDIDRADNIK]) INNER JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = T3.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = T3.[IDBANKE]) INNER JOIN [OPCINA] T6 WITH (NOLOCK) ON T6.[IDOPCINE] = T3.[OPCINARADAIDOPCINE]) INNER JOIN [DDKATEGORIJA] T7 WITH (NOLOCK) ON T7.[IDKATEGORIJA] = T1.[IDKATEGORIJA]) ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[DDOBRACUNIDOBRACUN], ROW_NUMBER() OVER  (  ORDER BY TM1.[DDOBRACUNIDOBRACUN]  ) AS DK_PAGENUM   FROM [DDOBRACUN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString173 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[DDOBRACUNIDOBRACUN], T3.[DDPREZIME], T3.[DDIME], T7.[NAZIVKATEGORIJA], T1.[DDOBRACUNATIPRIREZ], T1.[DDOBRACUNATIPDV], T6.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, T4.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T4.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T4.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T4.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T5.[NAZIVBANKE1], T5.[NAZIVBANKE2], T5.[NAZIVBANKE3], T5.[VBDIBANKE], T5.[ZRNBANKE], T3.[DDPDVOBVEZNIK], T3.[DDDRUGISTUP], T1.[DDSIFRAOPCINESTANOVANJA], T1.[IDKOLONAIDD], T3.[DDOIB], T3.[DDZRN], T1.[DDIDRADNIK], T3.[IDBANKE], T3.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, T1.[IDKATEGORIJA] FROM (((((([DDOBRACUNRadnici] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString173 + "  TMX ON TMX.[DDOBRACUNIDOBRACUN] = T1.[DDOBRACUNIDOBRACUN]) INNER JOIN [DDRADNIK] T3 WITH (NOLOCK) ON T3.[DDIDRADNIK] = T1.[DDIDRADNIK]) INNER JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = T3.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = T3.[IDBANKE]) INNER JOIN [OPCINA] T6 WITH (NOLOCK) ON T6.[IDOPCINE] = T3.[OPCINARADAIDOPCINE]) INNER JOIN [DDKATEGORIJA] T7 WITH (NOLOCK) ON T7.[IDKATEGORIJA] = T1.[IDKATEGORIJA]) ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString173 = "[DDOBRACUN]";
                this.scmdbuf = "SELECT T1.[DDOBRACUNIDOBRACUN], T3.[DDPREZIME], T3.[DDIME], T7.[NAZIVKATEGORIJA], T1.[DDOBRACUNATIPRIREZ], T1.[DDOBRACUNATIPDV], T6.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, T4.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T4.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T4.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T4.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T5.[NAZIVBANKE1], T5.[NAZIVBANKE2], T5.[NAZIVBANKE3], T5.[VBDIBANKE], T5.[ZRNBANKE], T3.[DDPDVOBVEZNIK], T3.[DDDRUGISTUP], T1.[DDSIFRAOPCINESTANOVANJA], T1.[IDKOLONAIDD], T3.[DDOIB], T3.[DDZRN], T1.[DDIDRADNIK], T3.[IDBANKE], T3.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, T1.[IDKATEGORIJA] FROM (((((([DDOBRACUNRadnici] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString173 + "  TM1 WITH (NOLOCK) ON TM1.[DDOBRACUNIDOBRACUN] = T1.[DDOBRACUNIDOBRACUN]) INNER JOIN [DDRADNIK] T3 WITH (NOLOCK) ON T3.[DDIDRADNIK] = T1.[DDIDRADNIK]) INNER JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = T3.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = T3.[IDBANKE]) INNER JOIN [OPCINA] T6 WITH (NOLOCK) ON T6.[IDOPCINE] = T3.[OPCINARADAIDOPCINE]) INNER JOIN [DDKATEGORIJA] T7 WITH (NOLOCK) ON T7.[IDKATEGORIJA] = T1.[IDKATEGORIJA])" + this.m_WhereString + " ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK] ";
            }
            this.cmDDOBRACUNRadniciSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartDdobracunradniciddkrizniporez(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString178 = "(SELECT TOP " + maxRows.ToString() + " TM1.[DDOBRACUNIDOBRACUN]  FROM [DDOBRACUN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[DDOBRACUNIDOBRACUN] )";
                    this.scmdbuf = "SELECT T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[NAZIVKRIZNIPOREZ], T1.[KRIZNISTOPA], T1.[MOKRIZNI], T1.[POKRIZNI], T1.[MZKRIZNI], T1.[PZKRIZNI], T1.[PRIMATELJKRIZNI1], T1.[PRIMATELJKRIZNI2], T1.[PRIMATELJKRIZNI3], T1.[SIFRAOPISAPLACANJAKRIZNI], T1.[OPISPLACANJAKRIZNI], T1.[VBDIKRIZNI], T1.[ZRNKRIZNI], T1.[DDOSNOVICAKRIZNI], T1.[DDPOREZKRIZNI], T1.[DDOSNOVICAPRETHODNA], T1.[DDOSNOVICAUKUPNA], T1.[DDPOREZPRETHODNI], T1.[DDPOREZUKUPNO], T1.[IDKRIZNIPOREZ] FROM ([DDOBRACUNRadniciDDKrizniPorez] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString178 + "  TMX ON TMX.[DDOBRACUNIDOBRACUN] = T1.[DDOBRACUNIDOBRACUN]) ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[IDKRIZNIPOREZ]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[DDOBRACUNIDOBRACUN], ROW_NUMBER() OVER  (  ORDER BY TM1.[DDOBRACUNIDOBRACUN]  ) AS DK_PAGENUM   FROM [DDOBRACUN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString178 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[NAZIVKRIZNIPOREZ], T1.[KRIZNISTOPA], T1.[MOKRIZNI], T1.[POKRIZNI], T1.[MZKRIZNI], T1.[PZKRIZNI], T1.[PRIMATELJKRIZNI1], T1.[PRIMATELJKRIZNI2], T1.[PRIMATELJKRIZNI3], T1.[SIFRAOPISAPLACANJAKRIZNI], T1.[OPISPLACANJAKRIZNI], T1.[VBDIKRIZNI], T1.[ZRNKRIZNI], T1.[DDOSNOVICAKRIZNI], T1.[DDPOREZKRIZNI], T1.[DDOSNOVICAPRETHODNA], T1.[DDOSNOVICAUKUPNA], T1.[DDPOREZPRETHODNI], T1.[DDPOREZUKUPNO], T1.[IDKRIZNIPOREZ] FROM ([DDOBRACUNRadniciDDKrizniPorez] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString178 + "  TMX ON TMX.[DDOBRACUNIDOBRACUN] = T1.[DDOBRACUNIDOBRACUN]) ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[IDKRIZNIPOREZ]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString178 = "[DDOBRACUN]";
                this.scmdbuf = "SELECT T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[NAZIVKRIZNIPOREZ], T1.[KRIZNISTOPA], T1.[MOKRIZNI], T1.[POKRIZNI], T1.[MZKRIZNI], T1.[PZKRIZNI], T1.[PRIMATELJKRIZNI1], T1.[PRIMATELJKRIZNI2], T1.[PRIMATELJKRIZNI3], T1.[SIFRAOPISAPLACANJAKRIZNI], T1.[OPISPLACANJAKRIZNI], T1.[VBDIKRIZNI], T1.[ZRNKRIZNI], T1.[DDOSNOVICAKRIZNI], T1.[DDPOREZKRIZNI], T1.[DDOSNOVICAPRETHODNA], T1.[DDOSNOVICAUKUPNA], T1.[DDPOREZPRETHODNI], T1.[DDPOREZUKUPNO], T1.[IDKRIZNIPOREZ] FROM ([DDOBRACUNRadniciDDKrizniPorez] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString178 + "  TM1 WITH (NOLOCK) ON TM1.[DDOBRACUNIDOBRACUN] = T1.[DDOBRACUNIDOBRACUN])" + this.m_WhereString + " ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[IDKRIZNIPOREZ] ";
            }
            this.cmDDOBRACUNRadniciDDKrizniPorezSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartDdobracunradnicidoprinosi(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString176 = "(SELECT TOP " + maxRows.ToString() + " TM1.[DDOBRACUNIDOBRACUN]  FROM [DDOBRACUN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[DDOBRACUNIDOBRACUN] )";
                    this.scmdbuf = "SELECT T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[NAZIVDOPRINOS], T1.[IDVRSTADOPRINOS], T1.[NAZIVVRSTADOPRINOS], T1.[MODOPRINOS], T1.[PODOPRINOS], T1.[MZDOPRINOS], T1.[PZDOPRINOS], T1.[PRIMATELJDOPRINOS1], T1.[PRIMATELJDOPRINOS2], T1.[SIFRAOPISAPLACANJADOPRINOS], T1.[OPISPLACANJADOPRINOS], T1.[VBDIDOPRINOS], T1.[ZRNDOPRINOS], T1.[STOPA], T1.[DDOBRACUNATIDOPRINOS], T1.[DDOSNOVICADOPRINOS], T1.[IDDOPRINOS] FROM (([DDOBRACUNRadniciDoprinosi] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString176 + "  TMX ON TMX.[DDOBRACUNIDOBRACUN] = T1.[DDOBRACUNIDOBRACUN]) INNER JOIN [DOPRINOS] T3 WITH (NOLOCK) ON T3.[IDDOPRINOS] = T1.[IDDOPRINOS]) ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[IDDOPRINOS]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[DDOBRACUNIDOBRACUN], ROW_NUMBER() OVER  (  ORDER BY TM1.[DDOBRACUNIDOBRACUN]  ) AS DK_PAGENUM   FROM [DDOBRACUN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString176 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[NAZIVDOPRINOS], T1.[IDVRSTADOPRINOS], T1.[NAZIVVRSTADOPRINOS], T1.[MODOPRINOS], T1.[PODOPRINOS], T1.[MZDOPRINOS], T1.[PZDOPRINOS], T1.[PRIMATELJDOPRINOS1], T1.[PRIMATELJDOPRINOS2], T1.[SIFRAOPISAPLACANJADOPRINOS], T1.[OPISPLACANJADOPRINOS], T1.[VBDIDOPRINOS], T1.[ZRNDOPRINOS], T1.[STOPA], T1.[DDOBRACUNATIDOPRINOS], T1.[DDOSNOVICADOPRINOS], T1.[IDDOPRINOS] FROM (([DDOBRACUNRadniciDoprinosi] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString176 + "  TMX ON TMX.[DDOBRACUNIDOBRACUN] = T1.[DDOBRACUNIDOBRACUN]) INNER JOIN [DOPRINOS] T3 WITH (NOLOCK) ON T3.[IDDOPRINOS] = T1.[IDDOPRINOS]) ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[IDDOPRINOS]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString176 = "[DDOBRACUN]";
                this.scmdbuf = "SELECT T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[NAZIVDOPRINOS], T1.[IDVRSTADOPRINOS], T1.[NAZIVVRSTADOPRINOS], T1.[MODOPRINOS], T1.[PODOPRINOS], T1.[MZDOPRINOS], T1.[PZDOPRINOS], T1.[PRIMATELJDOPRINOS1], T1.[PRIMATELJDOPRINOS2], T1.[SIFRAOPISAPLACANJADOPRINOS], T1.[OPISPLACANJADOPRINOS], T1.[VBDIDOPRINOS], T1.[ZRNDOPRINOS], T1.[STOPA], T1.[DDOBRACUNATIDOPRINOS], T1.[DDOSNOVICADOPRINOS], T1.[IDDOPRINOS] FROM (([DDOBRACUNRadniciDoprinosi] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString176 + "  TM1 WITH (NOLOCK) ON TM1.[DDOBRACUNIDOBRACUN] = T1.[DDOBRACUNIDOBRACUN]) INNER JOIN [DOPRINOS] T3 WITH (NOLOCK) ON T3.[IDDOPRINOS] = T1.[IDDOPRINOS])" + this.m_WhereString + " ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[IDDOPRINOS] ";
            }
            this.cmDDOBRACUNRadniciDoprinosiSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartDdobracunradniciizdaci(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString175 = "(SELECT TOP " + maxRows.ToString() + " TM1.[DDOBRACUNIDOBRACUN]  FROM [DDOBRACUN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[DDOBRACUNIDOBRACUN] )";
                    this.scmdbuf = "SELECT T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[DDNAZIVIZDATKA], T1.[DDPOSTOTAKIZDATKA], T1.[DDOBRACUNATIIZDATAK], T1.[DDIDIZDATAK] FROM ([DDOBRACUNRadniciIzdaci] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString175 + "  TMX ON TMX.[DDOBRACUNIDOBRACUN] = T1.[DDOBRACUNIDOBRACUN]) ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[DDIDIZDATAK]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[DDOBRACUNIDOBRACUN], ROW_NUMBER() OVER  (  ORDER BY TM1.[DDOBRACUNIDOBRACUN]  ) AS DK_PAGENUM   FROM [DDOBRACUN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString175 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[DDNAZIVIZDATKA], T1.[DDPOSTOTAKIZDATKA], T1.[DDOBRACUNATIIZDATAK], T1.[DDIDIZDATAK] FROM ([DDOBRACUNRadniciIzdaci] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString175 + "  TMX ON TMX.[DDOBRACUNIDOBRACUN] = T1.[DDOBRACUNIDOBRACUN]) ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[DDIDIZDATAK]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString175 = "[DDOBRACUN]";
                this.scmdbuf = "SELECT T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[DDNAZIVIZDATKA], T1.[DDPOSTOTAKIZDATKA], T1.[DDOBRACUNATIIZDATAK], T1.[DDIDIZDATAK] FROM ([DDOBRACUNRadniciIzdaci] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString175 + "  TM1 WITH (NOLOCK) ON TM1.[DDOBRACUNIDOBRACUN] = T1.[DDOBRACUNIDOBRACUN])" + this.m_WhereString + " ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[DDIDIZDATAK] ";
            }
            this.cmDDOBRACUNRadniciIzdaciSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartDdobracunradniciporezi(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString177 = "(SELECT TOP " + maxRows.ToString() + " TM1.[DDOBRACUNIDOBRACUN]  FROM [DDOBRACUN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[DDOBRACUNIDOBRACUN] )";
                    this.scmdbuf = "SELECT T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[NAZIVPOREZ], T3.[POREZMJESECNO], T1.[STOPAPOREZA], T1.[DDPOPOREZ], T1.[DDMOPOREZ], T1.[MZPOREZ], T1.[PZPOREZ], T1.[PRIMATELJPOREZ1], T1.[PRIMATELJPOREZ2], T1.[SIFRAOPISAPLACANJAPOREZ], T1.[OPISPLACANJAPOREZ], T1.[DDOBRACUNATIPOREZ], T1.[DDOSNOVICAPOREZ], T1.[IDPOREZ] FROM (([DDOBRACUNRadniciPorezi] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString177 + "  TMX ON TMX.[DDOBRACUNIDOBRACUN] = T1.[DDOBRACUNIDOBRACUN]) INNER JOIN [POREZ] T3 WITH (NOLOCK) ON T3.[IDPOREZ] = T1.[IDPOREZ]) ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[IDPOREZ]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[DDOBRACUNIDOBRACUN], ROW_NUMBER() OVER  (  ORDER BY TM1.[DDOBRACUNIDOBRACUN]  ) AS DK_PAGENUM   FROM [DDOBRACUN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString177 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[NAZIVPOREZ], T3.[POREZMJESECNO], T1.[STOPAPOREZA], T1.[DDPOPOREZ], T1.[DDMOPOREZ], T1.[MZPOREZ], T1.[PZPOREZ], T1.[PRIMATELJPOREZ1], T1.[PRIMATELJPOREZ2], T1.[SIFRAOPISAPLACANJAPOREZ], T1.[OPISPLACANJAPOREZ], T1.[DDOBRACUNATIPOREZ], T1.[DDOSNOVICAPOREZ], T1.[IDPOREZ] FROM (([DDOBRACUNRadniciPorezi] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString177 + "  TMX ON TMX.[DDOBRACUNIDOBRACUN] = T1.[DDOBRACUNIDOBRACUN]) INNER JOIN [POREZ] T3 WITH (NOLOCK) ON T3.[IDPOREZ] = T1.[IDPOREZ]) ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[IDPOREZ]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString177 = "[DDOBRACUN]";
                this.scmdbuf = "SELECT T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[NAZIVPOREZ], T3.[POREZMJESECNO], T1.[STOPAPOREZA], T1.[DDPOPOREZ], T1.[DDMOPOREZ], T1.[MZPOREZ], T1.[PZPOREZ], T1.[PRIMATELJPOREZ1], T1.[PRIMATELJPOREZ2], T1.[SIFRAOPISAPLACANJAPOREZ], T1.[OPISPLACANJAPOREZ], T1.[DDOBRACUNATIPOREZ], T1.[DDOSNOVICAPOREZ], T1.[IDPOREZ] FROM (([DDOBRACUNRadniciPorezi] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString177 + "  TM1 WITH (NOLOCK) ON TM1.[DDOBRACUNIDOBRACUN] = T1.[DDOBRACUNIDOBRACUN]) INNER JOIN [POREZ] T3 WITH (NOLOCK) ON T3.[IDPOREZ] = T1.[IDPOREZ])" + this.m_WhereString + " ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[IDPOREZ] ";
            }
            this.cmDDOBRACUNRadniciPoreziSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartDdobracunradnicivrsteposla(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString174 = "(SELECT TOP " + maxRows.ToString() + " TM1.[DDOBRACUNIDOBRACUN]  FROM [DDOBRACUN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[DDOBRACUNIDOBRACUN] )";
                    this.scmdbuf = "SELECT T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[DDNAZIVVRSTAPOSLA], T1.[DDSATI], T1.[DDSATNICA], T1.[DDIZNOS], T1.[DDIDVRSTAPOSLA] FROM ([DDOBRACUNRadniciVrstePosla] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString174 + "  TMX ON TMX.[DDOBRACUNIDOBRACUN] = T1.[DDOBRACUNIDOBRACUN]) ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[DDIDVRSTAPOSLA]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[DDOBRACUNIDOBRACUN], ROW_NUMBER() OVER  (  ORDER BY TM1.[DDOBRACUNIDOBRACUN]  ) AS DK_PAGENUM   FROM [DDOBRACUN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString174 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[DDNAZIVVRSTAPOSLA], T1.[DDSATI], T1.[DDSATNICA], T1.[DDIZNOS], T1.[DDIDVRSTAPOSLA] FROM ([DDOBRACUNRadniciVrstePosla] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString174 + "  TMX ON TMX.[DDOBRACUNIDOBRACUN] = T1.[DDOBRACUNIDOBRACUN]) ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[DDIDVRSTAPOSLA]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString174 = "[DDOBRACUN]";
                this.scmdbuf = "SELECT T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[DDNAZIVVRSTAPOSLA], T1.[DDSATI], T1.[DDSATNICA], T1.[DDIZNOS], T1.[DDIDVRSTAPOSLA] FROM ([DDOBRACUNRadniciVrstePosla] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString174 + "  TM1 WITH (NOLOCK) ON TM1.[DDOBRACUNIDOBRACUN] = T1.[DDOBRACUNIDOBRACUN])" + this.m_WhereString + " ORDER BY T1.[DDOBRACUNIDOBRACUN], T1.[DDIDRADNIK], T1.[DDIDVRSTAPOSLA] ";
            }
            this.cmDDOBRACUNRadniciVrstePoslaSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.DDOBRACUNSet = (DDOBRACUNDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.DDOBRACUNSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.DDOBRACUNSet.DDOBRACUN.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DDOBRACUNDataSet.DDOBRACUNRow current = (DDOBRACUNDataSet.DDOBRACUNRow) enumerator.Current;
                        this.rowDDOBRACUN = current;
                        if (Helpers.IsRowChanged(this.rowDDOBRACUN))
                        {
                            this.ReadRowDdobracun();
                            if (this.rowDDOBRACUN.RowState == DataRowState.Added)
                            {
                                this.InsertDdobracun();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateDdobracun();
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

        private void UpdateDdobracun()
        {
            this.CheckOptimisticConcurrencyDdobracun();
            this.AfterConfirmDdobracun();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DDOBRACUN] SET [DDOPISOBRACUN]=@DDOPISOBRACUN, [DDDATUMOBRACUNA]=@DDDATUMOBRACUNA, [DDZAKLJUCAN]=@DDZAKLJUCAN, [DDRSM]=@DDRSM  WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOPISOBRACUN", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDDATUMOBRACUNA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDZAKLJUCAN", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDRSM", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDOPISOBRACUN"]));
            command.SetParameterDateObject(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDDATUMOBRACUNA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDZAKLJUCAN"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDRSM"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUN["DDOBRACUNIDOBRACUN"]));
            command.ExecuteStmt();
            this.OnDDOBRACUNUpdated(new DDOBRACUNEventArgs(this.rowDDOBRACUN, StatementType.Update));
            this.ProcessLevelDdobracun();
        }

        private void UpdateDdobracunradnici()
        {
            this.CheckOptimisticConcurrencyDdobracunradnici();
            this.CheckExtendedTableDdobracunradnici();
            this.AfterConfirmDdobracunradnici();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DDOBRACUNRadnici] SET [OPCINASTANOVANJAIDOPCINE]=@OPCINASTANOVANJAIDOPCINE, [IDKOLONAIDD]=@IDKOLONAIDD, [DDOBRACUNATIPRIREZ]=@DDOBRACUNATIPRIREZ, [DDOBRACUNATIPDV]=@DDOBRACUNATIPDV, [DDSIFRAOPCINESTANOVANJA]=@DDSIFRAOPCINESTANOVANJA, [IDKATEGORIJA]=@IDKATEGORIJA  WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN AND [DDIDRADNIK] = @DDIDRADNIK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNATIPRIREZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNATIPDV", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDSIFRAOPCINESTANOVANJA", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["OPCINASTANOVANJAIDOPCINE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["IDKOLONAIDD"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDOBRACUNATIPRIREZ"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDOBRACUNATIPDV"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDSIFRAOPCINESTANOVANJA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["IDKATEGORIJA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadnici["DDIDRADNIK"]));
            command.ExecuteStmt();
            this.OnDDOBRACUNRadniciUpdated(new DDOBRACUNRadniciEventArgs(this.rowDDOBRACUNRadnici, StatementType.Update));
            this.ProcessLevelDdobracunradnici();
        }

        private void UpdateDdobracunradniciddkrizniporez()
        {
            this.CheckOptimisticConcurrencyDdobracunradniciddkrizniporez();
            this.CheckExtendedTableDdobracunradniciddkrizniporez();
            this.AfterConfirmDdobracunradniciddkrizniporez();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DDOBRACUNRadniciDDKrizniPorez] SET [NAZIVKRIZNIPOREZ]=@NAZIVKRIZNIPOREZ, [KRIZNISTOPA]=@KRIZNISTOPA, [MOKRIZNI]=@MOKRIZNI, [POKRIZNI]=@POKRIZNI, [MZKRIZNI]=@MZKRIZNI, [PZKRIZNI]=@PZKRIZNI, [PRIMATELJKRIZNI1]=@PRIMATELJKRIZNI1, [PRIMATELJKRIZNI2]=@PRIMATELJKRIZNI2, [PRIMATELJKRIZNI3]=@PRIMATELJKRIZNI3, [SIFRAOPISAPLACANJAKRIZNI]=@SIFRAOPISAPLACANJAKRIZNI, [OPISPLACANJAKRIZNI]=@OPISPLACANJAKRIZNI, [VBDIKRIZNI]=@VBDIKRIZNI, [ZRNKRIZNI]=@ZRNKRIZNI, [DDOSNOVICAKRIZNI]=@DDOSNOVICAKRIZNI, [DDPOREZKRIZNI]=@DDPOREZKRIZNI, [DDOSNOVICAPRETHODNA]=@DDOSNOVICAPRETHODNA, [DDOSNOVICAUKUPNA]=@DDOSNOVICAUKUPNA, [DDPOREZPRETHODNI]=@DDPOREZPRETHODNI, [DDPOREZUKUPNO]=@DDPOREZUKUPNO  WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN AND [DDIDRADNIK] = @DDIDRADNIK AND [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ", false);
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
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAKRIZNI", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAKRIZNI", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIKRIZNI", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNKRIZNI", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOSNOVICAKRIZNI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPOREZKRIZNI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOSNOVICAPRETHODNA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOSNOVICAUKUPNA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPOREZPRETHODNI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPOREZUKUPNO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["NAZIVKRIZNIPOREZ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["KRIZNISTOPA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["MOKRIZNI"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["POKRIZNI"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["MZKRIZNI"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["PZKRIZNI"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["PRIMATELJKRIZNI1"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["PRIMATELJKRIZNI2"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["PRIMATELJKRIZNI3"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["SIFRAOPISAPLACANJAKRIZNI"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["OPISPLACANJAKRIZNI"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["VBDIKRIZNI"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["ZRNKRIZNI"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDOSNOVICAKRIZNI"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDPOREZKRIZNI"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDOSNOVICAPRETHODNA"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDOSNOVICAUKUPNA"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDPOREZPRETHODNI"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDPOREZUKUPNO"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["DDIDRADNIK"]));
            command.SetParameter(0x15, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDDKrizniPorez["IDKRIZNIPOREZ"]));
            command.ExecuteStmt();
            this.OnDDOBRACUNRadniciDDKrizniPorezUpdated(new DDOBRACUNRadniciDDKrizniPorezEventArgs(this.rowDDOBRACUNRadniciDDKrizniPorez, StatementType.Update));
        }

        private void UpdateDdobracunradnicidoprinosi()
        {
            this.CheckOptimisticConcurrencyDdobracunradnicidoprinosi();
            this.CheckExtendedTableDdobracunradnicidoprinosi();
            this.AfterConfirmDdobracunradnicidoprinosi();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DDOBRACUNRadniciDoprinosi] SET [NAZIVDOPRINOS]=@NAZIVDOPRINOS, [IDVRSTADOPRINOS]=@IDVRSTADOPRINOS, [NAZIVVRSTADOPRINOS]=@NAZIVVRSTADOPRINOS, [MODOPRINOS]=@MODOPRINOS, [PODOPRINOS]=@PODOPRINOS, [MZDOPRINOS]=@MZDOPRINOS, [PZDOPRINOS]=@PZDOPRINOS, [PRIMATELJDOPRINOS1]=@PRIMATELJDOPRINOS1, [PRIMATELJDOPRINOS2]=@PRIMATELJDOPRINOS2, [SIFRAOPISAPLACANJADOPRINOS]=@SIFRAOPISAPLACANJADOPRINOS, [OPISPLACANJADOPRINOS]=@OPISPLACANJADOPRINOS, [VBDIDOPRINOS]=@VBDIDOPRINOS, [ZRNDOPRINOS]=@ZRNDOPRINOS, [STOPA]=@STOPA, [DDOBRACUNATIDOPRINOS]=@DDOBRACUNATIDOPRINOS, [DDOSNOVICADOPRINOS]=@DDOSNOVICADOPRINOS  WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN AND [DDIDRADNIK] = @DDIDRADNIK AND [IDDOPRINOS] = @IDDOPRINOS", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVDOPRINOS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTADOPRINOS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MODOPRINOS", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PODOPRINOS", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZDOPRINOS", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZDOPRINOS", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJDOPRINOS1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJDOPRINOS2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJADOPRINOS", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJADOPRINOS", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIDOPRINOS", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNDOPRINOS", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STOPA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNATIDOPRINOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOSNOVICADOPRINOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["NAZIVDOPRINOS"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["IDVRSTADOPRINOS"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["NAZIVVRSTADOPRINOS"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["MODOPRINOS"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["PODOPRINOS"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["MZDOPRINOS"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["PZDOPRINOS"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["PRIMATELJDOPRINOS1"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["PRIMATELJDOPRINOS2"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["SIFRAOPISAPLACANJADOPRINOS"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["OPISPLACANJADOPRINOS"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["VBDIDOPRINOS"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["ZRNDOPRINOS"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["STOPA"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["DDOBRACUNATIDOPRINOS"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["DDOSNOVICADOPRINOS"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["DDIDRADNIK"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciDoprinosi["IDDOPRINOS"]));
            command.ExecuteStmt();
            this.OnDDOBRACUNRadniciDoprinosiUpdated(new DDOBRACUNRadniciDoprinosiEventArgs(this.rowDDOBRACUNRadniciDoprinosi, StatementType.Update));
        }

        private void UpdateDdobracunradniciizdaci()
        {
            this.CheckOptimisticConcurrencyDdobracunradniciizdaci();
            this.CheckExtendedTableDdobracunradniciizdaci();
            this.AfterConfirmDdobracunradniciizdaci();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DDOBRACUNRadniciIzdaci] SET [DDPOSTOTAKIZDATKA]=@DDPOSTOTAKIZDATKA, [DDNAZIVIZDATKA]=@DDNAZIVIZDATKA, [DDOBRACUNATIIZDATAK]=@DDOBRACUNATIIZDATAK  WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN AND [DDIDRADNIK] = @DDIDRADNIK AND [DDIDIZDATAK] = @DDIDIZDATAK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPOSTOTAKIZDATKA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDNAZIVIZDATKA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNATIIZDATAK", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDPOSTOTAKIZDATKA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDNAZIVIZDATKA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDOBRACUNATIIZDATAK"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDIDRADNIK"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciIzdaci["DDIDIZDATAK"]));
            command.ExecuteStmt();
            this.OnDDOBRACUNRadniciIzdaciUpdated(new DDOBRACUNRadniciIzdaciEventArgs(this.rowDDOBRACUNRadniciIzdaci, StatementType.Update));
        }

        private void UpdateDdobracunradniciporezi()
        {
            this.CheckOptimisticConcurrencyDdobracunradniciporezi();
            this.CheckExtendedTableDdobracunradniciporezi();
            this.AfterConfirmDdobracunradniciporezi();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DDOBRACUNRadniciPorezi] SET [NAZIVPOREZ]=@NAZIVPOREZ, [STOPAPOREZA]=@STOPAPOREZA, [MZPOREZ]=@MZPOREZ, [PZPOREZ]=@PZPOREZ, [PRIMATELJPOREZ1]=@PRIMATELJPOREZ1, [PRIMATELJPOREZ2]=@PRIMATELJPOREZ2, [SIFRAOPISAPLACANJAPOREZ]=@SIFRAOPISAPLACANJAPOREZ, [OPISPLACANJAPOREZ]=@OPISPLACANJAPOREZ, [DDPOPOREZ]=@DDPOPOREZ, [DDMOPOREZ]=@DDMOPOREZ, [DDOBRACUNATIPOREZ]=@DDOBRACUNATIPOREZ, [DDOSNOVICAPOREZ]=@DDOSNOVICAPOREZ  WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN AND [DDIDRADNIK] = @DDIDRADNIK AND [IDPOREZ] = @IDPOREZ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPOREZ", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STOPAPOREZA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZPOREZ", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJPOREZ1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJPOREZ2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAPOREZ", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPOPOREZ", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDMOPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNATIPOREZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOSNOVICAPOREZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["NAZIVPOREZ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["STOPAPOREZA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["MZPOREZ"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["PZPOREZ"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["PRIMATELJPOREZ1"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["PRIMATELJPOREZ2"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["SIFRAOPISAPLACANJAPOREZ"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["OPISPLACANJAPOREZ"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDPOPOREZ"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDMOPOREZ"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDOBRACUNATIPOREZ"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDOSNOVICAPOREZ"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["DDIDRADNIK"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciPorezi["IDPOREZ"]));
            command.ExecuteStmt();
            this.OnDDOBRACUNRadniciPoreziUpdated(new DDOBRACUNRadniciPoreziEventArgs(this.rowDDOBRACUNRadniciPorezi, StatementType.Update));
        }

        private void UpdateDdobracunradnicivrsteposla()
        {
            this.CheckOptimisticConcurrencyDdobracunradnicivrsteposla();
            this.CheckExtendedTableDdobracunradnicivrsteposla();
            this.AfterConfirmDdobracunradnicivrsteposla();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DDOBRACUNRadniciVrstePosla] SET [DDNAZIVVRSTAPOSLA]=@DDNAZIVVRSTAPOSLA, [DDSATI]=@DDSATI, [DDSATNICA]=@DDSATNICA, [DDIZNOS]=@DDIZNOS  WHERE [DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN AND [DDIDRADNIK] = @DDIDRADNIK AND [DDIDVRSTAPOSLA] = @DDIDVRSTAPOSLA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDNAZIVVRSTAPOSLA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDSATI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDSATNICA", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDVRSTAPOSLA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDNAZIVVRSTAPOSLA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDSATI"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDSATNICA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDIZNOS"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDOBRACUNIDOBRACUN"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDIDRADNIK"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowDDOBRACUNRadniciVrstePosla["DDIDVRSTAPOSLA"]));
            command.ExecuteStmt();
            this.OnDDOBRACUNRadniciVrstePoslaUpdated(new DDOBRACUNRadniciVrstePoslaEventArgs(this.rowDDOBRACUNRadniciVrstePosla, StatementType.Update));
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
        public class DDIZDATAKForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public DDIZDATAKForeignKeyNotFoundException()
            {
            }

            public DDIZDATAKForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected DDIZDATAKForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDIZDATAKForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDKATEGORIJAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public DDKATEGORIJAForeignKeyNotFoundException()
            {
            }

            public DDKATEGORIJAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected DDKATEGORIJAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDKATEGORIJALevel1ForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public DDKATEGORIJALevel1ForeignKeyNotFoundException()
            {
            }

            public DDKATEGORIJALevel1ForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected DDKATEGORIJALevel1ForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJALevel1ForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNDataChangedException : DataChangedException
        {
            public DDOBRACUNDataChangedException()
            {
            }

            public DDOBRACUNDataChangedException(string message) : base(message)
            {
            }

            protected DDOBRACUNDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNDataLockedException : DataLockedException
        {
            public DDOBRACUNDataLockedException()
            {
            }

            public DDOBRACUNDataLockedException(string message) : base(message)
            {
            }

            protected DDOBRACUNDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNDuplicateKeyException : DuplicateKeyException
        {
            public DDOBRACUNDuplicateKeyException()
            {
            }

            public DDOBRACUNDuplicateKeyException(string message) : base(message)
            {
            }

            protected DDOBRACUNDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DDOBRACUNEventArgs : EventArgs
        {
            private DDOBRACUNDataSet.DDOBRACUNRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public DDOBRACUNEventArgs(DDOBRACUNDataSet.DDOBRACUNRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DDOBRACUNDataSet.DDOBRACUNRow Row
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
        public class DDOBRACUNNotFoundException : DataNotFoundException
        {
            public DDOBRACUNNotFoundException()
            {
            }

            public DDOBRACUNNotFoundException(string message) : base(message)
            {
            }

            protected DDOBRACUNNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNRadniciDataChangedException : DataChangedException
        {
            public DDOBRACUNRadniciDataChangedException()
            {
            }

            public DDOBRACUNRadniciDataChangedException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNRadniciDataLockedException : DataLockedException
        {
            public DDOBRACUNRadniciDataLockedException()
            {
            }

            public DDOBRACUNRadniciDataLockedException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNRadniciDDKrizniPorezDataChangedException : DataChangedException
        {
            public DDOBRACUNRadniciDDKrizniPorezDataChangedException()
            {
            }

            public DDOBRACUNRadniciDDKrizniPorezDataChangedException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciDDKrizniPorezDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciDDKrizniPorezDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNRadniciDDKrizniPorezDataLockedException : DataLockedException
        {
            public DDOBRACUNRadniciDDKrizniPorezDataLockedException()
            {
            }

            public DDOBRACUNRadniciDDKrizniPorezDataLockedException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciDDKrizniPorezDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciDDKrizniPorezDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNRadniciDDKrizniPorezDuplicateKeyException : DuplicateKeyException
        {
            public DDOBRACUNRadniciDDKrizniPorezDuplicateKeyException()
            {
            }

            public DDOBRACUNRadniciDDKrizniPorezDuplicateKeyException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciDDKrizniPorezDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciDDKrizniPorezDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DDOBRACUNRadniciDDKrizniPorezEventArgs : EventArgs
        {
            private DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public DDOBRACUNRadniciDDKrizniPorezEventArgs(DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow Row
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

        public delegate void DDOBRACUNRadniciDDKrizniPorezUpdateEventHandler(object sender, DDOBRACUNDataAdapter.DDOBRACUNRadniciDDKrizniPorezEventArgs e);

        [Serializable]
        public class DDOBRACUNRadniciDoprinosiDataChangedException : DataChangedException
        {
            public DDOBRACUNRadniciDoprinosiDataChangedException()
            {
            }

            public DDOBRACUNRadniciDoprinosiDataChangedException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciDoprinosiDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciDoprinosiDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNRadniciDoprinosiDataLockedException : DataLockedException
        {
            public DDOBRACUNRadniciDoprinosiDataLockedException()
            {
            }

            public DDOBRACUNRadniciDoprinosiDataLockedException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciDoprinosiDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciDoprinosiDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNRadniciDoprinosiDuplicateKeyException : DuplicateKeyException
        {
            public DDOBRACUNRadniciDoprinosiDuplicateKeyException()
            {
            }

            public DDOBRACUNRadniciDoprinosiDuplicateKeyException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciDoprinosiDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciDoprinosiDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DDOBRACUNRadniciDoprinosiEventArgs : EventArgs
        {
            private DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public DDOBRACUNRadniciDoprinosiEventArgs(DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow Row
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

        public delegate void DDOBRACUNRadniciDoprinosiUpdateEventHandler(object sender, DDOBRACUNDataAdapter.DDOBRACUNRadniciDoprinosiEventArgs e);

        [Serializable]
        public class DDOBRACUNRadniciDuplicateKeyException : DuplicateKeyException
        {
            public DDOBRACUNRadniciDuplicateKeyException()
            {
            }

            public DDOBRACUNRadniciDuplicateKeyException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DDOBRACUNRadniciEventArgs : EventArgs
        {
            private DDOBRACUNDataSet.DDOBRACUNRadniciRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public DDOBRACUNRadniciEventArgs(DDOBRACUNDataSet.DDOBRACUNRadniciRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciRow Row
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
        public class DDOBRACUNRadniciIzdaciDataChangedException : DataChangedException
        {
            public DDOBRACUNRadniciIzdaciDataChangedException()
            {
            }

            public DDOBRACUNRadniciIzdaciDataChangedException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciIzdaciDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciIzdaciDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNRadniciIzdaciDataLockedException : DataLockedException
        {
            public DDOBRACUNRadniciIzdaciDataLockedException()
            {
            }

            public DDOBRACUNRadniciIzdaciDataLockedException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciIzdaciDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciIzdaciDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNRadniciIzdaciDuplicateKeyException : DuplicateKeyException
        {
            public DDOBRACUNRadniciIzdaciDuplicateKeyException()
            {
            }

            public DDOBRACUNRadniciIzdaciDuplicateKeyException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciIzdaciDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciIzdaciDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DDOBRACUNRadniciIzdaciEventArgs : EventArgs
        {
            private DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public DDOBRACUNRadniciIzdaciEventArgs(DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow Row
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

        public delegate void DDOBRACUNRadniciIzdaciUpdateEventHandler(object sender, DDOBRACUNDataAdapter.DDOBRACUNRadniciIzdaciEventArgs e);

        [Serializable]
        public class DDOBRACUNRadniciPoreziDataChangedException : DataChangedException
        {
            public DDOBRACUNRadniciPoreziDataChangedException()
            {
            }

            public DDOBRACUNRadniciPoreziDataChangedException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciPoreziDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciPoreziDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNRadniciPoreziDataLockedException : DataLockedException
        {
            public DDOBRACUNRadniciPoreziDataLockedException()
            {
            }

            public DDOBRACUNRadniciPoreziDataLockedException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciPoreziDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciPoreziDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNRadniciPoreziDuplicateKeyException : DuplicateKeyException
        {
            public DDOBRACUNRadniciPoreziDuplicateKeyException()
            {
            }

            public DDOBRACUNRadniciPoreziDuplicateKeyException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciPoreziDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciPoreziDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DDOBRACUNRadniciPoreziEventArgs : EventArgs
        {
            private DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public DDOBRACUNRadniciPoreziEventArgs(DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow Row
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

        public delegate void DDOBRACUNRadniciPoreziUpdateEventHandler(object sender, DDOBRACUNDataAdapter.DDOBRACUNRadniciPoreziEventArgs e);

        public delegate void DDOBRACUNRadniciUpdateEventHandler(object sender, DDOBRACUNDataAdapter.DDOBRACUNRadniciEventArgs e);

        [Serializable]
        public class DDOBRACUNRadniciVrstePoslaDataChangedException : DataChangedException
        {
            public DDOBRACUNRadniciVrstePoslaDataChangedException()
            {
            }

            public DDOBRACUNRadniciVrstePoslaDataChangedException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciVrstePoslaDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciVrstePoslaDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNRadniciVrstePoslaDataLockedException : DataLockedException
        {
            public DDOBRACUNRadniciVrstePoslaDataLockedException()
            {
            }

            public DDOBRACUNRadniciVrstePoslaDataLockedException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciVrstePoslaDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciVrstePoslaDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNRadniciVrstePoslaDuplicateKeyException : DuplicateKeyException
        {
            public DDOBRACUNRadniciVrstePoslaDuplicateKeyException()
            {
            }

            public DDOBRACUNRadniciVrstePoslaDuplicateKeyException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciVrstePoslaDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciVrstePoslaDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DDOBRACUNRadniciVrstePoslaEventArgs : EventArgs
        {
            private DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public DDOBRACUNRadniciVrstePoslaEventArgs(DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow Row
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

        public delegate void DDOBRACUNRadniciVrstePoslaUpdateEventHandler(object sender, DDOBRACUNDataAdapter.DDOBRACUNRadniciVrstePoslaEventArgs e);

        public delegate void DDOBRACUNUpdateEventHandler(object sender, DDOBRACUNDataAdapter.DDOBRACUNEventArgs e);

        [Serializable]
        public class DDRADNIKForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public DDRADNIKForeignKeyNotFoundException()
            {
            }

            public DDRADNIKForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected DDRADNIKForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDRADNIKForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDVRSTEPOSLAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public DDVRSTEPOSLAForeignKeyNotFoundException()
            {
            }

            public DDVRSTEPOSLAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected DDVRSTEPOSLAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDVRSTEPOSLAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
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
    }
}

