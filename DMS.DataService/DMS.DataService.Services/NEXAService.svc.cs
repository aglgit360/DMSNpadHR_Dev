using System;
using System.Collections.Generic;
using System.Linq;
using NEXA.DataService.ServiceContract;
using System.ServiceModel.Activation;
using NEXA.DataService.DataContract;
using NEXA.DataService.Common.Enum;
using NEXA.DataService.DataLayer;
using System.Data;
using System.ServiceModel.Web;
using System.Data.OracleClient;
using System.Configuration;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Web.Script.Serialization;
using System.IO;
using DMS.DataService.DataContract;
using System.Web;

namespace NEXA.DataService.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class NEXAService : INEXAService
    {
        string jsonResponce = string.Empty;
        JavaScriptSerializer js = new JavaScriptSerializer();
        String encType = string.Empty;
        string constr = ConfigurationManager.ConnectionStrings["conoracle"].ConnectionString;
        string constr_PullApi = ConfigurationManager.ConnectionStrings["conoracle_PullApi"].ConnectionString;
        OracleConnection con;
        OracleCommand cmd;
        DataSet ds;
        OracleDataAdapter da;
        DataTable dt;



        #region All USP from Web.config

        string Usp_DIYJC_PullCustomerContact = ConfigurationManager.AppSettings["Usp_DIYJC_PullCustomerContact"].ToString();
        string Usp_DIYJC_PushCustomerSMS = ConfigurationManager.AppSettings["Usp_DIYJC_PushCustomerSMS"].ToString();
        string Usp_DIYJC_PullSADashboard = ConfigurationManager.AppSettings["Usp_DIYJC_PullSADashboard"].ToString();
        string Usp_JobCardOpeningCustomerAndVehicleMaster = ConfigurationManager.AppSettings["Usp_JobCardOpeningCustomerAndVehicleMaster"].ToString();
        string USP_SP_CHECK_CNG_VEH = ConfigurationManager.AppSettings["USP_SP_CHECK_CNG_VEH"].ToString(); //Added on 19 Dec 2022
        string USP_SP_CNG_TESTING_DUE = ConfigurationManager.AppSettings["USP_SP_CNG_TESTING_DUE"].ToString(); //Added on 19 Dec 2022
        #endregion


        #region for JobCardOpeningCustomerAndVehicleMaster
        /// <summary>
        /// 50.
        /// This function is used the DMS server to returning the Customer And Vehicle Details for job card opening by Using SP PKG_NJCO.SP_GET_NJCO_CUSTVEH_DTL working for Nexa NPAD.
        /// </summary>
        /// <param name="pn_reg_num"></param>
        /// <param name="pn_dealer_cd"></param>
        /// <param name="pn_loc_cd"></param>
        /// <param name="pn_vin"></param>
        /// <returns></returns>
        public BaseListReturnType<JobCardOpeningCustomerAndVehicleMaster> JobCardOpeningCustomerAndVehicleMaster(string pn_reg_num, string pn_dealer_cd, string pn_loc_cd, string pn_vin = "")
        {
            //string err1 = string.Empty;
            //string err2 = string.Empty;
            //string err3 = string.Empty;
            //string err4 = string.Empty;
            //string err5 = string.Empty;
            //string err6 = string.Empty;
            //string err7 = string.Empty;
            //string err8 = string.Empty;
            //string err9 = string.Empty;
            //string err10 = string.Empty;
            //string err11 = string.Empty;
            //string err12 = string.Empty;
            //string err13 = string.Empty;
            //string err14 = string.Empty;
            //string err15 = string.Empty;
            //string err16 = string.Empty;
            //string err17 = string.Empty;
            //string err18 = string.Empty;
            //string err19 = string.Empty;
            //string err20 = string.Empty;
            //string err21 = string.Empty;
            //string err22 = string.Empty;
            //string err23 = string.Empty;
            //string err24 = string.Empty;

            string input = "{ 'pn_reg_num':'" + pn_reg_num + "', 'pn_dealer_cd':'" + pn_dealer_cd + "', 'pn_loc_cd':'" + pn_loc_cd + "', 'pn_vin':'" + pn_vin + "'}";

            BaseListReturnType<JobCardOpeningCustomerAndVehicleMaster> response = new BaseListReturnType<JobCardOpeningCustomerAndVehicleMaster>();

            JobCardOpeningCustomerAndVehicleMaster Typedetail = null;
            List<JobCardOpeningCustomerAndVehicleMaster> Details;

            List<SubscriberDetail> SubscriberDetailList = new List<SubscriberDetail>();
            SubscriberDetail SubscriberDetailList1;

            List<SubscriberHistory> SubscriberHistoryList = new List<SubscriberHistory>();
            SubscriberHistory SubscriberHistoryList1;

            List<CCPDetails> CCPDetailsList = new List<CCPDetails>();
            CCPDetails CCPDetailsList1;

            //List<POHoldup> POholdupList = new List<POHoldup>();
            //POHoldup POholdupList1;

            //err1 = " 1 ";

            try
            {
                if (string.IsNullOrEmpty(pn_vin))// added on 17 December 2019
                {
                    pn_vin = "";
                }


                //if (string.IsNullOrEmpty(PN_FIND_ID))// added on 21 January 2021
                //{
                //    PN_FIND_ID = "";
                //}

                if (string.IsNullOrEmpty(pn_dealer_cd))
                {
                    pn_dealer_cd = "0";
                }

                JobCardOpeningCustomerAndVehicleMaster result = new JobCardOpeningCustomerAndVehicleMaster();
                #region Token Validating //Validate Token
                ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
                DateTime DateOfEval;
                if (!headerInfo.IsAuthenticated)
                {
                    response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                    response.message = Convert.ToString(ServiceMassageCode.ERROR);
                    response.result = null;
                    return response;
                }
                #endregion

                //err2 = " 2 ";

                #region DB Hit
                con = new OracleConnection(constr_PullApi);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_JobCardOpeningCustomerAndVehicleMaster;
                cmd.CommandType = CommandType.StoredProcedure;

                //Input
                //cmd.Parameters.Add("pn_reg_num", OracleType.VarChar).Value = pn_reg_num;
                var pInOut1 = cmd.Parameters.Add("pn_reg_num", OracleType.VarChar, 4000); //consume input-output parameter
                pInOut1.Direction = ParameterDirection.InputOutput;
                pInOut1.Value = pn_reg_num;  //changes added on 6 January 2020




                cmd.Parameters.Add("pn_dealer_cd", OracleType.Number).Value = Convert.ToInt32(pn_dealer_cd);
                cmd.Parameters.Add("pn_loc_cd", OracleType.VarChar).Value = pn_loc_cd;

                cmd.Parameters.Add("pn_vin", OracleType.VarChar).Value = pn_vin;// added on 17 December 2019

                //cmd.Parameters.Add("PN_FIND_ID", OracleType.VarChar).Value = PN_FIND_ID;// added on 21 January 2021

                //for output params
                cmd.Parameters.Add("po_srvbooking_no", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_cust_id", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_cust_name", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_cust_address", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_city", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_state", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_phone", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_mobile", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_pin", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_email", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_vehiclemodel", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_vin", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_rftagno", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_chassisno", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_color", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_ownveh_count", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_veh_sale_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_tv_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_n2n_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_ew_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_mi_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_category", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_tv_sale_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_mi_validity_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_variant_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_variant_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_cust_category", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_ew_type", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_ew_expiry_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_srv_model_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_srv_model_cd", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_tech_cap_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_mcp_package_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_mcp_expiry_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_autocard_no", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_autocard_point", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_complement_dtl", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_last_followup_dtl", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_last_followup_by", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_govt_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_last_csi", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_theft_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_veh_user_name", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_engine_num", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_key_no", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_sold_by", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_mcp_enrol_no", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_mcp_type", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_repair", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_location", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_last_psf_status", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_last_srv_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_next_srv_due", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_next_due_date", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("po_subs_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;// added on 15 November 2019

                //output cursor
                cmd.Parameters.Add("po_subscriber_det", OracleType.Cursor).Direction = ParameterDirection.Output;// added on 15 November 2019

                cmd.Parameters.Add("PO_SUBSCRIPTION_HIST", OracleType.Cursor).Direction = ParameterDirection.Output;// added on 25 December 2019

                cmd.Parameters.Add("po_first_serv_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;// added on 27 February 2020

                cmd.Parameters.Add("po_diy_srv_type", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;// added on 13 April 2020
                cmd.Parameters.Add("po_diy_srv_type_desc", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;// added on 13 April 2020
                cmd.Parameters.Add("po_diy_odometer", OracleType.Number).Direction = ParameterDirection.Output;// added on 13 April 2020
                cmd.Parameters.Add("po_diy_cust_dmd_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;// added on 13 April 2020

                cmd.Parameters.Add("po_model_channel", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;// added on 4 August 2020

                cmd.Parameters.Add("po_Counter_measure", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;// added on 12 January 2021

                //need to remove when on production
                //cmd.Parameters.Add("po_find_id_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;// added on 1 June 2021

                cmd.Parameters.Add("po_ccp_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output; // added on 10 march 2022
                cmd.Parameters.Add("PO_RECALL_PIC_YN", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;//new added column 4 april 2022
                cmd.Parameters.Add("po_ccp_refcur", OracleType.Cursor).Direction = ParameterDirection.Output;//new added cursor 5 May 2022

                cmd.Parameters.Add("po_subsequent_visit_yn", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;//new added 16 Sept 2022

                cmd.Parameters.Add("PO_TC_YN_NEW", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;//new added 27 Oct 2022
                cmd.Parameters.Add("PO_RECALL_PIC_YN_NEW", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;//new added 27 Oct 2022

                //cmd.Parameters.Add("PO_holdup_refcur", OracleType.Cursor).Direction = ParameterDirection.Output; //Added on 22 Nov 2022

                cmd.Parameters.Add("PO_FC_OK_DATE", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;//new added 20 Feb 2023
                cmd.Parameters.Add("PO_CATALYTIC_CONV_NUM", OracleType.VarChar, 50).Direction = ParameterDirection.Output;//new added 20 Feb 2023

                cmd.Parameters.Add("PO_CORP_CUST_FLAG", OracleType.VarChar, 1).Direction = ParameterDirection.Output;//new added 30 June 2023
                cmd.Parameters.Add("PO_CORP_NAME", OracleType.VarChar, 500).Direction = ParameterDirection.Output;//new added 30 June 2023
                cmd.Parameters.Add("po_ccp_renewal_yn", OracleType.VarChar, 500).Direction = ParameterDirection.Output;//new added 29 Jan 2024

                cmd.Parameters.Add("po_err_cd", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("po_err_msg", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;


                //err3 = " 3 ";

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //err4 = " 4 ";

                cmd.ExecuteNonQuery();

                //err5 = " 5 ";

                OracleDataReader rdrSubscriberDetail;
                OracleDataReader rdrSubscriberHistory;
                OracleDataReader po_ccp_refcur;
                //OracleDataReader PO_holdup_refcur;//Added on 22 Nov 2022

                rdrSubscriberDetail = (OracleDataReader)cmd.Parameters["po_subscriber_det"].Value;
                rdrSubscriberHistory = (OracleDataReader)cmd.Parameters["PO_SUBSCRIPTION_HIST"].Value;
                po_ccp_refcur = (OracleDataReader)cmd.Parameters["po_ccp_refcur"].Value;//Added on 5 May 2022
                //PO_holdup_refcur = (OracleDataReader)cmd.Parameters["PO_holdup_refcur"].Value;//Added on 22 Nov 2022

                #endregion
                //// string outputStr = string.Empty;
                //if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                //{
                //    response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                //    response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                //    response.result = null;
                //    con.Close();
                //    cmd.Dispose();
                //    return response;
                //}

                //err6 = " 6 ";

                #region Code to check Error Message
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                {
                    if (!string.IsNullOrEmpty(cmd.Parameters["po_err_cd"].Value.ToString()))
                    {
                        if (Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString()) != 0)
                        {
                            try
                            {
                                response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                            }
                            catch
                            {
                                response.code = 100; //(int)ServiceMassageCode.ERROR;
                            }
                            response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                            response.result = null;
                            string Msg = "{'Message from DMS', 'po_err_cd':'" + response.code + "', 'po_err_msg':'" + response.message + "'}";
                            ErrorLog.SuccessLog("NEXAService_JobCardOpeningCustomerAndVehicleMaster", ConfigurationManager.AppSettings["Usp_JobCardOpeningCustomerAndVehicleMaster"].ToString(), input, Msg);
                            con.Close();
                            cmd.Dispose();
                            return response;
                        }
                    }
                    else
                    {
                        try
                        {
                            response.code = Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString());
                        }
                        catch
                        {
                            response.code = 100; //(int)ServiceMassageCode.ERROR;
                        }
                        response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                        string Msg = "{'Message from DMS', 'po_err_cd':'" + response.code + "', 'po_err_msg':'" + response.message + "'}";
                        ErrorLog.SuccessLog("NEXAService_JobCardOpeningCustomerAndVehicleMaster", ConfigurationManager.AppSettings["Usp_JobCardOpeningCustomerAndVehicleMaster"].ToString(), input, Msg);
                        response.result = null;
                        con.Close();
                        cmd.Dispose();
                        return response;
                    }
                }
                #endregion

                #region Assigning Values
                Details = new List<JobCardOpeningCustomerAndVehicleMaster>();

                SubscriberDetailList = new List<SubscriberDetail>();
                SubscriberHistoryList = new List<SubscriberHistory>();
                CCPDetailsList = new List<CCPDetails>();//Added on 5 May 2022
                //POholdupList = new List<POHoldup>();//Added on 22 Nov 2022
                #region rdrSubscriberDetail
                if (rdrSubscriberDetail.HasRows)
                {
                    while (rdrSubscriberDetail.Read())
                    {
                        SubscriberDetailList1 = new SubscriberDetail();
                        SubscriberDetailList1.DMS_SUBSCRIBER_ID = rdrSubscriberDetail["DMS_SUBSCRIBER_ID"].ToString();
                        SubscriberDetailList1.SUBS_NAME = rdrSubscriberDetail["SUBS_NAME"].ToString();
                        SubscriberDetailList1.SUBS_EMAIL = rdrSubscriberDetail["SUBS_EMAIL"].ToString();
                        SubscriberDetailList1.SUBS_DOB = rdrSubscriberDetail["SUBS_DOB"].ToString();
                        SubscriberDetailList1.SUBS_ADD1 = rdrSubscriberDetail["SUBS_ADD1"].ToString();
                        SubscriberDetailList1.SUBS_ADD2 = rdrSubscriberDetail["SUBS_ADD2"].ToString();
                        SubscriberDetailList1.SUBS_ADD3 = rdrSubscriberDetail["SUBS_ADD3"].ToString();
                        SubscriberDetailList1.SUBS_PIN = rdrSubscriberDetail["SUBS_PIN"].ToString();
                        SubscriberDetailList1.SUBS_CITY_CD = rdrSubscriberDetail["SUBS_CITY_CD"].ToString();
                        SubscriberDetailList1.SUBS_CITY_DESC = rdrSubscriberDetail["SUBS_CITY_DESC"].ToString();
                        SubscriberDetailList1.SUBS_STATE_CD = rdrSubscriberDetail["SUBS_STATE_CD"].ToString();
                        SubscriberDetailList1.SUBS_STATE_DESC = rdrSubscriberDetail["SUBS_STATE_DESC"].ToString();
                        SubscriberDetailList1.SUBS_MOBILE = rdrSubscriberDetail["SUBS_MOBILE"].ToString();

                        SubscriberDetailList.Add(SubscriberDetailList1);
                    }
                }
                #endregion

                #region rdrSubscriberHistory
                if (rdrSubscriberHistory.HasRows)
                {
                    while (rdrSubscriberHistory.Read())
                    {
                        SubscriberHistoryList1 = new SubscriberHistory();
                        SubscriberHistoryList1.DMS_SUBSCRIBER_ID = rdrSubscriberHistory["DMS_SUBSCRIBER_ID"].ToString();
                        SubscriberHistoryList1.SUBS_NAME = rdrSubscriberHistory["SUBS_NAME"].ToString();
                        SubscriberHistoryList1.FROM_DATE = rdrSubscriberHistory["FROM_DATE"].ToString();
                        SubscriberHistoryList1.TO_DATE = rdrSubscriberHistory["TO_DATE"].ToString();
                        SubscriberHistoryList1.SUBS_EMAIL = rdrSubscriberHistory["SUBS_EMAIL"].ToString();
                        SubscriberHistoryList1.SUBS_DOB = rdrSubscriberHistory["SUBS_DOB"].ToString();
                        SubscriberHistoryList1.SUBS_ADD1 = rdrSubscriberHistory["SUBS_ADD1"].ToString();
                        SubscriberHistoryList1.SUBS_ADD2 = rdrSubscriberHistory["SUBS_ADD2"].ToString();
                        SubscriberHistoryList1.SUBS_ADD3 = rdrSubscriberHistory["SUBS_ADD3"].ToString();
                        SubscriberHistoryList1.SUBS_PIN = rdrSubscriberHistory["SUBS_PIN"].ToString();
                        SubscriberHistoryList1.SUBS_CITY_CD = rdrSubscriberHistory["SUBS_CITY_CD"].ToString();
                        SubscriberHistoryList1.SUBS_CITY_DESC = rdrSubscriberHistory["SUBS_CITY_DESC"].ToString();
                        SubscriberHistoryList1.SUBS_STATE_CD = rdrSubscriberHistory["SUBS_STATE_CD"].ToString();
                        SubscriberHistoryList1.SUBS_STATE_DESC = rdrSubscriberHistory["SUBS_STATE_DESC"].ToString();
                        SubscriberHistoryList1.SUBS_MOBILE = rdrSubscriberHistory["SUBS_MOBILE"].ToString();

                        SubscriberHistoryList.Add(SubscriberHistoryList1);
                    }
                }
                #endregion

                #region po_ccp_refcur //Added on 5 May 2022
                if (po_ccp_refcur.HasRows)
                {
                    while (po_ccp_refcur.Read())
                    {
                        CCPDetailsList1 = new CCPDetails();
                        CCPDetailsList1.CCP_PolicyNo = po_ccp_refcur["CCP_PolicyNo"].ToString();
                        CCPDetailsList1.CCP_Validity = po_ccp_refcur["CCP_Validity"].ToString();
                        CCPDetailsList1.CCP_Description = po_ccp_refcur["CCP_Description"].ToString();
                        try
                        {
                            CCPDetailsList1.ccp_renewable_yn = po_ccp_refcur["ccp_renewable_yn"].ToString(); //Added on 24 April 2023
                        }
                        catch (Exception)
                        {
                            CCPDetailsList1.ccp_renewable_yn = ""; //Added on 24 April 2023
                        }

                        CCPDetailsList.Add(CCPDetailsList1);
                    }
                }
                #endregion

                //#region po_HoldUp_refcur //Added on 22 Nov 2022
                //if (PO_holdup_refcur.HasRows)
                //{
                //    while (PO_holdup_refcur.Read())
                //    {
                //        POholdupList1 = new POHoldup();
                //        POholdupList1.REASON_CD = PO_holdup_refcur["REASON_CD"].ToString();
                //        POholdupList1.REASON_DESC = PO_holdup_refcur["REASON_DESC"].ToString();
                //        POholdupList1.REASON_TYPE = PO_holdup_refcur["REASON_TYPE"].ToString();
                //        POholdupList.Add(POholdupList1);
                //    }
                //}
                //#endregion

                Typedetail = new JobCardOpeningCustomerAndVehicleMaster();

                Typedetail.SubscriberDetail = SubscriberDetailList;
                Typedetail.SubscriberHistory = SubscriberHistoryList;
                Typedetail.CCPDetails = CCPDetailsList;//Added on 5 May 2022
                //Typedetail.POHoldup = POholdupList;//Added on 22 Nov 2022


                Typedetail.pn_reg_num = cmd.Parameters["pn_reg_num"].Value.ToString(); //consume input-output parameter

                Typedetail.po_srvbooking_no = cmd.Parameters["po_srvbooking_no"].Value.ToString();
                Typedetail.po_cust_id = cmd.Parameters["po_cust_id"].Value.ToString();
                Typedetail.po_cust_name = cmd.Parameters["po_cust_name"].Value.ToString();
                Typedetail.po_cust_address = cmd.Parameters["po_cust_address"].Value.ToString();
                Typedetail.po_city = cmd.Parameters["po_city"].Value.ToString();
                Typedetail.po_state = cmd.Parameters["po_state"].Value.ToString();
                Typedetail.po_phone = cmd.Parameters["po_phone"].Value.ToString();
                Typedetail.po_mobile = cmd.Parameters["po_mobile"].Value.ToString();
                Typedetail.po_pin = cmd.Parameters["po_pin"].Value.ToString();
                Typedetail.po_email = cmd.Parameters["po_email"].Value.ToString();
                Typedetail.po_vehiclemodel = cmd.Parameters["po_vehiclemodel"].Value.ToString();
                Typedetail.po_vin = cmd.Parameters["po_vin"].Value.ToString();
                Typedetail.po_rftagno = cmd.Parameters["po_rftagno"].Value.ToString();
                Typedetail.po_chassisno = cmd.Parameters["po_chassisno"].Value.ToString();
                Typedetail.po_color = cmd.Parameters["po_color"].Value.ToString();
                Typedetail.po_ownveh_count = cmd.Parameters["po_ownveh_count"].Value.ToString();
                Typedetail.po_veh_sale_date = cmd.Parameters["po_veh_sale_date"].Value.ToString();
                Typedetail.po_tv_yn = cmd.Parameters["po_tv_yn"].Value.ToString();
                Typedetail.po_n2n_yn = cmd.Parameters["po_n2n_yn"].Value.ToString();
                Typedetail.po_ew_yn = cmd.Parameters["po_ew_yn"].Value.ToString();
                Typedetail.po_mi_yn = cmd.Parameters["po_mi_yn"].Value.ToString();
                Typedetail.po_category = cmd.Parameters["po_category"].Value.ToString();
                Typedetail.po_tv_sale_date = cmd.Parameters["po_tv_sale_date"].Value.ToString();
                Typedetail.po_mi_validity_date = cmd.Parameters["po_mi_validity_date"].Value.ToString();
                Typedetail.po_variant_cd = cmd.Parameters["po_variant_cd"].Value.ToString();
                Typedetail.po_variant_desc = cmd.Parameters["po_variant_desc"].Value.ToString();
                Typedetail.po_cust_category = cmd.Parameters["po_cust_category"].Value.ToString();
                Typedetail.po_ew_type = cmd.Parameters["po_ew_type"].Value.ToString();
                Typedetail.po_ew_expiry_date = cmd.Parameters["po_ew_expiry_date"].Value.ToString();
                Typedetail.po_srv_model_desc = cmd.Parameters["po_srv_model_desc"].Value.ToString();
                Typedetail.po_srv_model_cd = cmd.Parameters["po_srv_model_cd"].Value.ToString();
                Typedetail.po_tech_cap_yn = cmd.Parameters["po_tech_cap_yn"].Value.ToString();
                Typedetail.po_mcp_package_desc = cmd.Parameters["po_mcp_package_desc"].Value.ToString();
                Typedetail.po_mcp_expiry_date = cmd.Parameters["po_mcp_expiry_date"].Value.ToString();
                Typedetail.po_autocard_no = cmd.Parameters["po_autocard_no"].Value.ToString();
                Typedetail.po_autocard_point = cmd.Parameters["po_autocard_point"].Value.ToString();
                Typedetail.po_complement_dtl = cmd.Parameters["po_complement_dtl"].Value.ToString();
                Typedetail.po_last_followup_dtl = cmd.Parameters["po_last_followup_dtl"].Value.ToString();
                Typedetail.po_last_followup_by = cmd.Parameters["po_last_followup_by"].Value.ToString();
                Typedetail.po_govt_yn = cmd.Parameters["po_govt_yn"].Value.ToString();
                Typedetail.po_last_csi = cmd.Parameters["po_last_csi"].Value.ToString();
                Typedetail.po_theft_yn = cmd.Parameters["po_theft_yn"].Value.ToString();

                Typedetail.po_veh_user_name = cmd.Parameters["po_veh_user_name"].Value.ToString();
                Typedetail.po_engine_num = cmd.Parameters["po_engine_num"].Value.ToString();
                Typedetail.po_key_no = cmd.Parameters["po_key_no"].Value.ToString();
                Typedetail.po_sold_by = cmd.Parameters["po_sold_by"].Value.ToString();
                Typedetail.po_mcp_enrol_no = cmd.Parameters["po_mcp_enrol_no"].Value.ToString();
                Typedetail.po_mcp_type = cmd.Parameters["po_mcp_type"].Value.ToString();
                Typedetail.po_repair = cmd.Parameters["po_repair"].Value.ToString();
                Typedetail.po_location = cmd.Parameters["po_location"].Value.ToString();
                Typedetail.po_last_psf_status = cmd.Parameters["po_last_psf_status"].Value.ToString();
                Typedetail.po_last_srv_date = cmd.Parameters["po_last_srv_date"].Value.ToString();
                Typedetail.po_next_srv_due = cmd.Parameters["po_next_srv_due"].Value.ToString();
                Typedetail.po_next_due_date = cmd.Parameters["po_next_due_date"].Value.ToString();

                Typedetail.po_subs_yn = cmd.Parameters["po_subs_yn"].Value.ToString();// added on 15 November 2019

                Typedetail.po_first_serv_yn = cmd.Parameters["po_first_serv_yn"].Value.ToString();// added on 27 February 2020

                Typedetail.po_diy_srv_type = cmd.Parameters["po_diy_srv_type"].Value.ToString();// added on 13 April 2020
                Typedetail.po_diy_srv_type_desc = cmd.Parameters["po_diy_srv_type_desc"].Value.ToString();// added on 13 April 2020
                //Typedetail.po_diy_odometer = Convert.ToInt32(cmd.Parameters["po_diy_odometer"].Value.ToString()).ToString();// added on 13 April 2020
                Typedetail.po_diy_odometer = cmd.Parameters["po_diy_odometer"].Value.ToString();// added on 13 April 2020
                Typedetail.po_diy_cust_dmd_yn = cmd.Parameters["po_diy_cust_dmd_yn"].Value.ToString();// added on 13 April 2020

                Typedetail.po_model_channel = cmd.Parameters["po_model_channel"].Value.ToString();// added on 4 August 2020

                Typedetail.po_Counter_measure = cmd.Parameters["po_Counter_measure"].Value.ToString();// added on 12 January 2021

                // Typedetail.po_find_id_yn = cmd.Parameters["po_find_id_yn"].Value.ToString();// added on 1 June 2021

                Typedetail.po_ccp_yn = cmd.Parameters["po_ccp_yn"].Value.ToString();  // added on 10 Mrach 2022
                Typedetail.po_recall_pic_yn = cmd.Parameters["PO_RECALL_PIC_YN"].Value.ToString();  // added on 4 April 2022

                Typedetail.po_subsequent_visit_yn = cmd.Parameters["po_subsequent_visit_yn"].Value.ToString();  // added on 16 sept 2022

                Typedetail.PO_TC_YN_NEW = cmd.Parameters["PO_TC_YN_NEW"].Value.ToString();  // added on 27 Oct 2022
                Typedetail.PO_RECALL_PIC_YN_NEW = cmd.Parameters["PO_RECALL_PIC_YN_NEW"].Value.ToString();  // added on 27 Oct 2022

                Typedetail.PO_FC_OK_DATE = cmd.Parameters["PO_FC_OK_DATE"].Value.ToString();  // added on 20 Feb 2023
                Typedetail.PO_CATALYTIC_CONV_NUM = cmd.Parameters["PO_CATALYTIC_CONV_NUM"].Value.ToString();  // added on 20 Feb 2023

                Typedetail.PO_CORP_CUST_FLAG = cmd.Parameters["PO_CORP_CUST_FLAG"].Value.ToString();  // added on 30 June 2023
                Typedetail.PO_CORP_NAME = cmd.Parameters["PO_CORP_NAME"].Value.ToString();  // added on 30 June 2023
                Typedetail.po_ccp_renewal_yn = cmd.Parameters["po_ccp_renewal_yn"].Value.ToString();  // added on 20 Jan 2024

                Details.Add(Typedetail);
                #endregion

                //response.code = (int)ServiceMassageCode.SUCCESS;
                //response.message = Convert.ToString(ServiceMassageCode.SUCCESS);

                response.code = (int)ServiceMassageCode.SUCCESS;
                if (!string.IsNullOrEmpty(cmd.Parameters["po_err_cd"].Value.ToString()))
                {
                    if (Convert.ToInt32(cmd.Parameters["po_err_cd"].Value.ToString()) == 0)
                    {
                        if (!string.IsNullOrEmpty(cmd.Parameters["po_err_msg"].Value.ToString()))
                        {
                            response.message = cmd.Parameters["po_err_msg"].Value.ToString();
                        }
                        else
                        {
                            response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                        }
                    }
                    else
                    {
                        response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                    }
                }
                else
                {
                    response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                }

                response.result = Details;

                string outputPara = "{ 'po_err_cd':'" + response.code + "', 'po_err_msg':'" + response.message + "'}";
                ErrorLog.SuccessLog("NEXAService_JobCardOpeningCustomerAndVehicleMaster", ConfigurationManager.AppSettings["Usp_JobCardOpeningCustomerAndVehicleMaster"].ToString(), input, outputPara);

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLogException("NEXAService_JobCardOpeningCustomerAndVehicleMaster", ConfigurationManager.AppSettings["Usp_JobCardOpeningCustomerAndVehicleMaster"].ToString(), input, ex);

                // CreateLogFiles Err = new CreateLogFiles();
                // Err.ErrorLog((@"ErrorLog/Logfile"), ex.Message);

                //Logging.Error(ex, "DMS:PushEvaluaton");

                //ErrorLog.LogException(ex, "NEXAService_JobCardOpeningCustomerAndVehicleMaster");

                //ErrorLog.LogException(ex, "NEXAService_JobCardOpeningCustomerAndVehicleMaster" + ex.Message + "=: " + err1 + err2 + err3 + err4 + err5 + err6 + err7 + err8 + err9 + err10 + err11 + err12 + err13 + err14 + err15 + err16 + err17 + err18 + err19 + err20 + err21 + err22 + err23 + err24);

                response.code = 100; //(int)ServiceMassageCode.ERROR;

                /*response.message = ex.Message;*/ //Convert.ToString(ServiceMassageCode.ERROR);
                                                   // response.result = null;

                response.message = ex.Message;
                //response.message = ex.Message + "=: " + err1 + err2 + err3 + err4 + err5 + err6 + err7 + err8 + err9 + err10 + err11 + err12 + err13 + err14 + err15 + err16 + err17 + err18 + err19 + err20 + err21 + err22 + err23 + err24;

                //response.result = null;

                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

       
        #region DIY JC - Do It Yourself JobCard
        #region for DIYJC_PullCustomerContact
        /// <summary>
        /// 112. 
        /// This function is used the DMS server to Returning the  Customer Contact Details for DIYJC like PO_DEALER_CD, PO_CAR_USER_NUM, PO_CUST_MOBILE_NUM, PO_CONTACT_YN etc. by Using SP PKG_DIY_JC.SP_GET_CONTACT working for Nexa NPAD.
        /// </summary>
        /// <param name="PN_USER_ID"></param>
        /// <param name="PN_REG_NUM"></param>
        /// <param name="PN_VIN"></param>
        /// <returns></returns>
        public BaseListReturnType<DIYJC_PullCustomerContact> DIYJC_PullCustomerContact(string PN_USER_ID, string PN_REG_NUM, string PN_VIN)
        {
            string input = "{ 'PN_USER_ID':'" + PN_USER_ID + "', 'PN_REG_NUM':'" + PN_REG_NUM + "', 'PN_VIN':'" + PN_VIN + "'}";
            BaseListReturnType<DIYJC_PullCustomerContact> response = new BaseListReturnType<DIYJC_PullCustomerContact>();

            List<DIYJC_ContactList> DIYJCContactList = new List<DIYJC_ContactList>();
            DIYJC_ContactList DIYJCContactList1;

            DIYJC_PullCustomerContact Typedetail = null;
            List<DIYJC_PullCustomerContact> Details;

            //ServiceHeaderInfo1 headerInfo = ServiceHelper.Authenticate2(WebOperationContext.Current.IncomingRequest);
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            #region Token Validating //Validate Token
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion

            try
            {
                #region DB Hit
                con = new OracleConnection(constr_PullApi);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_DIYJC_PullCustomerContact;
                cmd.CommandType = CommandType.StoredProcedure;

                //Input
                cmd.Parameters.Add("PN_USER_ID", OracleType.VarChar).Value = PN_USER_ID;

                var pInOut1 = cmd.Parameters.Add("PN_REG_NUM", OracleType.VarChar, 4000); //consume input-output parameter
                pInOut1.Direction = ParameterDirection.InputOutput;
                pInOut1.Value = PN_REG_NUM;

                cmd.Parameters.Add("PN_VIN", OracleType.VarChar).Value = PN_VIN;

                //for output params
                cmd.Parameters.Add("PO_DEALER_CD", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PO_CAR_USER_NUM", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PO_CUST_MOBILE_NUM", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PO_CONTACT_YN", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                //added contact numbers for DIYJC Enhancement
                cmd.Parameters.Add("PO_MOB_OUT", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PO_ERR_CD", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PO_ERR_MSG", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                #endregion

                #region Code to check Error Message
                if (!string.IsNullOrEmpty(cmd.Parameters["PO_ERR_MSG"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["PO_ERR_CD"].Value.ToString());
                    response.message = cmd.Parameters["PO_ERR_MSG"].Value.ToString();
                    string Msg = "{'Message from DMS', 'po_err_cd':'" + response.code + "', 'po_err_msg':'" + response.message + "'}";
                    ErrorLog.SuccessLog("DIYJC_PullCustomerContact", "PKG_DIY_JC.SP_GET_CONTACT", input, "Code " + response.code + " Message " + response.message);
                    response.result = null;
                    con.Close();
                    return response;
                }
                #endregion

                OracleDataReader rdrDIYJCContactDetail;
                rdrDIYJCContactDetail = (OracleDataReader)cmd.Parameters["PO_MOB_OUT"].Value;

                #region rdrSubscriberDetail
                if (rdrDIYJCContactDetail.HasRows)
                {
                    while (rdrDIYJCContactDetail.Read())
                    {
                        DIYJCContactList1 = new DIYJC_ContactList();
                        DIYJCContactList1.MOBILE_NUM = Convert.ToString(rdrDIYJCContactDetail["MOBILE_NUM"]);
                        DIYJCContactList1.REG_MOBILE_NUM = Convert.ToString(rdrDIYJCContactDetail["REG_MOBILE_NUM"]);
                        DIYJCContactList1.MI_MOBILE_NUM = Convert.ToString(rdrDIYJCContactDetail["MI_MOBILE_NUM"]);
                        DIYJCContactList.Add(DIYJCContactList1);
                    }
                }
                #endregion

                #region Assigning Values
                Details = new List<DIYJC_PullCustomerContact>();

                Typedetail = new DIYJC_PullCustomerContact();

                Typedetail.PN_USER_ID = PN_USER_ID;
                Typedetail.PN_REG_NUM = cmd.Parameters["PN_REG_NUM"].Value.ToString(); //consume input-output parameter
                Typedetail.PN_VIN = PN_VIN;

                Typedetail.PO_DEALER_CD = cmd.Parameters["PO_DEALER_CD"].Value.ToString();
                Typedetail.PO_CAR_USER_NUM = cmd.Parameters["PO_CAR_USER_NUM"].Value.ToString();
                Typedetail.PO_CUST_MOBILE_NUM = cmd.Parameters["PO_CUST_MOBILE_NUM"].Value.ToString();
                Typedetail.PO_CONTACT_YN = cmd.Parameters["PO_CONTACT_YN"].Value.ToString();

                //Added for new contact details for DIYJC
                Typedetail.PO_MOB_OUT = DIYJCContactList;

                Details.Add(Typedetail);
                #endregion

                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
                ErrorLog.SuccessLog("DIYJC_PullCustomerContact", "PKG_DIY_JC.SP_GET_CONTACT", input, "Code " + response.code + " Message " + response.message);
            }
            catch (Exception ex)
            {

                ErrorLog.ErrorLogException("DIYJC_PullCustomerContact", "PKG_DIY_JC.SP_GET_CONTACT", input, ex);
                //ErrorLog.LogException(ex, "NEXAService_DIYJC_PullCustomerContact");

                response.code = (int)ServiceMassageCode.ERROR; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region for DIYJC_PushCustomerSMS
        /// <summary>
        /// 113. 
        /// This function is used the DMS server to Push the Customer SMS for DIYJC  by Using SP PKG_DIY_JC.SP_SEND_SMS working for Nexa NPAD.
        /// </summary>
        /// <param name="PN_USER_ID"></param>
        /// <param name="PN_REG_NUM"></param>
        /// <param name="PN_SMS_NUM"></param>
        /// <param name="PN_SMS_LINK"></param>
        /// <returns></returns>
        public BaseListReturnType<DIYJC_PushCustomerSMS> DIYJC_PushCustomerSMS(string PN_USER_ID, string PN_REG_NUM, string PN_SMS_NUM, string PN_SMS_LINK)
        {
            string input = "{ 'PN_USER_ID':'" + PN_USER_ID + "', 'PN_REG_NUM':'" + PN_REG_NUM + "', 'PN_SMS_NUM':'" + PN_SMS_NUM + "', 'PN_SMS_LINK':'" + PN_SMS_LINK + "'}";

            BaseListReturnType<DIYJC_PushCustomerSMS> response = new BaseListReturnType<DIYJC_PushCustomerSMS>();
            try
            {
                DIYJC_PushCustomerSMS result = new DIYJC_PushCustomerSMS();
                ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
                #region Token Validating //Validate Token
                if (!headerInfo.IsAuthenticated)
                {
                    response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                    response.message = Convert.ToString(ServiceMassageCode.ERROR);
                    response.result = null;
                    return response;
                }
                #endregion

                con = new OracleConnection(constr);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_DIYJC_PushCustomerSMS;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PN_USER_ID", OracleType.VarChar).Value = PN_USER_ID;
                cmd.Parameters.Add("PN_REG_NUM", OracleType.VarChar).Value = PN_REG_NUM;
                cmd.Parameters.Add("PN_SMS_NUM", OracleType.VarChar).Value = PN_SMS_NUM;
                cmd.Parameters.Add("PN_SMS_LINK", OracleType.VarChar).Value = PN_SMS_LINK;

                //for output params
                cmd.Parameters.Add("PO_ERR_CD", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PO_ERR_MSG", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                if (!string.IsNullOrEmpty(cmd.Parameters["PO_ERR_MSG"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["PO_ERR_CD"].Value.ToString());
                    response.message = cmd.Parameters["PO_ERR_MSG"].Value.ToString();
                    string Msg = "{'Message from DMS', 'po_err_cd':'" + response.code + "', 'po_err_msg':'" + response.message + "'}";
                    ErrorLog.SuccessLog("DIYJC_PushCustomerSMS", "PKG_DIY_JC.SP_SEND_SMS", input, Msg);
                    response.result = null;
                    con.Close();
                    cmd.Dispose();
                    return response;
                }

                con.Close();
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                ErrorLog.SuccessLog("DIYJC_PushCustomerSMS", "PKG_DIY_JC.SP_SEND_SMS", input, "Code " + response.code + " Message " + response.message);
                // response.result = result;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLogException("DIYJC_PushCustomerSMS", "PKG_DIY_JC.SP_SEND_SMS", input, ex);
                // ErrorLog.LogException(ex, "NEXAService_DIYJC_PushCustomerSMS");
                response.code = 100; //(int)ServiceMassageCode.ERROR;
                response.message = ex.Message; //Convert.ToString(ServiceMassageCode.ERROR);
                                               // response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

       

        #region for DIYJC_PullSADashboard
        /// <summary>
        /// 117. 
        /// This function is used the DMS server to Pull the SA Dashboard details list like SENT_DATE, RECEIVE_DATE, SA_NAME, CUST_NAME, REG_NUM, VIN etc. by Using SP PKG_DIY_JC.SP_GET_EXIST_DMD working for Nexa NPAD.
        /// </summary>
        /// <param name="PN_USER_ID"></param>
        /// <returns></returns>
        public BaseListReturnType<DIYJC_PullSADashboard> DIYJC_PullSADashboard(string PN_USER_ID)
        {
            string input = "{ 'PN_USER_ID':'" + PN_USER_ID + "'}";
            BaseListReturnType<DIYJC_PullSADashboard> response = new BaseListReturnType<DIYJC_PullSADashboard>();

            DIYJC_PullSADashboard Typedetail = null;
            List<DIYJC_PullSADashboard> Details;

            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            #region Token Validating //Validate Token
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion
            try
            {
                con = new OracleConnection(constr_PullApi);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = Usp_DIYJC_PullSADashboard;
                cmd.CommandType = CommandType.StoredProcedure;

                //Input
                cmd.Parameters.Add("PN_USER_ID", OracleType.VarChar).Value = PN_USER_ID;

                cmd.Parameters.Add("PO_SRV_ADV_REFCUR", OracleType.Cursor).Direction = ParameterDirection.Output;// output Ref Cursor

                cmd.Parameters.Add("PO_ERR_CD", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PO_ERR_MSG", OracleType.VarChar, 4000).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                da = new OracleDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (!string.IsNullOrEmpty(cmd.Parameters["PO_ERR_MSG"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["PO_ERR_CD"].Value.ToString());
                    response.message = cmd.Parameters["PO_ERR_MSG"].Value.ToString();
                    string Msg = "{'Message from DMS', 'po_err_cd':'" + response.code + "', 'po_err_msg':'" + response.message + "'}";
                    ErrorLog.SuccessLog("DIYJC_PullSADashboard", "PKG_DIY_JC.SP_GET_EXIST_DMD", input, Msg);
                    response.result = null;
                    con.Close();
                    return response;
                }
                // con.Close();
                Details = new List<DIYJC_PullSADashboard>();
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    var detailTable = ds.Tables[0];
                    if (detailTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Typedetail = new DIYJC_PullSADashboard();

                            Typedetail.SENT_DATE = Convert.ToString(row["SENT_DATE"]);
                            Typedetail.RECEIVE_DATE = Convert.ToString(row["RECEIVE_DATE"]);
                            Typedetail.SA_NAME = Convert.ToString(row["SA_NAME"]);
                            Typedetail.CUST_NAME = Convert.ToString(row["CUST_NAME"]);
                            Typedetail.REG_NUM = Convert.ToString(row["REG_NUM"]);
                            Typedetail.VIN = Convert.ToString(row["VIN"]);
                            Typedetail.ODOMETER_READING = Convert.ToString(row["ODOMETER_READING"]);
                            Typedetail.RCATEG_CD = Convert.ToString(row["RCATEG_CD"]);
                            Typedetail.RCATEG_DESC = Convert.ToString(row["RCATEG_DESC"]);
                            Typedetail.STATUS = Convert.ToString(row["STATUS"]);

                            Details.Add(Typedetail);
                        }
                    }
                }
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;

                ErrorLog.SuccessLog("DIYJC_PullSADashboard", "PKG_DIY_JC.SP_GET_EXIST_DMD", input, "Code " + response.code + " Message " + response.message);

            }
            catch (Exception ex)
            {

                ErrorLog.ErrorLogException("DIYJC_PullSADashboard", "PKG_DIY_JC.SP_GET_EXIST_DMD", input, ex);
                // ErrorLog.LogException(ex, "NEXAService_DIYJC_PullSADashboard");
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

       
        #endregion

        //Added on 19 Dec 2022
        #region for GET MSG for CNG Vehicle
        /// <summary>
        /// 147. This function is used the DMS server to returning MSG for CNG Vehicle by Using SP_CHECK_CNG_VEH working for Nexa NPAD. If PO_CNG_MSG not Null then vehicle is CNG
        /// </summary>
        /// <param name="PN_VIN"></param>
        /// <returns></returns>
        public BaseListReturnType<CheckCNGVehicle> GetDTLCNGVehicle(string PN_VIN)
        {

            string input = "{ 'PN_VIN':'" + PN_VIN + "'}";
            BaseListReturnType<CheckCNGVehicle> response = new BaseListReturnType<CheckCNGVehicle>();

            //Validate Token
            #region Token Validating 
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion
            CheckCNGVehicle Typedetail = null;
            List<CheckCNGVehicle> Details = new List<CheckCNGVehicle>();

            try
            {
                con = new OracleConnection(constr_PullApi);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = USP_SP_CHECK_CNG_VEH;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("PN_VIN", OracleType.VarChar).Value = PN_VIN;
                cmd.Parameters.Add("PO_CNG_MSG", OracleType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PO_ERR_CD", OracleType.Number, 8).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PO_ERR_MSG", OracleType.VarChar, 500).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                if (!string.IsNullOrEmpty(cmd.Parameters["PO_ERR_MSG"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["PO_ERR_CD"].Value.ToString());
                    response.message = cmd.Parameters["PO_ERR_MSG"].Value.ToString();
                    string Msg = "{'Message from DMS', 'PO_ERR_CD':'" + response.code + "', 'PO_ERR_MSG':'" + response.message + "'}";
                    ErrorLog.SuccessLog("GetDTLCNGVehicle", "PKG_JCO_1.SP_CHECK_CNG_VEH", input, Msg);
                    response.result = null;
                    con.Close();
                    return response;
                }
                Details = new List<CheckCNGVehicle>();
                Typedetail = new CheckCNGVehicle();
                Typedetail.PO_CNG_MSG = cmd.Parameters["PO_CNG_MSG"].Value.ToString();
                Details.Add(Typedetail);
                con.Close();
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
                ErrorLog.SuccessLog("GetDTLCNGVehicle", "PKG_JCO_1.SP_CHECK_CNG_VEH", input, "Code " + response.code + " Message " + response.message);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLogException("GetDTLCNGVehicle", "PKG_JCO_1.SP_CHECK_CNG_VEH", input, ex);
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        //Added on 19 Dec 2022
        #region for GET CNG Testing due Date
        /// <summary>
        /// 148. This function is used the DMS server to returning CNG Testing due Date by Using SP_CNG_TESTING_DUE working for Nexa NPAD.
        /// </summary>
        /// <param name="PN_TESTING_DATE"></param>
        /// <returns></returns>
        public BaseListReturnType<CNGTestingdueDate> GetCNGTestingdueDate(string PN_TESTING_DATE)
        {

            string input = "{ 'PN_TESTING_DATE ':'" + PN_TESTING_DATE + "'}";
            BaseListReturnType<CNGTestingdueDate> response = new BaseListReturnType<CNGTestingdueDate>();

            //Validate Token
            #region Token Validating 
            ServiceHeaderInfo headerInfo = ServiceHelper.Authenticate(WebOperationContext.Current.IncomingRequest);
            if (!headerInfo.IsAuthenticated)
            {
                response.code = (int)ServiceMassageCode.UNAUTHORIZED_REQUEST;
                response.message = Convert.ToString(ServiceMassageCode.ERROR);
                response.result = null;
                return response;
            }
            #endregion
            CNGTestingdueDate Typedetail = null;
            List<CNGTestingdueDate> Details = new List<CNGTestingdueDate>();

            //PN_TESTING_DATE = ServiceHelper.GetDateFormat(PN_TESTING_DATE);

            try
            {
                con = new OracleConnection(constr_PullApi);
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = USP_SP_CNG_TESTING_DUE;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("PN_TESTING_DATE", OracleType.VarChar).Value = PN_TESTING_DATE;
                cmd.Parameters.Add("PO_TESTING_DUE", OracleType.VarChar, 200).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PO_MSG", OracleType.VarChar, 200).Direction = ParameterDirection.Output;  //Added on 22 Dec 2022

                cmd.Parameters.Add("PO_ERR_CD", OracleType.Number, 8).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PO_ERR_MSG", OracleType.VarChar, 500).Direction = ParameterDirection.Output;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                if (!string.IsNullOrEmpty(cmd.Parameters["PO_ERR_MSG"].Value.ToString()))
                {
                    response.code = Convert.ToInt32(cmd.Parameters["PO_ERR_CD"].Value.ToString());
                    response.message = cmd.Parameters["PO_ERR_MSG"].Value.ToString();
                    string Msg = "{'Message from DMS', 'PO_ERR_CD':'" + response.code + "', 'PO_ERR_MSG':'" + response.message + "'}";
                    ErrorLog.SuccessLog("GetCNGTestingdueDate", "PKG_JCO_1.SP_CNG_TESTING_DUE", input, Msg);
                    response.result = null;
                    con.Close();
                    return response;
                }
                Details = new List<CNGTestingdueDate>();
                Typedetail = new CNGTestingdueDate();
                Typedetail.PO_TESTING_DUE = cmd.Parameters["PO_TESTING_DUE"].Value.ToString();
                if (string.IsNullOrEmpty(cmd.Parameters["PO_MSG"].Value.ToString()))//Added on 22 Dec 2022
                {
                    Typedetail.PO_MSG = "";//Added on 22 Dec 2022
                }
                else
                {
                    Typedetail.PO_MSG = cmd.Parameters["PO_MSG"].Value.ToString();//Added on 22 Dec 2022
                }


                Details.Add(Typedetail);
                con.Close();
                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = Convert.ToString(ServiceMassageCode.SUCCESS);
                response.result = Details;
                ErrorLog.SuccessLog("GetCNGTestingdueDate", "PKG_JCO_1.SP_CNG_TESTING_DUE", input, "Code " + response.code + " Message " + response.message);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLogException("GetCNGTestingdueDate", "PKG_JCO_1.SP_CHECK_CNG_VEH", input, ex);
                response.code = (int)ServiceMassageCode.ERROR;
                response.message = ex.Message;
                response.result = null;
                con.Close();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                OracleConnection.ClearPool(con);
            }
            return response;
        }
        #endregion

        #region Read Log
        /// <summary>
        /// 102
        /// This function is used read log file from DMS server working for Nexa NPAD.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public BaseListReturnType<string> ReadLogFiles(string fileName)
        {
            BaseListReturnType<string> response = new BaseListReturnType<string>();

            try
            {
                string logFilePath = ConfigurationManager.AppSettings["PullAppLogPath"].ToString();

                string logFile = logFilePath + fileName;

                string res = File.ReadAllText(logFile).ToString();

                response.code = (int)ServiceMassageCode.SUCCESS;
                response.message = res;
            }
            catch (Exception Ex)
            {
                response.code = 100;
                response.message = Ex.Message;
            }
            return response;
        }
        #endregion

    }
}