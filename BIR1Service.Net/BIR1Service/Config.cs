using System;

namespace BIR1Service
{
    internal static class Config
    {
        public const string ServiceUrl = "https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc/ajaxEndpoint/";
        public const string ServiceTestUrl = "https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc/ajaxEndpoint/";
        public static readonly Version UtilsMinVersion = new Version("1.3.1.0");
        public static bool TestServerRequests { get; set; }
    }
}
