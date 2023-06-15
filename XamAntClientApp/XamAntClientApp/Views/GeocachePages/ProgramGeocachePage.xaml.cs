using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.GeocachePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgramGeocachePage : ContentPage
    {
        public ProgramGeocachePage(GeocacheViewModel vm)
        {
            InitializeComponent();
            Title = "Programming";
            BindingContext = vm;
        }
    }
}