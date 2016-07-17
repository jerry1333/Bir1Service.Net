using System;
using System.IO;
using System.Net;
using BIR1Service.Data;
using Jerry1333.Libs;

namespace BIR1Service
{
    internal static class Network
    {
        public static string GetMethodUri(Method type)
        {
            return Config.TestServerRequests ? $"{Config.TestServerBaseUri}{type}" : $"{Config.ServerBaseUri}{type}";
        }
    }
}
