using System;
using System.Threading.Tasks;
using Playground.MiscUtilities;
using Playground.Models;

namespace Playground.Tasks
{
    public class SillySingleton
    {
        private static SillySingleton _instance = null;

        public static SillySingleton Instance
        {
            get { return _instance ?? new SillySingleton(); }
        }

        private Task<Weather> _loadWeatherTask = null;
        private RestService _restService = null;

        public SillySingleton()
        {
            _restService = new RestService();
        }

        public Task<Weather> LoadWeather()
        {
            if (_loadWeatherTask == null)
            {
                _loadWeatherTask = Task.Run(async () =>
                {
                    string apiKey = "";
                    string urlTemplate = @"https://api.openweathermap.org/data/2.5/weather?q=Manila&appid={0}";
                    string url = string.Format(urlTemplate, apiKey);

                    System.Diagnostics.Debug.WriteLine("Crap i am running again");

                    var weather = await _restService.GetRequest<Weather>(url);
                    return weather;
                });
            }

            return _loadWeatherTask;
        }
    }
}
