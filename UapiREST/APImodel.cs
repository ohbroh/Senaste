using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapiREST
{
    //public class Rootobject1
    //{
    //    //public Class1[] Property1 { get; set; }
    //    //public Result[] result { get; set; }'
    //    public Rootobject Items { get; set; }
    //}


    public class Rootobject
    {
        //public Class1[] Property1 { get; set; }
        //public List<Class1> Item322A { get; set; }
        //public Dictionary<string, List<Class12>> Items { get; set; }


        //public Result[] result { get; set; }'
        //public List<Class1> addResults { get; set; }
    }


    //public class Class1
    //{
    //    [JsonProperty(PropertyName = "companyId")]
    //    public string companyId { get; set; }
    //    [JsonProperty(PropertyName = "companyName")]
    //    public string companyName { get; set; }


    public class Class12
    {
        public string companyId { get; set; }

        public string companyName { get; set; }
        public string companyRegistrationNumber { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public int currentAccountingPeriod { get; set; }
        public string employerId { get; set; }
        public string languageCode { get; set; }
        //public int maximumPaymentDifference { get; set; }
        //public int maximumTransactionDifference { get; set; }
        //public string municipal { get; set; }
        //public int numberOfPeriods { get; set; }
        //public int overrun { get; set; }
        //public string payReference { get; set; }
        //public string remindReference { get; set; }
        //public string systemSetupCode { get; set; }
        //public string taxOfficeName { get; set; }
        //public string taxOfficeReference { get; set; }
        //public string taxSystem { get; set; }
        //public string vatRegistrationNumber { get; set; }
        //public Multicompanyinformation multiCompanyInformation { get; set; }
        //public Accounting accounting { get; set; }
        //public Currencyinformation currencyInformation { get; set; }
        //public Vatinformation vatInformation { get; set; }
        //public Contactpoint[] contactPoints { get; set; }
        //public Lastupdated lastUpdated { get; set; }
    }

    public class Multicompanyinformation
    {
        public string currencyCompanyId { get; set; }
        public string headOffice { get; set; }
        public string legalActingCompanyId { get; set; }
        public string remittanceCompanyId { get; set; }
    }

    public class Accounting
    {
        public string amount3BalanceAccount { get; set; }
        public string amount4BalanceAccount { get; set; }
        public string balancingAttributeAccount { get; set; }
        public string costCapitalisation { get; set; }
        public string differenceAccount { get; set; }
        public string exchangeGainAccount { get; set; }
        public string exchangeLossAccount { get; set; }
        public string incomeCapitalisationAccount { get; set; }
        public string invoiceFee { get; set; }
        public string paymentDifferenceGain { get; set; }
        public string paymentDifferenceLoss { get; set; }
        public string reversedPaymentAccount { get; set; }
        public string undeclaredVatAccount { get; set; }
    }

    public class Currencyinformation
    {
        public string amount3Currency { get; set; }
        public string amount3DifferenceAccount { get; set; }
        public int amount3MaxTransactionDifference { get; set; }
        public string amount4Currency { get; set; }
        public string amount4DifferenceAccount { get; set; }
        public int amount4MaxTransactionDifference { get; set; }
        public string balanceAttribute { get; set; }
        public string currencyCode { get; set; }
        public bool currencySplit { get; set; }
        public string currencyType { get; set; }
        public string triangulationCurrency { get; set; }
    }

    public class Vatinformation
    {
        public bool reverseVatWhenDiscountAp { get; set; }
        public bool reverseVatWhenDiscountAr { get; set; }
        public string undeclVatForAp { get; set; }
        public string undeclVatForApNotes { get; set; }
        public string undeclVatForAr { get; set; }
        public string undeclVatForArNotes { get; set; }
    }

    public class Lastupdated
    {
        public DateTime updatedAt { get; set; }
        public string updatedBy { get; set; }
    }

    public class Contactpoint
    {
        public string contactPointType { get; set; }
        public Address address { get; set; }
        public Phonenumbers phoneNumbers { get; set; }
        public Additionalcontactinfo additionalContactInfo { get; set; }
        public Lastupdated1 lastUpdated { get; set; }
    }

    public class Address
    {
        public string countryCode { get; set; }
        public string place { get; set; }
        public string postcode { get; set; }
        public string province { get; set; }
        public string streetAddress { get; set; }
    }

    public class Phonenumbers
    {
        public string telephone1 { get; set; }
        public string telephone2 { get; set; }
        public string telephone3 { get; set; }
        public string telephone4 { get; set; }
        public string telephone5 { get; set; }
        public string telephone6 { get; set; }
        public string telephone7 { get; set; }
    }

    public class Additionalcontactinfo
    {
        public string contactPerson { get; set; }
        public string contactPosition { get; set; }
        public string eMail { get; set; }
        public string eMailCc { get; set; }
        public string gtin { get; set; }
        public string url { get; set; }
    }

    public class Lastupdated1
    {
        public DateTime updatedAt { get; set; }
        public string updatedBy { get; set; }
    }

}
