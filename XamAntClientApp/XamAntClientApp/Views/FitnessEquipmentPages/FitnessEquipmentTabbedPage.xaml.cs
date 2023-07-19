using SmallEarthTech.AntPlus.DeviceProfiles.FitnessEquipment;
using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.FitnessEquipmentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FitnessEquipmentTabbedPage : TabbedPage
    {
        public FitnessEquipmentTabbedPage(Equipment fitnessEquipment)
        {
            InitializeComponent();
            FitnessEquipmentViewModel vm = new(fitnessEquipment);
            Children.Add(new EquipmentDataPage(vm));
            Children.Add(new GeneralDataPage(vm));
            Children.Add(new EquipmentSettingsPage(vm));
        }
    }
}