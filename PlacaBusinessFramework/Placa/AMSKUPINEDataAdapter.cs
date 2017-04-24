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

    public class AMSKUPINEDataAdapter : IDataAdapter, IAMSKUPINEDataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private IDataReader AMSKUPINESelect1;
        private IDataReader AMSKUPINESelect2;
        private IDataReader AMSKUPINESelect3;
        private IDataReader AMSKUPINESelect4;
        private IDataReader AMSKUPINESelect7;
        private AMSKUPINEDataSet AMSKUPINESet;
        private ReadWriteCommand cmAMSKUPINESelect1;
        private ReadWriteCommand cmAMSKUPINESelect2;
        private ReadWriteCommand cmAMSKUPINESelect3;
        private ReadWriteCommand cmAMSKUPINESelect4;
        private ReadWriteCommand cmAMSKUPINESelect7;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__AMSKUPINASTOPAOriginal;
        private object m__KRATKASIFRAOriginal;
        private object m__KTOISPRAVKAIDKONTOOriginal;
        private object m__KTOIZVORAIDKONTOOriginal;
        private object m__KTONABAVKEIDKONTOOriginal;
        private object m__OPISAMSKUPINEOriginal;
        private readonly string m_SelectString254 = "TM1.[IDAMSKUPINE], TM1.[KRATKASIFRA], TM1.[OPISAMSKUPINE], TM1.[AMSKUPINASTOPA], TM1.[KTONABAVKEIDKONTO] AS KTONABAVKEIDKONTO, TM1.[KTOISPRAVKAIDKONTO] AS KTOISPRAVKAIDKONTO, TM1.[KTOIZVORAIDKONTO] AS KTOIZVORAIDKONTO";
        private string m_WhereString;
        private short RcdFound254;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private AMSKUPINEDataSet.AMSKUPINERow rowAMSKUPINE;
        private string scmdbuf;
        private StatementType sMode254;

        public event AMSKUPINEUpdateEventHandler AMSKUPINEUpdated;

        public event AMSKUPINEUpdateEventHandler AMSKUPINEUpdating;

        private void AddRowAmskupine()
        {
            this.AMSKUPINESet.AMSKUPINE.AddAMSKUPINERow(this.rowAMSKUPINE);
        }

        private void AfterConfirmAmskupine()
        {
            this.OnAMSKUPINEUpdating(new AMSKUPINEEventArgs(this.rowAMSKUPINE, this.Gx_mode));
        }

        private void CheckDeleteErrorsAmskupine()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [INVBROJ] FROM [OS] WITH (NOLOCK) WHERE [IDAMSKUPINE] = @IDAMSKUPINE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAMSKUPINE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["IDAMSKUPINE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new OSInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "OS" }));
            }
            reader.Close();
        }

        private void CheckExtendedTableAmskupine()
        {
            this.rowAMSKUPINE.AM = NumberUtil.ToString((long) this.rowAMSKUPINE.IDAMSKUPINE, "") + " | " + this.rowAMSKUPINE.OPISAMSKUPINE;
        }

        private void CheckIntegrityErrorsAmskupine()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKONTO] AS KTONABAVKEIDKONTO FROM [KONTO] WITH (NOLOCK) WHERE [IDKONTO] = @KTONABAVKEIDKONTO ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTONABAVKEIDKONTO", DbType.String, 14));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KTONABAVKEIDKONTO"]))));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new KONTOForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KONTO") }));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [IDKONTO] AS KTOISPRAVKAIDKONTO FROM [KONTO] WITH (NOLOCK) WHERE [IDKONTO] = @KTOISPRAVKAIDKONTO ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTOISPRAVKAIDKONTO", DbType.String, 14));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KTOISPRAVKAIDKONTO"]))));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new KONTOForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KONTO") }));
            }
            reader2.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [IDKONTO] AS KTOIZVORAIDKONTO FROM [KONTO] WITH (NOLOCK) WHERE [IDKONTO] = @KTOIZVORAIDKONTO ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTOIZVORAIDKONTO", DbType.String, 14));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KTOIZVORAIDKONTO"]))));
            IDataReader reader3 = command3.FetchData();
            if (!command3.HasMoreRows)
            {
                reader3.Close();
                throw new KONTOForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KONTO") }));
            }
            reader3.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyAmskupine()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDAMSKUPINE], [KRATKASIFRA], [OPISAMSKUPINE], [AMSKUPINASTOPA], [KTONABAVKEIDKONTO] AS KTONABAVKEIDKONTO, [KTOISPRAVKAIDKONTO] AS KTOISPRAVKAIDKONTO, [KTOIZVORAIDKONTO] AS KTOIZVORAIDKONTO FROM [AMSKUPINE] WITH (UPDLOCK) WHERE [IDAMSKUPINE] = @IDAMSKUPINE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAMSKUPINE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["IDAMSKUPINE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new AMSKUPINEDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("AMSKUPINE") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__KRATKASIFRAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPISAMSKUPINEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))) || ((!this.m__AMSKUPINASTOPAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__KTONABAVKEIDKONTOOriginal), RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4)))))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__KTOISPRAVKAIDKONTOOriginal), RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))))
                {
                    this._Condition = true;
                }
                if (this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__KTOIZVORAIDKONTOOriginal), RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6))))))
                {
                    reader.Close();
                    throw new AMSKUPINEDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("AMSKUPINE") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowAmskupine()
        {
            this.rowAMSKUPINE = this.AMSKUPINESet.AMSKUPINE.NewAMSKUPINERow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyAmskupine();
            this.OnDeleteControlsAmskupine();
            this.AfterConfirmAmskupine();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [AMSKUPINE]  WHERE [IDAMSKUPINE] = @IDAMSKUPINE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAMSKUPINE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["IDAMSKUPINE"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsAmskupine();
            }
            this.OnAMSKUPINEUpdated(new AMSKUPINEEventArgs(this.rowAMSKUPINE, StatementType.Delete));
            this.rowAMSKUPINE.Delete();
            this.sMode254 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode254;
        }

        public virtual int Fill(AMSKUPINEDataSet dataSet)
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
                    this.AMSKUPINESet = dataSet;
                    this.LoadChildAmskupine(0, -1);
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
            this.AMSKUPINESet = (AMSKUPINEDataSet) dataSet;
            if (this.AMSKUPINESet != null)
            {
                return this.Fill(this.AMSKUPINESet);
            }
            this.AMSKUPINESet = new AMSKUPINEDataSet();
            this.Fill(this.AMSKUPINESet);
            dataSet.Merge(this.AMSKUPINESet);
            return 0;
        }

        public virtual int Fill(AMSKUPINEDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDAMSKUPINE"]));
        }

        public virtual int Fill(AMSKUPINEDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDAMSKUPINE"]));
        }

        public virtual int Fill(AMSKUPINEDataSet dataSet, int iDAMSKUPINE)
        {
            if (!this.FillByIDAMSKUPINE(dataSet, iDAMSKUPINE))
            {
                throw new AMSKUPINENotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("AMSKUPINE") }));
            }
            return 0;
        }

        public virtual bool FillByIDAMSKUPINE(AMSKUPINEDataSet dataSet, int iDAMSKUPINE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.AMSKUPINESet = dataSet;
            this.rowAMSKUPINE = this.AMSKUPINESet.AMSKUPINE.NewAMSKUPINERow();
            this.rowAMSKUPINE.IDAMSKUPINE = iDAMSKUPINE;
            try
            {
                this.LoadByIDAMSKUPINE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound254 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByKTOISPRAVKAIDKONTO(AMSKUPINEDataSet dataSet, string kTOISPRAVKAIDKONTO)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.AMSKUPINESet = dataSet;
            this.rowAMSKUPINE = this.AMSKUPINESet.AMSKUPINE.NewAMSKUPINERow();
            this.rowAMSKUPINE.KTOISPRAVKAIDKONTO = kTOISPRAVKAIDKONTO;
            try
            {
                this.LoadByKTOISPRAVKAIDKONTO(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByKTOIZVORAIDKONTO(AMSKUPINEDataSet dataSet, string kTOIZVORAIDKONTO)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.AMSKUPINESet = dataSet;
            this.rowAMSKUPINE = this.AMSKUPINESet.AMSKUPINE.NewAMSKUPINERow();
            this.rowAMSKUPINE.KTOIZVORAIDKONTO = kTOIZVORAIDKONTO;
            try
            {
                this.LoadByKTOIZVORAIDKONTO(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByKTONABAVKEIDKONTO(AMSKUPINEDataSet dataSet, string kTONABAVKEIDKONTO)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.AMSKUPINESet = dataSet;
            this.rowAMSKUPINE = this.AMSKUPINESet.AMSKUPINE.NewAMSKUPINERow();
            this.rowAMSKUPINE.KTONABAVKEIDKONTO = kTONABAVKEIDKONTO;
            try
            {
                this.LoadByKTONABAVKEIDKONTO(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(AMSKUPINEDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.AMSKUPINESet = dataSet;
            try
            {
                this.LoadChildAmskupine(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByKTOISPRAVKAIDKONTO(AMSKUPINEDataSet dataSet, string kTOISPRAVKAIDKONTO, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.AMSKUPINESet = dataSet;
            this.rowAMSKUPINE = this.AMSKUPINESet.AMSKUPINE.NewAMSKUPINERow();
            this.rowAMSKUPINE.KTOISPRAVKAIDKONTO = kTOISPRAVKAIDKONTO;
            try
            {
                this.LoadByKTOISPRAVKAIDKONTO(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByKTOIZVORAIDKONTO(AMSKUPINEDataSet dataSet, string kTOIZVORAIDKONTO, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.AMSKUPINESet = dataSet;
            this.rowAMSKUPINE = this.AMSKUPINESet.AMSKUPINE.NewAMSKUPINERow();
            this.rowAMSKUPINE.KTOIZVORAIDKONTO = kTOIZVORAIDKONTO;
            try
            {
                this.LoadByKTOIZVORAIDKONTO(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByKTONABAVKEIDKONTO(AMSKUPINEDataSet dataSet, string kTONABAVKEIDKONTO, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.AMSKUPINESet = dataSet;
            this.rowAMSKUPINE = this.AMSKUPINESet.AMSKUPINE.NewAMSKUPINERow();
            this.rowAMSKUPINE.KTONABAVKEIDKONTO = kTONABAVKEIDKONTO;
            try
            {
                this.LoadByKTONABAVKEIDKONTO(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDAMSKUPINE], [KRATKASIFRA], [OPISAMSKUPINE], [AMSKUPINASTOPA], [KTONABAVKEIDKONTO] AS KTONABAVKEIDKONTO, [KTOISPRAVKAIDKONTO] AS KTOISPRAVKAIDKONTO, [KTOIZVORAIDKONTO] AS KTOIZVORAIDKONTO FROM [AMSKUPINE] WITH (NOLOCK) WHERE [IDAMSKUPINE] = @IDAMSKUPINE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAMSKUPINE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["IDAMSKUPINE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound254 = 1;
                this.rowAMSKUPINE["IDAMSKUPINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowAMSKUPINE["KRATKASIFRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowAMSKUPINE["OPISAMSKUPINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowAMSKUPINE["AMSKUPINASTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3));
                this.rowAMSKUPINE["KTONABAVKEIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))));
                this.rowAMSKUPINE["KTOISPRAVKAIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))));
                this.rowAMSKUPINE["KTOIZVORAIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6))));
                this.sMode254 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadAmskupine();
                this.Gx_mode = this.sMode254;
            }
            else
            {
                this.RcdFound254 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDAMSKUPINE";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmAMSKUPINESelect4 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [AMSKUPINE] WITH (NOLOCK) ", false);
            this.AMSKUPINESelect4 = this.cmAMSKUPINESelect4.FetchData();
            if (this.AMSKUPINESelect4.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.AMSKUPINESelect4.GetInt32(0);
            }
            this.AMSKUPINESelect4.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByKTOISPRAVKAIDKONTO(string kTOISPRAVKAIDKONTO)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmAMSKUPINESelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [AMSKUPINE] WITH (NOLOCK) WHERE [KTOISPRAVKAIDKONTO] = @KTOISPRAVKAIDKONTO ", false);
            if (this.cmAMSKUPINESelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmAMSKUPINESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTOISPRAVKAIDKONTO", DbType.String, 14));
            }
            this.cmAMSKUPINESelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(kTOISPRAVKAIDKONTO)));
            this.AMSKUPINESelect2 = this.cmAMSKUPINESelect2.FetchData();
            if (this.AMSKUPINESelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.AMSKUPINESelect2.GetInt32(0);
            }
            this.AMSKUPINESelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByKTOIZVORAIDKONTO(string kTOIZVORAIDKONTO)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmAMSKUPINESelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [AMSKUPINE] WITH (NOLOCK) WHERE [KTOIZVORAIDKONTO] = @KTOIZVORAIDKONTO ", false);
            if (this.cmAMSKUPINESelect3.IDbCommand.Parameters.Count == 0)
            {
                this.cmAMSKUPINESelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTOIZVORAIDKONTO", DbType.String, 14));
            }
            this.cmAMSKUPINESelect3.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(kTOIZVORAIDKONTO)));
            this.AMSKUPINESelect3 = this.cmAMSKUPINESelect3.FetchData();
            if (this.AMSKUPINESelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.AMSKUPINESelect3.GetInt32(0);
            }
            this.AMSKUPINESelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByKTONABAVKEIDKONTO(string kTONABAVKEIDKONTO)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmAMSKUPINESelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [AMSKUPINE] WITH (NOLOCK) WHERE [KTONABAVKEIDKONTO] = @KTONABAVKEIDKONTO ", false);
            if (this.cmAMSKUPINESelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmAMSKUPINESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTONABAVKEIDKONTO", DbType.String, 14));
            }
            this.cmAMSKUPINESelect1.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(kTONABAVKEIDKONTO)));
            this.AMSKUPINESelect1 = this.cmAMSKUPINESelect1.FetchData();
            if (this.AMSKUPINESelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.AMSKUPINESelect1.GetInt32(0);
            }
            this.AMSKUPINESelect1.Close();
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

        public virtual int GetRecordCountByKTOISPRAVKAIDKONTO(string kTOISPRAVKAIDKONTO)
        {
            int internalRecordCountByKTOISPRAVKAIDKONTO;
            try
            {
                this.InitializeMembers();
                internalRecordCountByKTOISPRAVKAIDKONTO = this.GetInternalRecordCountByKTOISPRAVKAIDKONTO(kTOISPRAVKAIDKONTO);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByKTOISPRAVKAIDKONTO;
        }

        public virtual int GetRecordCountByKTOIZVORAIDKONTO(string kTOIZVORAIDKONTO)
        {
            int internalRecordCountByKTOIZVORAIDKONTO;
            try
            {
                this.InitializeMembers();
                internalRecordCountByKTOIZVORAIDKONTO = this.GetInternalRecordCountByKTOIZVORAIDKONTO(kTOIZVORAIDKONTO);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByKTOIZVORAIDKONTO;
        }

        public virtual int GetRecordCountByKTONABAVKEIDKONTO(string kTONABAVKEIDKONTO)
        {
            int internalRecordCountByKTONABAVKEIDKONTO;
            try
            {
                this.InitializeMembers();
                internalRecordCountByKTONABAVKEIDKONTO = this.GetInternalRecordCountByKTONABAVKEIDKONTO(kTONABAVKEIDKONTO);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByKTONABAVKEIDKONTO;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound254 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__KRATKASIFRAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OPISAMSKUPINEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__AMSKUPINASTOPAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KTONABAVKEIDKONTOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KTOISPRAVKAIDKONTOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KTOIZVORAIDKONTOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Condition = false;
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.AMSKUPINESet = new AMSKUPINEDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertAmskupine()
        {
            this.CheckOptimisticConcurrencyAmskupine();
            this.CheckExtendedTableAmskupine();
            this.AfterConfirmAmskupine();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [AMSKUPINE] ([IDAMSKUPINE], [KRATKASIFRA], [OPISAMSKUPINE], [AMSKUPINASTOPA], [KTONABAVKEIDKONTO], [KTOISPRAVKAIDKONTO], [KTOIZVORAIDKONTO]) VALUES (@IDAMSKUPINE, @KRATKASIFRA, @OPISAMSKUPINE, @AMSKUPINASTOPA, @KTONABAVKEIDKONTO, @KTOISPRAVKAIDKONTO, @KTOIZVORAIDKONTO)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAMSKUPINE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KRATKASIFRA", DbType.String, 15));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISAMSKUPINE", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@AMSKUPINASTOPA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTONABAVKEIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTOISPRAVKAIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTOIZVORAIDKONTO", DbType.String, 14));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["IDAMSKUPINE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KRATKASIFRA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["OPISAMSKUPINE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["AMSKUPINASTOPA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KTONABAVKEIDKONTO"]))));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KTOISPRAVKAIDKONTO"]))));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KTOIZVORAIDKONTO"]))));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new AMSKUPINEDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsAmskupine();
            }
            this.OnAMSKUPINEUpdated(new AMSKUPINEEventArgs(this.rowAMSKUPINE, StatementType.Insert));
        }

        private void LoadAmskupine()
        {
            this.rowAMSKUPINE.AM = NumberUtil.ToString((long) this.rowAMSKUPINE.IDAMSKUPINE, "") + " | " + this.rowAMSKUPINE.OPISAMSKUPINE;
        }

        private void LoadByIDAMSKUPINE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.AMSKUPINESet.EnforceConstraints;
            this.AMSKUPINESet.AMSKUPINE.BeginLoadData();
            this.ScanByIDAMSKUPINE(startRow, maxRows);
            this.AMSKUPINESet.AMSKUPINE.EndLoadData();
            this.AMSKUPINESet.EnforceConstraints = enforceConstraints;
            if (this.AMSKUPINESet.AMSKUPINE.Count > 0)
            {
                this.rowAMSKUPINE = this.AMSKUPINESet.AMSKUPINE[this.AMSKUPINESet.AMSKUPINE.Count - 1];
            }
        }

        private void LoadByKTOISPRAVKAIDKONTO(int startRow, int maxRows)
        {
            bool enforceConstraints = this.AMSKUPINESet.EnforceConstraints;
            this.AMSKUPINESet.AMSKUPINE.BeginLoadData();
            this.ScanByKTOISPRAVKAIDKONTO(startRow, maxRows);
            this.AMSKUPINESet.AMSKUPINE.EndLoadData();
            this.AMSKUPINESet.EnforceConstraints = enforceConstraints;
            if (this.AMSKUPINESet.AMSKUPINE.Count > 0)
            {
                this.rowAMSKUPINE = this.AMSKUPINESet.AMSKUPINE[this.AMSKUPINESet.AMSKUPINE.Count - 1];
            }
        }

        private void LoadByKTOIZVORAIDKONTO(int startRow, int maxRows)
        {
            bool enforceConstraints = this.AMSKUPINESet.EnforceConstraints;
            this.AMSKUPINESet.AMSKUPINE.BeginLoadData();
            this.ScanByKTOIZVORAIDKONTO(startRow, maxRows);
            this.AMSKUPINESet.AMSKUPINE.EndLoadData();
            this.AMSKUPINESet.EnforceConstraints = enforceConstraints;
            if (this.AMSKUPINESet.AMSKUPINE.Count > 0)
            {
                this.rowAMSKUPINE = this.AMSKUPINESet.AMSKUPINE[this.AMSKUPINESet.AMSKUPINE.Count - 1];
            }
        }

        private void LoadByKTONABAVKEIDKONTO(int startRow, int maxRows)
        {
            bool enforceConstraints = this.AMSKUPINESet.EnforceConstraints;
            this.AMSKUPINESet.AMSKUPINE.BeginLoadData();
            this.ScanByKTONABAVKEIDKONTO(startRow, maxRows);
            this.AMSKUPINESet.AMSKUPINE.EndLoadData();
            this.AMSKUPINESet.EnforceConstraints = enforceConstraints;
            if (this.AMSKUPINESet.AMSKUPINE.Count > 0)
            {
                this.rowAMSKUPINE = this.AMSKUPINESet.AMSKUPINE[this.AMSKUPINESet.AMSKUPINE.Count - 1];
            }
        }

        private void LoadChildAmskupine(int startRow, int maxRows)
        {
            this.CreateNewRowAmskupine();
            bool enforceConstraints = this.AMSKUPINESet.EnforceConstraints;
            this.AMSKUPINESet.AMSKUPINE.BeginLoadData();
            this.ScanStartAmskupine(startRow, maxRows);
            this.AMSKUPINESet.AMSKUPINE.EndLoadData();
            this.AMSKUPINESet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataAmskupine(int maxRows)
        {
            int num = 0;
            if (this.RcdFound254 != 0)
            {
                this.ScanLoadAmskupine();
                while ((this.RcdFound254 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowAmskupine();
                    this.CreateNewRowAmskupine();
                    this.ScanNextAmskupine();
                }
            }
            if (num > 0)
            {
                this.RcdFound254 = 1;
            }
            this.ScanEndAmskupine();
            if (this.AMSKUPINESet.AMSKUPINE.Count > 0)
            {
                this.rowAMSKUPINE = this.AMSKUPINESet.AMSKUPINE[this.AMSKUPINESet.AMSKUPINE.Count - 1];
            }
        }

        private void LoadRowAmskupine()
        {
            this.OnLoadActionsAmskupine();
            this.AddRowAmskupine();
        }

        private void OnAMSKUPINEUpdated(AMSKUPINEEventArgs e)
        {
            if (this.AMSKUPINEUpdated != null)
            {
                AMSKUPINEUpdateEventHandler aMSKUPINEUpdatedEvent = this.AMSKUPINEUpdated;
                if (aMSKUPINEUpdatedEvent != null)
                {
                    aMSKUPINEUpdatedEvent(this, e);
                }
            }
        }

        private void OnAMSKUPINEUpdating(AMSKUPINEEventArgs e)
        {
            if (this.AMSKUPINEUpdating != null)
            {
                AMSKUPINEUpdateEventHandler aMSKUPINEUpdatingEvent = this.AMSKUPINEUpdating;
                if (aMSKUPINEUpdatingEvent != null)
                {
                    aMSKUPINEUpdatingEvent(this, e);
                }
            }
        }

        private void OnDeleteControlsAmskupine()
        {
            this.rowAMSKUPINE.AM = NumberUtil.ToString((long) this.rowAMSKUPINE.IDAMSKUPINE, "") + " | " + this.rowAMSKUPINE.OPISAMSKUPINE;
        }

        private void OnLoadActionsAmskupine()
        {
            this.rowAMSKUPINE.AM = NumberUtil.ToString((long) this.rowAMSKUPINE.IDAMSKUPINE, "") + " | " + this.rowAMSKUPINE.OPISAMSKUPINE;
        }

        private void ReadRowAmskupine()
        {
            this.Gx_mode = Mode.FromRowState(this.rowAMSKUPINE.RowState);
            if (this.rowAMSKUPINE.RowState != DataRowState.Added)
            {
                this.m__KRATKASIFRAOriginal = RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KRATKASIFRA", DataRowVersion.Original]);
                this.m__OPISAMSKUPINEOriginal = RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["OPISAMSKUPINE", DataRowVersion.Original]);
                this.m__AMSKUPINASTOPAOriginal = RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["AMSKUPINASTOPA", DataRowVersion.Original]);
                this.m__KTONABAVKEIDKONTOOriginal = RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KTONABAVKEIDKONTO", DataRowVersion.Original]);
                this.m__KTOISPRAVKAIDKONTOOriginal = RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KTOISPRAVKAIDKONTO", DataRowVersion.Original]);
                this.m__KTOIZVORAIDKONTOOriginal = RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KTOIZVORAIDKONTO", DataRowVersion.Original]);
            }
            else
            {
                this.m__KRATKASIFRAOriginal = RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KRATKASIFRA"]);
                this.m__OPISAMSKUPINEOriginal = RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["OPISAMSKUPINE"]);
                this.m__AMSKUPINASTOPAOriginal = RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["AMSKUPINASTOPA"]);
                this.m__KTONABAVKEIDKONTOOriginal = RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KTONABAVKEIDKONTO"]);
                this.m__KTOISPRAVKAIDKONTOOriginal = RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KTOISPRAVKAIDKONTO"]);
                this.m__KTOIZVORAIDKONTOOriginal = RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KTOIZVORAIDKONTO"]);
            }
            this._Gxremove = this.rowAMSKUPINE.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowAMSKUPINE = (AMSKUPINEDataSet.AMSKUPINERow) DataSetUtil.CloneOriginalDataRow(this.rowAMSKUPINE);
            }
        }

        private void ScanByIDAMSKUPINE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDAMSKUPINE] = @IDAMSKUPINE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString254 + "  FROM [AMSKUPINE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDAMSKUPINE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString254, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDAMSKUPINE] ) AS DK_PAGENUM   FROM [AMSKUPINE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString254 + " FROM [AMSKUPINE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDAMSKUPINE] ";
            }
            this.cmAMSKUPINESelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmAMSKUPINESelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmAMSKUPINESelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAMSKUPINE", DbType.Int32));
            }
            this.cmAMSKUPINESelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["IDAMSKUPINE"]));
            this.AMSKUPINESelect7 = this.cmAMSKUPINESelect7.FetchData();
            this.RcdFound254 = 0;
            this.ScanLoadAmskupine();
            this.LoadDataAmskupine(maxRows);
        }

        private void ScanByKTOISPRAVKAIDKONTO(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[KTOISPRAVKAIDKONTO] = @KTOISPRAVKAIDKONTO";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString254 + "  FROM [AMSKUPINE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDAMSKUPINE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString254, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDAMSKUPINE] ) AS DK_PAGENUM   FROM [AMSKUPINE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString254 + " FROM [AMSKUPINE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDAMSKUPINE] ";
            }
            this.cmAMSKUPINESelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmAMSKUPINESelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmAMSKUPINESelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTOISPRAVKAIDKONTO", DbType.String, 14));
            }
            this.cmAMSKUPINESelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KTOISPRAVKAIDKONTO"]))));
            this.AMSKUPINESelect7 = this.cmAMSKUPINESelect7.FetchData();
            this.RcdFound254 = 0;
            this.ScanLoadAmskupine();
            this.LoadDataAmskupine(maxRows);
        }

        private void ScanByKTOIZVORAIDKONTO(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[KTOIZVORAIDKONTO] = @KTOIZVORAIDKONTO";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString254 + "  FROM [AMSKUPINE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDAMSKUPINE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString254, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDAMSKUPINE] ) AS DK_PAGENUM   FROM [AMSKUPINE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString254 + " FROM [AMSKUPINE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDAMSKUPINE] ";
            }
            this.cmAMSKUPINESelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmAMSKUPINESelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmAMSKUPINESelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTOIZVORAIDKONTO", DbType.String, 14));
            }
            this.cmAMSKUPINESelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KTOIZVORAIDKONTO"]))));
            this.AMSKUPINESelect7 = this.cmAMSKUPINESelect7.FetchData();
            this.RcdFound254 = 0;
            this.ScanLoadAmskupine();
            this.LoadDataAmskupine(maxRows);
        }

        private void ScanByKTONABAVKEIDKONTO(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[KTONABAVKEIDKONTO] = @KTONABAVKEIDKONTO";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString254 + "  FROM [AMSKUPINE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDAMSKUPINE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString254, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDAMSKUPINE] ) AS DK_PAGENUM   FROM [AMSKUPINE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString254 + " FROM [AMSKUPINE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDAMSKUPINE] ";
            }
            this.cmAMSKUPINESelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmAMSKUPINESelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmAMSKUPINESelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTONABAVKEIDKONTO", DbType.String, 14));
            }
            this.cmAMSKUPINESelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KTONABAVKEIDKONTO"]))));
            this.AMSKUPINESelect7 = this.cmAMSKUPINESelect7.FetchData();
            this.RcdFound254 = 0;
            this.ScanLoadAmskupine();
            this.LoadDataAmskupine(maxRows);
        }

        private void ScanEndAmskupine()
        {
            this.AMSKUPINESelect7.Close();
        }

        private void ScanLoadAmskupine()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmAMSKUPINESelect7.HasMoreRows)
            {
                this.RcdFound254 = 1;
                this.rowAMSKUPINE["IDAMSKUPINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.AMSKUPINESelect7, 0));
                this.rowAMSKUPINE["KRATKASIFRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.AMSKUPINESelect7, 1));
                this.rowAMSKUPINE["OPISAMSKUPINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.AMSKUPINESelect7, 2));
                this.rowAMSKUPINE["AMSKUPINASTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.AMSKUPINESelect7, 3));
                this.rowAMSKUPINE["KTONABAVKEIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.AMSKUPINESelect7, 4))));
                this.rowAMSKUPINE["KTOISPRAVKAIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.AMSKUPINESelect7, 5))));
                this.rowAMSKUPINE["KTOIZVORAIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.AMSKUPINESelect7, 6))));
            }
        }

        private void ScanNextAmskupine()
        {
            this.cmAMSKUPINESelect7.HasMoreRows = this.AMSKUPINESelect7.Read();
            this.RcdFound254 = 0;
            this.ScanLoadAmskupine();
        }

        private void ScanStartAmskupine(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString254 + "  FROM [AMSKUPINE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDAMSKUPINE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString254, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDAMSKUPINE] ) AS DK_PAGENUM   FROM [AMSKUPINE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString254 + " FROM [AMSKUPINE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDAMSKUPINE] ";
            }
            this.cmAMSKUPINESelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.AMSKUPINESelect7 = this.cmAMSKUPINESelect7.FetchData();
            this.RcdFound254 = 0;
            this.ScanLoadAmskupine();
            this.LoadDataAmskupine(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.AMSKUPINESet = (AMSKUPINEDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.AMSKUPINESet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.AMSKUPINESet.AMSKUPINE.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        AMSKUPINEDataSet.AMSKUPINERow current = (AMSKUPINEDataSet.AMSKUPINERow) enumerator.Current;
                        this.rowAMSKUPINE = current;
                        if (Helpers.IsRowChanged(this.rowAMSKUPINE))
                        {
                            this.ReadRowAmskupine();
                            if (this.rowAMSKUPINE.RowState == DataRowState.Added)
                            {
                                this.InsertAmskupine();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateAmskupine();
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

        private void UpdateAmskupine()
        {
            this.CheckOptimisticConcurrencyAmskupine();
            this.CheckExtendedTableAmskupine();
            this.AfterConfirmAmskupine();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [AMSKUPINE] SET [KRATKASIFRA]=@KRATKASIFRA, [OPISAMSKUPINE]=@OPISAMSKUPINE, [AMSKUPINASTOPA]=@AMSKUPINASTOPA, [KTONABAVKEIDKONTO]=@KTONABAVKEIDKONTO, [KTOISPRAVKAIDKONTO]=@KTOISPRAVKAIDKONTO, [KTOIZVORAIDKONTO]=@KTOIZVORAIDKONTO  WHERE [IDAMSKUPINE] = @IDAMSKUPINE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KRATKASIFRA", DbType.String, 15));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISAMSKUPINE", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@AMSKUPINASTOPA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTONABAVKEIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTOISPRAVKAIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTOIZVORAIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAMSKUPINE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KRATKASIFRA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["OPISAMSKUPINE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["AMSKUPINASTOPA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KTONABAVKEIDKONTO"]))));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KTOISPRAVKAIDKONTO"]))));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["KTOIZVORAIDKONTO"]))));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowAMSKUPINE["IDAMSKUPINE"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsAmskupine();
            }
            this.OnAMSKUPINEUpdated(new AMSKUPINEEventArgs(this.rowAMSKUPINE, StatementType.Update));
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
        public class AMSKUPINEDataChangedException : DataChangedException
        {
            public AMSKUPINEDataChangedException()
            {
            }

            public AMSKUPINEDataChangedException(string message) : base(message)
            {
            }

            protected AMSKUPINEDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public AMSKUPINEDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class AMSKUPINEDataLockedException : DataLockedException
        {
            public AMSKUPINEDataLockedException()
            {
            }

            public AMSKUPINEDataLockedException(string message) : base(message)
            {
            }

            protected AMSKUPINEDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public AMSKUPINEDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class AMSKUPINEDuplicateKeyException : DuplicateKeyException
        {
            public AMSKUPINEDuplicateKeyException()
            {
            }

            public AMSKUPINEDuplicateKeyException(string message) : base(message)
            {
            }

            protected AMSKUPINEDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public AMSKUPINEDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class AMSKUPINEEventArgs : EventArgs
        {
            private AMSKUPINEDataSet.AMSKUPINERow m_dataRow;
            private System.Data.StatementType m_statementType;

            public AMSKUPINEEventArgs(AMSKUPINEDataSet.AMSKUPINERow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public AMSKUPINEDataSet.AMSKUPINERow Row
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
        public class AMSKUPINENotFoundException : DataNotFoundException
        {
            public AMSKUPINENotFoundException()
            {
            }

            public AMSKUPINENotFoundException(string message) : base(message)
            {
            }

            protected AMSKUPINENotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public AMSKUPINENotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void AMSKUPINEUpdateEventHandler(object sender, AMSKUPINEDataAdapter.AMSKUPINEEventArgs e);

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
        public class KONTOForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public KONTOForeignKeyNotFoundException()
            {
            }

            public KONTOForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected KONTOForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KONTOForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSInvalidDeleteException : InvalidDeleteException
        {
            public OSInvalidDeleteException()
            {
            }

            public OSInvalidDeleteException(string message) : base(message)
            {
            }

            protected OSInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

