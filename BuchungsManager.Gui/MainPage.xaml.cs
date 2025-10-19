using BuchungsManager.Core.ViewModels;

namespace BuchungsManager.Gui
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }

        
    }

}
