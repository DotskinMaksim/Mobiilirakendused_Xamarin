using System;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinApps.Classes;

namespace XamarinApps
{
    public partial class ListViewPage : ContentPage
    {
        public ObservableCollection<Phone> Phones { get; set; }
        ListView list;
        Button add, delete;
        Phone selectedPhone;

        public ListViewPage()
        {

            Title = "ListView";


            add = new Button { Text = "Lisa telefon" };
            delete = new Button { Text = "Kustuta telefon" };

            Phones = new ObservableCollection<Phone>
            {
                new Phone { Name = "Samsung Galaxy S20 Ultra", Manufacturer = "Samsung", Price = 1349, Photo = ImageSource.FromFile("Samsung_Galaxy_S20_Ultra.jpeg") },
                new Phone { Name = "Xiaomi Mi 11 Lite 5G NE", Manufacturer = "Xiaomi", Price = 399, Photo = ImageSource.FromFile("XiaomiMi11Lite5GNE.jpeg") },
                new Phone { Name = "Xiaomi Mi 11 Lite 5G", Manufacturer = "Xiaomi", Price = 339, Photo = ImageSource.FromFile("XiaomiMi11Lite5G.jpeg") },
                new Phone { Name = "iPhone 13", Manufacturer = "Apple", Price = 1179, Photo = ImageSource.FromFile("iPhone13.jpeg") }
            };


            list = new ListView
            {

                SeparatorColor = Color.Orange,
                Header = "Minu telefonikogu",
                Footer = DateTime.Now.ToString("t"),
                HasUnevenRows = true,
                ItemsSource = Phones,
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Name");
                    Binding manufacturerBinding = new Binding { Path = "Manufacturer", StringFormat = "{0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, manufacturerBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Photo");
                    return imageCell;


                })
            };

            list.ItemTapped += List_ItemTapped;
            add.Clicked += Add_Clicked;
            delete.Clicked += Delete_Clicked;



            this.Content = new StackLayout { Children = {  list, add, delete } };
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            if (selectedPhone != null)
            {
                Phones.Remove(selectedPhone);
                list.SelectedItem = null;
                selectedPhone = null;
            }
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            string name = await DisplayPromptAsync("Sisestage telefoni nimetus", "Nimetus:");
            if (string.IsNullOrWhiteSpace(name)) return;

            string manufacturer = await DisplayPromptAsync("Sisestage tootja", "Tootja:");
            if (string.IsNullOrWhiteSpace(manufacturer)) return;

            string priceStr = await DisplayPromptAsync("Sisestage hind", "Hind:", keyboard: Keyboard.Numeric);
            if (string.IsNullOrWhiteSpace(priceStr) || !int.TryParse(priceStr, out int price)) return;

   
            var photo = await MediaPicker.PickPhotoAsync();
            if (photo != null)
            {
                ImageSource photoSource = ImageSource.FromFile(photo.FullPath);
                Phones.Add(new Phone { Name = name, Manufacturer = manufacturer, Price = price, Photo = photoSource });

                list.ItemsSource = null;
                list.ItemsSource = Phones;
            }
            
           
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            selectedPhone = e.Item as Phone;
            if (selectedPhone != null)
            {
                await DisplayAlert("Telefoni üksikasjad", $"{selectedPhone.Manufacturer} - {selectedPhone.Name} \nHind: {selectedPhone.Price} eurot", "OK");
            }
        }
    }
}
