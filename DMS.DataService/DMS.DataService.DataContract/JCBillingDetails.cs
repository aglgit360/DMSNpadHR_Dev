using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DMS.DataService.DataContract
{
    [DataContract]//added on 18 July 2022
    public class JCBillingDetails
    {
        [DataMember]
        public string PO_DOC_DATE { get; set; }
        [DataMember]
        public string PO_DOC_STATUS { get; set; }

        [DataMember]
        public string PN_JC_NO { get; set; }
        //----BILL DETAILS SECTION---
        [DataMember]
        public string PO_BILL_NUM { get; set; }
        [DataMember]
        public string PO_BILL_TYPE { get; set; }
        [DataMember]
        public string PO_PAYMENT_MODE { get; set; }
        [DataMember]
        public string PO_INSURANCE { get; set; }
        //----CUSTOMER CREDIT CARD SECTION----
        [DataMember]
        public string PO_CUST_CREDIT_NAME { get; set; }
        [DataMember]
        public string PO_CUST_CREDIT_NO { get; set; }
        //---- VEHICLE DETAILS----
        [DataMember]
        public string PO_VIN { get; set; }
        [DataMember]
        public string PO_REG_NO { get; set; }
        [DataMember]
        public string PO_MODEL_CD { get; set; }
        [DataMember]
        public string PO_MODEL_DESC { get; set; }
        [DataMember]
        public string PO_VEH_DELV_BY { get; set; }
        [DataMember]
        public string PO_UNAPPR_PART_ACC_YN { get; set; }
        [DataMember]
        public string PO_UNAPPR_CNG_LPG_YN { get; set; }
        //----CUSTOMER DETAILS---
        [DataMember]
        public string PO_CUST_LEGAL_STATUS_YN { get; set; }
        [DataMember]
        public string PO_CUST_CD { get; set; }
        [DataMember]
        public string PO_CUST_DESC { get; set; }
        [DataMember]
        public string PO_INV_CD { get; set; }
        [DataMember]
        public string PO_INV_DESC { get; set; }
        [DataMember]
        public string PO_INV_GSTIN { get; set; }
        [DataMember]
        public string PO_INS_COMPANY_CD { get; set; }
        [DataMember]
        public string PO_INS_COMPANY_DESC { get; set; }
        [DataMember]
        public string PO_INS_PARTY_CD { get; set; }
        [DataMember]
        public string PO_INS_PARTY_DESC { get; set; }
        [DataMember]
        public string PO_DEDUCTIBLES { get; set; }
        [DataMember]
        public string PO_SALVAGE { get; set; }

        [DataMember]
        public string PO_CATEGORY { get; set; }
        [DataMember]
        public string PO_CAR_USERNAME { get; set; }
        [DataMember]
        public string PO_REMARKS { get; set; }
        //---JC DETAILS---
        [DataMember]
        public string PO_JC_CLOSE_DATE { get; set; }
        [DataMember]
        public string PO_GST_TYPE { get; set; }
        //---PICKUP DETAILS---
        [DataMember]
        public string PO_PICKUP_TYPE { get; set; }
        [DataMember]
        public string PO_PICKUP_DATE { get; set; }
        //---OTHER CHARGES---
        [DataMember]
        public string PO_OUT_AMT { get; set; }
        [DataMember]
        public string PO_CUST_TYPE { get; set; }
        //--- CUSTOMER DISCOUNT---
        [DataMember]
        public string PO_PART_DISC_PER { get; set; }
        [DataMember]
        public string PO_LABOUR_DISC_PER { get; set; }
        [DataMember]
        public string PO_PART_DISC_VAL { get; set; }
        [DataMember]
        public string PO_LABOUR_DISC_VAL { get; set; }
        [DataMember]
        public string PO_DISC_AUTH_BY { get; set; }
        //---- FINAL AMOUNT---
        [DataMember]
        public string PO_PART_AMT_EST { get; set; }
        [DataMember]
        public string PO_LABOUR_AMT_EST { get; set; }
        [DataMember]
        public string PO_TOTAL_BILL_AMT_EST { get; set; }
        [DataMember]
        public string PO_QR_CD_YN { get; set; }
        [DataMember]
        public string PO_ROUND_OFF { get; set; }
        [DataMember]
        public string PO_VAR_REASON_CD { get; set; }
        [DataMember]
        public string PO_DELAY_REASON_CD { get; set; }
        [DataMember]
        public string PO_DELAY_REMARKS { get; set; }
        [DataMember]
        public string PO_CUST_TCS { get; set; }
        [DataMember]
        public string PO_INS_TCS { get; set; }
        [DataMember]
        public string PO_EWR_TCS { get; set; }
        [DataMember]
        public string PO_B2B_FLAG { get; set; }//Added on 9 August 2022
        [DataMember]
        public string PO_B2C_FLAG { get; set; }//Added on 9 August 2022

        [DataMember]
        public List<PartDetails> partDetails { get; set; }
        [DataMember]
        public List<LabourDetails> labourDetails { get; set; }
    }

    [DataContract]//added on 18 July 2022
    public class PartDetails
    {
        [DataMember]
        public string srl_no { get; set; }
        [DataMember]
        public string Part_no { get; set; }
        [DataMember]
        public string Qty { get; set; }
        [DataMember]
        public string Rate { get; set; }
        [DataMember]
        public string Item_Val { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Perc { get; set; }
        [DataMember]
        public string Basic_Amt { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public string Disc_Amt { get; set; }
        [DataMember]
        public string Tax { get; set; }
        [DataMember]
        public string Total_Amt { get; set; }
        [DataMember]
        public string Set_No { get; set; }
        [DataMember]
        public string Batch { get; set; }
        [DataMember]
        public string Part_Desc { get; set; }
        [DataMember]
        public string Tax_Category { get; set; }


    }
    [DataContract]//added on 18 July 2022
    public class LabourDetails
    {
        [DataMember]
        public string srl_no { get; set; }
        [DataMember]
        public string Labour { get; set; }
        [DataMember]
        public string Frm_hr { get; set; }
        [DataMember]
        public string Comp_perc { get; set; }
        [DataMember]
        public string Normal_perc { get; set; }
        [DataMember]
        public string Labour_Amt { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Perc { get; set; }
        [DataMember]
        public string Basic_Amt { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public string Disc_Amt { get; set; }
        [DataMember]
        public string Tax { get; set; }
        [DataMember]
        public string Total_Amt { get; set; }
        [DataMember]
        public string Set_No { get; set; }
        [DataMember]
        public string Labour_Desc { get; set; }
        [DataMember]
        public string Tax_Category { get; set; }


    }


    #region Calculate JC Billing 
    [DataContract]
    public class CalculateJCBills
    {
        [DataMember]
        public string PN_PAYMENT_MODE { get; set; }
        [DataMember]
        public string PO_PART_AMT { get; set; }
        [DataMember]
        public string PO_LABOUR_AMT { get; set; }
        [DataMember]
        public string PO_TOTAL_AMT { get; set; }
        [DataMember]
        public List<JCPartDetails> PO_PART_REFCUR { get; set; }
        [DataMember]
        public List<JCLabourDetails> PO_LABOUR_REFCUR { get; set; }
      
    }
    [DataContract]
    public class JCPartDetails
    {
        [DataMember]
        public string req_iss_type { get; set; }
        [DataMember]
        public string Basic_Amt { get; set; }
        [DataMember]
        public string Total_Disc { get; set; }
        [DataMember]
        public string Total_Charges { get; set; }
        [DataMember]
        public string Total_Amt { get; set; }
        [DataMember]
        public string Set_No { get; set; }
    }
    [DataContract]
    public class JCLabourDetails
    {
        [DataMember]
        public string req_iss_type { get; set; }
        [DataMember]
        public string Basic_Amt { get; set; }
        [DataMember]
        public string Total_Disc { get; set; }
        [DataMember]
        public string Total_Charges { get; set; }
        [DataMember]
        public string Total_Amt { get; set; }
        [DataMember]
        public string Set_No { get; set; }
    }

    #endregion

    #region Create JC Billing 
    [DataContract]
    public class CreateJCBills
    {
        [DataMember]
        public List<JC_BillDetails> PO_BILL_DTL { get; set; }
       
    }

    [DataContract]
    public class JC_BillDetails
    {
        [DataMember]
        public string srl_no { get; set; }
        [DataMember]
        public string Req_iss_type { get; set; }
        [DataMember]
        public string Bill_num { get; set; }
        [DataMember]
        public string set_no { get; set; }

    }
    #endregion
}
