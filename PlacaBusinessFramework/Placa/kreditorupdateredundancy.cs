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

    public class kreditorupdateredundancy
    {
        private string AV2GXV327;
        private string AV3GXV326;
        private string AV4GXV325;
        private string AV5GXV324;
        private string AV6GXV323;
        private string AV7GXV309;
        private ReadWriteCommand cmKREDITORUp2;
        private ReadWriteCommand cmKREDITORUp3;
        private ReadWriteConnection connDefault;
        private DataStore dsDefault;
        private IDataReader KREDITORUp2;
        private bool m__NAZIVKREDITORIsNull;
        private bool m__PRIMATELJKREDITOR1IsNull;
        private bool m__PRIMATELJKREDITOR2IsNull;
        private bool m__PRIMATELJKREDITOR3IsNull;
        private bool m__VBDIKREDITORIsNull;
        private bool m__ZRNKREDITORIsNull;
        private int m_IDKREDITOR;
        private string m_NAZIVKREDITOR;
        private string m_PRIMATELJKREDITOR1;
        private string m_PRIMATELJKREDITOR2;
        private string m_PRIMATELJKREDITOR3;
        private string m_VBDIKREDITOR;
        private string m_ZRNKREDITOR;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;

        public event ReorganizationMessageEventHandler messageHandlerEvent;

        public kreditorupdateredundancy(ref DataStore ds)
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

        public void execute(int aP0_IDKREDITOR)
        {
            this.m_IDKREDITOR = aP0_IDKREDITOR;
            this.Initialize();
            this.executePrivate();
        }

        public void executePrivate()
        {
            this.cmKREDITORUp2 = this.connDefault.GetCommand("SELECT [IDKREDITOR], [NAZIVKREDITOR], [VBDIKREDITOR], [ZRNKREDITOR], [PRIMATELJKREDITOR1], [PRIMATELJKREDITOR2], [PRIMATELJKREDITOR3] FROM [KREDITOR] WITH (NOLOCK) WHERE [IDKREDITOR] = @IDKREDITOR ORDER BY [IDKREDITOR] ", false);
            if (this.cmKREDITORUp2.IDbCommand.Parameters.Count == 0)
            {
                this.cmKREDITORUp2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKREDITOR", DbType.Int32));
            }
            this.cmKREDITORUp2.SetParameter(0, this.m_IDKREDITOR);
            this.cmKREDITORUp2.ErrorMask |= ErrorMask.Lock;
            this.KREDITORUp2 = this.cmKREDITORUp2.FetchData();
            while (this.cmKREDITORUp2.HasMoreRows)
            {
                this.m_NAZIVKREDITOR = this.dsDefault.Db.GetString(this.KREDITORUp2, 1, ref this.m__NAZIVKREDITORIsNull);
                this.m_VBDIKREDITOR = this.dsDefault.Db.GetString(this.KREDITORUp2, 2, ref this.m__VBDIKREDITORIsNull);
                this.m_ZRNKREDITOR = this.dsDefault.Db.GetString(this.KREDITORUp2, 3, ref this.m__ZRNKREDITORIsNull);
                this.m_PRIMATELJKREDITOR1 = this.dsDefault.Db.GetString(this.KREDITORUp2, 4, ref this.m__PRIMATELJKREDITOR1IsNull);
                this.m_PRIMATELJKREDITOR2 = this.dsDefault.Db.GetString(this.KREDITORUp2, 5, ref this.m__PRIMATELJKREDITOR2IsNull);
                this.m_PRIMATELJKREDITOR3 = this.dsDefault.Db.GetString(this.KREDITORUp2, 6, ref this.m__PRIMATELJKREDITOR3IsNull);
                this.AV7GXV309 = this.m_NAZIVKREDITOR;
                this.AV6GXV323 = this.m_VBDIKREDITOR;
                this.AV5GXV324 = this.m_ZRNKREDITOR;
                this.AV4GXV325 = this.m_PRIMATELJKREDITOR1;
                this.AV3GXV326 = this.m_PRIMATELJKREDITOR2;
                this.AV2GXV327 = this.m_PRIMATELJKREDITOR3;
                this.cmKREDITORUp3 = this.connDefault.GetCommand("UPDATE [OBRACUNKrediti] SET [NAZIVKREDITOR]=@NAZIVKREDITOR, [VBDIKREDITOR]=@VBDIKREDITOR, [ZRNKREDITOR]=@ZRNKREDITOR, [PRIMATELJKREDITOR1]=@PRIMATELJKREDITOR1, [PRIMATELJKREDITOR2]=@PRIMATELJKREDITOR2, [PRIMATELJKREDITOR3]=@PRIMATELJKREDITOR3  WHERE [IDKREDITOR] = @IDKREDITOR", false);
                if (this.cmKREDITORUp3.IDbCommand.Parameters.Count == 0)
                {
                    this.cmKREDITORUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVKREDITOR", DbType.String, 20));
                    this.cmKREDITORUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIKREDITOR", DbType.String, 7));
                    this.cmKREDITORUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNKREDITOR", DbType.String, 10));
                    this.cmKREDITORUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKREDITOR1", DbType.String, 20));
                    this.cmKREDITORUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKREDITOR2", DbType.String, 20));
                    this.cmKREDITORUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKREDITOR3", DbType.String, 20));
                    this.cmKREDITORUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKREDITOR", DbType.Int32));
                }
                this.cmKREDITORUp3.SetParameter(0, this.AV7GXV309);
                this.cmKREDITORUp3.SetParameter(1, this.AV6GXV323);
                this.cmKREDITORUp3.SetParameter(2, this.AV5GXV324);
                this.cmKREDITORUp3.SetParameter(3, this.AV4GXV325);
                this.cmKREDITORUp3.SetParameter(4, this.AV3GXV326, this.m__PRIMATELJKREDITOR2IsNull);
                this.cmKREDITORUp3.SetParameter(5, this.AV2GXV327, this.m__PRIMATELJKREDITOR3IsNull);
                this.cmKREDITORUp3.SetParameter(6, this.m_IDKREDITOR);
                this.cmKREDITORUp3.ExecuteStmt();
                break;
            }
            this.KREDITORUp2.Close();
            this.Cleanup();
        }

        public void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m__NAZIVKREDITORIsNull = false;
            this.m_NAZIVKREDITOR = "";
            this.m__VBDIKREDITORIsNull = false;
            this.m_VBDIKREDITOR = "";
            this.m__ZRNKREDITORIsNull = false;
            this.m_ZRNKREDITOR = "";
            this.m__PRIMATELJKREDITOR1IsNull = false;
            this.m_PRIMATELJKREDITOR1 = "";
            this.m__PRIMATELJKREDITOR2IsNull = false;
            this.m_PRIMATELJKREDITOR2 = "";
            this.m__PRIMATELJKREDITOR3IsNull = false;
            this.m_PRIMATELJKREDITOR3 = "";
            this.AV7GXV309 = "";
            this.AV6GXV323 = "";
            this.AV5GXV324 = "";
            this.AV4GXV325 = "";
            this.AV3GXV326 = "";
            this.AV2GXV327 = "";
        }
    }
}

