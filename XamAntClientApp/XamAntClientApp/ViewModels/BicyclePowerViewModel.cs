using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmallEarthTech.AntPlus.DeviceProfiles.BicyclePower;
using System;

namespace XamAntClientApp.ViewModels
{
    public partial class BicyclePowerViewModel : ObservableObject
    {
        public BicyclePower BicyclePower { get; }
        public SensorType SensorType => BicyclePower.Sensor;

        [ObservableProperty]
        private string ctfAckMessage;

        public BicyclePowerViewModel(BicyclePower bicyclePower)
        {
            BicyclePower = bicyclePower;
            if (bicyclePower.Sensor == SensorType.CrankTorqueFrequency)
            {
                bicyclePower.CTFSensor.SaveAcknowledged += CTFSensor_SaveAcknowledged;
            }
        }

        private void CTFSensor_SaveAcknowledged(object sender, CrankTorqueFrequencySensor.CTFDefinedId e)
        {
            switch (e)
            {
                case CrankTorqueFrequencySensor.CTFDefinedId.Slope:
                    CtfAckMessage = "Slope saved.";
                    break;
                case CrankTorqueFrequencySensor.CTFDefinedId.SerialNumber:
                    CtfAckMessage = "Serial number saved.";
                    break;
                default:
                    break;
            }
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
        private void GetParameters(Subpage subpage) => BicyclePower.PowerSensor.Parameters.GetParameters(subpage);

        [RelayCommand]
        private void SetCrankLength(string length) => BicyclePower.PowerSensor.Parameters.SetCrankLength(Convert.ToDouble(length));

        [RelayCommand]
        private void SaveSlope(string slope)
        {
            CtfAckMessage = "Save slope";
            BicyclePower.CTFSensor.SaveSlopeToFlash(Convert.ToDouble(slope));
        }

        [RelayCommand]
        private void SaveSerialNumber(string sn)
        {
            CtfAckMessage = "Save SN";
            BicyclePower.CTFSensor.SaveSerialNumberToFlash(Convert.ToUInt16(sn));
        }
    }
}
