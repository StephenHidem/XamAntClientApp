using SmallEarthTech.AntPlus.DeviceProfiles.AssetTracker;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.AssetTrackerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssetTrackerTabbedPage : TabbedPage
    {
        public AssetTrackerTabbedPage(AssetTracker assetTracker)
        {
            InitializeComponent();
            Title = "Asset Tracker";
            Children.Add(new AssetTrackerPage(assetTracker));
            Children.Add(new CommonDataPage(assetTracker.CommonDataPages));
        }
    }
}