using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.HeartRatePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CapabilitiesPage : ContentPage
    {
        public CapabilitiesPage()
        {
            InitializeComponent();
            Title = "Capabilities/Features";
        }
    }
}