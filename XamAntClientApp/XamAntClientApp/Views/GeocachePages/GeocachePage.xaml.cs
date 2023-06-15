using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.GeocachePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeocachePage : ContentPage
    {
        public GeocachePage(GeocacheViewModel vm)
        {
            InitializeComponent();
            Title = "Geocache";
            BindingContext = vm;
        }
    }
}