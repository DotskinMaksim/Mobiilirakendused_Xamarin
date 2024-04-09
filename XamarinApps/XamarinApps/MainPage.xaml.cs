using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinApps.Classes;

namespace XamarinApps
{
    public partial class MainPage : ContentPage
    {
        Label theoryLbl;
        Label exercisesLbl;

        Dictionary<string, MenuPage[]> categories = new Dictionary<string, MenuPage[]>
        {
            { "Theory", new MenuPage[]
                {
                    new MenuPage { Name="Taimer", Page= new TimerPage() },
                    new MenuPage { Name="BoxView", Page= new BoxViewPage() },
                    new MenuPage { Name="Entry", Page= new EntryPage() },
                    new MenuPage { Name="DateTime", Page= new DateTimePage() },
                    new MenuPage { Name="Frame", Page= new FramePage() },
                    new MenuPage { Name="Table", Page= new TablePage() },
                    new MenuPage { Name="ListView", Page= new ListViewPage() },
                    new MenuPage { Name="Stepper ja slider", Page= new StepperSliderPage() },
                    new MenuPage { Name="Image ja switch", Page= new ImagePage() },
                }
            },
            { "Tasks", new MenuPage[]
                {
                    new MenuPage { Name="Lumememm", Page= new SnowmanPage() },
                    new MenuPage { Name="Brauser", Page= new BrowserPage() },
                    new MenuPage { Name="Trips-Traps-Trull", Page= new ChooseGameModePage() },
                    new MenuPage { Name="RGB mudel", Page= new RGBModelPage() },
                    new MenuPage { Name="Pühade tervitused", Page= new HolidaysGreetingPage() },
                    new MenuPage { Name="Euroopa riigid", Page= new CountriesPage() },
                    new MenuPage { Name="Temperament", Page= new TemperamentPage() },
                    new MenuPage { Name="Mängud", Page= new GamesPage() }
                }
            }
        };

        public MainPage()
        {
            InitializeComponent();

            Title = "Menüü";

            theoryLbl = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = "Teooria",
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            exercisesLbl = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = "Ülesandeid",
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            StackLayout stackLayout = new StackLayout();
            stackLayout.Children.Add(theoryLbl);

            foreach (var category in categories)
            {
                if (category.Key == "Theory")
                {
                    stackLayout.Children.Add(theoryLbl);
                }
                else
                {
                    stackLayout.Children.Add(exercisesLbl);
                }

                foreach (var page in category.Value)
                {
                    Button button = new Button
                    {
                        Text = page.Name,
                        BackgroundColor = Color.FromHex("#52"),
                        TextColor = Color.Black,
                        CommandParameter = page.Page
                    };
                    button.Clicked += Button_Clicked;
                    stackLayout.Children.Add(button);
                }
            }

            ScrollView scrollView = new ScrollView { Content = stackLayout };
            Content = scrollView;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Page pageToNavigate = (Page)btn.CommandParameter;
            if (pageToNavigate != null)
            {
                await Navigation.PushAsync(pageToNavigate);
            }
        }
    }
}
