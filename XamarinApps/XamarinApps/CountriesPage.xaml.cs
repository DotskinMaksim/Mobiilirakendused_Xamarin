using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinApps.Classes;

namespace XamarinApps
{
    public partial class CountriesPage : ContentPage
    {
        public ObservableCollection<Country> Countries { get; set; }
        public ObservableCollection<Group<string, Country>> CountriesGrouped { get; set; }
        ListView list;
        Button add, delete;
        Country selectedCountry;
        Switch sw;

        public CountriesPage()
        {
            InitializeComponent();

            Title = "Euroopa riigid";


            add = new Button { Text = "Lisa riik" };
            delete = new Button { Text = "Kustuta riik" };

            Countries = new ObservableCollection<Country>
            {
                new Country { Name = "Prantsusmaa",Region = "Lääne-Euroopa", Capital="Paris", Population = 67000000, Flag = ImageSource.FromFile("France.png") },
                new Country { Name = "Saksamaa", Region = "Lääne-Euroopa",Capital="Berlin", Population = 83000000, Flag = ImageSource.FromFile("Germany.png") },
                new Country { Name = "Hispaania", Region = "Lõuna-Euroopa", Capital="Madrid", Population = 47000000, Flag = ImageSource.FromFile("Spain.png") },
                new Country { Name = "Itaalia",Region = "Lõuna-Euroopa", Capital="Rome",Population = 60000000, Flag = ImageSource.FromFile("Italy.png") }
            };

            UpdateGroupedCountries();

            

            list = new ListView
            {
                SeparatorColor = Color.Orange,
                Footer = DateTime.Now.ToString("T"),
                HasUnevenRows = true,
                ItemsSource = CountriesGrouped,
                IsGroupingEnabled = true,
                GroupHeaderTemplate = new DataTemplate(() =>
                {
                    Label regionLabel = new Label
                    {
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Color.Black,
                        VerticalOptions = LayoutOptions.Center
                    };
                    regionLabel.SetBinding(Label.TextProperty, "Name");

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(10, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children = { regionLabel }
                        }
                    };
                }),
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell
                    {
                        TextColor = Color.Black,
                        DetailColor = Color.Gray
                    };
                    imageCell.SetBinding(ImageCell.TextProperty, "Name");
                    Binding populationBinding = new Binding
                    {
                        Path = "Population",
                        StringFormat = "Rahvaarv: {0:N0}"
                    };
                    imageCell.SetBinding(ImageCell.DetailProperty, populationBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Flag");
                    return imageCell;
                })
            };
            sw = new Switch
            {
                IsToggled = false,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };


            var switchLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Children = { new Label { Text = "Värskendada riigi andmeid?", VerticalOptions = LayoutOptions.Center }, sw }
            };


            list.ItemTapped += List_ItemTapped;
            add.Clicked += Add_Clicked;
            delete.Clicked += Delete_Clicked;
            sw.Toggled += Sw_Toggled;



            this.Content = new StackLayout { Children = {list, add, delete , switchLayout} };
        }

        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                list.ItemTapped -= List_ItemTapped;
                list.ItemTapped += List_ItemTappedForUpdate;
            }
            else
            {
                list.ItemTapped -= List_ItemTappedForUpdate;
                list.ItemTapped += List_ItemTapped;
            }
        }
        private void UpdateGroupedCountries()
        {
            var groupedCountries = Countries.GroupBy(c => c.Region)
                                            .Select(g => new Group<string, Country>(g.Key, g));
            CountriesGrouped = new ObservableCollection<Group<string, Country>>(groupedCountries);
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            if (selectedCountry != null)
            {
                Countries.Remove(selectedCountry);
                UpdateGroupedCountries();
                list.ItemsSource = null;
                list.ItemsSource = CountriesGrouped;
                selectedCountry = null;
            }
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            string name = await DisplayPromptAsync("Sisestage riigi nimetus", "Name:");
            string region = await DisplayPromptAsync("Sisestage piirkondad", "Piirkond:");
            string capital = await DisplayPromptAsync("Sisestage pealinn", "Pealinn:");
            string populationStr = await DisplayPromptAsync("Sisestage rahvaarv", "Rahvaarv:", keyboard: Keyboard.Numeric);
            if (int.TryParse(populationStr, out int population) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(region) && !string.IsNullOrEmpty(capital))
            {


                var photo = await MediaPicker.PickPhotoAsync();
                if (photo != null)
                {
                    ImageSource flag = ImageSource.FromFile(photo.FullPath);
                    if (Countries.Any(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                    {
                        await DisplayAlert("Viga", "Siin on juba seda riik", "OK");
                    }
                    else
                    {
                        Countries.Add(new Country { Name = name, Region = region, Capital=capital,Population = population, Flag = flag });
                    }
                    UpdateGroupedCountries();
                    list.ItemsSource = null;
                    list.ItemsSource = CountriesGrouped;
                }
            }
                
  
       
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {


            selectedCountry = e.Item as Country;
            if (selectedCountry != null)
            {
                await DisplayAlert("Riigi üksikasjad", $"{selectedCountry.Name} | {selectedCountry.Region} | Rahvaarv: {selectedCountry.Population:N0} | Pealinn: {selectedCountry.Capital}", "Ok");
            }
        }
        private async void List_ItemTappedForUpdate(object sender, ItemTappedEventArgs e)
        {
            selectedCountry = e.Item as Country;
            if (selectedCountry != null)
            {
                string newName = await DisplayPromptAsync("Muuda riigi nimetus", "Name:", initialValue: selectedCountry.Name);
                string newRegion = await DisplayPromptAsync("Muuda piirkond", "Region:", initialValue: selectedCountry.Region);
                string newCapital = await DisplayPromptAsync("Muuda pealinn", "Pealinn:", initialValue: selectedCountry.Capital);
                string newPopulationStr = await DisplayPromptAsync("Muuda rahvaarv", "Population:", initialValue: selectedCountry.Population.ToString(), keyboard: Keyboard.Numeric);

                if (int.TryParse(newPopulationStr, out int newPopulation) && !string.IsNullOrEmpty(newName) && !string.IsNullOrEmpty(newRegion) && !string.IsNullOrEmpty(newCapital))
                {
                    selectedCountry.Name = newName;
                    selectedCountry.Region = newRegion;
                    selectedCountry.Population = newPopulation;
                    selectedCountry.Capital = newCapital;

                    UpdateGroupedCountries();
                    list.ItemsSource = null;
                    list.ItemsSource = CountriesGrouped;

                    await DisplayAlert("Info", "Riigi andmeid on värskendatud", "OK");
                }
                
            }
        }

    }
}
