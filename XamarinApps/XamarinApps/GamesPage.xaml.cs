using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApps.Classes;

namespace XamarinApps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamesPage : TabbedPage
    {
        public GamesPage()
        {
            InitializeComponent();

            Title = "Mängud";


            Dictionary<string, Game[]> categories = new Dictionary<string, Game[]>
            {
                { "Põnevusmängud", new Game[]
                    {
                        new Game { Name = "Grand Theft Auto V", Description = "\"Grand Theft Auto V\" on avatud maailma kriminaalse teema tegevusmäng, kus mängijad saavad uurida Los Santose linna, täites missioone ja osaledes erinevates ebaseaduslikes tegevustes.",
                            ImageSource = "GrandTheftAutoV.jpeg", Link = "https://ru.wikipedia.org/wiki/Grand_Theft_Auto_V", ReleaseDate = "17 September 2013", Developer = "Rockstar North" },
                        new Game { Name = "The Legend of Zelda: Breath of the Wild", Description = "\"The Legend of Zelda: Breath of the Wild\" on seikluslik tegevusmäng, kus mängijad uurivad avatud maailma, lahendavad mõistatusi ja võitlevad vaenlastega, et päästa Hyrule'i kuningriik.",
                            ImageSource = "TheLegendofZelda.jpeg", Link = "https://ru.wikipedia.org/wiki/The_Legend_of_Zelda:_Breath_of_the_Wild", ReleaseDate = "3 March 2017", Developer = "Nintendo" },
                        new Game { Name = "Dark Souls III", Description = "\"Dark Souls III\" on tegevus-RPG, tuntud oma kõrge raskusastme ja sünge atmosfääri poolest. Mängijad võitlevad võimsate vaenlaste ja ülemustega, kogudes samal ajal ressursse ja avastades sügavat narratiivi.",
                            ImageSource = "DarkSoulsIII.jpeg", Link = "https://et.wikipedia.org/wiki/Dark_Souls_III", ReleaseDate = "24 March 2016", Developer = "FromSoftware" }
                    }
                },
                { "RPG mängud", new Game[]
                    {
                        new Game { Name = "The Witcher 3: Wild Hunt", Description = "\"The Witcher 3: Wild Hunt\" on fantaasia RPG, mis pakub sügavat lugu ja avatud maailma. Mängijad võtavad Geralt of Rivia rolli, kes otsib oma adopteeritud tütart, võideldes samal ajal koletiste ja inimeste vastu.",
                            ImageSource = "TheWitcher3.jpeg", Link = "https://et.wikipedia.org/wiki/The_Witcher_3:_Wild_Hunt", ReleaseDate = "19 May 2015", Developer = "CD Projekt Red" },
                        new Game { Name = "Final Fantasy VII Remake", Description = "\"Final Fantasy VII Remake\" on klassikalise Jaapani RPG uusversioon, mis keskendub rikkalikule loole ja keerukale võitlussüsteemile. Mängijad järgivad Cloud Strife'i ja tema kaaslaste seiklusi.",
                            ImageSource = "FinalFantasyVII.jpeg", Link = "https://et.wikipedia.org/wiki/Final_Fantasy_VII_Remake", ReleaseDate = "10 April 2020", Developer = "Square Enix" },
                        new Game { Name = "The Elder Scrolls V: Skyrim", Description = "\"The Elder Scrolls V: Skyrim\" on avatud maailmaga RPG, mis pakub mängijatele vabadust uurida tohutut fantaasiamaailma, täita missioone ja arendada oma tegelast vastavalt oma eelistustele.",
                            ImageSource = "ElderScrollsV.jpeg", Link = "https://et.wikipedia.org/wiki/The_Elder_Scrolls_V:_Skyrim", ReleaseDate = "11 November 2011", Developer = "Bethesda Game Studios" }
                    }
                },
                { "Strateegilised mängud", new Game[]
                    {
                        new Game { Name = "StarCraft II", Description = "\"StarCraft II\" on ulmeline reaalajas strateegiamäng, mis keskendub mitme mängijaga lahingutele. Mängijad valivad ühe kolmest rassist ja juhivad oma vägesid võidu saavutamiseks.",
                            ImageSource = "StarCraftII.jpeg", Link = "https://et.wikipedia.org/wiki/StarCraft_II:_Wings_of_Liberty", ReleaseDate = "27 July 2010", Developer = "Blizzard Entertainment" },
                        new Game { Name = "Civilization VI", Description = "\"Civilization VI\" on käigupõhine strateegiamäng, kus mängijad arendavad oma tsivilisatsiooni läbi erinevate ajastute, tegeledes diplomaatia, sõja ja teadusliku arenguga.",
                            ImageSource = "CivilizationVI.jpeg", Link = "https://et.wikipedia.org/wiki/Civilization_VI", ReleaseDate = "21 October 2016", Developer = "Firaxis Games" },
                        new Game { Name = "Total War: Three Kingdoms", Description = "\"Total War: Three Kingdoms\" on strateegiamäng, mis ühendab käigupõhise strateegia ja reaalajas taktikalised lahingud. Mäng põhineb Hiina ajaloolistel sündmustel ja võimaldab mängijatel juhtida oma kuningriiki.",
                            ImageSource = "TotalWarThreeKingdoms.jpeg", Link = "https://et.wikipedia.org/wiki/Total_War:_Three_Kingdoms", ReleaseDate = "23 May 2019", Developer = "Creative Assembly" }
                    }
                },
                { "Simulatsioonimängud", new Game[]
                    {
                        new Game { Name = "The Sims 4", Description = "\"The Sims 4\" on elusimulaator, kus mängijad juhivad virtuaalseid tegelasi, aidates neil elada oma igapäevaelu, suhelda teistega ja saavutada erinevaid eesmärke.",
                            ImageSource = "TheSims4.jpeg", Link = "https://et.wikipedia.org/wiki/The_Sims_4", ReleaseDate = "2 September 2014", Developer = "Maxis" },
                        new Game { Name = "Flight Simulator 2020", Description = "\"Flight Simulator 2020\" on realistlik lennusimulaator, mis pakub detailset graafikat ja globaalset kaarti. Mängijad saavad lennata erinevate lennukitega ja kogeda lendamist reaalmaailma tingimustes.",
                            ImageSource = "FlightSimulator2020.jpeg", Link = "https://et.wikipedia.org/wiki/Microsoft_Flight_Simulator_(2020_video_game)", ReleaseDate = "18 August 2020", Developer = "Asobo Studio" },
                        new Game { Name = "Stardew Valley", Description = "\"Stardew Valley\" on talusimulaator, mis sisaldab RPG ja sotsiaalse suhtluse elemente. Mängijad hoolitsevad oma talu eest, kasvatavad taimi, hoolitsevad loomade eest ja suhtlevad külainimestega.",
                            ImageSource = "StardewValley.jpeg", Link = "https://et.wikipedia.org/wiki/Stardew_Valley", ReleaseDate = "26 February 2016", Developer = "ConcernedApe" }
                    }
                }
            };

            foreach (var category in categories)
            {
                var categoryPage = new TabbedPage
                {
                    Title = category.Key
                };

                foreach (var game in category.Value)
                {
                    var grid = new Grid
                    {
                        RowDefinitions =
                        {
                            new RowDefinition { Height = GridLength.Auto },
                            new RowDefinition { Height = new GridLength(200) },
                            new RowDefinition { Height = GridLength.Auto },
                            new RowDefinition { Height = GridLength.Auto }
                        }
                    };

                    var descriptionLabel = new Label
                    {
                        Text = game.Description,
                        FontSize = 20,
                        TextColor = Color.Black,
                        HorizontalTextAlignment = TextAlignment.Center,
                        Margin = new Thickness(10)
                    };
                    Grid.SetRow(descriptionLabel, 0);
                    grid.Children.Add(descriptionLabel);

                    var image = new Image
                    {
                        Source = game.ImageSource,
                        HeightRequest = 200,
                        Aspect = Aspect.AspectFit,
                        MinimumHeightRequest = 200
                    };
                    Grid.SetRow(image, 1);
                    grid.Children.Add(image);

                    image.GestureRecognizers.Add(new TapGestureRecognizer
                    {
                        Command = new Command(async () =>
                        {
                            await Launcher.OpenAsync(new Uri(game.Link));
                        })
                    });

                    var releaseDateLabel = new Label
                    {
                        Text = $"Väljalaske kuupäev: {game.ReleaseDate}",
                        FontSize = 16,
                        TextColor = Color.Gray,
                        HorizontalTextAlignment = TextAlignment.Center,
                        Margin = new Thickness(10)
                    };
                    Grid.SetRow(releaseDateLabel, 2);
                    grid.Children.Add(releaseDateLabel);

                    var developerLabel = new Label
                    {
                        Text = $"Arendaja: {game.Developer}",
                        FontSize = 16,
                        TextColor = Color.Gray,
                        HorizontalTextAlignment = TextAlignment.Center,
                        Margin = new Thickness(10)
                    };
                    Grid.SetRow(developerLabel, 3);
                    grid.Children.Add(developerLabel);

                    var scrollView = new ScrollView
                    {
                        Content = grid
                    };

                    var gamePage = new ContentPage
                    {
                        Title = game.Name,
                        Content = scrollView
                    };

                    categoryPage.Children.Add(gamePage);
                }

                Children.Add(categoryPage);
            }
        }
    }
}
