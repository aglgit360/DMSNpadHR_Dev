using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Web;
using System.Configuration;
using System.IO;

namespace NEXA.DataService.Services
{
    public class ServiceHelper
    {
        public static ServiceHeaderInfo Authenticate(IncomingWebRequestContext requestContext)
        {
            string fileContent = "";
            string textFilePath = ConfigurationManager.AppSettings["PullTokenpath"].ToString();
            fileContent = File.ReadAllText(textFilePath).ToString();

            ServiceHeaderInfo headerInfo = new ServiceHeaderInfo();
            System.Net.WebHeaderCollection headerCollection = requestContext.Headers;
            headerInfo.Token = headerCollection["Token"];

            //if (headerInfo.Token == "dR$545#h^jjmanJ")
            if (headerInfo.Token == fileContent.Trim().ToString())
            {
                headerInfo.IsAuthenticated = true;
            }
            else
            {
                headerInfo.IsAuthenticated = false;
            }

            return headerInfo;
        }


        public static ServiceHeaderInfo AuthenticateForTokenAPI(IncomingWebRequestContext requestContext)
        {
            ServiceHeaderInfo headerInfo = new ServiceHeaderInfo();
            System.Net.WebHeaderCollection headerCollection = requestContext.Headers;
            headerInfo.Token = headerCollection["Token"];

            if (headerInfo.Token == "dR$545#h^jjmanJ")
            {
                headerInfo.IsAuthenticated = true;
            }
            else
            {
                headerInfo.IsAuthenticated = false;
            }

            return headerInfo;
        }


        public static string GetDateFormat(string date)
        {
            try
            {
                if (!string.IsNullOrEmpty(date))
                {
                    string[] datesplit_fromDate = date.Split('-');
                    if (datesplit_fromDate.Length > 0)
                    {
                        string day_fromDate = datesplit_fromDate[0];
                        string month_fromDate = datesplit_fromDate[1];
                        string year_fromDate = datesplit_fromDate[2];
                        if (month_fromDate.Length > 3)
                        {
                            month_fromDate = month_fromDate.Substring(0, 3);
                        }
                        date = day_fromDate + "-" + month_fromDate + "-" + year_fromDate;
                    }

                }
                ErrorLog.LogFunction(date);
            }
            catch (Exception ex)
            {
                ErrorLog.LogException(ex, "Nexa_GetDateFormat");
            }
            return date;
        }

    }

    public class ServiceHeaderInfo
    {

        public bool IsAuthenticated { get; set; }
        public string Token { get; set; }
    }
}