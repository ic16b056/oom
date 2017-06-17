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
    class PushExamplesSubject
    {
        public static void Run(Mitarbeiter [] workers)
        {
            var data_producer = new Subject<Mitarbeiter>();

            data_producer
                .Where(p => p.EmployeeSalary >20000)
                .Subscribe(x => Console.WriteLine($"received employee's salary amount: {x.EmployeeName} earns [{x.EmployeeSalary}]EUR\n"));

            data_producer
                .Select(y => y.EmployeePerformance)
                .Take(1) //only interested in the first employee's performance
                .Subscribe(y => Console.WriteLine($"received the first employee's performance progress: {y}\n"));

            foreach (var emp in workers)
                data_producer.OnNext(emp);
        }
    }
}
