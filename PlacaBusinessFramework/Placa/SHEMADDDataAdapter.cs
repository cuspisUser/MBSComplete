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

    public class SHEMADDDataAdapter : IDataAdapter, ISHEMADDDataAdapter
    {
        private bool _Gxremove;
        private bool _Gxremove17;
        private bool _Gxremove23;
        private ReadWriteCommand cmSHEMADDSelect1;
        private ReadWriteCommand cmSHEMADDSelect2;
        private ReadWriteCommand cmSHEMADDSelect5;
        private ReadWriteCommand cmSHEMADDSHEMADDDOPRINOSSelect2;
        private ReadWriteCommand cmSHEMADDSHEMADDSTANDARDSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__IDDDVRSTEIZNOSAOriginal;
        private object m__KONTODDVRSTAIZNOSAIDKONTOOriginal;
        private object m__MTDDVRSTAIZNOSAIDMJESTOTROSKAOriginal;
        private object m__MTDOPIDMJESTOTROSKAOriginal;
        private object m__NAZIVSHEMADDOriginal;
        private object m__SHEMADDOJIDORGJEDOriginal;
        private object m__STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJAOriginal;
        private object m__STRANEDOPIDSTRANEKNJIZENJAOriginal;
        private readonly string m_SelectString241 = "TM1.[IDSHEMADD], TM1.[NAZIVSHEMADD], TM1.[SHEMADDOJIDORGJED] AS SHEMADDOJIDORGJED";
        private string m_SubSelTopString243;
        private string m_SubSelTopString244;
        private string m_WhereString;
        private short RcdFound241;
        private short RcdFound243;
        private short RcdFound244;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private SHEMADDDataSet.SHEMADDRow rowSHEMADD;
        private SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow rowSHEMADDSHEMADDDOPRINOS;
        private SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow rowSHEMADDSHEMADDSTANDARD;
        private string scmdbuf;
        private IDataReader SHEMADDSelect1;
        private IDataReader SHEMADDSelect2;
        private IDataReader SHEMADDSelect5;
        private SHEMADDDataSet SHEMADDSet;
        private IDataReader SHEMADDSHEMADDDOPRINOSSelect2;
        private IDataReader SHEMADDSHEMADDSTANDARDSelect2;
        private StatementType sMode241;
        private StatementType sMode243;
        private StatementType sMode244;

        public event SHEMADDSHEMADDDOPRINOSUpdateEventHandler SHEMADDSHEMADDDOPRINOSUpdated;

        public event SHEMADDSHEMADDDOPRINOSUpdateEventHandler SHEMADDSHEMADDDOPRINOSUpdating;

        public event SHEMADDSHEMADDSTANDARDUpdateEventHandler SHEMADDSHEMADDSTANDARDUpdated;

        public event SHEMADDSHEMADDSTANDARDUpdateEventHandler SHEMADDSHEMADDSTANDARDUpdating;

        public event SHEMADDUpdateEventHandler SHEMADDUpdated;

        public event SHEMADDUpdateEventHandler SHEMADDUpdating;

        private void AddRowShemadd()
        {
            this.SHEMADDSet.SHEMADD.AddSHEMADDRow(this.rowSHEMADD);
        }

        private void AddRowShemaddshemadddoprinos()
        {
            this.SHEMADDSet.SHEMADDSHEMADDDOPRINOS.AddSHEMADDSHEMADDDOPRINOSRow(this.rowSHEMADDSHEMADDDOPRINOS);
        }

        private void AddRowShemaddshemaddstandard()
        {
            this.SHEMADDSet.SHEMADDSHEMADDSTANDARD.AddSHEMADDSHEMADDSTANDARDRow(this.rowSHEMADDSHEMADDSTANDARD);
        }

        private void AfterConfirmShemadd()
        {
            this.OnSHEMADDUpdating(new SHEMADDEventArgs(this.rowSHEMADD, this.Gx_mode));
        }

        private void AfterConfirmShemaddshemadddoprinos()
        {
            this.OnSHEMADDSHEMADDDOPRINOSUpdating(new SHEMADDSHEMADDDOPRINOSEventArgs(this.rowSHEMADDSHEMADDDOPRINOS, this.Gx_mode));
        }

        private void AfterConfirmShemaddshemaddstandard()
        {
            this.OnSHEMADDSHEMADDSTANDARDUpdating(new SHEMADDSHEMADDSTANDARDEventArgs(this.rowSHEMADDSHEMADDSTANDARD, this.Gx_mode));
        }

        private void CheckExtendedTableShemaddshemadddoprinos()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVDOPRINOS] AS SHEMADDDOPRINOSNAZIVDOPRINOS FROM [DOPRINOS] WITH (NOLOCK) WHERE [IDDOPRINOS] = @SHEMADDDOPRINOSIDDOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMADDDOPRINOSIDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["SHEMADDDOPRINOSIDDOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new DOPRINOSForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DOPRINOS") }));
            }
            this.rowSHEMADDSHEMADDDOPRINOS["SHEMADDDOPRINOSNAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            reader.Close();
        }

        private void CheckExtendedTableShemaddshemaddstandard()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVDDVRSTEIZNOSA] FROM [DDVRSTEIZNOSA] WITH (NOLOCK) WHERE [IDDDVRSTEIZNOSA] = @IDDDVRSTEIZNOSA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDDVRSTEIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["IDDDVRSTEIZNOSA"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new DDVRSTEIZNOSAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DDVRSTEIZNOSA") }));
            }
            this.rowSHEMADDSHEMADDSTANDARD["NAZIVDDVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            reader.Close();
        }

        private void CheckIntegrityErrorsShemadd()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDORGJED] AS SHEMADDOJIDORGJED FROM [ORGJED] WITH (NOLOCK) WHERE [IDORGJED] = @SHEMADDOJIDORGJED ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMADDOJIDORGJED", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADD["SHEMADDOJIDORGJED"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new ORGJEDForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ORGJED") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckIntegrityErrorsShemaddshemadddoprinos()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKONTO] AS KONTODOPIDKONTO FROM [KONTO] WITH (NOLOCK) WHERE [IDKONTO] = @KONTODOPIDKONTO ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTODOPIDKONTO", DbType.String, 14));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["KONTODOPIDKONTO"]))));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new KONTOForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KONTO") }));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [IDMJESTOTROSKA] AS MTDOPIDMJESTOTROSKA FROM [MJESTOTROSKA] WITH (NOLOCK) WHERE [IDMJESTOTROSKA] = @MTDOPIDMJESTOTROSKA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MTDOPIDMJESTOTROSKA", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["MTDOPIDMJESTOTROSKA"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new MJESTOTROSKAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("MJESTOTROSKA") }));
            }
            reader2.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [IDSTRANEKNJIZENJA] AS STRANEDOPIDSTRANEKNJIZENJA FROM [STRANEKNJIZENJA] WITH (NOLOCK) WHERE [IDSTRANEKNJIZENJA] = @STRANEDOPIDSTRANEKNJIZENJA ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STRANEDOPIDSTRANEKNJIZENJA", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["STRANEDOPIDSTRANEKNJIZENJA"]));
            IDataReader reader3 = command3.FetchData();
            if (!command3.HasMoreRows)
            {
                reader3.Close();
                throw new STRANEKNJIZENJAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("STRANEKNJIZENJA") }));
            }
            reader3.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckIntegrityErrorsShemaddshemaddstandard()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKONTO] AS KONTODDVRSTAIZNOSAIDKONTO FROM [KONTO] WITH (NOLOCK) WHERE [IDKONTO] = @KONTODDVRSTAIZNOSAIDKONTO ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTODDVRSTAIZNOSAIDKONTO", DbType.String, 14));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["KONTODDVRSTAIZNOSAIDKONTO"]))));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new KONTOForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KONTO") }));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [IDMJESTOTROSKA] AS MTDDVRSTAIZNOSAIDMJESTOTROSKA FROM [MJESTOTROSKA] WITH (NOLOCK) WHERE [IDMJESTOTROSKA] = @MTDDVRSTAIZNOSAIDMJESTOTROSKA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MTDDVRSTAIZNOSAIDMJESTOTROSKA", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["MTDDVRSTAIZNOSAIDMJESTOTROSKA"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new MJESTOTROSKAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("MJESTOTROSKA") }));
            }
            reader2.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [IDSTRANEKNJIZENJA] AS STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA FROM [STRANEKNJIZENJA] WITH (NOLOCK) WHERE [IDSTRANEKNJIZENJA] = @STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"]));
            IDataReader reader3 = command3.FetchData();
            if (!command3.HasMoreRows)
            {
                reader3.Close();
                throw new STRANEKNJIZENJAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("STRANEKNJIZENJA") }));
            }
            reader3.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyShemadd()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSHEMADD], [NAZIVSHEMADD], [SHEMADDOJIDORGJED] AS SHEMADDOJIDORGJED FROM [SHEMADD] WITH (UPDLOCK) WHERE [IDSHEMADD] = @IDSHEMADD ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMADD", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADD["IDSHEMADD"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new SHEMADDDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("SHEMADD") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVSHEMADDOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || !this.m__SHEMADDOJIDORGJEDOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2))))
                {
                    reader.Close();
                    throw new SHEMADDDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("SHEMADD") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyShemaddshemadddoprinos()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSHEMADD], [SHEMADDDOPRINOSIDDOPRINOS] AS SHEMADDDOPRINOSIDDOPRINOS, [KONTODOPIDKONTO] AS KONTODOPIDKONTO, [MTDOPIDMJESTOTROSKA] AS MTDOPIDMJESTOTROSKA, [STRANEDOPIDSTRANEKNJIZENJA] AS STRANEDOPIDSTRANEKNJIZENJA FROM [SHEMADDSHEMADDDOPRINOS] WITH (UPDLOCK) WHERE [IDSHEMADD] = @IDSHEMADD AND [SHEMADDDOPRINOSIDDOPRINOS] = @SHEMADDDOPRINOSIDDOPRINOS AND [KONTODOPIDKONTO] = @KONTODOPIDKONTO ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMADD", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMADDDOPRINOSIDDOPRINOS", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTODOPIDKONTO", DbType.String, 14));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["IDSHEMADD"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["SHEMADDDOPRINOSIDDOPRINOS"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["KONTODOPIDKONTO"]))));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new SHEMADDSHEMADDDOPRINOSDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("SHEMADDSHEMADDDOPRINOS") }));
                }
                if ((!command.HasMoreRows || !this.m__MTDOPIDMJESTOTROSKAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3)))) || !this.m__STRANEDOPIDSTRANEKNJIZENJAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 4))))
                {
                    reader.Close();
                    throw new SHEMADDSHEMADDDOPRINOSDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("SHEMADDSHEMADDDOPRINOS") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyShemaddshemaddstandard()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSHEMADD], [SHEMADDSTANDARDID], [IDDDVRSTEIZNOSA], [KONTODDVRSTAIZNOSAIDKONTO] AS KONTODDVRSTAIZNOSAIDKONTO, [MTDDVRSTAIZNOSAIDMJESTOTROSKA] AS MTDDVRSTAIZNOSAIDMJESTOTROSKA, [STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA] AS STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA FROM [SHEMADDSHEMADDSTANDARD] WITH (UPDLOCK) WHERE [IDSHEMADD] = @IDSHEMADD AND [SHEMADDSTANDARDID] = @SHEMADDSTANDARDID ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMADD", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMADDSTANDARDID", DbType.Guid));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["IDSHEMADD"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["SHEMADDSTANDARDID"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new SHEMADDSHEMADDSTANDARDDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("SHEMADDSHEMADDSTANDARD") }));
                }
                if ((!command.HasMoreRows || !this.m__IDDDVRSTEIZNOSAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__KONTODDVRSTAIZNOSAIDKONTOOriginal), RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3))))) || !this.m__MTDDVRSTAIZNOSAIDMJESTOTROSKAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 4)))) || !this.m__STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 5)))))
                {
                    reader.Close();
                    throw new SHEMADDSHEMADDSTANDARDDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("SHEMADDSHEMADDSTANDARD") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowShemadd()
        {
            this.rowSHEMADD = this.SHEMADDSet.SHEMADD.NewSHEMADDRow();
        }

        private void CreateNewRowShemaddshemadddoprinos()
        {
            this.rowSHEMADDSHEMADDDOPRINOS = this.SHEMADDSet.SHEMADDSHEMADDDOPRINOS.NewSHEMADDSHEMADDDOPRINOSRow();
        }

        private void CreateNewRowShemaddshemaddstandard()
        {
            this.rowSHEMADDSHEMADDSTANDARD = this.SHEMADDSet.SHEMADDSHEMADDSTANDARD.NewSHEMADDSHEMADDSTANDARDRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyShemadd();
            this.ProcessNestedLevelShemaddshemaddstandard();
            this.ProcessNestedLevelShemaddshemadddoprinos();
            this.AfterConfirmShemadd();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [SHEMADD]  WHERE [IDSHEMADD] = @IDSHEMADD", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMADD", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADD["IDSHEMADD"]));
            command.ExecuteStmt();
            this.OnSHEMADDUpdated(new SHEMADDEventArgs(this.rowSHEMADD, StatementType.Delete));
            this.rowSHEMADD.Delete();
            this.sMode241 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode241;
        }

        private void DeleteShemaddshemadddoprinos()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyShemaddshemadddoprinos();
            this.OnDeleteControlsShemaddshemadddoprinos();
            this.AfterConfirmShemaddshemadddoprinos();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [SHEMADDSHEMADDDOPRINOS]  WHERE [IDSHEMADD] = @IDSHEMADD AND [SHEMADDDOPRINOSIDDOPRINOS] = @SHEMADDDOPRINOSIDDOPRINOS AND [KONTODOPIDKONTO] = @KONTODOPIDKONTO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMADD", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMADDDOPRINOSIDDOPRINOS", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTODOPIDKONTO", DbType.String, 14));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["IDSHEMADD"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["SHEMADDDOPRINOSIDDOPRINOS"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["KONTODOPIDKONTO"]))));
            command.ExecuteStmt();
            this.OnSHEMADDSHEMADDDOPRINOSUpdated(new SHEMADDSHEMADDDOPRINOSEventArgs(this.rowSHEMADDSHEMADDDOPRINOS, StatementType.Delete));
            this.rowSHEMADDSHEMADDDOPRINOS.Delete();
            this.sMode243 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode243;
        }

        private void DeleteShemaddshemaddstandard()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyShemaddshemaddstandard();
            this.OnDeleteControlsShemaddshemaddstandard();
            this.AfterConfirmShemaddshemaddstandard();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [SHEMADDSHEMADDSTANDARD]  WHERE [IDSHEMADD] = @IDSHEMADD AND [SHEMADDSTANDARDID] = @SHEMADDSTANDARDID", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMADD", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMADDSTANDARDID", DbType.Guid));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["IDSHEMADD"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["SHEMADDSTANDARDID"]));
            command.ExecuteStmt();
            this.OnSHEMADDSHEMADDSTANDARDUpdated(new SHEMADDSHEMADDSTANDARDEventArgs(this.rowSHEMADDSHEMADDSTANDARD, StatementType.Delete));
            this.rowSHEMADDSHEMADDSTANDARD.Delete();
            this.sMode244 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode244;
        }

        public virtual int Fill(SHEMADDDataSet dataSet)
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
                    this.SHEMADDSet = dataSet;
                    this.LoadChildShemadd(0, -1);
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
            this.SHEMADDSet = (SHEMADDDataSet) dataSet;
            if (this.SHEMADDSet != null)
            {
                return this.Fill(this.SHEMADDSet);
            }
            this.SHEMADDSet = new SHEMADDDataSet();
            this.Fill(this.SHEMADDSet);
            dataSet.Merge(this.SHEMADDSet);
            return 0;
        }

        public virtual int Fill(SHEMADDDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSHEMADD"]));
        }

        public virtual int Fill(SHEMADDDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSHEMADD"]));
        }

        public virtual int Fill(SHEMADDDataSet dataSet, int iDSHEMADD)
        {
            if (!this.FillByIDSHEMADD(dataSet, iDSHEMADD))
            {
                throw new SHEMADDNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("SHEMADD") }));
            }
            return 0;
        }

        public virtual bool FillByIDSHEMADD(SHEMADDDataSet dataSet, int iDSHEMADD)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SHEMADDSet = dataSet;
            this.rowSHEMADD = this.SHEMADDSet.SHEMADD.NewSHEMADDRow();
            this.rowSHEMADD.IDSHEMADD = iDSHEMADD;
            try
            {
                this.LoadByIDSHEMADD(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound241 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillBySHEMADDOJIDORGJED(SHEMADDDataSet dataSet, int sHEMADDOJIDORGJED)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SHEMADDSet = dataSet;
            this.rowSHEMADD = this.SHEMADDSet.SHEMADD.NewSHEMADDRow();
            this.rowSHEMADD.SHEMADDOJIDORGJED = sHEMADDOJIDORGJED;
            try
            {
                this.LoadBySHEMADDOJIDORGJED(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(SHEMADDDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SHEMADDSet = dataSet;
            try
            {
                this.LoadChildShemadd(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageBySHEMADDOJIDORGJED(SHEMADDDataSet dataSet, int sHEMADDOJIDORGJED, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SHEMADDSet = dataSet;
            this.rowSHEMADD = this.SHEMADDSet.SHEMADD.NewSHEMADDRow();
            this.rowSHEMADD.SHEMADDOJIDORGJED = sHEMADDOJIDORGJED;
            try
            {
                this.LoadBySHEMADDOJIDORGJED(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSHEMADD], [NAZIVSHEMADD], [SHEMADDOJIDORGJED] AS SHEMADDOJIDORGJED FROM [SHEMADD] WITH (NOLOCK) WHERE [IDSHEMADD] = @IDSHEMADD ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMADD", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADD["IDSHEMADD"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound241 = 1;
                this.rowSHEMADD["IDSHEMADD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowSHEMADD["NAZIVSHEMADD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowSHEMADD["SHEMADDOJIDORGJED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2));
                this.sMode241 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode241;
            }
            else
            {
                this.RcdFound241 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDSHEMADD";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMADDSelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [SHEMADD] WITH (NOLOCK) ", false);
            this.SHEMADDSelect2 = this.cmSHEMADDSelect2.FetchData();
            if (this.SHEMADDSelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.SHEMADDSelect2.GetInt32(0);
            }
            this.SHEMADDSelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountBySHEMADDOJIDORGJED(int sHEMADDOJIDORGJED)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMADDSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [SHEMADD] WITH (NOLOCK) WHERE [SHEMADDOJIDORGJED] = @SHEMADDOJIDORGJED ", false);
            if (this.cmSHEMADDSelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMADDSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMADDOJIDORGJED", DbType.Int32));
            }
            this.cmSHEMADDSelect1.SetParameter(0, sHEMADDOJIDORGJED);
            this.SHEMADDSelect1 = this.cmSHEMADDSelect1.FetchData();
            if (this.SHEMADDSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.SHEMADDSelect1.GetInt32(0);
            }
            this.SHEMADDSelect1.Close();
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

        public virtual int GetRecordCountBySHEMADDOJIDORGJED(int sHEMADDOJIDORGJED)
        {
            int internalRecordCountBySHEMADDOJIDORGJED;
            try
            {
                this.InitializeMembers();
                internalRecordCountBySHEMADDOJIDORGJED = this.GetInternalRecordCountBySHEMADDOJIDORGJED(sHEMADDOJIDORGJED);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountBySHEMADDOJIDORGJED;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound241 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__IDDDVRSTEIZNOSAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KONTODDVRSTAIZNOSAIDKONTOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MTDDVRSTAIZNOSAIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove23 = false;
            this.RcdFound244 = 0;
            this.m_SubSelTopString244 = "";
            this.m__MTDOPIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__STRANEDOPIDSTRANEKNJIZENJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove17 = false;
            this.RcdFound243 = 0;
            this.m_SubSelTopString243 = "";
            this.m__NAZIVSHEMADDOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SHEMADDOJIDORGJEDOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.SHEMADDSet = new SHEMADDDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertShemadd()
        {
            this.CheckOptimisticConcurrencyShemadd();
            this.AfterConfirmShemadd();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [SHEMADD] ([IDSHEMADD], [NAZIVSHEMADD], [SHEMADDOJIDORGJED]) VALUES (@IDSHEMADD, @NAZIVSHEMADD, @SHEMADDOJIDORGJED)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMADD", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSHEMADD", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMADDOJIDORGJED", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADD["IDSHEMADD"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMADD["NAZIVSHEMADD"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMADD["SHEMADDOJIDORGJED"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new SHEMADDDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemadd();
            }
            this.OnSHEMADDUpdated(new SHEMADDEventArgs(this.rowSHEMADD, StatementType.Insert));
            this.ProcessLevelShemadd();
        }

        private void InsertShemaddshemadddoprinos()
        {
            this.CheckOptimisticConcurrencyShemaddshemadddoprinos();
            this.CheckExtendedTableShemaddshemadddoprinos();
            this.AfterConfirmShemaddshemadddoprinos();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [SHEMADDSHEMADDDOPRINOS] ([IDSHEMADD], [SHEMADDDOPRINOSIDDOPRINOS], [KONTODOPIDKONTO], [MTDOPIDMJESTOTROSKA], [STRANEDOPIDSTRANEKNJIZENJA]) VALUES (@IDSHEMADD, @SHEMADDDOPRINOSIDDOPRINOS, @KONTODOPIDKONTO, @MTDOPIDMJESTOTROSKA, @STRANEDOPIDSTRANEKNJIZENJA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMADD", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMADDDOPRINOSIDDOPRINOS", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTODOPIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MTDOPIDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STRANEDOPIDSTRANEKNJIZENJA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["IDSHEMADD"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["SHEMADDDOPRINOSIDDOPRINOS"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["KONTODOPIDKONTO"]))));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["MTDOPIDMJESTOTROSKA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["STRANEDOPIDSTRANEKNJIZENJA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new SHEMADDSHEMADDDOPRINOSDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemaddshemadddoprinos();
            }
            this.OnSHEMADDSHEMADDDOPRINOSUpdated(new SHEMADDSHEMADDDOPRINOSEventArgs(this.rowSHEMADDSHEMADDDOPRINOS, StatementType.Insert));
        }

        private void InsertShemaddshemaddstandard()
        {
            this.CheckOptimisticConcurrencyShemaddshemaddstandard();
            this.CheckExtendedTableShemaddshemaddstandard();
            this.AfterConfirmShemaddshemaddstandard();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [SHEMADDSHEMADDSTANDARD] ([IDSHEMADD], [SHEMADDSTANDARDID], [IDDDVRSTEIZNOSA], [KONTODDVRSTAIZNOSAIDKONTO], [MTDDVRSTAIZNOSAIDMJESTOTROSKA], [STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA]) VALUES (@IDSHEMADD, @SHEMADDSTANDARDID, @IDDDVRSTEIZNOSA, @KONTODDVRSTAIZNOSAIDKONTO, @MTDDVRSTAIZNOSAIDMJESTOTROSKA, @STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMADD", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMADDSTANDARDID", DbType.Guid));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDDVRSTEIZNOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTODDVRSTAIZNOSAIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MTDDVRSTAIZNOSAIDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["IDSHEMADD"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["SHEMADDSTANDARDID"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["IDDDVRSTEIZNOSA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["KONTODDVRSTAIZNOSAIDKONTO"]))));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["MTDDVRSTAIZNOSAIDMJESTOTROSKA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new SHEMADDSHEMADDSTANDARDDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemaddshemaddstandard();
            }
            this.OnSHEMADDSHEMADDSTANDARDUpdated(new SHEMADDSHEMADDSTANDARDEventArgs(this.rowSHEMADDSHEMADDSTANDARD, StatementType.Insert));
        }

        private void LoadByIDSHEMADD(int startRow, int maxRows)
        {
            bool enforceConstraints = this.SHEMADDSet.EnforceConstraints;
            this.SHEMADDSet.SHEMADDSHEMADDSTANDARD.BeginLoadData();
            this.SHEMADDSet.SHEMADDSHEMADDDOPRINOS.BeginLoadData();
            this.SHEMADDSet.SHEMADD.BeginLoadData();
            this.ScanByIDSHEMADD(startRow, maxRows);
            this.SHEMADDSet.SHEMADDSHEMADDSTANDARD.EndLoadData();
            this.SHEMADDSet.SHEMADDSHEMADDDOPRINOS.EndLoadData();
            this.SHEMADDSet.SHEMADD.EndLoadData();
            this.SHEMADDSet.EnforceConstraints = enforceConstraints;
            if (this.SHEMADDSet.SHEMADD.Count > 0)
            {
                this.rowSHEMADD = this.SHEMADDSet.SHEMADD[this.SHEMADDSet.SHEMADD.Count - 1];
            }
        }

        private void LoadBySHEMADDOJIDORGJED(int startRow, int maxRows)
        {
            bool enforceConstraints = this.SHEMADDSet.EnforceConstraints;
            this.SHEMADDSet.SHEMADDSHEMADDSTANDARD.BeginLoadData();
            this.SHEMADDSet.SHEMADDSHEMADDDOPRINOS.BeginLoadData();
            this.SHEMADDSet.SHEMADD.BeginLoadData();
            this.ScanBySHEMADDOJIDORGJED(startRow, maxRows);
            this.SHEMADDSet.SHEMADDSHEMADDSTANDARD.EndLoadData();
            this.SHEMADDSet.SHEMADDSHEMADDDOPRINOS.EndLoadData();
            this.SHEMADDSet.SHEMADD.EndLoadData();
            this.SHEMADDSet.EnforceConstraints = enforceConstraints;
            if (this.SHEMADDSet.SHEMADD.Count > 0)
            {
                this.rowSHEMADD = this.SHEMADDSet.SHEMADD[this.SHEMADDSet.SHEMADD.Count - 1];
            }
        }

        private void LoadChildShemadd(int startRow, int maxRows)
        {
            this.CreateNewRowShemadd();
            bool enforceConstraints = this.SHEMADDSet.EnforceConstraints;
            this.SHEMADDSet.SHEMADDSHEMADDSTANDARD.BeginLoadData();
            this.SHEMADDSet.SHEMADDSHEMADDDOPRINOS.BeginLoadData();
            this.SHEMADDSet.SHEMADD.BeginLoadData();
            this.ScanStartShemadd(startRow, maxRows);
            this.SHEMADDSet.SHEMADDSHEMADDSTANDARD.EndLoadData();
            this.SHEMADDSet.SHEMADDSHEMADDDOPRINOS.EndLoadData();
            this.SHEMADDSet.SHEMADD.EndLoadData();
            this.SHEMADDSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildShemaddshemadddoprinos()
        {
            this.CreateNewRowShemaddshemadddoprinos();
            this.ScanStartShemaddshemadddoprinos();
        }

        private void LoadChildShemaddshemaddstandard()
        {
            this.CreateNewRowShemaddshemaddstandard();
            this.ScanStartShemaddshemaddstandard();
        }

        private void LoadDataShemadd(int maxRows)
        {
            int num = 0;
            if (this.RcdFound241 != 0)
            {
                this.ScanLoadShemadd();
                while ((this.RcdFound241 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowShemadd();
                    this.CreateNewRowShemadd();
                    this.ScanNextShemadd();
                }
            }
            if (num > 0)
            {
                this.RcdFound241 = 1;
            }
            this.ScanEndShemadd();
            if (this.SHEMADDSet.SHEMADD.Count > 0)
            {
                this.rowSHEMADD = this.SHEMADDSet.SHEMADD[this.SHEMADDSet.SHEMADD.Count - 1];
            }
        }

        private void LoadDataShemaddshemadddoprinos()
        {
            while (this.RcdFound243 != 0)
            {
                this.LoadRowShemaddshemadddoprinos();
                this.CreateNewRowShemaddshemadddoprinos();
                this.ScanNextShemaddshemadddoprinos();
            }
            this.ScanEndShemaddshemadddoprinos();
        }

        private void LoadDataShemaddshemaddstandard()
        {
            while (this.RcdFound244 != 0)
            {
                this.LoadRowShemaddshemaddstandard();
                this.CreateNewRowShemaddshemaddstandard();
                this.ScanNextShemaddshemaddstandard();
            }
            this.ScanEndShemaddshemaddstandard();
        }

        private void LoadRowShemadd()
        {
            this.AddRowShemadd();
        }

        private void LoadRowShemaddshemadddoprinos()
        {
            this.AddRowShemaddshemadddoprinos();
        }

        private void LoadRowShemaddshemaddstandard()
        {
            this.AddRowShemaddshemaddstandard();
        }

        private void OnDeleteControlsShemaddshemadddoprinos()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVDOPRINOS] AS SHEMADDDOPRINOSNAZIVDOPRINOS FROM [DOPRINOS] WITH (NOLOCK) WHERE [IDDOPRINOS] = @SHEMADDDOPRINOSIDDOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMADDDOPRINOSIDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["SHEMADDDOPRINOSIDDOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowSHEMADDSHEMADDDOPRINOS["SHEMADDDOPRINOSNAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void OnDeleteControlsShemaddshemaddstandard()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVDDVRSTEIZNOSA] FROM [DDVRSTEIZNOSA] WITH (NOLOCK) WHERE [IDDDVRSTEIZNOSA] = @IDDDVRSTEIZNOSA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDDVRSTEIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["IDDDVRSTEIZNOSA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowSHEMADDSHEMADDSTANDARD["NAZIVDDVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void OnSHEMADDSHEMADDDOPRINOSUpdated(SHEMADDSHEMADDDOPRINOSEventArgs e)
        {
            if (this.SHEMADDSHEMADDDOPRINOSUpdated != null)
            {
                SHEMADDSHEMADDDOPRINOSUpdateEventHandler sHEMADDSHEMADDDOPRINOSUpdatedEvent = this.SHEMADDSHEMADDDOPRINOSUpdated;
                if (sHEMADDSHEMADDDOPRINOSUpdatedEvent != null)
                {
                    sHEMADDSHEMADDDOPRINOSUpdatedEvent(this, e);
                }
            }
        }

        private void OnSHEMADDSHEMADDDOPRINOSUpdating(SHEMADDSHEMADDDOPRINOSEventArgs e)
        {
            if (this.SHEMADDSHEMADDDOPRINOSUpdating != null)
            {
                SHEMADDSHEMADDDOPRINOSUpdateEventHandler sHEMADDSHEMADDDOPRINOSUpdatingEvent = this.SHEMADDSHEMADDDOPRINOSUpdating;
                if (sHEMADDSHEMADDDOPRINOSUpdatingEvent != null)
                {
                    sHEMADDSHEMADDDOPRINOSUpdatingEvent(this, e);
                }
            }
        }

        private void OnSHEMADDSHEMADDSTANDARDUpdated(SHEMADDSHEMADDSTANDARDEventArgs e)
        {
            if (this.SHEMADDSHEMADDSTANDARDUpdated != null)
            {
                SHEMADDSHEMADDSTANDARDUpdateEventHandler sHEMADDSHEMADDSTANDARDUpdatedEvent = this.SHEMADDSHEMADDSTANDARDUpdated;
                if (sHEMADDSHEMADDSTANDARDUpdatedEvent != null)
                {
                    sHEMADDSHEMADDSTANDARDUpdatedEvent(this, e);
                }
            }
        }

        private void OnSHEMADDSHEMADDSTANDARDUpdating(SHEMADDSHEMADDSTANDARDEventArgs e)
        {
            if (this.SHEMADDSHEMADDSTANDARDUpdating != null)
            {
                SHEMADDSHEMADDSTANDARDUpdateEventHandler sHEMADDSHEMADDSTANDARDUpdatingEvent = this.SHEMADDSHEMADDSTANDARDUpdating;
                if (sHEMADDSHEMADDSTANDARDUpdatingEvent != null)
                {
                    sHEMADDSHEMADDSTANDARDUpdatingEvent(this, e);
                }
            }
        }

        private void OnSHEMADDUpdated(SHEMADDEventArgs e)
        {
            if (this.SHEMADDUpdated != null)
            {
                SHEMADDUpdateEventHandler sHEMADDUpdatedEvent = this.SHEMADDUpdated;
                if (sHEMADDUpdatedEvent != null)
                {
                    sHEMADDUpdatedEvent(this, e);
                }
            }
        }

        private void OnSHEMADDUpdating(SHEMADDEventArgs e)
        {
            if (this.SHEMADDUpdating != null)
            {
                SHEMADDUpdateEventHandler sHEMADDUpdatingEvent = this.SHEMADDUpdating;
                if (sHEMADDUpdatingEvent != null)
                {
                    sHEMADDUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelShemadd()
        {
            this.sMode241 = this.Gx_mode;
            this.ProcessNestedLevelShemaddshemadddoprinos();
            this.ProcessNestedLevelShemaddshemaddstandard();
            this.Gx_mode = this.sMode241;
        }

        private void ProcessNestedLevelShemaddshemadddoprinos()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.SHEMADDSet.SHEMADDSHEMADDDOPRINOS.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowSHEMADDSHEMADDDOPRINOS = (SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow) current;
                    if (Helpers.IsRowChanged(this.rowSHEMADDSHEMADDDOPRINOS))
                    {
                        bool flag = false;
                        if (this.rowSHEMADDSHEMADDDOPRINOS.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowSHEMADDSHEMADDDOPRINOS.IDSHEMADD == this.rowSHEMADD.IDSHEMADD;
                        }
                        else
                        {
                            flag = this.rowSHEMADDSHEMADDDOPRINOS["IDSHEMADD", DataRowVersion.Original].Equals(this.rowSHEMADD.IDSHEMADD);
                        }
                        if (flag)
                        {
                            this.ReadRowShemaddshemadddoprinos();
                            if (this.rowSHEMADDSHEMADDDOPRINOS.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertShemaddshemadddoprinos();
                            }
                            else
                            {
                                if (this._Gxremove17)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteShemaddshemadddoprinos();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateShemaddshemadddoprinos();
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

        private void ProcessNestedLevelShemaddshemaddstandard()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.SHEMADDSet.SHEMADDSHEMADDSTANDARD.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowSHEMADDSHEMADDSTANDARD = (SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow) current;
                    if (Helpers.IsRowChanged(this.rowSHEMADDSHEMADDSTANDARD))
                    {
                        bool flag = false;
                        if (this.rowSHEMADDSHEMADDSTANDARD.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowSHEMADDSHEMADDSTANDARD.IDSHEMADD == this.rowSHEMADD.IDSHEMADD;
                        }
                        else
                        {
                            flag = this.rowSHEMADDSHEMADDSTANDARD["IDSHEMADD", DataRowVersion.Original].Equals(this.rowSHEMADD.IDSHEMADD);
                        }
                        if (flag)
                        {
                            this.ReadRowShemaddshemaddstandard();
                            if (this.rowSHEMADDSHEMADDSTANDARD.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertShemaddshemaddstandard();
                            }
                            else
                            {
                                if (this._Gxremove23)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteShemaddshemaddstandard();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateShemaddshemaddstandard();
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

        private void ReadRowShemadd()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSHEMADD.RowState);
            if (this.rowSHEMADD.RowState != DataRowState.Added)
            {
                this.m__NAZIVSHEMADDOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMADD["NAZIVSHEMADD", DataRowVersion.Original]);
                this.m__SHEMADDOJIDORGJEDOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMADD["SHEMADDOJIDORGJED", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVSHEMADDOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMADD["NAZIVSHEMADD"]);
                this.m__SHEMADDOJIDORGJEDOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMADD["SHEMADDOJIDORGJED"]);
            }
            this._Gxremove = this.rowSHEMADD.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowSHEMADD = (SHEMADDDataSet.SHEMADDRow) DataSetUtil.CloneOriginalDataRow(this.rowSHEMADD);
            }
        }

        private void ReadRowShemaddshemadddoprinos()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSHEMADDSHEMADDDOPRINOS.RowState);
            if (this.rowSHEMADDSHEMADDDOPRINOS.RowState != DataRowState.Added)
            {
                this.m__MTDOPIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["MTDOPIDMJESTOTROSKA", DataRowVersion.Original]);
                this.m__STRANEDOPIDSTRANEKNJIZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["STRANEDOPIDSTRANEKNJIZENJA", DataRowVersion.Original]);
            }
            else
            {
                this.m__MTDOPIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["MTDOPIDMJESTOTROSKA"]);
                this.m__STRANEDOPIDSTRANEKNJIZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["STRANEDOPIDSTRANEKNJIZENJA"]);
            }
            this._Gxremove17 = this.rowSHEMADDSHEMADDDOPRINOS.RowState == DataRowState.Deleted;
            if (this._Gxremove17)
            {
                this.rowSHEMADDSHEMADDDOPRINOS = (SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow) DataSetUtil.CloneOriginalDataRow(this.rowSHEMADDSHEMADDDOPRINOS);
            }
        }

        private void ReadRowShemaddshemaddstandard()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSHEMADDSHEMADDSTANDARD.RowState);
            if (this.rowSHEMADDSHEMADDSTANDARD.RowState != DataRowState.Added)
            {
                this.m__IDDDVRSTEIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["IDDDVRSTEIZNOSA", DataRowVersion.Original]);
                this.m__KONTODDVRSTAIZNOSAIDKONTOOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["KONTODDVRSTAIZNOSAIDKONTO", DataRowVersion.Original]);
                this.m__MTDDVRSTAIZNOSAIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["MTDDVRSTAIZNOSAIDMJESTOTROSKA", DataRowVersion.Original]);
                this.m__STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA", DataRowVersion.Original]);
            }
            else
            {
                this.m__IDDDVRSTEIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["IDDDVRSTEIZNOSA"]);
                this.m__KONTODDVRSTAIZNOSAIDKONTOOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["KONTODDVRSTAIZNOSAIDKONTO"]);
                this.m__MTDDVRSTAIZNOSAIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["MTDDVRSTAIZNOSAIDMJESTOTROSKA"]);
                this.m__STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"]);
            }
            this._Gxremove23 = this.rowSHEMADDSHEMADDSTANDARD.RowState == DataRowState.Deleted;
            if (this._Gxremove23)
            {
                this.rowSHEMADDSHEMADDSTANDARD = (SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow) DataSetUtil.CloneOriginalDataRow(this.rowSHEMADDSHEMADDSTANDARD);
            }
        }

        private void ScanByIDSHEMADD(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDSHEMADD] = @IDSHEMADD";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString241 + "  FROM [SHEMADD] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMADD]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString241, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMADD] ) AS DK_PAGENUM   FROM [SHEMADD] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString241 + " FROM [SHEMADD] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMADD] ";
            }
            this.cmSHEMADDSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmSHEMADDSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMADDSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMADD", DbType.Int32));
            }
            this.cmSHEMADDSelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADD["IDSHEMADD"]));
            this.SHEMADDSelect5 = this.cmSHEMADDSelect5.FetchData();
            this.RcdFound241 = 0;
            this.ScanLoadShemadd();
            this.LoadDataShemadd(maxRows);
            if (this.RcdFound241 > 0)
            {
                this.SubLvlScanStartShemaddshemadddoprinos(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSHEMADDShemadd(this.cmSHEMADDSHEMADDDOPRINOSSelect2);
                this.SubLvlFetchShemaddshemadddoprinos();
                this.SubLoadDataShemaddshemadddoprinos();
                this.SubLvlScanStartShemaddshemaddstandard(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSHEMADDShemadd(this.cmSHEMADDSHEMADDSTANDARDSelect2);
                this.SubLvlFetchShemaddshemaddstandard();
                this.SubLoadDataShemaddshemaddstandard();
            }
        }

        private void ScanBySHEMADDOJIDORGJED(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[SHEMADDOJIDORGJED] = @SHEMADDOJIDORGJED";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString241 + "  FROM [SHEMADD] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMADD]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString241, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMADD] ) AS DK_PAGENUM   FROM [SHEMADD] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString241 + " FROM [SHEMADD] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMADD] ";
            }
            this.cmSHEMADDSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmSHEMADDSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMADDSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMADDOJIDORGJED", DbType.Int32));
            }
            this.cmSHEMADDSelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADD["SHEMADDOJIDORGJED"]));
            this.SHEMADDSelect5 = this.cmSHEMADDSelect5.FetchData();
            this.RcdFound241 = 0;
            this.ScanLoadShemadd();
            this.LoadDataShemadd(maxRows);
            if (this.RcdFound241 > 0)
            {
                this.SubLvlScanStartShemaddshemadddoprinos(this.m_WhereString, startRow, maxRows);
                this.SetParametersSHEMADDOJIDORGJEDShemadd(this.cmSHEMADDSHEMADDDOPRINOSSelect2);
                this.SubLvlFetchShemaddshemadddoprinos();
                this.SubLoadDataShemaddshemadddoprinos();
                this.SubLvlScanStartShemaddshemaddstandard(this.m_WhereString, startRow, maxRows);
                this.SetParametersSHEMADDOJIDORGJEDShemadd(this.cmSHEMADDSHEMADDSTANDARDSelect2);
                this.SubLvlFetchShemaddshemaddstandard();
                this.SubLoadDataShemaddshemaddstandard();
            }
        }

        private void ScanEndShemadd()
        {
            this.SHEMADDSelect5.Close();
        }

        private void ScanEndShemaddshemadddoprinos()
        {
            this.SHEMADDSHEMADDDOPRINOSSelect2.Close();
        }

        private void ScanEndShemaddshemaddstandard()
        {
            this.SHEMADDSHEMADDSTANDARDSelect2.Close();
        }

        private void ScanLoadShemadd()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSHEMADDSelect5.HasMoreRows)
            {
                this.RcdFound241 = 1;
                this.rowSHEMADD["IDSHEMADD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMADDSelect5, 0));
                this.rowSHEMADD["NAZIVSHEMADD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMADDSelect5, 1));
                this.rowSHEMADD["SHEMADDOJIDORGJED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMADDSelect5, 2));
            }
        }

        private void ScanLoadShemaddshemadddoprinos()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSHEMADDSHEMADDDOPRINOSSelect2.HasMoreRows)
            {
                this.RcdFound243 = 1;
                this.rowSHEMADDSHEMADDDOPRINOS["IDSHEMADD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMADDSHEMADDDOPRINOSSelect2, 0));
                this.rowSHEMADDSHEMADDDOPRINOS["SHEMADDDOPRINOSNAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMADDSHEMADDDOPRINOSSelect2, 1));
                this.rowSHEMADDSHEMADDDOPRINOS["SHEMADDDOPRINOSIDDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMADDSHEMADDDOPRINOSSelect2, 2));
                this.rowSHEMADDSHEMADDDOPRINOS["KONTODOPIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMADDSHEMADDDOPRINOSSelect2, 3))));
                this.rowSHEMADDSHEMADDDOPRINOS["MTDOPIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMADDSHEMADDDOPRINOSSelect2, 4));
                this.rowSHEMADDSHEMADDDOPRINOS["STRANEDOPIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMADDSHEMADDDOPRINOSSelect2, 5));
                this.rowSHEMADDSHEMADDDOPRINOS["SHEMADDDOPRINOSNAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMADDSHEMADDDOPRINOSSelect2, 1));
            }
        }

        private void ScanLoadShemaddshemaddstandard()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSHEMADDSHEMADDSTANDARDSelect2.HasMoreRows)
            {
                this.RcdFound244 = 1;
                this.rowSHEMADDSHEMADDSTANDARD["IDSHEMADD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMADDSHEMADDSTANDARDSelect2, 0));
                this.rowSHEMADDSHEMADDSTANDARD["SHEMADDSTANDARDID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetGuid(this.SHEMADDSHEMADDSTANDARDSelect2, 1));
                this.rowSHEMADDSHEMADDSTANDARD["NAZIVDDVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMADDSHEMADDSTANDARDSelect2, 2));
                this.rowSHEMADDSHEMADDSTANDARD["IDDDVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMADDSHEMADDSTANDARDSelect2, 3));
                this.rowSHEMADDSHEMADDSTANDARD["KONTODDVRSTAIZNOSAIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMADDSHEMADDSTANDARDSelect2, 4))));
                this.rowSHEMADDSHEMADDSTANDARD["MTDDVRSTAIZNOSAIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMADDSHEMADDSTANDARDSelect2, 5));
                this.rowSHEMADDSHEMADDSTANDARD["STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMADDSHEMADDSTANDARDSelect2, 6));
                this.rowSHEMADDSHEMADDSTANDARD["NAZIVDDVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMADDSHEMADDSTANDARDSelect2, 2));
            }
        }

        private void ScanNextShemadd()
        {
            this.cmSHEMADDSelect5.HasMoreRows = this.SHEMADDSelect5.Read();
            this.RcdFound241 = 0;
            this.ScanLoadShemadd();
        }

        private void ScanNextShemaddshemadddoprinos()
        {
            this.cmSHEMADDSHEMADDDOPRINOSSelect2.HasMoreRows = this.SHEMADDSHEMADDDOPRINOSSelect2.Read();
            this.RcdFound243 = 0;
            this.ScanLoadShemaddshemadddoprinos();
        }

        private void ScanNextShemaddshemaddstandard()
        {
            this.cmSHEMADDSHEMADDSTANDARDSelect2.HasMoreRows = this.SHEMADDSHEMADDSTANDARDSelect2.Read();
            this.RcdFound244 = 0;
            this.ScanLoadShemaddshemaddstandard();
        }

        private void ScanStartShemadd(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString241 + "  FROM [SHEMADD] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMADD]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString241, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMADD] ) AS DK_PAGENUM   FROM [SHEMADD] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString241 + " FROM [SHEMADD] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMADD] ";
            }
            this.cmSHEMADDSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.SHEMADDSelect5 = this.cmSHEMADDSelect5.FetchData();
            this.RcdFound241 = 0;
            this.ScanLoadShemadd();
            this.LoadDataShemadd(maxRows);
            if (this.RcdFound241 > 0)
            {
                this.SubLvlScanStartShemaddshemadddoprinos(this.m_WhereString, startRow, maxRows);
                this.SetParametersShemaddShemadd(this.cmSHEMADDSHEMADDDOPRINOSSelect2);
                this.SubLvlFetchShemaddshemadddoprinos();
                this.SubLoadDataShemaddshemadddoprinos();
                this.SubLvlScanStartShemaddshemaddstandard(this.m_WhereString, startRow, maxRows);
                this.SetParametersShemaddShemadd(this.cmSHEMADDSHEMADDSTANDARDSelect2);
                this.SubLvlFetchShemaddshemaddstandard();
                this.SubLoadDataShemaddshemaddstandard();
            }
        }

        private void ScanStartShemaddshemadddoprinos()
        {
            this.cmSHEMADDSHEMADDDOPRINOSSelect2 = this.connDefault.GetCommand("SELECT T1.[IDSHEMADD], T2.[NAZIVDOPRINOS] AS SHEMADDDOPRINOSNAZIVDOPRINOS, T1.[SHEMADDDOPRINOSIDDOPRINOS] AS SHEMADDDOPRINOSIDDOPRINOS, T1.[KONTODOPIDKONTO] AS KONTODOPIDKONTO, T1.[MTDOPIDMJESTOTROSKA] AS MTDOPIDMJESTOTROSKA, T1.[STRANEDOPIDSTRANEKNJIZENJA] AS STRANEDOPIDSTRANEKNJIZENJA FROM ([SHEMADDSHEMADDDOPRINOS] T1 WITH (NOLOCK) INNER JOIN [DOPRINOS] T2 WITH (NOLOCK) ON T2.[IDDOPRINOS] = T1.[SHEMADDDOPRINOSIDDOPRINOS]) WHERE T1.[IDSHEMADD] = @IDSHEMADD ORDER BY T1.[IDSHEMADD], T1.[SHEMADDDOPRINOSIDDOPRINOS], T1.[KONTODOPIDKONTO] ", false);
            if (this.cmSHEMADDSHEMADDDOPRINOSSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMADDSHEMADDDOPRINOSSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMADD", DbType.Int32));
            }
            this.cmSHEMADDSHEMADDDOPRINOSSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["IDSHEMADD"]));
            this.SHEMADDSHEMADDDOPRINOSSelect2 = this.cmSHEMADDSHEMADDDOPRINOSSelect2.FetchData();
            this.RcdFound243 = 0;
            this.ScanLoadShemaddshemadddoprinos();
        }

        private void ScanStartShemaddshemaddstandard()
        {
            this.cmSHEMADDSHEMADDSTANDARDSelect2 = this.connDefault.GetCommand("SELECT T1.[IDSHEMADD], T1.[SHEMADDSTANDARDID], T2.[NAZIVDDVRSTEIZNOSA], T1.[IDDDVRSTEIZNOSA], T1.[KONTODDVRSTAIZNOSAIDKONTO] AS KONTODDVRSTAIZNOSAIDKONTO, T1.[MTDDVRSTAIZNOSAIDMJESTOTROSKA] AS MTDDVRSTAIZNOSAIDMJESTOTROSKA, T1.[STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA] AS STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA FROM ([SHEMADDSHEMADDSTANDARD] T1 WITH (NOLOCK) INNER JOIN [DDVRSTEIZNOSA] T2 WITH (NOLOCK) ON T2.[IDDDVRSTEIZNOSA] = T1.[IDDDVRSTEIZNOSA]) WHERE T1.[IDSHEMADD] = @IDSHEMADD ORDER BY T1.[IDSHEMADD], T1.[SHEMADDSTANDARDID] ", false);
            if (this.cmSHEMADDSHEMADDSTANDARDSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMADDSHEMADDSTANDARDSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMADD", DbType.Int32));
            }
            this.cmSHEMADDSHEMADDSTANDARDSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["IDSHEMADD"]));
            this.SHEMADDSHEMADDSTANDARDSelect2 = this.cmSHEMADDSHEMADDSTANDARDSelect2.FetchData();
            this.RcdFound244 = 0;
            this.ScanLoadShemaddshemaddstandard();
        }

        private void SetParametersIDSHEMADDShemadd(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMADD", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADD["IDSHEMADD"]));
        }

        private void SetParametersSHEMADDOJIDORGJEDShemadd(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMADDOJIDORGJED", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADD["SHEMADDOJIDORGJED"]));
        }

        private void SetParametersShemaddShemadd(ReadWriteCommand m_Command)
        {
        }

        private void SkipNextShemaddshemadddoprinos()
        {
            this.cmSHEMADDSHEMADDDOPRINOSSelect2.HasMoreRows = this.SHEMADDSHEMADDDOPRINOSSelect2.Read();
            this.RcdFound243 = 0;
            if (this.cmSHEMADDSHEMADDDOPRINOSSelect2.HasMoreRows)
            {
                this.RcdFound243 = 1;
            }
        }

        private void SkipNextShemaddshemaddstandard()
        {
            this.cmSHEMADDSHEMADDSTANDARDSelect2.HasMoreRows = this.SHEMADDSHEMADDSTANDARDSelect2.Read();
            this.RcdFound244 = 0;
            if (this.cmSHEMADDSHEMADDSTANDARDSelect2.HasMoreRows)
            {
                this.RcdFound244 = 1;
            }
        }

        private void SubLoadDataShemaddshemadddoprinos()
        {
            while (this.RcdFound243 != 0)
            {
                this.LoadRowShemaddshemadddoprinos();
                this.CreateNewRowShemaddshemadddoprinos();
                this.ScanNextShemaddshemadddoprinos();
            }
            this.ScanEndShemaddshemadddoprinos();
        }

        private void SubLoadDataShemaddshemaddstandard()
        {
            while (this.RcdFound244 != 0)
            {
                this.LoadRowShemaddshemaddstandard();
                this.CreateNewRowShemaddshemaddstandard();
                this.ScanNextShemaddshemaddstandard();
            }
            this.ScanEndShemaddshemaddstandard();
        }

        private void SubLvlFetchShemaddshemadddoprinos()
        {
            this.CreateNewRowShemaddshemadddoprinos();
            this.SHEMADDSHEMADDDOPRINOSSelect2 = this.cmSHEMADDSHEMADDDOPRINOSSelect2.FetchData();
            this.RcdFound243 = 0;
            this.ScanLoadShemaddshemadddoprinos();
        }

        private void SubLvlFetchShemaddshemaddstandard()
        {
            this.CreateNewRowShemaddshemaddstandard();
            this.SHEMADDSHEMADDSTANDARDSelect2 = this.cmSHEMADDSHEMADDSTANDARDSelect2.FetchData();
            this.RcdFound244 = 0;
            this.ScanLoadShemaddshemaddstandard();
        }

        private void SubLvlScanStartShemaddshemadddoprinos(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString243 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDSHEMADD]  FROM [SHEMADD]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDSHEMADD] )";
                    this.scmdbuf = "SELECT T1.[IDSHEMADD], T3.[NAZIVDOPRINOS] AS SHEMADDDOPRINOSNAZIVDOPRINOS, T1.[SHEMADDDOPRINOSIDDOPRINOS] AS SHEMADDDOPRINOSIDDOPRINOS, T1.[KONTODOPIDKONTO] AS KONTODOPIDKONTO, T1.[MTDOPIDMJESTOTROSKA] AS MTDOPIDMJESTOTROSKA, T1.[STRANEDOPIDSTRANEKNJIZENJA] AS STRANEDOPIDSTRANEKNJIZENJA FROM (([SHEMADDSHEMADDDOPRINOS] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString243 + "  TMX ON TMX.[IDSHEMADD] = T1.[IDSHEMADD]) INNER JOIN [DOPRINOS] T3 WITH (NOLOCK) ON T3.[IDDOPRINOS] = T1.[SHEMADDDOPRINOSIDDOPRINOS]) ORDER BY T1.[IDSHEMADD], T1.[SHEMADDDOPRINOSIDDOPRINOS], T1.[KONTODOPIDKONTO]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDSHEMADD], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMADD]  ) AS DK_PAGENUM   FROM [SHEMADD]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString243 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDSHEMADD], T3.[NAZIVDOPRINOS] AS SHEMADDDOPRINOSNAZIVDOPRINOS, T1.[SHEMADDDOPRINOSIDDOPRINOS] AS SHEMADDDOPRINOSIDDOPRINOS, T1.[KONTODOPIDKONTO] AS KONTODOPIDKONTO, T1.[MTDOPIDMJESTOTROSKA] AS MTDOPIDMJESTOTROSKA, T1.[STRANEDOPIDSTRANEKNJIZENJA] AS STRANEDOPIDSTRANEKNJIZENJA FROM (([SHEMADDSHEMADDDOPRINOS] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString243 + "  TMX ON TMX.[IDSHEMADD] = T1.[IDSHEMADD]) INNER JOIN [DOPRINOS] T3 WITH (NOLOCK) ON T3.[IDDOPRINOS] = T1.[SHEMADDDOPRINOSIDDOPRINOS]) ORDER BY T1.[IDSHEMADD], T1.[SHEMADDDOPRINOSIDDOPRINOS], T1.[KONTODOPIDKONTO]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString243 = "[SHEMADD]";
                this.scmdbuf = "SELECT T1.[IDSHEMADD], T3.[NAZIVDOPRINOS] AS SHEMADDDOPRINOSNAZIVDOPRINOS, T1.[SHEMADDDOPRINOSIDDOPRINOS] AS SHEMADDDOPRINOSIDDOPRINOS, T1.[KONTODOPIDKONTO] AS KONTODOPIDKONTO, T1.[MTDOPIDMJESTOTROSKA] AS MTDOPIDMJESTOTROSKA, T1.[STRANEDOPIDSTRANEKNJIZENJA] AS STRANEDOPIDSTRANEKNJIZENJA FROM (([SHEMADDSHEMADDDOPRINOS] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString243 + "  TM1 WITH (NOLOCK) ON TM1.[IDSHEMADD] = T1.[IDSHEMADD]) INNER JOIN [DOPRINOS] T3 WITH (NOLOCK) ON T3.[IDDOPRINOS] = T1.[SHEMADDDOPRINOSIDDOPRINOS])" + this.m_WhereString + " ORDER BY T1.[IDSHEMADD], T1.[SHEMADDDOPRINOSIDDOPRINOS], T1.[KONTODOPIDKONTO] ";
            }
            this.cmSHEMADDSHEMADDDOPRINOSSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartShemaddshemaddstandard(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString244 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDSHEMADD]  FROM [SHEMADD]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDSHEMADD] )";
                    this.scmdbuf = "SELECT T1.[IDSHEMADD], T1.[SHEMADDSTANDARDID], T3.[NAZIVDDVRSTEIZNOSA], T1.[IDDDVRSTEIZNOSA], T1.[KONTODDVRSTAIZNOSAIDKONTO] AS KONTODDVRSTAIZNOSAIDKONTO, T1.[MTDDVRSTAIZNOSAIDMJESTOTROSKA] AS MTDDVRSTAIZNOSAIDMJESTOTROSKA, T1.[STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA] AS STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA FROM (([SHEMADDSHEMADDSTANDARD] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString244 + "  TMX ON TMX.[IDSHEMADD] = T1.[IDSHEMADD]) INNER JOIN [DDVRSTEIZNOSA] T3 WITH (NOLOCK) ON T3.[IDDDVRSTEIZNOSA] = T1.[IDDDVRSTEIZNOSA]) ORDER BY T1.[IDSHEMADD], T1.[SHEMADDSTANDARDID]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDSHEMADD], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMADD]  ) AS DK_PAGENUM   FROM [SHEMADD]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString244 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDSHEMADD], T1.[SHEMADDSTANDARDID], T3.[NAZIVDDVRSTEIZNOSA], T1.[IDDDVRSTEIZNOSA], T1.[KONTODDVRSTAIZNOSAIDKONTO] AS KONTODDVRSTAIZNOSAIDKONTO, T1.[MTDDVRSTAIZNOSAIDMJESTOTROSKA] AS MTDDVRSTAIZNOSAIDMJESTOTROSKA, T1.[STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA] AS STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA FROM (([SHEMADDSHEMADDSTANDARD] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString244 + "  TMX ON TMX.[IDSHEMADD] = T1.[IDSHEMADD]) INNER JOIN [DDVRSTEIZNOSA] T3 WITH (NOLOCK) ON T3.[IDDDVRSTEIZNOSA] = T1.[IDDDVRSTEIZNOSA]) ORDER BY T1.[IDSHEMADD], T1.[SHEMADDSTANDARDID]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString244 = "[SHEMADD]";
                this.scmdbuf = "SELECT T1.[IDSHEMADD], T1.[SHEMADDSTANDARDID], T3.[NAZIVDDVRSTEIZNOSA], T1.[IDDDVRSTEIZNOSA], T1.[KONTODDVRSTAIZNOSAIDKONTO] AS KONTODDVRSTAIZNOSAIDKONTO, T1.[MTDDVRSTAIZNOSAIDMJESTOTROSKA] AS MTDDVRSTAIZNOSAIDMJESTOTROSKA, T1.[STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA] AS STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA FROM (([SHEMADDSHEMADDSTANDARD] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString244 + "  TM1 WITH (NOLOCK) ON TM1.[IDSHEMADD] = T1.[IDSHEMADD]) INNER JOIN [DDVRSTEIZNOSA] T3 WITH (NOLOCK) ON T3.[IDDDVRSTEIZNOSA] = T1.[IDDDVRSTEIZNOSA])" + this.m_WhereString + " ORDER BY T1.[IDSHEMADD], T1.[SHEMADDSTANDARDID] ";
            }
            this.cmSHEMADDSHEMADDSTANDARDSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.SHEMADDSet = (SHEMADDDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.SHEMADDSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.SHEMADDSet.SHEMADD.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        SHEMADDDataSet.SHEMADDRow current = (SHEMADDDataSet.SHEMADDRow) enumerator.Current;
                        this.rowSHEMADD = current;
                        if (Helpers.IsRowChanged(this.rowSHEMADD))
                        {
                            this.ReadRowShemadd();
                            if (this.rowSHEMADD.RowState == DataRowState.Added)
                            {
                                this.InsertShemadd();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateShemadd();
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

        private void UpdateShemadd()
        {
            this.CheckOptimisticConcurrencyShemadd();
            this.AfterConfirmShemadd();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [SHEMADD] SET [NAZIVSHEMADD]=@NAZIVSHEMADD, [SHEMADDOJIDORGJED]=@SHEMADDOJIDORGJED  WHERE [IDSHEMADD] = @IDSHEMADD", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSHEMADD", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMADDOJIDORGJED", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMADD", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADD["NAZIVSHEMADD"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMADD["SHEMADDOJIDORGJED"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMADD["IDSHEMADD"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemadd();
            }
            this.OnSHEMADDUpdated(new SHEMADDEventArgs(this.rowSHEMADD, StatementType.Update));
            this.ProcessLevelShemadd();
        }

        private void UpdateShemaddshemadddoprinos()
        {
            this.CheckOptimisticConcurrencyShemaddshemadddoprinos();
            this.CheckExtendedTableShemaddshemadddoprinos();
            this.AfterConfirmShemaddshemadddoprinos();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [SHEMADDSHEMADDDOPRINOS] SET [MTDOPIDMJESTOTROSKA]=@MTDOPIDMJESTOTROSKA, [STRANEDOPIDSTRANEKNJIZENJA]=@STRANEDOPIDSTRANEKNJIZENJA  WHERE [IDSHEMADD] = @IDSHEMADD AND [SHEMADDDOPRINOSIDDOPRINOS] = @SHEMADDDOPRINOSIDDOPRINOS AND [KONTODOPIDKONTO] = @KONTODOPIDKONTO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MTDOPIDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STRANEDOPIDSTRANEKNJIZENJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMADD", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMADDDOPRINOSIDDOPRINOS", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTODOPIDKONTO", DbType.String, 14));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["MTDOPIDMJESTOTROSKA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["STRANEDOPIDSTRANEKNJIZENJA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["IDSHEMADD"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["SHEMADDDOPRINOSIDDOPRINOS"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDDOPRINOS["KONTODOPIDKONTO"]))));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemaddshemadddoprinos();
            }
            this.OnSHEMADDSHEMADDDOPRINOSUpdated(new SHEMADDSHEMADDDOPRINOSEventArgs(this.rowSHEMADDSHEMADDDOPRINOS, StatementType.Update));
        }

        private void UpdateShemaddshemaddstandard()
        {
            this.CheckOptimisticConcurrencyShemaddshemaddstandard();
            this.CheckExtendedTableShemaddshemaddstandard();
            this.AfterConfirmShemaddshemaddstandard();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [SHEMADDSHEMADDSTANDARD] SET [IDDDVRSTEIZNOSA]=@IDDDVRSTEIZNOSA, [KONTODDVRSTAIZNOSAIDKONTO]=@KONTODDVRSTAIZNOSAIDKONTO, [MTDDVRSTAIZNOSAIDMJESTOTROSKA]=@MTDDVRSTAIZNOSAIDMJESTOTROSKA, [STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA]=@STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA  WHERE [IDSHEMADD] = @IDSHEMADD AND [SHEMADDSTANDARDID] = @SHEMADDSTANDARDID", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDDVRSTEIZNOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTODDVRSTAIZNOSAIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MTDDVRSTAIZNOSAIDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMADD", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMADDSTANDARDID", DbType.Guid));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["IDDDVRSTEIZNOSA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["KONTODDVRSTAIZNOSAIDKONTO"]))));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["MTDDVRSTAIZNOSAIDMJESTOTROSKA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["IDSHEMADD"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowSHEMADDSHEMADDSTANDARD["SHEMADDSTANDARDID"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemaddshemaddstandard();
            }
            this.OnSHEMADDSHEMADDSTANDARDUpdated(new SHEMADDSHEMADDSTANDARDEventArgs(this.rowSHEMADDSHEMADDSTANDARD, StatementType.Update));
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
        public class DDVRSTEIZNOSAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public DDVRSTEIZNOSAForeignKeyNotFoundException()
            {
            }

            public DDVRSTEIZNOSAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected DDVRSTEIZNOSAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDVRSTEIZNOSAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
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

        [Serializable]
        public class SHEMADDDataChangedException : DataChangedException
        {
            public SHEMADDDataChangedException()
            {
            }

            public SHEMADDDataChangedException(string message) : base(message)
            {
            }

            protected SHEMADDDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMADDDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMADDDataLockedException : DataLockedException
        {
            public SHEMADDDataLockedException()
            {
            }

            public SHEMADDDataLockedException(string message) : base(message)
            {
            }

            protected SHEMADDDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMADDDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMADDDuplicateKeyException : DuplicateKeyException
        {
            public SHEMADDDuplicateKeyException()
            {
            }

            public SHEMADDDuplicateKeyException(string message) : base(message)
            {
            }

            protected SHEMADDDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMADDDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class SHEMADDEventArgs : EventArgs
        {
            private SHEMADDDataSet.SHEMADDRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public SHEMADDEventArgs(SHEMADDDataSet.SHEMADDRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public SHEMADDDataSet.SHEMADDRow Row
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
        public class SHEMADDNotFoundException : DataNotFoundException
        {
            public SHEMADDNotFoundException()
            {
            }

            public SHEMADDNotFoundException(string message) : base(message)
            {
            }

            protected SHEMADDNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMADDNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMADDSHEMADDDOPRINOSDataChangedException : DataChangedException
        {
            public SHEMADDSHEMADDDOPRINOSDataChangedException()
            {
            }

            public SHEMADDSHEMADDDOPRINOSDataChangedException(string message) : base(message)
            {
            }

            protected SHEMADDSHEMADDDOPRINOSDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMADDSHEMADDDOPRINOSDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMADDSHEMADDDOPRINOSDataLockedException : DataLockedException
        {
            public SHEMADDSHEMADDDOPRINOSDataLockedException()
            {
            }

            public SHEMADDSHEMADDDOPRINOSDataLockedException(string message) : base(message)
            {
            }

            protected SHEMADDSHEMADDDOPRINOSDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMADDSHEMADDDOPRINOSDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMADDSHEMADDDOPRINOSDuplicateKeyException : DuplicateKeyException
        {
            public SHEMADDSHEMADDDOPRINOSDuplicateKeyException()
            {
            }

            public SHEMADDSHEMADDDOPRINOSDuplicateKeyException(string message) : base(message)
            {
            }

            protected SHEMADDSHEMADDDOPRINOSDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMADDSHEMADDDOPRINOSDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class SHEMADDSHEMADDDOPRINOSEventArgs : EventArgs
        {
            private SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public SHEMADDSHEMADDDOPRINOSEventArgs(SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow Row
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

        public delegate void SHEMADDSHEMADDDOPRINOSUpdateEventHandler(object sender, SHEMADDDataAdapter.SHEMADDSHEMADDDOPRINOSEventArgs e);

        [Serializable]
        public class SHEMADDSHEMADDSTANDARDDataChangedException : DataChangedException
        {
            public SHEMADDSHEMADDSTANDARDDataChangedException()
            {
            }

            public SHEMADDSHEMADDSTANDARDDataChangedException(string message) : base(message)
            {
            }

            protected SHEMADDSHEMADDSTANDARDDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMADDSHEMADDSTANDARDDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMADDSHEMADDSTANDARDDataLockedException : DataLockedException
        {
            public SHEMADDSHEMADDSTANDARDDataLockedException()
            {
            }

            public SHEMADDSHEMADDSTANDARDDataLockedException(string message) : base(message)
            {
            }

            protected SHEMADDSHEMADDSTANDARDDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMADDSHEMADDSTANDARDDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMADDSHEMADDSTANDARDDuplicateKeyException : DuplicateKeyException
        {
            public SHEMADDSHEMADDSTANDARDDuplicateKeyException()
            {
            }

            public SHEMADDSHEMADDSTANDARDDuplicateKeyException(string message) : base(message)
            {
            }

            protected SHEMADDSHEMADDSTANDARDDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMADDSHEMADDSTANDARDDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class SHEMADDSHEMADDSTANDARDEventArgs : EventArgs
        {
            private SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public SHEMADDSHEMADDSTANDARDEventArgs(SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow Row
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

        public delegate void SHEMADDSHEMADDSTANDARDUpdateEventHandler(object sender, SHEMADDDataAdapter.SHEMADDSHEMADDSTANDARDEventArgs e);

        public delegate void SHEMADDUpdateEventHandler(object sender, SHEMADDDataAdapter.SHEMADDEventArgs e);

        [Serializable]
        public class STRANEKNJIZENJAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public STRANEKNJIZENJAForeignKeyNotFoundException()
            {
            }

            public STRANEKNJIZENJAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected STRANEKNJIZENJAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRANEKNJIZENJAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

