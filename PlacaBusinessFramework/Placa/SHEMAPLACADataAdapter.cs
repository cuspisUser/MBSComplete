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

    public class SHEMAPLACADataAdapter : IDataAdapter, ISHEMAPLACADataAdapter
    {
        private bool _Gxremove;
        private bool _Gxremove17;
        private bool _Gxremove23;
        private bool _Gxremove30;
        private ReadWriteCommand cmSHEMAPLACASelect1;
        private ReadWriteCommand cmSHEMAPLACASelect2;
        private ReadWriteCommand cmSHEMAPLACASelect5;
        private ReadWriteCommand cmSHEMAPLACASHEMAPLACADOPSelect2;
        private ReadWriteCommand cmSHEMAPLACASHEMAPLACAELEMENTSelect2;
        private ReadWriteCommand cmSHEMAPLACASHEMAPLACASTANDARDSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__IDPLVRSTEIZNOSAOriginal;
        private object m__KONTOPLACAVRSTAIZNOSAIDKONTOOriginal;
        private object m__MTDOPIDMJESTOTROSKAOriginal;
        private object m__MTELEMENTIDMJESTOTROSKAOriginal;
        private object m__MTPLACAVRSTAIZNOSAIDMJESTOTROSKAOriginal;
        private object m__NAZIVSHEMAPLACAOriginal;
        private object m__SHEMAPLOJIDORGJEDOriginal;
        private object m__STRANEDOPIDSTRANEKNJIZENJAOriginal;
        private object m__STRANEVRSTEIZNOSAIDSTRANEKNJIZENJAOriginal;
        private readonly string m_SelectString224 = "TM1.[IDSHEMAPLACA], TM1.[NAZIVSHEMAPLACA], TM1.[SHEMAPLOJIDORGJED] AS SHEMAPLOJIDORGJED";
        private string m_SubSelTopString230;
        private string m_SubSelTopString233;
        private string m_SubSelTopString234;
        private string m_WhereString;
        private short RcdFound224;
        private short RcdFound230;
        private short RcdFound233;
        private short RcdFound234;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private SHEMAPLACADataSet.SHEMAPLACARow rowSHEMAPLACA;
        private SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow rowSHEMAPLACASHEMAPLACADOP;
        private SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow rowSHEMAPLACASHEMAPLACAELEMENT;
        private SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow rowSHEMAPLACASHEMAPLACASTANDARD;
        private string scmdbuf;
        private IDataReader SHEMAPLACASelect1;
        private IDataReader SHEMAPLACASelect2;
        private IDataReader SHEMAPLACASelect5;
        private SHEMAPLACADataSet SHEMAPLACASet;
        private IDataReader SHEMAPLACASHEMAPLACADOPSelect2;
        private IDataReader SHEMAPLACASHEMAPLACAELEMENTSelect2;
        private IDataReader SHEMAPLACASHEMAPLACASTANDARDSelect2;
        private StatementType sMode224;
        private StatementType sMode230;
        private StatementType sMode233;
        private StatementType sMode234;

        public event SHEMAPLACASHEMAPLACADOPUpdateEventHandler SHEMAPLACASHEMAPLACADOPUpdated;

        public event SHEMAPLACASHEMAPLACADOPUpdateEventHandler SHEMAPLACASHEMAPLACADOPUpdating;

        public event SHEMAPLACASHEMAPLACAELEMENTUpdateEventHandler SHEMAPLACASHEMAPLACAELEMENTUpdated;

        public event SHEMAPLACASHEMAPLACAELEMENTUpdateEventHandler SHEMAPLACASHEMAPLACAELEMENTUpdating;

        public event SHEMAPLACASHEMAPLACASTANDARDUpdateEventHandler SHEMAPLACASHEMAPLACASTANDARDUpdated;

        public event SHEMAPLACASHEMAPLACASTANDARDUpdateEventHandler SHEMAPLACASHEMAPLACASTANDARDUpdating;

        public event SHEMAPLACAUpdateEventHandler SHEMAPLACAUpdated;

        public event SHEMAPLACAUpdateEventHandler SHEMAPLACAUpdating;

        private void AddRowShemaplaca()
        {
            this.SHEMAPLACASet.SHEMAPLACA.AddSHEMAPLACARow(this.rowSHEMAPLACA);
        }

        private void AddRowShemaplacashemaplacadop()
        {
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACADOP.AddSHEMAPLACASHEMAPLACADOPRow(this.rowSHEMAPLACASHEMAPLACADOP);
        }

        private void AddRowShemaplacashemaplacaelement()
        {
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACAELEMENT.AddSHEMAPLACASHEMAPLACAELEMENTRow(this.rowSHEMAPLACASHEMAPLACAELEMENT);
        }

        private void AddRowShemaplacashemaplacastandard()
        {
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACASTANDARD.AddSHEMAPLACASHEMAPLACASTANDARDRow(this.rowSHEMAPLACASHEMAPLACASTANDARD);
        }

        private void AfterConfirmShemaplaca()
        {
            this.OnSHEMAPLACAUpdating(new SHEMAPLACAEventArgs(this.rowSHEMAPLACA, this.Gx_mode));
        }

        private void AfterConfirmShemaplacashemaplacadop()
        {
            this.OnSHEMAPLACASHEMAPLACADOPUpdating(new SHEMAPLACASHEMAPLACADOPEventArgs(this.rowSHEMAPLACASHEMAPLACADOP, this.Gx_mode));
        }

        private void AfterConfirmShemaplacashemaplacaelement()
        {
            this.OnSHEMAPLACASHEMAPLACAELEMENTUpdating(new SHEMAPLACASHEMAPLACAELEMENTEventArgs(this.rowSHEMAPLACASHEMAPLACAELEMENT, this.Gx_mode));
        }

        private void AfterConfirmShemaplacashemaplacastandard()
        {
            this.OnSHEMAPLACASHEMAPLACASTANDARDUpdating(new SHEMAPLACASHEMAPLACASTANDARDEventArgs(this.rowSHEMAPLACASHEMAPLACASTANDARD, this.Gx_mode));
        }

        private void CheckExtendedTableShemaplacashemaplacadop()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVDOPRINOS] AS SHEMAPLDOPNAZIVDOPRINOS FROM [DOPRINOS] WITH (NOLOCK) WHERE [IDDOPRINOS] = @SHEMAPLDOPIDDOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLDOPIDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["SHEMAPLDOPIDDOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new DOPRINOSForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DOPRINOS") }));
            }
            this.rowSHEMAPLACASHEMAPLACADOP["SHEMAPLDOPNAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            reader.Close();
        }

        private void CheckExtendedTableShemaplacashemaplacaelement()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVELEMENT] AS SHEMAPLELEMENTNAZIVELEMENT, [IDVRSTAELEMENTA] AS SHEMAPLELEMENTIDVRSTAELEMENTA FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @SHEMAPLELEMENTIDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLELEMENTIDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["SHEMAPLELEMENTIDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new ELEMENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ELEMENT") }));
            }
            this.rowSHEMAPLACASHEMAPLACAELEMENT["SHEMAPLELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowSHEMAPLACASHEMAPLACAELEMENT["SHEMAPLELEMENTIDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 1));
            reader.Close();
        }

        private void CheckExtendedTableShemaplacashemaplacastandard()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVPLVRSTEIZNOSA] FROM [PLVRSTEIZNOSA] WITH (NOLOCK) WHERE [IDPLVRSTEIZNOSA] = @IDPLVRSTEIZNOSA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLVRSTEIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["IDPLVRSTEIZNOSA"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new PLVRSTEIZNOSAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("PLVRSTEIZNOSA") }));
            }
            this.rowSHEMAPLACASHEMAPLACASTANDARD["NAZIVPLVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            reader.Close();
        }

        private void CheckIntegrityErrorsShemaplaca()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDORGJED] AS SHEMAPLOJIDORGJED FROM [ORGJED] WITH (NOLOCK) WHERE [IDORGJED] = @SHEMAPLOJIDORGJED ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLOJIDORGJED", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACA["SHEMAPLOJIDORGJED"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new ORGJEDForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ORGJED") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckIntegrityErrorsShemaplacashemaplacadop()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKONTO] AS KONTODOPIDKONTO FROM [KONTO] WITH (NOLOCK) WHERE [IDKONTO] = @KONTODOPIDKONTO ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTODOPIDKONTO", DbType.String, 14));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["KONTODOPIDKONTO"]))));
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
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["MTDOPIDMJESTOTROSKA"]));
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
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["STRANEDOPIDSTRANEKNJIZENJA"]));
            IDataReader reader3 = command3.FetchData();
            if (!command3.HasMoreRows)
            {
                reader3.Close();
                throw new STRANEKNJIZENJAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("STRANEKNJIZENJA") }));
            }
            reader3.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckIntegrityErrorsShemaplacashemaplacaelement()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKONTO] AS KONTOELEMENTIDKONTO FROM [KONTO] WITH (NOLOCK) WHERE [IDKONTO] = @KONTOELEMENTIDKONTO ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTOELEMENTIDKONTO", DbType.String, 14));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["KONTOELEMENTIDKONTO"]))));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new KONTOForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KONTO") }));
            }
            reader.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [IDSTRANEKNJIZENJA] AS STRANEELEMENTIDSTRANEKNJIZENJA FROM [STRANEKNJIZENJA] WITH (NOLOCK) WHERE [IDSTRANEKNJIZENJA] = @STRANEELEMENTIDSTRANEKNJIZENJA ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STRANEELEMENTIDSTRANEKNJIZENJA", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["STRANEELEMENTIDSTRANEKNJIZENJA"]));
            IDataReader reader3 = command3.FetchData();
            if (!command3.HasMoreRows)
            {
                reader3.Close();
                throw new STRANEKNJIZENJAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("STRANEKNJIZENJA") }));
            }
            reader3.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [IDMJESTOTROSKA] AS MTELEMENTIDMJESTOTROSKA FROM [MJESTOTROSKA] WITH (NOLOCK) WHERE [IDMJESTOTROSKA] = @MTELEMENTIDMJESTOTROSKA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MTELEMENTIDMJESTOTROSKA", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["MTELEMENTIDMJESTOTROSKA"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new MJESTOTROSKAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("MJESTOTROSKA") }));
            }
            reader2.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckIntegrityErrorsShemaplacashemaplacastandard()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKONTO] AS KONTOPLACAVRSTAIZNOSAIDKONTO FROM [KONTO] WITH (NOLOCK) WHERE [IDKONTO] = @KONTOPLACAVRSTAIZNOSAIDKONTO ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTOPLACAVRSTAIZNOSAIDKONTO", DbType.String, 14));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["KONTOPLACAVRSTAIZNOSAIDKONTO"]))));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new KONTOForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KONTO") }));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [IDMJESTOTROSKA] AS MTPLACAVRSTAIZNOSAIDMJESTOTROSKA FROM [MJESTOTROSKA] WITH (NOLOCK) WHERE [IDMJESTOTROSKA] = @MTPLACAVRSTAIZNOSAIDMJESTOTROSKA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MTPLACAVRSTAIZNOSAIDMJESTOTROSKA", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["MTPLACAVRSTAIZNOSAIDMJESTOTROSKA"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new MJESTOTROSKAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("MJESTOTROSKA") }));
            }
            reader2.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [IDSTRANEKNJIZENJA] AS STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA FROM [STRANEKNJIZENJA] WITH (NOLOCK) WHERE [IDSTRANEKNJIZENJA] = @STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"]));
            IDataReader reader3 = command3.FetchData();
            if (!command3.HasMoreRows)
            {
                reader3.Close();
                throw new STRANEKNJIZENJAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("STRANEKNJIZENJA") }));
            }
            reader3.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyShemaplaca()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSHEMAPLACA], [NAZIVSHEMAPLACA], [SHEMAPLOJIDORGJED] AS SHEMAPLOJIDORGJED FROM [SHEMAPLACA] WITH (UPDLOCK) WHERE [IDSHEMAPLACA] = @IDSHEMAPLACA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACA["IDSHEMAPLACA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new SHEMAPLACADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("SHEMAPLACA") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVSHEMAPLACAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || !this.m__SHEMAPLOJIDORGJEDOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2))))
                {
                    reader.Close();
                    throw new SHEMAPLACADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("SHEMAPLACA") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyShemaplacashemaplacadop()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSHEMAPLACA], [SHEMAPLDOPIDDOPRINOS] AS SHEMAPLDOPIDDOPRINOS, [KONTODOPIDKONTO] AS KONTODOPIDKONTO, [MTDOPIDMJESTOTROSKA] AS MTDOPIDMJESTOTROSKA, [STRANEDOPIDSTRANEKNJIZENJA] AS STRANEDOPIDSTRANEKNJIZENJA FROM [SHEMAPLACASHEMAPLACADOP] WITH (UPDLOCK) WHERE [IDSHEMAPLACA] = @IDSHEMAPLACA AND [SHEMAPLDOPIDDOPRINOS] = @SHEMAPLDOPIDDOPRINOS AND [KONTODOPIDKONTO] = @KONTODOPIDKONTO ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLDOPIDDOPRINOS", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTODOPIDKONTO", DbType.String, 14));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["IDSHEMAPLACA"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["SHEMAPLDOPIDDOPRINOS"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["KONTODOPIDKONTO"]))));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new SHEMAPLACASHEMAPLACADOPDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("SHEMAPLACASHEMAPLACADOP") }));
                }
                if ((!command.HasMoreRows || !this.m__MTDOPIDMJESTOTROSKAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3)))) || !this.m__STRANEDOPIDSTRANEKNJIZENJAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 4))))
                {
                    reader.Close();
                    throw new SHEMAPLACASHEMAPLACADOPDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("SHEMAPLACASHEMAPLACADOP") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyShemaplacashemaplacaelement()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSHEMAPLACA], [SHEMAPLELEMENTIDELEMENT] AS SHEMAPLELEMENTIDELEMENT, [KONTOELEMENTIDKONTO] AS KONTOELEMENTIDKONTO, [STRANEELEMENTIDSTRANEKNJIZENJA] AS STRANEELEMENTIDSTRANEKNJIZENJA, [MTELEMENTIDMJESTOTROSKA] AS MTELEMENTIDMJESTOTROSKA FROM [SHEMAPLACASHEMAPLACAELEMENT] WITH (UPDLOCK) WHERE [IDSHEMAPLACA] = @IDSHEMAPLACA AND [SHEMAPLELEMENTIDELEMENT] = @SHEMAPLELEMENTIDELEMENT AND [KONTOELEMENTIDKONTO] = @KONTOELEMENTIDKONTO AND [STRANEELEMENTIDSTRANEKNJIZENJA] = @STRANEELEMENTIDSTRANEKNJIZENJA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLELEMENTIDELEMENT", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTOELEMENTIDKONTO", DbType.String, 14));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STRANEELEMENTIDSTRANEKNJIZENJA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["IDSHEMAPLACA"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["SHEMAPLELEMENTIDELEMENT"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["KONTOELEMENTIDKONTO"]))));
                command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["STRANEELEMENTIDSTRANEKNJIZENJA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new SHEMAPLACASHEMAPLACAELEMENTDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("SHEMAPLACASHEMAPLACAELEMENT") }));
                }
                if (!command.HasMoreRows || !this.m__MTELEMENTIDMJESTOTROSKAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 4))))
                {
                    reader.Close();
                    throw new SHEMAPLACASHEMAPLACAELEMENTDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("SHEMAPLACASHEMAPLACAELEMENT") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyShemaplacashemaplacastandard()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSHEMAPLACA], [SHEMAPLACASTANDARDID], [IDPLVRSTEIZNOSA], [KONTOPLACAVRSTAIZNOSAIDKONTO] AS KONTOPLACAVRSTAIZNOSAIDKONTO, [MTPLACAVRSTAIZNOSAIDMJESTOTROSKA] AS MTPLACAVRSTAIZNOSAIDMJESTOTROSKA, [STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA] AS STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA FROM [SHEMAPLACASHEMAPLACASTANDARD] WITH (UPDLOCK) WHERE [IDSHEMAPLACA] = @IDSHEMAPLACA AND [SHEMAPLACASTANDARDID] = @SHEMAPLACASTANDARDID ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLACASTANDARDID", DbType.Guid));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["IDSHEMAPLACA"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["SHEMAPLACASTANDARDID"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new SHEMAPLACASHEMAPLACASTANDARDDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("SHEMAPLACASHEMAPLACASTANDARD") }));
                }
                if ((!command.HasMoreRows || !this.m__IDPLVRSTEIZNOSAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__KONTOPLACAVRSTAIZNOSAIDKONTOOriginal), RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3))))) || !this.m__MTPLACAVRSTAIZNOSAIDMJESTOTROSKAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 4)))) || !this.m__STRANEVRSTEIZNOSAIDSTRANEKNJIZENJAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 5)))))
                {
                    reader.Close();
                    throw new SHEMAPLACASHEMAPLACASTANDARDDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("SHEMAPLACASHEMAPLACASTANDARD") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowShemaplaca()
        {
            this.rowSHEMAPLACA = this.SHEMAPLACASet.SHEMAPLACA.NewSHEMAPLACARow();
        }

        private void CreateNewRowShemaplacashemaplacadop()
        {
            this.rowSHEMAPLACASHEMAPLACADOP = this.SHEMAPLACASet.SHEMAPLACASHEMAPLACADOP.NewSHEMAPLACASHEMAPLACADOPRow();
        }

        private void CreateNewRowShemaplacashemaplacaelement()
        {
            this.rowSHEMAPLACASHEMAPLACAELEMENT = this.SHEMAPLACASet.SHEMAPLACASHEMAPLACAELEMENT.NewSHEMAPLACASHEMAPLACAELEMENTRow();
        }

        private void CreateNewRowShemaplacashemaplacastandard()
        {
            this.rowSHEMAPLACASHEMAPLACASTANDARD = this.SHEMAPLACASet.SHEMAPLACASHEMAPLACASTANDARD.NewSHEMAPLACASHEMAPLACASTANDARDRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyShemaplaca();
            this.ProcessNestedLevelShemaplacashemaplacaelement();
            this.ProcessNestedLevelShemaplacashemaplacastandard();
            this.ProcessNestedLevelShemaplacashemaplacadop();
            this.AfterConfirmShemaplaca();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [SHEMAPLACA]  WHERE [IDSHEMAPLACA] = @IDSHEMAPLACA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACA["IDSHEMAPLACA"]));
            command.ExecuteStmt();
            this.OnSHEMAPLACAUpdated(new SHEMAPLACAEventArgs(this.rowSHEMAPLACA, StatementType.Delete));
            this.rowSHEMAPLACA.Delete();
            this.sMode224 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode224;
        }

        private void DeleteShemaplacashemaplacadop()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyShemaplacashemaplacadop();
            this.OnDeleteControlsShemaplacashemaplacadop();
            this.AfterConfirmShemaplacashemaplacadop();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [SHEMAPLACASHEMAPLACADOP]  WHERE [IDSHEMAPLACA] = @IDSHEMAPLACA AND [SHEMAPLDOPIDDOPRINOS] = @SHEMAPLDOPIDDOPRINOS AND [KONTODOPIDKONTO] = @KONTODOPIDKONTO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLDOPIDDOPRINOS", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTODOPIDKONTO", DbType.String, 14));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["IDSHEMAPLACA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["SHEMAPLDOPIDDOPRINOS"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["KONTODOPIDKONTO"]))));
            command.ExecuteStmt();
            this.OnSHEMAPLACASHEMAPLACADOPUpdated(new SHEMAPLACASHEMAPLACADOPEventArgs(this.rowSHEMAPLACASHEMAPLACADOP, StatementType.Delete));
            this.rowSHEMAPLACASHEMAPLACADOP.Delete();
            this.sMode230 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode230;
        }

        private void DeleteShemaplacashemaplacaelement()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyShemaplacashemaplacaelement();
            this.OnDeleteControlsShemaplacashemaplacaelement();
            this.AfterConfirmShemaplacashemaplacaelement();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [SHEMAPLACASHEMAPLACAELEMENT]  WHERE [IDSHEMAPLACA] = @IDSHEMAPLACA AND [SHEMAPLELEMENTIDELEMENT] = @SHEMAPLELEMENTIDELEMENT AND [KONTOELEMENTIDKONTO] = @KONTOELEMENTIDKONTO AND [STRANEELEMENTIDSTRANEKNJIZENJA] = @STRANEELEMENTIDSTRANEKNJIZENJA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLELEMENTIDELEMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTOELEMENTIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STRANEELEMENTIDSTRANEKNJIZENJA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["IDSHEMAPLACA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["SHEMAPLELEMENTIDELEMENT"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["KONTOELEMENTIDKONTO"]))));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["STRANEELEMENTIDSTRANEKNJIZENJA"]));
            command.ExecuteStmt();
            this.OnSHEMAPLACASHEMAPLACAELEMENTUpdated(new SHEMAPLACASHEMAPLACAELEMENTEventArgs(this.rowSHEMAPLACASHEMAPLACAELEMENT, StatementType.Delete));
            this.rowSHEMAPLACASHEMAPLACAELEMENT.Delete();
            this.sMode234 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode234;
        }

        private void DeleteShemaplacashemaplacastandard()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyShemaplacashemaplacastandard();
            this.OnDeleteControlsShemaplacashemaplacastandard();
            this.AfterConfirmShemaplacashemaplacastandard();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [SHEMAPLACASHEMAPLACASTANDARD]  WHERE [IDSHEMAPLACA] = @IDSHEMAPLACA AND [SHEMAPLACASTANDARDID] = @SHEMAPLACASTANDARDID", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLACASTANDARDID", DbType.Guid));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["IDSHEMAPLACA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["SHEMAPLACASTANDARDID"]));
            command.ExecuteStmt();
            this.OnSHEMAPLACASHEMAPLACASTANDARDUpdated(new SHEMAPLACASHEMAPLACASTANDARDEventArgs(this.rowSHEMAPLACASHEMAPLACASTANDARD, StatementType.Delete));
            this.rowSHEMAPLACASHEMAPLACASTANDARD.Delete();
            this.sMode233 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode233;
        }

        public virtual int Fill(SHEMAPLACADataSet dataSet)
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
                    this.SHEMAPLACASet = dataSet;
                    this.LoadChildShemaplaca(0, -1);
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
            this.SHEMAPLACASet = (SHEMAPLACADataSet) dataSet;
            if (this.SHEMAPLACASet != null)
            {
                return this.Fill(this.SHEMAPLACASet);
            }
            this.SHEMAPLACASet = new SHEMAPLACADataSet();
            this.Fill(this.SHEMAPLACASet);
            dataSet.Merge(this.SHEMAPLACASet);
            return 0;
        }

        public virtual int Fill(SHEMAPLACADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSHEMAPLACA"]));
        }

        public virtual int Fill(SHEMAPLACADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSHEMAPLACA"]));
        }

        public virtual int Fill(SHEMAPLACADataSet dataSet, int iDSHEMAPLACA)
        {
            if (!this.FillByIDSHEMAPLACA(dataSet, iDSHEMAPLACA))
            {
                throw new SHEMAPLACANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("SHEMAPLACA") }));
            }
            return 0;
        }

        public virtual bool FillByIDSHEMAPLACA(SHEMAPLACADataSet dataSet, int iDSHEMAPLACA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SHEMAPLACASet = dataSet;
            this.rowSHEMAPLACA = this.SHEMAPLACASet.SHEMAPLACA.NewSHEMAPLACARow();
            this.rowSHEMAPLACA.IDSHEMAPLACA = iDSHEMAPLACA;
            try
            {
                this.LoadByIDSHEMAPLACA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound224 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillBySHEMAPLOJIDORGJED(SHEMAPLACADataSet dataSet, int sHEMAPLOJIDORGJED)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SHEMAPLACASet = dataSet;
            this.rowSHEMAPLACA = this.SHEMAPLACASet.SHEMAPLACA.NewSHEMAPLACARow();
            this.rowSHEMAPLACA.SHEMAPLOJIDORGJED = sHEMAPLOJIDORGJED;
            try
            {
                this.LoadBySHEMAPLOJIDORGJED(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(SHEMAPLACADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SHEMAPLACASet = dataSet;
            try
            {
                this.LoadChildShemaplaca(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageBySHEMAPLOJIDORGJED(SHEMAPLACADataSet dataSet, int sHEMAPLOJIDORGJED, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SHEMAPLACASet = dataSet;
            this.rowSHEMAPLACA = this.SHEMAPLACASet.SHEMAPLACA.NewSHEMAPLACARow();
            this.rowSHEMAPLACA.SHEMAPLOJIDORGJED = sHEMAPLOJIDORGJED;
            try
            {
                this.LoadBySHEMAPLOJIDORGJED(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSHEMAPLACA], [NAZIVSHEMAPLACA], [SHEMAPLOJIDORGJED] AS SHEMAPLOJIDORGJED FROM [SHEMAPLACA] WITH (NOLOCK) WHERE [IDSHEMAPLACA] = @IDSHEMAPLACA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACA["IDSHEMAPLACA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound224 = 1;
                this.rowSHEMAPLACA["IDSHEMAPLACA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowSHEMAPLACA["NAZIVSHEMAPLACA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowSHEMAPLACA["SHEMAPLOJIDORGJED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2));
                this.sMode224 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode224;
            }
            else
            {
                this.RcdFound224 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDSHEMAPLACA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMAPLACASelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [SHEMAPLACA] WITH (NOLOCK) ", false);
            this.SHEMAPLACASelect2 = this.cmSHEMAPLACASelect2.FetchData();
            if (this.SHEMAPLACASelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.SHEMAPLACASelect2.GetInt32(0);
            }
            this.SHEMAPLACASelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountBySHEMAPLOJIDORGJED(int sHEMAPLOJIDORGJED)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMAPLACASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [SHEMAPLACA] WITH (NOLOCK) WHERE [SHEMAPLOJIDORGJED] = @SHEMAPLOJIDORGJED ", false);
            if (this.cmSHEMAPLACASelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAPLACASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLOJIDORGJED", DbType.Int32));
            }
            this.cmSHEMAPLACASelect1.SetParameter(0, sHEMAPLOJIDORGJED);
            this.SHEMAPLACASelect1 = this.cmSHEMAPLACASelect1.FetchData();
            if (this.SHEMAPLACASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.SHEMAPLACASelect1.GetInt32(0);
            }
            this.SHEMAPLACASelect1.Close();
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

        public virtual int GetRecordCountBySHEMAPLOJIDORGJED(int sHEMAPLOJIDORGJED)
        {
            int internalRecordCountBySHEMAPLOJIDORGJED;
            try
            {
                this.InitializeMembers();
                internalRecordCountBySHEMAPLOJIDORGJED = this.GetInternalRecordCountBySHEMAPLOJIDORGJED(sHEMAPLOJIDORGJED);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountBySHEMAPLOJIDORGJED;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound224 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__IDPLVRSTEIZNOSAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KONTOPLACAVRSTAIZNOSAIDKONTOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MTPLACAVRSTAIZNOSAIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__STRANEVRSTEIZNOSAIDSTRANEKNJIZENJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove30 = false;
            this.RcdFound233 = 0;
            this.m_SubSelTopString233 = "";
            this.m__MTELEMENTIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove23 = false;
            this.RcdFound234 = 0;
            this.m_SubSelTopString234 = "";
            this.m__MTDOPIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__STRANEDOPIDSTRANEKNJIZENJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove17 = false;
            this.RcdFound230 = 0;
            this.m_SubSelTopString230 = "";
            this.m__NAZIVSHEMAPLACAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SHEMAPLOJIDORGJEDOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.SHEMAPLACASet = new SHEMAPLACADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertShemaplaca()
        {
            this.CheckOptimisticConcurrencyShemaplaca();
            this.AfterConfirmShemaplaca();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [SHEMAPLACA] ([IDSHEMAPLACA], [NAZIVSHEMAPLACA], [SHEMAPLOJIDORGJED]) VALUES (@IDSHEMAPLACA, @NAZIVSHEMAPLACA, @SHEMAPLOJIDORGJED)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSHEMAPLACA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLOJIDORGJED", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACA["IDSHEMAPLACA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACA["NAZIVSHEMAPLACA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACA["SHEMAPLOJIDORGJED"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new SHEMAPLACADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemaplaca();
            }
            this.OnSHEMAPLACAUpdated(new SHEMAPLACAEventArgs(this.rowSHEMAPLACA, StatementType.Insert));
            this.ProcessLevelShemaplaca();
        }

        private void InsertShemaplacashemaplacadop()
        {
            this.CheckOptimisticConcurrencyShemaplacashemaplacadop();
            this.CheckExtendedTableShemaplacashemaplacadop();
            this.AfterConfirmShemaplacashemaplacadop();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [SHEMAPLACASHEMAPLACADOP] ([IDSHEMAPLACA], [SHEMAPLDOPIDDOPRINOS], [KONTODOPIDKONTO], [MTDOPIDMJESTOTROSKA], [STRANEDOPIDSTRANEKNJIZENJA]) VALUES (@IDSHEMAPLACA, @SHEMAPLDOPIDDOPRINOS, @KONTODOPIDKONTO, @MTDOPIDMJESTOTROSKA, @STRANEDOPIDSTRANEKNJIZENJA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLDOPIDDOPRINOS", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTODOPIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MTDOPIDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STRANEDOPIDSTRANEKNJIZENJA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["IDSHEMAPLACA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["SHEMAPLDOPIDDOPRINOS"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["KONTODOPIDKONTO"]))));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["MTDOPIDMJESTOTROSKA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["STRANEDOPIDSTRANEKNJIZENJA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new SHEMAPLACASHEMAPLACADOPDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemaplacashemaplacadop();
            }
            this.OnSHEMAPLACASHEMAPLACADOPUpdated(new SHEMAPLACASHEMAPLACADOPEventArgs(this.rowSHEMAPLACASHEMAPLACADOP, StatementType.Insert));
        }

        private void InsertShemaplacashemaplacaelement()
        {
            this.CheckOptimisticConcurrencyShemaplacashemaplacaelement();
            this.CheckExtendedTableShemaplacashemaplacaelement();
            this.AfterConfirmShemaplacashemaplacaelement();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [SHEMAPLACASHEMAPLACAELEMENT] ([IDSHEMAPLACA], [SHEMAPLELEMENTIDELEMENT], [KONTOELEMENTIDKONTO], [STRANEELEMENTIDSTRANEKNJIZENJA], [MTELEMENTIDMJESTOTROSKA]) VALUES (@IDSHEMAPLACA, @SHEMAPLELEMENTIDELEMENT, @KONTOELEMENTIDKONTO, @STRANEELEMENTIDSTRANEKNJIZENJA, @MTELEMENTIDMJESTOTROSKA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLELEMENTIDELEMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTOELEMENTIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STRANEELEMENTIDSTRANEKNJIZENJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MTELEMENTIDMJESTOTROSKA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["IDSHEMAPLACA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["SHEMAPLELEMENTIDELEMENT"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["KONTOELEMENTIDKONTO"]))));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["STRANEELEMENTIDSTRANEKNJIZENJA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["MTELEMENTIDMJESTOTROSKA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new SHEMAPLACASHEMAPLACAELEMENTDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemaplacashemaplacaelement();
            }
            this.OnSHEMAPLACASHEMAPLACAELEMENTUpdated(new SHEMAPLACASHEMAPLACAELEMENTEventArgs(this.rowSHEMAPLACASHEMAPLACAELEMENT, StatementType.Insert));
        }

        private void InsertShemaplacashemaplacastandard()
        {
            this.CheckOptimisticConcurrencyShemaplacashemaplacastandard();
            this.CheckExtendedTableShemaplacashemaplacastandard();
            this.AfterConfirmShemaplacashemaplacastandard();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [SHEMAPLACASHEMAPLACASTANDARD] ([IDSHEMAPLACA], [SHEMAPLACASTANDARDID], [IDPLVRSTEIZNOSA], [KONTOPLACAVRSTAIZNOSAIDKONTO], [MTPLACAVRSTAIZNOSAIDMJESTOTROSKA], [STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA]) VALUES (@IDSHEMAPLACA, @SHEMAPLACASTANDARDID, @IDPLVRSTEIZNOSA, @KONTOPLACAVRSTAIZNOSAIDKONTO, @MTPLACAVRSTAIZNOSAIDMJESTOTROSKA, @STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLACASTANDARDID", DbType.Guid));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLVRSTEIZNOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTOPLACAVRSTAIZNOSAIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MTPLACAVRSTAIZNOSAIDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["IDSHEMAPLACA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["SHEMAPLACASTANDARDID"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["IDPLVRSTEIZNOSA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["KONTOPLACAVRSTAIZNOSAIDKONTO"]))));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["MTPLACAVRSTAIZNOSAIDMJESTOTROSKA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new SHEMAPLACASHEMAPLACASTANDARDDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemaplacashemaplacastandard();
            }
            this.OnSHEMAPLACASHEMAPLACASTANDARDUpdated(new SHEMAPLACASHEMAPLACASTANDARDEventArgs(this.rowSHEMAPLACASHEMAPLACASTANDARD, StatementType.Insert));
        }

        private void LoadByIDSHEMAPLACA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.SHEMAPLACASet.EnforceConstraints;
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACASTANDARD.BeginLoadData();
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACAELEMENT.BeginLoadData();
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACADOP.BeginLoadData();
            this.SHEMAPLACASet.SHEMAPLACA.BeginLoadData();
            this.ScanByIDSHEMAPLACA(startRow, maxRows);
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACASTANDARD.EndLoadData();
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACAELEMENT.EndLoadData();
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACADOP.EndLoadData();
            this.SHEMAPLACASet.SHEMAPLACA.EndLoadData();
            this.SHEMAPLACASet.EnforceConstraints = enforceConstraints;
            if (this.SHEMAPLACASet.SHEMAPLACA.Count > 0)
            {
                this.rowSHEMAPLACA = this.SHEMAPLACASet.SHEMAPLACA[this.SHEMAPLACASet.SHEMAPLACA.Count - 1];
            }
        }

        private void LoadBySHEMAPLOJIDORGJED(int startRow, int maxRows)
        {
            bool enforceConstraints = this.SHEMAPLACASet.EnforceConstraints;
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACASTANDARD.BeginLoadData();
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACAELEMENT.BeginLoadData();
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACADOP.BeginLoadData();
            this.SHEMAPLACASet.SHEMAPLACA.BeginLoadData();
            this.ScanBySHEMAPLOJIDORGJED(startRow, maxRows);
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACASTANDARD.EndLoadData();
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACAELEMENT.EndLoadData();
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACADOP.EndLoadData();
            this.SHEMAPLACASet.SHEMAPLACA.EndLoadData();
            this.SHEMAPLACASet.EnforceConstraints = enforceConstraints;
            if (this.SHEMAPLACASet.SHEMAPLACA.Count > 0)
            {
                this.rowSHEMAPLACA = this.SHEMAPLACASet.SHEMAPLACA[this.SHEMAPLACASet.SHEMAPLACA.Count - 1];
            }
        }

        private void LoadChildShemaplaca(int startRow, int maxRows)
        {
            this.CreateNewRowShemaplaca();
            bool enforceConstraints = this.SHEMAPLACASet.EnforceConstraints;
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACASTANDARD.BeginLoadData();
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACAELEMENT.BeginLoadData();
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACADOP.BeginLoadData();
            this.SHEMAPLACASet.SHEMAPLACA.BeginLoadData();
            this.ScanStartShemaplaca(startRow, maxRows);
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACASTANDARD.EndLoadData();
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACAELEMENT.EndLoadData();
            this.SHEMAPLACASet.SHEMAPLACASHEMAPLACADOP.EndLoadData();
            this.SHEMAPLACASet.SHEMAPLACA.EndLoadData();
            this.SHEMAPLACASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildShemaplacashemaplacadop()
        {
            this.CreateNewRowShemaplacashemaplacadop();
            this.ScanStartShemaplacashemaplacadop();
        }

        private void LoadChildShemaplacashemaplacaelement()
        {
            this.CreateNewRowShemaplacashemaplacaelement();
            this.ScanStartShemaplacashemaplacaelement();
        }

        private void LoadChildShemaplacashemaplacastandard()
        {
            this.CreateNewRowShemaplacashemaplacastandard();
            this.ScanStartShemaplacashemaplacastandard();
        }

        private void LoadDataShemaplaca(int maxRows)
        {
            int num = 0;
            if (this.RcdFound224 != 0)
            {
                this.ScanLoadShemaplaca();
                while ((this.RcdFound224 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowShemaplaca();
                    this.CreateNewRowShemaplaca();
                    this.ScanNextShemaplaca();
                }
            }
            if (num > 0)
            {
                this.RcdFound224 = 1;
            }
            this.ScanEndShemaplaca();
            if (this.SHEMAPLACASet.SHEMAPLACA.Count > 0)
            {
                this.rowSHEMAPLACA = this.SHEMAPLACASet.SHEMAPLACA[this.SHEMAPLACASet.SHEMAPLACA.Count - 1];
            }
        }

        private void LoadDataShemaplacashemaplacadop()
        {
            while (this.RcdFound230 != 0)
            {
                this.LoadRowShemaplacashemaplacadop();
                this.CreateNewRowShemaplacashemaplacadop();
                this.ScanNextShemaplacashemaplacadop();
            }
            this.ScanEndShemaplacashemaplacadop();
        }

        private void LoadDataShemaplacashemaplacaelement()
        {
            while (this.RcdFound234 != 0)
            {
                this.LoadRowShemaplacashemaplacaelement();
                this.CreateNewRowShemaplacashemaplacaelement();
                this.ScanNextShemaplacashemaplacaelement();
            }
            this.ScanEndShemaplacashemaplacaelement();
        }

        private void LoadDataShemaplacashemaplacastandard()
        {
            while (this.RcdFound233 != 0)
            {
                this.LoadRowShemaplacashemaplacastandard();
                this.CreateNewRowShemaplacashemaplacastandard();
                this.ScanNextShemaplacashemaplacastandard();
            }
            this.ScanEndShemaplacashemaplacastandard();
        }

        private void LoadRowShemaplaca()
        {
            this.AddRowShemaplaca();
        }

        private void LoadRowShemaplacashemaplacadop()
        {
            this.AddRowShemaplacashemaplacadop();
        }

        private void LoadRowShemaplacashemaplacaelement()
        {
            this.AddRowShemaplacashemaplacaelement();
        }

        private void LoadRowShemaplacashemaplacastandard()
        {
            this.AddRowShemaplacashemaplacastandard();
        }

        private void OnDeleteControlsShemaplacashemaplacadop()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVDOPRINOS] AS SHEMAPLDOPNAZIVDOPRINOS FROM [DOPRINOS] WITH (NOLOCK) WHERE [IDDOPRINOS] = @SHEMAPLDOPIDDOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLDOPIDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["SHEMAPLDOPIDDOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowSHEMAPLACASHEMAPLACADOP["SHEMAPLDOPNAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void OnDeleteControlsShemaplacashemaplacaelement()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVELEMENT] AS SHEMAPLELEMENTNAZIVELEMENT, [IDVRSTAELEMENTA] AS SHEMAPLELEMENTIDVRSTAELEMENTA FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @SHEMAPLELEMENTIDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLELEMENTIDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["SHEMAPLELEMENTIDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowSHEMAPLACASHEMAPLACAELEMENT["SHEMAPLELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowSHEMAPLACASHEMAPLACAELEMENT["SHEMAPLELEMENTIDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 1));
            }
            reader.Close();
        }

        private void OnDeleteControlsShemaplacashemaplacastandard()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVPLVRSTEIZNOSA] FROM [PLVRSTEIZNOSA] WITH (NOLOCK) WHERE [IDPLVRSTEIZNOSA] = @IDPLVRSTEIZNOSA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLVRSTEIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["IDPLVRSTEIZNOSA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowSHEMAPLACASHEMAPLACASTANDARD["NAZIVPLVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void OnSHEMAPLACASHEMAPLACADOPUpdated(SHEMAPLACASHEMAPLACADOPEventArgs e)
        {
            if (this.SHEMAPLACASHEMAPLACADOPUpdated != null)
            {
                SHEMAPLACASHEMAPLACADOPUpdateEventHandler sHEMAPLACASHEMAPLACADOPUpdatedEvent = this.SHEMAPLACASHEMAPLACADOPUpdated;
                if (sHEMAPLACASHEMAPLACADOPUpdatedEvent != null)
                {
                    sHEMAPLACASHEMAPLACADOPUpdatedEvent(this, e);
                }
            }
        }

        private void OnSHEMAPLACASHEMAPLACADOPUpdating(SHEMAPLACASHEMAPLACADOPEventArgs e)
        {
            if (this.SHEMAPLACASHEMAPLACADOPUpdating != null)
            {
                SHEMAPLACASHEMAPLACADOPUpdateEventHandler sHEMAPLACASHEMAPLACADOPUpdatingEvent = this.SHEMAPLACASHEMAPLACADOPUpdating;
                if (sHEMAPLACASHEMAPLACADOPUpdatingEvent != null)
                {
                    sHEMAPLACASHEMAPLACADOPUpdatingEvent(this, e);
                }
            }
        }

        private void OnSHEMAPLACASHEMAPLACAELEMENTUpdated(SHEMAPLACASHEMAPLACAELEMENTEventArgs e)
        {
            if (this.SHEMAPLACASHEMAPLACAELEMENTUpdated != null)
            {
                SHEMAPLACASHEMAPLACAELEMENTUpdateEventHandler sHEMAPLACASHEMAPLACAELEMENTUpdatedEvent = this.SHEMAPLACASHEMAPLACAELEMENTUpdated;
                if (sHEMAPLACASHEMAPLACAELEMENTUpdatedEvent != null)
                {
                    sHEMAPLACASHEMAPLACAELEMENTUpdatedEvent(this, e);
                }
            }
        }

        private void OnSHEMAPLACASHEMAPLACAELEMENTUpdating(SHEMAPLACASHEMAPLACAELEMENTEventArgs e)
        {
            if (this.SHEMAPLACASHEMAPLACAELEMENTUpdating != null)
            {
                SHEMAPLACASHEMAPLACAELEMENTUpdateEventHandler sHEMAPLACASHEMAPLACAELEMENTUpdatingEvent = this.SHEMAPLACASHEMAPLACAELEMENTUpdating;
                if (sHEMAPLACASHEMAPLACAELEMENTUpdatingEvent != null)
                {
                    sHEMAPLACASHEMAPLACAELEMENTUpdatingEvent(this, e);
                }
            }
        }

        private void OnSHEMAPLACASHEMAPLACASTANDARDUpdated(SHEMAPLACASHEMAPLACASTANDARDEventArgs e)
        {
            if (this.SHEMAPLACASHEMAPLACASTANDARDUpdated != null)
            {
                SHEMAPLACASHEMAPLACASTANDARDUpdateEventHandler sHEMAPLACASHEMAPLACASTANDARDUpdatedEvent = this.SHEMAPLACASHEMAPLACASTANDARDUpdated;
                if (sHEMAPLACASHEMAPLACASTANDARDUpdatedEvent != null)
                {
                    sHEMAPLACASHEMAPLACASTANDARDUpdatedEvent(this, e);
                }
            }
        }

        private void OnSHEMAPLACASHEMAPLACASTANDARDUpdating(SHEMAPLACASHEMAPLACASTANDARDEventArgs e)
        {
            if (this.SHEMAPLACASHEMAPLACASTANDARDUpdating != null)
            {
                SHEMAPLACASHEMAPLACASTANDARDUpdateEventHandler sHEMAPLACASHEMAPLACASTANDARDUpdatingEvent = this.SHEMAPLACASHEMAPLACASTANDARDUpdating;
                if (sHEMAPLACASHEMAPLACASTANDARDUpdatingEvent != null)
                {
                    sHEMAPLACASHEMAPLACASTANDARDUpdatingEvent(this, e);
                }
            }
        }

        private void OnSHEMAPLACAUpdated(SHEMAPLACAEventArgs e)
        {
            if (this.SHEMAPLACAUpdated != null)
            {
                SHEMAPLACAUpdateEventHandler sHEMAPLACAUpdatedEvent = this.SHEMAPLACAUpdated;
                if (sHEMAPLACAUpdatedEvent != null)
                {
                    sHEMAPLACAUpdatedEvent(this, e);
                }
            }
        }

        private void OnSHEMAPLACAUpdating(SHEMAPLACAEventArgs e)
        {
            if (this.SHEMAPLACAUpdating != null)
            {
                SHEMAPLACAUpdateEventHandler sHEMAPLACAUpdatingEvent = this.SHEMAPLACAUpdating;
                if (sHEMAPLACAUpdatingEvent != null)
                {
                    sHEMAPLACAUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelShemaplaca()
        {
            this.sMode224 = this.Gx_mode;
            this.ProcessNestedLevelShemaplacashemaplacadop();
            this.ProcessNestedLevelShemaplacashemaplacaelement();
            this.ProcessNestedLevelShemaplacashemaplacastandard();
            this.Gx_mode = this.sMode224;
        }

        private void ProcessNestedLevelShemaplacashemaplacadop()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.SHEMAPLACASet.SHEMAPLACASHEMAPLACADOP.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowSHEMAPLACASHEMAPLACADOP = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow) current;
                    if (Helpers.IsRowChanged(this.rowSHEMAPLACASHEMAPLACADOP))
                    {
                        bool flag = false;
                        if (this.rowSHEMAPLACASHEMAPLACADOP.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowSHEMAPLACASHEMAPLACADOP.IDSHEMAPLACA == this.rowSHEMAPLACA.IDSHEMAPLACA;
                        }
                        else
                        {
                            flag = this.rowSHEMAPLACASHEMAPLACADOP["IDSHEMAPLACA", DataRowVersion.Original].Equals(this.rowSHEMAPLACA.IDSHEMAPLACA);
                        }
                        if (flag)
                        {
                            this.ReadRowShemaplacashemaplacadop();
                            if (this.rowSHEMAPLACASHEMAPLACADOP.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertShemaplacashemaplacadop();
                            }
                            else
                            {
                                if (this._Gxremove17)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteShemaplacashemaplacadop();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateShemaplacashemaplacadop();
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

        private void ProcessNestedLevelShemaplacashemaplacaelement()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.SHEMAPLACASet.SHEMAPLACASHEMAPLACAELEMENT.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowSHEMAPLACASHEMAPLACAELEMENT = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow) current;
                    if (Helpers.IsRowChanged(this.rowSHEMAPLACASHEMAPLACAELEMENT))
                    {
                        bool flag = false;
                        if (this.rowSHEMAPLACASHEMAPLACAELEMENT.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowSHEMAPLACASHEMAPLACAELEMENT.IDSHEMAPLACA == this.rowSHEMAPLACA.IDSHEMAPLACA;
                        }
                        else
                        {
                            flag = this.rowSHEMAPLACASHEMAPLACAELEMENT["IDSHEMAPLACA", DataRowVersion.Original].Equals(this.rowSHEMAPLACA.IDSHEMAPLACA);
                        }
                        if (flag)
                        {
                            this.ReadRowShemaplacashemaplacaelement();
                            if (this.rowSHEMAPLACASHEMAPLACAELEMENT.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertShemaplacashemaplacaelement();
                            }
                            else
                            {
                                if (this._Gxremove23)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteShemaplacashemaplacaelement();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateShemaplacashemaplacaelement();
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

        private void ProcessNestedLevelShemaplacashemaplacastandard()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.SHEMAPLACASet.SHEMAPLACASHEMAPLACASTANDARD.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowSHEMAPLACASHEMAPLACASTANDARD = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow) current;
                    if (Helpers.IsRowChanged(this.rowSHEMAPLACASHEMAPLACASTANDARD))
                    {
                        bool flag = false;
                        if (this.rowSHEMAPLACASHEMAPLACASTANDARD.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowSHEMAPLACASHEMAPLACASTANDARD.IDSHEMAPLACA == this.rowSHEMAPLACA.IDSHEMAPLACA;
                        }
                        else
                        {
                            flag = this.rowSHEMAPLACASHEMAPLACASTANDARD["IDSHEMAPLACA", DataRowVersion.Original].Equals(this.rowSHEMAPLACA.IDSHEMAPLACA);
                        }
                        if (flag)
                        {
                            this.ReadRowShemaplacashemaplacastandard();
                            if (this.rowSHEMAPLACASHEMAPLACASTANDARD.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertShemaplacashemaplacastandard();
                            }
                            else
                            {
                                if (this._Gxremove30)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteShemaplacashemaplacastandard();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateShemaplacashemaplacastandard();
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

        private void ReadRowShemaplaca()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSHEMAPLACA.RowState);
            if (this.rowSHEMAPLACA.RowState != DataRowState.Added)
            {
                this.m__NAZIVSHEMAPLACAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACA["NAZIVSHEMAPLACA", DataRowVersion.Original]);
                this.m__SHEMAPLOJIDORGJEDOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACA["SHEMAPLOJIDORGJED", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVSHEMAPLACAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACA["NAZIVSHEMAPLACA"]);
                this.m__SHEMAPLOJIDORGJEDOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACA["SHEMAPLOJIDORGJED"]);
            }
            this._Gxremove = this.rowSHEMAPLACA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowSHEMAPLACA = (SHEMAPLACADataSet.SHEMAPLACARow) DataSetUtil.CloneOriginalDataRow(this.rowSHEMAPLACA);
            }
        }

        private void ReadRowShemaplacashemaplacadop()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSHEMAPLACASHEMAPLACADOP.RowState);
            if (this.rowSHEMAPLACASHEMAPLACADOP.RowState != DataRowState.Added)
            {
                this.m__MTDOPIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["MTDOPIDMJESTOTROSKA", DataRowVersion.Original]);
                this.m__STRANEDOPIDSTRANEKNJIZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["STRANEDOPIDSTRANEKNJIZENJA", DataRowVersion.Original]);
            }
            else
            {
                this.m__MTDOPIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["MTDOPIDMJESTOTROSKA"]);
                this.m__STRANEDOPIDSTRANEKNJIZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["STRANEDOPIDSTRANEKNJIZENJA"]);
            }
            this._Gxremove17 = this.rowSHEMAPLACASHEMAPLACADOP.RowState == DataRowState.Deleted;
            if (this._Gxremove17)
            {
                this.rowSHEMAPLACASHEMAPLACADOP = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow) DataSetUtil.CloneOriginalDataRow(this.rowSHEMAPLACASHEMAPLACADOP);
            }
        }

        private void ReadRowShemaplacashemaplacaelement()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSHEMAPLACASHEMAPLACAELEMENT.RowState);
            if (this.rowSHEMAPLACASHEMAPLACAELEMENT.RowState != DataRowState.Added)
            {
                this.m__MTELEMENTIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["MTELEMENTIDMJESTOTROSKA", DataRowVersion.Original]);
            }
            else
            {
                this.m__MTELEMENTIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["MTELEMENTIDMJESTOTROSKA"]);
            }
            this._Gxremove23 = this.rowSHEMAPLACASHEMAPLACAELEMENT.RowState == DataRowState.Deleted;
            if (this._Gxremove23)
            {
                this.rowSHEMAPLACASHEMAPLACAELEMENT = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow) DataSetUtil.CloneOriginalDataRow(this.rowSHEMAPLACASHEMAPLACAELEMENT);
            }
        }

        private void ReadRowShemaplacashemaplacastandard()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSHEMAPLACASHEMAPLACASTANDARD.RowState);
            if (this.rowSHEMAPLACASHEMAPLACASTANDARD.RowState != DataRowState.Added)
            {
                this.m__IDPLVRSTEIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["IDPLVRSTEIZNOSA", DataRowVersion.Original]);
                this.m__KONTOPLACAVRSTAIZNOSAIDKONTOOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["KONTOPLACAVRSTAIZNOSAIDKONTO", DataRowVersion.Original]);
                this.m__MTPLACAVRSTAIZNOSAIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["MTPLACAVRSTAIZNOSAIDMJESTOTROSKA", DataRowVersion.Original]);
                this.m__STRANEVRSTEIZNOSAIDSTRANEKNJIZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA", DataRowVersion.Original]);
            }
            else
            {
                this.m__IDPLVRSTEIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["IDPLVRSTEIZNOSA"]);
                this.m__KONTOPLACAVRSTAIZNOSAIDKONTOOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["KONTOPLACAVRSTAIZNOSAIDKONTO"]);
                this.m__MTPLACAVRSTAIZNOSAIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["MTPLACAVRSTAIZNOSAIDMJESTOTROSKA"]);
                this.m__STRANEVRSTEIZNOSAIDSTRANEKNJIZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"]);
            }
            this._Gxremove30 = this.rowSHEMAPLACASHEMAPLACASTANDARD.RowState == DataRowState.Deleted;
            if (this._Gxremove30)
            {
                this.rowSHEMAPLACASHEMAPLACASTANDARD = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow) DataSetUtil.CloneOriginalDataRow(this.rowSHEMAPLACASHEMAPLACASTANDARD);
            }
        }

        private void ScanByIDSHEMAPLACA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDSHEMAPLACA] = @IDSHEMAPLACA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString224 + "  FROM [SHEMAPLACA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMAPLACA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString224, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMAPLACA] ) AS DK_PAGENUM   FROM [SHEMAPLACA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString224 + " FROM [SHEMAPLACA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMAPLACA] ";
            }
            this.cmSHEMAPLACASelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmSHEMAPLACASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAPLACASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
            }
            this.cmSHEMAPLACASelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACA["IDSHEMAPLACA"]));
            this.SHEMAPLACASelect5 = this.cmSHEMAPLACASelect5.FetchData();
            this.RcdFound224 = 0;
            this.ScanLoadShemaplaca();
            this.LoadDataShemaplaca(maxRows);
            if (this.RcdFound224 > 0)
            {
                this.SubLvlScanStartShemaplacashemaplacadop(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSHEMAPLACAShemaplaca(this.cmSHEMAPLACASHEMAPLACADOPSelect2);
                this.SubLvlFetchShemaplacashemaplacadop();
                this.SubLoadDataShemaplacashemaplacadop();
                this.SubLvlScanStartShemaplacashemaplacaelement(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSHEMAPLACAShemaplaca(this.cmSHEMAPLACASHEMAPLACAELEMENTSelect2);
                this.SubLvlFetchShemaplacashemaplacaelement();
                this.SubLoadDataShemaplacashemaplacaelement();
                this.SubLvlScanStartShemaplacashemaplacastandard(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSHEMAPLACAShemaplaca(this.cmSHEMAPLACASHEMAPLACASTANDARDSelect2);
                this.SubLvlFetchShemaplacashemaplacastandard();
                this.SubLoadDataShemaplacashemaplacastandard();
            }
        }

        private void ScanBySHEMAPLOJIDORGJED(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[SHEMAPLOJIDORGJED] = @SHEMAPLOJIDORGJED";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString224 + "  FROM [SHEMAPLACA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMAPLACA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString224, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMAPLACA] ) AS DK_PAGENUM   FROM [SHEMAPLACA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString224 + " FROM [SHEMAPLACA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMAPLACA] ";
            }
            this.cmSHEMAPLACASelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmSHEMAPLACASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAPLACASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLOJIDORGJED", DbType.Int32));
            }
            this.cmSHEMAPLACASelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACA["SHEMAPLOJIDORGJED"]));
            this.SHEMAPLACASelect5 = this.cmSHEMAPLACASelect5.FetchData();
            this.RcdFound224 = 0;
            this.ScanLoadShemaplaca();
            this.LoadDataShemaplaca(maxRows);
            if (this.RcdFound224 > 0)
            {
                this.SubLvlScanStartShemaplacashemaplacadop(this.m_WhereString, startRow, maxRows);
                this.SetParametersSHEMAPLOJIDORGJEDShemaplaca(this.cmSHEMAPLACASHEMAPLACADOPSelect2);
                this.SubLvlFetchShemaplacashemaplacadop();
                this.SubLoadDataShemaplacashemaplacadop();
                this.SubLvlScanStartShemaplacashemaplacaelement(this.m_WhereString, startRow, maxRows);
                this.SetParametersSHEMAPLOJIDORGJEDShemaplaca(this.cmSHEMAPLACASHEMAPLACAELEMENTSelect2);
                this.SubLvlFetchShemaplacashemaplacaelement();
                this.SubLoadDataShemaplacashemaplacaelement();
                this.SubLvlScanStartShemaplacashemaplacastandard(this.m_WhereString, startRow, maxRows);
                this.SetParametersSHEMAPLOJIDORGJEDShemaplaca(this.cmSHEMAPLACASHEMAPLACASTANDARDSelect2);
                this.SubLvlFetchShemaplacashemaplacastandard();
                this.SubLoadDataShemaplacashemaplacastandard();
            }
        }

        private void ScanEndShemaplaca()
        {
            this.SHEMAPLACASelect5.Close();
        }

        private void ScanEndShemaplacashemaplacadop()
        {
            this.SHEMAPLACASHEMAPLACADOPSelect2.Close();
        }

        private void ScanEndShemaplacashemaplacaelement()
        {
            this.SHEMAPLACASHEMAPLACAELEMENTSelect2.Close();
        }

        private void ScanEndShemaplacashemaplacastandard()
        {
            this.SHEMAPLACASHEMAPLACASTANDARDSelect2.Close();
        }

        private void ScanLoadShemaplaca()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSHEMAPLACASelect5.HasMoreRows)
            {
                this.RcdFound224 = 1;
                this.rowSHEMAPLACA["IDSHEMAPLACA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAPLACASelect5, 0));
                this.rowSHEMAPLACA["NAZIVSHEMAPLACA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMAPLACASelect5, 1));
                this.rowSHEMAPLACA["SHEMAPLOJIDORGJED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAPLACASelect5, 2));
            }
        }

        private void ScanLoadShemaplacashemaplacadop()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSHEMAPLACASHEMAPLACADOPSelect2.HasMoreRows)
            {
                this.RcdFound230 = 1;
                this.rowSHEMAPLACASHEMAPLACADOP["IDSHEMAPLACA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAPLACASHEMAPLACADOPSelect2, 0));
                this.rowSHEMAPLACASHEMAPLACADOP["SHEMAPLDOPNAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMAPLACASHEMAPLACADOPSelect2, 1));
                this.rowSHEMAPLACASHEMAPLACADOP["SHEMAPLDOPIDDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAPLACASHEMAPLACADOPSelect2, 2));
                this.rowSHEMAPLACASHEMAPLACADOP["KONTODOPIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMAPLACASHEMAPLACADOPSelect2, 3))));
                this.rowSHEMAPLACASHEMAPLACADOP["MTDOPIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAPLACASHEMAPLACADOPSelect2, 4));
                this.rowSHEMAPLACASHEMAPLACADOP["STRANEDOPIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAPLACASHEMAPLACADOPSelect2, 5));
                this.rowSHEMAPLACASHEMAPLACADOP["SHEMAPLDOPNAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMAPLACASHEMAPLACADOPSelect2, 1));
            }
        }

        private void ScanLoadShemaplacashemaplacaelement()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSHEMAPLACASHEMAPLACAELEMENTSelect2.HasMoreRows)
            {
                this.RcdFound234 = 1;
                this.rowSHEMAPLACASHEMAPLACAELEMENT["IDSHEMAPLACA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAPLACASHEMAPLACAELEMENTSelect2, 0));
                this.rowSHEMAPLACASHEMAPLACAELEMENT["SHEMAPLELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMAPLACASHEMAPLACAELEMENTSelect2, 1));
                this.rowSHEMAPLACASHEMAPLACAELEMENT["SHEMAPLELEMENTIDELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAPLACASHEMAPLACAELEMENTSelect2, 2));
                this.rowSHEMAPLACASHEMAPLACAELEMENT["SHEMAPLELEMENTIDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.SHEMAPLACASHEMAPLACAELEMENTSelect2, 3));
                this.rowSHEMAPLACASHEMAPLACAELEMENT["KONTOELEMENTIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMAPLACASHEMAPLACAELEMENTSelect2, 4))));
                this.rowSHEMAPLACASHEMAPLACAELEMENT["STRANEELEMENTIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAPLACASHEMAPLACAELEMENTSelect2, 5));
                this.rowSHEMAPLACASHEMAPLACAELEMENT["MTELEMENTIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAPLACASHEMAPLACAELEMENTSelect2, 6));
                this.rowSHEMAPLACASHEMAPLACAELEMENT["SHEMAPLELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMAPLACASHEMAPLACAELEMENTSelect2, 1));
                this.rowSHEMAPLACASHEMAPLACAELEMENT["SHEMAPLELEMENTIDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.SHEMAPLACASHEMAPLACAELEMENTSelect2, 3));
            }
        }

        private void ScanLoadShemaplacashemaplacastandard()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSHEMAPLACASHEMAPLACASTANDARDSelect2.HasMoreRows)
            {
                this.RcdFound233 = 1;
                this.rowSHEMAPLACASHEMAPLACASTANDARD["IDSHEMAPLACA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAPLACASHEMAPLACASTANDARDSelect2, 0));
                this.rowSHEMAPLACASHEMAPLACASTANDARD["SHEMAPLACASTANDARDID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetGuid(this.SHEMAPLACASHEMAPLACASTANDARDSelect2, 1));
                this.rowSHEMAPLACASHEMAPLACASTANDARD["NAZIVPLVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMAPLACASHEMAPLACASTANDARDSelect2, 2));
                this.rowSHEMAPLACASHEMAPLACASTANDARD["IDPLVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAPLACASHEMAPLACASTANDARDSelect2, 3));
                this.rowSHEMAPLACASHEMAPLACASTANDARD["KONTOPLACAVRSTAIZNOSAIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMAPLACASHEMAPLACASTANDARDSelect2, 4))));
                this.rowSHEMAPLACASHEMAPLACASTANDARD["MTPLACAVRSTAIZNOSAIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAPLACASHEMAPLACASTANDARDSelect2, 5));
                this.rowSHEMAPLACASHEMAPLACASTANDARD["STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAPLACASHEMAPLACASTANDARDSelect2, 6));
                this.rowSHEMAPLACASHEMAPLACASTANDARD["NAZIVPLVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMAPLACASHEMAPLACASTANDARDSelect2, 2));
            }
        }

        private void ScanNextShemaplaca()
        {
            this.cmSHEMAPLACASelect5.HasMoreRows = this.SHEMAPLACASelect5.Read();
            this.RcdFound224 = 0;
            this.ScanLoadShemaplaca();
        }

        private void ScanNextShemaplacashemaplacadop()
        {
            this.cmSHEMAPLACASHEMAPLACADOPSelect2.HasMoreRows = this.SHEMAPLACASHEMAPLACADOPSelect2.Read();
            this.RcdFound230 = 0;
            this.ScanLoadShemaplacashemaplacadop();
        }

        private void ScanNextShemaplacashemaplacaelement()
        {
            this.cmSHEMAPLACASHEMAPLACAELEMENTSelect2.HasMoreRows = this.SHEMAPLACASHEMAPLACAELEMENTSelect2.Read();
            this.RcdFound234 = 0;
            this.ScanLoadShemaplacashemaplacaelement();
        }

        private void ScanNextShemaplacashemaplacastandard()
        {
            this.cmSHEMAPLACASHEMAPLACASTANDARDSelect2.HasMoreRows = this.SHEMAPLACASHEMAPLACASTANDARDSelect2.Read();
            this.RcdFound233 = 0;
            this.ScanLoadShemaplacashemaplacastandard();
        }

        private void ScanStartShemaplaca(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString224 + "  FROM [SHEMAPLACA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMAPLACA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString224, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMAPLACA] ) AS DK_PAGENUM   FROM [SHEMAPLACA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString224 + " FROM [SHEMAPLACA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMAPLACA] ";
            }
            this.cmSHEMAPLACASelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.SHEMAPLACASelect5 = this.cmSHEMAPLACASelect5.FetchData();
            this.RcdFound224 = 0;
            this.ScanLoadShemaplaca();
            this.LoadDataShemaplaca(maxRows);
            if (this.RcdFound224 > 0)
            {
                this.SubLvlScanStartShemaplacashemaplacadop(this.m_WhereString, startRow, maxRows);
                this.SetParametersShemaplacaShemaplaca(this.cmSHEMAPLACASHEMAPLACADOPSelect2);
                this.SubLvlFetchShemaplacashemaplacadop();
                this.SubLoadDataShemaplacashemaplacadop();
                this.SubLvlScanStartShemaplacashemaplacaelement(this.m_WhereString, startRow, maxRows);
                this.SetParametersShemaplacaShemaplaca(this.cmSHEMAPLACASHEMAPLACAELEMENTSelect2);
                this.SubLvlFetchShemaplacashemaplacaelement();
                this.SubLoadDataShemaplacashemaplacaelement();
                this.SubLvlScanStartShemaplacashemaplacastandard(this.m_WhereString, startRow, maxRows);
                this.SetParametersShemaplacaShemaplaca(this.cmSHEMAPLACASHEMAPLACASTANDARDSelect2);
                this.SubLvlFetchShemaplacashemaplacastandard();
                this.SubLoadDataShemaplacashemaplacastandard();
            }
        }

        private void ScanStartShemaplacashemaplacadop()
        {
            this.cmSHEMAPLACASHEMAPLACADOPSelect2 = this.connDefault.GetCommand("SELECT T1.[IDSHEMAPLACA], T2.[NAZIVDOPRINOS] AS SHEMAPLDOPNAZIVDOPRINOS, T1.[SHEMAPLDOPIDDOPRINOS] AS SHEMAPLDOPIDDOPRINOS, T1.[KONTODOPIDKONTO] AS KONTODOPIDKONTO, T1.[MTDOPIDMJESTOTROSKA] AS MTDOPIDMJESTOTROSKA, T1.[STRANEDOPIDSTRANEKNJIZENJA] AS STRANEDOPIDSTRANEKNJIZENJA FROM ([SHEMAPLACASHEMAPLACADOP] T1 WITH (NOLOCK) INNER JOIN [DOPRINOS] T2 WITH (NOLOCK) ON T2.[IDDOPRINOS] = T1.[SHEMAPLDOPIDDOPRINOS]) WHERE T1.[IDSHEMAPLACA] = @IDSHEMAPLACA ORDER BY T1.[IDSHEMAPLACA], T1.[SHEMAPLDOPIDDOPRINOS], T1.[KONTODOPIDKONTO] ", false);
            if (this.cmSHEMAPLACASHEMAPLACADOPSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAPLACASHEMAPLACADOPSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
            }
            this.cmSHEMAPLACASHEMAPLACADOPSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["IDSHEMAPLACA"]));
            this.SHEMAPLACASHEMAPLACADOPSelect2 = this.cmSHEMAPLACASHEMAPLACADOPSelect2.FetchData();
            this.RcdFound230 = 0;
            this.ScanLoadShemaplacashemaplacadop();
        }

        private void ScanStartShemaplacashemaplacaelement()
        {
            this.cmSHEMAPLACASHEMAPLACAELEMENTSelect2 = this.connDefault.GetCommand("SELECT T1.[IDSHEMAPLACA], T2.[NAZIVELEMENT] AS SHEMAPLELEMENTNAZIVELEMENT, T1.[SHEMAPLELEMENTIDELEMENT] AS SHEMAPLELEMENTIDELEMENT, T2.[IDVRSTAELEMENTA] AS SHEMAPLELEMENTIDVRSTAELEMENTA, T1.[KONTOELEMENTIDKONTO] AS KONTOELEMENTIDKONTO, T1.[STRANEELEMENTIDSTRANEKNJIZENJA] AS STRANEELEMENTIDSTRANEKNJIZENJA, T1.[MTELEMENTIDMJESTOTROSKA] AS MTELEMENTIDMJESTOTROSKA FROM ([SHEMAPLACASHEMAPLACAELEMENT] T1 WITH (NOLOCK) INNER JOIN [ELEMENT] T2 WITH (NOLOCK) ON T2.[IDELEMENT] = T1.[SHEMAPLELEMENTIDELEMENT]) WHERE T1.[IDSHEMAPLACA] = @IDSHEMAPLACA ORDER BY T1.[IDSHEMAPLACA], T1.[SHEMAPLELEMENTIDELEMENT], T1.[KONTOELEMENTIDKONTO], T1.[STRANEELEMENTIDSTRANEKNJIZENJA] ", false);
            if (this.cmSHEMAPLACASHEMAPLACAELEMENTSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAPLACASHEMAPLACAELEMENTSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
            }
            this.cmSHEMAPLACASHEMAPLACAELEMENTSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["IDSHEMAPLACA"]));
            this.SHEMAPLACASHEMAPLACAELEMENTSelect2 = this.cmSHEMAPLACASHEMAPLACAELEMENTSelect2.FetchData();
            this.RcdFound234 = 0;
            this.ScanLoadShemaplacashemaplacaelement();
        }

        private void ScanStartShemaplacashemaplacastandard()
        {
            this.cmSHEMAPLACASHEMAPLACASTANDARDSelect2 = this.connDefault.GetCommand("SELECT T1.[IDSHEMAPLACA], T1.[SHEMAPLACASTANDARDID], T2.[NAZIVPLVRSTEIZNOSA], T1.[IDPLVRSTEIZNOSA], T1.[KONTOPLACAVRSTAIZNOSAIDKONTO] AS KONTOPLACAVRSTAIZNOSAIDKONTO, T1.[MTPLACAVRSTAIZNOSAIDMJESTOTROSKA] AS MTPLACAVRSTAIZNOSAIDMJESTOTROSKA, T1.[STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA] AS STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA FROM ([SHEMAPLACASHEMAPLACASTANDARD] T1 WITH (NOLOCK) INNER JOIN [PLVRSTEIZNOSA] T2 WITH (NOLOCK) ON T2.[IDPLVRSTEIZNOSA] = T1.[IDPLVRSTEIZNOSA]) WHERE T1.[IDSHEMAPLACA] = @IDSHEMAPLACA ORDER BY T1.[IDSHEMAPLACA], T1.[SHEMAPLACASTANDARDID] ", false);
            if (this.cmSHEMAPLACASHEMAPLACASTANDARDSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAPLACASHEMAPLACASTANDARDSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
            }
            this.cmSHEMAPLACASHEMAPLACASTANDARDSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["IDSHEMAPLACA"]));
            this.SHEMAPLACASHEMAPLACASTANDARDSelect2 = this.cmSHEMAPLACASHEMAPLACASTANDARDSelect2.FetchData();
            this.RcdFound233 = 0;
            this.ScanLoadShemaplacashemaplacastandard();
        }

        private void SetParametersIDSHEMAPLACAShemaplaca(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACA["IDSHEMAPLACA"]));
        }

        private void SetParametersShemaplacaShemaplaca(ReadWriteCommand m_Command)
        {
        }

        private void SetParametersSHEMAPLOJIDORGJEDShemaplaca(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLOJIDORGJED", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACA["SHEMAPLOJIDORGJED"]));
        }

        private void SkipNextShemaplacashemaplacadop()
        {
            this.cmSHEMAPLACASHEMAPLACADOPSelect2.HasMoreRows = this.SHEMAPLACASHEMAPLACADOPSelect2.Read();
            this.RcdFound230 = 0;
            if (this.cmSHEMAPLACASHEMAPLACADOPSelect2.HasMoreRows)
            {
                this.RcdFound230 = 1;
            }
        }

        private void SkipNextShemaplacashemaplacaelement()
        {
            this.cmSHEMAPLACASHEMAPLACAELEMENTSelect2.HasMoreRows = this.SHEMAPLACASHEMAPLACAELEMENTSelect2.Read();
            this.RcdFound234 = 0;
            if (this.cmSHEMAPLACASHEMAPLACAELEMENTSelect2.HasMoreRows)
            {
                this.RcdFound234 = 1;
            }
        }

        private void SkipNextShemaplacashemaplacastandard()
        {
            this.cmSHEMAPLACASHEMAPLACASTANDARDSelect2.HasMoreRows = this.SHEMAPLACASHEMAPLACASTANDARDSelect2.Read();
            this.RcdFound233 = 0;
            if (this.cmSHEMAPLACASHEMAPLACASTANDARDSelect2.HasMoreRows)
            {
                this.RcdFound233 = 1;
            }
        }

        private void SubLoadDataShemaplacashemaplacadop()
        {
            while (this.RcdFound230 != 0)
            {
                this.LoadRowShemaplacashemaplacadop();
                this.CreateNewRowShemaplacashemaplacadop();
                this.ScanNextShemaplacashemaplacadop();
            }
            this.ScanEndShemaplacashemaplacadop();
        }

        private void SubLoadDataShemaplacashemaplacaelement()
        {
            while (this.RcdFound234 != 0)
            {
                this.LoadRowShemaplacashemaplacaelement();
                this.CreateNewRowShemaplacashemaplacaelement();
                this.ScanNextShemaplacashemaplacaelement();
            }
            this.ScanEndShemaplacashemaplacaelement();
        }

        private void SubLoadDataShemaplacashemaplacastandard()
        {
            while (this.RcdFound233 != 0)
            {
                this.LoadRowShemaplacashemaplacastandard();
                this.CreateNewRowShemaplacashemaplacastandard();
                this.ScanNextShemaplacashemaplacastandard();
            }
            this.ScanEndShemaplacashemaplacastandard();
        }

        private void SubLvlFetchShemaplacashemaplacadop()
        {
            this.CreateNewRowShemaplacashemaplacadop();
            this.SHEMAPLACASHEMAPLACADOPSelect2 = this.cmSHEMAPLACASHEMAPLACADOPSelect2.FetchData();
            this.RcdFound230 = 0;
            this.ScanLoadShemaplacashemaplacadop();
        }

        private void SubLvlFetchShemaplacashemaplacaelement()
        {
            this.CreateNewRowShemaplacashemaplacaelement();
            this.SHEMAPLACASHEMAPLACAELEMENTSelect2 = this.cmSHEMAPLACASHEMAPLACAELEMENTSelect2.FetchData();
            this.RcdFound234 = 0;
            this.ScanLoadShemaplacashemaplacaelement();
        }

        private void SubLvlFetchShemaplacashemaplacastandard()
        {
            this.CreateNewRowShemaplacashemaplacastandard();
            this.SHEMAPLACASHEMAPLACASTANDARDSelect2 = this.cmSHEMAPLACASHEMAPLACASTANDARDSelect2.FetchData();
            this.RcdFound233 = 0;
            this.ScanLoadShemaplacashemaplacastandard();
        }

        private void SubLvlScanStartShemaplacashemaplacadop(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString230 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDSHEMAPLACA]  FROM [SHEMAPLACA]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDSHEMAPLACA] )";
                    this.scmdbuf = "SELECT T1.[IDSHEMAPLACA], T3.[NAZIVDOPRINOS] AS SHEMAPLDOPNAZIVDOPRINOS, T1.[SHEMAPLDOPIDDOPRINOS] AS SHEMAPLDOPIDDOPRINOS, T1.[KONTODOPIDKONTO] AS KONTODOPIDKONTO, T1.[MTDOPIDMJESTOTROSKA] AS MTDOPIDMJESTOTROSKA, T1.[STRANEDOPIDSTRANEKNJIZENJA] AS STRANEDOPIDSTRANEKNJIZENJA FROM (([SHEMAPLACASHEMAPLACADOP] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString230 + "  TMX ON TMX.[IDSHEMAPLACA] = T1.[IDSHEMAPLACA]) INNER JOIN [DOPRINOS] T3 WITH (NOLOCK) ON T3.[IDDOPRINOS] = T1.[SHEMAPLDOPIDDOPRINOS]) ORDER BY T1.[IDSHEMAPLACA], T1.[SHEMAPLDOPIDDOPRINOS], T1.[KONTODOPIDKONTO]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDSHEMAPLACA], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMAPLACA]  ) AS DK_PAGENUM   FROM [SHEMAPLACA]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString230 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDSHEMAPLACA], T3.[NAZIVDOPRINOS] AS SHEMAPLDOPNAZIVDOPRINOS, T1.[SHEMAPLDOPIDDOPRINOS] AS SHEMAPLDOPIDDOPRINOS, T1.[KONTODOPIDKONTO] AS KONTODOPIDKONTO, T1.[MTDOPIDMJESTOTROSKA] AS MTDOPIDMJESTOTROSKA, T1.[STRANEDOPIDSTRANEKNJIZENJA] AS STRANEDOPIDSTRANEKNJIZENJA FROM (([SHEMAPLACASHEMAPLACADOP] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString230 + "  TMX ON TMX.[IDSHEMAPLACA] = T1.[IDSHEMAPLACA]) INNER JOIN [DOPRINOS] T3 WITH (NOLOCK) ON T3.[IDDOPRINOS] = T1.[SHEMAPLDOPIDDOPRINOS]) ORDER BY T1.[IDSHEMAPLACA], T1.[SHEMAPLDOPIDDOPRINOS], T1.[KONTODOPIDKONTO]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString230 = "[SHEMAPLACA]";
                this.scmdbuf = "SELECT T1.[IDSHEMAPLACA], T3.[NAZIVDOPRINOS] AS SHEMAPLDOPNAZIVDOPRINOS, T1.[SHEMAPLDOPIDDOPRINOS] AS SHEMAPLDOPIDDOPRINOS, T1.[KONTODOPIDKONTO] AS KONTODOPIDKONTO, T1.[MTDOPIDMJESTOTROSKA] AS MTDOPIDMJESTOTROSKA, T1.[STRANEDOPIDSTRANEKNJIZENJA] AS STRANEDOPIDSTRANEKNJIZENJA FROM (([SHEMAPLACASHEMAPLACADOP] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString230 + "  TM1 WITH (NOLOCK) ON TM1.[IDSHEMAPLACA] = T1.[IDSHEMAPLACA]) INNER JOIN [DOPRINOS] T3 WITH (NOLOCK) ON T3.[IDDOPRINOS] = T1.[SHEMAPLDOPIDDOPRINOS])" + this.m_WhereString + " ORDER BY T1.[IDSHEMAPLACA], T1.[SHEMAPLDOPIDDOPRINOS], T1.[KONTODOPIDKONTO] ";
            }
            this.cmSHEMAPLACASHEMAPLACADOPSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartShemaplacashemaplacaelement(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString234 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDSHEMAPLACA]  FROM [SHEMAPLACA]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDSHEMAPLACA] )";
                    this.scmdbuf = "SELECT T1.[IDSHEMAPLACA], T3.[NAZIVELEMENT] AS SHEMAPLELEMENTNAZIVELEMENT, T1.[SHEMAPLELEMENTIDELEMENT] AS SHEMAPLELEMENTIDELEMENT, T3.[IDVRSTAELEMENTA] AS SHEMAPLELEMENTIDVRSTAELEMENTA, T1.[KONTOELEMENTIDKONTO] AS KONTOELEMENTIDKONTO, T1.[STRANEELEMENTIDSTRANEKNJIZENJA] AS STRANEELEMENTIDSTRANEKNJIZENJA, T1.[MTELEMENTIDMJESTOTROSKA] AS MTELEMENTIDMJESTOTROSKA FROM (([SHEMAPLACASHEMAPLACAELEMENT] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString234 + "  TMX ON TMX.[IDSHEMAPLACA] = T1.[IDSHEMAPLACA]) INNER JOIN [ELEMENT] T3 WITH (NOLOCK) ON T3.[IDELEMENT] = T1.[SHEMAPLELEMENTIDELEMENT]) ORDER BY T1.[IDSHEMAPLACA], T1.[SHEMAPLELEMENTIDELEMENT], T1.[KONTOELEMENTIDKONTO], T1.[STRANEELEMENTIDSTRANEKNJIZENJA]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDSHEMAPLACA], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMAPLACA]  ) AS DK_PAGENUM   FROM [SHEMAPLACA]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString234 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDSHEMAPLACA], T3.[NAZIVELEMENT] AS SHEMAPLELEMENTNAZIVELEMENT, T1.[SHEMAPLELEMENTIDELEMENT] AS SHEMAPLELEMENTIDELEMENT, T3.[IDVRSTAELEMENTA] AS SHEMAPLELEMENTIDVRSTAELEMENTA, T1.[KONTOELEMENTIDKONTO] AS KONTOELEMENTIDKONTO, T1.[STRANEELEMENTIDSTRANEKNJIZENJA] AS STRANEELEMENTIDSTRANEKNJIZENJA, T1.[MTELEMENTIDMJESTOTROSKA] AS MTELEMENTIDMJESTOTROSKA FROM (([SHEMAPLACASHEMAPLACAELEMENT] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString234 + "  TMX ON TMX.[IDSHEMAPLACA] = T1.[IDSHEMAPLACA]) INNER JOIN [ELEMENT] T3 WITH (NOLOCK) ON T3.[IDELEMENT] = T1.[SHEMAPLELEMENTIDELEMENT]) ORDER BY T1.[IDSHEMAPLACA], T1.[SHEMAPLELEMENTIDELEMENT], T1.[KONTOELEMENTIDKONTO], T1.[STRANEELEMENTIDSTRANEKNJIZENJA]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString234 = "[SHEMAPLACA]";
                this.scmdbuf = "SELECT T1.[IDSHEMAPLACA], T3.[NAZIVELEMENT] AS SHEMAPLELEMENTNAZIVELEMENT, T1.[SHEMAPLELEMENTIDELEMENT] AS SHEMAPLELEMENTIDELEMENT, T3.[IDVRSTAELEMENTA] AS SHEMAPLELEMENTIDVRSTAELEMENTA, T1.[KONTOELEMENTIDKONTO] AS KONTOELEMENTIDKONTO, T1.[STRANEELEMENTIDSTRANEKNJIZENJA] AS STRANEELEMENTIDSTRANEKNJIZENJA, T1.[MTELEMENTIDMJESTOTROSKA] AS MTELEMENTIDMJESTOTROSKA FROM (([SHEMAPLACASHEMAPLACAELEMENT] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString234 + "  TM1 WITH (NOLOCK) ON TM1.[IDSHEMAPLACA] = T1.[IDSHEMAPLACA]) INNER JOIN [ELEMENT] T3 WITH (NOLOCK) ON T3.[IDELEMENT] = T1.[SHEMAPLELEMENTIDELEMENT])" + this.m_WhereString + " ORDER BY T1.[IDSHEMAPLACA], T1.[SHEMAPLELEMENTIDELEMENT], T1.[KONTOELEMENTIDKONTO], T1.[STRANEELEMENTIDSTRANEKNJIZENJA] ";
            }
            this.cmSHEMAPLACASHEMAPLACAELEMENTSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartShemaplacashemaplacastandard(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString233 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDSHEMAPLACA]  FROM [SHEMAPLACA]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDSHEMAPLACA] )";
                    this.scmdbuf = "SELECT T1.[IDSHEMAPLACA], T1.[SHEMAPLACASTANDARDID], T3.[NAZIVPLVRSTEIZNOSA], T1.[IDPLVRSTEIZNOSA], T1.[KONTOPLACAVRSTAIZNOSAIDKONTO] AS KONTOPLACAVRSTAIZNOSAIDKONTO, T1.[MTPLACAVRSTAIZNOSAIDMJESTOTROSKA] AS MTPLACAVRSTAIZNOSAIDMJESTOTROSKA, T1.[STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA] AS STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA FROM (([SHEMAPLACASHEMAPLACASTANDARD] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString233 + "  TMX ON TMX.[IDSHEMAPLACA] = T1.[IDSHEMAPLACA]) INNER JOIN [PLVRSTEIZNOSA] T3 WITH (NOLOCK) ON T3.[IDPLVRSTEIZNOSA] = T1.[IDPLVRSTEIZNOSA]) ORDER BY T1.[IDSHEMAPLACA], T1.[SHEMAPLACASTANDARDID]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDSHEMAPLACA], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMAPLACA]  ) AS DK_PAGENUM   FROM [SHEMAPLACA]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString233 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDSHEMAPLACA], T1.[SHEMAPLACASTANDARDID], T3.[NAZIVPLVRSTEIZNOSA], T1.[IDPLVRSTEIZNOSA], T1.[KONTOPLACAVRSTAIZNOSAIDKONTO] AS KONTOPLACAVRSTAIZNOSAIDKONTO, T1.[MTPLACAVRSTAIZNOSAIDMJESTOTROSKA] AS MTPLACAVRSTAIZNOSAIDMJESTOTROSKA, T1.[STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA] AS STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA FROM (([SHEMAPLACASHEMAPLACASTANDARD] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString233 + "  TMX ON TMX.[IDSHEMAPLACA] = T1.[IDSHEMAPLACA]) INNER JOIN [PLVRSTEIZNOSA] T3 WITH (NOLOCK) ON T3.[IDPLVRSTEIZNOSA] = T1.[IDPLVRSTEIZNOSA]) ORDER BY T1.[IDSHEMAPLACA], T1.[SHEMAPLACASTANDARDID]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString233 = "[SHEMAPLACA]";
                this.scmdbuf = "SELECT T1.[IDSHEMAPLACA], T1.[SHEMAPLACASTANDARDID], T3.[NAZIVPLVRSTEIZNOSA], T1.[IDPLVRSTEIZNOSA], T1.[KONTOPLACAVRSTAIZNOSAIDKONTO] AS KONTOPLACAVRSTAIZNOSAIDKONTO, T1.[MTPLACAVRSTAIZNOSAIDMJESTOTROSKA] AS MTPLACAVRSTAIZNOSAIDMJESTOTROSKA, T1.[STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA] AS STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA FROM (([SHEMAPLACASHEMAPLACASTANDARD] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString233 + "  TM1 WITH (NOLOCK) ON TM1.[IDSHEMAPLACA] = T1.[IDSHEMAPLACA]) INNER JOIN [PLVRSTEIZNOSA] T3 WITH (NOLOCK) ON T3.[IDPLVRSTEIZNOSA] = T1.[IDPLVRSTEIZNOSA])" + this.m_WhereString + " ORDER BY T1.[IDSHEMAPLACA], T1.[SHEMAPLACASTANDARDID] ";
            }
            this.cmSHEMAPLACASHEMAPLACASTANDARDSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.SHEMAPLACASet = (SHEMAPLACADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.SHEMAPLACASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.SHEMAPLACASet.SHEMAPLACA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        SHEMAPLACADataSet.SHEMAPLACARow current = (SHEMAPLACADataSet.SHEMAPLACARow) enumerator.Current;
                        this.rowSHEMAPLACA = current;
                        if (Helpers.IsRowChanged(this.rowSHEMAPLACA))
                        {
                            this.ReadRowShemaplaca();
                            if (this.rowSHEMAPLACA.RowState == DataRowState.Added)
                            {
                                this.InsertShemaplaca();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateShemaplaca();
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

        private void UpdateShemaplaca()
        {
            this.CheckOptimisticConcurrencyShemaplaca();
            this.AfterConfirmShemaplaca();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [SHEMAPLACA] SET [NAZIVSHEMAPLACA]=@NAZIVSHEMAPLACA, [SHEMAPLOJIDORGJED]=@SHEMAPLOJIDORGJED  WHERE [IDSHEMAPLACA] = @IDSHEMAPLACA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSHEMAPLACA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLOJIDORGJED", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACA["NAZIVSHEMAPLACA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACA["SHEMAPLOJIDORGJED"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACA["IDSHEMAPLACA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemaplaca();
            }
            this.OnSHEMAPLACAUpdated(new SHEMAPLACAEventArgs(this.rowSHEMAPLACA, StatementType.Update));
            this.ProcessLevelShemaplaca();
        }

        private void UpdateShemaplacashemaplacadop()
        {
            this.CheckOptimisticConcurrencyShemaplacashemaplacadop();
            this.CheckExtendedTableShemaplacashemaplacadop();
            this.AfterConfirmShemaplacashemaplacadop();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [SHEMAPLACASHEMAPLACADOP] SET [MTDOPIDMJESTOTROSKA]=@MTDOPIDMJESTOTROSKA, [STRANEDOPIDSTRANEKNJIZENJA]=@STRANEDOPIDSTRANEKNJIZENJA  WHERE [IDSHEMAPLACA] = @IDSHEMAPLACA AND [SHEMAPLDOPIDDOPRINOS] = @SHEMAPLDOPIDDOPRINOS AND [KONTODOPIDKONTO] = @KONTODOPIDKONTO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MTDOPIDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STRANEDOPIDSTRANEKNJIZENJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLDOPIDDOPRINOS", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTODOPIDKONTO", DbType.String, 14));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["MTDOPIDMJESTOTROSKA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["STRANEDOPIDSTRANEKNJIZENJA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["IDSHEMAPLACA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["SHEMAPLDOPIDDOPRINOS"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACADOP["KONTODOPIDKONTO"]))));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemaplacashemaplacadop();
            }
            this.OnSHEMAPLACASHEMAPLACADOPUpdated(new SHEMAPLACASHEMAPLACADOPEventArgs(this.rowSHEMAPLACASHEMAPLACADOP, StatementType.Update));
        }

        private void UpdateShemaplacashemaplacaelement()
        {
            this.CheckOptimisticConcurrencyShemaplacashemaplacaelement();
            this.CheckExtendedTableShemaplacashemaplacaelement();
            this.AfterConfirmShemaplacashemaplacaelement();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [SHEMAPLACASHEMAPLACAELEMENT] SET [MTELEMENTIDMJESTOTROSKA]=@MTELEMENTIDMJESTOTROSKA  WHERE [IDSHEMAPLACA] = @IDSHEMAPLACA AND [SHEMAPLELEMENTIDELEMENT] = @SHEMAPLELEMENTIDELEMENT AND [KONTOELEMENTIDKONTO] = @KONTOELEMENTIDKONTO AND [STRANEELEMENTIDSTRANEKNJIZENJA] = @STRANEELEMENTIDSTRANEKNJIZENJA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MTELEMENTIDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLELEMENTIDELEMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTOELEMENTIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STRANEELEMENTIDSTRANEKNJIZENJA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["MTELEMENTIDMJESTOTROSKA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["IDSHEMAPLACA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["SHEMAPLELEMENTIDELEMENT"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["KONTOELEMENTIDKONTO"]))));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACAELEMENT["STRANEELEMENTIDSTRANEKNJIZENJA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemaplacashemaplacaelement();
            }
            this.OnSHEMAPLACASHEMAPLACAELEMENTUpdated(new SHEMAPLACASHEMAPLACAELEMENTEventArgs(this.rowSHEMAPLACASHEMAPLACAELEMENT, StatementType.Update));
        }

        private void UpdateShemaplacashemaplacastandard()
        {
            this.CheckOptimisticConcurrencyShemaplacashemaplacastandard();
            this.CheckExtendedTableShemaplacashemaplacastandard();
            this.AfterConfirmShemaplacashemaplacastandard();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [SHEMAPLACASHEMAPLACASTANDARD] SET [IDPLVRSTEIZNOSA]=@IDPLVRSTEIZNOSA, [KONTOPLACAVRSTAIZNOSAIDKONTO]=@KONTOPLACAVRSTAIZNOSAIDKONTO, [MTPLACAVRSTAIZNOSAIDMJESTOTROSKA]=@MTPLACAVRSTAIZNOSAIDMJESTOTROSKA, [STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA]=@STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA  WHERE [IDSHEMAPLACA] = @IDSHEMAPLACA AND [SHEMAPLACASTANDARDID] = @SHEMAPLACASTANDARDID", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLVRSTEIZNOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTOPLACAVRSTAIZNOSAIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MTPLACAVRSTAIZNOSAIDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLACASTANDARDID", DbType.Guid));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["IDPLVRSTEIZNOSA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["KONTOPLACAVRSTAIZNOSAIDKONTO"]))));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["MTPLACAVRSTAIZNOSAIDMJESTOTROSKA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["IDSHEMAPLACA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowSHEMAPLACASHEMAPLACASTANDARD["SHEMAPLACASTANDARDID"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemaplacashemaplacastandard();
            }
            this.OnSHEMAPLACASHEMAPLACASTANDARDUpdated(new SHEMAPLACASHEMAPLACASTANDARDEventArgs(this.rowSHEMAPLACASHEMAPLACASTANDARD, StatementType.Update));
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
        public class ELEMENTForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public ELEMENTForeignKeyNotFoundException()
            {
            }

            public ELEMENTForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected ELEMENTForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ELEMENTForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
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
        public class PLVRSTEIZNOSAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public PLVRSTEIZNOSAForeignKeyNotFoundException()
            {
            }

            public PLVRSTEIZNOSAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected PLVRSTEIZNOSAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PLVRSTEIZNOSAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAPLACADataChangedException : DataChangedException
        {
            public SHEMAPLACADataChangedException()
            {
            }

            public SHEMAPLACADataChangedException(string message) : base(message)
            {
            }

            protected SHEMAPLACADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAPLACADataLockedException : DataLockedException
        {
            public SHEMAPLACADataLockedException()
            {
            }

            public SHEMAPLACADataLockedException(string message) : base(message)
            {
            }

            protected SHEMAPLACADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAPLACADuplicateKeyException : DuplicateKeyException
        {
            public SHEMAPLACADuplicateKeyException()
            {
            }

            public SHEMAPLACADuplicateKeyException(string message) : base(message)
            {
            }

            protected SHEMAPLACADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class SHEMAPLACAEventArgs : EventArgs
        {
            private SHEMAPLACADataSet.SHEMAPLACARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public SHEMAPLACAEventArgs(SHEMAPLACADataSet.SHEMAPLACARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public SHEMAPLACADataSet.SHEMAPLACARow Row
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
        public class SHEMAPLACANotFoundException : DataNotFoundException
        {
            public SHEMAPLACANotFoundException()
            {
            }

            public SHEMAPLACANotFoundException(string message) : base(message)
            {
            }

            protected SHEMAPLACANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAPLACASHEMAPLACADOPDataChangedException : DataChangedException
        {
            public SHEMAPLACASHEMAPLACADOPDataChangedException()
            {
            }

            public SHEMAPLACASHEMAPLACADOPDataChangedException(string message) : base(message)
            {
            }

            protected SHEMAPLACASHEMAPLACADOPDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACASHEMAPLACADOPDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAPLACASHEMAPLACADOPDataLockedException : DataLockedException
        {
            public SHEMAPLACASHEMAPLACADOPDataLockedException()
            {
            }

            public SHEMAPLACASHEMAPLACADOPDataLockedException(string message) : base(message)
            {
            }

            protected SHEMAPLACASHEMAPLACADOPDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACASHEMAPLACADOPDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAPLACASHEMAPLACADOPDuplicateKeyException : DuplicateKeyException
        {
            public SHEMAPLACASHEMAPLACADOPDuplicateKeyException()
            {
            }

            public SHEMAPLACASHEMAPLACADOPDuplicateKeyException(string message) : base(message)
            {
            }

            protected SHEMAPLACASHEMAPLACADOPDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACASHEMAPLACADOPDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class SHEMAPLACASHEMAPLACADOPEventArgs : EventArgs
        {
            private SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public SHEMAPLACASHEMAPLACADOPEventArgs(SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow Row
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

        public delegate void SHEMAPLACASHEMAPLACADOPUpdateEventHandler(object sender, SHEMAPLACADataAdapter.SHEMAPLACASHEMAPLACADOPEventArgs e);

        [Serializable]
        public class SHEMAPLACASHEMAPLACAELEMENTDataChangedException : DataChangedException
        {
            public SHEMAPLACASHEMAPLACAELEMENTDataChangedException()
            {
            }

            public SHEMAPLACASHEMAPLACAELEMENTDataChangedException(string message) : base(message)
            {
            }

            protected SHEMAPLACASHEMAPLACAELEMENTDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACASHEMAPLACAELEMENTDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAPLACASHEMAPLACAELEMENTDataLockedException : DataLockedException
        {
            public SHEMAPLACASHEMAPLACAELEMENTDataLockedException()
            {
            }

            public SHEMAPLACASHEMAPLACAELEMENTDataLockedException(string message) : base(message)
            {
            }

            protected SHEMAPLACASHEMAPLACAELEMENTDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACASHEMAPLACAELEMENTDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAPLACASHEMAPLACAELEMENTDuplicateKeyException : DuplicateKeyException
        {
            public SHEMAPLACASHEMAPLACAELEMENTDuplicateKeyException()
            {
            }

            public SHEMAPLACASHEMAPLACAELEMENTDuplicateKeyException(string message) : base(message)
            {
            }

            protected SHEMAPLACASHEMAPLACAELEMENTDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACASHEMAPLACAELEMENTDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class SHEMAPLACASHEMAPLACAELEMENTEventArgs : EventArgs
        {
            private SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public SHEMAPLACASHEMAPLACAELEMENTEventArgs(SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow Row
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

        public delegate void SHEMAPLACASHEMAPLACAELEMENTUpdateEventHandler(object sender, SHEMAPLACADataAdapter.SHEMAPLACASHEMAPLACAELEMENTEventArgs e);

        [Serializable]
        public class SHEMAPLACASHEMAPLACASTANDARDDataChangedException : DataChangedException
        {
            public SHEMAPLACASHEMAPLACASTANDARDDataChangedException()
            {
            }

            public SHEMAPLACASHEMAPLACASTANDARDDataChangedException(string message) : base(message)
            {
            }

            protected SHEMAPLACASHEMAPLACASTANDARDDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACASHEMAPLACASTANDARDDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAPLACASHEMAPLACASTANDARDDataLockedException : DataLockedException
        {
            public SHEMAPLACASHEMAPLACASTANDARDDataLockedException()
            {
            }

            public SHEMAPLACASHEMAPLACASTANDARDDataLockedException(string message) : base(message)
            {
            }

            protected SHEMAPLACASHEMAPLACASTANDARDDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACASHEMAPLACASTANDARDDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAPLACASHEMAPLACASTANDARDDuplicateKeyException : DuplicateKeyException
        {
            public SHEMAPLACASHEMAPLACASTANDARDDuplicateKeyException()
            {
            }

            public SHEMAPLACASHEMAPLACASTANDARDDuplicateKeyException(string message) : base(message)
            {
            }

            protected SHEMAPLACASHEMAPLACASTANDARDDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACASHEMAPLACASTANDARDDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class SHEMAPLACASHEMAPLACASTANDARDEventArgs : EventArgs
        {
            private SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public SHEMAPLACASHEMAPLACASTANDARDEventArgs(SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow Row
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

        public delegate void SHEMAPLACASHEMAPLACASTANDARDUpdateEventHandler(object sender, SHEMAPLACADataAdapter.SHEMAPLACASHEMAPLACASTANDARDEventArgs e);

        public delegate void SHEMAPLACAUpdateEventHandler(object sender, SHEMAPLACADataAdapter.SHEMAPLACAEventArgs e);

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

