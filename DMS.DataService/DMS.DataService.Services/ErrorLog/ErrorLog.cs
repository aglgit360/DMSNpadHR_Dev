using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web;
// Create our own utility for exceptions 
public sealed class ErrorLog
{
    private static object lockerFile = new Object();
    // All methods are static, so this can be private 
    private ErrorLog()
    { }

    // Log an Exception 
    public static void LogException(Exception exc, string source)
    {
        Boolean IsLogTrace = false;
        IsLogTrace = Convert.ToBoolean(ConfigurationManager.AppSettings["IsLogTrace"]);

        if (IsLogTrace)
        {
            // Include enterprise logic for logging exceptions 
            // Get the absolute path to the log file 
            string logFile = "ErrorLog" + "_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

            logFile = HttpContext.Current.Server.MapPath(logFile);

            // Open the log file for append and write the log
            StreamWriter sw = new StreamWriter(logFile, true);
            sw.WriteLine("********** {0} **********", DateTime.Now);
            if (exc.InnerException != null)
            {
                sw.Write("Inner Exception Type: ");
                sw.WriteLine(exc.InnerException.GetType().ToString());
                sw.Write("Inner Exception: ");
                sw.WriteLine(exc.InnerException.Message);
                sw.Write("Inner Source: ");
                sw.WriteLine(exc.InnerException.Source);
                if (exc.InnerException.StackTrace != null)
                {
                    sw.WriteLine("Inner Stack Trace: ");
                    sw.WriteLine(exc.InnerException.StackTrace);
                }
            }
            sw.Write("Exception Type: ");
            sw.WriteLine(exc.GetType().ToString());
            sw.WriteLine("Exception: " + exc.Message);
            sw.WriteLine("Source: " + source);
            sw.WriteLine("Stack Trace: ");
            if (exc.StackTrace != null)
            {
                sw.WriteLine(exc.StackTrace);
                sw.WriteLine();
            }
            sw.Close();
        }
    }
    public static void LogFunction(string logsource)
    {
        Boolean IsLogTrace = false;
        IsLogTrace = Convert.ToBoolean(ConfigurationManager.AppSettings["IsLogTrace"]);
        if (IsLogTrace)
        {
            // Include enterprise logic for logging exceptions 
            // Get the absolute path to the log file 
            string logFile = "ErrorLog" + "_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

            logFile = HttpContext.Current.Server.MapPath(logFile);

            // Open the log file for append and write the log
            StreamWriter sw = new StreamWriter(logFile, true);
            sw.Write("****************************************************************");
            sw.Write(DateTime.Now);
            sw.Write("****************************************************************");
            sw.Write(logsource + "- as input values from API");
            sw.Write("Nexa_GetDateFormat function called... ");
            sw.Close();
        }
    }
    // Notify System Operators about an exception 
    public static void NotifySystemOps(Exception ex)
    {

    }

    public static void LogTack(Exception exc, string source)
    {
        Boolean IsLogTrace = false;
        IsLogTrace = Convert.ToBoolean(ConfigurationManager.AppSettings["IsLogTrace"]);

        if (IsLogTrace)
        {
            // Include enterprise logic for logging exceptions 
            // Get the absolute path to the log file 
            string logFile = "ErrorLog" + "_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

            logFile = HttpContext.Current.Server.MapPath(logFile);

            // Open the log file for append and write the log
            StreamWriter sw = new StreamWriter(logFile, true);
            sw.WriteLine("********** {0} **********", DateTime.Now);
            
            sw.Write("Exception Type: ");
            sw.WriteLine(exc.GetType().ToString());
            sw.WriteLine("Exception: " + exc.Message);
            sw.WriteLine("Source: " + source);
            sw.WriteLine("Stack Trace: ");
            if (exc.StackTrace != null)
            {
                sw.WriteLine(exc.StackTrace);
                sw.WriteLine();
            }
            sw.Close();
        }
    }

    public static void ErrorLogException(string FunctionName, string SP_Name, string inputPara, dynamic exc)
    {
        try
        {
            Boolean IsLogTrace = false;
            IsLogTrace = Convert.ToBoolean(ConfigurationManager.AppSettings["IsLogTrace"]);
            //StackFrame STACK = new StackFrame();
            if (IsLogTrace)
            {
                lock (lockerFile)
                {
                    string logFile = "ErrorLog" + "_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

                    logFile = HttpContext.Current.Server.MapPath(logFile);
                    StringBuilder sb = null;
                    sb = new StringBuilder();
                    sb.AppendLine("************** " + DateTime.Now.ToString() + " **************");
                    sb.AppendLine("API Name:" + FunctionName);
                    sb.AppendLine("SP_NAME:" + SP_Name);
                    //sb.AppendLine("Line No: "+ STACK.GetFileLineNumber() + " Exception Type :"+ exc.Message);
                    sb.AppendLine("Exception Type :" + exc);
                    sb.AppendLine("Input Para: " + inputPara);
                    sb.AppendLine();

                    StreamWriter sw = new StreamWriter(logFile, true);
                    sw.WriteLine(sb.ToString());
                    //sw.AutoFlush = true;
                    sw.Close();
                }
            }
        }
        catch (Exception exe)
        {
            LogTack(exe, "From Error Log - " + FunctionName);
        }
        
    }
    //old method of successLog creation_______________________

    public static void SuccessLog(string FunctionName, string SP_Name, string inputPara, dynamic OutputPara)
    {
        try
        {
            Boolean IsLogTrace = false;
            IsLogTrace = Convert.ToBoolean(ConfigurationManager.AppSettings["IsLogTrace"]);
            //StackFrame STACK = new StackFrame();
            if (IsLogTrace)
            {
                lock (lockerFile)
                {
                    string logFile = "SuccessLog" + "_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

                    logFile = HttpContext.Current.Server.MapPath(logFile);
                    StringBuilder sb = null;
                    sb = new StringBuilder();
                    sb.AppendLine("************** " + DateTime.Now.ToString() + " **************");
                    sb.AppendLine("API Name:" + FunctionName);
                    sb.AppendLine("SP_NAME:" + SP_Name);
                    //sb.AppendLine("Line No: " + STACK.GetFileLineNumber() + "Exception Type :" + exc.Message);
                    sb.AppendLine("Input Para: " + inputPara);
                    sb.Append("OutPut: " + OutputPara);
                    sb.AppendLine();

                    StreamWriter sw = new StreamWriter(logFile, true);
                    sw.WriteLine(sb.ToString());

                    sw.Close();
                }
            }
        }
        catch (Exception exe)
        {
            LogTack(exe, "From Success Log - " + FunctionName);

        }

    }

    //public static void SuccessLog(string FunctionName, string SP_Name, string inputPara, dynamic OutputPara)
    //{
    //    Boolean IsLogTrace = false;
    //    IsLogTrace = Convert.ToBoolean(ConfigurationManager.AppSettings["IsLogTrace"]);

    //    if (IsLogTrace)
    //    {
    //        lock (lockerFile)
    //        {
    //            string logFile = "SuccessLog" + "_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
    //            logFile = HttpContext.Current.Server.MapPath(logFile);
    //            using (var stream = new FileStream(logFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
    //            {
    //                using (var writer = new StreamWriter(stream))
    //                {
    //                    StringBuilder sb = null;
    //                    sb = new StringBuilder();
    //                    sb.AppendLine("************** " + DateTime.Now.ToString() + " **************");
    //                    sb.AppendLine("API Name:" + FunctionName);
    //                    sb.AppendLine("SP_NAME:" + SP_Name);
    //                    sb.AppendLine("Input Para: " + inputPara);
    //                    sb.Append("OutPut: " + OutputPara);
    //                    sb.AppendLine();

    //                    writer.WriteLine(sb.ToString());

    //                    writer.Close();
    //                }
    //            }

    //        }
    //    }
    //}

    //private static string createFolder()
    //{
    //    string path = HttpContext.Current.Server.MapPath("~/");
    //    var now = DateTime.UtcNow;
    //    var yearName = now.ToString("yyyy");
    //    var monthName = now.ToString("MMMM");
    //    var dayName = now.ToString("dd-MM-yyyy");

    //    string folder = Path.Combine(path, Path.Combine("Logs\\"));

    //    if (!Directory.Exists(folder))
    //    {
    //        Directory.CreateDirectory(folder);
    //    }
    //    return (folder);
    //}
}