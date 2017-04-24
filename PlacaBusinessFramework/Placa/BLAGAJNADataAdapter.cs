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

    public class BLAGAJNADataAdapter : IDataAdapter, IBLAGAJNADataAdapter
    {
        private bool _Gxremove;
        private bool _Gxremove31;
        private IDataReader BLAGAJNASelect1;
        private IDataReader BLAGAJNASelect2;
        private IDataReader BLAGAJNASelect5;
        private BLAGAJNADataSet BLAGAJNASet;
        private IDataReader BLAGAJNAStavkeBlagajneSelect2;
        private IDataReader BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2;
        private ReadWriteCommand cmBLAGAJNASelect1;
        private ReadWriteCommand cmBLAGAJNASelect2;
        private ReadWriteCommand cmBLAGAJNASelect5;
        private ReadWriteCommand cmBLAGAJNAStavkeBlagajneSelect2;
        private ReadWriteCommand cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__BLGDATUMDOKUMENTAOriginal;
        private object m__BLGIZNOSKONTIRANJAOriginal;
        private object m__BLGIZNOSOriginal;
        private object m__BLGKONTOIDKONTOOriginal;
        private object m__BLGMTIDMJESTOTROSKAOriginal;
        private object m__BLGORGJEDIDORGJEDOriginal;
        private object m__BLGSVRHAOriginal;
        private object m__NAZIVBLAGAJNAOriginal;
        private readonly string m_SelectString180 = "TM1.[NAZIVBLAGAJNA], TM1.[BLGDOKIDDOKUMENT] AS BLGDOKIDDOKUMENT, TM1.[BLGKONTOIDKONTO] AS BLGKONTOIDKONTO";
        private string m_SubSelTopString181;
        private string m_SubSelTopString182;
        private string m_WhereString;
        private short RcdFound180;
        private short RcdFound181;
        private short RcdFound182;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private BLAGAJNADataSet.BLAGAJNARow rowBLAGAJNA;
        private BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow rowBLAGAJNAStavkeBlagajne;
        private BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje;
        private string scmdbuf;
        private StatementType sMode180;
        private StatementType sMode181;
        private StatementType sMode182;

        public event BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdateEventHandler BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdated;

        public event BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdateEventHandler BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdating;

        public event BLAGAJNAStavkeBlagajneUpdateEventHandler BLAGAJNAStavkeBlagajneUpdated;

        public event BLAGAJNAStavkeBlagajneUpdateEventHandler BLAGAJNAStavkeBlagajneUpdating;

        public event BLAGAJNAUpdateEventHandler BLAGAJNAUpdated;

        public event BLAGAJNAUpdateEventHandler BLAGAJNAUpdating;

        private void AddRowBlagajna()
        {
            this.BLAGAJNASet.BLAGAJNA.AddBLAGAJNARow(this.rowBLAGAJNA);
        }

        private void AddRowBlagajnastavkeblagajne()
        {
            this.BLAGAJNASet.BLAGAJNAStavkeBlagajne.AddBLAGAJNAStavkeBlagajneRow(this.rowBLAGAJNAStavkeBlagajne);
        }

        private void AddRowBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            this.BLAGAJNASet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.AddBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje);
        }

        private void AfterConfirmBlagajna()
        {
            this.OnBLAGAJNAUpdating(new BLAGAJNAEventArgs(this.rowBLAGAJNA, this.Gx_mode));
        }

        private void AfterConfirmBlagajnastavkeblagajne()
        {
            this.OnBLAGAJNAStavkeBlagajneUpdating(new BLAGAJNAStavkeBlagajneEventArgs(this.rowBLAGAJNAStavkeBlagajne, this.Gx_mode));
        }

        private void AfterConfirmBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            this.OnBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdating(new BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeEventArgs(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje, this.Gx_mode));
        }

        private void CheckExtendedTableBlagajnastavkeblagajne()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVVRSTEDOK] FROM [BLGVRSTEDOK] WITH (NOLOCK) WHERE [IDBLGVRSTEDOK] = @IDBLGVRSTEDOK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["IDBLGVRSTEDOK"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new BLGVRSTEDOKForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("BLGVRSTEDOK") }));
            }
            this.rowBLAGAJNAStavkeBlagajne["NAZIVVRSTEDOK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            reader.Close();
        }

        private void CheckExtendedTableBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVKONTO] AS BLGSTAVKEBLAGAJNEKONTONAZIVKONTO FROM [KONTO] WITH (NOLOCK) WHERE [IDKONTO] = @BLGSTAVKEBLAGAJNEKONTOIDKONTO ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGSTAVKEBLAGAJNEKONTOIDKONTO", DbType.String, 14));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGSTAVKEBLAGAJNEKONTOIDKONTO"]))));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new KONTOForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KONTO") }));
            }
            this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGSTAVKEBLAGAJNEKONTONAZIVKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0))));
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVMJESTOTROSKA] AS BLGMTNAZIVMJESTOTROSKA FROM [MJESTOTROSKA] WITH (NOLOCK) WHERE [IDMJESTOTROSKA] = @BLGMTIDMJESTOTROSKA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGMTIDMJESTOTROSKA", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGMTIDMJESTOTROSKA"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new MJESTOTROSKAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("MJESTOTROSKA") }));
            }
            this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGMTNAZIVMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0))));
            reader2.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVORGJED] AS BLGORGJEDNAZIVORGJED FROM [ORGJED] WITH (NOLOCK) WHERE [IDORGJED] = @BLGORGJEDIDORGJED ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGORGJEDIDORGJED", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGORGJEDIDORGJED"]));
            IDataReader reader3 = command3.FetchData();
            if (!command3.HasMoreRows)
            {
                reader3.Close();
                throw new ORGJEDForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ORGJED") }));
            }
            this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGORGJEDNAZIVORGJED"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0))));
            reader3.Close();
        }

        private void CheckIntegrityErrorsBlagajna()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDDOKUMENT] AS BLGDOKIDDOKUMENT FROM [DOKUMENT] WITH (NOLOCK) WHERE [IDDOKUMENT] = @BLGDOKIDDOKUMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDOKIDDOKUMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["BLGDOKIDDOKUMENT"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new DOKUMENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DOKUMENT") }));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [IDKONTO] AS BLGKONTOIDKONTO FROM [KONTO] WITH (NOLOCK) WHERE [IDKONTO] = @BLGKONTOIDKONTO ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGKONTOIDKONTO", DbType.String, 14));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["BLGKONTOIDKONTO"]))));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new KONTOForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KONTO") }));
            }
            reader2.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckIntegrityErrorsBlagajnastavkeblagajne()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDGODINE] AS blggodineIDGODINE FROM [GODINE] WITH (NOLOCK) WHERE [IDGODINE] = @blggodineIDGODINE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@blggodineIDGODINE", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["blggodineIDGODINE"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new GODINEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("GODINE") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyBlagajna()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVBLAGAJNA], [BLGDOKIDDOKUMENT] AS BLGDOKIDDOKUMENT, [BLGKONTOIDKONTO] AS BLGKONTOIDKONTO FROM [BLAGAJNA] WITH (UPDLOCK) WHERE [BLGDOKIDDOKUMENT] = @BLGDOKIDDOKUMENT ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDOKIDDOKUMENT", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["BLGDOKIDDOKUMENT"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new BLAGAJNADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("BLAGAJNA") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVBLAGAJNAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__BLGKONTOIDKONTOOriginal), RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))))))
                {
                    reader.Close();
                    throw new BLAGAJNADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("BLAGAJNA") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyBlagajnastavkeblagajne()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [BLGDOKIDDOKUMENT] AS BLGDOKIDDOKUMENT, [BLGBROJDOKUMENTA], [BLGDATUMDOKUMENTA], [BLGSVRHA], [BLGIZNOS], [IDBLGVRSTEDOK], [blggodineIDGODINE] AS blggodineIDGODINE FROM [BLAGAJNAStavkeBlagajne] WITH (UPDLOCK) WHERE [BLGDOKIDDOKUMENT] = @BLGDOKIDDOKUMENT AND [IDBLGVRSTEDOK] = @IDBLGVRSTEDOK AND [blggodineIDGODINE] = @blggodineIDGODINE AND [BLGBROJDOKUMENTA] = @BLGBROJDOKUMENTA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDOKIDDOKUMENT", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@blggodineIDGODINE", DbType.Int16));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGBROJDOKUMENTA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGDOKIDDOKUMENT"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["IDBLGVRSTEDOK"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["blggodineIDGODINE"]));
                command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGBROJDOKUMENTA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new BLAGAJNAStavkeBlagajneDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("BLAGAJNAStavkeBlagajne") }));
                }
                if ((!command.HasMoreRows || !DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__BLGDATUMDOKUMENTAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 2)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__BLGSVRHAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3))) || !this.m__BLGIZNOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4)))))
                {
                    reader.Close();
                    throw new BLAGAJNAStavkeBlagajneDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("BLAGAJNAStavkeBlagajne") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [BLGDOKIDDOKUMENT] AS BLGDOKIDDOKUMENT, [IDBLGVRSTEDOK], [blggodineIDGODINE] AS blggodineIDGODINE, [BLGBROJDOKUMENTA], [BLGIZNOSKONTIRANJA], [BLGSTAVKEBLAGAJNEKONTOIDKONTO] AS BLGSTAVKEBLAGAJNEKONTOIDKONTO, [BLGMTIDMJESTOTROSKA] AS BLGMTIDMJESTOTROSKA, [BLGORGJEDIDORGJED] AS BLGORGJEDIDORGJED FROM [BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje] WITH (UPDLOCK) WHERE [BLGDOKIDDOKUMENT] = @BLGDOKIDDOKUMENT AND [IDBLGVRSTEDOK] = @IDBLGVRSTEDOK AND [blggodineIDGODINE] = @blggodineIDGODINE AND [BLGBROJDOKUMENTA] = @BLGBROJDOKUMENTA AND [BLGSTAVKEBLAGAJNEKONTOIDKONTO] = @BLGSTAVKEBLAGAJNEKONTOIDKONTO ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDOKIDDOKUMENT", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@blggodineIDGODINE", DbType.Int16));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGBROJDOKUMENTA", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGSTAVKEBLAGAJNEKONTOIDKONTO", DbType.String, 14));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGDOKIDDOKUMENT"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["IDBLGVRSTEDOK"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["blggodineIDGODINE"]));
                command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGBROJDOKUMENTA"]));
                command.SetParameter(4, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGSTAVKEBLAGAJNEKONTOIDKONTO"]))));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje") }));
                }
                if ((!command.HasMoreRows || !this.m__BLGIZNOSKONTIRANJAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4)))) || (!this.m__BLGMTIDMJESTOTROSKAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 6))) || !this.m__BLGORGJEDIDORGJEDOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 7)))))
                {
                    reader.Close();
                    throw new BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowBlagajna()
        {
            this.rowBLAGAJNA = this.BLAGAJNASet.BLAGAJNA.NewBLAGAJNARow();
        }

        private void CreateNewRowBlagajnastavkeblagajne()
        {
            this.rowBLAGAJNAStavkeBlagajne = this.BLAGAJNASet.BLAGAJNAStavkeBlagajne.NewBLAGAJNAStavkeBlagajneRow();
        }

        private void CreateNewRowBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje = this.BLAGAJNASet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.NewBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyBlagajna();
            this.ProcessNestedLevelBlagajnastavkeblagajne();
            this.AfterConfirmBlagajna();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [BLAGAJNA]  WHERE [BLGDOKIDDOKUMENT] = @BLGDOKIDDOKUMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDOKIDDOKUMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["BLGDOKIDDOKUMENT"]));
            command.ExecuteStmt();
            this.OnBLAGAJNAUpdated(new BLAGAJNAEventArgs(this.rowBLAGAJNA, StatementType.Delete));
            this.rowBLAGAJNA.Delete();
            this.sMode180 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode180;
        }

        private void DeleteBlagajnastavkeblagajne()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyBlagajnastavkeblagajne();
            this.OnDeleteControlsBlagajnastavkeblagajne();
            this.ProcessNestedLevelBlagajnastavkeblagajnestavkeblagajnekontiranje();
            this.AfterConfirmBlagajnastavkeblagajne();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [BLAGAJNAStavkeBlagajne]  WHERE [BLGDOKIDDOKUMENT] = @BLGDOKIDDOKUMENT AND [IDBLGVRSTEDOK] = @IDBLGVRSTEDOK AND [blggodineIDGODINE] = @blggodineIDGODINE AND [BLGBROJDOKUMENTA] = @BLGBROJDOKUMENTA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDOKIDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@blggodineIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGBROJDOKUMENTA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGDOKIDDOKUMENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["IDBLGVRSTEDOK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["blggodineIDGODINE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGBROJDOKUMENTA"]));
            command.ExecuteStmt();
            this.OnBLAGAJNAStavkeBlagajneUpdated(new BLAGAJNAStavkeBlagajneEventArgs(this.rowBLAGAJNAStavkeBlagajne, StatementType.Delete));
            this.rowBLAGAJNAStavkeBlagajne.Delete();
            this.sMode181 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode181;
        }

        private void DeleteBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyBlagajnastavkeblagajnestavkeblagajnekontiranje();
            this.OnDeleteControlsBlagajnastavkeblagajnestavkeblagajnekontiranje();
            this.AfterConfirmBlagajnastavkeblagajnestavkeblagajnekontiranje();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje]  WHERE [BLGDOKIDDOKUMENT] = @BLGDOKIDDOKUMENT AND [IDBLGVRSTEDOK] = @IDBLGVRSTEDOK AND [blggodineIDGODINE] = @blggodineIDGODINE AND [BLGBROJDOKUMENTA] = @BLGBROJDOKUMENTA AND [BLGSTAVKEBLAGAJNEKONTOIDKONTO] = @BLGSTAVKEBLAGAJNEKONTOIDKONTO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDOKIDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@blggodineIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGBROJDOKUMENTA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGSTAVKEBLAGAJNEKONTOIDKONTO", DbType.String, 14));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGDOKIDDOKUMENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["IDBLGVRSTEDOK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["blggodineIDGODINE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGBROJDOKUMENTA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGSTAVKEBLAGAJNEKONTOIDKONTO"]))));
            command.ExecuteStmt();
            this.OnBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdated(new BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeEventArgs(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje, StatementType.Delete));
            this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.Delete();
            this.sMode182 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode182;
        }

        public virtual int Fill(BLAGAJNADataSet dataSet)
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
                    this.BLAGAJNASet = dataSet;
                    this.LoadChildBlagajna(0, -1);
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
            this.BLAGAJNASet = (BLAGAJNADataSet) dataSet;
            if (this.BLAGAJNASet != null)
            {
                return this.Fill(this.BLAGAJNASet);
            }
            this.BLAGAJNASet = new BLAGAJNADataSet();
            this.Fill(this.BLAGAJNASet);
            dataSet.Merge(this.BLAGAJNASet);
            return 0;
        }

        public virtual int Fill(BLAGAJNADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["BLGDOKIDDOKUMENT"]));
        }

        public virtual int Fill(BLAGAJNADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["BLGDOKIDDOKUMENT"]));
        }

        public virtual int Fill(BLAGAJNADataSet dataSet, int bLGDOKIDDOKUMENT)
        {
            if (!this.FillByBLGDOKIDDOKUMENT(dataSet, bLGDOKIDDOKUMENT))
            {
                throw new BLAGAJNANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("BLAGAJNA") }));
            }
            return 0;
        }

        public virtual bool FillByBLGDOKIDDOKUMENT(BLAGAJNADataSet dataSet, int bLGDOKIDDOKUMENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.BLAGAJNASet = dataSet;
            this.rowBLAGAJNA = this.BLAGAJNASet.BLAGAJNA.NewBLAGAJNARow();
            this.rowBLAGAJNA.BLGDOKIDDOKUMENT = bLGDOKIDDOKUMENT;
            try
            {
                this.LoadByBLGDOKIDDOKUMENT(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound180 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByBLGKONTOIDKONTO(BLAGAJNADataSet dataSet, string bLGKONTOIDKONTO)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.BLAGAJNASet = dataSet;
            this.rowBLAGAJNA = this.BLAGAJNASet.BLAGAJNA.NewBLAGAJNARow();
            this.rowBLAGAJNA.BLGKONTOIDKONTO = bLGKONTOIDKONTO;
            try
            {
                this.LoadByBLGKONTOIDKONTO(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(BLAGAJNADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.BLAGAJNASet = dataSet;
            try
            {
                this.LoadChildBlagajna(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByBLGKONTOIDKONTO(BLAGAJNADataSet dataSet, string bLGKONTOIDKONTO, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.BLAGAJNASet = dataSet;
            this.rowBLAGAJNA = this.BLAGAJNASet.BLAGAJNA.NewBLAGAJNARow();
            this.rowBLAGAJNA.BLGKONTOIDKONTO = bLGKONTOIDKONTO;
            try
            {
                this.LoadByBLGKONTOIDKONTO(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVBLAGAJNA], [BLGDOKIDDOKUMENT] AS BLGDOKIDDOKUMENT, [BLGKONTOIDKONTO] AS BLGKONTOIDKONTO FROM [BLAGAJNA] WITH (NOLOCK) WHERE [BLGDOKIDDOKUMENT] = @BLGDOKIDDOKUMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDOKIDDOKUMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["BLGDOKIDDOKUMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound180 = 1;
                this.rowBLAGAJNA["NAZIVBLAGAJNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowBLAGAJNA["BLGDOKIDDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 1));
                this.rowBLAGAJNA["BLGKONTOIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))));
                this.sMode180 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode180;
            }
            else
            {
                this.RcdFound180 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "BLGDOKIDDOKUMENT";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmBLAGAJNASelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [BLAGAJNA] WITH (NOLOCK) ", false);
            this.BLAGAJNASelect2 = this.cmBLAGAJNASelect2.FetchData();
            if (this.BLAGAJNASelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.BLAGAJNASelect2.GetInt32(0);
            }
            this.BLAGAJNASelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByBLGKONTOIDKONTO(string bLGKONTOIDKONTO)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmBLAGAJNASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [BLAGAJNA] WITH (NOLOCK) WHERE [BLGKONTOIDKONTO] = @BLGKONTOIDKONTO ", false);
            if (this.cmBLAGAJNASelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmBLAGAJNASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGKONTOIDKONTO", DbType.String, 14));
            }
            this.cmBLAGAJNASelect1.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(bLGKONTOIDKONTO)));
            this.BLAGAJNASelect1 = this.cmBLAGAJNASelect1.FetchData();
            if (this.BLAGAJNASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.BLAGAJNASelect1.GetInt32(0);
            }
            this.BLAGAJNASelect1.Close();
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

        public virtual int GetRecordCountByBLGKONTOIDKONTO(string bLGKONTOIDKONTO)
        {
            int internalRecordCountByBLGKONTOIDKONTO;
            try
            {
                this.InitializeMembers();
                internalRecordCountByBLGKONTOIDKONTO = this.GetInternalRecordCountByBLGKONTOIDKONTO(bLGKONTOIDKONTO);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByBLGKONTOIDKONTO;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound180 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__BLGIZNOSKONTIRANJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BLGMTIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BLGORGJEDIDORGJEDOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove31 = false;
            this.RcdFound182 = 0;
            this.m_SubSelTopString182 = "";
            this.m__BLGDATUMDOKUMENTAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BLGSVRHAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BLGIZNOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.RcdFound181 = 0;
            this.m_SubSelTopString181 = "";
            this.m__NAZIVBLAGAJNAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BLGKONTOIDKONTOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.BLAGAJNASet = new BLAGAJNADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertBlagajna()
        {
            this.CheckOptimisticConcurrencyBlagajna();
            this.AfterConfirmBlagajna();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [BLAGAJNA] ([NAZIVBLAGAJNA], [BLGDOKIDDOKUMENT], [BLGKONTOIDKONTO]) VALUES (@NAZIVBLAGAJNA, @BLGDOKIDDOKUMENT, @BLGKONTOIDKONTO)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVBLAGAJNA", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDOKIDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGKONTOIDKONTO", DbType.String, 14));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["NAZIVBLAGAJNA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["BLGDOKIDDOKUMENT"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["BLGKONTOIDKONTO"]))));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new BLAGAJNADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsBlagajna();
            }
            this.OnBLAGAJNAUpdated(new BLAGAJNAEventArgs(this.rowBLAGAJNA, StatementType.Insert));
            this.ProcessLevelBlagajna();
        }

        private void InsertBlagajnastavkeblagajne()
        {
            this.CheckOptimisticConcurrencyBlagajnastavkeblagajne();
            this.CheckExtendedTableBlagajnastavkeblagajne();
            this.AfterConfirmBlagajnastavkeblagajne();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [BLAGAJNAStavkeBlagajne] ([BLGDOKIDDOKUMENT], [BLGBROJDOKUMENTA], [BLGDATUMDOKUMENTA], [BLGSVRHA], [BLGIZNOS], [IDBLGVRSTEDOK], [blggodineIDGODINE]) VALUES (@BLGDOKIDDOKUMENT, @BLGBROJDOKUMENTA, @BLGDATUMDOKUMENTA, @BLGSVRHA, @BLGIZNOS, @IDBLGVRSTEDOK, @blggodineIDGODINE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDOKIDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGBROJDOKUMENTA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDATUMDOKUMENTA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGSVRHA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@blggodineIDGODINE", DbType.Int16));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGDOKIDDOKUMENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGBROJDOKUMENTA"]));
            command.SetParameterDateObject(2, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGDATUMDOKUMENTA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGSVRHA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGIZNOS"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["IDBLGVRSTEDOK"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["blggodineIDGODINE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new BLAGAJNAStavkeBlagajneDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsBlagajnastavkeblagajne();
            }
            this.OnBLAGAJNAStavkeBlagajneUpdated(new BLAGAJNAStavkeBlagajneEventArgs(this.rowBLAGAJNAStavkeBlagajne, StatementType.Insert));
            this.ProcessLevelBlagajnastavkeblagajne();
        }

        private void InsertBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            this.CheckOptimisticConcurrencyBlagajnastavkeblagajnestavkeblagajnekontiranje();
            this.CheckExtendedTableBlagajnastavkeblagajnestavkeblagajnekontiranje();
            this.AfterConfirmBlagajnastavkeblagajnestavkeblagajnekontiranje();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje] ([BLGDOKIDDOKUMENT], [IDBLGVRSTEDOK], [blggodineIDGODINE], [BLGBROJDOKUMENTA], [BLGIZNOSKONTIRANJA], [BLGSTAVKEBLAGAJNEKONTOIDKONTO], [BLGMTIDMJESTOTROSKA], [BLGORGJEDIDORGJED]) VALUES (@BLGDOKIDDOKUMENT, @IDBLGVRSTEDOK, @blggodineIDGODINE, @BLGBROJDOKUMENTA, @BLGIZNOSKONTIRANJA, @BLGSTAVKEBLAGAJNEKONTOIDKONTO, @BLGMTIDMJESTOTROSKA, @BLGORGJEDIDORGJED)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDOKIDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@blggodineIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGBROJDOKUMENTA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGIZNOSKONTIRANJA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGSTAVKEBLAGAJNEKONTOIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGMTIDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGORGJEDIDORGJED", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGDOKIDDOKUMENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["IDBLGVRSTEDOK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["blggodineIDGODINE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGBROJDOKUMENTA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGIZNOSKONTIRANJA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGSTAVKEBLAGAJNEKONTOIDKONTO"]))));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGMTIDMJESTOTROSKA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGORGJEDIDORGJED"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdated(new BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeEventArgs(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje, StatementType.Insert));
        }

        private void LoadByBLGDOKIDDOKUMENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.BLAGAJNASet.EnforceConstraints;
            this.BLAGAJNASet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BeginLoadData();
            this.BLAGAJNASet.BLAGAJNAStavkeBlagajne.BeginLoadData();
            this.BLAGAJNASet.BLAGAJNA.BeginLoadData();
            this.ScanByBLGDOKIDDOKUMENT(startRow, maxRows);
            this.BLAGAJNASet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.EndLoadData();
            this.BLAGAJNASet.BLAGAJNAStavkeBlagajne.EndLoadData();
            this.BLAGAJNASet.BLAGAJNA.EndLoadData();
            this.BLAGAJNASet.EnforceConstraints = enforceConstraints;
            if (this.BLAGAJNASet.BLAGAJNA.Count > 0)
            {
                this.rowBLAGAJNA = this.BLAGAJNASet.BLAGAJNA[this.BLAGAJNASet.BLAGAJNA.Count - 1];
            }
        }

        private void LoadByBLGKONTOIDKONTO(int startRow, int maxRows)
        {
            bool enforceConstraints = this.BLAGAJNASet.EnforceConstraints;
            this.BLAGAJNASet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BeginLoadData();
            this.BLAGAJNASet.BLAGAJNAStavkeBlagajne.BeginLoadData();
            this.BLAGAJNASet.BLAGAJNA.BeginLoadData();
            this.ScanByBLGKONTOIDKONTO(startRow, maxRows);
            this.BLAGAJNASet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.EndLoadData();
            this.BLAGAJNASet.BLAGAJNAStavkeBlagajne.EndLoadData();
            this.BLAGAJNASet.BLAGAJNA.EndLoadData();
            this.BLAGAJNASet.EnforceConstraints = enforceConstraints;
            if (this.BLAGAJNASet.BLAGAJNA.Count > 0)
            {
                this.rowBLAGAJNA = this.BLAGAJNASet.BLAGAJNA[this.BLAGAJNASet.BLAGAJNA.Count - 1];
            }
        }

        private void LoadChildBlagajna(int startRow, int maxRows)
        {
            this.CreateNewRowBlagajna();
            bool enforceConstraints = this.BLAGAJNASet.EnforceConstraints;
            this.BLAGAJNASet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BeginLoadData();
            this.BLAGAJNASet.BLAGAJNAStavkeBlagajne.BeginLoadData();
            this.BLAGAJNASet.BLAGAJNA.BeginLoadData();
            this.ScanStartBlagajna(startRow, maxRows);
            this.BLAGAJNASet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.EndLoadData();
            this.BLAGAJNASet.BLAGAJNAStavkeBlagajne.EndLoadData();
            this.BLAGAJNASet.BLAGAJNA.EndLoadData();
            this.BLAGAJNASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildBlagajnastavkeblagajne()
        {
            this.CreateNewRowBlagajnastavkeblagajne();
            this.ScanStartBlagajnastavkeblagajne();
        }

        private void LoadChildBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            this.CreateNewRowBlagajnastavkeblagajnestavkeblagajnekontiranje();
            this.ScanStartBlagajnastavkeblagajnestavkeblagajnekontiranje();
        }

        private void LoadDataBlagajna(int maxRows)
        {
            int num = 0;
            if (this.RcdFound180 != 0)
            {
                this.ScanLoadBlagajna();
                while ((this.RcdFound180 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowBlagajna();
                    this.CreateNewRowBlagajna();
                    this.ScanNextBlagajna();
                }
            }
            if (num > 0)
            {
                this.RcdFound180 = 1;
            }
            this.ScanEndBlagajna();
            if (this.BLAGAJNASet.BLAGAJNA.Count > 0)
            {
                this.rowBLAGAJNA = this.BLAGAJNASet.BLAGAJNA[this.BLAGAJNASet.BLAGAJNA.Count - 1];
            }
        }

        private void LoadDataBlagajnastavkeblagajne()
        {
            while (this.RcdFound181 != 0)
            {
                this.LoadRowBlagajnastavkeblagajne();
                this.CreateNewRowBlagajnastavkeblagajne();
                this.ScanNextBlagajnastavkeblagajne();
            }
            this.ScanEndBlagajnastavkeblagajne();
        }

        private void LoadDataBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            while (this.RcdFound182 != 0)
            {
                this.LoadRowBlagajnastavkeblagajnestavkeblagajnekontiranje();
                this.CreateNewRowBlagajnastavkeblagajnestavkeblagajnekontiranje();
                this.ScanNextBlagajnastavkeblagajnestavkeblagajnekontiranje();
            }
            this.ScanEndBlagajnastavkeblagajnestavkeblagajnekontiranje();
        }

        private void LoadRowBlagajna()
        {
            this.AddRowBlagajna();
        }

        private void LoadRowBlagajnastavkeblagajne()
        {
            this.AddRowBlagajnastavkeblagajne();
        }

        private void LoadRowBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            this.AddRowBlagajnastavkeblagajnestavkeblagajnekontiranje();
        }

        private void OnBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdated(BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeEventArgs e)
        {
            if (this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdated != null)
            {
                BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdateEventHandler bLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdatedEvent = this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdated;
                if (bLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdatedEvent != null)
                {
                    bLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdatedEvent(this, e);
                }
            }
        }

        private void OnBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdating(BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeEventArgs e)
        {
            if (this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdating != null)
            {
                BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdateEventHandler bLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdatingEvent = this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdating;
                if (bLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdatingEvent != null)
                {
                    bLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdatingEvent(this, e);
                }
            }
        }

        private void OnBLAGAJNAStavkeBlagajneUpdated(BLAGAJNAStavkeBlagajneEventArgs e)
        {
            if (this.BLAGAJNAStavkeBlagajneUpdated != null)
            {
                BLAGAJNAStavkeBlagajneUpdateEventHandler bLAGAJNAStavkeBlagajneUpdatedEvent = this.BLAGAJNAStavkeBlagajneUpdated;
                if (bLAGAJNAStavkeBlagajneUpdatedEvent != null)
                {
                    bLAGAJNAStavkeBlagajneUpdatedEvent(this, e);
                }
            }
        }

        private void OnBLAGAJNAStavkeBlagajneUpdating(BLAGAJNAStavkeBlagajneEventArgs e)
        {
            if (this.BLAGAJNAStavkeBlagajneUpdating != null)
            {
                BLAGAJNAStavkeBlagajneUpdateEventHandler bLAGAJNAStavkeBlagajneUpdatingEvent = this.BLAGAJNAStavkeBlagajneUpdating;
                if (bLAGAJNAStavkeBlagajneUpdatingEvent != null)
                {
                    bLAGAJNAStavkeBlagajneUpdatingEvent(this, e);
                }
            }
        }

        private void OnBLAGAJNAUpdated(BLAGAJNAEventArgs e)
        {
            if (this.BLAGAJNAUpdated != null)
            {
                BLAGAJNAUpdateEventHandler bLAGAJNAUpdatedEvent = this.BLAGAJNAUpdated;
                if (bLAGAJNAUpdatedEvent != null)
                {
                    bLAGAJNAUpdatedEvent(this, e);
                }
            }
        }

        private void OnBLAGAJNAUpdating(BLAGAJNAEventArgs e)
        {
            if (this.BLAGAJNAUpdating != null)
            {
                BLAGAJNAUpdateEventHandler bLAGAJNAUpdatingEvent = this.BLAGAJNAUpdating;
                if (bLAGAJNAUpdatingEvent != null)
                {
                    bLAGAJNAUpdatingEvent(this, e);
                }
            }
        }

        private void OnDeleteControlsBlagajnastavkeblagajne()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVVRSTEDOK] FROM [BLGVRSTEDOK] WITH (NOLOCK) WHERE [IDBLGVRSTEDOK] = @IDBLGVRSTEDOK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["IDBLGVRSTEDOK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowBLAGAJNAStavkeBlagajne["NAZIVVRSTEDOK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void OnDeleteControlsBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVKONTO] AS BLGSTAVKEBLAGAJNEKONTONAZIVKONTO FROM [KONTO] WITH (NOLOCK) WHERE [IDKONTO] = @BLGSTAVKEBLAGAJNEKONTOIDKONTO ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGSTAVKEBLAGAJNEKONTOIDKONTO", DbType.String, 14));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGSTAVKEBLAGAJNEKONTOIDKONTO"]))));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGSTAVKEBLAGAJNEKONTONAZIVKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0))));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVMJESTOTROSKA] AS BLGMTNAZIVMJESTOTROSKA FROM [MJESTOTROSKA] WITH (NOLOCK) WHERE [IDMJESTOTROSKA] = @BLGMTIDMJESTOTROSKA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGMTIDMJESTOTROSKA", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGMTIDMJESTOTROSKA"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGMTNAZIVMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0))));
            }
            reader2.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVORGJED] AS BLGORGJEDNAZIVORGJED FROM [ORGJED] WITH (NOLOCK) WHERE [IDORGJED] = @BLGORGJEDIDORGJED ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGORGJEDIDORGJED", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGORGJEDIDORGJED"]));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGORGJEDNAZIVORGJED"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0))));
            }
            reader3.Close();
        }

        private void ProcessLevelBlagajna()
        {
            this.sMode180 = this.Gx_mode;
            this.ProcessNestedLevelBlagajnastavkeblagajne();
            this.Gx_mode = this.sMode180;
        }

        private void ProcessLevelBlagajnastavkeblagajne()
        {
            this.sMode181 = this.Gx_mode;
            this.ProcessNestedLevelBlagajnastavkeblagajnestavkeblagajnekontiranje();
            this.Gx_mode = this.sMode181;
        }

        private void ProcessNestedLevelBlagajnastavkeblagajne()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.BLAGAJNASet.BLAGAJNAStavkeBlagajne.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowBLAGAJNAStavkeBlagajne = (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow) current;
                    if (Helpers.IsRowChanged(this.rowBLAGAJNAStavkeBlagajne))
                    {
                        bool flag = false;
                        if (this.rowBLAGAJNAStavkeBlagajne.RowState != DataRowState.Deleted)
                        {
                            this.rowBLAGAJNAStavkeBlagajne["BLGDATUMDOKUMENTA"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGDATUMDOKUMENTA"])));
                        }
                        if (this.rowBLAGAJNAStavkeBlagajne.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowBLAGAJNAStavkeBlagajne.BLGDOKIDDOKUMENT == this.rowBLAGAJNA.BLGDOKIDDOKUMENT;
                        }
                        else
                        {
                            flag = this.rowBLAGAJNAStavkeBlagajne["BLGDOKIDDOKUMENT", DataRowVersion.Original].Equals(this.rowBLAGAJNA.BLGDOKIDDOKUMENT);
                        }
                        if (flag)
                        {
                            this.ReadRowBlagajnastavkeblagajne();
                            if (this.rowBLAGAJNAStavkeBlagajne.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertBlagajnastavkeblagajne();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteBlagajnastavkeblagajne();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateBlagajnastavkeblagajne();
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

        private void ProcessNestedLevelBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.BLAGAJNASet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje = (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow) current;
                    if (Helpers.IsRowChanged(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje))
                    {
                        bool flag = false;
                        if (this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.RowState != DataRowState.Deleted)
                        {
                            flag = ((this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGDOKIDDOKUMENT == this.rowBLAGAJNAStavkeBlagajne.BLGDOKIDDOKUMENT) && (this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.IDBLGVRSTEDOK == this.rowBLAGAJNAStavkeBlagajne.IDBLGVRSTEDOK)) && ((this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.blggodineIDGODINE == this.rowBLAGAJNAStavkeBlagajne.blggodineIDGODINE) && (this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.BLGBROJDOKUMENTA == this.rowBLAGAJNAStavkeBlagajne.BLGBROJDOKUMENTA));
                        }
                        else
                        {
                            flag = (this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGDOKIDDOKUMENT", DataRowVersion.Original].Equals(this.rowBLAGAJNAStavkeBlagajne.BLGDOKIDDOKUMENT) && this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["IDBLGVRSTEDOK", DataRowVersion.Original].Equals(this.rowBLAGAJNAStavkeBlagajne.IDBLGVRSTEDOK)) && (this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["blggodineIDGODINE", DataRowVersion.Original].Equals(this.rowBLAGAJNAStavkeBlagajne.blggodineIDGODINE) && this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGBROJDOKUMENTA", DataRowVersion.Original].Equals(this.rowBLAGAJNAStavkeBlagajne.BLGBROJDOKUMENTA));
                        }
                        if (flag)
                        {
                            this.ReadRowBlagajnastavkeblagajnestavkeblagajnekontiranje();
                            if (this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertBlagajnastavkeblagajnestavkeblagajnekontiranje();
                            }
                            else
                            {
                                if (this._Gxremove31)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteBlagajnastavkeblagajnestavkeblagajnekontiranje();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateBlagajnastavkeblagajnestavkeblagajnekontiranje();
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

        private void ReadRowBlagajna()
        {
            this.Gx_mode = Mode.FromRowState(this.rowBLAGAJNA.RowState);
            if (this.rowBLAGAJNA.RowState != DataRowState.Added)
            {
                this.m__NAZIVBLAGAJNAOriginal = RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["NAZIVBLAGAJNA", DataRowVersion.Original]);
                this.m__BLGKONTOIDKONTOOriginal = RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["BLGKONTOIDKONTO", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVBLAGAJNAOriginal = RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["NAZIVBLAGAJNA"]);
                this.m__BLGKONTOIDKONTOOriginal = RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["BLGKONTOIDKONTO"]);
            }
            this._Gxremove = this.rowBLAGAJNA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowBLAGAJNA = (BLAGAJNADataSet.BLAGAJNARow) DataSetUtil.CloneOriginalDataRow(this.rowBLAGAJNA);
            }
        }

        private void ReadRowBlagajnastavkeblagajne()
        {
            this.Gx_mode = Mode.FromRowState(this.rowBLAGAJNAStavkeBlagajne.RowState);
            if (this.rowBLAGAJNAStavkeBlagajne.RowState != DataRowState.Added)
            {
                this.m__BLGDATUMDOKUMENTAOriginal = RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGDATUMDOKUMENTA", DataRowVersion.Original]);
                this.m__BLGSVRHAOriginal = RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGSVRHA", DataRowVersion.Original]);
                this.m__BLGIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGIZNOS", DataRowVersion.Original]);
            }
            else
            {
                this.m__BLGDATUMDOKUMENTAOriginal = RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGDATUMDOKUMENTA"]);
                this.m__BLGSVRHAOriginal = RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGSVRHA"]);
                this.m__BLGIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGIZNOS"]);
            }
            this._Gxremove = this.rowBLAGAJNAStavkeBlagajne.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowBLAGAJNAStavkeBlagajne = (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow) DataSetUtil.CloneOriginalDataRow(this.rowBLAGAJNAStavkeBlagajne);
            }
        }

        private void ReadRowBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            this.Gx_mode = Mode.FromRowState(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.RowState);
            if (this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.RowState != DataRowState.Added)
            {
                this.m__BLGIZNOSKONTIRANJAOriginal = RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGIZNOSKONTIRANJA", DataRowVersion.Original]);
                this.m__BLGMTIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGMTIDMJESTOTROSKA", DataRowVersion.Original]);
                this.m__BLGORGJEDIDORGJEDOriginal = RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGORGJEDIDORGJED", DataRowVersion.Original]);
            }
            else
            {
                this.m__BLGIZNOSKONTIRANJAOriginal = RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGIZNOSKONTIRANJA"]);
                this.m__BLGMTIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGMTIDMJESTOTROSKA"]);
                this.m__BLGORGJEDIDORGJEDOriginal = RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGORGJEDIDORGJED"]);
            }
            this._Gxremove31 = this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje.RowState == DataRowState.Deleted;
            if (this._Gxremove31)
            {
                this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje = (BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow) DataSetUtil.CloneOriginalDataRow(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje);
            }
        }

        private void ScanByBLGDOKIDDOKUMENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[BLGDOKIDDOKUMENT] = @BLGDOKIDDOKUMENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString180 + "  FROM [BLAGAJNA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[BLGDOKIDDOKUMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString180, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[BLGDOKIDDOKUMENT] ) AS DK_PAGENUM   FROM [BLAGAJNA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString180 + " FROM [BLAGAJNA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[BLGDOKIDDOKUMENT] ";
            }
            this.cmBLAGAJNASelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmBLAGAJNASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmBLAGAJNASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDOKIDDOKUMENT", DbType.Int32));
            }
            this.cmBLAGAJNASelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["BLGDOKIDDOKUMENT"]));
            this.BLAGAJNASelect5 = this.cmBLAGAJNASelect5.FetchData();
            this.RcdFound180 = 0;
            this.ScanLoadBlagajna();
            this.LoadDataBlagajna(maxRows);
            if (this.RcdFound180 > 0)
            {
                this.SubLvlScanStartBlagajnastavkeblagajne(this.m_WhereString, startRow, maxRows);
                this.SetParametersBLGDOKIDDOKUMENTBlagajna(this.cmBLAGAJNAStavkeBlagajneSelect2);
                this.SubLvlFetchBlagajnastavkeblagajne();
                this.SubLoadDataBlagajnastavkeblagajne();
                this.SubLvlScanStartBlagajnastavkeblagajnestavkeblagajnekontiranje(this.m_WhereString, startRow, maxRows);
                this.SetParametersBLGDOKIDDOKUMENTBlagajna(this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2);
                this.SubLvlFetchBlagajnastavkeblagajnestavkeblagajnekontiranje();
                this.SubLoadDataBlagajnastavkeblagajnestavkeblagajnekontiranje();
            }
        }

        private void ScanByBLGKONTOIDKONTO(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[BLGKONTOIDKONTO] = @BLGKONTOIDKONTO";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString180 + "  FROM [BLAGAJNA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[BLGDOKIDDOKUMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString180, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[BLGDOKIDDOKUMENT] ) AS DK_PAGENUM   FROM [BLAGAJNA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString180 + " FROM [BLAGAJNA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[BLGDOKIDDOKUMENT] ";
            }
            this.cmBLAGAJNASelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmBLAGAJNASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmBLAGAJNASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGKONTOIDKONTO", DbType.String, 14));
            }
            this.cmBLAGAJNASelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["BLGKONTOIDKONTO"]))));
            this.BLAGAJNASelect5 = this.cmBLAGAJNASelect5.FetchData();
            this.RcdFound180 = 0;
            this.ScanLoadBlagajna();
            this.LoadDataBlagajna(maxRows);
            if (this.RcdFound180 > 0)
            {
                this.SubLvlScanStartBlagajnastavkeblagajne(this.m_WhereString, startRow, maxRows);
                this.SetParametersBLGKONTOIDKONTOBlagajna(this.cmBLAGAJNAStavkeBlagajneSelect2);
                this.SubLvlFetchBlagajnastavkeblagajne();
                this.SubLoadDataBlagajnastavkeblagajne();
                this.SubLvlScanStartBlagajnastavkeblagajnestavkeblagajnekontiranje(this.m_WhereString, startRow, maxRows);
                this.SetParametersBLGKONTOIDKONTOBlagajna(this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2);
                this.SubLvlFetchBlagajnastavkeblagajnestavkeblagajnekontiranje();
                this.SubLoadDataBlagajnastavkeblagajnestavkeblagajnekontiranje();
            }
        }

        private void ScanEndBlagajna()
        {
            this.BLAGAJNASelect5.Close();
        }

        private void ScanEndBlagajnastavkeblagajne()
        {
            this.BLAGAJNAStavkeBlagajneSelect2.Close();
        }

        private void ScanEndBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2.Close();
        }

        private void ScanLoadBlagajna()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmBLAGAJNASelect5.HasMoreRows)
            {
                this.RcdFound180 = 1;
                this.rowBLAGAJNA["NAZIVBLAGAJNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BLAGAJNASelect5, 0));
                this.rowBLAGAJNA["BLGDOKIDDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.BLAGAJNASelect5, 1));
                this.rowBLAGAJNA["BLGKONTOIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BLAGAJNASelect5, 2))));
            }
        }

        private void ScanLoadBlagajnastavkeblagajne()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmBLAGAJNAStavkeBlagajneSelect2.HasMoreRows)
            {
                this.RcdFound181 = 1;
                this.rowBLAGAJNAStavkeBlagajne["BLGDOKIDDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.BLAGAJNAStavkeBlagajneSelect2, 0));
                this.rowBLAGAJNAStavkeBlagajne["BLGBROJDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.BLAGAJNAStavkeBlagajneSelect2, 1));
                this.rowBLAGAJNAStavkeBlagajne["NAZIVVRSTEDOK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BLAGAJNAStavkeBlagajneSelect2, 2));
                this.rowBLAGAJNAStavkeBlagajne["BLGDATUMDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.BLAGAJNAStavkeBlagajneSelect2, 3));
                this.rowBLAGAJNAStavkeBlagajne["BLGSVRHA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BLAGAJNAStavkeBlagajneSelect2, 4));
                this.rowBLAGAJNAStavkeBlagajne["BLGIZNOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.BLAGAJNAStavkeBlagajneSelect2, 5));
                this.rowBLAGAJNAStavkeBlagajne["IDBLGVRSTEDOK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.BLAGAJNAStavkeBlagajneSelect2, 6));
                this.rowBLAGAJNAStavkeBlagajne["blggodineIDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.BLAGAJNAStavkeBlagajneSelect2, 7));
                this.rowBLAGAJNAStavkeBlagajne["NAZIVVRSTEDOK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BLAGAJNAStavkeBlagajneSelect2, 2));
            }
        }

        private void ScanLoadBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2.HasMoreRows)
            {
                this.RcdFound182 = 1;
                this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGDOKIDDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2, 0));
                this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["IDBLGVRSTEDOK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2, 1));
                this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["blggodineIDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2, 2));
                this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGBROJDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2, 3));
                this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGSTAVKEBLAGAJNEKONTONAZIVKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2, 4))));
                this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGMTNAZIVMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2, 5))));
                this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGORGJEDNAZIVORGJED"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2, 6))));
                this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGIZNOSKONTIRANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2, 7));
                this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGSTAVKEBLAGAJNEKONTOIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2, 8))));
                this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGMTIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2, 9));
                this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGORGJEDIDORGJED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2, 10));
                this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGSTAVKEBLAGAJNEKONTONAZIVKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2, 4))));
                this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGMTNAZIVMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2, 5))));
                this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGORGJEDNAZIVORGJED"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2, 6))));
            }
        }

        private void ScanNextBlagajna()
        {
            this.cmBLAGAJNASelect5.HasMoreRows = this.BLAGAJNASelect5.Read();
            this.RcdFound180 = 0;
            this.ScanLoadBlagajna();
        }

        private void ScanNextBlagajnastavkeblagajne()
        {
            this.cmBLAGAJNAStavkeBlagajneSelect2.HasMoreRows = this.BLAGAJNAStavkeBlagajneSelect2.Read();
            this.RcdFound181 = 0;
            this.ScanLoadBlagajnastavkeblagajne();
        }

        private void ScanNextBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2.HasMoreRows = this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2.Read();
            this.RcdFound182 = 0;
            this.ScanLoadBlagajnastavkeblagajnestavkeblagajnekontiranje();
        }

        private void ScanStartBlagajna(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString180 + "  FROM [BLAGAJNA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[BLGDOKIDDOKUMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString180, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[BLGDOKIDDOKUMENT] ) AS DK_PAGENUM   FROM [BLAGAJNA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString180 + " FROM [BLAGAJNA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[BLGDOKIDDOKUMENT] ";
            }
            this.cmBLAGAJNASelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.BLAGAJNASelect5 = this.cmBLAGAJNASelect5.FetchData();
            this.RcdFound180 = 0;
            this.ScanLoadBlagajna();
            this.LoadDataBlagajna(maxRows);
            if (this.RcdFound180 > 0)
            {
                this.SubLvlScanStartBlagajnastavkeblagajne(this.m_WhereString, startRow, maxRows);
                this.SetParametersBlagajnaBlagajna(this.cmBLAGAJNAStavkeBlagajneSelect2);
                this.SubLvlFetchBlagajnastavkeblagajne();
                this.SubLoadDataBlagajnastavkeblagajne();
                this.SubLvlScanStartBlagajnastavkeblagajnestavkeblagajnekontiranje(this.m_WhereString, startRow, maxRows);
                this.SetParametersBlagajnaBlagajna(this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2);
                this.SubLvlFetchBlagajnastavkeblagajnestavkeblagajnekontiranje();
                this.SubLoadDataBlagajnastavkeblagajnestavkeblagajnekontiranje();
            }
        }

        private void ScanStartBlagajnastavkeblagajne()
        {
            this.cmBLAGAJNAStavkeBlagajneSelect2 = this.connDefault.GetCommand("SELECT T1.[BLGDOKIDDOKUMENT] AS BLGDOKIDDOKUMENT, T1.[BLGBROJDOKUMENTA], T2.[NAZIVVRSTEDOK], T1.[BLGDATUMDOKUMENTA], T1.[BLGSVRHA], T1.[BLGIZNOS], T1.[IDBLGVRSTEDOK], T1.[blggodineIDGODINE] AS blggodineIDGODINE FROM ([BLAGAJNAStavkeBlagajne] T1 WITH (NOLOCK) INNER JOIN [BLGVRSTEDOK] T2 WITH (NOLOCK) ON T2.[IDBLGVRSTEDOK] = T1.[IDBLGVRSTEDOK]) WHERE T1.[BLGDOKIDDOKUMENT] = @BLGDOKIDDOKUMENT ORDER BY T1.[BLGDOKIDDOKUMENT], T1.[IDBLGVRSTEDOK], T1.[blggodineIDGODINE], T1.[BLGBROJDOKUMENTA] ", false);
            if (this.cmBLAGAJNAStavkeBlagajneSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmBLAGAJNAStavkeBlagajneSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDOKIDDOKUMENT", DbType.Int32));
            }
            this.cmBLAGAJNAStavkeBlagajneSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGDOKIDDOKUMENT"]));
            this.BLAGAJNAStavkeBlagajneSelect2 = this.cmBLAGAJNAStavkeBlagajneSelect2.FetchData();
            this.RcdFound181 = 0;
            this.ScanLoadBlagajnastavkeblagajne();
        }

        private void ScanStartBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2 = this.connDefault.GetCommand("SELECT T1.[BLGDOKIDDOKUMENT] AS BLGDOKIDDOKUMENT, T1.[IDBLGVRSTEDOK], T1.[blggodineIDGODINE] AS blggodineIDGODINE, T1.[BLGBROJDOKUMENTA], T2.[NAZIVKONTO] AS BLGSTAVKEBLAGAJNEKONTONAZIVKONTO, T3.[NAZIVMJESTOTROSKA] AS BLGMTNAZIVMJESTOTROSKA, T4.[NAZIVORGJED] AS BLGORGJEDNAZIVORGJED, T1.[BLGIZNOSKONTIRANJA], T1.[BLGSTAVKEBLAGAJNEKONTOIDKONTO] AS BLGSTAVKEBLAGAJNEKONTOIDKONTO, T1.[BLGMTIDMJESTOTROSKA] AS BLGMTIDMJESTOTROSKA, T1.[BLGORGJEDIDORGJED] AS BLGORGJEDIDORGJED FROM ((([BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje] T1 WITH (NOLOCK) INNER JOIN [KONTO] T2 WITH (NOLOCK) ON T2.[IDKONTO] = T1.[BLGSTAVKEBLAGAJNEKONTOIDKONTO]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = T1.[BLGMTIDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = T1.[BLGORGJEDIDORGJED]) WHERE T1.[BLGDOKIDDOKUMENT] = @BLGDOKIDDOKUMENT and T1.[IDBLGVRSTEDOK] = @IDBLGVRSTEDOK and T1.[blggodineIDGODINE] = @blggodineIDGODINE and T1.[BLGBROJDOKUMENTA] = @BLGBROJDOKUMENTA ORDER BY T1.[BLGDOKIDDOKUMENT], T1.[IDBLGVRSTEDOK], T1.[blggodineIDGODINE], T1.[BLGBROJDOKUMENTA], T1.[BLGSTAVKEBLAGAJNEKONTOIDKONTO] ", false);
            if (this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDOKIDDOKUMENT", DbType.Int32));
                this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
                this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@blggodineIDGODINE", DbType.Int16));
                this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGBROJDOKUMENTA", DbType.Int32));
            }
            this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGDOKIDDOKUMENT"]));
            this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["IDBLGVRSTEDOK"]));
            this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["blggodineIDGODINE"]));
            this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGBROJDOKUMENTA"]));
            this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2 = this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2.FetchData();
            this.RcdFound182 = 0;
            this.ScanLoadBlagajnastavkeblagajnestavkeblagajnekontiranje();
        }

        private void SetParametersBlagajnaBlagajna(ReadWriteCommand m_Command)
        {
        }

        private void SetParametersBLGDOKIDDOKUMENTBlagajna(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDOKIDDOKUMENT", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["BLGDOKIDDOKUMENT"]));
        }

        private void SetParametersBLGKONTOIDKONTOBlagajna(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGKONTOIDKONTO", DbType.String, 14));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["BLGKONTOIDKONTO"]))));
        }

        private void SkipNextBlagajnastavkeblagajne()
        {
            this.cmBLAGAJNAStavkeBlagajneSelect2.HasMoreRows = this.BLAGAJNAStavkeBlagajneSelect2.Read();
            this.RcdFound181 = 0;
            if (this.cmBLAGAJNAStavkeBlagajneSelect2.HasMoreRows)
            {
                this.RcdFound181 = 1;
            }
        }

        private void SkipNextBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2.HasMoreRows = this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2.Read();
            this.RcdFound182 = 0;
            if (this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2.HasMoreRows)
            {
                this.RcdFound182 = 1;
            }
        }

        private void SubLoadDataBlagajnastavkeblagajne()
        {
            while (this.RcdFound181 != 0)
            {
                this.LoadRowBlagajnastavkeblagajne();
                this.CreateNewRowBlagajnastavkeblagajne();
                this.ScanNextBlagajnastavkeblagajne();
            }
            this.ScanEndBlagajnastavkeblagajne();
        }

        private void SubLoadDataBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            while (this.RcdFound182 != 0)
            {
                this.LoadRowBlagajnastavkeblagajnestavkeblagajnekontiranje();
                this.CreateNewRowBlagajnastavkeblagajnestavkeblagajnekontiranje();
                this.ScanNextBlagajnastavkeblagajnestavkeblagajnekontiranje();
            }
            this.ScanEndBlagajnastavkeblagajnestavkeblagajnekontiranje();
        }

        private void SubLvlFetchBlagajnastavkeblagajne()
        {
            this.CreateNewRowBlagajnastavkeblagajne();
            this.BLAGAJNAStavkeBlagajneSelect2 = this.cmBLAGAJNAStavkeBlagajneSelect2.FetchData();
            this.RcdFound181 = 0;
            this.ScanLoadBlagajnastavkeblagajne();
        }

        private void SubLvlFetchBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            this.CreateNewRowBlagajnastavkeblagajnestavkeblagajnekontiranje();
            this.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2 = this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2.FetchData();
            this.RcdFound182 = 0;
            this.ScanLoadBlagajnastavkeblagajnestavkeblagajnekontiranje();
        }

        private void SubLvlScanStartBlagajnastavkeblagajne(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString181 = "(SELECT TOP " + maxRows.ToString() + " TM1.[BLGDOKIDDOKUMENT]  FROM [BLAGAJNA]  TM1 " + this.m_WhereString + " ORDER BY TM1.[BLGDOKIDDOKUMENT] )";
                    this.scmdbuf = "SELECT T1.[BLGDOKIDDOKUMENT] AS BLGDOKIDDOKUMENT, T1.[BLGBROJDOKUMENTA], T3.[NAZIVVRSTEDOK], T1.[BLGDATUMDOKUMENTA], T1.[BLGSVRHA], T1.[BLGIZNOS], T1.[IDBLGVRSTEDOK], T1.[blggodineIDGODINE] AS blggodineIDGODINE FROM (([BLAGAJNAStavkeBlagajne] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString181 + "  TMX ON TMX.[BLGDOKIDDOKUMENT] = T1.[BLGDOKIDDOKUMENT]) INNER JOIN [BLGVRSTEDOK] T3 WITH (NOLOCK) ON T3.[IDBLGVRSTEDOK] = T1.[IDBLGVRSTEDOK]) ORDER BY T1.[BLGDOKIDDOKUMENT], T1.[IDBLGVRSTEDOK], T1.[blggodineIDGODINE], T1.[BLGBROJDOKUMENTA]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[BLGDOKIDDOKUMENT], ROW_NUMBER() OVER  (  ORDER BY TM1.[BLGDOKIDDOKUMENT]  ) AS DK_PAGENUM   FROM [BLAGAJNA]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString181 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[BLGDOKIDDOKUMENT] AS BLGDOKIDDOKUMENT, T1.[BLGBROJDOKUMENTA], T3.[NAZIVVRSTEDOK], T1.[BLGDATUMDOKUMENTA], T1.[BLGSVRHA], T1.[BLGIZNOS], T1.[IDBLGVRSTEDOK], T1.[blggodineIDGODINE] AS blggodineIDGODINE FROM (([BLAGAJNAStavkeBlagajne] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString181 + "  TMX ON TMX.[BLGDOKIDDOKUMENT] = T1.[BLGDOKIDDOKUMENT]) INNER JOIN [BLGVRSTEDOK] T3 WITH (NOLOCK) ON T3.[IDBLGVRSTEDOK] = T1.[IDBLGVRSTEDOK]) ORDER BY T1.[BLGDOKIDDOKUMENT], T1.[IDBLGVRSTEDOK], T1.[blggodineIDGODINE], T1.[BLGBROJDOKUMENTA]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString181 = "[BLAGAJNA]";
                this.scmdbuf = "SELECT T1.[BLGDOKIDDOKUMENT] AS BLGDOKIDDOKUMENT, T1.[BLGBROJDOKUMENTA], T3.[NAZIVVRSTEDOK], T1.[BLGDATUMDOKUMENTA], T1.[BLGSVRHA], T1.[BLGIZNOS], T1.[IDBLGVRSTEDOK], T1.[blggodineIDGODINE] AS blggodineIDGODINE FROM (([BLAGAJNAStavkeBlagajne] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString181 + "  TM1 WITH (NOLOCK) ON TM1.[BLGDOKIDDOKUMENT] = T1.[BLGDOKIDDOKUMENT]) INNER JOIN [BLGVRSTEDOK] T3 WITH (NOLOCK) ON T3.[IDBLGVRSTEDOK] = T1.[IDBLGVRSTEDOK])" + this.m_WhereString + " ORDER BY T1.[BLGDOKIDDOKUMENT], T1.[IDBLGVRSTEDOK], T1.[blggodineIDGODINE], T1.[BLGBROJDOKUMENTA] ";
            }
            this.cmBLAGAJNAStavkeBlagajneSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartBlagajnastavkeblagajnestavkeblagajnekontiranje(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString182 = "(SELECT TOP " + maxRows.ToString() + " TM1.[BLGDOKIDDOKUMENT]  FROM [BLAGAJNA]  TM1 " + this.m_WhereString + " ORDER BY TM1.[BLGDOKIDDOKUMENT] )";
                    this.scmdbuf = "SELECT T1.[BLGDOKIDDOKUMENT] AS BLGDOKIDDOKUMENT, T1.[IDBLGVRSTEDOK], T1.[blggodineIDGODINE] AS blggodineIDGODINE, T1.[BLGBROJDOKUMENTA], T3.[NAZIVKONTO] AS BLGSTAVKEBLAGAJNEKONTONAZIVKONTO, T4.[NAZIVMJESTOTROSKA] AS BLGMTNAZIVMJESTOTROSKA, T5.[NAZIVORGJED] AS BLGORGJEDNAZIVORGJED, T1.[BLGIZNOSKONTIRANJA], T1.[BLGSTAVKEBLAGAJNEKONTOIDKONTO] AS BLGSTAVKEBLAGAJNEKONTOIDKONTO, T1.[BLGMTIDMJESTOTROSKA] AS BLGMTIDMJESTOTROSKA, T1.[BLGORGJEDIDORGJED] AS BLGORGJEDIDORGJED FROM (((([BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString182 + "  TMX ON TMX.[BLGDOKIDDOKUMENT] = T1.[BLGDOKIDDOKUMENT]) INNER JOIN [KONTO] T3 WITH (NOLOCK) ON T3.[IDKONTO] = T1.[BLGSTAVKEBLAGAJNEKONTOIDKONTO]) INNER JOIN [MJESTOTROSKA] T4 WITH (NOLOCK) ON T4.[IDMJESTOTROSKA] = T1.[BLGMTIDMJESTOTROSKA]) INNER JOIN [ORGJED] T5 WITH (NOLOCK) ON T5.[IDORGJED] = T1.[BLGORGJEDIDORGJED]) ORDER BY T1.[BLGDOKIDDOKUMENT], T1.[IDBLGVRSTEDOK], T1.[blggodineIDGODINE], T1.[BLGBROJDOKUMENTA], T1.[BLGSTAVKEBLAGAJNEKONTOIDKONTO]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[BLGDOKIDDOKUMENT], ROW_NUMBER() OVER  (  ORDER BY TM1.[BLGDOKIDDOKUMENT]  ) AS DK_PAGENUM   FROM [BLAGAJNA]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString182 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[BLGDOKIDDOKUMENT] AS BLGDOKIDDOKUMENT, T1.[IDBLGVRSTEDOK], T1.[blggodineIDGODINE] AS blggodineIDGODINE, T1.[BLGBROJDOKUMENTA], T3.[NAZIVKONTO] AS BLGSTAVKEBLAGAJNEKONTONAZIVKONTO, T4.[NAZIVMJESTOTROSKA] AS BLGMTNAZIVMJESTOTROSKA, T5.[NAZIVORGJED] AS BLGORGJEDNAZIVORGJED, T1.[BLGIZNOSKONTIRANJA], T1.[BLGSTAVKEBLAGAJNEKONTOIDKONTO] AS BLGSTAVKEBLAGAJNEKONTOIDKONTO, T1.[BLGMTIDMJESTOTROSKA] AS BLGMTIDMJESTOTROSKA, T1.[BLGORGJEDIDORGJED] AS BLGORGJEDIDORGJED FROM (((([BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString182 + "  TMX ON TMX.[BLGDOKIDDOKUMENT] = T1.[BLGDOKIDDOKUMENT]) INNER JOIN [KONTO] T3 WITH (NOLOCK) ON T3.[IDKONTO] = T1.[BLGSTAVKEBLAGAJNEKONTOIDKONTO]) INNER JOIN [MJESTOTROSKA] T4 WITH (NOLOCK) ON T4.[IDMJESTOTROSKA] = T1.[BLGMTIDMJESTOTROSKA]) INNER JOIN [ORGJED] T5 WITH (NOLOCK) ON T5.[IDORGJED] = T1.[BLGORGJEDIDORGJED]) ORDER BY T1.[BLGDOKIDDOKUMENT], T1.[IDBLGVRSTEDOK], T1.[blggodineIDGODINE], T1.[BLGBROJDOKUMENTA], T1.[BLGSTAVKEBLAGAJNEKONTOIDKONTO]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString182 = "[BLAGAJNA]";
                this.scmdbuf = "SELECT T1.[BLGDOKIDDOKUMENT] AS BLGDOKIDDOKUMENT, T1.[IDBLGVRSTEDOK], T1.[blggodineIDGODINE] AS blggodineIDGODINE, T1.[BLGBROJDOKUMENTA], T3.[NAZIVKONTO] AS BLGSTAVKEBLAGAJNEKONTONAZIVKONTO, T4.[NAZIVMJESTOTROSKA] AS BLGMTNAZIVMJESTOTROSKA, T5.[NAZIVORGJED] AS BLGORGJEDNAZIVORGJED, T1.[BLGIZNOSKONTIRANJA], T1.[BLGSTAVKEBLAGAJNEKONTOIDKONTO] AS BLGSTAVKEBLAGAJNEKONTOIDKONTO, T1.[BLGMTIDMJESTOTROSKA] AS BLGMTIDMJESTOTROSKA, T1.[BLGORGJEDIDORGJED] AS BLGORGJEDIDORGJED FROM (((([BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString182 + "  TM1 WITH (NOLOCK) ON TM1.[BLGDOKIDDOKUMENT] = T1.[BLGDOKIDDOKUMENT]) INNER JOIN [KONTO] T3 WITH (NOLOCK) ON T3.[IDKONTO] = T1.[BLGSTAVKEBLAGAJNEKONTOIDKONTO]) INNER JOIN [MJESTOTROSKA] T4 WITH (NOLOCK) ON T4.[IDMJESTOTROSKA] = T1.[BLGMTIDMJESTOTROSKA]) INNER JOIN [ORGJED] T5 WITH (NOLOCK) ON T5.[IDORGJED] = T1.[BLGORGJEDIDORGJED])" + this.m_WhereString + " ORDER BY T1.[BLGDOKIDDOKUMENT], T1.[IDBLGVRSTEDOK], T1.[blggodineIDGODINE], T1.[BLGBROJDOKUMENTA], T1.[BLGSTAVKEBLAGAJNEKONTOIDKONTO] ";
            }
            this.cmBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.BLAGAJNASet = (BLAGAJNADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.BLAGAJNASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.BLAGAJNASet.BLAGAJNA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        BLAGAJNADataSet.BLAGAJNARow current = (BLAGAJNADataSet.BLAGAJNARow) enumerator.Current;
                        this.rowBLAGAJNA = current;
                        if (Helpers.IsRowChanged(this.rowBLAGAJNA))
                        {
                            this.ReadRowBlagajna();
                            if (this.rowBLAGAJNA.RowState == DataRowState.Added)
                            {
                                this.InsertBlagajna();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateBlagajna();
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

        private void UpdateBlagajna()
        {
            this.CheckOptimisticConcurrencyBlagajna();
            this.AfterConfirmBlagajna();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [BLAGAJNA] SET [NAZIVBLAGAJNA]=@NAZIVBLAGAJNA, [BLGKONTOIDKONTO]=@BLGKONTOIDKONTO  WHERE [BLGDOKIDDOKUMENT] = @BLGDOKIDDOKUMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVBLAGAJNA", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGKONTOIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDOKIDDOKUMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["NAZIVBLAGAJNA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["BLGKONTOIDKONTO"]))));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNA["BLGDOKIDDOKUMENT"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsBlagajna();
            }
            this.OnBLAGAJNAUpdated(new BLAGAJNAEventArgs(this.rowBLAGAJNA, StatementType.Update));
            this.ProcessLevelBlagajna();
        }

        private void UpdateBlagajnastavkeblagajne()
        {
            this.CheckOptimisticConcurrencyBlagajnastavkeblagajne();
            this.CheckExtendedTableBlagajnastavkeblagajne();
            this.AfterConfirmBlagajnastavkeblagajne();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [BLAGAJNAStavkeBlagajne] SET [BLGDATUMDOKUMENTA]=@BLGDATUMDOKUMENTA, [BLGSVRHA]=@BLGSVRHA, [BLGIZNOS]=@BLGIZNOS  WHERE [BLGDOKIDDOKUMENT] = @BLGDOKIDDOKUMENT AND [IDBLGVRSTEDOK] = @IDBLGVRSTEDOK AND [blggodineIDGODINE] = @blggodineIDGODINE AND [BLGBROJDOKUMENTA] = @BLGBROJDOKUMENTA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDATUMDOKUMENTA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGSVRHA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDOKIDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@blggodineIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGBROJDOKUMENTA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameterDateObject(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGDATUMDOKUMENTA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGSVRHA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGIZNOS"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGDOKIDDOKUMENT"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["IDBLGVRSTEDOK"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["blggodineIDGODINE"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajne["BLGBROJDOKUMENTA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsBlagajnastavkeblagajne();
            }
            this.OnBLAGAJNAStavkeBlagajneUpdated(new BLAGAJNAStavkeBlagajneEventArgs(this.rowBLAGAJNAStavkeBlagajne, StatementType.Update));
            this.ProcessLevelBlagajnastavkeblagajne();
        }

        private void UpdateBlagajnastavkeblagajnestavkeblagajnekontiranje()
        {
            this.CheckOptimisticConcurrencyBlagajnastavkeblagajnestavkeblagajnekontiranje();
            this.CheckExtendedTableBlagajnastavkeblagajnestavkeblagajnekontiranje();
            this.AfterConfirmBlagajnastavkeblagajnestavkeblagajnekontiranje();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje] SET [BLGIZNOSKONTIRANJA]=@BLGIZNOSKONTIRANJA, [BLGMTIDMJESTOTROSKA]=@BLGMTIDMJESTOTROSKA, [BLGORGJEDIDORGJED]=@BLGORGJEDIDORGJED  WHERE [BLGDOKIDDOKUMENT] = @BLGDOKIDDOKUMENT AND [IDBLGVRSTEDOK] = @IDBLGVRSTEDOK AND [blggodineIDGODINE] = @blggodineIDGODINE AND [BLGBROJDOKUMENTA] = @BLGBROJDOKUMENTA AND [BLGSTAVKEBLAGAJNEKONTOIDKONTO] = @BLGSTAVKEBLAGAJNEKONTOIDKONTO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGIZNOSKONTIRANJA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGMTIDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGORGJEDIDORGJED", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGDOKIDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@blggodineIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGBROJDOKUMENTA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLGSTAVKEBLAGAJNEKONTOIDKONTO", DbType.String, 14));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGIZNOSKONTIRANJA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGMTIDMJESTOTROSKA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGORGJEDIDORGJED"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGDOKIDDOKUMENT"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["IDBLGVRSTEDOK"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["blggodineIDGODINE"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGBROJDOKUMENTA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje["BLGSTAVKEBLAGAJNEKONTOIDKONTO"]))));
            command.ExecuteStmt();
            this.OnBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdated(new BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeEventArgs(this.rowBLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje, StatementType.Update));
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
        public class BLAGAJNADataChangedException : DataChangedException
        {
            public BLAGAJNADataChangedException()
            {
            }

            public BLAGAJNADataChangedException(string message) : base(message)
            {
            }

            protected BLAGAJNADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLAGAJNADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BLAGAJNADataLockedException : DataLockedException
        {
            public BLAGAJNADataLockedException()
            {
            }

            public BLAGAJNADataLockedException(string message) : base(message)
            {
            }

            protected BLAGAJNADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLAGAJNADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BLAGAJNADuplicateKeyException : DuplicateKeyException
        {
            public BLAGAJNADuplicateKeyException()
            {
            }

            public BLAGAJNADuplicateKeyException(string message) : base(message)
            {
            }

            protected BLAGAJNADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLAGAJNADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class BLAGAJNAEventArgs : EventArgs
        {
            private BLAGAJNADataSet.BLAGAJNARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public BLAGAJNAEventArgs(BLAGAJNADataSet.BLAGAJNARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public BLAGAJNADataSet.BLAGAJNARow Row
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
        public class BLAGAJNANotFoundException : DataNotFoundException
        {
            public BLAGAJNANotFoundException()
            {
            }

            public BLAGAJNANotFoundException(string message) : base(message)
            {
            }

            protected BLAGAJNANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLAGAJNANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BLAGAJNAStavkeBlagajneDataChangedException : DataChangedException
        {
            public BLAGAJNAStavkeBlagajneDataChangedException()
            {
            }

            public BLAGAJNAStavkeBlagajneDataChangedException(string message) : base(message)
            {
            }

            protected BLAGAJNAStavkeBlagajneDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLAGAJNAStavkeBlagajneDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BLAGAJNAStavkeBlagajneDataLockedException : DataLockedException
        {
            public BLAGAJNAStavkeBlagajneDataLockedException()
            {
            }

            public BLAGAJNAStavkeBlagajneDataLockedException(string message) : base(message)
            {
            }

            protected BLAGAJNAStavkeBlagajneDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLAGAJNAStavkeBlagajneDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BLAGAJNAStavkeBlagajneDuplicateKeyException : DuplicateKeyException
        {
            public BLAGAJNAStavkeBlagajneDuplicateKeyException()
            {
            }

            public BLAGAJNAStavkeBlagajneDuplicateKeyException(string message) : base(message)
            {
            }

            protected BLAGAJNAStavkeBlagajneDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLAGAJNAStavkeBlagajneDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class BLAGAJNAStavkeBlagajneEventArgs : EventArgs
        {
            private BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public BLAGAJNAStavkeBlagajneEventArgs(BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public BLAGAJNADataSet.BLAGAJNAStavkeBlagajneRow Row
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
        public class BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataChangedException : DataChangedException
        {
            public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataChangedException()
            {
            }

            public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataChangedException(string message) : base(message)
            {
            }

            protected BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataLockedException : DataLockedException
        {
            public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataLockedException()
            {
            }

            public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataLockedException(string message) : base(message)
            {
            }

            protected BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDuplicateKeyException : DuplicateKeyException
        {
            public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDuplicateKeyException()
            {
            }

            public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDuplicateKeyException(string message) : base(message)
            {
            }

            protected BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeEventArgs : EventArgs
        {
            private BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeEventArgs(BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public BLAGAJNADataSet.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeRow Row
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

        public delegate void BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeUpdateEventHandler(object sender, BLAGAJNADataAdapter.BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeEventArgs e);

        public delegate void BLAGAJNAStavkeBlagajneUpdateEventHandler(object sender, BLAGAJNADataAdapter.BLAGAJNAStavkeBlagajneEventArgs e);

        public delegate void BLAGAJNAUpdateEventHandler(object sender, BLAGAJNADataAdapter.BLAGAJNAEventArgs e);

        [Serializable]
        public class BLGVRSTEDOKForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public BLGVRSTEDOKForeignKeyNotFoundException()
            {
            }

            public BLGVRSTEDOKForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected BLGVRSTEDOKForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLGVRSTEDOKForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DOKUMENTForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public DOKUMENTForeignKeyNotFoundException()
            {
            }

            public DOKUMENTForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected DOKUMENTForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOKUMENTForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
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
        public class MJESTOTROSKAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public MJESTOTROSKAForeignKeyNotFoundException()
            {
            }

            public MJESTOTROSKAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected MJESTOTROSKAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public MJESTOTROSKAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
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
    }
}

