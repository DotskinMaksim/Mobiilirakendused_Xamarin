using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinApps
{	
	public partial class FramePage : ContentPage
	{
        Grid grid;
        Random random = new Random();
        Frame fr;
        Label lbl;
        Image image;
        Switch sw;
        public FramePage ()
		{
			InitializeComponent ();

            Title = "Frame";

            grid = new Grid
            {
                BackgroundColor = Color.Firebrick,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            tap.NumberOfTapsRequired = 1;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    grid.Children.Add(fr = new Frame
                    {
                        BackgroundColor = Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)),
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    }, i, j);
                    fr.GestureRecognizers.Add(tap);
                }
            }
            lbl = new Label { Text = "Tekst", FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)) };
            grid.Children.Add(lbl, 0, 6);
            Grid.SetColumnSpan(lbl, 6);

            image = new Image() { Source = "BogomDan.jpg" };
            sw = new Switch { IsToggled = false };

            sw.Toggled += Sw_Toggled;
            grid.Children.Add(sw, 0, 7);
            grid.Children.Add(image, 2, 7);

            Content = grid;
        }

        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value) { image.IsVisible = true; } else { image.IsVisible = false; }
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            Frame fr = (Frame)sender;
            var r = Grid.GetRow(fr) + 1;
            var c = Grid.GetColumn(fr) + 1;
            lbl.Text = "Rida: " + r.ToString() + "Veerg: " + c.ToString();
        }
    }
}

