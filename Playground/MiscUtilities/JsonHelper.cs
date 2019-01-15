using System;
using Newtonsoft.Json;

namespace Playground.MiscUtilities
{
    public static class JsonHelper
    {
        public static bool TryParse<T>(string model, out T result)
        {
            result = default(T);

            try
            {
                result = JsonConvert.DeserializeObject<T>(model);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"JsonHelper.TryParse(): {ex}");
            }

            return false;
        }
    }
}
