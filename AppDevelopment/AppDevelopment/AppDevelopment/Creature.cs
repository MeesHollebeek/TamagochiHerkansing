using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Tamagotchi;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamagotchi
{
	public class Creature : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public string Name { get; set; }
		public float Thirst { get; set; } 
		public float Boredom { get; set; } 
		public float Hunger { get; set; }
		public float Tired { get; set; }
		public Creature()
		{
			Hunger = 0.0f;
			Thirst = 0.0f;
			Boredom = 0.0f;
			Tired = 1.0f;
		}
	
		public void LowerStats()
		{
			float rate = 0.005f;
			Hunger -= rate;
			Thirst -= rate;
			Boredom -= rate;
		}

		public void UpdateStat(float stat)
		{
			Console.WriteLine(Hunger);
			if (stat < 0)
			{
				stat = 0;
			}
			if (stat > 1)
			{
				stat = 1;
			}
		}

	}


	

    
}
