using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.BicyclePowerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BicycleCalibrationPage : ContentPage
    {
        public BicycleCalibrationPage(BicyclePowerViewModel vm)
        {
            InitializeComponent();
            Title = "Calibration";
            BindingContext = vm;
        }
    }
}