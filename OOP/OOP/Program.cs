using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Musical_instrument Git1 = new Guitar("Guitar-25", "Yamaha", 25000, true, 6);
            //Musical_instrument UP1 = new Piano("Piano_1", "Casio", 70000, true, true);
            //Guitar Git2 = new Guitar("Guitar-10", "Fender", 50000, true, 7);
            //Classical Git3 = new Classical("Guitar-14", "Denn", 10000, true, 6, true);
            //Guitar Git4 = new Electric("Guitar-12", "Yamaha", 90000, true, 12, true);
            //Guitar Git5 = new Classical("Guitar-7", "Fender", 30000, true, 7, true);
            //Git1.Sound();
            //UP1.Sound();
            //Git2.Sound_Sourse();
            //Git3.Sound_Sourse();
            //Git4.Sound_Sourse();
            //Git5.Sound_Sourse();
            Piano UP2 = new Piano("Piano25", "Casio", 50000, false, true);
            Console.WriteLine(UP2.ToString());//вызов переопределенного метода ToString
            Piano UP3 = new Piano("Piano25", "Casio", 50000, true, true);
            Piano UP4 = new Piano("Piano25", "Casio", 50000, false, true);
            Piano UP5 = new Piano("Piano25", "Yamaha", 2000, false, true);
            Console.WriteLine(UP3.Equals(UP4));//вызов переопределенного метода Equals
            Console.WriteLine(UP4.Equals(UP5));//вызов переопределенного метода Equals

        }
    }
}
