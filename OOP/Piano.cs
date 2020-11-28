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

        public override bool Equals(object obj)//переопределение метода Equals
        {
            return obj is Piano piano &&
                   name.Contains(piano.name) &&
                   mobility == piano.mobility &&
                   piano_pedals == piano.piano_pedals;
        }

        public override void Sound()//реализация абстрактного метода
        {
            Console.WriteLine("Фортепиано звучит");
        }
        public override string ToString()//переопределение метода ToString
        {
            return String.Format("Музыкальный инструмент: название - {0}, бренд - {1}, цена = {2}, мобильность = {3}, наличие педалей = {4}", this.name,this.brand,this.price,this.mobility,this.piano_pedals);
        }
        
    }
}
