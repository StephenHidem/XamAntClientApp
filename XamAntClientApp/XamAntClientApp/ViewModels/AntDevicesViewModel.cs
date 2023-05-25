using SmallEarthTech.AntPlus;
using SmallEarthTech.AntPlus.DeviceProfiles.HeartRate;
using SmallEarthTech.AntPlus.DeviceProfiles.UnknownDevice;
using XamAntClientApp.Services;
using XamAntClientApp.Views;
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

        public void OnAppearing()
        {

        }

        public async void LoadDevicePage(AntDevice device)
        {
            Page page = device switch
            {
                HeartRate => new HeartRateTabbedPage(device as HeartRate),
                UnknownDevice => new UnknownDevicePage(device as UnknownDevice),
                _ => throw new System.NotImplementedException()
            };

            await Shell.Current.Navigation.PushAsync(page);
        }
    }
}
