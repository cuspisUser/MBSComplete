using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.EntityClient;
using System.Data.SqlClient;

using UcenickoFakturiranje.Utils.Exceptions;
using Mipsed7.DataAccessLayer.EntityFramework;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class Base
    {
        protected Mipsed7.DataAccessLayer.EntityFramework.Entities Database { get; set; }

        public Base()
        {
            this.Database = new Entities(GetConnection());
        }

        #region DatabaseConnectionString

        public EntityConnection GetConnection()
        {
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

            sqlBuilder.DataSource = Mipsed7.Core.ApplicationDatabaseInformation.ServerName;
            sqlBuilder.InitialCatalog = Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName;
            sqlBuilder.UserID = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
            sqlBuilder.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;
            sqlBuilder.IntegratedSecurity = false;

            string providerString = sqlBuilder.ToString();

            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.Provider = "System.Data.SqlClient";
            entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
            entityBuilder.Metadata = @"res://*/EntityFramework.dbMIPSED7.csdl|res://*/EntityFramework.dbMIPSED7.ssdl|res://*/EntityFramework.dbMIPSED7.msl";

            return new EntityConnection(entityBuilder.ToString());
        }

        #endregion

        #region Validation

        /// <summary>
        /// Form validation message collection
        /// </summary>
        protected List<DataValidationException> ValidationMessages { get; set; }

        public bool IsValid { get { return this.ValidationMessages.Count == 0; } }

        /// <summary>
        /// Display validation message in form
        /// </summary>
        /// <param name="userControl"></param>
        public void DisplayValidationMessages(UserControl userControl)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (DataValidationException message in this.ValidationMessages)
            {
                // Focus only first control
                if (string.IsNullOrEmpty(stringBuilder.ToString()))
                    userControl.Controls.Find(message.ControlToFocus, true).SingleOrDefault().Focus();

                stringBuilder.AppendLine(message.Message);
            }

            ((Label)userControl.Controls.Find("lblValidationMessages", true).SingleOrDefault()).Text = stringBuilder.ToString();
        }

        /// <summary>
        /// Display validation message as message box
        /// </summary>
        public void DisplayValidationMessages()
        {
            StringBuilder stringBuilder = new StringBuilder();
                 
            foreach (DataValidationException message in this.ValidationMessages)
                stringBuilder.AppendLine(message.Message);

            if(!string.IsNullOrEmpty(stringBuilder.ToString()))
            {
                MessageBox.Show(stringBuilder.ToString(), "Obavezno polje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
