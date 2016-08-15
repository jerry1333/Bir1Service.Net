using System;
using System.Runtime.InteropServices;
using BIR1Service.ServiceData;
using Jerry1333.Utils;
using Newtonsoft.Json;

namespace BIR1Service
{
    public class Bir1Service
    {
        public Datas Data;
        private static Config _config;

        public Bir1Service(string kluczUzytkownika = null, bool testServer = false)
        {
            try
            {
                _config = new Config();
                Data = new Datas(ref _config);

                Config.TestServerRequests = testServer;
                _config.KluczUzytkownika = kluczUzytkownika.IsNullOrEmpty() ? Network.GetKluczUzytkownika() : kluczUzytkownika;

                if (_config.UtilsMinVersion.CompareTo(Utils.GetUtilsVersion()) > 0)
                    throw new DllNotFoundException("Wrong utils dll version! Min version is: " + _config.UtilsMinVersion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Login()
        {
            try
            {
                if (!_config.Sid.IsNullOrEmpty()) throw new InvalidOperationException("SID already set! Use logout method.");

                var response = Network.MakeRequest(Method.Zaloguj, _config.KluczUzytkownika);
                dynamic dane = JsonConvert.DeserializeObject(response);
                _config.Sid = dane.d;

                return !_config.Sid.IsNullOrEmpty() && _config.Sid.Length == 20;
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
                if (_config.Sid.IsNullOrEmpty()) throw new InvalidOperationException("No SID set! Use login method.");

                var response = Network.MakeRequest(Method.Wyloguj, _config.Sid);
                dynamic dane = JsonConvert.DeserializeObject(response);
                if (dane.d) _config.Sid = null;

                return dane.d;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
