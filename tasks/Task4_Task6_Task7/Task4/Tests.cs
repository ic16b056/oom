using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task4;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void SalaryHasBeenIncreased()
        {
            var x = new Mitarbeiter("Max Mustermann", 94, "AT51021478521", 2041, 1600);
            x.printData();
            Assert.IsTrue(x.EmployeeSalary == 1900);
        }

        [Test]
        public void CannotIncreaseSalary()
        {
            var x = new Mitarbeiter("Max Mustermann", 92, "AT51021478521", 2041, 1600);
            x.printData();
            Assert.IsFalse(x.EmployeeSalary == 1900);
        }

        [Test]
        public void CanCreateMitarbeiter()
        {
            var x = new Mitarbeiter("Max Mustermann", 82, "AT51021478521", 2041, 1600);
            Assert.IsTrue(x.EmployeeName == "Max Mustermann");
            Assert.IsTrue(x.EmployeePerformance == 82);
            Assert.IsTrue(x.EmployeeIBAN == "AT51021478521");
            Assert.IsTrue(x.EmployeeID == 2041);
            Assert.IsTrue(x.EmployeeSalary == 1600);
        }

        [Test]
        public void CannotCreateEmployeeWithInvalidID()
        {
            Assert.Catch(() =>
            {
                var x = new Mitarbeiter("Phil Morris", 94, "AT51021478521", 128, 3800);
            });
        }

        [Test]
        public void CannotCreateEmployeeWithEmptyName1()
        {
            Assert.Catch(() =>
            {
                var x = new Mitarbeiter("", 94, "AT51021478521", 4712, 3800);
            });
        }

        [Test]
        public void CannotCreateEmployeeWithEmptyName2()
        {
            Assert.Catch(() =>
            {
                var x = new Mitarbeiter(null, 72, "AT51030298231", 4210, 2800);
            });
        }
        [Test]
        public void CannotCreateDepartment()
        {
            Assert.Catch(() =>
            {
                var y = new Abteilung("", 84, 4);
            });
        }
        [Test]
        public void VerifyIncrementOfCounter()
        {
            var x = new Mitarbeiter("Max Mustermann", 82, "AT51021478521", 2041, 1600);
            Assert.IsTrue(x.Value !=0);
        }
    }
}
