using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Timers;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Newtonsoft.Json;
using Tamagotchi;

namespace AppDevelopment
{
    public partial class MainPage : ContentPage
    {
      
  

       // private Timer timer;

        

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();

           
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            

          
            Navigation.PushAsync(new nutteloos());
        }
    }
}
