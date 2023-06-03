﻿using SmallEarthTech.AntPlus;
using SmallEarthTech.AntPlus.DeviceProfiles.AssetTracker;
using SmallEarthTech.AntPlus.DeviceProfiles.BicyclePower;
using SmallEarthTech.AntPlus.DeviceProfiles.HeartRate;
using SmallEarthTech.AntPlus.DeviceProfiles.StrideBasedSpeedAndDistance;
using SmallEarthTech.AntPlus.DeviceProfiles.UnknownDevice;
using XamAntClientApp.Services;
using XamAntClientApp.Views;
using XamAntClientApp.Views.AssetTrackerPages;
using XamAntClientApp.Views.BicyclePowerPages;
using XamAntClientApp.Views.HeartRatePages;
using Xamarin.Forms;

namespace XamAntClientApp.ViewModels
{
    internal class AntDevicesViewModel : BaseViewModel
    {
        public AntDeviceCollection AntDevices { get; }

        public AntDevicesViewModel()
        {
            Title = "ANT Devices";

            // create ANT device collection
            AntDevices = new AntDeviceCollection(new AntRadio());
        }

        public async void LoadDevicePage(AntDevice device)
        {
            Page page = device switch
            {
                AssetTracker => new AssetTrackerTabbedPage(device as AssetTracker),
                BicyclePower => new BicyclePowerTabbedPage(device as BicyclePower),
                HeartRate => new HeartRateTabbedPage(device as HeartRate),
                StrideBasedSpeedAndDistance => new StrideBasedMonitorPage(device as StrideBasedSpeedAndDistance),
                UnknownDevice => new UnknownDevicePage(device as UnknownDevice),
                _ => throw new System.NotImplementedException()
            }; ;

            await Shell.Current.Navigation.PushAsync(page);
        }
    }
}
