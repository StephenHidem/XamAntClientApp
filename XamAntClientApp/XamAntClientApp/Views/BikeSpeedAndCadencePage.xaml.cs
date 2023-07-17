using SmallEarthTech.AntPlus.DeviceProfiles.BikeSpeedAndCadence;
using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BikeSpeedAndCadencePage : ContentPage
    {
        public BikeSpeedAndCadencePage(CombinedSpeedAndCadenceSensor combinedSpeedAndCadence)
        {
            InitializeComponent();
            BindingContext = new BikeSpeedAndCadenceViewModel(combinedSpeedAndCadence);
        }
    }
}