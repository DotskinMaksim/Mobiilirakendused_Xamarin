using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinApps
{	
	public partial class ImagePage : ContentPage
	{
		Switch sw;
		Image img;

		public ImagePage ()
		{
			InitializeComponent ();

            Title = "Image ja switch";


            img = new Image { Source = "BogomDan.jpg" };
            sw = new Switch
            {
                IsToggled = true,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            sw.Toggled += Sw_Toggled; ;
            this.Content = new StackLayout { Children = { img, sw } };
        }

        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                img.IsVisible = true;
            }
            else
            {
                img.IsVisible = false;
            }
        }
    }
}

