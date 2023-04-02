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
    public partial class bed : ContentPage
    {
        public Creature Markie { get; set; } = new Creature
        {
        };
        public Creature MyCreature { get; set; }
        public float sleep { get; set; } = .0f;

        public string SleepText => sleep switch
        {
            >= 1.0f => "plenty of sleep!",
            >= .5f => "good night of sleep.",
            > .0f => "getting tired",
            .0f => "falling asleep on the ground",
            _ => throw new Exception("impossible")

        };


        public bed()
        {
            sleep = Markie.Tired;
            var timer = new Timer();
            timer.Interval = 3000.0;
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

                sleep = Markie.Tired;
            });

        }
        async void sleepy(object sender, EventArgs args)
        {


            if (Markie.Tired <= 1)
            {
                Markie.Tired += 0.1f;
                

            }
   
            sleep = Markie.Tired;
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            await creatureDataStore.UpdateItem(Markie);

            await rutten.RotateXTo(15, 0);
            await rutten.RotateXTo(0, 0);
            await rutten.RotateXTo(-15, 0);
            await rutten.RotateXTo(0, 0);


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