using Microsoft.Maui.Controls;

namespace Syddjurs
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var customShell = new CustomShell();

            MainPage = customShell;

#if ANDROID
            var activity = Platform.CurrentActivity as MainActivity;
            bool isDark = RequestedTheme == AppTheme.Dark;
            activity?.SetSystemBarColorsBasedOnTheme(isDark);

            RequestedThemeChanged += (s, e) =>
            {
                var act = Platform.CurrentActivity as MainActivity;
                act?.SetSystemBarColorsBasedOnTheme(e.RequestedTheme == AppTheme.Dark);
            };
#endif
        }
    }
}