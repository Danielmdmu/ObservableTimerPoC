using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ObservableTimerOnOff
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var update = new Subject<bool>();

            var res = update.Select(x => Observable.Interval(TimeSpan.FromSeconds(3))).Switch();

            res.Subscribe(_ => Console.WriteLine("Ping"));

            var exitApp = false;

            while (!exitApp)
            {
                Console.Write("Turn off Timer with 'x' turn on with 't' exit with 'q'");

                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.X:
                        update.OnNext(false);
                        break;

                    case ConsoleKey.Q:
                        exitApp = true;
                        break;

                    case ConsoleKey.T:
                        update.OnNext(true);
                        break;

                    default:

                        break;
                }
            }
        }
    }
}