using SmallEarthTech.AntPlus.DeviceProfiles;
using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StrideBasedMonitorPage : ContentPage
    {
        public StrideBasedMonitorPage(StrideBasedSpeedAndDistance sdm)
        {
            InitializeComponent();
            Title = "Stride Based Speed and Distance";
            BindingContext = new SDMViewModel(sdm);
        }
    }
}