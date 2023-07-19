using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.FitnessEquipmentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EquipmentSettingsPage : ContentPage
    {
        public EquipmentSettingsPage(FitnessEquipmentViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}