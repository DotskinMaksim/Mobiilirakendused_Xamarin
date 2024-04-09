using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks; 

namespace XamarinApps
{	
	public partial class RGBModelPage : ContentPage
	{
        Label redLabel, blueLabel, greenLabel;
        Slider redSlider, blueSlider, greenSlider;
        BoxView box;
        Button randomColor, randomSize, defaultSize;
        Stepper changeSize, changeAngles;
        Random rnd;

        public RGBModelPage()
        {

            Title = "RGB mudel";
            box = new BoxView
            {

                WidthRequest = 200,
                HeightRequest = 200*1.3,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            redLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            greenLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            blueLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            blueSlider = new Slider
            {
                Minimum = 0,
                Maximum = 256,
                Value = 3,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
            };

            greenSlider = new Slider
            {
                Minimum = 0,
                Maximum = 256,
                Value = 3,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
            };

            redSlider = new Slider
            {
                Minimum = 0,
                Maximum = 256,
                Value = 3,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
            };

            randomColor = new Button
            {
                Text = "Juhuslik värv"
            };

            randomSize = new Button
            {
                Text = "Juhuslik suurur"
            };

            defaultSize = new Button
            {
                Text = "Eemalda suurus"
            };

            changeSize = new Stepper
            {
                Minimum = 0,
                Maximum = 255,
                Increment = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Value=20
                
            };
            changeAngles = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Increment = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Value = 0

            };


            var changeSizeLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Children = { new Label { Text = "Suurus", VerticalOptions = LayoutOptions.Center }, changeSize }
            };
            var changeAnglesLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Children = { new Label { Text = "Nurgad", VerticalOptions = LayoutOptions.Center }, changeAngles}
            };

            redSlider.ValueChanged += Slider_ValueChanged;
            blueSlider.ValueChanged += Slider_ValueChanged;
            greenSlider.ValueChanged += Slider_ValueChanged;

            randomColor.Clicked += randomColor_Clicked;
            randomSize.Clicked += randomSize_Clicked;
            defaultSize.Clicked += defaultSize_Clicked;

            changeSize.ValueChanged += ChangeSize_ValueChanged;
            changeAngles.ValueChanged += ChangeAngles_ValueChanged;
            StackLayout st = new StackLayout
            {
                Children = { box,redSlider, redLabel, greenSlider, greenLabel, blueSlider, blueLabel , randomSize, randomColor, defaultSize, changeSizeLayout, changeAnglesLayout},
                Margin = new Thickness(20)
            };

            ScrollView sv = new ScrollView { Content = st };
            Content = sv;
        }

        private void ChangeAngles_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            box.CornerRadius = e.NewValue;
        }

        private void ChangeSize_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            box.WidthRequest =e.NewValue;
            box.HeightRequest = e.NewValue*1.3;
        }

        private void randomColor_Clicked(object sender, EventArgs e)
        {
            rnd = new Random();
            int ar = rnd.Next(0, 300);
            int ag = rnd.Next(0, 300);
            int ab = rnd.Next(0, 300);
            box.Color = Color.FromRgb(ar, ag, ab);
        }
        private void randomSize_Clicked(object sender, EventArgs e)
        {
            rnd = new Random();
            int n = rnd.Next(0, 255);
            box.WidthRequest = n;
            box.HeightRequest = n*1.3;

            changeSize.Value = n;
        }
        private void defaultSize_Clicked(object sender, EventArgs e)
        {
            box.WidthRequest = 200;
            box.HeightRequest = 200*1.3;

            changeSize.Value = 200;
        }

        void Slider_ValueChanged(object sender, ValueChangedEventArgs args)
        {


            if (sender == redSlider)
            {
                redLabel.Text = String.Format("Red = {0:X2}", (int)args.NewValue);
            }
            else if (sender == greenSlider)
            {
                greenLabel.Text = String.Format("Green = {0:X2}", (int)args.NewValue);
            }
            else if (sender == blueSlider)
            {
                blueLabel.Text = String.Format("Blue = {0:X2}", (int)args.NewValue);
            }

            box.Color = Color.FromRgb((int)redSlider.Value, (int)greenSlider.Value, (int)blueSlider.Value);
        }
    }
}