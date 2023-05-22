using SmallEarthTech.AntPlus.DeviceProfiles.UnknownDevice;

namespace XamAntClientApp.ViewModels
{
    internal class UnknownDeviceViewModel
    {
        private readonly UnknownDevice unknownDevice;

        public UnknownDevice UnknownDevice => unknownDevice;

        public UnknownDeviceViewModel(UnknownDevice device)
        {
            unknownDevice = device;
        }
    }
}
