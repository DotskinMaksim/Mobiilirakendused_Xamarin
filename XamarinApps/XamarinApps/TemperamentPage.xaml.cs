using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinApps
{
    public partial class TemperamentPage : CarouselPage
    {
        private string resultsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "results.txt");

        public TemperamentPage()
        {
            InitializeComponent();

            Title = "Temperament";


            Children.Add(CreateTemperamentPage("Koleerik", "Choleric.jpeg", "Koleerik on inimene, kellel on selgelt väljendunud liidriomadused, kõrge energiatase ja kalduvus domineerimisele. Nad teevad sageli kiireid otsuseid ja tegutsevad otsustavalt, mõnikord isegi agressiivselt. Koleerikud ärrituvad kergesti, kuid nende ärrituvus möödub kiiresti. Nad on eesmärgikindlad, ambitsioonikad ja armastavad olukorda kontrollida. Sageli on nad organiseerijad ja juhid."));
            Children.Add(CreateTemperamentPage("Sangviinik", "Sanguine.jpeg", "Sangviinik on rõõmsameelne, seltskondlik ja optimistlik inimene. Nad sõbrunevad kergesti, armastavad suhelda ja olla tähelepanu keskpunktis. Sangviinikud on sageli hea huumorimeelega ja suudavad teiste tuju tõsta. Nad kohanevad kiiresti muutustega ja armastavad uusi kogemusi. Siiski võivad nad olla mõnikord ebapüsivad ja kalduvad pealiskaudsusele."));
            Children.Add(CreateTemperamentPage("Melanhoolik", "Melancholic.jpeg", "Melanhoolik on sügava tundlikkuse ja eneseanalüüsile kalduv inimene. Nad muretsevad sageli pisiasjade pärast, kalduvad depressiivsetele seisunditele ja pessimismile. Melanhoolikud on tavaliselt introverdid, kes eelistavad üksindust või väikest lähedaste inimeste ringi. Nad on vastutustundlikud, detailidele tähelepanu pööravad ja kalduvad perfektsionismile. Melanhoolikutel on rikkalik sisemaailm ja nad võivad olla andekad kunstis ja teaduses."));
            Children.Add(CreateTemperamentPage("Flegmaatik", "Phlegmatic.jpeg", "Flegmaatik on rahulik, tasakaalukas ja kannatlik inimene. Nad näitavad harva oma emotsioone ja eelistavad stabiilsust ja etteaimatavust. Flegmaatikud töötavad sageli aeglaselt, kuid kvaliteetselt, ja ei kiirusta harva. Nad on usaldusväärsed, oma kohustustele truud ja suure töövõimega. Flegmaatikud kohanevad kergesti rutiiniga ja suudavad pikka aega teha ühtlast tööd. Nad hindavad rahu ja harmooniat, väldivad konflikte ja püüavad säilitada head suhted ümbritsevate inimestega."));
        }

        private ContentPage CreateTemperamentPage(string title, string imageSource,  string characteristic)
        {
            var image = new Image { Source = imageSource, HorizontalOptions = LayoutOptions.Center };
            var characteristicLabel = new Label { Text = characteristic, IsVisible = false, TextColor = Color.Black };

            image.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => characteristicLabel.IsVisible = !characteristicLabel.IsVisible)
            });

            var yesButton = new Button
            {
                Text = "Jah",
                BackgroundColor = Color.Green,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center
            };


            var noButton = new Button
            {
                Text = "Ei",
                BackgroundColor = Color.Red,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center
            };
            var statisticsButton = new Button
            {
                Text = "Statistika",
                HorizontalOptions = LayoutOptions.Center
            };
            var buttonLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 20, 0, 0), 
                Children =
                {
                    yesButton,
                    noButton
                }
            };



            yesButton.Clicked += async (sender, e) => await SaveAnswer(title, "Yes", yesButton, noButton);
            noButton.Clicked += async (sender, e) => await SaveAnswer(title, "No", yesButton, noButton);
            statisticsButton.Clicked += async (sender, e) => await DisplayStatistics();

            return new ContentPage
            {
                Content = new StackLayout
                {
                    Padding = new Thickness(20),
                    Children =
                    {
                        new Label { Text = title, FontAttributes = FontAttributes.Bold, FontSize = 24, HorizontalOptions = LayoutOptions.Center },
                        image,
                        characteristicLabel,
                        new Label
                        {
                            Text = "Tehke test",
                            TextColor = Color.Blue,
                            HorizontalOptions = LayoutOptions.Center,
                            GestureRecognizers =
                            {
                                new TapGestureRecognizer
                                {
                                    Command = new Command(async () => await Xamarin.Essentials.Browser.OpenAsync("https://personalitytest.mobi/?lang=en&gad_source=1&gclid=Cj0KCQjwsPCyBhD4ARIsAPaaRf3LMhBSn1VTOAvcDFjaafmq2YButv6NhXSwI7XU9TS6Aq-1MEErLLoaAn_zEALw_wcB"))
                                }
                            }
                        },
                        new Label{
                            Text = $"Kas peate end nimeks {title}?",
                            FontAttributes = FontAttributes.Bold,
                            FontSize = 18,
                            HorizontalOptions = LayoutOptions.Center
                        },
                        buttonLayout,
                        statisticsButton

                    }
                }
            };
        }
        private async Task SaveAnswer(string title, string answer, Button yesButton, Button noButton)
        {
            using (StreamWriter writer = new StreamWriter(resultsFilePath, true))
            {
                await writer.WriteLineAsync($"{title}: {answer}");
            }
            yesButton.IsEnabled = false;
            noButton.IsEnabled = false;
            
        }


        private async Task DisplayStatistics()
        {
            string statistics = await CalculateStatistics();
            await DisplayAlert("Statistika", statistics, "OK");
        }

        private async Task<string> CalculateStatistics()
        {

            string[] lines = await Task.Run(() => File.ReadAllLines(resultsFilePath));
            int cholericYesCount = 0;
            int sanguineYesCount = 0;
            int melancholicYesCount = 0;
            int phlegmaticYesCount = 0;

            int cholericTotalResponses = 0;
            int sanguineTotalResponses = 0;
            int melancholicTotalResponses = 0;
            int phlegmaticTotalResponses = 0;

            foreach (string line in lines)
            {
                if (line.StartsWith("Koleerik"))
                {
                    cholericTotalResponses++;
                    if (line.Contains("Yes"))
                        cholericYesCount++;
                 
                }
                else if (line.StartsWith("Sangviinik"))
                {
                    sanguineTotalResponses++;
                    if (line.Contains("Yes"))
                        sanguineYesCount++;
               
                }
                else if (line.StartsWith("Melanhoolik"))
                {
                    melancholicTotalResponses++;
                    if (line.Contains("Yes"))
                        melancholicYesCount++;
                  
                }
                else if (line.StartsWith("Flegmaatik"))
                {
                    phlegmaticTotalResponses++;
                    if (line.Contains("Yes"))
                        phlegmaticYesCount++;
              
                }
            }
            double cholericYesPercentage = cholericTotalResponses > 0 ? Math.Round((double)cholericYesCount / cholericTotalResponses * 100, 1) : 0;
            double sanguineYesPercentage = sanguineTotalResponses > 0 ? Math.Round((double)sanguineYesCount / sanguineTotalResponses * 100, 1) : 0;
            double melancholicYesPercentage = melancholicTotalResponses > 0 ? Math.Round((double)melancholicYesCount / melancholicTotalResponses * 100, 1) : 0;
            double phlegmaticYesPercentage = phlegmaticTotalResponses > 0 ? Math.Round((double)phlegmaticYesCount / phlegmaticTotalResponses * 100, 1) : 0;




            string statistics = $"{cholericYesPercentage}% peavad end Kaleriteks\n \n" +
                                $"{sanguineYesPercentage}% peavad end Sangviiniteks\n  \n" +
                                $"{melancholicYesPercentage}% peavad end Melanhooliteks\n  \n" +
                                $"{phlegmaticYesPercentage}% peavad end Flegmaatiteks\n \n";

            return statistics;
                
 
        }


    }
}
