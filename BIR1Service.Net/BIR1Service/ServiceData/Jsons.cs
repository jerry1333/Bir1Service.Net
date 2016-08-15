namespace BIR1Service.ServiceData
{
    internal static class Jsons
    {
        public const string LoginParams = "{'pKluczUzytkownika': 'aaaaهbbbbbccccccdd|ه'}";

        public const string LogoutParams = "{'pIdentyfikatorSesji': ''}";

        public const string DaneSzukajParams = @"{
                                                    'pParametryWyszukiwania': {'NazwaPodmiotu': '','AdsSymbolGminy': '','AdsSymbolMiejscowosci': '','AdsSymbolPowiatu': '','AdsSymbolUlicy': '','AdsSymbolWojewodztwa': '','Dzialalnosci': '','PrzewazajacePKD': false,'Regon': '','Krs': '','Nip': '','Regony9zn': '','Regony14zn': '','Krsy': '','Nipy': '','NumerwRejestrzeLubEwidencji': '','OrganRejestrowy': '','RodzajRejestru': '','FormaPrawna': ''},
                                                    'jestWojPowGmn': true
                                                }";

        public const string CaptchaCheckParams = "{'pCaptcha': ''}";

        public const string CaptchaGetParams = "{'': ''}";

        public const string DaneKomunikatParams = "{'': ''}";

        public const string DaneRaportParams = @"{
                                                    {'pRegon': ''}, 
                                                    {'pNazwaRaportu': ''}, 
                                                    {'pSilosID': ''}
                                                }";

        public const string GetValueParams = "{'pNazwaParametru': ''}";
    }
}
