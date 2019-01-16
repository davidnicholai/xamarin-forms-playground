using System.Threading.Tasks;
using System.Windows.Input;
using Playground.MiscUtilities;
using Playground.Models;
using Xamarin.Forms;

namespace Playground.Tasks
{
    public class TasksPageViewModel : BindableBase
    {
        public ICommand StartTaskCommand { get; set; }
        public ICommand StartTaskCommandAwaited { get; set; }

        public TasksPageViewModel()
        {
            StartTaskCommand = new Command(() =>
            {
                SillySingleton.Instance.LoadWeather();
                SillySingleton.Instance.LoadWeather();
                SillySingleton.Instance.LoadWeather();
            });

            StartTaskCommandAwaited = new Command(async () =>
            {
                await SillySingleton.Instance.LoadWeather();
                await SillySingleton.Instance.LoadWeather();
                await SillySingleton.Instance.LoadWeather();
            });
        }
    }
}
