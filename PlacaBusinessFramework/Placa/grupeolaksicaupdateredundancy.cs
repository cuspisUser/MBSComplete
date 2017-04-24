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

    public class grupeolaksicaupdateredundancy
    {
        private decimal AV2GXV53;
        private string AV3GXV52;
        private ReadWriteCommand cmGRUPEOLAKS2;
        private ReadWriteCommand cmGRUPEOLAKS3;
        private ReadWriteConnection connDefault;
        private DataStore dsDefault;
        private IDataReader GRUPEOLAKS2;
        private bool m__MAXIMALNIIZNOSGRUPEIsNull;
        private bool m__NAZIVGRUPEOLAKSICAIsNull;
        private int m_IDGRUPEOLAKSICA;
        private decimal m_MAXIMALNIIZNOSGRUPE;
        private string m_NAZIVGRUPEOLAKSICA;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;

        public event ReorganizationMessageEventHandler messageHandlerEvent;

        public grupeolaksicaupdateredundancy(ref DataStore ds)
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

        public void execute(int aP0_IDGRUPEOLAKSICA)
        {
            this.m_IDGRUPEOLAKSICA = aP0_IDGRUPEOLAKSICA;
            this.Initialize();
            this.executePrivate();
        }

        public void executePrivate()
        {
            this.cmGRUPEOLAKS2 = this.connDefault.GetCommand("SELECT [IDGRUPEOLAKSICA], [NAZIVGRUPEOLAKSICA], [MAXIMALNIIZNOSGRUPE] FROM [GRUPEOLAKSICA] WITH (NOLOCK) WHERE [IDGRUPEOLAKSICA] = @IDGRUPEOLAKSICA ORDER BY [IDGRUPEOLAKSICA] ", false);
            if (this.cmGRUPEOLAKS2.IDbCommand.Parameters.Count == 0)
            {
                this.cmGRUPEOLAKS2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
            }
            this.cmGRUPEOLAKS2.SetParameter(0, this.m_IDGRUPEOLAKSICA);
            this.cmGRUPEOLAKS2.ErrorMask |= ErrorMask.Lock;
            this.GRUPEOLAKS2 = this.cmGRUPEOLAKS2.FetchData();
            while (this.cmGRUPEOLAKS2.HasMoreRows)
            {
                this.m_NAZIVGRUPEOLAKSICA = this.dsDefault.Db.GetString(this.GRUPEOLAKS2, 1, ref this.m__NAZIVGRUPEOLAKSICAIsNull);
                this.m_MAXIMALNIIZNOSGRUPE = this.dsDefault.Db.GetDecimal(this.GRUPEOLAKS2, 2, ref this.m__MAXIMALNIIZNOSGRUPEIsNull);
                this.AV3GXV52 = this.m_NAZIVGRUPEOLAKSICA;
                this.AV2GXV53 = this.m_MAXIMALNIIZNOSGRUPE;
                this.cmGRUPEOLAKS3 = this.connDefault.GetCommand("UPDATE [ObracunOlaksice] SET [NAZIVGRUPEOLAKSICA]=@NAZIVGRUPEOLAKSICA, [MAXIMALNIIZNOSGRUPE]=@MAXIMALNIIZNOSGRUPE ", false);
                if (this.cmGRUPEOLAKS3.IDbCommand.Parameters.Count == 0)
                {
                    this.cmGRUPEOLAKS3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVGRUPEOLAKSICA", DbType.String, 100));
                    this.cmGRUPEOLAKS3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MAXIMALNIIZNOSGRUPE", DbType.Currency));
                }
                this.cmGRUPEOLAKS3.SetParameter(0, this.AV3GXV52);
                this.cmGRUPEOLAKS3.SetParameter(1, this.AV2GXV53);
                this.cmGRUPEOLAKS3.ExecuteStmt();
                break;
            }
            this.GRUPEOLAKS2.Close();
            this.Cleanup();
        }

        public void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m__NAZIVGRUPEOLAKSICAIsNull = false;
            this.m_NAZIVGRUPEOLAKSICA = "";
            this.m__MAXIMALNIIZNOSGRUPEIsNull = false;
            this.m_MAXIMALNIIZNOSGRUPE = new decimal();
            this.AV3GXV52 = "";
            this.AV2GXV53 = new decimal();
        }
    }
}

