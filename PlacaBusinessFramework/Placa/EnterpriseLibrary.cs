namespace Placa
{
    using Deklarit.EnterpriseLibrary.Security.Configuration.Cryptography;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.VisualBasic.CompilerServices;
    using System;

    public class EnterpriseLibrary
    {
        public static EnterpriseLibrary Instance = new EnterpriseLibrary();
        private IConfigurationSource m_ConfigurationContext;
        private object m_ConfigurationContextLock = System.Runtime.CompilerServices.RuntimeHelpers.GetObjectValue(new object());
        private string m_ConfigurationFile;

        private EnterpriseLibrary()
        {
        }

        public bool CompareHash(byte[] plainText, byte[] hashedText)
        {
            return Cryptographer.CompareHash("HashProvider", plainText, hashedText, this.ConfigurationContext);
        }

        public bool CompareHash(string plainText, string hashedText)
        {
            return Cryptographer.CompareHash("HashProvider", plainText, hashedText, this.ConfigurationContext);
        }

        public byte[] CreateHash(byte[] value)
        {
            return Cryptographer.CreateHash("HashProvider", value, this.ConfigurationContext);
        }

        public string CreateHash(string value)
        {
            return Cryptographer.CreateHash("HashProvider", value, this.ConfigurationContext);
        }

        public string DecryptSymmetric(string value)
        {
            return Cryptographer.DecryptSymmetric("EncryptionProvider", value, this.ConfigurationContext);
        }

        public byte[] DecryptSymmetric(byte[] value)
        {
            return Cryptographer.DecryptSymmetric("EncryptionProvider", value, this.ConfigurationContext);
        }

        public string EncryptSymmetric(string value)
        {
            return Cryptographer.EncryptSymmetric("EncryptionProvider", value, this.ConfigurationContext);
        }

        public byte[] EncryptSymmetric(byte[] value)
        {
            return Cryptographer.EncryptSymmetric("EncryptionProvider", value, this.ConfigurationContext);
        }

        public IConfigurationSource ConfigurationContext
        {
            get
            {
                if (this.m_ConfigurationContext == null)
                {
                    object configurationContextLock = this.m_ConfigurationContextLock;
                    ObjectFlowControl.CheckForSyncLockOnValueType(configurationContextLock);
                    lock (configurationContextLock)
                    {
                        if (this.m_ConfigurationContext == null)
                        {
                            if (this.m_ConfigurationFile == null)
                            {
                                this.m_ConfigurationContext = ConfigurationSourceFactory.Create();
                            }
                            else
                            {
                                this.m_ConfigurationContext = new FileConfigurationSource(this.m_ConfigurationFile);
                            }
                        }
                    }
                }
                return this.m_ConfigurationContext;
            }
            set
            {
                this.m_ConfigurationContext = value;
            }
        }

        public string ConfigurationFile
        {
            get
            {
                return this.m_ConfigurationFile;
            }
            set
            {
                if (this.m_ConfigurationFile != value)
                {
                    this.m_ConfigurationFile = value;
                    this.m_ConfigurationContext = null;
                }
            }
        }
    }
}

