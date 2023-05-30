using SmallEarthTech.AntPlus.DeviceProfiles.AssetTracker;
using System.Diagnostics;
using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.AssetTrackerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssetTrackerPage : ContentPage
    {
        public AssetTrackerPage(AssetTracker assetTracker)
        {
            InitializeComponent();
            Title = "Assets";
            BindingContext = new AssetTrackerViewModel(assetTracker);
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Debug.WriteLine(sender);
            await Shell.Current.Navigation.PushAsync(new AssetPage(e.Item as Asset));
            ((ListView)sender).SelectedItem = null;
        }
    }
}