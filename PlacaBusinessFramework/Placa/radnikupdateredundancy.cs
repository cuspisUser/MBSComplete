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

    public class radnikupdateredundancy
    {
        private int AV2GXV414;
        private decimal AV3GXV105;
        private ReadWriteCommand cmRADNIKUpda2;
        private ReadWriteCommand cmRADNIKUpda3;
        private ReadWriteConnection connDefault;
        private DataStore dsDefault;
        private bool m__IDIPIDENTIsNull;
        private bool m__IDRADNIKIsNull;
        private bool m__KOEFICIJENTIsNull;
        private int m_IDIPIDENT;
        private int m_IDRADNIK;
        private decimal m_KOEFICIJENT;
        private IDataReader RADNIKUpda2;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;

        public event ReorganizationMessageEventHandler messageHandlerEvent;

        public radnikupdateredundancy(ref DataStore ds)
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

        public void execute(int aP0_IDRADNIK)
        {
            this.m_IDRADNIK = aP0_IDRADNIK;
            this.Initialize();
            this.executePrivate();
        }

        public void executePrivate()
        {
            this.cmRADNIKUpda2 = this.connDefault.GetCommand("SELECT [IDRADNIK], [KOEFICIJENT], [IDIPIDENT] FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ORDER BY [IDRADNIK] ", false);
            if (this.cmRADNIKUpda2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKUpda2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmRADNIKUpda2.SetParameter(0, this.m_IDRADNIK, this.m__IDRADNIKIsNull);
            this.cmRADNIKUpda2.ErrorMask |= ErrorMask.Lock;
            this.RADNIKUpda2 = this.cmRADNIKUpda2.FetchData();
            while (this.cmRADNIKUpda2.HasMoreRows)
            {
                this.m_KOEFICIJENT = this.dsDefault.Db.GetDecimal(this.RADNIKUpda2, 1, ref this.m__KOEFICIJENTIsNull);
                this.m_IDIPIDENT = this.dsDefault.Db.GetInt32(this.RADNIKUpda2, 2, ref this.m__IDIPIDENTIsNull);
                this.AV3GXV105 = this.m_KOEFICIJENT;
                this.AV2GXV414 = this.m_IDIPIDENT;
                this.cmRADNIKUpda3 = this.connDefault.GetCommand("UPDATE [ObracunRadnici] SET [KOEFICIJENT]=@KOEFICIJENT, [IDIPIDENT]=@IDIPIDENT  WHERE [IDRADNIK] = @IDRADNIK", false);
                if (this.cmRADNIKUpda3.IDbCommand.Parameters.Count == 0)
                {
                    this.cmRADNIKUpda3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KOEFICIJENT", DbType.Decimal));
                    this.cmRADNIKUpda3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
                    this.cmRADNIKUpda3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                }
                this.cmRADNIKUpda3.SetParameter(0, this.AV3GXV105, this.m__KOEFICIJENTIsNull);
                this.cmRADNIKUpda3.SetParameter(1, this.AV2GXV414, this.m__IDIPIDENTIsNull);
                this.cmRADNIKUpda3.SetParameter(2, this.m_IDRADNIK, this.m__IDRADNIKIsNull);
                this.cmRADNIKUpda3.ExecuteStmt();
                break;
            }
            this.RADNIKUpda2.Close();
            this.Cleanup();
        }

        public void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m__IDRADNIKIsNull = false;
            this.m__KOEFICIJENTIsNull = false;
            this.m_KOEFICIJENT = new decimal();
            this.m__IDIPIDENTIsNull = false;
            this.m_IDIPIDENT = 0;
            this.AV3GXV105 = new decimal();
            this.AV2GXV414 = 0;
        }
    }
}

