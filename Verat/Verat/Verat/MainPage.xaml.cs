using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Verat
{
    public partial class MainPage : ContentPage
    {
        StackLayout stackLayout;
        List<Item> items;

        public MainPage()
        {
            InitializeComponent();
            stackLayout = stacklayout;
            NavigationPage.SetHasNavigationBar(this, false);

            if (Application.Current.Properties.ContainsKey("listOfItem"))
            {
                items = Application.Current.Properties["listOfItem"] as List<Item>;
                Debug.Write("Old DataStore"); 
            }
            else
            {
                Application.Current.Properties.Add("listOfItem", new List<Item>());
                items = Application.Current.Properties["listOfItem"] as List<Item>;
                Debug.Write("New DataStore");
            }

            reloadItems();
        }

        public void reloadItems()
        {
            Debug.Write("Reloaded");
            stackLayout.Children.Clear();

            foreach (Item item in items)
            {
                newItem(item.Name, item.Done);
            }

            Button newButton = new Button
            {
                Text = "Add Item",
                Margin = new Thickness(0, 5),
                HeightRequest = 50,
                Font = Font.OfSize("Bold", 24),
                WidthRequest = 100,
                FontSize = 24,
                TextColor = Color.Coral,
                BackgroundColor = Color.DimGray,
            };

            stackLayout.Children.Add(newButton);
            Debug.Write("NewItem Button Added");
            newButton.Clicked += CreateNew_Clicked;
        }

        public void newItem(string name, bool done)
        {
            Button newButton = new Button
            {
                Text = name,
                Margin = new Thickness(0, 5),
                HeightRequest = 50,
                TextColor = Color.Coral,
                WidthRequest = 100,
                Font = Font.OfSize("Bold", 24)
        };
            if (done)
            {

                BackgroundColor = Color.DimGray;
            }
            else
            {
                BackgroundColor = Color.DarkGray;
            }

            stackLayout.Children.Add(newButton);

            newButton.Clicked += Done_Clicked;
        }

        public void newItemReply(string name)
        {

            bool check = false;

            foreach (Item item in items)
            {
                if (item.Name == name)
                {
                    check = true;
                }
            }

            if (check == false)
            {
                items.Add(new Item(name, false));
            }
            else
            {
                items.Add(new Item(name + " Copy", false));
            }

            Application.Current.Properties["listOfItem"] = items;
            reloadItems();
        }

        private void CreateNew_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewItemPage());
        }

        private void Done_Clicked(object sender, EventArgs e)
        {

            Button button = sender as Button;

            foreach (Item item in items)
            {
                if (item.Name == button.Text)
                {
                    item.Done = !item.Done;

                    if (item.Done)
                    {
                        button.BackgroundColor = Color.DimGray;
                    }
                    else
                    {
                        Debug.Write("Item Button Removed");
                        items.Remove(item);
                        Debug.Write("Continues 1");
                    }
                }
                Debug.Write("Continues 2");
            }

            Debug.Write("Continues 3");

            foreach (Item item in items)
            {
                if (item.Name == button.Text)
                {
                    Debug.Write("Dead Button found");
                }
            }
            Application.Current.Properties["listOfItem"] = items;
            reloadItems();
        }

        class Item
        {
            public string Name { get; set; }
            public bool Done { get; set; }
             
            public Item(string name, bool done)
            {
                Name = name;
                Done = done;
            }
        }

    }

}
