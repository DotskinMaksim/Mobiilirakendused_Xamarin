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
        BoxView[] arvud = new BoxView[3];

        public Lumememm_Page()
        {
            InitializeComponent();

            ruut = new BoxView
            {
                CornerRadius = 1,
                WidthRequest = 70,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Brown
            };
            arvud[0] = ruut;

            ring1 = new BoxView
            {
                CornerRadius = 400,
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.White
            };
            arvud[1] = ring1;


            ring2 = new BoxView
            {
                CornerRadius = 400,
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.White
            };
            arvud[2] = ring2;


            hide = new Button
            {
                Text = "Peita"
            };

            show = new Button
            {
                Text = "Näita",
                IsVisible = false
            };
            color = new Button
            {
                Text = "Muuda värv",
            };
            rotate = new Button
            {
                Text = "Pööra ämbrit",

            };
            slider = new Slider
            {
                
                Minimum = 0,
                Maximum = 2,
                Value = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            lbl = new Label
            {
                Text = "Sulatada lumememm"
            };
            show.Clicked += Show_Clicked;
            hide.Clicked += Hide_Clicked;
            color.Clicked += Color_Clicked;
            slider.ValueChanged += Slider_ValueChanged;
            rotate.Clicked += RotateSquare;

            var lay = new AbsoluteLayout
            {
                Children = { ring1, ring2, ruut, rotate, hide, show, color, lbl, slider }
            };

            AbsoluteLayout.SetLayoutBounds(ruut, new Rectangle(0.4, 0.03, 300, 200));
            AbsoluteLayout.SetLayoutFlags(ruut, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(ring1, new Rectangle(0.4, 0.19, 300, 200));
            AbsoluteLayout.SetLayoutFlags(ring1, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(ring2, new Rectangle(0.4, 0.49, 300, 200));
            AbsoluteLayout.SetLayoutFlags(ring2, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(hide, new Rectangle(0, 0.7, 200, 50));
            AbsoluteLayout.SetLayoutFlags(hide, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(show, new Rectangle(0, 0.7, 400, 50));
            AbsoluteLayout.SetLayoutFlags(show, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(color, new Rectangle(0, 0.8, 200, 50));
            AbsoluteLayout.SetLayoutFlags(color, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.1, 0.89, 200, 50));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(slider, new Rectangle(0, 0.9, 200, 50));
            AbsoluteLayout.SetLayoutFlags(slider, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(rotate, new Rectangle(0, 1, 200, 50));
            AbsoluteLayout.SetLayoutFlags(rotate, AbsoluteLayoutFlags.PositionProportional);

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
            int r, g, b;

            foreach (BoxView arv in arvud)
            {
                r = rnd.Next(0, 255);
                g = rnd.Next(0, 255);
                b = rnd.Next(0, 255);
                arv.BackgroundColor = Color.FromRgb(r, g, b);
            }
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
                await ruut.RelRotateTo(360, 2000);
                ruut.Rotation = 0;
        }
    }
}