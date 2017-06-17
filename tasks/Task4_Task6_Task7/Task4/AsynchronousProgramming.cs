using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace Task4
{
    class AsynchronousProgramming
    {
        public static void Run(Mitarbeiter[] person)
        {
            foreach (var x in person)
            {
                Console.WriteLine($"received value: {x.EmployeeSalary}");
                var task1 = Task.Run(() =>
                {
                    Console.WriteLine($"employee's name: {x.EmployeeName}");
                    x.EmployeeSalary = x.EmployeeSalary+100;
                    Console.WriteLine($"modified value: {x.EmployeeSalary}");
                });
                task1.ContinueWith(y => Console.WriteLine($"Object {person} converted successfully!\n"));
            }
            Console.WriteLine("Doing something else .. \n");
            var task2 = Task.Run(() =>
            {
                int i = 100;
                while (i >= 0)
                {
                    i--;
                    Task.Delay(1000).Wait();
                    Console.WriteLine($"Returned value: [{i}]\n");          
                }
                return i;

            });
            task2.ContinueWith(r => Console.WriteLine($"The answer is {r.Result}"));

            Task<int> futureLength = GetEmployeesNameLengthAsync(person);

            Console.ReadLine();
        }   
        public static async Task<int> GetEmployeesNameLengthAsync(Mitarbeiter[]person)
        {
            int value=0;
            foreach(var x in person)
            {
                value = x.EmployeeName.Length;
                await Task.Delay(1000);
                Console.WriteLine($"Total length of the employee's name is: {value}");
            }
            return value;
        }   
    }
}


