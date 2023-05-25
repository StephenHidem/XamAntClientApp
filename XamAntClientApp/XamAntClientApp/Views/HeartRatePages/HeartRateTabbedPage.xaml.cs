using SmallEarthTech.AntPlus.DeviceProfiles.HeartRate;
using XamAntClientApp.ViewModels;
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
            HeartRateViewModel vm = new(heartRate);
            Page page = new GeneralPage
            {
                BindingContext = vm
            };
            Children.Add(page);
            page = new CapabilitiesPage
            {
                BindingContext = vm
            };
            Children.Add(page);
            page = new FeaturesPage
            {
                BindingContext = vm
            };
            Children.Add(page);
        }
    }
}