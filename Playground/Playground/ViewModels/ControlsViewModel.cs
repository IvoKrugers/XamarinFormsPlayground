using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Playground.ViewModels
{
    class ControlsViewModel : BaseViewModel
    {
        public class Item
        {
            public string Artist { get; set; }
            public string Song { get; set; }
            public string Lyrics { get; set; }
        }

        public ObservableCollection<Item> Items { get; private set; }

        public ICommand CarouselItemTappedCommand { get; } 
            = new Command(() =>
        {
            Debug.WriteLine("Item Clicked");
        });

        public ControlsViewModel()
        {
            Title = "MyControls";

            Items = new ObservableCollection<Item>()
            {
                new Item {Artist="Massive Attack", Song="Teardrop", Lyrics=$"Love, love is a verb\nLove is a doing word\nFearless on my breath\nGentle impulsion" },
                new Item {Artist="Red Hot Chilly Peppers", Song="Suck my kiss" , Lyrics= $"Should of been, could of been\nWould of been dead\nIf I didn't get the message" },
                new Item {Artist="Suicidal Tendencies", Song="Institutionalised" , Lyrics= $"Sometimes I try to do things\nAnd it just doesn't work out the way I wanted to\nAnd I get real frustrated" },
            };
        }

    }
}
