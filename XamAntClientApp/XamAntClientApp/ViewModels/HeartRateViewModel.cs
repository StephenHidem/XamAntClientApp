using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmallEarthTech.AntPlus;
using SmallEarthTech.AntPlus.DeviceProfiles.HeartRate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamAntClientApp.ViewModels
{
    internal partial class HeartRateViewModel : ObservableObject
    {
        [ObservableProperty]
        private HeartRate heartRateDevice;

        public static IEnumerable<HeartRate.DataPage> DataPageValues => Enum.GetValues(typeof(HeartRate.DataPage)).Cast<HeartRate.DataPage>();
        public static IEnumerable<SportMode> SportModeValues => Enum.GetValues(typeof(SportMode)).Cast<SportMode>();

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RequestPageCommand))]
        private HeartRate.DataPage pageRequested;
        [ObservableProperty]
        private SportMode modeRequested;

        [ObservableProperty]
        private bool applyFeature;
        [ObservableProperty]
        private bool enableGymMode;

        public HeartRateViewModel(HeartRate heartRate)
        {
            HeartRateDevice = heartRate;
            PageRequested = HeartRate.DataPage.Capabilities;
            ModeRequested = SportMode.Cycling;
        }

        [RelayCommand(CanExecute = nameof(CanRequestPage))]
        private void RequestPage()
        {
            _ = HeartRateDevice.RequestDataPage(PageRequested);
        }
        private bool CanRequestPage()
        {
            switch (PageRequested)
            {
                case HeartRate.DataPage.Default:
                case HeartRate.DataPage.PreviousHeartBeat:
                    return false;
                case HeartRate.DataPage.CumulativeOperatingTime:
                case HeartRate.DataPage.ManufacturerInfo:
                case HeartRate.DataPage.ProductInfo:
                case HeartRate.DataPage.SwimInterval:
                case HeartRate.DataPage.Capabilities:
                case HeartRate.DataPage.BatteryStatus:
                    return true;
                default:
                    return false;
            }
        }

        private bool CanSetSportMode()
        {
            return ModeRequested switch
            {
                SportMode.Generic => !HeartRateDevice.Capabilities.Enabled.Equals(HeartRate.Features.Generic),
                SportMode.Running => HeartRateDevice.Capabilities.Supported.HasFlag(HeartRate.Features.Running),
                SportMode.Cycling => HeartRateDevice.Capabilities.Supported.HasFlag(HeartRate.Features.Cycling),
                SportMode.Swimming => HeartRateDevice.Capabilities.Supported.HasFlag(HeartRate.Features.Swimming),
                _ => false,
            };
        }

        [RelayCommand]
        private void SetCapabilities()
        {
            // check if gym mode is supported
            if (HeartRateDevice.Capabilities.Supported.HasFlag(HeartRate.Features.GymMode))
            {
                HeartRateDevice.SetHRFeature(true, EnableGymMode);
            }

            // check selected sport mode is supported
            if (CanSetSportMode())
            {
                HeartRateDevice.SetSportMode(ModeRequested);
            }
        }

        [RelayCommand(CanExecute = nameof(CanSetSportMode))]
        private void SetSportMode()
        {
            HeartRateDevice.SetSportMode(ModeRequested);
        }

        [RelayCommand]
        private void SetHRFeature()
        {
            HeartRateDevice.SetHRFeature(ApplyFeature, EnableGymMode);
        }
    }
}
