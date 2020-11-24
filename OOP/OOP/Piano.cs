using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class Piano : Musical_instrument
    {
        public bool piano_pedals;//педали - истинно для фортепиано
        public Piano(string name, string brand, int price, bool mobility, bool piano_pedals) : base(name, brand, price, mobility)
        {
            this.piano_pedals = piano_pedals;
        }

        public override void Sound()//реализация абстрактного метода
        {
            Console.WriteLine("Фортепиано звучит");
        }
    }
}
