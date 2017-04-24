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

    public class DOPRINOSDataAdapter : IDataAdapter, IDOPRINOSDataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private ReadWriteCommand cmDOPRINOSSelect1;
        private ReadWriteCommand cmDOPRINOSSelect2;
        private ReadWriteCommand cmDOPRINOSSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DOPRINOSSelect1;
        private IDataReader DOPRINOSSelect2;
        private IDataReader DOPRINOSSelect5;
        private DOPRINOSDataSet DOPRINOSSet;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__IDVRSTADOPRINOSOriginal;
        private object m__MAXDOPRINOSOriginal;
        private object m__MINDOPRINOSOriginal;
        private object m__MODOPRINOSOriginal;
        private object m__MZDOPRINOSOriginal;
        private object m__NAZIVDOPRINOSOriginal;
        private object m__OPISPLACANJADOPRINOSOriginal;
        private object m__PODOPRINOSOriginal;
        private object m__PRIMATELJDOPRINOS1Original;
        private object m__PRIMATELJDOPRINOS2Original;
        private object m__PZDOPRINOSOriginal;
        private object m__SIFRAOPISAPLACANJADOPRINOSOriginal;
        private object m__STOPAOriginal;
        private object m__VBDIDOPRINOSOriginal;
        private object m__ZRNDOPRINOSOriginal;
        private readonly string m_SelectString5 = "TM1.[IDDOPRINOS], TM1.[NAZIVDOPRINOS], T2.[NAZIVVRSTADOPRINOS], TM1.[STOPA], TM1.[MODOPRINOS], TM1.[PODOPRINOS], TM1.[MZDOPRINOS], TM1.[PZDOPRINOS], TM1.[PRIMATELJDOPRINOS1], TM1.[PRIMATELJDOPRINOS2], TM1.[SIFRAOPISAPLACANJADOPRINOS], TM1.[OPISPLACANJADOPRINOS], TM1.[VBDIDOPRINOS], TM1.[ZRNDOPRINOS], TM1.[MINDOPRINOS], TM1.[MAXDOPRINOS], TM1.[IDVRSTADOPRINOS]";
        private string m_WhereString;
        private short RcdFound5;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private DOPRINOSDataSet.DOPRINOSRow rowDOPRINOS;
        private string scmdbuf;
        private StatementType sMode5;

        public event DOPRINOSUpdateEventHandler DOPRINOSUpdated;

        public event DOPRINOSUpdateEventHandler DOPRINOSUpdating;

        private void AddRowDoprinos()
        {
            this.DOPRINOSSet.DOPRINOS.AddDOPRINOSRow(this.rowDOPRINOS);
        }

        private void AfterConfirmDoprinos()
        {
            this.OnDOPRINOSUpdating(new DOPRINOSEventArgs(this.rowDOPRINOS, this.Gx_mode));
        }

        private void CheckDeleteErrorsDoprinos()
        {
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMADD], [SHEMADDDOPRINOSIDDOPRINOS], [KONTODOPIDKONTO] FROM [SHEMADDSHEMADDDOPRINOS] WITH (NOLOCK) WHERE [SHEMADDDOPRINOSIDDOPRINOS] = @IDDOPRINOS ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDDOPRINOS"]));
            IDataReader reader4 = command4.FetchData();
            if (command4.HasMoreRows)
            {
                reader4.Close();
                throw new SHEMADDSHEMADDDOPRINOSInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Doprinosi" }));
            }
            reader4.Close();
            ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAPLACA], [SHEMAPLDOPIDDOPRINOS], [KONTODOPIDKONTO] FROM [SHEMAPLACASHEMAPLACADOP] WITH (NOLOCK) WHERE [SHEMAPLDOPIDDOPRINOS] = @IDDOPRINOS ", false);
            if (command5.IDbCommand.Parameters.Count == 0)
            {
                command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDDOPRINOS"]));
            IDataReader reader5 = command5.FetchData();
            if (command5.HasMoreRows)
            {
                reader5.Close();
                throw new SHEMAPLACASHEMAPLACADOPInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Doprinosi" }));
            }
            reader5.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [IDDOPRINOS] FROM [DDOBRACUNRadniciDoprinosi] WITH (NOLOCK) WHERE [IDDOPRINOS] = @IDDOPRINOS ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDDOPRINOS"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new DDOBRACUNRadniciDoprinosiInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Doprinosi" }));
            }
            reader2.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDKATEGORIJA], [IDDOPRINOS] FROM [DDKATEGORIJALevel3] WITH (NOLOCK) WHERE [IDDOPRINOS] = @IDDOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDDOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new DDKATEGORIJALevel3InvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Level3" }));
            }
            reader.Close();
            ReadWriteCommand command6 = this.connDefault.GetCommand("SELECT TOP 1 [IDSKUPPOREZAIDOPRINOSA], [IDDOPRINOS] FROM [SKUPPOREZAIDOPRINOSA2] WITH (NOLOCK) WHERE [IDDOPRINOS] = @IDDOPRINOS ", false);
            if (command6.IDbCommand.Parameters.Count == 0)
            {
                command6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDDOPRINOS"]));
            IDataReader reader6 = command6.FetchData();
            if (command6.HasMoreRows)
            {
                reader6.Close();
                throw new SKUPPOREZAIDOPRINOSA2InvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SKUPPOREZAIDOPRINOSA2" }));
            }
            reader6.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT TOP 1 [IDOBRACUN], [IDRADNIK], [IDDOPRINOS] FROM [ObracunDoprinosi] WITH (NOLOCK) WHERE [IDDOPRINOS] = @IDDOPRINOS ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDDOPRINOS"]));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                reader3.Close();
                throw new ObracunDoprinosiInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "ObracunDoprinosi" }));
            }
            reader3.Close();
        }

        private void CheckExtendedTableDoprinos()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVVRSTADOPRINOS] FROM [VRSTADOPRINOS] WITH (NOLOCK) WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDVRSTADOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new VRSTADOPRINOSForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("VRSTADOPRINOS") }));
            }
            this.rowDOPRINOS["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            reader.Close();
        }

        private void CheckOptimisticConcurrencyDoprinos()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDDOPRINOS], [NAZIVDOPRINOS], [STOPA], [MODOPRINOS], [PODOPRINOS], [MZDOPRINOS], [PZDOPRINOS], [PRIMATELJDOPRINOS1], [PRIMATELJDOPRINOS2], [SIFRAOPISAPLACANJADOPRINOS], [OPISPLACANJADOPRINOS], [VBDIDOPRINOS], [ZRNDOPRINOS], [MINDOPRINOS], [MAXDOPRINOS], [IDVRSTADOPRINOS] FROM [DOPRINOS] WITH (UPDLOCK) WHERE [IDDOPRINOS] = @IDDOPRINOS ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDDOPRINOS"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DOPRINOSDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DOPRINOS") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVDOPRINOSOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!this.m__STOPAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MODOPRINOSOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PODOPRINOSOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MZDOPRINOSOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PZDOPRINOSOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJDOPRINOS1Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJDOPRINOS2Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__SIFRAOPISAPLACANJADOPRINOSOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPISPLACANJADOPRINOSOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__VBDIDOPRINOSOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZRNDOPRINOSOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12))) || !this.m__MINDOPRINOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 13)))) || (!this.m__MAXDOPRINOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 14))) || !this.m__IDVRSTADOPRINOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 15))))))
                {
                    reader.Close();
                    throw new DOPRINOSDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DOPRINOS") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowDoprinos()
        {
            this.rowDOPRINOS = this.DOPRINOSSet.DOPRINOS.NewDOPRINOSRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDoprinos();
            this.OnDeleteControlsDoprinos();
            this.AfterConfirmDoprinos();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DOPRINOS]  WHERE [IDDOPRINOS] = @IDDOPRINOS", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDDOPRINOS"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsDoprinos();
            }
            this.OnDOPRINOSUpdated(new DOPRINOSEventArgs(this.rowDOPRINOS, StatementType.Delete));
            this.rowDOPRINOS.Delete();
            this.sMode5 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode5;
        }

        public virtual int Fill(DOPRINOSDataSet dataSet)
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
                    this.DOPRINOSSet = dataSet;
                    this.LoadChildDoprinos(0, -1);
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
            this.DOPRINOSSet = (DOPRINOSDataSet) dataSet;
            if (this.DOPRINOSSet != null)
            {
                return this.Fill(this.DOPRINOSSet);
            }
            this.DOPRINOSSet = new DOPRINOSDataSet();
            this.Fill(this.DOPRINOSSet);
            dataSet.Merge(this.DOPRINOSSet);
            return 0;
        }

        public virtual int Fill(DOPRINOSDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDDOPRINOS"]));
        }

        public virtual int Fill(DOPRINOSDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDDOPRINOS"]));
        }

        public virtual int Fill(DOPRINOSDataSet dataSet, int iDDOPRINOS)
        {
            if (!this.FillByIDDOPRINOS(dataSet, iDDOPRINOS))
            {
                throw new DOPRINOSNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DOPRINOS") }));
            }
            return 0;
        }

        public virtual bool FillByIDDOPRINOS(DOPRINOSDataSet dataSet, int iDDOPRINOS)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DOPRINOSSet = dataSet;
            this.rowDOPRINOS = this.DOPRINOSSet.DOPRINOS.NewDOPRINOSRow();
            this.rowDOPRINOS.IDDOPRINOS = iDDOPRINOS;
            try
            {
                this.LoadByIDDOPRINOS(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound5 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByIDVRSTADOPRINOS(DOPRINOSDataSet dataSet, int iDVRSTADOPRINOS)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DOPRINOSSet = dataSet;
            this.rowDOPRINOS = this.DOPRINOSSet.DOPRINOS.NewDOPRINOSRow();
            this.rowDOPRINOS.IDVRSTADOPRINOS = iDVRSTADOPRINOS;
            try
            {
                this.LoadByIDVRSTADOPRINOS(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(DOPRINOSDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DOPRINOSSet = dataSet;
            try
            {
                this.LoadChildDoprinos(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDVRSTADOPRINOS(DOPRINOSDataSet dataSet, int iDVRSTADOPRINOS, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DOPRINOSSet = dataSet;
            this.rowDOPRINOS = this.DOPRINOSSet.DOPRINOS.NewDOPRINOSRow();
            this.rowDOPRINOS.IDVRSTADOPRINOS = iDVRSTADOPRINOS;
            try
            {
                this.LoadByIDVRSTADOPRINOS(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDDOPRINOS], [NAZIVDOPRINOS], [STOPA], [MODOPRINOS], [PODOPRINOS], [MZDOPRINOS], [PZDOPRINOS], [PRIMATELJDOPRINOS1], [PRIMATELJDOPRINOS2], [SIFRAOPISAPLACANJADOPRINOS], [OPISPLACANJADOPRINOS], [VBDIDOPRINOS], [ZRNDOPRINOS], [MINDOPRINOS], [MAXDOPRINOS], [IDVRSTADOPRINOS] FROM [DOPRINOS] WITH (NOLOCK) WHERE [IDDOPRINOS] = @IDDOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDDOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound5 = 1;
                this.rowDOPRINOS["IDDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowDOPRINOS["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowDOPRINOS["STOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
                this.rowDOPRINOS["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowDOPRINOS["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowDOPRINOS["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowDOPRINOS["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowDOPRINOS["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowDOPRINOS["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowDOPRINOS["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowDOPRINOS["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
                this.rowDOPRINOS["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
                this.rowDOPRINOS["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12));
                this.rowDOPRINOS["MINDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 13));
                this.rowDOPRINOS["MAXDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 14));
                this.rowDOPRINOS["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 15));
                this.sMode5 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadDoprinos();
                this.Gx_mode = this.sMode5;
            }
            else
            {
                this.RcdFound5 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDDOPRINOS";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDOPRINOSSelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [DOPRINOS] WITH (NOLOCK) ", false);
            this.DOPRINOSSelect2 = this.cmDOPRINOSSelect2.FetchData();
            if (this.DOPRINOSSelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.DOPRINOSSelect2.GetInt32(0);
            }
            this.DOPRINOSSelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDVRSTADOPRINOS(int iDVRSTADOPRINOS)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDOPRINOSSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [DOPRINOS] WITH (NOLOCK) WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS ", false);
            if (this.cmDOPRINOSSelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOPRINOSSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
            }
            this.cmDOPRINOSSelect1.SetParameter(0, iDVRSTADOPRINOS);
            this.DOPRINOSSelect1 = this.cmDOPRINOSSelect1.FetchData();
            if (this.DOPRINOSSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.DOPRINOSSelect1.GetInt32(0);
            }
            this.DOPRINOSSelect1.Close();
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

        public virtual int GetRecordCountByIDVRSTADOPRINOS(int iDVRSTADOPRINOS)
        {
            int internalRecordCountByIDVRSTADOPRINOS;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDVRSTADOPRINOS = this.GetInternalRecordCountByIDVRSTADOPRINOS(iDVRSTADOPRINOS);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDVRSTADOPRINOS;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound5 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__STOPAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MODOPRINOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PODOPRINOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MZDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PZDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIMATELJDOPRINOS1Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIMATELJDOPRINOS2Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__SIFRAOPISAPLACANJADOPRINOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OPISPLACANJADOPRINOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__VBDIDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZRNDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MINDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MAXDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDVRSTADOPRINOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Condition = false;
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.DOPRINOSSet = new DOPRINOSDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertDoprinos()
        {
            this.CheckOptimisticConcurrencyDoprinos();
            this.CheckExtendedTableDoprinos();
            this.AfterConfirmDoprinos();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DOPRINOS] ([IDDOPRINOS], [NAZIVDOPRINOS], [STOPA], [MODOPRINOS], [PODOPRINOS], [MZDOPRINOS], [PZDOPRINOS], [PRIMATELJDOPRINOS1], [PRIMATELJDOPRINOS2], [SIFRAOPISAPLACANJADOPRINOS], [OPISPLACANJADOPRINOS], [VBDIDOPRINOS], [ZRNDOPRINOS], [MINDOPRINOS], [MAXDOPRINOS], [IDVRSTADOPRINOS]) VALUES (@IDDOPRINOS, @NAZIVDOPRINOS, @STOPA, @MODOPRINOS, @PODOPRINOS, @MZDOPRINOS, @PZDOPRINOS, @PRIMATELJDOPRINOS1, @PRIMATELJDOPRINOS2, @SIFRAOPISAPLACANJADOPRINOS, @OPISPLACANJADOPRINOS, @VBDIDOPRINOS, @ZRNDOPRINOS, @MINDOPRINOS, @MAXDOPRINOS, @IDVRSTADOPRINOS)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVDOPRINOS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STOPA", DbType.Currency));
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
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MINDOPRINOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MAXDOPRINOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDDOPRINOS"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["NAZIVDOPRINOS"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["STOPA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["MODOPRINOS"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["PODOPRINOS"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["MZDOPRINOS"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["PZDOPRINOS"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["PRIMATELJDOPRINOS1"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["PRIMATELJDOPRINOS2"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["SIFRAOPISAPLACANJADOPRINOS"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["OPISPLACANJADOPRINOS"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["VBDIDOPRINOS"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["ZRNDOPRINOS"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["MINDOPRINOS"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["MAXDOPRINOS"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDVRSTADOPRINOS"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DOPRINOSDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDOPRINOSUpdated(new DOPRINOSEventArgs(this.rowDOPRINOS, StatementType.Insert));
        }

        private void LoadByIDDOPRINOS(int startRow, int maxRows)
        {
            bool enforceConstraints = this.DOPRINOSSet.EnforceConstraints;
            this.DOPRINOSSet.DOPRINOS.BeginLoadData();
            this.ScanByIDDOPRINOS(startRow, maxRows);
            this.DOPRINOSSet.DOPRINOS.EndLoadData();
            this.DOPRINOSSet.EnforceConstraints = enforceConstraints;
            if (this.DOPRINOSSet.DOPRINOS.Count > 0)
            {
                this.rowDOPRINOS = this.DOPRINOSSet.DOPRINOS[this.DOPRINOSSet.DOPRINOS.Count - 1];
            }
        }

        private void LoadByIDVRSTADOPRINOS(int startRow, int maxRows)
        {
            bool enforceConstraints = this.DOPRINOSSet.EnforceConstraints;
            this.DOPRINOSSet.DOPRINOS.BeginLoadData();
            this.ScanByIDVRSTADOPRINOS(startRow, maxRows);
            this.DOPRINOSSet.DOPRINOS.EndLoadData();
            this.DOPRINOSSet.EnforceConstraints = enforceConstraints;
            if (this.DOPRINOSSet.DOPRINOS.Count > 0)
            {
                this.rowDOPRINOS = this.DOPRINOSSet.DOPRINOS[this.DOPRINOSSet.DOPRINOS.Count - 1];
            }
        }

        private void LoadChildDoprinos(int startRow, int maxRows)
        {
            this.CreateNewRowDoprinos();
            bool enforceConstraints = this.DOPRINOSSet.EnforceConstraints;
            this.DOPRINOSSet.DOPRINOS.BeginLoadData();
            this.ScanStartDoprinos(startRow, maxRows);
            this.DOPRINOSSet.DOPRINOS.EndLoadData();
            this.DOPRINOSSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataDoprinos(int maxRows)
        {
            int num = 0;
            if (this.RcdFound5 != 0)
            {
                this.ScanLoadDoprinos();
                while ((this.RcdFound5 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowDoprinos();
                    this.CreateNewRowDoprinos();
                    this.ScanNextDoprinos();
                }
            }
            if (num > 0)
            {
                this.RcdFound5 = 1;
            }
            this.ScanEndDoprinos();
            if (this.DOPRINOSSet.DOPRINOS.Count > 0)
            {
                this.rowDOPRINOS = this.DOPRINOSSet.DOPRINOS[this.DOPRINOSSet.DOPRINOS.Count - 1];
            }
        }

        private void LoadDoprinos()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVVRSTADOPRINOS] FROM [VRSTADOPRINOS] WITH (NOLOCK) WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDVRSTADOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowDOPRINOS["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void LoadRowDoprinos()
        {
            this.AddRowDoprinos();
        }

        private void OnDeleteControlsDoprinos()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVVRSTADOPRINOS] FROM [VRSTADOPRINOS] WITH (NOLOCK) WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDVRSTADOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowDOPRINOS["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void OnDOPRINOSUpdated(DOPRINOSEventArgs e)
        {
            if (this.DOPRINOSUpdated != null)
            {
                DOPRINOSUpdateEventHandler dOPRINOSUpdatedEvent = this.DOPRINOSUpdated;
                if (dOPRINOSUpdatedEvent != null)
                {
                    dOPRINOSUpdatedEvent(this, e);
                }
            }
        }

        private void OnDOPRINOSUpdating(DOPRINOSEventArgs e)
        {
            if (this.DOPRINOSUpdating != null)
            {
                DOPRINOSUpdateEventHandler dOPRINOSUpdatingEvent = this.DOPRINOSUpdating;
                if (dOPRINOSUpdatingEvent != null)
                {
                    dOPRINOSUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowDoprinos()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDOPRINOS.RowState);
            if (this.rowDOPRINOS.RowState != DataRowState.Added)
            {
                this.m__NAZIVDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["NAZIVDOPRINOS", DataRowVersion.Original]);
                this.m__STOPAOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["STOPA", DataRowVersion.Original]);
                this.m__MODOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["MODOPRINOS", DataRowVersion.Original]);
                this.m__PODOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["PODOPRINOS", DataRowVersion.Original]);
                this.m__MZDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["MZDOPRINOS", DataRowVersion.Original]);
                this.m__PZDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["PZDOPRINOS", DataRowVersion.Original]);
                this.m__PRIMATELJDOPRINOS1Original = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["PRIMATELJDOPRINOS1", DataRowVersion.Original]);
                this.m__PRIMATELJDOPRINOS2Original = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["PRIMATELJDOPRINOS2", DataRowVersion.Original]);
                this.m__SIFRAOPISAPLACANJADOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["SIFRAOPISAPLACANJADOPRINOS", DataRowVersion.Original]);
                this.m__OPISPLACANJADOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["OPISPLACANJADOPRINOS", DataRowVersion.Original]);
                this.m__VBDIDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["VBDIDOPRINOS", DataRowVersion.Original]);
                this.m__ZRNDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["ZRNDOPRINOS", DataRowVersion.Original]);
                this.m__MINDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["MINDOPRINOS", DataRowVersion.Original]);
                this.m__MAXDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["MAXDOPRINOS", DataRowVersion.Original]);
                this.m__IDVRSTADOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDVRSTADOPRINOS", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["NAZIVDOPRINOS"]);
                this.m__STOPAOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["STOPA"]);
                this.m__MODOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["MODOPRINOS"]);
                this.m__PODOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["PODOPRINOS"]);
                this.m__MZDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["MZDOPRINOS"]);
                this.m__PZDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["PZDOPRINOS"]);
                this.m__PRIMATELJDOPRINOS1Original = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["PRIMATELJDOPRINOS1"]);
                this.m__PRIMATELJDOPRINOS2Original = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["PRIMATELJDOPRINOS2"]);
                this.m__SIFRAOPISAPLACANJADOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["SIFRAOPISAPLACANJADOPRINOS"]);
                this.m__OPISPLACANJADOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["OPISPLACANJADOPRINOS"]);
                this.m__VBDIDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["VBDIDOPRINOS"]);
                this.m__ZRNDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["ZRNDOPRINOS"]);
                this.m__MINDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["MINDOPRINOS"]);
                this.m__MAXDOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["MAXDOPRINOS"]);
                this.m__IDVRSTADOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDVRSTADOPRINOS"]);
            }
            this._Gxremove = this.rowDOPRINOS.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowDOPRINOS = (DOPRINOSDataSet.DOPRINOSRow) DataSetUtil.CloneOriginalDataRow(this.rowDOPRINOS);
            }
        }

        private void ScanByIDDOPRINOS(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDDOPRINOS] = @IDDOPRINOS";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString5 + "  FROM ([DOPRINOS] TM1 WITH (NOLOCK) INNER JOIN [VRSTADOPRINOS] T2 WITH (NOLOCK) ON T2.[IDVRSTADOPRINOS] = TM1.[IDVRSTADOPRINOS])" + this.m_WhereString + " ORDER BY TM1.[IDDOPRINOS]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString5, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDDOPRINOS] ) AS DK_PAGENUM   FROM ([DOPRINOS] TM1 WITH (NOLOCK) INNER JOIN [VRSTADOPRINOS] T2 WITH (NOLOCK) ON T2.[IDVRSTADOPRINOS] = TM1.[IDVRSTADOPRINOS]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString5 + " FROM ([DOPRINOS] TM1 WITH (NOLOCK) INNER JOIN [VRSTADOPRINOS] T2 WITH (NOLOCK) ON T2.[IDVRSTADOPRINOS] = TM1.[IDVRSTADOPRINOS])" + this.m_WhereString + " ORDER BY TM1.[IDDOPRINOS] ";
            }
            this.cmDOPRINOSSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmDOPRINOSSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOPRINOSSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            this.cmDOPRINOSSelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDDOPRINOS"]));
            this.DOPRINOSSelect5 = this.cmDOPRINOSSelect5.FetchData();
            this.RcdFound5 = 0;
            this.ScanLoadDoprinos();
            this.LoadDataDoprinos(maxRows);
        }

        private void ScanByIDVRSTADOPRINOS(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDVRSTADOPRINOS] = @IDVRSTADOPRINOS";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString5 + "  FROM ([DOPRINOS] TM1 WITH (NOLOCK) INNER JOIN [VRSTADOPRINOS] T2 WITH (NOLOCK) ON T2.[IDVRSTADOPRINOS] = TM1.[IDVRSTADOPRINOS])" + this.m_WhereString + " ORDER BY TM1.[IDDOPRINOS]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString5, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDDOPRINOS] ) AS DK_PAGENUM   FROM ([DOPRINOS] TM1 WITH (NOLOCK) INNER JOIN [VRSTADOPRINOS] T2 WITH (NOLOCK) ON T2.[IDVRSTADOPRINOS] = TM1.[IDVRSTADOPRINOS]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString5 + " FROM ([DOPRINOS] TM1 WITH (NOLOCK) INNER JOIN [VRSTADOPRINOS] T2 WITH (NOLOCK) ON T2.[IDVRSTADOPRINOS] = TM1.[IDVRSTADOPRINOS])" + this.m_WhereString + " ORDER BY TM1.[IDDOPRINOS] ";
            }
            this.cmDOPRINOSSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmDOPRINOSSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOPRINOSSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
            }
            this.cmDOPRINOSSelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDVRSTADOPRINOS"]));
            this.DOPRINOSSelect5 = this.cmDOPRINOSSelect5.FetchData();
            this.RcdFound5 = 0;
            this.ScanLoadDoprinos();
            this.LoadDataDoprinos(maxRows);
        }

        private void ScanEndDoprinos()
        {
            this.DOPRINOSSelect5.Close();
        }

        private void ScanLoadDoprinos()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDOPRINOSSelect5.HasMoreRows)
            {
                this.RcdFound5 = 1;
                this.rowDOPRINOS["IDDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DOPRINOSSelect5, 0));
                this.rowDOPRINOS["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOPRINOSSelect5, 1));
                this.rowDOPRINOS["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOPRINOSSelect5, 2));
                this.rowDOPRINOS["STOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DOPRINOSSelect5, 3));
                this.rowDOPRINOS["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOPRINOSSelect5, 4));
                this.rowDOPRINOS["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOPRINOSSelect5, 5));
                this.rowDOPRINOS["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOPRINOSSelect5, 6));
                this.rowDOPRINOS["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOPRINOSSelect5, 7));
                this.rowDOPRINOS["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOPRINOSSelect5, 8));
                this.rowDOPRINOS["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOPRINOSSelect5, 9));
                this.rowDOPRINOS["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOPRINOSSelect5, 10));
                this.rowDOPRINOS["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOPRINOSSelect5, 11));
                this.rowDOPRINOS["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOPRINOSSelect5, 12));
                this.rowDOPRINOS["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOPRINOSSelect5, 13));
                this.rowDOPRINOS["MINDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DOPRINOSSelect5, 14));
                this.rowDOPRINOS["MAXDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DOPRINOSSelect5, 15));
                this.rowDOPRINOS["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DOPRINOSSelect5, 0x10));
                this.rowDOPRINOS["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOPRINOSSelect5, 2));
            }
        }

        private void ScanNextDoprinos()
        {
            this.cmDOPRINOSSelect5.HasMoreRows = this.DOPRINOSSelect5.Read();
            this.RcdFound5 = 0;
            this.ScanLoadDoprinos();
        }

        private void ScanStartDoprinos(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString5 + "  FROM ([DOPRINOS] TM1 WITH (NOLOCK) INNER JOIN [VRSTADOPRINOS] T2 WITH (NOLOCK) ON T2.[IDVRSTADOPRINOS] = TM1.[IDVRSTADOPRINOS])" + this.m_WhereString + " ORDER BY TM1.[IDDOPRINOS]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString5, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDDOPRINOS] ) AS DK_PAGENUM   FROM ([DOPRINOS] TM1 WITH (NOLOCK) INNER JOIN [VRSTADOPRINOS] T2 WITH (NOLOCK) ON T2.[IDVRSTADOPRINOS] = TM1.[IDVRSTADOPRINOS]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString5 + " FROM ([DOPRINOS] TM1 WITH (NOLOCK) INNER JOIN [VRSTADOPRINOS] T2 WITH (NOLOCK) ON T2.[IDVRSTADOPRINOS] = TM1.[IDVRSTADOPRINOS])" + this.m_WhereString + " ORDER BY TM1.[IDDOPRINOS] ";
            }
            this.cmDOPRINOSSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.DOPRINOSSelect5 = this.cmDOPRINOSSelect5.FetchData();
            this.RcdFound5 = 0;
            this.ScanLoadDoprinos();
            this.LoadDataDoprinos(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.DOPRINOSSet = (DOPRINOSDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.DOPRINOSSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.DOPRINOSSet.DOPRINOS.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DOPRINOSDataSet.DOPRINOSRow current = (DOPRINOSDataSet.DOPRINOSRow) enumerator.Current;
                        this.rowDOPRINOS = current;
                        if (Helpers.IsRowChanged(this.rowDOPRINOS))
                        {
                            this.ReadRowDoprinos();
                            if (this.rowDOPRINOS.RowState == DataRowState.Added)
                            {
                                this.InsertDoprinos();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateDoprinos();
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

        private void UpdateDoprinos()
        {
            this.CheckOptimisticConcurrencyDoprinos();
            this.CheckExtendedTableDoprinos();
            this.AfterConfirmDoprinos();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DOPRINOS] SET [NAZIVDOPRINOS]=@NAZIVDOPRINOS, [STOPA]=@STOPA, [MODOPRINOS]=@MODOPRINOS, [PODOPRINOS]=@PODOPRINOS, [MZDOPRINOS]=@MZDOPRINOS, [PZDOPRINOS]=@PZDOPRINOS, [PRIMATELJDOPRINOS1]=@PRIMATELJDOPRINOS1, [PRIMATELJDOPRINOS2]=@PRIMATELJDOPRINOS2, [SIFRAOPISAPLACANJADOPRINOS]=@SIFRAOPISAPLACANJADOPRINOS, [OPISPLACANJADOPRINOS]=@OPISPLACANJADOPRINOS, [VBDIDOPRINOS]=@VBDIDOPRINOS, [ZRNDOPRINOS]=@ZRNDOPRINOS, [MINDOPRINOS]=@MINDOPRINOS, [MAXDOPRINOS]=@MAXDOPRINOS, [IDVRSTADOPRINOS]=@IDVRSTADOPRINOS  WHERE [IDDOPRINOS] = @IDDOPRINOS", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVDOPRINOS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STOPA", DbType.Currency));
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
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MINDOPRINOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MAXDOPRINOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["NAZIVDOPRINOS"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["STOPA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["MODOPRINOS"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["PODOPRINOS"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["MZDOPRINOS"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["PZDOPRINOS"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["PRIMATELJDOPRINOS1"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["PRIMATELJDOPRINOS2"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["SIFRAOPISAPLACANJADOPRINOS"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["OPISPLACANJADOPRINOS"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["VBDIDOPRINOS"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["ZRNDOPRINOS"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["MINDOPRINOS"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["MAXDOPRINOS"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDVRSTADOPRINOS"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowDOPRINOS["IDDOPRINOS"]));
            command.ExecuteStmt();
            new doprinosupdateredundancy(ref this.dsDefault).execute(this.rowDOPRINOS.IDDOPRINOS);
            this.OnDOPRINOSUpdated(new DOPRINOSEventArgs(this.rowDOPRINOS, StatementType.Update));
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
        public class DDKATEGORIJALevel3InvalidDeleteException : InvalidDeleteException
        {
            public DDKATEGORIJALevel3InvalidDeleteException()
            {
            }

            public DDKATEGORIJALevel3InvalidDeleteException(string message) : base(message)
            {
            }

            protected DDKATEGORIJALevel3InvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJALevel3InvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNRadniciDoprinosiInvalidDeleteException : InvalidDeleteException
        {
            public DDOBRACUNRadniciDoprinosiInvalidDeleteException()
            {
            }

            public DDOBRACUNRadniciDoprinosiInvalidDeleteException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciDoprinosiInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciDoprinosiInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DOPRINOSDataChangedException : DataChangedException
        {
            public DOPRINOSDataChangedException()
            {
            }

            public DOPRINOSDataChangedException(string message) : base(message)
            {
            }

            protected DOPRINOSDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOPRINOSDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DOPRINOSDataLockedException : DataLockedException
        {
            public DOPRINOSDataLockedException()
            {
            }

            public DOPRINOSDataLockedException(string message) : base(message)
            {
            }

            protected DOPRINOSDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOPRINOSDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DOPRINOSDuplicateKeyException : DuplicateKeyException
        {
            public DOPRINOSDuplicateKeyException()
            {
            }

            public DOPRINOSDuplicateKeyException(string message) : base(message)
            {
            }

            protected DOPRINOSDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOPRINOSDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DOPRINOSEventArgs : EventArgs
        {
            private DOPRINOSDataSet.DOPRINOSRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public DOPRINOSEventArgs(DOPRINOSDataSet.DOPRINOSRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DOPRINOSDataSet.DOPRINOSRow Row
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
        public class DOPRINOSNotFoundException : DataNotFoundException
        {
            public DOPRINOSNotFoundException()
            {
            }

            public DOPRINOSNotFoundException(string message) : base(message)
            {
            }

            protected DOPRINOSNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOPRINOSNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void DOPRINOSUpdateEventHandler(object sender, DOPRINOSDataAdapter.DOPRINOSEventArgs e);

        [Serializable]
        public class ObracunDoprinosiInvalidDeleteException : InvalidDeleteException
        {
            public ObracunDoprinosiInvalidDeleteException()
            {
            }

            public ObracunDoprinosiInvalidDeleteException(string message) : base(message)
            {
            }

            protected ObracunDoprinosiInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunDoprinosiInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMADDSHEMADDDOPRINOSInvalidDeleteException : InvalidDeleteException
        {
            public SHEMADDSHEMADDDOPRINOSInvalidDeleteException()
            {
            }

            public SHEMADDSHEMADDDOPRINOSInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMADDSHEMADDDOPRINOSInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMADDSHEMADDDOPRINOSInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAPLACASHEMAPLACADOPInvalidDeleteException : InvalidDeleteException
        {
            public SHEMAPLACASHEMAPLACADOPInvalidDeleteException()
            {
            }

            public SHEMAPLACASHEMAPLACADOPInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMAPLACASHEMAPLACADOPInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACASHEMAPLACADOPInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SKUPPOREZAIDOPRINOSA2InvalidDeleteException : InvalidDeleteException
        {
            public SKUPPOREZAIDOPRINOSA2InvalidDeleteException()
            {
            }

            public SKUPPOREZAIDOPRINOSA2InvalidDeleteException(string message) : base(message)
            {
            }

            protected SKUPPOREZAIDOPRINOSA2InvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SKUPPOREZAIDOPRINOSA2InvalidDeleteException(string message, System.Exception inner) : base(message, inner)
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

