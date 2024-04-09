using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinApps
{
    public partial class EntryPage : ContentPage
    {
        Button btn_Start, btn_Time, btn_BV;
        Label lbl;
        StackLayout st;
        Editor ed;
        public EntryPage()
        {
            InitializeComponent();

            Title = "Entry";
            btn_Start = new Button
            {
                Text = "Menüü",
            };
            btn_Start.Clicked += async (s, e) => await Navigation.PopAsync(true);

            btn_Time = new Button
            {
                Text = "Taimer",
            };
            btn_Time.Clicked += async (s, e) => await Navigation.PushAsync(new TimerPage());

            btn_BV = new Button
            {
                Text = "BoxView",
            };
            btn_BV.Clicked += async (s, e) => await Navigation.PushAsync(new BoxViewPage());

            lbl = new Label
            {
                Text = "Mingi tekst",
                BackgroundColor = Color.Yellow,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 12,
                TextColor = Color.Black,
            };

            ed = new Editor
            {
                Placeholder = "Sisesta tekst..",
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                TextColor = Color.Black,
                WidthRequest = 400,
                MaxLength = 50,
            };
            ed.TextChanged += (s, e) => { lbl.Text = ed.Text; };
            

            Content = st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.LightGray,
                Children = { lbl, btn_Start, btn_Time, btn_BV, ed },
            };
        }
    }
}
