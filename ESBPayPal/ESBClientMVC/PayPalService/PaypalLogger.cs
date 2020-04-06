namespace ESBClientMVC.PayPalService
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.IO;


    public static class PaypalLogger
    {
        public static string LogDirectoryPath = Environment.CurrentDirectory;
        public static void Log(string messages)
        {
            try
            {
                StreamWriter strw = new StreamWriter(LogDirectoryPath + "\\PaypalErro.log", true);
                strw.WriteLine("{0} --> {1}", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), messages);
            }
            catch (Exception ex)
            {
                Log("Error : " + ex.Message);
            }
        }
    }
}