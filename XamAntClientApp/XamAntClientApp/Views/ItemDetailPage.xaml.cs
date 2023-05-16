using System.ComponentModel;
using XamAntClientApp.ViewModels;
using Xamarin.Forms;

namespace XamAntClientApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}