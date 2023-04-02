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
    public partial class playing : ContentPage
    {
        public Creature Markie { get; set; } = new Creature
        {
        };
        public Creature MyCreature { get; set; }
        public float happy { get; set; } = .0f;

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
        public playing()
        {
            happy = Markie.Boredom;

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
 
            });

        }
        async void spin(object sender, EventArgs args)
        {
            if (Markie.Boredom <= 1)
            {
                Markie.Boredom += 0.1f;

            }
            happy = Markie.Boredom;
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            await creatureDataStore.UpdateItem(Markie);

            await rutten.RelRotateTo(45, 0);

        }

        protected override async void OnAppearing()
        {
            happy = Markie.Boredom;
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