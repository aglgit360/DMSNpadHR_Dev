using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NEXA.DataService.DataContract
{
    class MasterList
    {
    }

    #region for service Type

    [DataContract]

    public class ServiceTypes
    {
        [DataMember]
        public string po_ServiceTypeDesc { get; set; }
        [DataMember]
        public string po_Code { get; set; }

    }

    #endregion
    #region for Part Master Details
    [DataContract]

    public class PartList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }

        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string pn_part_num { get; set; }

        [DataMember]
        public string part_num { get; set; }
        [DataMember]
        public string part_desc { get; set; }
        [DataMember]
        public string mrp { get; set; }
        [DataMember]
        public string stock { get; set; }

    }
    #endregion

    #region for Dealer&LocationList

    public class DealerLocationList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string parent_group { get; set; }

        [DataMember]
        public string dealer_map_cd { get; set; }
        [DataMember]
        public string loc_cd { get; set; }

        [DataMember]
        public string comp_fa { get; set; }

        [DataMember]
        public string dealer_name { get; set; }

        [DataMember]
        public string loc_desc { get; set; }
    }

    #endregion


    #region for Extended Warranty List

    public class ExtendedWarrantyList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string pn_vin { get; set; }

        [DataMember]
        public string ew_type { get; set; }
        [DataMember]
        public string ew_type_desc { get; set; }

        [DataMember]
        public string ewr_price { get; set; }

        [DataMember]
        public string ewr_expiry_date { get; set; }

        [DataMember]
        public string ewr_expiry_mileage { get; set; }
    }

    #endregion
    #region for MCP List

    public class MCPList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }

        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]

        public string pn_reg_num { get; set; }
        [DataMember]
        public string pn_omr { get; set; }

        [DataMember]
        public string pkg_code { get; set; }

        [DataMember]
        public string pkg_desc { get; set; }

        [DataMember]
        public string mcp_start_date { get; set; }

        [DataMember]
        public string mcp_expiry_date { get; set; }

        [DataMember]
        public string price { get; set; }
    }

    #endregion
    #region for Labour Master List

    public class LabourMasterList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }

        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]

        public string pn_reg_num { get; set; }
        [DataMember]
        public string pn_srv_cat_cd { get; set; }

        [DataMember]
        public string veh_system { get; set; }

        [DataMember]
        public string veh_sub_system { get; set; }

        [DataMember]
        public string veh_sys_desc { get; set; }

        [DataMember]
        public string veh_sub_sys_desc { get; set; }

        [DataMember]
        public string opr_cd { get; set; }

        [DataMember]
        public string opr_desc { get; set; }
        [DataMember]
        public string frm_hrs { get; set; }
        [DataMember]
        public string fixed_amt { get; set; }

    }

    #endregion

    #region for Pickup Type List
    public class PickupTypeList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string pickup_code { get; set; }
        [DataMember]
        public string pickup_desc { get; set; }
    }
    #endregion

    #region for UnApprovedFitmentsList
    public class UnApprovedFitmentsList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string apprv_fit_code { get; set; }
        [DataMember]
        public string apprv_fit_desc { get; set; }
    }
    #endregion

    #region for DemandRepairsList
    public class DemandRepairsList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string pn_reg_num { get; set; }
        [DataMember]
        public string demand_cd { get; set; }
        [DataMember]
        public string demand_desc { get; set; }
        [DataMember]
        public string service_type { get; set; }
        [DataMember]
        public string pop_yn { get; set; }
    }
    #endregion

    #region for ServiceTypeList
    public class ServiceTypeList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string srv_type { get; set; }
        [DataMember]
        public string srv_type_desc { get; set; }
    }
    #endregion

    #region for BillableTypeList
    public class BillableTypeList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string bill_type { get; set; }
        [DataMember]
        public string bill_type_desc { get; set; }
    }
    #endregion

    #region for ProblemCodeList
    public class ProblemCodeList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string problem_cd { get; set; }
        [DataMember]
        public string problem_desc { get; set; }
    }
    #endregion

    #region for FaultCodeList
    public class FaultCodeList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string problem_cd { get; set; }
        [DataMember]
        public string fault_cd { get; set; }
        [DataMember]
        public string fault_desc { get; set; }
    }
    #endregion

    #region for ActionCodeList
    public class ActionCodeList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string problem_cd { get; set; }
        [DataMember]
        public string fault_cd { get; set; }
        [DataMember]
        public string action_cd { get; set; }
        [DataMember]
        public string action_desc { get; set; }
    }
    #endregion

    #region for CSIReasonList
    public class CSIReasonList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string csi_cd { get; set; }
        [DataMember]
        public string csi_desc { get; set; }
    }
    #endregion

    #region for DelayReasonsClosingList
    public class DelayReasonsClosingList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string delay_cd { get; set; }
        [DataMember]
        public string delay_desc { get; set; }
    }
    #endregion

    #region for DelayReasonsBillingList
    public class DelayReasonsBillingList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string delay_cd { get; set; }
        [DataMember]
        public string delay_desc { get; set; }
    }
    #endregion

    #region for PaymentModeList
    public class PaymentModeList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string pay_mode_cd { get; set; }
        [DataMember]
        public string pay_mode_desc { get; set; }
    }
    #endregion

    #region for ReportedByList
    public class ReportedByList
    {
        [DataMember]
        public string pn_pmc { get; set; }
        [DataMember]
        public string rep_by_cd { get; set; }
        [DataMember]
        public string rep_by_desc { get; set; }
    }
    #endregion

    #region for PickUpLocationList
    public class PickUpLocationList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string area_cd { get; set; }
        [DataMember]
        public string area_desc { get; set; }
    }
    #endregion

    #region for MobileServiceMMSList
    public class MobileServiceMMSList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string mms_num { get; set; }
    }
    #endregion

    #region for DriveEmployeeList
    public class DriveEmployeeList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string emp_cd { get; set; }
        [DataMember]
        public string emp_name { get; set; }
    }
    #endregion

    #region for BayCodeList
    public class BayCodeList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string bay_type { get; set; }
        [DataMember]
        public string bay_desc { get; set; }
        [DataMember]
        public string bay_cd { get; set; }
    }
    #endregion

    #region for ServiceAdvisorEmployeeList
    public class ServiceAdvisorEmployeeList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }

        [DataMember]
        public string emp_cd { get; set; }
        [DataMember]
        public string emp_name { get; set; }
        [DataMember]
        public string dms_user_id { get; set; }
    }
    #endregion

    #region for TechnicalAdvisorEmployeeList
    public class TechnicalAdvisorEmployeeList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string emp_cd { get; set; }
        [DataMember]
        public string emp_name { get; set; }
    }
    #endregion

    #region for GroupList
    public class GroupList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string group_cd { get; set; }
        [DataMember]
        public string group_name { get; set; }
    }
    #endregion

    #region for TechnicianEmployeeList
    public class TechnicianEmployeeList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string group_cd { get; set; }
        [DataMember]
        public string emp_cd { get; set; }
        [DataMember]
        public string emp_name { get; set; }
    }
    #endregion

    #region for InventoryList
    public class InventoryList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string inventory_cd { get; set; }
        [DataMember]
        public string inventory_desc { get; set; }
    }
    #endregion

    #region for AuthorizedPersonForDiscountList
    public class AuthorizedPersonForDiscountList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string emp_cd { get; set; }
        [DataMember]
        public string emp_name { get; set; }
    }
    #endregion

    #region for SplitRatioListOnlyForParts
    public class SplitRatioListOnlyForParts
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string split_cd { get; set; }
        [DataMember]
        public string split_desc { get; set; }
        [DataMember]
        public string cust_per { get; set; }
        [DataMember]
        public string ins_per { get; set; }
        [DataMember]
        public string dlr_per { get; set; }
        [DataMember]
        public string oem_per { get; set; }
    }
    #endregion

    #region for ServiceMenuCardList
    public class ServiceMenuCardList
    {
        [DataMember]
        public string pn_parent { get; set; }
        [DataMember]
        public string pn_dealer_cd { get; set; }
        [DataMember]
        public string pn_loc_cd { get; set; }
        [DataMember]
        public string pn_reg_num { get; set; }
        [DataMember]
        public string pn_srv_cat_cd { get; set; }
        [DataMember]
        public string pn_omr { get; set; }
        [DataMember]
        public string po_sub_srv_cd { get; set; }
        [DataMember]
        public string po_sub_srv_desc { get; set; }
        [DataMember]
        public string srv_type_cd { get; set; }
        [DataMember]
        public string srv_type_desc { get; set; }
        [DataMember]
        public string srv_cd { get; set; }
        [DataMember]
        public string srv_desc { get; set; }
        [DataMember]
        public string srv_qty { get; set; }
        [DataMember]
        public string grp_cd { get; set; }
        [DataMember]
        public string rate { get; set; }
        //New parameter added on 28/07/2022
        [DataMember]
        public string MENU_PART_YN { get; set; }

    }
    #endregion

    #region for SP_rh_enq RHEnquiry (ITD Work)
    public class RHEnquiry
    {
        [DataMember]
        public string p_pmc { get; set; }

        [DataMember]
        public string DEALER_MAP_CD { get; set; }
        [DataMember]
        public string ENQ_NUM { get; set; }
        [DataMember]
        public string LOC_CD { get; set; }
        [DataMember]
        public string PARENT_GROUP { get; set; }
        [DataMember]
        public string ENQ_DATE { get; set; }
        [DataMember]
        public string ENQ_NAME { get; set; }
        [DataMember]
        public string ENQ_IC { get; set; }
        [DataMember]
        public string ETYPE_CD { get; set; }
        [DataMember]
        public string ENQ_REF_CUSTCD { get; set; }
        [DataMember]
        public string ENQ_FINANCE { get; set; }
        [DataMember]
        public string ENQ_ADDREP { get; set; }
        [DataMember]
        public string TRADEIN_YN { get; set; }
        [DataMember]
        public string ENQ_COMMOR { get; set; }
        [DataMember]
        public string RES_ADDRESS1 { get; set; }
        [DataMember]
        public string RES_ADDRESS2 { get; set; }
        [DataMember]
        public string RES_ADDRESS3 { get; set; }
        [DataMember]
        public string RES_COUNTRY_CD { get; set; }
        [DataMember]
        public string RES_STATE_CD { get; set; }
        [DataMember]
        public string RES_CITY_CD { get; set; }
        [DataMember]
        public string RES_PIN { get; set; }
        [DataMember]
        public string RES_PHONE { get; set; }
        [DataMember]
        public string MOBILE { get; set; }
        [DataMember]
        public string FAX { get; set; }
        [DataMember]
        public string EMAIL { get; set; }
        [DataMember]
        public string WORK_PLACE { get; set; }
        [DataMember]
        public string OFF_ADDRESS1 { get; set; }
        [DataMember]
        public string OFF_ADDRESS2 { get; set; }
        [DataMember]
        public string OFF_ADDRESS3 { get; set; }
        [DataMember]
        public string OFF_COUNTRY_CD { get; set; }
        [DataMember]
        public string OFF_STATE_CD { get; set; }
        [DataMember]
        public string OFF_CITY_CD { get; set; }
        [DataMember]
        public string OFF_PIN { get; set; }
        [DataMember]
        public string OFF_PHONE { get; set; }
        [DataMember]
        public string CREATED_DATE { get; set; }
        [DataMember]
        public string CREATED_BY { get; set; }
        [DataMember]
        public string MODIFIED_DATE { get; set; }
        [DataMember]
        public string MODIFIED_BY { get; set; }
        [DataMember]
        public string OFF_PHONE2 { get; set; }
        [DataMember]
        public string COMP_FA { get; set; }
        [DataMember]
        public string ENQ_CUST_SUB_CATG { get; set; }
        [DataMember]
        public string ENQ_REF_MODE { get; set; }
        [DataMember]
        public string TITLE_CD { get; set; }
        [DataMember]
        public string DMA_DSA_CD { get; set; }
        [DataMember]
        public string MIDDLE_NAME { get; set; }
        [DataMember]
        public string LAST_NAME { get; set; }
        [DataMember]
        public string PRE_RES_PHONE { get; set; }
        [DataMember]
        public string PRE_MOB_PHONE { get; set; }
        [DataMember]
        public string PRE_OFF_PHONE { get; set; }
        [DataMember]
        public string PRE_FAX_PHONE { get; set; }
        [DataMember]
        public string ENQ_SOURCE { get; set; }
        [DataMember]
        public string ENQ_EVENTCD { get; set; }
        [DataMember]
        public string ENQ_ZONE_CD { get; set; }
        [DataMember]
        public string TEST_DRIVE_GIVEN { get; set; }
        [DataMember]
        public string REFFERED_BY { get; set; }
        [DataMember]
        public string CUST_REQ { get; set; }
        [DataMember]
        public string ENQ_CUSTCD { get; set; }
        [DataMember]
        public string ENQ_SALESMAN_CD { get; set; }
        [DataMember]
        public string TEST_DRIVE_DATE { get; set; }
        [DataMember]
        public string CASH { get; set; }
        [DataMember]
        public string WORKPLACE_ID { get; set; }
        [DataMember]
        public string ENQ_SRC_REF_NUM { get; set; }
        [DataMember]
        public string ENQ_PRIM_VARIANT { get; set; }
        [DataMember]
        public string STATUS { get; set; }
        [DataMember]
        public string ENQUIRER_TYPE { get; set; }
        [DataMember]
        public string ENQ_LIKELYPURDATE { get; set; }
        [DataMember]
        public string LINK_FLAG { get; set; }
        [DataMember]
        public string REF_AUTOCARD_NO { get; set; }
        [DataMember]
        public string REF_AUTOCARD_DOB { get; set; }
        [DataMember]
        public string REF_PHONE_N0 { get; set; }
        [DataMember]
        public string FVISIT_DATE { get; set; }
        [DataMember]
        public string VEH_USE_PRE { get; set; }
        [DataMember]
        public string KM_COVER { get; set; }
        [DataMember]
        public string FAM_MEM { get; set; }
        [DataMember]
        public string PUROS_NCAR { get; set; }
        [DataMember]
        public string EXPCTNS_YCAR { get; set; }
        [DataMember]
        public string ANY_PCAR_MIND { get; set; }
        [DataMember]
        public string KM_COVR_MNTH { get; set; }
        [DataMember]
        public string FAM_MEM_CNT { get; set; }
        [DataMember]
        public string PUROS_NEW_CAR { get; set; }
        [DataMember]
        public string EXPCTNS_FCAR1 { get; set; }
        [DataMember]
        public string EXPCTNS_FCAR2 { get; set; }
        [DataMember]
        public string EXPCTNS_FCAR3 { get; set; }
        [DataMember]
        public string TYPE_OF_BUYER { get; set; }
        [DataMember]
        public string VEHICLE_MAKER { get; set; }
        [DataMember]
        public string VEHICLE_MODEL { get; set; }
        [DataMember]
        public string ENQ_CHANGE_DATE { get; set; }
        [DataMember]
        public string ENQ_STATUS { get; set; }
        [DataMember]
        public string LOST_REASON_CD { get; set; }
        [DataMember]
        public string LOST_SUB_REASON_CD { get; set; }
        [DataMember]
        public string ENQ_LOST_DLR { get; set; }
        [DataMember]
        public string ENQ_LOST_MOD { get; set; }
        [DataMember]
        public string STATE_CD { get; set; }
        [DataMember]
        public string DISTRICT { get; set; }
        [DataMember]
        public string TEHSIL_CD { get; set; }
        [DataMember]
        public string VILLAGE_CD { get; set; }
        [DataMember]
        public string DUP_ENQ_NUM { get; set; }
        [DataMember]
        public string DUP_ETYPE_CD { get; set; }
        [DataMember]
        public string DUP_ENQ_TYPE { get; set; }
        [DataMember]
        public string REF_VEH_REG_NO { get; set; }
        [DataMember]
        public string VEH_REG_CHECK { get; set; }
        [DataMember]
        public string REF_MOBILE_NO { get; set; }
        [DataMember]
        public string MOB_CHECK { get; set; }
        [DataMember]
        public string CUST_NAME { get; set; }
        [DataMember]
        public string CUST_CD { get; set; }
        [DataMember]
        public string MOBILE_NUM { get; set; }
        [DataMember]
        public string ENQ_NUMBER { get; set; }
        [DataMember]
        public string ENQ_SOURCE_FLAG { get; set; }
        [DataMember]
        public string ENQ_BEVERAGE_CHOICE { get; set; }
        [DataMember]
        public string ENQ_LIKELYPURDAYS { get; set; }
        [DataMember]
        public string VEH_USE_PRE1 { get; set; }
        [DataMember]
        public string VEH_USE_PRE2 { get; set; }
        [DataMember]
        public string ENQ_OTH_CUST_DTL { get; set; }
        [DataMember]
        public string YR_OF_MANUFACTURE { get; set; }
        [DataMember]
        public string YR_OF_MANUFACTURE1 { get; set; }
        [DataMember]
        public string YR_OF_MANUFACTURE2 { get; set; }
        [DataMember]
        public string INT_AUTOCARD { get; set; }
        [DataMember]
        public string ENQ_BEVERAGE_REMARK { get; set; }
        [DataMember]
        public string ENQ_EVALUATOR { get; set; }
        [DataMember]
        public string OLD_VEH_ENQ_STATUS { get; set; }
        [DataMember]
        public string EVAL_DLR_MAP_CD { get; set; }
        [DataMember]
        public string EVAL_LOC_CD { get; set; }
        [DataMember]
        public string EXCH_REMARK_CD { get; set; }
        [DataMember]
        public string COM_CUST_PROFILE { get; set; }
        [DataMember]
        public string COM_USAGE_AREA { get; set; }
        [DataMember]
        public string COM_LICENSE_AVL { get; set; }
        [DataMember]
        public string FOLLOWUP_FLAG { get; set; }
        [DataMember]
        public string FLAG_DATE { get; set; }
        [DataMember]
        public string ENQ_COMMOR_TIME { get; set; }
        [DataMember]
        public string NEXA_TRANSACTION_ID { get; set; }
        [DataMember]
        public string WEB_BOOK_REF_NO { get; set; }
        [DataMember]
        public string WEB_PAY_REF_NO { get; set; }
        [DataMember]
        public string WEB_ENQ_PAN_NO { get; set; }
        [DataMember]
        public string BROCHURE { get; set; }
        [DataMember]
        public string PROSPECT_CLASSIFICATION { get; set; }
        [DataMember]
        public string BROCHURE_DATE { get; set; }
        [DataMember]
        public string RPIN_CODE { get; set; }
        [DataMember]
        public string OPIN_CODE { get; set; }
        [DataMember]
        public string REMARKS { get; set; }
        [DataMember]
        public string NRM_WEBBOOK_SHFLAG { get; set; }
        [DataMember]
        public string NRM_WEBBOOK_SHFLAG_DATE { get; set; }
        [DataMember]
        public string NRM_WEBBOOK_TDFLAG { get; set; }
        [DataMember]
        public string NRM_WEBBOOK_TDFLAG_DATE { get; set; }
        [DataMember]
        public string NRM_WEBBOOK_CRFLAG { get; set; }
        [DataMember]
        public string NRM_WEBBOOK_CRFLAG_DATE { get; set; }
        [DataMember]
        public string NRM_BOOK_PREF_DATE { get; set; }
        [DataMember]
        public string NRM_BOOK_PREF_TIME { get; set; }
        [DataMember]
        public string NRM_RELATION_CD { get; set; }
        [DataMember]
        public string NRM_REL_NAME { get; set; }
        [DataMember]
        public string VEH_DRIVER { get; set; }
        [DataMember]
        public string VEH_FOR { get; set; }
        [DataMember]
        public string TWO_WHL_OWNED { get; set; }
        [DataMember]
        public string TWO_WHL_AGE { get; set; }
        [DataMember]
        public string FOUR_WHL_OWNED { get; set; }
        [DataMember]
        public string MARUTI_CARS_OWNED { get; set; }
        [DataMember]
        public string VIN_REG_NUM { get; set; }
        [DataMember]
        public string TWO_WHL_TYPE { get; set; }
        [DataMember]
        public string REF_CARD_TYPE { get; set; }
        [DataMember]
        public string CAR_FEAT_EXPLD { get; set; }
        [DataMember]
        public string VAR_FEAT_EXPLD { get; set; }
        [DataMember]
        public string CAR_CONF_SAVED { get; set; }
        [DataMember]
        public string CAR_FEAT_TSPNT { get; set; }
        [DataMember]
        public string CONF_QUOT_SENT { get; set; }
        [DataMember]
        public string CAR_COMP_SHOWN { get; set; }
        [DataMember]
        public string ALLIED_BUS_EXPLD { get; set; }
        [DataMember]
        public string UTM_SOURCE { get; set; }
        [DataMember]
        public string UTM_MEDIUM { get; set; }
        [DataMember]
        public string UTM_CAMPAIGN { get; set; }
        [DataMember]
        public string UTM_KEYWORD { get; set; }
        [DataMember]
        public string UTM_ADGROUPNAME { get; set; }
        [DataMember]
        public string UTM_TERM { get; set; }
        [DataMember]
        public string UTM_CONTENT { get; set; }
        [DataMember]
        public string HYPER_REF_ID { get; set; }
    }
    #endregion

    #region for SP_VH_RO_CRM VHROCRM (ITD Work)
    public class VHROCRM
    {
        [DataMember]
        public string PMC { get; set; }

        [DataMember]
        public string DEALER_MAP_CD { get; set; }
        [DataMember]
        public string COMP_FA { get; set; }
        [DataMember]
        public string LOC_CD { get; set; }
        [DataMember]
        public string RO_NUM { get; set; }
        [DataMember]
        public string RO_DATE { get; set; }
        [DataMember]
        public string RCATEG_CD { get; set; }
        [DataMember]
        public string VIN { get; set; }
        [DataMember]
        public string REG_NUM { get; set; }
        [DataMember]
        public string BTN { get; set; }
        [DataMember]
        public string RO_STATUS { get; set; }
        [DataMember]
        public string ODOMETER_READING { get; set; }
        [DataMember]
        public string CHKLST_PRINTED_YN { get; set; }
        [DataMember]
        public string CHKLST_CONF_YN { get; set; }
        [DataMember]
        public string SVC_EMP_CODE { get; set; }
        [DataMember]
        public string SVC_MESG { get; set; }
        [DataMember]
        public string PRINTED_YN { get; set; }
        [DataMember]
        public string BILLED_YN { get; set; }
        [DataMember]
        public string PROMISED_DATE { get; set; }
        [DataMember]
        public string ACTUAL_DATE { get; set; }
        [DataMember]
        public string DELAY_REAS_CD { get; set; }
        [DataMember]
        public string VEH_DET { get; set; }
        [DataMember]
        public string LABOUR_AMT { get; set; }
        [DataMember]
        public string PART_AMT { get; set; }
        [DataMember]
        public string ERS_AMT { get; set; }
        [DataMember]
        public string LONGPARK_AMT { get; set; }
        [DataMember]
        public string DISCOUNT_PCT { get; set; }
        [DataMember]
        public string DISCOUNT_AMT { get; set; }
        [DataMember]
        public string BILL_AMT { get; set; }
        [DataMember]
        public string OTHER1_AMT { get; set; }
        [DataMember]
        public string O1_DESC { get; set; }
        [DataMember]
        public string OTHER2_AMT { get; set; }
        [DataMember]
        public string O2_DESC { get; set; }
        [DataMember]
        public string OTHER3_AMT { get; set; }
        [DataMember]
        public string O3_DESC { get; set; }
        [DataMember]
        public string OTHER4_AMT { get; set; }
        [DataMember]
        public string O4_DESC { get; set; }
        [DataMember]
        public string OTHER5_AMT { get; set; }
        [DataMember]
        public string O5_DESC { get; set; }
        [DataMember]
        public string CREATED_DATE { get; set; }
        [DataMember]
        public string CREATED_BY { get; set; }
        [DataMember]
        public string MODIFIED_DATE { get; set; }
        [DataMember]
        public string MODIFIED_BY { get; set; }
        [DataMember]
        public string ESTI_NUM { get; set; }
        [DataMember]
        public string ADVANCE_AMT { get; set; }
        [DataMember]
        public string ERS_TIME { get; set; }
        [DataMember]
        public string ERS_KMS { get; set; }
        [DataMember]
        public string TOWING_AMT { get; set; }
        [DataMember]
        public string SUB_LET_AMT { get; set; }
        [DataMember]
        public string ISSUE_CLOSED_YN { get; set; }
        [DataMember]
        public string CUST_SATISFIED_YN { get; set; }
        [DataMember]
        public string PRINV_YN { get; set; }
        [DataMember]
        public string FS_CLAIM_YN { get; set; }
        [DataMember]
        public string RECD_AMT { get; set; }
        [DataMember]
        public string WRITE_OFF_FLAG { get; set; }
        [DataMember]
        public string PDI_YN { get; set; }
        [DataMember]
        public string CONTRACT_NUM { get; set; }
        [DataMember]
        public string CDS_CD { get; set; }
        [DataMember]
        public string ESTI_AMT_YN { get; set; }
        [DataMember]
        public string PETROL_AMT { get; set; }
        [DataMember]
        public string GP_NUM { get; set; }
        [DataMember]
        public string BILL_NUM { get; set; }
        [DataMember]
        public string BILL_DATE { get; set; }
        [DataMember]
        public string BILL_TYPE { get; set; }
        [DataMember]
        public string SMODEL_CD { get; set; }
        [DataMember]
        public string REMARKS { get; set; }
        [DataMember]
        public string EST_PART_AMT { get; set; }
        [DataMember]
        public string EST_LAB_AMT { get; set; }
        [DataMember]
        public string EFFECTIVE_YN { get; set; }
        [DataMember]
        public string CCAR_YN { get; set; }
        [DataMember]
        public string BAY_CD { get; set; }
        [DataMember]
        public string REV_PROMISED_DATE { get; set; }
        [DataMember]
        public string IQS_STATUS { get; set; }
        [DataMember]
        public string PROMISED_TIME_COUNT { get; set; }
        [DataMember]
        public string CHECKLIST_CD { get; set; }
        [DataMember]
        public string GROUP_CD { get; set; }
        [DataMember]
        public string PARENT_GROUP { get; set; }
        [DataMember]
        public string SCHEME_NUM { get; set; }
        [DataMember]
        public string TECH_EMP_CD { get; set; }
        [DataMember]
        public string BODY_PAINT { get; set; }
        [DataMember]
        public string ROADTEST_END_KM { get; set; }
        [DataMember]
        public string ROADTEST_START_TIME { get; set; }
        [DataMember]
        public string ROADTEST_END_TIME { get; set; }
        [DataMember]
        public string PICKUP_DATE { get; set; }
        [DataMember]
        public string PICKUP_AREA_CD { get; set; }
        [DataMember]
        public string PICKUP_FREE_YN { get; set; }
        [DataMember]
        public string PICKUP_REMARKS { get; set; }
        [DataMember]
        public string PREF_PSF_TIME { get; set; }
        [DataMember]
        public string WC_NUM { get; set; }
        [DataMember]
        public string RECALL_CAMPAIGN_YN { get; set; }
        [DataMember]
        public string RV_SYS_FLAG { get; set; }
        [DataMember]
        public string RV_CONFIRM_FLAG { get; set; }
        [DataMember]
        public string VEHICLE_READY_YN { get; set; }
        [DataMember]
        public string VEHICLE_READY_DATE { get; set; }
        [DataMember]
        public string ROADTEST_START_KM { get; set; }
        [DataMember]
        public string RECALL_CAMPAIGN_DEF { get; set; }
        [DataMember]
        public string CUST_CD { get; set; }
        [DataMember]
        public string CSI_REASON_CD { get; set; }
        [DataMember]
        public string CSI_NUM { get; set; }
        [DataMember]
        public string REPEAT_REMARKS { get; set; }
        [DataMember]
        public string OTH_CHG_YN { get; set; }
        [DataMember]
        public string REPEAT_RO_NUM { get; set; }
        [DataMember]
        public string EWC_NUM { get; set; }
        [DataMember]
        public string TWC_NUM { get; set; }
        [DataMember]
        public string BTN_NUM { get; set; }
        [DataMember]
        public string COUPON_NUM { get; set; }
        [DataMember]
        public string FSC_CLAIM_YN { get; set; }
        [DataMember]
        public string IQS_GEN_YN { get; set; }
        [DataMember]
        public string IFC_GEN_YN { get; set; }
        [DataMember]
        public string ROADTEST_START_KM_JC_CL { get; set; }
        [DataMember]
        public string ROADTEST_END_KM_JC_CL { get; set; }
        [DataMember]
        public string ROADTEST_START_TIME_JC_CL { get; set; }
        [DataMember]
        public string ROADTEST_END_TIME_JC_CL { get; set; }
        [DataMember]
        public string PSF_GEN_YN { get; set; }
        [DataMember]
        public string WC_NUM_PART { get; set; }
        [DataMember]
        public string RO_CANCEL_REASON_CD { get; set; }
        [DataMember]
        public string WC_NUM_TRANSIT { get; set; }
        [DataMember]
        public string WC_NUM_PDI { get; set; }
        [DataMember]
        public string CSI_PRINT_YN { get; set; }
        [DataMember]
        public string BATCHPICKEDUP_FSC { get; set; }
        [DataMember]
        public string FSC_REMARKS { get; set; }
        [DataMember]
        public string BATCHPICKEDUP_SMR { get; set; }
        [DataMember]
        public string SMR_REMARKS { get; set; }
        [DataMember]
        public string GP_DATE { get; set; }
        [DataMember]
        public string BATCHPICKEDUP_BILL_YN { get; set; }
        [DataMember]
        public string BATCHPICKEDUP_BILL_REMARKS { get; set; }
        [DataMember]
        public string OPF_GEN_MOD_YN { get; set; }
        [DataMember]
        public string PSFBATCH_REMARKS { get; set; }
        [DataMember]
        public string LAST_RO_DATE { get; set; }
        [DataMember]
        public string LAST_RO_NUM { get; set; }
        [DataMember]
        public string LAST_RO_NUM_COMP_FA { get; set; }
        [DataMember]
        public string LAST_RO_NUM_DEALER_MAP_CD { get; set; }
        [DataMember]
        public string LAST_RO_NUM_LOC_CD { get; set; }
        [DataMember]
        public string LAST_RO2_DATE { get; set; }
        [DataMember]
        public string LAST2_RO_NUM { get; set; }
        [DataMember]
        public string LAST2_RO_NUM_COMP_FA { get; set; }
        [DataMember]
        public string LAST2_RO_NUM_DEALER_MAP_CD { get; set; }
        [DataMember]
        public string LAST2_RO_NUM_LOC_CD { get; set; }
        [DataMember]
        public string DELAY_REMARKS { get; set; }
        [DataMember]
        public string LAST_RO_SOURCE { get; set; }
        [DataMember]
        public string LAST2_RO_SOURCE { get; set; }
        [DataMember]
        public string WHY1 { get; set; }
        [DataMember]
        public string WHY2 { get; set; }
        [DataMember]
        public string WHY3 { get; set; }
        [DataMember]
        public string WHY4 { get; set; }
        [DataMember]
        public string WHY5 { get; set; }
        [DataMember]
        public string BATCHPICKEDUP_WAR_LBR { get; set; }
        [DataMember]
        public string WAR_LBR_REMARKS { get; set; }
        [DataMember]
        public string CLF_GEN_YN { get; set; }
        [DataMember]
        public string LABR_DISC { get; set; }
        [DataMember]
        public string PART_DISC { get; set; }
        [DataMember]
        public string AUTHORISED_BY { get; set; }
        [DataMember]
        public string BAY_TYPE { get; set; }
        [DataMember]
        public string WAITING_YN { get; set; }
        [DataMember]
        public string DRIVER { get; set; }
        [DataMember]
        public string PICKUP_TYPE { get; set; }
        [DataMember]
        public string AUTO_DEPRECIATION { get; set; }
        [DataMember]
        public string AMC_YN { get; set; }
        [DataMember]
        public string DELAYBILL_REAS_CD { get; set; }
        [DataMember]
        public string DELAYBILL_REMARKS { get; set; }
        [DataMember]
        public string TECH_ADV { get; set; }
        [DataMember]
        public string UNAPPR_ACCS_FITMENT_YN { get; set; }
        [DataMember]
        public string UNAUTH_CNF_FITMENT_YN { get; set; }
        [DataMember]
        public string IFC_REMARKS { get; set; }
        [DataMember]
        public string VTS_CARD_NUM { get; set; }
        [DataMember]
        public string SOURCE { get; set; }
        [DataMember]
        public string CORPORATE_YN { get; set; }
        [DataMember]
        public string BNDP_VTS_YN { get; set; }
        [DataMember]
        public string SUB_RCATEG_CD { get; set; }
        [DataMember]
        public string ODOMETER_CHANGE { get; set; }
        [DataMember]
        public string ODOMETER_REASON { get; set; }
        [DataMember]
        public string ODOMETER_APPROVE { get; set; }
        [DataMember]
        public string FSC_COUPON { get; set; }
        [DataMember]
        public string AMC_NUM { get; set; }
        [DataMember]
        public string SMCARD_YN { get; set; }
        [DataMember]
        public string MMS_NUM { get; set; }
        [DataMember]
        public string SCH_EST_PART_AMT { get; set; }
        [DataMember]
        public string SCH_EST_LAB_AMT { get; set; }
        [DataMember]
        public string REV_EST_PART_AMT { get; set; }
        [DataMember]
        public string REV_EST_LAB_AMT { get; set; }
        [DataMember]
        public string SCH_REV_EST_PART_AMT { get; set; }
        [DataMember]
        public string SCH_REV_EST_LAB_AMT { get; set; }
        [DataMember]
        public string SOURCE_CLOSING { get; set; }
        [DataMember]
        public string SOURCE_BILLING { get; set; }
        [DataMember]
        public string RFID_TAG_NO { get; set; }
        [DataMember]
        public string EST_TIME { get; set; }
        [DataMember]
        public string VTS_UPD_YN { get; set; }
        [DataMember]
        public string LABOUR_AMT_WT { get; set; }
        [DataMember]
        public string PART_AMT_WT { get; set; }
        [DataMember]
        public string PAY_MODE { get; set; }
        [DataMember]
        public string MOD_EST_TIME { get; set; }
        [DataMember]
        public string CUST_SIGN { get; set; }
        [DataMember]
        public string COMPOSITE_TAX_YN { get; set; }
        [DataMember]
        public string GST_TYPE { get; set; }
        [DataMember]
        public string GST_CODE { get; set; }
        [DataMember]
        public string BILL_ALLOW_YN { get; set; }
        [DataMember]
        public string BILL_CANCEL_BY { get; set; }
        [DataMember]
        public string PRE_SVR_EMP_CODE { get; set; }
        [DataMember]
        public string PRE_TECH_EMP_CD { get; set; }
        [DataMember]
        public string LAST_ODOMETER_READING { get; set; }
        [DataMember]
        public string RSM_APPROVAL_ID { get; set; }
        [DataMember]
        public string RSM_APPROVAL_DATE { get; set; }
        [DataMember]
        public string ODOMETER_RSM_REASON { get; set; }
        [DataMember]
        public string FSC_NUM { get; set; }
        [DataMember]
        public string QR_CODE { get; set; }
        [DataMember]
        public string CUSTOMER_RAMARKS { get; set; }
        [DataMember]
        public string DEALER_REMARKS { get; set; }
        [DataMember]
        public string APPROVAL_STATUS { get; set; }
        [DataMember]
        public string CUST_SEZ { get; set; }
        [DataMember]
        public string APP_SENT_DATE { get; set; }
        [DataMember]
        public string APP_REJ_DATE { get; set; }
        [DataMember]
        public string EXTSN_WAR_YN { get; set; }
        [DataMember]
        public string BSC_PART_FLAG { get; set; }
        [DataMember]
        public string BSC_PART_LAB_VALUE { get; set; }
        [DataMember]
        public string BSC_UPD_DATE { get; set; }
    }
    #endregion

    #region for RescanFSC (ITD Work)
    [DataContract]
    public class RescanFSC
    {
        [DataMember]
        public string pn_user_id { get; set; }
        [DataMember]
        public string Pn_password { get; set; }
        [DataMember]
        public string pn_reg_num { get; set; }
        [DataMember]
        public string Pn_Jo_num { get; set; }
        [DataMember]
        public string Pn_Fsc_num { get; set; }
    }
    #endregion

    [DataContract]
    public class GetWashType
    {
        [DataMember]
        public string LIST_CODE { get; set; }
        [DataMember]
        public string LIST_DESC { get; set; }
    }


    #region PullAPIToken
    [DataContract]
    public class APIToken
    {
        [DataMember]
        public string Token { get; set; }
        
    }
    #endregion


    [DataContract]
    public class CRERemarkPopUp //Added on 31 March 2023
    {
        [DataMember]
        public string Pn_part_Disc_Amount { get; set; }
        [DataMember]
        public string pn_part_Disc_Perc { get; set; }
        [DataMember]
        public string pn_Labour_Disc_Amount { get; set; }
        [DataMember]
        public string pn_Labour_Disc_Perc { get; set; }
        [DataMember]
        public string pn_CRE_Remark { get; set; }
    }


    #region PullALLConfigurations
    [DataContract]
    public class ALLConfigurations
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Configs { get; set; }
        [DataMember]
        public string LastHitFlag { get; set; }
        [DataMember]
        public string LastHitDate { get; set; }
        [DataMember]
        public string CreationDate { get; set; }
    }
    #endregion

    #region for JCOPartValidate
    [DataContract]
    public class JCOPartValidate
    {
        [DataMember]
        public string PN_PART_NUM { get; set; }
    }
    #endregion

    #region for DemandWarrantyValidate
    [DataContract]
    public class DemandWarrantyValidate
    {
        [DataMember]
        public string PN_VIN { get; set; }
    }
    #endregion


    [DataContract]
    public class MediaRecallStatus
    {
        [DataMember]
        public string LIST_CODE { get; set; }
        [DataMember]
        public string LIST_DESC { get; set; }
    }

    [DataContract]
    public class UpdateRecallStatus
    {
        [DataMember]
        public string LIST_CODE { get; set; }
        [DataMember]
        public string LIST_DESC { get; set; }
    }

    [DataContract]//added on 23 May 2022
    public class CCPList
    {
        [DataMember]
        public string ccp_cd { get; set; }
        [DataMember]
        public string ccp_desc { get; set; }
        [DataMember]
        public string price { get; set; }
    }

    [DataContract]//added on 19 July 2022
    public class InsuranceCompanyMaster
    {
        [DataMember]
        public string ins_comp_cd { get; set; }
        [DataMember]
        public string ins_comp_desc { get; set; }
    }
    [DataContract]//added on 19 July 2022
    public class InsurancePartyMaster
    {
        [DataMember]
        public string ins_party_Cd { get; set; }
        //[DataMember]
        //public string ins_party_desc { get; set; }
        [DataMember]
        public string ins_city { get; set; }
        [DataMember]
        public string ins_state { get; set; }
        [DataMember]
        public string ins_gst_num { get; set; }
        [DataMember]
        public string ins_name { get; set; }
    }

    [DataContract]//added on 19 July 2022
    public class DiscAuthByMaster
    {
        [DataMember]
        public string Disc_auth_by_cd { get; set; }
        [DataMember]
        public string Disc_auth_by_desc { get; set; }
    }
    [DataContract]//added on 19 July 2022
    public class VehDelByMaster
    {
        [DataMember]
        public string veh_delivered_by_cd { get; set; }
        [DataMember]
        public string veh_delivered_by_desc { get; set; }
    }

    //added on 19 July 2022
    [DataContract]
    public class BillDelayReason
    {
        [DataMember]
        public string Bill_delay_reason_cd { get; set; }
        [DataMember]
        public string Bill_delay_reason_desc { get; set; }

    }


    //added on 19 July 2022
    [DataContract]
    public class VariationReason
    {
        [DataMember]
        public string variation_cd { get; set; }
        [DataMember]
        public string variation_desc { get; set; }

    }

    //added on 22 July 2022
    [DataContract]
    public class InvPartyDetails
    {
        [DataMember]
        public string Cust_cd { get; set; }
        [DataMember]
        public string Cust_name { get; set; }
        [DataMember]
        public string State_cd { get; set; }
    }

}