using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Verat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        Editor editor;

        public NewItemPage()
        {
            InitializeComponent();
            editor = NameTextEditor;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            new MainPage().newItemReply(editor.Text);
            Navigation.PushAsync(new MainPage());
        }
    }
}