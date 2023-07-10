using SmallEarthTech.AntPlus.DeviceProfiles.AssetTracker;

namespace XamAntClientApp.ViewModels
{
    internal class AssetTrackerViewModel
    {
        public Tracker AssetTracker { get; }

        public AssetTrackerViewModel(Tracker tracker)
        {
            AssetTracker = tracker;
        }
    }
}
