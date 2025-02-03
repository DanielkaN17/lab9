using Lab9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class RunnerArray
    {
        private Runner[] arr;
        private static int collectionCount = 0;

        public static int CollectionCount
        {
            get { return collectionCount; }
        }

        /// <summary>
        /// Конструктор без параметров. Длина массива равна 1
        /// </summary>
        public RunnerArray() : this(1) { }

        /// <summary>
        /// Конструктор с параметром, задает размер массива. Заполняем массив случайными числами
        /// </summary>
        /// <param name="size">Размер массива должен быть больше нуля</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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


        /// <summary>
        /// Конструктор копирования (глубокое копирование)
        /// </summary>
        /// <param name="other">Коллекция, которую нужно скопировать</param>
        /// <exception cref="ArgumentNullException">Ошибка, если коллекция равна нулю</exception>
        public RunnerArray(RunnerArray other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other), "Коллекция не может быть равна нулю");

            arr = new Runner[other.arr.Length];
            for (int i = 0; i < other.arr.Length; i++)
            {
                arr[i] = new Runner(other.arr[i]); // Глубокое копирование
            }
            collectionCount++;
        }

        /// <summary>
        /// Индексатор для доступа к элементам массива. Обеспечивает проверку границ
        /// </summary>
        /// <param name="index">Индекс элемента</param>
        /// <returns>Объект Runner по указанному индексу</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Runner this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException("Число за пределами массива");
                return arr[index];
            }
            set
            {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException("Число за пределами массива");
                arr[index] = value;
            }
        }

        /// <summary>
        /// Выводит информацию о всех бегунах в коллекции на консоль
        /// </summary>
        public void PrintRunner()
        {
            if (arr.Length == 0 || arr == null)
            {
                Console.WriteLine("Коллекция пуста");
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Бегун {i+1}: {arr[i]}");
            }
        }
        
        /// <summary>
        /// Сортировка массива по расстоянию, после по скорости (по убыванию)
        /// </summary>
        public void SortRunners()
        {
            if (arr == null)
            {
                Console.WriteLine("Массив не создан, сортировка невозможна");
                return;
            }

            if (arr.Length == 0)
            {
                Console.WriteLine("Массив пуст, сортировка невозможна");
                return;
            }

            Array.Sort(arr, (x,y) =>
            {
                int distanceComparison = y.Distance.CompareTo(x.Distance);
                return distanceComparison != 0 ? distanceComparison : x.CalculatingTime().CompareTo(y.CalculatingTime());  
            });
        }
    }
}

