using SmallEarthTech.AntPlus.DeviceProfiles.HeartRate;
using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeartRatePage : ContentPage
    {
        public HeartRatePage(HeartRate heartRate)
        {
            InitializeComponent();
            BindingContext = new HeartRateViewModel(heartRate);
        }
    }
}