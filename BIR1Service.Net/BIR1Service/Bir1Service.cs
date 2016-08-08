using System;
using BIR1Service.Data;
using Jerry1333.Utils;
using Newtonsoft.Json;

namespace BIR1Service
{
    public class Bir1Service
    {
        public Bir1Service(bool testServer = false)
        {
            try
            {
                Config.TestServerRequests = testServer;
                var verTest = Config.UtilsMinVersion.CompareTo(Utils.GetUtilsVersion());
                if (verTest > 0) throw new DllNotFoundException("Wrong utils dll version! Min version is: " + Config.UtilsMinVersion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Sid { get; set; }

        public bool Login(string kluczUzytkownika = "aaaaaabbbbbcccccddd_")
        {
            try
            {
                if (!Sid.IsNullOrEmpty()) throw new InvalidOperationException("Already logged in!");

                if (kluczUzytkownika.IsNullOrEmpty()) throw new ArgumentNullException(nameof(kluczUzytkownika));

                var response = Network.MakeRequest(Method.Zaloguj, kluczUzytkownika);
                dynamic dane = JsonConvert.DeserializeObject(response);
                Sid = dane.d;

                return !Sid.IsNullOrEmpty() && Sid.Length == 20;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Logout()
        {
            try
            {
                if (Sid.IsNullOrEmpty()) throw new InvalidOperationException("Not logged in!");

                var response = Network.MakeRequest(Method.Wyloguj, Sid);
                dynamic dane = JsonConvert.DeserializeObject(response);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string SearchBySingle(SearchBy searchBy, string param)
        {
            try
            {
                if (Sid.IsNullOrEmpty()) throw new InvalidOperationException("Not logged in!");

                if (searchBy == SearchBy.Nipy || searchBy == SearchBy.Krsy || searchBy == SearchBy.Regony9zn || searchBy == SearchBy.Rregony14zn) throw new ArgumentException(nameof(searchBy));

                if (param.IsNullOrEmpty()) throw new ArgumentNullException(nameof(param));

                return Search(searchBy, new[] {param});
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string SearchByMulti(SearchBy searchBy, string[] param)
        {
            try
            {
                if (Sid.IsNullOrEmpty()) throw new InvalidOperationException("Not logged in!");

                if (searchBy == SearchBy.Nip || searchBy == SearchBy.Krs || searchBy == SearchBy.Regon) throw new ArgumentException(nameof(searchBy));

                if (param.Length == 0) throw new ArgumentNullException(nameof(param));

                return Search(searchBy, param);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string Search(SearchBy type, string[] param)
        {
            try
            {
                var response = Network.MakeRequest(type, param, Sid);
                dynamic dane = JsonConvert.DeserializeObject(response);
                return dane.d;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetFullData(string regon, string silosId, RaportFiz type)
        {
            try
            {
                if (Sid.IsNullOrEmpty()) throw new InvalidOperationException("Not logged in!");

                if (regon.IsNullOrEmpty()) throw new ArgumentNullException(nameof(regon));
                if (silosId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(silosId));

                var response = Network.MakeRequest(regon, silosId, type, Sid);
                dynamic dane = JsonConvert.DeserializeObject(response);
                return dane.d;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetFullData(string regon, string silosId, RaportPraw type)
        {
            try
            {
                if (Sid.IsNullOrEmpty()) throw new InvalidOperationException("Not logged in!");

                if (regon.IsNullOrEmpty()) throw new ArgumentNullException(nameof(regon));
                if (silosId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(silosId));

                var response = Network.MakeRequest(regon, silosId, type, Sid);
                dynamic dane = JsonConvert.DeserializeObject(response);
                return dane.d;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
