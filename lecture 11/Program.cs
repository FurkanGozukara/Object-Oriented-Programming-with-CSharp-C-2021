using System;
using System.Collections;
using System.Collections.Generic;

namespace lecture_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee firstEmployee = new Employee(1, "furkan", 100);
           
            Employees EmpList = new Employees();
            Employee e1 = new Employee(1, "Employee#1", 1250.75);
            Employee e2 = new Employee(2, "Employee#2", 1275.85);
            EmpList.AddEmployee(e1);
            EmpList.AddEmployee(e2);

            IEnumerator EmpEnumerator = EmpList.GetEnumerator();
            EmpEnumerator.Reset();
            while (EmpEnumerator.MoveNext())
            {
                Console.WriteLine((Employee)EmpEnumerator.Current);
            }

            foreach (int i in Power(2, 8))
            {
                Console.WriteLine(i);
            }

            ShowGalaxies();

        }

        public static IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                //if (result > 100)
                //    break;//this will only break for loop and method will continue
                if (result > 100)
                    yield break;//equal to return therefore not prints break
                yield return result;
            }

            Console.WriteLine("  break;");
        }

        class Employee
        {
            private int Id;
            private string Name;
            private double Salary;
            public Employee(int id, string name, double salary)//after we compose an instance of object, the id is not setable again
            {
                this.Id = id;
                this.Name = name;
                this.Salary = salary;
            }
            public int ID//this is only get not setable
            {
                get
                {
                    return this.Id;
                }
            }
            public override string ToString()
            {
                return "Id: " + this.Id.ToString() + "\tName: " + Name + "\tSalary: " + Salary.ToString();
            }
        }

        class Employees : IEnumerable, IEnumerator
        {
            ArrayList EmpList = new ArrayList();//there is no explicit type such as string int etc in arraylist
            private int Position = -1;
            public void AddEmployee(Employee oEmp)
            {
                EmpList.Add(oEmp);
            }
            /* Needed since Implementing IEnumerable*/
            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)this;
            }
            /* Needed since Implementing IEnumerator*/
            public bool MoveNext()
            {
                if (Position < EmpList.Count - 1)
                {
                    ++Position;
                    return true;
                }
                return false;
            }
            public void Reset()
            {
                Position = -1;
            }
            public object Current
            {
                get
                {
                    return EmpList[Position];
                }
            }
        }

        public class Galaxies
        {
            public IEnumerable<Galaxy> NextGalaxy//this is IEnumerable property
            {
                get
                {
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                }
            }
        }

        public class Galaxy
        {
            public String Name { get; set; }
            public int MegaLightYears { get; set; }
        }

        public static void ShowGalaxies()
        {
            var theGalaxies = new Galaxies();
            foreach (Galaxy theGalaxy in theGalaxies.NextGalaxy)
            {
                Console.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears.ToString());
            }
        }
    }
}
