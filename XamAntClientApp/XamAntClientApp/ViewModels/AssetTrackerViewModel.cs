using SmallEarthTech.AntPlus.DeviceProfiles.AssetTracker;

namespace XamAntClientApp.ViewModels
{
    internal class AssetTrackerViewModel
    {
        public AssetTracker AssetTracker { get; }

        public AssetTrackerViewModel(AssetTracker tracker)
        {
            AssetTracker = tracker;
        }
    }
}
