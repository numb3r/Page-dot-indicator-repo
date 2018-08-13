using DataTemplateDemo.ViewModels;
using Xamarin.Forms;

namespace DataTemplateDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}