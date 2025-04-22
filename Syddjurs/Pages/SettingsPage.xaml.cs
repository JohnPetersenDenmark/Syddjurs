using Syddjurs.ViewModels;

namespace Syddjurs.Pages;

public partial class SettingsPage : ContentPage
{
    SettingsViewModel viewModel;

    public SettingsPage()
	{
		InitializeComponent();

        viewModel = new SettingsViewModel();

        this.Loaded += async (s, e) =>
        {
            

            viewModel.HomeStreet = Preferences.Get("HomeStreet", "");
            viewModel.HomeZip = Preferences.Get("HomeZip", "");
            viewModel.HomeCity = Preferences.Get("HomeCity", "");
            viewModel.HomeCountry = Preferences.Get("HomeCountry", "");

            if (Preferences.Get("UseHomeAddress", "") == "Yes")
            {
                homeAddressSwitch.IsToggled = true;
            }
            else
            {
                homeAddressSwitch.IsToggled = false;
            }

            entriesContainer.IsVisible = homeAddressSwitch.IsToggled;
         
            BindingContext = viewModel;
        };
      

        BindingContext = viewModel;
    }

    public void OnToggled(object sender, ToggledEventArgs e)
    {
       if ( e.Value)
            viewModel.UseHomeAddress = "Yes";
       else
        {
            viewModel.UseHomeAddress = "No";
        }

        //SwitchOnColor switchOn = new SwitchOnColor();
        //string colorHexString = switchOn.GetColor();
        //this.homeAddressSwitch.OnColor = Color.FromArgb(colorHexString);

        //SwitchThumbColor thumbhOn = new SwitchThumbColor();
        //colorHexString = thumbhOn.GetColor();
        //this.homeAddressSwitch.ThumbColor = Color.FromArgb(colorHexString);

      

        HideShowAddressFields(e.Value);
    }

    private void HideShowAddressFields(bool show)
    {
        entriesContainer.IsVisible = show;
       
     

    }
}