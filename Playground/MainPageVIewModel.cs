using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Playground
{
    public class MainPageViewModel : BindableBase
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

        private string _isRunningText;
        public string IsRunningText
        {
            get { return _isRunningText; }
            set { SetProperty(ref _isRunningText, value); }
        }

        private string _isVisibleText;
        public string IsVisibleText
        {
            get { return _isVisibleText; }
            set { SetProperty(ref _isVisibleText, value); }
        }

        public MainPageViewModel()
        {
            IsRunningCommand = new Command(() =>
            {
                IsRunningSpinner = !IsRunningSpinner;
                IsRunningText = "IsRunning: " + IsRunningSpinner.ToString();
            });

            IsVisibleCommand = new Command(() =>
            {
                IsVisibleSpinner = !IsVisibleSpinner;
                IsVisibleText = "IsVisible: " + IsVisibleSpinner.ToString();
            });

            IsRunningText = "IsRunning: " + IsRunningSpinner.ToString();
            IsVisibleText = "IsVisible: " + IsVisibleSpinner.ToString();
        }
    }
}
