
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class  Electric <T> : Guitar //обобщенный класс
    {
        public bool pickup;//звукосниматель - истинно для электрогитары
        public T weight;//вес T - обобщенный тип
        public Electric(string name, string brand, int price, bool mobility, int number_of_string, bool pickup, T weight) : base(name, brand, price, mobility, number_of_string)
        {
            this.pickup = pickup;
            this.weight = weight;
        }
        public override void Sound_Sourse()
        {
            Console.WriteLine("Источник звука в электрогитаре - звукосниматель");
        }
    }
}
