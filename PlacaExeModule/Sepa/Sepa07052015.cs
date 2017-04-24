using System.Xml.Serialization;

namespace Sepa07052015
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03", IsNullable = false)]
    public partial class Document
    {

        private CustomerCreditTransferInitiationV03 cstmrCdtTrfInitnField;

        /// <remarks/>
        public CustomerCreditTransferInitiationV03 CstmrCdtTrfInitn
        {
            get
            {
                return this.cstmrCdtTrfInitnField;
            }
            set
            {
                this.cstmrCdtTrfInitnField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class CustomerCreditTransferInitiationV03
    {

        private GroupHeader32 grpHdrField;

        private PaymentInstructionInformation3[] pmtInfField;

        /// <remarks/>
        public GroupHeader32 GrpHdr
        {
            get
            {
                return this.grpHdrField;
            }
            set
            {
                this.grpHdrField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PmtInf")]
        public PaymentInstructionInformation3[] PmtInf
        {
            get
            {
                return this.pmtInfField;
            }
            set
            {
                this.pmtInfField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class GroupHeader32
    {

        private string msgIdField;

        private System.String creDtTmField;

        private string nbOfTxsField;

        private decimal ctrlSumField;

        private bool ctrlSumFieldSpecified;

        private PartyIdentification32_1 initgPtyField;

        /// <remarks/>
        public string MsgId
        {
            get
            {
                return this.msgIdField;
            }
            set
            {
                this.msgIdField = value;
            }
        }

        /// <remarks/>
        public System.String CreDtTm
        {
            get
            {
                return this.creDtTmField;
            }
            set
            {
                this.creDtTmField = value;
            }
        }

        /// <remarks/>
        public string NbOfTxs
        {
            get
            {
                return this.nbOfTxsField;
            }
            set
            {
                this.nbOfTxsField = value;
            }
        }

        /// <remarks/>
        public decimal CtrlSum
        {
            get
            {
                return this.ctrlSumField;
            }
            set
            {
                this.ctrlSumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CtrlSumSpecified
        {
            get
            {
                return this.ctrlSumFieldSpecified;
            }
            set
            {
                this.ctrlSumFieldSpecified = value;
            }
        }

        /// <remarks/>
        public PartyIdentification32_1 InitgPty
        {
            get
            {
                return this.initgPtyField;
            }
            set
            {
                this.initgPtyField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class PartyIdentification32_1
    {

        private string nmField;

        private Party6Choice idField;

        /// <remarks/>
        public string Nm
        {
            get
            {
                return this.nmField;
            }
            set
            {
                this.nmField = value;
            }
        }

        /// <remarks/>
        public Party6Choice Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class Party6Choice
    {

        private object itemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrgId", typeof(OrganisationIdentification4))]
        [System.Xml.Serialization.XmlElementAttribute("PrvtId", typeof(PersonIdentification5))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class OrganisationIdentification4
    {

        private object itemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BICOrBEI", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("Othr", typeof(GenericOrganisationIdentification1))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class GenericOrganisationIdentification1
    {

        private string idField;

        private OrganisationIdentificationSchemeName1Choice schmeNmField;

        private string issrField;

        /// <remarks/>
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public OrganisationIdentificationSchemeName1Choice SchmeNm
        {
            get
            {
                return this.schmeNmField;
            }
            set
            {
                this.schmeNmField = value;
            }
        }

        /// <remarks/>
        public string Issr
        {
            get
            {
                return this.issrField;
            }
            set
            {
                this.issrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class OrganisationIdentificationSchemeName1Choice
    {

        private string itemField;

        private ItemChoiceType itemElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Cd", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("Prtry", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType ItemElementName
        {
            get
            {
                return this.itemElementNameField;
            }
            set
            {
                this.itemElementNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03", IncludeInSchema = false)]
    public enum ItemChoiceType
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class CreditorReferenceType1Choice
    {

        private DocumentType3Code cdField;

        /// <remarks/>
        public DocumentType3Code Cd
        {
            get
            {
                return this.cdField;
            }
            set
            {
                this.cdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public enum DocumentType3Code
    {

        /// <remarks/>
        SCOR,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class CreditorReferenceType2
    {

        private CreditorReferenceType1Choice cdOrPrtryField;

        private string issrField;

        /// <remarks/>
        public CreditorReferenceType1Choice CdOrPrtry
        {
            get
            {
                return this.cdOrPrtryField;
            }
            set
            {
                this.cdOrPrtryField = value;
            }
        }

        /// <remarks/>
        public string Issr
        {
            get
            {
                return this.issrField;
            }
            set
            {
                this.issrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class CreditorReferenceInformation2
    {

        private CreditorReferenceType2 tpField;

        private string refField;

        /// <remarks/>
        public CreditorReferenceType2 Tp
        {
            get
            {
                return this.tpField;
            }
            set
            {
                this.tpField = value;
            }
        }

        /// <remarks/>
        public string Ref
        {
            get
            {
                return this.refField;
            }
            set
            {
                this.refField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class StructuredRemittanceInformation7
    {

        private CreditorReferenceInformation2 cdtrRefInfField;

        private string addtlRmtInfField;

        /// <remarks/>
        public CreditorReferenceInformation2 CdtrRefInf
        {
            get
            {
                return this.cdtrRefInfField;
            }
            set
            {
                this.cdtrRefInfField = value;
            }
        }

        /// <remarks/>
        public string AddtlRmtInf
        {
            get
            {
                return this.addtlRmtInfField;
            }
            set
            {
                this.addtlRmtInfField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class RemittanceInformation5
    {

        private object itemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Strd", typeof(StructuredRemittanceInformation7))]
        [System.Xml.Serialization.XmlElementAttribute("Ustrd", typeof(string))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class Purpose2Choice
    {

        private string cdField;

        /// <remarks/>
        public string Cd
        {
            get
            {
                return this.cdField;
            }
            set
            {
                this.cdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class GenericAccountIdentification1
    {

        private string idField;

        /// <remarks/>
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class AccountIdentification4Choice_2
    {

        private object itemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IBAN", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("Othr", typeof(GenericAccountIdentification1))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class CashAccount16_2
    {

        private AccountIdentification4Choice_2 idField;

        /// <remarks/>
        public AccountIdentification4Choice_2 Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class ClearingSystemMemberIdentification2
    {

        private string mmbIdField;

        /// <remarks/>
        public string MmbId
        {
            get
            {
                return this.mmbIdField;
            }
            set
            {
                this.mmbIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class FinancialInstitutionIdentification7_2
    {

        private string bICField;

        private ClearingSystemMemberIdentification2 clrSysMmbIdField;

        private string nmField;

        private PostalAddress6 pstlAdrField;

        /// <remarks/>
        public string BIC
        {
            get
            {
                return this.bICField;
            }
            set
            {
                this.bICField = value;
            }
        }

        /// <remarks/>
        public ClearingSystemMemberIdentification2 ClrSysMmbId
        {
            get
            {
                return this.clrSysMmbIdField;
            }
            set
            {
                this.clrSysMmbIdField = value;
            }
        }

        /// <remarks/>
        public string Nm
        {
            get
            {
                return this.nmField;
            }
            set
            {
                this.nmField = value;
            }
        }

        /// <remarks/>
        public PostalAddress6 PstlAdr
        {
            get
            {
                return this.pstlAdrField;
            }
            set
            {
                this.pstlAdrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class PostalAddress6
    {

        private string ctryField;

        private string[] adrLineField;

        /// <remarks/>
        public string Ctry
        {
            get
            {
                return this.ctryField;
            }
            set
            {
                this.ctryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AdrLine")]
        public string[] AdrLine
        {
            get
            {
                return this.adrLineField;
            }
            set
            {
                this.adrLineField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class BranchAndFinancialInstitutionIdentification4_2
    {

        private FinancialInstitutionIdentification7_2 finInstnIdField;

        /// <remarks/>
        public FinancialInstitutionIdentification7_2 FinInstnId
        {
            get
            {
                return this.finInstnIdField;
            }
            set
            {
                this.finInstnIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class ActiveOrHistoricCurrencyAndAmount
    {

        private string ccyField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Ccy
        {
            get
            {
                return this.ccyField;
            }
            set
            {
                this.ccyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class AmountType3Choice
    {

        private ActiveOrHistoricCurrencyAndAmount instdAmtField;

        /// <remarks/>
        public ActiveOrHistoricCurrencyAndAmount InstdAmt
        {
            get
            {
                return this.instdAmtField;
            }
            set
            {
                this.instdAmtField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class PaymentTypeInformation19_2
    {

        private ServiceLevel8Choice svcLvlField;

        private LocalInstrument2Choice lclInstrmField;

        private CategoryPurpose1Choice ctgyPurpField;

        /// <remarks/>
        public ServiceLevel8Choice SvcLvl
        {
            get
            {
                return this.svcLvlField;
            }
            set
            {
                this.svcLvlField = value;
            }
        }

        /// <remarks/>
        public LocalInstrument2Choice LclInstrm
        {
            get
            {
                return this.lclInstrmField;
            }
            set
            {
                this.lclInstrmField = value;
            }
        }

        /// <remarks/>
        public CategoryPurpose1Choice CtgyPurp
        {
            get
            {
                return this.ctgyPurpField;
            }
            set
            {
                this.ctgyPurpField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class ServiceLevel8Choice
    {

        private string cdField;

        /// <remarks/>
        public string Cd
        {
            get
            {
                return this.cdField;
            }
            set
            {
                this.cdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class LocalInstrument2Choice
    {

        private string itemField;

        private ItemChoiceType2 itemElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Cd", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("Prtry", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType2 ItemElementName
        {
            get
            {
                return this.itemElementNameField;
            }
            set
            {
                this.itemElementNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03", IncludeInSchema = false)]
    public enum ItemChoiceType2
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class CategoryPurpose1Choice
    {

        private string cdField;

        /// <remarks/>
        public string Cd
        {
            get
            {
                return this.cdField;
            }
            set
            {
                this.cdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class PaymentIdentification1
    {

        private string instrIdField;

        private string endToEndIdField;

        /// <remarks/>
        public string InstrId
        {
            get
            {
                return this.instrIdField;
            }
            set
            {
                this.instrIdField = value;
            }
        }

        /// <remarks/>
        public string EndToEndId
        {
            get
            {
                return this.endToEndIdField;
            }
            set
            {
                this.endToEndIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class CreditTransferTransactionInformation10
    {

        private PaymentIdentification1 pmtIdField;

        private PaymentTypeInformation19_2 pmtTpInfField;

        private AmountType3Choice amtField;

        private ChargeBearerType1Code chrgBrField;

        private bool chrgBrFieldSpecified;

        private PartyIdentification32_1 ultmtDbtrField;

        private BranchAndFinancialInstitutionIdentification4_2 cdtrAgtField;

        private PartyIdentification32_2 cdtrField;

        private CashAccount16_2 cdtrAcctField;

        private PartyIdentification32_1 ultmtCdtrField;

        private Purpose2Choice purpField;

        private RemittanceInformation5 rmtInfField;

        /// <remarks/>
        public PaymentIdentification1 PmtId
        {
            get
            {
                return this.pmtIdField;
            }
            set
            {
                this.pmtIdField = value;
            }
        }

        /// <remarks/>
        public PaymentTypeInformation19_2 PmtTpInf
        {
            get
            {
                return this.pmtTpInfField;
            }
            set
            {
                this.pmtTpInfField = value;
            }
        }

        /// <remarks/>
        public AmountType3Choice Amt
        {
            get
            {
                return this.amtField;
            }
            set
            {
                this.amtField = value;
            }
        }

        /// <remarks/>
        public ChargeBearerType1Code ChrgBr
        {
            get
            {
                return this.chrgBrField;
            }
            set
            {
                this.chrgBrField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChrgBrSpecified
        {
            get
            {
                return this.chrgBrFieldSpecified;
            }
            set
            {
                this.chrgBrFieldSpecified = value;
            }
        }

        /// <remarks/>
        public PartyIdentification32_1 UltmtDbtr
        {
            get
            {
                return this.ultmtDbtrField;
            }
            set
            {
                this.ultmtDbtrField = value;
            }
        }

        /// <remarks/>
        public BranchAndFinancialInstitutionIdentification4_2 CdtrAgt
        {
            get
            {
                return this.cdtrAgtField;
            }
            set
            {
                this.cdtrAgtField = value;
            }
        }

        /// <remarks/>
        public PartyIdentification32_2 Cdtr
        {
            get
            {
                return this.cdtrField;
            }
            set
            {
                this.cdtrField = value;
            }
        }

        /// <remarks/>
        public CashAccount16_2 CdtrAcct
        {
            get
            {
                return this.cdtrAcctField;
            }
            set
            {
                this.cdtrAcctField = value;
            }
        }

        /// <remarks/>
        public PartyIdentification32_1 UltmtCdtr
        {
            get
            {
                return this.ultmtCdtrField;
            }
            set
            {
                this.ultmtCdtrField = value;
            }
        }

        /// <remarks/>
        public Purpose2Choice Purp
        {
            get
            {
                return this.purpField;
            }
            set
            {
                this.purpField = value;
            }
        }

        /// <remarks/>
        public RemittanceInformation5 RmtInf
        {
            get
            {
                return this.rmtInfField;
            }
            set
            {
                this.rmtInfField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public enum ChargeBearerType1Code
    {

        /// <remarks/>
        DEBT,

        /// <remarks/>
        CRED,

        /// <remarks/>
        SHAR,

        /// <remarks/>
        SLEV,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class PartyIdentification32_2
    {

        private string nmField;

        private PostalAddress6 pstlAdrField;

        private Party6Choice idField;

        /// <remarks/>
        public string Nm
        {
            get
            {
                return this.nmField;
            }
            set
            {
                this.nmField = value;
            }
        }

        /// <remarks/>
        public PostalAddress6 PstlAdr
        {
            get
            {
                return this.pstlAdrField;
            }
            set
            {
                this.pstlAdrField = value;
            }
        }

        /// <remarks/>
        public Party6Choice Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class GenericFinancialIdentification1
    {

        private Max35Text_NP idField;

        /// <remarks/>
        public Max35Text_NP Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public enum Max35Text_NP
    {

        /// <remarks/>
        NOTPROVIDED,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class FinancialInstitutionIdentification7_1
    {

        private object itemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BIC", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("Othr", typeof(GenericFinancialIdentification1))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class BranchAndFinancialInstitutionIdentification4_1
    {

        private FinancialInstitutionIdentification7_1 finInstnIdField;

        /// <remarks/>
        public FinancialInstitutionIdentification7_1 FinInstnId
        {
            get
            {
                return this.finInstnIdField;
            }
            set
            {
                this.finInstnIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class AccountIdentification4Choice_HR
    {

        private string iBANField;

        /// <remarks/>
        public string IBAN
        {
            get
            {
                return this.iBANField;
            }
            set
            {
                this.iBANField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class CashAccount16_HR
    {

        private AccountIdentification4Choice_HR idField;

        private string ccyField;

        /// <remarks/>
        public AccountIdentification4Choice_HR Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string Ccy
        {
            get
            {
                return this.ccyField;
            }
            set
            {
                this.ccyField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class PaymentTypeInformation19_1
    {

        private Priority2Code instrPrtyField;

        private bool instrPrtyFieldSpecified;

        private ServiceLevel8Choice svcLvlField;

        private LocalInstrument2Choice lclInstrmField;

        private CategoryPurpose1Choice ctgyPurpField;

        /// <remarks/>
        public Priority2Code InstrPrty
        {
            get
            {
                return this.instrPrtyField;
            }
            set
            {
                this.instrPrtyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InstrPrtySpecified
        {
            get
            {
                return this.instrPrtyFieldSpecified;
            }
            set
            {
                this.instrPrtyFieldSpecified = value;
            }
        }

        /// <remarks/>
        public ServiceLevel8Choice SvcLvl
        {
            get
            {
                return this.svcLvlField;
            }
            set
            {
                this.svcLvlField = value;
            }
        }

        /// <remarks/>
        public LocalInstrument2Choice LclInstrm
        {
            get
            {
                return this.lclInstrmField;
            }
            set
            {
                this.lclInstrmField = value;
            }
        }

        /// <remarks/>
        public CategoryPurpose1Choice CtgyPurp
        {
            get
            {
                return this.ctgyPurpField;
            }
            set
            {
                this.ctgyPurpField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public enum Priority2Code
    {

        /// <remarks/>
        HIGH,

        /// <remarks/>
        NORM,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class PaymentInstructionInformation3
    {

        private string pmtInfIdField;

        private PaymentMethod3Code pmtMtdField;

        private bool btchBookgField;

        private bool btchBookgFieldSpecified;

        private string nbOfTxsField;

        private decimal ctrlSumField;

        private bool ctrlSumFieldSpecified;

        private PaymentTypeInformation19_1 pmtTpInfField;

        private System.DateTime reqdExctnDtField;

        private PartyIdentification32_2 dbtrField;

        private CashAccount16_HR dbtrAcctField;

        private BranchAndFinancialInstitutionIdentification4_1 dbtrAgtField;

        private PartyIdentification32_1 ultmtDbtrField;

        private ChargeBearerType1Code chrgBrField;

        private bool chrgBrFieldSpecified;

        private CreditTransferTransactionInformation10[] cdtTrfTxInfField;

        /// <remarks/>
        public string PmtInfId
        {
            get
            {
                return this.pmtInfIdField;
            }
            set
            {
                this.pmtInfIdField = value;
            }
        }

        /// <remarks/>
        public PaymentMethod3Code PmtMtd
        {
            get
            {
                return this.pmtMtdField;
            }
            set
            {
                this.pmtMtdField = value;
            }
        }

        /// <remarks/>
        public bool BtchBookg
        {
            get
            {
                return this.btchBookgField;
            }
            set
            {
                this.btchBookgField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BtchBookgSpecified
        {
            get
            {
                return this.btchBookgFieldSpecified;
            }
            set
            {
                this.btchBookgFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string NbOfTxs
        {
            get
            {
                return this.nbOfTxsField;
            }
            set
            {
                this.nbOfTxsField = value;
            }
        }

        /// <remarks/>
        public decimal CtrlSum
        {
            get
            {
                return this.ctrlSumField;
            }
            set
            {
                this.ctrlSumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CtrlSumSpecified
        {
            get
            {
                return this.ctrlSumFieldSpecified;
            }
            set
            {
                this.ctrlSumFieldSpecified = value;
            }
        }

        /// <remarks/>
        public PaymentTypeInformation19_1 PmtTpInf
        {
            get
            {
                return this.pmtTpInfField;
            }
            set
            {
                this.pmtTpInfField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime ReqdExctnDt
        {
            get
            {
                return this.reqdExctnDtField;
            }
            set
            {
                this.reqdExctnDtField = value;
            }
        }

        /// <remarks/>
        public PartyIdentification32_2 Dbtr
        {
            get
            {
                return this.dbtrField;
            }
            set
            {
                this.dbtrField = value;
            }
        }

        /// <remarks/>
        public CashAccount16_HR DbtrAcct
        {
            get
            {
                return this.dbtrAcctField;
            }
            set
            {
                this.dbtrAcctField = value;
            }
        }

        /// <remarks/>
        public BranchAndFinancialInstitutionIdentification4_1 DbtrAgt
        {
            get
            {
                return this.dbtrAgtField;
            }
            set
            {
                this.dbtrAgtField = value;
            }
        }

        /// <remarks/>
        public PartyIdentification32_1 UltmtDbtr
        {
            get
            {
                return this.ultmtDbtrField;
            }
            set
            {
                this.ultmtDbtrField = value;
            }
        }

        /// <remarks/>
        public ChargeBearerType1Code ChrgBr
        {
            get
            {
                return this.chrgBrField;
            }
            set
            {
                this.chrgBrField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChrgBrSpecified
        {
            get
            {
                return this.chrgBrFieldSpecified;
            }
            set
            {
                this.chrgBrFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CdtTrfTxInf")]
        public CreditTransferTransactionInformation10[] CdtTrfTxInf
        {
            get
            {
                return this.cdtTrfTxInfField;
            }
            set
            {
                this.cdtTrfTxInfField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public enum PaymentMethod3Code
    {

        /// <remarks/>
        TRF,

        /// <remarks/>
        CHK,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class PersonIdentificationSchemeName1Choice
    {

        private string itemField;

        private ItemChoiceType1 itemElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Cd", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("Prtry", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType1 ItemElementName
        {
            get
            {
                return this.itemElementNameField;
            }
            set
            {
                this.itemElementNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03", IncludeInSchema = false)]
    public enum ItemChoiceType1
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class GenericPersonIdentification1
    {

        private string idField;

        private PersonIdentificationSchemeName1Choice schmeNmField;

        private string issrField;

        /// <remarks/>
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public PersonIdentificationSchemeName1Choice SchmeNm
        {
            get
            {
                return this.schmeNmField;
            }
            set
            {
                this.schmeNmField = value;
            }
        }

        /// <remarks/>
        public string Issr
        {
            get
            {
                return this.issrField;
            }
            set
            {
                this.issrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class DateAndPlaceOfBirth
    {

        private System.DateTime birthDtField;

        private string prvcOfBirthField;

        private string cityOfBirthField;

        private string ctryOfBirthField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime BirthDt
        {
            get
            {
                return this.birthDtField;
            }
            set
            {
                this.birthDtField = value;
            }
        }

        /// <remarks/>
        public string PrvcOfBirth
        {
            get
            {
                return this.prvcOfBirthField;
            }
            set
            {
                this.prvcOfBirthField = value;
            }
        }

        /// <remarks/>
        public string CityOfBirth
        {
            get
            {
                return this.cityOfBirthField;
            }
            set
            {
                this.cityOfBirthField = value;
            }
        }

        /// <remarks/>
        public string CtryOfBirth
        {
            get
            {
                return this.ctryOfBirthField;
            }
            set
            {
                this.ctryOfBirthField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:scthr:pain.001.001.03")]
    public partial class PersonIdentification5
    {

        private object itemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DtAndPlcOfBirth", typeof(DateAndPlaceOfBirth))]
        [System.Xml.Serialization.XmlElementAttribute("Othr", typeof(GenericPersonIdentification1))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }
}
