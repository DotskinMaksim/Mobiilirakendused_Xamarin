using System;
using System.Collections.ObjectModel;
using System.IO; // Add this line to use the Path class
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobileAppDotskin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class List_Page : ContentPage
    {
        public ObservableCollection<Telefon> telefons { get; set; }
        Label lbl_list;
        ListView list;
        Button lisa, kustuta;

        public List_Page()
        {
            telefons = new ObservableCollection<Telefon>
            {
                new Telefon { Nimetus = "Samsung Galaxy S20 Ultra", Tootja = "Samsung", Hind = 1349, Pilt = "SamsungGalaxyS20Ultra.png" },
                new Telefon { Nimetus = "Xiaomi Mi 11 Lite 5G NE", Tootja = "Xiaomi", Hind = 399, Pilt = "XiaomiMi11Lite5GNE.png" },
                new Telefon { Nimetus = "Xiaomi Mi 11 Lite 5G", Tootja = "Xiaomi", Hind = 339, Pilt = "XiaomiMi11Lite5G.png" },
                new Telefon { Nimetus = "iPhone 13", Tootja = "Apple", Hind = 1179, Pilt = "iPhone13.png" }
            };

            list = new ListView
            {
                SeparatorColor = Color.Orange,
                Header = "Minu oma kolektion",
                Footer = DateTime.Now.ToString("t"),
                HasUnevenRows = true,
                ItemsSource = telefons,
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                    Binding companyBinding = new Binding { Path = "Tootja", StringFormat = "Tore telefon firmalt {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                    return imageCell;
                })
            };
            list.ItemTapped += List_ItemTapped;

            lisa = new Button { Text = "Lisa telefon" };
            kustuta = new Button { Text = "Kustuta telefon" };
            lisa.Clicked += Lisa_Clicked;
            kustuta.Clicked += Kustuta_Clicked;

            lbl_list = new Label
            {
                Text = "Telefonide loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };

            this.Content = new StackLayout { Children = { lbl_list, list, lisa, kustuta } };
        }

        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            Telefon phone = list.SelectedItem as Telefon;
            if (phone != null)
            {
                telefons.Remove(phone);
                list.SelectedItem = null;
            }
            lbl_list.Text = "Telefonide loetelu";
        }

        private async void Lisa_Clicked(object sender, EventArgs e)
        {
            string nimetus = await DisplayPromptAsync("Nimetus", "Kirjuta nimetus");
            if (string.IsNullOrWhiteSpace(nimetus))
            {
                return;
            }
            string tootja = await DisplayPromptAsync("Tootja", "Kirjuta tootja");
            if (string.IsNullOrWhiteSpace(tootja))
            {
                return;
            }
            string hindStr = await DisplayPromptAsync("Hind", "Kirjuta hind", keyboard: Keyboard.Numeric);
            if (string.IsNullOrWhiteSpace(hindStr) || !int.TryParse(hindStr, out int hind))
            {
                return;
            }
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                if (photo != null)
                {
                    string fileName = Path.GetFileName(photo.FullPath); 
                    telefons.Add(new Telefon { Nimetus = nimetus, Tootja = tootja, Hind = hind, Pilt = fileName });

                    list.ItemsSource = null;
                    list.ItemsSource = telefons;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Failed to pick photo: " + ex.Message, "OK");
            }
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Telefon selectedPhone = e.Item as Telefon;
            if (selectedPhone != null)
            {
                await DisplayAlert("Vali model", $"{selectedPhone.Tootja} - {selectedPhone.Nimetus} \n{selectedPhone.Hind} eurot", "OK");
            }
        }
    }


}
