using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NEXA.DataService.DataContract
{
    class MyJobCard
    {
    }
    [DataContract]
    public class JobCardListForSA
    {
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string model { get; set; }
        [DataMember]
        public string cust_name { get; set; }
        [DataMember]
        public string mobile_phone { get; set; }
        [DataMember]
        public string job_card_num { get; set; }
        [DataMember]
        public string srv_type { get; set; }
        [DataMember]
        public string jc_open_date { get; set; }
        [DataMember]
        public string prom_date { get; set; }
        [DataMember]
        public string jc_status { get; set; }
        [DataMember]
        public string srv_adv_cd { get; set; }
        [DataMember]
        public string srv_sdv_name { get; set; }
        [DataMember]
        public string approval_status { get; set; }//New added on 14 March 2018
        [DataMember]
        public string ccp_num { get; set; }//New added on 5 May 2022

    }

    #region DIY JC - Do It Yourself JobCard
    #region for DIYJC_PullCustomerContact
    [DataContract]
    public class DIYJC_PullCustomerContact
    {
        [DataMember]
        public string PN_USER_ID { get; set; }
        [DataMember]
        public string PN_REG_NUM { get; set; }
        [DataMember]
        public string PN_VIN { get; set; }

        [DataMember]
        public string PO_DEALER_CD { get; set; }
        [DataMember]
        public string PO_CAR_USER_NUM { get; set; }
        [DataMember]
        public string PO_CUST_MOBILE_NUM { get; set; }
        [DataMember]
        public string PO_CONTACT_YN { get; set; }
    }
    #endregion

    #region for DIYJC_PushCustomerSMS
    [DataContract]
    public class DIYJC_PushCustomerSMS
    {
        [DataMember]
        public string PN_USER_ID { get; set; }
        [DataMember]
        public string PN_REG_NUM { get; set; }
        [DataMember]
        public string PN_SMS_NUM { get; set; }
        [DataMember]
        public string PN_SMS_LINK { get; set; }
    }
    #endregion

    #region for DIYJC_PullVehicleDetails
    [DataContract]
    public class DIYJC_PullVehicleDetails
    {
        [DataMember]
        public string PO_VIN { get; set; }
    }
    #endregion

    #region for DIYJC_PullServiceType
    [DataContract]
    public class DIYJC_PullServiceType
    {
        [DataMember]
        public string LIST_CD { get; set; }
        [DataMember]
        public string LIST_DESC { get; set; }
    }
    #endregion

    #region for DIYJC_PushCustomerDmdDetails
    [DataContract]
    public class DIYJC_PushCustomerDmdDetails
    {
        [DataMember]
        public string PN_USER_ID { get; set; }
        [DataMember]
        public string PN_REG_NUM { get; set; }
        [DataMember]
        public string PN_DEALER_CD { get; set; }
        [DataMember]
        public string PN_SRV_TYPE { get; set; }
        [DataMember]
        public string PN_ODOMETER { get; set; }
        [DataMember]
        public string PN_CUST_DMD { get; set; }
    }
    #endregion

    #region for DIYJC_PullSADashboard
    [DataContract]
    public class DIYJC_PullSADashboard
    {
        [DataMember]
        public string SENT_DATE { get; set; }
        [DataMember]
        public string RECEIVE_DATE { get; set; }
        [DataMember]
        public string SA_NAME { get; set; }
        [DataMember]
        public string CUST_NAME { get; set; }
        [DataMember]
        public string REG_NUM { get; set; }
        [DataMember]
        public string VIN { get; set; }
        [DataMember]
        public string ODOMETER_READING { get; set; }
        [DataMember]
        public string RCATEG_CD { get; set; }
        [DataMember]
        public string RCATEG_DESC { get; set; }
        [DataMember]
        public string STATUS { get; set; }
    }
    #endregion

    #region for DIYJC_PullCustomerDmdDetails
    [DataContract]
    public class DIYJC_PullCustomerDmdDetails
    {
        [DataMember]
        public string PO_CUST_DMD { get; set; }
    }
    #endregion
    #endregion

    #region WCC - Web Customer Consent
    #region for WCC_PullCustVehDetails
    [DataContract]
    public class WCC_PullCustVehDetails
    {
        [DataMember]
        public string PO_CUST_CD { get; set; }
        [DataMember]
        public string PO_CUS_NAME { get; set; }
        [DataMember]
        public string PO_CUS_ADD { get; set; }
        [DataMember]
        public string PO_MOBILE { get; set; }
        [DataMember]
        public string PO_EMAIL { get; set; }
        [DataMember]
        public string PO_MODEL_CD { get; set; }
        [DataMember]
        public string PO_MODEL_DESC { get; set; }
        [DataMember]
        public string PO_REG_NUM { get; set; }
        [DataMember]
        public string PO_ENG_NUM { get; set; }
        [DataMember]
        public string PO_CHASSIS { get; set; }
        [DataMember]
        public string PO_ODOMETER { get; set; }
        [DataMember]
        public string PO_DATE { get; set; }
        [DataMember]
        public string PO_FIXED_AMT { get; set; }
        [DataMember]
        public string PO_VAR_AMT { get; set; }
    }
    #endregion

    #region for WCC_PushCustomerConsent
    [DataContract]
    public class WCC_PushCustomerConsent
    {
        [DataMember]
        public string PN_VIN { get; set; }
        [DataMember]
        public string PN_TNC_YN { get; set; }
        [DataMember]
        public string PN_AUTH_YN { get; set; }
    }
    #endregion
    #endregion
}