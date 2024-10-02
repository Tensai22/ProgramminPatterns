using System;


namespace Name
{
    class Program
    {
        public static void Main() 
        {
            Permanent emp1 = new("Nurbek", 800000);
            Contract emp2 = new("Aidos", 650000);
            Intern emp3 = new("Aiaru", 400000);

            emp1.CalculateSalary();
            emp2.CalculateSalary();
            emp3.CalculateSalary();

        }
    }
    public abstract class Employee(string Name, double BaseSalary){
        public string Name { get; set; } = Name;
        public double BaseSalary { get; set; } = BaseSalary;
    }

    public class Permanent : Employee{
        public Permanent(string Name, double BaseSalary) : base(Name, BaseSalary){}

        public void CalculateSalary(){
                Console.WriteLine(BaseSalary * 1.2); 
        }
    }
    public class Contract : Employee{
        public Contract(string Name, double BaseSalary) : base(Name, BaseSalary){}

        public void CalculateSalary(){
                Console.WriteLine(BaseSalary * 1.1); 
        }
    }
    public class Intern : Employee{
        public Intern(string Name, double BaseSalary) : base(Name, BaseSalary){}
        public void CalculateSalary(){
                Console.WriteLine(BaseSalary * 0.8);
        }
    }
}

