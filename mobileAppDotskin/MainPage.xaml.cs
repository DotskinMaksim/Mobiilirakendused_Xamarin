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
            Button btn1 = new Button
            {
                Text = "Telefonid",
                BackgroundColor = Color.Gray
            };
            Button btn2 = new Button
            {
                Text = "Riigid",
                BackgroundColor = Color.Gray
            };
           

            StackLayout st = new StackLayout
            {
                Children = { btn1,btn2 }
            };
            st.BackgroundColor = Color.White;
            Content = st;
            btn1.Clicked += Lumm_btn_Clicked;
            btn2.Clicked += dt_btn_Clicked;
        }

        private async void Lumm_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new List_Page());

        }
        private async void dt_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EuropeCountries_Page());
        }
       
    }
}