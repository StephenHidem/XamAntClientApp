using SmallEarthTech.AntPlus;
using SmallEarthTech.AntPlus.DeviceProfiles.HeartRate;
using XamAntClientApp.Services;
using XamAntClientApp.Views;
using Xamarin.Forms;

namespace XamAntClientApp.ViewModels
{
    internal partial class AntDevicesViewModel
    {
        public AntDeviceCollection AntDevices { get; }

        public AntDevicesViewModel()
        {

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
                HeartRate => new HeartRatePage(device as HeartRate),
                _ => throw new System.NotImplementedException()
            };

            await Shell.Current.Navigation.PushAsync(page);
        }
    }
}
