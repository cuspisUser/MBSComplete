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

    public class UCENIKOBRACUNDataAdapter : IDataAdapter, IUCENIKOBRACUNDataAdapter
    {
        private bool _Gxremove;
        private bool _Gxremove21;
        private ReadWriteCommand cmUCENIKOBRACUNSelect1;
        private ReadWriteCommand cmUCENIKOBRACUNSelect2;
        private ReadWriteCommand cmUCENIKOBRACUNSelect5;
        private ReadWriteCommand cmUCENIKOBRACUNUCENIKOBRACUNDETAILSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;

        private object m__AKTIVANZARSMOriginal;
        private object m__BROJDANAPRAKSEOriginal;
        private object m__OBRACUNOSNOVICEPRAKSAOriginal;
        private object m__OSNOVICAPODANUOriginal;
        private object m__UCOBROPISOriginal;

        private readonly string m_SelectString297 = "TM1.[UCOBRMJESEC], TM1.[UCOBRGODINA], TM1.[AKTIVANZARSM], TM1.[UCOBROPIS], TM1.[OSNOVICAPODANU]";
        private string m_SubSelTopString298;
        private string m_WhereString;

        private short RcdFound297;
        private short RcdFound298;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private UCENIKOBRACUNDataSet.UCENIKOBRACUNRow rowUCENIKOBRACUN;
        private UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow rowUCENIKOBRACUNUCENIKOBRACUNDETAIL;
        private string scmdbuf;
        private StatementType sMode297;
        private StatementType sMode298;
        private IDataReader UCENIKOBRACUNSelect1;
        private IDataReader UCENIKOBRACUNSelect2;
        private IDataReader UCENIKOBRACUNSelect5;
        private UCENIKOBRACUNDataSet UCENIKOBRACUNSet;
        private IDataReader UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2;

        public event UCENIKOBRACUNUCENIKOBRACUNDETAILUpdateEventHandler UCENIKOBRACUNUCENIKOBRACUNDETAILUpdated;

        public event UCENIKOBRACUNUCENIKOBRACUNDETAILUpdateEventHandler UCENIKOBRACUNUCENIKOBRACUNDETAILUpdating;

        public event UCENIKOBRACUNUpdateEventHandler UCENIKOBRACUNUpdated;

        public event UCENIKOBRACUNUpdateEventHandler UCENIKOBRACUNUpdating;

        private void AddRowUcenikobracun()
        {
            this.UCENIKOBRACUNSet.UCENIKOBRACUN.AddUCENIKOBRACUNRow(this.rowUCENIKOBRACUN);
        }

        private void AddRowUcenikobracunucenikobracundetail()
        {
            this.UCENIKOBRACUNSet.UCENIKOBRACUNUCENIKOBRACUNDETAIL.AddUCENIKOBRACUNUCENIKOBRACUNDETAILRow(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL);
        }

        private void AfterConfirmUcenikobracun()
        {
            this.OnUCENIKOBRACUNUpdating(new UCENIKOBRACUNEventArgs(this.rowUCENIKOBRACUN, this.Gx_mode));
        }

        private void AfterConfirmUcenikobracunucenikobracundetail()
        {
            this.OnUCENIKOBRACUNUCENIKOBRACUNDETAILUpdating(new UCENIKOBRACUNUCENIKOBRACUNDETAILEventArgs(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL, this.Gx_mode));
        }

        private void CheckExtendedTableUcenikobracunucenikobracundetail()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [PREZIMEUCENIK], [IMEUCENIK], [RAZRED], [ODJELJENJE] FROM [UCENIK] WITH (NOLOCK) WHERE [IDUCENIK] = @IDUCENIK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUCENIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["IDUCENIK"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new UCENIKForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("UCENIK") }));
            }
            this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["PREZIMEUCENIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["IMEUCENIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
            this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["RAZRED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2));
            this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["ODJELJENJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
            reader.Close();
        }

        private void CheckOptimisticConcurrencyUcenikobracun()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [UCOBRMJESEC], [UCOBRGODINA], [AKTIVANZARSM], [UCOBROPIS], [OSNOVICAPODANU] FROM [UCENIKOBRACUN] WITH (UPDLOCK) WHERE [UCOBRMJESEC] = @UCOBRMJESEC AND [UCOBRGODINA] = @UCOBRGODINA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRMJESEC", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRGODINA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBRMJESEC"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBRGODINA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new UCENIKOBRACUNDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("UCENIKOBRACUN") }));
                }
                if ((!command.HasMoreRows || !this.m__AKTIVANZARSMOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 2)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__UCOBROPISOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3))) || !this.m__OSNOVICAPODANUOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4)))))
                {
                    reader.Close();
                    throw new UCENIKOBRACUNDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("UCENIKOBRACUN") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyUcenikobracunucenikobracundetail()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [UCOBRMJESEC], [UCOBRGODINA], [BROJDANAPRAKSE], [OBRACUNOSNOVICEPRAKSA], [IDUCENIK] FROM [UCENIKOBRACUNUCENIKOBRACUNDETAIL] WITH (UPDLOCK) WHERE [UCOBRMJESEC] = @UCOBRMJESEC AND [UCOBRGODINA] = @UCOBRGODINA AND [IDUCENIK] = @IDUCENIK ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRMJESEC", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRGODINA", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUCENIK", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["UCOBRMJESEC"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["UCOBRGODINA"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["IDUCENIK"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new UCENIKOBRACUNUCENIKOBRACUNDETAILDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("UCENIKOBRACUNUCENIKOBRACUNDETAIL") }));
                }
                if ((!command.HasMoreRows || !this.m__BROJDANAPRAKSEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2)))) || !this.m__OBRACUNOSNOVICEPRAKSAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3))))
                {
                    reader.Close();
                    throw new UCENIKOBRACUNUCENIKOBRACUNDETAILDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("UCENIKOBRACUNUCENIKOBRACUNDETAIL") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowUcenikobracun()
        {
            this.rowUCENIKOBRACUN = this.UCENIKOBRACUNSet.UCENIKOBRACUN.NewUCENIKOBRACUNRow();
        }

        private void CreateNewRowUcenikobracunucenikobracundetail()
        {
            this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL = this.UCENIKOBRACUNSet.UCENIKOBRACUNUCENIKOBRACUNDETAIL.NewUCENIKOBRACUNUCENIKOBRACUNDETAILRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyUcenikobracun();
            this.ProcessNestedLevelUcenikobracunucenikobracundetail();
            this.AfterConfirmUcenikobracun();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [UCENIKOBRACUN]  WHERE [UCOBRMJESEC] = @UCOBRMJESEC AND [UCOBRGODINA] = @UCOBRGODINA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRMJESEC", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRGODINA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBRMJESEC"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBRGODINA"]));
            command.ExecuteStmt();
            this.OnUCENIKOBRACUNUpdated(new UCENIKOBRACUNEventArgs(this.rowUCENIKOBRACUN, StatementType.Delete));
            this.rowUCENIKOBRACUN.Delete();
            this.sMode297 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode297;
        }

        private void DeleteUcenikobracunucenikobracundetail()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyUcenikobracunucenikobracundetail();
            this.OnDeleteControlsUcenikobracunucenikobracundetail();
            this.AfterConfirmUcenikobracunucenikobracundetail();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [UCENIKOBRACUNUCENIKOBRACUNDETAIL]  WHERE [UCOBRMJESEC] = @UCOBRMJESEC AND [UCOBRGODINA] = @UCOBRGODINA AND [IDUCENIK] = @IDUCENIK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRMJESEC", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRGODINA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUCENIK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["UCOBRMJESEC"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["UCOBRGODINA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["IDUCENIK"]));
            command.ExecuteStmt();
            this.OnUCENIKOBRACUNUCENIKOBRACUNDETAILUpdated(new UCENIKOBRACUNUCENIKOBRACUNDETAILEventArgs(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL, StatementType.Delete));
            this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL.Delete();
            this.sMode298 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode298;
        }

        public virtual int Fill(UCENIKOBRACUNDataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()));
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.UCENIKOBRACUNSet = dataSet;
                    this.LoadChildUcenikobracun(0, -1);
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
            this.UCENIKOBRACUNSet = (UCENIKOBRACUNDataSet) dataSet;
            if (this.UCENIKOBRACUNSet != null)
            {
                return this.Fill(this.UCENIKOBRACUNSet);
            }
            this.UCENIKOBRACUNSet = new UCENIKOBRACUNDataSet();
            this.Fill(this.UCENIKOBRACUNSet);
            dataSet.Merge(this.UCENIKOBRACUNSet);
            return 0;
        }

        public virtual int Fill(UCENIKOBRACUNDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["UCOBRMJESEC"]), Conversions.ToInteger(dataRecord["UCOBRGODINA"]));
        }

        public virtual int Fill(UCENIKOBRACUNDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["UCOBRMJESEC"]), Conversions.ToInteger(dataRecord["UCOBRGODINA"]));
        }

        public virtual int Fill(UCENIKOBRACUNDataSet dataSet, int uCOBRMJESEC, int uCOBRGODINA)
        {
            if (!this.FillByUCOBRMJESECUCOBRGODINA(dataSet, uCOBRMJESEC, uCOBRGODINA))
            {
                throw new UCENIKOBRACUNNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("UCENIKOBRACUN") }));
            }
            return 0;
        }

        public virtual int FillByUCOBRMJESEC(UCENIKOBRACUNDataSet dataSet, int uCOBRMJESEC)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.UCENIKOBRACUNSet = dataSet;
            this.rowUCENIKOBRACUN = this.UCENIKOBRACUNSet.UCENIKOBRACUN.NewUCENIKOBRACUNRow();
            this.rowUCENIKOBRACUN.UCOBRMJESEC = uCOBRMJESEC;
            try
            {
                this.LoadByUCOBRMJESEC(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByUCOBRMJESECUCOBRGODINA(UCENIKOBRACUNDataSet dataSet, int uCOBRMJESEC, int uCOBRGODINA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.UCENIKOBRACUNSet = dataSet;
            this.rowUCENIKOBRACUN = this.UCENIKOBRACUNSet.UCENIKOBRACUN.NewUCENIKOBRACUNRow();
            this.rowUCENIKOBRACUN.UCOBRMJESEC = uCOBRMJESEC;
            this.rowUCENIKOBRACUN.UCOBRGODINA = uCOBRGODINA;
            try
            {
                this.LoadByUCOBRMJESECUCOBRGODINA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound297 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(UCENIKOBRACUNDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.UCENIKOBRACUNSet = dataSet;
            try
            {
                this.LoadChildUcenikobracun(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByUCOBRMJESEC(UCENIKOBRACUNDataSet dataSet, int uCOBRMJESEC, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.UCENIKOBRACUNSet = dataSet;
            this.rowUCENIKOBRACUN = this.UCENIKOBRACUNSet.UCENIKOBRACUN.NewUCENIKOBRACUNRow();
            this.rowUCENIKOBRACUN.UCOBRMJESEC = uCOBRMJESEC;
            try
            {
                this.LoadByUCOBRMJESEC(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [UCOBRMJESEC], [UCOBRGODINA], [AKTIVANZARSM], [UCOBROPIS], [OSNOVICAPODANU] FROM [UCENIKOBRACUN] WITH (NOLOCK) WHERE [UCOBRMJESEC] = @UCOBRMJESEC AND [UCOBRGODINA] = @UCOBRGODINA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRMJESEC", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRGODINA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBRMJESEC"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBRGODINA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound297 = 1;
                this.rowUCENIKOBRACUN["UCOBRMJESEC"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowUCENIKOBRACUN["UCOBRGODINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 1));
                this.rowUCENIKOBRACUN["AKTIVANZARSM"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 2));
                this.rowUCENIKOBRACUN["UCOBROPIS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowUCENIKOBRACUN["OSNOVICAPODANU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4));
                this.sMode297 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode297;
            }
            else
            {
                this.RcdFound297 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = "UCOBRMJESEC";
                parameter.DbType = DbType.Int32;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "UCOBRGODINA";
                parameter2.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmUCENIKOBRACUNSelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [UCENIKOBRACUN] WITH (NOLOCK) ", false);
            this.UCENIKOBRACUNSelect2 = this.cmUCENIKOBRACUNSelect2.FetchData();
            if (this.UCENIKOBRACUNSelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.UCENIKOBRACUNSelect2.GetInt32(0);
            }
            this.UCENIKOBRACUNSelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByUCOBRMJESEC(int uCOBRMJESEC)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmUCENIKOBRACUNSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [UCENIKOBRACUN] WITH (NOLOCK) WHERE [UCOBRMJESEC] = @UCOBRMJESEC ", false);
            if (this.cmUCENIKOBRACUNSelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmUCENIKOBRACUNSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRMJESEC", DbType.Int32));
            }
            this.cmUCENIKOBRACUNSelect1.SetParameter(0, uCOBRMJESEC);
            this.UCENIKOBRACUNSelect1 = this.cmUCENIKOBRACUNSelect1.FetchData();
            if (this.UCENIKOBRACUNSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.UCENIKOBRACUNSelect1.GetInt32(0);
            }
            this.UCENIKOBRACUNSelect1.Close();
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

        public virtual int GetRecordCountByUCOBRMJESEC(int uCOBRMJESEC)
        {
            int internalRecordCountByUCOBRMJESEC;
            try
            {
                this.InitializeMembers();
                internalRecordCountByUCOBRMJESEC = this.GetInternalRecordCountByUCOBRMJESEC(uCOBRMJESEC);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByUCOBRMJESEC;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound297 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__BROJDANAPRAKSEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBRACUNOSNOVICEPRAKSAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove21 = false;
            this.RcdFound298 = 0;
            this.m_SubSelTopString298 = "";
            this.m__AKTIVANZARSMOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__UCOBROPISOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSNOVICAPODANUOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.UCENIKOBRACUNSet = new UCENIKOBRACUNDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertUcenikobracun()
        {
            this.CheckOptimisticConcurrencyUcenikobracun();
            this.AfterConfirmUcenikobracun();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [UCENIKOBRACUN] ([UCOBRMJESEC], [UCOBRGODINA], [AKTIVANZARSM], [UCOBROPIS], [OSNOVICAPODANU]) VALUES (@UCOBRMJESEC, @UCOBRGODINA, @AKTIVANZARSM, @UCOBROPIS, @OSNOVICAPODANU)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRMJESEC", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRGODINA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@AKTIVANZARSM", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBROPIS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICAPODANU", DbType.Currency));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBRMJESEC"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBRGODINA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["AKTIVANZARSM"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBROPIS"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["OSNOVICAPODANU"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new UCENIKOBRACUNDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnUCENIKOBRACUNUpdated(new UCENIKOBRACUNEventArgs(this.rowUCENIKOBRACUN, StatementType.Insert));
            this.ProcessLevelUcenikobracun();
        }

        private void InsertUcenikobracunucenikobracundetail()
        {
            this.CheckOptimisticConcurrencyUcenikobracunucenikobracundetail();
            this.CheckExtendedTableUcenikobracunucenikobracundetail();
            this.AfterConfirmUcenikobracunucenikobracundetail();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [UCENIKOBRACUNUCENIKOBRACUNDETAIL] ([UCOBRMJESEC], [UCOBRGODINA], [BROJDANAPRAKSE], [OBRACUNOSNOVICEPRAKSA], [IDUCENIK]) VALUES (@UCOBRMJESEC, @UCOBRGODINA, @BROJDANAPRAKSE, @OBRACUNOSNOVICEPRAKSA, @IDUCENIK)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRMJESEC", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRGODINA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJDANAPRAKSE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNOSNOVICEPRAKSA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUCENIK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["UCOBRMJESEC"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["UCOBRGODINA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["BROJDANAPRAKSE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["OBRACUNOSNOVICEPRAKSA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["IDUCENIK"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new UCENIKOBRACUNUCENIKOBRACUNDETAILDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnUCENIKOBRACUNUCENIKOBRACUNDETAILUpdated(new UCENIKOBRACUNUCENIKOBRACUNDETAILEventArgs(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL, StatementType.Insert));
        }

        private void LoadByUCOBRMJESEC(int startRow, int maxRows)
        {
            bool enforceConstraints = this.UCENIKOBRACUNSet.EnforceConstraints;
            this.UCENIKOBRACUNSet.UCENIKOBRACUNUCENIKOBRACUNDETAIL.BeginLoadData();
            this.UCENIKOBRACUNSet.UCENIKOBRACUN.BeginLoadData();
            this.ScanByUCOBRMJESEC(startRow, maxRows);
            this.UCENIKOBRACUNSet.UCENIKOBRACUNUCENIKOBRACUNDETAIL.EndLoadData();
            this.UCENIKOBRACUNSet.UCENIKOBRACUN.EndLoadData();
            this.UCENIKOBRACUNSet.EnforceConstraints = enforceConstraints;
            if (this.UCENIKOBRACUNSet.UCENIKOBRACUN.Count > 0)
            {
                this.rowUCENIKOBRACUN = this.UCENIKOBRACUNSet.UCENIKOBRACUN[this.UCENIKOBRACUNSet.UCENIKOBRACUN.Count - 1];
            }
        }

        private void LoadByUCOBRMJESECUCOBRGODINA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.UCENIKOBRACUNSet.EnforceConstraints;
            this.UCENIKOBRACUNSet.UCENIKOBRACUNUCENIKOBRACUNDETAIL.BeginLoadData();
            this.UCENIKOBRACUNSet.UCENIKOBRACUN.BeginLoadData();
            this.ScanByUCOBRMJESECUCOBRGODINA(startRow, maxRows);
            this.UCENIKOBRACUNSet.UCENIKOBRACUNUCENIKOBRACUNDETAIL.EndLoadData();
            this.UCENIKOBRACUNSet.UCENIKOBRACUN.EndLoadData();
            this.UCENIKOBRACUNSet.EnforceConstraints = enforceConstraints;
            if (this.UCENIKOBRACUNSet.UCENIKOBRACUN.Count > 0)
            {
                this.rowUCENIKOBRACUN = this.UCENIKOBRACUNSet.UCENIKOBRACUN[this.UCENIKOBRACUNSet.UCENIKOBRACUN.Count - 1];
            }
        }

        private void LoadChildUcenikobracun(int startRow, int maxRows)
        {
            this.CreateNewRowUcenikobracun();
            bool enforceConstraints = this.UCENIKOBRACUNSet.EnforceConstraints;
            this.UCENIKOBRACUNSet.UCENIKOBRACUNUCENIKOBRACUNDETAIL.BeginLoadData();
            this.UCENIKOBRACUNSet.UCENIKOBRACUN.BeginLoadData();
            this.ScanStartUcenikobracun(startRow, maxRows);
            this.UCENIKOBRACUNSet.UCENIKOBRACUNUCENIKOBRACUNDETAIL.EndLoadData();
            this.UCENIKOBRACUNSet.UCENIKOBRACUN.EndLoadData();
            this.UCENIKOBRACUNSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildUcenikobracunucenikobracundetail()
        {
            this.CreateNewRowUcenikobracunucenikobracundetail();
            this.ScanStartUcenikobracunucenikobracundetail();
        }

        private void LoadDataUcenikobracun(int maxRows)
        {
            int num = 0;
            if (this.RcdFound297 != 0)
            {
                this.ScanLoadUcenikobracun();
                while ((this.RcdFound297 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowUcenikobracun();
                    this.CreateNewRowUcenikobracun();
                    this.ScanNextUcenikobracun();
                }
            }
            if (num > 0)
            {
                this.RcdFound297 = 1;
            }
            this.ScanEndUcenikobracun();
            if (this.UCENIKOBRACUNSet.UCENIKOBRACUN.Count > 0)
            {
                this.rowUCENIKOBRACUN = this.UCENIKOBRACUNSet.UCENIKOBRACUN[this.UCENIKOBRACUNSet.UCENIKOBRACUN.Count - 1];
            }
        }

        private void LoadDataUcenikobracunucenikobracundetail()
        {
            while (this.RcdFound298 != 0)
            {
                this.LoadRowUcenikobracunucenikobracundetail();
                this.CreateNewRowUcenikobracunucenikobracundetail();
                this.ScanNextUcenikobracunucenikobracundetail();
            }
            this.ScanEndUcenikobracunucenikobracundetail();
        }

        private void LoadRowUcenikobracun()
        {
            this.AddRowUcenikobracun();
        }

        private void LoadRowUcenikobracunucenikobracundetail()
        {
            this.AddRowUcenikobracunucenikobracundetail();
        }

        private void OnDeleteControlsUcenikobracunucenikobracundetail()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [PREZIMEUCENIK], [IMEUCENIK], [RAZRED], [ODJELJENJE] FROM [UCENIK] WITH (NOLOCK) WHERE [IDUCENIK] = @IDUCENIK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUCENIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["IDUCENIK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["PREZIMEUCENIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["IMEUCENIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["RAZRED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2));
                this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["ODJELJENJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
            }
            reader.Close();
        }

        private void OnUCENIKOBRACUNUCENIKOBRACUNDETAILUpdated(UCENIKOBRACUNUCENIKOBRACUNDETAILEventArgs e)
        {
            if (this.UCENIKOBRACUNUCENIKOBRACUNDETAILUpdated != null)
            {
                UCENIKOBRACUNUCENIKOBRACUNDETAILUpdateEventHandler uCENIKOBRACUNUCENIKOBRACUNDETAILUpdatedEvent = this.UCENIKOBRACUNUCENIKOBRACUNDETAILUpdated;
                if (uCENIKOBRACUNUCENIKOBRACUNDETAILUpdatedEvent != null)
                {
                    uCENIKOBRACUNUCENIKOBRACUNDETAILUpdatedEvent(this, e);
                }
            }
        }

        private void OnUCENIKOBRACUNUCENIKOBRACUNDETAILUpdating(UCENIKOBRACUNUCENIKOBRACUNDETAILEventArgs e)
        {
            if (this.UCENIKOBRACUNUCENIKOBRACUNDETAILUpdating != null)
            {
                UCENIKOBRACUNUCENIKOBRACUNDETAILUpdateEventHandler uCENIKOBRACUNUCENIKOBRACUNDETAILUpdatingEvent = this.UCENIKOBRACUNUCENIKOBRACUNDETAILUpdating;
                if (uCENIKOBRACUNUCENIKOBRACUNDETAILUpdatingEvent != null)
                {
                    uCENIKOBRACUNUCENIKOBRACUNDETAILUpdatingEvent(this, e);
                }
            }
        }

        private void OnUCENIKOBRACUNUpdated(UCENIKOBRACUNEventArgs e)
        {
            if (this.UCENIKOBRACUNUpdated != null)
            {
                UCENIKOBRACUNUpdateEventHandler uCENIKOBRACUNUpdatedEvent = this.UCENIKOBRACUNUpdated;
                if (uCENIKOBRACUNUpdatedEvent != null)
                {
                    uCENIKOBRACUNUpdatedEvent(this, e);
                }
            }
        }

        private void OnUCENIKOBRACUNUpdating(UCENIKOBRACUNEventArgs e)
        {
            if (this.UCENIKOBRACUNUpdating != null)
            {
                UCENIKOBRACUNUpdateEventHandler uCENIKOBRACUNUpdatingEvent = this.UCENIKOBRACUNUpdating;
                if (uCENIKOBRACUNUpdatingEvent != null)
                {
                    uCENIKOBRACUNUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelUcenikobracun()
        {
            this.sMode297 = this.Gx_mode;
            this.ProcessNestedLevelUcenikobracunucenikobracundetail();
            this.Gx_mode = this.sMode297;
        }

        private void ProcessNestedLevelUcenikobracunucenikobracundetail()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.UCENIKOBRACUNSet.UCENIKOBRACUNUCENIKOBRACUNDETAIL.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL = (UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow) current;
                    if (Helpers.IsRowChanged(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL))
                    {
                        bool flag = false;
                        if (this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL.RowState != DataRowState.Deleted)
                        {
                            flag = (this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL.UCOBRMJESEC == this.rowUCENIKOBRACUN.UCOBRMJESEC) && (this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL.UCOBRGODINA == this.rowUCENIKOBRACUN.UCOBRGODINA);
                        }
                        else
                        {
                            flag = this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["UCOBRMJESEC", DataRowVersion.Original].Equals(this.rowUCENIKOBRACUN.UCOBRMJESEC) && this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["UCOBRGODINA", DataRowVersion.Original].Equals(this.rowUCENIKOBRACUN.UCOBRGODINA);
                        }
                        if (flag)
                        {
                            this.ReadRowUcenikobracunucenikobracundetail();
                            if (this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertUcenikobracunucenikobracundetail();
                            }
                            else
                            {
                                if (this._Gxremove21)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteUcenikobracunucenikobracundetail();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateUcenikobracunucenikobracundetail();
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

        private void ReadRowUcenikobracun()
        {
            this.Gx_mode = Mode.FromRowState(this.rowUCENIKOBRACUN.RowState);
            if (this.rowUCENIKOBRACUN.RowState != DataRowState.Added)
            {
                this.m__AKTIVANZARSMOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["AKTIVANZARSM", DataRowVersion.Original]);
                this.m__UCOBROPISOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBROPIS", DataRowVersion.Original]);
                this.m__OSNOVICAPODANUOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["OSNOVICAPODANU", DataRowVersion.Original]);
            }
            else
            {
                this.m__AKTIVANZARSMOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["AKTIVANZARSM"]);
                this.m__UCOBROPISOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBROPIS"]);
                this.m__OSNOVICAPODANUOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["OSNOVICAPODANU"]);
            }
            this._Gxremove = this.rowUCENIKOBRACUN.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowUCENIKOBRACUN = (UCENIKOBRACUNDataSet.UCENIKOBRACUNRow) DataSetUtil.CloneOriginalDataRow(this.rowUCENIKOBRACUN);
            }
        }

        private void ReadRowUcenikobracunucenikobracundetail()
        {
            this.Gx_mode = Mode.FromRowState(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL.RowState);
            if (this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL.RowState != DataRowState.Added)
            {
                this.m__BROJDANAPRAKSEOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["BROJDANAPRAKSE", DataRowVersion.Original]);
                this.m__OBRACUNOSNOVICEPRAKSAOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["OBRACUNOSNOVICEPRAKSA", DataRowVersion.Original]);
            }
            else
            {
                this.m__BROJDANAPRAKSEOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["BROJDANAPRAKSE"]);
                this.m__OBRACUNOSNOVICEPRAKSAOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["OBRACUNOSNOVICEPRAKSA"]);
            }
            this._Gxremove21 = this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL.RowState == DataRowState.Deleted;
            if (this._Gxremove21)
            {
                this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL = (UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow) DataSetUtil.CloneOriginalDataRow(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL);
            }
        }

        private void ScanByUCOBRMJESEC(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[UCOBRMJESEC] = @UCOBRMJESEC";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString297 + "  FROM [UCENIKOBRACUN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[UCOBRMJESEC], TM1.[UCOBRGODINA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString297, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[UCOBRMJESEC], TM1.[UCOBRGODINA] ) AS DK_PAGENUM   FROM [UCENIKOBRACUN] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString297 + " FROM [UCENIKOBRACUN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[UCOBRMJESEC], TM1.[UCOBRGODINA] ";
            }
            this.cmUCENIKOBRACUNSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmUCENIKOBRACUNSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmUCENIKOBRACUNSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRMJESEC", DbType.Int32));
            }
            this.cmUCENIKOBRACUNSelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBRMJESEC"]));
            this.UCENIKOBRACUNSelect5 = this.cmUCENIKOBRACUNSelect5.FetchData();
            this.RcdFound297 = 0;
            this.ScanLoadUcenikobracun();
            this.LoadDataUcenikobracun(maxRows);
            if (this.RcdFound297 > 0)
            {
                this.SubLvlScanStartUcenikobracunucenikobracundetail(this.m_WhereString, startRow, maxRows);
                this.SetParametersUCOBRMJESECUcenikobracun(this.cmUCENIKOBRACUNUCENIKOBRACUNDETAILSelect2);
                this.SubLvlFetchUcenikobracunucenikobracundetail();
                this.SubLoadDataUcenikobracunucenikobracundetail();
            }
        }

        private void ScanByUCOBRMJESECUCOBRGODINA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[UCOBRMJESEC] = @UCOBRMJESEC and TM1.[UCOBRGODINA] = @UCOBRGODINA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString297 + "  FROM [UCENIKOBRACUN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[UCOBRMJESEC], TM1.[UCOBRGODINA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString297, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[UCOBRMJESEC], TM1.[UCOBRGODINA] ) AS DK_PAGENUM   FROM [UCENIKOBRACUN] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString297 + " FROM [UCENIKOBRACUN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[UCOBRMJESEC], TM1.[UCOBRGODINA] ";
            }
            this.cmUCENIKOBRACUNSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmUCENIKOBRACUNSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmUCENIKOBRACUNSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRMJESEC", DbType.Int32));
                this.cmUCENIKOBRACUNSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRGODINA", DbType.Int32));
            }
            this.cmUCENIKOBRACUNSelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBRMJESEC"]));
            this.cmUCENIKOBRACUNSelect5.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBRGODINA"]));
            this.UCENIKOBRACUNSelect5 = this.cmUCENIKOBRACUNSelect5.FetchData();
            this.RcdFound297 = 0;
            this.ScanLoadUcenikobracun();
            this.LoadDataUcenikobracun(maxRows);
            if (this.RcdFound297 > 0)
            {
                this.SubLvlScanStartUcenikobracunucenikobracundetail(this.m_WhereString, startRow, maxRows);
                this.SetParametersUCOBRMJESECUCOBRGODINAUcenikobracun(this.cmUCENIKOBRACUNUCENIKOBRACUNDETAILSelect2);
                this.SubLvlFetchUcenikobracunucenikobracundetail();
                this.SubLoadDataUcenikobracunucenikobracundetail();
            }
        }

        private void ScanEndUcenikobracun()
        {
            this.UCENIKOBRACUNSelect5.Close();
        }

        private void ScanEndUcenikobracunucenikobracundetail()
        {
            this.UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2.Close();
        }

        private void ScanLoadUcenikobracun()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmUCENIKOBRACUNSelect5.HasMoreRows)
            {
                this.RcdFound297 = 1;
                this.rowUCENIKOBRACUN["UCOBRMJESEC"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.UCENIKOBRACUNSelect5, 0));
                this.rowUCENIKOBRACUN["UCOBRGODINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.UCENIKOBRACUNSelect5, 1));
                this.rowUCENIKOBRACUN["AKTIVANZARSM"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.UCENIKOBRACUNSelect5, 2));
                this.rowUCENIKOBRACUN["UCOBROPIS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKOBRACUNSelect5, 3));
                this.rowUCENIKOBRACUN["OSNOVICAPODANU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.UCENIKOBRACUNSelect5, 4));
            }
        }

        private void ScanLoadUcenikobracunucenikobracundetail()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmUCENIKOBRACUNUCENIKOBRACUNDETAILSelect2.HasMoreRows)
            {
                this.RcdFound298 = 1;
                this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["UCOBRMJESEC"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2, 0));
                this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["UCOBRGODINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2, 1));
                this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["PREZIMEUCENIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2, 2));
                this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["IMEUCENIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2, 3));
                this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["BROJDANAPRAKSE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2, 4));
                this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["OBRACUNOSNOVICEPRAKSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2, 5));
                this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["RAZRED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2, 6));
                this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["ODJELJENJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2, 7));
                this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["IDUCENIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2, 8));
                this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["PREZIMEUCENIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2, 2));
                this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["IMEUCENIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2, 3));
                this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["RAZRED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2, 6));
                this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["ODJELJENJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2, 7));
            }
        }

        private void ScanNextUcenikobracun()
        {
            this.cmUCENIKOBRACUNSelect5.HasMoreRows = this.UCENIKOBRACUNSelect5.Read();
            this.RcdFound297 = 0;
            this.ScanLoadUcenikobracun();
        }

        private void ScanNextUcenikobracunucenikobracundetail()
        {
            this.cmUCENIKOBRACUNUCENIKOBRACUNDETAILSelect2.HasMoreRows = this.UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2.Read();
            this.RcdFound298 = 0;
            this.ScanLoadUcenikobracunucenikobracundetail();
        }

        private void ScanStartUcenikobracun(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString297 + "  FROM [UCENIKOBRACUN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[UCOBRMJESEC], TM1.[UCOBRGODINA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString297, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[UCOBRMJESEC], TM1.[UCOBRGODINA] ) AS DK_PAGENUM   FROM [UCENIKOBRACUN] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString297 + " FROM [UCENIKOBRACUN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[UCOBRMJESEC], TM1.[UCOBRGODINA] ";
            }
            this.cmUCENIKOBRACUNSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.UCENIKOBRACUNSelect5 = this.cmUCENIKOBRACUNSelect5.FetchData();
            this.RcdFound297 = 0;
            this.ScanLoadUcenikobracun();
            this.LoadDataUcenikobracun(maxRows);
            if (this.RcdFound297 > 0)
            {
                this.SubLvlScanStartUcenikobracunucenikobracundetail(this.m_WhereString, startRow, maxRows);
                this.SetParametersUcenikobracunUcenikobracun(this.cmUCENIKOBRACUNUCENIKOBRACUNDETAILSelect2);
                this.SubLvlFetchUcenikobracunucenikobracundetail();
                this.SubLoadDataUcenikobracunucenikobracundetail();
            }
        }

        private void ScanStartUcenikobracunucenikobracundetail()
        {
            this.cmUCENIKOBRACUNUCENIKOBRACUNDETAILSelect2 = this.connDefault.GetCommand("SELECT T1.[UCOBRMJESEC], T1.[UCOBRGODINA], T2.[PREZIMEUCENIK], T2.[IMEUCENIK], T1.[BROJDANAPRAKSE], T1.[OBRACUNOSNOVICEPRAKSA], T2.[RAZRED], T2.[ODJELJENJE], T1.[IDUCENIK] FROM ([UCENIKOBRACUNUCENIKOBRACUNDETAIL] T1 WITH (NOLOCK) INNER JOIN [UCENIK] T2 WITH (NOLOCK) ON T2.[IDUCENIK] = T1.[IDUCENIK]) WHERE T1.[UCOBRMJESEC] = @UCOBRMJESEC and T1.[UCOBRGODINA] = @UCOBRGODINA ORDER BY T1.[UCOBRMJESEC], T1.[UCOBRGODINA], T1.[IDUCENIK] ", false);
            if (this.cmUCENIKOBRACUNUCENIKOBRACUNDETAILSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmUCENIKOBRACUNUCENIKOBRACUNDETAILSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRMJESEC", DbType.Int32));
                this.cmUCENIKOBRACUNUCENIKOBRACUNDETAILSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRGODINA", DbType.Int32));
            }
            this.cmUCENIKOBRACUNUCENIKOBRACUNDETAILSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["UCOBRMJESEC"]));
            this.cmUCENIKOBRACUNUCENIKOBRACUNDETAILSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["UCOBRGODINA"]));
            this.UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2 = this.cmUCENIKOBRACUNUCENIKOBRACUNDETAILSelect2.FetchData();
            this.RcdFound298 = 0;
            this.ScanLoadUcenikobracunucenikobracundetail();
        }

        private void SetParametersUcenikobracunUcenikobracun(ReadWriteCommand m_Command)
        {
        }

        private void SetParametersUCOBRMJESECUcenikobracun(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRMJESEC", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBRMJESEC"]));
        }

        private void SetParametersUCOBRMJESECUCOBRGODINAUcenikobracun(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRMJESEC", DbType.Int32));
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRGODINA", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBRMJESEC"]));
            m_Command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBRGODINA"]));
        }

        private void SkipNextUcenikobracunucenikobracundetail()
        {
            this.cmUCENIKOBRACUNUCENIKOBRACUNDETAILSelect2.HasMoreRows = this.UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2.Read();
            this.RcdFound298 = 0;
            if (this.cmUCENIKOBRACUNUCENIKOBRACUNDETAILSelect2.HasMoreRows)
            {
                this.RcdFound298 = 1;
            }
        }

        private void SubLoadDataUcenikobracunucenikobracundetail()
        {
            while (this.RcdFound298 != 0)
            {
                this.LoadRowUcenikobracunucenikobracundetail();
                this.CreateNewRowUcenikobracunucenikobracundetail();
                this.ScanNextUcenikobracunucenikobracundetail();
            }
            this.ScanEndUcenikobracunucenikobracundetail();
        }

        private void SubLvlFetchUcenikobracunucenikobracundetail()
        {
            this.CreateNewRowUcenikobracunucenikobracundetail();
            this.UCENIKOBRACUNUCENIKOBRACUNDETAILSelect2 = this.cmUCENIKOBRACUNUCENIKOBRACUNDETAILSelect2.FetchData();
            this.RcdFound298 = 0;
            this.ScanLoadUcenikobracunucenikobracundetail();
        }

        private void SubLvlScanStartUcenikobracunucenikobracundetail(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString298 = "(SELECT TOP " + maxRows.ToString() + " TM1.[UCOBRMJESEC],TM1.[UCOBRGODINA]  FROM [UCENIKOBRACUN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[UCOBRMJESEC], TM1.[UCOBRGODINA] )";
                    this.scmdbuf = "SELECT T1.[UCOBRMJESEC], T1.[UCOBRGODINA], T3.[PREZIMEUCENIK], T3.[IMEUCENIK], T1.[BROJDANAPRAKSE], T1.[OBRACUNOSNOVICEPRAKSA], T3.[RAZRED], T3.[ODJELJENJE], T1.[IDUCENIK] FROM (([UCENIKOBRACUNUCENIKOBRACUNDETAIL] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString298 + "  TMX ON TMX.[UCOBRMJESEC] = T1.[UCOBRMJESEC] AND TMX.[UCOBRGODINA] = T1.[UCOBRGODINA]) INNER JOIN [UCENIK] T3 WITH (NOLOCK) ON T3.[IDUCENIK] = T1.[IDUCENIK]) ORDER BY T1.[UCOBRMJESEC], T1.[UCOBRGODINA], T1.[IDUCENIK]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[UCOBRMJESEC],TM1.[UCOBRGODINA], ROW_NUMBER() OVER  (  ORDER BY TM1.[UCOBRMJESEC], TM1.[UCOBRGODINA]  ) AS DK_PAGENUM   FROM [UCENIKOBRACUN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString298 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[UCOBRMJESEC], T1.[UCOBRGODINA], T3.[PREZIMEUCENIK], T3.[IMEUCENIK], T1.[BROJDANAPRAKSE], T1.[OBRACUNOSNOVICEPRAKSA], T3.[RAZRED], T3.[ODJELJENJE], T1.[IDUCENIK] FROM (([UCENIKOBRACUNUCENIKOBRACUNDETAIL] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString298 + "  TMX ON TMX.[UCOBRMJESEC] = T1.[UCOBRMJESEC] AND TMX.[UCOBRGODINA] = T1.[UCOBRGODINA]) INNER JOIN [UCENIK] T3 WITH (NOLOCK) ON T3.[IDUCENIK] = T1.[IDUCENIK]) ORDER BY T1.[UCOBRMJESEC], T1.[UCOBRGODINA], T1.[IDUCENIK]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString298 = "[UCENIKOBRACUN]";
                this.scmdbuf = "SELECT T1.[UCOBRMJESEC], T1.[UCOBRGODINA], T3.[PREZIMEUCENIK], T3.[IMEUCENIK], T1.[BROJDANAPRAKSE], T1.[OBRACUNOSNOVICEPRAKSA], T3.[RAZRED], T3.[ODJELJENJE], T1.[IDUCENIK] FROM (([UCENIKOBRACUNUCENIKOBRACUNDETAIL] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString298 + "  TM1 WITH (NOLOCK) ON TM1.[UCOBRMJESEC] = T1.[UCOBRMJESEC] AND TM1.[UCOBRGODINA] = T1.[UCOBRGODINA]) INNER JOIN [UCENIK] T3 WITH (NOLOCK) ON T3.[IDUCENIK] = T1.[IDUCENIK])" + this.m_WhereString + " ORDER BY T1.[UCOBRMJESEC], T1.[UCOBRGODINA], T1.[IDUCENIK] ";
            }
            this.cmUCENIKOBRACUNUCENIKOBRACUNDETAILSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.UCENIKOBRACUNSet = (UCENIKOBRACUNDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.UCENIKOBRACUNSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.UCENIKOBRACUNSet.UCENIKOBRACUN.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        UCENIKOBRACUNDataSet.UCENIKOBRACUNRow current = (UCENIKOBRACUNDataSet.UCENIKOBRACUNRow) enumerator.Current;
                        this.rowUCENIKOBRACUN = current;
                        if (Helpers.IsRowChanged(this.rowUCENIKOBRACUN))
                        {
                            this.ReadRowUcenikobracun();
                            if (this.rowUCENIKOBRACUN.RowState == DataRowState.Added)
                            {
                                this.InsertUcenikobracun();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateUcenikobracun();
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

        private void UpdateUcenikobracun()
        {
            this.CheckOptimisticConcurrencyUcenikobracun();
            this.AfterConfirmUcenikobracun();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [UCENIKOBRACUN] SET [AKTIVANZARSM]=@AKTIVANZARSM, [UCOBROPIS]=@UCOBROPIS, [OSNOVICAPODANU]=@OSNOVICAPODANU  WHERE [UCOBRMJESEC] = @UCOBRMJESEC AND [UCOBRGODINA] = @UCOBRGODINA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@AKTIVANZARSM", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBROPIS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICAPODANU", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRMJESEC", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRGODINA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["AKTIVANZARSM"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBROPIS"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["OSNOVICAPODANU"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBRMJESEC"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUN["UCOBRGODINA"]));
            command.ExecuteStmt();
            this.OnUCENIKOBRACUNUpdated(new UCENIKOBRACUNEventArgs(this.rowUCENIKOBRACUN, StatementType.Update));
            this.ProcessLevelUcenikobracun();
        }

        private void UpdateUcenikobracunucenikobracundetail()
        {
            this.CheckOptimisticConcurrencyUcenikobracunucenikobracundetail();
            this.CheckExtendedTableUcenikobracunucenikobracundetail();
            this.AfterConfirmUcenikobracunucenikobracundetail();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [UCENIKOBRACUNUCENIKOBRACUNDETAIL] SET [BROJDANAPRAKSE]=@BROJDANAPRAKSE, [OBRACUNOSNOVICEPRAKSA]=@OBRACUNOSNOVICEPRAKSA  WHERE [UCOBRMJESEC] = @UCOBRMJESEC AND [UCOBRGODINA] = @UCOBRGODINA AND [IDUCENIK] = @IDUCENIK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJDANAPRAKSE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBRACUNOSNOVICEPRAKSA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRMJESEC", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRGODINA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUCENIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["BROJDANAPRAKSE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["OBRACUNOSNOVICEPRAKSA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["UCOBRMJESEC"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["UCOBRGODINA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL["IDUCENIK"]));
            command.ExecuteStmt();
            this.OnUCENIKOBRACUNUCENIKOBRACUNDETAILUpdated(new UCENIKOBRACUNUCENIKOBRACUNDETAILEventArgs(this.rowUCENIKOBRACUNUCENIKOBRACUNDETAIL, StatementType.Update));
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
        public class UCENIKForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public UCENIKForeignKeyNotFoundException()
            {
            }

            public UCENIKForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected UCENIKForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UCENIKForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class UCENIKOBRACUNDataChangedException : DataChangedException
        {
            public UCENIKOBRACUNDataChangedException()
            {
            }

            public UCENIKOBRACUNDataChangedException(string message) : base(message)
            {
            }

            protected UCENIKOBRACUNDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UCENIKOBRACUNDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class UCENIKOBRACUNDataLockedException : DataLockedException
        {
            public UCENIKOBRACUNDataLockedException()
            {
            }

            public UCENIKOBRACUNDataLockedException(string message) : base(message)
            {
            }

            protected UCENIKOBRACUNDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UCENIKOBRACUNDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class UCENIKOBRACUNDuplicateKeyException : DuplicateKeyException
        {
            public UCENIKOBRACUNDuplicateKeyException()
            {
            }

            public UCENIKOBRACUNDuplicateKeyException(string message) : base(message)
            {
            }

            protected UCENIKOBRACUNDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UCENIKOBRACUNDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class UCENIKOBRACUNEventArgs : EventArgs
        {
            private UCENIKOBRACUNDataSet.UCENIKOBRACUNRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public UCENIKOBRACUNEventArgs(UCENIKOBRACUNDataSet.UCENIKOBRACUNRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public UCENIKOBRACUNDataSet.UCENIKOBRACUNRow Row
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
        public class UCENIKOBRACUNNotFoundException : DataNotFoundException
        {
            public UCENIKOBRACUNNotFoundException()
            {
            }

            public UCENIKOBRACUNNotFoundException(string message) : base(message)
            {
            }

            protected UCENIKOBRACUNNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UCENIKOBRACUNNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class UCENIKOBRACUNUCENIKOBRACUNDETAILDataChangedException : DataChangedException
        {
            public UCENIKOBRACUNUCENIKOBRACUNDETAILDataChangedException()
            {
            }

            public UCENIKOBRACUNUCENIKOBRACUNDETAILDataChangedException(string message) : base(message)
            {
            }

            protected UCENIKOBRACUNUCENIKOBRACUNDETAILDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UCENIKOBRACUNUCENIKOBRACUNDETAILDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class UCENIKOBRACUNUCENIKOBRACUNDETAILDataLockedException : DataLockedException
        {
            public UCENIKOBRACUNUCENIKOBRACUNDETAILDataLockedException()
            {
            }

            public UCENIKOBRACUNUCENIKOBRACUNDETAILDataLockedException(string message) : base(message)
            {
            }

            protected UCENIKOBRACUNUCENIKOBRACUNDETAILDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UCENIKOBRACUNUCENIKOBRACUNDETAILDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class UCENIKOBRACUNUCENIKOBRACUNDETAILDuplicateKeyException : DuplicateKeyException
        {
            public UCENIKOBRACUNUCENIKOBRACUNDETAILDuplicateKeyException()
            {
            }

            public UCENIKOBRACUNUCENIKOBRACUNDETAILDuplicateKeyException(string message) : base(message)
            {
            }

            protected UCENIKOBRACUNUCENIKOBRACUNDETAILDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UCENIKOBRACUNUCENIKOBRACUNDETAILDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class UCENIKOBRACUNUCENIKOBRACUNDETAILEventArgs : EventArgs
        {
            private UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public UCENIKOBRACUNUCENIKOBRACUNDETAILEventArgs(UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public UCENIKOBRACUNDataSet.UCENIKOBRACUNUCENIKOBRACUNDETAILRow Row
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

        public delegate void UCENIKOBRACUNUCENIKOBRACUNDETAILUpdateEventHandler(object sender, UCENIKOBRACUNDataAdapter.UCENIKOBRACUNUCENIKOBRACUNDETAILEventArgs e);

        public delegate void UCENIKOBRACUNUpdateEventHandler(object sender, UCENIKOBRACUNDataAdapter.UCENIKOBRACUNEventArgs e);
    }
}

