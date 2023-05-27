using SmallEarthTech.AntPlus.DeviceProfiles.AssetTracker;
using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssetTrackerPage : ContentPage
    {
        public AssetTrackerPage(AssetTracker assetTracker)
        {
            InitializeComponent();
            Title = "Asset Tracker";
            BindingContext = new AssetTrackerViewModel(assetTracker);
        }
    }
}