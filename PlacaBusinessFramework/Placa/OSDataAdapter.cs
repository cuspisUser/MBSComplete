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

    public class OSDataAdapter : IDataAdapter, IOSDataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private bool _Gxremove35;
        private ReadWriteCommand cmOSSelect1;
        private ReadWriteCommand cmOSSelect2;
        private ReadWriteCommand cmOSSelect3;
        private ReadWriteCommand cmOSSelect6;
        private ReadWriteCommand cmOSTEMELJNICASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__DATUMNABAVKEOriginal;
        private object m__DATUMUPORABEOriginal;
        private object m__IDAMSKUPINEOriginal;
        private object m__IDOSVRSTAOriginal;
        private object m__NAPOMENAOSOriginal;
        private object m__NAZIVOSOriginal;
        private object m__OSDATUMDOKOriginal;
        private object m__OSDUGUJEOriginal;
        private object m__OSKOLICINAOriginal;
        private object m__OSOPISOriginal;
        private object m__OSOSNOVICAOriginal;
        private object m__OSPOTRAZUJEOriginal;
        private object m__OSSTOPAOriginal;
        private object m__RASHODLOKACIJEIDLOKACIJEOriginal;
        private readonly string m_SelectString269 = "TM1.[INVBROJ], TM1.[NAZIVOS], TM1.[DATUMNABAVKE], TM1.[DATUMUPORABE], TM1.[NAPOMENAOS], T2.[OPISAMSKUPINE], T2.[AMSKUPINASTOPA], TM1.[IDAMSKUPINE], T2.[KTONABAVKEIDKONTO], T2.[KTOISPRAVKAIDKONTO], T2.[KTOIZVORAIDKONTO], TM1.[IDOSVRSTA]";
        private string m_SubSelTopString275;
        private string m_WhereString;
        private IDataReader OSSelect1;
        private IDataReader OSSelect2;
        private IDataReader OSSelect3;
        private IDataReader OSSelect6;
        private OSDataSet OSSet;
        private IDataReader OSTEMELJNICASelect2;
        private short RcdFound269;
        private short RcdFound275;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private OSDataSet.OSRow rowOS;
        private OSDataSet.OSTEMELJNICARow rowOSTEMELJNICA;
        private string scmdbuf;
        private StatementType sMode269;
        private StatementType sMode275;

        public event OSTEMELJNICAUpdateEventHandler OSTEMELJNICAUpdated;

        public event OSTEMELJNICAUpdateEventHandler OSTEMELJNICAUpdating;

        public event OSUpdateEventHandler OSUpdated;

        public event OSUpdateEventHandler OSUpdating;

        private void AddRowOs()
        {
            this.OSSet.OS.AddOSRow(this.rowOS);
        }

        private void AddRowOstemeljnica()
        {
            this.OSSet.OSTEMELJNICA.AddOSTEMELJNICARow(this.rowOSTEMELJNICA);
        }

        private void AfterConfirmOs()
        {
            this.OnOSUpdating(new OSEventArgs(this.rowOS, this.Gx_mode));
        }

        private void AfterConfirmOstemeljnica()
        {
            this.OnOSTEMELJNICAUpdating(new OSTEMELJNICAEventArgs(this.rowOSTEMELJNICA, this.Gx_mode));
        }

        private void CheckDeleteErrorsOs()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDOSRAZMJESTAJ] FROM [OSRAZMJESTAJ] WITH (NOLOCK) WHERE [INVBROJ] = @INVBROJ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOS["INVBROJ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new OSRAZMJESTAJInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "OSRAZMJESTAJ" }));
            }
            reader.Close();
        }

        private void CheckExtendedTableOs()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [OPISAMSKUPINE], [AMSKUPINASTOPA], [KTONABAVKEIDKONTO], [KTOISPRAVKAIDKONTO], [KTOIZVORAIDKONTO] FROM [AMSKUPINE] WITH (NOLOCK) WHERE [IDAMSKUPINE] = @IDAMSKUPINE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAMSKUPINE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOS["IDAMSKUPINE"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new AMSKUPINEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("AMSKUPINE") }));
            }
            this.rowOS["OPISAMSKUPINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowOS["AMSKUPINASTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            this.rowOS["KTONABAVKEIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))));
            this.rowOS["KTOISPRAVKAIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3))));
            this.rowOS["KTOIZVORAIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))));
            reader.Close();
        }

        private void CheckExtendedTableOstemeljnica()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVOSDOKUMENT] FROM [OSDOKUMENT] WITH (NOLOCK) WHERE [IDOSDOKUMENT] = @IDOSDOKUMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSDOKUMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["IDOSDOKUMENT"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new OSDOKUMENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OSDOKUMENT") }));
            }
            this.rowOSTEMELJNICA["NAZIVOSDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            reader.Close();
        }

        private void CheckIntegrityErrorsOs()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOSVRSTA] FROM [OSVRSTA] WITH (NOLOCK) WHERE [IDOSVRSTA] = @IDOSVRSTA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSVRSTA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOS["IDOSVRSTA"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new OSVRSTAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OSVRSTA") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckIntegrityErrorsOstemeljnica()
        {
            if (!this.rowOSTEMELJNICA.IsRASHODLOKACIJEIDLOKACIJENull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDLOKACIJE] AS RASHODLOKACIJEIDLOKACIJE FROM [LOKACIJE] WITH (NOLOCK) WHERE [IDLOKACIJE] = @RASHODLOKACIJEIDLOKACIJE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RASHODLOKACIJEIDLOKACIJE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["RASHODLOKACIJEIDLOKACIJE"]));
                IDataReader reader = command.FetchData();
                if (!command.HasMoreRows && (0 != this.rowOSTEMELJNICA.RASHODLOKACIJEIDLOKACIJE))
                {
                    reader.Close();
                    throw new LOKACIJEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("LOKACIJE") }));
                }
                reader.Close();
            }
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyOs()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [INVBROJ], [NAZIVOS], [DATUMNABAVKE], [DATUMUPORABE], [NAPOMENAOS], [IDAMSKUPINE], [IDOSVRSTA] FROM [OS] WITH (UPDLOCK) WHERE [INVBROJ] = @INVBROJ ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOS["INVBROJ"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new OSDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("OS") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVOSOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__DATUMNABAVKEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 2))) || !DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__DATUMUPORABEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 3)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAPOMENAOSOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))) || !this.m__IDAMSKUPINEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 5))))))
                {
                    this._Condition = true;
                }
                if (this._Condition || !this.m__IDOSVRSTAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 6))))
                {
                    reader.Close();
                    throw new OSDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("OS") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyOstemeljnica()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [INVBROJ], [OSBROJDOKUMENTA], [OSDATUMDOK], [OSKOLICINA], [OSSTOPA], [OSOSNOVICA], [OSDUGUJE], [OSPOTRAZUJE], [OSOPIS], [IDOSDOKUMENT], [RASHODLOKACIJEIDLOKACIJE] AS RASHODLOKACIJEIDLOKACIJE FROM [OSTEMELJNICA] WITH (UPDLOCK) WHERE [INVBROJ] = @INVBROJ AND [IDOSDOKUMENT] = @IDOSDOKUMENT AND [OSBROJDOKUMENTA] = @OSBROJDOKUMENTA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSDOKUMENT", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSBROJDOKUMENTA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["INVBROJ"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["IDOSDOKUMENT"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSBROJDOKUMENTA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new OSTEMELJNICADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("OSTEMELJNICA") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__OSDATUMDOKOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 2)))) || ((!this.m__OSKOLICINAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3))) || !this.m__OSSTOPAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4)))) || (!this.m__OSOSNOVICAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 5))) || !this.m__OSDUGUJEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 6))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__OSPOTRAZUJEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 7)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OSOPISOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8))) || !this.m__RASHODLOKACIJEIDLOKACIJEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 10)))))
                {
                    reader.Close();
                    throw new OSTEMELJNICADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("OSTEMELJNICA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowOs()
        {
            this.rowOS = this.OSSet.OS.NewOSRow();
        }

        private void CreateNewRowOstemeljnica()
        {
            this.rowOSTEMELJNICA = this.OSSet.OSTEMELJNICA.NewOSTEMELJNICARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyOs();
            this.OnDeleteControlsOs();
            this.ProcessNestedLevelOstemeljnica();
            this.AfterConfirmOs();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [OS]  WHERE [INVBROJ] = @INVBROJ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOS["INVBROJ"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsOs();
            }
            this.OnOSUpdated(new OSEventArgs(this.rowOS, StatementType.Delete));
            this.rowOS.Delete();
            this.sMode269 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode269;
        }

        private void DeleteOstemeljnica()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyOstemeljnica();
            this.OnDeleteControlsOstemeljnica();
            this.AfterConfirmOstemeljnica();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [OSTEMELJNICA]  WHERE [INVBROJ] = @INVBROJ AND [IDOSDOKUMENT] = @IDOSDOKUMENT AND [OSBROJDOKUMENTA] = @OSBROJDOKUMENTA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSBROJDOKUMENTA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["INVBROJ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["IDOSDOKUMENT"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSBROJDOKUMENTA"]));
            command.ExecuteStmt();
            this.OnOSTEMELJNICAUpdated(new OSTEMELJNICAEventArgs(this.rowOSTEMELJNICA, StatementType.Delete));
            this.rowOSTEMELJNICA.Delete();
            this.sMode275 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode275;
        }

        public virtual int Fill(OSDataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, long.Parse(this.fillDataParameters[0].Value.ToString()));
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.OSSet = dataSet;
                    this.LoadChildOs(0, -1);
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
            this.OSSet = (OSDataSet) dataSet;
            if (this.OSSet != null)
            {
                return this.Fill(this.OSSet);
            }
            this.OSSet = new OSDataSet();
            this.Fill(this.OSSet);
            dataSet.Merge(this.OSSet);
            return 0;
        }

        public virtual int Fill(OSDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToLong(dataRecord["INVBROJ"]));
        }

        public virtual int Fill(OSDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToLong(dataRecord["INVBROJ"]));
        }

        public virtual int Fill(OSDataSet dataSet, long iNVBROJ)
        {
            if (!this.FillByINVBROJ(dataSet, iNVBROJ))
            {
                throw new OSNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OS") }));
            }
            return 0;
        }

        public virtual int FillByIDAMSKUPINE(OSDataSet dataSet, int iDAMSKUPINE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSSet = dataSet;
            this.rowOS = this.OSSet.OS.NewOSRow();
            this.rowOS.IDAMSKUPINE = iDAMSKUPINE;
            try
            {
                this.LoadByIDAMSKUPINE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDOSVRSTA(OSDataSet dataSet, int iDOSVRSTA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSSet = dataSet;
            this.rowOS = this.OSSet.OS.NewOSRow();
            this.rowOS.IDOSVRSTA = iDOSVRSTA;
            try
            {
                this.LoadByIDOSVRSTA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByINVBROJ(OSDataSet dataSet, long iNVBROJ)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSSet = dataSet;
            this.rowOS = this.OSSet.OS.NewOSRow();
            this.rowOS.INVBROJ = iNVBROJ;
            try
            {
                this.LoadByINVBROJ(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound269 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(OSDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSSet = dataSet;
            try
            {
                this.LoadChildOs(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDAMSKUPINE(OSDataSet dataSet, int iDAMSKUPINE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSSet = dataSet;
            this.rowOS = this.OSSet.OS.NewOSRow();
            this.rowOS.IDAMSKUPINE = iDAMSKUPINE;
            try
            {
                this.LoadByIDAMSKUPINE(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDOSVRSTA(OSDataSet dataSet, int iDOSVRSTA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSSet = dataSet;
            this.rowOS = this.OSSet.OS.NewOSRow();
            this.rowOS.IDOSVRSTA = iDOSVRSTA;
            try
            {
                this.LoadByIDOSVRSTA(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [INVBROJ], [NAZIVOS], [DATUMNABAVKE], [DATUMUPORABE], [NAPOMENAOS], [IDAMSKUPINE], [IDOSVRSTA] FROM [OS] WITH (NOLOCK) WHERE [INVBROJ] = @INVBROJ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOS["INVBROJ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound269 = 1;
                this.rowOS["INVBROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt64(reader, 0));
                this.rowOS["NAZIVOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowOS["DATUMNABAVKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 2));
                this.rowOS["DATUMUPORABE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 3));
                this.rowOS["NAPOMENAOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowOS["IDAMSKUPINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 5));
                this.rowOS["IDOSVRSTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 6));
                this.sMode269 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadOs();
                this.Gx_mode = this.sMode269;
            }
            else
            {
                this.RcdFound269 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "INVBROJ";
                parameter.DbType = DbType.Int64;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSSelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OS] WITH (NOLOCK) ", false);
            this.OSSelect3 = this.cmOSSelect3.FetchData();
            if (this.OSSelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OSSelect3.GetInt32(0);
            }
            this.OSSelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDAMSKUPINE(int iDAMSKUPINE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OS] WITH (NOLOCK) WHERE [IDAMSKUPINE] = @IDAMSKUPINE ", false);
            if (this.cmOSSelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAMSKUPINE", DbType.Int32));
            }
            this.cmOSSelect1.SetParameter(0, iDAMSKUPINE);
            this.OSSelect1 = this.cmOSSelect1.FetchData();
            if (this.OSSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OSSelect1.GetInt32(0);
            }
            this.OSSelect1.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDOSVRSTA(int iDOSVRSTA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSSelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OS] WITH (NOLOCK) WHERE [IDOSVRSTA] = @IDOSVRSTA ", false);
            if (this.cmOSSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSVRSTA", DbType.Int32));
            }
            this.cmOSSelect2.SetParameter(0, iDOSVRSTA);
            this.OSSelect2 = this.cmOSSelect2.FetchData();
            if (this.OSSelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OSSelect2.GetInt32(0);
            }
            this.OSSelect2.Close();
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

        public virtual int GetRecordCountByIDAMSKUPINE(int iDAMSKUPINE)
        {
            int internalRecordCountByIDAMSKUPINE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDAMSKUPINE = this.GetInternalRecordCountByIDAMSKUPINE(iDAMSKUPINE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDAMSKUPINE;
        }

        public virtual int GetRecordCountByIDOSVRSTA(int iDOSVRSTA)
        {
            int internalRecordCountByIDOSVRSTA;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDOSVRSTA = this.GetInternalRecordCountByIDOSVRSTA(iDOSVRSTA);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDOSVRSTA;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound269 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__OSDATUMDOKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSKOLICINAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSSTOPAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSOSNOVICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSDUGUJEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSPOTRAZUJEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSOPISOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__RASHODLOKACIJEIDLOKACIJEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove35 = false;
            this._Condition = false;
            this.RcdFound275 = 0;
            this.m_SubSelTopString275 = "";
            this.m__NAZIVOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DATUMNABAVKEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DATUMUPORABEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NAPOMENAOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDAMSKUPINEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDOSVRSTAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.OSSet = new OSDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertOs()
        {
            this.CheckOptimisticConcurrencyOs();
            this.CheckExtendedTableOs();
            this.AfterConfirmOs();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [OS] ([INVBROJ], [NAZIVOS], [DATUMNABAVKE], [DATUMUPORABE], [NAPOMENAOS], [IDAMSKUPINE], [IDOSVRSTA]) VALUES (@INVBROJ, @NAZIVOS, @DATUMNABAVKE, @DATUMUPORABE, @NAPOMENAOS, @IDAMSKUPINE, @IDOSVRSTA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMNABAVKE", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMUPORABE", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAPOMENAOS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAMSKUPINE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSVRSTA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOS["INVBROJ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOS["NAZIVOS"]));
            command.SetParameterDateObject(2, RuntimeHelpers.GetObjectValue(this.rowOS["DATUMNABAVKE"]));
            command.SetParameterDateObject(3, RuntimeHelpers.GetObjectValue(this.rowOS["DATUMUPORABE"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOS["NAPOMENAOS"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowOS["IDAMSKUPINE"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowOS["IDOSVRSTA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new OSDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsOs();
            }
            this.OnOSUpdated(new OSEventArgs(this.rowOS, StatementType.Insert));
            this.ProcessLevelOs();
        }

        private void InsertOstemeljnica()
        {
            this.CheckOptimisticConcurrencyOstemeljnica();
            this.CheckExtendedTableOstemeljnica();
            this.AfterConfirmOstemeljnica();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [OSTEMELJNICA] ([INVBROJ], [OSBROJDOKUMENTA], [OSDATUMDOK], [OSKOLICINA], [OSSTOPA], [OSOSNOVICA], [OSDUGUJE], [OSPOTRAZUJE], [OSOPIS], [IDOSDOKUMENT], [RASHODLOKACIJEIDLOKACIJE]) VALUES (@INVBROJ, @OSBROJDOKUMENTA, @OSDATUMDOK, @OSKOLICINA, @OSSTOPA, @OSOSNOVICA, @OSDUGUJE, @OSPOTRAZUJE, @OSOPIS, @IDOSDOKUMENT, @RASHODLOKACIJEIDLOKACIJE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSBROJDOKUMENTA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSDATUMDOK", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSKOLICINA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSSTOPA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSOSNOVICA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSDUGUJE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSPOTRAZUJE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSOPIS", DbType.String, 40));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RASHODLOKACIJEIDLOKACIJE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["INVBROJ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSBROJDOKUMENTA"]));
            command.SetParameterDateObject(2, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSDATUMDOK"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSKOLICINA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSSTOPA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSOSNOVICA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSDUGUJE"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSPOTRAZUJE"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSOPIS"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["IDOSDOKUMENT"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["RASHODLOKACIJEIDLOKACIJE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new OSTEMELJNICADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsOstemeljnica();
            }
            this.OnOSTEMELJNICAUpdated(new OSTEMELJNICAEventArgs(this.rowOSTEMELJNICA, StatementType.Insert));
        }

        private void LoadByIDAMSKUPINE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OSSet.EnforceConstraints;
            this.OSSet.OSTEMELJNICA.BeginLoadData();
            this.OSSet.OS.BeginLoadData();
            this.ScanByIDAMSKUPINE(startRow, maxRows);
            this.OSSet.OSTEMELJNICA.EndLoadData();
            this.OSSet.OS.EndLoadData();
            this.OSSet.EnforceConstraints = enforceConstraints;
            if (this.OSSet.OS.Count > 0)
            {
                this.rowOS = this.OSSet.OS[this.OSSet.OS.Count - 1];
            }
        }

        private void LoadByIDOSVRSTA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OSSet.EnforceConstraints;
            this.OSSet.OSTEMELJNICA.BeginLoadData();
            this.OSSet.OS.BeginLoadData();
            this.ScanByIDOSVRSTA(startRow, maxRows);
            this.OSSet.OSTEMELJNICA.EndLoadData();
            this.OSSet.OS.EndLoadData();
            this.OSSet.EnforceConstraints = enforceConstraints;
            if (this.OSSet.OS.Count > 0)
            {
                this.rowOS = this.OSSet.OS[this.OSSet.OS.Count - 1];
            }
        }

        private void LoadByINVBROJ(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OSSet.EnforceConstraints;
            this.OSSet.OSTEMELJNICA.BeginLoadData();
            this.OSSet.OS.BeginLoadData();
            this.ScanByINVBROJ(startRow, maxRows);
            this.OSSet.OSTEMELJNICA.EndLoadData();
            this.OSSet.OS.EndLoadData();
            this.OSSet.EnforceConstraints = enforceConstraints;
            if (this.OSSet.OS.Count > 0)
            {
                this.rowOS = this.OSSet.OS[this.OSSet.OS.Count - 1];
            }
        }

        private void LoadChildOs(int startRow, int maxRows)
        {
            this.CreateNewRowOs();
            bool enforceConstraints = this.OSSet.EnforceConstraints;
            this.OSSet.OSTEMELJNICA.BeginLoadData();
            this.OSSet.OS.BeginLoadData();
            this.ScanStartOs(startRow, maxRows);
            this.OSSet.OSTEMELJNICA.EndLoadData();
            this.OSSet.OS.EndLoadData();
            this.OSSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildOstemeljnica()
        {
            this.CreateNewRowOstemeljnica();
            this.ScanStartOstemeljnica();
        }

        private void LoadDataOs(int maxRows)
        {
            int num = 0;
            if (this.RcdFound269 != 0)
            {
                this.ScanLoadOs();
                while ((this.RcdFound269 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowOs();
                    this.CreateNewRowOs();
                    this.ScanNextOs();
                }
            }
            if (num > 0)
            {
                this.RcdFound269 = 1;
            }
            this.ScanEndOs();
            if (this.OSSet.OS.Count > 0)
            {
                this.rowOS = this.OSSet.OS[this.OSSet.OS.Count - 1];
            }
        }

        private void LoadDataOstemeljnica()
        {
            while (this.RcdFound275 != 0)
            {
                this.LoadRowOstemeljnica();
                this.CreateNewRowOstemeljnica();
                this.ScanNextOstemeljnica();
            }
            this.ScanEndOstemeljnica();
        }

        private void LoadOs()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [OPISAMSKUPINE], [AMSKUPINASTOPA], [KTONABAVKEIDKONTO], [KTOISPRAVKAIDKONTO], [KTOIZVORAIDKONTO] FROM [AMSKUPINE] WITH (NOLOCK) WHERE [IDAMSKUPINE] = @IDAMSKUPINE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAMSKUPINE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOS["IDAMSKUPINE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowOS["OPISAMSKUPINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowOS["AMSKUPINASTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
                this.rowOS["KTONABAVKEIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))));
                this.rowOS["KTOISPRAVKAIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3))));
                this.rowOS["KTOIZVORAIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))));
            }
            reader.Close();
        }

        private void LoadRowOs()
        {
            this.AddRowOs();
        }

        private void LoadRowOstemeljnica()
        {
            this.AddRowOstemeljnica();
        }

        private void OnDeleteControlsOs()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [OPISAMSKUPINE], [AMSKUPINASTOPA], [KTONABAVKEIDKONTO], [KTOISPRAVKAIDKONTO], [KTOIZVORAIDKONTO] FROM [AMSKUPINE] WITH (NOLOCK) WHERE [IDAMSKUPINE] = @IDAMSKUPINE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAMSKUPINE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOS["IDAMSKUPINE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowOS["OPISAMSKUPINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowOS["AMSKUPINASTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
                this.rowOS["KTONABAVKEIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))));
                this.rowOS["KTOISPRAVKAIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3))));
                this.rowOS["KTOIZVORAIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))));
            }
            reader.Close();
        }

        private void OnDeleteControlsOstemeljnica()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVOSDOKUMENT] FROM [OSDOKUMENT] WITH (NOLOCK) WHERE [IDOSDOKUMENT] = @IDOSDOKUMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSDOKUMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["IDOSDOKUMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowOSTEMELJNICA["NAZIVOSDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void OnOSTEMELJNICAUpdated(OSTEMELJNICAEventArgs e)
        {
            if (this.OSTEMELJNICAUpdated != null)
            {
                OSTEMELJNICAUpdateEventHandler oSTEMELJNICAUpdatedEvent = this.OSTEMELJNICAUpdated;
                if (oSTEMELJNICAUpdatedEvent != null)
                {
                    oSTEMELJNICAUpdatedEvent(this, e);
                }
            }
        }

        private void OnOSTEMELJNICAUpdating(OSTEMELJNICAEventArgs e)
        {
            if (this.OSTEMELJNICAUpdating != null)
            {
                OSTEMELJNICAUpdateEventHandler oSTEMELJNICAUpdatingEvent = this.OSTEMELJNICAUpdating;
                if (oSTEMELJNICAUpdatingEvent != null)
                {
                    oSTEMELJNICAUpdatingEvent(this, e);
                }
            }
        }

        private void OnOSUpdated(OSEventArgs e)
        {
            if (this.OSUpdated != null)
            {
                OSUpdateEventHandler oSUpdatedEvent = this.OSUpdated;
                if (oSUpdatedEvent != null)
                {
                    oSUpdatedEvent(this, e);
                }
            }
        }

        private void OnOSUpdating(OSEventArgs e)
        {
            if (this.OSUpdating != null)
            {
                OSUpdateEventHandler oSUpdatingEvent = this.OSUpdating;
                if (oSUpdatingEvent != null)
                {
                    oSUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelOs()
        {
            this.sMode269 = this.Gx_mode;
            this.ProcessNestedLevelOstemeljnica();
            this.Gx_mode = this.sMode269;
        }

        private void ProcessNestedLevelOstemeljnica()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.OSSet.OSTEMELJNICA.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowOSTEMELJNICA = (OSDataSet.OSTEMELJNICARow) current;
                    if (Helpers.IsRowChanged(this.rowOSTEMELJNICA))
                    {
                        bool flag = false;
                        if (this.rowOSTEMELJNICA.RowState != DataRowState.Deleted)
                        {
                            this.rowOSTEMELJNICA["OSDATUMDOK"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSDATUMDOK"])));
                        }
                        if (this.rowOSTEMELJNICA.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowOSTEMELJNICA.INVBROJ == this.rowOS.INVBROJ;
                        }
                        else
                        {
                            flag = this.rowOSTEMELJNICA["INVBROJ", DataRowVersion.Original].Equals(this.rowOS.INVBROJ);
                        }
                        if (flag)
                        {
                            this.ReadRowOstemeljnica();
                            if (this.rowOSTEMELJNICA.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertOstemeljnica();
                            }
                            else
                            {
                                if (this._Gxremove35)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteOstemeljnica();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateOstemeljnica();
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

        private void ReadRowOs()
        {
            this.Gx_mode = Mode.FromRowState(this.rowOS.RowState);
            if (this.rowOS.RowState != DataRowState.Deleted)
            {
                this.rowOS["DATUMNABAVKE"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowOS["DATUMNABAVKE"])));
                this.rowOS["DATUMUPORABE"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowOS["DATUMUPORABE"])));
            }
            if (this.rowOS.RowState != DataRowState.Added)
            {
                this.m__NAZIVOSOriginal = RuntimeHelpers.GetObjectValue(this.rowOS["NAZIVOS", DataRowVersion.Original]);
                this.m__DATUMNABAVKEOriginal = RuntimeHelpers.GetObjectValue(this.rowOS["DATUMNABAVKE", DataRowVersion.Original]);
                this.m__DATUMUPORABEOriginal = RuntimeHelpers.GetObjectValue(this.rowOS["DATUMUPORABE", DataRowVersion.Original]);
                this.m__NAPOMENAOSOriginal = RuntimeHelpers.GetObjectValue(this.rowOS["NAPOMENAOS", DataRowVersion.Original]);
                this.m__IDAMSKUPINEOriginal = RuntimeHelpers.GetObjectValue(this.rowOS["IDAMSKUPINE", DataRowVersion.Original]);
                this.m__IDOSVRSTAOriginal = RuntimeHelpers.GetObjectValue(this.rowOS["IDOSVRSTA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVOSOriginal = RuntimeHelpers.GetObjectValue(this.rowOS["NAZIVOS"]);
                this.m__DATUMNABAVKEOriginal = RuntimeHelpers.GetObjectValue(this.rowOS["DATUMNABAVKE"]);
                this.m__DATUMUPORABEOriginal = RuntimeHelpers.GetObjectValue(this.rowOS["DATUMUPORABE"]);
                this.m__NAPOMENAOSOriginal = RuntimeHelpers.GetObjectValue(this.rowOS["NAPOMENAOS"]);
                this.m__IDAMSKUPINEOriginal = RuntimeHelpers.GetObjectValue(this.rowOS["IDAMSKUPINE"]);
                this.m__IDOSVRSTAOriginal = RuntimeHelpers.GetObjectValue(this.rowOS["IDOSVRSTA"]);
            }
            this._Gxremove = this.rowOS.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowOS = (OSDataSet.OSRow) DataSetUtil.CloneOriginalDataRow(this.rowOS);
            }
        }

        private void ReadRowOstemeljnica()
        {
            this.Gx_mode = Mode.FromRowState(this.rowOSTEMELJNICA.RowState);
            if (this.rowOSTEMELJNICA.RowState != DataRowState.Added)
            {
                this.m__OSDATUMDOKOriginal = RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSDATUMDOK", DataRowVersion.Original]);
                this.m__OSKOLICINAOriginal = RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSKOLICINA", DataRowVersion.Original]);
                this.m__OSSTOPAOriginal = RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSSTOPA", DataRowVersion.Original]);
                this.m__OSOSNOVICAOriginal = RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSOSNOVICA", DataRowVersion.Original]);
                this.m__OSDUGUJEOriginal = RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSDUGUJE", DataRowVersion.Original]);
                this.m__OSPOTRAZUJEOriginal = RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSPOTRAZUJE", DataRowVersion.Original]);
                this.m__OSOPISOriginal = RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSOPIS", DataRowVersion.Original]);
                this.m__RASHODLOKACIJEIDLOKACIJEOriginal = RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["RASHODLOKACIJEIDLOKACIJE", DataRowVersion.Original]);
            }
            else
            {
                this.m__OSDATUMDOKOriginal = RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSDATUMDOK"]);
                this.m__OSKOLICINAOriginal = RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSKOLICINA"]);
                this.m__OSSTOPAOriginal = RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSSTOPA"]);
                this.m__OSOSNOVICAOriginal = RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSOSNOVICA"]);
                this.m__OSDUGUJEOriginal = RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSDUGUJE"]);
                this.m__OSPOTRAZUJEOriginal = RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSPOTRAZUJE"]);
                this.m__OSOPISOriginal = RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSOPIS"]);
                this.m__RASHODLOKACIJEIDLOKACIJEOriginal = RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["RASHODLOKACIJEIDLOKACIJE"]);
            }
            this._Gxremove35 = this.rowOSTEMELJNICA.RowState == DataRowState.Deleted;
            if (this._Gxremove35)
            {
                this.rowOSTEMELJNICA = (OSDataSet.OSTEMELJNICARow) DataSetUtil.CloneOriginalDataRow(this.rowOSTEMELJNICA);
            }
        }

        private void ScanByIDAMSKUPINE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDAMSKUPINE] = @IDAMSKUPINE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString269 + "  FROM ([OS] TM1 WITH (NOLOCK) INNER JOIN [AMSKUPINE] T2 WITH (NOLOCK) ON T2.[IDAMSKUPINE] = TM1.[IDAMSKUPINE])" + this.m_WhereString + " ORDER BY TM1.[INVBROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString269, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[INVBROJ] ) AS DK_PAGENUM   FROM ([OS] TM1 WITH (NOLOCK) INNER JOIN [AMSKUPINE] T2 WITH (NOLOCK) ON T2.[IDAMSKUPINE] = TM1.[IDAMSKUPINE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString269 + " FROM ([OS] TM1 WITH (NOLOCK) INNER JOIN [AMSKUPINE] T2 WITH (NOLOCK) ON T2.[IDAMSKUPINE] = TM1.[IDAMSKUPINE])" + this.m_WhereString + " ORDER BY TM1.[INVBROJ] ";
            }
            this.cmOSSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOSSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAMSKUPINE", DbType.Int32));
            }
            this.cmOSSelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOS["IDAMSKUPINE"]));
            this.OSSelect6 = this.cmOSSelect6.FetchData();
            this.RcdFound269 = 0;
            this.ScanLoadOs();
            this.LoadDataOs(maxRows);
            if (this.RcdFound269 > 0)
            {
                this.SubLvlScanStartOstemeljnica(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDAMSKUPINEOs(this.cmOSTEMELJNICASelect2);
                this.SubLvlFetchOstemeljnica();
                this.SubLoadDataOstemeljnica();
            }
        }

        private void ScanByIDOSVRSTA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDOSVRSTA] = @IDOSVRSTA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString269 + "  FROM ([OS] TM1 WITH (NOLOCK) INNER JOIN [AMSKUPINE] T2 WITH (NOLOCK) ON T2.[IDAMSKUPINE] = TM1.[IDAMSKUPINE])" + this.m_WhereString + " ORDER BY TM1.[INVBROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString269, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[INVBROJ] ) AS DK_PAGENUM   FROM ([OS] TM1 WITH (NOLOCK) INNER JOIN [AMSKUPINE] T2 WITH (NOLOCK) ON T2.[IDAMSKUPINE] = TM1.[IDAMSKUPINE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString269 + " FROM ([OS] TM1 WITH (NOLOCK) INNER JOIN [AMSKUPINE] T2 WITH (NOLOCK) ON T2.[IDAMSKUPINE] = TM1.[IDAMSKUPINE])" + this.m_WhereString + " ORDER BY TM1.[INVBROJ] ";
            }
            this.cmOSSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOSSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSVRSTA", DbType.Int32));
            }
            this.cmOSSelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOS["IDOSVRSTA"]));
            this.OSSelect6 = this.cmOSSelect6.FetchData();
            this.RcdFound269 = 0;
            this.ScanLoadOs();
            this.LoadDataOs(maxRows);
            if (this.RcdFound269 > 0)
            {
                this.SubLvlScanStartOstemeljnica(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDOSVRSTAOs(this.cmOSTEMELJNICASelect2);
                this.SubLvlFetchOstemeljnica();
                this.SubLoadDataOstemeljnica();
            }
        }

        private void ScanByINVBROJ(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[INVBROJ] = @INVBROJ";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString269 + "  FROM ([OS] TM1 WITH (NOLOCK) INNER JOIN [AMSKUPINE] T2 WITH (NOLOCK) ON T2.[IDAMSKUPINE] = TM1.[IDAMSKUPINE])" + this.m_WhereString + " ORDER BY TM1.[INVBROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString269, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[INVBROJ] ) AS DK_PAGENUM   FROM ([OS] TM1 WITH (NOLOCK) INNER JOIN [AMSKUPINE] T2 WITH (NOLOCK) ON T2.[IDAMSKUPINE] = TM1.[IDAMSKUPINE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString269 + " FROM ([OS] TM1 WITH (NOLOCK) INNER JOIN [AMSKUPINE] T2 WITH (NOLOCK) ON T2.[IDAMSKUPINE] = TM1.[IDAMSKUPINE])" + this.m_WhereString + " ORDER BY TM1.[INVBROJ] ";
            }
            this.cmOSSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOSSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
            }
            this.cmOSSelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOS["INVBROJ"]));
            this.OSSelect6 = this.cmOSSelect6.FetchData();
            this.RcdFound269 = 0;
            this.ScanLoadOs();
            this.LoadDataOs(maxRows);
            if (this.RcdFound269 > 0)
            {
                this.SubLvlScanStartOstemeljnica(this.m_WhereString, startRow, maxRows);
                this.SetParametersINVBROJOs(this.cmOSTEMELJNICASelect2);
                this.SubLvlFetchOstemeljnica();
                this.SubLoadDataOstemeljnica();
            }
        }

        private void ScanEndOs()
        {
            this.OSSelect6.Close();
        }

        private void ScanEndOstemeljnica()
        {
            this.OSTEMELJNICASelect2.Close();
        }

        private void ScanLoadOs()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmOSSelect6.HasMoreRows)
            {
                this.RcdFound269 = 1;
                this.rowOS["INVBROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt64(this.OSSelect6, 0));
                this.rowOS["NAZIVOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSSelect6, 1));
                this.rowOS["DATUMNABAVKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.OSSelect6, 2));
                this.rowOS["DATUMUPORABE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.OSSelect6, 3));
                this.rowOS["NAPOMENAOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSSelect6, 4));
                this.rowOS["OPISAMSKUPINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSSelect6, 5));
                this.rowOS["AMSKUPINASTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OSSelect6, 6));
                this.rowOS["IDAMSKUPINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OSSelect6, 7));
                this.rowOS["KTONABAVKEIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSSelect6, 8))));
                this.rowOS["KTOISPRAVKAIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSSelect6, 9))));
                this.rowOS["KTOIZVORAIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSSelect6, 10))));
                this.rowOS["IDOSVRSTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OSSelect6, 11));
                this.rowOS["OPISAMSKUPINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSSelect6, 5));
                this.rowOS["AMSKUPINASTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OSSelect6, 6));
                this.rowOS["KTONABAVKEIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSSelect6, 8))));
                this.rowOS["KTOISPRAVKAIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSSelect6, 9))));
                this.rowOS["KTOIZVORAIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSSelect6, 10))));
            }
        }

        private void ScanLoadOstemeljnica()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmOSTEMELJNICASelect2.HasMoreRows)
            {
                this.RcdFound275 = 1;
                this.rowOSTEMELJNICA["INVBROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt64(this.OSTEMELJNICASelect2, 0));
                this.rowOSTEMELJNICA["OSBROJDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OSTEMELJNICASelect2, 1));
                this.rowOSTEMELJNICA["OSDATUMDOK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.OSTEMELJNICASelect2, 2));
                this.rowOSTEMELJNICA["OSKOLICINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OSTEMELJNICASelect2, 3));
                this.rowOSTEMELJNICA["OSSTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OSTEMELJNICASelect2, 4));
                this.rowOSTEMELJNICA["OSOSNOVICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OSTEMELJNICASelect2, 5));
                this.rowOSTEMELJNICA["OSDUGUJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OSTEMELJNICASelect2, 6));
                this.rowOSTEMELJNICA["OSPOTRAZUJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OSTEMELJNICASelect2, 7));
                this.rowOSTEMELJNICA["OSOPIS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSTEMELJNICASelect2, 8));
                this.rowOSTEMELJNICA["NAZIVOSDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSTEMELJNICASelect2, 9));
                this.rowOSTEMELJNICA["IDOSDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OSTEMELJNICASelect2, 10));
                this.rowOSTEMELJNICA["RASHODLOKACIJEIDLOKACIJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OSTEMELJNICASelect2, 11));
                this.rowOSTEMELJNICA["NAZIVOSDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSTEMELJNICASelect2, 9));
            }
        }

        private void ScanNextOs()
        {
            this.cmOSSelect6.HasMoreRows = this.OSSelect6.Read();
            this.RcdFound269 = 0;
            this.ScanLoadOs();
        }

        private void ScanNextOstemeljnica()
        {
            this.cmOSTEMELJNICASelect2.HasMoreRows = this.OSTEMELJNICASelect2.Read();
            this.RcdFound275 = 0;
            this.ScanLoadOstemeljnica();
        }

        private void ScanStartOs(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString269 + "  FROM ([OS] TM1 WITH (NOLOCK) INNER JOIN [AMSKUPINE] T2 WITH (NOLOCK) ON T2.[IDAMSKUPINE] = TM1.[IDAMSKUPINE])" + this.m_WhereString + " ORDER BY TM1.[INVBROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString269, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[INVBROJ] ) AS DK_PAGENUM   FROM ([OS] TM1 WITH (NOLOCK) INNER JOIN [AMSKUPINE] T2 WITH (NOLOCK) ON T2.[IDAMSKUPINE] = TM1.[IDAMSKUPINE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString269 + " FROM ([OS] TM1 WITH (NOLOCK) INNER JOIN [AMSKUPINE] T2 WITH (NOLOCK) ON T2.[IDAMSKUPINE] = TM1.[IDAMSKUPINE])" + this.m_WhereString + " ORDER BY TM1.[INVBROJ] ";
            }
            this.cmOSSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.OSSelect6 = this.cmOSSelect6.FetchData();
            this.RcdFound269 = 0;
            this.ScanLoadOs();
            this.LoadDataOs(maxRows);
            if (this.RcdFound269 > 0)
            {
                this.SubLvlScanStartOstemeljnica(this.m_WhereString, startRow, maxRows);
                this.SetParametersOsOs(this.cmOSTEMELJNICASelect2);
                this.SubLvlFetchOstemeljnica();
                this.SubLoadDataOstemeljnica();
            }
        }

        private void ScanStartOstemeljnica()
        {
            this.cmOSTEMELJNICASelect2 = this.connDefault.GetCommand("SELECT T1.[INVBROJ], T1.[OSBROJDOKUMENTA], T1.[OSDATUMDOK], T1.[OSKOLICINA], T1.[OSSTOPA], T1.[OSOSNOVICA], T1.[OSDUGUJE], T1.[OSPOTRAZUJE], T1.[OSOPIS], T2.[NAZIVOSDOKUMENT], T1.[IDOSDOKUMENT], T1.[RASHODLOKACIJEIDLOKACIJE] AS RASHODLOKACIJEIDLOKACIJE FROM ([OSTEMELJNICA] T1 WITH (NOLOCK) INNER JOIN [OSDOKUMENT] T2 WITH (NOLOCK) ON T2.[IDOSDOKUMENT] = T1.[IDOSDOKUMENT]) WHERE T1.[INVBROJ] = @INVBROJ ORDER BY T1.[INVBROJ], T1.[IDOSDOKUMENT], T1.[OSBROJDOKUMENTA] ", false);
            if (this.cmOSTEMELJNICASelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSTEMELJNICASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
            }
            this.cmOSTEMELJNICASelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["INVBROJ"]));
            this.OSTEMELJNICASelect2 = this.cmOSTEMELJNICASelect2.FetchData();
            this.RcdFound275 = 0;
            this.ScanLoadOstemeljnica();
        }

        private void SetParametersIDAMSKUPINEOs(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAMSKUPINE", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOS["IDAMSKUPINE"]));
        }

        private void SetParametersIDOSVRSTAOs(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSVRSTA", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOS["IDOSVRSTA"]));
        }

        private void SetParametersINVBROJOs(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOS["INVBROJ"]));
        }

        private void SetParametersOsOs(ReadWriteCommand m_Command)
        {
        }

        private void SkipNextOstemeljnica()
        {
            this.cmOSTEMELJNICASelect2.HasMoreRows = this.OSTEMELJNICASelect2.Read();
            this.RcdFound275 = 0;
            if (this.cmOSTEMELJNICASelect2.HasMoreRows)
            {
                this.RcdFound275 = 1;
            }
        }

        private void SubLoadDataOstemeljnica()
        {
            while (this.RcdFound275 != 0)
            {
                this.LoadRowOstemeljnica();
                this.CreateNewRowOstemeljnica();
                this.ScanNextOstemeljnica();
            }
            this.ScanEndOstemeljnica();
        }

        private void SubLvlFetchOstemeljnica()
        {
            this.CreateNewRowOstemeljnica();
            this.OSTEMELJNICASelect2 = this.cmOSTEMELJNICASelect2.FetchData();
            this.RcdFound275 = 0;
            this.ScanLoadOstemeljnica();
        }

        private void SubLvlScanStartOstemeljnica(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString275 = "(SELECT TOP " + maxRows.ToString() + " TM1.[INVBROJ]  FROM [OS]  TM1 " + this.m_WhereString + " ORDER BY TM1.[INVBROJ] )";
                    this.scmdbuf = "SELECT T1.[INVBROJ], T1.[OSBROJDOKUMENTA], T1.[OSDATUMDOK], T1.[OSKOLICINA], T1.[OSSTOPA], T1.[OSOSNOVICA], T1.[OSDUGUJE], T1.[OSPOTRAZUJE], T1.[OSOPIS], T3.[NAZIVOSDOKUMENT], T1.[IDOSDOKUMENT], T1.[RASHODLOKACIJEIDLOKACIJE] AS RASHODLOKACIJEIDLOKACIJE FROM (([OSTEMELJNICA] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString275 + "  TMX ON TMX.[INVBROJ] = T1.[INVBROJ]) INNER JOIN [OSDOKUMENT] T3 WITH (NOLOCK) ON T3.[IDOSDOKUMENT] = T1.[IDOSDOKUMENT]) ORDER BY T1.[INVBROJ], T1.[IDOSDOKUMENT], T1.[OSBROJDOKUMENTA]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[INVBROJ], ROW_NUMBER() OVER  (  ORDER BY TM1.[INVBROJ]  ) AS DK_PAGENUM   FROM [OS]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString275 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[INVBROJ], T1.[OSBROJDOKUMENTA], T1.[OSDATUMDOK], T1.[OSKOLICINA], T1.[OSSTOPA], T1.[OSOSNOVICA], T1.[OSDUGUJE], T1.[OSPOTRAZUJE], T1.[OSOPIS], T3.[NAZIVOSDOKUMENT], T1.[IDOSDOKUMENT], T1.[RASHODLOKACIJEIDLOKACIJE] AS RASHODLOKACIJEIDLOKACIJE FROM (([OSTEMELJNICA] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString275 + "  TMX ON TMX.[INVBROJ] = T1.[INVBROJ]) INNER JOIN [OSDOKUMENT] T3 WITH (NOLOCK) ON T3.[IDOSDOKUMENT] = T1.[IDOSDOKUMENT]) ORDER BY T1.[INVBROJ], T1.[IDOSDOKUMENT], T1.[OSBROJDOKUMENTA]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString275 = "[OS]";
                this.scmdbuf = "SELECT T1.[INVBROJ], T1.[OSBROJDOKUMENTA], T1.[OSDATUMDOK], T1.[OSKOLICINA], T1.[OSSTOPA], T1.[OSOSNOVICA], T1.[OSDUGUJE], T1.[OSPOTRAZUJE], T1.[OSOPIS], T3.[NAZIVOSDOKUMENT], T1.[IDOSDOKUMENT], T1.[RASHODLOKACIJEIDLOKACIJE] AS RASHODLOKACIJEIDLOKACIJE FROM (([OSTEMELJNICA] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString275 + "  TM1 WITH (NOLOCK) ON TM1.[INVBROJ] = T1.[INVBROJ]) INNER JOIN [OSDOKUMENT] T3 WITH (NOLOCK) ON T3.[IDOSDOKUMENT] = T1.[IDOSDOKUMENT])" + this.m_WhereString + " ORDER BY T1.[INVBROJ], T1.[IDOSDOKUMENT], T1.[OSBROJDOKUMENTA] ";
            }
            this.cmOSTEMELJNICASelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.OSSet = (OSDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.OSSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.OSSet.OS.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        OSDataSet.OSRow current = (OSDataSet.OSRow) enumerator.Current;
                        this.rowOS = current;
                        if (Helpers.IsRowChanged(this.rowOS))
                        {
                            this.ReadRowOs();
                            if (this.rowOS.RowState == DataRowState.Added)
                            {
                                this.InsertOs();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateOs();
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
                
                //this.connDefault.Rollback();
                
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        private void UpdateOs()
        {
            this.CheckOptimisticConcurrencyOs();
            this.CheckExtendedTableOs();
            this.AfterConfirmOs();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [OS] SET [NAZIVOS]=@NAZIVOS, [DATUMNABAVKE]=@DATUMNABAVKE, [DATUMUPORABE]=@DATUMUPORABE, [NAPOMENAOS]=@NAPOMENAOS, [IDAMSKUPINE]=@IDAMSKUPINE, [IDOSVRSTA]=@IDOSVRSTA  WHERE [INVBROJ] = @INVBROJ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMNABAVKE", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMUPORABE", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAPOMENAOS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAMSKUPINE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSVRSTA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOS["NAZIVOS"]));
            command.SetParameterDateObject(1, RuntimeHelpers.GetObjectValue(this.rowOS["DATUMNABAVKE"]));
            command.SetParameterDateObject(2, RuntimeHelpers.GetObjectValue(this.rowOS["DATUMUPORABE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOS["NAPOMENAOS"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOS["IDAMSKUPINE"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowOS["IDOSVRSTA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowOS["INVBROJ"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsOs();
            }
            this.OnOSUpdated(new OSEventArgs(this.rowOS, StatementType.Update));
            this.ProcessLevelOs();
        }

        private void UpdateOstemeljnica()
        {
            this.CheckOptimisticConcurrencyOstemeljnica();
            this.CheckExtendedTableOstemeljnica();
            this.AfterConfirmOstemeljnica();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [OSTEMELJNICA] SET [OSDATUMDOK]=@OSDATUMDOK, [OSKOLICINA]=@OSKOLICINA, [OSSTOPA]=@OSSTOPA, [OSOSNOVICA]=@OSOSNOVICA, [OSDUGUJE]=@OSDUGUJE, [OSPOTRAZUJE]=@OSPOTRAZUJE, [OSOPIS]=@OSOPIS, [RASHODLOKACIJEIDLOKACIJE]=@RASHODLOKACIJEIDLOKACIJE  WHERE [INVBROJ] = @INVBROJ AND [IDOSDOKUMENT] = @IDOSDOKUMENT AND [OSBROJDOKUMENTA] = @OSBROJDOKUMENTA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSDATUMDOK", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSKOLICINA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSSTOPA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSOSNOVICA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSDUGUJE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSPOTRAZUJE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSOPIS", DbType.String, 40));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RASHODLOKACIJEIDLOKACIJE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSBROJDOKUMENTA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameterDateObject(0, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSDATUMDOK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSKOLICINA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSSTOPA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSOSNOVICA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSDUGUJE"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSPOTRAZUJE"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSOPIS"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["RASHODLOKACIJEIDLOKACIJE"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["INVBROJ"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["IDOSDOKUMENT"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowOSTEMELJNICA["OSBROJDOKUMENTA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsOstemeljnica();
            }
            this.OnOSTEMELJNICAUpdated(new OSTEMELJNICAEventArgs(this.rowOSTEMELJNICA, StatementType.Update));
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
        public class AMSKUPINEForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public AMSKUPINEForeignKeyNotFoundException()
            {
            }

            public AMSKUPINEForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected AMSKUPINEForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public AMSKUPINEForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public ForeignKeyNotFoundException()
            {
            }

            public ForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected ForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class LOKACIJEForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public LOKACIJEForeignKeyNotFoundException()
            {
            }

            public LOKACIJEForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected LOKACIJEForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public LOKACIJEForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSDataChangedException : DataChangedException
        {
            public OSDataChangedException()
            {
            }

            public OSDataChangedException(string message) : base(message)
            {
            }

            protected OSDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSDataLockedException : DataLockedException
        {
            public OSDataLockedException()
            {
            }

            public OSDataLockedException(string message) : base(message)
            {
            }

            protected OSDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSDOKUMENTForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public OSDOKUMENTForeignKeyNotFoundException()
            {
            }

            public OSDOKUMENTForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected OSDOKUMENTForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSDOKUMENTForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSDuplicateKeyException : DuplicateKeyException
        {
            public OSDuplicateKeyException()
            {
            }

            public OSDuplicateKeyException(string message) : base(message)
            {
            }

            protected OSDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class OSEventArgs : EventArgs
        {
            private OSDataSet.OSRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public OSEventArgs(OSDataSet.OSRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OSDataSet.OSRow Row
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
        public class OSNotFoundException : DataNotFoundException
        {
            public OSNotFoundException()
            {
            }

            public OSNotFoundException(string message) : base(message)
            {
            }

            protected OSNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSRAZMJESTAJInvalidDeleteException : InvalidDeleteException
        {
            public OSRAZMJESTAJInvalidDeleteException()
            {
            }

            public OSRAZMJESTAJInvalidDeleteException(string message) : base(message)
            {
            }

            protected OSRAZMJESTAJInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSRAZMJESTAJInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSTEMELJNICADataChangedException : DataChangedException
        {
            public OSTEMELJNICADataChangedException()
            {
            }

            public OSTEMELJNICADataChangedException(string message) : base(message)
            {
            }

            protected OSTEMELJNICADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSTEMELJNICADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSTEMELJNICADataLockedException : DataLockedException
        {
            public OSTEMELJNICADataLockedException()
            {
            }

            public OSTEMELJNICADataLockedException(string message) : base(message)
            {
            }

            protected OSTEMELJNICADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSTEMELJNICADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSTEMELJNICADuplicateKeyException : DuplicateKeyException
        {
            public OSTEMELJNICADuplicateKeyException()
            {
            }

            public OSTEMELJNICADuplicateKeyException(string message) : base(message)
            {
            }

            protected OSTEMELJNICADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSTEMELJNICADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class OSTEMELJNICAEventArgs : EventArgs
        {
            private OSDataSet.OSTEMELJNICARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public OSTEMELJNICAEventArgs(OSDataSet.OSTEMELJNICARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OSDataSet.OSTEMELJNICARow Row
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

        public delegate void OSTEMELJNICAUpdateEventHandler(object sender, OSDataAdapter.OSTEMELJNICAEventArgs e);

        public delegate void OSUpdateEventHandler(object sender, OSDataAdapter.OSEventArgs e);

        [Serializable]
        public class OSVRSTAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public OSVRSTAForeignKeyNotFoundException()
            {
            }

            public OSVRSTAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected OSVRSTAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSVRSTAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

