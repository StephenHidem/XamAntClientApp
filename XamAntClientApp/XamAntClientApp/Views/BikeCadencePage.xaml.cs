using SmallEarthTech.AntPlus.DeviceProfiles.BikeSpeedAndCadence;
using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BikeCadencePage : ContentPage
    {
        public BikeCadencePage(BikeCadenceSensor bikeCadence)
        {
            InitializeComponent();
            BindingContext = new BikeCadenceViewModel(bikeCadence);
        }
    }
}