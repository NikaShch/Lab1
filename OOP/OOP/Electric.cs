
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class  Electric : Guitar
    {
        public bool pickup;//звукосниматель - истинно для электрогитары

        public Electric(string name, string brand, int price, bool mobility, int number_of_string, bool pickup) : base(name, brand, price, mobility, number_of_string)
        {
            this.pickup = pickup;
        }
        public override void Sound_Sourse()
        {
            Console.WriteLine("Источник звука в электрогитаре - звукосниматель");
        }
    }
}
