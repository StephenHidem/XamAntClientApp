using SmallEarthTech.AntPlus;
using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AntDevicesPage : ContentPage
    {
        private readonly AntDevicesViewModel vm;

        public AntDevicesPage()
        {
            InitializeComponent();
            BindingContext = vm = new AntDevicesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.OnAppearing();
        }

        private void AntDeviceSelected(object sender, System.EventArgs e)
        {
            ListView listView = sender as ListView;
            if (listView.SelectedItem is not AntDevice antDevice)
            {
                return;
            }
            vm.LoadDevicePage(antDevice);
            listView.SelectedItem = null;
        }
    }
}