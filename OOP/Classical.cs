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
        public override string ToString()
        {
            return String.Format("Классическая гитара: название - {0}, бренд - {1}, цена = {2}, мобильность = {3}, количество струн = {4}, наличие резонатора = {5}", this.name, this.brand, this.price, this.mobility, this.number_of_strings, this.resonator_hole);
        }

      
    }
}
