using System;

namespace CarDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Delegates as event enablers *****\n");
            Car c1 = new Car("SlugBug", 100, 10);
            // Сообщить объекту Car, какой метод вызывать,
            // когда он пожелает отправить сообщение
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            // зарегистрировал второй обработчик событий
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent2));
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
        }
        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg.ToUpper());
            Console.WriteLine("************************************\n");
        }

        public static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("=> {0}", msg);
        }
    }
}
