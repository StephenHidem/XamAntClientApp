using SmallEarthTech.AntPlus.DeviceProfiles.UnknownDevice;

namespace XamAntClientApp.ViewModels
{
    internal class UnknownDeviceViewModel : BaseViewModel
    {
        private readonly UnknownDevice unknownDevice;

        public UnknownDevice UnknownDevice => unknownDevice;

        public UnknownDeviceViewModel(UnknownDevice device)
        {
            Title = "Unknown Device";
            unknownDevice = device;
        }
    }
}
