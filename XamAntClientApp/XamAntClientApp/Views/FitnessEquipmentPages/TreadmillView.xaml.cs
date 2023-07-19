using SmallEarthTech.AntPlus.DeviceProfiles.FitnessEquipment;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.FitnessEquipmentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TreadmillView : ContentView
    {
        public static readonly BindableProperty TreadmillProperty =
            BindableProperty.Create(
            "TrdMill",
            typeof(Treadmill),
            typeof(TreadmillView)
        );

        public Treadmill TrdMill
        {
            get => (Treadmill)GetValue(TreadmillProperty);
            set => SetValue(TreadmillProperty, value);
        }

        public TreadmillView(Treadmill treadmill)
        {
            InitializeComponent();
            BindingContext = treadmill;
        }
    }
}