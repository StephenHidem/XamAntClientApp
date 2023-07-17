﻿using SmallEarthTech.AntPlus.DeviceProfiles.BikeSpeedAndCadence;

namespace XamAntClientApp.ViewModels
{
    internal class BikeSpeedAndCadenceViewModel
    {
        private readonly CombinedSpeedAndCadenceSensor combined;

        public CombinedSpeedAndCadenceSensor CombinedSpeedAndCadenceSensor => combined;

        public BikeSpeedAndCadenceViewModel(CombinedSpeedAndCadenceSensor combinedSpeedAndCadence)
        {
            combined = combinedSpeedAndCadence;
        }
    }
}
