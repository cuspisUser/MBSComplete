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

    public class PLANDataAdapter : IDataAdapter, IPLANDataAdapter
    {
        private bool _Gxremove;
        private bool _Gxremove21;
        private ReadWriteCommand cmPLANORGKONSelect2;
        private ReadWriteCommand cmPLANORGSelect2;
        private ReadWriteCommand cmPLANSelect1;
        private ReadWriteCommand cmPLANSelect2;
        private ReadWriteCommand cmPLANSelect3;
        private ReadWriteCommand cmPLANSelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__PLANIRANIIZNOSOriginal;
        private object m__RADNINAZIVPLANAOriginal;
        private readonly string m_SelectString237 = "TM1.[IDPLAN], TM1.[RADNINAZIVPLANA], TM1.[PLANGODINAIDGODINE] AS PLANGODINAIDGODINE";
        private string m_SubSelTopString238;
        private string m_SubSelTopString239;
        private string m_WhereString;
        private IDataReader PLANORGKONSelect2;
        private IDataReader PLANORGSelect2;
        private IDataReader PLANSelect1;
        private IDataReader PLANSelect2;
        private IDataReader PLANSelect3;
        private IDataReader PLANSelect6;
        private PLANDataSet PLANSet;
        private short RcdFound237;
        private short RcdFound238;
        private short RcdFound239;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private PLANDataSet.PLANRow rowPLAN;
        private PLANDataSet.PLANORGRow rowPLANORG;
        private PLANDataSet.PLANORGKONRow rowPLANORGKON;
        private string scmdbuf;
        private StatementType sMode237;
        private StatementType sMode238;
        private StatementType sMode239;

        public event PLANORGKONUpdateEventHandler PLANORGKONUpdated;

        public event PLANORGKONUpdateEventHandler PLANORGKONUpdating;

        public event PLANORGUpdateEventHandler PLANORGUpdated;

        public event PLANORGUpdateEventHandler PLANORGUpdating;

        public event PLANUpdateEventHandler PLANUpdated;

        public event PLANUpdateEventHandler PLANUpdating;

        private void AddRowPlan()
        {
            this.PLANSet.PLAN.AddPLANRow(this.rowPLAN);
        }

        private void AddRowPlanorg()
        {
            this.PLANSet.PLANORG.AddPLANORGRow(this.rowPLANORG);
        }

        private void AddRowPlanorgkon()
        {
            this.PLANSet.PLANORGKON.AddPLANORGKONRow(this.rowPLANORGKON);
        }

        private void AfterConfirmPlan()
        {
            this.OnPLANUpdating(new PLANEventArgs(this.rowPLAN, this.Gx_mode));
        }

        private void AfterConfirmPlanorg()
        {
            this.OnPLANORGUpdating(new PLANORGEventArgs(this.rowPLANORG, this.Gx_mode));
        }

        private void AfterConfirmPlanorgkon()
        {
            this.OnPLANORGKONUpdating(new PLANORGKONEventArgs(this.rowPLANORGKON, this.Gx_mode));
        }

        private void CheckExtendedTablePlanorg()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVORGJED] AS PLANOJNAZIVORGJED FROM [ORGJED] WITH (NOLOCK) WHERE [IDORGJED] = @PLANOJIDORGJED ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANOJIDORGJED", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLANORG["PLANOJIDORGJED"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new ORGJEDForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ORGJED") }));
            }
            this.rowPLANORG["PLANOJNAZIVORGJED"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0))));
            reader.Close();
        }

        private void CheckIntegrityErrorsPlan()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDGODINE] AS PLANGODINAIDGODINE FROM [GODINE] WITH (NOLOCK) WHERE [IDGODINE] = @PLANGODINAIDGODINE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLAN["PLANGODINAIDGODINE"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new GODINEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("GODINE") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckIntegrityErrorsPlanorgkon()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKONTO] AS PLANKONTOIDKONTO FROM [KONTO] WITH (NOLOCK) WHERE [IDKONTO] = @PLANKONTOIDKONTO ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANKONTOIDKONTO", DbType.String, 14));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANKONTOIDKONTO"]))));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new KONTOForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KONTO") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyPlan()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDPLAN], [RADNINAZIVPLANA], [PLANGODINAIDGODINE] AS PLANGODINAIDGODINE FROM [PLAN] WITH (UPDLOCK) WHERE [IDPLAN] = @IDPLAN AND [PLANGODINAIDGODINE] = @PLANGODINAIDGODINE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLAN["IDPLAN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPLAN["PLANGODINAIDGODINE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new PLANDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("PLAN") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__RADNINAZIVPLANAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new PLANDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("PLAN") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyPlanorg()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDPLAN], [PLANGODINAIDGODINE] AS PLANGODINAIDGODINE, [PLANOJIDORGJED] AS PLANOJIDORGJED FROM [PLANORG] WITH (UPDLOCK) WHERE [IDPLAN] = @IDPLAN AND [PLANGODINAIDGODINE] = @PLANGODINAIDGODINE AND [PLANOJIDORGJED] = @PLANOJIDORGJED ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANOJIDORGJED", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLANORG["IDPLAN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPLANORG["PLANGODINAIDGODINE"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPLANORG["PLANOJIDORGJED"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new PLANORGDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("PLANORG") }));
                }
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new PLANORGDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("PLANORG") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyPlanorgkon()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDPLAN], [PLANGODINAIDGODINE] AS PLANGODINAIDGODINE, [PLANOJIDORGJED] AS PLANOJIDORGJED, [PLANIRANIIZNOS], [PLANKONTOIDKONTO] AS PLANKONTOIDKONTO FROM [PLANORGKON] WITH (UPDLOCK) WHERE [IDPLAN] = @IDPLAN AND [PLANGODINAIDGODINE] = @PLANGODINAIDGODINE AND [PLANOJIDORGJED] = @PLANOJIDORGJED AND [PLANKONTOIDKONTO] = @PLANKONTOIDKONTO ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANOJIDORGJED", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANKONTOIDKONTO", DbType.String, 14));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["IDPLAN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANGODINAIDGODINE"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANOJIDORGJED"]));
                command.SetParameter(3, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANKONTOIDKONTO"]))));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new PLANORGKONDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("PLANORGKON") }));
                }
                if (!command.HasMoreRows || !this.m__PLANIRANIIZNOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3))))
                {
                    reader.Close();
                    throw new PLANORGKONDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("PLANORGKON") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowPlan()
        {
            this.rowPLAN = this.PLANSet.PLAN.NewPLANRow();
        }

        private void CreateNewRowPlanorg()
        {
            this.rowPLANORG = this.PLANSet.PLANORG.NewPLANORGRow();
        }

        private void CreateNewRowPlanorgkon()
        {
            this.rowPLANORGKON = this.PLANSet.PLANORGKON.NewPLANORGKONRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyPlan();
            this.ProcessNestedLevelPlanorg();
            this.AfterConfirmPlan();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [PLAN]  WHERE [IDPLAN] = @IDPLAN AND [PLANGODINAIDGODINE] = @PLANGODINAIDGODINE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLAN["IDPLAN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPLAN["PLANGODINAIDGODINE"]));
            command.ExecuteStmt();
            this.OnPLANUpdated(new PLANEventArgs(this.rowPLAN, StatementType.Delete));
            this.rowPLAN.Delete();
            this.sMode237 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode237;
        }

        private void DeletePlanorg()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyPlanorg();
            this.OnDeleteControlsPlanorg();
            this.ProcessNestedLevelPlanorgkon();
            this.AfterConfirmPlanorg();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [PLANORG]  WHERE [IDPLAN] = @IDPLAN AND [PLANGODINAIDGODINE] = @PLANGODINAIDGODINE AND [PLANOJIDORGJED] = @PLANOJIDORGJED", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANOJIDORGJED", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLANORG["IDPLAN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPLANORG["PLANGODINAIDGODINE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPLANORG["PLANOJIDORGJED"]));
            command.ExecuteStmt();
            this.OnPLANORGUpdated(new PLANORGEventArgs(this.rowPLANORG, StatementType.Delete));
            this.rowPLANORG.Delete();
            this.sMode238 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode238;
        }

        private void DeletePlanorgkon()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyPlanorgkon();
            this.AfterConfirmPlanorgkon();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [PLANORGKON]  WHERE [IDPLAN] = @IDPLAN AND [PLANGODINAIDGODINE] = @PLANGODINAIDGODINE AND [PLANOJIDORGJED] = @PLANOJIDORGJED AND [PLANKONTOIDKONTO] = @PLANKONTOIDKONTO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANOJIDORGJED", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANKONTOIDKONTO", DbType.String, 14));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["IDPLAN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANGODINAIDGODINE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANOJIDORGJED"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANKONTOIDKONTO"]))));
            command.ExecuteStmt();
            this.OnPLANORGKONUpdated(new PLANORGKONEventArgs(this.rowPLANORGKON, StatementType.Delete));
            this.rowPLANORGKON.Delete();
            this.sMode239 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode239;
        }

        public virtual int Fill(PLANDataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), short.Parse(this.fillDataParameters[1].Value.ToString()));
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.PLANSet = dataSet;
                    this.LoadChildPlan(0, -1);
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
            this.PLANSet = (PLANDataSet) dataSet;
            if (this.PLANSet != null)
            {
                return this.Fill(this.PLANSet);
            }
            this.PLANSet = new PLANDataSet();
            this.Fill(this.PLANSet);
            dataSet.Merge(this.PLANSet);
            return 0;
        }

        public virtual int Fill(PLANDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDPLAN"]), Conversions.ToShort(dataRecord["PLANGODINAIDGODINE"]));
        }

        public virtual int Fill(PLANDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDPLAN"]), Conversions.ToShort(dataRecord["PLANGODINAIDGODINE"]));
        }

        public virtual int Fill(PLANDataSet dataSet, int iDPLAN, short pLANGODINAIDGODINE)
        {
            if (!this.FillByIDPLANPLANGODINAIDGODINE(dataSet, iDPLAN, pLANGODINAIDGODINE))
            {
                throw new PLANNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("PLAN") }));
            }
            return 0;
        }

        public virtual int FillByIDPLAN(PLANDataSet dataSet, int iDPLAN)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PLANSet = dataSet;
            this.rowPLAN = this.PLANSet.PLAN.NewPLANRow();
            this.rowPLAN.IDPLAN = iDPLAN;
            try
            {
                this.LoadByIDPLAN(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByIDPLANPLANGODINAIDGODINE(PLANDataSet dataSet, int iDPLAN, short pLANGODINAIDGODINE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PLANSet = dataSet;
            this.rowPLAN = this.PLANSet.PLAN.NewPLANRow();
            this.rowPLAN.IDPLAN = iDPLAN;
            this.rowPLAN.PLANGODINAIDGODINE = pLANGODINAIDGODINE;
            try
            {
                this.LoadByIDPLANPLANGODINAIDGODINE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound237 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByPLANGODINAIDGODINE(PLANDataSet dataSet, short pLANGODINAIDGODINE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PLANSet = dataSet;
            this.rowPLAN = this.PLANSet.PLAN.NewPLANRow();
            this.rowPLAN.PLANGODINAIDGODINE = pLANGODINAIDGODINE;
            try
            {
                this.LoadByPLANGODINAIDGODINE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(PLANDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PLANSet = dataSet;
            try
            {
                this.LoadChildPlan(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDPLAN(PLANDataSet dataSet, int iDPLAN, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PLANSet = dataSet;
            this.rowPLAN = this.PLANSet.PLAN.NewPLANRow();
            this.rowPLAN.IDPLAN = iDPLAN;
            try
            {
                this.LoadByIDPLAN(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByPLANGODINAIDGODINE(PLANDataSet dataSet, short pLANGODINAIDGODINE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PLANSet = dataSet;
            this.rowPLAN = this.PLANSet.PLAN.NewPLANRow();
            this.rowPLAN.PLANGODINAIDGODINE = pLANGODINAIDGODINE;
            try
            {
                this.LoadByPLANGODINAIDGODINE(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDPLAN], [RADNINAZIVPLANA], [PLANGODINAIDGODINE] AS PLANGODINAIDGODINE FROM [PLAN] WITH (NOLOCK) WHERE [IDPLAN] = @IDPLAN AND [PLANGODINAIDGODINE] = @PLANGODINAIDGODINE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLAN["IDPLAN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPLAN["PLANGODINAIDGODINE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound237 = 1;
                this.rowPLAN["IDPLAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowPLAN["RADNINAZIVPLANA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowPLAN["PLANGODINAIDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 2));
                this.sMode237 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode237;
            }
            else
            {
                this.RcdFound237 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = "IDPLAN";
                parameter.DbType = DbType.Int32;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "PLANGODINAIDGODINE";
                parameter2.DbType = DbType.Int16;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPLANSelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [PLAN] WITH (NOLOCK) ", false);
            this.PLANSelect3 = this.cmPLANSelect3.FetchData();
            if (this.PLANSelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.PLANSelect3.GetInt32(0);
            }
            this.PLANSelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDPLAN(int iDPLAN)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPLANSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [PLAN] WITH (NOLOCK) WHERE [IDPLAN] = @IDPLAN ", false);
            if (this.cmPLANSelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmPLANSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
            }
            this.cmPLANSelect1.SetParameter(0, iDPLAN);
            this.PLANSelect1 = this.cmPLANSelect1.FetchData();
            if (this.PLANSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.PLANSelect1.GetInt32(0);
            }
            this.PLANSelect1.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByPLANGODINAIDGODINE(short pLANGODINAIDGODINE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPLANSelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [PLAN] WITH (NOLOCK) WHERE [PLANGODINAIDGODINE] = @PLANGODINAIDGODINE ", false);
            if (this.cmPLANSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmPLANSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
            }
            this.cmPLANSelect2.SetParameter(0, pLANGODINAIDGODINE);
            this.PLANSelect2 = this.cmPLANSelect2.FetchData();
            if (this.PLANSelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.PLANSelect2.GetInt32(0);
            }
            this.PLANSelect2.Close();
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

        public virtual int GetRecordCountByIDPLAN(int iDPLAN)
        {
            int internalRecordCountByIDPLAN;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDPLAN = this.GetInternalRecordCountByIDPLAN(iDPLAN);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDPLAN;
        }

        public virtual int GetRecordCountByPLANGODINAIDGODINE(short pLANGODINAIDGODINE)
        {
            int internalRecordCountByPLANGODINAIDGODINE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByPLANGODINAIDGODINE = this.GetInternalRecordCountByPLANGODINAIDGODINE(pLANGODINAIDGODINE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByPLANGODINAIDGODINE;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound237 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__PLANIRANIIZNOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove21 = false;
            this.RcdFound239 = 0;
            this.m_SubSelTopString239 = "";
            this.RcdFound238 = 0;
            this.m_SubSelTopString238 = "";
            this.m__RADNINAZIVPLANAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.PLANSet = new PLANDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertPlan()
        {
            this.CheckOptimisticConcurrencyPlan();
            this.AfterConfirmPlan();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [PLAN] ([IDPLAN], [RADNINAZIVPLANA], [PLANGODINAIDGODINE]) VALUES (@IDPLAN, @RADNINAZIVPLANA, @PLANGODINAIDGODINE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNINAZIVPLANA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLAN["IDPLAN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPLAN["RADNINAZIVPLANA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPLAN["PLANGODINAIDGODINE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new PLANDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsPlan();
            }
            this.OnPLANUpdated(new PLANEventArgs(this.rowPLAN, StatementType.Insert));
            this.ProcessLevelPlan();
        }

        private void InsertPlanorg()
        {
            this.CheckOptimisticConcurrencyPlanorg();
            this.CheckExtendedTablePlanorg();
            this.AfterConfirmPlanorg();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [PLANORG] ([IDPLAN], [PLANGODINAIDGODINE], [PLANOJIDORGJED]) VALUES (@IDPLAN, @PLANGODINAIDGODINE, @PLANOJIDORGJED)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANOJIDORGJED", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLANORG["IDPLAN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPLANORG["PLANGODINAIDGODINE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPLANORG["PLANOJIDORGJED"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new PLANORGDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnPLANORGUpdated(new PLANORGEventArgs(this.rowPLANORG, StatementType.Insert));
            this.ProcessLevelPlanorg();
        }

        private void InsertPlanorgkon()
        {
            this.CheckOptimisticConcurrencyPlanorgkon();
            this.AfterConfirmPlanorgkon();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [PLANORGKON] ([IDPLAN], [PLANGODINAIDGODINE], [PLANOJIDORGJED], [PLANIRANIIZNOS], [PLANKONTOIDKONTO]) VALUES (@IDPLAN, @PLANGODINAIDGODINE, @PLANOJIDORGJED, @PLANIRANIIZNOS, @PLANKONTOIDKONTO)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANOJIDORGJED", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANIRANIIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANKONTOIDKONTO", DbType.String, 14));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["IDPLAN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANGODINAIDGODINE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANOJIDORGJED"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANIRANIIZNOS"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANKONTOIDKONTO"]))));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new PLANORGKONDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsPlanorgkon();
            }
            this.OnPLANORGKONUpdated(new PLANORGKONEventArgs(this.rowPLANORGKON, StatementType.Insert));
        }

        private void LoadByIDPLAN(int startRow, int maxRows)
        {
            bool enforceConstraints = this.PLANSet.EnforceConstraints;
            this.PLANSet.PLANORGKON.BeginLoadData();
            this.PLANSet.PLANORG.BeginLoadData();
            this.PLANSet.PLAN.BeginLoadData();
            this.ScanByIDPLAN(startRow, maxRows);
            this.PLANSet.PLANORGKON.EndLoadData();
            this.PLANSet.PLANORG.EndLoadData();
            this.PLANSet.PLAN.EndLoadData();
            this.PLANSet.EnforceConstraints = enforceConstraints;
            if (this.PLANSet.PLAN.Count > 0)
            {
                this.rowPLAN = this.PLANSet.PLAN[this.PLANSet.PLAN.Count - 1];
            }
        }

        private void LoadByIDPLANPLANGODINAIDGODINE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.PLANSet.EnforceConstraints;
            this.PLANSet.PLANORGKON.BeginLoadData();
            this.PLANSet.PLANORG.BeginLoadData();
            this.PLANSet.PLAN.BeginLoadData();
            this.ScanByIDPLANPLANGODINAIDGODINE(startRow, maxRows);
            this.PLANSet.PLANORGKON.EndLoadData();
            this.PLANSet.PLANORG.EndLoadData();
            this.PLANSet.PLAN.EndLoadData();
            this.PLANSet.EnforceConstraints = enforceConstraints;
            if (this.PLANSet.PLAN.Count > 0)
            {
                this.rowPLAN = this.PLANSet.PLAN[this.PLANSet.PLAN.Count - 1];
            }
        }

        private void LoadByPLANGODINAIDGODINE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.PLANSet.EnforceConstraints;
            this.PLANSet.PLANORGKON.BeginLoadData();
            this.PLANSet.PLANORG.BeginLoadData();
            this.PLANSet.PLAN.BeginLoadData();
            this.ScanByPLANGODINAIDGODINE(startRow, maxRows);
            this.PLANSet.PLANORGKON.EndLoadData();
            this.PLANSet.PLANORG.EndLoadData();
            this.PLANSet.PLAN.EndLoadData();
            this.PLANSet.EnforceConstraints = enforceConstraints;
            if (this.PLANSet.PLAN.Count > 0)
            {
                this.rowPLAN = this.PLANSet.PLAN[this.PLANSet.PLAN.Count - 1];
            }
        }

        private void LoadChildPlan(int startRow, int maxRows)
        {
            this.CreateNewRowPlan();
            bool enforceConstraints = this.PLANSet.EnforceConstraints;
            this.PLANSet.PLANORGKON.BeginLoadData();
            this.PLANSet.PLANORG.BeginLoadData();
            this.PLANSet.PLAN.BeginLoadData();
            this.ScanStartPlan(startRow, maxRows);
            this.PLANSet.PLANORGKON.EndLoadData();
            this.PLANSet.PLANORG.EndLoadData();
            this.PLANSet.PLAN.EndLoadData();
            this.PLANSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildPlanorg()
        {
            this.CreateNewRowPlanorg();
            this.ScanStartPlanorg();
        }

        private void LoadChildPlanorgkon()
        {
            this.CreateNewRowPlanorgkon();
            this.ScanStartPlanorgkon();
        }

        private void LoadDataPlan(int maxRows)
        {
            int num = 0;
            if (this.RcdFound237 != 0)
            {
                this.ScanLoadPlan();
                while ((this.RcdFound237 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowPlan();
                    this.CreateNewRowPlan();
                    this.ScanNextPlan();
                }
            }
            if (num > 0)
            {
                this.RcdFound237 = 1;
            }
            this.ScanEndPlan();
            if (this.PLANSet.PLAN.Count > 0)
            {
                this.rowPLAN = this.PLANSet.PLAN[this.PLANSet.PLAN.Count - 1];
            }
        }

        private void LoadDataPlanorg()
        {
            while (this.RcdFound238 != 0)
            {
                this.LoadRowPlanorg();
                this.CreateNewRowPlanorg();
                this.ScanNextPlanorg();
            }
            this.ScanEndPlanorg();
        }

        private void LoadDataPlanorgkon()
        {
            while (this.RcdFound239 != 0)
            {
                this.LoadRowPlanorgkon();
                this.CreateNewRowPlanorgkon();
                this.ScanNextPlanorgkon();
            }
            this.ScanEndPlanorgkon();
        }

        private void LoadRowPlan()
        {
            this.AddRowPlan();
        }

        private void LoadRowPlanorg()
        {
            this.AddRowPlanorg();
        }

        private void LoadRowPlanorgkon()
        {
            this.AddRowPlanorgkon();
        }

        private void OnDeleteControlsPlanorg()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVORGJED] AS PLANOJNAZIVORGJED FROM [ORGJED] WITH (NOLOCK) WHERE [IDORGJED] = @PLANOJIDORGJED ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANOJIDORGJED", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLANORG["PLANOJIDORGJED"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowPLANORG["PLANOJNAZIVORGJED"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0))));
            }
            reader.Close();
        }

        private void OnPLANORGKONUpdated(PLANORGKONEventArgs e)
        {
            if (this.PLANORGKONUpdated != null)
            {
                PLANORGKONUpdateEventHandler pLANORGKONUpdatedEvent = this.PLANORGKONUpdated;
                if (pLANORGKONUpdatedEvent != null)
                {
                    pLANORGKONUpdatedEvent(this, e);
                }
            }
        }

        private void OnPLANORGKONUpdating(PLANORGKONEventArgs e)
        {
            if (this.PLANORGKONUpdating != null)
            {
                PLANORGKONUpdateEventHandler pLANORGKONUpdatingEvent = this.PLANORGKONUpdating;
                if (pLANORGKONUpdatingEvent != null)
                {
                    pLANORGKONUpdatingEvent(this, e);
                }
            }
        }

        private void OnPLANORGUpdated(PLANORGEventArgs e)
        {
            if (this.PLANORGUpdated != null)
            {
                PLANORGUpdateEventHandler pLANORGUpdatedEvent = this.PLANORGUpdated;
                if (pLANORGUpdatedEvent != null)
                {
                    pLANORGUpdatedEvent(this, e);
                }
            }
        }

        private void OnPLANORGUpdating(PLANORGEventArgs e)
        {
            if (this.PLANORGUpdating != null)
            {
                PLANORGUpdateEventHandler pLANORGUpdatingEvent = this.PLANORGUpdating;
                if (pLANORGUpdatingEvent != null)
                {
                    pLANORGUpdatingEvent(this, e);
                }
            }
        }

        private void OnPLANUpdated(PLANEventArgs e)
        {
            if (this.PLANUpdated != null)
            {
                PLANUpdateEventHandler pLANUpdatedEvent = this.PLANUpdated;
                if (pLANUpdatedEvent != null)
                {
                    pLANUpdatedEvent(this, e);
                }
            }
        }

        private void OnPLANUpdating(PLANEventArgs e)
        {
            if (this.PLANUpdating != null)
            {
                PLANUpdateEventHandler pLANUpdatingEvent = this.PLANUpdating;
                if (pLANUpdatingEvent != null)
                {
                    pLANUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelPlan()
        {
            this.sMode237 = this.Gx_mode;
            this.ProcessNestedLevelPlanorg();
            this.Gx_mode = this.sMode237;
        }

        private void ProcessLevelPlanorg()
        {
            this.sMode238 = this.Gx_mode;
            this.ProcessNestedLevelPlanorgkon();
            this.Gx_mode = this.sMode238;
        }

        private void ProcessNestedLevelPlanorg()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.PLANSet.PLANORG.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowPLANORG = (PLANDataSet.PLANORGRow) current;
                    if (Helpers.IsRowChanged(this.rowPLANORG))
                    {
                        bool flag = false;
                        if (this.rowPLANORG.RowState != DataRowState.Deleted)
                        {
                            flag = (this.rowPLANORG.IDPLAN == this.rowPLAN.IDPLAN) && (this.rowPLANORG.PLANGODINAIDGODINE == this.rowPLAN.PLANGODINAIDGODINE);
                        }
                        else
                        {
                            flag = this.rowPLANORG["IDPLAN", DataRowVersion.Original].Equals(this.rowPLAN.IDPLAN) && this.rowPLANORG["PLANGODINAIDGODINE", DataRowVersion.Original].Equals(this.rowPLAN.PLANGODINAIDGODINE);
                        }
                        if (flag)
                        {
                            this.ReadRowPlanorg();
                            if (this.rowPLANORG.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertPlanorg();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeletePlanorg();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdatePlanorg();
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

        private void ProcessNestedLevelPlanorgkon()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.PLANSet.PLANORGKON.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowPLANORGKON = (PLANDataSet.PLANORGKONRow) current;
                    if (Helpers.IsRowChanged(this.rowPLANORGKON))
                    {
                        bool flag = false;
                        if (this.rowPLANORGKON.RowState != DataRowState.Deleted)
                        {
                            flag = ((this.rowPLANORGKON.IDPLAN == this.rowPLANORG.IDPLAN) && (this.rowPLANORGKON.PLANGODINAIDGODINE == this.rowPLANORG.PLANGODINAIDGODINE)) && (this.rowPLANORGKON.PLANOJIDORGJED == this.rowPLANORG.PLANOJIDORGJED);
                        }
                        else
                        {
                            flag = (this.rowPLANORGKON["IDPLAN", DataRowVersion.Original].Equals(this.rowPLANORG.IDPLAN) && this.rowPLANORGKON["PLANGODINAIDGODINE", DataRowVersion.Original].Equals(this.rowPLANORG.PLANGODINAIDGODINE)) && this.rowPLANORGKON["PLANOJIDORGJED", DataRowVersion.Original].Equals(this.rowPLANORG.PLANOJIDORGJED);
                        }
                        if (flag)
                        {
                            this.ReadRowPlanorgkon();
                            if (this.rowPLANORGKON.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertPlanorgkon();
                            }
                            else
                            {
                                if (this._Gxremove21)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeletePlanorgkon();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdatePlanorgkon();
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

        private void ReadRowPlan()
        {
            this.Gx_mode = Mode.FromRowState(this.rowPLAN.RowState);
            if (this.rowPLAN.RowState != DataRowState.Added)
            {
                this.m__RADNINAZIVPLANAOriginal = RuntimeHelpers.GetObjectValue(this.rowPLAN["RADNINAZIVPLANA", DataRowVersion.Original]);
            }
            else
            {
                this.m__RADNINAZIVPLANAOriginal = RuntimeHelpers.GetObjectValue(this.rowPLAN["RADNINAZIVPLANA"]);
            }
            this._Gxremove = this.rowPLAN.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowPLAN = (PLANDataSet.PLANRow) DataSetUtil.CloneOriginalDataRow(this.rowPLAN);
            }
        }

        private void ReadRowPlanorg()
        {
            this.Gx_mode = Mode.FromRowState(this.rowPLANORG.RowState);
            if (this.rowPLANORG.RowState == DataRowState.Added)
            {
            }
            this._Gxremove = this.rowPLANORG.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowPLANORG = (PLANDataSet.PLANORGRow) DataSetUtil.CloneOriginalDataRow(this.rowPLANORG);
            }
        }

        private void ReadRowPlanorgkon()
        {
            this.Gx_mode = Mode.FromRowState(this.rowPLANORGKON.RowState);
            if (this.rowPLANORGKON.RowState != DataRowState.Added)
            {
                this.m__PLANIRANIIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANIRANIIZNOS", DataRowVersion.Original]);
            }
            else
            {
                this.m__PLANIRANIIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANIRANIIZNOS"]);
            }
            this._Gxremove21 = this.rowPLANORGKON.RowState == DataRowState.Deleted;
            if (this._Gxremove21)
            {
                this.rowPLANORGKON = (PLANDataSet.PLANORGKONRow) DataSetUtil.CloneOriginalDataRow(this.rowPLANORGKON);
            }
        }

        private void ScanByIDPLAN(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDPLAN] = @IDPLAN";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString237 + "  FROM [PLAN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString237, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE] ) AS DK_PAGENUM   FROM [PLAN] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString237 + " FROM [PLAN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE] ";
            }
            this.cmPLANSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmPLANSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmPLANSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
            }
            this.cmPLANSelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLAN["IDPLAN"]));
            this.PLANSelect6 = this.cmPLANSelect6.FetchData();
            this.RcdFound237 = 0;
            this.ScanLoadPlan();
            this.LoadDataPlan(maxRows);
            if (this.RcdFound237 > 0)
            {
                this.SubLvlScanStartPlanorg(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDPLANPlan(this.cmPLANORGSelect2);
                this.SubLvlFetchPlanorg();
                this.SubLoadDataPlanorg();
                this.SubLvlScanStartPlanorgkon(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDPLANPlan(this.cmPLANORGKONSelect2);
                this.SubLvlFetchPlanorgkon();
                this.SubLoadDataPlanorgkon();
            }
        }

        private void ScanByIDPLANPLANGODINAIDGODINE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDPLAN] = @IDPLAN and TM1.[PLANGODINAIDGODINE] = @PLANGODINAIDGODINE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString237 + "  FROM [PLAN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString237, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE] ) AS DK_PAGENUM   FROM [PLAN] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString237 + " FROM [PLAN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE] ";
            }
            this.cmPLANSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmPLANSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmPLANSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
                this.cmPLANSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
            }
            this.cmPLANSelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLAN["IDPLAN"]));
            this.cmPLANSelect6.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPLAN["PLANGODINAIDGODINE"]));
            this.PLANSelect6 = this.cmPLANSelect6.FetchData();
            this.RcdFound237 = 0;
            this.ScanLoadPlan();
            this.LoadDataPlan(maxRows);
            if (this.RcdFound237 > 0)
            {
                this.SubLvlScanStartPlanorg(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDPLANPLANGODINAIDGODINEPlan(this.cmPLANORGSelect2);
                this.SubLvlFetchPlanorg();
                this.SubLoadDataPlanorg();
                this.SubLvlScanStartPlanorgkon(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDPLANPLANGODINAIDGODINEPlan(this.cmPLANORGKONSelect2);
                this.SubLvlFetchPlanorgkon();
                this.SubLoadDataPlanorgkon();
            }
        }

        private void ScanByPLANGODINAIDGODINE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[PLANGODINAIDGODINE] = @PLANGODINAIDGODINE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString237 + "  FROM [PLAN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString237, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE] ) AS DK_PAGENUM   FROM [PLAN] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString237 + " FROM [PLAN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE] ";
            }
            this.cmPLANSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmPLANSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmPLANSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
            }
            this.cmPLANSelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLAN["PLANGODINAIDGODINE"]));
            this.PLANSelect6 = this.cmPLANSelect6.FetchData();
            this.RcdFound237 = 0;
            this.ScanLoadPlan();
            this.LoadDataPlan(maxRows);
            if (this.RcdFound237 > 0)
            {
                this.SubLvlScanStartPlanorg(this.m_WhereString, startRow, maxRows);
                this.SetParametersPLANGODINAIDGODINEPlan(this.cmPLANORGSelect2);
                this.SubLvlFetchPlanorg();
                this.SubLoadDataPlanorg();
                this.SubLvlScanStartPlanorgkon(this.m_WhereString, startRow, maxRows);
                this.SetParametersPLANGODINAIDGODINEPlan(this.cmPLANORGKONSelect2);
                this.SubLvlFetchPlanorgkon();
                this.SubLoadDataPlanorgkon();
            }
        }

        private void ScanEndPlan()
        {
            this.PLANSelect6.Close();
        }

        private void ScanEndPlanorg()
        {
            this.PLANORGSelect2.Close();
        }

        private void ScanEndPlanorgkon()
        {
            this.PLANORGKONSelect2.Close();
        }

        private void ScanLoadPlan()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmPLANSelect6.HasMoreRows)
            {
                this.RcdFound237 = 1;
                this.rowPLAN["IDPLAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PLANSelect6, 0));
                this.rowPLAN["RADNINAZIVPLANA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PLANSelect6, 1));
                this.rowPLAN["PLANGODINAIDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.PLANSelect6, 2));
            }
        }

        private void ScanLoadPlanorg()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmPLANORGSelect2.HasMoreRows)
            {
                this.RcdFound238 = 1;
                this.rowPLANORG["IDPLAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PLANORGSelect2, 0));
                this.rowPLANORG["PLANGODINAIDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.PLANORGSelect2, 1));
                this.rowPLANORG["PLANOJNAZIVORGJED"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PLANORGSelect2, 2))));
                this.rowPLANORG["PLANOJIDORGJED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PLANORGSelect2, 3));
                this.rowPLANORG["PLANOJNAZIVORGJED"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PLANORGSelect2, 2))));
            }
        }

        private void ScanLoadPlanorgkon()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmPLANORGKONSelect2.HasMoreRows)
            {
                this.RcdFound239 = 1;
                this.rowPLANORGKON["IDPLAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PLANORGKONSelect2, 0));
                this.rowPLANORGKON["PLANGODINAIDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.PLANORGKONSelect2, 1));
                this.rowPLANORGKON["PLANOJIDORGJED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PLANORGKONSelect2, 2));
                this.rowPLANORGKON["PLANIRANIIZNOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.PLANORGKONSelect2, 3));
                this.rowPLANORGKON["PLANKONTOIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PLANORGKONSelect2, 4))));
            }
        }

        private void ScanNextPlan()
        {
            this.cmPLANSelect6.HasMoreRows = this.PLANSelect6.Read();
            this.RcdFound237 = 0;
            this.ScanLoadPlan();
        }

        private void ScanNextPlanorg()
        {
            this.cmPLANORGSelect2.HasMoreRows = this.PLANORGSelect2.Read();
            this.RcdFound238 = 0;
            this.ScanLoadPlanorg();
        }

        private void ScanNextPlanorgkon()
        {
            this.cmPLANORGKONSelect2.HasMoreRows = this.PLANORGKONSelect2.Read();
            this.RcdFound239 = 0;
            this.ScanLoadPlanorgkon();
        }

        private void ScanStartPlan(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString237 + "  FROM [PLAN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString237, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE] ) AS DK_PAGENUM   FROM [PLAN] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString237 + " FROM [PLAN] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE] ";
            }
            this.cmPLANSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.PLANSelect6 = this.cmPLANSelect6.FetchData();
            this.RcdFound237 = 0;
            this.ScanLoadPlan();
            this.LoadDataPlan(maxRows);
            if (this.RcdFound237 > 0)
            {
                this.SubLvlScanStartPlanorg(this.m_WhereString, startRow, maxRows);
                this.SetParametersPlanPlan(this.cmPLANORGSelect2);
                this.SubLvlFetchPlanorg();
                this.SubLoadDataPlanorg();
                this.SubLvlScanStartPlanorgkon(this.m_WhereString, startRow, maxRows);
                this.SetParametersPlanPlan(this.cmPLANORGKONSelect2);
                this.SubLvlFetchPlanorgkon();
                this.SubLoadDataPlanorgkon();
            }
        }

        private void ScanStartPlanorg()
        {
            this.cmPLANORGSelect2 = this.connDefault.GetCommand("SELECT T1.[IDPLAN], T1.[PLANGODINAIDGODINE] AS PLANGODINAIDGODINE, T2.[NAZIVORGJED] AS PLANOJNAZIVORGJED, T1.[PLANOJIDORGJED] AS PLANOJIDORGJED FROM ([PLANORG] T1 WITH (NOLOCK) INNER JOIN [ORGJED] T2 WITH (NOLOCK) ON T2.[IDORGJED] = T1.[PLANOJIDORGJED]) WHERE T1.[IDPLAN] = @IDPLAN and T1.[PLANGODINAIDGODINE] = @PLANGODINAIDGODINE ORDER BY T1.[IDPLAN], T1.[PLANGODINAIDGODINE], T1.[PLANOJIDORGJED] ", false);
            if (this.cmPLANORGSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmPLANORGSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
                this.cmPLANORGSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
            }
            this.cmPLANORGSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLANORG["IDPLAN"]));
            this.cmPLANORGSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPLANORG["PLANGODINAIDGODINE"]));
            this.PLANORGSelect2 = this.cmPLANORGSelect2.FetchData();
            this.RcdFound238 = 0;
            this.ScanLoadPlanorg();
        }

        private void ScanStartPlanorgkon()
        {
            this.cmPLANORGKONSelect2 = this.connDefault.GetCommand("SELECT [IDPLAN], [PLANGODINAIDGODINE] AS PLANGODINAIDGODINE, [PLANOJIDORGJED] AS PLANOJIDORGJED, [PLANIRANIIZNOS], [PLANKONTOIDKONTO] AS PLANKONTOIDKONTO FROM [PLANORGKON] WITH (NOLOCK) WHERE [IDPLAN] = @IDPLAN and [PLANGODINAIDGODINE] = @PLANGODINAIDGODINE and [PLANOJIDORGJED] = @PLANOJIDORGJED ORDER BY [IDPLAN], [PLANGODINAIDGODINE], [PLANOJIDORGJED], [PLANKONTOIDKONTO] ", false);
            if (this.cmPLANORGKONSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmPLANORGKONSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
                this.cmPLANORGKONSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
                this.cmPLANORGKONSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANOJIDORGJED", DbType.Int32));
            }
            this.cmPLANORGKONSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["IDPLAN"]));
            this.cmPLANORGKONSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANGODINAIDGODINE"]));
            this.cmPLANORGKONSelect2.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANOJIDORGJED"]));
            this.PLANORGKONSelect2 = this.cmPLANORGKONSelect2.FetchData();
            this.RcdFound239 = 0;
            this.ScanLoadPlanorgkon();
        }

        private void SetParametersIDPLANPlan(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLAN["IDPLAN"]));
        }

        private void SetParametersIDPLANPLANGODINAIDGODINEPlan(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLAN["IDPLAN"]));
            m_Command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPLAN["PLANGODINAIDGODINE"]));
        }

        private void SetParametersPLANGODINAIDGODINEPlan(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLAN["PLANGODINAIDGODINE"]));
        }

        private void SetParametersPlanPlan(ReadWriteCommand m_Command)
        {
        }

        private void SkipNextPlanorg()
        {
            this.cmPLANORGSelect2.HasMoreRows = this.PLANORGSelect2.Read();
            this.RcdFound238 = 0;
            if (this.cmPLANORGSelect2.HasMoreRows)
            {
                this.RcdFound238 = 1;
            }
        }

        private void SkipNextPlanorgkon()
        {
            this.cmPLANORGKONSelect2.HasMoreRows = this.PLANORGKONSelect2.Read();
            this.RcdFound239 = 0;
            if (this.cmPLANORGKONSelect2.HasMoreRows)
            {
                this.RcdFound239 = 1;
            }
        }

        private void SubLoadDataPlanorg()
        {
            while (this.RcdFound238 != 0)
            {
                this.LoadRowPlanorg();
                this.CreateNewRowPlanorg();
                this.ScanNextPlanorg();
            }
            this.ScanEndPlanorg();
        }

        private void SubLoadDataPlanorgkon()
        {
            while (this.RcdFound239 != 0)
            {
                this.LoadRowPlanorgkon();
                this.CreateNewRowPlanorgkon();
                this.ScanNextPlanorgkon();
            }
            this.ScanEndPlanorgkon();
        }

        private void SubLvlFetchPlanorg()
        {
            this.CreateNewRowPlanorg();
            this.PLANORGSelect2 = this.cmPLANORGSelect2.FetchData();
            this.RcdFound238 = 0;
            this.ScanLoadPlanorg();
        }

        private void SubLvlFetchPlanorgkon()
        {
            this.CreateNewRowPlanorgkon();
            this.PLANORGKONSelect2 = this.cmPLANORGKONSelect2.FetchData();
            this.RcdFound239 = 0;
            this.ScanLoadPlanorgkon();
        }

        private void SubLvlScanStartPlanorg(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString238 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDPLAN],TM1.[PLANGODINAIDGODINE]  FROM [PLAN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE] )";
                    this.scmdbuf = "SELECT T1.[IDPLAN], T1.[PLANGODINAIDGODINE] AS PLANGODINAIDGODINE, T3.[NAZIVORGJED] AS PLANOJNAZIVORGJED, T1.[PLANOJIDORGJED] AS PLANOJIDORGJED FROM (([PLANORG] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString238 + "  TMX ON TMX.[IDPLAN] = T1.[IDPLAN] AND TMX.[PLANGODINAIDGODINE] = T1.[PLANGODINAIDGODINE]) INNER JOIN [ORGJED] T3 WITH (NOLOCK) ON T3.[IDORGJED] = T1.[PLANOJIDORGJED]) ORDER BY T1.[IDPLAN], T1.[PLANGODINAIDGODINE], T1.[PLANOJIDORGJED]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDPLAN],TM1.[PLANGODINAIDGODINE], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE]  ) AS DK_PAGENUM   FROM [PLAN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString238 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDPLAN], T1.[PLANGODINAIDGODINE] AS PLANGODINAIDGODINE, T3.[NAZIVORGJED] AS PLANOJNAZIVORGJED, T1.[PLANOJIDORGJED] AS PLANOJIDORGJED FROM (([PLANORG] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString238 + "  TMX ON TMX.[IDPLAN] = T1.[IDPLAN] AND TMX.[PLANGODINAIDGODINE] = T1.[PLANGODINAIDGODINE]) INNER JOIN [ORGJED] T3 WITH (NOLOCK) ON T3.[IDORGJED] = T1.[PLANOJIDORGJED]) ORDER BY T1.[IDPLAN], T1.[PLANGODINAIDGODINE], T1.[PLANOJIDORGJED]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString238 = "[PLAN]";
                this.scmdbuf = "SELECT T1.[IDPLAN], T1.[PLANGODINAIDGODINE] AS PLANGODINAIDGODINE, T3.[NAZIVORGJED] AS PLANOJNAZIVORGJED, T1.[PLANOJIDORGJED] AS PLANOJIDORGJED FROM (([PLANORG] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString238 + "  TM1 WITH (NOLOCK) ON TM1.[IDPLAN] = T1.[IDPLAN] AND TM1.[PLANGODINAIDGODINE] = T1.[PLANGODINAIDGODINE]) INNER JOIN [ORGJED] T3 WITH (NOLOCK) ON T3.[IDORGJED] = T1.[PLANOJIDORGJED])" + this.m_WhereString + " ORDER BY T1.[IDPLAN], T1.[PLANGODINAIDGODINE], T1.[PLANOJIDORGJED] ";
            }
            this.cmPLANORGSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartPlanorgkon(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString239 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDPLAN],TM1.[PLANGODINAIDGODINE]  FROM [PLAN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE] )";
                    this.scmdbuf = "SELECT T1.[IDPLAN], T1.[PLANGODINAIDGODINE] AS PLANGODINAIDGODINE, T1.[PLANOJIDORGJED] AS PLANOJIDORGJED, T1.[PLANIRANIIZNOS], T1.[PLANKONTOIDKONTO] AS PLANKONTOIDKONTO FROM ([PLANORGKON] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString239 + "  TMX ON TMX.[IDPLAN] = T1.[IDPLAN] AND TMX.[PLANGODINAIDGODINE] = T1.[PLANGODINAIDGODINE]) ORDER BY T1.[IDPLAN], T1.[PLANGODINAIDGODINE], T1.[PLANOJIDORGJED], T1.[PLANKONTOIDKONTO]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDPLAN],TM1.[PLANGODINAIDGODINE], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE]  ) AS DK_PAGENUM   FROM [PLAN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString239 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDPLAN], T1.[PLANGODINAIDGODINE] AS PLANGODINAIDGODINE, T1.[PLANOJIDORGJED] AS PLANOJIDORGJED, T1.[PLANIRANIIZNOS], T1.[PLANKONTOIDKONTO] AS PLANKONTOIDKONTO FROM ([PLANORGKON] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString239 + "  TMX ON TMX.[IDPLAN] = T1.[IDPLAN] AND TMX.[PLANGODINAIDGODINE] = T1.[PLANGODINAIDGODINE]) ORDER BY T1.[IDPLAN], T1.[PLANGODINAIDGODINE], T1.[PLANOJIDORGJED], T1.[PLANKONTOIDKONTO]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString239 = "[PLAN]";
                this.scmdbuf = "SELECT T1.[IDPLAN], T1.[PLANGODINAIDGODINE] AS PLANGODINAIDGODINE, T1.[PLANOJIDORGJED] AS PLANOJIDORGJED, T1.[PLANIRANIIZNOS], T1.[PLANKONTOIDKONTO] AS PLANKONTOIDKONTO FROM ([PLANORGKON] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString239 + "  TM1 WITH (NOLOCK) ON TM1.[IDPLAN] = T1.[IDPLAN] AND TM1.[PLANGODINAIDGODINE] = T1.[PLANGODINAIDGODINE])" + this.m_WhereString + " ORDER BY T1.[IDPLAN], T1.[PLANGODINAIDGODINE], T1.[PLANOJIDORGJED], T1.[PLANKONTOIDKONTO] ";
            }
            this.cmPLANORGKONSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.PLANSet = (PLANDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.PLANSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.PLANSet.PLAN.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        PLANDataSet.PLANRow current = (PLANDataSet.PLANRow) enumerator.Current;
                        this.rowPLAN = current;
                        if (Helpers.IsRowChanged(this.rowPLAN))
                        {
                            this.ReadRowPlan();
                            if (this.rowPLAN.RowState == DataRowState.Added)
                            {
                                this.InsertPlan();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdatePlan();
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

        private void UpdatePlan()
        {
            this.CheckOptimisticConcurrencyPlan();
            this.AfterConfirmPlan();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [PLAN] SET [RADNINAZIVPLANA]=@RADNINAZIVPLANA  WHERE [IDPLAN] = @IDPLAN AND [PLANGODINAIDGODINE] = @PLANGODINAIDGODINE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNINAZIVPLANA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLAN["RADNINAZIVPLANA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPLAN["IDPLAN"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPLAN["PLANGODINAIDGODINE"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsPlan();
            }
            this.OnPLANUpdated(new PLANEventArgs(this.rowPLAN, StatementType.Update));
            this.ProcessLevelPlan();
        }

        private void UpdatePlanorg()
        {
            this.CheckOptimisticConcurrencyPlanorg();
            this.CheckExtendedTablePlanorg();
            this.AfterConfirmPlanorg();
            this.OnPLANORGUpdated(new PLANORGEventArgs(this.rowPLANORG, StatementType.Update));
            this.ProcessLevelPlanorg();
        }

        private void UpdatePlanorgkon()
        {
            this.CheckOptimisticConcurrencyPlanorgkon();
            this.AfterConfirmPlanorgkon();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [PLANORGKON] SET [PLANIRANIIZNOS]=@PLANIRANIIZNOS  WHERE [IDPLAN] = @IDPLAN AND [PLANGODINAIDGODINE] = @PLANGODINAIDGODINE AND [PLANOJIDORGJED] = @PLANOJIDORGJED AND [PLANKONTOIDKONTO] = @PLANKONTOIDKONTO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANIRANIIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANOJIDORGJED", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANKONTOIDKONTO", DbType.String, 14));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANIRANIIZNOS"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["IDPLAN"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANGODINAIDGODINE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANOJIDORGJED"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowPLANORGKON["PLANKONTOIDKONTO"]))));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsPlanorgkon();
            }
            this.OnPLANORGKONUpdated(new PLANORGKONEventArgs(this.rowPLANORGKON, StatementType.Update));
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
        public class GODINEForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public GODINEForeignKeyNotFoundException()
            {
            }

            public GODINEForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected GODINEForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GODINEForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
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
        public class ORGJEDForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public ORGJEDForeignKeyNotFoundException()
            {
            }

            public ORGJEDForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected ORGJEDForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ORGJEDForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PLANDataChangedException : DataChangedException
        {
            public PLANDataChangedException()
            {
            }

            public PLANDataChangedException(string message) : base(message)
            {
            }

            protected PLANDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PLANDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PLANDataLockedException : DataLockedException
        {
            public PLANDataLockedException()
            {
            }

            public PLANDataLockedException(string message) : base(message)
            {
            }

            protected PLANDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PLANDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PLANDuplicateKeyException : DuplicateKeyException
        {
            public PLANDuplicateKeyException()
            {
            }

            public PLANDuplicateKeyException(string message) : base(message)
            {
            }

            protected PLANDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PLANDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class PLANEventArgs : EventArgs
        {
            private PLANDataSet.PLANRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public PLANEventArgs(PLANDataSet.PLANRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public PLANDataSet.PLANRow Row
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
        public class PLANNotFoundException : DataNotFoundException
        {
            public PLANNotFoundException()
            {
            }

            public PLANNotFoundException(string message) : base(message)
            {
            }

            protected PLANNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PLANNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PLANORGDataChangedException : DataChangedException
        {
            public PLANORGDataChangedException()
            {
            }

            public PLANORGDataChangedException(string message) : base(message)
            {
            }

            protected PLANORGDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PLANORGDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PLANORGDataLockedException : DataLockedException
        {
            public PLANORGDataLockedException()
            {
            }

            public PLANORGDataLockedException(string message) : base(message)
            {
            }

            protected PLANORGDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PLANORGDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PLANORGDuplicateKeyException : DuplicateKeyException
        {
            public PLANORGDuplicateKeyException()
            {
            }

            public PLANORGDuplicateKeyException(string message) : base(message)
            {
            }

            protected PLANORGDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PLANORGDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class PLANORGEventArgs : EventArgs
        {
            private PLANDataSet.PLANORGRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public PLANORGEventArgs(PLANDataSet.PLANORGRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public PLANDataSet.PLANORGRow Row
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
        public class PLANORGKONDataChangedException : DataChangedException
        {
            public PLANORGKONDataChangedException()
            {
            }

            public PLANORGKONDataChangedException(string message) : base(message)
            {
            }

            protected PLANORGKONDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PLANORGKONDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PLANORGKONDataLockedException : DataLockedException
        {
            public PLANORGKONDataLockedException()
            {
            }

            public PLANORGKONDataLockedException(string message) : base(message)
            {
            }

            protected PLANORGKONDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PLANORGKONDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PLANORGKONDuplicateKeyException : DuplicateKeyException
        {
            public PLANORGKONDuplicateKeyException()
            {
            }

            public PLANORGKONDuplicateKeyException(string message) : base(message)
            {
            }

            protected PLANORGKONDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PLANORGKONDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class PLANORGKONEventArgs : EventArgs
        {
            private PLANDataSet.PLANORGKONRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public PLANORGKONEventArgs(PLANDataSet.PLANORGKONRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public PLANDataSet.PLANORGKONRow Row
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

        public delegate void PLANORGKONUpdateEventHandler(object sender, PLANDataAdapter.PLANORGKONEventArgs e);

        public delegate void PLANORGUpdateEventHandler(object sender, PLANDataAdapter.PLANORGEventArgs e);

        public delegate void PLANUpdateEventHandler(object sender, PLANDataAdapter.PLANEventArgs e);
    }
}

