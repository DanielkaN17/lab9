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

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="distance"></param>
        public Runner(double speed, double distance)
        {
            Speed = speed;
            Distance = distance;
            objectCount++;
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Runner() : this(1, 1) 
        {
        }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="r"></param>
        public Runner(Runner r) : this(r.speed, r.distance)
        {
        }

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        public double Distance
        {
            get => distance;
            set {
                if (value < 0)
                    throw new ArgumentException("Расстояние не может быть отрицательным");
                    distance = value;
                }
        }

        /// <summary>
        /// Вычисление времени
        /// </summary>
        /// <returns>Время в часах, округление до двух знаков после запятой</returns>
        /// <exception cref="InvalidOperationException">Выдает ошибку, если скорость равна нулю</exception>
        public double CalculatingTime()
        {
            if (speed == 0) throw new InvalidOperationException("Скорость не может быть равна нулю.");
            return Math.Round(distance / speed, 2);
        }

        /// <summary>
        /// Вычисление времени на основе переданной сокрости и расстояния
        /// </summary>
        /// <param name="speed">Скорость бегуна</param>
        /// <param name="distance">Расстояние, которое нужно преодолеть</param>
        /// <returns>Время в часах, округление до двух знаков после запятой</returns>
        /// <exception cref="ArgumentException">Выдает ошибку, если скорость равна нулю</exception>
        public static double TimeStatic(double speed, double distance)
        {
            if (speed == 0) throw new ArgumentException("Скорость не может быть равна нулю.");
            return Math.Round(distance / speed, 2);
        }

        /// <summary>
        /// Вычисление времени на основе объекта Runner
        /// </summary>
        /// <param name="runner">Объект Runner</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Выдает ошибку, если объект равен null</exception>
        /// <exception cref="InvalidOperationException">Выдает ошибку, если скорость равна нулю</exception>
        public static double TimeStatic(Runner runner)
        {
            if (runner == null) throw new ArgumentNullException(nameof(runner), "Передан пустой объект");
            if (runner.Speed == 0) throw new InvalidOperationException("Скорость не может быть равна нулю");
            return Math.Round(runner.Distance / runner.Speed, 2);
        }

        /// <summary>
        /// Возвращает все значения о бегуне
        /// </summary>
        /// <returns>Строка с информацией о расстоянии, скорости и времени</returns>
        public override string ToString()
        {
            return $"Расстояние: {distance} км, Скорость: {speed} км/ч,  Время: {CalculatingTime()} ч.";
        }

        /// <summary>
        /// Перегруженный оператор инкремента 
        /// </summary>
        /// <param name="runner">Объект Runner</param>
        /// <returns>Обновленный объект Runner</returns>
        public static Runner operator ++(Runner runner)
        {
            runner.Distance += 0.1;
            return runner;
        }

        /// <summary>
        /// Перегруженный оператор декремента
        /// </summary>
        /// <param name="runner">Объект Runner</param>
        /// <returns>Обновленный объект Runner</returns>
        /// <exception cref="ArgumentException">Выдает ошибку, если скорость становится меньше нуля</exception>
        public static Runner operator --(Runner runner)
        {
            if (runner.Speed - 0.05 < 0)
            {
                throw new ArgumentException("Скорость не может быть меньше 0");
            }

            runner.Speed -= 0.05;
            return runner;
        }

        /// <summary>
        /// Преобразование объекта Runner в double для вычисления разности в скорости
        /// </summary>
        /// <param name="runner">Объект Runner</param>
        public static explicit operator double(Runner runner)
        {
            if (runner.Speed <= 0) throw new ArgumentException("Скорость должна быть больше нуля.");
            double currentTime = runner.CalculatingTime();
            double targetTime = currentTime * 0.95; // 5% сокращение времени
            return Math.Round((runner.distance / targetTime) - runner.speed, 2);

        }

        /// <summary>
        /// Конвертирование объекта Runner в строку "чч:мм:сс"
        /// </summary>
        /// <param name="runner">Объект Runner, который необходимо преобразовать в строку</param>
        public static implicit operator string(Runner runner)
        {
            if (runner.Speed <= 0) throw new ArgumentException("Скорость должна быть больше нуля.");
            double totalSeconds = runner.CalculatingTime() * 3600;
            int hours = (int)(totalSeconds / 3600);
            int minutes = (int)((totalSeconds % 3600) / 60);
            int seconds = (int)(totalSeconds % 60);

            return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }

        /// <summary>
        /// Вычисление расстояние бегунов, при котором они встретяться
        /// при условии, что они бегут навстречу друг другу
        /// </summary>
        /// <param name="r1">Первый бегун</param>
        /// <param name="r2">Второй бегун</param>
        /// <returns>Расстояние, на котором они встретяться, либо -1, если не встретятся</returns>
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

        /// <summary>
        /// Увеличение скорости бегуна на заданное значение
        /// </summary>
        /// <param name="r">Бегун, скорость которого будет увеличена</param>
        /// <param name="speedIncrease">Значение, на которое будет увеличена скорость</param>
        /// <returns>Новый объект Runner с увеличенной скоростью</returns>
        public static Runner operator ^(Runner r, double speedIncrease)
        {
            return new Runner(r.Speed + speedIncrease, r.Distance);
        }

        /// <summary>
        /// Сравнение объектов Runner
        /// </summary>
        /// <param name="obj">Объект для сравнения с текущим объектом</param>
        /// <returns>Если объекты равны - true, иначе false</returns>
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
