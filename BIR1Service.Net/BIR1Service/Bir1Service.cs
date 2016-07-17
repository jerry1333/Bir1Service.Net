using System;
using BIR1Service.Data;
using Jerry1333.Libs;
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
                var verTest = Config.MinUtilsVersion.CompareTo(Utils.GetVersion(typeof(Utils)));
                if (verTest > 0) throw new DllNotFoundException("Wrong utils dll version! Min version is: " + Config.MinUtilsVersion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Sid { get; set; }

    }
}
