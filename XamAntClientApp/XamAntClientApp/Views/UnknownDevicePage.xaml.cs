using SmallEarthTech.AntPlus.DeviceProfiles.UnknownDevice;
using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnknownDevicePage : ContentPage
    {
        public UnknownDevicePage(UnknownDevice unknownDevice)
        {
            InitializeComponent();
            BindingContext = new UnknownDeviceViewModel(unknownDevice);
        }
    }
}