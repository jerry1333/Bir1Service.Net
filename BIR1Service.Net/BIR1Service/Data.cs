using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BIR1Service.ServiceData;
using Jerry1333.Utils;
using Newtonsoft.Json;

namespace BIR1Service
{
    public class Datas
    {
        private readonly Config _config;

        public Datas(ref Config conf)
        {
            _config = conf;
        }

        public string SearchBySingle(SearchBy searchBy, string param)
        {
            try
            {
                if (_config.Sid.IsNullOrEmpty()) throw new InvalidOperationException("No SID set! Use login method.");

                if (searchBy == SearchBy.Nipy || searchBy == SearchBy.Krsy || searchBy == SearchBy.Regony9zn || searchBy == SearchBy.Rregony14zn) throw new ArgumentException(nameof(searchBy));

                if (param.IsNullOrEmpty()) throw new ArgumentNullException(nameof(param));

                return Search(searchBy, new[] { param });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string SearchByMulti(SearchBy searchBy, params string[] param)
        {
            try
            {
                if (_config.Sid.IsNullOrEmpty()) throw new InvalidOperationException("No SID set! Use login method.");
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
                var response = Network.MakeRequest(type, param, _config.Sid);
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
                if (_config.Sid.IsNullOrEmpty()) throw new InvalidOperationException("No SID set! Use login method.");
                if (regon.IsNullOrEmpty()) throw new ArgumentNullException(nameof(regon));
                if (silosId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(silosId));

                var response = Network.MakeRequest(regon, silosId, type, _config.Sid);
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
                if (_config.Sid.IsNullOrEmpty()) throw new InvalidOperationException("No SID set! Use login method.");
                if (regon.IsNullOrEmpty()) throw new ArgumentNullException(nameof(regon));
                if (silosId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(silosId));

                var response = Network.MakeRequest(regon, silosId, type, _config.Sid);
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
