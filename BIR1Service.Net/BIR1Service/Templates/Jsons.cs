using System.Collections.Generic;

namespace BIR1Service.Templates
{
    internal static class Jsons
    {
        public static Dictionary<string, object> LoginParams = new Dictionary<string, object> {
            // JSON: {"pKluczUzytkownika":""}
            {"pKluczUzytkownika", null}};

        public static Dictionary<string, object> LogoutParams = new Dictionary<string, object> {
            // JSON: {"pIdentyfikatorSesji":""}
            {"pIdentyfikatorSesji", null}};

        public static Dictionary<string, object> DaneSzukajParams = new Dictionary<string, object> {
            /* JSON: {
             * "pParametryWyszukiwania":
             * {
             *      "NazwaPodmiotu":null,
             *      "AdsSymbolGminy":null,
             *      "AdsSymbolMiejscowosci":null,
             *      "AdsSymbolPowiatu":null,
             *      "AdsSymbolUlicy":null,
             *      "AdsSymbolWojewodztwa":null,
             *      "Dzialalnosci":null,
             *      "PrzewazajacePKD":false,
             *      "Regon":{0},
             *      "Krs":{1},
             *      "Nip":{2},
             *      "Regony9zn":{3},
             *      "Regony14zn":{4},
             *      "Krsy":{5},
             *      "Nipy":{6},
             *      "NumerwRejestrzeLubEwidencji":null,
             *      "OrganRejestrowy":null,
             *      "RodzajRejestru":null,
             *      "FormaPrawna":null
             * },
             * "jestWojPowGmn":true}
            */
            {"pParametryWyszukiwania", new Dictionary<string, string> {{"NazwaPodmiotu", null}, {"AdsSymbolGminy", null}, {"AdsSymbolMiejscowosci", null}, {"AdsSymbolPowiatu", null}, {"AdsSymbolUlicy", null}, {"AdsSymbolWojewodztwa", null}, {"Dzialalnosci", null}, {"PrzewazajacePKD", "false"}, {"Regon", null}, {"Krs", null}, {"Nip", null}, {"Regony9zn", null}, {"Regony14zn", null}, {"Krsy", null}, {"Nipy", null}, {"NumerwRejestrzeLubEwidencji", null}, {"OrganRejestrowy", null}, {"RodzajRejestru", null}, {"FormaPrawna", null}}}, {"jestWojPowGmn", true}};

        public static Dictionary<string, object> DaneRaportParams = new Dictionary<string, object> {{"pRegon", null}, {"pNazwaRaportu", null}, {"pSilosID", null}};

        public static Dictionary<string, object> CaptchaGetParams = new Dictionary<string, object> {
            // JSON: ""
            {"", null}};

        public static Dictionary<string, object> CaptchaCheckParams = new Dictionary<string, object> {
            // JSON: {"pCaptcha":""}
            {"pCaptcha", null}};

        public static Dictionary<string, object> GetValueParams = new Dictionary<string, object> {
            // JSON: {"pNazwaParametru":""}
            {"pNazwaParametru", null}};

        public static Dictionary<string, object> DaneKomunikatParams = new Dictionary<string, object> {
            // JSON: ""
            {"", null}};
    }
}
