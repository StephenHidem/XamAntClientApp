using SmallEarthTech.AntPlus.DeviceProfiles.FitnessEquipment;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.FitnessEquipmentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NordicSkierView : ContentView
    {
        public static readonly BindableProperty NordicSkierProperty =
            BindableProperty.Create(
            "Nordic",
            typeof(NordicSkier),
            typeof(NordicSkierView)
        );

        public NordicSkier Nordic
        {
            get => (NordicSkier)GetValue(NordicSkierProperty);
            set => SetValue(NordicSkierProperty, value);
        }

        public NordicSkierView(NordicSkier nordic)
        {
            InitializeComponent();
            BindingContext = nordic;
        }
    }
}