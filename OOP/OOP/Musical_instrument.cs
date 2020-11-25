using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    abstract class Musical_instrument//абстрактный класс музыкальный инструмент
    {
        public string name;//наименование
        public string brand;//бренд музыкального инструмента
        public int price;//цена
        public bool mobility;//мобильность 
        public Musical_instrument(string name, string brand, int price, bool mobility)//конструктор
        {
            this.name = name;
            this.brand = brand;
            this.price = price;
            this.mobility = mobility;
        }
        public abstract void Sound();//абстрактный метод - звучание музыкального инструмента
    }
}
