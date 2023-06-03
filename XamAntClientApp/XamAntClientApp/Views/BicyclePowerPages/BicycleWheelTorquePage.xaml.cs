using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.BicyclePowerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BicycleWheelTorquePage : ContentPage
    {
        public BicycleWheelTorquePage(BicyclePowerViewModel vm)
        {
            InitializeComponent();
            Title = "Wheel Torque";
            BindingContext = vm;
        }
    }
}