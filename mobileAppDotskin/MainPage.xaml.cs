using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mobileAppDotskin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Button Lumm_btn = new Button
            {
                Text = "Lumememm",
                BackgroundColor = Color.Gray
            };
            Button dt_btn = new Button
            {
                Text = "DateTime page",
                BackgroundColor = Color.Gray
            };

            StackLayout st = new StackLayout
            {
                Children = { Lumm_btn }
            };
            st.BackgroundColor = Color.White;
            Content = st;
            Lumm_btn.Clicked += Lumm_btn_Clicked;
            dt_btn.Clicked += dt_btn_Clicked;
        }

        private async void Lumm_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lumememm_Page());

        }
        private async void dt_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DateTime_Page());
        }
    }
}