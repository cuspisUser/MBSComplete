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

    public class porezupdateredundancy
    {
        private decimal AV10GXV114;
        private decimal AV11GXV115;
        private string AV12GXV113;
        private string AV2GXV123;
        private string AV3GXV122;
        private string AV4GXV121;
        private string AV5GXV120;
        private string AV6GXV119;
        private string AV7GXV118;
        private string AV8GXV117;
        private string AV9GXV116;
        private ReadWriteCommand cmPOREZUpdat2;
        private ReadWriteCommand cmPOREZUpdat3;
        private ReadWriteCommand cmPOREZUpdat4;
        private ReadWriteConnection connDefault;
        private DataStore dsDefault;
        private bool m__IDPOREZIsNull;
        private bool m__MOPOREZIsNull;
        private bool m__MZPOREZIsNull;
        private bool m__NAZIVPOREZIsNull;
        private bool m__OPISPLACANJAPOREZIsNull;
        private bool m__POPOREZIsNull;
        private bool m__POREZMJESECNOIsNull;
        private bool m__PRIMATELJPOREZ1IsNull;
        private bool m__PRIMATELJPOREZ2IsNull;
        private bool m__PZPOREZIsNull;
        private bool m__SIFRAOPISAPLACANJAPOREZIsNull;
        private bool m__STOPAPOREZAIsNull;
        private int m_IDPOREZ;
        private string m_MOPOREZ;
        private string m_MZPOREZ;
        private string m_NAZIVPOREZ;
        private string m_OPISPLACANJAPOREZ;
        private string m_POPOREZ;
        private decimal m_POREZMJESECNO;
        private string m_PRIMATELJPOREZ1;
        private string m_PRIMATELJPOREZ2;
        private string m_PZPOREZ;
        private string m_SIFRAOPISAPLACANJAPOREZ;
        private decimal m_STOPAPOREZA;
        private IDataReader POREZUpdat2;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;

        public event ReorganizationMessageEventHandler messageHandlerEvent;

        public porezupdateredundancy(ref DataStore ds)
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

        public void execute(int aP0_IDPOREZ)
        {
            this.m_IDPOREZ = aP0_IDPOREZ;
            this.Initialize();
            this.executePrivate();
        }

        public void executePrivate()
        {
            this.cmPOREZUpdat2 = this.connDefault.GetCommand("SELECT [IDPOREZ], [NAZIVPOREZ], [POREZMJESECNO], [STOPAPOREZA], [MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ] FROM [POREZ] WITH (NOLOCK) WHERE [IDPOREZ] = @IDPOREZ ORDER BY [IDPOREZ] ", false);
            if (this.cmPOREZUpdat2.IDbCommand.Parameters.Count == 0)
            {
                this.cmPOREZUpdat2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            this.cmPOREZUpdat2.SetParameter(0, this.m_IDPOREZ, this.m__IDPOREZIsNull);
            this.cmPOREZUpdat2.ErrorMask |= ErrorMask.Lock;
            this.POREZUpdat2 = this.cmPOREZUpdat2.FetchData();
            while (this.cmPOREZUpdat2.HasMoreRows)
            {
                this.m_NAZIVPOREZ = this.dsDefault.Db.GetString(this.POREZUpdat2, 1, ref this.m__NAZIVPOREZIsNull);
                this.m_POREZMJESECNO = this.dsDefault.Db.GetDecimal(this.POREZUpdat2, 2, ref this.m__POREZMJESECNOIsNull);
                this.m_STOPAPOREZA = this.dsDefault.Db.GetDecimal(this.POREZUpdat2, 3, ref this.m__STOPAPOREZAIsNull);
                this.m_MOPOREZ = this.dsDefault.Db.GetString(this.POREZUpdat2, 4, ref this.m__MOPOREZIsNull);
                this.m_POPOREZ = this.dsDefault.Db.GetString(this.POREZUpdat2, 5, ref this.m__POPOREZIsNull);
                this.m_MZPOREZ = this.dsDefault.Db.GetString(this.POREZUpdat2, 6, ref this.m__MZPOREZIsNull);
                this.m_PZPOREZ = this.dsDefault.Db.GetString(this.POREZUpdat2, 7, ref this.m__PZPOREZIsNull);
                this.m_PRIMATELJPOREZ1 = this.dsDefault.Db.GetString(this.POREZUpdat2, 8, ref this.m__PRIMATELJPOREZ1IsNull);
                this.m_PRIMATELJPOREZ2 = this.dsDefault.Db.GetString(this.POREZUpdat2, 9, ref this.m__PRIMATELJPOREZ2IsNull);
                this.m_SIFRAOPISAPLACANJAPOREZ = this.dsDefault.Db.GetString(this.POREZUpdat2, 10, ref this.m__SIFRAOPISAPLACANJAPOREZIsNull);
                this.m_OPISPLACANJAPOREZ = this.dsDefault.Db.GetString(this.POREZUpdat2, 11, ref this.m__OPISPLACANJAPOREZIsNull);
                this.AV12GXV113 = this.m_NAZIVPOREZ;
                this.AV11GXV115 = this.m_POREZMJESECNO;
                this.AV10GXV114 = this.m_STOPAPOREZA;
                this.AV9GXV116 = this.m_MOPOREZ;
                this.AV8GXV117 = this.m_POPOREZ;
                this.AV7GXV118 = this.m_MZPOREZ;
                this.AV6GXV119 = this.m_PZPOREZ;
                this.AV5GXV120 = this.m_PRIMATELJPOREZ1;
                this.AV4GXV121 = this.m_PRIMATELJPOREZ2;
                this.AV3GXV122 = this.m_SIFRAOPISAPLACANJAPOREZ;
                this.AV2GXV123 = this.m_OPISPLACANJAPOREZ;
                this.cmPOREZUpdat3 = this.connDefault.GetCommand("UPDATE [ObracunPorezi] SET [NAZIVPOREZ]=@NAZIVPOREZ, [POREZMJESECNO]=@POREZMJESECNO, [STOPAPOREZA]=@STOPAPOREZA, [MOPOREZ]=@MOPOREZ, [POPOREZ]=@POPOREZ, [MZPOREZ]=@MZPOREZ, [PZPOREZ]=@PZPOREZ, [PRIMATELJPOREZ1]=@PRIMATELJPOREZ1, [PRIMATELJPOREZ2]=@PRIMATELJPOREZ2, [SIFRAOPISAPLACANJAPOREZ]=@SIFRAOPISAPLACANJAPOREZ, [OPISPLACANJAPOREZ]=@OPISPLACANJAPOREZ  WHERE [IDPOREZ] = @IDPOREZ", false);
                if (this.cmPOREZUpdat3.IDbCommand.Parameters.Count == 0)
                {
                    this.cmPOREZUpdat3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPOREZ", DbType.String, 50));
                    this.cmPOREZUpdat3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POREZMJESECNO", DbType.Currency));
                    this.cmPOREZUpdat3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STOPAPOREZA", DbType.Currency));
                    this.cmPOREZUpdat3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOPOREZ", DbType.String, 2));
                    this.cmPOREZUpdat3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POPOREZ", DbType.String, 0x16));
                    this.cmPOREZUpdat3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZPOREZ", DbType.String, 2));
                    this.cmPOREZUpdat3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZPOREZ", DbType.String, 0x16));
                    this.cmPOREZUpdat3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJPOREZ1", DbType.String, 20));
                    this.cmPOREZUpdat3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJPOREZ2", DbType.String, 20));
                    this.cmPOREZUpdat3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAPOREZ", DbType.String, 2));
                    this.cmPOREZUpdat3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAPOREZ", DbType.String, 0x24));
                    this.cmPOREZUpdat3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
                }
                this.cmPOREZUpdat3.SetParameter(0, this.AV12GXV113, this.m__NAZIVPOREZIsNull);
                this.cmPOREZUpdat3.SetParameter(1, this.AV11GXV115, this.m__POREZMJESECNOIsNull);
                this.cmPOREZUpdat3.SetParameter(2, this.AV10GXV114, this.m__STOPAPOREZAIsNull);
                this.cmPOREZUpdat3.SetParameter(3, this.AV9GXV116, this.m__MOPOREZIsNull);
                this.cmPOREZUpdat3.SetParameter(4, this.AV8GXV117, this.m__POPOREZIsNull);
                this.cmPOREZUpdat3.SetParameter(5, this.AV7GXV118, this.m__MZPOREZIsNull);
                this.cmPOREZUpdat3.SetParameter(6, this.AV6GXV119, this.m__PZPOREZIsNull);
                this.cmPOREZUpdat3.SetParameter(7, this.AV5GXV120, this.m__PRIMATELJPOREZ1IsNull);
                this.cmPOREZUpdat3.SetParameter(8, this.AV4GXV121, this.m__PRIMATELJPOREZ2IsNull);
                this.cmPOREZUpdat3.SetParameter(9, this.AV3GXV122, this.m__SIFRAOPISAPLACANJAPOREZIsNull);
                this.cmPOREZUpdat3.SetParameter(10, this.AV2GXV123, this.m__OPISPLACANJAPOREZIsNull);
                this.cmPOREZUpdat3.SetParameter(11, this.m_IDPOREZ, this.m__IDPOREZIsNull);
                this.cmPOREZUpdat3.ExecuteStmt();
                this.cmPOREZUpdat4 = this.connDefault.GetCommand("UPDATE [DDOBRACUNRadniciPorezi] SET [NAZIVPOREZ]=@NAZIVPOREZ, [STOPAPOREZA]=@STOPAPOREZA, [MZPOREZ]=@MZPOREZ, [PZPOREZ]=@PZPOREZ, [PRIMATELJPOREZ1]=@PRIMATELJPOREZ1, [PRIMATELJPOREZ2]=@PRIMATELJPOREZ2, [SIFRAOPISAPLACANJAPOREZ]=@SIFRAOPISAPLACANJAPOREZ, [OPISPLACANJAPOREZ]=@OPISPLACANJAPOREZ  WHERE [IDPOREZ] = @IDPOREZ", false);
                if (this.cmPOREZUpdat4.IDbCommand.Parameters.Count == 0)
                {
                    this.cmPOREZUpdat4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPOREZ", DbType.String, 50));
                    this.cmPOREZUpdat4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STOPAPOREZA", DbType.Currency));
                    this.cmPOREZUpdat4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZPOREZ", DbType.String, 2));
                    this.cmPOREZUpdat4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZPOREZ", DbType.String, 0x16));
                    this.cmPOREZUpdat4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJPOREZ1", DbType.String, 20));
                    this.cmPOREZUpdat4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJPOREZ2", DbType.String, 20));
                    this.cmPOREZUpdat4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAPOREZ", DbType.String, 2));
                    this.cmPOREZUpdat4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAPOREZ", DbType.String, 0x24));
                    this.cmPOREZUpdat4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
                }
                this.cmPOREZUpdat4.SetParameter(0, this.AV12GXV113, this.m__NAZIVPOREZIsNull);
                this.cmPOREZUpdat4.SetParameter(1, this.AV10GXV114, this.m__STOPAPOREZAIsNull);
                this.cmPOREZUpdat4.SetParameter(2, this.AV7GXV118, this.m__MZPOREZIsNull);
                this.cmPOREZUpdat4.SetParameter(3, this.AV6GXV119, this.m__PZPOREZIsNull);
                this.cmPOREZUpdat4.SetParameter(4, this.AV5GXV120, this.m__PRIMATELJPOREZ1IsNull);
                this.cmPOREZUpdat4.SetParameter(5, this.AV4GXV121, this.m__PRIMATELJPOREZ2IsNull);
                this.cmPOREZUpdat4.SetParameter(6, this.AV3GXV122, this.m__SIFRAOPISAPLACANJAPOREZIsNull);
                this.cmPOREZUpdat4.SetParameter(7, this.AV2GXV123, this.m__OPISPLACANJAPOREZIsNull);
                this.cmPOREZUpdat4.SetParameter(8, this.m_IDPOREZ, this.m__IDPOREZIsNull);
                this.cmPOREZUpdat4.ExecuteStmt();
                break;
            }
            this.POREZUpdat2.Close();
            this.Cleanup();
        }

        public void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m__IDPOREZIsNull = false;
            this.m__NAZIVPOREZIsNull = false;
            this.m_NAZIVPOREZ = "";
            this.m__POREZMJESECNOIsNull = false;
            this.m_POREZMJESECNO = new decimal();
            this.m__STOPAPOREZAIsNull = false;
            this.m_STOPAPOREZA = new decimal();
            this.m__MOPOREZIsNull = false;
            this.m_MOPOREZ = "";
            this.m__POPOREZIsNull = false;
            this.m_POPOREZ = "";
            this.m__MZPOREZIsNull = false;
            this.m_MZPOREZ = "";
            this.m__PZPOREZIsNull = false;
            this.m_PZPOREZ = "";
            this.m__PRIMATELJPOREZ1IsNull = false;
            this.m_PRIMATELJPOREZ1 = "";
            this.m__PRIMATELJPOREZ2IsNull = false;
            this.m_PRIMATELJPOREZ2 = "";
            this.m__SIFRAOPISAPLACANJAPOREZIsNull = false;
            this.m_SIFRAOPISAPLACANJAPOREZ = "";
            this.m__OPISPLACANJAPOREZIsNull = false;
            this.m_OPISPLACANJAPOREZ = "";
            this.AV12GXV113 = "";
            this.AV11GXV115 = new decimal();
            this.AV10GXV114 = new decimal();
            this.AV9GXV116 = "";
            this.AV8GXV117 = "";
            this.AV7GXV118 = "";
            this.AV6GXV119 = "";
            this.AV5GXV120 = "";
            this.AV4GXV121 = "";
            this.AV3GXV122 = "";
            this.AV2GXV123 = "";
        }
    }
}

