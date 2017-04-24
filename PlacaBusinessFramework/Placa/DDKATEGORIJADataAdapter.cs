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

    public class DDKATEGORIJADataAdapter : IDataAdapter, IDDKATEGORIJADataAdapter
    {
        private bool _Gxremove;
        private bool _Gxremove19;
        private bool _Gxremove32;
        private bool _Gxremove49;
        private ReadWriteCommand cmDDKATEGORIJAIzdaciSelect2;
        private ReadWriteCommand cmDDKATEGORIJALevel1Select2;
        private ReadWriteCommand cmDDKATEGORIJALevel3Select2;
        private ReadWriteCommand cmDDKATEGORIJASelect1;
        private ReadWriteCommand cmDDKATEGORIJASelect2;
        private ReadWriteCommand cmDDKATEGORIJASelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DDKATEGORIJAIzdaciSelect2;
        private IDataReader DDKATEGORIJALevel1Select2;
        private IDataReader DDKATEGORIJALevel3Select2;
        private IDataReader DDKATEGORIJASelect1;
        private IDataReader DDKATEGORIJASelect2;
        private IDataReader DDKATEGORIJASelect5;
        private DDKATEGORIJADataSet DDKATEGORIJASet;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__DDMOPOREZOriginal;
        private object m__DDPOPOREZOriginal;
        private object m__DOPRINOSDRUGOGSTUPAOriginal;
        private object m__IDKOLONAIDDOriginal;
        private object m__NAZIVKATEGORIJAOriginal;
        private readonly string m_SelectString138 = "TM1.[IDKATEGORIJA], TM1.[NAZIVKATEGORIJA], T2.[NAZIVKOLONAIDD], TM1.[IDKOLONAIDD]";
        private string m_SubSelTopString139;
        private string m_SubSelTopString140;
        private string m_SubSelTopString165;
        private string m_WhereString;
        private short RcdFound138;
        private short RcdFound139;
        private short RcdFound140;
        private short RcdFound165;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private DDKATEGORIJADataSet.DDKATEGORIJARow rowDDKATEGORIJA;
        private DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow rowDDKATEGORIJAIzdaci;
        private DDKATEGORIJADataSet.DDKATEGORIJALevel1Row rowDDKATEGORIJALevel1;
        private DDKATEGORIJADataSet.DDKATEGORIJALevel3Row rowDDKATEGORIJALevel3;
        private string scmdbuf;
        private StatementType sMode138;
        private StatementType sMode139;
        private StatementType sMode140;
        private StatementType sMode165;

        public event DDKATEGORIJAIzdaciUpdateEventHandler DDKATEGORIJAIzdaciUpdated;

        public event DDKATEGORIJAIzdaciUpdateEventHandler DDKATEGORIJAIzdaciUpdating;

        public event DDKATEGORIJALevel1UpdateEventHandler DDKATEGORIJALevel1Updated;

        public event DDKATEGORIJALevel1UpdateEventHandler DDKATEGORIJALevel1Updating;

        public event DDKATEGORIJALevel3UpdateEventHandler DDKATEGORIJALevel3Updated;

        public event DDKATEGORIJALevel3UpdateEventHandler DDKATEGORIJALevel3Updating;

        public event DDKATEGORIJAUpdateEventHandler DDKATEGORIJAUpdated;

        public event DDKATEGORIJAUpdateEventHandler DDKATEGORIJAUpdating;

        private void AddRowDdkategorija()
        {
            this.DDKATEGORIJASet.DDKATEGORIJA.AddDDKATEGORIJARow(this.rowDDKATEGORIJA);
        }

        private void AddRowDdkategorijaizdaci()
        {
            this.DDKATEGORIJASet.DDKATEGORIJAIzdaci.AddDDKATEGORIJAIzdaciRow(this.rowDDKATEGORIJAIzdaci);
        }

        private void AddRowDdkategorijalevel1()
        {
            this.DDKATEGORIJASet.DDKATEGORIJALevel1.AddDDKATEGORIJALevel1Row(this.rowDDKATEGORIJALevel1);
        }

        private void AddRowDdkategorijalevel3()
        {
            this.DDKATEGORIJASet.DDKATEGORIJALevel3.AddDDKATEGORIJALevel3Row(this.rowDDKATEGORIJALevel3);
        }

        private void AfterConfirmDdkategorija()
        {
            this.OnDDKATEGORIJAUpdating(new DDKATEGORIJAEventArgs(this.rowDDKATEGORIJA, this.Gx_mode));
        }

        private void AfterConfirmDdkategorijaizdaci()
        {
            this.OnDDKATEGORIJAIzdaciUpdating(new DDKATEGORIJAIzdaciEventArgs(this.rowDDKATEGORIJAIzdaci, this.Gx_mode));
        }

        private void AfterConfirmDdkategorijalevel1()
        {
            this.OnDDKATEGORIJALevel1Updating(new DDKATEGORIJALevel1EventArgs(this.rowDDKATEGORIJALevel1, this.Gx_mode));
        }

        private void AfterConfirmDdkategorijalevel3()
        {
            this.OnDDKATEGORIJALevel3Updating(new DDKATEGORIJALevel3EventArgs(this.rowDDKATEGORIJALevel3, this.Gx_mode));
        }

        private void CheckDeleteErrorsDdkategorija()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [DDOBRACUNIDOBRACUN], [DDIDRADNIK] FROM [DDOBRACUNRadnici] WITH (NOLOCK) WHERE [IDKATEGORIJA] = @IDKATEGORIJA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["IDKATEGORIJA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new DDOBRACUNRadniciInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Radnici" }));
            }
            reader.Close();
        }

        private void CheckExtendedTableDdkategorija()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVKOLONAIDD] FROM [DDKOLONAIDD] WITH (NOLOCK) WHERE [IDKOLONAIDD] = @IDKOLONAIDD ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["IDKOLONAIDD"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new DDKOLONAIDDForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DDKOLONAIDD") }));
            }
            this.rowDDKATEGORIJA["NAZIVKOLONAIDD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            reader.Close();
        }

        private void CheckExtendedTableDdkategorijaizdaci()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDNAZIVIZDATKA], [DDPOSTOTAKIZDATKA] FROM [DDIZDATAK] WITH (NOLOCK) WHERE [DDIDIZDATAK] = @DDIDIZDATAK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJAIzdaci["DDIDIZDATAK"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new DDIZDATAKForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DDIZDATAK") }));
            }
            this.rowDDKATEGORIJAIzdaci["DDNAZIVIZDATKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowDDKATEGORIJAIzdaci["DDPOSTOTAKIZDATKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            reader.Close();
        }

        private void CheckExtendedTableDdkategorijalevel1()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVPOREZ], [POREZMJESECNO], [STOPAPOREZA], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ] FROM [POREZ] WITH (NOLOCK) WHERE [IDPOREZ] = @IDPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["IDPOREZ"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new POREZForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("POREZ") }));
            }
            this.rowDDKATEGORIJALevel1["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowDDKATEGORIJALevel1["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            this.rowDDKATEGORIJALevel1["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
            this.rowDDKATEGORIJALevel1["MZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
            this.rowDDKATEGORIJALevel1["PZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
            this.rowDDKATEGORIJALevel1["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
            this.rowDDKATEGORIJALevel1["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
            this.rowDDKATEGORIJALevel1["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
            this.rowDDKATEGORIJALevel1["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
            reader.Close();
        }

        private void CheckExtendedTableDdkategorijalevel3()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVDOPRINOS], [MODOPRINOS], [PODOPRINOS], [MZDOPRINOS], [PZDOPRINOS], [PRIMATELJDOPRINOS1], [PRIMATELJDOPRINOS2], [SIFRAOPISAPLACANJADOPRINOS], [OPISPLACANJADOPRINOS], [VBDIDOPRINOS], [ZRNDOPRINOS], [STOPA], [IDVRSTADOPRINOS] FROM [DOPRINOS] WITH (NOLOCK) WHERE [IDDOPRINOS] = @IDDOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel3["IDDOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new DOPRINOSForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DOPRINOS") }));
            }
            this.rowDDKATEGORIJALevel3["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowDDKATEGORIJALevel3["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
            this.rowDDKATEGORIJALevel3["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
            this.rowDDKATEGORIJALevel3["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
            this.rowDDKATEGORIJALevel3["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
            this.rowDDKATEGORIJALevel3["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
            this.rowDDKATEGORIJALevel3["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
            this.rowDDKATEGORIJALevel3["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
            this.rowDDKATEGORIJALevel3["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
            this.rowDDKATEGORIJALevel3["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
            this.rowDDKATEGORIJALevel3["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
            this.rowDDKATEGORIJALevel3["STOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 11));
            this.rowDDKATEGORIJALevel3["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 12));
            reader.Close();
            if (!this.rowDDKATEGORIJALevel3.IsIDVRSTADOPRINOSNull())
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVVRSTADOPRINOS] FROM [VRSTADOPRINOS] WITH (NOLOCK) WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
                }
                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel3["IDVRSTADOPRINOS"]));
                IDataReader reader2 = command2.FetchData();
                if (!command2.HasMoreRows)
                {
                    reader2.Close();
                    throw new VRSTADOPRINOSForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("VRSTADOPRINOS") }));
                }
                this.rowDDKATEGORIJALevel3["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                reader2.Close();
            }
            else
            {
                this.rowDDKATEGORIJALevel3["NAZIVVRSTADOPRINOS"] = "";
            }
        }

        private void CheckOptimisticConcurrencyDdkategorija()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKATEGORIJA], [NAZIVKATEGORIJA], [IDKOLONAIDD] FROM [DDKATEGORIJA] WITH (UPDLOCK) WHERE [IDKATEGORIJA] = @IDKATEGORIJA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["IDKATEGORIJA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DDKATEGORIJADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DDKATEGORIJA") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVKATEGORIJAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || !this.m__IDKOLONAIDDOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2))))
                {
                    reader.Close();
                    throw new DDKATEGORIJADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DDKATEGORIJA") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyDdkategorijaizdaci()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKATEGORIJA], [DDIDIZDATAK] FROM [DDKATEGORIJAIzdaci] WITH (UPDLOCK) WHERE [IDKATEGORIJA] = @IDKATEGORIJA AND [DDIDIZDATAK] = @DDIDIZDATAK ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJAIzdaci["IDKATEGORIJA"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJAIzdaci["DDIDIZDATAK"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DDKATEGORIJAIzdaciDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DDKATEGORIJAIzdaci") }));
                }
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new DDKATEGORIJAIzdaciDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DDKATEGORIJAIzdaci") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyDdkategorijalevel1()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKATEGORIJA], [DDMOPOREZ], [DDPOPOREZ], [IDPOREZ] FROM [DDKATEGORIJALevel1] WITH (UPDLOCK) WHERE [IDKATEGORIJA] = @IDKATEGORIJA AND [IDPOREZ] = @IDPOREZ ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["IDKATEGORIJA"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["IDPOREZ"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DDKATEGORIJALevel1DataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DDKATEGORIJALevel1") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDMOPOREZOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDPOPOREZOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))))
                {
                    reader.Close();
                    throw new DDKATEGORIJALevel1DataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DDKATEGORIJALevel1") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyDdkategorijalevel3()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKATEGORIJA], [DOPRINOSDRUGOGSTUPA], [IDDOPRINOS] FROM [DDKATEGORIJALevel3] WITH (UPDLOCK) WHERE [IDKATEGORIJA] = @IDKATEGORIJA AND [IDDOPRINOS] = @IDDOPRINOS ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel3["IDKATEGORIJA"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel3["IDDOPRINOS"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DDKATEGORIJALevel3DataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DDKATEGORIJALevel3") }));
                }
                if (!command.HasMoreRows || !this.m__DOPRINOSDRUGOGSTUPAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 1))))
                {
                    reader.Close();
                    throw new DDKATEGORIJALevel3DataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DDKATEGORIJALevel3") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowDdkategorija()
        {
            this.rowDDKATEGORIJA = this.DDKATEGORIJASet.DDKATEGORIJA.NewDDKATEGORIJARow();
        }

        private void CreateNewRowDdkategorijaizdaci()
        {
            this.rowDDKATEGORIJAIzdaci = this.DDKATEGORIJASet.DDKATEGORIJAIzdaci.NewDDKATEGORIJAIzdaciRow();
        }

        private void CreateNewRowDdkategorijalevel1()
        {
            this.rowDDKATEGORIJALevel1 = this.DDKATEGORIJASet.DDKATEGORIJALevel1.NewDDKATEGORIJALevel1Row();
        }

        private void CreateNewRowDdkategorijalevel3()
        {
            this.rowDDKATEGORIJALevel3 = this.DDKATEGORIJASet.DDKATEGORIJALevel3.NewDDKATEGORIJALevel3Row();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDdkategorija();
            this.OnDeleteControlsDdkategorija();
            this.ProcessNestedLevelDdkategorijaizdaci();
            this.ProcessNestedLevelDdkategorijalevel3();
            this.ProcessNestedLevelDdkategorijalevel1();
            this.AfterConfirmDdkategorija();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DDKATEGORIJA]  WHERE [IDKATEGORIJA] = @IDKATEGORIJA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["IDKATEGORIJA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsDdkategorija();
            }
            this.OnDDKATEGORIJAUpdated(new DDKATEGORIJAEventArgs(this.rowDDKATEGORIJA, StatementType.Delete));
            this.rowDDKATEGORIJA.Delete();
            this.sMode138 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode138;
        }

        private void DeleteDdkategorijaizdaci()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDdkategorijaizdaci();
            this.OnDeleteControlsDdkategorijaizdaci();
            this.AfterConfirmDdkategorijaizdaci();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DDKATEGORIJAIzdaci]  WHERE [IDKATEGORIJA] = @IDKATEGORIJA AND [DDIDIZDATAK] = @DDIDIZDATAK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJAIzdaci["IDKATEGORIJA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJAIzdaci["DDIDIZDATAK"]));
            command.ExecuteStmt();
            this.OnDDKATEGORIJAIzdaciUpdated(new DDKATEGORIJAIzdaciEventArgs(this.rowDDKATEGORIJAIzdaci, StatementType.Delete));
            this.rowDDKATEGORIJAIzdaci.Delete();
            this.sMode165 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode165;
        }

        private void DeleteDdkategorijalevel1()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDdkategorijalevel1();
            this.OnDeleteControlsDdkategorijalevel1();
            this.AfterConfirmDdkategorijalevel1();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DDKATEGORIJALevel1]  WHERE [IDKATEGORIJA] = @IDKATEGORIJA AND [IDPOREZ] = @IDPOREZ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["IDKATEGORIJA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["IDPOREZ"]));
            command.ExecuteStmt();
            this.OnDDKATEGORIJALevel1Updated(new DDKATEGORIJALevel1EventArgs(this.rowDDKATEGORIJALevel1, StatementType.Delete));
            this.rowDDKATEGORIJALevel1.Delete();
            this.sMode139 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode139;
        }

        private void DeleteDdkategorijalevel3()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDdkategorijalevel3();
            this.OnDeleteControlsDdkategorijalevel3();
            this.AfterConfirmDdkategorijalevel3();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DDKATEGORIJALevel3]  WHERE [IDKATEGORIJA] = @IDKATEGORIJA AND [IDDOPRINOS] = @IDDOPRINOS", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel3["IDKATEGORIJA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel3["IDDOPRINOS"]));
            command.ExecuteStmt();
            this.OnDDKATEGORIJALevel3Updated(new DDKATEGORIJALevel3EventArgs(this.rowDDKATEGORIJALevel3, StatementType.Delete));
            this.rowDDKATEGORIJALevel3.Delete();
            this.sMode140 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode140;
        }


        public virtual int Fill(DDKATEGORIJADataSet dataSet)
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
                    this.DDKATEGORIJASet = dataSet;
                    this.LoadChildDdkategorija(0, -1);
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
            this.DDKATEGORIJASet = (DDKATEGORIJADataSet) dataSet;
            if (this.DDKATEGORIJASet != null)
            {
                return this.Fill(this.DDKATEGORIJASet);
            }
            this.DDKATEGORIJASet = new DDKATEGORIJADataSet();
            this.Fill(this.DDKATEGORIJASet);
            dataSet.Merge(this.DDKATEGORIJASet);
            return 0;
        }

        public virtual int Fill(DDKATEGORIJADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDKATEGORIJA"]));
        }

        public virtual int Fill(DDKATEGORIJADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDKATEGORIJA"]));
        }

        public virtual int Fill(DDKATEGORIJADataSet dataSet, int iDKATEGORIJA)
        {
            if (!this.FillByIDKATEGORIJA(dataSet, iDKATEGORIJA))
            {
                throw new DDKATEGORIJANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DDKATEGORIJA") }));
            }
            return 0;
        }

        public virtual bool FillByIDKATEGORIJA(DDKATEGORIJADataSet dataSet, int iDKATEGORIJA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDKATEGORIJASet = dataSet;
            this.rowDDKATEGORIJA = this.DDKATEGORIJASet.DDKATEGORIJA.NewDDKATEGORIJARow();
            this.rowDDKATEGORIJA.IDKATEGORIJA = iDKATEGORIJA;
            try
            {
                this.LoadByIDKATEGORIJA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound138 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByIDKOLONAIDD(DDKATEGORIJADataSet dataSet, int iDKOLONAIDD)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDKATEGORIJASet = dataSet;
            this.rowDDKATEGORIJA = this.DDKATEGORIJASet.DDKATEGORIJA.NewDDKATEGORIJARow();
            this.rowDDKATEGORIJA.IDKOLONAIDD = iDKOLONAIDD;
            try
            {
                this.LoadByIDKOLONAIDD(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(DDKATEGORIJADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDKATEGORIJASet = dataSet;
            try
            {
                this.LoadChildDdkategorija(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDKOLONAIDD(DDKATEGORIJADataSet dataSet, int iDKOLONAIDD, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDKATEGORIJASet = dataSet;
            this.rowDDKATEGORIJA = this.DDKATEGORIJASet.DDKATEGORIJA.NewDDKATEGORIJARow();
            this.rowDDKATEGORIJA.IDKOLONAIDD = iDKOLONAIDD;
            try
            {
                this.LoadByIDKOLONAIDD(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKATEGORIJA], [NAZIVKATEGORIJA], [IDKOLONAIDD] FROM [DDKATEGORIJA] WITH (NOLOCK) WHERE [IDKATEGORIJA] = @IDKATEGORIJA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["IDKATEGORIJA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound138 = 1;
                this.rowDDKATEGORIJA["IDKATEGORIJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowDDKATEGORIJA["NAZIVKATEGORIJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowDDKATEGORIJA["IDKOLONAIDD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2));
                this.sMode138 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadDdkategorija();
                this.Gx_mode = this.sMode138;
            }
            else
            {
                this.RcdFound138 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDKATEGORIJA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDKATEGORIJASelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [DDKATEGORIJA] WITH (NOLOCK) ", false);
            this.DDKATEGORIJASelect2 = this.cmDDKATEGORIJASelect2.FetchData();
            if (this.DDKATEGORIJASelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.DDKATEGORIJASelect2.GetInt32(0);
            }
            this.DDKATEGORIJASelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDKOLONAIDD(int iDKOLONAIDD)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDKATEGORIJASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [DDKATEGORIJA] WITH (NOLOCK) WHERE [IDKOLONAIDD] = @IDKOLONAIDD ", false);
            if (this.cmDDKATEGORIJASelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDKATEGORIJASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
            }
            this.cmDDKATEGORIJASelect1.SetParameter(0, iDKOLONAIDD);
            this.DDKATEGORIJASelect1 = this.cmDDKATEGORIJASelect1.FetchData();
            if (this.DDKATEGORIJASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.DDKATEGORIJASelect1.GetInt32(0);
            }
            this.DDKATEGORIJASelect1.Close();
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

        public virtual int GetRecordCountByIDKOLONAIDD(int iDKOLONAIDD)
        {
            int internalRecordCountByIDKOLONAIDD;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDKOLONAIDD = this.GetInternalRecordCountByIDKOLONAIDD(iDKOLONAIDD);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDKOLONAIDD;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound138 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this._Gxremove49 = false;
            this.RcdFound165 = 0;
            this.m_SubSelTopString165 = "";
            this.m__DOPRINOSDRUGOGSTUPAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove32 = false;
            this.RcdFound140 = 0;
            this.m_SubSelTopString140 = "";
            this.m__DDMOPOREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDPOPOREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove19 = false;
            this.RcdFound139 = 0;
            this.m_SubSelTopString139 = "";
            this.m__NAZIVKATEGORIJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDKOLONAIDDOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.DDKATEGORIJASet = new DDKATEGORIJADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertDdkategorija()
        {
            this.CheckOptimisticConcurrencyDdkategorija();
            this.CheckExtendedTableDdkategorija();
            this.AfterConfirmDdkategorija();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DDKATEGORIJA] ([IDKATEGORIJA], [NAZIVKATEGORIJA], [IDKOLONAIDD]) VALUES (@IDKATEGORIJA, @NAZIVKATEGORIJA, @IDKOLONAIDD)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVKATEGORIJA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["IDKATEGORIJA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["NAZIVKATEGORIJA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["IDKOLONAIDD"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DDKATEGORIJADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDDKATEGORIJAUpdated(new DDKATEGORIJAEventArgs(this.rowDDKATEGORIJA, StatementType.Insert));
            this.ProcessLevelDdkategorija();
        }

        private void InsertDdkategorijaizdaci()
        {
            this.CheckOptimisticConcurrencyDdkategorijaizdaci();
            this.CheckExtendedTableDdkategorijaizdaci();
            this.AfterConfirmDdkategorijaizdaci();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DDKATEGORIJAIzdaci] ([IDKATEGORIJA], [DDIDIZDATAK]) VALUES (@IDKATEGORIJA, @DDIDIZDATAK)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJAIzdaci["IDKATEGORIJA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJAIzdaci["DDIDIZDATAK"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DDKATEGORIJAIzdaciDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDDKATEGORIJAIzdaciUpdated(new DDKATEGORIJAIzdaciEventArgs(this.rowDDKATEGORIJAIzdaci, StatementType.Insert));
        }

        private void InsertDdkategorijalevel1()
        {
            this.CheckOptimisticConcurrencyDdkategorijalevel1();
            this.CheckExtendedTableDdkategorijalevel1();
            this.AfterConfirmDdkategorijalevel1();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DDKATEGORIJALevel1] ([IDKATEGORIJA], [DDMOPOREZ], [DDPOPOREZ], [IDPOREZ]) VALUES (@IDKATEGORIJA, @DDMOPOREZ, @DDPOPOREZ, @IDPOREZ)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDMOPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPOPOREZ", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["IDKATEGORIJA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["DDMOPOREZ"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["DDPOPOREZ"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["IDPOREZ"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DDKATEGORIJALevel1DuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDDKATEGORIJALevel1Updated(new DDKATEGORIJALevel1EventArgs(this.rowDDKATEGORIJALevel1, StatementType.Insert));
        }

        private void InsertDdkategorijalevel3()
        {
            this.CheckOptimisticConcurrencyDdkategorijalevel3();
            this.CheckExtendedTableDdkategorijalevel3();
            this.AfterConfirmDdkategorijalevel3();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DDKATEGORIJALevel3] ([IDKATEGORIJA], [DOPRINOSDRUGOGSTUPA], [IDDOPRINOS]) VALUES (@IDKATEGORIJA, @DOPRINOSDRUGOGSTUPA, @IDDOPRINOS)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOPRINOSDRUGOGSTUPA", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel3["IDKATEGORIJA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel3["DOPRINOSDRUGOGSTUPA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel3["IDDOPRINOS"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DDKATEGORIJALevel3DuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDDKATEGORIJALevel3Updated(new DDKATEGORIJALevel3EventArgs(this.rowDDKATEGORIJALevel3, StatementType.Insert));
        }

        private void LoadByIDKATEGORIJA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.DDKATEGORIJASet.EnforceConstraints;
            this.DDKATEGORIJASet.DDKATEGORIJAIzdaci.BeginLoadData();
            this.DDKATEGORIJASet.DDKATEGORIJALevel3.BeginLoadData();
            this.DDKATEGORIJASet.DDKATEGORIJALevel1.BeginLoadData();
            this.DDKATEGORIJASet.DDKATEGORIJA.BeginLoadData();
            this.ScanByIDKATEGORIJA(startRow, maxRows);
            this.DDKATEGORIJASet.DDKATEGORIJAIzdaci.EndLoadData();
            this.DDKATEGORIJASet.DDKATEGORIJALevel3.EndLoadData();
            this.DDKATEGORIJASet.DDKATEGORIJALevel1.EndLoadData();
            this.DDKATEGORIJASet.DDKATEGORIJA.EndLoadData();
            this.DDKATEGORIJASet.EnforceConstraints = enforceConstraints;
            if (this.DDKATEGORIJASet.DDKATEGORIJA.Count > 0)
            {
                this.rowDDKATEGORIJA = this.DDKATEGORIJASet.DDKATEGORIJA[this.DDKATEGORIJASet.DDKATEGORIJA.Count - 1];
            }
        }

        private void LoadByIDKOLONAIDD(int startRow, int maxRows)
        {
            bool enforceConstraints = this.DDKATEGORIJASet.EnforceConstraints;
            this.DDKATEGORIJASet.DDKATEGORIJAIzdaci.BeginLoadData();
            this.DDKATEGORIJASet.DDKATEGORIJALevel3.BeginLoadData();
            this.DDKATEGORIJASet.DDKATEGORIJALevel1.BeginLoadData();
            this.DDKATEGORIJASet.DDKATEGORIJA.BeginLoadData();
            this.ScanByIDKOLONAIDD(startRow, maxRows);
            this.DDKATEGORIJASet.DDKATEGORIJAIzdaci.EndLoadData();
            this.DDKATEGORIJASet.DDKATEGORIJALevel3.EndLoadData();
            this.DDKATEGORIJASet.DDKATEGORIJALevel1.EndLoadData();
            this.DDKATEGORIJASet.DDKATEGORIJA.EndLoadData();
            this.DDKATEGORIJASet.EnforceConstraints = enforceConstraints;
            if (this.DDKATEGORIJASet.DDKATEGORIJA.Count > 0)
            {
                this.rowDDKATEGORIJA = this.DDKATEGORIJASet.DDKATEGORIJA[this.DDKATEGORIJASet.DDKATEGORIJA.Count - 1];
            }
        }

        private void LoadChildDdkategorija(int startRow, int maxRows)
        {
            this.CreateNewRowDdkategorija();
            bool enforceConstraints = this.DDKATEGORIJASet.EnforceConstraints;
            this.DDKATEGORIJASet.DDKATEGORIJAIzdaci.BeginLoadData();
            this.DDKATEGORIJASet.DDKATEGORIJALevel3.BeginLoadData();
            this.DDKATEGORIJASet.DDKATEGORIJALevel1.BeginLoadData();
            this.DDKATEGORIJASet.DDKATEGORIJA.BeginLoadData();
            this.ScanStartDdkategorija(startRow, maxRows);
            this.DDKATEGORIJASet.DDKATEGORIJAIzdaci.EndLoadData();
            this.DDKATEGORIJASet.DDKATEGORIJALevel3.EndLoadData();
            this.DDKATEGORIJASet.DDKATEGORIJALevel1.EndLoadData();
            this.DDKATEGORIJASet.DDKATEGORIJA.EndLoadData();
            this.DDKATEGORIJASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildDdkategorijaizdaci()
        {
            this.CreateNewRowDdkategorijaizdaci();
            this.ScanStartDdkategorijaizdaci();
        }

        private void LoadChildDdkategorijalevel1()
        {
            this.CreateNewRowDdkategorijalevel1();
            this.ScanStartDdkategorijalevel1();
        }

        private void LoadChildDdkategorijalevel3()
        {
            this.CreateNewRowDdkategorijalevel3();
            this.ScanStartDdkategorijalevel3();
        }

        private void LoadDataDdkategorija(int maxRows)
        {
            int num = 0;
            if (this.RcdFound138 != 0)
            {
                this.ScanLoadDdkategorija();
                while ((this.RcdFound138 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowDdkategorija();
                    this.CreateNewRowDdkategorija();
                    this.ScanNextDdkategorija();
                }
            }
            if (num > 0)
            {
                this.RcdFound138 = 1;
            }
            this.ScanEndDdkategorija();
            if (this.DDKATEGORIJASet.DDKATEGORIJA.Count > 0)
            {
                this.rowDDKATEGORIJA = this.DDKATEGORIJASet.DDKATEGORIJA[this.DDKATEGORIJASet.DDKATEGORIJA.Count - 1];
            }
        }

        private void LoadDataDdkategorijaizdaci()
        {
            while (this.RcdFound165 != 0)
            {
                this.LoadRowDdkategorijaizdaci();
                this.CreateNewRowDdkategorijaizdaci();
                this.ScanNextDdkategorijaizdaci();
            }
            this.ScanEndDdkategorijaizdaci();
        }

        private void LoadDataDdkategorijalevel1()
        {
            while (this.RcdFound139 != 0)
            {
                this.LoadRowDdkategorijalevel1();
                this.CreateNewRowDdkategorijalevel1();
                this.ScanNextDdkategorijalevel1();
            }
            this.ScanEndDdkategorijalevel1();
        }

        private void LoadDataDdkategorijalevel3()
        {
            while (this.RcdFound140 != 0)
            {
                this.LoadRowDdkategorijalevel3();
                this.CreateNewRowDdkategorijalevel3();
                this.ScanNextDdkategorijalevel3();
            }
            this.ScanEndDdkategorijalevel3();
        }

        private void LoadDdkategorija()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVKOLONAIDD] FROM [DDKOLONAIDD] WITH (NOLOCK) WHERE [IDKOLONAIDD] = @IDKOLONAIDD ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["IDKOLONAIDD"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowDDKATEGORIJA["NAZIVKOLONAIDD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void LoadRowDdkategorija()
        {
            this.AddRowDdkategorija();
        }

        private void LoadRowDdkategorijaizdaci()
        {
            this.AddRowDdkategorijaizdaci();
        }

        private void LoadRowDdkategorijalevel1()
        {
            this.AddRowDdkategorijalevel1();
        }

        private void LoadRowDdkategorijalevel3()
        {
            this.AddRowDdkategorijalevel3();
        }

        private void OnDDKATEGORIJAIzdaciUpdated(DDKATEGORIJAIzdaciEventArgs e)
        {
            if (this.DDKATEGORIJAIzdaciUpdated != null)
            {
                DDKATEGORIJAIzdaciUpdateEventHandler dDKATEGORIJAIzdaciUpdatedEvent = this.DDKATEGORIJAIzdaciUpdated;
                if (dDKATEGORIJAIzdaciUpdatedEvent != null)
                {
                    dDKATEGORIJAIzdaciUpdatedEvent(this, e);
                }
            }
        }

        private void OnDDKATEGORIJAIzdaciUpdating(DDKATEGORIJAIzdaciEventArgs e)
        {
            if (this.DDKATEGORIJAIzdaciUpdating != null)
            {
                DDKATEGORIJAIzdaciUpdateEventHandler dDKATEGORIJAIzdaciUpdatingEvent = this.DDKATEGORIJAIzdaciUpdating;
                if (dDKATEGORIJAIzdaciUpdatingEvent != null)
                {
                    dDKATEGORIJAIzdaciUpdatingEvent(this, e);
                }
            }
        }

        private void OnDDKATEGORIJALevel1Updated(DDKATEGORIJALevel1EventArgs e)
        {
            if (this.DDKATEGORIJALevel1Updated != null)
            {
                DDKATEGORIJALevel1UpdateEventHandler handler = this.DDKATEGORIJALevel1Updated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnDDKATEGORIJALevel1Updating(DDKATEGORIJALevel1EventArgs e)
        {
            if (this.DDKATEGORIJALevel1Updating != null)
            {
                DDKATEGORIJALevel1UpdateEventHandler handler = this.DDKATEGORIJALevel1Updating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnDDKATEGORIJALevel3Updated(DDKATEGORIJALevel3EventArgs e)
        {
            if (this.DDKATEGORIJALevel3Updated != null)
            {
                DDKATEGORIJALevel3UpdateEventHandler handler = this.DDKATEGORIJALevel3Updated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnDDKATEGORIJALevel3Updating(DDKATEGORIJALevel3EventArgs e)
        {
            if (this.DDKATEGORIJALevel3Updating != null)
            {
                DDKATEGORIJALevel3UpdateEventHandler handler = this.DDKATEGORIJALevel3Updating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnDDKATEGORIJAUpdated(DDKATEGORIJAEventArgs e)
        {
            if (this.DDKATEGORIJAUpdated != null)
            {
                DDKATEGORIJAUpdateEventHandler dDKATEGORIJAUpdatedEvent = this.DDKATEGORIJAUpdated;
                if (dDKATEGORIJAUpdatedEvent != null)
                {
                    dDKATEGORIJAUpdatedEvent(this, e);
                }
            }
        }

        private void OnDDKATEGORIJAUpdating(DDKATEGORIJAEventArgs e)
        {
            if (this.DDKATEGORIJAUpdating != null)
            {
                DDKATEGORIJAUpdateEventHandler dDKATEGORIJAUpdatingEvent = this.DDKATEGORIJAUpdating;
                if (dDKATEGORIJAUpdatingEvent != null)
                {
                    dDKATEGORIJAUpdatingEvent(this, e);
                }
            }
        }

        private void OnDeleteControlsDdkategorija()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVKOLONAIDD] FROM [DDKOLONAIDD] WITH (NOLOCK) WHERE [IDKOLONAIDD] = @IDKOLONAIDD ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["IDKOLONAIDD"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowDDKATEGORIJA["NAZIVKOLONAIDD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void OnDeleteControlsDdkategorijaizdaci()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDNAZIVIZDATKA], [DDPOSTOTAKIZDATKA] FROM [DDIZDATAK] WITH (NOLOCK) WHERE [DDIDIZDATAK] = @DDIDIZDATAK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJAIzdaci["DDIDIZDATAK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowDDKATEGORIJAIzdaci["DDNAZIVIZDATKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowDDKATEGORIJAIzdaci["DDPOSTOTAKIZDATKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            }
            reader.Close();
        }

        private void OnDeleteControlsDdkategorijalevel1()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVPOREZ], [POREZMJESECNO], [STOPAPOREZA], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ] FROM [POREZ] WITH (NOLOCK) WHERE [IDPOREZ] = @IDPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["IDPOREZ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowDDKATEGORIJALevel1["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowDDKATEGORIJALevel1["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
                this.rowDDKATEGORIJALevel1["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
                this.rowDDKATEGORIJALevel1["MZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowDDKATEGORIJALevel1["PZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowDDKATEGORIJALevel1["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowDDKATEGORIJALevel1["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowDDKATEGORIJALevel1["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowDDKATEGORIJALevel1["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
            }
            reader.Close();
        }

        private void OnDeleteControlsDdkategorijalevel3()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVDOPRINOS], [MODOPRINOS], [PODOPRINOS], [MZDOPRINOS], [PZDOPRINOS], [PRIMATELJDOPRINOS1], [PRIMATELJDOPRINOS2], [SIFRAOPISAPLACANJADOPRINOS], [OPISPLACANJADOPRINOS], [VBDIDOPRINOS], [ZRNDOPRINOS], [STOPA], [IDVRSTADOPRINOS] FROM [DOPRINOS] WITH (NOLOCK) WHERE [IDDOPRINOS] = @IDDOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel3["IDDOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowDDKATEGORIJALevel3["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowDDKATEGORIJALevel3["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowDDKATEGORIJALevel3["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowDDKATEGORIJALevel3["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowDDKATEGORIJALevel3["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowDDKATEGORIJALevel3["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowDDKATEGORIJALevel3["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowDDKATEGORIJALevel3["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowDDKATEGORIJALevel3["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowDDKATEGORIJALevel3["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowDDKATEGORIJALevel3["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
                this.rowDDKATEGORIJALevel3["STOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 11));
                this.rowDDKATEGORIJALevel3["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 12));
            }
            reader.Close();
            if (!this.rowDDKATEGORIJALevel3.IsIDVRSTADOPRINOSNull())
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVVRSTADOPRINOS] FROM [VRSTADOPRINOS] WITH (NOLOCK) WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
                }
                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel3["IDVRSTADOPRINOS"]));
                IDataReader reader2 = command2.FetchData();
                if (command2.HasMoreRows)
                {
                    this.rowDDKATEGORIJALevel3["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                }
                reader2.Close();
            }
            else
            {
                this.rowDDKATEGORIJALevel3["NAZIVVRSTADOPRINOS"] = "";
            }
        }

        private void ProcessLevelDdkategorija()
        {
            this.sMode138 = this.Gx_mode;
            this.ProcessNestedLevelDdkategorijalevel1();
            this.ProcessNestedLevelDdkategorijalevel3();
            this.ProcessNestedLevelDdkategorijaizdaci();
            this.Gx_mode = this.sMode138;
        }

        private void ProcessNestedLevelDdkategorijaizdaci()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.DDKATEGORIJASet.DDKATEGORIJAIzdaci.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowDDKATEGORIJAIzdaci = (DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow) current;
                    if (Helpers.IsRowChanged(this.rowDDKATEGORIJAIzdaci))
                    {
                        bool flag = false;
                        if (this.rowDDKATEGORIJAIzdaci.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowDDKATEGORIJAIzdaci.IDKATEGORIJA == this.rowDDKATEGORIJA.IDKATEGORIJA;
                        }
                        else
                        {
                            flag = this.rowDDKATEGORIJAIzdaci["IDKATEGORIJA", DataRowVersion.Original].Equals(this.rowDDKATEGORIJA.IDKATEGORIJA);
                        }
                        if (flag)
                        {
                            this.ReadRowDdkategorijaizdaci();
                            if (this.rowDDKATEGORIJAIzdaci.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertDdkategorijaizdaci();
                            }
                            else
                            {
                                if (this._Gxremove49)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteDdkategorijaizdaci();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateDdkategorijaizdaci();
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

        private void ProcessNestedLevelDdkategorijalevel1()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.DDKATEGORIJASet.DDKATEGORIJALevel1.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowDDKATEGORIJALevel1 = (DDKATEGORIJADataSet.DDKATEGORIJALevel1Row) current;
                    if (Helpers.IsRowChanged(this.rowDDKATEGORIJALevel1))
                    {
                        bool flag = false;
                        if (this.rowDDKATEGORIJALevel1.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowDDKATEGORIJALevel1.IDKATEGORIJA == this.rowDDKATEGORIJA.IDKATEGORIJA;
                        }
                        else
                        {
                            flag = this.rowDDKATEGORIJALevel1["IDKATEGORIJA", DataRowVersion.Original].Equals(this.rowDDKATEGORIJA.IDKATEGORIJA);
                        }
                        if (flag)
                        {
                            this.ReadRowDdkategorijalevel1();
                            if (this.rowDDKATEGORIJALevel1.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertDdkategorijalevel1();
                            }
                            else
                            {
                                if (this._Gxremove19)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteDdkategorijalevel1();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateDdkategorijalevel1();
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

        private void ProcessNestedLevelDdkategorijalevel3()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.DDKATEGORIJASet.DDKATEGORIJALevel3.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowDDKATEGORIJALevel3 = (DDKATEGORIJADataSet.DDKATEGORIJALevel3Row) current;
                    if (Helpers.IsRowChanged(this.rowDDKATEGORIJALevel3))
                    {
                        bool flag = false;
                        if (this.rowDDKATEGORIJALevel3.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowDDKATEGORIJALevel3.IDKATEGORIJA == this.rowDDKATEGORIJA.IDKATEGORIJA;
                        }
                        else
                        {
                            flag = this.rowDDKATEGORIJALevel3["IDKATEGORIJA", DataRowVersion.Original].Equals(this.rowDDKATEGORIJA.IDKATEGORIJA);
                        }
                        if (flag)
                        {
                            this.ReadRowDdkategorijalevel3();
                            if (this.rowDDKATEGORIJALevel3.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertDdkategorijalevel3();
                            }
                            else
                            {
                                if (this._Gxremove32)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteDdkategorijalevel3();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateDdkategorijalevel3();
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

        private void ReadRowDdkategorija()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDDKATEGORIJA.RowState);
            if (this.rowDDKATEGORIJA.RowState != DataRowState.Added)
            {
                this.m__NAZIVKATEGORIJAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["NAZIVKATEGORIJA", DataRowVersion.Original]);
                this.m__IDKOLONAIDDOriginal = RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["IDKOLONAIDD", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVKATEGORIJAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["NAZIVKATEGORIJA"]);
                this.m__IDKOLONAIDDOriginal = RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["IDKOLONAIDD"]);
            }
            this._Gxremove = this.rowDDKATEGORIJA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowDDKATEGORIJA = (DDKATEGORIJADataSet.DDKATEGORIJARow) DataSetUtil.CloneOriginalDataRow(this.rowDDKATEGORIJA);
            }
        }

        private void ReadRowDdkategorijaizdaci()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDDKATEGORIJAIzdaci.RowState);
            if (this.rowDDKATEGORIJAIzdaci.RowState == DataRowState.Added)
            {
            }
            this._Gxremove49 = this.rowDDKATEGORIJAIzdaci.RowState == DataRowState.Deleted;
            if (this._Gxremove49)
            {
                this.rowDDKATEGORIJAIzdaci = (DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow) DataSetUtil.CloneOriginalDataRow(this.rowDDKATEGORIJAIzdaci);
            }
        }

        private void ReadRowDdkategorijalevel1()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDDKATEGORIJALevel1.RowState);
            if (this.rowDDKATEGORIJALevel1.RowState != DataRowState.Added)
            {
                this.m__DDMOPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["DDMOPOREZ", DataRowVersion.Original]);
                this.m__DDPOPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["DDPOPOREZ", DataRowVersion.Original]);
            }
            else
            {
                this.m__DDMOPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["DDMOPOREZ"]);
                this.m__DDPOPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["DDPOPOREZ"]);
            }
            this._Gxremove19 = this.rowDDKATEGORIJALevel1.RowState == DataRowState.Deleted;
            if (this._Gxremove19)
            {
                this.rowDDKATEGORIJALevel1 = (DDKATEGORIJADataSet.DDKATEGORIJALevel1Row) DataSetUtil.CloneOriginalDataRow(this.rowDDKATEGORIJALevel1);
            }
        }

        private void ReadRowDdkategorijalevel3()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDDKATEGORIJALevel3.RowState);
            if (this.rowDDKATEGORIJALevel3.RowState != DataRowState.Added)
            {
                this.m__DOPRINOSDRUGOGSTUPAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel3["DOPRINOSDRUGOGSTUPA", DataRowVersion.Original]);
            }
            else
            {
                this.m__DOPRINOSDRUGOGSTUPAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel3["DOPRINOSDRUGOGSTUPA"]);
            }
            this._Gxremove32 = this.rowDDKATEGORIJALevel3.RowState == DataRowState.Deleted;
            if (this._Gxremove32)
            {
                this.rowDDKATEGORIJALevel3 = (DDKATEGORIJADataSet.DDKATEGORIJALevel3Row) DataSetUtil.CloneOriginalDataRow(this.rowDDKATEGORIJALevel3);
            }
        }

        private void ScanByIDKATEGORIJA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDKATEGORIJA] = @IDKATEGORIJA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString138 + "  FROM ([DDKATEGORIJA] TM1 WITH (NOLOCK) INNER JOIN [DDKOLONAIDD] T2 WITH (NOLOCK) ON T2.[IDKOLONAIDD] = TM1.[IDKOLONAIDD])" + this.m_WhereString + " ORDER BY TM1.[IDKATEGORIJA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString138, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDKATEGORIJA] ) AS DK_PAGENUM   FROM ([DDKATEGORIJA] TM1 WITH (NOLOCK) INNER JOIN [DDKOLONAIDD] T2 WITH (NOLOCK) ON T2.[IDKOLONAIDD] = TM1.[IDKOLONAIDD]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString138 + " FROM ([DDKATEGORIJA] TM1 WITH (NOLOCK) INNER JOIN [DDKOLONAIDD] T2 WITH (NOLOCK) ON T2.[IDKOLONAIDD] = TM1.[IDKOLONAIDD])" + this.m_WhereString + " ORDER BY TM1.[IDKATEGORIJA] ";
            }
            this.cmDDKATEGORIJASelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmDDKATEGORIJASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDKATEGORIJASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
            }
            this.cmDDKATEGORIJASelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["IDKATEGORIJA"]));
            this.DDKATEGORIJASelect5 = this.cmDDKATEGORIJASelect5.FetchData();
            this.RcdFound138 = 0;
            this.ScanLoadDdkategorija();
            this.LoadDataDdkategorija(maxRows);
            if (this.RcdFound138 > 0)
            {
                this.SubLvlScanStartDdkategorijalevel1(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDKATEGORIJADdkategorija(this.cmDDKATEGORIJALevel1Select2);
                this.SubLvlFetchDdkategorijalevel1();
                this.SubLoadDataDdkategorijalevel1();
                this.SubLvlScanStartDdkategorijalevel3(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDKATEGORIJADdkategorija(this.cmDDKATEGORIJALevel3Select2);
                this.SubLvlFetchDdkategorijalevel3();
                this.SubLoadDataDdkategorijalevel3();
                this.SubLvlScanStartDdkategorijaizdaci(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDKATEGORIJADdkategorija(this.cmDDKATEGORIJAIzdaciSelect2);
                this.SubLvlFetchDdkategorijaizdaci();
                this.SubLoadDataDdkategorijaizdaci();
            }
        }

        private void ScanByIDKOLONAIDD(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDKOLONAIDD] = @IDKOLONAIDD";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString138 + "  FROM ([DDKATEGORIJA] TM1 WITH (NOLOCK) INNER JOIN [DDKOLONAIDD] T2 WITH (NOLOCK) ON T2.[IDKOLONAIDD] = TM1.[IDKOLONAIDD])" + this.m_WhereString + " ORDER BY TM1.[IDKATEGORIJA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString138, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDKATEGORIJA] ) AS DK_PAGENUM   FROM ([DDKATEGORIJA] TM1 WITH (NOLOCK) INNER JOIN [DDKOLONAIDD] T2 WITH (NOLOCK) ON T2.[IDKOLONAIDD] = TM1.[IDKOLONAIDD]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString138 + " FROM ([DDKATEGORIJA] TM1 WITH (NOLOCK) INNER JOIN [DDKOLONAIDD] T2 WITH (NOLOCK) ON T2.[IDKOLONAIDD] = TM1.[IDKOLONAIDD])" + this.m_WhereString + " ORDER BY TM1.[IDKATEGORIJA] ";
            }
            this.cmDDKATEGORIJASelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmDDKATEGORIJASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDKATEGORIJASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
            }
            this.cmDDKATEGORIJASelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["IDKOLONAIDD"]));
            this.DDKATEGORIJASelect5 = this.cmDDKATEGORIJASelect5.FetchData();
            this.RcdFound138 = 0;
            this.ScanLoadDdkategorija();
            this.LoadDataDdkategorija(maxRows);
            if (this.RcdFound138 > 0)
            {
                this.SubLvlScanStartDdkategorijalevel1(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDKOLONAIDDDdkategorija(this.cmDDKATEGORIJALevel1Select2);
                this.SubLvlFetchDdkategorijalevel1();
                this.SubLoadDataDdkategorijalevel1();
                this.SubLvlScanStartDdkategorijalevel3(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDKOLONAIDDDdkategorija(this.cmDDKATEGORIJALevel3Select2);
                this.SubLvlFetchDdkategorijalevel3();
                this.SubLoadDataDdkategorijalevel3();
                this.SubLvlScanStartDdkategorijaizdaci(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDKOLONAIDDDdkategorija(this.cmDDKATEGORIJAIzdaciSelect2);
                this.SubLvlFetchDdkategorijaizdaci();
                this.SubLoadDataDdkategorijaizdaci();
            }
        }

        private void ScanEndDdkategorija()
        {
            this.DDKATEGORIJASelect5.Close();
        }

        private void ScanEndDdkategorijaizdaci()
        {
            this.DDKATEGORIJAIzdaciSelect2.Close();
        }

        private void ScanEndDdkategorijalevel1()
        {
            this.DDKATEGORIJALevel1Select2.Close();
        }

        private void ScanEndDdkategorijalevel3()
        {
            this.DDKATEGORIJALevel3Select2.Close();
        }

        private void ScanLoadDdkategorija()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDDKATEGORIJASelect5.HasMoreRows)
            {
                this.RcdFound138 = 1;
                this.rowDDKATEGORIJA["IDKATEGORIJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDKATEGORIJASelect5, 0));
                this.rowDDKATEGORIJA["NAZIVKATEGORIJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJASelect5, 1));
                this.rowDDKATEGORIJA["NAZIVKOLONAIDD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJASelect5, 2));
                this.rowDDKATEGORIJA["IDKOLONAIDD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDKATEGORIJASelect5, 3));
                this.rowDDKATEGORIJA["NAZIVKOLONAIDD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJASelect5, 2));
            }
        }

        private void ScanLoadDdkategorijaizdaci()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDDKATEGORIJAIzdaciSelect2.HasMoreRows)
            {
                this.RcdFound165 = 1;
                this.rowDDKATEGORIJAIzdaci["IDKATEGORIJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDKATEGORIJAIzdaciSelect2, 0));
                this.rowDDKATEGORIJAIzdaci["DDNAZIVIZDATKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJAIzdaciSelect2, 1));
                this.rowDDKATEGORIJAIzdaci["DDPOSTOTAKIZDATKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDKATEGORIJAIzdaciSelect2, 2));
                this.rowDDKATEGORIJAIzdaci["DDIDIZDATAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDKATEGORIJAIzdaciSelect2, 3));
                this.rowDDKATEGORIJAIzdaci["DDNAZIVIZDATKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJAIzdaciSelect2, 1));
                this.rowDDKATEGORIJAIzdaci["DDPOSTOTAKIZDATKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDKATEGORIJAIzdaciSelect2, 2));
            }
        }

        private void ScanLoadDdkategorijalevel1()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDDKATEGORIJALevel1Select2.HasMoreRows)
            {
                this.RcdFound139 = 1;
                this.rowDDKATEGORIJALevel1["IDKATEGORIJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDKATEGORIJALevel1Select2, 0));
                this.rowDDKATEGORIJALevel1["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel1Select2, 1));
                this.rowDDKATEGORIJALevel1["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDKATEGORIJALevel1Select2, 2));
                this.rowDDKATEGORIJALevel1["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDKATEGORIJALevel1Select2, 3));
                this.rowDDKATEGORIJALevel1["DDMOPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel1Select2, 4));
                this.rowDDKATEGORIJALevel1["DDPOPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel1Select2, 5));
                this.rowDDKATEGORIJALevel1["MZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel1Select2, 6));
                this.rowDDKATEGORIJALevel1["PZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel1Select2, 7));
                this.rowDDKATEGORIJALevel1["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel1Select2, 8));
                this.rowDDKATEGORIJALevel1["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel1Select2, 9));
                this.rowDDKATEGORIJALevel1["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel1Select2, 10));
                this.rowDDKATEGORIJALevel1["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel1Select2, 11));
                this.rowDDKATEGORIJALevel1["IDPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDKATEGORIJALevel1Select2, 12));
                this.rowDDKATEGORIJALevel1["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel1Select2, 1));
                this.rowDDKATEGORIJALevel1["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDKATEGORIJALevel1Select2, 2));
                this.rowDDKATEGORIJALevel1["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDKATEGORIJALevel1Select2, 3));
                this.rowDDKATEGORIJALevel1["MZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel1Select2, 6));
                this.rowDDKATEGORIJALevel1["PZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel1Select2, 7));
                this.rowDDKATEGORIJALevel1["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel1Select2, 8));
                this.rowDDKATEGORIJALevel1["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel1Select2, 9));
                this.rowDDKATEGORIJALevel1["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel1Select2, 10));
                this.rowDDKATEGORIJALevel1["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel1Select2, 11));
            }
        }

        private void ScanLoadDdkategorijalevel3()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDDKATEGORIJALevel3Select2.HasMoreRows)
            {
                this.RcdFound140 = 1;
                this.rowDDKATEGORIJALevel3["IDKATEGORIJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDKATEGORIJALevel3Select2, 0));
                this.rowDDKATEGORIJALevel3["DOPRINOSDRUGOGSTUPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.DDKATEGORIJALevel3Select2, 1));
                this.rowDDKATEGORIJALevel3["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 2));
                this.rowDDKATEGORIJALevel3["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 3));
                this.rowDDKATEGORIJALevel3["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 4));
                this.rowDDKATEGORIJALevel3["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 5));
                this.rowDDKATEGORIJALevel3["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 6));
                this.rowDDKATEGORIJALevel3["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 7));
                this.rowDDKATEGORIJALevel3["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 8));
                this.rowDDKATEGORIJALevel3["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 9));
                this.rowDDKATEGORIJALevel3["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 10));
                this.rowDDKATEGORIJALevel3["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 11));
                this.rowDDKATEGORIJALevel3["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 12));
                this.rowDDKATEGORIJALevel3["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 13));
                this.rowDDKATEGORIJALevel3["STOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDKATEGORIJALevel3Select2, 14));
                this.rowDDKATEGORIJALevel3["IDDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDKATEGORIJALevel3Select2, 15));
                this.rowDDKATEGORIJALevel3["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDKATEGORIJALevel3Select2, 0x10));
                this.rowDDKATEGORIJALevel3["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 2));
                this.rowDDKATEGORIJALevel3["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 4));
                this.rowDDKATEGORIJALevel3["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 5));
                this.rowDDKATEGORIJALevel3["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 6));
                this.rowDDKATEGORIJALevel3["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 7));
                this.rowDDKATEGORIJALevel3["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 8));
                this.rowDDKATEGORIJALevel3["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 9));
                this.rowDDKATEGORIJALevel3["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 10));
                this.rowDDKATEGORIJALevel3["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 11));
                this.rowDDKATEGORIJALevel3["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 12));
                this.rowDDKATEGORIJALevel3["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 13));
                this.rowDDKATEGORIJALevel3["STOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDKATEGORIJALevel3Select2, 14));
                this.rowDDKATEGORIJALevel3["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDKATEGORIJALevel3Select2, 0x10));
                this.rowDDKATEGORIJALevel3["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKATEGORIJALevel3Select2, 3));
            }
        }

        private void ScanNextDdkategorija()
        {
            this.cmDDKATEGORIJASelect5.HasMoreRows = this.DDKATEGORIJASelect5.Read();
            this.RcdFound138 = 0;
            this.ScanLoadDdkategorija();
        }

        private void ScanNextDdkategorijaizdaci()
        {
            this.cmDDKATEGORIJAIzdaciSelect2.HasMoreRows = this.DDKATEGORIJAIzdaciSelect2.Read();
            this.RcdFound165 = 0;
            this.ScanLoadDdkategorijaizdaci();
        }

        private void ScanNextDdkategorijalevel1()
        {
            this.cmDDKATEGORIJALevel1Select2.HasMoreRows = this.DDKATEGORIJALevel1Select2.Read();
            this.RcdFound139 = 0;
            this.ScanLoadDdkategorijalevel1();
        }

        private void ScanNextDdkategorijalevel3()
        {
            this.cmDDKATEGORIJALevel3Select2.HasMoreRows = this.DDKATEGORIJALevel3Select2.Read();
            this.RcdFound140 = 0;
            this.ScanLoadDdkategorijalevel3();
        }

        //Dohvat iz BAZE
        private void ScanStartDdkategorija(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString138 + "  FROM ([DDKATEGORIJA] TM1 WITH (NOLOCK) INNER JOIN [DDKOLONAIDD] T2 WITH (NOLOCK) ON T2.[IDKOLONAIDD] = TM1.[IDKOLONAIDD])" + this.m_WhereString + " ORDER BY TM1.[IDKATEGORIJA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString138, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDKATEGORIJA] ) AS DK_PAGENUM   FROM ([DDKATEGORIJA] TM1 WITH (NOLOCK) INNER JOIN [DDKOLONAIDD] T2 WITH (NOLOCK) ON T2.[IDKOLONAIDD] = TM1.[IDKOLONAIDD]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString138 + " FROM ([DDKATEGORIJA] TM1 WITH (NOLOCK) INNER JOIN [DDKOLONAIDD] T2 WITH (NOLOCK) ON T2.[IDKOLONAIDD] = TM1.[IDKOLONAIDD])" + this.m_WhereString + " ORDER BY TM1.[IDKATEGORIJA] desc "; //db - 03.02.2017 dodano desc na kraju
            }
            this.cmDDKATEGORIJASelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.DDKATEGORIJASelect5 = this.cmDDKATEGORIJASelect5.FetchData();
            this.RcdFound138 = 0;
            this.ScanLoadDdkategorija();
            this.LoadDataDdkategorija(maxRows);
            if (this.RcdFound138 > 0)
            {
                this.SubLvlScanStartDdkategorijalevel1(this.m_WhereString, startRow, maxRows);
                this.SetParametersDdkategorijaDdkategorija(this.cmDDKATEGORIJALevel1Select2);
                this.SubLvlFetchDdkategorijalevel1();
                this.SubLoadDataDdkategorijalevel1();
                this.SubLvlScanStartDdkategorijalevel3(this.m_WhereString, startRow, maxRows);
                this.SetParametersDdkategorijaDdkategorija(this.cmDDKATEGORIJALevel3Select2);
                this.SubLvlFetchDdkategorijalevel3();
                this.SubLoadDataDdkategorijalevel3();
                this.SubLvlScanStartDdkategorijaizdaci(this.m_WhereString, startRow, maxRows);
                this.SetParametersDdkategorijaDdkategorija(this.cmDDKATEGORIJAIzdaciSelect2);
                this.SubLvlFetchDdkategorijaizdaci();
                this.SubLoadDataDdkategorijaizdaci();
            }
        }

        private void ScanStartDdkategorijaizdaci()
        {
            this.cmDDKATEGORIJAIzdaciSelect2 = this.connDefault.GetCommand("SELECT T1.[IDKATEGORIJA], T2.[DDNAZIVIZDATKA], T2.[DDPOSTOTAKIZDATKA], T1.[DDIDIZDATAK] FROM ([DDKATEGORIJAIzdaci] T1 WITH (NOLOCK) INNER JOIN [DDIZDATAK] T2 WITH (NOLOCK) ON T2.[DDIDIZDATAK] = T1.[DDIDIZDATAK]) WHERE T1.[IDKATEGORIJA] = @IDKATEGORIJA ORDER BY T1.[IDKATEGORIJA], T1.[DDIDIZDATAK] ", false);
            if (this.cmDDKATEGORIJAIzdaciSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDKATEGORIJAIzdaciSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
            }
            this.cmDDKATEGORIJAIzdaciSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJAIzdaci["IDKATEGORIJA"]));
            this.DDKATEGORIJAIzdaciSelect2 = this.cmDDKATEGORIJAIzdaciSelect2.FetchData();
            this.RcdFound165 = 0;
            this.ScanLoadDdkategorijaizdaci();
        }

        private void ScanStartDdkategorijalevel1()
        {
            this.cmDDKATEGORIJALevel1Select2 = this.connDefault.GetCommand("SELECT T1.[IDKATEGORIJA], T2.[NAZIVPOREZ], T2.[POREZMJESECNO], T2.[STOPAPOREZA], T1.[DDMOPOREZ], T1.[DDPOPOREZ], T2.[MZPOREZ], T2.[PZPOREZ], T2.[PRIMATELJPOREZ1], T2.[PRIMATELJPOREZ2], T2.[SIFRAOPISAPLACANJAPOREZ], T2.[OPISPLACANJAPOREZ], T1.[IDPOREZ] FROM ([DDKATEGORIJALevel1] T1 WITH (NOLOCK) INNER JOIN [POREZ] T2 WITH (NOLOCK) ON T2.[IDPOREZ] = T1.[IDPOREZ]) WHERE T1.[IDKATEGORIJA] = @IDKATEGORIJA ORDER BY T1.[IDKATEGORIJA], T1.[IDPOREZ] ", false);
            if (this.cmDDKATEGORIJALevel1Select2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDKATEGORIJALevel1Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
            }
            this.cmDDKATEGORIJALevel1Select2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["IDKATEGORIJA"]));
            this.DDKATEGORIJALevel1Select2 = this.cmDDKATEGORIJALevel1Select2.FetchData();
            this.RcdFound139 = 0;
            this.ScanLoadDdkategorijalevel1();
        }

        private void ScanStartDdkategorijalevel3()
        {
            this.cmDDKATEGORIJALevel3Select2 = this.connDefault.GetCommand("SELECT T1.[IDKATEGORIJA], T1.[DOPRINOSDRUGOGSTUPA], T2.[NAZIVDOPRINOS], T3.[NAZIVVRSTADOPRINOS], T2.[MODOPRINOS], T2.[PODOPRINOS], T2.[MZDOPRINOS], T2.[PZDOPRINOS], T2.[PRIMATELJDOPRINOS1], T2.[PRIMATELJDOPRINOS2], T2.[SIFRAOPISAPLACANJADOPRINOS], T2.[OPISPLACANJADOPRINOS], T2.[VBDIDOPRINOS], T2.[ZRNDOPRINOS], T2.[STOPA], T1.[IDDOPRINOS], T2.[IDVRSTADOPRINOS] FROM (([DDKATEGORIJALevel3] T1 WITH (NOLOCK) INNER JOIN [DOPRINOS] T2 WITH (NOLOCK) ON T2.[IDDOPRINOS] = T1.[IDDOPRINOS]) INNER JOIN [VRSTADOPRINOS] T3 WITH (NOLOCK) ON T3.[IDVRSTADOPRINOS] = T2.[IDVRSTADOPRINOS]) WHERE T1.[IDKATEGORIJA] = @IDKATEGORIJA ORDER BY T1.[IDKATEGORIJA], T1.[IDDOPRINOS] ", false);
            if (this.cmDDKATEGORIJALevel3Select2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDKATEGORIJALevel3Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
            }
            this.cmDDKATEGORIJALevel3Select2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel3["IDKATEGORIJA"]));
            this.DDKATEGORIJALevel3Select2 = this.cmDDKATEGORIJALevel3Select2.FetchData();
            this.RcdFound140 = 0;
            this.ScanLoadDdkategorijalevel3();
        }

        private void SetParametersDdkategorijaDdkategorija(ReadWriteCommand m_Command)
        {
        }

        private void SetParametersIDKATEGORIJADdkategorija(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["IDKATEGORIJA"]));
        }

        private void SetParametersIDKOLONAIDDDdkategorija(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["IDKOLONAIDD"]));
        }

        private void SkipNextDdkategorijaizdaci()
        {
            this.cmDDKATEGORIJAIzdaciSelect2.HasMoreRows = this.DDKATEGORIJAIzdaciSelect2.Read();
            this.RcdFound165 = 0;
            if (this.cmDDKATEGORIJAIzdaciSelect2.HasMoreRows)
            {
                this.RcdFound165 = 1;
            }
        }

        private void SkipNextDdkategorijalevel1()
        {
            this.cmDDKATEGORIJALevel1Select2.HasMoreRows = this.DDKATEGORIJALevel1Select2.Read();
            this.RcdFound139 = 0;
            if (this.cmDDKATEGORIJALevel1Select2.HasMoreRows)
            {
                this.RcdFound139 = 1;
            }
        }

        private void SkipNextDdkategorijalevel3()
        {
            this.cmDDKATEGORIJALevel3Select2.HasMoreRows = this.DDKATEGORIJALevel3Select2.Read();
            this.RcdFound140 = 0;
            if (this.cmDDKATEGORIJALevel3Select2.HasMoreRows)
            {
                this.RcdFound140 = 1;
            }
        }

        private void SubLoadDataDdkategorijaizdaci()
        {
            while (this.RcdFound165 != 0)
            {
                this.LoadRowDdkategorijaizdaci();
                this.CreateNewRowDdkategorijaizdaci();
                this.ScanNextDdkategorijaizdaci();
            }
            this.ScanEndDdkategorijaizdaci();
        }

        private void SubLoadDataDdkategorijalevel1()
        {
            while (this.RcdFound139 != 0)
            {
                this.LoadRowDdkategorijalevel1();
                this.CreateNewRowDdkategorijalevel1();
                this.ScanNextDdkategorijalevel1();
            }
            this.ScanEndDdkategorijalevel1();
        }

        private void SubLoadDataDdkategorijalevel3()
        {
            while (this.RcdFound140 != 0)
            {
                this.LoadRowDdkategorijalevel3();
                this.CreateNewRowDdkategorijalevel3();
                this.ScanNextDdkategorijalevel3();
            }
            this.ScanEndDdkategorijalevel3();
        }

        private void SubLvlFetchDdkategorijaizdaci()
        {
            this.CreateNewRowDdkategorijaizdaci();
            this.DDKATEGORIJAIzdaciSelect2 = this.cmDDKATEGORIJAIzdaciSelect2.FetchData();
            this.RcdFound165 = 0;
            this.ScanLoadDdkategorijaizdaci();
        }

        private void SubLvlFetchDdkategorijalevel1()
        {
            this.CreateNewRowDdkategorijalevel1();
            this.DDKATEGORIJALevel1Select2 = this.cmDDKATEGORIJALevel1Select2.FetchData();
            this.RcdFound139 = 0;
            this.ScanLoadDdkategorijalevel1();
        }

        private void SubLvlFetchDdkategorijalevel3()
        {
            this.CreateNewRowDdkategorijalevel3();
            this.DDKATEGORIJALevel3Select2 = this.cmDDKATEGORIJALevel3Select2.FetchData();
            this.RcdFound140 = 0;
            this.ScanLoadDdkategorijalevel3();
        }

        private void SubLvlScanStartDdkategorijaizdaci(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString165 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDKATEGORIJA]  FROM [DDKATEGORIJA]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDKATEGORIJA] )";
                    this.scmdbuf = "SELECT T1.[IDKATEGORIJA], T3.[DDNAZIVIZDATKA], T3.[DDPOSTOTAKIZDATKA], T1.[DDIDIZDATAK] FROM (([DDKATEGORIJAIzdaci] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString165 + "  TMX ON TMX.[IDKATEGORIJA] = T1.[IDKATEGORIJA]) INNER JOIN [DDIZDATAK] T3 WITH (NOLOCK) ON T3.[DDIDIZDATAK] = T1.[DDIDIZDATAK]) ORDER BY T1.[IDKATEGORIJA], T1.[DDIDIZDATAK]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDKATEGORIJA], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDKATEGORIJA]  ) AS DK_PAGENUM   FROM [DDKATEGORIJA]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString165 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDKATEGORIJA], T3.[DDNAZIVIZDATKA], T3.[DDPOSTOTAKIZDATKA], T1.[DDIDIZDATAK] FROM (([DDKATEGORIJAIzdaci] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString165 + "  TMX ON TMX.[IDKATEGORIJA] = T1.[IDKATEGORIJA]) INNER JOIN [DDIZDATAK] T3 WITH (NOLOCK) ON T3.[DDIDIZDATAK] = T1.[DDIDIZDATAK]) ORDER BY T1.[IDKATEGORIJA], T1.[DDIDIZDATAK]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString165 = "[DDKATEGORIJA]";
                this.scmdbuf = "SELECT T1.[IDKATEGORIJA], T3.[DDNAZIVIZDATKA], T3.[DDPOSTOTAKIZDATKA], T1.[DDIDIZDATAK] FROM (([DDKATEGORIJAIzdaci] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString165 + "  TM1 WITH (NOLOCK) ON TM1.[IDKATEGORIJA] = T1.[IDKATEGORIJA]) INNER JOIN [DDIZDATAK] T3 WITH (NOLOCK) ON T3.[DDIDIZDATAK] = T1.[DDIDIZDATAK])" + this.m_WhereString + " ORDER BY T1.[IDKATEGORIJA], T1.[DDIDIZDATAK] ";
            }
            this.cmDDKATEGORIJAIzdaciSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartDdkategorijalevel1(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString139 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDKATEGORIJA]  FROM [DDKATEGORIJA]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDKATEGORIJA] )";
                    this.scmdbuf = "SELECT T1.[IDKATEGORIJA], T3.[NAZIVPOREZ], T3.[POREZMJESECNO], T3.[STOPAPOREZA], T1.[DDMOPOREZ], T1.[DDPOPOREZ], T3.[MZPOREZ], T3.[PZPOREZ], T3.[PRIMATELJPOREZ1], T3.[PRIMATELJPOREZ2], T3.[SIFRAOPISAPLACANJAPOREZ], T3.[OPISPLACANJAPOREZ], T1.[IDPOREZ] FROM (([DDKATEGORIJALevel1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString139 + "  TMX ON TMX.[IDKATEGORIJA] = T1.[IDKATEGORIJA]) INNER JOIN [POREZ] T3 WITH (NOLOCK) ON T3.[IDPOREZ] = T1.[IDPOREZ]) ORDER BY T1.[IDKATEGORIJA], T1.[IDPOREZ]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDKATEGORIJA], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDKATEGORIJA]  ) AS DK_PAGENUM   FROM [DDKATEGORIJA]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString139 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDKATEGORIJA], T3.[NAZIVPOREZ], T3.[POREZMJESECNO], T3.[STOPAPOREZA], T1.[DDMOPOREZ], T1.[DDPOPOREZ], T3.[MZPOREZ], T3.[PZPOREZ], T3.[PRIMATELJPOREZ1], T3.[PRIMATELJPOREZ2], T3.[SIFRAOPISAPLACANJAPOREZ], T3.[OPISPLACANJAPOREZ], T1.[IDPOREZ] FROM (([DDKATEGORIJALevel1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString139 + "  TMX ON TMX.[IDKATEGORIJA] = T1.[IDKATEGORIJA]) INNER JOIN [POREZ] T3 WITH (NOLOCK) ON T3.[IDPOREZ] = T1.[IDPOREZ]) ORDER BY T1.[IDKATEGORIJA], T1.[IDPOREZ]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString139 = "[DDKATEGORIJA]";
                this.scmdbuf = "SELECT T1.[IDKATEGORIJA], T3.[NAZIVPOREZ], T3.[POREZMJESECNO], T3.[STOPAPOREZA], T1.[DDMOPOREZ], T1.[DDPOPOREZ], T3.[MZPOREZ], T3.[PZPOREZ], T3.[PRIMATELJPOREZ1], T3.[PRIMATELJPOREZ2], T3.[SIFRAOPISAPLACANJAPOREZ], T3.[OPISPLACANJAPOREZ], T1.[IDPOREZ] FROM (([DDKATEGORIJALevel1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString139 + "  TM1 WITH (NOLOCK) ON TM1.[IDKATEGORIJA] = T1.[IDKATEGORIJA]) INNER JOIN [POREZ] T3 WITH (NOLOCK) ON T3.[IDPOREZ] = T1.[IDPOREZ])" + this.m_WhereString + " ORDER BY T1.[IDKATEGORIJA], T1.[IDPOREZ] ";
            }
            this.cmDDKATEGORIJALevel1Select2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartDdkategorijalevel3(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString140 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDKATEGORIJA]  FROM [DDKATEGORIJA]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDKATEGORIJA] )";
                    this.scmdbuf = "SELECT T1.[IDKATEGORIJA], T1.[DOPRINOSDRUGOGSTUPA], T3.[NAZIVDOPRINOS], T4.[NAZIVVRSTADOPRINOS], T3.[MODOPRINOS], T3.[PODOPRINOS], T3.[MZDOPRINOS], T3.[PZDOPRINOS], T3.[PRIMATELJDOPRINOS1], T3.[PRIMATELJDOPRINOS2], T3.[SIFRAOPISAPLACANJADOPRINOS], T3.[OPISPLACANJADOPRINOS], T3.[VBDIDOPRINOS], T3.[ZRNDOPRINOS], T3.[STOPA], T1.[IDDOPRINOS], T3.[IDVRSTADOPRINOS] FROM ((([DDKATEGORIJALevel3] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString140 + "  TMX ON TMX.[IDKATEGORIJA] = T1.[IDKATEGORIJA]) INNER JOIN [DOPRINOS] T3 WITH (NOLOCK) ON T3.[IDDOPRINOS] = T1.[IDDOPRINOS]) INNER JOIN [VRSTADOPRINOS] T4 WITH (NOLOCK) ON T4.[IDVRSTADOPRINOS] = T3.[IDVRSTADOPRINOS]) ORDER BY T1.[IDKATEGORIJA], T1.[IDDOPRINOS]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDKATEGORIJA], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDKATEGORIJA]  ) AS DK_PAGENUM   FROM [DDKATEGORIJA]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString140 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDKATEGORIJA], T1.[DOPRINOSDRUGOGSTUPA], T3.[NAZIVDOPRINOS], T4.[NAZIVVRSTADOPRINOS], T3.[MODOPRINOS], T3.[PODOPRINOS], T3.[MZDOPRINOS], T3.[PZDOPRINOS], T3.[PRIMATELJDOPRINOS1], T3.[PRIMATELJDOPRINOS2], T3.[SIFRAOPISAPLACANJADOPRINOS], T3.[OPISPLACANJADOPRINOS], T3.[VBDIDOPRINOS], T3.[ZRNDOPRINOS], T3.[STOPA], T1.[IDDOPRINOS], T3.[IDVRSTADOPRINOS] FROM ((([DDKATEGORIJALevel3] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString140 + "  TMX ON TMX.[IDKATEGORIJA] = T1.[IDKATEGORIJA]) INNER JOIN [DOPRINOS] T3 WITH (NOLOCK) ON T3.[IDDOPRINOS] = T1.[IDDOPRINOS]) INNER JOIN [VRSTADOPRINOS] T4 WITH (NOLOCK) ON T4.[IDVRSTADOPRINOS] = T3.[IDVRSTADOPRINOS]) ORDER BY T1.[IDKATEGORIJA], T1.[IDDOPRINOS]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString140 = "[DDKATEGORIJA]";
                this.scmdbuf = "SELECT T1.[IDKATEGORIJA], T1.[DOPRINOSDRUGOGSTUPA], T3.[NAZIVDOPRINOS], T4.[NAZIVVRSTADOPRINOS], T3.[MODOPRINOS], T3.[PODOPRINOS], T3.[MZDOPRINOS], T3.[PZDOPRINOS], T3.[PRIMATELJDOPRINOS1], T3.[PRIMATELJDOPRINOS2], T3.[SIFRAOPISAPLACANJADOPRINOS], T3.[OPISPLACANJADOPRINOS], T3.[VBDIDOPRINOS], T3.[ZRNDOPRINOS], T3.[STOPA], T1.[IDDOPRINOS], T3.[IDVRSTADOPRINOS] FROM ((([DDKATEGORIJALevel3] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString140 + "  TM1 WITH (NOLOCK) ON TM1.[IDKATEGORIJA] = T1.[IDKATEGORIJA]) INNER JOIN [DOPRINOS] T3 WITH (NOLOCK) ON T3.[IDDOPRINOS] = T1.[IDDOPRINOS]) INNER JOIN [VRSTADOPRINOS] T4 WITH (NOLOCK) ON T4.[IDVRSTADOPRINOS] = T3.[IDVRSTADOPRINOS])" + this.m_WhereString + " ORDER BY T1.[IDKATEGORIJA], T1.[IDDOPRINOS] ";
            }
            this.cmDDKATEGORIJALevel3Select2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.DDKATEGORIJASet = (DDKATEGORIJADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.DDKATEGORIJASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.DDKATEGORIJASet.DDKATEGORIJA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DDKATEGORIJADataSet.DDKATEGORIJARow current = (DDKATEGORIJADataSet.DDKATEGORIJARow) enumerator.Current;
                        this.rowDDKATEGORIJA = current;
                        if (Helpers.IsRowChanged(this.rowDDKATEGORIJA))
                        {
                            this.ReadRowDdkategorija();
                            if (this.rowDDKATEGORIJA.RowState == DataRowState.Added)
                            {
                                this.InsertDdkategorija();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateDdkategorija();
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

        private void UpdateDdkategorija()
        {
            this.CheckOptimisticConcurrencyDdkategorija();
            this.CheckExtendedTableDdkategorija();
            this.AfterConfirmDdkategorija();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DDKATEGORIJA] SET [NAZIVKATEGORIJA]=@NAZIVKATEGORIJA, [IDKOLONAIDD]=@IDKOLONAIDD  WHERE [IDKATEGORIJA] = @IDKATEGORIJA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVKATEGORIJA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["NAZIVKATEGORIJA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["IDKOLONAIDD"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJA["IDKATEGORIJA"]));
            command.ExecuteStmt();
            new ddkategorijaupdateredundancy(ref this.dsDefault).execute(this.rowDDKATEGORIJA.IDKATEGORIJA);
            this.OnDDKATEGORIJAUpdated(new DDKATEGORIJAEventArgs(this.rowDDKATEGORIJA, StatementType.Update));
            this.ProcessLevelDdkategorija();
        }

        private void UpdateDdkategorijaizdaci()
        {
            this.CheckOptimisticConcurrencyDdkategorijaizdaci();
            this.CheckExtendedTableDdkategorijaizdaci();
            this.AfterConfirmDdkategorijaizdaci();
            new ddkategorijaupdateredundancy(ref this.dsDefault).execute(this.rowDDKATEGORIJAIzdaci.IDKATEGORIJA);
            this.OnDDKATEGORIJAIzdaciUpdated(new DDKATEGORIJAIzdaciEventArgs(this.rowDDKATEGORIJAIzdaci, StatementType.Update));
        }

        private void UpdateDdkategorijalevel1()
        {
            this.CheckOptimisticConcurrencyDdkategorijalevel1();
            this.CheckExtendedTableDdkategorijalevel1();
            this.AfterConfirmDdkategorijalevel1();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DDKATEGORIJALevel1] SET [DDMOPOREZ]=@DDMOPOREZ, [DDPOPOREZ]=@DDPOPOREZ  WHERE [IDKATEGORIJA] = @IDKATEGORIJA AND [IDPOREZ] = @IDPOREZ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDMOPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPOPOREZ", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["DDMOPOREZ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["DDPOPOREZ"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["IDKATEGORIJA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel1["IDPOREZ"]));
            command.ExecuteStmt();
            new ddkategorijaupdateredundancy(ref this.dsDefault).execute(this.rowDDKATEGORIJALevel1.IDKATEGORIJA);
            this.OnDDKATEGORIJALevel1Updated(new DDKATEGORIJALevel1EventArgs(this.rowDDKATEGORIJALevel1, StatementType.Update));
        }

        private void UpdateDdkategorijalevel3()
        {
            this.CheckOptimisticConcurrencyDdkategorijalevel3();
            this.CheckExtendedTableDdkategorijalevel3();
            this.AfterConfirmDdkategorijalevel3();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DDKATEGORIJALevel3] SET [DOPRINOSDRUGOGSTUPA]=@DOPRINOSDRUGOGSTUPA  WHERE [IDKATEGORIJA] = @IDKATEGORIJA AND [IDDOPRINOS] = @IDDOPRINOS", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOPRINOSDRUGOGSTUPA", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel3["DOPRINOSDRUGOGSTUPA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel3["IDKATEGORIJA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDKATEGORIJALevel3["IDDOPRINOS"]));
            command.ExecuteStmt();
            new ddkategorijaupdateredundancy(ref this.dsDefault).execute(this.rowDDKATEGORIJALevel3.IDKATEGORIJA);
            this.OnDDKATEGORIJALevel3Updated(new DDKATEGORIJALevel3EventArgs(this.rowDDKATEGORIJALevel3, StatementType.Update));
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
        public class DDKATEGORIJADataChangedException : DataChangedException
        {
            public DDKATEGORIJADataChangedException()
            {
            }

            public DDKATEGORIJADataChangedException(string message) : base(message)
            {
            }

            protected DDKATEGORIJADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDKATEGORIJADataLockedException : DataLockedException
        {
            public DDKATEGORIJADataLockedException()
            {
            }

            public DDKATEGORIJADataLockedException(string message) : base(message)
            {
            }

            protected DDKATEGORIJADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDKATEGORIJADuplicateKeyException : DuplicateKeyException
        {
            public DDKATEGORIJADuplicateKeyException()
            {
            }

            public DDKATEGORIJADuplicateKeyException(string message) : base(message)
            {
            }

            protected DDKATEGORIJADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DDKATEGORIJAEventArgs : EventArgs
        {
            private DDKATEGORIJADataSet.DDKATEGORIJARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public DDKATEGORIJAEventArgs(DDKATEGORIJADataSet.DDKATEGORIJARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DDKATEGORIJADataSet.DDKATEGORIJARow Row
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
        public class DDKATEGORIJAIzdaciDataChangedException : DataChangedException
        {
            public DDKATEGORIJAIzdaciDataChangedException()
            {
            }

            public DDKATEGORIJAIzdaciDataChangedException(string message) : base(message)
            {
            }

            protected DDKATEGORIJAIzdaciDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJAIzdaciDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDKATEGORIJAIzdaciDataLockedException : DataLockedException
        {
            public DDKATEGORIJAIzdaciDataLockedException()
            {
            }

            public DDKATEGORIJAIzdaciDataLockedException(string message) : base(message)
            {
            }

            protected DDKATEGORIJAIzdaciDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJAIzdaciDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDKATEGORIJAIzdaciDuplicateKeyException : DuplicateKeyException
        {
            public DDKATEGORIJAIzdaciDuplicateKeyException()
            {
            }

            public DDKATEGORIJAIzdaciDuplicateKeyException(string message) : base(message)
            {
            }

            protected DDKATEGORIJAIzdaciDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJAIzdaciDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DDKATEGORIJAIzdaciEventArgs : EventArgs
        {
            private DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public DDKATEGORIJAIzdaciEventArgs(DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow Row
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

        public delegate void DDKATEGORIJAIzdaciUpdateEventHandler(object sender, DDKATEGORIJADataAdapter.DDKATEGORIJAIzdaciEventArgs e);

        [Serializable]
        public class DDKATEGORIJALevel1DataChangedException : DataChangedException
        {
            public DDKATEGORIJALevel1DataChangedException()
            {
            }

            public DDKATEGORIJALevel1DataChangedException(string message) : base(message)
            {
            }

            protected DDKATEGORIJALevel1DataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJALevel1DataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDKATEGORIJALevel1DataLockedException : DataLockedException
        {
            public DDKATEGORIJALevel1DataLockedException()
            {
            }

            public DDKATEGORIJALevel1DataLockedException(string message) : base(message)
            {
            }

            protected DDKATEGORIJALevel1DataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJALevel1DataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDKATEGORIJALevel1DuplicateKeyException : DuplicateKeyException
        {
            public DDKATEGORIJALevel1DuplicateKeyException()
            {
            }

            public DDKATEGORIJALevel1DuplicateKeyException(string message) : base(message)
            {
            }

            protected DDKATEGORIJALevel1DuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJALevel1DuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DDKATEGORIJALevel1EventArgs : EventArgs
        {
            private DDKATEGORIJADataSet.DDKATEGORIJALevel1Row m_dataRow;
            private System.Data.StatementType m_statementType;

            public DDKATEGORIJALevel1EventArgs(DDKATEGORIJADataSet.DDKATEGORIJALevel1Row row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DDKATEGORIJADataSet.DDKATEGORIJALevel1Row Row
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

        public delegate void DDKATEGORIJALevel1UpdateEventHandler(object sender, DDKATEGORIJADataAdapter.DDKATEGORIJALevel1EventArgs e);

        [Serializable]
        public class DDKATEGORIJALevel3DataChangedException : DataChangedException
        {
            public DDKATEGORIJALevel3DataChangedException()
            {
            }

            public DDKATEGORIJALevel3DataChangedException(string message) : base(message)
            {
            }

            protected DDKATEGORIJALevel3DataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJALevel3DataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDKATEGORIJALevel3DataLockedException : DataLockedException
        {
            public DDKATEGORIJALevel3DataLockedException()
            {
            }

            public DDKATEGORIJALevel3DataLockedException(string message) : base(message)
            {
            }

            protected DDKATEGORIJALevel3DataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJALevel3DataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDKATEGORIJALevel3DuplicateKeyException : DuplicateKeyException
        {
            public DDKATEGORIJALevel3DuplicateKeyException()
            {
            }

            public DDKATEGORIJALevel3DuplicateKeyException(string message) : base(message)
            {
            }

            protected DDKATEGORIJALevel3DuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJALevel3DuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DDKATEGORIJALevel3EventArgs : EventArgs
        {
            private DDKATEGORIJADataSet.DDKATEGORIJALevel3Row m_dataRow;
            private System.Data.StatementType m_statementType;

            public DDKATEGORIJALevel3EventArgs(DDKATEGORIJADataSet.DDKATEGORIJALevel3Row row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DDKATEGORIJADataSet.DDKATEGORIJALevel3Row Row
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

        public delegate void DDKATEGORIJALevel3UpdateEventHandler(object sender, DDKATEGORIJADataAdapter.DDKATEGORIJALevel3EventArgs e);

        [Serializable]
        public class DDKATEGORIJANotFoundException : DataNotFoundException
        {
            public DDKATEGORIJANotFoundException()
            {
            }

            public DDKATEGORIJANotFoundException(string message) : base(message)
            {
            }

            protected DDKATEGORIJANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void DDKATEGORIJAUpdateEventHandler(object sender, DDKATEGORIJADataAdapter.DDKATEGORIJAEventArgs e);

        [Serializable]
        public class DDKOLONAIDDForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public DDKOLONAIDDForeignKeyNotFoundException()
            {
            }

            public DDKOLONAIDDForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected DDKOLONAIDDForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKOLONAIDDForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
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

