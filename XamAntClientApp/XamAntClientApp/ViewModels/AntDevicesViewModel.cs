using SmallEarthTech.AntPlus;
using SmallEarthTech.AntPlus.DeviceProfiles;
using SmallEarthTech.AntPlus.DeviceProfiles.AssetTracker;
using SmallEarthTech.AntPlus.DeviceProfiles.BicyclePower;
using SmallEarthTech.AntPlus.DeviceProfiles.BikeSpeedAndCadence;
using SmallEarthTech.AntPlus.DeviceProfiles.FitnessEquipment;
using XamAntClientApp.Services;
using XamAntClientApp.Views;
using XamAntClientApp.Views.AssetTrackerPages;
using XamAntClientApp.Views.BicyclePowerPages;
using XamAntClientApp.Views.FitnessEquipmentPages;
using XamAntClientApp.Views.GeocachePages;
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
            AntDevices = new AntDeviceCollection(new AntRadio(), null);
        }

        public async void LoadDevicePage(AntDevice device)
        {
            Page page = device switch
            {
                Tracker => new AssetTrackerTabbedPage(device as Tracker),
                Bicycle => new BicyclePowerTabbedPage(device as Bicycle),
                BikeCadenceSensor => new BikeCadencePage(device as BikeCadenceSensor),
                BikeSpeedSensor => new BikeSpeedPage(device as BikeSpeedSensor),
                CombinedSpeedAndCadenceSensor => new BikeSpeedAndCadencePage(device as CombinedSpeedAndCadenceSensor),
                Equipment => new FitnessEquipmentTabbedPage(device as Equipment),
                Geocache => new GeocacheTabbedPage(device as Geocache),
                HeartRate => new HeartRateTabbedPage(device as HeartRate),
                MuscleOxygen => new MuscleOxygenTabbedPage(device as MuscleOxygen),
                StrideBasedSpeedAndDistance => new StrideBasedMonitorPage(device as StrideBasedSpeedAndDistance),
                UnknownDevice => new UnknownDevicePage(device as UnknownDevice),
                _ => throw new System.NotImplementedException()
            };

            await Shell.Current.Navigation.PushAsync(page);
        }
    }
}
