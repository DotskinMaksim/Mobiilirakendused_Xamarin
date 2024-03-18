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
    public partial class ChooseGameMod : ContentPage
    {

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