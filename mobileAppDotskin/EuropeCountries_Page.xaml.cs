using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobileAppDotskin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EuropeCountries_Page : ContentPage
    {
        public ObservableCollection<Country> Countries { get; set; }
        public ObservableCollection<Group<string, Country>> countriesGrouped { get; set; }
        Label lbl_list;
        ListView list;
        Button add, delete;
        Country selectedCountry;

        public EuropeCountries_Page()
        {
            add = new Button { Text = "Add Country" };
            delete = new Button { Text = "Delete Country" };

            Countries = new ObservableCollection<Country>
            {
                new Country { Name = "France", Region = "Western Europe", Population = 67000000, Flag = ImageSource.FromResource("France.png") },
                new Country { Name = "Germany", Region = "Western Europe", Population = 83000000, Flag = ImageSource.FromResource("Germany.jpg") },
                new Country { Name = "Spain", Region = "Southern Europe", Population = 47000000, Flag = ImageSource.FromResource("Spain.jpg") },
                new Country { Name = "Italy", Region = "Southern Europe", Population = 60000000, Flag = ImageSource.FromResource("Italy.jpg") }
            };

            var groupedCountries = Countries.GroupBy(c => c.Region)
                                             .Select(g => new Group<string, Country>(g.Key, g));
            countriesGrouped = new ObservableCollection<Group<string, Country>>(groupedCountries);

            lbl_list = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = "List of European Countries",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            list = new ListView
            {
                SeparatorColor = Color.Orange,
                Header = "Countries grouped by region",
                Footer = DateTime.Now.ToString("T"),
                HasUnevenRows = true,
                ItemsSource = countriesGrouped,
                IsGroupingEnabled = true,
                GroupHeaderTemplate = new DataTemplate(() =>
                {
                    Label region = new Label();
                    region.SetBinding(Label.TextProperty, "Key");
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Vertical,
                            Children = { region }
                        }
                    };
                }),
                ItemTemplate = new DataTemplate(() =>
                {
                    Image img = new Image
                    {
                        WidthRequest = 100,
                        HeightRequest = 100
                    };
                    img.SetBinding(Image.SourceProperty, "Flag");

                    Label name = new Label { FontSize = 20 };
                    name.SetBinding(Label.TextProperty, "Name");

                    Label population = new Label();
                    population.SetBinding(Label.TextProperty, "Population");

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children = { img, name, population }
                        }
                    };
                })
            };

            list.ItemTapped += List_ItemTapped;
            add.Clicked += Add_Clicked;
            delete.Clicked += Delete_Clicked;

            this.Content = new StackLayout { Children = { lbl_list, list, add, delete } };
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            Countries.Remove(selectedCountry);
            var groupedCountries = Countries.GroupBy(c => c.Region)
                                             .Select(g => new Group<string, Country>(g.Key, g));
            countriesGrouped = new ObservableCollection<Group<string, Country>>(groupedCountries);
            list.ItemsSource = null;
            list.ItemsSource = countriesGrouped;
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            string name = await DisplayPromptAsync("Enter Country Name", "Name:");
            string region = await DisplayPromptAsync("Enter Region", "Region:");
            string populationStr = await DisplayPromptAsync("Enter Population", "Population:");
            if (int.TryParse(populationStr, out int population) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(region))
            {
                try
                {
                    var photo = await MediaPicker.PickPhotoAsync();
                    ImageSource flag = ImageSource.FromFile(photo.FullPath);
                    Countries.Add(new Country { Name = name, Region = region, Population = population, Flag = flag });
                    var groupedCountries = Countries.GroupBy(c => c.Region)
                                                     .Select(g => new Group<string, Country>(g.Key, g));
                    countriesGrouped = new ObservableCollection<Group<string, Country>>(groupedCountries);
                    list.ItemsSource = null;
                    list.ItemsSource = countriesGrouped;
                }
                catch (Exception)
                {
                }
            }
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            selectedCountry = e.Item as Country;
            if (selectedCountry != null)
            {
                await DisplayAlert("Country Details", $"{selectedCountry.Name} | {selectedCountry.Region} - Population: {selectedCountry.Population}", "Ok");
            }
        }
    }




}
