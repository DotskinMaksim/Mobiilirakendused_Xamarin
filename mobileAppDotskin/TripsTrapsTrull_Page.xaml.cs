using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static mobileAppDotskin.TripsTrapsTrull_Page;

namespace mobileAppDotskin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TripsTrapsTrull_Page : ContentPage
    {
<<<<<<< HEAD
=======

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




<<<<<<< HEAD
>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c
=======
>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c
        Grid grid;
        Label lbl;
        List<Label> labels = new List<Label>();
        bool playWithBot;
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======

        Player player1;
        Player player2;

        Player lastGonePlayer;
>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c

        Player player1;
        Player player2;

<<<<<<< HEAD
        Player lastGonePlayer;
>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c

        Player player1;
        Player player2;

<<<<<<< HEAD
        Player lastGonePlayer;
        Player nextGonePlayer;

        string player2Sym;
        Answer answer;

        Button btnBack, btnNewGame;

        StackLayout stack, mainStack;

        public TripsTrapsTrull_Page(bool PlayWithBot, string player1Sym)
        {
            InitializeComponent();

            BackgroundColor = Color.White;

            playWithBot = PlayWithBot;
            player1 = new Player(player1Sym, false);

            if (player1Sym == "X")
            {
                player2Sym = "O";
            }
            else
            {
                player2Sym = "X";
            }

            if (playWithBot) player2 = new Player(player2Sym, true);
            else player2 = new Player(player2Sym, false);

            lastGonePlayer = player2;
            nextGonePlayer = player1;
=======
        public TripsTrapsTrull_Page(bool PlayWithBot)
        {
=======
        public TripsTrapsTrull_Page(bool PlayWithBot)
        {
>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c

            playWithBot = PlayWithBot;

            player1 = new Player("X", false);

            if (playWithBot)  player2 = new Player("O", true); 

            else player2 = new Player("O", false);

            lastGonePlayer = player2;
<<<<<<< HEAD
>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c
=======
>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c


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


                    stack = new StackLayout
                    {
                    };
                    //dfd
                    mainStack = new StackLayout
                    {
                    };

                    btnBack = new Button
                    {
                        Text = "Tagasi"
                    };
                    btnNewGame = new Button
                    {
                        Text = "Uus mäng"
                    };
                    

                    stack.Children.Add(btnNewGame);
                    stack.Children.Add(btnBack);
                

                    


                    labels.Add(lbl);
                    grid.Children.Add(lbl, i, j);

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += async (s, e) =>
                    {
                        var tappedLabel = (Label)s;

                        if (string.IsNullOrEmpty(tappedLabel.Text))
                        {
<<<<<<< HEAD
<<<<<<< HEAD
                            tappedLabel.Text = nextGonePlayer.sym;
                            answer = CheckForWin();
                            if (answer.res == true)
                            {
                                await DisplayAlert("Võit!", $"Mängija {answer.sym} võitis!", "Ok");
=======
=======
>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c
                            // Ход игрока
                            tappedLabel.Text = lastGonePlayer.sym;
                            // Проверяем, выиграл ли игрок
                            if (CheckForWin())
                            {
                                await DisplayAlert("Победа", $"Игрок {lastGonePlayer.sym} выиграл!", "OK");
<<<<<<< HEAD
>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c
=======
>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c
                                reloadGame();
                                return;
                            }

<<<<<<< HEAD
<<<<<<< HEAD
                            if (labels.Any(label => string.IsNullOrEmpty(label.Text)))
                            {

                                if (player2.isBot)
                                {
                                    await BotMove();
                                   
                                }

                                answer = CheckForWin();
                                if (answer.res==true )
                                {
                                    if (player2.isBot)
                                        await DisplayAlert("Võit!", "Bot võitis!", "Ok");
                                    else
                                        await DisplayAlert("Võit!", $"Mängija {answer.sym} võitis!", "Ok");

                                    reloadGame();
                                    return;
                                }
                                lastGonePlayer = (lastGonePlayer == player1) ? player2 : player1;
                                nextGonePlayer = (nextGonePlayer == player1) ? player2 : player1;
                            }
                            else
                            {
                                await DisplayAlert("Joonista", "Mängus joonista!", "Ok");
                                reloadGame();
=======
=======
>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c

                            if (labels.Any(label => string.IsNullOrEmpty(label.Text)))
                            {
                                // Ход бота
                                
                                if (player2.isBot)
                                {
                                    await BotMove();
                                }
                                else
                                {                   
                                    lastGonePlayer.sym = (lastGonePlayer.sym == "X") ? "O" : "X";
                                }

                                // Проверяем, выиграл ли бот
                                if (CheckForWin())
                                {
                                    await DisplayAlert("Победа", "Бот выиграл!", "OK");
                                    reloadGame();

                                    return;
                                }
                            }
                            else
                            {
                                await DisplayAlert("Ничья", "Игра окончена вничью!", "OK");
                                reloadGame();

<<<<<<< HEAD
>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c
=======
>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c
                                return;
                            }
                        }


                    };
                    lbl.GestureRecognizers.Add(tapGestureRecognizer);

                    mainStack.Children.Add(grid);
                    mainStack.Children.Add(stack);

                }
            }
            

            Content = mainStack;
        }

        private void reloadGame()
        {
            foreach (var label in labels)
            {
                label.Text = "";
            }
            lastGonePlayer = player2; 
        }

        private Answer CheckForWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (labels[i * 3].Text == labels[i * 3 + 1].Text && labels[i * 3].Text == labels[i * 3 + 2].Text && !string.IsNullOrEmpty(labels[i * 3].Text))
                {
                    answer = new Answer(true, labels[i * 3].Text);
                    return answer;
                }
            }
<<<<<<< HEAD

            for (int i = 0; i < 3; i++)
            {
                if (labels[i].Text == labels[i + 3].Text && labels[i].Text == labels[i + 6].Text && !string.IsNullOrEmpty(labels[i].Text))
                {
                    answer = new Answer(true, labels[i].Text);
                    return answer;
                }
            }
<<<<<<< HEAD

            if (labels[0].Text == labels[4].Text && labels[0].Text == labels[8].Text && !string.IsNullOrEmpty(labels[0].Text))
            {
                answer = new Answer(true, labels[0].Text);
                return answer;
            }
            if (labels[2].Text == labels[4].Text && labels[2].Text == labels[6].Text && !string.IsNullOrEmpty(labels[2].Text))
            {
                answer = new Answer(true, labels[2].Text);
                return answer;
            }

            answer = new Answer(false, "");
            return answer;
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
                lastGonePlayer = (lastGonePlayer == player1) ? player2 : player1;
                nextGonePlayer = (nextGonePlayer == player1) ? player2 : player1;
            }
        }
        public class Answer
        {
            public bool res;
            public string sym;
            public Answer(bool Res, string Sym) { 
                res= Res;
                sym = Sym;
            }
        }

=======
            
            Content = grid;
           
        }


        private void reloadGame()
        {
            foreach (var label in labels)
            {
                label.Text = "";
            }

            // Вернуть последнего игрока (первого или второго) в качестве текущего игрока
            lastGonePlayer = player2;
        }
=======
            
            Content = grid;
           
        }


        private void reloadGame()
        {
            foreach (var label in labels)
            {
                label.Text = "";
            }

            // Вернуть последнего игрока (первого или второго) в качестве текущего игрока
            lastGonePlayer = player2;
        }
>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c
        private bool CheckForWin()
        {
          
            for (int i = 0; i < 3; i++)
            {
                if (labels[i * 3].Text == labels[i * 3 + 1].Text &&
                    labels[i * 3].Text == labels[i * 3 + 2].Text &&
                    !string.IsNullOrEmpty(labels[i * 3].Text))
                {
                    return true;
                }
            }

           
            for (int i = 0; i < 3; i++)
            {
                if (labels[i].Text == labels[i + 3].Text &&
                    labels[i].Text == labels[i + 6].Text &&
                    !string.IsNullOrEmpty(labels[i].Text))
                {
                    return true;
                }
            }

        
            if (labels[0].Text == labels[4].Text && labels[0].Text == labels[8].Text && !string.IsNullOrEmpty(labels[0].Text))
            {
                return true;
            }
            if (labels[2].Text == labels[4].Text && labels[2].Text == labels[6].Text && !string.IsNullOrEmpty(labels[2].Text))
            {
                return true;
            }

            return false;
        }
        private async Task BotMove()
        {
            await Task.Delay(500); // Для имитации задержки, чтобы было видно ход бота

            var emptyCells = labels.Where(label => string.IsNullOrEmpty(label.Text)).ToList();
            if (emptyCells.Any())
            {
                var random = new Random();
                var randomCell = emptyCells[random.Next(emptyCells.Count)];
                var botSymbol = (lastGonePlayer.sym == "X") ? "O" : "X";
                randomCell.Text = botSymbol; // Ход бота в случайную пустую клетку
                lastGonePlayer.sym = botSymbol; // Изменение текущего игрока
            }
        }





<<<<<<< HEAD
>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c
=======
>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c
    }
}
