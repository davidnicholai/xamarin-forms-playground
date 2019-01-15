using System;
using Xamarin.Forms;

namespace Playground
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ActivityIndicatorPage_Clicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new ActivityIndicator.ActivityIndicatorPage());
        }

        private async void TasksPage_Clicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new Tasks.TasksPage());
        }
    }
}
