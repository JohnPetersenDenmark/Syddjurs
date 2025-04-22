using Microsoft.Maui.Controls;

namespace Syddjurs
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var customShell =  new CustomShell();

            MainPage = customShell;
        }

       
    }
}