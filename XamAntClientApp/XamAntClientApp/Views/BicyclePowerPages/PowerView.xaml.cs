using SmallEarthTech.AntPlus.DeviceProfiles.BicyclePower;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.BicyclePowerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PowerView : ContentView
    {
        public static readonly BindableProperty StandardPowerSensorProperty =
            BindableProperty.Create(
            "Power",
            typeof(StandardPowerSensor),
            typeof(PowerView)
        );

        public StandardPowerSensor Power
        {
            get => (StandardPowerSensor)GetValue(StandardPowerSensorProperty);
            set => SetValue(StandardPowerSensorProperty, value);
        }

        public PowerView()
        {
            InitializeComponent();
        }
    }
}