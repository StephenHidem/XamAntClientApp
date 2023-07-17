using SmallEarthTech.AntPlus.DeviceProfiles;
using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MuscleOxygenPage : ContentPage
    {
        public MuscleOxygenPage(MuscleOxygen muscleOxygen)
        {
            InitializeComponent();
            BindingContext = new MuscleOxygenViewModel(muscleOxygen);
        }
    }
}