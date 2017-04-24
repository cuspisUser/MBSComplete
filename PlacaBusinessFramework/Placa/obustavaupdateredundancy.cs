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

    public class obustavaupdateredundancy
    {
        private string AV10GXV191;
        private string AV11GXV190;
        private string AV12GXV189;
        private string AV13GXV188;
        private string AV14GXV187;
        private short AV2GXV199;
        private string AV3GXV198;
        private string AV4GXV197;
        private string AV5GXV196;
        private string AV6GXV195;
        private string AV7GXV194;
        private string AV8GXV193;
        private string AV9GXV192;
        private ReadWriteCommand cmOBUSTAVAUp2;
        private ReadWriteCommand cmOBUSTAVAUp3;
        private ReadWriteConnection connDefault;
        private DataStore dsDefault;
        private bool m__IDOBUSTAVAIsNull;
        private bool m__MOOBUSTAVAIsNull;
        private bool m__MZOBUSTAVAIsNull;
        private bool m__NAZIVOBUSTAVAIsNull;
        private bool m__OPISPLACANJAOBUSTAVAIsNull;
        private bool m__POOBUSTAVAIsNull;
        private bool m__PRIMATELJOBUSTAVA1IsNull;
        private bool m__PRIMATELJOBUSTAVA2IsNull;
        private bool m__PRIMATELJOBUSTAVA3IsNull;
        private bool m__PZOBUSTAVAIsNull;
        private bool m__SIFRAOPISAPLACANJAOBUSTAVAIsNull;
        private bool m__VBDIOBUSTAVAIsNull;
        private bool m__VRSTAOBUSTAVEIsNull;
        private bool m__ZRNOBUSTAVAIsNull;
        private int m_IDOBUSTAVA;
        private string m_MOOBUSTAVA;
        private string m_MZOBUSTAVA;
        private string m_NAZIVOBUSTAVA;
        private string m_OPISPLACANJAOBUSTAVA;
        private string m_POOBUSTAVA;
        private string m_PRIMATELJOBUSTAVA1;
        private string m_PRIMATELJOBUSTAVA2;
        private string m_PRIMATELJOBUSTAVA3;
        private string m_PZOBUSTAVA;
        private string m_SIFRAOPISAPLACANJAOBUSTAVA;
        private string m_VBDIOBUSTAVA;
        private short m_VRSTAOBUSTAVE;
        private string m_ZRNOBUSTAVA;
        private IDataReader OBUSTAVAUp2;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;

        public event ReorganizationMessageEventHandler messageHandlerEvent;

        public obustavaupdateredundancy(ref DataStore ds)
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

        public void execute(int aP0_IDOBUSTAVA)
        {
            this.m_IDOBUSTAVA = aP0_IDOBUSTAVA;
            this.Initialize();
            this.executePrivate();
        }

        public void executePrivate()
        {
            this.cmOBUSTAVAUp2 = this.connDefault.GetCommand("SELECT [IDOBUSTAVA], [NAZIVOBUSTAVA], [MOOBUSTAVA], [POOBUSTAVA], [MZOBUSTAVA], [PZOBUSTAVA], [VBDIOBUSTAVA], [ZRNOBUSTAVA], [PRIMATELJOBUSTAVA1], [PRIMATELJOBUSTAVA2], [PRIMATELJOBUSTAVA3], [SIFRAOPISAPLACANJAOBUSTAVA], [OPISPLACANJAOBUSTAVA], [VRSTAOBUSTAVE] FROM [OBUSTAVA] WITH (NOLOCK) WHERE [IDOBUSTAVA] = @IDOBUSTAVA ORDER BY [IDOBUSTAVA] ", false);
            if (this.cmOBUSTAVAUp2.IDbCommand.Parameters.Count == 0)
            {
                this.cmOBUSTAVAUp2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBUSTAVA", DbType.Int32));
            }
            this.cmOBUSTAVAUp2.SetParameter(0, this.m_IDOBUSTAVA, this.m__IDOBUSTAVAIsNull);
            this.cmOBUSTAVAUp2.ErrorMask |= ErrorMask.Lock;
            this.OBUSTAVAUp2 = this.cmOBUSTAVAUp2.FetchData();
            while (this.cmOBUSTAVAUp2.HasMoreRows)
            {
                this.m_NAZIVOBUSTAVA = this.dsDefault.Db.GetString(this.OBUSTAVAUp2, 1, ref this.m__NAZIVOBUSTAVAIsNull);
                this.m_MOOBUSTAVA = this.dsDefault.Db.GetString(this.OBUSTAVAUp2, 2, ref this.m__MOOBUSTAVAIsNull);
                this.m_POOBUSTAVA = this.dsDefault.Db.GetString(this.OBUSTAVAUp2, 3, ref this.m__POOBUSTAVAIsNull);
                this.m_MZOBUSTAVA = this.dsDefault.Db.GetString(this.OBUSTAVAUp2, 4, ref this.m__MZOBUSTAVAIsNull);
                this.m_PZOBUSTAVA = this.dsDefault.Db.GetString(this.OBUSTAVAUp2, 5, ref this.m__PZOBUSTAVAIsNull);
                this.m_VBDIOBUSTAVA = this.dsDefault.Db.GetString(this.OBUSTAVAUp2, 6, ref this.m__VBDIOBUSTAVAIsNull);
                this.m_ZRNOBUSTAVA = this.dsDefault.Db.GetString(this.OBUSTAVAUp2, 7, ref this.m__ZRNOBUSTAVAIsNull);
                this.m_PRIMATELJOBUSTAVA1 = this.dsDefault.Db.GetString(this.OBUSTAVAUp2, 8, ref this.m__PRIMATELJOBUSTAVA1IsNull);
                this.m_PRIMATELJOBUSTAVA2 = this.dsDefault.Db.GetString(this.OBUSTAVAUp2, 9, ref this.m__PRIMATELJOBUSTAVA2IsNull);
                this.m_PRIMATELJOBUSTAVA3 = this.dsDefault.Db.GetString(this.OBUSTAVAUp2, 10, ref this.m__PRIMATELJOBUSTAVA3IsNull);
                this.m_SIFRAOPISAPLACANJAOBUSTAVA = this.dsDefault.Db.GetString(this.OBUSTAVAUp2, 11, ref this.m__SIFRAOPISAPLACANJAOBUSTAVAIsNull);
                this.m_OPISPLACANJAOBUSTAVA = this.dsDefault.Db.GetString(this.OBUSTAVAUp2, 12, ref this.m__OPISPLACANJAOBUSTAVAIsNull);
                this.m_VRSTAOBUSTAVE = this.dsDefault.Db.GetInt16(this.OBUSTAVAUp2, 13, ref this.m__VRSTAOBUSTAVEIsNull);
                this.AV14GXV187 = this.m_NAZIVOBUSTAVA;
                this.AV13GXV188 = this.m_MOOBUSTAVA;
                this.AV12GXV189 = this.m_POOBUSTAVA;
                this.AV11GXV190 = this.m_MZOBUSTAVA;
                this.AV10GXV191 = this.m_PZOBUSTAVA;
                this.AV9GXV192 = this.m_VBDIOBUSTAVA;
                this.AV8GXV193 = this.m_ZRNOBUSTAVA;
                this.AV7GXV194 = this.m_PRIMATELJOBUSTAVA1;
                this.AV6GXV195 = this.m_PRIMATELJOBUSTAVA2;
                this.AV5GXV196 = this.m_PRIMATELJOBUSTAVA3;
                this.AV4GXV197 = this.m_SIFRAOPISAPLACANJAOBUSTAVA;
                this.AV3GXV198 = this.m_OPISPLACANJAOBUSTAVA;
                this.AV2GXV199 = this.m_VRSTAOBUSTAVE;
                this.cmOBUSTAVAUp3 = this.connDefault.GetCommand("UPDATE [OBRACUNObustave] SET [NAZIVOBUSTAVA]=@NAZIVOBUSTAVA, [MOOBUSTAVA]=@MOOBUSTAVA, [POOBUSTAVA]=@POOBUSTAVA, [MZOBUSTAVA]=@MZOBUSTAVA, [PZOBUSTAVA]=@PZOBUSTAVA, [VBDIOBUSTAVA]=@VBDIOBUSTAVA, [ZRNOBUSTAVA]=@ZRNOBUSTAVA, [PRIMATELJOBUSTAVA1]=@PRIMATELJOBUSTAVA1, [PRIMATELJOBUSTAVA2]=@PRIMATELJOBUSTAVA2, [PRIMATELJOBUSTAVA3]=@PRIMATELJOBUSTAVA3, [SIFRAOPISAPLACANJAOBUSTAVA]=@SIFRAOPISAPLACANJAOBUSTAVA, [OPISPLACANJAOBUSTAVA]=@OPISPLACANJAOBUSTAVA, [VRSTAOBUSTAVE]=@VRSTAOBUSTAVE  WHERE [IDOBUSTAVA] = @IDOBUSTAVA", false);
                if (this.cmOBUSTAVAUp3.IDbCommand.Parameters.Count == 0)
                {
                    this.cmOBUSTAVAUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOBUSTAVA", DbType.String, 100));
                    this.cmOBUSTAVAUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOOBUSTAVA", DbType.String, 2));
                    this.cmOBUSTAVAUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POOBUSTAVA", DbType.String, 0x16));
                    this.cmOBUSTAVAUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZOBUSTAVA", DbType.String, 2));
                    this.cmOBUSTAVAUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZOBUSTAVA", DbType.String, 0x16));
                    this.cmOBUSTAVAUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIOBUSTAVA", DbType.String, 7));
                    this.cmOBUSTAVAUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNOBUSTAVA", DbType.String, 10));
                    this.cmOBUSTAVAUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOBUSTAVA1", DbType.String, 20));
                    this.cmOBUSTAVAUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOBUSTAVA2", DbType.String, 20));
                    this.cmOBUSTAVAUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOBUSTAVA3", DbType.String, 20));
                    this.cmOBUSTAVAUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAOBUSTAVA", DbType.String, 2));
                    this.cmOBUSTAVAUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAOBUSTAVA", DbType.String, 0x24));
                    this.cmOBUSTAVAUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
                    this.cmOBUSTAVAUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBUSTAVA", DbType.Int32));
                }
                this.cmOBUSTAVAUp3.SetParameter(0, this.AV14GXV187, this.m__NAZIVOBUSTAVAIsNull);
                this.cmOBUSTAVAUp3.SetParameter(1, this.AV13GXV188, this.m__MOOBUSTAVAIsNull);
                this.cmOBUSTAVAUp3.SetParameter(2, this.AV12GXV189, this.m__POOBUSTAVAIsNull);
                this.cmOBUSTAVAUp3.SetParameter(3, this.AV11GXV190, this.m__MZOBUSTAVAIsNull);
                this.cmOBUSTAVAUp3.SetParameter(4, this.AV10GXV191, this.m__PZOBUSTAVAIsNull);
                this.cmOBUSTAVAUp3.SetParameter(5, this.AV9GXV192, this.m__VBDIOBUSTAVAIsNull);
                this.cmOBUSTAVAUp3.SetParameter(6, this.AV8GXV193, this.m__ZRNOBUSTAVAIsNull);
                this.cmOBUSTAVAUp3.SetParameter(7, this.AV7GXV194, this.m__PRIMATELJOBUSTAVA1IsNull);
                this.cmOBUSTAVAUp3.SetParameter(8, this.AV6GXV195, this.m__PRIMATELJOBUSTAVA2IsNull);
                this.cmOBUSTAVAUp3.SetParameter(9, this.AV5GXV196, this.m__PRIMATELJOBUSTAVA3IsNull);
                this.cmOBUSTAVAUp3.SetParameter(10, this.AV4GXV197, this.m__SIFRAOPISAPLACANJAOBUSTAVAIsNull);
                this.cmOBUSTAVAUp3.SetParameter(11, this.AV3GXV198, this.m__OPISPLACANJAOBUSTAVAIsNull);
                this.cmOBUSTAVAUp3.SetParameter(12, this.AV2GXV199, this.m__VRSTAOBUSTAVEIsNull);
                this.cmOBUSTAVAUp3.SetParameter(13, this.m_IDOBUSTAVA, this.m__IDOBUSTAVAIsNull);
                this.cmOBUSTAVAUp3.ExecuteStmt();
                break;
            }
            this.OBUSTAVAUp2.Close();
            this.Cleanup();
        }

        public void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m__IDOBUSTAVAIsNull = false;
            this.m__NAZIVOBUSTAVAIsNull = false;
            this.m_NAZIVOBUSTAVA = "";
            this.m__MOOBUSTAVAIsNull = false;
            this.m_MOOBUSTAVA = "";
            this.m__POOBUSTAVAIsNull = false;
            this.m_POOBUSTAVA = "";
            this.m__MZOBUSTAVAIsNull = false;
            this.m_MZOBUSTAVA = "";
            this.m__PZOBUSTAVAIsNull = false;
            this.m_PZOBUSTAVA = "";
            this.m__VBDIOBUSTAVAIsNull = false;
            this.m_VBDIOBUSTAVA = "";
            this.m__ZRNOBUSTAVAIsNull = false;
            this.m_ZRNOBUSTAVA = "";
            this.m__PRIMATELJOBUSTAVA1IsNull = false;
            this.m_PRIMATELJOBUSTAVA1 = "";
            this.m__PRIMATELJOBUSTAVA2IsNull = false;
            this.m_PRIMATELJOBUSTAVA2 = "";
            this.m__PRIMATELJOBUSTAVA3IsNull = false;
            this.m_PRIMATELJOBUSTAVA3 = "";
            this.m__SIFRAOPISAPLACANJAOBUSTAVAIsNull = false;
            this.m_SIFRAOPISAPLACANJAOBUSTAVA = "";
            this.m__OPISPLACANJAOBUSTAVAIsNull = false;
            this.m_OPISPLACANJAOBUSTAVA = "";
            this.m__VRSTAOBUSTAVEIsNull = false;
            this.m_VRSTAOBUSTAVE = 0;
            this.AV14GXV187 = "";
            this.AV13GXV188 = "";
            this.AV12GXV189 = "";
            this.AV11GXV190 = "";
            this.AV10GXV191 = "";
            this.AV9GXV192 = "";
            this.AV8GXV193 = "";
            this.AV7GXV194 = "";
            this.AV6GXV195 = "";
            this.AV5GXV196 = "";
            this.AV4GXV197 = "";
            this.AV3GXV198 = "";
            this.AV2GXV199 = 0;
        }
    }
}

