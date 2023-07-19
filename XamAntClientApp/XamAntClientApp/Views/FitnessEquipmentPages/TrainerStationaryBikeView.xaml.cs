using SmallEarthTech.AntPlus.DeviceProfiles.FitnessEquipment;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.FitnessEquipmentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainerStationaryBikeView : ContentView
    {
        public static readonly BindableProperty TrainerStationaryBikeProperty =
            BindableProperty.Create(
            "Trainer",
            typeof(TrainerStationaryBike),
            typeof(TrainerStationaryBikeView)
        );

        public TrainerStationaryBike Trainer
        {
            get => (TrainerStationaryBike)GetValue(TrainerStationaryBikeProperty);
            set => SetValue(TrainerStationaryBikeProperty, value);
        }

        public TrainerStationaryBikeView(TrainerStationaryBike trainer)
        {
            InitializeComponent();
            BindingContext = trainer;
        }
    }
}