using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.BicyclePowerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BicycleParametersPage : ContentPage
    {
        public BicycleParametersPage(BicyclePowerViewModel vm)
        {
            InitializeComponent();
            Title = "Parameters";
            BindingContext = vm;
        }
    }
}