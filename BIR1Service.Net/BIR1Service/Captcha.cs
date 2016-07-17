using System;
using System.Drawing;
using System.IO;
using BIR1Service.Data;
using Jerry1333.Libs;
using Newtonsoft.Json;

namespace BIR1Service
{
    internal static class Captcha
    {
        public static bool IsCaptchaNeeded(string sid)
        {
            try
            {
                if (sid.IsNullOrEmpty()) throw new ArgumentNullException(nameof(sid));

                var response = Network.MakeRequest(Method.GetValue, ServiceStatus.KomunikatKod.ToString(), sid);
                dynamic dane = JsonConvert.DeserializeObject(response);

                return dane.d == KomunikatKod.NeedCaptcha;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetCaptcha(string sid)
        {
            try
            {
                if (sid.IsNullOrEmpty()) throw new ArgumentNullException(nameof(sid));

                var response = Network.MakeRequest(Method.PobierzCaptcha, null, sid);
                dynamic dane = JsonConvert.DeserializeObject(response);
                return dane.d.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Image Base64ToImage(string base64String)
        {
            try
            {
                if (base64String.IsNullOrEmpty()) return null;

                var imageBytes = Convert.FromBase64String(base64String);
                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    var image = Image.FromStream(ms, true);
                    return image;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool ValidateCaptcha(string sid, string input)
        {
            try
            {
                if (sid.IsNullOrEmpty()) throw new ArgumentNullException(nameof(sid));
                if (input.IsNullOrEmpty()) throw new ArgumentNullException(nameof(input));

                var response = Network.MakeRequest(Method.SprawdzCaptcha, input, sid);
                dynamic dane = JsonConvert.DeserializeObject(response);
                return Convert.ToBoolean(dane.d.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
