using Lab9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    internal class RunnerArray
    {
        private Runner[] arr;
        private static int collectionCount = 0;

        public static int CollectionCount
        {
            get { return collectionCount; }
        }

        public RunnerArray()
        {
            arr = Array.Empty<Runner>();
            collectionCount++;
        }

        public RunnerArray(int size)
        {
            if (size < 0) throw new ArgumentOutOfRangeException("Размер массива должен быть больше нуля");
            arr = new Runner[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = new Runner(random.Next(1, 100), random.Next(1, 100));
            }
            collectionCount++;
        }


        public RunnerArray(RunnerArray other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other), "Коллекция не может быть null");

            arr = new Runner[other.arr.Length];
            for (int i = 0; i < other.arr.Length; i++)
            {
                arr[i] = new Runner(other.arr[i]); // Глубокое копирование
            }
            collectionCount++;
        }

        public void PrintRunners()
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("Коллекция пуста");
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"[{i}]: {arr[i]}");
            }
        }

        public Runner this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException("Индекс за пределами массива");
                return arr[index];
            }
            set
            {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException("Индекс за пределами массива");
                arr[index] = value;
            }
        }

        public void SortRunners()
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("Массив пуст, сортировка невозможна");
                return;
            }

            arr = arr.OrderByDescending(runner => runner.Distance)
                        .ThenBy(runner => runner.Time())
                        .ToArray();
        }
    }
}

