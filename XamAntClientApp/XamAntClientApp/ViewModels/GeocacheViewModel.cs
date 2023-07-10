﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmallEarthTech.AntPlus.DeviceProfiles;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Essentials;

#nullable enable
namespace XamAntClientApp.ViewModels
{
    public partial class GeocacheViewModel : ObservableObject
    {
        private bool pinReq, authReq, programming, logVisit;

        private readonly Geocache geocache;
        public Geocache Geocache => geocache;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ProgramGeocacheCommand))]
        private uint? pin;
        [ObservableProperty]
        private string? trackableId;
        [ObservableProperty]
        private double? latitude;
        [ObservableProperty]
        private double? longitude;
        [ObservableProperty]
        private string? hint;

        public GeocacheViewModel(Geocache geocache)
        {
            this.geocache = geocache;
            geocache.PropertyChanged += Geocache_PropertyChanged;
        }

        private void Geocache_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Geocache.ProgrammingPIN):
                    if (pinReq)
                    {
                        pinReq = false;
                        CheckCanExecutes();
                    }
                    break;
                case nameof(Geocache.NumberOfVisits):
                    if (logVisit)
                    {
                        logVisit = false;
                    }
                    CheckCanExecutes();
                    break;
                case nameof(Geocache.AuthenticationToken):
                    if (authReq)
                    {
                        authReq = false;
                        CheckCanExecutes();
                    }
                    break;
                default:
                    break;
            }
        }

        [RelayCommand(CanExecute = nameof(CanRequestPin))]
        private async void RequestPIN()
        {
            pinReq = true;
            CheckCanExecutes();
            _ = await Task.Run(() => geocache.RequestPinPage());
        }
        private bool CanRequestPin()
        {
            return !geocache.Offline && !programming && !pinReq && !authReq;
        }

        [RelayCommand(CanExecute = nameof(CanLogVisit))]
        private void LogVisit()
        {
            logVisit = true;
            CheckCanExecutes();
            _ = geocache.UpdateLoggedVisits();
        }
        private bool CanLogVisit()
        {
            return !geocache.Offline && !programming && !logVisit && !pinReq && !authReq && geocache.NumberOfVisits != null;
        }

        [RelayCommand(CanExecute = nameof(CanRequestAuthentication))]
        private async void RequestAuthentication()
        {
            authReq = true;
            CheckCanExecutes();
            Random rnd = new();
            _ = await Task.Run(() => geocache.RequestAuthentication((uint)rnd.Next()));
        }
        private bool CanRequestAuthentication()
        {
            return !geocache.Offline && !programming && !pinReq && !logVisit && !authReq;
        }

        [RelayCommand(CanExecute = nameof(CanProgramGeocache))]
        private async void ProgramGeocache()
        {
            // we want to capture the updated logged visits
            programming = logVisit = true;
            CheckCanExecutes();
            await Task.Run(() =>
            {
                geocache.ProgramGeocache(TrackableId, Pin, Latitude, Longitude, Hint);
                programming = false;
                CheckCanExecutes();
            });
        }
        private bool CanProgramGeocache()
        {
            return !geocache.Offline && !programming && !pinReq && !logVisit && !authReq;
        }

        private void CheckCanExecutes()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                RequestPINCommand.NotifyCanExecuteChanged();
                LogVisitCommand.NotifyCanExecuteChanged();
                RequestAuthenticationCommand.NotifyCanExecuteChanged();
                ProgramGeocacheCommand.NotifyCanExecuteChanged();
            });
        }
    }
}