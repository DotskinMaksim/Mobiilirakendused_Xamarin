using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Plugin.Messaging;
using XamarinApps.Classes;

namespace XamarinApps
{
    public partial class HolidaysGreetingPage : ContentPage
    {



        TableView tableView;
        EntryCell phone, email;
        Picker friendPicker;
        List<Friend> friends = new List<Friend>
        {
            new Friend { Name = "Maksik", Email = "ultramax2516@gmail.com", Number = 55553605 },
            new Friend { Name = "Artur", Email = "maxell9976@gmail.com", Number = 87654321 },
            new Friend { Name = "Bogdan", Email = "dotskin.maksim@gmail.com", Number = 12345678 }
        };

        List<string> greetings = new List<string>
        {
            "Palju õnne sünnipäevaks!",
            "Head uut aastat!",
            "Kevadpüha!",
            "Häid jõule!",
            "Head kevad - ja talgupäeva!"
        };

        public HolidaysGreetingPage()
        {

            

            Title = "Pühade tervitused";

            phone = new EntryCell()
            {
                Label = "Number",
                Placeholder = "Telefoni number",
                Keyboard = Keyboard.Telephone
            };

            email = new EntryCell()
            {
                Label = "Email",
                Placeholder = "E-posti aadress",
                Keyboard = Keyboard.Email
            };

            friendPicker = new Picker
            {
                Title = "Valige sõber",
                ItemsSource = friends,
                ItemDisplayBinding = new Binding("Name")
            };

            Button sendGreetingBtn = new Button { Text = "Õnnitle" };
            Button addFriendBtn = new Button { Text = "Lisa sõber" };
            Button saveFriendDataBtn = new Button { Text = "Salvesta"};

            tableView = new TableView()
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Saadamine õnnitlused")
                {
                    new TableSection("Kontaktandmed: ")
                    {
                        phone,
                        email,
                        new ViewCell { View = saveFriendDataBtn }
                    }
                }
            };
            Grid grid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) }
                },
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) } 
                }
            };

            grid.Children.Add(friendPicker, 0, 0);
            grid.Children.Add(addFriendBtn, 1, 0);

            sendGreetingBtn.Clicked += SendGreetingBtn_Clicked;
            addFriendBtn.Clicked += AddFriendBtn_Clicked;
            saveFriendDataBtn.Clicked += SaveFriendDataBtn_Clicked;
            friendPicker.SelectedIndexChanged += FriendPicker_SelectedIndexChanged;

            Content = new StackLayout
            {
                Padding = new Thickness(10),
                Children = { tableView ,grid, sendGreetingBtn}
            };
        }

        private void SaveFriendDataBtn_Clicked(object sender, EventArgs e)
        {
            if (friendPicker.SelectedIndex != -1)
            {
                Friend selectedFriend = (Friend)friendPicker.SelectedItem;
                selectedFriend.Email = email.Text;

                if (int.TryParse(phone.Text, out int newNumber))
                {
                    selectedFriend.Number = newNumber;
                }
                else
                {
                    DisplayAlert("Viga", "Sisestage õige telefoninumber", "OK");
                }
            }
            else
            {
                DisplayAlert("Viga", "Palun valige sõber", "OK");
            }
        }

        private async void AddFriendBtn_Clicked(object sender, EventArgs e)
        {
            string newName = await DisplayPromptAsync("Uus sõber", "Sisestage uue sõbra nimi", "ОК", "Tühista", "Nimi");
            string newEmail = await DisplayPromptAsync("Uus sõber", "Sisestage uue sõbra e-posti aadress", "ОК", "Tühista", "Email");
            string newNumber = await DisplayPromptAsync("Uus sõber", "Sisestage uue sõbra telefoninumber", "ОК", "Tühista", "Number");

            if (!string.IsNullOrWhiteSpace(newName) && !string.IsNullOrWhiteSpace(newEmail) && !string.IsNullOrWhiteSpace(newNumber))
            {
                Friend newFriend = new Friend
                {
                    Name = newName,
                    Email = newEmail,
                    Number = int.Parse(newNumber)
                };

                friends.Add(newFriend);

                friendPicker.ItemsSource = null;
                friendPicker.ItemsSource = friends;
            }
        }

        private void FriendPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (friendPicker.SelectedIndex != -1)
            {
                Friend selectedFriend = friends[friendPicker.SelectedIndex];
                phone.Text = selectedFriend.Number.ToString();
                email.Text = selectedFriend.Email;
            }
        }

        private async void SendGreetingBtn_Clicked(object sender, EventArgs e)
        {
            if (friendPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Viga", "Palun valige sõber", "OK");
                return;
            }

            Friend selectedFriend = friends[friendPicker.SelectedIndex];
            string greeting = GetRandomGreeting();
            string recipient = "";

            if (await DisplayAlert("Meetodi valimine", "Saada õnnitlused SMS-i teel?", "Jah", "Ei"))
            {
                recipient = selectedFriend.Number.ToString();
                var sms = CrossMessaging.Current.SmsMessenger;
                if (sms.CanSendSms)
                {
                    sms.SendSms(recipient, greeting);
                }
            }
            else
            {
                recipient = selectedFriend.Email;
                var mail = CrossMessaging.Current.EmailMessenger;
                if (mail.CanSendEmail)
                {
                    mail.SendEmail(recipient, "Õnnitlused", greeting);
                }
            }
        }

        private string GetRandomGreeting()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, greetings.Count);
            return greetings[index];
        }
    }
}
