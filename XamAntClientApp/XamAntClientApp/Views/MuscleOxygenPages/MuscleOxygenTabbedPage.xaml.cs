using SmallEarthTech.AntPlus.DeviceProfiles;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MuscleOxygenTabbedPage : TabbedPage
    {
        public MuscleOxygenTabbedPage(MuscleOxygen muscleOxygen)
        {
            InitializeComponent();
            Title = "Muscle Oxygen Sensor";
            Children.Add(new MuscleOxygenPage(muscleOxygen));
            Children.Add(new CommonDataPage(muscleOxygen.CommonDataPages));
        }
    }
}