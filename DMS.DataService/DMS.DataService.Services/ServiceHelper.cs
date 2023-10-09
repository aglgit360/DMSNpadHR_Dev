using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Web;
using System.Configuration;
using System.IO;
using DMS.DataService.Services;

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

        public static ServiceHeaderInfo1 Authenticate2(IncomingWebRequestContext requestContext)
        {
            ServiceHeaderInfo1 headerInfo = new ServiceHeaderInfo1();
            System.Net.WebHeaderCollection headerCollection = requestContext.Headers;
            //headerInfo.Token = headerCollection["Token"];

            string authorization = headerCollection["Token"];
            string type = headerCollection["type"];
            //string authorization = requestContext.Headers["token"];
            //If we don't find the authorization header return null  

            //if (string.IsNullOrEmpty(authorization))
            //{
            //    return null;
            //}
            //get the token from the auth header           
            //if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            //{
            headerInfo.Token = authorization.Substring("Bearer ".Length).Trim();
            //type = type.Trim().ToString();
            //}
            return TokenGenerate.ValidateToken(headerInfo.Token, type);
            //return GetPrincipalFromExpiredToken(headerInfo.Token);

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

    public class ServiceHeaderInfo1
    {
        public bool IsAuthenticated { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}