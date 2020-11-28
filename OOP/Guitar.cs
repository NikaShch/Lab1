using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class Guitar  : Musical_instrument
    {
        public int number_of_strings;//количество струн;
        
        public Guitar(string name, string brand, int price, bool mobility, int number_of_string) : base(name, brand, price, mobility)
        {
            this.number_of_strings = number_of_strings;
        }

        public override void Sound()//реализация абстрактного метода 
        {
            Console.WriteLine("Гитара звучит");
        }
        public virtual void Sound_Sourse()//виртуальный метод источник звука гитары
        {
            Console.WriteLine("Источник звука");
        }
    }
}
