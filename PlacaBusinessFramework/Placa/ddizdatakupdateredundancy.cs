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

    public class ddizdatakupdateredundancy
    {
        private decimal AV2GXV1081;
        private string AV3GXV1080;
        private ReadWriteCommand cmDDIZDATAKU2;
        private ReadWriteCommand cmDDIZDATAKU3;
        private ReadWriteConnection connDefault;
        private IDataReader DDIZDATAKU2;
        private DataStore dsDefault;
        private bool m__DDNAZIVIZDATKAIsNull;
        private bool m__DDPOSTOTAKIZDATKAIsNull;
        private int m_DDIDIZDATAK;
        private string m_DDNAZIVIZDATKA;
        private decimal m_DDPOSTOTAKIZDATKA;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;

        public event ReorganizationMessageEventHandler messageHandlerEvent;

        public ddizdatakupdateredundancy(ref DataStore ds)
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

        public void execute(int aP0_DDIDIZDATAK)
        {
            this.m_DDIDIZDATAK = aP0_DDIDIZDATAK;
            this.Initialize();
            this.executePrivate();
        }

        public void executePrivate()
        {
            this.cmDDIZDATAKU2 = this.connDefault.GetCommand("SELECT [DDIDIZDATAK], [DDNAZIVIZDATKA], [DDPOSTOTAKIZDATKA] FROM [DDIZDATAK] WITH (NOLOCK) WHERE [DDIDIZDATAK] = @DDIDIZDATAK ORDER BY [DDIDIZDATAK] ", false);
            if (this.cmDDIZDATAKU2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDIZDATAKU2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
            }
            this.cmDDIZDATAKU2.SetParameter(0, this.m_DDIDIZDATAK);
            this.cmDDIZDATAKU2.ErrorMask |= ErrorMask.Lock;
            this.DDIZDATAKU2 = this.cmDDIZDATAKU2.FetchData();
            while (this.cmDDIZDATAKU2.HasMoreRows)
            {
                this.m_DDNAZIVIZDATKA = this.dsDefault.Db.GetString(this.DDIZDATAKU2, 1, ref this.m__DDNAZIVIZDATKAIsNull);
                this.m_DDPOSTOTAKIZDATKA = this.dsDefault.Db.GetDecimal(this.DDIZDATAKU2, 2, ref this.m__DDPOSTOTAKIZDATKAIsNull);
                this.AV3GXV1080 = this.m_DDNAZIVIZDATKA;
                this.AV2GXV1081 = this.m_DDPOSTOTAKIZDATKA;
                this.cmDDIZDATAKU3 = this.connDefault.GetCommand("UPDATE [DDOBRACUNRadniciIzdaci] SET [DDNAZIVIZDATKA]=@DDNAZIVIZDATKA, [DDPOSTOTAKIZDATKA]=@DDPOSTOTAKIZDATKA  WHERE [DDIDIZDATAK] = @DDIDIZDATAK", false);
                if (this.cmDDIZDATAKU3.IDbCommand.Parameters.Count == 0)
                {
                    this.cmDDIZDATAKU3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDNAZIVIZDATKA", DbType.String, 50));
                    this.cmDDIZDATAKU3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPOSTOTAKIZDATKA", DbType.Currency));
                    this.cmDDIZDATAKU3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
                }
                this.cmDDIZDATAKU3.SetParameter(0, this.AV3GXV1080);
                this.cmDDIZDATAKU3.SetParameter(1, this.AV2GXV1081);
                this.cmDDIZDATAKU3.SetParameter(2, this.m_DDIDIZDATAK);
                this.cmDDIZDATAKU3.ExecuteStmt();
                break;
            }
            this.DDIZDATAKU2.Close();
            this.Cleanup();
        }

        public void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m__DDNAZIVIZDATKAIsNull = false;
            this.m_DDNAZIVIZDATKA = "";
            this.m__DDPOSTOTAKIZDATKAIsNull = false;
            this.m_DDPOSTOTAKIZDATKA = new decimal();
            this.AV3GXV1080 = "";
            this.AV2GXV1081 = new decimal();
        }
    }
}

