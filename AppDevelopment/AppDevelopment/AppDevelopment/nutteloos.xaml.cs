using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Timers;
using Tamagotchi;

namespace AppDevelopment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class nutteloos : ContentPage
    {
        public float slaap { get; set; } = .0f;

        public string SleepText => slaap switch
        {
            >= 1.0f => "plenty of sleep!",
            >= .5f => "good night of sleep.",
            > .0f => "getting tired.",
            .0f => "falling asleep on the ground.",
            _ => throw new Exception("impossible")

        };

        public Creature Markie { get; set; } = new Creature
        {

        };
        public Creature MyCreature { get; set; }

        public float hong { get; set; }        
        public float happy { get; set; } 
        public float drank { get; set; }
        public string ThirstText => drank switch
        {
            >= 1.0f => "Water Bucket full.",
            >= .5f => "Drinking away.",
            >= .3f => "Getting thisty.",
            >= .1f => "Very thirsty.",
            > .0f => "Loading Thirst status...",
            .0f => "Loading Thirst stats...",
            _ => throw new Exception("impossible")

        };
        public string SpinText => happy switch
        {
            >= 1.0f => "Full of happynes.",
            >= .5f => "Happy.",
            >= .3f => "Nutral.",
            >= .1f => "Bored.",
            > .0f => "Loading Boredom status...",
            .0f => "Loading Boredom stats...",
            _ => throw new Exception("impossible")
        };
        public string HungerText => hong switch
        {
            >= 1.0f => "Food bucket full",
            >= .5f => "Nomming away.",
            >= .3f => "Getting hungry.",
            >= .1f => "Very hungry.",
            > .0f => "Loading food status...",
            .0f => "Loading food stats...",
            _ => throw new Exception("impossible")

        };



        public nutteloos()
        {
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
                if(Markie.Hunger > 0.11)
                {
                    Markie.Hunger -= 0.0005f;
                    Console.WriteLine(Markie.Hunger);
                    hong = Markie.Hunger;
                }
                if (Markie.Hunger < 0.1)
                {
                    Markie.Hunger = 0.1f;
                    hong = Markie.Hunger;
                }

                if (Markie.Thirst > 0.11)
                {
                    Markie.Thirst -= 0.0005f;
                    
                    drank = Markie.Thirst;
                }
                if (Markie.Thirst < 0.1)
                {
                    Markie.Thirst = 0.1f;
                    drank = Markie.Thirst;
                }

                if (Markie.Boredom > 0.11)
                {
                    Markie.Boredom -= 0.0005f;

                    happy = Markie.Boredom;
                }
                if (Markie.Boredom < 0.1)
                {
                    Markie.Boredom = 0.1f;
                    happy = Markie.Boredom;
                }
                if (Markie.Tired > 0.11)
                {
                    Markie.Tired -= 0.00005f;

                    slaap = Markie.Tired;
                }
                if (Markie.Tired < 0.1)
                {
                    Markie.Tired = 0.1f;
                    slaap = Markie.Tired;
                }
            });
            
        }



        void Feed(object sender, EventArgs args)
        {
            Navigation.PushAsync(new food());
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(Markie);

        }
        void spin(object sender, EventArgs args)
        {
            Navigation.PushAsync(new playing());
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(Markie);

        }
         void thirst(object sender, EventArgs args)
        {
            Navigation.PushAsync(new drink());
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(Markie);

        }
         void sleep(object sender, EventArgs args)
        {
            Navigation.PushAsync(new bed());
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(Markie);

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            Markie = await creatureDataStore.ReadItem();
            if (Markie == null)
            {
                Markie = new Creature { Name = "Markie" };
                await creatureDataStore.CreateItem(Markie);
            }
        }
    }
}