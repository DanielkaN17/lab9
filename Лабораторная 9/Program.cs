namespace Lab9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Часть 1
                Console.WriteLine("Часть 1: Демонстрация класса Runner");
                Runner r1 = new Runner();
                Console.WriteLine(r1);

                Runner r2 = new Runner(52, 38);
                Console.WriteLine(r2);
                double timeStatic2 = Runner.TimeStatic(r2);
                Console.WriteLine($"Время (статическая функция): {timeStatic2} ч.");

                Runner r3 = new Runner(r1);
                r3.Speed = 33; 
                r3.Distance = 44; 
                Console.WriteLine(r3);

                // Статическая функция
                double timeStatic = Runner.TimeStatic(33, 44);
                Console.WriteLine($"Время (статическая функция): {timeStatic} ч.");

                // Нестатический метод
                double timeMethod = r2.CalculatingTime();
                Console.WriteLine($"Время (метод класса): {timeMethod} ч.");

                // Вывод количества созданных объектов
                Console.WriteLine($"Количество созданных объектов: {Runner.ObjectCount}");

                // Часть 2
                Console.WriteLine("\nЧасть 2: Демонстрация перегруженных операций");

                // Унарные операции
                Console.WriteLine($"Исходный бегун: {r2}");
                r2++;
                Console.WriteLine($"После ++: {r2}");
                r2--;
                Console.WriteLine($"После --: {r2}");

                // Операция приведения к double
                double speedIncrease = (double)r2;
                Console.WriteLine($"Необходимо увеличить скорость на {speedIncrease} км/ч, чтобы сократить время на 5%");

                // Операция неявного приведения к string
                string timeString = (string)r2;
                Console.WriteLine($"Время в формате ЧЧ:ММ:СС: {timeString}");


                // Бинарные операции
                Runner r4 = new Runner(10, 0);
                Runner r5 = new Runner(5, 0);
                double meetingDistance = r4 - r5;
                if (meetingDistance == -1)
                    Console.WriteLine("Бегуны не встретятся");
                else
                    Console.WriteLine($"Расстояние до встречи бегунов: {meetingDistance} км.");
                Runner r6 = r2 ^ 10;
                Console.WriteLine($"Бегун с увеличенной скоростью: {r6}");
                
                // Часть 3
                Console.WriteLine("\nЧасть 3: Демонстрация класса RunnerArray");




            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Конец работы");
            }

        }
    }
}


