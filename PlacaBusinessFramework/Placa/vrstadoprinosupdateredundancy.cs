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

    public class vrstadoprinosupdateredundancy
    {
        private string AV2GXV51;
        private ReadWriteCommand cmVRSTADOPRI2;
        private ReadWriteCommand cmVRSTADOPRI3;
        private ReadWriteCommand cmVRSTADOPRI4;
        private ReadWriteConnection connDefault;
        private DataStore dsDefault;
        private bool m__NAZIVVRSTADOPRINOSIsNull;
        private int m_IDVRSTADOPRINOS;
        private string m_NAZIVVRSTADOPRINOS;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private IDataReader VRSTADOPRI2;

        public event ReorganizationMessageEventHandler messageHandlerEvent;

        public vrstadoprinosupdateredundancy(ref DataStore ds)
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

        public void execute(int aP0_IDVRSTADOPRINOS)
        {
            this.m_IDVRSTADOPRINOS = aP0_IDVRSTADOPRINOS;
            this.Initialize();
            this.executePrivate();
        }

        public void executePrivate()
        {
            this.cmVRSTADOPRI2 = this.connDefault.GetCommand("SELECT [IDVRSTADOPRINOS], [NAZIVVRSTADOPRINOS] FROM [VRSTADOPRINOS] WITH (NOLOCK) WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS ORDER BY [IDVRSTADOPRINOS] ", false);
            if (this.cmVRSTADOPRI2.IDbCommand.Parameters.Count == 0)
            {
                this.cmVRSTADOPRI2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
            }
            this.cmVRSTADOPRI2.SetParameter(0, this.m_IDVRSTADOPRINOS);
            this.cmVRSTADOPRI2.ErrorMask |= ErrorMask.Lock;
            this.VRSTADOPRI2 = this.cmVRSTADOPRI2.FetchData();
            while (this.cmVRSTADOPRI2.HasMoreRows)
            {
                this.m_NAZIVVRSTADOPRINOS = this.dsDefault.Db.GetString(this.VRSTADOPRI2, 1, ref this.m__NAZIVVRSTADOPRINOSIsNull);
                this.AV2GXV51 = this.m_NAZIVVRSTADOPRINOS;
                this.cmVRSTADOPRI3 = this.connDefault.GetCommand("UPDATE [ObracunDoprinosi] SET [NAZIVVRSTADOPRINOS]=@NAZIVVRSTADOPRINOS ", false);
                if (this.cmVRSTADOPRI3.IDbCommand.Parameters.Count == 0)
                {
                    this.cmVRSTADOPRI3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTADOPRINOS", DbType.String, 50));
                }
                this.cmVRSTADOPRI3.SetParameter(0, this.AV2GXV51);
                this.cmVRSTADOPRI3.ExecuteStmt();
                this.cmVRSTADOPRI4 = this.connDefault.GetCommand("UPDATE [DDOBRACUNRadniciDoprinosi] SET [NAZIVVRSTADOPRINOS]=@NAZIVVRSTADOPRINOS ", false);
                if (this.cmVRSTADOPRI4.IDbCommand.Parameters.Count == 0)
                {
                    this.cmVRSTADOPRI4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTADOPRINOS", DbType.String, 50));
                }
                this.cmVRSTADOPRI4.SetParameter(0, this.AV2GXV51);
                this.cmVRSTADOPRI4.ExecuteStmt();
                break;
            }
            this.VRSTADOPRI2.Close();
            this.Cleanup();
        }

        public void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m__NAZIVVRSTADOPRINOSIsNull = false;
            this.m_NAZIVVRSTADOPRINOS = "";
            this.AV2GXV51 = "";
        }
    }
}

