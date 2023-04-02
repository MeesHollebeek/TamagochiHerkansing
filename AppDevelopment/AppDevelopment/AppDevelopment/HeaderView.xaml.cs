using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDevelopment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeaderView : ContentView
    {
        public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create(nameof (HeaderText), typeof(string), typeof(HeaderView));


        public string HeaderText
        {
            get => GetValue(HeaderTextProperty) as string;
            set => SetValue(HeaderTextProperty, value);
        }




        public HeaderView()
        {
            InitializeComponent();
        }
    }
}