using System.Collections.ObjectModel;
using System.ComponentModel;
using Syddjurs.Models;

namespace Syddjurs.Pages;

public partial class ItemListPage : ContentPage, INotifyPropertyChanged
{

    private readonly HttpClient _httpClient;
    public ObservableCollection<ItemInListDto> Items { get; set; }

    private ItemInListDto _selectedItem;

    public ItemInListDto SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            // OnPropertyChanged(nameof(SelectedStamp));           
        }
    }
    public ItemListPage()
	{
		InitializeComponent();

        _httpClient = new HttpClient();
        Items = new ObservableCollection<ItemInListDto>(); // Initialize the collection

        BindingContext = this;
    }

    private void OnItemSelected(object sender, SelectionChangedEventArgs e)
    {

        SelectedItem = e.CurrentSelection.FirstOrDefault() as ItemInListDto;

        var copyOfItems = new List<ItemInListDto>();
        foreach (var stamp in Items)
        {
            if (stamp.Equals(SelectedItem))
            {
                stamp.IsSelected = true;
            //    //stamp.SelectedColor = Color.FromArgb(AddressListViewSelectedItemColorHex);
            //    stamp.SelectedBackgroundColor = _selectedCollectionViewItemBackgroundColor;
            //    stamp.SelectedLabelTextColor = _selectedLabelTextColor;
            }
            else
            {
            /   stamp.IsSelected = false;
            //    stamp.SelectedBackgroundColor = _unSelectedCollectionViewItemBackgroundColor;
            //    stamp.SelectedLabelTextColor = _unSelectedLabelTextColor;
            }

        }
    }
}