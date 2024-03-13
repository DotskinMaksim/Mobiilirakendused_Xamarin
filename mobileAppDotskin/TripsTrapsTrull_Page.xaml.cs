using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobileAppDotskin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TripsTrapsTrull_Page : ContentPage
    {

        //List<Label> tapped = new List<Label>();
        //List<Label> untapped = new List<Label>();
        //List<Label> untappedClone;
        //int counter = 0;
        //int gamescounter = 0;
        //Grid grid;
        //Button btnbot, btnonline, rndbackgorund;
        //int gmmode = 0;
        //Random rnd;
        //Label lblinfo, whichturnlbl, howmanygames;



        Grid grid;
        Random rnd;
        Label lbl;
        Button btn;
        List<Label> labels = new List<Label>();


        public TripsTrapsTrull_Page()
        {
            grid = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    lbl = new Label
                    {
                        Text = "",
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        BackgroundColor = Color.Beige
                    };
                    labels.Add(lbl); // Добавляем метку в список
                    grid.Children.Add(lbl, i, j);

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (s, e) =>
                    {
                        var tappedLabel = (Label)s;
                        if (string.IsNullOrEmpty(tappedLabel.Text))
                        {
                            // Если текст пустой, изменяем его на "X"
                            tappedLabel.Text = "X";
                        }
                        else if (tappedLabel.Text == "X")
                        {
                            // Если текст "X", изменяем его на "O"
                            tappedLabel.Text = "O";
                        }
                        else
                        {
                            // Если текст "O", изменяем его на пустоту
                            tappedLabel.Text = "";
                        }
                    };
                    lbl.GestureRecognizers.Add(tapGestureRecognizer);
                }
            }

            btn = new Button
            {
                Text = "mängida"
            };

            grid.Children.Add(btn, 0, 4); // Добавляем кнопку в сетку с индексами столбца и строки
            btn.Clicked += Btn_Clicked;

            Content = grid;
        }


        private void Btn_Clicked(object sender, EventArgs e)
        {
            labels[0].Text = "X";
        }
    }


}



        //grid = new Grid
        //    {
        //        BackgroundColor = Color.FromRgb(12, 123, 123),
        //        HorizontalOptions = LayoutOptions.FillAndExpand,
        //        VerticalOptions = LayoutOptions.FillAndExpand,
        //    };
        //TapGestureRecognizer tap = new TapGestureRecognizer();
        //tap.NumberOfTapsRequired = 1;
        //tap.Tapped += Tap_Tapped1;
        //for (int i = 0; i < 3; i++)
        //{
        //    for (int ii = 0; ii < 3; ii++)
        //    {
        //        Label label = new Label
        //        {
        //            HorizontalOptions = LayoutOptions.FillAndExpand,
        //            VerticalOptions = LayoutOptions.FillAndExpand,
        //            Text = " ",
        //            FontSize = 50,
        //            BackgroundColor = Color.White,
        //            TextColor = Color.Black,

        //            HorizontalTextAlignment = TextAlignment.Center

        //        };
        //        untapped.Add(label);
        //        label.GestureRecognizers.Add(tap);
        //        grid.Children.Add(label, i, ii);
        //    }
        //}
        //    untappedClone = new List<Label>(untapped);
        //    lblinfo = new Label
        //    {
        //        Text = "Mängija vs mängija",
        //        TextColor = Color.Black,
        //        FontFamily = "Bold, Lobster-Regular",
        //        HorizontalTextAlignment = TextAlignment.Center,
        //        FontSize = 18
        //    };
        //    whichturnlbl = new Label
        //    {
        //        TextColor = Color.Black,
        //        FontFamily = "Bold, Lobster-Regular",
        //        HorizontalTextAlignment = TextAlignment.Center,
        //        FontSize = 18
        //    };
        //    btnbot = new Button
        //    {
        //        Text = "Mängi vs bot"
        //    };
        //    btnonline = new Button
        //    {
        //        Text = "Mängi vs mängija"
        //    };
        //    rndbackgorund = new Button
        //    {
        //        Text = "Määra juhuslik värv"
        //    };
        //    howmanygames = new Label
        //    {
        //        Text = $"Sa mängisid {gamescounter} mänge",
        //        TextColor = Color.Black,
        //        FontFamily = "Bold, Lobster-Regular",
        //        HorizontalTextAlignment = TextAlignment.Center,
        //        FontSize = 18
        //    };
        //    btnbot.Clicked += Btnbot_Clicked;
        //    btnonline.Clicked += Btnonline_Clicked;
        //    rndbackgorund.Clicked += Rndbackgorund_Clicked;
        //    grid.Children.Add(lblinfo, 1, 4);
        //    grid.Children.Add(whichturnlbl, 0, 4);
        //    grid.Children.Add(howmanygames, 2, 4);
        //    grid.Children.Add(btnonline, 0, 5);
        //    grid.Children.Add(btnbot, 1, 5);
        //    grid.Children.Add(rndbackgorund, 2, 5);
        //    Content = grid;
        //}


        //private void Rndbackgorund_Clicked(object sender, EventArgs e)
        //{
        //    rnd = new Random();
        //    int ar = rnd.Next(0, 255);
        //    int ag = rnd.Next(0, 255);
        //    int ab = rnd.Next(0, 255);
        //    grid.BackgroundColor = Color.FromRgb(ar, ag, ab);
        //}


        //private void Whichcturn()
        //{
        //    if (counter % 2 == 0)
        //    {
        //        whichturnlbl.Text = "Nüüd " + "X " + " pöörake";
        //    }
        //    else
        //    {
        //        whichturnlbl.Text = "Nüüd " + "0" + " pöörake";
        //    }
        //}
        //private void Btnonline_Clicked(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        for (int ii = 0; ii < 3; ii++)
        //        {
        //            GetLabel(i, ii).Text = " ";
        //        }
        //    }
        //    gmmode = 0;
        //    counter = 0;
        //    gamescounter++;
        //    lblinfo.Text = "Mängija vs Mängija ";
        //    whichturnlbl.Text = "Nüüd X omakorda";
        //    untapped = new List<Label>(untappedClone);
        //    howmanygames.Text = $"Sa mängisid {gamescounter} mänge";
        //}

        //private void Btnbot_Clicked(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        for (int ii = 0; ii < 3; ii++)
        //        {
        //            GetLabel(i, ii).Text = " ";
        //        }
        //    }
        //    gmmode = 1;
        //    counter = 0;
        //    gamescounter++;
        //    lblinfo.Text = "Mängija vs bot ";
        //    whichturnlbl.Text = "Nüüd X omakorda";
        //    untapped = new List<Label>(untappedClone);
        //    howmanygames.Text = $"Sa mängisid {gamescounter} mänge";
        //}

        //private void Tap_Tapped1(object sender, EventArgs e)
        //{
        //    rnd = new Random();
        //    Label fr = (Label)sender;
        //    int r = Grid.GetRow(fr); int c = Grid.GetColumn(fr);
        //    if (gmmode == 0)
        //    {
        //        if (counter % 2 == 0)
        //        {
        //            if (fr.Text == " ")
        //            {
        //                fr.Text = "X";
        //                counter++;
        //                tapped.Add(fr);
        //                untapped.Remove(fr);
        //            }
        //        }
        //        else
        //        {
        //            if (fr.Text == " ")
        //            {
        //                fr.Text = "O";
        //                counter++;
        //                tapped.Add(fr);
        //                untapped.Remove(fr);
        //            }
        //        }
        //    }
        //    if (gmmode == 1)
        //    {
        //        if (counter % 2 == 0)
        //        {
        //            if (fr.Text == " ")
        //            {
        //                fr.Text = "X";
        //                counter++;
        //                tapped.Add(fr);
        //                untapped.Remove(fr);
        //            }
        //            Botstep();
        //        }
        //    }
        //    Whichcturn();
        //    Checkwin();
        //}

        //private void Checkwin()
        //{
        //    foreach (var winCondition in Winconditions())
        //    {
        //        bool xWins = true;
        //        bool oWins = true;
        //        foreach (var label in winCondition)
        //        {
        //            if (label.Text != "X")
        //                xWins = false;
        //            if (label.Text != "O")
        //                oWins = false;
        //        }

        //        if (xWins)
        //        {
        //            DisplayAlert("X Võidab", "Kui soovite mängu taaskäivitamist, klõpsake mis tahes nupule", "OK");
        //            break;
        //        }
        //        if (oWins)
        //        {
        //            DisplayAlert("O Võidab", "Kui soovite mängu taaskäivitamist, klõpsake mis tahes nupule", "OK");
        //            break;
        //        }
        //        if (counter == 9)
        //        {
        //            DisplayAlert("Viik", "Kui soovite mängu taaskäivitamist, klõpsake mis tahes nupule", "OK");
        //            break;
        //        }

        //    }
        //}

        //private List<List<Label>> Winconditions()
        //{
        //    List<List<Label>> winConditions = new List<List<Label>>();


        //    winConditions.Add(new List<Label> { GetLabel(0, 0), GetLabel(1, 0), GetLabel(2, 0) });
        //    winConditions.Add(new List<Label> { GetLabel(0, 1), GetLabel(1, 1), GetLabel(2, 1) });
        //    winConditions.Add(new List<Label> { GetLabel(0, 2), GetLabel(1, 2), GetLabel(2, 2) });


        //    winConditions.Add(new List<Label> { GetLabel(0, 0), GetLabel(0, 1), GetLabel(0, 2) });
        //    winConditions.Add(new List<Label> { GetLabel(1, 0), GetLabel(1, 1), GetLabel(1, 2) });
        //    winConditions.Add(new List<Label> { GetLabel(2, 0), GetLabel(2, 1), GetLabel(2, 2) });

        //    winConditions.Add(new List<Label> { GetLabel(0, 0), GetLabel(1, 1), GetLabel(2, 2) });
        //    winConditions.Add(new List<Label> { GetLabel(0, 2), GetLabel(1, 1), GetLabel(2, 0) });

        //    return winConditions;
        //}

        //private Label GetLabel(int row, int column)
        //{
        //    foreach (var child in grid.Children)
        //    {
        //        if (Grid.GetRow(child) == row && Grid.GetColumn(child) == column)
        //            return (Label)child;
        //    }
        //    return null;
        //}
        //private void Botstep()
        //{
        //    rnd = new Random();
        //    int rndint = untapped.Count + 1;
        //    int rnd_element = rnd.Next(rndint);
        //    Label label = untapped[rnd_element];
        //    label.Text = "O";
        //    counter++;
        //    tapped.Add(untapped[rnd_element]);
        //    untapped.Remove(untapped[rnd_element]);

