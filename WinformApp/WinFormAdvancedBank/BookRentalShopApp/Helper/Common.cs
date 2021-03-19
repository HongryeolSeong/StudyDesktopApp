using System;
using System.Net;

namespace BookRentalShopApp.Helper
{
    public static class Common
    {
        public static string ConnString = "Data Source=127.0.0.1; " +
                                          "Initial Catalog=bookrentalshop; " +
                                          "Persist Security Info=True; " +
                                          "User ID=sa; " +
                                          "Password=mssql_p@ssw0rd!";

        public static string LoginUserId = string.Empty;

        internal static string GetLocalIp()
        {
            string localIP = "";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress iP in host.AddressList)
            {
                if (iP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = iP.ToString();
                    break;
                }
            }

            return localIP;
        }

        internal static string ReplaceCmdText(string strSource)
        {
            var result = strSource.Replace("'", "＇");
            result = result.Replace("--", "");
            result = result.Replace(";", "");

            return result;
        }
    }
}
