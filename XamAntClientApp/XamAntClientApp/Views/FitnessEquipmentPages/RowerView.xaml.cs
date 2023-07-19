using SmallEarthTech.AntPlus.DeviceProfiles.FitnessEquipment;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.FitnessEquipmentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RowerView : ContentView
    {
        public static readonly BindableProperty RowerProperty =
            BindableProperty.Create(
            "Rower",
            typeof(Rower),
            typeof(RowerView)
        );

        public Rower Rower
        {
            get => (Rower)GetValue(RowerProperty);
            set => SetValue(RowerProperty, value);
        }

        public RowerView(Rower rower)
        {
            InitializeComponent();
            BindingContext = rower;
        }
    }
}