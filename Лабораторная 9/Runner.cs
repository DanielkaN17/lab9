using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab9
{
    public class Runner
    {
        private double speed;
        private double distance;
        private static int objectCount = 0; // Статическая переменная для подсчета объектов

        public static int ObjectCount 
        {
            get { return objectCount; }
        }

        // Конструктор с параметрами
        public Runner(double speed, double distance)
        {
            Speed = speed;
            Distance = distance;
            objectCount++;
        }

        // Конструктор без параметров
        public Runner() : this(1, 1) 
        {
        }

        // Конструктор копирования
        public Runner(Runner r) : this(r.speed, r.distance)
        {
        }

        // Свойства
        public double Speed
        {
            get => speed;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Скорость не может быть отрицательна");
                }
                speed = value;
            }
        }

        public double Distance
        {
            get => distance;
            set {
                if (value < 0)
                    throw new ArgumentException("Расстояние не может быть отрицательным");
                    distance = value;
                }
        }

        // Метод для вычисления времени
        public double CalculatingTime()
        {
            if (speed == 0) throw new InvalidOperationException("Скорость не может быть равна нулю.");
            return Math.Round(distance / speed, 2);
        }

        //Статическая функция для вычисления времени
        public static double TimeStatic(double speed, double distance)
        {
            if (speed == 0) throw new ArgumentException("Скорость не может быть равна нулю.");
            return Math.Round(distance / speed, 2);
        }

        public static double TimeStatic(Runner runner)
        {
            if (runner == null) throw new ArgumentNullException(nameof(runner), "Передан пустой объект");
            if (runner.Speed == 0) throw new InvalidOperationException("Скорость не может быть равна нулю");
            return Math.Round(runner.Distance / runner.Speed, 2);
        }

        // Метод для вывода информации
        public override string ToString()
        {
            return $"Скорость: {speed} км/ч, Расстояние: {distance} км, Время: {Time()} ч.";
        }

        // Унарные операции
        public static Runner operator ++(Runner runner)
        {
            runner.Distance += 0.1;
            return runner;
        }

        public static Runner operator --(Runner runner)
        {
            if (runner.Speed - 0.05 < 0)
            {
                throw new ArgumentException("Скорость не может быть меньше 0");
            }

            runner.Speed -= 0.05;
            return runner;
        }

        // Операции приведения типа

        public static explicit operator double(Runner runner)
        {
            if (runner.Speed <= 0) throw new ArgumentException("Скорость должна быть больше нуля.");
            double currentTime = runner.Time();
            double targetTime = currentTime * 0.95; // 5% сокращение времени
            return Math.Round((runner.distance / targetTime) - runner.speed, 2);

        }

        public static implicit operator string(Runner runner)
        {
            if (runner.Speed <= 0) throw new ArgumentException("Скорость должна быть больше нуля.");
            double totalSeconds = runner.Time() * 3600;
            int hours = (int)(totalSeconds / 3600);
            int minutes = (int)((totalSeconds % 3600) / 60);
            int seconds = (int)(totalSeconds % 60);

            return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }

        // Бинарные операции
        public static double operator -(Runner r1, Runner r2)
        {
            if (r1.Speed <= 0 || r2.Speed <= 0)
            {
                return -1; // Если скорость одного из бегунов равна 0, то они не встретятся
            }

            double meetingTime = 15 / (r1.Speed + r2.Speed);
            double distanceR1 = r1.Speed * meetingTime;
            if (distanceR1 > 15) return -1;
            return Math.Round(distanceR1, 2);
        }

        public static Runner operator ^(Runner r, double speedIncrease)
        {
            return new Runner(r.Speed + speedIncrease, r.Distance);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Runner other = (Runner)obj;
            return speed == other.speed && distance == other.distance;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Speed, Distance);
        }
    }
}
