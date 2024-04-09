using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinApps
{	
	public partial class ChooseGameModePage : ContentPage
	{
        private string selectedSymbol;
        public ChooseGameModePage ()
		{
			InitializeComponent ();
            Button playWithBotButton = new Button
            {
                Text = "Mängima bottiga",
                BackgroundColor = Color.Gray
            };

            Button playWithPlayerButton = new Button
            {
                Text = "Mängima teise mängijaga",
                BackgroundColor = Color.Gray
            };

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
                await Navigation.PushAsync(new TicTacToePage(true, selectedSymbol));
            else
                await DisplayAlert("Viga", "Palun valige sümbol", "Ok");
        }

        private async void playWithPlayerButtonClicked(object sender, EventArgs e)
        {
            if (selectedSymbol != null)
                await Navigation.PushAsync(new TicTacToePage(false, selectedSymbol));
            else
                await DisplayAlert("Viga", "Palun valige sümbol", "Ok");
        }
    }
}

