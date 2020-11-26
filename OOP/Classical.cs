using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class Classical : Guitar 
    {
        public bool resonator_hole;//резонатор, отверстие истинно для классической гитары 
        public Classical(string name, string brand, int price, bool mobility, int number_of_string, bool resonator_hole) : base(name, brand, price, mobility, number_of_string)
        {
            this.resonator_hole = resonator_hole;
        }
        public override void Sound_Sourse()
        {
            Console.WriteLine("Источник звука в классической гитаре - розетка");
        }
    }
}
