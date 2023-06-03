using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.BicyclePowerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BicycleCrankTorquePage : ContentPage
    {
        public BicycleCrankTorquePage(BicyclePowerViewModel vm)
        {
            InitializeComponent();
            Title = "Crank Torque";
            BindingContext = vm;
        }
    }
}