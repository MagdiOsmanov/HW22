using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HW22
{
    class Program
    {

        static void SumArray(Task task,object a)
        {
            int[] items = (int[])a;
            int sum = 0;
            for (int i = 0; i < items.Length; i++)
            {
                sum += items[i];
                Thread.Sleep(1);
            }
            Console.WriteLine($"Сумма чисел массива {sum}");
        }
        static public int MaxArray(int[] items)
        {
            int Max = 0;
            for (int i = 0; i < items.Length; i++)
            {
                if (Max<items[i])
                {
                    Max = items[i];
                    
                    Thread.Sleep(1);
                }
                
            }
            Console.WriteLine($"Максимум {Max}");
            return Max;
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Random math = new Random();
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = math.Next(0, 15);
                Console.Write("{0} ",array[i]);
            }
            Console.WriteLine();
            Task task1 = new Task(() => MaxArray(array));
            task1.Start();
            Action<Task, object> actionTask = new Action<Task, object>(SumArray);
            Task task2 = task1.ContinueWith(actionTask, array);

            Console.ReadKey();
        }
    }
}
