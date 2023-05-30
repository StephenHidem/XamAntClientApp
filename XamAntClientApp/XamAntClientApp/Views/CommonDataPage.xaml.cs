using SmallEarthTech.AntPlus;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommonDataPage : ContentPage
    {
        public CommonDataPage(CommonDataPages commonDataPages)
        {
            InitializeComponent();
            Title = "Common Data Pages";
            BindingContext = commonDataPages;
        }
    }
}