using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tasks
{
    class Program
    {
        static void ShowTaskWork()
        {
            Console.WriteLine("Метод ShowTaskWork начал работу...в потоке "+Thread.CurrentThread.ManagedThreadId);
            // имитация длительной и плодотворной работы метода
            Thread.Sleep(5000);
            Console.WriteLine("Метод ShowTaskWork завершил работу! в потоке " + Thread.CurrentThread.ManagedThreadId);
        }

        static void Main(string[] args)
        {
            //Task task = new Task(ShowTaskWork);
            //task.Start();
            //Console.WriteLine("Выполняется мето Main в потоке "+Thread.CurrentThread.ManagedThreadId);
            //Task tus1 = Task.Run(() => { Console.WriteLine("Ещё одна операция в потоке " + Thread.CurrentThread.ManagedThreadId); });
            //Task tsk2 = Task.Factory.StartNew(()=> { Console.WriteLine("Ещё одно действие " + Thread.CurrentThread.ManagedThreadId); });
            //task.Wait();
            //Console.WriteLine("Метод main зваершил свою работу");
            //Parallel.Invoke(ShowTaskWork, () =>
            //{
            //    Console.WriteLine("Метод Anonim начал свою работу в потоке "+Thread.CurrentThread.ManagedThreadId );
            //    Thread.Sleep(5000);
            //    Console.WriteLine("Метод Anonim завершил свою работу в потоку "+Thread.CurrentThread.ManagedThreadId);
            //},ShowTaskWork);
            //Возвращение результата из задачи
            Task<int> taskInt = new Task<int>(() =>
              {
                  Console.WriteLine("Выполняется суммирование в потоке "+Thread.CurrentThread.ManagedThreadId);
                  int sum = 0;
                  for(int i=0;i<=125;i++)
                  {
                      sum += i;
                      Thread.Sleep(100);
                  }
                  Console.WriteLine("Метод завершил суммирование в потоке "+Thread.CurrentThread.ManagedThreadId);
                  return sum;
              });
            //taskInt.Start();
            //Console.WriteLine("Мы в Main'e");
            //int sum1 = taskInt.Result;
            //Console.WriteLine(sum1);
            SumDisplayAsync(taskInt);
            Console.WriteLine("Метод main зваершил свою работу в потоке " + Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }
        static async void SumDisplayAsync(Task<int> t)
        {
            Console.WriteLine("Метод SumDisplayAsync начал работу в потоке " + Thread.CurrentThread.ManagedThreadId);
            t.Start();
            int res=await Task.Run(() => t);
            Console.WriteLine("Продолжение метода SumDisplayAsync в потоке "+Thread.CurrentThread.ManagedThreadId);
            //int res1 = await Task.Run(() => t);
            Console.WriteLine("Сумма чисел от 0 до 125 = "+res);
            //Console.WriteLine("Сумма чисел от 0 до 125 = " + res1);
        }
    }
}
