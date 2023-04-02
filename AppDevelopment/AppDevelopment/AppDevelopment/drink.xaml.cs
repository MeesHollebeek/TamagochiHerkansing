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
    public partial class drink : ContentPage
    {
        public Creature Markie { get; set; } = new Creature
        {
        };

        public Creature MyCreature { get; set; }
        public float drank { get; set; } = .0f;



        public float Status => drank;

        public string ThirstText => Status switch
        {
            >= 1.0f => "Water Bucket full",
            >= .5f => "Drinking away.",
            >= .3f => "Getting thisty.",
            >= .1f => "Very thirsty.",
            > .0f => "Loading Thirst status...",
            .0f => "Loading Thirst stats...",
            _ => throw new Exception("impossible")

        };
        public drink()
        {
            drank = Markie.Thirst;

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
                drank = Markie.Thirst;

            });


        }
        async void thirsty(object sender, EventArgs args)
        {
            if (Markie.Thirst <= 1)
            {
                Markie.Thirst += 0.1f;

            }
            drank = Markie.Thirst;
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            await creatureDataStore.UpdateItem(Markie);



            await rutten.TranslateTo(0, 5);
            await rutten.TranslateTo(0, 0);
            await rutten.TranslateTo(0, 5);
            rutten.TranslateTo(0, 0);


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
            await creatureDataStore.UpdateItem(Markie);
        }
    }
}