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

    public class EVIDENCIJADataAdapter : IDataAdapter, IEVIDENCIJADataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private bool _Gxremove29;
        private ReadWriteCommand cmEVIDENCIJARADNICISATISelect2;
        private ReadWriteCommand cmEVIDENCIJARADNICISelect2;
        private ReadWriteCommand cmEVIDENCIJASelect1;
        private ReadWriteCommand cmEVIDENCIJASelect2;
        private ReadWriteCommand cmEVIDENCIJASelect3;
        private ReadWriteCommand cmEVIDENCIJASelect4;
        private ReadWriteCommand cmEVIDENCIJASelect7;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private IDataReader EVIDENCIJARADNICISATISelect2;
        private IDataReader EVIDENCIJARADNICISelect2;
        private IDataReader EVIDENCIJASelect1;
        private IDataReader EVIDENCIJASelect2;
        private IDataReader EVIDENCIJASelect3;
        private IDataReader EVIDENCIJASelect4;
        private IDataReader EVIDENCIJASelect7;
        private EVIDENCIJADataSet EVIDENCIJASet;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__BLGOriginal;
        private object m__BOFOriginal;
        private object m__BOPOriginal;
        private object m__DRUGASMJENAIDSMJENEOriginal;
        private object m__GOOriginal;
        private object m__IZNADNORMEOriginal;
        private object m__LOCOriginal;
        private object m__NEDOriginal;
        private object m__NENNEODOBRENAOriginal;
        private object m__NENOriginal;
        private object m__NOCOriginal;
        private object m__NPDOriginal;
        private object m__ODTOGADVOKRATNIOriginal;
        private object m__ODTOGAKOMBINACIJAOriginal;
        private object m__ODTOGAPOSEBNI1Original;
        private object m__ODTOGAPOSEBNI2Original;
        private object m__ODTOGAPOSEBNI3Original;
        private object m__ODTOGASMJENSKIOriginal;
        private object m__ODTOGASPECIJALNAOriginal;
        private object m__OPISEVIDENCIJEOriginal;
        private object m__PDOriginal;
        private object m__PRIOriginal;
        private object m__PROriginal;
        private object m__PRVASMJENAIDSMJENEOriginal;
        private object m__PRVOriginal;
        private object m__RDOriginal;
        private object m__RROriginal;
        private object m__SPOriginal;
        private object m__STROriginal;
        private object m__TROriginal;
        private object m__ZASOriginal;
        private readonly string m_SelectString264 = "TM1.[MJESEC], TM1.[BROJEVIDENCIJE], TM1.[OPISEVIDENCIJE], TM1.[IDGODINE]";
        private string m_SubSelTopString265;
        private string m_SubSelTopString266;
        private string m_WhereString;
        private short RcdFound264;
        private short RcdFound265;
        private short RcdFound266;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private EVIDENCIJADataSet.EVIDENCIJARow rowEVIDENCIJA;
        private EVIDENCIJADataSet.EVIDENCIJARADNICIRow rowEVIDENCIJARADNICI;
        private EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow rowEVIDENCIJARADNICISATI;
        private string scmdbuf;
        private StatementType sMode264;
        private StatementType sMode265;
        private StatementType sMode266;

        public event EVIDENCIJARADNICISATIUpdateEventHandler EVIDENCIJARADNICISATIUpdated;

        public event EVIDENCIJARADNICISATIUpdateEventHandler EVIDENCIJARADNICISATIUpdating;

        public event EVIDENCIJARADNICIUpdateEventHandler EVIDENCIJARADNICIUpdated;

        public event EVIDENCIJARADNICIUpdateEventHandler EVIDENCIJARADNICIUpdating;

        public event EVIDENCIJAUpdateEventHandler EVIDENCIJAUpdated;

        public event EVIDENCIJAUpdateEventHandler EVIDENCIJAUpdating;

        private void AddRowEvidencija()
        {
            this.EVIDENCIJASet.EVIDENCIJA.AddEVIDENCIJARow(this.rowEVIDENCIJA);
        }

        private void AddRowEvidencijaradnici()
        {
            this.EVIDENCIJASet.EVIDENCIJARADNICI.AddEVIDENCIJARADNICIRow(this.rowEVIDENCIJARADNICI);
        }

        private void AddRowEvidencijaradnicisati()
        {
            this.EVIDENCIJASet.EVIDENCIJARADNICISATI.AddEVIDENCIJARADNICISATIRow(this.rowEVIDENCIJARADNICISATI);
        }

        private void AfterConfirmEvidencija()
        {
            this.OnEVIDENCIJAUpdating(new EVIDENCIJAEventArgs(this.rowEVIDENCIJA, this.Gx_mode));
        }

        private void AfterConfirmEvidencijaradnici()
        {
            this.OnEVIDENCIJARADNICIUpdating(new EVIDENCIJARADNICIEventArgs(this.rowEVIDENCIJARADNICI, this.Gx_mode));
        }

        private void AfterConfirmEvidencijaradnicisati()
        {
            this.OnEVIDENCIJARADNICISATIUpdating(new EVIDENCIJARADNICISATIEventArgs(this.rowEVIDENCIJARADNICISATI, this.Gx_mode));
        }

        private void CheckExtendedTableEvidencijaradnici()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [PREZIME], [IME], [TJEDNIFONDSATI], [AKTIVAN] FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICI["IDRADNIK"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new RADNIKForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RADNIK") }));
            }
            this.rowEVIDENCIJARADNICI["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowEVIDENCIJARADNICI["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
            this.rowEVIDENCIJARADNICI["TJEDNIFONDSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
            this.rowEVIDENCIJARADNICI["AKTIVAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 3));
            reader.Close();
        }

        private void CheckExtendedTableEvidencijaradnicisati()
        {
            if (!this.rowEVIDENCIJARADNICISATI.IsPRVASMJENAIDSMJENENull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [OPISSMJENE] AS PRVASMJENAOPISSMJENE, [POCETAK] AS PRVASMJENAPOCETAK, [ZAVRSETAK] AS PRVASMJENAZAVRSETAK FROM [SMJENE] WITH (NOLOCK) WHERE [IDSMJENE] = @PRVASMJENAIDSMJENE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRVASMJENAIDSMJENE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PRVASMJENAIDSMJENE"]));
                IDataReader reader = command.FetchData();
                if (!command.HasMoreRows && (0 != this.rowEVIDENCIJARADNICISATI.PRVASMJENAIDSMJENE))
                {
                    reader.Close();
                    throw new SMJENEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("SMJENE") }));
                }
                this.rowEVIDENCIJARADNICISATI["PRVASMJENAOPISSMJENE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowEVIDENCIJARADNICISATI["PRVASMJENAPOCETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowEVIDENCIJARADNICISATI["PRVASMJENAZAVRSETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                reader.Close();
            }
            else
            {
                this.rowEVIDENCIJARADNICISATI["PRVASMJENAOPISSMJENE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowEVIDENCIJARADNICISATI["PRVASMJENAPOCETAK"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowEVIDENCIJARADNICISATI["PRVASMJENAZAVRSETAK"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowEVIDENCIJARADNICISATI.IsDRUGASMJENAIDSMJENENull())
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [OPISSMJENE] AS DRUGASMJENAOPISSMJENE, [POCETAK] AS DRUGASMJENAPOCETAK, [ZAVRSETAK] AS DRUGASMJENAZAVRSETAK FROM [SMJENE] WITH (NOLOCK) WHERE [IDSMJENE] = @DRUGASMJENAIDSMJENE ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DRUGASMJENAIDSMJENE", DbType.Int32));
                }
                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["DRUGASMJENAIDSMJENE"]));
                IDataReader reader2 = command2.FetchData();
                if (!command2.HasMoreRows && (0 != this.rowEVIDENCIJARADNICISATI.DRUGASMJENAIDSMJENE))
                {
                    reader2.Close();
                    throw new SMJENEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("SMJENE") }));
                }
                this.rowEVIDENCIJARADNICISATI["DRUGASMJENAOPISSMJENE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                this.rowEVIDENCIJARADNICISATI["DRUGASMJENAPOCETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 1));
                this.rowEVIDENCIJARADNICISATI["DRUGASMJENAZAVRSETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 2));
                reader2.Close();
            }
            else
            {
                this.rowEVIDENCIJARADNICISATI["DRUGASMJENAOPISSMJENE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowEVIDENCIJARADNICISATI["DRUGASMJENAPOCETAK"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowEVIDENCIJARADNICISATI["DRUGASMJENAZAVRSETAK"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
        }

        private void CheckIntegrityErrorsEvidencija()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDGODINE] FROM [GODINE] WITH (NOLOCK) WHERE [IDGODINE] = @IDGODINE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["IDGODINE"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new GODINEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("GODINE") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyEvidencija()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [MJESEC], [BROJEVIDENCIJE], [OPISEVIDENCIJE], [IDGODINE] FROM [EVIDENCIJA] WITH (UPDLOCK) WHERE [MJESEC] = @MJESEC AND [IDGODINE] = @IDGODINE AND [BROJEVIDENCIJE] = @BROJEVIDENCIJE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJEVIDENCIJE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["MJESEC"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["IDGODINE"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["BROJEVIDENCIJE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new EVIDENCIJADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("EVIDENCIJA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPISEVIDENCIJEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))))
                {
                    reader.Close();
                    throw new EVIDENCIJADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("EVIDENCIJA") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyEvidencijaradnici()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [MJESEC], [IDGODINE], [BROJEVIDENCIJE], [IDRADNIK] FROM [EVIDENCIJARADNICI] WITH (UPDLOCK) WHERE [MJESEC] = @MJESEC AND [IDGODINE] = @IDGODINE AND [BROJEVIDENCIJE] = @BROJEVIDENCIJE AND [IDRADNIK] = @IDRADNIK ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJEVIDENCIJE", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICI["MJESEC"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICI["IDGODINE"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICI["BROJEVIDENCIJE"]));
                command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICI["IDRADNIK"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new EVIDENCIJARADNICIDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("EVIDENCIJARADNICI") }));
                }
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new EVIDENCIJARADNICIDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("EVIDENCIJARADNICI") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyEvidencijaradnicisati()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [MJESEC], [IDGODINE], [BROJEVIDENCIJE], [IDRADNIK], [DAN], [RR], [ODTOGASMJENSKI], [ODTOGADVOKRATNI], [ODTOGAPOSEBNI1], [ODTOGAPOSEBNI2], [ODTOGAPOSEBNI3], [ODTOGAKOMBINACIJA], [ODTOGASPECIJALNA], [IZNADNORME], [PR], [SP], [GO], [BOP], [BOF], [RD], [PD], [NPD], [BLG], [ZAS], [PRV], [TR], [PRI], [NEN], [NENNEODOBRENA], [STR], [LOC], [NED], [NOC], [PRVASMJENAIDSMJENE] AS PRVASMJENAIDSMJENE, [DRUGASMJENAIDSMJENE] AS DRUGASMJENAIDSMJENE FROM [EVIDENCIJARADNICISATI] WITH (UPDLOCK) WHERE [MJESEC] = @MJESEC AND [IDGODINE] = @IDGODINE AND [BROJEVIDENCIJE] = @BROJEVIDENCIJE AND [IDRADNIK] = @IDRADNIK AND [DAN] = @DAN ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJEVIDENCIJE", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DAN", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["MJESEC"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["IDGODINE"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["BROJEVIDENCIJE"]));
                command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["IDRADNIK"]));
                command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["DAN"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new EVIDENCIJARADNICISATIDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("EVIDENCIJARADNICISATI") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !this.m__RROriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 5)))) || ((!this.m__ODTOGASMJENSKIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 6))) || !this.m__ODTOGADVOKRATNIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 7)))) || (!this.m__ODTOGAPOSEBNI1Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 8))) || !this.m__ODTOGAPOSEBNI2Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 9))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__ODTOGAPOSEBNI3Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 10)))) || ((!this.m__ODTOGAKOMBINACIJAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 11))) || !this.m__ODTOGASPECIJALNAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 12)))) || (!this.m__IZNADNORMEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 13))) || !this.m__PROriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 14))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__SPOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 15)))) || ((!this.m__GOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x10))) || !this.m__BOPOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x11)))) || (!this.m__BOFOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x12))) || !this.m__RDOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x13))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__PDOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 20)))) || ((!this.m__NPDOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x15))) || !this.m__BLGOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x16)))) || (!this.m__ZASOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x17))) || !this.m__PRVOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x18))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__TROriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x19)))) || ((!this.m__PRIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x1a))) || !this.m__NENOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x1b)))) || (!this.m__NENNEODOBRENAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x1c))) || !this.m__STROriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x1d))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__LOCOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 30)))) || ((!this.m__NEDOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x1f))) || !this.m__NOCOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x20)))) || (!this.m__PRVASMJENAIDSMJENEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x21))) || !this.m__DRUGASMJENAIDSMJENEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x22))))))
                {
                    reader.Close();
                    throw new EVIDENCIJARADNICISATIDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("EVIDENCIJARADNICISATI") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowEvidencija()
        {
            this.rowEVIDENCIJA = this.EVIDENCIJASet.EVIDENCIJA.NewEVIDENCIJARow();
        }

        private void CreateNewRowEvidencijaradnici()
        {
            this.rowEVIDENCIJARADNICI = this.EVIDENCIJASet.EVIDENCIJARADNICI.NewEVIDENCIJARADNICIRow();
        }

        private void CreateNewRowEvidencijaradnicisati()
        {
            this.rowEVIDENCIJARADNICISATI = this.EVIDENCIJASet.EVIDENCIJARADNICISATI.NewEVIDENCIJARADNICISATIRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyEvidencija();
            this.ProcessNestedLevelEvidencijaradnici();
            this.AfterConfirmEvidencija();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [EVIDENCIJA]  WHERE [MJESEC] = @MJESEC AND [IDGODINE] = @IDGODINE AND [BROJEVIDENCIJE] = @BROJEVIDENCIJE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJEVIDENCIJE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["MJESEC"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["IDGODINE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["BROJEVIDENCIJE"]));
            command.ExecuteStmt();
            this.OnEVIDENCIJAUpdated(new EVIDENCIJAEventArgs(this.rowEVIDENCIJA, StatementType.Delete));
            this.rowEVIDENCIJA.Delete();
            this.sMode264 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode264;
        }

        private void DeleteEvidencijaradnici()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyEvidencijaradnici();
            this.OnDeleteControlsEvidencijaradnici();
            this.ProcessNestedLevelEvidencijaradnicisati();
            this.AfterConfirmEvidencijaradnici();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [EVIDENCIJARADNICI]  WHERE [MJESEC] = @MJESEC AND [IDGODINE] = @IDGODINE AND [BROJEVIDENCIJE] = @BROJEVIDENCIJE AND [IDRADNIK] = @IDRADNIK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJEVIDENCIJE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICI["MJESEC"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICI["IDGODINE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICI["BROJEVIDENCIJE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICI["IDRADNIK"]));
            command.ExecuteStmt();
            this.OnEVIDENCIJARADNICIUpdated(new EVIDENCIJARADNICIEventArgs(this.rowEVIDENCIJARADNICI, StatementType.Delete));
            this.rowEVIDENCIJARADNICI.Delete();
            this.sMode265 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode265;
        }

        private void DeleteEvidencijaradnicisati()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyEvidencijaradnicisati();
            this.OnDeleteControlsEvidencijaradnicisati();
            this.AfterConfirmEvidencijaradnicisati();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [EVIDENCIJARADNICISATI]  WHERE [MJESEC] = @MJESEC AND [IDGODINE] = @IDGODINE AND [BROJEVIDENCIJE] = @BROJEVIDENCIJE AND [IDRADNIK] = @IDRADNIK AND [DAN] = @DAN", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJEVIDENCIJE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DAN", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["MJESEC"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["IDGODINE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["BROJEVIDENCIJE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["IDRADNIK"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["DAN"]));
            command.ExecuteStmt();
            this.OnEVIDENCIJARADNICISATIUpdated(new EVIDENCIJARADNICISATIEventArgs(this.rowEVIDENCIJARADNICISATI, StatementType.Delete));
            this.rowEVIDENCIJARADNICISATI.Delete();
            this.sMode266 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode266;
        }


        public virtual int Fill(EVIDENCIJADataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), short.Parse(this.fillDataParameters[1].Value.ToString()), int.Parse(this.fillDataParameters[2].Value.ToString()));
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.EVIDENCIJASet = dataSet;
                    this.LoadChildEvidencija(0, -1);
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
            this.EVIDENCIJASet = (EVIDENCIJADataSet) dataSet;
            if (this.EVIDENCIJASet != null)
            {
                return this.Fill(this.EVIDENCIJASet);
            }
            this.EVIDENCIJASet = new EVIDENCIJADataSet();
            this.Fill(this.EVIDENCIJASet);
            dataSet.Merge(this.EVIDENCIJASet);
            return 0;
        }

        public virtual int Fill(EVIDENCIJADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["MJESEC"]), Conversions.ToShort(dataRecord["IDGODINE"]), Conversions.ToInteger(dataRecord["BROJEVIDENCIJE"]));
        }

        public virtual int Fill(EVIDENCIJADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["MJESEC"]), Conversions.ToShort(dataRecord["IDGODINE"]), Conversions.ToInteger(dataRecord["BROJEVIDENCIJE"]));
        }

        public virtual int Fill(EVIDENCIJADataSet dataSet, int mJESEC, short iDGODINE, int bROJEVIDENCIJE)
        {
            if (!this.FillByMJESECIDGODINEBROJEVIDENCIJE(dataSet, mJESEC, iDGODINE, bROJEVIDENCIJE))
            {
                throw new EVIDENCIJANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("EVIDENCIJA") }));
            }
            return 0;
        }

        public virtual int FillByIDGODINE(EVIDENCIJADataSet dataSet, short iDGODINE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.EVIDENCIJASet = dataSet;
            this.rowEVIDENCIJA = this.EVIDENCIJASet.EVIDENCIJA.NewEVIDENCIJARow();
            this.rowEVIDENCIJA.IDGODINE = iDGODINE;
            try
            {
                this.LoadByIDGODINE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByMJESEC(EVIDENCIJADataSet dataSet, int mJESEC)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.EVIDENCIJASet = dataSet;
            this.rowEVIDENCIJA = this.EVIDENCIJASet.EVIDENCIJA.NewEVIDENCIJARow();
            this.rowEVIDENCIJA.MJESEC = mJESEC;
            try
            {
                this.LoadByMJESEC(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByMJESECIDGODINE(EVIDENCIJADataSet dataSet, int mJESEC, short iDGODINE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.EVIDENCIJASet = dataSet;
            this.rowEVIDENCIJA = this.EVIDENCIJASet.EVIDENCIJA.NewEVIDENCIJARow();
            this.rowEVIDENCIJA.MJESEC = mJESEC;
            this.rowEVIDENCIJA.IDGODINE = iDGODINE;
            try
            {
                this.LoadByMJESECIDGODINE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByMJESECIDGODINEBROJEVIDENCIJE(EVIDENCIJADataSet dataSet, int mJESEC, short iDGODINE, int bROJEVIDENCIJE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.EVIDENCIJASet = dataSet;
            this.rowEVIDENCIJA = this.EVIDENCIJASet.EVIDENCIJA.NewEVIDENCIJARow();
            this.rowEVIDENCIJA.MJESEC = mJESEC;
            this.rowEVIDENCIJA.IDGODINE = iDGODINE;
            this.rowEVIDENCIJA.BROJEVIDENCIJE = bROJEVIDENCIJE;
            try
            {
                this.LoadByMJESECIDGODINEBROJEVIDENCIJE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound264 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(EVIDENCIJADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.EVIDENCIJASet = dataSet;
            try
            {
                this.LoadChildEvidencija(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDGODINE(EVIDENCIJADataSet dataSet, short iDGODINE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.EVIDENCIJASet = dataSet;
            this.rowEVIDENCIJA = this.EVIDENCIJASet.EVIDENCIJA.NewEVIDENCIJARow();
            this.rowEVIDENCIJA.IDGODINE = iDGODINE;
            try
            {
                this.LoadByIDGODINE(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByMJESEC(EVIDENCIJADataSet dataSet, int mJESEC, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.EVIDENCIJASet = dataSet;
            this.rowEVIDENCIJA = this.EVIDENCIJASet.EVIDENCIJA.NewEVIDENCIJARow();
            this.rowEVIDENCIJA.MJESEC = mJESEC;
            try
            {
                this.LoadByMJESEC(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByMJESECIDGODINE(EVIDENCIJADataSet dataSet, int mJESEC, short iDGODINE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.EVIDENCIJASet = dataSet;
            this.rowEVIDENCIJA = this.EVIDENCIJASet.EVIDENCIJA.NewEVIDENCIJARow();
            this.rowEVIDENCIJA.MJESEC = mJESEC;
            this.rowEVIDENCIJA.IDGODINE = iDGODINE;
            try
            {
                this.LoadByMJESECIDGODINE(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [MJESEC], [BROJEVIDENCIJE], [OPISEVIDENCIJE], [IDGODINE] FROM [EVIDENCIJA] WITH (NOLOCK) WHERE [MJESEC] = @MJESEC AND [IDGODINE] = @IDGODINE AND [BROJEVIDENCIJE] = @BROJEVIDENCIJE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJEVIDENCIJE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["MJESEC"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["IDGODINE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["BROJEVIDENCIJE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound264 = 1;
                this.rowEVIDENCIJA["MJESEC"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowEVIDENCIJA["BROJEVIDENCIJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 1));
                this.rowEVIDENCIJA["OPISEVIDENCIJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowEVIDENCIJA["IDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 3));
                this.sMode264 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode264;
            }
            else
            {
                this.RcdFound264 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = "MJESEC";
                parameter.DbType = DbType.Int32;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "IDGODINE";
                parameter2.DbType = DbType.Int16;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "BROJEVIDENCIJE";
                parameter3.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmEVIDENCIJASelect4 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [EVIDENCIJA] WITH (NOLOCK) ", false);
            this.EVIDENCIJASelect4 = this.cmEVIDENCIJASelect4.FetchData();
            if (this.EVIDENCIJASelect4.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.EVIDENCIJASelect4.GetInt32(0);
            }
            this.EVIDENCIJASelect4.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDGODINE(short iDGODINE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmEVIDENCIJASelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [EVIDENCIJA] WITH (NOLOCK) WHERE [IDGODINE] = @IDGODINE ", false);
            if (this.cmEVIDENCIJASelect3.IDbCommand.Parameters.Count == 0)
            {
                this.cmEVIDENCIJASelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            this.cmEVIDENCIJASelect3.SetParameter(0, iDGODINE);
            this.EVIDENCIJASelect3 = this.cmEVIDENCIJASelect3.FetchData();
            if (this.EVIDENCIJASelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.EVIDENCIJASelect3.GetInt32(0);
            }
            this.EVIDENCIJASelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByMJESEC(int mJESEC)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmEVIDENCIJASelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [EVIDENCIJA] WITH (NOLOCK) WHERE [MJESEC] = @MJESEC ", false);
            if (this.cmEVIDENCIJASelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmEVIDENCIJASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
            }
            this.cmEVIDENCIJASelect2.SetParameter(0, mJESEC);
            this.EVIDENCIJASelect2 = this.cmEVIDENCIJASelect2.FetchData();
            if (this.EVIDENCIJASelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.EVIDENCIJASelect2.GetInt32(0);
            }
            this.EVIDENCIJASelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByMJESECIDGODINE(int mJESEC, short iDGODINE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmEVIDENCIJASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [EVIDENCIJA] WITH (NOLOCK) WHERE [MJESEC] = @MJESEC and [IDGODINE] = @IDGODINE ", false);
            if (this.cmEVIDENCIJASelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmEVIDENCIJASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                this.cmEVIDENCIJASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            this.cmEVIDENCIJASelect1.SetParameter(0, mJESEC);
            this.cmEVIDENCIJASelect1.SetParameter(1, iDGODINE);
            this.EVIDENCIJASelect1 = this.cmEVIDENCIJASelect1.FetchData();
            if (this.EVIDENCIJASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.EVIDENCIJASelect1.GetInt32(0);
            }
            this.EVIDENCIJASelect1.Close();
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

        public virtual int GetRecordCountByIDGODINE(short iDGODINE)
        {
            int internalRecordCountByIDGODINE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDGODINE = this.GetInternalRecordCountByIDGODINE(iDGODINE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDGODINE;
        }

        public virtual int GetRecordCountByMJESEC(int mJESEC)
        {
            int internalRecordCountByMJESEC;
            try
            {
                this.InitializeMembers();
                internalRecordCountByMJESEC = this.GetInternalRecordCountByMJESEC(mJESEC);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByMJESEC;
        }

        public virtual int GetRecordCountByMJESECIDGODINE(int mJESEC, short iDGODINE)
        {
            int internalRecordCountByMJESECIDGODINE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByMJESECIDGODINE = this.GetInternalRecordCountByMJESECIDGODINE(mJESEC, iDGODINE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByMJESECIDGODINE;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound264 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__RROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ODTOGASMJENSKIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ODTOGADVOKRATNIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ODTOGAPOSEBNI1Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__ODTOGAPOSEBNI2Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__ODTOGAPOSEBNI3Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__ODTOGAKOMBINACIJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ODTOGASPECIJALNAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IZNADNORMEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SPOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__GOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BOPOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BOFOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__RDOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PDOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NPDOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BLGOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZASOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRVOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__TROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NENOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NENNEODOBRENAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__STROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__LOCOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NEDOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NOCOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRVASMJENAIDSMJENEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DRUGASMJENAIDSMJENEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove29 = false;
            this._Condition = false;
            this.RcdFound266 = 0;
            this.m_SubSelTopString266 = "";
            this.RcdFound265 = 0;
            this.m_SubSelTopString265 = "";
            this.m__OPISEVIDENCIJEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.EVIDENCIJASet = new EVIDENCIJADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertEvidencija()
        {
            this.CheckOptimisticConcurrencyEvidencija();
            this.AfterConfirmEvidencija();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [EVIDENCIJA] ([MJESEC], [BROJEVIDENCIJE], [OPISEVIDENCIJE], [IDGODINE]) VALUES (@MJESEC, @BROJEVIDENCIJE, @OPISEVIDENCIJE, @IDGODINE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJEVIDENCIJE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISEVIDENCIJE", DbType.String, 40));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["MJESEC"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["BROJEVIDENCIJE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["OPISEVIDENCIJE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["IDGODINE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new EVIDENCIJADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsEvidencija();
            }
            this.OnEVIDENCIJAUpdated(new EVIDENCIJAEventArgs(this.rowEVIDENCIJA, StatementType.Insert));
            this.ProcessLevelEvidencija();
        }

        private void InsertEvidencijaradnici()
        {
            this.CheckOptimisticConcurrencyEvidencijaradnici();
            this.CheckExtendedTableEvidencijaradnici();
            this.AfterConfirmEvidencijaradnici();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [EVIDENCIJARADNICI] ([MJESEC], [IDGODINE], [BROJEVIDENCIJE], [IDRADNIK]) VALUES (@MJESEC, @IDGODINE, @BROJEVIDENCIJE, @IDRADNIK)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJEVIDENCIJE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICI["MJESEC"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICI["IDGODINE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICI["BROJEVIDENCIJE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICI["IDRADNIK"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new EVIDENCIJARADNICIDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnEVIDENCIJARADNICIUpdated(new EVIDENCIJARADNICIEventArgs(this.rowEVIDENCIJARADNICI, StatementType.Insert));
            this.ProcessLevelEvidencijaradnici();
        }

        private void InsertEvidencijaradnicisati()
        {
            this.CheckOptimisticConcurrencyEvidencijaradnicisati();
            this.CheckExtendedTableEvidencijaradnicisati();
            this.AfterConfirmEvidencijaradnicisati();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [EVIDENCIJARADNICISATI] ([MJESEC], [IDGODINE], [BROJEVIDENCIJE], [IDRADNIK], [DAN], [RR], [ODTOGASMJENSKI], [ODTOGADVOKRATNI], [ODTOGAPOSEBNI1], [ODTOGAPOSEBNI2], [ODTOGAPOSEBNI3], [ODTOGAKOMBINACIJA], [ODTOGASPECIJALNA], [IZNADNORME], [PR], [SP], [GO], [BOP], [BOF], [RD], [PD], [NPD], [BLG], [ZAS], [PRV], [TR], [PRI], [NEN], [NENNEODOBRENA], [STR], [LOC], [NED], [NOC], [PRVASMJENAIDSMJENE], [DRUGASMJENAIDSMJENE]) VALUES (@MJESEC, @IDGODINE, @BROJEVIDENCIJE, @IDRADNIK, @DAN, @RR, @ODTOGASMJENSKI, @ODTOGADVOKRATNI, @ODTOGAPOSEBNI1, @ODTOGAPOSEBNI2, @ODTOGAPOSEBNI3, @ODTOGAKOMBINACIJA, @ODTOGASPECIJALNA, @IZNADNORME, @PR, @SP, @GO, @BOP, @BOF, @RD, @PD, @NPD, @BLG, @ZAS, @PRV, @TR, @PRI, @NEN, @NENNEODOBRENA, @STR, @LOC, @NED, @NOC, @PRVASMJENAIDSMJENE, @DRUGASMJENAIDSMJENE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJEVIDENCIJE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DAN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RR", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODTOGASMJENSKI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODTOGADVOKRATNI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODTOGAPOSEBNI1", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODTOGAPOSEBNI2", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODTOGAPOSEBNI3", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODTOGAKOMBINACIJA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODTOGASPECIJALNA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZNADNORME", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PR", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SP", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BOP", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BOF", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RD", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PD", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NPD", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLG", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRV", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TR", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NEN", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NENNEODOBRENA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STR", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@LOC", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NED", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NOC", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRVASMJENAIDSMJENE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DRUGASMJENAIDSMJENE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["MJESEC"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["IDGODINE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["BROJEVIDENCIJE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["IDRADNIK"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["DAN"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["RR"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGASMJENSKI"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGADVOKRATNI"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGAPOSEBNI1"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGAPOSEBNI2"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGAPOSEBNI3"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGAKOMBINACIJA"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGASPECIJALNA"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["IZNADNORME"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PR"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["SP"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["GO"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["BOP"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["BOF"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["RD"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PD"]));
            command.SetParameter(0x15, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NPD"]));
            command.SetParameter(0x16, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["BLG"]));
            command.SetParameter(0x17, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ZAS"]));
            command.SetParameter(0x18, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PRV"]));
            command.SetParameter(0x19, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["TR"]));
            command.SetParameter(0x1a, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PRI"]));
            command.SetParameter(0x1b, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NEN"]));
            command.SetParameter(0x1c, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NENNEODOBRENA"]));
            command.SetParameter(0x1d, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["STR"]));
            command.SetParameter(30, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["LOC"]));
            command.SetParameter(0x1f, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NED"]));
            command.SetParameter(0x20, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NOC"]));
            command.SetParameter(0x21, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PRVASMJENAIDSMJENE"]));
            command.SetParameter(0x22, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["DRUGASMJENAIDSMJENE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new EVIDENCIJARADNICISATIDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnEVIDENCIJARADNICISATIUpdated(new EVIDENCIJARADNICISATIEventArgs(this.rowEVIDENCIJARADNICISATI, StatementType.Insert));
        }

        private void LoadByIDGODINE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.EVIDENCIJASet.EnforceConstraints;
            this.EVIDENCIJASet.EVIDENCIJARADNICISATI.BeginLoadData();
            this.EVIDENCIJASet.EVIDENCIJARADNICI.BeginLoadData();
            this.EVIDENCIJASet.EVIDENCIJA.BeginLoadData();
            this.ScanByIDGODINE(startRow, maxRows);
            this.EVIDENCIJASet.EVIDENCIJARADNICISATI.EndLoadData();
            this.EVIDENCIJASet.EVIDENCIJARADNICI.EndLoadData();
            this.EVIDENCIJASet.EVIDENCIJA.EndLoadData();
            this.EVIDENCIJASet.EnforceConstraints = enforceConstraints;
            if (this.EVIDENCIJASet.EVIDENCIJA.Count > 0)
            {
                this.rowEVIDENCIJA = this.EVIDENCIJASet.EVIDENCIJA[this.EVIDENCIJASet.EVIDENCIJA.Count - 1];
            }
        }

        private void LoadByMJESEC(int startRow, int maxRows)
        {
            bool enforceConstraints = this.EVIDENCIJASet.EnforceConstraints;
            this.EVIDENCIJASet.EVIDENCIJARADNICISATI.BeginLoadData();
            this.EVIDENCIJASet.EVIDENCIJARADNICI.BeginLoadData();
            this.EVIDENCIJASet.EVIDENCIJA.BeginLoadData();
            this.ScanByMJESEC(startRow, maxRows);
            this.EVIDENCIJASet.EVIDENCIJARADNICISATI.EndLoadData();
            this.EVIDENCIJASet.EVIDENCIJARADNICI.EndLoadData();
            this.EVIDENCIJASet.EVIDENCIJA.EndLoadData();
            this.EVIDENCIJASet.EnforceConstraints = enforceConstraints;
            if (this.EVIDENCIJASet.EVIDENCIJA.Count > 0)
            {
                this.rowEVIDENCIJA = this.EVIDENCIJASet.EVIDENCIJA[this.EVIDENCIJASet.EVIDENCIJA.Count - 1];
            }
        }

        private void LoadByMJESECIDGODINE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.EVIDENCIJASet.EnforceConstraints;
            this.EVIDENCIJASet.EVIDENCIJARADNICISATI.BeginLoadData();
            this.EVIDENCIJASet.EVIDENCIJARADNICI.BeginLoadData();
            this.EVIDENCIJASet.EVIDENCIJA.BeginLoadData();
            this.ScanByMJESECIDGODINE(startRow, maxRows);
            this.EVIDENCIJASet.EVIDENCIJARADNICISATI.EndLoadData();
            this.EVIDENCIJASet.EVIDENCIJARADNICI.EndLoadData();
            this.EVIDENCIJASet.EVIDENCIJA.EndLoadData();
            this.EVIDENCIJASet.EnforceConstraints = enforceConstraints;
            if (this.EVIDENCIJASet.EVIDENCIJA.Count > 0)
            {
                this.rowEVIDENCIJA = this.EVIDENCIJASet.EVIDENCIJA[this.EVIDENCIJASet.EVIDENCIJA.Count - 1];
            }
        }

        private void LoadByMJESECIDGODINEBROJEVIDENCIJE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.EVIDENCIJASet.EnforceConstraints;
            this.EVIDENCIJASet.EVIDENCIJARADNICISATI.BeginLoadData();
            this.EVIDENCIJASet.EVIDENCIJARADNICI.BeginLoadData();
            this.EVIDENCIJASet.EVIDENCIJA.BeginLoadData();
            this.ScanByMJESECIDGODINEBROJEVIDENCIJE(startRow, maxRows);
            this.EVIDENCIJASet.EVIDENCIJARADNICISATI.EndLoadData();
            this.EVIDENCIJASet.EVIDENCIJARADNICI.EndLoadData();
            this.EVIDENCIJASet.EVIDENCIJA.EndLoadData();
            this.EVIDENCIJASet.EnforceConstraints = enforceConstraints;
            if (this.EVIDENCIJASet.EVIDENCIJA.Count > 0)
            {
                this.rowEVIDENCIJA = this.EVIDENCIJASet.EVIDENCIJA[this.EVIDENCIJASet.EVIDENCIJA.Count - 1];
            }
        }

        private void LoadChildEvidencija(int startRow, int maxRows)
        {
            this.CreateNewRowEvidencija();
            bool enforceConstraints = this.EVIDENCIJASet.EnforceConstraints;
            this.EVIDENCIJASet.EVIDENCIJARADNICISATI.BeginLoadData();
            this.EVIDENCIJASet.EVIDENCIJARADNICI.BeginLoadData();
            this.EVIDENCIJASet.EVIDENCIJA.BeginLoadData();
            this.ScanStartEvidencija(startRow, maxRows);
            this.EVIDENCIJASet.EVIDENCIJARADNICISATI.EndLoadData();
            this.EVIDENCIJASet.EVIDENCIJARADNICI.EndLoadData();
            this.EVIDENCIJASet.EVIDENCIJA.EndLoadData();
            this.EVIDENCIJASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildEvidencijaradnici()
        {
            this.CreateNewRowEvidencijaradnici();
            this.ScanStartEvidencijaradnici();
        }

        private void LoadChildEvidencijaradnicisati()
        {
            this.CreateNewRowEvidencijaradnicisati();
            this.ScanStartEvidencijaradnicisati();
        }

        private void LoadDataEvidencija(int maxRows)
        {
            int num = 0;
            if (this.RcdFound264 != 0)
            {
                this.ScanLoadEvidencija();
                while ((this.RcdFound264 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowEvidencija();
                    this.CreateNewRowEvidencija();
                    this.ScanNextEvidencija();
                }
            }
            if (num > 0)
            {
                this.RcdFound264 = 1;
            }
            this.ScanEndEvidencija();
            if (this.EVIDENCIJASet.EVIDENCIJA.Count > 0)
            {
                this.rowEVIDENCIJA = this.EVIDENCIJASet.EVIDENCIJA[this.EVIDENCIJASet.EVIDENCIJA.Count - 1];
            }
        }

        private void LoadDataEvidencijaradnici()
        {
            while (this.RcdFound265 != 0)
            {
                this.LoadRowEvidencijaradnici();
                this.CreateNewRowEvidencijaradnici();
                this.ScanNextEvidencijaradnici();
            }
            this.ScanEndEvidencijaradnici();
        }

        private void LoadDataEvidencijaradnicisati()
        {
            while (this.RcdFound266 != 0)
            {
                this.LoadRowEvidencijaradnicisati();
                this.CreateNewRowEvidencijaradnicisati();
                this.ScanNextEvidencijaradnicisati();
            }
            this.ScanEndEvidencijaradnicisati();
        }

        private void LoadRowEvidencija()
        {
            this.AddRowEvidencija();
        }

        private void LoadRowEvidencijaradnici()
        {
            this.AddRowEvidencijaradnici();
        }

        private void LoadRowEvidencijaradnicisati()
        {
            this.AddRowEvidencijaradnicisati();
        }

        private void OnDeleteControlsEvidencijaradnici()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [PREZIME], [IME], [TJEDNIFONDSATI], [AKTIVAN] FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICI["IDRADNIK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowEVIDENCIJARADNICI["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowEVIDENCIJARADNICI["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowEVIDENCIJARADNICI["TJEDNIFONDSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
                this.rowEVIDENCIJARADNICI["AKTIVAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 3));
            }
            reader.Close();
        }

        private void OnDeleteControlsEvidencijaradnicisati()
        {
            if (!this.rowEVIDENCIJARADNICISATI.IsPRVASMJENAIDSMJENENull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [OPISSMJENE] AS PRVASMJENAOPISSMJENE, [POCETAK] AS PRVASMJENAPOCETAK, [ZAVRSETAK] AS PRVASMJENAZAVRSETAK FROM [SMJENE] WITH (NOLOCK) WHERE [IDSMJENE] = @PRVASMJENAIDSMJENE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRVASMJENAIDSMJENE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PRVASMJENAIDSMJENE"]));
                IDataReader reader = command.FetchData();
                if (command.HasMoreRows)
                {
                    this.rowEVIDENCIJARADNICISATI["PRVASMJENAOPISSMJENE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                    this.rowEVIDENCIJARADNICISATI["PRVASMJENAPOCETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                    this.rowEVIDENCIJARADNICISATI["PRVASMJENAZAVRSETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                }
                reader.Close();
            }
            else
            {
                this.rowEVIDENCIJARADNICISATI["PRVASMJENAOPISSMJENE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowEVIDENCIJARADNICISATI["PRVASMJENAPOCETAK"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowEVIDENCIJARADNICISATI["PRVASMJENAZAVRSETAK"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowEVIDENCIJARADNICISATI.IsDRUGASMJENAIDSMJENENull())
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [OPISSMJENE] AS DRUGASMJENAOPISSMJENE, [POCETAK] AS DRUGASMJENAPOCETAK, [ZAVRSETAK] AS DRUGASMJENAZAVRSETAK FROM [SMJENE] WITH (NOLOCK) WHERE [IDSMJENE] = @DRUGASMJENAIDSMJENE ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DRUGASMJENAIDSMJENE", DbType.Int32));
                }
                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["DRUGASMJENAIDSMJENE"]));
                IDataReader reader2 = command2.FetchData();
                if (command2.HasMoreRows)
                {
                    this.rowEVIDENCIJARADNICISATI["DRUGASMJENAOPISSMJENE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                    this.rowEVIDENCIJARADNICISATI["DRUGASMJENAPOCETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 1));
                    this.rowEVIDENCIJARADNICISATI["DRUGASMJENAZAVRSETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 2));
                }
                reader2.Close();
            }
            else
            {
                this.rowEVIDENCIJARADNICISATI["DRUGASMJENAOPISSMJENE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowEVIDENCIJARADNICISATI["DRUGASMJENAPOCETAK"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowEVIDENCIJARADNICISATI["DRUGASMJENAZAVRSETAK"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
        }

        private void OnEVIDENCIJARADNICISATIUpdated(EVIDENCIJARADNICISATIEventArgs e)
        {
            if (this.EVIDENCIJARADNICISATIUpdated != null)
            {
                EVIDENCIJARADNICISATIUpdateEventHandler eVIDENCIJARADNICISATIUpdatedEvent = this.EVIDENCIJARADNICISATIUpdated;
                if (eVIDENCIJARADNICISATIUpdatedEvent != null)
                {
                    eVIDENCIJARADNICISATIUpdatedEvent(this, e);
                }
            }
        }

        private void OnEVIDENCIJARADNICISATIUpdating(EVIDENCIJARADNICISATIEventArgs e)
        {
            if (this.EVIDENCIJARADNICISATIUpdating != null)
            {
                EVIDENCIJARADNICISATIUpdateEventHandler eVIDENCIJARADNICISATIUpdatingEvent = this.EVIDENCIJARADNICISATIUpdating;
                if (eVIDENCIJARADNICISATIUpdatingEvent != null)
                {
                    eVIDENCIJARADNICISATIUpdatingEvent(this, e);
                }
            }
        }

        private void OnEVIDENCIJARADNICIUpdated(EVIDENCIJARADNICIEventArgs e)
        {
            if (this.EVIDENCIJARADNICIUpdated != null)
            {
                EVIDENCIJARADNICIUpdateEventHandler eVIDENCIJARADNICIUpdatedEvent = this.EVIDENCIJARADNICIUpdated;
                if (eVIDENCIJARADNICIUpdatedEvent != null)
                {
                    eVIDENCIJARADNICIUpdatedEvent(this, e);
                }
            }
        }

        private void OnEVIDENCIJARADNICIUpdating(EVIDENCIJARADNICIEventArgs e)
        {
            if (this.EVIDENCIJARADNICIUpdating != null)
            {
                EVIDENCIJARADNICIUpdateEventHandler eVIDENCIJARADNICIUpdatingEvent = this.EVIDENCIJARADNICIUpdating;
                if (eVIDENCIJARADNICIUpdatingEvent != null)
                {
                    eVIDENCIJARADNICIUpdatingEvent(this, e);
                }
            }
        }

        private void OnEVIDENCIJAUpdated(EVIDENCIJAEventArgs e)
        {
            if (this.EVIDENCIJAUpdated != null)
            {
                EVIDENCIJAUpdateEventHandler eVIDENCIJAUpdatedEvent = this.EVIDENCIJAUpdated;
                if (eVIDENCIJAUpdatedEvent != null)
                {
                    eVIDENCIJAUpdatedEvent(this, e);
                }
            }
        }

        private void OnEVIDENCIJAUpdating(EVIDENCIJAEventArgs e)
        {
            if (this.EVIDENCIJAUpdating != null)
            {
                EVIDENCIJAUpdateEventHandler eVIDENCIJAUpdatingEvent = this.EVIDENCIJAUpdating;
                if (eVIDENCIJAUpdatingEvent != null)
                {
                    eVIDENCIJAUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelEvidencija()
        {
            this.sMode264 = this.Gx_mode;
            this.ProcessNestedLevelEvidencijaradnici();
            this.Gx_mode = this.sMode264;
        }

        private void ProcessLevelEvidencijaradnici()
        {
            this.sMode265 = this.Gx_mode;
            this.ProcessNestedLevelEvidencijaradnicisati();
            this.Gx_mode = this.sMode265;
        }

        private void ProcessNestedLevelEvidencijaradnici()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.EVIDENCIJASet.EVIDENCIJARADNICI.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowEVIDENCIJARADNICI = (EVIDENCIJADataSet.EVIDENCIJARADNICIRow) current;
                    if (Helpers.IsRowChanged(this.rowEVIDENCIJARADNICI))
                    {
                        bool flag = false;
                        if (this.rowEVIDENCIJARADNICI.RowState != DataRowState.Deleted)
                        {
                            flag = ((this.rowEVIDENCIJARADNICI.MJESEC == this.rowEVIDENCIJA.MJESEC) && (this.rowEVIDENCIJARADNICI.IDGODINE == this.rowEVIDENCIJA.IDGODINE)) && (this.rowEVIDENCIJARADNICI.BROJEVIDENCIJE == this.rowEVIDENCIJA.BROJEVIDENCIJE);
                        }
                        else
                        {
                            flag = (this.rowEVIDENCIJARADNICI["MJESEC", DataRowVersion.Original].Equals(this.rowEVIDENCIJA.MJESEC) && this.rowEVIDENCIJARADNICI["IDGODINE", DataRowVersion.Original].Equals(this.rowEVIDENCIJA.IDGODINE)) && this.rowEVIDENCIJARADNICI["BROJEVIDENCIJE", DataRowVersion.Original].Equals(this.rowEVIDENCIJA.BROJEVIDENCIJE);
                        }
                        if (flag)
                        {
                            this.ReadRowEvidencijaradnici();
                            if (this.rowEVIDENCIJARADNICI.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertEvidencijaradnici();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteEvidencijaradnici();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateEvidencijaradnici();
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

        private void ProcessNestedLevelEvidencijaradnicisati()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.EVIDENCIJASet.EVIDENCIJARADNICISATI.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowEVIDENCIJARADNICISATI = (EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow) current;
                    if (Helpers.IsRowChanged(this.rowEVIDENCIJARADNICISATI))
                    {
                        bool flag = false;
                        if (this.rowEVIDENCIJARADNICISATI.RowState != DataRowState.Deleted)
                        {
                            flag = ((this.rowEVIDENCIJARADNICISATI.MJESEC == this.rowEVIDENCIJARADNICI.MJESEC) && (this.rowEVIDENCIJARADNICISATI.IDGODINE == this.rowEVIDENCIJARADNICI.IDGODINE)) && ((this.rowEVIDENCIJARADNICISATI.BROJEVIDENCIJE == this.rowEVIDENCIJARADNICI.BROJEVIDENCIJE) && (this.rowEVIDENCIJARADNICISATI.IDRADNIK == this.rowEVIDENCIJARADNICI.IDRADNIK));
                        }
                        else
                        {
                            flag = (this.rowEVIDENCIJARADNICISATI["MJESEC", DataRowVersion.Original].Equals(this.rowEVIDENCIJARADNICI.MJESEC) && this.rowEVIDENCIJARADNICISATI["IDGODINE", DataRowVersion.Original].Equals(this.rowEVIDENCIJARADNICI.IDGODINE)) && (this.rowEVIDENCIJARADNICISATI["BROJEVIDENCIJE", DataRowVersion.Original].Equals(this.rowEVIDENCIJARADNICI.BROJEVIDENCIJE) && this.rowEVIDENCIJARADNICISATI["IDRADNIK", DataRowVersion.Original].Equals(this.rowEVIDENCIJARADNICI.IDRADNIK));
                        }
                        if (flag)
                        {
                            this.ReadRowEvidencijaradnicisati();
                            if (this.rowEVIDENCIJARADNICISATI.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertEvidencijaradnicisati();
                            }
                            else
                            {
                                if (this._Gxremove29)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteEvidencijaradnicisati();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateEvidencijaradnicisati();
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

        private void ReadRowEvidencija()
        {
            this.Gx_mode = Mode.FromRowState(this.rowEVIDENCIJA.RowState);
            if (this.rowEVIDENCIJA.RowState != DataRowState.Added)
            {
                this.m__OPISEVIDENCIJEOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["OPISEVIDENCIJE", DataRowVersion.Original]);
            }
            else
            {
                this.m__OPISEVIDENCIJEOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["OPISEVIDENCIJE"]);
            }
            this._Gxremove = this.rowEVIDENCIJA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowEVIDENCIJA = (EVIDENCIJADataSet.EVIDENCIJARow) DataSetUtil.CloneOriginalDataRow(this.rowEVIDENCIJA);
            }
        }

        private void ReadRowEvidencijaradnici()
        {
            this.Gx_mode = Mode.FromRowState(this.rowEVIDENCIJARADNICI.RowState);
            if (this.rowEVIDENCIJARADNICI.RowState == DataRowState.Added)
            {
            }
            this._Gxremove = this.rowEVIDENCIJARADNICI.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowEVIDENCIJARADNICI = (EVIDENCIJADataSet.EVIDENCIJARADNICIRow) DataSetUtil.CloneOriginalDataRow(this.rowEVIDENCIJARADNICI);
            }
        }

        private void ReadRowEvidencijaradnicisati()
        {
            this.Gx_mode = Mode.FromRowState(this.rowEVIDENCIJARADNICISATI.RowState);
            if (this.rowEVIDENCIJARADNICISATI.RowState != DataRowState.Added)
            {
                this.m__RROriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["RR", DataRowVersion.Original]);
                this.m__ODTOGASMJENSKIOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGASMJENSKI", DataRowVersion.Original]);
                this.m__ODTOGADVOKRATNIOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGADVOKRATNI", DataRowVersion.Original]);
                this.m__ODTOGAPOSEBNI1Original = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGAPOSEBNI1", DataRowVersion.Original]);
                this.m__ODTOGAPOSEBNI2Original = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGAPOSEBNI2", DataRowVersion.Original]);
                this.m__ODTOGAPOSEBNI3Original = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGAPOSEBNI3", DataRowVersion.Original]);
                this.m__ODTOGAKOMBINACIJAOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGAKOMBINACIJA", DataRowVersion.Original]);
                this.m__ODTOGASPECIJALNAOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGASPECIJALNA", DataRowVersion.Original]);
                this.m__IZNADNORMEOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["IZNADNORME", DataRowVersion.Original]);
                this.m__PROriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PR", DataRowVersion.Original]);
                this.m__SPOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["SP", DataRowVersion.Original]);
                this.m__GOOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["GO", DataRowVersion.Original]);
                this.m__BOPOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["BOP", DataRowVersion.Original]);
                this.m__BOFOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["BOF", DataRowVersion.Original]);
                this.m__RDOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["RD", DataRowVersion.Original]);
                this.m__PDOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PD", DataRowVersion.Original]);
                this.m__NPDOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NPD", DataRowVersion.Original]);
                this.m__BLGOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["BLG", DataRowVersion.Original]);
                this.m__ZASOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ZAS", DataRowVersion.Original]);
                this.m__PRVOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PRV", DataRowVersion.Original]);
                this.m__TROriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["TR", DataRowVersion.Original]);
                this.m__PRIOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PRI", DataRowVersion.Original]);
                this.m__NENOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NEN", DataRowVersion.Original]);
                this.m__NENNEODOBRENAOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NENNEODOBRENA", DataRowVersion.Original]);
                this.m__STROriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["STR", DataRowVersion.Original]);
                this.m__LOCOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["LOC", DataRowVersion.Original]);
                this.m__NEDOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NED", DataRowVersion.Original]);
                this.m__NOCOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NOC", DataRowVersion.Original]);
                this.m__PRVASMJENAIDSMJENEOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PRVASMJENAIDSMJENE", DataRowVersion.Original]);
                this.m__DRUGASMJENAIDSMJENEOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["DRUGASMJENAIDSMJENE", DataRowVersion.Original]);
            }
            else
            {
                this.m__RROriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["RR"]);
                this.m__ODTOGASMJENSKIOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGASMJENSKI"]);
                this.m__ODTOGADVOKRATNIOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGADVOKRATNI"]);
                this.m__ODTOGAPOSEBNI1Original = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGAPOSEBNI1"]);
                this.m__ODTOGAPOSEBNI2Original = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGAPOSEBNI2"]);
                this.m__ODTOGAPOSEBNI3Original = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGAPOSEBNI3"]);
                this.m__ODTOGAKOMBINACIJAOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGAKOMBINACIJA"]);
                this.m__ODTOGASPECIJALNAOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGASPECIJALNA"]);
                this.m__IZNADNORMEOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["IZNADNORME"]);
                this.m__PROriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PR"]);
                this.m__SPOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["SP"]);
                this.m__GOOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["GO"]);
                this.m__BOPOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["BOP"]);
                this.m__BOFOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["BOF"]);
                this.m__RDOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["RD"]);
                this.m__PDOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PD"]);
                this.m__NPDOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NPD"]);
                this.m__BLGOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["BLG"]);
                this.m__ZASOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ZAS"]);
                this.m__PRVOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PRV"]);
                this.m__TROriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["TR"]);
                this.m__PRIOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PRI"]);
                this.m__NENOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NEN"]);
                this.m__NENNEODOBRENAOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NENNEODOBRENA"]);
                this.m__STROriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["STR"]);
                this.m__LOCOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["LOC"]);
                this.m__NEDOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NED"]);
                this.m__NOCOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NOC"]);
                this.m__PRVASMJENAIDSMJENEOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PRVASMJENAIDSMJENE"]);
                this.m__DRUGASMJENAIDSMJENEOriginal = RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["DRUGASMJENAIDSMJENE"]);
            }
            this._Gxremove29 = this.rowEVIDENCIJARADNICISATI.RowState == DataRowState.Deleted;
            if (this._Gxremove29)
            {
                this.rowEVIDENCIJARADNICISATI = (EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow) DataSetUtil.CloneOriginalDataRow(this.rowEVIDENCIJARADNICISATI);
            }
        }

        private void ScanByIDGODINE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDGODINE] = @IDGODINE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString264 + "  FROM [EVIDENCIJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString264, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE] ) AS DK_PAGENUM   FROM [EVIDENCIJA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString264 + " FROM [EVIDENCIJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE] ";
            }
            this.cmEVIDENCIJASelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmEVIDENCIJASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmEVIDENCIJASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            this.cmEVIDENCIJASelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["IDGODINE"]));
            this.EVIDENCIJASelect7 = this.cmEVIDENCIJASelect7.FetchData();
            this.RcdFound264 = 0;
            this.ScanLoadEvidencija();
            this.LoadDataEvidencija(maxRows);
            if (this.RcdFound264 > 0)
            {
                this.SubLvlScanStartEvidencijaradnici(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDGODINEEvidencija(this.cmEVIDENCIJARADNICISelect2);
                this.SubLvlFetchEvidencijaradnici();
                this.SubLoadDataEvidencijaradnici();
                this.SubLvlScanStartEvidencijaradnicisati(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDGODINEEvidencija(this.cmEVIDENCIJARADNICISATISelect2);
                this.SubLvlFetchEvidencijaradnicisati();
                this.SubLoadDataEvidencijaradnicisati();
            }
        }

        private void ScanByMJESEC(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[MJESEC] = @MJESEC";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString264 + "  FROM [EVIDENCIJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString264, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE] ) AS DK_PAGENUM   FROM [EVIDENCIJA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString264 + " FROM [EVIDENCIJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE] ";
            }
            this.cmEVIDENCIJASelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmEVIDENCIJASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmEVIDENCIJASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
            }
            this.cmEVIDENCIJASelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["MJESEC"]));
            this.EVIDENCIJASelect7 = this.cmEVIDENCIJASelect7.FetchData();
            this.RcdFound264 = 0;
            this.ScanLoadEvidencija();
            this.LoadDataEvidencija(maxRows);
            if (this.RcdFound264 > 0)
            {
                this.SubLvlScanStartEvidencijaradnici(this.m_WhereString, startRow, maxRows);
                this.SetParametersMJESECEvidencija(this.cmEVIDENCIJARADNICISelect2);
                this.SubLvlFetchEvidencijaradnici();
                this.SubLoadDataEvidencijaradnici();
                this.SubLvlScanStartEvidencijaradnicisati(this.m_WhereString, startRow, maxRows);
                this.SetParametersMJESECEvidencija(this.cmEVIDENCIJARADNICISATISelect2);
                this.SubLvlFetchEvidencijaradnicisati();
                this.SubLoadDataEvidencijaradnicisati();
            }
        }

        private void ScanByMJESECIDGODINE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[MJESEC] = @MJESEC and TM1.[IDGODINE] = @IDGODINE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString264 + "  FROM [EVIDENCIJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString264, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE] ) AS DK_PAGENUM   FROM [EVIDENCIJA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString264 + " FROM [EVIDENCIJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE] ";
            }
            this.cmEVIDENCIJASelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmEVIDENCIJASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmEVIDENCIJASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                this.cmEVIDENCIJASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            this.cmEVIDENCIJASelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["MJESEC"]));
            this.cmEVIDENCIJASelect7.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["IDGODINE"]));
            this.EVIDENCIJASelect7 = this.cmEVIDENCIJASelect7.FetchData();
            this.RcdFound264 = 0;
            this.ScanLoadEvidencija();
            this.LoadDataEvidencija(maxRows);
            if (this.RcdFound264 > 0)
            {
                this.SubLvlScanStartEvidencijaradnici(this.m_WhereString, startRow, maxRows);
                this.SetParametersMJESECIDGODINEEvidencija(this.cmEVIDENCIJARADNICISelect2);
                this.SubLvlFetchEvidencijaradnici();
                this.SubLoadDataEvidencijaradnici();
                this.SubLvlScanStartEvidencijaradnicisati(this.m_WhereString, startRow, maxRows);
                this.SetParametersMJESECIDGODINEEvidencija(this.cmEVIDENCIJARADNICISATISelect2);
                this.SubLvlFetchEvidencijaradnicisati();
                this.SubLoadDataEvidencijaradnicisati();
            }
        }

        private void ScanByMJESECIDGODINEBROJEVIDENCIJE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[MJESEC] = @MJESEC and TM1.[IDGODINE] = @IDGODINE and TM1.[BROJEVIDENCIJE] = @BROJEVIDENCIJE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString264 + "  FROM [EVIDENCIJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString264, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE] ) AS DK_PAGENUM   FROM [EVIDENCIJA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString264 + " FROM [EVIDENCIJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE] ";
            }
            this.cmEVIDENCIJASelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmEVIDENCIJASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmEVIDENCIJASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                this.cmEVIDENCIJASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
                this.cmEVIDENCIJASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJEVIDENCIJE", DbType.Int32));
            }
            this.cmEVIDENCIJASelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["MJESEC"]));
            this.cmEVIDENCIJASelect7.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["IDGODINE"]));
            this.cmEVIDENCIJASelect7.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["BROJEVIDENCIJE"]));
            this.EVIDENCIJASelect7 = this.cmEVIDENCIJASelect7.FetchData();
            this.RcdFound264 = 0;
            this.ScanLoadEvidencija();
            this.LoadDataEvidencija(maxRows);
            if (this.RcdFound264 > 0)
            {
                this.SubLvlScanStartEvidencijaradnici(this.m_WhereString, startRow, maxRows);
                this.SetParametersMJESECIDGODINEBROJEVIDENCIJEEvidencija(this.cmEVIDENCIJARADNICISelect2);
                this.SubLvlFetchEvidencijaradnici();
                this.SubLoadDataEvidencijaradnici();
                this.SubLvlScanStartEvidencijaradnicisati(this.m_WhereString, startRow, maxRows);
                this.SetParametersMJESECIDGODINEBROJEVIDENCIJEEvidencija(this.cmEVIDENCIJARADNICISATISelect2);
                this.SubLvlFetchEvidencijaradnicisati();
                this.SubLoadDataEvidencijaradnicisati();
            }
        }

        private void ScanEndEvidencija()
        {
            this.EVIDENCIJASelect7.Close();
        }

        private void ScanEndEvidencijaradnici()
        {
            this.EVIDENCIJARADNICISelect2.Close();
        }

        private void ScanEndEvidencijaradnicisati()
        {
            this.EVIDENCIJARADNICISATISelect2.Close();
        }

        private void ScanLoadEvidencija()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmEVIDENCIJASelect7.HasMoreRows)
            {
                this.RcdFound264 = 1;
                this.rowEVIDENCIJA["MJESEC"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.EVIDENCIJASelect7, 0));
                this.rowEVIDENCIJA["BROJEVIDENCIJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.EVIDENCIJASelect7, 1));
                this.rowEVIDENCIJA["OPISEVIDENCIJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.EVIDENCIJASelect7, 2));
                this.rowEVIDENCIJA["IDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.EVIDENCIJASelect7, 3));
            }
        }

        private void ScanLoadEvidencijaradnici()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmEVIDENCIJARADNICISelect2.HasMoreRows)
            {
                this.RcdFound265 = 1;
                this.rowEVIDENCIJARADNICI["MJESEC"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.EVIDENCIJARADNICISelect2, 0));
                this.rowEVIDENCIJARADNICI["IDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.EVIDENCIJARADNICISelect2, 1));
                this.rowEVIDENCIJARADNICI["BROJEVIDENCIJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.EVIDENCIJARADNICISelect2, 2));
                this.rowEVIDENCIJARADNICI["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.EVIDENCIJARADNICISelect2, 3));
                this.rowEVIDENCIJARADNICI["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.EVIDENCIJARADNICISelect2, 4));
                this.rowEVIDENCIJARADNICI["TJEDNIFONDSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISelect2, 5));
                this.rowEVIDENCIJARADNICI["AKTIVAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.EVIDENCIJARADNICISelect2, 6));
                this.rowEVIDENCIJARADNICI["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.EVIDENCIJARADNICISelect2, 7));
                this.rowEVIDENCIJARADNICI["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.EVIDENCIJARADNICISelect2, 3));
                this.rowEVIDENCIJARADNICI["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.EVIDENCIJARADNICISelect2, 4));
                this.rowEVIDENCIJARADNICI["TJEDNIFONDSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISelect2, 5));
                this.rowEVIDENCIJARADNICI["AKTIVAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.EVIDENCIJARADNICISelect2, 6));
            }
        }

        private void ScanLoadEvidencijaradnicisati()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmEVIDENCIJARADNICISATISelect2.HasMoreRows)
            {
                this.RcdFound266 = 1;
                this.rowEVIDENCIJARADNICISATI["MJESEC"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.EVIDENCIJARADNICISATISelect2, 0));
                this.rowEVIDENCIJARADNICISATI["IDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.EVIDENCIJARADNICISATISelect2, 1));
                this.rowEVIDENCIJARADNICISATI["BROJEVIDENCIJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.EVIDENCIJARADNICISATISelect2, 2));
                this.rowEVIDENCIJARADNICISATI["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.EVIDENCIJARADNICISATISelect2, 3));
                this.rowEVIDENCIJARADNICISATI["DAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.EVIDENCIJARADNICISATISelect2, 4));
                this.rowEVIDENCIJARADNICISATI["PRVASMJENAOPISSMJENE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.EVIDENCIJARADNICISATISelect2, 5));
                this.rowEVIDENCIJARADNICISATI["PRVASMJENAPOCETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.EVIDENCIJARADNICISATISelect2, 6));
                this.rowEVIDENCIJARADNICISATI["PRVASMJENAZAVRSETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.EVIDENCIJARADNICISATISelect2, 7));
                this.rowEVIDENCIJARADNICISATI["DRUGASMJENAOPISSMJENE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.EVIDENCIJARADNICISATISelect2, 8));
                this.rowEVIDENCIJARADNICISATI["DRUGASMJENAPOCETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.EVIDENCIJARADNICISATISelect2, 9));
                this.rowEVIDENCIJARADNICISATI["DRUGASMJENAZAVRSETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.EVIDENCIJARADNICISATISelect2, 10));
                this.rowEVIDENCIJARADNICISATI["RR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 11));
                this.rowEVIDENCIJARADNICISATI["ODTOGASMJENSKI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 12));
                this.rowEVIDENCIJARADNICISATI["ODTOGADVOKRATNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 13));
                this.rowEVIDENCIJARADNICISATI["ODTOGAPOSEBNI1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 14));
                this.rowEVIDENCIJARADNICISATI["ODTOGAPOSEBNI2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 15));
                this.rowEVIDENCIJARADNICISATI["ODTOGAPOSEBNI3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x10));
                this.rowEVIDENCIJARADNICISATI["ODTOGAKOMBINACIJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x11));
                this.rowEVIDENCIJARADNICISATI["ODTOGASPECIJALNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x12));
                this.rowEVIDENCIJARADNICISATI["IZNADNORME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x13));
                this.rowEVIDENCIJARADNICISATI["PR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 20));
                this.rowEVIDENCIJARADNICISATI["SP"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x15));
                this.rowEVIDENCIJARADNICISATI["GO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x16));
                this.rowEVIDENCIJARADNICISATI["BOP"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x17));
                this.rowEVIDENCIJARADNICISATI["BOF"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x18));
                this.rowEVIDENCIJARADNICISATI["RD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x19));
                this.rowEVIDENCIJARADNICISATI["PD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x1a));
                this.rowEVIDENCIJARADNICISATI["NPD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x1b));
                this.rowEVIDENCIJARADNICISATI["BLG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x1c));
                this.rowEVIDENCIJARADNICISATI["ZAS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x1d));
                this.rowEVIDENCIJARADNICISATI["PRV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 30));
                this.rowEVIDENCIJARADNICISATI["TR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x1f));
                this.rowEVIDENCIJARADNICISATI["PRI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x20));
                this.rowEVIDENCIJARADNICISATI["NEN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x21));
                this.rowEVIDENCIJARADNICISATI["NENNEODOBRENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x22));
                this.rowEVIDENCIJARADNICISATI["STR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x23));
                this.rowEVIDENCIJARADNICISATI["LOC"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x24));
                this.rowEVIDENCIJARADNICISATI["NED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x25));
                this.rowEVIDENCIJARADNICISATI["NOC"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.EVIDENCIJARADNICISATISelect2, 0x26));
                this.rowEVIDENCIJARADNICISATI["PRVASMJENAIDSMJENE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.EVIDENCIJARADNICISATISelect2, 0x27));
                this.rowEVIDENCIJARADNICISATI["DRUGASMJENAIDSMJENE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.EVIDENCIJARADNICISATISelect2, 40));
                this.rowEVIDENCIJARADNICISATI["PRVASMJENAOPISSMJENE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.EVIDENCIJARADNICISATISelect2, 5));
                this.rowEVIDENCIJARADNICISATI["PRVASMJENAPOCETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.EVIDENCIJARADNICISATISelect2, 6));
                this.rowEVIDENCIJARADNICISATI["PRVASMJENAZAVRSETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.EVIDENCIJARADNICISATISelect2, 7));
                this.rowEVIDENCIJARADNICISATI["DRUGASMJENAOPISSMJENE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.EVIDENCIJARADNICISATISelect2, 8));
                this.rowEVIDENCIJARADNICISATI["DRUGASMJENAPOCETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.EVIDENCIJARADNICISATISelect2, 9));
                this.rowEVIDENCIJARADNICISATI["DRUGASMJENAZAVRSETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.EVIDENCIJARADNICISATISelect2, 10));
            }
        }

        private void ScanNextEvidencija()
        {
            this.cmEVIDENCIJASelect7.HasMoreRows = this.EVIDENCIJASelect7.Read();
            this.RcdFound264 = 0;
            this.ScanLoadEvidencija();
        }

        private void ScanNextEvidencijaradnici()
        {
            this.cmEVIDENCIJARADNICISelect2.HasMoreRows = this.EVIDENCIJARADNICISelect2.Read();
            this.RcdFound265 = 0;
            this.ScanLoadEvidencijaradnici();
        }

        private void ScanNextEvidencijaradnicisati()
        {
            this.cmEVIDENCIJARADNICISATISelect2.HasMoreRows = this.EVIDENCIJARADNICISATISelect2.Read();
            this.RcdFound266 = 0;
            this.ScanLoadEvidencijaradnicisati();
        }

        private void ScanStartEvidencija(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString264 + "  FROM [EVIDENCIJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString264, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE] ) AS DK_PAGENUM   FROM [EVIDENCIJA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString264 + " FROM [EVIDENCIJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE] ";
            }
            this.cmEVIDENCIJASelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.EVIDENCIJASelect7 = this.cmEVIDENCIJASelect7.FetchData();
            this.RcdFound264 = 0;
            this.ScanLoadEvidencija();
            this.LoadDataEvidencija(maxRows);
            if (this.RcdFound264 > 0)
            {
                this.SubLvlScanStartEvidencijaradnici(this.m_WhereString, startRow, maxRows);
                this.SetParametersEvidencijaEvidencija(this.cmEVIDENCIJARADNICISelect2);
                this.SubLvlFetchEvidencijaradnici();
                this.SubLoadDataEvidencijaradnici();
                this.SubLvlScanStartEvidencijaradnicisati(this.m_WhereString, startRow, maxRows);
                this.SetParametersEvidencijaEvidencija(this.cmEVIDENCIJARADNICISATISelect2);
                this.SubLvlFetchEvidencijaradnicisati();
                this.SubLoadDataEvidencijaradnicisati();
            }
        }

        private void ScanStartEvidencijaradnici()
        {
            this.cmEVIDENCIJARADNICISelect2 = this.connDefault.GetCommand("SELECT T1.[MJESEC], T1.[IDGODINE], T1.[BROJEVIDENCIJE], T2.[PREZIME], T2.[IME], T2.[TJEDNIFONDSATI], T2.[AKTIVAN], T1.[IDRADNIK] FROM ([EVIDENCIJARADNICI] T1 WITH (NOLOCK) INNER JOIN [RADNIK] T2 WITH (NOLOCK) ON T2.[IDRADNIK] = T1.[IDRADNIK]) WHERE T1.[MJESEC] = @MJESEC and T1.[IDGODINE] = @IDGODINE and T1.[BROJEVIDENCIJE] = @BROJEVIDENCIJE ORDER BY T1.[MJESEC], T1.[IDGODINE], T1.[BROJEVIDENCIJE], T1.[IDRADNIK] ", false);
            if (this.cmEVIDENCIJARADNICISelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmEVIDENCIJARADNICISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                this.cmEVIDENCIJARADNICISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
                this.cmEVIDENCIJARADNICISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJEVIDENCIJE", DbType.Int32));
            }
            this.cmEVIDENCIJARADNICISelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICI["MJESEC"]));
            this.cmEVIDENCIJARADNICISelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICI["IDGODINE"]));
            this.cmEVIDENCIJARADNICISelect2.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICI["BROJEVIDENCIJE"]));
            this.EVIDENCIJARADNICISelect2 = this.cmEVIDENCIJARADNICISelect2.FetchData();
            this.RcdFound265 = 0;
            this.ScanLoadEvidencijaradnici();
        }

        private void ScanStartEvidencijaradnicisati()
        {
            this.cmEVIDENCIJARADNICISATISelect2 = this.connDefault.GetCommand("SELECT T1.[MJESEC], T1.[IDGODINE], T1.[BROJEVIDENCIJE], T1.[IDRADNIK], T1.[DAN], T2.[OPISSMJENE] AS PRVASMJENAOPISSMJENE, T2.[POCETAK] AS PRVASMJENAPOCETAK, T2.[ZAVRSETAK] AS PRVASMJENAZAVRSETAK, T3.[OPISSMJENE] AS DRUGASMJENAOPISSMJENE, T3.[POCETAK] AS DRUGASMJENAPOCETAK, T3.[ZAVRSETAK] AS DRUGASMJENAZAVRSETAK, T1.[RR], T1.[ODTOGASMJENSKI], T1.[ODTOGADVOKRATNI], T1.[ODTOGAPOSEBNI1], T1.[ODTOGAPOSEBNI2], T1.[ODTOGAPOSEBNI3], T1.[ODTOGAKOMBINACIJA], T1.[ODTOGASPECIJALNA], T1.[IZNADNORME], T1.[PR], T1.[SP], T1.[GO], T1.[BOP], T1.[BOF], T1.[RD], T1.[PD], T1.[NPD], T1.[BLG], T1.[ZAS], T1.[PRV], T1.[TR], T1.[PRI], T1.[NEN], T1.[NENNEODOBRENA], T1.[STR], T1.[LOC], T1.[NED], T1.[NOC], T1.[PRVASMJENAIDSMJENE] AS PRVASMJENAIDSMJENE, T1.[DRUGASMJENAIDSMJENE] AS DRUGASMJENAIDSMJENE FROM (([EVIDENCIJARADNICISATI] T1 WITH (NOLOCK) LEFT JOIN [SMJENE] T2 WITH (NOLOCK) ON T2.[IDSMJENE] = T1.[PRVASMJENAIDSMJENE]) LEFT JOIN [SMJENE] T3 WITH (NOLOCK) ON T3.[IDSMJENE] = T1.[DRUGASMJENAIDSMJENE]) WHERE T1.[MJESEC] = @MJESEC and T1.[IDGODINE] = @IDGODINE and T1.[BROJEVIDENCIJE] = @BROJEVIDENCIJE and T1.[IDRADNIK] = @IDRADNIK ORDER BY T1.[MJESEC], T1.[IDGODINE], T1.[BROJEVIDENCIJE], T1.[IDRADNIK], T1.[DAN] ", false);
            if (this.cmEVIDENCIJARADNICISATISelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmEVIDENCIJARADNICISATISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                this.cmEVIDENCIJARADNICISATISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
                this.cmEVIDENCIJARADNICISATISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJEVIDENCIJE", DbType.Int32));
                this.cmEVIDENCIJARADNICISATISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmEVIDENCIJARADNICISATISelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["MJESEC"]));
            this.cmEVIDENCIJARADNICISATISelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["IDGODINE"]));
            this.cmEVIDENCIJARADNICISATISelect2.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["BROJEVIDENCIJE"]));
            this.cmEVIDENCIJARADNICISATISelect2.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["IDRADNIK"]));
            this.EVIDENCIJARADNICISATISelect2 = this.cmEVIDENCIJARADNICISATISelect2.FetchData();
            this.RcdFound266 = 0;
            this.ScanLoadEvidencijaradnicisati();
        }

        private void SetParametersEvidencijaEvidencija(ReadWriteCommand m_Command)
        {
        }

        private void SetParametersIDGODINEEvidencija(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["IDGODINE"]));
        }

        private void SetParametersMJESECEvidencija(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["MJESEC"]));
        }

        private void SetParametersMJESECIDGODINEBROJEVIDENCIJEEvidencija(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJEVIDENCIJE", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["MJESEC"]));
            m_Command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["IDGODINE"]));
            m_Command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["BROJEVIDENCIJE"]));
        }

        private void SetParametersMJESECIDGODINEEvidencija(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["MJESEC"]));
            m_Command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["IDGODINE"]));
        }

        private void SkipNextEvidencijaradnici()
        {
            this.cmEVIDENCIJARADNICISelect2.HasMoreRows = this.EVIDENCIJARADNICISelect2.Read();
            this.RcdFound265 = 0;
            if (this.cmEVIDENCIJARADNICISelect2.HasMoreRows)
            {
                this.RcdFound265 = 1;
            }
        }

        private void SkipNextEvidencijaradnicisati()
        {
            this.cmEVIDENCIJARADNICISATISelect2.HasMoreRows = this.EVIDENCIJARADNICISATISelect2.Read();
            this.RcdFound266 = 0;
            if (this.cmEVIDENCIJARADNICISATISelect2.HasMoreRows)
            {
                this.RcdFound266 = 1;
            }
        }

        private void SubLoadDataEvidencijaradnici()
        {
            while (this.RcdFound265 != 0)
            {
                this.LoadRowEvidencijaradnici();
                this.CreateNewRowEvidencijaradnici();
                this.ScanNextEvidencijaradnici();
            }
            this.ScanEndEvidencijaradnici();
        }

        private void SubLoadDataEvidencijaradnicisati()
        {
            while (this.RcdFound266 != 0)
            {
                this.LoadRowEvidencijaradnicisati();
                this.CreateNewRowEvidencijaradnicisati();
                this.ScanNextEvidencijaradnicisati();
            }
            this.ScanEndEvidencijaradnicisati();
        }

        private void SubLvlFetchEvidencijaradnici()
        {
            this.CreateNewRowEvidencijaradnici();
            this.EVIDENCIJARADNICISelect2 = this.cmEVIDENCIJARADNICISelect2.FetchData();
            this.RcdFound265 = 0;
            this.ScanLoadEvidencijaradnici();
        }

        private void SubLvlFetchEvidencijaradnicisati()
        {
            this.CreateNewRowEvidencijaradnicisati();
            this.EVIDENCIJARADNICISATISelect2 = this.cmEVIDENCIJARADNICISATISelect2.FetchData();
            this.RcdFound266 = 0;
            this.ScanLoadEvidencijaradnicisati();
        }

        private void SubLvlScanStartEvidencijaradnici(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString265 = "(SELECT TOP " + maxRows.ToString() + " TM1.[MJESEC],TM1.[IDGODINE],TM1.[BROJEVIDENCIJE]  FROM [EVIDENCIJA]  TM1 " + this.m_WhereString + " ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE] )";
                    this.scmdbuf = "SELECT T1.[MJESEC], T1.[IDGODINE], T1.[BROJEVIDENCIJE], T3.[PREZIME], T3.[IME], T3.[TJEDNIFONDSATI], T3.[AKTIVAN], T1.[IDRADNIK] FROM (([EVIDENCIJARADNICI] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString265 + "  TMX ON TMX.[MJESEC] = T1.[MJESEC] AND TMX.[IDGODINE] = T1.[IDGODINE] AND TMX.[BROJEVIDENCIJE] = T1.[BROJEVIDENCIJE]) INNER JOIN [RADNIK] T3 WITH (NOLOCK) ON T3.[IDRADNIK] = T1.[IDRADNIK]) ORDER BY T1.[MJESEC], T1.[IDGODINE], T1.[BROJEVIDENCIJE], T1.[IDRADNIK]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[MJESEC],TM1.[IDGODINE],TM1.[BROJEVIDENCIJE], ROW_NUMBER() OVER  (  ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE]  ) AS DK_PAGENUM   FROM [EVIDENCIJA]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString265 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[MJESEC], T1.[IDGODINE], T1.[BROJEVIDENCIJE], T3.[PREZIME], T3.[IME], T3.[TJEDNIFONDSATI], T3.[AKTIVAN], T1.[IDRADNIK] FROM (([EVIDENCIJARADNICI] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString265 + "  TMX ON TMX.[MJESEC] = T1.[MJESEC] AND TMX.[IDGODINE] = T1.[IDGODINE] AND TMX.[BROJEVIDENCIJE] = T1.[BROJEVIDENCIJE]) INNER JOIN [RADNIK] T3 WITH (NOLOCK) ON T3.[IDRADNIK] = T1.[IDRADNIK]) ORDER BY T1.[MJESEC], T1.[IDGODINE], T1.[BROJEVIDENCIJE], T1.[IDRADNIK]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString265 = "[EVIDENCIJA]";
                this.scmdbuf = "SELECT T1.[MJESEC], T1.[IDGODINE], T1.[BROJEVIDENCIJE], T3.[PREZIME], T3.[IME], T3.[TJEDNIFONDSATI], T3.[AKTIVAN], T1.[IDRADNIK] FROM (([EVIDENCIJARADNICI] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString265 + "  TM1 WITH (NOLOCK) ON TM1.[MJESEC] = T1.[MJESEC] AND TM1.[IDGODINE] = T1.[IDGODINE] AND TM1.[BROJEVIDENCIJE] = T1.[BROJEVIDENCIJE]) INNER JOIN [RADNIK] T3 WITH (NOLOCK) ON T3.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString + " ORDER BY T1.[MJESEC], T1.[IDGODINE], T1.[BROJEVIDENCIJE], T1.[IDRADNIK] ";
            }
            this.cmEVIDENCIJARADNICISelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartEvidencijaradnicisati(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString266 = "(SELECT TOP " + maxRows.ToString() + " TM1.[MJESEC],TM1.[IDGODINE],TM1.[BROJEVIDENCIJE]  FROM [EVIDENCIJA]  TM1 " + this.m_WhereString + " ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE] )";
                    this.scmdbuf = "SELECT T1.[MJESEC], T1.[IDGODINE], T1.[BROJEVIDENCIJE], T1.[IDRADNIK], T1.[DAN], T3.[OPISSMJENE] AS PRVASMJENAOPISSMJENE, T3.[POCETAK] AS PRVASMJENAPOCETAK, T3.[ZAVRSETAK] AS PRVASMJENAZAVRSETAK, T4.[OPISSMJENE] AS DRUGASMJENAOPISSMJENE, T4.[POCETAK] AS DRUGASMJENAPOCETAK, T4.[ZAVRSETAK] AS DRUGASMJENAZAVRSETAK, T1.[RR], T1.[ODTOGASMJENSKI], T1.[ODTOGADVOKRATNI], T1.[ODTOGAPOSEBNI1], T1.[ODTOGAPOSEBNI2], T1.[ODTOGAPOSEBNI3], T1.[ODTOGAKOMBINACIJA], T1.[ODTOGASPECIJALNA], T1.[IZNADNORME], T1.[PR], T1.[SP], T1.[GO], T1.[BOP], T1.[BOF], T1.[RD], T1.[PD], T1.[NPD], T1.[BLG], T1.[ZAS], T1.[PRV], T1.[TR], T1.[PRI], T1.[NEN], T1.[NENNEODOBRENA], T1.[STR], T1.[LOC], T1.[NED], T1.[NOC], T1.[PRVASMJENAIDSMJENE] AS PRVASMJENAIDSMJENE, T1.[DRUGASMJENAIDSMJENE] AS DRUGASMJENAIDSMJENE FROM ((([EVIDENCIJARADNICISATI] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString266 + "  TMX ON TMX.[MJESEC] = T1.[MJESEC] AND TMX.[IDGODINE] = T1.[IDGODINE] AND TMX.[BROJEVIDENCIJE] = T1.[BROJEVIDENCIJE]) LEFT JOIN [SMJENE] T3 WITH (NOLOCK) ON T3.[IDSMJENE] = T1.[PRVASMJENAIDSMJENE]) LEFT JOIN [SMJENE] T4 WITH (NOLOCK) ON T4.[IDSMJENE] = T1.[DRUGASMJENAIDSMJENE]) ORDER BY T1.[MJESEC], T1.[IDGODINE], T1.[BROJEVIDENCIJE], T1.[IDRADNIK], T1.[DAN]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[MJESEC],TM1.[IDGODINE],TM1.[BROJEVIDENCIJE], ROW_NUMBER() OVER  (  ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE]  ) AS DK_PAGENUM   FROM [EVIDENCIJA]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString266 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[MJESEC], T1.[IDGODINE], T1.[BROJEVIDENCIJE], T1.[IDRADNIK], T1.[DAN], T3.[OPISSMJENE] AS PRVASMJENAOPISSMJENE, T3.[POCETAK] AS PRVASMJENAPOCETAK, T3.[ZAVRSETAK] AS PRVASMJENAZAVRSETAK, T4.[OPISSMJENE] AS DRUGASMJENAOPISSMJENE, T4.[POCETAK] AS DRUGASMJENAPOCETAK, T4.[ZAVRSETAK] AS DRUGASMJENAZAVRSETAK, T1.[RR], T1.[ODTOGASMJENSKI], T1.[ODTOGADVOKRATNI], T1.[ODTOGAPOSEBNI1], T1.[ODTOGAPOSEBNI2], T1.[ODTOGAPOSEBNI3], T1.[ODTOGAKOMBINACIJA], T1.[ODTOGASPECIJALNA], T1.[IZNADNORME], T1.[PR], T1.[SP], T1.[GO], T1.[BOP], T1.[BOF], T1.[RD], T1.[PD], T1.[NPD], T1.[BLG], T1.[ZAS], T1.[PRV], T1.[TR], T1.[PRI], T1.[NEN], T1.[NENNEODOBRENA], T1.[STR], T1.[LOC], T1.[NED], T1.[NOC], T1.[PRVASMJENAIDSMJENE] AS PRVASMJENAIDSMJENE, T1.[DRUGASMJENAIDSMJENE] AS DRUGASMJENAIDSMJENE FROM ((([EVIDENCIJARADNICISATI] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString266 + "  TMX ON TMX.[MJESEC] = T1.[MJESEC] AND TMX.[IDGODINE] = T1.[IDGODINE] AND TMX.[BROJEVIDENCIJE] = T1.[BROJEVIDENCIJE]) LEFT JOIN [SMJENE] T3 WITH (NOLOCK) ON T3.[IDSMJENE] = T1.[PRVASMJENAIDSMJENE]) LEFT JOIN [SMJENE] T4 WITH (NOLOCK) ON T4.[IDSMJENE] = T1.[DRUGASMJENAIDSMJENE]) ORDER BY T1.[MJESEC], T1.[IDGODINE], T1.[BROJEVIDENCIJE], T1.[IDRADNIK], T1.[DAN]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString266 = "[EVIDENCIJA]";
                this.scmdbuf = "SELECT T1.[MJESEC], T1.[IDGODINE], T1.[BROJEVIDENCIJE], T1.[IDRADNIK], T1.[DAN], T3.[OPISSMJENE] AS PRVASMJENAOPISSMJENE, T3.[POCETAK] AS PRVASMJENAPOCETAK, T3.[ZAVRSETAK] AS PRVASMJENAZAVRSETAK, T4.[OPISSMJENE] AS DRUGASMJENAOPISSMJENE, T4.[POCETAK] AS DRUGASMJENAPOCETAK, T4.[ZAVRSETAK] AS DRUGASMJENAZAVRSETAK, T1.[RR], T1.[ODTOGASMJENSKI], T1.[ODTOGADVOKRATNI], T1.[ODTOGAPOSEBNI1], T1.[ODTOGAPOSEBNI2], T1.[ODTOGAPOSEBNI3], T1.[ODTOGAKOMBINACIJA], T1.[ODTOGASPECIJALNA], T1.[IZNADNORME], T1.[PR], T1.[SP], T1.[GO], T1.[BOP], T1.[BOF], T1.[RD], T1.[PD], T1.[NPD], T1.[BLG], T1.[ZAS], T1.[PRV], T1.[TR], T1.[PRI], T1.[NEN], T1.[NENNEODOBRENA], T1.[STR], T1.[LOC], T1.[NED], T1.[NOC], T1.[PRVASMJENAIDSMJENE] AS PRVASMJENAIDSMJENE, T1.[DRUGASMJENAIDSMJENE] AS DRUGASMJENAIDSMJENE FROM ((([EVIDENCIJARADNICISATI] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString266 + "  TM1 WITH (NOLOCK) ON TM1.[MJESEC] = T1.[MJESEC] AND TM1.[IDGODINE] = T1.[IDGODINE] AND TM1.[BROJEVIDENCIJE] = T1.[BROJEVIDENCIJE]) LEFT JOIN [SMJENE] T3 WITH (NOLOCK) ON T3.[IDSMJENE] = T1.[PRVASMJENAIDSMJENE]) LEFT JOIN [SMJENE] T4 WITH (NOLOCK) ON T4.[IDSMJENE] = T1.[DRUGASMJENAIDSMJENE])" + this.m_WhereString + " ORDER BY T1.[MJESEC], T1.[IDGODINE], T1.[BROJEVIDENCIJE], T1.[IDRADNIK], T1.[DAN] ";
            }
            this.cmEVIDENCIJARADNICISATISelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.EVIDENCIJASet = (EVIDENCIJADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.EVIDENCIJASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.EVIDENCIJASet.EVIDENCIJA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        EVIDENCIJADataSet.EVIDENCIJARow current = (EVIDENCIJADataSet.EVIDENCIJARow) enumerator.Current;
                        this.rowEVIDENCIJA = current;
                        if (Helpers.IsRowChanged(this.rowEVIDENCIJA))
                        {
                            this.ReadRowEvidencija();
                            if (this.rowEVIDENCIJA.RowState == DataRowState.Added)
                            {
                                this.InsertEvidencija();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateEvidencija();
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

        private void UpdateEvidencija()
        {
            this.CheckOptimisticConcurrencyEvidencija();
            this.AfterConfirmEvidencija();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [EVIDENCIJA] SET [OPISEVIDENCIJE]=@OPISEVIDENCIJE  WHERE [MJESEC] = @MJESEC AND [IDGODINE] = @IDGODINE AND [BROJEVIDENCIJE] = @BROJEVIDENCIJE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISEVIDENCIJE", DbType.String, 40));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJEVIDENCIJE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["OPISEVIDENCIJE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["MJESEC"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["IDGODINE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJA["BROJEVIDENCIJE"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsEvidencija();
            }
            this.OnEVIDENCIJAUpdated(new EVIDENCIJAEventArgs(this.rowEVIDENCIJA, StatementType.Update));
            this.ProcessLevelEvidencija();
        }

        private void UpdateEvidencijaradnici()
        {
            this.CheckOptimisticConcurrencyEvidencijaradnici();
            this.CheckExtendedTableEvidencijaradnici();
            this.AfterConfirmEvidencijaradnici();
            this.OnEVIDENCIJARADNICIUpdated(new EVIDENCIJARADNICIEventArgs(this.rowEVIDENCIJARADNICI, StatementType.Update));
            this.ProcessLevelEvidencijaradnici();
        }

        private void UpdateEvidencijaradnicisati()
        {
            this.CheckOptimisticConcurrencyEvidencijaradnicisati();
            this.CheckExtendedTableEvidencijaradnicisati();
            this.AfterConfirmEvidencijaradnicisati();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [EVIDENCIJARADNICISATI] SET [RR]=@RR, [ODTOGASMJENSKI]=@ODTOGASMJENSKI, [ODTOGADVOKRATNI]=@ODTOGADVOKRATNI, [ODTOGAPOSEBNI1]=@ODTOGAPOSEBNI1, [ODTOGAPOSEBNI2]=@ODTOGAPOSEBNI2, [ODTOGAPOSEBNI3]=@ODTOGAPOSEBNI3, [ODTOGAKOMBINACIJA]=@ODTOGAKOMBINACIJA, [ODTOGASPECIJALNA]=@ODTOGASPECIJALNA, [IZNADNORME]=@IZNADNORME, [PR]=@PR, [SP]=@SP, [GO]=@GO, [BOP]=@BOP, [BOF]=@BOF, [RD]=@RD, [PD]=@PD, [NPD]=@NPD, [BLG]=@BLG, [ZAS]=@ZAS, [PRV]=@PRV, [TR]=@TR, [PRI]=@PRI, [NEN]=@NEN, [NENNEODOBRENA]=@NENNEODOBRENA, [STR]=@STR, [LOC]=@LOC, [NED]=@NED, [NOC]=@NOC, [PRVASMJENAIDSMJENE]=@PRVASMJENAIDSMJENE, [DRUGASMJENAIDSMJENE]=@DRUGASMJENAIDSMJENE  WHERE [MJESEC] = @MJESEC AND [IDGODINE] = @IDGODINE AND [BROJEVIDENCIJE] = @BROJEVIDENCIJE AND [IDRADNIK] = @IDRADNIK AND [DAN] = @DAN", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RR", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODTOGASMJENSKI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODTOGADVOKRATNI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODTOGAPOSEBNI1", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODTOGAPOSEBNI2", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODTOGAPOSEBNI3", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODTOGAKOMBINACIJA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODTOGASPECIJALNA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZNADNORME", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PR", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SP", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BOP", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BOF", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RD", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PD", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NPD", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLG", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRV", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TR", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NEN", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NENNEODOBRENA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STR", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@LOC", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NED", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NOC", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRVASMJENAIDSMJENE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DRUGASMJENAIDSMJENE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJEVIDENCIJE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DAN", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["RR"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGASMJENSKI"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGADVOKRATNI"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGAPOSEBNI1"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGAPOSEBNI2"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGAPOSEBNI3"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGAKOMBINACIJA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ODTOGASPECIJALNA"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["IZNADNORME"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PR"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["SP"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["GO"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["BOP"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["BOF"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["RD"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PD"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NPD"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["BLG"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["ZAS"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PRV"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["TR"]));
            command.SetParameter(0x15, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PRI"]));
            command.SetParameter(0x16, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NEN"]));
            command.SetParameter(0x17, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NENNEODOBRENA"]));
            command.SetParameter(0x18, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["STR"]));
            command.SetParameter(0x19, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["LOC"]));
            command.SetParameter(0x1a, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NED"]));
            command.SetParameter(0x1b, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["NOC"]));
            command.SetParameter(0x1c, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["PRVASMJENAIDSMJENE"]));
            command.SetParameter(0x1d, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["DRUGASMJENAIDSMJENE"]));
            command.SetParameter(30, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["MJESEC"]));
            command.SetParameter(0x1f, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["IDGODINE"]));
            command.SetParameter(0x20, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["BROJEVIDENCIJE"]));
            command.SetParameter(0x21, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["IDRADNIK"]));
            command.SetParameter(0x22, RuntimeHelpers.GetObjectValue(this.rowEVIDENCIJARADNICISATI["DAN"]));
            command.ExecuteStmt();
            this.OnEVIDENCIJARADNICISATIUpdated(new EVIDENCIJARADNICISATIEventArgs(this.rowEVIDENCIJARADNICISATI, StatementType.Update));
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
        public class EVIDENCIJADataChangedException : DataChangedException
        {
            public EVIDENCIJADataChangedException()
            {
            }

            public EVIDENCIJADataChangedException(string message) : base(message)
            {
            }

            protected EVIDENCIJADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public EVIDENCIJADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class EVIDENCIJADataLockedException : DataLockedException
        {
            public EVIDENCIJADataLockedException()
            {
            }

            public EVIDENCIJADataLockedException(string message) : base(message)
            {
            }

            protected EVIDENCIJADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public EVIDENCIJADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class EVIDENCIJADuplicateKeyException : DuplicateKeyException
        {
            public EVIDENCIJADuplicateKeyException()
            {
            }

            public EVIDENCIJADuplicateKeyException(string message) : base(message)
            {
            }

            protected EVIDENCIJADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public EVIDENCIJADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class EVIDENCIJAEventArgs : EventArgs
        {
            private EVIDENCIJADataSet.EVIDENCIJARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public EVIDENCIJAEventArgs(EVIDENCIJADataSet.EVIDENCIJARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public EVIDENCIJADataSet.EVIDENCIJARow Row
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
        public class EVIDENCIJANotFoundException : DataNotFoundException
        {
            public EVIDENCIJANotFoundException()
            {
            }

            public EVIDENCIJANotFoundException(string message) : base(message)
            {
            }

            protected EVIDENCIJANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public EVIDENCIJANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class EVIDENCIJARADNICIDataChangedException : DataChangedException
        {
            public EVIDENCIJARADNICIDataChangedException()
            {
            }

            public EVIDENCIJARADNICIDataChangedException(string message) : base(message)
            {
            }

            protected EVIDENCIJARADNICIDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public EVIDENCIJARADNICIDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class EVIDENCIJARADNICIDataLockedException : DataLockedException
        {
            public EVIDENCIJARADNICIDataLockedException()
            {
            }

            public EVIDENCIJARADNICIDataLockedException(string message) : base(message)
            {
            }

            protected EVIDENCIJARADNICIDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public EVIDENCIJARADNICIDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class EVIDENCIJARADNICIDuplicateKeyException : DuplicateKeyException
        {
            public EVIDENCIJARADNICIDuplicateKeyException()
            {
            }

            public EVIDENCIJARADNICIDuplicateKeyException(string message) : base(message)
            {
            }

            protected EVIDENCIJARADNICIDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public EVIDENCIJARADNICIDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class EVIDENCIJARADNICIEventArgs : EventArgs
        {
            private EVIDENCIJADataSet.EVIDENCIJARADNICIRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public EVIDENCIJARADNICIEventArgs(EVIDENCIJADataSet.EVIDENCIJARADNICIRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public EVIDENCIJADataSet.EVIDENCIJARADNICIRow Row
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
        public class EVIDENCIJARADNICISATIDataChangedException : DataChangedException
        {
            public EVIDENCIJARADNICISATIDataChangedException()
            {
            }

            public EVIDENCIJARADNICISATIDataChangedException(string message) : base(message)
            {
            }

            protected EVIDENCIJARADNICISATIDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public EVIDENCIJARADNICISATIDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class EVIDENCIJARADNICISATIDataLockedException : DataLockedException
        {
            public EVIDENCIJARADNICISATIDataLockedException()
            {
            }

            public EVIDENCIJARADNICISATIDataLockedException(string message) : base(message)
            {
            }

            protected EVIDENCIJARADNICISATIDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public EVIDENCIJARADNICISATIDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class EVIDENCIJARADNICISATIDuplicateKeyException : DuplicateKeyException
        {
            public EVIDENCIJARADNICISATIDuplicateKeyException()
            {
            }

            public EVIDENCIJARADNICISATIDuplicateKeyException(string message) : base(message)
            {
            }

            protected EVIDENCIJARADNICISATIDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public EVIDENCIJARADNICISATIDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class EVIDENCIJARADNICISATIEventArgs : EventArgs
        {
            private EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public EVIDENCIJARADNICISATIEventArgs(EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public EVIDENCIJADataSet.EVIDENCIJARADNICISATIRow Row
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

        public delegate void EVIDENCIJARADNICISATIUpdateEventHandler(object sender, EVIDENCIJADataAdapter.EVIDENCIJARADNICISATIEventArgs e);

        public delegate void EVIDENCIJARADNICIUpdateEventHandler(object sender, EVIDENCIJADataAdapter.EVIDENCIJARADNICIEventArgs e);

        public delegate void EVIDENCIJAUpdateEventHandler(object sender, EVIDENCIJADataAdapter.EVIDENCIJAEventArgs e);

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
        public class RADNIKForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public RADNIKForeignKeyNotFoundException()
            {
            }

            public RADNIKForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected RADNIKForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SMJENEForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public SMJENEForeignKeyNotFoundException()
            {
            }

            public SMJENEForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected SMJENEForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SMJENEForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

