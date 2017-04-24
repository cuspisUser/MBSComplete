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

    public class krizniporezupdateredundancy
    {
        private string AV10GXV919;
        private string AV11GXV918;
        private string AV12GXV917;
        private decimal AV13GXV914;
        private string AV14GXV913;
        private string AV2GXV935;
        private string AV3GXV934;
        private string AV4GXV933;
        private string AV5GXV924;
        private string AV6GXV923;
        private string AV7GXV922;
        private string AV8GXV921;
        private string AV9GXV920;
        private ReadWriteCommand cmKRIZNIPORE2;
        private ReadWriteCommand cmKRIZNIPORE3;
        private ReadWriteCommand cmKRIZNIPORE4;
        private ReadWriteConnection connDefault;
        private DataStore dsDefault;
        private IDataReader KRIZNIPORE2;
        private bool m__KRIZNISTOPAIsNull;
        private bool m__MOKRIZNIIsNull;
        private bool m__MZKRIZNIIsNull;
        private bool m__NAZIVKRIZNIPOREZIsNull;
        private bool m__OPISPLACANJAKRIZNIIsNull;
        private bool m__POKRIZNIIsNull;
        private bool m__PRIMATELJKRIZNI1IsNull;
        private bool m__PRIMATELJKRIZNI2IsNull;
        private bool m__PRIMATELJKRIZNI3IsNull;
        private bool m__PZKRIZNIIsNull;
        private bool m__SIFRAOPISAPLACANJAKRIZNIIsNull;
        private bool m__VBDIKRIZNIIsNull;
        private bool m__ZRNKRIZNIIsNull;
        private int m_IDKRIZNIPOREZ;
        private decimal m_KRIZNISTOPA;
        private string m_MOKRIZNI;
        private string m_MZKRIZNI;
        private string m_NAZIVKRIZNIPOREZ;
        private string m_OPISPLACANJAKRIZNI;
        private string m_POKRIZNI;
        private string m_PRIMATELJKRIZNI1;
        private string m_PRIMATELJKRIZNI2;
        private string m_PRIMATELJKRIZNI3;
        private string m_PZKRIZNI;
        private string m_SIFRAOPISAPLACANJAKRIZNI;
        private string m_VBDIKRIZNI;
        private string m_ZRNKRIZNI;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;

        public event ReorganizationMessageEventHandler messageHandlerEvent;

        public krizniporezupdateredundancy(ref DataStore ds)
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

        public void execute(int aP0_IDKRIZNIPOREZ)
        {
            this.m_IDKRIZNIPOREZ = aP0_IDKRIZNIPOREZ;
            this.Initialize();
            this.executePrivate();
        }

        public void executePrivate()
        {
            this.cmKRIZNIPORE2 = this.connDefault.GetCommand("SELECT [IDKRIZNIPOREZ], [NAZIVKRIZNIPOREZ], [KRIZNISTOPA], [MOKRIZNI], [POKRIZNI], [MZKRIZNI], [PZKRIZNI], [PRIMATELJKRIZNI1], [PRIMATELJKRIZNI2], [SIFRAOPISAPLACANJAKRIZNI], [OPISPLACANJAKRIZNI], [PRIMATELJKRIZNI3], [VBDIKRIZNI], [ZRNKRIZNI] FROM [KRIZNIPOREZ] WITH (NOLOCK) WHERE [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ ORDER BY [IDKRIZNIPOREZ] ", false);
            if (this.cmKRIZNIPORE2.IDbCommand.Parameters.Count == 0)
            {
                this.cmKRIZNIPORE2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
            }
            this.cmKRIZNIPORE2.SetParameter(0, this.m_IDKRIZNIPOREZ);
            this.cmKRIZNIPORE2.ErrorMask |= ErrorMask.Lock;
            this.KRIZNIPORE2 = this.cmKRIZNIPORE2.FetchData();
            while (this.cmKRIZNIPORE2.HasMoreRows)
            {
                this.m_NAZIVKRIZNIPOREZ = this.dsDefault.Db.GetString(this.KRIZNIPORE2, 1, ref this.m__NAZIVKRIZNIPOREZIsNull);
                this.m_KRIZNISTOPA = this.dsDefault.Db.GetDecimal(this.KRIZNIPORE2, 2, ref this.m__KRIZNISTOPAIsNull);
                this.m_MOKRIZNI = this.dsDefault.Db.GetString(this.KRIZNIPORE2, 3, ref this.m__MOKRIZNIIsNull);
                this.m_POKRIZNI = this.dsDefault.Db.GetString(this.KRIZNIPORE2, 4, ref this.m__POKRIZNIIsNull);
                this.m_MZKRIZNI = this.dsDefault.Db.GetString(this.KRIZNIPORE2, 5, ref this.m__MZKRIZNIIsNull);
                this.m_PZKRIZNI = this.dsDefault.Db.GetString(this.KRIZNIPORE2, 6, ref this.m__PZKRIZNIIsNull);
                this.m_PRIMATELJKRIZNI1 = this.dsDefault.Db.GetString(this.KRIZNIPORE2, 7, ref this.m__PRIMATELJKRIZNI1IsNull);
                this.m_PRIMATELJKRIZNI2 = this.dsDefault.Db.GetString(this.KRIZNIPORE2, 8, ref this.m__PRIMATELJKRIZNI2IsNull);
                this.m_SIFRAOPISAPLACANJAKRIZNI = this.dsDefault.Db.GetString(this.KRIZNIPORE2, 9, ref this.m__SIFRAOPISAPLACANJAKRIZNIIsNull);
                this.m_OPISPLACANJAKRIZNI = this.dsDefault.Db.GetString(this.KRIZNIPORE2, 10, ref this.m__OPISPLACANJAKRIZNIIsNull);
                this.m_PRIMATELJKRIZNI3 = this.dsDefault.Db.GetString(this.KRIZNIPORE2, 11, ref this.m__PRIMATELJKRIZNI3IsNull);
                this.m_VBDIKRIZNI = this.dsDefault.Db.GetString(this.KRIZNIPORE2, 12, ref this.m__VBDIKRIZNIIsNull);
                this.m_ZRNKRIZNI = this.dsDefault.Db.GetString(this.KRIZNIPORE2, 13, ref this.m__ZRNKRIZNIIsNull);
                this.AV14GXV913 = this.m_NAZIVKRIZNIPOREZ;
                this.AV13GXV914 = this.m_KRIZNISTOPA;
                this.AV12GXV917 = this.m_MOKRIZNI;
                this.AV11GXV918 = this.m_POKRIZNI;
                this.AV10GXV919 = this.m_MZKRIZNI;
                this.AV9GXV920 = this.m_PZKRIZNI;
                this.AV8GXV921 = this.m_PRIMATELJKRIZNI1;
                this.AV7GXV922 = this.m_PRIMATELJKRIZNI2;
                this.AV6GXV923 = this.m_SIFRAOPISAPLACANJAKRIZNI;
                this.AV5GXV924 = this.m_OPISPLACANJAKRIZNI;
                this.AV4GXV933 = this.m_PRIMATELJKRIZNI3;
                this.AV3GXV934 = this.m_VBDIKRIZNI;
                this.AV2GXV935 = this.m_ZRNKRIZNI;
                this.cmKRIZNIPORE3 = this.connDefault.GetCommand("UPDATE [OBRACUNOBRACUNLevel1ObracunKrizni] SET [NAZIVKRIZNIPOREZ]=@NAZIVKRIZNIPOREZ, [KRIZNISTOPA]=@KRIZNISTOPA, [MOKRIZNI]=@MOKRIZNI, [POKRIZNI]=@POKRIZNI, [MZKRIZNI]=@MZKRIZNI, [PZKRIZNI]=@PZKRIZNI, [PRIMATELJKRIZNI1]=@PRIMATELJKRIZNI1, [PRIMATELJKRIZNI2]=@PRIMATELJKRIZNI2, [SIFRAOPISAPLACANJAKRIZNI]=@SIFRAOPISAPLACANJAKRIZNI, [OPISPLACANJAKRIZNI]=@OPISPLACANJAKRIZNI, [PRIMATELJKRIZNI3]=@PRIMATELJKRIZNI3, [VBDIKRIZNI]=@VBDIKRIZNI, [ZRNKRIZNI]=@ZRNKRIZNI  WHERE [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ", false);
                if (this.cmKRIZNIPORE3.IDbCommand.Parameters.Count == 0)
                {
                    this.cmKRIZNIPORE3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVKRIZNIPOREZ", DbType.String, 50));
                    this.cmKRIZNIPORE3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KRIZNISTOPA", DbType.Currency));
                    this.cmKRIZNIPORE3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOKRIZNI", DbType.String, 2));
                    this.cmKRIZNIPORE3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POKRIZNI", DbType.String, 0x16));
                    this.cmKRIZNIPORE3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZKRIZNI", DbType.String, 2));
                    this.cmKRIZNIPORE3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZKRIZNI", DbType.String, 0x16));
                    this.cmKRIZNIPORE3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI1", DbType.String, 20));
                    this.cmKRIZNIPORE3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI2", DbType.String, 20));
                    this.cmKRIZNIPORE3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAKRIZNI", DbType.String, 2));
                    this.cmKRIZNIPORE3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAKRIZNI", DbType.String, 0x24));
                    this.cmKRIZNIPORE3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI3", DbType.String, 20));
                    this.cmKRIZNIPORE3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIKRIZNI", DbType.String, 7));
                    this.cmKRIZNIPORE3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNKRIZNI", DbType.String, 10));
                    this.cmKRIZNIPORE3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
                }
                this.cmKRIZNIPORE3.SetParameter(0, this.AV14GXV913);
                this.cmKRIZNIPORE3.SetParameter(1, this.AV13GXV914);
                this.cmKRIZNIPORE3.SetParameter(2, this.AV12GXV917);
                this.cmKRIZNIPORE3.SetParameter(3, this.AV11GXV918);
                this.cmKRIZNIPORE3.SetParameter(4, this.AV10GXV919, this.m__MZKRIZNIIsNull);
                this.cmKRIZNIPORE3.SetParameter(5, this.AV9GXV920, this.m__PZKRIZNIIsNull);
                this.cmKRIZNIPORE3.SetParameter(6, this.AV8GXV921);
                this.cmKRIZNIPORE3.SetParameter(7, this.AV7GXV922);
                this.cmKRIZNIPORE3.SetParameter(8, this.AV6GXV923);
                this.cmKRIZNIPORE3.SetParameter(9, this.AV5GXV924);
                this.cmKRIZNIPORE3.SetParameter(10, this.AV4GXV933, this.m__PRIMATELJKRIZNI3IsNull);
                this.cmKRIZNIPORE3.SetParameter(11, this.AV3GXV934);
                this.cmKRIZNIPORE3.SetParameter(12, this.AV2GXV935);
                this.cmKRIZNIPORE3.SetParameter(13, this.m_IDKRIZNIPOREZ);
                this.cmKRIZNIPORE3.ExecuteStmt();
                this.cmKRIZNIPORE4 = this.connDefault.GetCommand("UPDATE [DDOBRACUNRadniciDDKrizniPorez] SET [NAZIVKRIZNIPOREZ]=@NAZIVKRIZNIPOREZ, [KRIZNISTOPA]=@KRIZNISTOPA, [MOKRIZNI]=@MOKRIZNI, [POKRIZNI]=@POKRIZNI, [MZKRIZNI]=@MZKRIZNI, [PZKRIZNI]=@PZKRIZNI, [PRIMATELJKRIZNI1]=@PRIMATELJKRIZNI1, [PRIMATELJKRIZNI2]=@PRIMATELJKRIZNI2, [SIFRAOPISAPLACANJAKRIZNI]=@SIFRAOPISAPLACANJAKRIZNI, [OPISPLACANJAKRIZNI]=@OPISPLACANJAKRIZNI, [PRIMATELJKRIZNI3]=@PRIMATELJKRIZNI3, [VBDIKRIZNI]=@VBDIKRIZNI, [ZRNKRIZNI]=@ZRNKRIZNI  WHERE [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ", false);
                if (this.cmKRIZNIPORE4.IDbCommand.Parameters.Count == 0)
                {
                    this.cmKRIZNIPORE4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVKRIZNIPOREZ", DbType.String, 50));
                    this.cmKRIZNIPORE4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KRIZNISTOPA", DbType.Currency));
                    this.cmKRIZNIPORE4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOKRIZNI", DbType.String, 2));
                    this.cmKRIZNIPORE4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POKRIZNI", DbType.String, 0x16));
                    this.cmKRIZNIPORE4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZKRIZNI", DbType.String, 2));
                    this.cmKRIZNIPORE4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZKRIZNI", DbType.String, 0x16));
                    this.cmKRIZNIPORE4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI1", DbType.String, 20));
                    this.cmKRIZNIPORE4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI2", DbType.String, 20));
                    this.cmKRIZNIPORE4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAKRIZNI", DbType.String, 2));
                    this.cmKRIZNIPORE4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAKRIZNI", DbType.String, 0x24));
                    this.cmKRIZNIPORE4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI3", DbType.String, 20));
                    this.cmKRIZNIPORE4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIKRIZNI", DbType.String, 7));
                    this.cmKRIZNIPORE4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNKRIZNI", DbType.String, 10));
                    this.cmKRIZNIPORE4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
                }
                this.cmKRIZNIPORE4.SetParameter(0, this.AV14GXV913);
                this.cmKRIZNIPORE4.SetParameter(1, this.AV13GXV914);
                this.cmKRIZNIPORE4.SetParameter(2, this.AV12GXV917);
                this.cmKRIZNIPORE4.SetParameter(3, this.AV11GXV918);
                this.cmKRIZNIPORE4.SetParameter(4, this.AV10GXV919, this.m__MZKRIZNIIsNull);
                this.cmKRIZNIPORE4.SetParameter(5, this.AV9GXV920, this.m__PZKRIZNIIsNull);
                this.cmKRIZNIPORE4.SetParameter(6, this.AV8GXV921);
                this.cmKRIZNIPORE4.SetParameter(7, this.AV7GXV922);
                this.cmKRIZNIPORE4.SetParameter(8, this.AV6GXV923);
                this.cmKRIZNIPORE4.SetParameter(9, this.AV5GXV924);
                this.cmKRIZNIPORE4.SetParameter(10, this.AV4GXV933, this.m__PRIMATELJKRIZNI3IsNull);
                this.cmKRIZNIPORE4.SetParameter(11, this.AV3GXV934);
                this.cmKRIZNIPORE4.SetParameter(12, this.AV2GXV935);
                this.cmKRIZNIPORE4.SetParameter(13, this.m_IDKRIZNIPOREZ);
                this.cmKRIZNIPORE4.ExecuteStmt();
                break;
            }
            this.KRIZNIPORE2.Close();
            this.Cleanup();
        }

        public void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m__NAZIVKRIZNIPOREZIsNull = false;
            this.m_NAZIVKRIZNIPOREZ = "";
            this.m__KRIZNISTOPAIsNull = false;
            this.m_KRIZNISTOPA = new decimal();
            this.m__MOKRIZNIIsNull = false;
            this.m_MOKRIZNI = "";
            this.m__POKRIZNIIsNull = false;
            this.m_POKRIZNI = "";
            this.m__MZKRIZNIIsNull = false;
            this.m_MZKRIZNI = "";
            this.m__PZKRIZNIIsNull = false;
            this.m_PZKRIZNI = "";
            this.m__PRIMATELJKRIZNI1IsNull = false;
            this.m_PRIMATELJKRIZNI1 = "";
            this.m__PRIMATELJKRIZNI2IsNull = false;
            this.m_PRIMATELJKRIZNI2 = "";
            this.m__SIFRAOPISAPLACANJAKRIZNIIsNull = false;
            this.m_SIFRAOPISAPLACANJAKRIZNI = "";
            this.m__OPISPLACANJAKRIZNIIsNull = false;
            this.m_OPISPLACANJAKRIZNI = "";
            this.m__PRIMATELJKRIZNI3IsNull = false;
            this.m_PRIMATELJKRIZNI3 = "";
            this.m__VBDIKRIZNIIsNull = false;
            this.m_VBDIKRIZNI = "";
            this.m__ZRNKRIZNIIsNull = false;
            this.m_ZRNKRIZNI = "";
            this.AV14GXV913 = "";
            this.AV13GXV914 = new decimal();
            this.AV12GXV917 = "";
            this.AV11GXV918 = "";
            this.AV10GXV919 = "";
            this.AV9GXV920 = "";
            this.AV8GXV921 = "";
            this.AV7GXV922 = "";
            this.AV6GXV923 = "";
            this.AV5GXV924 = "";
            this.AV4GXV933 = "";
            this.AV3GXV934 = "";
            this.AV2GXV935 = "";
        }
    }
}

