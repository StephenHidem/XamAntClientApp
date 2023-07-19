using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.FitnessEquipmentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeneralDataPage : ContentPage
    {
        public GeneralDataPage(FitnessEquipmentViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}