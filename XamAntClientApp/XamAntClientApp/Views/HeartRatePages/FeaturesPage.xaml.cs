using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.HeartRatePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeaturesPage : ContentPage
    {
        public FeaturesPage()
        {
            InitializeComponent();
            Title = "Features";
        }
    }
}