using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    public class Car
    {
        // Этот делегат работает в сочетании с событиями Car.
        public delegate void CarEngineHandler(string msgForCaller);

        // Car может отправлять следующие события:
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }
        // исправен ли автомобиль
        private bool carIsDead;

        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }
        // Реализовать метод Accelerate() для обращения к списку
        // вызовов делегата в подходящих обстоятельствах
        public void Accelerate(int delta)
        {
            // Если автомобиль сломан, то отправить сообщение об этом
            if (carIsDead)
            {
                Exploded?.Invoke("Sorry, this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;
                // Автомобиль почти сломан?
                if (10==MaxSpeed-CurrentSpeed)
                {
                    AboutToBlow?.Invoke("Careful buddy! Gonna blow!");
                }
                // Все ещё в порядке!
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}",CurrentSpeed);
            }
        }
    }
}
