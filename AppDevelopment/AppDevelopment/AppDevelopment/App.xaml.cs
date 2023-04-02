using System;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Tamagotchi;

namespace AppDevelopment
{
    public partial class App : Application
    {
        public App ()
        {
            DependencyService.RegisterSingleton<IDataStore<Creature>>(new CreatureDatastore());


            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart ()
        {
            var sleepTime = Preferences.Get("SleepTime", DateTime.Now);
            var wakeTime = DateTime.Now;

            TimeSpan timeAsleep = wakeTime - sleepTime;

        }

        protected override void OnSleep ()
        {
            var sleepTime = DateTime.UtcNow;
            Preferences.Set("SleepTime", sleepTime);
        }

        protected override void OnResume ()
        {
            var sleepTime = Preferences.Get("SleepTime", DateTime.UtcNow);
            var timePassed = DateTime.UtcNow - sleepTime;

    
        }
        
    }
}
