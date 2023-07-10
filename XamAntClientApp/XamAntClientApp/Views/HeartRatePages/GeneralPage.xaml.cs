using SmallEarthTech.AntPlus.DeviceProfiles;
using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.HeartRatePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeneralPage : ContentPage
    {
        public GeneralPage(HeartRate heartRate)
        {
            InitializeComponent();
            Title = "General";
            BindingContext = new HeartRateViewModel(heartRate);
        }
    }
}