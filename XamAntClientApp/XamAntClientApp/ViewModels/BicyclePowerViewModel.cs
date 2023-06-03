using CommunityToolkit.Mvvm.Input;
using SmallEarthTech.AntPlus.DeviceProfiles.BicyclePower;

namespace XamAntClientApp.ViewModels
{
    public partial class BicyclePowerViewModel
    {
        public BicyclePower BicyclePower { get; }
        public SensorType SensorType => BicyclePower.Sensor;

        public BicyclePowerViewModel(BicyclePower bicyclePower)
        {
            BicyclePower = bicyclePower;
        }

        [RelayCommand]
        private void ManualCalRequest() => BicyclePower.Calibration.RequestManualCalibration();

        [RelayCommand(CanExecute = nameof(CanSetAutoZeroConfig))]
        private void SetAutoZeroConfig() => BicyclePower.Calibration.SetAutoZeroConfiguration(Calibration.AutoZero.On);
        private bool CanSetAutoZeroConfig() => BicyclePower.Sensor != SensorType.CrankTorqueFrequency;

        [RelayCommand(CanExecute = nameof(CanGetCustomCalParameters))]
        private void GetCustomCalParameters() => BicyclePower.Calibration.RequestCustomParameters();
        private bool CanGetCustomCalParameters() => BicyclePower.Sensor != SensorType.CrankTorqueFrequency;

        [RelayCommand(CanExecute = nameof(CanSetCustomCalParameters))]
        private void SetCustomCalParameters() => BicyclePower.Calibration.SetCustomParameters(new byte[] { 0x11, 0x22, 0x33, 0x44, 0x55, 0x66 });
        private bool CanSetCustomCalParameters() => BicyclePower.Sensor != SensorType.CrankTorqueFrequency;

        [RelayCommand]
        private void GetParameters(Subpage subpage) => BicyclePower.PowerOnlySensor.Parameters.GetParameters(subpage);

        [RelayCommand]
        private void SetCrankLength(string length) => BicyclePower.PowerOnlySensor.Parameters.SetCrankLength(double.Parse(length));
    }
}
