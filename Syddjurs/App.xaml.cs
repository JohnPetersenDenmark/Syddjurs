﻿using Microsoft.Maui.Controls;
using Syddjurs.Pages;

namespace Syddjurs
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ItemPage), typeof(ItemPage));

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