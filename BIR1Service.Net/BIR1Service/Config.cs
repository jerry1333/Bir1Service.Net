using System;

namespace BIR1Service
{
    internal static class Config
    {
        public const string ServerBaseUri = "https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc/ajaxEndpoint/";
        public const string TestServerBaseUri = "https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc/ajaxEndpoint/";

        public static bool TestServerRequests { get; set; } = false;
        public static readonly Version UtilsMinVersion = new Version("1.3.1.0");
    }
}
