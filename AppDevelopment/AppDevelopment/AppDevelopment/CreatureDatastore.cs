using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Threading.Tasks;
using Tamagotchi;

namespace AppDevelopment
{
   public class CreatureDatastore : IDataStore<Creature>
    {
        //CRUD Create, Read. Update, Delete

        public Task<bool> CreateItem(Creature item)
        {
            
            string creatureAsText = JsonConvert.SerializeObject(item);

            Preferences.Set("MyCreature", creatureAsText);



            return Task.FromResult(true);
        }

        public Task<Creature> ReadItem()
        {
            

            string creatureAsText = Preferences.Get("MyCreature", "");

            Creature creatureFromText = JsonConvert.DeserializeObject<Creature>(creatureAsText);

            return Task.FromResult(creatureFromText);
        }
        public Task<bool> UpdateItem(Creature item)
        {
           
            if (Preferences.ContainsKey("MyCreature"))
            {
                string creatureAsText = JsonConvert.SerializeObject(item);

                Preferences.Set("MyCreature", creatureAsText);

                return Task.FromResult(true);
            }
            
            return Task.FromResult(false);
        }

        public Task<bool> DeleteItem(Creature item)
        {
            Preferences.Remove("MyCreature");

            return Task.FromResult(true);

        }
    }
}
