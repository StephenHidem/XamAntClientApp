using SmallEarthTech.AntPlus.DeviceProfiles.Geocache;
using XamAntClientApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAntClientApp.Views.GeocachePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeocacheTabbedPage : TabbedPage
    {
        public GeocacheTabbedPage(Geocache geocache)
        {
            InitializeComponent();
            Title = "Geocache";
            GeocacheViewModel vm = new(geocache);
            Children.Add(new GeocachePage(vm));
            Children.Add(new ProgramGeocachePage(vm));
            Children.Add(new CommonDataPage(geocache.CommonDataPages));
        }
    }
}