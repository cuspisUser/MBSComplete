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

    public class SKUPPOREZAIDOPRINOSADataAdapter : IDataAdapter, ISKUPPOREZAIDOPRINOSADataAdapter
    {
        private bool _Gxremove;
        private bool _Gxremove15;
        private bool _Gxremove28;
        private ReadWriteCommand cmSKUPPOREZAIDOPRINOSA1Select2;
        private ReadWriteCommand cmSKUPPOREZAIDOPRINOSA2Select2;
        private ReadWriteCommand cmSKUPPOREZAIDOPRINOSASelect1;
        private ReadWriteCommand cmSKUPPOREZAIDOPRINOSASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVSKUPPOREZAIDOPRINOSAOriginal;
        private readonly string m_SelectString31 = "TM1.[IDSKUPPOREZAIDOPRINOSA], TM1.[NAZIVSKUPPOREZAIDOPRINOSA]";
        private string m_SubSelTopString32;
        private string m_SubSelTopString33;
        private string m_WhereString;
        private short RcdFound31;
        private short RcdFound32;
        private short RcdFound33;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow rowSKUPPOREZAIDOPRINOSA;
        private SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row rowSKUPPOREZAIDOPRINOSA1;
        private SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row rowSKUPPOREZAIDOPRINOSA2;
        private string scmdbuf;
        private IDataReader SKUPPOREZAIDOPRINOSA1Select2;
        private IDataReader SKUPPOREZAIDOPRINOSA2Select2;
        private IDataReader SKUPPOREZAIDOPRINOSASelect1;
        private IDataReader SKUPPOREZAIDOPRINOSASelect4;
        private SKUPPOREZAIDOPRINOSADataSet SKUPPOREZAIDOPRINOSASet;
        private StatementType sMode31;
        private StatementType sMode32;
        private StatementType sMode33;

        public event SKUPPOREZAIDOPRINOSA1UpdateEventHandler SKUPPOREZAIDOPRINOSA1Updated;

        public event SKUPPOREZAIDOPRINOSA1UpdateEventHandler SKUPPOREZAIDOPRINOSA1Updating;

        public event SKUPPOREZAIDOPRINOSA2UpdateEventHandler SKUPPOREZAIDOPRINOSA2Updated;

        public event SKUPPOREZAIDOPRINOSA2UpdateEventHandler SKUPPOREZAIDOPRINOSA2Updating;

        public event SKUPPOREZAIDOPRINOSAUpdateEventHandler SKUPPOREZAIDOPRINOSAUpdated;

        public event SKUPPOREZAIDOPRINOSAUpdateEventHandler SKUPPOREZAIDOPRINOSAUpdating;

        private void AddRowSkupporezaidoprinosa()
        {
            this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA.AddSKUPPOREZAIDOPRINOSARow(this.rowSKUPPOREZAIDOPRINOSA);
        }

        private void AddRowSkupporezaidoprinosa1()
        {
            this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA1.AddSKUPPOREZAIDOPRINOSA1Row(this.rowSKUPPOREZAIDOPRINOSA1);
        }

        private void AddRowSkupporezaidoprinosa2()
        {
            this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA2.AddSKUPPOREZAIDOPRINOSA2Row(this.rowSKUPPOREZAIDOPRINOSA2);
        }

        private void AfterConfirmSkupporezaidoprinosa()
        {
            this.OnSKUPPOREZAIDOPRINOSAUpdating(new SKUPPOREZAIDOPRINOSAEventArgs(this.rowSKUPPOREZAIDOPRINOSA, this.Gx_mode));
        }

        private void AfterConfirmSkupporezaidoprinosa1()
        {
            this.OnSKUPPOREZAIDOPRINOSA1Updating(new SKUPPOREZAIDOPRINOSA1EventArgs(this.rowSKUPPOREZAIDOPRINOSA1, this.Gx_mode));
        }

        private void AfterConfirmSkupporezaidoprinosa2()
        {
            this.OnSKUPPOREZAIDOPRINOSA2Updating(new SKUPPOREZAIDOPRINOSA2EventArgs(this.rowSKUPPOREZAIDOPRINOSA2, this.Gx_mode));
        }

        private void CheckDeleteErrorsSkupporezaidoprinosa()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] = @IDSKUPPOREZAIDOPRINOSA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSKUPPOREZAIDOPRINOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA["IDSKUPPOREZAIDOPRINOSA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIK" }));
            }
            reader.Close();
        }

        private void CheckExtendedTableSkupporezaidoprinosa1()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVPOREZ], [POREZMJESECNO], [STOPAPOREZA], [MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ] FROM [POREZ] WITH (NOLOCK) WHERE [IDPOREZ] = @IDPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA1["IDPOREZ"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new POREZForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("POREZ") }));
            }
            this.rowSKUPPOREZAIDOPRINOSA1["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowSKUPPOREZAIDOPRINOSA1["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            this.rowSKUPPOREZAIDOPRINOSA1["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
            this.rowSKUPPOREZAIDOPRINOSA1["MOPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
            this.rowSKUPPOREZAIDOPRINOSA1["POPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
            this.rowSKUPPOREZAIDOPRINOSA1["MZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
            this.rowSKUPPOREZAIDOPRINOSA1["PZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
            this.rowSKUPPOREZAIDOPRINOSA1["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
            this.rowSKUPPOREZAIDOPRINOSA1["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
            this.rowSKUPPOREZAIDOPRINOSA1["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
            this.rowSKUPPOREZAIDOPRINOSA1["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
            reader.Close();
        }

        private void CheckExtendedTableSkupporezaidoprinosa2()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVDOPRINOS], [MODOPRINOS], [PODOPRINOS], [MZDOPRINOS], [PZDOPRINOS], [PRIMATELJDOPRINOS1], [PRIMATELJDOPRINOS2], [SIFRAOPISAPLACANJADOPRINOS], [OPISPLACANJADOPRINOS], [VBDIDOPRINOS], [ZRNDOPRINOS], [MINDOPRINOS], [MAXDOPRINOS], [STOPA], [IDVRSTADOPRINOS] FROM [DOPRINOS] WITH (NOLOCK) WHERE [IDDOPRINOS] = @IDDOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA2["IDDOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new DOPRINOSForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DOPRINOS") }));
            }
            this.rowSKUPPOREZAIDOPRINOSA2["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowSKUPPOREZAIDOPRINOSA2["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
            this.rowSKUPPOREZAIDOPRINOSA2["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
            this.rowSKUPPOREZAIDOPRINOSA2["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
            this.rowSKUPPOREZAIDOPRINOSA2["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
            this.rowSKUPPOREZAIDOPRINOSA2["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
            this.rowSKUPPOREZAIDOPRINOSA2["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
            this.rowSKUPPOREZAIDOPRINOSA2["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
            this.rowSKUPPOREZAIDOPRINOSA2["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
            this.rowSKUPPOREZAIDOPRINOSA2["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
            this.rowSKUPPOREZAIDOPRINOSA2["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
            this.rowSKUPPOREZAIDOPRINOSA2["MINDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 11));
            this.rowSKUPPOREZAIDOPRINOSA2["MAXDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 12));
            this.rowSKUPPOREZAIDOPRINOSA2["STOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 13));
            this.rowSKUPPOREZAIDOPRINOSA2["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 14));
            reader.Close();
            if (!this.rowSKUPPOREZAIDOPRINOSA2.IsIDVRSTADOPRINOSNull())
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVVRSTADOPRINOS] FROM [VRSTADOPRINOS] WITH (NOLOCK) WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
                }
                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA2["IDVRSTADOPRINOS"]));
                IDataReader reader2 = command2.FetchData();
                if (!command2.HasMoreRows)
                {
                    reader2.Close();
                    throw new VRSTADOPRINOSForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("VRSTADOPRINOS") }));
                }
                this.rowSKUPPOREZAIDOPRINOSA2["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                reader2.Close();
            }
            else
            {
                this.rowSKUPPOREZAIDOPRINOSA2["NAZIVVRSTADOPRINOS"] = "";
            }
        }

        private void CheckOptimisticConcurrencySkupporezaidoprinosa()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSKUPPOREZAIDOPRINOSA], [NAZIVSKUPPOREZAIDOPRINOSA] FROM [SKUPPOREZAIDOPRINOSA] WITH (UPDLOCK) WHERE [IDSKUPPOREZAIDOPRINOSA] = @IDSKUPPOREZAIDOPRINOSA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSKUPPOREZAIDOPRINOSA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA["IDSKUPPOREZAIDOPRINOSA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new SKUPPOREZAIDOPRINOSADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("SKUPPOREZAIDOPRINOSA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVSKUPPOREZAIDOPRINOSAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new SKUPPOREZAIDOPRINOSADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("SKUPPOREZAIDOPRINOSA") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencySkupporezaidoprinosa1()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSKUPPOREZAIDOPRINOSA], [IDPOREZ] FROM [SKUPPOREZAIDOPRINOSA1] WITH (UPDLOCK) WHERE [IDSKUPPOREZAIDOPRINOSA] = @IDSKUPPOREZAIDOPRINOSA AND [IDPOREZ] = @IDPOREZ ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSKUPPOREZAIDOPRINOSA", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA1["IDSKUPPOREZAIDOPRINOSA"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA1["IDPOREZ"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new SKUPPOREZAIDOPRINOSA1DataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("SKUPPOREZAIDOPRINOSA1") }));
                }
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new SKUPPOREZAIDOPRINOSA1DataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("SKUPPOREZAIDOPRINOSA1") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencySkupporezaidoprinosa2()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSKUPPOREZAIDOPRINOSA], [IDDOPRINOS] FROM [SKUPPOREZAIDOPRINOSA2] WITH (UPDLOCK) WHERE [IDSKUPPOREZAIDOPRINOSA] = @IDSKUPPOREZAIDOPRINOSA AND [IDDOPRINOS] = @IDDOPRINOS ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSKUPPOREZAIDOPRINOSA", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA2["IDSKUPPOREZAIDOPRINOSA"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA2["IDDOPRINOS"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new SKUPPOREZAIDOPRINOSA2DataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("SKUPPOREZAIDOPRINOSA2") }));
                }
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new SKUPPOREZAIDOPRINOSA2DataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("SKUPPOREZAIDOPRINOSA2") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowSkupporezaidoprinosa()
        {
            this.rowSKUPPOREZAIDOPRINOSA = this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA.NewSKUPPOREZAIDOPRINOSARow();
        }

        private void CreateNewRowSkupporezaidoprinosa1()
        {
            this.rowSKUPPOREZAIDOPRINOSA1 = this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA1.NewSKUPPOREZAIDOPRINOSA1Row();
        }

        private void CreateNewRowSkupporezaidoprinosa2()
        {
            this.rowSKUPPOREZAIDOPRINOSA2 = this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA2.NewSKUPPOREZAIDOPRINOSA2Row();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencySkupporezaidoprinosa();
            this.ProcessNestedLevelSkupporezaidoprinosa2();
            this.ProcessNestedLevelSkupporezaidoprinosa1();
            this.AfterConfirmSkupporezaidoprinosa();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [SKUPPOREZAIDOPRINOSA]  WHERE [IDSKUPPOREZAIDOPRINOSA] = @IDSKUPPOREZAIDOPRINOSA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSKUPPOREZAIDOPRINOSA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA["IDSKUPPOREZAIDOPRINOSA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsSkupporezaidoprinosa();
            }
            this.OnSKUPPOREZAIDOPRINOSAUpdated(new SKUPPOREZAIDOPRINOSAEventArgs(this.rowSKUPPOREZAIDOPRINOSA, StatementType.Delete));
            this.rowSKUPPOREZAIDOPRINOSA.Delete();
            this.sMode31 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode31;
        }

        private void DeleteSkupporezaidoprinosa1()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencySkupporezaidoprinosa1();
            this.OnDeleteControlsSkupporezaidoprinosa1();
            this.AfterConfirmSkupporezaidoprinosa1();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [SKUPPOREZAIDOPRINOSA1]  WHERE [IDSKUPPOREZAIDOPRINOSA] = @IDSKUPPOREZAIDOPRINOSA AND [IDPOREZ] = @IDPOREZ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSKUPPOREZAIDOPRINOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA1["IDSKUPPOREZAIDOPRINOSA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA1["IDPOREZ"]));
            command.ExecuteStmt();
            this.OnSKUPPOREZAIDOPRINOSA1Updated(new SKUPPOREZAIDOPRINOSA1EventArgs(this.rowSKUPPOREZAIDOPRINOSA1, StatementType.Delete));
            this.rowSKUPPOREZAIDOPRINOSA1.Delete();
            this.sMode32 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode32;
        }

        private void DeleteSkupporezaidoprinosa2()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencySkupporezaidoprinosa2();
            this.OnDeleteControlsSkupporezaidoprinosa2();
            this.AfterConfirmSkupporezaidoprinosa2();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [SKUPPOREZAIDOPRINOSA2]  WHERE [IDSKUPPOREZAIDOPRINOSA] = @IDSKUPPOREZAIDOPRINOSA AND [IDDOPRINOS] = @IDDOPRINOS", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSKUPPOREZAIDOPRINOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA2["IDSKUPPOREZAIDOPRINOSA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA2["IDDOPRINOS"]));
            command.ExecuteStmt();
            this.OnSKUPPOREZAIDOPRINOSA2Updated(new SKUPPOREZAIDOPRINOSA2EventArgs(this.rowSKUPPOREZAIDOPRINOSA2, StatementType.Delete));
            this.rowSKUPPOREZAIDOPRINOSA2.Delete();
            this.sMode33 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode33;
        }

        public virtual int Fill(SKUPPOREZAIDOPRINOSADataSet dataSet)
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
                    this.SKUPPOREZAIDOPRINOSASet = dataSet;
                    this.LoadChildSkupporezaidoprinosa(0, -1);
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
            this.SKUPPOREZAIDOPRINOSASet = (SKUPPOREZAIDOPRINOSADataSet) dataSet;
            if (this.SKUPPOREZAIDOPRINOSASet != null)
            {
                return this.Fill(this.SKUPPOREZAIDOPRINOSASet);
            }
            this.SKUPPOREZAIDOPRINOSASet = new SKUPPOREZAIDOPRINOSADataSet();
            this.Fill(this.SKUPPOREZAIDOPRINOSASet);
            dataSet.Merge(this.SKUPPOREZAIDOPRINOSASet);
            return 0;
        }

        public virtual int Fill(SKUPPOREZAIDOPRINOSADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSKUPPOREZAIDOPRINOSA"]));
        }

        public virtual int Fill(SKUPPOREZAIDOPRINOSADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSKUPPOREZAIDOPRINOSA"]));
        }

        public virtual int Fill(SKUPPOREZAIDOPRINOSADataSet dataSet, int iDSKUPPOREZAIDOPRINOSA)
        {
            if (!this.FillByIDSKUPPOREZAIDOPRINOSA(dataSet, iDSKUPPOREZAIDOPRINOSA))
            {
                throw new SKUPPOREZAIDOPRINOSANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("SKUPPOREZAIDOPRINOSA") }));
            }
            return 0;
        }

        public virtual bool FillByIDSKUPPOREZAIDOPRINOSA(SKUPPOREZAIDOPRINOSADataSet dataSet, int iDSKUPPOREZAIDOPRINOSA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SKUPPOREZAIDOPRINOSASet = dataSet;
            this.rowSKUPPOREZAIDOPRINOSA = this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA.NewSKUPPOREZAIDOPRINOSARow();
            this.rowSKUPPOREZAIDOPRINOSA.IDSKUPPOREZAIDOPRINOSA = iDSKUPPOREZAIDOPRINOSA;
            try
            {
                this.LoadByIDSKUPPOREZAIDOPRINOSA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound31 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(SKUPPOREZAIDOPRINOSADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SKUPPOREZAIDOPRINOSASet = dataSet;
            try
            {
                this.LoadChildSkupporezaidoprinosa(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSKUPPOREZAIDOPRINOSA], [NAZIVSKUPPOREZAIDOPRINOSA] FROM [SKUPPOREZAIDOPRINOSA] WITH (NOLOCK) WHERE [IDSKUPPOREZAIDOPRINOSA] = @IDSKUPPOREZAIDOPRINOSA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSKUPPOREZAIDOPRINOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA["IDSKUPPOREZAIDOPRINOSA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound31 = 1;
                this.rowSKUPPOREZAIDOPRINOSA["IDSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowSKUPPOREZAIDOPRINOSA["NAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode31 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode31;
            }
            else
            {
                this.RcdFound31 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDSKUPPOREZAIDOPRINOSA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSKUPPOREZAIDOPRINOSASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [SKUPPOREZAIDOPRINOSA] WITH (NOLOCK) ", false);
            this.SKUPPOREZAIDOPRINOSASelect1 = this.cmSKUPPOREZAIDOPRINOSASelect1.FetchData();
            if (this.SKUPPOREZAIDOPRINOSASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.SKUPPOREZAIDOPRINOSASelect1.GetInt32(0);
            }
            this.SKUPPOREZAIDOPRINOSASelect1.Close();
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
            this.RcdFound31 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this._Gxremove28 = false;
            this.RcdFound33 = 0;
            this.m_SubSelTopString33 = "";
            this._Gxremove15 = false;
            this.RcdFound32 = 0;
            this.m_SubSelTopString32 = "";
            this.m__NAZIVSKUPPOREZAIDOPRINOSAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.SKUPPOREZAIDOPRINOSASet = new SKUPPOREZAIDOPRINOSADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertSkupporezaidoprinosa()
        {
            this.CheckOptimisticConcurrencySkupporezaidoprinosa();
            this.AfterConfirmSkupporezaidoprinosa();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [SKUPPOREZAIDOPRINOSA] ([IDSKUPPOREZAIDOPRINOSA], [NAZIVSKUPPOREZAIDOPRINOSA]) VALUES (@IDSKUPPOREZAIDOPRINOSA, @NAZIVSKUPPOREZAIDOPRINOSA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSKUPPOREZAIDOPRINOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSKUPPOREZAIDOPRINOSA", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA["IDSKUPPOREZAIDOPRINOSA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA["NAZIVSKUPPOREZAIDOPRINOSA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new SKUPPOREZAIDOPRINOSADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnSKUPPOREZAIDOPRINOSAUpdated(new SKUPPOREZAIDOPRINOSAEventArgs(this.rowSKUPPOREZAIDOPRINOSA, StatementType.Insert));
            this.ProcessLevelSkupporezaidoprinosa();
        }

        private void InsertSkupporezaidoprinosa1()
        {
            this.CheckOptimisticConcurrencySkupporezaidoprinosa1();
            this.CheckExtendedTableSkupporezaidoprinosa1();
            this.AfterConfirmSkupporezaidoprinosa1();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [SKUPPOREZAIDOPRINOSA1] ([IDSKUPPOREZAIDOPRINOSA], [IDPOREZ]) VALUES (@IDSKUPPOREZAIDOPRINOSA, @IDPOREZ)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSKUPPOREZAIDOPRINOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA1["IDSKUPPOREZAIDOPRINOSA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA1["IDPOREZ"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new SKUPPOREZAIDOPRINOSA1DuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnSKUPPOREZAIDOPRINOSA1Updated(new SKUPPOREZAIDOPRINOSA1EventArgs(this.rowSKUPPOREZAIDOPRINOSA1, StatementType.Insert));
        }

        private void InsertSkupporezaidoprinosa2()
        {
            this.CheckOptimisticConcurrencySkupporezaidoprinosa2();
            this.CheckExtendedTableSkupporezaidoprinosa2();
            this.AfterConfirmSkupporezaidoprinosa2();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [SKUPPOREZAIDOPRINOSA2] ([IDSKUPPOREZAIDOPRINOSA], [IDDOPRINOS]) VALUES (@IDSKUPPOREZAIDOPRINOSA, @IDDOPRINOS)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSKUPPOREZAIDOPRINOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA2["IDSKUPPOREZAIDOPRINOSA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA2["IDDOPRINOS"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new SKUPPOREZAIDOPRINOSA2DuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnSKUPPOREZAIDOPRINOSA2Updated(new SKUPPOREZAIDOPRINOSA2EventArgs(this.rowSKUPPOREZAIDOPRINOSA2, StatementType.Insert));
        }

        private void LoadByIDSKUPPOREZAIDOPRINOSA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.SKUPPOREZAIDOPRINOSASet.EnforceConstraints;
            this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA2.BeginLoadData();
            this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA1.BeginLoadData();
            this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA.BeginLoadData();
            this.ScanByIDSKUPPOREZAIDOPRINOSA(startRow, maxRows);
            this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA2.EndLoadData();
            this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA1.EndLoadData();
            this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA.EndLoadData();
            this.SKUPPOREZAIDOPRINOSASet.EnforceConstraints = enforceConstraints;
            if (this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA.Count > 0)
            {
                this.rowSKUPPOREZAIDOPRINOSA = this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA[this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA.Count - 1];
            }
        }

        private void LoadChildSkupporezaidoprinosa(int startRow, int maxRows)
        {
            this.CreateNewRowSkupporezaidoprinosa();
            bool enforceConstraints = this.SKUPPOREZAIDOPRINOSASet.EnforceConstraints;
            this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA2.BeginLoadData();
            this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA1.BeginLoadData();
            this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA.BeginLoadData();
            this.ScanStartSkupporezaidoprinosa(startRow, maxRows);
            this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA2.EndLoadData();
            this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA1.EndLoadData();
            this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA.EndLoadData();
            this.SKUPPOREZAIDOPRINOSASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildSkupporezaidoprinosa1()
        {
            this.CreateNewRowSkupporezaidoprinosa1();
            this.ScanStartSkupporezaidoprinosa1();
        }

        private void LoadChildSkupporezaidoprinosa2()
        {
            this.CreateNewRowSkupporezaidoprinosa2();
            this.ScanStartSkupporezaidoprinosa2();
        }

        private void LoadDataSkupporezaidoprinosa(int maxRows)
        {
            int num = 0;
            if (this.RcdFound31 != 0)
            {
                this.ScanLoadSkupporezaidoprinosa();
                while ((this.RcdFound31 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowSkupporezaidoprinosa();
                    this.CreateNewRowSkupporezaidoprinosa();
                    this.ScanNextSkupporezaidoprinosa();
                }
            }
            if (num > 0)
            {
                this.RcdFound31 = 1;
            }
            this.ScanEndSkupporezaidoprinosa();
            if (this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA.Count > 0)
            {
                this.rowSKUPPOREZAIDOPRINOSA = this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA[this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA.Count - 1];
            }
        }

        private void LoadDataSkupporezaidoprinosa1()
        {
            while (this.RcdFound32 != 0)
            {
                this.LoadRowSkupporezaidoprinosa1();
                this.CreateNewRowSkupporezaidoprinosa1();
                this.ScanNextSkupporezaidoprinosa1();
            }
            this.ScanEndSkupporezaidoprinosa1();
        }

        private void LoadDataSkupporezaidoprinosa2()
        {
            while (this.RcdFound33 != 0)
            {
                this.LoadRowSkupporezaidoprinosa2();
                this.CreateNewRowSkupporezaidoprinosa2();
                this.ScanNextSkupporezaidoprinosa2();
            }
            this.ScanEndSkupporezaidoprinosa2();
        }

        private void LoadRowSkupporezaidoprinosa()
        {
            this.AddRowSkupporezaidoprinosa();
        }

        private void LoadRowSkupporezaidoprinosa1()
        {
            this.AddRowSkupporezaidoprinosa1();
        }

        private void LoadRowSkupporezaidoprinosa2()
        {
            this.AddRowSkupporezaidoprinosa2();
        }

        private void OnDeleteControlsSkupporezaidoprinosa1()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVPOREZ], [POREZMJESECNO], [STOPAPOREZA], [MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ] FROM [POREZ] WITH (NOLOCK) WHERE [IDPOREZ] = @IDPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA1["IDPOREZ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowSKUPPOREZAIDOPRINOSA1["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowSKUPPOREZAIDOPRINOSA1["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
                this.rowSKUPPOREZAIDOPRINOSA1["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
                this.rowSKUPPOREZAIDOPRINOSA1["MOPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowSKUPPOREZAIDOPRINOSA1["POPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowSKUPPOREZAIDOPRINOSA1["MZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowSKUPPOREZAIDOPRINOSA1["PZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowSKUPPOREZAIDOPRINOSA1["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowSKUPPOREZAIDOPRINOSA1["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowSKUPPOREZAIDOPRINOSA1["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowSKUPPOREZAIDOPRINOSA1["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
            }
            reader.Close();
        }

        private void OnDeleteControlsSkupporezaidoprinosa2()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVDOPRINOS], [MODOPRINOS], [PODOPRINOS], [MZDOPRINOS], [PZDOPRINOS], [PRIMATELJDOPRINOS1], [PRIMATELJDOPRINOS2], [SIFRAOPISAPLACANJADOPRINOS], [OPISPLACANJADOPRINOS], [VBDIDOPRINOS], [ZRNDOPRINOS], [MINDOPRINOS], [MAXDOPRINOS], [STOPA], [IDVRSTADOPRINOS] FROM [DOPRINOS] WITH (NOLOCK) WHERE [IDDOPRINOS] = @IDDOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA2["IDDOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowSKUPPOREZAIDOPRINOSA2["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowSKUPPOREZAIDOPRINOSA2["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowSKUPPOREZAIDOPRINOSA2["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowSKUPPOREZAIDOPRINOSA2["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowSKUPPOREZAIDOPRINOSA2["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowSKUPPOREZAIDOPRINOSA2["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowSKUPPOREZAIDOPRINOSA2["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowSKUPPOREZAIDOPRINOSA2["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowSKUPPOREZAIDOPRINOSA2["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowSKUPPOREZAIDOPRINOSA2["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowSKUPPOREZAIDOPRINOSA2["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
                this.rowSKUPPOREZAIDOPRINOSA2["MINDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 11));
                this.rowSKUPPOREZAIDOPRINOSA2["MAXDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 12));
                this.rowSKUPPOREZAIDOPRINOSA2["STOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 13));
                this.rowSKUPPOREZAIDOPRINOSA2["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 14));
            }
            reader.Close();
            if (!this.rowSKUPPOREZAIDOPRINOSA2.IsIDVRSTADOPRINOSNull())
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVVRSTADOPRINOS] FROM [VRSTADOPRINOS] WITH (NOLOCK) WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
                }
                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA2["IDVRSTADOPRINOS"]));
                IDataReader reader2 = command2.FetchData();
                if (command2.HasMoreRows)
                {
                    this.rowSKUPPOREZAIDOPRINOSA2["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                }
                reader2.Close();
            }
            else
            {
                this.rowSKUPPOREZAIDOPRINOSA2["NAZIVVRSTADOPRINOS"] = "";
            }
        }

        private void OnSKUPPOREZAIDOPRINOSA1Updated(SKUPPOREZAIDOPRINOSA1EventArgs e)
        {
            if (this.SKUPPOREZAIDOPRINOSA1Updated != null)
            {
                SKUPPOREZAIDOPRINOSA1UpdateEventHandler handler = this.SKUPPOREZAIDOPRINOSA1Updated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnSKUPPOREZAIDOPRINOSA1Updating(SKUPPOREZAIDOPRINOSA1EventArgs e)
        {
            if (this.SKUPPOREZAIDOPRINOSA1Updating != null)
            {
                SKUPPOREZAIDOPRINOSA1UpdateEventHandler handler = this.SKUPPOREZAIDOPRINOSA1Updating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnSKUPPOREZAIDOPRINOSA2Updated(SKUPPOREZAIDOPRINOSA2EventArgs e)
        {
            if (this.SKUPPOREZAIDOPRINOSA2Updated != null)
            {
                SKUPPOREZAIDOPRINOSA2UpdateEventHandler handler = this.SKUPPOREZAIDOPRINOSA2Updated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnSKUPPOREZAIDOPRINOSA2Updating(SKUPPOREZAIDOPRINOSA2EventArgs e)
        {
            if (this.SKUPPOREZAIDOPRINOSA2Updating != null)
            {
                SKUPPOREZAIDOPRINOSA2UpdateEventHandler handler = this.SKUPPOREZAIDOPRINOSA2Updating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnSKUPPOREZAIDOPRINOSAUpdated(SKUPPOREZAIDOPRINOSAEventArgs e)
        {
            if (this.SKUPPOREZAIDOPRINOSAUpdated != null)
            {
                SKUPPOREZAIDOPRINOSAUpdateEventHandler sKUPPOREZAIDOPRINOSAUpdatedEvent = this.SKUPPOREZAIDOPRINOSAUpdated;
                if (sKUPPOREZAIDOPRINOSAUpdatedEvent != null)
                {
                    sKUPPOREZAIDOPRINOSAUpdatedEvent(this, e);
                }
            }
        }

        private void OnSKUPPOREZAIDOPRINOSAUpdating(SKUPPOREZAIDOPRINOSAEventArgs e)
        {
            if (this.SKUPPOREZAIDOPRINOSAUpdating != null)
            {
                SKUPPOREZAIDOPRINOSAUpdateEventHandler sKUPPOREZAIDOPRINOSAUpdatingEvent = this.SKUPPOREZAIDOPRINOSAUpdating;
                if (sKUPPOREZAIDOPRINOSAUpdatingEvent != null)
                {
                    sKUPPOREZAIDOPRINOSAUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelSkupporezaidoprinosa()
        {
            this.sMode31 = this.Gx_mode;
            this.ProcessNestedLevelSkupporezaidoprinosa1();
            this.ProcessNestedLevelSkupporezaidoprinosa2();
            this.Gx_mode = this.sMode31;
        }

        private void ProcessNestedLevelSkupporezaidoprinosa1()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA1.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowSKUPPOREZAIDOPRINOSA1 = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row) current;
                    if (Helpers.IsRowChanged(this.rowSKUPPOREZAIDOPRINOSA1))
                    {
                        bool flag = false;
                        if (this.rowSKUPPOREZAIDOPRINOSA1.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowSKUPPOREZAIDOPRINOSA1.IDSKUPPOREZAIDOPRINOSA == this.rowSKUPPOREZAIDOPRINOSA.IDSKUPPOREZAIDOPRINOSA;
                        }
                        else
                        {
                            flag = this.rowSKUPPOREZAIDOPRINOSA1["IDSKUPPOREZAIDOPRINOSA", DataRowVersion.Original].Equals(this.rowSKUPPOREZAIDOPRINOSA.IDSKUPPOREZAIDOPRINOSA);
                        }
                        if (flag)
                        {
                            this.ReadRowSkupporezaidoprinosa1();
                            if (this.rowSKUPPOREZAIDOPRINOSA1.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertSkupporezaidoprinosa1();
                            }
                            else
                            {
                                if (this._Gxremove15)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteSkupporezaidoprinosa1();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateSkupporezaidoprinosa1();
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

        private void ProcessNestedLevelSkupporezaidoprinosa2()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA2.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowSKUPPOREZAIDOPRINOSA2 = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row) current;
                    if (Helpers.IsRowChanged(this.rowSKUPPOREZAIDOPRINOSA2))
                    {
                        bool flag = false;
                        if (this.rowSKUPPOREZAIDOPRINOSA2.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowSKUPPOREZAIDOPRINOSA2.IDSKUPPOREZAIDOPRINOSA == this.rowSKUPPOREZAIDOPRINOSA.IDSKUPPOREZAIDOPRINOSA;
                        }
                        else
                        {
                            flag = this.rowSKUPPOREZAIDOPRINOSA2["IDSKUPPOREZAIDOPRINOSA", DataRowVersion.Original].Equals(this.rowSKUPPOREZAIDOPRINOSA.IDSKUPPOREZAIDOPRINOSA);
                        }
                        if (flag)
                        {
                            this.ReadRowSkupporezaidoprinosa2();
                            if (this.rowSKUPPOREZAIDOPRINOSA2.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertSkupporezaidoprinosa2();
                            }
                            else
                            {
                                if (this._Gxremove28)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteSkupporezaidoprinosa2();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateSkupporezaidoprinosa2();
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

        private void ReadRowSkupporezaidoprinosa()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSKUPPOREZAIDOPRINOSA.RowState);
            if (this.rowSKUPPOREZAIDOPRINOSA.RowState != DataRowState.Added)
            {
                this.m__NAZIVSKUPPOREZAIDOPRINOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA["NAZIVSKUPPOREZAIDOPRINOSA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVSKUPPOREZAIDOPRINOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA["NAZIVSKUPPOREZAIDOPRINOSA"]);
            }
            this._Gxremove = this.rowSKUPPOREZAIDOPRINOSA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowSKUPPOREZAIDOPRINOSA = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow) DataSetUtil.CloneOriginalDataRow(this.rowSKUPPOREZAIDOPRINOSA);
            }
        }

        private void ReadRowSkupporezaidoprinosa1()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSKUPPOREZAIDOPRINOSA1.RowState);
            if (this.rowSKUPPOREZAIDOPRINOSA1.RowState == DataRowState.Added)
            {
            }
            this._Gxremove15 = this.rowSKUPPOREZAIDOPRINOSA1.RowState == DataRowState.Deleted;
            if (this._Gxremove15)
            {
                this.rowSKUPPOREZAIDOPRINOSA1 = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row) DataSetUtil.CloneOriginalDataRow(this.rowSKUPPOREZAIDOPRINOSA1);
            }
        }

        private void ReadRowSkupporezaidoprinosa2()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSKUPPOREZAIDOPRINOSA2.RowState);
            if (this.rowSKUPPOREZAIDOPRINOSA2.RowState == DataRowState.Added)
            {
            }
            this._Gxremove28 = this.rowSKUPPOREZAIDOPRINOSA2.RowState == DataRowState.Deleted;
            if (this._Gxremove28)
            {
                this.rowSKUPPOREZAIDOPRINOSA2 = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row) DataSetUtil.CloneOriginalDataRow(this.rowSKUPPOREZAIDOPRINOSA2);
            }
        }

        private void ScanByIDSKUPPOREZAIDOPRINOSA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDSKUPPOREZAIDOPRINOSA] = @IDSKUPPOREZAIDOPRINOSA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString31 + "  FROM [SKUPPOREZAIDOPRINOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSKUPPOREZAIDOPRINOSA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString31, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSKUPPOREZAIDOPRINOSA] ) AS DK_PAGENUM   FROM [SKUPPOREZAIDOPRINOSA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString31 + " FROM [SKUPPOREZAIDOPRINOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSKUPPOREZAIDOPRINOSA] ";
            }
            this.cmSKUPPOREZAIDOPRINOSASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmSKUPPOREZAIDOPRINOSASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmSKUPPOREZAIDOPRINOSASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSKUPPOREZAIDOPRINOSA", DbType.Int32));
            }
            this.cmSKUPPOREZAIDOPRINOSASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA["IDSKUPPOREZAIDOPRINOSA"]));
            this.SKUPPOREZAIDOPRINOSASelect4 = this.cmSKUPPOREZAIDOPRINOSASelect4.FetchData();
            this.RcdFound31 = 0;
            this.ScanLoadSkupporezaidoprinosa();
            this.LoadDataSkupporezaidoprinosa(maxRows);
            if (this.RcdFound31 > 0)
            {
                this.SubLvlScanStartSkupporezaidoprinosa1(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSKUPPOREZAIDOPRINOSASkupporezaidoprinosa(this.cmSKUPPOREZAIDOPRINOSA1Select2);
                this.SubLvlFetchSkupporezaidoprinosa1();
                this.SubLoadDataSkupporezaidoprinosa1();
                this.SubLvlScanStartSkupporezaidoprinosa2(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSKUPPOREZAIDOPRINOSASkupporezaidoprinosa(this.cmSKUPPOREZAIDOPRINOSA2Select2);
                this.SubLvlFetchSkupporezaidoprinosa2();
                this.SubLoadDataSkupporezaidoprinosa2();
            }
        }

        private void ScanEndSkupporezaidoprinosa()
        {
            this.SKUPPOREZAIDOPRINOSASelect4.Close();
        }

        private void ScanEndSkupporezaidoprinosa1()
        {
            this.SKUPPOREZAIDOPRINOSA1Select2.Close();
        }

        private void ScanEndSkupporezaidoprinosa2()
        {
            this.SKUPPOREZAIDOPRINOSA2Select2.Close();
        }

        private void ScanLoadSkupporezaidoprinosa()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSKUPPOREZAIDOPRINOSASelect4.HasMoreRows)
            {
                this.RcdFound31 = 1;
                this.rowSKUPPOREZAIDOPRINOSA["IDSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SKUPPOREZAIDOPRINOSASelect4, 0));
                this.rowSKUPPOREZAIDOPRINOSA["NAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSASelect4, 1));
            }
        }

        private void ScanLoadSkupporezaidoprinosa1()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSKUPPOREZAIDOPRINOSA1Select2.HasMoreRows)
            {
                this.RcdFound32 = 1;
                this.rowSKUPPOREZAIDOPRINOSA1["IDSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SKUPPOREZAIDOPRINOSA1Select2, 0));
                this.rowSKUPPOREZAIDOPRINOSA1["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA1Select2, 1));
                this.rowSKUPPOREZAIDOPRINOSA1["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.SKUPPOREZAIDOPRINOSA1Select2, 2));
                this.rowSKUPPOREZAIDOPRINOSA1["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.SKUPPOREZAIDOPRINOSA1Select2, 3));
                this.rowSKUPPOREZAIDOPRINOSA1["MOPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA1Select2, 4));
                this.rowSKUPPOREZAIDOPRINOSA1["POPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA1Select2, 5));
                this.rowSKUPPOREZAIDOPRINOSA1["MZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA1Select2, 6));
                this.rowSKUPPOREZAIDOPRINOSA1["PZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA1Select2, 7));
                this.rowSKUPPOREZAIDOPRINOSA1["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA1Select2, 8));
                this.rowSKUPPOREZAIDOPRINOSA1["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA1Select2, 9));
                this.rowSKUPPOREZAIDOPRINOSA1["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA1Select2, 10));
                this.rowSKUPPOREZAIDOPRINOSA1["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA1Select2, 11));
                this.rowSKUPPOREZAIDOPRINOSA1["IDPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SKUPPOREZAIDOPRINOSA1Select2, 12));
                this.rowSKUPPOREZAIDOPRINOSA1["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA1Select2, 1));
                this.rowSKUPPOREZAIDOPRINOSA1["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.SKUPPOREZAIDOPRINOSA1Select2, 2));
                this.rowSKUPPOREZAIDOPRINOSA1["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.SKUPPOREZAIDOPRINOSA1Select2, 3));
                this.rowSKUPPOREZAIDOPRINOSA1["MOPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA1Select2, 4));
                this.rowSKUPPOREZAIDOPRINOSA1["POPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA1Select2, 5));
                this.rowSKUPPOREZAIDOPRINOSA1["MZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA1Select2, 6));
                this.rowSKUPPOREZAIDOPRINOSA1["PZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA1Select2, 7));
                this.rowSKUPPOREZAIDOPRINOSA1["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA1Select2, 8));
                this.rowSKUPPOREZAIDOPRINOSA1["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA1Select2, 9));
                this.rowSKUPPOREZAIDOPRINOSA1["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA1Select2, 10));
                this.rowSKUPPOREZAIDOPRINOSA1["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA1Select2, 11));
            }
        }

        private void ScanLoadSkupporezaidoprinosa2()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSKUPPOREZAIDOPRINOSA2Select2.HasMoreRows)
            {
                this.RcdFound33 = 1;
                this.rowSKUPPOREZAIDOPRINOSA2["IDSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SKUPPOREZAIDOPRINOSA2Select2, 0));
                this.rowSKUPPOREZAIDOPRINOSA2["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 1));
                this.rowSKUPPOREZAIDOPRINOSA2["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 2));
                this.rowSKUPPOREZAIDOPRINOSA2["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 3));
                this.rowSKUPPOREZAIDOPRINOSA2["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 4));
                this.rowSKUPPOREZAIDOPRINOSA2["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 5));
                this.rowSKUPPOREZAIDOPRINOSA2["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 6));
                this.rowSKUPPOREZAIDOPRINOSA2["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 7));
                this.rowSKUPPOREZAIDOPRINOSA2["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 8));
                this.rowSKUPPOREZAIDOPRINOSA2["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 9));
                this.rowSKUPPOREZAIDOPRINOSA2["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 10));
                this.rowSKUPPOREZAIDOPRINOSA2["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 11));
                this.rowSKUPPOREZAIDOPRINOSA2["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 12));
                this.rowSKUPPOREZAIDOPRINOSA2["MINDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.SKUPPOREZAIDOPRINOSA2Select2, 13));
                this.rowSKUPPOREZAIDOPRINOSA2["MAXDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.SKUPPOREZAIDOPRINOSA2Select2, 14));
                this.rowSKUPPOREZAIDOPRINOSA2["STOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.SKUPPOREZAIDOPRINOSA2Select2, 15));
                this.rowSKUPPOREZAIDOPRINOSA2["IDDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SKUPPOREZAIDOPRINOSA2Select2, 0x10));
                this.rowSKUPPOREZAIDOPRINOSA2["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SKUPPOREZAIDOPRINOSA2Select2, 0x11));
                this.rowSKUPPOREZAIDOPRINOSA2["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 1));
                this.rowSKUPPOREZAIDOPRINOSA2["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 3));
                this.rowSKUPPOREZAIDOPRINOSA2["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 4));
                this.rowSKUPPOREZAIDOPRINOSA2["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 5));
                this.rowSKUPPOREZAIDOPRINOSA2["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 6));
                this.rowSKUPPOREZAIDOPRINOSA2["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 7));
                this.rowSKUPPOREZAIDOPRINOSA2["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 8));
                this.rowSKUPPOREZAIDOPRINOSA2["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 9));
                this.rowSKUPPOREZAIDOPRINOSA2["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 10));
                this.rowSKUPPOREZAIDOPRINOSA2["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 11));
                this.rowSKUPPOREZAIDOPRINOSA2["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 12));
                this.rowSKUPPOREZAIDOPRINOSA2["MINDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.SKUPPOREZAIDOPRINOSA2Select2, 13));
                this.rowSKUPPOREZAIDOPRINOSA2["MAXDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.SKUPPOREZAIDOPRINOSA2Select2, 14));
                this.rowSKUPPOREZAIDOPRINOSA2["STOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.SKUPPOREZAIDOPRINOSA2Select2, 15));
                this.rowSKUPPOREZAIDOPRINOSA2["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SKUPPOREZAIDOPRINOSA2Select2, 0x11));
                this.rowSKUPPOREZAIDOPRINOSA2["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SKUPPOREZAIDOPRINOSA2Select2, 2));
            }
        }

        private void ScanNextSkupporezaidoprinosa()
        {
            this.cmSKUPPOREZAIDOPRINOSASelect4.HasMoreRows = this.SKUPPOREZAIDOPRINOSASelect4.Read();
            this.RcdFound31 = 0;
            this.ScanLoadSkupporezaidoprinosa();
        }

        private void ScanNextSkupporezaidoprinosa1()
        {
            this.cmSKUPPOREZAIDOPRINOSA1Select2.HasMoreRows = this.SKUPPOREZAIDOPRINOSA1Select2.Read();
            this.RcdFound32 = 0;
            this.ScanLoadSkupporezaidoprinosa1();
        }

        private void ScanNextSkupporezaidoprinosa2()
        {
            this.cmSKUPPOREZAIDOPRINOSA2Select2.HasMoreRows = this.SKUPPOREZAIDOPRINOSA2Select2.Read();
            this.RcdFound33 = 0;
            this.ScanLoadSkupporezaidoprinosa2();
        }

        private void ScanStartSkupporezaidoprinosa(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString31 + "  FROM [SKUPPOREZAIDOPRINOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSKUPPOREZAIDOPRINOSA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString31, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSKUPPOREZAIDOPRINOSA] ) AS DK_PAGENUM   FROM [SKUPPOREZAIDOPRINOSA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString31 + " FROM [SKUPPOREZAIDOPRINOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSKUPPOREZAIDOPRINOSA] ";
            }
            this.cmSKUPPOREZAIDOPRINOSASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.SKUPPOREZAIDOPRINOSASelect4 = this.cmSKUPPOREZAIDOPRINOSASelect4.FetchData();
            this.RcdFound31 = 0;
            this.ScanLoadSkupporezaidoprinosa();
            this.LoadDataSkupporezaidoprinosa(maxRows);
            if (this.RcdFound31 > 0)
            {
                this.SubLvlScanStartSkupporezaidoprinosa1(this.m_WhereString, startRow, maxRows);
                this.SetParametersSkupporezaidoprinosaSkupporezaidoprinosa(this.cmSKUPPOREZAIDOPRINOSA1Select2);
                this.SubLvlFetchSkupporezaidoprinosa1();
                this.SubLoadDataSkupporezaidoprinosa1();
                this.SubLvlScanStartSkupporezaidoprinosa2(this.m_WhereString, startRow, maxRows);
                this.SetParametersSkupporezaidoprinosaSkupporezaidoprinosa(this.cmSKUPPOREZAIDOPRINOSA2Select2);
                this.SubLvlFetchSkupporezaidoprinosa2();
                this.SubLoadDataSkupporezaidoprinosa2();
            }
        }

        private void ScanStartSkupporezaidoprinosa1()
        {
            this.cmSKUPPOREZAIDOPRINOSA1Select2 = this.connDefault.GetCommand("SELECT T1.[IDSKUPPOREZAIDOPRINOSA], T2.[NAZIVPOREZ], T2.[POREZMJESECNO], T2.[STOPAPOREZA], T2.[MOPOREZ], T2.[POPOREZ], T2.[MZPOREZ], T2.[PZPOREZ], T2.[PRIMATELJPOREZ1], T2.[PRIMATELJPOREZ2], T2.[SIFRAOPISAPLACANJAPOREZ], T2.[OPISPLACANJAPOREZ], T1.[IDPOREZ] FROM ([SKUPPOREZAIDOPRINOSA1] T1 WITH (NOLOCK) INNER JOIN [POREZ] T2 WITH (NOLOCK) ON T2.[IDPOREZ] = T1.[IDPOREZ]) WHERE T1.[IDSKUPPOREZAIDOPRINOSA] = @IDSKUPPOREZAIDOPRINOSA ORDER BY T1.[IDSKUPPOREZAIDOPRINOSA], T1.[IDPOREZ] ", false);
            if (this.cmSKUPPOREZAIDOPRINOSA1Select2.IDbCommand.Parameters.Count == 0)
            {
                this.cmSKUPPOREZAIDOPRINOSA1Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSKUPPOREZAIDOPRINOSA", DbType.Int32));
            }
            this.cmSKUPPOREZAIDOPRINOSA1Select2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA1["IDSKUPPOREZAIDOPRINOSA"]));
            this.SKUPPOREZAIDOPRINOSA1Select2 = this.cmSKUPPOREZAIDOPRINOSA1Select2.FetchData();
            this.RcdFound32 = 0;
            this.ScanLoadSkupporezaidoprinosa1();
        }

        private void ScanStartSkupporezaidoprinosa2()
        {
            this.cmSKUPPOREZAIDOPRINOSA2Select2 = this.connDefault.GetCommand("SELECT T1.[IDSKUPPOREZAIDOPRINOSA], T2.[NAZIVDOPRINOS], T3.[NAZIVVRSTADOPRINOS], T2.[MODOPRINOS], T2.[PODOPRINOS], T2.[MZDOPRINOS], T2.[PZDOPRINOS], T2.[PRIMATELJDOPRINOS1], T2.[PRIMATELJDOPRINOS2], T2.[SIFRAOPISAPLACANJADOPRINOS], T2.[OPISPLACANJADOPRINOS], T2.[VBDIDOPRINOS], T2.[ZRNDOPRINOS], T2.[MINDOPRINOS], T2.[MAXDOPRINOS], T2.[STOPA], T1.[IDDOPRINOS], T2.[IDVRSTADOPRINOS] FROM (([SKUPPOREZAIDOPRINOSA2] T1 WITH (NOLOCK) INNER JOIN [DOPRINOS] T2 WITH (NOLOCK) ON T2.[IDDOPRINOS] = T1.[IDDOPRINOS]) INNER JOIN [VRSTADOPRINOS] T3 WITH (NOLOCK) ON T3.[IDVRSTADOPRINOS] = T2.[IDVRSTADOPRINOS]) WHERE T1.[IDSKUPPOREZAIDOPRINOSA] = @IDSKUPPOREZAIDOPRINOSA ORDER BY T1.[IDSKUPPOREZAIDOPRINOSA], T1.[IDDOPRINOS] ", false);
            if (this.cmSKUPPOREZAIDOPRINOSA2Select2.IDbCommand.Parameters.Count == 0)
            {
                this.cmSKUPPOREZAIDOPRINOSA2Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSKUPPOREZAIDOPRINOSA", DbType.Int32));
            }
            this.cmSKUPPOREZAIDOPRINOSA2Select2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA2["IDSKUPPOREZAIDOPRINOSA"]));
            this.SKUPPOREZAIDOPRINOSA2Select2 = this.cmSKUPPOREZAIDOPRINOSA2Select2.FetchData();
            this.RcdFound33 = 0;
            this.ScanLoadSkupporezaidoprinosa2();
        }

        private void SetParametersIDSKUPPOREZAIDOPRINOSASkupporezaidoprinosa(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSKUPPOREZAIDOPRINOSA", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA["IDSKUPPOREZAIDOPRINOSA"]));
        }

        private void SetParametersSkupporezaidoprinosaSkupporezaidoprinosa(ReadWriteCommand m_Command)
        {
        }

        private void SkipNextSkupporezaidoprinosa1()
        {
            this.cmSKUPPOREZAIDOPRINOSA1Select2.HasMoreRows = this.SKUPPOREZAIDOPRINOSA1Select2.Read();
            this.RcdFound32 = 0;
            if (this.cmSKUPPOREZAIDOPRINOSA1Select2.HasMoreRows)
            {
                this.RcdFound32 = 1;
            }
        }

        private void SkipNextSkupporezaidoprinosa2()
        {
            this.cmSKUPPOREZAIDOPRINOSA2Select2.HasMoreRows = this.SKUPPOREZAIDOPRINOSA2Select2.Read();
            this.RcdFound33 = 0;
            if (this.cmSKUPPOREZAIDOPRINOSA2Select2.HasMoreRows)
            {
                this.RcdFound33 = 1;
            }
        }

        private void SubLoadDataSkupporezaidoprinosa1()
        {
            while (this.RcdFound32 != 0)
            {
                this.LoadRowSkupporezaidoprinosa1();
                this.CreateNewRowSkupporezaidoprinosa1();
                this.ScanNextSkupporezaidoprinosa1();
            }
            this.ScanEndSkupporezaidoprinosa1();
        }

        private void SubLoadDataSkupporezaidoprinosa2()
        {
            while (this.RcdFound33 != 0)
            {
                this.LoadRowSkupporezaidoprinosa2();
                this.CreateNewRowSkupporezaidoprinosa2();
                this.ScanNextSkupporezaidoprinosa2();
            }
            this.ScanEndSkupporezaidoprinosa2();
        }

        private void SubLvlFetchSkupporezaidoprinosa1()
        {
            this.CreateNewRowSkupporezaidoprinosa1();
            this.SKUPPOREZAIDOPRINOSA1Select2 = this.cmSKUPPOREZAIDOPRINOSA1Select2.FetchData();
            this.RcdFound32 = 0;
            this.ScanLoadSkupporezaidoprinosa1();
        }

        private void SubLvlFetchSkupporezaidoprinosa2()
        {
            this.CreateNewRowSkupporezaidoprinosa2();
            this.SKUPPOREZAIDOPRINOSA2Select2 = this.cmSKUPPOREZAIDOPRINOSA2Select2.FetchData();
            this.RcdFound33 = 0;
            this.ScanLoadSkupporezaidoprinosa2();
        }

        private void SubLvlScanStartSkupporezaidoprinosa1(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString32 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDSKUPPOREZAIDOPRINOSA]  FROM [SKUPPOREZAIDOPRINOSA]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDSKUPPOREZAIDOPRINOSA] )";
                    this.scmdbuf = "SELECT T1.[IDSKUPPOREZAIDOPRINOSA], T3.[NAZIVPOREZ], T3.[POREZMJESECNO], T3.[STOPAPOREZA], T3.[MOPOREZ], T3.[POPOREZ], T3.[MZPOREZ], T3.[PZPOREZ], T3.[PRIMATELJPOREZ1], T3.[PRIMATELJPOREZ2], T3.[SIFRAOPISAPLACANJAPOREZ], T3.[OPISPLACANJAPOREZ], T1.[IDPOREZ] FROM (([SKUPPOREZAIDOPRINOSA1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString32 + "  TMX ON TMX.[IDSKUPPOREZAIDOPRINOSA] = T1.[IDSKUPPOREZAIDOPRINOSA]) INNER JOIN [POREZ] T3 WITH (NOLOCK) ON T3.[IDPOREZ] = T1.[IDPOREZ]) ORDER BY T1.[IDSKUPPOREZAIDOPRINOSA], T1.[IDPOREZ]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDSKUPPOREZAIDOPRINOSA], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSKUPPOREZAIDOPRINOSA]  ) AS DK_PAGENUM   FROM [SKUPPOREZAIDOPRINOSA]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString32 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDSKUPPOREZAIDOPRINOSA], T3.[NAZIVPOREZ], T3.[POREZMJESECNO], T3.[STOPAPOREZA], T3.[MOPOREZ], T3.[POPOREZ], T3.[MZPOREZ], T3.[PZPOREZ], T3.[PRIMATELJPOREZ1], T3.[PRIMATELJPOREZ2], T3.[SIFRAOPISAPLACANJAPOREZ], T3.[OPISPLACANJAPOREZ], T1.[IDPOREZ] FROM (([SKUPPOREZAIDOPRINOSA1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString32 + "  TMX ON TMX.[IDSKUPPOREZAIDOPRINOSA] = T1.[IDSKUPPOREZAIDOPRINOSA]) INNER JOIN [POREZ] T3 WITH (NOLOCK) ON T3.[IDPOREZ] = T1.[IDPOREZ]) ORDER BY T1.[IDSKUPPOREZAIDOPRINOSA], T1.[IDPOREZ]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString32 = "[SKUPPOREZAIDOPRINOSA]";
                this.scmdbuf = "SELECT T1.[IDSKUPPOREZAIDOPRINOSA], T3.[NAZIVPOREZ], T3.[POREZMJESECNO], T3.[STOPAPOREZA], T3.[MOPOREZ], T3.[POPOREZ], T3.[MZPOREZ], T3.[PZPOREZ], T3.[PRIMATELJPOREZ1], T3.[PRIMATELJPOREZ2], T3.[SIFRAOPISAPLACANJAPOREZ], T3.[OPISPLACANJAPOREZ], T1.[IDPOREZ] FROM (([SKUPPOREZAIDOPRINOSA1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString32 + "  TM1 WITH (NOLOCK) ON TM1.[IDSKUPPOREZAIDOPRINOSA] = T1.[IDSKUPPOREZAIDOPRINOSA]) INNER JOIN [POREZ] T3 WITH (NOLOCK) ON T3.[IDPOREZ] = T1.[IDPOREZ])" + this.m_WhereString + " ORDER BY T1.[IDSKUPPOREZAIDOPRINOSA], T1.[IDPOREZ] ";
            }
            this.cmSKUPPOREZAIDOPRINOSA1Select2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartSkupporezaidoprinosa2(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString33 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDSKUPPOREZAIDOPRINOSA]  FROM [SKUPPOREZAIDOPRINOSA]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDSKUPPOREZAIDOPRINOSA] )";
                    this.scmdbuf = "SELECT T1.[IDSKUPPOREZAIDOPRINOSA], T3.[NAZIVDOPRINOS], T4.[NAZIVVRSTADOPRINOS], T3.[MODOPRINOS], T3.[PODOPRINOS], T3.[MZDOPRINOS], T3.[PZDOPRINOS], T3.[PRIMATELJDOPRINOS1], T3.[PRIMATELJDOPRINOS2], T3.[SIFRAOPISAPLACANJADOPRINOS], T3.[OPISPLACANJADOPRINOS], T3.[VBDIDOPRINOS], T3.[ZRNDOPRINOS], T3.[MINDOPRINOS], T3.[MAXDOPRINOS], T3.[STOPA], T1.[IDDOPRINOS], T3.[IDVRSTADOPRINOS] FROM ((([SKUPPOREZAIDOPRINOSA2] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString33 + "  TMX ON TMX.[IDSKUPPOREZAIDOPRINOSA] = T1.[IDSKUPPOREZAIDOPRINOSA]) INNER JOIN [DOPRINOS] T3 WITH (NOLOCK) ON T3.[IDDOPRINOS] = T1.[IDDOPRINOS]) INNER JOIN [VRSTADOPRINOS] T4 WITH (NOLOCK) ON T4.[IDVRSTADOPRINOS] = T3.[IDVRSTADOPRINOS]) ORDER BY T1.[IDSKUPPOREZAIDOPRINOSA], T1.[IDDOPRINOS]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDSKUPPOREZAIDOPRINOSA], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSKUPPOREZAIDOPRINOSA]  ) AS DK_PAGENUM   FROM [SKUPPOREZAIDOPRINOSA]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString33 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDSKUPPOREZAIDOPRINOSA], T3.[NAZIVDOPRINOS], T4.[NAZIVVRSTADOPRINOS], T3.[MODOPRINOS], T3.[PODOPRINOS], T3.[MZDOPRINOS], T3.[PZDOPRINOS], T3.[PRIMATELJDOPRINOS1], T3.[PRIMATELJDOPRINOS2], T3.[SIFRAOPISAPLACANJADOPRINOS], T3.[OPISPLACANJADOPRINOS], T3.[VBDIDOPRINOS], T3.[ZRNDOPRINOS], T3.[MINDOPRINOS], T3.[MAXDOPRINOS], T3.[STOPA], T1.[IDDOPRINOS], T3.[IDVRSTADOPRINOS] FROM ((([SKUPPOREZAIDOPRINOSA2] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString33 + "  TMX ON TMX.[IDSKUPPOREZAIDOPRINOSA] = T1.[IDSKUPPOREZAIDOPRINOSA]) INNER JOIN [DOPRINOS] T3 WITH (NOLOCK) ON T3.[IDDOPRINOS] = T1.[IDDOPRINOS]) INNER JOIN [VRSTADOPRINOS] T4 WITH (NOLOCK) ON T4.[IDVRSTADOPRINOS] = T3.[IDVRSTADOPRINOS]) ORDER BY T1.[IDSKUPPOREZAIDOPRINOSA], T1.[IDDOPRINOS]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString33 = "[SKUPPOREZAIDOPRINOSA]";
                this.scmdbuf = "SELECT T1.[IDSKUPPOREZAIDOPRINOSA], T3.[NAZIVDOPRINOS], T4.[NAZIVVRSTADOPRINOS], T3.[MODOPRINOS], T3.[PODOPRINOS], T3.[MZDOPRINOS], T3.[PZDOPRINOS], T3.[PRIMATELJDOPRINOS1], T3.[PRIMATELJDOPRINOS2], T3.[SIFRAOPISAPLACANJADOPRINOS], T3.[OPISPLACANJADOPRINOS], T3.[VBDIDOPRINOS], T3.[ZRNDOPRINOS], T3.[MINDOPRINOS], T3.[MAXDOPRINOS], T3.[STOPA], T1.[IDDOPRINOS], T3.[IDVRSTADOPRINOS] FROM ((([SKUPPOREZAIDOPRINOSA2] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString33 + "  TM1 WITH (NOLOCK) ON TM1.[IDSKUPPOREZAIDOPRINOSA] = T1.[IDSKUPPOREZAIDOPRINOSA]) INNER JOIN [DOPRINOS] T3 WITH (NOLOCK) ON T3.[IDDOPRINOS] = T1.[IDDOPRINOS]) INNER JOIN [VRSTADOPRINOS] T4 WITH (NOLOCK) ON T4.[IDVRSTADOPRINOS] = T3.[IDVRSTADOPRINOS])" + this.m_WhereString + " ORDER BY T1.[IDSKUPPOREZAIDOPRINOSA], T1.[IDDOPRINOS] ";
            }
            this.cmSKUPPOREZAIDOPRINOSA2Select2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.SKUPPOREZAIDOPRINOSASet = (SKUPPOREZAIDOPRINOSADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.SKUPPOREZAIDOPRINOSASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.SKUPPOREZAIDOPRINOSASet.SKUPPOREZAIDOPRINOSA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow current = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow) enumerator.Current;
                        this.rowSKUPPOREZAIDOPRINOSA = current;
                        if (Helpers.IsRowChanged(this.rowSKUPPOREZAIDOPRINOSA))
                        {
                            this.ReadRowSkupporezaidoprinosa();
                            if (this.rowSKUPPOREZAIDOPRINOSA.RowState == DataRowState.Added)
                            {
                                this.InsertSkupporezaidoprinosa();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateSkupporezaidoprinosa();
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

        private void UpdateSkupporezaidoprinosa()
        {
            this.CheckOptimisticConcurrencySkupporezaidoprinosa();
            this.AfterConfirmSkupporezaidoprinosa();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [SKUPPOREZAIDOPRINOSA] SET [NAZIVSKUPPOREZAIDOPRINOSA]=@NAZIVSKUPPOREZAIDOPRINOSA  WHERE [IDSKUPPOREZAIDOPRINOSA] = @IDSKUPPOREZAIDOPRINOSA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSKUPPOREZAIDOPRINOSA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSKUPPOREZAIDOPRINOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA["NAZIVSKUPPOREZAIDOPRINOSA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSKUPPOREZAIDOPRINOSA["IDSKUPPOREZAIDOPRINOSA"]));
            command.ExecuteStmt();
            this.OnSKUPPOREZAIDOPRINOSAUpdated(new SKUPPOREZAIDOPRINOSAEventArgs(this.rowSKUPPOREZAIDOPRINOSA, StatementType.Update));
            this.ProcessLevelSkupporezaidoprinosa();
        }

        private void UpdateSkupporezaidoprinosa1()
        {
            this.CheckOptimisticConcurrencySkupporezaidoprinosa1();
            this.CheckExtendedTableSkupporezaidoprinosa1();
            this.AfterConfirmSkupporezaidoprinosa1();
            this.OnSKUPPOREZAIDOPRINOSA1Updated(new SKUPPOREZAIDOPRINOSA1EventArgs(this.rowSKUPPOREZAIDOPRINOSA1, StatementType.Update));
        }

        private void UpdateSkupporezaidoprinosa2()
        {
            this.CheckOptimisticConcurrencySkupporezaidoprinosa2();
            this.CheckExtendedTableSkupporezaidoprinosa2();
            this.AfterConfirmSkupporezaidoprinosa2();
            this.OnSKUPPOREZAIDOPRINOSA2Updated(new SKUPPOREZAIDOPRINOSA2EventArgs(this.rowSKUPPOREZAIDOPRINOSA2, StatementType.Update));
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
        public class RADNIKInvalidDeleteException : InvalidDeleteException
        {
            public RADNIKInvalidDeleteException()
            {
            }

            public RADNIKInvalidDeleteException(string message) : base(message)
            {
            }

            protected RADNIKInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SKUPPOREZAIDOPRINOSA1DataChangedException : DataChangedException
        {
            public SKUPPOREZAIDOPRINOSA1DataChangedException()
            {
            }

            public SKUPPOREZAIDOPRINOSA1DataChangedException(string message) : base(message)
            {
            }

            protected SKUPPOREZAIDOPRINOSA1DataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SKUPPOREZAIDOPRINOSA1DataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SKUPPOREZAIDOPRINOSA1DataLockedException : DataLockedException
        {
            public SKUPPOREZAIDOPRINOSA1DataLockedException()
            {
            }

            public SKUPPOREZAIDOPRINOSA1DataLockedException(string message) : base(message)
            {
            }

            protected SKUPPOREZAIDOPRINOSA1DataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SKUPPOREZAIDOPRINOSA1DataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SKUPPOREZAIDOPRINOSA1DuplicateKeyException : DuplicateKeyException
        {
            public SKUPPOREZAIDOPRINOSA1DuplicateKeyException()
            {
            }

            public SKUPPOREZAIDOPRINOSA1DuplicateKeyException(string message) : base(message)
            {
            }

            protected SKUPPOREZAIDOPRINOSA1DuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SKUPPOREZAIDOPRINOSA1DuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class SKUPPOREZAIDOPRINOSA1EventArgs : EventArgs
        {
            private SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row m_dataRow;
            private System.Data.StatementType m_statementType;

            public SKUPPOREZAIDOPRINOSA1EventArgs(SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row Row
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

        public delegate void SKUPPOREZAIDOPRINOSA1UpdateEventHandler(object sender, SKUPPOREZAIDOPRINOSADataAdapter.SKUPPOREZAIDOPRINOSA1EventArgs e);

        [Serializable]
        public class SKUPPOREZAIDOPRINOSA2DataChangedException : DataChangedException
        {
            public SKUPPOREZAIDOPRINOSA2DataChangedException()
            {
            }

            public SKUPPOREZAIDOPRINOSA2DataChangedException(string message) : base(message)
            {
            }

            protected SKUPPOREZAIDOPRINOSA2DataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SKUPPOREZAIDOPRINOSA2DataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SKUPPOREZAIDOPRINOSA2DataLockedException : DataLockedException
        {
            public SKUPPOREZAIDOPRINOSA2DataLockedException()
            {
            }

            public SKUPPOREZAIDOPRINOSA2DataLockedException(string message) : base(message)
            {
            }

            protected SKUPPOREZAIDOPRINOSA2DataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SKUPPOREZAIDOPRINOSA2DataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SKUPPOREZAIDOPRINOSA2DuplicateKeyException : DuplicateKeyException
        {
            public SKUPPOREZAIDOPRINOSA2DuplicateKeyException()
            {
            }

            public SKUPPOREZAIDOPRINOSA2DuplicateKeyException(string message) : base(message)
            {
            }

            protected SKUPPOREZAIDOPRINOSA2DuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SKUPPOREZAIDOPRINOSA2DuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class SKUPPOREZAIDOPRINOSA2EventArgs : EventArgs
        {
            private SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row m_dataRow;
            private System.Data.StatementType m_statementType;

            public SKUPPOREZAIDOPRINOSA2EventArgs(SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA2Row Row
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

        public delegate void SKUPPOREZAIDOPRINOSA2UpdateEventHandler(object sender, SKUPPOREZAIDOPRINOSADataAdapter.SKUPPOREZAIDOPRINOSA2EventArgs e);

        [Serializable]
        public class SKUPPOREZAIDOPRINOSADataChangedException : DataChangedException
        {
            public SKUPPOREZAIDOPRINOSADataChangedException()
            {
            }

            public SKUPPOREZAIDOPRINOSADataChangedException(string message) : base(message)
            {
            }

            protected SKUPPOREZAIDOPRINOSADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SKUPPOREZAIDOPRINOSADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SKUPPOREZAIDOPRINOSADataLockedException : DataLockedException
        {
            public SKUPPOREZAIDOPRINOSADataLockedException()
            {
            }

            public SKUPPOREZAIDOPRINOSADataLockedException(string message) : base(message)
            {
            }

            protected SKUPPOREZAIDOPRINOSADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SKUPPOREZAIDOPRINOSADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SKUPPOREZAIDOPRINOSADuplicateKeyException : DuplicateKeyException
        {
            public SKUPPOREZAIDOPRINOSADuplicateKeyException()
            {
            }

            public SKUPPOREZAIDOPRINOSADuplicateKeyException(string message) : base(message)
            {
            }

            protected SKUPPOREZAIDOPRINOSADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SKUPPOREZAIDOPRINOSADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class SKUPPOREZAIDOPRINOSAEventArgs : EventArgs
        {
            private SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public SKUPPOREZAIDOPRINOSAEventArgs(SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow Row
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
        public class SKUPPOREZAIDOPRINOSANotFoundException : DataNotFoundException
        {
            public SKUPPOREZAIDOPRINOSANotFoundException()
            {
            }

            public SKUPPOREZAIDOPRINOSANotFoundException(string message) : base(message)
            {
            }

            protected SKUPPOREZAIDOPRINOSANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SKUPPOREZAIDOPRINOSANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void SKUPPOREZAIDOPRINOSAUpdateEventHandler(object sender, SKUPPOREZAIDOPRINOSADataAdapter.SKUPPOREZAIDOPRINOSAEventArgs e);

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

