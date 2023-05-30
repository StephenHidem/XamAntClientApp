using SmallEarthTech.AntPlus.DeviceProfiles.AssetTracker;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.AssetTrackerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssetPage : ContentPage
    {
        public AssetPage(Asset asset)
        {
            InitializeComponent();
            BindingContext = asset;
            Title = string.Format("Asset Index {0}", asset.Index);
        }
    }
}