using System.Windows.Input;
using Xamarin.Forms;

namespace Playground.ActivityIndicator
{
    public class ActivityIndicatorPageViewModel : BindableBase
    {
        public ICommand IsRunningCommand { get; set; }
        public ICommand IsVisibleCommand { get; set; }

        private bool _isRunningSpinner;
        public bool IsRunningSpinner
        {
            get { return _isRunningSpinner; }
            set { SetProperty(ref _isRunningSpinner, value); }
        }

        private bool _isVisibleSpinner;
        public bool IsVisibleSpinner
        {
            get { return _isVisibleSpinner; }
            set { SetProperty(ref _isVisibleSpinner, value); }
        }

        public ActivityIndicatorPageViewModel()
        {
            IsRunningCommand = new Command(() => IsRunningSpinner = !IsRunningSpinner);
            IsVisibleCommand = new Command(() => IsVisibleSpinner = !IsVisibleSpinner);
        }
    }
}