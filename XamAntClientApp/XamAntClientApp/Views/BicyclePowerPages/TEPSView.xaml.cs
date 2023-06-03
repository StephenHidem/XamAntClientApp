using SmallEarthTech.AntPlus.DeviceProfiles.BicyclePower;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.BicyclePowerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TEPSView : ContentView
    {
        public static readonly BindableProperty TorqueEffectivenesAndPedalSmoothnessProperty = BindableProperty.Create(
            "TEPS",
            typeof(TorqueEffectivenessAndPedalSmoothness),
            typeof(TEPSView));

        public TorqueEffectivenessAndPedalSmoothness TEPS
        {
            get => (TorqueEffectivenessAndPedalSmoothness)GetValue(TorqueEffectivenesAndPedalSmoothnessProperty);
            set => SetValue(TorqueEffectivenesAndPedalSmoothnessProperty, value);
        }

        public TEPSView()
        {
            InitializeComponent();
        }
    }
}