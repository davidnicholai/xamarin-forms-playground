using System.Threading.Tasks;
using System.Windows.Input;
using Playground.MiscUtilities;
using Playground.Models;
using Xamarin.Forms;

namespace Playground.Tasks
{
    public class TasksPageViewModel : BindableBase
    {
        private Task _myTask;

        public ICommand StartTaskCommand { get; set; }
        public ICommand StartTaskAsyncCommand { get; set; }
        public ICommand RefreshStatusCommand { get; set; }

        private RestService _restService;

        private string _taskStatus;
        public string TaskStatus
        {
            get { return _taskStatus; }
            set { SetProperty(ref _taskStatus, value); }
        }

        private string _weatherData;
        public string WeatherData
        {
            get { return _weatherData; }
            set { SetProperty(ref _weatherData, value); }
        }

        public TasksPageViewModel()
        {
            StartTaskCommand = new Command(() => StartTask());
            StartTaskAsyncCommand = new Command(async () => await StartTaskAsync());
            RefreshStatusCommand = new Command(() => RefreshStatus());
            _restService = new RestService();
            RefreshStatus();
        }

        private Task StartTask()
        {
            bool hasCompleted = false;;
            if (_myTask != null && _myTask.IsCompleted)
            {
                hasCompleted = true;
            }

            _myTask = FetchWeatherData(hasCompleted);

            return _myTask;
        }

        private async Task StartTaskAsync()
        {
            Weather weather = await FetchWeatherDataAsync();

            WeatherData = weather != null
                ? $"Fetched! Name: {weather.Name}"
                : "weather is null";
        }

        private Task<Weather> FetchWeatherData(bool hasCompleted)
        {
            if (hasCompleted)
            {
                System.Diagnostics.Debug.WriteLine("The task is already IsCompleted but ok");
            }
            string apiKey = "";
            string urlTemplate = @"https://api.openweathermap.org/data/2.5/weather?q=Manila&appid={0}";
            string url = string.Format(urlTemplate, apiKey);

            System.Diagnostics.Debug.WriteLine("Crap i am running again");

            return _restService.GetRequest<Weather>(url);
        }

        private async Task<Weather> FetchWeatherDataAsync()
        {
            string apiKey = "";
            string urlTemplate = @"https://api.openweathermap.org/data/2.5/weather?q=Manila&appid={0}";
            string url = string.Format(urlTemplate, apiKey);

            return await _restService.GetRequest<Weather>(url);
        }


        private void RefreshStatus()
        {
            TaskStatus = _myTask != null
                ? $"IsCompleted: {_myTask.IsCompleted} | IsCanceled: {_myTask.IsCanceled} | IsFaulted: {_myTask.IsFaulted}" 
                : "_myTask is null";
        }
    }
}
