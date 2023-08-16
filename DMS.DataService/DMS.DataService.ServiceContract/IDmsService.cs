using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using NEXA.DataService.DataContract;
using DMS.DataService.DataContract;

namespace NEXA.DataService.ServiceContract
{
    [ServiceContract]
    public interface INEXAService
    {
        #region JobCardOpeningCustomerAndVehicleMaster
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "JobCardOpeningCustomerAndVehicleMaster")]
        //BaseListReturnType<JobCardOpeningCustomerAndVehicleMaster> JobCardOpeningCustomerAndVehicleMaster(string pn_reg_num, string pn_dealer_cd, string pn_loc_cd);
        //BaseListReturnType<JobCardOpeningCustomerAndVehicleMaster> JobCardOpeningCustomerAndVehicleMaster(string pn_reg_num, string pn_dealer_cd, string pn_loc_cd, string pn_vin = "");
        BaseListReturnType<JobCardOpeningCustomerAndVehicleMaster> JobCardOpeningCustomerAndVehicleMaster(string pn_reg_num, string pn_dealer_cd, string pn_loc_cd, string pn_vin = "");
        #endregion
      

        #region DIY JC - Do It Yourself JobCard
        #region for DIYJC_PullCustomerContact
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "DIYJC_PullCustomerContact")]
        BaseListReturnType<DIYJC_PullCustomerContact> DIYJC_PullCustomerContact(string PN_USER_ID, string PN_REG_NUM, string PN_VIN);
        #endregion

        #region for DIYJC_PushCustomerSMS
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "DIYJC_PushCustomerSMS")]
        BaseListReturnType<DIYJC_PushCustomerSMS> DIYJC_PushCustomerSMS(string PN_USER_ID, string PN_REG_NUM, string PN_SMS_NUM, string PN_SMS_LINK);
        #endregion

        #region for DIYJC_PullSADashboard
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "DIYJC_PullSADashboard")]
        BaseListReturnType<DIYJC_PullSADashboard> DIYJC_PullSADashboard(string PN_USER_ID);
        #endregion

        #endregion


        #region for GET MSG for CNG Vehicle
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetDTLCNGVehicle")]
        BaseListReturnType<CheckCNGVehicle> GetDTLCNGVehicle(string PN_VIN);
        #endregion

        #region for GET CNG Testing due Date
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetCNGTestingdueDate")]
        BaseListReturnType<CNGTestingdueDate> GetCNGTestingdueDate(string PN_TESTING_DATE);
        #endregion

     

    }
}