using SmallEarthTech.AntPlus.DeviceProfiles.BicyclePower;
using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.BicyclePowerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BicyclePowerTabbedPage : TabbedPage
    {
        public BicyclePowerTabbedPage(BicyclePower bicyclePower)
        {
            InitializeComponent();
            Title = "Bicycle Power";
            BicyclePowerViewModel vm = new(bicyclePower);
            switch (bicyclePower.Sensor)
            {
                case SensorType.Power:
                    Children.Add(new BicyclePowerOnlyPage(vm));
                    AddStandardPages(vm);
                    break;
                case SensorType.WheelTorque:
                    Children.Add(new BicycleWheelTorquePage(vm));
                    AddStandardPages(vm);
                    break;
                case SensorType.CrankTorque:
                    Children.Add(new BicycleCrankTorquePage(vm));
                    AddStandardPages(vm);
                    break;
                case SensorType.CrankTorqueFrequency:
                    Children.Add(new CrankTorqueFrequencyPage(vm));
                    break;
                default:
                    break;
            }
        }

        private void AddStandardPages(BicyclePowerViewModel vm)
        {
            Children.Add(new CommonDataPage(vm.BicyclePower.PowerSensor.CommonDataPages));
            Children.Add(new BicycleCalibrationPage(vm));
            Children.Add(new BicycleParametersPage(vm));
        }
    }
}