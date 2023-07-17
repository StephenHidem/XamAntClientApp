using SmallEarthTech.AntPlus.DeviceProfiles.BikeSpeedAndCadence;
using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BikeSpeedPage : ContentPage
    {
        public BikeSpeedPage(BikeSpeedSensor bikeSpeedSensor)
        {
            InitializeComponent();
            BindingContext = new BikeSpeedViewModel(bikeSpeedSensor);
        }
    }
}