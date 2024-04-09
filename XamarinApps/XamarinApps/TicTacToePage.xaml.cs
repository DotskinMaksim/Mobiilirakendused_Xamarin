using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApps.Classes;

namespace XamarinApps
{
    public partial class TicTacToePage : ContentPage
    {
        Grid grid;
        List<Label> labels = new List<Label>();
        bool playWithBot;

        Player player1;
        Player player2;
        Player lastGonePlayer;
        Player nextGonePlayer;
        string player2Sym;
        Answer answer;

        Button btnBack, btnNewGame;
        StackLayout mainStack;
        public TicTacToePage(bool PlayWithBot, string player1Sym)
        {
            InitializeComponent();
            BackgroundColor = Color.White;

            playWithBot = PlayWithBot;
            player1 = new Player(player1Sym, false);

            player2Sym = (player1Sym == "X") ? "O" : "X";
            player2 = new Player(player2Sym, playWithBot);

            lastGonePlayer = player2;
            nextGonePlayer = player1;

            grid = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var lbl = new Label
                    {
                        Text = "",
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        BackgroundColor = Color.Beige
                    };

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += async (s, e) =>
                    {
                        var tappedLabel = (Label)s;
                        if (string.IsNullOrEmpty(tappedLabel.Text))
                        {
                            tappedLabel.Text = nextGonePlayer.sym;
                            answer = CheckForWin();
                            if (answer.res)
                            {
                                await DisplayAlert("Võit!", $"Mängija {answer.sym} võitis!", "Ok");
                                ReloadGame();
                                return;
                            }

                            if (IsDraw())
                            {
                                await DisplayAlert("Joonista!", "Mäng on joonistatud!", "Ok");
                                ReloadGame();
                                return;
                            }

                            lastGonePlayer = nextGonePlayer;
                            nextGonePlayer = (nextGonePlayer == player1) ? player2 : player1;

                            if (playWithBot && nextGonePlayer.isBot)
                            {
                                await BotMove();
                                answer = CheckForWin();
                                if (answer.res)
                                {
                                    await DisplayAlert("Võit!", "Bot võitis!", "Ok");
                                    ReloadGame();
                                    return;
                                }

                                if (IsDraw())
                                {
                                    await DisplayAlert("Joonista!", "Mäng on joonistatud!", "Ok");
                                    ReloadGame();
                                    return;
                                }
                            }
                        }
                    };

                    lbl.GestureRecognizers.Add(tapGestureRecognizer);
                    labels.Add(lbl);
                    grid.Children.Add(lbl, j, i);
                }
            }

            btnBack = new Button { Text = "Tagasi" };
            btnNewGame = new Button { Text = "Uus mäng" };
            btnNewGame.Clicked += (s, e) => ReloadGame();
            btnBack.Clicked += (s, e) => GoBack();

            var stack = new StackLayout { Orientation = StackOrientation.Horizontal };
            stack.Children.Add(btnNewGame);
            stack.Children.Add(btnBack);

            mainStack = new StackLayout();
            mainStack.Children.Add(grid);
            mainStack.Children.Add(stack);

            Content = mainStack;
        }

        private async void GoBack()
        {
            await Navigation.PushAsync(new ChooseGameModePage());
        }

        private void ReloadGame()
        {
            foreach (var label in labels)
            {
                label.Text = "";
            }
            lastGonePlayer = player2;
            nextGonePlayer = player1;
        }

        private Answer CheckForWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(labels[i * 3].Text) &&
                    labels[i * 3].Text == labels[i * 3 + 1].Text &&
                    labels[i * 3].Text == labels[i * 3 + 2].Text)
                {
                    return new Answer(true, labels[i * 3].Text);
                }

                if (!string.IsNullOrEmpty(labels[i].Text) &&
                    labels[i].Text == labels[i + 3].Text &&
                    labels[i].Text == labels[i + 6].Text)
                {
                    return new Answer(true, labels[i].Text);
                }
            }

            if (!string.IsNullOrEmpty(labels[0].Text) &&
                labels[0].Text == labels[4].Text &&
                labels[0].Text == labels[8].Text)
            {
                return new Answer(true, labels[0].Text);
            }

            if (!string.IsNullOrEmpty(labels[2].Text) &&
                labels[2].Text == labels[4].Text &&
                labels[2].Text == labels[6].Text)
            {
                return new Answer(true, labels[2].Text);
            }

            return new Answer(false, "");
        }

        private bool IsDraw()
        {
            return labels.All(label => !string.IsNullOrEmpty(label.Text));
        }

        private async Task BotMove()
        {
            await Task.Delay(500);

            var emptyCells = labels.Where(label => string.IsNullOrEmpty(label.Text)).ToList();
            if (emptyCells.Any())
            {
                var random = new Random();
                var randomCell = emptyCells[random.Next(emptyCells.Count)];
                randomCell.Text = player2.sym;
                lastGonePlayer = player2;
                nextGonePlayer = player1;
            }
        }
    }
}
