using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinApps.Classes;

namespace XamarinApps
{	
	public partial class BrowserPage : ContentPage
	{
        Picker picker;
        WebView webView;
        Frame frame;
        List<WebPage> pages = new List<WebPage>
        {
            new WebPage("TTHK - konsultatsioonid", "https://www.tthk.ee/tabel_proov/"),
            new WebPage("Moodle", "https://moodle.edu.ee/"),
            new WebPage("YouTube - laul", "https://www.youtube.com/watch?v=ygTZZpVkmKg"),
            new WebPage("Delfi - uudis", "https://rus.delfi.ee/statja/120294158/prezident-irana-ibrahim-raisi-pogib-pri-krushenii-vertoleta")
        };

        List<string> history = new List<string>();


        StackLayout historyLayout;
        Entry addressEntry;
        public BrowserPage ()
		{
			InitializeComponent ();

            picker = new Picker
            {
                Title = "Brauser"
            };

            foreach (WebPage page in pages)
            {
                picker.Items.Add(page.name);
            }

            frame = new Frame
            {
                BackgroundColor = Color.Gray
            };

            webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = "https://github.com/dashboard",
                },
                WidthRequest = 100,
                HeightRequest = 1000,
            };

            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();


            swipe.Swiped += Swipe_Swiped;

            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            frame.GestureRecognizers.Add(swipe);

            Button addButton = new Button { Text = "Lisa oma lehekülg" };
            addButton.Clicked += AddPageButton_Clicked;

            Button historyButton = new Button { Text = "Ajalugu" };
            historyButton.Clicked += HistoryButton_Clicked;

            historyLayout = new StackLayout();

            addressEntry = new Entry { Placeholder = "Sisesta aadress", Keyboard = Keyboard.Url };
            addressEntry.Completed += AddressEntry_Completed;

            StackLayout st = new StackLayout { Children = { addressEntry, picker, webView, frame, addButton, historyButton, historyLayout } };

            Content = st;
        }

        private void AddressEntry_Completed(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(addressEntry.Text))
            {
                webView.Source = addressEntry.Text;
                AddToHistory(addressEntry.Text);

            }
        }

        private async void AddPageButton_Clicked(object sender, EventArgs e)
        {
            string url = await DisplayPromptAsync("Lisa leht", "Sisesta lehekülje URL", maxLength: 100, keyboard: Keyboard.Url);
            if (!string.IsNullOrWhiteSpace(url))
            {
                string nimi = await DisplayPromptAsync("Lehekülje nimi", "Sisesta lehekülje nimi", maxLength: 50);
                if (!string.IsNullOrWhiteSpace(nimi))
                {
                    pages.Add(new WebPage(nimi, url));
                    picker.Items.Add(nimi);
                }
            }
        }

        private async void HistoryButton_Clicked(object sender, EventArgs e)
        {
            string historyMessage = "Brauseri ajalugu:\n";
            foreach (string page in history)
            {
                historyMessage += page + "\n";
            }
            await DisplayAlert("Ajalugu", historyMessage, "OK");
        }

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = pages[3].name };
        }


        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            webView.Source = pages[picker.SelectedIndex].url;
            AddToHistory(pages[picker.SelectedIndex].name);
        }


        private void AddToHistory(string page)
        {
            history.Insert(0, page);
            if (history.Count > 10)
            {
                history.RemoveAt(history.Count - 1);
            }
            UpdateHistoryView();
        }

        private void UpdateHistoryView()
        {
            historyLayout.Children.Clear();
            foreach (string page in history)
            {
                historyLayout.Children.Add(new Label { Text = page });
            }
        }
    }
}

