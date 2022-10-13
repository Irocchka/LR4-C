using System;

namespace лр4_1
{
    class MyMatrix
    {
        int n;
        int m;
        int[,] mass;
        public MyMatrix(int n, int m)
        {
            this.n = n;
            this.m = m;
            mass = new int[this.n, this.m];
        }
        public int this[int i, int j]//индекстатор
        {
            get
            {
                return mass[i, j];
            }
            set
            {
                mass[i, j] = value;
            }
        }
        public MyMatrix(int n, int m,int min,int max)
        {
            this.n = n;
            this.m = m;
            mass = new int[this.n, this.m];
            Random rd = new Random(); //обращение к классу случайных величин
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mass[i, j] = rd.Next(min, max);
                }
            }
        }

        public void Read()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(mass[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public static MyMatrix operator *(MyMatrix a, int num)
        {
            MyMatrix c = new MyMatrix(a.n, a.m);
            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < a.m; j++)
                {
                    c[i, j] = a[i, j] * num;
                }
            }
            return c;
        }
        public static MyMatrix operator /(MyMatrix a, int num)
        {
            MyMatrix c = new MyMatrix(a.n, a.m);
            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < a.m; j++)
                {
                    c[i, j] = a[i, j] / num;
                }
            }
            return c;
        }
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            MyMatrix c = new MyMatrix(a.n, a.m);
            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < a.m; j++)
                {
                    c[i, j] = a[i, j]+b[i,j];
                }
            }
            return c;
        }
        public static MyMatrix operator -(MyMatrix a, MyMatrix b)
        {
            MyMatrix c = new MyMatrix(a.n, a.m);
            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < a.m; j++)
                {
                    c[i, j] = a[i, j] - b[i, j];
                }
            }
            return c;
        }
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            MyMatrix c = new MyMatrix(a.n, a.m);
            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < a.m; j++)
                {
                    c[i, j] = a[i, j] * b[i, j];
                }
            }
            return c;
        }
    }
        class Program
        {
            static void Main(string[] args)
            {
            Console.WriteLine("Введите размерзность матрицы");
            int n = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите диапазон");
            int min = Convert.ToInt32(Console.ReadLine());
            int max = Convert.ToInt32(Console.ReadLine());
            MyMatrix m1 = new MyMatrix(n, m,min,max);
            MyMatrix m2 = new MyMatrix(n, m, min, max);
            Console.WriteLine("Матрица А: ");
            m1.Read();
            Console.WriteLine("Матрица Б: ");
            m2.Read();
            Console.WriteLine("Сложение матриц А и Б: ");
            MyMatrix m3 = m1 + m2;
            m3.Read();
            Console.WriteLine("Умножение матриц А и Б: ");
            MyMatrix m4 = m1 * m2;
            m4.Read();
            Console.WriteLine("Вычитание матриц А и Б: ");
            MyMatrix m5 = m1 - m2;
            m5.Read();
            Console.WriteLine("Умножение матриц А на число: ");
            Console.WriteLine("Введите число: ");
            int number = Convert.ToInt32(Console.ReadLine());
            MyMatrix m6 = m1*number;
            m6.Read();
            Console.WriteLine("Деление матриц А на число: ");
            Console.WriteLine("Введите число: ");
            int numb = Convert.ToInt32(Console.ReadLine());
            MyMatrix m7 = m1 * numb;
            m7.Read();
        }
        }
}
