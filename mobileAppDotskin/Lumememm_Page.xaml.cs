using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace mobileAppDotskin
{

    public partial class Lumememm_Page : ContentPage
    {
        Label lbl;
        BoxView ring1, ring2, ruut;
        Button hide, show, color,rotate;
        Random rnd;
        Slider slider;
        public Lumememm_Page()
        {
            InitializeComponent();

            lbl = new Label { Text = "Rgb is 0.0.0", TextColor = Color.Black, HorizontalOptions = LayoutOptions.Center, FontSize = 24 };

            ruut = new BoxView
            {
                CornerRadius = 1,
                WidthRequest = 70,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Brown
            };

            ring1 = new BoxView
            {
                CornerRadius = 400,
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.White
            };

            ring2 = new BoxView
            {
                CornerRadius = 400,
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.White
            };

            hide = new Button
            {
                Text = "Hide snowman"
            };

            show = new Button
            {
                Text = "Show snowman",
                IsVisible = false
            };
            color = new Button
            {
                Text = "Change color",
            };
            rotate = new Button
            {
                Text = "Rotate",
            };
            slider = new Slider
            {
                Minimum = 0,
                Maximum = 2,
                Value = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            show.Clicked += Show_Clicked;
            hide.Clicked += Hide_Clicked;
            color.Clicked += Color_Clicked;
            slider.ValueChanged += Slider_ValueChanged;
            rotate.Clicked += RotateSquare;

            var lay = new AbsoluteLayout
            {
                Children = { ring1, ring2, ruut, rotate,hide, show, color ,slider}
            };

            AbsoluteLayout.SetLayoutBounds(ruut, new Rectangle(0.4, 0.13, 300, 200));
            AbsoluteLayout.SetLayoutFlags(ruut, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(ring1, new Rectangle(0.4, 0.29, 300, 200));
            AbsoluteLayout.SetLayoutFlags(ring1, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(ring2, new Rectangle(0.4, 0.59, 300, 200));
            AbsoluteLayout.SetLayoutFlags(ring2, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(hide, new Rectangle(0, 0.9, 200, 50));
            AbsoluteLayout.SetLayoutFlags(hide, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(show, new Rectangle(0, 0.9, 200, 50));
            AbsoluteLayout.SetLayoutFlags(show, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(color, new Rectangle(0, 1, 200, 50));
            AbsoluteLayout.SetLayoutFlags(color, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(slider, new Rectangle(0.5, 1, 300, 50));
            AbsoluteLayout.SetLayoutFlags(slider, AbsoluteLayoutFlags.PositionProportional);
            Content = lay;
            BackgroundColor = Color.Gray;
            
        }
        private void Hide_Clicked(object sender, EventArgs e)
        {
            ring1.IsVisible = false;
            ring2.IsVisible = false;
            ruut.IsVisible = false;
            hide.IsVisible = false;
            show.IsVisible = true;
        }

        private void Show_Clicked(object sender, EventArgs e)
        {
            ring1.IsVisible = true;
            ring2.IsVisible = true;
            ruut.IsVisible = true;
            hide.IsVisible = true;
            show.IsVisible = false;
        }
        private void Color_Clicked(object sender, EventArgs e)
        {
            rnd = new Random();
            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
            ring1.BackgroundColor = Color.FromRgb(r, g, b);
            r = rnd.Next(0, 255);
            g = rnd.Next(0, 255);
            b = rnd.Next(0, 255);
            ring2.BackgroundColor = Color.FromRgb(r, g, b);
            r = rnd.Next(0, 255);
            g = rnd.Next(0, 255);
            b = rnd.Next(0, 255);
            ruut.BackgroundColor = Color.FromRgb(r, g, b);
        }
        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var value = (int)e.NewValue;
            switch (value)
            {
                case 0:
                    ring1.IsVisible = true;
                    ring2.IsVisible = true;
                    break;
                case 1:
                    ring1.IsVisible = false;
                    ring2.IsVisible = true;

                    break;
                case 2:
                    ring1.IsVisible = false;
                    ring2.IsVisible = false;
                    break;
                default:
                    break;
            }
        }
        private async void RotateSquare(object sender, EventArgs e)
        {
            while (true)
            {
      
                await ruut.RelRotateTo(360, 2000);

       
                ruut.Rotation = 0;

                  
                await Task.Delay(1000);
            }
        
        }
    }
}