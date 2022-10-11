using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace дк4_2
{
    class Car
    {
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int MaxSpeed { get; set; }
        public Car(string Name, int ProductionYear, int MaxSpeed)
        {
            this.Name = Name;
            this.ProductionYear = ProductionYear;
            this.MaxSpeed = MaxSpeed;
        }
        public void print()
        {
            Console.WriteLine($"Name: {Name} ProductionYear: {ProductionYear} MaxSpeed: {MaxSpeed}");
        }
    }
        public enum CarComparerType // перечисление
        {
            Name,
            ProductionYear,
            MaxSpeed
        }
    
     class CarComparer : IComparer<Car>
    {
        private CarComparerType _CarComparerType;
        public CarComparer(CarComparerType CarComparerType)
        {
            _CarComparerType = CarComparerType;
        }

        public int Compare(Car c1, Car c2)//sort
        {
            if (_CarComparerType == CarComparerType.Name)
            {
                 return c1.Name.CompareTo(c2.Name);
            }
            if (_CarComparerType == CarComparerType.ProductionYear)
            {
                 return c1.ProductionYear.CompareTo(c2.ProductionYear);
                           }
            if (_CarComparerType == CarComparerType.MaxSpeed)
            {
                return c1.MaxSpeed.CompareTo(c2.MaxSpeed);
               }
            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("audi", 2020, 150);
            Car car2 = new Car("mers", 2022, 180);
            Car car3 = new Car("bmw", 2017, 120);
            List<Car> lis = new List<Car> { car1, car2, car3 };
            lis.Sort(new CarComparer(CarComparerType.Name));
            Console.WriteLine("Sorrt on name");
            for(int i = 0; i < 3; i++)
            {
                lis[i].print();
            }
            lis.Sort(new CarComparer(CarComparerType.ProductionYear));
            Console.WriteLine("Sorrt on year");
            for (int i = 0; i < 3; i++)
            {
                lis[i].print();
            }
            lis.Sort(new CarComparer(CarComparerType.MaxSpeed));
            Console.WriteLine("Sorrt on maxspeed");
            for (int i = 0; i < 3; i++)
            {
                lis[i].print();
            }
        }
    }
}
