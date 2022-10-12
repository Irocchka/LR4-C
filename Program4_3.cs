using System;
using System.Collections.Generic;

namespace lr4_3
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

    class CarCatalog
    {
        public List<Car> lis = new List<Car>();
        public CarCatalog(params Car[] cars)
        {
            for(int i = 0; i < cars.Length; i++)
            {
                lis.Add(cars[i]);
            }
        }
        //Метод GetEnumerator возвращает каждую строку поочередно с помощью оператора yield return.
        public IEnumerator<Car> GetEnumerator()//прямой проход
        {
            for(int i = 0; i < lis.Count; i++)
            {
                yield return lis[i];
            }
        }
        public IEnumerable<Car> obr()//обратный проход
        {
            for (int i =lis.Count-1; i >=0; i--)
            {
                yield return lis[i];
            }
        }
        public IEnumerable<Car> ProdYear()//проход по году выпуска
        {
            lis.Sort(new CarComparer(CarComparerType.ProductionYear));
            for (int i = 0; i < lis.Count; i++)
            {
                yield return lis[i];
            }
        }
        public IEnumerable<Car> MaxSp()//проход по max скорости
        {
            lis.Sort(new CarComparer(CarComparerType.MaxSpeed));
            for (int i = 0; i < lis.Count; i++)
            {
                yield return lis[i];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("audi", 2020, 150);
            Car car2 = new Car("mers", 2022, 180);
            Car car3 = new Car("bmw", 2017, 120);
            CarCatalog cat = new CarCatalog(car1, car2, car3);
            Console.WriteLine("catalog");
            foreach(Car element in cat)
            {
                element.print();
            }
            Console.WriteLine("обратный проход");
            foreach (Car element in cat.obr())
            {
                element.print();
            }
            Console.WriteLine("по году выпуска");
            foreach (Car element in cat.ProdYear())
            {
                element.print();
            }
            Console.WriteLine("п скорости");
            foreach (Car element in cat.MaxSp())
            {
                element.print();
            }
        }
    }
}
