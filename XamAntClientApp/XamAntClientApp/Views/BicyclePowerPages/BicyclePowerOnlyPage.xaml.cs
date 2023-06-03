using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.BicyclePowerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BicyclePowerOnlyPage : ContentPage
    {
        public BicyclePowerOnlyPage(BicyclePowerViewModel vm)
        {
            InitializeComponent();
            Title = "Power Only";
            BindingContext = vm;
        }
    }
}