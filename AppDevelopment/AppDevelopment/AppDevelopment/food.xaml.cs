using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Tamagotchi;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDevelopment
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class food : ContentPage
    {
        public Creature Markie { get; set; } = new Creature
        {
        };
       
        public Creature MyCreature { get; set; }

        public float hong { get; set; } = .0f;



        public float Status => hong;

        public food()
        {
            hong = Markie.Hunger;

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(Markie);

            var timer = new Timer();
            timer.Interval = 30.0;
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

          

            BindingContext = this;

            InitializeComponent();

        }


        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
           

            Device.BeginInvokeOnMainThread(() =>
            {
                hong = Markie.Hunger;

            });

        }

       


        private async void Feed(object sender, EventArgs e)
        {

            if (Markie.Hunger <= 1)
            {
                Markie.Hunger += 0.1f;
               
            }            
            Console.WriteLine(Markie.Hunger);
            hong = Markie.Hunger;
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            await creatureDataStore.UpdateItem(Markie);



            await rutten.TranslateTo(0, 5);
            await rutten.TranslateTo(0, 0);
            await rutten.TranslateTo(0, 5);
            rutten.TranslateTo(0, 0);
         
            


        }
        
        public string HungerText => Status switch
        {
            >= 1.0f => "Food bucket full",
            >= .5f => "Nomming away.",
            >= .3f => "Getting hungry.",
            >= .1f => "Very hungry.",
            > .0f => "Loading food status...",
            .0f => "Loading food stats...",
            _ => throw new Exception("impossible")
        };

        protected override async void OnAppearing()
        {
            hong = Markie.Hunger;
            base.OnAppearing();

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            Markie = await creatureDataStore.ReadItem();
            if (Markie == null)
            {
                Markie = new Creature { Name = "Markie" };
                await creatureDataStore.CreateItem(Markie);
                await creatureDataStore.UpdateItem(Markie);
            }

        }



    }
}