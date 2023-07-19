using SmallEarthTech.AntPlus.DeviceProfiles.FitnessEquipment;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.FitnessEquipmentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EllipticalView : ContentView
    {
        public static readonly BindableProperty EllipticalProperty =
            BindableProperty.Create(
            "Ellipt",
            typeof(Elliptical),
            typeof(EllipticalView)
        );

        public Elliptical Ellipt
        {
            get => (Elliptical)GetValue(EllipticalProperty);
            set => SetValue(EllipticalProperty, value);
        }

        public EllipticalView(Elliptical elliptical)
        {
            InitializeComponent();
            BindingContext = elliptical;
        }
    }
}