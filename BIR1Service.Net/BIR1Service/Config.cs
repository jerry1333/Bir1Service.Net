using System;

namespace BIR1Service
{
    internal class Config
    {
        public const string ServerBaseUri = "https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc/ajaxEndpoint/";
        public const string TestServerBaseUri = "https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc/ajaxEndpoint/";
        public static readonly Version MinUtilsVersion = new Version("1.2.0.0");

        public static bool TestServerRequests { get; set; } = false;
    }
}
