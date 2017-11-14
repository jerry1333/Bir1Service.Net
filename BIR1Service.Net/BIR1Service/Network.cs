using BIR1Service.ServiceData;
using Jerry1333.Utils;
using System;
using System.IO;
using System.Net;

namespace BIR1Service
{
    internal static class Network
    {
        public static string MakeRequest(string regon, string silosId, RaportFiz type, string sid = null)
        {
            try
            {
                return MakeRequest(GetMethodUri(Method.DanePobierzPelnyRaport), Raport.PrepareDataString(Method.DanePobierzPelnyRaport, regon, type.ToString(), silosId), sid);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string MakeRequest(string regon, string silosId, RaportPraw type, string sid = null)
        {
            try
            {
                return MakeRequest(GetMethodUri(Method.DanePobierzPelnyRaport), Raport.PrepareDataString(Method.DanePobierzPelnyRaport, regon, type.ToString(), silosId), sid);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string MakeRequest(SearchBy search, string[] data, string sid = null)
        {
            try
            {
                return MakeRequest(GetMethodUri(Method.DaneSzukaj), Raport.PrepareSearchString(search, data), sid);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string MakeRequest(Method type, string data, string sid = null)
        {
            try
            {
                if (type == Method.DaneSzukaj) throw new ArgumentOutOfRangeException(nameof(type));

                return MakeRequest(GetMethodUri(type), Raport.PrepareDataString(type, data), sid);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string MakeRequest(string uri, string data, string sid = null)
        {
            try
            {
                if (uri.IsNullOrEmpty()) throw new ArgumentNullException(nameof(uri));

                var req = (HttpWebRequest) WebRequest.Create(uri);
                req.Method = "POST";
                req.SendChunked = true;
                req.ContentType = "application/json";
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:45.0) Gecko/20100101 Firefox/45.0";
                req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                req.Timeout = 7000;
                req.AutomaticDecompression = DecompressionMethods.GZip;
                req.ContentLength = data.IsNullOrEmpty() ? 0 : data.Length;
                if (!sid.IsNullOrEmpty())
                    req.Headers.Add("sid", sid);

                using (var os = new StreamWriter(req.GetRequestStream()))
                {
                    os.Write(data);
                    os.Flush();
                    var resp = (HttpWebResponse) req.GetResponse();
                    if (resp.StatusCode != HttpStatusCode.OK) return null;
                    using (var respStream = resp.GetResponseStream())
                    {
                        if (respStream == null) return null;

                        var sr = new StreamReader(respStream);
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string GetMethodUri(Method type)
        {
            return Config.TestServerRequests ? $"{Config.ServiceTestUrl}{type}" : $"{Config.ServiceUrl}{type}";
        }
        
        public static string GetKluczUzytkownika()
        {
            try
            {
                //var rx = new Regex("[a-f0-9?|]{20}");
                //return rx.Match(data).Groups[1].Value;
                throw new NotImplementedException();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
