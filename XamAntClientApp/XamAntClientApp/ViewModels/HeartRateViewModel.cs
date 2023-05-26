using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmallEarthTech.AntPlus;
using SmallEarthTech.AntPlus.DeviceProfiles.HeartRate;

namespace XamAntClientApp.ViewModels
{
    internal partial class HeartRateViewModel : ObservableObject
    {
        [ObservableProperty]
        private HeartRate heartRateDevice;

        //public List<HeartRate.DataPage> DataPageValues => Enum.GetValues(typeof(HeartRate.DataPage)).Cast<HeartRate.DataPage>().ToList();
        //public List<SportMode> SportModeValues => Enum.GetValues(typeof(SportMode)).Cast<SportMode>().ToList();

        [ObservableProperty]
        private SportMode modeRequested;

        [ObservableProperty]
        private bool applyFeature;
        [ObservableProperty]
        private bool enableGymMode;

        public HeartRateViewModel(HeartRate heartRate)
        {
            HeartRateDevice = heartRate;
            ModeRequested = SportMode.Generic;
            ApplyFeature = true;
            HeartRateDevice.PropertyChanged += HeartRateDevice_PropertyChanged;
        }

        private void HeartRateDevice_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Capabilities")
            {
                App.Current.Dispatcher.BeginInvokeOnMainThread(() =>
                {
                    SetGymModeCommand.NotifyCanExecuteChanged();
                    SetSportModeCommand.NotifyCanExecuteChanged();
                });
            }
        }

        [RelayCommand]
        private void GetCapabilities()
        {
            _ = HeartRateDevice.RequestDataPage(HeartRate.DataPage.Capabilities);
        }

        [RelayCommand(CanExecute = nameof(CanSetGymMode))]
        private void SetGymMode()
        {
            HeartRateDevice.SetHRFeature(ApplyFeature, EnableGymMode);
        }
        private bool CanSetGymMode()
        {
            return HeartRateDevice.Capabilities.Supported.HasFlag(HeartRate.Features.GymMode);
        }

        [RelayCommand(CanExecute = nameof(CanSetSportMode))]
        private void SetSportMode()
        {
            HeartRateDevice.SetSportMode(ModeRequested);
        }
        private bool CanSetSportMode()
        {
            return HeartRateDevice.Capabilities.Supported.HasFlag(HeartRate.Features.Running) ||
                HeartRateDevice.Capabilities.Supported.HasFlag(HeartRate.Features.Cycling) ||
                HeartRateDevice.Capabilities.Supported.HasFlag(HeartRate.Features.Swimming);
        }

        [RelayCommand]
        private void SetHRFeature()
        {
            HeartRateDevice.SetHRFeature(ApplyFeature, EnableGymMode);
        }
    }
}
