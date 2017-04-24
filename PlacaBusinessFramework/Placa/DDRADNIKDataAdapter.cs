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

    public class DDRADNIKDataAdapter : IDataAdapter, IDDRADNIKDataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private ReadWriteCommand cmDDRADNIKSelect1;
        private ReadWriteCommand cmDDRADNIKSelect2;
        private ReadWriteCommand cmDDRADNIKSelect3;
        private ReadWriteCommand cmDDRADNIKSelect4;
        private ReadWriteCommand cmDDRADNIKSelect7;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DDRADNIKSelect1;
        private IDataReader DDRADNIKSelect2;
        private IDataReader DDRADNIKSelect3;
        private IDataReader DDRADNIKSelect4;
        private IDataReader DDRADNIKSelect7;
        private DDRADNIKDataSet DDRADNIKSet;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__DDADRESAOriginal;
        private object m__DDDRUGISTUPOriginal;
        private object m__DDIMEOriginal;
        private object m__DDJMBGOriginal;
        private object m__DDKUCNIBROJOriginal;
        private object m__DDMJESTOOriginal;
        private object m__DDMOOriginal;
        private object m__DDOIBOriginal;
        private object m__DDOPISPLACANJANETOOriginal;
        private object m__DDPBOOriginal;
        private object m__DDPDVOBVEZNIKOriginal;
        private object m__DDPREZIMEOriginal;
        private object m__DDSIFRAOPISAPLACANJANETOOriginal;
        private object m__DDZBIRNINETOOriginal;
        private object m__DDZRNOriginal;

        private object m__AktivanOriginal;

        private object m__IDBANKEOriginal;
        private object m__OPCINARADAIDOPCINEOriginal;
        private object m__OPCINASTANOVANJAIDOPCINEOriginal;
        private readonly string m_SelectString141 = "TM1.[DDIDRADNIK], TM1.[DDDRUGISTUP], TM1.[DDPDVOBVEZNIK], TM1.[DDZBIRNINETO], TM1.[DDJMBG], TM1.[DDOIB], TM1.[DDPREZIME], TM1.[DDIME], TM1.[DDADRESA], TM1.[DDKUCNIBROJ], TM1.[DDMJESTO], TM1.[DDZRN], T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], T3.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T4.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T4.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T4.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T4.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, TM1.[DDSIFRAOPISAPLACANJANETO], TM1.[DDOPISPLACANJANETO], TM1.[DDMO], TM1.[DDPBO], TM1.[IDBANKE], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[Aktivan]";
        private string m_WhereString;
        private short RcdFound141;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private DDRADNIKDataSet.DDRADNIKRow rowDDRADNIK;
        private string scmdbuf;
        private StatementType sMode141;

        public event DDRADNIKUpdateEventHandler DDRADNIKUpdated;

        public event DDRADNIKUpdateEventHandler DDRADNIKUpdating;

        private void AddRowDdradnik()
        {
            this.DDRADNIKSet.DDRADNIK.AddDDRADNIKRow(this.rowDDRADNIK);
        }

        private void AfterConfirmDdradnik()
        {
            this.OnDDRADNIKUpdating(new DDRADNIKEventArgs(this.rowDDRADNIK, this.Gx_mode));
        }

        private void CheckDeleteErrorsDdradnik()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [DDOBRACUNIDOBRACUN], [DDIDRADNIK] FROM [DDOBRACUNRadnici] WITH (NOLOCK) WHERE [DDIDRADNIK] = @DDIDRADNIK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDIDRADNIK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new DDOBRACUNRadniciInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Radnici" }));
            }
            reader.Close();
        }

        private void CheckExtendedTableDdradnik()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVBANKE1], [NAZIVBANKE2], [NAZIVBANKE3], [VBDIBANKE], [ZRNBANKE] FROM [BANKE] WITH (NOLOCK) WHERE [IDBANKE] = @IDBANKE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["IDBANKE"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new BANKEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("BANKE") }));
            }
            this.rowDDRADNIK["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowDDRADNIK["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
            this.rowDDRADNIK["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
            this.rowDDRADNIK["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
            this.rowDDRADNIK["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINARADANAZIVOPCINE FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINARADAIDOPCINE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["OPCINARADAIDOPCINE"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new OPCINAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OPCINA") }));
            }
            this.rowDDRADNIK["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            reader2.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, [PRIREZ] AS OPCINASTANOVANJAPRIREZ, [VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, [ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINASTANOVANJAIDOPCINE ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["OPCINASTANOVANJAIDOPCINE"]));
            IDataReader reader3 = command3.FetchData();
            if (!command3.HasMoreRows)
            {
                reader3.Close();
                throw new OPCINAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OPCINA") }));
            }
            this.rowDDRADNIK["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0));
            this.rowDDRADNIK["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader3, 1));
            this.rowDDRADNIK["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 2));
            this.rowDDRADNIK["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 3));
            reader3.Close();
        }

        private void CheckOptimisticConcurrencyDdradnik()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDIDRADNIK], [DDDRUGISTUP], [DDPDVOBVEZNIK], [DDZBIRNINETO], [DDJMBG], [DDOIB], [DDPREZIME], [DDIME], [DDADRESA], [DDKUCNIBROJ], [DDMJESTO], [DDZRN], [DDSIFRAOPISAPLACANJANETO], [DDOPISPLACANJANETO], [DDMO], [DDPBO], [IDBANKE], [OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, [OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE FROM [DDRADNIK] WITH (UPDLOCK) WHERE [DDIDRADNIK] = @DDIDRADNIK ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDIDRADNIK"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DDRADNIKDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DDRADNIK") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !this.m__DDDRUGISTUPOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 1)))) || ((!this.m__DDPDVOBVEZNIKOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 2))) || !this.m__DDZBIRNINETOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 3)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDJMBGOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDOIBOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDPREZIMEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDIMEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDADRESAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDKUCNIBROJOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDMJESTOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDZRNOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDSIFRAOPISAPLACANJANETOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDOPISPLACANJANETOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 13))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDMOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 14)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDPBOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 15))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__IDBANKEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x10)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPCINARADAIDOPCINEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x11))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPCINASTANOVANJAIDOPCINEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x12)))))
                {
                    reader.Close();
                    throw new DDRADNIKDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DDRADNIK") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowDdradnik()
        {
            this.rowDDRADNIK = this.DDRADNIKSet.DDRADNIK.NewDDRADNIKRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDdradnik();
            this.OnDeleteControlsDdradnik();
            this.AfterConfirmDdradnik();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DDRADNIK]  WHERE [DDIDRADNIK] = @DDIDRADNIK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDIDRADNIK"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsDdradnik();
            }
            this.OnDDRADNIKUpdated(new DDRADNIKEventArgs(this.rowDDRADNIK, StatementType.Delete));
            this.rowDDRADNIK.Delete();
            this.sMode141 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode141;
        }


        public virtual int Fill(DDRADNIKDataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()));
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.DDRADNIKSet = dataSet;
                    this.LoadChildDdradnik(0, -1);
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
            this.DDRADNIKSet = (DDRADNIKDataSet) dataSet;
            if (this.DDRADNIKSet != null)
            {
                return this.Fill(this.DDRADNIKSet);
            }
            this.DDRADNIKSet = new DDRADNIKDataSet();
            this.Fill(this.DDRADNIKSet);
            dataSet.Merge(this.DDRADNIKSet);
            return 0;
        }

        public virtual int Fill(DDRADNIKDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["DDIDRADNIK"]));
        }

        public virtual int Fill(DDRADNIKDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["DDIDRADNIK"]));
        }

        public virtual int Fill(DDRADNIKDataSet dataSet, int dDIDRADNIK)
        {
            if (!this.FillByDDIDRADNIK(dataSet, dDIDRADNIK))
            {
                throw new DDRADNIKNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DDRADNIK") }));
            }
            return 0;
        }

        public virtual bool FillByDDIDRADNIK(DDRADNIKDataSet dataSet, int dDIDRADNIK)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDRADNIKSet = dataSet;
            this.rowDDRADNIK = this.DDRADNIKSet.DDRADNIK.NewDDRADNIKRow();
            this.rowDDRADNIK.DDIDRADNIK = dDIDRADNIK;
            try
            {
                this.LoadByDDIDRADNIK(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound141 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByIDBANKE(DDRADNIKDataSet dataSet, int iDBANKE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDRADNIKSet = dataSet;
            this.rowDDRADNIK = this.DDRADNIKSet.DDRADNIK.NewDDRADNIKRow();
            this.rowDDRADNIK.IDBANKE = iDBANKE;
            try
            {
                this.LoadByIDBANKE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByOPCINARADAIDOPCINE(DDRADNIKDataSet dataSet, string oPCINARADAIDOPCINE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDRADNIKSet = dataSet;
            this.rowDDRADNIK = this.DDRADNIKSet.DDRADNIK.NewDDRADNIKRow();
            this.rowDDRADNIK.OPCINARADAIDOPCINE = oPCINARADAIDOPCINE;
            try
            {
                this.LoadByOPCINARADAIDOPCINE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByOPCINASTANOVANJAIDOPCINE(DDRADNIKDataSet dataSet, string oPCINASTANOVANJAIDOPCINE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDRADNIKSet = dataSet;
            this.rowDDRADNIK = this.DDRADNIKSet.DDRADNIK.NewDDRADNIKRow();
            this.rowDDRADNIK.OPCINASTANOVANJAIDOPCINE = oPCINASTANOVANJAIDOPCINE;
            try
            {
                this.LoadByOPCINASTANOVANJAIDOPCINE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(DDRADNIKDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDRADNIKSet = dataSet;
            try
            {
                this.LoadChildDdradnik(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDBANKE(DDRADNIKDataSet dataSet, int iDBANKE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDRADNIKSet = dataSet;
            this.rowDDRADNIK = this.DDRADNIKSet.DDRADNIK.NewDDRADNIKRow();
            this.rowDDRADNIK.IDBANKE = iDBANKE;
            try
            {
                this.LoadByIDBANKE(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByOPCINARADAIDOPCINE(DDRADNIKDataSet dataSet, string oPCINARADAIDOPCINE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDRADNIKSet = dataSet;
            this.rowDDRADNIK = this.DDRADNIKSet.DDRADNIK.NewDDRADNIKRow();
            this.rowDDRADNIK.OPCINARADAIDOPCINE = oPCINARADAIDOPCINE;
            try
            {
                this.LoadByOPCINARADAIDOPCINE(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByOPCINASTANOVANJAIDOPCINE(DDRADNIKDataSet dataSet, string oPCINASTANOVANJAIDOPCINE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDRADNIKSet = dataSet;
            this.rowDDRADNIK = this.DDRADNIKSet.DDRADNIK.NewDDRADNIKRow();
            this.rowDDRADNIK.OPCINASTANOVANJAIDOPCINE = oPCINASTANOVANJAIDOPCINE;
            try
            {
                this.LoadByOPCINASTANOVANJAIDOPCINE(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDIDRADNIK], [DDDRUGISTUP], [DDPDVOBVEZNIK], [DDZBIRNINETO], [DDJMBG], [DDOIB], [DDPREZIME], [DDIME], [DDADRESA], [DDKUCNIBROJ], [DDMJESTO], [DDZRN], [DDSIFRAOPISAPLACANJANETO], [DDOPISPLACANJANETO], [DDMO], [DDPBO], [IDBANKE], [OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, [OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, [Aktivan] FROM [DDRADNIK] WITH (NOLOCK) WHERE [DDIDRADNIK] = @DDIDRADNIK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDIDRADNIK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound141 = 1;
                this.rowDDRADNIK["DDIDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowDDRADNIK["DDDRUGISTUP"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 1));
                this.rowDDRADNIK["DDPDVOBVEZNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 2));
                this.rowDDRADNIK["DDZBIRNINETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 3));
                this.rowDDRADNIK["DDJMBG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowDDRADNIK["DDOIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowDDRADNIK["DDPREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowDDRADNIK["DDIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowDDRADNIK["DDADRESA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowDDRADNIK["DDKUCNIBROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowDDRADNIK["DDMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
                this.rowDDRADNIK["DDZRN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
                this.rowDDRADNIK["DDSIFRAOPISAPLACANJANETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12));
                this.rowDDRADNIK["DDOPISPLACANJANETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 13));
                this.rowDDRADNIK["DDMO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 14));
                this.rowDDRADNIK["DDPBO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 15));
                this.rowDDRADNIK["IDBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x10));
                this.rowDDRADNIK["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x11));
                this.rowDDRADNIK["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x12));
                this.rowDDRADNIK["Aktivan"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 0x13));
                this.sMode141 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadDdradnik();
                this.Gx_mode = this.sMode141;
            }
            else
            {
                this.RcdFound141 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "DDIDRADNIK";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDRADNIKSelect4 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [DDRADNIK] WITH (NOLOCK) ", false);
            this.DDRADNIKSelect4 = this.cmDDRADNIKSelect4.FetchData();
            if (this.DDRADNIKSelect4.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.DDRADNIKSelect4.GetInt32(0);
            }
            this.DDRADNIKSelect4.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDBANKE(int iDBANKE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDRADNIKSelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [DDRADNIK] WITH (NOLOCK) WHERE [IDBANKE] = @IDBANKE ", false);
            if (this.cmDDRADNIKSelect3.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDRADNIKSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            this.cmDDRADNIKSelect3.SetParameter(0, iDBANKE);
            this.DDRADNIKSelect3 = this.cmDDRADNIKSelect3.FetchData();
            if (this.DDRADNIKSelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.DDRADNIKSelect3.GetInt32(0);
            }
            this.DDRADNIKSelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByOPCINARADAIDOPCINE(string oPCINARADAIDOPCINE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDRADNIKSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [DDRADNIK] WITH (NOLOCK) WHERE [OPCINARADAIDOPCINE] = @OPCINARADAIDOPCINE ", false);
            if (this.cmDDRADNIKSelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDRADNIKSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
            }
            this.cmDDRADNIKSelect1.SetParameter(0, oPCINARADAIDOPCINE);
            this.DDRADNIKSelect1 = this.cmDDRADNIKSelect1.FetchData();
            if (this.DDRADNIKSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.DDRADNIKSelect1.GetInt32(0);
            }
            this.DDRADNIKSelect1.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByOPCINASTANOVANJAIDOPCINE(string oPCINASTANOVANJAIDOPCINE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDRADNIKSelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [DDRADNIK] WITH (NOLOCK) WHERE [OPCINASTANOVANJAIDOPCINE] = @OPCINASTANOVANJAIDOPCINE ", false);
            if (this.cmDDRADNIKSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDRADNIKSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
            }
            this.cmDDRADNIKSelect2.SetParameter(0, oPCINASTANOVANJAIDOPCINE);
            this.DDRADNIKSelect2 = this.cmDDRADNIKSelect2.FetchData();
            if (this.DDRADNIKSelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.DDRADNIKSelect2.GetInt32(0);
            }
            this.DDRADNIKSelect2.Close();
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

        public virtual int GetRecordCountByIDBANKE(int iDBANKE)
        {
            int internalRecordCountByIDBANKE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDBANKE = this.GetInternalRecordCountByIDBANKE(iDBANKE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDBANKE;
        }

        public virtual int GetRecordCountByOPCINARADAIDOPCINE(string oPCINARADAIDOPCINE)
        {
            int internalRecordCountByOPCINARADAIDOPCINE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByOPCINARADAIDOPCINE = this.GetInternalRecordCountByOPCINARADAIDOPCINE(oPCINARADAIDOPCINE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByOPCINARADAIDOPCINE;
        }

        public virtual int GetRecordCountByOPCINASTANOVANJAIDOPCINE(string oPCINASTANOVANJAIDOPCINE)
        {
            int internalRecordCountByOPCINASTANOVANJAIDOPCINE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByOPCINASTANOVANJAIDOPCINE = this.GetInternalRecordCountByOPCINASTANOVANJAIDOPCINE(oPCINASTANOVANJAIDOPCINE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByOPCINASTANOVANJAIDOPCINE;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound141 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__DDDRUGISTUPOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDPDVOBVEZNIKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDZBIRNINETOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDJMBGOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDOIBOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDPREZIMEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDIMEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDADRESAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDKUCNIBROJOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDMJESTOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDZRNOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDSIFRAOPISAPLACANJANETOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDOPISPLACANJANETOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDMOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDPBOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDBANKEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OPCINARADAIDOPCINEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OPCINASTANOVANJAIDOPCINEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__AktivanOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Condition = false;
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.DDRADNIKSet = new DDRADNIKDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertDdradnik()
        {
            this.CheckOptimisticConcurrencyDdradnik();
            this.CheckExtendedTableDdradnik();
            this.AfterConfirmDdradnik();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DDRADNIK] ([DDIDRADNIK], [DDDRUGISTUP], [DDPDVOBVEZNIK], [DDZBIRNINETO], [DDJMBG], [DDOIB], [DDPREZIME], [DDIME], " +
                "[DDADRESA], [DDKUCNIBROJ], [DDMJESTO], [DDZRN], [DDSIFRAOPISAPLACANJANETO], [DDOPISPLACANJANETO], [DDMO], [DDPBO], [IDBANKE], [OPCINARADAIDOPCINE], [OPCINASTANOVANJAIDOPCINE], [Aktivan]) " +
                "VALUES (@DDIDRADNIK, @DDDRUGISTUP, @DDPDVOBVEZNIK, @DDZBIRNINETO, @DDJMBG, @DDOIB, @DDPREZIME, @DDIME, @DDADRESA, @DDKUCNIBROJ, @DDMJESTO, @DDZRN, @DDSIFRAOPISAPLACANJANETO, " +
                "@DDOPISPLACANJANETO, @DDMO, @DDPBO, @IDBANKE, @OPCINARADAIDOPCINE, @OPCINASTANOVANJAIDOPCINE, @Aktivan)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDDRUGISTUP", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPDVOBVEZNIK", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDZBIRNINETO", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDJMBG", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOIB", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPREZIME", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIME", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDADRESA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDKUCNIBROJ", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDMJESTO", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDZRN", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDSIFRAOPISAPLACANJANETO", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOPISPLACANJANETO", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDMO", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPBO", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@Aktivan", DbType.Boolean));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDIDRADNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDDRUGISTUP"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDPDVOBVEZNIK"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDZBIRNINETO"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDJMBG"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDOIB"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDPREZIME"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDIME"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDADRESA"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDKUCNIBROJ"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDMJESTO"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDZRN"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDSIFRAOPISAPLACANJANETO"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDOPISPLACANJANETO"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDMO"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDPBO"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["IDBANKE"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["OPCINARADAIDOPCINE"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["OPCINASTANOVANJAIDOPCINE"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["Aktivan"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DDRADNIKDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDDRADNIKUpdated(new DDRADNIKEventArgs(this.rowDDRADNIK, StatementType.Insert));
        }

        private void LoadByDDIDRADNIK(int startRow, int maxRows)
        {
            bool enforceConstraints = this.DDRADNIKSet.EnforceConstraints;
            this.DDRADNIKSet.DDRADNIK.BeginLoadData();
            this.ScanByDDIDRADNIK(startRow, maxRows);
            this.DDRADNIKSet.DDRADNIK.EndLoadData();
            this.DDRADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.DDRADNIKSet.DDRADNIK.Count > 0)
            {
                this.rowDDRADNIK = this.DDRADNIKSet.DDRADNIK[this.DDRADNIKSet.DDRADNIK.Count - 1];
            }
        }

        private void LoadByIDBANKE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.DDRADNIKSet.EnforceConstraints;
            this.DDRADNIKSet.DDRADNIK.BeginLoadData();
            this.ScanByIDBANKE(startRow, maxRows);
            this.DDRADNIKSet.DDRADNIK.EndLoadData();
            this.DDRADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.DDRADNIKSet.DDRADNIK.Count > 0)
            {
                this.rowDDRADNIK = this.DDRADNIKSet.DDRADNIK[this.DDRADNIKSet.DDRADNIK.Count - 1];
            }
        }

        private void LoadByOPCINARADAIDOPCINE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.DDRADNIKSet.EnforceConstraints;
            this.DDRADNIKSet.DDRADNIK.BeginLoadData();
            this.ScanByOPCINARADAIDOPCINE(startRow, maxRows);
            this.DDRADNIKSet.DDRADNIK.EndLoadData();
            this.DDRADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.DDRADNIKSet.DDRADNIK.Count > 0)
            {
                this.rowDDRADNIK = this.DDRADNIKSet.DDRADNIK[this.DDRADNIKSet.DDRADNIK.Count - 1];
            }
        }

        private void LoadByOPCINASTANOVANJAIDOPCINE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.DDRADNIKSet.EnforceConstraints;
            this.DDRADNIKSet.DDRADNIK.BeginLoadData();
            this.ScanByOPCINASTANOVANJAIDOPCINE(startRow, maxRows);
            this.DDRADNIKSet.DDRADNIK.EndLoadData();
            this.DDRADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.DDRADNIKSet.DDRADNIK.Count > 0)
            {
                this.rowDDRADNIK = this.DDRADNIKSet.DDRADNIK[this.DDRADNIKSet.DDRADNIK.Count - 1];
            }
        }

        private void LoadChildDdradnik(int startRow, int maxRows)
        {
            this.CreateNewRowDdradnik();
            bool enforceConstraints = this.DDRADNIKSet.EnforceConstraints;
            this.DDRADNIKSet.DDRADNIK.BeginLoadData();
            this.ScanStartDdradnik(startRow, maxRows);
            this.DDRADNIKSet.DDRADNIK.EndLoadData();
            this.DDRADNIKSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataDdradnik(int maxRows)
        {
            int num = 0;
            if (this.RcdFound141 != 0)
            {
                this.ScanLoadDdradnik();
                while ((this.RcdFound141 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowDdradnik();
                    this.CreateNewRowDdradnik();
                    this.ScanNextDdradnik();
                }
            }
            if (num > 0)
            {
                this.RcdFound141 = 1;
            }
            this.ScanEndDdradnik();
            if (this.DDRADNIKSet.DDRADNIK.Count > 0)
            {
                this.rowDDRADNIK = this.DDRADNIKSet.DDRADNIK[this.DDRADNIKSet.DDRADNIK.Count - 1];
            }
        }

        private void LoadDdradnik()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVBANKE1], [NAZIVBANKE2], [NAZIVBANKE3], [VBDIBANKE], [ZRNBANKE] FROM [BANKE] WITH (NOLOCK) WHERE [IDBANKE] = @IDBANKE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["IDBANKE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowDDRADNIK["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowDDRADNIK["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowDDRADNIK["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowDDRADNIK["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowDDRADNIK["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINARADANAZIVOPCINE FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINARADAIDOPCINE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["OPCINARADAIDOPCINE"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowDDRADNIK["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            }
            reader2.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, [PRIREZ] AS OPCINASTANOVANJAPRIREZ, [VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, [ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINASTANOVANJAIDOPCINE ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["OPCINASTANOVANJAIDOPCINE"]));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                this.rowDDRADNIK["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0));
                this.rowDDRADNIK["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader3, 1));
                this.rowDDRADNIK["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 2));
                this.rowDDRADNIK["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 3));
            }
            reader3.Close();
        }

        private void LoadRowDdradnik()
        {
            this.AddRowDdradnik();
        }

        private void OnDDRADNIKUpdated(DDRADNIKEventArgs e)
        {
            if (this.DDRADNIKUpdated != null)
            {
                DDRADNIKUpdateEventHandler dDRADNIKUpdatedEvent = this.DDRADNIKUpdated;
                if (dDRADNIKUpdatedEvent != null)
                {
                    dDRADNIKUpdatedEvent(this, e);
                }
            }
        }

        private void OnDDRADNIKUpdating(DDRADNIKEventArgs e)
        {
            if (this.DDRADNIKUpdating != null)
            {
                DDRADNIKUpdateEventHandler dDRADNIKUpdatingEvent = this.DDRADNIKUpdating;
                if (dDRADNIKUpdatingEvent != null)
                {
                    dDRADNIKUpdatingEvent(this, e);
                }
            }
        }

        private void OnDeleteControlsDdradnik()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVBANKE1], [NAZIVBANKE2], [NAZIVBANKE3], [VBDIBANKE], [ZRNBANKE] FROM [BANKE] WITH (NOLOCK) WHERE [IDBANKE] = @IDBANKE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["IDBANKE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowDDRADNIK["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowDDRADNIK["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowDDRADNIK["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowDDRADNIK["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowDDRADNIK["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINARADANAZIVOPCINE FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINARADAIDOPCINE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["OPCINARADAIDOPCINE"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowDDRADNIK["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            }
            reader2.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, [PRIREZ] AS OPCINASTANOVANJAPRIREZ, [VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, [ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINASTANOVANJAIDOPCINE ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["OPCINASTANOVANJAIDOPCINE"]));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                this.rowDDRADNIK["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0));
                this.rowDDRADNIK["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader3, 1));
                this.rowDDRADNIK["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 2));
                this.rowDDRADNIK["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 3));
            }
            reader3.Close();
        }

        private void ReadRowDdradnik()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDDRADNIK.RowState);
            if (this.rowDDRADNIK.RowState != DataRowState.Added)
            {
                this.m__DDDRUGISTUPOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDDRUGISTUP", DataRowVersion.Original]);
                this.m__DDPDVOBVEZNIKOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDPDVOBVEZNIK", DataRowVersion.Original]);
                this.m__DDZBIRNINETOOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDZBIRNINETO", DataRowVersion.Original]);
                this.m__DDJMBGOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDJMBG", DataRowVersion.Original]);
                this.m__DDOIBOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDOIB", DataRowVersion.Original]);
                this.m__DDPREZIMEOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDPREZIME", DataRowVersion.Original]);
                this.m__DDIMEOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDIME", DataRowVersion.Original]);
                this.m__DDADRESAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDADRESA", DataRowVersion.Original]);
                this.m__DDKUCNIBROJOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDKUCNIBROJ", DataRowVersion.Original]);
                this.m__DDMJESTOOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDMJESTO", DataRowVersion.Original]);
                this.m__DDZRNOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDZRN", DataRowVersion.Original]);
                this.m__DDSIFRAOPISAPLACANJANETOOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDSIFRAOPISAPLACANJANETO", DataRowVersion.Original]);
                this.m__DDOPISPLACANJANETOOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDOPISPLACANJANETO", DataRowVersion.Original]);
                this.m__DDMOOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDMO", DataRowVersion.Original]);
                this.m__DDPBOOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDPBO", DataRowVersion.Original]);
                this.m__IDBANKEOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["IDBANKE", DataRowVersion.Original]);
                this.m__OPCINARADAIDOPCINEOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["OPCINARADAIDOPCINE", DataRowVersion.Original]);
                this.m__OPCINASTANOVANJAIDOPCINEOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["OPCINASTANOVANJAIDOPCINE", DataRowVersion.Original]);
                this.m__AktivanOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["Aktivan", DataRowVersion.Original]);
            }
            else
            {
                this.m__DDDRUGISTUPOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDDRUGISTUP"]);
                this.m__DDPDVOBVEZNIKOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDPDVOBVEZNIK"]);
                this.m__DDZBIRNINETOOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDZBIRNINETO"]);
                this.m__DDJMBGOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDJMBG"]);
                this.m__DDOIBOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDOIB"]);
                this.m__DDPREZIMEOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDPREZIME"]);
                this.m__DDIMEOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDIME"]);
                this.m__DDADRESAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDADRESA"]);
                this.m__DDKUCNIBROJOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDKUCNIBROJ"]);
                this.m__DDMJESTOOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDMJESTO"]);
                this.m__DDZRNOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDZRN"]);
                this.m__DDSIFRAOPISAPLACANJANETOOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDSIFRAOPISAPLACANJANETO"]);
                this.m__DDOPISPLACANJANETOOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDOPISPLACANJANETO"]);
                this.m__DDMOOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDMO"]);
                this.m__DDPBOOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDPBO"]);
                this.m__IDBANKEOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["IDBANKE"]);
                this.m__OPCINARADAIDOPCINEOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["OPCINARADAIDOPCINE"]);
                this.m__OPCINASTANOVANJAIDOPCINEOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["OPCINASTANOVANJAIDOPCINE"]);
                this.m__AktivanOriginal = RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["Aktivan"]);
            }
            this._Gxremove = this.rowDDRADNIK.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowDDRADNIK = (DDRADNIKDataSet.DDRADNIKRow) DataSetUtil.CloneOriginalDataRow(this.rowDDRADNIK);
            }
        }

        private void ScanByDDIDRADNIK(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[DDIDRADNIK] = @DDIDRADNIK";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString141 + "  FROM ((([DDRADNIK] TM1 WITH (NOLOCK) INNER JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE])" + this.m_WhereString + " ORDER BY TM1.[DDIDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString141, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[DDIDRADNIK] ) AS DK_PAGENUM   FROM ((([DDRADNIK] TM1 WITH (NOLOCK) INNER JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString141 + " FROM ((([DDRADNIK] TM1 WITH (NOLOCK) INNER JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE])" + this.m_WhereString + " ORDER BY TM1.[DDIDRADNIK] ";
            }
            this.cmDDRADNIKSelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmDDRADNIKSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDRADNIKSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
            }
            this.cmDDRADNIKSelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDIDRADNIK"]));
            this.DDRADNIKSelect7 = this.cmDDRADNIKSelect7.FetchData();
            this.RcdFound141 = 0;
            this.ScanLoadDdradnik();
            this.LoadDataDdradnik(maxRows);
        }

        private void ScanByIDBANKE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDBANKE] = @IDBANKE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString141 + "  FROM ((([DDRADNIK] TM1 WITH (NOLOCK) INNER JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE])" + this.m_WhereString + " ORDER BY TM1.[DDIDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString141, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[DDIDRADNIK] ) AS DK_PAGENUM   FROM ((([DDRADNIK] TM1 WITH (NOLOCK) INNER JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString141 + " FROM ((([DDRADNIK] TM1 WITH (NOLOCK) INNER JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE])" + this.m_WhereString + " ORDER BY TM1.[DDIDRADNIK] ";
            }
            this.cmDDRADNIKSelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmDDRADNIKSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDRADNIKSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            this.cmDDRADNIKSelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["IDBANKE"]));
            this.DDRADNIKSelect7 = this.cmDDRADNIKSelect7.FetchData();
            this.RcdFound141 = 0;
            this.ScanLoadDdradnik();
            this.LoadDataDdradnik(maxRows);
        }

        private void ScanByOPCINARADAIDOPCINE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[OPCINARADAIDOPCINE] = @OPCINARADAIDOPCINE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString141 + "  FROM ((([DDRADNIK] TM1 WITH (NOLOCK) INNER JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE])" + this.m_WhereString + " ORDER BY TM1.[DDIDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString141, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[DDIDRADNIK] ) AS DK_PAGENUM   FROM ((([DDRADNIK] TM1 WITH (NOLOCK) INNER JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString141 + " FROM ((([DDRADNIK] TM1 WITH (NOLOCK) INNER JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE])" + this.m_WhereString + " ORDER BY TM1.[DDIDRADNIK] ";
            }
            this.cmDDRADNIKSelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmDDRADNIKSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDRADNIKSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
            }
            this.cmDDRADNIKSelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["OPCINARADAIDOPCINE"]));
            this.DDRADNIKSelect7 = this.cmDDRADNIKSelect7.FetchData();
            this.RcdFound141 = 0;
            this.ScanLoadDdradnik();
            this.LoadDataDdradnik(maxRows);
        }

        private void ScanByOPCINASTANOVANJAIDOPCINE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[OPCINASTANOVANJAIDOPCINE] = @OPCINASTANOVANJAIDOPCINE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString141 + "  FROM ((([DDRADNIK] TM1 WITH (NOLOCK) INNER JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE])" + this.m_WhereString + " ORDER BY TM1.[DDIDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString141, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[DDIDRADNIK] ) AS DK_PAGENUM   FROM ((([DDRADNIK] TM1 WITH (NOLOCK) INNER JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString141 + " FROM ((([DDRADNIK] TM1 WITH (NOLOCK) INNER JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE])" + this.m_WhereString + " ORDER BY TM1.[DDIDRADNIK] ";
            }
            this.cmDDRADNIKSelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmDDRADNIKSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDRADNIKSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
            }
            this.cmDDRADNIKSelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["OPCINASTANOVANJAIDOPCINE"]));
            this.DDRADNIKSelect7 = this.cmDDRADNIKSelect7.FetchData();
            this.RcdFound141 = 0;
            this.ScanLoadDdradnik();
            this.LoadDataDdradnik(maxRows);
        }

        private void ScanEndDdradnik()
        {
            this.DDRADNIKSelect7.Close();
        }

        private void ScanLoadDdradnik()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDDRADNIKSelect7.HasMoreRows)
            {
                this.RcdFound141 = 1;
                this.rowDDRADNIK["DDIDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDRADNIKSelect7, 0));
                this.rowDDRADNIK["DDDRUGISTUP"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.DDRADNIKSelect7, 1));
                this.rowDDRADNIK["DDPDVOBVEZNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.DDRADNIKSelect7, 2));
                this.rowDDRADNIK["DDZBIRNINETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.DDRADNIKSelect7, 3));
                this.rowDDRADNIK["DDJMBG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 4));
                this.rowDDRADNIK["DDOIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 5));
                this.rowDDRADNIK["DDPREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 6));
                this.rowDDRADNIK["DDIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 7));
                this.rowDDRADNIK["DDADRESA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 8));
                this.rowDDRADNIK["DDKUCNIBROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 9));
                this.rowDDRADNIK["DDMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 10));
                this.rowDDRADNIK["DDZRN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 11));
                this.rowDDRADNIK["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 12));
                this.rowDDRADNIK["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 13));
                this.rowDDRADNIK["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 14));
                this.rowDDRADNIK["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 15));
                this.rowDDRADNIK["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 0x10));
                this.rowDDRADNIK["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 0x11));
                this.rowDDRADNIK["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 0x12));
                this.rowDDRADNIK["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDRADNIKSelect7, 0x13));
                this.rowDDRADNIK["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 20));
                this.rowDDRADNIK["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 0x15));
                this.rowDDRADNIK["DDSIFRAOPISAPLACANJANETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 0x16));
                this.rowDDRADNIK["DDOPISPLACANJANETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 0x17));
                this.rowDDRADNIK["DDMO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 0x18));
                this.rowDDRADNIK["DDPBO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 0x19));
                this.rowDDRADNIK["IDBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDRADNIKSelect7, 0x1a));
                this.rowDDRADNIK["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 0x1b));
                this.rowDDRADNIK["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 0x1c));
                this.rowDDRADNIK["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 12));
                this.rowDDRADNIK["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 13));
                this.rowDDRADNIK["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 14));
                this.rowDDRADNIK["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 15));
                this.rowDDRADNIK["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 0x10));
                this.rowDDRADNIK["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 0x11));
                this.rowDDRADNIK["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 0x12));
                this.rowDDRADNIK["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDRADNIKSelect7, 0x13));
                this.rowDDRADNIK["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 20));
                this.rowDDRADNIK["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDRADNIKSelect7, 0x15));
                this.rowDDRADNIK["Aktivan"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.DDRADNIKSelect7, 29));
            }
        }

        private void ScanNextDdradnik()
        {
            this.cmDDRADNIKSelect7.HasMoreRows = this.DDRADNIKSelect7.Read();
            this.RcdFound141 = 0;
            this.ScanLoadDdradnik();
        }

        private void ScanStartDdradnik(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString141 + "  FROM ((([DDRADNIK] TM1 WITH (NOLOCK) INNER JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE])" + this.m_WhereString + " ORDER BY TM1.[DDIDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString141, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[DDIDRADNIK] ) AS DK_PAGENUM   FROM ((([DDRADNIK] TM1 WITH (NOLOCK) INNER JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString141 + " FROM ((([DDRADNIK] TM1 WITH (NOLOCK) INNER JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE])" + this.m_WhereString + " ORDER BY TM1.[DDIDRADNIK] ";
            }
            this.cmDDRADNIKSelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.DDRADNIKSelect7 = this.cmDDRADNIKSelect7.FetchData();
            this.RcdFound141 = 0;
            this.ScanLoadDdradnik();
            this.LoadDataDdradnik(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.DDRADNIKSet = (DDRADNIKDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.DDRADNIKSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.DDRADNIKSet.DDRADNIK.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DDRADNIKDataSet.DDRADNIKRow current = (DDRADNIKDataSet.DDRADNIKRow) enumerator.Current;
                        this.rowDDRADNIK = current;
                        if (Helpers.IsRowChanged(this.rowDDRADNIK))
                        {
                            this.ReadRowDdradnik();
                            if (this.rowDDRADNIK.RowState == DataRowState.Added)
                            {
                                this.InsertDdradnik();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateDdradnik();
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

        private void UpdateDdradnik()
        {
            this.CheckOptimisticConcurrencyDdradnik();
            this.CheckExtendedTableDdradnik();
            this.AfterConfirmDdradnik();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DDRADNIK] SET [DDDRUGISTUP]=@DDDRUGISTUP, [DDPDVOBVEZNIK]=@DDPDVOBVEZNIK, [DDZBIRNINETO]=@DDZBIRNINETO, [DDJMBG]=@DDJMBG, " +
                "[DDOIB]=@DDOIB, [DDPREZIME]=@DDPREZIME, [DDIME]=@DDIME, [DDADRESA]=@DDADRESA, [DDKUCNIBROJ]=@DDKUCNIBROJ, [DDMJESTO]=@DDMJESTO, [DDZRN]=@DDZRN, " +
                "[DDSIFRAOPISAPLACANJANETO]=@DDSIFRAOPISAPLACANJANETO, [DDOPISPLACANJANETO]=@DDOPISPLACANJANETO, [DDMO]=@DDMO, [DDPBO]=@DDPBO, [IDBANKE]=@IDBANKE, [OPCINARADAIDOPCINE]=@OPCINARADAIDOPCINE, " +
                "[OPCINASTANOVANJAIDOPCINE]=@OPCINASTANOVANJAIDOPCINE, [Aktivan] = @Aktivan  WHERE [DDIDRADNIK] = @DDIDRADNIK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDDRUGISTUP", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPDVOBVEZNIK", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDZBIRNINETO", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDJMBG", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOIB", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPREZIME", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIME", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDADRESA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDKUCNIBROJ", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDMJESTO", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDZRN", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDSIFRAOPISAPLACANJANETO", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOPISPLACANJANETO", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDMO", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPBO", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@Aktivan", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDDRUGISTUP"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDPDVOBVEZNIK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDZBIRNINETO"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDJMBG"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDOIB"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDPREZIME"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDIME"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDADRESA"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDKUCNIBROJ"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDMJESTO"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDZRN"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDSIFRAOPISAPLACANJANETO"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDOPISPLACANJANETO"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDMO"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDPBO"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["IDBANKE"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["OPCINARADAIDOPCINE"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["OPCINASTANOVANJAIDOPCINE"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["Aktivan"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowDDRADNIK["DDIDRADNIK"]));
            command.ExecuteStmt();
            new ddradnikupdateredundancy(ref this.dsDefault).execute(this.rowDDRADNIK.DDIDRADNIK);
            this.OnDDRADNIKUpdated(new DDRADNIKEventArgs(this.rowDDRADNIK, StatementType.Update));
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
        public class DDOBRACUNRadniciInvalidDeleteException : InvalidDeleteException
        {
            public DDOBRACUNRadniciInvalidDeleteException()
            {
            }

            public DDOBRACUNRadniciInvalidDeleteException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDRADNIKDataChangedException : DataChangedException
        {
            public DDRADNIKDataChangedException()
            {
            }

            public DDRADNIKDataChangedException(string message) : base(message)
            {
            }

            protected DDRADNIKDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDRADNIKDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDRADNIKDataLockedException : DataLockedException
        {
            public DDRADNIKDataLockedException()
            {
            }

            public DDRADNIKDataLockedException(string message) : base(message)
            {
            }

            protected DDRADNIKDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDRADNIKDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDRADNIKDuplicateKeyException : DuplicateKeyException
        {
            public DDRADNIKDuplicateKeyException()
            {
            }

            public DDRADNIKDuplicateKeyException(string message) : base(message)
            {
            }

            protected DDRADNIKDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDRADNIKDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DDRADNIKEventArgs : EventArgs
        {
            private DDRADNIKDataSet.DDRADNIKRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public DDRADNIKEventArgs(DDRADNIKDataSet.DDRADNIKRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DDRADNIKDataSet.DDRADNIKRow Row
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
        public class DDRADNIKNotFoundException : DataNotFoundException
        {
            public DDRADNIKNotFoundException()
            {
            }

            public DDRADNIKNotFoundException(string message) : base(message)
            {
            }

            protected DDRADNIKNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDRADNIKNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void DDRADNIKUpdateEventHandler(object sender, DDRADNIKDataAdapter.DDRADNIKEventArgs e);

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
    }
}

