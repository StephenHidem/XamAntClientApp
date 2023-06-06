using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.BicyclePowerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrankTorqueFrequencyPage : ContentPage
    {
        public CrankTorqueFrequencyPage(BicyclePowerViewModel vm)
        {
            InitializeComponent();
            Title = "Crank Torque Frequency";
            BindingContext = vm;
        }
    }
}