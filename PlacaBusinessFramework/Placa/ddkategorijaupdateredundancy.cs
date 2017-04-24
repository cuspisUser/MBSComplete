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

    public class ddkategorijaupdateredundancy
    {
        private int AV2GXV1086;
        private ReadWriteCommand cmDDKATEGORI2;
        private ReadWriteCommand cmDDKATEGORI3;
        private ReadWriteConnection connDefault;
        private IDataReader DDKATEGORI2;
        private DataStore dsDefault;
        private bool m__IDKOLONAIDDIsNull;
        private int m_IDKATEGORIJA;
        private int m_IDKOLONAIDD;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;

        public event ReorganizationMessageEventHandler messageHandlerEvent;

        public ddkategorijaupdateredundancy(ref DataStore ds)
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

        public void execute(int aP0_IDKATEGORIJA)
        {
            this.m_IDKATEGORIJA = aP0_IDKATEGORIJA;
            this.Initialize();
            this.executePrivate();
        }

        public void executePrivate()
        {
            this.cmDDKATEGORI2 = this.connDefault.GetCommand("SELECT [IDKATEGORIJA], [IDKOLONAIDD] FROM [DDKATEGORIJA] WITH (NOLOCK) WHERE [IDKATEGORIJA] = @IDKATEGORIJA ORDER BY [IDKATEGORIJA] ", false);
            if (this.cmDDKATEGORI2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDKATEGORI2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
            }
            this.cmDDKATEGORI2.SetParameter(0, this.m_IDKATEGORIJA);
            this.cmDDKATEGORI2.ErrorMask |= ErrorMask.Lock;
            this.DDKATEGORI2 = this.cmDDKATEGORI2.FetchData();
            while (this.cmDDKATEGORI2.HasMoreRows)
            {
                this.m_IDKOLONAIDD = this.dsDefault.Db.GetInt32(this.DDKATEGORI2, 1, ref this.m__IDKOLONAIDDIsNull);
                this.AV2GXV1086 = this.m_IDKOLONAIDD;
                this.cmDDKATEGORI3 = this.connDefault.GetCommand("UPDATE [DDOBRACUNRadnici] SET [IDKOLONAIDD]=@IDKOLONAIDD  WHERE [IDKATEGORIJA] = @IDKATEGORIJA", false);
                if (this.cmDDKATEGORI3.IDbCommand.Parameters.Count == 0)
                {
                    this.cmDDKATEGORI3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
                    this.cmDDKATEGORI3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
                }
                this.cmDDKATEGORI3.SetParameter(0, this.AV2GXV1086);
                this.cmDDKATEGORI3.SetParameter(1, this.m_IDKATEGORIJA);
                this.cmDDKATEGORI3.ExecuteStmt();
                break;
            }
            this.DDKATEGORI2.Close();
            this.Cleanup();
        }

        public void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m__IDKOLONAIDDIsNull = false;
            this.m_IDKOLONAIDD = 0;
            this.AV2GXV1086 = 0;
        }
    }
}

