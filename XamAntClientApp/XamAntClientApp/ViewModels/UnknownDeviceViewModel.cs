using SmallEarthTech.AntPlus.DeviceProfiles;

namespace XamAntClientApp.ViewModels
{
    internal class UnknownDeviceViewModel : BaseViewModel
    {
        private readonly UnknownDevice unknownDevice;

        public UnknownDevice Device => unknownDevice;

        public UnknownDeviceViewModel(UnknownDevice device)
        {
            Title = "Unknown Device";
            unknownDevice = device;
        }
    }
}
