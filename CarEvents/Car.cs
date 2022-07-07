﻿using System;
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

        //// Определить переменную-член этого типа делегата
        //private CarEngineHandler listOfHandlers;
        //// Добавить регистрационную функцию для вызывающего кода
        //public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        //{
        //    listOfHandlers += methodToCall;
        //}
        //// удалить обработчик
        //public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        //{
        //    listOfHandlers -= methodToCall;
        //}
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
                if (Exploded != null)
                    Exploded("Sorry, this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;
                // Автомобиль почти сломан?
                if (10==(MaxSpeed-CurrentSpeed) && AboutToBlow!=null)
                {
                    AboutToBlow("Careful buddy! Gonna blow!");
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
