using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.HeartRatePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeneralPage : ContentPage
    {
        public GeneralPage()
        {
            InitializeComponent();
            Title = "General";
        }
    }
}