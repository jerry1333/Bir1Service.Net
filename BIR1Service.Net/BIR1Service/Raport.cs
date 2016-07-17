using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using BIR1Service.Data;
using BIR1Service.Templates;
using Newtonsoft.Json;

namespace BIR1Service
{
    internal static class Raport
    {
        public static string PrepareDataString(Method type, params string[] param)
        {
            try
            {
                Dictionary<string, object> dict;
                switch (type)
                {
                    case Method.Zaloguj:
                        dict = Jsons.LoginParams;
                        dict["pKluczUzytkownika"] = param[0];
                        break;
                    case Method.Wyloguj:
                        dict = Jsons.LogoutParams;
                        dict["pIdentyfikatorSesji"] = param[0];
                        break;
                    case Method.PobierzCaptcha:
                        dict = Jsons.CaptchaGetParams;
                        break;
                    case Method.SprawdzCaptcha:
                        dict = Jsons.CaptchaCheckParams;
                        dict["pCaptcha"] = param[0];
                        break;
                    case Method.GetValue:
                        dict = Jsons.GetValueParams;
                        dict["pNazwaParametru"] = param[0];
                        break;
                    case Method.DaneKomunikat:
                        dict = Jsons.DaneKomunikatParams;
                        break;
                    case Method.DanePobierzPelnyRaport:
                        dict = Jsons.DaneRaportParams;
                        dict["pRegon"] = param[0];
                        dict["pNazwaRaportu"] = param[1];
                        dict["pSilosID"] = param[2];
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(type));
                }
                return JsonConvert.SerializeObject(dict);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string PrepareSearchString(SearchBy type, string[] param)
        {
            try
            {
                var dict = Jsons.DaneSzukajParams;
                var prepParam = new StringBuilder();

                if (!((type == SearchBy.Regon || type == SearchBy.Nip || type == SearchBy.Krs) && (param[0].Length == 10 || param[0].Length == 9 || param[0].Length == 14))) return null;
                if (type == SearchBy.Regony9zn || type == SearchBy.Rregony14zn || type == SearchBy.Krsy || type == SearchBy.Nipy)
                {
                    foreach (var s in param)
                        prepParam.AppendFormat("{0},", s);

                    var regexp = new Regex(@"^([0-9]+)(,\s*[0-9]+)*$");
                    if (!regexp.IsMatch(prepParam.ToString())) return null;
                }
                else
                    prepParam.Append(param[0]);

                ((Dictionary<string, string>) dict["pParametryWyszukiwania"])[type.ToString()] = prepParam.ToString();
                var paramsString = JsonConvert.SerializeObject(dict);

                return paramsString;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetStatusDataString(ServiceStatus type)
        {
            try
            {
                return PrepareDataString(Method.GetValue, type.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetReportDataString(string regon, RaportFiz type, string silosId)
        {
            try
            {
                return PrepareDataString(Method.DanePobierzPelnyRaport, regon, type.ToString(), silosId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetReportDataString(string regon, RaportPraw type, string silosId)
        {
            try
            {
                return PrepareDataString(Method.DanePobierzPelnyRaport, regon, type.ToString(), silosId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
