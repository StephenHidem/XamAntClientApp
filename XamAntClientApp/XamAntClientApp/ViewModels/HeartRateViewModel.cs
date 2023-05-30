using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmallEarthTech.AntPlus;
using SmallEarthTech.AntPlus.DeviceProfiles.HeartRate;
using Xamarin.Essentials;

namespace XamAntClientApp.ViewModels
{
    internal partial class HeartRateViewModel : ObservableObject
    {
        public HeartRate HeartRateDevice { get; }

        [ObservableProperty]
        private SportMode modeRequested;
        [ObservableProperty]
        private bool applyFeature;
        [ObservableProperty]
        private bool enableGymMode;
        [ObservableProperty]
        private bool isGymModeSupported;
        [ObservableProperty]
        private bool isRunningSupported;
        [ObservableProperty]
        private bool isCyclingSupported;
        [ObservableProperty]
        private bool isSwimmingSupported;

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
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    IsCyclingSupported = HeartRateDevice.Capabilities.Supported.HasFlag(HeartRate.Features.Cycling);
                    IsRunningSupported = HeartRateDevice.Capabilities.Supported.HasFlag(HeartRate.Features.Running);
                    IsSwimmingSupported = HeartRateDevice.Capabilities.Supported.HasFlag(HeartRate.Features.Swimming);
                    IsGymModeSupported = HeartRateDevice.Capabilities.Supported.HasFlag(HeartRate.Features.GymMode);
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
            return IsGymModeSupported;
        }

        [RelayCommand(CanExecute = nameof(CanSetSportMode))]
        private void SetSportMode()
        {
            HeartRateDevice.SetSportMode(ModeRequested);
        }
        private bool CanSetSportMode()
        {
            return IsRunningSupported || IsCyclingSupported || IsSwimmingSupported;
        }
    }
}
