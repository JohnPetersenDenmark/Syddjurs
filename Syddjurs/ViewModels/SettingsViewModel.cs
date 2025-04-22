
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Syddjurs.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
       

        private string? _UseHomeAddress;
        private string? _HomeStreet;
        private string? _HomeZip;
        private string? _HomeCity;
        private string? _HomeCountry;

        public string? UseHomeAddress
        {
            get => _UseHomeAddress;

            set
            {
                Preferences.Set("UseHomeAddress", value);                              
            }

        }

        public string? HomeStreet
        {
            get => _HomeStreet;

            set
            {
                _HomeStreet = value;
                Preferences.Set("HomeStreet",value);
            }

        }

        public string? HomeZip
        {
            get => _HomeZip;

            set
            {
                _HomeZip = value;
                Preferences.Set("HomeZip", value);
            }

        }

        public string? HomeCity
        {
            get => _HomeCity;

            set
            {
                _HomeCity = value;
                Preferences.Set("HomeCity", value);
            }

        }

        public string? HomeCountry
        {
            get => _HomeCountry;

            set
            {
                _HomeCountry = value;
                Preferences.Set("HomeCountry", value);
            }

        }


        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
