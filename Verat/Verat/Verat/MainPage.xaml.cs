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
        ScrollView scrollFrame;
        List<Item> items;
        View debugWatchVar;

        public MainPage()
        {
            InitializeComponent();
            scrollFrame = ScrollFrame;

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
            scrollFrame.Content = null;

            foreach (Item item in items)
            {
                newItem(item.Name, item.Done);
            }

            Button newButton = new Button
            {
                Parent = scrollFrame,
                Text = "Add Item",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(0, 5),
                HeightRequest = 50,
                Font = Font.OfSize("Bold", 24),
                FontSize = 24,
                TextColor = Color.Coral,
                BackgroundColor = Color.DimGray,
            };

            debugWatchVar = scrollFrame.Content;

            Debug.Write("NewItem Button Added");
            newButton.Clicked += CreateNew_Clicked;
        }

        public void newItem(string name, bool done)
        {
            Button newButton = new Button
            {
                Parent = scrollFrame,
                Text = name,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(0, 5),
                HeightRequest = 50,
                Font = Font.OfSize("Bold", 24)
            };
            if (done)
            {
                newButton.FontSize = 26;
            }
            else
            {
                newButton.FontSize = 22;
            }
            newButton.TextColor = Color.Coral;
            newButton.BackgroundColor = Color.DimGray;
            newButton.Clicked += Done_Clicked;

        }

        public void newItemReply(string name)
        {
            items.Add(new Item(name, false));
            Application.Current.Properties["listOfItem"] = items;
            reloadItems();
        }


        private void CreateNew_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewItemPage());
        }

        private void Done_Clicked(object sender, EventArgs e)
        {
            foreach (Item item in items)
            {
                if (item.Name == (sender as Button).Text)
                {
                    item.Done = !item.Done;
                }
            }
            Application.Current.Properties["listOfItem"] = items;
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
