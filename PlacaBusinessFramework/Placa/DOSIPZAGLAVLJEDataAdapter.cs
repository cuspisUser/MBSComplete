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

    public class DOSIPZAGLAVLJEDataAdapter : IDataAdapter, IDOSIPZAGLAVLJEDataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private bool _Gxremove21;
        private ReadWriteCommand cmDOSIPZAGLAVLJELevel1Select2;
        private ReadWriteCommand cmDOSIPZAGLAVLJESelect1;
        private ReadWriteCommand cmDOSIPZAGLAVLJESelect2;
        private ReadWriteCommand cmDOSIPZAGLAVLJESelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DOSIPZAGLAVLJELevel1Select2;
        private IDataReader DOSIPZAGLAVLJESelect1;
        private IDataReader DOSIPZAGLAVLJESelect2;
        private IDataReader DOSIPZAGLAVLJESelect5;
        private DOSIPZAGLAVLJEDataSet DOSIPZAGLAVLJESet;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__DOSDOHODAKOriginal;
        private object m__DOSIDOPCINESTANOVANJAOriginal;
        private object m__DOSISPLATAUGODINIOriginal;
        private object m__DOSISPLATAZAGODINUOriginal;
        private object m__DOSOZNACENOriginal;
        private object m__DOSPOREZNAOSNOVICAOriginal;
        private object m__DOSPOSEBANPOREZOriginal;
        private object m__DOSUKUPNOBRUTOOriginal;
        private object m__DOSUKUPNODOPRINOSIOriginal;
        private object m__DOSUKUPNONETOISPLATAOriginal;
        private object m__DOSUKUPNOOLAKSICEOriginal;
        private object m__DOSUKUPNOOOOriginal;
        private object m__DOSUKUPNOPOREZIPRIREZOriginal;
        private readonly string m_SelectString104 = "TM1.[DOSIPIDENT], TM1.[DOSJMBG], TM1.[DOSISPLATAUGODINI], TM1.[DOSISPLATAZAGODINU], TM1.[DOSOZNACEN]";
        private string m_SubSelTopString105;
        private string m_WhereString;
        private short RcdFound104;
        private short RcdFound105;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow rowDOSIPZAGLAVLJE;
        private DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row rowDOSIPZAGLAVLJELevel1;
        private string scmdbuf;
        private StatementType sMode104;
        private StatementType sMode105;

        public event DOSIPZAGLAVLJELevel1UpdateEventHandler DOSIPZAGLAVLJELevel1Updated;

        public event DOSIPZAGLAVLJELevel1UpdateEventHandler DOSIPZAGLAVLJELevel1Updating;

        public event DOSIPZAGLAVLJEUpdateEventHandler DOSIPZAGLAVLJEUpdated;

        public event DOSIPZAGLAVLJEUpdateEventHandler DOSIPZAGLAVLJEUpdating;

        private void AddRowDosipzaglavlje()
        {
            this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE.AddDOSIPZAGLAVLJERow(this.rowDOSIPZAGLAVLJE);
        }

        private void AddRowDosipzaglavljelevel1()
        {
            this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJELevel1.AddDOSIPZAGLAVLJELevel1Row(this.rowDOSIPZAGLAVLJELevel1);
        }

        private void AfterConfirmDosipzaglavlje()
        {
            this.OnDOSIPZAGLAVLJEUpdating(new DOSIPZAGLAVLJEEventArgs(this.rowDOSIPZAGLAVLJE, this.Gx_mode));
        }

        private void AfterConfirmDosipzaglavljelevel1()
        {
            this.OnDOSIPZAGLAVLJELevel1Updating(new DOSIPZAGLAVLJELevel1EventArgs(this.rowDOSIPZAGLAVLJELevel1, this.Gx_mode));
        }

        private void CheckOptimisticConcurrencyDosipzaglavlje()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DOSIPIDENT], [DOSJMBG], [DOSISPLATAUGODINI], [DOSISPLATAZAGODINU], [DOSOZNACEN] FROM [DOSIPZAGLAVLJE] WITH (UPDLOCK) WHERE [DOSIPIDENT] = @DOSIPIDENT AND [DOSJMBG] = @DOSJMBG ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIPIDENT", DbType.String, 2));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSJMBG", DbType.String, 13));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSIPIDENT"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSJMBG"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DOSIPZAGLAVLJEDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DOSIPZAGLAVLJE") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DOSISPLATAUGODINIOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DOSISPLATAZAGODINUOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3))) || !this.m__DOSOZNACENOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 4)))))
                {
                    reader.Close();
                    throw new DOSIPZAGLAVLJEDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DOSIPZAGLAVLJE") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyDosipzaglavljelevel1()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DOSIPIDENT], [DOSJMBG], [DOSMJESECISPLATE], [DOSIDOPCINESTANOVANJA], [DOSUKUPNOBRUTO], [DOSUKUPNODOPRINOSI], [DOSUKUPNOOLAKSICE], [DOSDOHODAK], [DOSUKUPNOOO], [DOSPOREZNAOSNOVICA], [DOSUKUPNOPOREZIPRIREZ], [DOSUKUPNONETOISPLATA], [DOSPOSEBANPOREZ] FROM [DOSIPZAGLAVLJELevel1] WITH (UPDLOCK) WHERE [DOSIPIDENT] = @DOSIPIDENT AND [DOSJMBG] = @DOSJMBG AND [DOSMJESECISPLATE] = @DOSMJESECISPLATE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIPIDENT", DbType.String, 2));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSJMBG", DbType.String, 13));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSMJESECISPLATE", DbType.String, 2));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSIPIDENT"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSJMBG"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSMJESECISPLATE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DOSIPZAGLAVLJELevel1DataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DOSIPZAGLAVLJELevel1") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DOSIDOPCINESTANOVANJAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || ((!this.m__DOSUKUPNOBRUTOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4))) || !this.m__DOSUKUPNODOPRINOSIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 5)))) || (!this.m__DOSUKUPNOOLAKSICEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 6))) || !this.m__DOSDOHODAKOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 7))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__DOSUKUPNOOOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 8)))) || ((!this.m__DOSPOREZNAOSNOVICAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 9))) || !this.m__DOSUKUPNOPOREZIPRIREZOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 10)))) || (!this.m__DOSUKUPNONETOISPLATAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 11))) || !this.m__DOSPOSEBANPOREZOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 12))))))
                {
                    reader.Close();
                    throw new DOSIPZAGLAVLJELevel1DataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DOSIPZAGLAVLJELevel1") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowDosipzaglavlje()
        {
            this.rowDOSIPZAGLAVLJE = this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE.NewDOSIPZAGLAVLJERow();
        }

        private void CreateNewRowDosipzaglavljelevel1()
        {
            this.rowDOSIPZAGLAVLJELevel1 = this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJELevel1.NewDOSIPZAGLAVLJELevel1Row();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDosipzaglavlje();
            this.ProcessNestedLevelDosipzaglavljelevel1();
            this.AfterConfirmDosipzaglavlje();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DOSIPZAGLAVLJE]  WHERE [DOSIPIDENT] = @DOSIPIDENT AND [DOSJMBG] = @DOSJMBG", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIPIDENT", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSJMBG", DbType.String, 13));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSIPIDENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSJMBG"]));
            command.ExecuteStmt();
            this.OnDOSIPZAGLAVLJEUpdated(new DOSIPZAGLAVLJEEventArgs(this.rowDOSIPZAGLAVLJE, StatementType.Delete));
            this.rowDOSIPZAGLAVLJE.Delete();
            this.sMode104 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode104;
        }

        private void DeleteDosipzaglavljelevel1()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDosipzaglavljelevel1();
            this.AfterConfirmDosipzaglavljelevel1();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DOSIPZAGLAVLJELevel1]  WHERE [DOSIPIDENT] = @DOSIPIDENT AND [DOSJMBG] = @DOSJMBG AND [DOSMJESECISPLATE] = @DOSMJESECISPLATE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIPIDENT", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSJMBG", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSMJESECISPLATE", DbType.String, 2));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSIPIDENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSJMBG"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSMJESECISPLATE"]));
            command.ExecuteStmt();
            this.OnDOSIPZAGLAVLJELevel1Updated(new DOSIPZAGLAVLJELevel1EventArgs(this.rowDOSIPZAGLAVLJELevel1, StatementType.Delete));
            this.rowDOSIPZAGLAVLJELevel1.Delete();
            this.sMode105 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode105;
        }

        public virtual int Fill(DOSIPZAGLAVLJEDataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString());
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.DOSIPZAGLAVLJESet = dataSet;
                    this.LoadChildDosipzaglavlje(0, -1);
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
            this.DOSIPZAGLAVLJESet = (DOSIPZAGLAVLJEDataSet) dataSet;
            if (this.DOSIPZAGLAVLJESet != null)
            {
                return this.Fill(this.DOSIPZAGLAVLJESet);
            }
            this.DOSIPZAGLAVLJESet = new DOSIPZAGLAVLJEDataSet();
            this.Fill(this.DOSIPZAGLAVLJESet);
            dataSet.Merge(this.DOSIPZAGLAVLJESet);
            return 0;
        }

        public virtual int Fill(DOSIPZAGLAVLJEDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["DOSIPIDENT"]), Conversions.ToString(dataRecord["DOSJMBG"]));
        }

        public virtual int Fill(DOSIPZAGLAVLJEDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["DOSIPIDENT"]), Conversions.ToString(dataRecord["DOSJMBG"]));
        }

        public virtual int Fill(DOSIPZAGLAVLJEDataSet dataSet, string dOSIPIDENT, string dOSJMBG)
        {
            if (!this.FillByDOSIPIDENTDOSJMBG(dataSet, dOSIPIDENT, dOSJMBG))
            {
                throw new DOSIPZAGLAVLJENotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DOSIPZAGLAVLJE") }));
            }
            return 0;
        }

        public virtual int FillByDOSIPIDENT(DOSIPZAGLAVLJEDataSet dataSet, string dOSIPIDENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DOSIPZAGLAVLJESet = dataSet;
            this.rowDOSIPZAGLAVLJE = this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE.NewDOSIPZAGLAVLJERow();
            this.rowDOSIPZAGLAVLJE.DOSIPIDENT = dOSIPIDENT;
            try
            {
                this.LoadByDOSIPIDENT(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByDOSIPIDENTDOSJMBG(DOSIPZAGLAVLJEDataSet dataSet, string dOSIPIDENT, string dOSJMBG)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DOSIPZAGLAVLJESet = dataSet;
            this.rowDOSIPZAGLAVLJE = this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE.NewDOSIPZAGLAVLJERow();
            this.rowDOSIPZAGLAVLJE.DOSIPIDENT = dOSIPIDENT;
            this.rowDOSIPZAGLAVLJE.DOSJMBG = dOSJMBG;
            try
            {
                this.LoadByDOSIPIDENTDOSJMBG(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound104 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(DOSIPZAGLAVLJEDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DOSIPZAGLAVLJESet = dataSet;
            try
            {
                this.LoadChildDosipzaglavlje(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByDOSIPIDENT(DOSIPZAGLAVLJEDataSet dataSet, string dOSIPIDENT, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DOSIPZAGLAVLJESet = dataSet;
            this.rowDOSIPZAGLAVLJE = this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE.NewDOSIPZAGLAVLJERow();
            this.rowDOSIPZAGLAVLJE.DOSIPIDENT = dOSIPIDENT;
            try
            {
                this.LoadByDOSIPIDENT(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DOSIPIDENT], [DOSJMBG], [DOSISPLATAUGODINI], [DOSISPLATAZAGODINU], [DOSOZNACEN] FROM [DOSIPZAGLAVLJE] WITH (NOLOCK) WHERE [DOSIPIDENT] = @DOSIPIDENT AND [DOSJMBG] = @DOSJMBG ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIPIDENT", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSJMBG", DbType.String, 13));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSIPIDENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSJMBG"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound104 = 1;
                this.rowDOSIPZAGLAVLJE["DOSIPIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowDOSIPZAGLAVLJE["DOSJMBG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowDOSIPZAGLAVLJE["DOSISPLATAUGODINI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowDOSIPZAGLAVLJE["DOSISPLATAZAGODINU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowDOSIPZAGLAVLJE["DOSOZNACEN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 4));
                this.sMode104 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode104;
            }
            else
            {
                this.RcdFound104 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = "DOSIPIDENT";
                parameter.DbType = DbType.String;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "DOSJMBG";
                parameter2.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDOSIPZAGLAVLJESelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [DOSIPZAGLAVLJE] WITH (NOLOCK) ", false);
            this.DOSIPZAGLAVLJESelect2 = this.cmDOSIPZAGLAVLJESelect2.FetchData();
            if (this.DOSIPZAGLAVLJESelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.DOSIPZAGLAVLJESelect2.GetInt32(0);
            }
            this.DOSIPZAGLAVLJESelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByDOSIPIDENT(string dOSIPIDENT)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDOSIPZAGLAVLJESelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [DOSIPZAGLAVLJE] WITH (NOLOCK) WHERE [DOSIPIDENT] = @DOSIPIDENT ", false);
            if (this.cmDOSIPZAGLAVLJESelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOSIPZAGLAVLJESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIPIDENT", DbType.String, 2));
            }
            this.cmDOSIPZAGLAVLJESelect1.SetParameter(0, dOSIPIDENT);
            this.DOSIPZAGLAVLJESelect1 = this.cmDOSIPZAGLAVLJESelect1.FetchData();
            if (this.DOSIPZAGLAVLJESelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.DOSIPZAGLAVLJESelect1.GetInt32(0);
            }
            this.DOSIPZAGLAVLJESelect1.Close();
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

        public virtual int GetRecordCountByDOSIPIDENT(string dOSIPIDENT)
        {
            int internalRecordCountByDOSIPIDENT;
            try
            {
                this.InitializeMembers();
                internalRecordCountByDOSIPIDENT = this.GetInternalRecordCountByDOSIPIDENT(dOSIPIDENT);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByDOSIPIDENT;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound104 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__DOSIDOPCINESTANOVANJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DOSUKUPNOBRUTOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DOSUKUPNODOPRINOSIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DOSUKUPNOOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DOSDOHODAKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DOSUKUPNOOOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DOSPOREZNAOSNOVICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DOSUKUPNOPOREZIPRIREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DOSUKUPNONETOISPLATAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DOSPOSEBANPOREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove21 = false;
            this._Condition = false;
            this.RcdFound105 = 0;
            this.m_SubSelTopString105 = "";
            this.m__DOSISPLATAUGODINIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DOSISPLATAZAGODINUOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DOSOZNACENOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.DOSIPZAGLAVLJESet = new DOSIPZAGLAVLJEDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertDosipzaglavlje()
        {
            this.CheckOptimisticConcurrencyDosipzaglavlje();
            this.AfterConfirmDosipzaglavlje();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DOSIPZAGLAVLJE] ([DOSIPIDENT], [DOSJMBG], [DOSISPLATAUGODINI], [DOSISPLATAZAGODINU], [DOSOZNACEN]) VALUES (@DOSIPIDENT, @DOSJMBG, @DOSISPLATAUGODINI, @DOSISPLATAZAGODINU, @DOSOZNACEN)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIPIDENT", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSJMBG", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSISPLATAUGODINI", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSISPLATAZAGODINU", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSOZNACEN", DbType.Boolean));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSIPIDENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSJMBG"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSISPLATAUGODINI"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSISPLATAZAGODINU"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSOZNACEN"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DOSIPZAGLAVLJEDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDOSIPZAGLAVLJEUpdated(new DOSIPZAGLAVLJEEventArgs(this.rowDOSIPZAGLAVLJE, StatementType.Insert));
            this.ProcessLevelDosipzaglavlje();
        }

        private void InsertDosipzaglavljelevel1()
        {
            this.CheckOptimisticConcurrencyDosipzaglavljelevel1();
            this.AfterConfirmDosipzaglavljelevel1();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DOSIPZAGLAVLJELevel1] ([DOSIPIDENT], [DOSJMBG], [DOSMJESECISPLATE], [DOSIDOPCINESTANOVANJA], [DOSUKUPNOBRUTO], [DOSUKUPNODOPRINOSI], [DOSUKUPNOOLAKSICE], [DOSDOHODAK], [DOSUKUPNOOO], [DOSPOREZNAOSNOVICA], [DOSUKUPNOPOREZIPRIREZ], [DOSUKUPNONETOISPLATA], [DOSPOSEBANPOREZ]) VALUES (@DOSIPIDENT, @DOSJMBG, @DOSMJESECISPLATE, @DOSIDOPCINESTANOVANJA, @DOSUKUPNOBRUTO, @DOSUKUPNODOPRINOSI, @DOSUKUPNOOLAKSICE, @DOSDOHODAK, @DOSUKUPNOOO, @DOSPOREZNAOSNOVICA, @DOSUKUPNOPOREZIPRIREZ, @DOSUKUPNONETOISPLATA, @DOSPOSEBANPOREZ)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIPIDENT", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSJMBG", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSMJESECISPLATE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIDOPCINESTANOVANJA", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSUKUPNOBRUTO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSUKUPNODOPRINOSI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSUKUPNOOLAKSICE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSDOHODAK", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSUKUPNOOO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSPOREZNAOSNOVICA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSUKUPNOPOREZIPRIREZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSUKUPNONETOISPLATA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSPOSEBANPOREZ", DbType.Currency));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSIPIDENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSJMBG"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSMJESECISPLATE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSIDOPCINESTANOVANJA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOBRUTO"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNODOPRINOSI"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOOLAKSICE"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSDOHODAK"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOOO"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSPOREZNAOSNOVICA"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOPOREZIPRIREZ"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNONETOISPLATA"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSPOSEBANPOREZ"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DOSIPZAGLAVLJELevel1DuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDOSIPZAGLAVLJELevel1Updated(new DOSIPZAGLAVLJELevel1EventArgs(this.rowDOSIPZAGLAVLJELevel1, StatementType.Insert));
        }

        private void LoadByDOSIPIDENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.DOSIPZAGLAVLJESet.EnforceConstraints;
            this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJELevel1.BeginLoadData();
            this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE.BeginLoadData();
            this.ScanByDOSIPIDENT(startRow, maxRows);
            this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJELevel1.EndLoadData();
            this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE.EndLoadData();
            this.DOSIPZAGLAVLJESet.EnforceConstraints = enforceConstraints;
            if (this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE.Count > 0)
            {
                this.rowDOSIPZAGLAVLJE = this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE[this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE.Count - 1];
            }
        }

        private void LoadByDOSIPIDENTDOSJMBG(int startRow, int maxRows)
        {
            bool enforceConstraints = this.DOSIPZAGLAVLJESet.EnforceConstraints;
            this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJELevel1.BeginLoadData();
            this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE.BeginLoadData();
            this.ScanByDOSIPIDENTDOSJMBG(startRow, maxRows);
            this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJELevel1.EndLoadData();
            this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE.EndLoadData();
            this.DOSIPZAGLAVLJESet.EnforceConstraints = enforceConstraints;
            if (this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE.Count > 0)
            {
                this.rowDOSIPZAGLAVLJE = this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE[this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE.Count - 1];
            }
        }

        private void LoadChildDosipzaglavlje(int startRow, int maxRows)
        {
            this.CreateNewRowDosipzaglavlje();
            bool enforceConstraints = this.DOSIPZAGLAVLJESet.EnforceConstraints;
            this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJELevel1.BeginLoadData();
            this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE.BeginLoadData();
            this.ScanStartDosipzaglavlje(startRow, maxRows);
            this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJELevel1.EndLoadData();
            this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE.EndLoadData();
            this.DOSIPZAGLAVLJESet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildDosipzaglavljelevel1()
        {
            this.CreateNewRowDosipzaglavljelevel1();
            this.ScanStartDosipzaglavljelevel1();
        }

        private void LoadDataDosipzaglavlje(int maxRows)
        {
            int num = 0;
            if (this.RcdFound104 != 0)
            {
                this.ScanLoadDosipzaglavlje();
                while ((this.RcdFound104 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowDosipzaglavlje();
                    this.CreateNewRowDosipzaglavlje();
                    this.ScanNextDosipzaglavlje();
                }
            }
            if (num > 0)
            {
                this.RcdFound104 = 1;
            }
            this.ScanEndDosipzaglavlje();
            if (this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE.Count > 0)
            {
                this.rowDOSIPZAGLAVLJE = this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE[this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE.Count - 1];
            }
        }

        private void LoadDataDosipzaglavljelevel1()
        {
            while (this.RcdFound105 != 0)
            {
                this.LoadRowDosipzaglavljelevel1();
                this.CreateNewRowDosipzaglavljelevel1();
                this.ScanNextDosipzaglavljelevel1();
            }
            this.ScanEndDosipzaglavljelevel1();
        }

        private void LoadRowDosipzaglavlje()
        {
            this.AddRowDosipzaglavlje();
        }

        private void LoadRowDosipzaglavljelevel1()
        {
            this.AddRowDosipzaglavljelevel1();
        }

        private void OnDOSIPZAGLAVLJELevel1Updated(DOSIPZAGLAVLJELevel1EventArgs e)
        {
            if (this.DOSIPZAGLAVLJELevel1Updated != null)
            {
                DOSIPZAGLAVLJELevel1UpdateEventHandler handler = this.DOSIPZAGLAVLJELevel1Updated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnDOSIPZAGLAVLJELevel1Updating(DOSIPZAGLAVLJELevel1EventArgs e)
        {
            if (this.DOSIPZAGLAVLJELevel1Updating != null)
            {
                DOSIPZAGLAVLJELevel1UpdateEventHandler handler = this.DOSIPZAGLAVLJELevel1Updating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnDOSIPZAGLAVLJEUpdated(DOSIPZAGLAVLJEEventArgs e)
        {
            if (this.DOSIPZAGLAVLJEUpdated != null)
            {
                DOSIPZAGLAVLJEUpdateEventHandler dOSIPZAGLAVLJEUpdatedEvent = this.DOSIPZAGLAVLJEUpdated;
                if (dOSIPZAGLAVLJEUpdatedEvent != null)
                {
                    dOSIPZAGLAVLJEUpdatedEvent(this, e);
                }
            }
        }

        private void OnDOSIPZAGLAVLJEUpdating(DOSIPZAGLAVLJEEventArgs e)
        {
            if (this.DOSIPZAGLAVLJEUpdating != null)
            {
                DOSIPZAGLAVLJEUpdateEventHandler dOSIPZAGLAVLJEUpdatingEvent = this.DOSIPZAGLAVLJEUpdating;
                if (dOSIPZAGLAVLJEUpdatingEvent != null)
                {
                    dOSIPZAGLAVLJEUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelDosipzaglavlje()
        {
            this.sMode104 = this.Gx_mode;
            this.ProcessNestedLevelDosipzaglavljelevel1();
            this.Gx_mode = this.sMode104;
        }

        private void ProcessNestedLevelDosipzaglavljelevel1()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJELevel1.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowDOSIPZAGLAVLJELevel1 = (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row) current;
                    if (Helpers.IsRowChanged(this.rowDOSIPZAGLAVLJELevel1))
                    {
                        bool flag = false;
                        if (this.rowDOSIPZAGLAVLJELevel1.RowState != DataRowState.Deleted)
                        {
                            flag = (string.Compare(this.rowDOSIPZAGLAVLJELevel1.DOSIPIDENT.TrimEnd(new char[] { ' ' }), this.rowDOSIPZAGLAVLJE.DOSIPIDENT.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0) && (string.Compare(this.rowDOSIPZAGLAVLJELevel1.DOSJMBG.TrimEnd(new char[] { ' ' }), this.rowDOSIPZAGLAVLJE.DOSJMBG.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0);
                        }
                        else
                        {
                            flag = this.rowDOSIPZAGLAVLJELevel1["DOSIPIDENT", DataRowVersion.Original].Equals(this.rowDOSIPZAGLAVLJE.DOSIPIDENT) && this.rowDOSIPZAGLAVLJELevel1["DOSJMBG", DataRowVersion.Original].Equals(this.rowDOSIPZAGLAVLJE.DOSJMBG);
                        }
                        if (flag)
                        {
                            this.ReadRowDosipzaglavljelevel1();
                            if (this.rowDOSIPZAGLAVLJELevel1.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertDosipzaglavljelevel1();
                            }
                            else
                            {
                                if (this._Gxremove21)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteDosipzaglavljelevel1();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateDosipzaglavljelevel1();
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

        private void ReadRowDosipzaglavlje()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDOSIPZAGLAVLJE.RowState);
            if (this.rowDOSIPZAGLAVLJE.RowState != DataRowState.Added)
            {
                this.m__DOSISPLATAUGODINIOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSISPLATAUGODINI", DataRowVersion.Original]);
                this.m__DOSISPLATAZAGODINUOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSISPLATAZAGODINU", DataRowVersion.Original]);
                this.m__DOSOZNACENOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSOZNACEN", DataRowVersion.Original]);
            }
            else
            {
                this.m__DOSISPLATAUGODINIOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSISPLATAUGODINI"]);
                this.m__DOSISPLATAZAGODINUOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSISPLATAZAGODINU"]);
                this.m__DOSOZNACENOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSOZNACEN"]);
            }
            this._Gxremove = this.rowDOSIPZAGLAVLJE.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowDOSIPZAGLAVLJE = (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow) DataSetUtil.CloneOriginalDataRow(this.rowDOSIPZAGLAVLJE);
            }
        }

        private void ReadRowDosipzaglavljelevel1()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDOSIPZAGLAVLJELevel1.RowState);
            if (this.rowDOSIPZAGLAVLJELevel1.RowState != DataRowState.Added)
            {
                this.m__DOSIDOPCINESTANOVANJAOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSIDOPCINESTANOVANJA", DataRowVersion.Original]);
                this.m__DOSUKUPNOBRUTOOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOBRUTO", DataRowVersion.Original]);
                this.m__DOSUKUPNODOPRINOSIOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNODOPRINOSI", DataRowVersion.Original]);
                this.m__DOSUKUPNOOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOOLAKSICE", DataRowVersion.Original]);
                this.m__DOSDOHODAKOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSDOHODAK", DataRowVersion.Original]);
                this.m__DOSUKUPNOOOOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOOO", DataRowVersion.Original]);
                this.m__DOSPOREZNAOSNOVICAOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSPOREZNAOSNOVICA", DataRowVersion.Original]);
                this.m__DOSUKUPNOPOREZIPRIREZOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOPOREZIPRIREZ", DataRowVersion.Original]);
                this.m__DOSUKUPNONETOISPLATAOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNONETOISPLATA", DataRowVersion.Original]);
                this.m__DOSPOSEBANPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSPOSEBANPOREZ", DataRowVersion.Original]);
            }
            else
            {
                this.m__DOSIDOPCINESTANOVANJAOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSIDOPCINESTANOVANJA"]);
                this.m__DOSUKUPNOBRUTOOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOBRUTO"]);
                this.m__DOSUKUPNODOPRINOSIOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNODOPRINOSI"]);
                this.m__DOSUKUPNOOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOOLAKSICE"]);
                this.m__DOSDOHODAKOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSDOHODAK"]);
                this.m__DOSUKUPNOOOOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOOO"]);
                this.m__DOSPOREZNAOSNOVICAOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSPOREZNAOSNOVICA"]);
                this.m__DOSUKUPNOPOREZIPRIREZOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOPOREZIPRIREZ"]);
                this.m__DOSUKUPNONETOISPLATAOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNONETOISPLATA"]);
                this.m__DOSPOSEBANPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSPOSEBANPOREZ"]);
            }
            this._Gxremove21 = this.rowDOSIPZAGLAVLJELevel1.RowState == DataRowState.Deleted;
            if (this._Gxremove21)
            {
                this.rowDOSIPZAGLAVLJELevel1 = (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row) DataSetUtil.CloneOriginalDataRow(this.rowDOSIPZAGLAVLJELevel1);
            }
        }

        private void ScanByDOSIPIDENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[DOSIPIDENT] = @DOSIPIDENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString104 + "  FROM [DOSIPZAGLAVLJE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[DOSIPIDENT], TM1.[DOSJMBG]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString104, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[DOSIPIDENT], TM1.[DOSJMBG] ) AS DK_PAGENUM   FROM [DOSIPZAGLAVLJE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString104 + " FROM [DOSIPZAGLAVLJE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[DOSIPIDENT], TM1.[DOSJMBG] ";
            }
            this.cmDOSIPZAGLAVLJESelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmDOSIPZAGLAVLJESelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOSIPZAGLAVLJESelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIPIDENT", DbType.String, 2));
            }
            this.cmDOSIPZAGLAVLJESelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSIPIDENT"]));
            this.DOSIPZAGLAVLJESelect5 = this.cmDOSIPZAGLAVLJESelect5.FetchData();
            this.RcdFound104 = 0;
            this.ScanLoadDosipzaglavlje();
            this.LoadDataDosipzaglavlje(maxRows);
            if (this.RcdFound104 > 0)
            {
                this.SubLvlScanStartDosipzaglavljelevel1(this.m_WhereString, startRow, maxRows);
                this.SetParametersDOSIPIDENTDosipzaglavlje(this.cmDOSIPZAGLAVLJELevel1Select2);
                this.SubLvlFetchDosipzaglavljelevel1();
                this.SubLoadDataDosipzaglavljelevel1();
            }
        }

        private void ScanByDOSIPIDENTDOSJMBG(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[DOSIPIDENT] = @DOSIPIDENT and TM1.[DOSJMBG] = @DOSJMBG";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString104 + "  FROM [DOSIPZAGLAVLJE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[DOSIPIDENT], TM1.[DOSJMBG]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString104, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[DOSIPIDENT], TM1.[DOSJMBG] ) AS DK_PAGENUM   FROM [DOSIPZAGLAVLJE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString104 + " FROM [DOSIPZAGLAVLJE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[DOSIPIDENT], TM1.[DOSJMBG] ";
            }
            this.cmDOSIPZAGLAVLJESelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmDOSIPZAGLAVLJESelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOSIPZAGLAVLJESelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIPIDENT", DbType.String, 2));
                this.cmDOSIPZAGLAVLJESelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSJMBG", DbType.String, 13));
            }
            this.cmDOSIPZAGLAVLJESelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSIPIDENT"]));
            this.cmDOSIPZAGLAVLJESelect5.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSJMBG"]));
            this.DOSIPZAGLAVLJESelect5 = this.cmDOSIPZAGLAVLJESelect5.FetchData();
            this.RcdFound104 = 0;
            this.ScanLoadDosipzaglavlje();
            this.LoadDataDosipzaglavlje(maxRows);
            if (this.RcdFound104 > 0)
            {
                this.SubLvlScanStartDosipzaglavljelevel1(this.m_WhereString, startRow, maxRows);
                this.SetParametersDOSIPIDENTDOSJMBGDosipzaglavlje(this.cmDOSIPZAGLAVLJELevel1Select2);
                this.SubLvlFetchDosipzaglavljelevel1();
                this.SubLoadDataDosipzaglavljelevel1();
            }
        }

        private void ScanEndDosipzaglavlje()
        {
            this.DOSIPZAGLAVLJESelect5.Close();
        }

        private void ScanEndDosipzaglavljelevel1()
        {
            this.DOSIPZAGLAVLJELevel1Select2.Close();
        }

        private void ScanLoadDosipzaglavlje()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDOSIPZAGLAVLJESelect5.HasMoreRows)
            {
                this.RcdFound104 = 1;
                this.rowDOSIPZAGLAVLJE["DOSIPIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOSIPZAGLAVLJESelect5, 0));
                this.rowDOSIPZAGLAVLJE["DOSJMBG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOSIPZAGLAVLJESelect5, 1));
                this.rowDOSIPZAGLAVLJE["DOSISPLATAUGODINI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOSIPZAGLAVLJESelect5, 2));
                this.rowDOSIPZAGLAVLJE["DOSISPLATAZAGODINU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOSIPZAGLAVLJESelect5, 3));
                this.rowDOSIPZAGLAVLJE["DOSOZNACEN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.DOSIPZAGLAVLJESelect5, 4));
            }
        }

        private void ScanLoadDosipzaglavljelevel1()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDOSIPZAGLAVLJELevel1Select2.HasMoreRows)
            {
                this.RcdFound105 = 1;
                this.rowDOSIPZAGLAVLJELevel1["DOSIPIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOSIPZAGLAVLJELevel1Select2, 0));
                this.rowDOSIPZAGLAVLJELevel1["DOSJMBG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOSIPZAGLAVLJELevel1Select2, 1));
                this.rowDOSIPZAGLAVLJELevel1["DOSMJESECISPLATE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOSIPZAGLAVLJELevel1Select2, 2));
                this.rowDOSIPZAGLAVLJELevel1["DOSIDOPCINESTANOVANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOSIPZAGLAVLJELevel1Select2, 3));
                this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOBRUTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DOSIPZAGLAVLJELevel1Select2, 4));
                this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNODOPRINOSI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DOSIPZAGLAVLJELevel1Select2, 5));
                this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DOSIPZAGLAVLJELevel1Select2, 6));
                this.rowDOSIPZAGLAVLJELevel1["DOSDOHODAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DOSIPZAGLAVLJELevel1Select2, 7));
                this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOOO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DOSIPZAGLAVLJELevel1Select2, 8));
                this.rowDOSIPZAGLAVLJELevel1["DOSPOREZNAOSNOVICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DOSIPZAGLAVLJELevel1Select2, 9));
                this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOPOREZIPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DOSIPZAGLAVLJELevel1Select2, 10));
                this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNONETOISPLATA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DOSIPZAGLAVLJELevel1Select2, 11));
                this.rowDOSIPZAGLAVLJELevel1["DOSPOSEBANPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DOSIPZAGLAVLJELevel1Select2, 12));
            }
        }

        private void ScanNextDosipzaglavlje()
        {
            this.cmDOSIPZAGLAVLJESelect5.HasMoreRows = this.DOSIPZAGLAVLJESelect5.Read();
            this.RcdFound104 = 0;
            this.ScanLoadDosipzaglavlje();
        }

        private void ScanNextDosipzaglavljelevel1()
        {
            this.cmDOSIPZAGLAVLJELevel1Select2.HasMoreRows = this.DOSIPZAGLAVLJELevel1Select2.Read();
            this.RcdFound105 = 0;
            this.ScanLoadDosipzaglavljelevel1();
        }

        private void ScanStartDosipzaglavlje(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString104 + "  FROM [DOSIPZAGLAVLJE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[DOSIPIDENT], TM1.[DOSJMBG]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString104, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[DOSIPIDENT], TM1.[DOSJMBG] ) AS DK_PAGENUM   FROM [DOSIPZAGLAVLJE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString104 + " FROM [DOSIPZAGLAVLJE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[DOSIPIDENT], TM1.[DOSJMBG] ";
            }
            this.cmDOSIPZAGLAVLJESelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.DOSIPZAGLAVLJESelect5 = this.cmDOSIPZAGLAVLJESelect5.FetchData();
            this.RcdFound104 = 0;
            this.ScanLoadDosipzaglavlje();
            this.LoadDataDosipzaglavlje(maxRows);
            if (this.RcdFound104 > 0)
            {
                this.SubLvlScanStartDosipzaglavljelevel1(this.m_WhereString, startRow, maxRows);
                this.SetParametersDosipzaglavljeDosipzaglavlje(this.cmDOSIPZAGLAVLJELevel1Select2);
                this.SubLvlFetchDosipzaglavljelevel1();
                this.SubLoadDataDosipzaglavljelevel1();
            }
        }

        private void ScanStartDosipzaglavljelevel1()
        {
            this.cmDOSIPZAGLAVLJELevel1Select2 = this.connDefault.GetCommand("SELECT [DOSIPIDENT], [DOSJMBG], [DOSMJESECISPLATE], [DOSIDOPCINESTANOVANJA], [DOSUKUPNOBRUTO], [DOSUKUPNODOPRINOSI], [DOSUKUPNOOLAKSICE], [DOSDOHODAK], [DOSUKUPNOOO], [DOSPOREZNAOSNOVICA], [DOSUKUPNOPOREZIPRIREZ], [DOSUKUPNONETOISPLATA], [DOSPOSEBANPOREZ] FROM [DOSIPZAGLAVLJELevel1] WITH (NOLOCK) WHERE [DOSIPIDENT] = @DOSIPIDENT and [DOSJMBG] = @DOSJMBG ORDER BY [DOSIPIDENT], [DOSJMBG], [DOSMJESECISPLATE] ", false);
            if (this.cmDOSIPZAGLAVLJELevel1Select2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOSIPZAGLAVLJELevel1Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIPIDENT", DbType.String, 2));
                this.cmDOSIPZAGLAVLJELevel1Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSJMBG", DbType.String, 13));
            }
            this.cmDOSIPZAGLAVLJELevel1Select2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSIPIDENT"]));
            this.cmDOSIPZAGLAVLJELevel1Select2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSJMBG"]));
            this.DOSIPZAGLAVLJELevel1Select2 = this.cmDOSIPZAGLAVLJELevel1Select2.FetchData();
            this.RcdFound105 = 0;
            this.ScanLoadDosipzaglavljelevel1();
        }

        private void SetParametersDOSIPIDENTDosipzaglavlje(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIPIDENT", DbType.String, 2));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSIPIDENT"]));
        }

        private void SetParametersDOSIPIDENTDOSJMBGDosipzaglavlje(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIPIDENT", DbType.String, 2));
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSJMBG", DbType.String, 13));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSIPIDENT"]));
            m_Command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSJMBG"]));
        }

        private void SetParametersDosipzaglavljeDosipzaglavlje(ReadWriteCommand m_Command)
        {
        }

        private void SkipNextDosipzaglavljelevel1()
        {
            this.cmDOSIPZAGLAVLJELevel1Select2.HasMoreRows = this.DOSIPZAGLAVLJELevel1Select2.Read();
            this.RcdFound105 = 0;
            if (this.cmDOSIPZAGLAVLJELevel1Select2.HasMoreRows)
            {
                this.RcdFound105 = 1;
            }
        }

        private void SubLoadDataDosipzaglavljelevel1()
        {
            while (this.RcdFound105 != 0)
            {
                this.LoadRowDosipzaglavljelevel1();
                this.CreateNewRowDosipzaglavljelevel1();
                this.ScanNextDosipzaglavljelevel1();
            }
            this.ScanEndDosipzaglavljelevel1();
        }

        private void SubLvlFetchDosipzaglavljelevel1()
        {
            this.CreateNewRowDosipzaglavljelevel1();
            this.DOSIPZAGLAVLJELevel1Select2 = this.cmDOSIPZAGLAVLJELevel1Select2.FetchData();
            this.RcdFound105 = 0;
            this.ScanLoadDosipzaglavljelevel1();
        }

        private void SubLvlScanStartDosipzaglavljelevel1(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString105 = "(SELECT TOP " + maxRows.ToString() + " TM1.[DOSIPIDENT],TM1.[DOSJMBG]  FROM [DOSIPZAGLAVLJE]  TM1 " + this.m_WhereString + " ORDER BY TM1.[DOSIPIDENT], TM1.[DOSJMBG] )";
                    this.scmdbuf = "SELECT T1.[DOSIPIDENT], T1.[DOSJMBG], T1.[DOSMJESECISPLATE], T1.[DOSIDOPCINESTANOVANJA], T1.[DOSUKUPNOBRUTO], T1.[DOSUKUPNODOPRINOSI], T1.[DOSUKUPNOOLAKSICE], T1.[DOSDOHODAK], T1.[DOSUKUPNOOO], T1.[DOSPOREZNAOSNOVICA], T1.[DOSUKUPNOPOREZIPRIREZ], T1.[DOSUKUPNONETOISPLATA], T1.[DOSPOSEBANPOREZ] FROM ([DOSIPZAGLAVLJELevel1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString105 + "  TMX ON TMX.[DOSIPIDENT] = T1.[DOSIPIDENT] AND TMX.[DOSJMBG] = T1.[DOSJMBG]) ORDER BY T1.[DOSIPIDENT], T1.[DOSJMBG], T1.[DOSMJESECISPLATE]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[DOSIPIDENT],TM1.[DOSJMBG], ROW_NUMBER() OVER  (  ORDER BY TM1.[DOSIPIDENT], TM1.[DOSJMBG]  ) AS DK_PAGENUM   FROM [DOSIPZAGLAVLJE]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString105 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[DOSIPIDENT], T1.[DOSJMBG], T1.[DOSMJESECISPLATE], T1.[DOSIDOPCINESTANOVANJA], T1.[DOSUKUPNOBRUTO], T1.[DOSUKUPNODOPRINOSI], T1.[DOSUKUPNOOLAKSICE], T1.[DOSDOHODAK], T1.[DOSUKUPNOOO], T1.[DOSPOREZNAOSNOVICA], T1.[DOSUKUPNOPOREZIPRIREZ], T1.[DOSUKUPNONETOISPLATA], T1.[DOSPOSEBANPOREZ] FROM ([DOSIPZAGLAVLJELevel1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString105 + "  TMX ON TMX.[DOSIPIDENT] = T1.[DOSIPIDENT] AND TMX.[DOSJMBG] = T1.[DOSJMBG]) ORDER BY T1.[DOSIPIDENT], T1.[DOSJMBG], T1.[DOSMJESECISPLATE]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString105 = "[DOSIPZAGLAVLJE]";
                this.scmdbuf = "SELECT T1.[DOSIPIDENT], T1.[DOSJMBG], T1.[DOSMJESECISPLATE], T1.[DOSIDOPCINESTANOVANJA], T1.[DOSUKUPNOBRUTO], T1.[DOSUKUPNODOPRINOSI], T1.[DOSUKUPNOOLAKSICE], T1.[DOSDOHODAK], T1.[DOSUKUPNOOO], T1.[DOSPOREZNAOSNOVICA], T1.[DOSUKUPNOPOREZIPRIREZ], T1.[DOSUKUPNONETOISPLATA], T1.[DOSPOSEBANPOREZ] FROM ([DOSIPZAGLAVLJELevel1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString105 + "  TM1 WITH (NOLOCK) ON TM1.[DOSIPIDENT] = T1.[DOSIPIDENT] AND TM1.[DOSJMBG] = T1.[DOSJMBG])" + this.m_WhereString + " ORDER BY T1.[DOSIPIDENT], T1.[DOSJMBG], T1.[DOSMJESECISPLATE] ";
            }
            this.cmDOSIPZAGLAVLJELevel1Select2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.DOSIPZAGLAVLJESet = (DOSIPZAGLAVLJEDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.DOSIPZAGLAVLJESet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.DOSIPZAGLAVLJESet.DOSIPZAGLAVLJE.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow current = (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow) enumerator.Current;
                        this.rowDOSIPZAGLAVLJE = current;
                        if (Helpers.IsRowChanged(this.rowDOSIPZAGLAVLJE))
                        {
                            this.ReadRowDosipzaglavlje();
                            if (this.rowDOSIPZAGLAVLJE.RowState == DataRowState.Added)
                            {
                                this.InsertDosipzaglavlje();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateDosipzaglavlje();
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

        private void UpdateDosipzaglavlje()
        {
            this.CheckOptimisticConcurrencyDosipzaglavlje();
            this.AfterConfirmDosipzaglavlje();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DOSIPZAGLAVLJE] SET [DOSISPLATAUGODINI]=@DOSISPLATAUGODINI, [DOSISPLATAZAGODINU]=@DOSISPLATAZAGODINU, [DOSOZNACEN]=@DOSOZNACEN  WHERE [DOSIPIDENT] = @DOSIPIDENT AND [DOSJMBG] = @DOSJMBG", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSISPLATAUGODINI", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSISPLATAZAGODINU", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSOZNACEN", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIPIDENT", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSJMBG", DbType.String, 13));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSISPLATAUGODINI"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSISPLATAZAGODINU"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSOZNACEN"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSIPIDENT"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJE["DOSJMBG"]));
            command.ExecuteStmt();
            this.OnDOSIPZAGLAVLJEUpdated(new DOSIPZAGLAVLJEEventArgs(this.rowDOSIPZAGLAVLJE, StatementType.Update));
            this.ProcessLevelDosipzaglavlje();
        }

        private void UpdateDosipzaglavljelevel1()
        {
            this.CheckOptimisticConcurrencyDosipzaglavljelevel1();
            this.AfterConfirmDosipzaglavljelevel1();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DOSIPZAGLAVLJELevel1] SET [DOSIDOPCINESTANOVANJA]=@DOSIDOPCINESTANOVANJA, [DOSUKUPNOBRUTO]=@DOSUKUPNOBRUTO, [DOSUKUPNODOPRINOSI]=@DOSUKUPNODOPRINOSI, [DOSUKUPNOOLAKSICE]=@DOSUKUPNOOLAKSICE, [DOSDOHODAK]=@DOSDOHODAK, [DOSUKUPNOOO]=@DOSUKUPNOOO, [DOSPOREZNAOSNOVICA]=@DOSPOREZNAOSNOVICA, [DOSUKUPNOPOREZIPRIREZ]=@DOSUKUPNOPOREZIPRIREZ, [DOSUKUPNONETOISPLATA]=@DOSUKUPNONETOISPLATA, [DOSPOSEBANPOREZ]=@DOSPOSEBANPOREZ  WHERE [DOSIPIDENT] = @DOSIPIDENT AND [DOSJMBG] = @DOSJMBG AND [DOSMJESECISPLATE] = @DOSMJESECISPLATE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIDOPCINESTANOVANJA", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSUKUPNOBRUTO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSUKUPNODOPRINOSI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSUKUPNOOLAKSICE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSDOHODAK", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSUKUPNOOO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSPOREZNAOSNOVICA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSUKUPNOPOREZIPRIREZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSUKUPNONETOISPLATA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSPOSEBANPOREZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIPIDENT", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSJMBG", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSMJESECISPLATE", DbType.String, 2));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSIDOPCINESTANOVANJA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOBRUTO"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNODOPRINOSI"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOOLAKSICE"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSDOHODAK"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOOO"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSPOREZNAOSNOVICA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNOPOREZIPRIREZ"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSUKUPNONETOISPLATA"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSPOSEBANPOREZ"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSIPIDENT"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSJMBG"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowDOSIPZAGLAVLJELevel1["DOSMJESECISPLATE"]));
            command.ExecuteStmt();
            this.OnDOSIPZAGLAVLJELevel1Updated(new DOSIPZAGLAVLJELevel1EventArgs(this.rowDOSIPZAGLAVLJELevel1, StatementType.Update));
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
        public class DOSIPZAGLAVLJEDataChangedException : DataChangedException
        {
            public DOSIPZAGLAVLJEDataChangedException()
            {
            }

            public DOSIPZAGLAVLJEDataChangedException(string message) : base(message)
            {
            }

            protected DOSIPZAGLAVLJEDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOSIPZAGLAVLJEDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DOSIPZAGLAVLJEDataLockedException : DataLockedException
        {
            public DOSIPZAGLAVLJEDataLockedException()
            {
            }

            public DOSIPZAGLAVLJEDataLockedException(string message) : base(message)
            {
            }

            protected DOSIPZAGLAVLJEDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOSIPZAGLAVLJEDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DOSIPZAGLAVLJEDuplicateKeyException : DuplicateKeyException
        {
            public DOSIPZAGLAVLJEDuplicateKeyException()
            {
            }

            public DOSIPZAGLAVLJEDuplicateKeyException(string message) : base(message)
            {
            }

            protected DOSIPZAGLAVLJEDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOSIPZAGLAVLJEDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DOSIPZAGLAVLJEEventArgs : EventArgs
        {
            private DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow m_dataRow;
            private System.Data.StatementType m_statementType;

            public DOSIPZAGLAVLJEEventArgs(DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow Row
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
        public class DOSIPZAGLAVLJELevel1DataChangedException : DataChangedException
        {
            public DOSIPZAGLAVLJELevel1DataChangedException()
            {
            }

            public DOSIPZAGLAVLJELevel1DataChangedException(string message) : base(message)
            {
            }

            protected DOSIPZAGLAVLJELevel1DataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOSIPZAGLAVLJELevel1DataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DOSIPZAGLAVLJELevel1DataLockedException : DataLockedException
        {
            public DOSIPZAGLAVLJELevel1DataLockedException()
            {
            }

            public DOSIPZAGLAVLJELevel1DataLockedException(string message) : base(message)
            {
            }

            protected DOSIPZAGLAVLJELevel1DataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOSIPZAGLAVLJELevel1DataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DOSIPZAGLAVLJELevel1DuplicateKeyException : DuplicateKeyException
        {
            public DOSIPZAGLAVLJELevel1DuplicateKeyException()
            {
            }

            public DOSIPZAGLAVLJELevel1DuplicateKeyException(string message) : base(message)
            {
            }

            protected DOSIPZAGLAVLJELevel1DuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOSIPZAGLAVLJELevel1DuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DOSIPZAGLAVLJELevel1EventArgs : EventArgs
        {
            private DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row m_dataRow;
            private System.Data.StatementType m_statementType;

            public DOSIPZAGLAVLJELevel1EventArgs(DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJELevel1Row Row
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

        public delegate void DOSIPZAGLAVLJELevel1UpdateEventHandler(object sender, DOSIPZAGLAVLJEDataAdapter.DOSIPZAGLAVLJELevel1EventArgs e);

        [Serializable]
        public class DOSIPZAGLAVLJENotFoundException : DataNotFoundException
        {
            public DOSIPZAGLAVLJENotFoundException()
            {
            }

            public DOSIPZAGLAVLJENotFoundException(string message) : base(message)
            {
            }

            protected DOSIPZAGLAVLJENotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOSIPZAGLAVLJENotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void DOSIPZAGLAVLJEUpdateEventHandler(object sender, DOSIPZAGLAVLJEDataAdapter.DOSIPZAGLAVLJEEventArgs e);
    }
}

