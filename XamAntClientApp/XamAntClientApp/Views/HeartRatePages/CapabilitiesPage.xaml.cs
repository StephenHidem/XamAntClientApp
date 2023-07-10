using SmallEarthTech.AntPlus.DeviceProfiles;
using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.HeartRatePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CapabilitiesPage : ContentPage
    {
        public CapabilitiesPage(HeartRate heartRate)
        {
            InitializeComponent();
            Title = "Capabilities/Features";
            BindingContext = new HeartRateViewModel(heartRate);
        }
    }
}