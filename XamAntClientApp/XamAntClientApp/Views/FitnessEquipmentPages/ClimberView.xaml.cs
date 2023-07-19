using SmallEarthTech.AntPlus.DeviceProfiles.FitnessEquipment;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.FitnessEquipmentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClimberView : ContentView
    {
        public static readonly BindableProperty ClimberProperty =
            BindableProperty.Create(
            "Climber",
            typeof(Climber),
            typeof(ClimberView)
        );

        public Climber Climber
        {
            get => (Climber)GetValue(ClimberProperty);
            set => SetValue(ClimberProperty, value);
        }

        public ClimberView(Climber climber)
        {
            InitializeComponent();
            BindingContext = climber;
        }
    }
}