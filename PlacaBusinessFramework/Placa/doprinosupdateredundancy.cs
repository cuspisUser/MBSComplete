namespace Placa
{
    using Deklarit.Data;
    using Deklarit.Reorganization;
    using Deklarit.Utils;
    using System;
    using System.Data;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;

    public class doprinosupdateredundancy
    {
        private string AV10GXV39;
        private string AV11GXV38;
        private decimal AV12GXV37;
        private int AV13GXV36;
        private string AV14GXV35;
        private string AV2GXV47;
        private string AV3GXV46;
        private string AV4GXV45;
        private string AV5GXV44;
        private string AV6GXV43;
        private string AV7GXV42;
        private string AV8GXV41;
        private string AV9GXV40;
        private ReadWriteCommand cmDOPRINOSUp2;
        private ReadWriteCommand cmDOPRINOSUp3;
        private ReadWriteCommand cmDOPRINOSUp4;
        private ReadWriteConnection connDefault;
        private IDataReader DOPRINOSUp2;
        private DataStore dsDefault;
        private bool m__IDVRSTADOPRINOSIsNull;
        private bool m__MODOPRINOSIsNull;
        private bool m__MZDOPRINOSIsNull;
        private bool m__NAZIVDOPRINOSIsNull;
        private bool m__OPISPLACANJADOPRINOSIsNull;
        private bool m__PODOPRINOSIsNull;
        private bool m__PRIMATELJDOPRINOS1IsNull;
        private bool m__PRIMATELJDOPRINOS2IsNull;
        private bool m__PZDOPRINOSIsNull;
        private bool m__SIFRAOPISAPLACANJADOPRINOSIsNull;
        private bool m__STOPAIsNull;
        private bool m__VBDIDOPRINOSIsNull;
        private bool m__ZRNDOPRINOSIsNull;
        private int m_IDDOPRINOS;
        private int m_IDVRSTADOPRINOS;
        private string m_MODOPRINOS;
        private string m_MZDOPRINOS;
        private string m_NAZIVDOPRINOS;
        private string m_OPISPLACANJADOPRINOS;
        private string m_PODOPRINOS;
        private string m_PRIMATELJDOPRINOS1;
        private string m_PRIMATELJDOPRINOS2;
        private string m_PZDOPRINOS;
        private string m_SIFRAOPISAPLACANJADOPRINOS;
        private decimal m_STOPA;
        private string m_VBDIDOPRINOS;
        private string m_ZRNDOPRINOS;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;

        public event ReorganizationMessageEventHandler messageHandlerEvent;

        public doprinosupdateredundancy(ref DataStore ds)
        {
            this.dsDefault = ds;
            this.connDefault = this.dsDefault.GetReadWriteConnection();
            this.Initialize();
        }

        public void AddMsg(string message)
        {
            if (this.messageHandlerEvent != null)
            {
                ReorganizationMessageEventHandler messageHandlerEvent = this.messageHandlerEvent;
                if (messageHandlerEvent != null)
                {
                    messageHandlerEvent(this, new ReorganizationMessageEventArgs(message));
                }
            }
        }

        protected void Cleanup()
        {
        }

        public void execute(int aP0_IDDOPRINOS)
        {
            this.m_IDDOPRINOS = aP0_IDDOPRINOS;
            this.Initialize();
            this.executePrivate();
        }

        public void executePrivate()
        {
            this.cmDOPRINOSUp2 = this.connDefault.GetCommand("SELECT [IDDOPRINOS], [NAZIVDOPRINOS], [IDVRSTADOPRINOS], [STOPA], [MODOPRINOS], [PODOPRINOS], [MZDOPRINOS], [PZDOPRINOS], [PRIMATELJDOPRINOS1], [PRIMATELJDOPRINOS2], [SIFRAOPISAPLACANJADOPRINOS], [OPISPLACANJADOPRINOS], [VBDIDOPRINOS], [ZRNDOPRINOS] FROM [DOPRINOS] WITH (NOLOCK) WHERE [IDDOPRINOS] = @IDDOPRINOS ORDER BY [IDDOPRINOS] ", false);
            if (this.cmDOPRINOSUp2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOPRINOSUp2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            this.cmDOPRINOSUp2.SetParameter(0, this.m_IDDOPRINOS);
            this.cmDOPRINOSUp2.ErrorMask |= ErrorMask.Lock;
            this.DOPRINOSUp2 = this.cmDOPRINOSUp2.FetchData();
            while (this.cmDOPRINOSUp2.HasMoreRows)
            {
                this.m_NAZIVDOPRINOS = this.dsDefault.Db.GetString(this.DOPRINOSUp2, 1, ref this.m__NAZIVDOPRINOSIsNull);
                this.m_IDVRSTADOPRINOS = this.dsDefault.Db.GetInt32(this.DOPRINOSUp2, 2, ref this.m__IDVRSTADOPRINOSIsNull);
                this.m_STOPA = this.dsDefault.Db.GetDecimal(this.DOPRINOSUp2, 3, ref this.m__STOPAIsNull);
                this.m_MODOPRINOS = this.dsDefault.Db.GetString(this.DOPRINOSUp2, 4, ref this.m__MODOPRINOSIsNull);
                this.m_PODOPRINOS = this.dsDefault.Db.GetString(this.DOPRINOSUp2, 5, ref this.m__PODOPRINOSIsNull);
                this.m_MZDOPRINOS = this.dsDefault.Db.GetString(this.DOPRINOSUp2, 6, ref this.m__MZDOPRINOSIsNull);
                this.m_PZDOPRINOS = this.dsDefault.Db.GetString(this.DOPRINOSUp2, 7, ref this.m__PZDOPRINOSIsNull);
                this.m_PRIMATELJDOPRINOS1 = this.dsDefault.Db.GetString(this.DOPRINOSUp2, 8, ref this.m__PRIMATELJDOPRINOS1IsNull);
                this.m_PRIMATELJDOPRINOS2 = this.dsDefault.Db.GetString(this.DOPRINOSUp2, 9, ref this.m__PRIMATELJDOPRINOS2IsNull);
                this.m_SIFRAOPISAPLACANJADOPRINOS = this.dsDefault.Db.GetString(this.DOPRINOSUp2, 10, ref this.m__SIFRAOPISAPLACANJADOPRINOSIsNull);
                this.m_OPISPLACANJADOPRINOS = this.dsDefault.Db.GetString(this.DOPRINOSUp2, 11, ref this.m__OPISPLACANJADOPRINOSIsNull);
                this.m_VBDIDOPRINOS = this.dsDefault.Db.GetString(this.DOPRINOSUp2, 12, ref this.m__VBDIDOPRINOSIsNull);
                this.m_ZRNDOPRINOS = this.dsDefault.Db.GetString(this.DOPRINOSUp2, 13, ref this.m__ZRNDOPRINOSIsNull);
                this.AV14GXV35 = this.m_NAZIVDOPRINOS;
                this.AV13GXV36 = this.m_IDVRSTADOPRINOS;
                this.AV12GXV37 = this.m_STOPA;
                this.AV11GXV38 = this.m_MODOPRINOS;
                this.AV10GXV39 = this.m_PODOPRINOS;
                this.AV9GXV40 = this.m_MZDOPRINOS;
                this.AV8GXV41 = this.m_PZDOPRINOS;
                this.AV7GXV42 = this.m_PRIMATELJDOPRINOS1;
                this.AV6GXV43 = this.m_PRIMATELJDOPRINOS2;
                this.AV5GXV44 = this.m_SIFRAOPISAPLACANJADOPRINOS;
                this.AV4GXV45 = this.m_OPISPLACANJADOPRINOS;
                this.AV3GXV46 = this.m_VBDIDOPRINOS;
                this.AV2GXV47 = this.m_ZRNDOPRINOS;
                this.cmDOPRINOSUp3 = this.connDefault.GetCommand("UPDATE [ObracunDoprinosi] SET [NAZIVDOPRINOS]=@NAZIVDOPRINOS, [IDVRSTADOPRINOS]=@IDVRSTADOPRINOS, [STOPA]=@STOPA, [MODOPRINOS]=@MODOPRINOS, [PODOPRINOS]=@PODOPRINOS, [MZDOPRINOS]=@MZDOPRINOS, [PZDOPRINOS]=@PZDOPRINOS, [PRIMATELJDOPRINOS1]=@PRIMATELJDOPRINOS1, [PRIMATELJDOPRINOS2]=@PRIMATELJDOPRINOS2, [SIFRAOPISAPLACANJADOPRINOS]=@SIFRAOPISAPLACANJADOPRINOS, [OPISPLACANJADOPRINOS]=@OPISPLACANJADOPRINOS, [VBDIDOPRINOS]=@VBDIDOPRINOS, [ZRNDOPRINOS]=@ZRNDOPRINOS  WHERE [IDDOPRINOS] = @IDDOPRINOS", false);
                if (this.cmDOPRINOSUp3.IDbCommand.Parameters.Count == 0)
                {
                    this.cmDOPRINOSUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVDOPRINOS", DbType.String, 50));
                    this.cmDOPRINOSUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
                    this.cmDOPRINOSUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STOPA", DbType.Currency));
                    this.cmDOPRINOSUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MODOPRINOS", DbType.String, 2));
                    this.cmDOPRINOSUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PODOPRINOS", DbType.String, 0x16));
                    this.cmDOPRINOSUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZDOPRINOS", DbType.String, 2));
                    this.cmDOPRINOSUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZDOPRINOS", DbType.String, 0x16));
                    this.cmDOPRINOSUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJDOPRINOS1", DbType.String, 20));
                    this.cmDOPRINOSUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJDOPRINOS2", DbType.String, 20));
                    this.cmDOPRINOSUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJADOPRINOS", DbType.String, 2));
                    this.cmDOPRINOSUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJADOPRINOS", DbType.String, 0x24));
                    this.cmDOPRINOSUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIDOPRINOS", DbType.String, 7));
                    this.cmDOPRINOSUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNDOPRINOS", DbType.String, 10));
                    this.cmDOPRINOSUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
                }
                this.cmDOPRINOSUp3.SetParameter(0, this.AV14GXV35);
                this.cmDOPRINOSUp3.SetParameter(1, this.AV13GXV36);
                this.cmDOPRINOSUp3.SetParameter(2, this.AV12GXV37);
                this.cmDOPRINOSUp3.SetParameter(3, this.AV11GXV38);
                this.cmDOPRINOSUp3.SetParameter(4, this.AV10GXV39);
                this.cmDOPRINOSUp3.SetParameter(5, this.AV9GXV40, this.m__MZDOPRINOSIsNull);
                this.cmDOPRINOSUp3.SetParameter(6, this.AV8GXV41, this.m__PZDOPRINOSIsNull);
                this.cmDOPRINOSUp3.SetParameter(7, this.AV7GXV42);
                this.cmDOPRINOSUp3.SetParameter(8, this.AV6GXV43, this.m__PRIMATELJDOPRINOS2IsNull);
                this.cmDOPRINOSUp3.SetParameter(9, this.AV5GXV44);
                this.cmDOPRINOSUp3.SetParameter(10, this.AV4GXV45);
                this.cmDOPRINOSUp3.SetParameter(11, this.AV3GXV46);
                this.cmDOPRINOSUp3.SetParameter(12, this.AV2GXV47);
                this.cmDOPRINOSUp3.SetParameter(13, this.m_IDDOPRINOS);
                this.cmDOPRINOSUp3.ExecuteStmt();
                this.cmDOPRINOSUp4 = this.connDefault.GetCommand("UPDATE [DDOBRACUNRadniciDoprinosi] SET [NAZIVDOPRINOS]=@NAZIVDOPRINOS, [IDVRSTADOPRINOS]=@IDVRSTADOPRINOS, [STOPA]=@STOPA, [MODOPRINOS]=@MODOPRINOS, [PODOPRINOS]=@PODOPRINOS, [MZDOPRINOS]=@MZDOPRINOS, [PZDOPRINOS]=@PZDOPRINOS, [PRIMATELJDOPRINOS1]=@PRIMATELJDOPRINOS1, [PRIMATELJDOPRINOS2]=@PRIMATELJDOPRINOS2, [SIFRAOPISAPLACANJADOPRINOS]=@SIFRAOPISAPLACANJADOPRINOS, [OPISPLACANJADOPRINOS]=@OPISPLACANJADOPRINOS, [VBDIDOPRINOS]=@VBDIDOPRINOS, [ZRNDOPRINOS]=@ZRNDOPRINOS  WHERE [IDDOPRINOS] = @IDDOPRINOS", false);
                if (this.cmDOPRINOSUp4.IDbCommand.Parameters.Count == 0)
                {
                    this.cmDOPRINOSUp4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVDOPRINOS", DbType.String, 50));
                    this.cmDOPRINOSUp4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
                    this.cmDOPRINOSUp4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STOPA", DbType.Currency));
                    this.cmDOPRINOSUp4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MODOPRINOS", DbType.String, 2));
                    this.cmDOPRINOSUp4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PODOPRINOS", DbType.String, 0x16));
                    this.cmDOPRINOSUp4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZDOPRINOS", DbType.String, 2));
                    this.cmDOPRINOSUp4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZDOPRINOS", DbType.String, 0x16));
                    this.cmDOPRINOSUp4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJDOPRINOS1", DbType.String, 20));
                    this.cmDOPRINOSUp4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJDOPRINOS2", DbType.String, 20));
                    this.cmDOPRINOSUp4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJADOPRINOS", DbType.String, 2));
                    this.cmDOPRINOSUp4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJADOPRINOS", DbType.String, 0x24));
                    this.cmDOPRINOSUp4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIDOPRINOS", DbType.String, 7));
                    this.cmDOPRINOSUp4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNDOPRINOS", DbType.String, 10));
                    this.cmDOPRINOSUp4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
                }
                this.cmDOPRINOSUp4.SetParameter(0, this.AV14GXV35);
                this.cmDOPRINOSUp4.SetParameter(1, this.AV13GXV36);
                this.cmDOPRINOSUp4.SetParameter(2, this.AV12GXV37);
                this.cmDOPRINOSUp4.SetParameter(3, this.AV11GXV38);
                this.cmDOPRINOSUp4.SetParameter(4, this.AV10GXV39);
                this.cmDOPRINOSUp4.SetParameter(5, this.AV9GXV40, this.m__MZDOPRINOSIsNull);
                this.cmDOPRINOSUp4.SetParameter(6, this.AV8GXV41, this.m__PZDOPRINOSIsNull);
                this.cmDOPRINOSUp4.SetParameter(7, this.AV7GXV42);
                this.cmDOPRINOSUp4.SetParameter(8, this.AV6GXV43, this.m__PRIMATELJDOPRINOS2IsNull);
                this.cmDOPRINOSUp4.SetParameter(9, this.AV5GXV44);
                this.cmDOPRINOSUp4.SetParameter(10, this.AV4GXV45);
                this.cmDOPRINOSUp4.SetParameter(11, this.AV3GXV46);
                this.cmDOPRINOSUp4.SetParameter(12, this.AV2GXV47);
                this.cmDOPRINOSUp4.SetParameter(13, this.m_IDDOPRINOS);
                this.cmDOPRINOSUp4.ExecuteStmt();
                break;
            }
            this.DOPRINOSUp2.Close();
            this.Cleanup();
        }

        public void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m__NAZIVDOPRINOSIsNull = false;
            this.m_NAZIVDOPRINOS = "";
            this.m__IDVRSTADOPRINOSIsNull = false;
            this.m_IDVRSTADOPRINOS = 0;
            this.m__STOPAIsNull = false;
            this.m_STOPA = new decimal();
            this.m__MODOPRINOSIsNull = false;
            this.m_MODOPRINOS = "";
            this.m__PODOPRINOSIsNull = false;
            this.m_PODOPRINOS = "";
            this.m__MZDOPRINOSIsNull = false;
            this.m_MZDOPRINOS = "";
            this.m__PZDOPRINOSIsNull = false;
            this.m_PZDOPRINOS = "";
            this.m__PRIMATELJDOPRINOS1IsNull = false;
            this.m_PRIMATELJDOPRINOS1 = "";
            this.m__PRIMATELJDOPRINOS2IsNull = false;
            this.m_PRIMATELJDOPRINOS2 = "";
            this.m__SIFRAOPISAPLACANJADOPRINOSIsNull = false;
            this.m_SIFRAOPISAPLACANJADOPRINOS = "";
            this.m__OPISPLACANJADOPRINOSIsNull = false;
            this.m_OPISPLACANJADOPRINOS = "";
            this.m__VBDIDOPRINOSIsNull = false;
            this.m_VBDIDOPRINOS = "";
            this.m__ZRNDOPRINOSIsNull = false;
            this.m_ZRNDOPRINOS = "";
            this.AV14GXV35 = "";
            this.AV13GXV36 = 0;
            this.AV12GXV37 = new decimal();
            this.AV11GXV38 = "";
            this.AV10GXV39 = "";
            this.AV9GXV40 = "";
            this.AV8GXV41 = "";
            this.AV7GXV42 = "";
            this.AV6GXV43 = "";
            this.AV5GXV44 = "";
            this.AV4GXV45 = "";
            this.AV3GXV46 = "";
            this.AV2GXV47 = "";
        }
    }
}

