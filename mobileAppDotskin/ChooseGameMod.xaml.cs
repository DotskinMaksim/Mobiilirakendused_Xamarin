using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobileAppDotskin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseGameMod : ContentPage
    {
<<<<<<< HEAD
        private string selectedSymbol;
=======
>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c

        public ChooseGameMod()
        {
            Button playWithBotButton = new Button
            {
                Text = "Mängida bottiga",
                BackgroundColor = Color.Gray
            };

            Button playWithPlayerButton = new Button
            {
                Text = "Mängida 2 mängijaga",
                BackgroundColor = Color.Gray
            };
<<<<<<< HEAD

            RadioButton radioX = new RadioButton
            {
                GroupName = "gameSym",
                Content = "X"
            };
            radioX.CheckedChanged += (sender, e) => { if (e.Value) selectedSymbol = "X"; };

            RadioButton radioO = new RadioButton
            {
                GroupName = "gameSym",
                Content = "O"
            };
            radioO.CheckedChanged += (sender, e) => { if (e.Value) selectedSymbol = "O"; };

            StackLayout st = new StackLayout
            {
                Children = { playWithBotButton, playWithPlayerButton, radioO, radioX }
            };
            Content = st;
            playWithPlayerButton.Clicked += playWithPlayerButtonClicked;
            playWithBotButton.Clicked += playWithBotButtonClicked;
        }

        private async void playWithBotButtonClicked(object sender, EventArgs e)
        {
            if (selectedSymbol != null)
                await Navigation.PushAsync(new TripsTrapsTrull_Page(true, selectedSymbol));
            else
                await DisplayAlert("Viga", "Palun valige sümbol", "Ok");
        }

        private async void playWithPlayerButtonClicked(object sender, EventArgs e)
        {
            if (selectedSymbol != null)
                await Navigation.PushAsync(new TripsTrapsTrull_Page(false, selectedSymbol));
            else
                await DisplayAlert("Viga", "Palun valige sümbol", "Ok");
        }
    }
}
=======
            StackLayout st = new StackLayout
            {
                Children = { playWithBotButton,playWithPlayerButton }
            };
            Content=st;
            playWithPlayerButton.Clicked += playWithPlayerButtonClicked;
            playWithBotButton.Clicked += playWithBotButtonClicked;

        }
        private async void playWithBotButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TripsTrapsTrull_Page(true));

        }
        private async void playWithPlayerButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TripsTrapsTrull_Page(false));

        }
    }
}
>>>>>>> 1fed75f61b824857e0f97b2d108e6e5eb409307c
