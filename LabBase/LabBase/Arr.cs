using System;
using System.Collections.Generic;
using System.Text;

namespace LabBase
{
    class Arr
    {
        public static void Met1()
        {
            int n;
            Console.Write("Введите число элементов массива: ");
            n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Введите arr[{0}] ", i + 1);
                arr[i] = int.Parse(Console.ReadLine());
            }
            int temp;
            for (int i = 0; i< arr.Length-1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            Console.WriteLine("Отсортированный массив: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadLine();
        }
    }

}
