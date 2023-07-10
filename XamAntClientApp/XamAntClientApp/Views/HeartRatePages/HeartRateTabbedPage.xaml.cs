using SmallEarthTech.AntPlus.DeviceProfiles;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.HeartRatePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeartRateTabbedPage : TabbedPage
    {
        public HeartRateTabbedPage(HeartRate heartRate)
        {
            InitializeComponent();
            Title = "Heart Rate Monitor";
            Children.Add(new GeneralPage(heartRate));
            Children.Add(new CapabilitiesPage(heartRate));
        }
    }
}