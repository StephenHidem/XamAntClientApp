using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmallEarthTech.AntPlus.DeviceProfiles.FitnessEquipment;
using System;
using XamAntClientApp.Views.FitnessEquipmentPages;
using Xamarin.Forms;

namespace XamAntClientApp.ViewModels
{
    public partial class FitnessEquipmentViewModel : ObservableObject
    {
        public Equipment FitnessEquipment { get; }
        public ContentView SpecificEquipmentView { get; }

        [ObservableProperty]
        private double userWeight;
        [ObservableProperty]
        private byte wheelDiameterOffset;
        [ObservableProperty]
        private double bikeWeight;
        [ObservableProperty]
        private double wheelDiameter;
        [ObservableProperty]
        private double gearRatio;
        [ObservableProperty]
        private TimeSpan lapSplitTime;

        public FitnessEquipmentViewModel(Equipment fitnessEquipment)
        {
            FitnessEquipment = fitnessEquipment;
            FitnessEquipment.LapToggled += FitnessEquipment_LapToggled;
            switch (fitnessEquipment.GeneralData.EquipmentType)
            {
                case Equipment.FitnessEquipmentType.Treadmill:
                    SpecificEquipmentView = new TreadmillView(FitnessEquipment.Treadmill);
                    break;
                case Equipment.FitnessEquipmentType.Elliptical:
                    SpecificEquipmentView = new EllipticalView(FitnessEquipment.Elliptical);
                    break;
                case Equipment.FitnessEquipmentType.Rower:
                    SpecificEquipmentView = new RowerView(FitnessEquipment.Rower);
                    break;
                case Equipment.FitnessEquipmentType.Climber:
                    SpecificEquipmentView = new ClimberView(FitnessEquipment.Climber);
                    break;
                case Equipment.FitnessEquipmentType.NordicSkier:
                    SpecificEquipmentView = new NordicSkierView(FitnessEquipment.NordicSkier);
                    break;
                case Equipment.FitnessEquipmentType.TrainerStationaryBike:
                    SpecificEquipmentView = new TrainerStationaryBikeView(FitnessEquipment.TrainerStationaryBike);
                    break;
                default:
                    break;
            }
        }

        private void FitnessEquipment_LapToggled(object sender, EventArgs e)
        {
            LapSplitTime = ((Equipment)sender).GeneralData.ElapsedTime;
        }

        [RelayCommand]
        private void FECapabilitiesRequest() => FitnessEquipment.RequestFECapabilities();
        [RelayCommand]
        private void SetUserConfig() => FitnessEquipment.SetUserConfiguration(UserWeight, WheelDiameterOffset, BikeWeight, WheelDiameter, GearRatio);
        [RelayCommand]
        private void SetBasicResistance(string percent) => FitnessEquipment.SetBasicResistance(double.Parse(percent));
        [RelayCommand]
        private void SetTargetPower(string power) => FitnessEquipment.SetTargetPower(double.Parse(power));
        [RelayCommand]
        private void SetWindResistance() => FitnessEquipment.SetWindResistance(0.51, -30, 0.9);
        [RelayCommand]
        private void SetTrackResistance() => FitnessEquipment.SetTrackResistance(-15);
    }
}
