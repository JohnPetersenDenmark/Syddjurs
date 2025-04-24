using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;
using Syddjurs.Models;

namespace Syddjurs.Pages;

public partial class ItemPage : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private readonly HttpClient _httpClient;

    private bool _isDropdownVisible = true;
    public bool IsDropdownVisible
    {
        get => _isDropdownVisible;
        set
        {
            if (_isDropdownVisible != value)
            {
                _isDropdownVisible = value;
                OnPropertyChanged(nameof(IsDropdownVisible));
            }
        }
    }

    private ItemCategoryDto _selectedCategory;
    public ItemCategoryDto SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            if (_selectedCategory != value)
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }
    }

    private ObservableCollection<ItemCategoryDto> _categoryList;
    public ObservableCollection<ItemCategoryDto> CategoryList
    {
        get => _categoryList;
        set
        {
            if (_categoryList != value)
            {
                _categoryList = value;
                OnPropertyChanged(nameof(CategoryList));
            }
        }
    }

    private bool _isSexDropdownVisible = true;
    public bool IsSexDropdownVisible
    {
        get => _isSexDropdownVisible;
        set
        {
            if (_isSexDropdownVisible != value)
            {
                _isSexDropdownVisible = value;
                OnPropertyChanged(nameof(IsSexDropdownVisible));
            }
        }
    }
    public List<string> Sex { get; set; } = new()
    {
        "Dame",
        "Herre",
        "Unisex"
    };


    string _selectedSex;
    public string SelectedSex
    {
        get => _selectedSex;
        set
        {
            if (_selectedSex != value)
            {
                _selectedSex = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedSex)));
            }
        }
    }


    public ItemPage()
	{
		InitializeComponent();

        _httpClient = new HttpClient();

        CategoryList = new ObservableCollection<ItemCategoryDto>(); // Initialize the collection
        GetCategoriesAsync();

        BindingContext = this;

        Loaded += OnPageLoaded;
    }

    private void OnPageLoaded(object? sender, EventArgs e)
    {
        IsDropdownVisible = false;
    }

    private void OnCategoryEntryTapped(object sender, EventArgs e)
    {
        IsDropdownVisible = !IsDropdownVisible;
    }

    private void OnSexyEntryTapped(object sender, EventArgs e)
    {
        IsSexDropdownVisible = !IsSexDropdownVisible;
    }

    private async Task GetCategoriesAsync()
    {
        try
        {
            var response = await _httpClient.GetStringAsync("http://10.111.26.121:5213/Home/itemCategories");
           
            var categories = JsonSerializer.Deserialize<List<ItemCategoryDto>>(response);

           
            CategoryList.Clear();
            foreach (var category in categories)
            {               
                CategoryList.Add(category);
            }

            IsDropdownVisible = true;
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., API failure, deserialization issues)
            Console.WriteLine($"Error loading images: {ex.Message}");
        }
    }

    private void OnCategorySelected(object sender, SelectionChangedEventArgs e)
    {

        if (e.CurrentSelection.FirstOrDefault() is ItemCategoryDto selected)
        {
            SelectedCategory = selected;
            IsDropdownVisible = false;           
            CategoryEntryChange.Text = selected.Category;
        }
    }

    private void OnSexSelected(object sender, SelectionChangedEventArgs e)
    {

        if (e.CurrentSelection.FirstOrDefault() is String selected)
        {
            SelectedSex = selected;
            IsSexDropdownVisible = false;
            SexEntryChange.Text = selected;
        }
    }

    //public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}