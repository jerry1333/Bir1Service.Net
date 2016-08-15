using System;

namespace BIR1Service
{
    public class Config
    {
        internal const string ServiceUrl = "https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc/ajaxEndpoint/";
        internal const string ServiceTestUrl = "https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc/ajaxEndpoint/";
        internal const string WebAppUrl = "https://wyszukiwarkaregon.stat.gov.pl/appBIR/scripts/appbir.js";
        internal readonly Version UtilsMinVersion = new Version("1.3.1.0");
        internal static bool TestServerRequests { get; set; }
        internal string Sid { get; set; }
        internal string KluczUzytkownika { get; set; }
    }
}
