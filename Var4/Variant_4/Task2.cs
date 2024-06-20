using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Variant_4.Task2;

namespace Variant_4
{

    public class Task2
    {
        private Figure[] figures;

        public Figure[] Figures => figures;

        public Task2(Figure[] figures)
        {
            this.figures = figures;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, figures.Select(f => f.ToString()));
        }
        public void Sorting()
        {
            for (int i = 0; i < figures.Length - 1; i++)
            {
                for (int j = 0; j < figures.Length - i - 1; j++)
                {
                    if (figures[j].Area() > figures[j + 1].Area())
                    {
                        // Обмен местами
                        Figure temp = figures[j];
                        figures[j] = figures[j + 1];
                        figures[j + 1] = temp;
                    }
                }
            }
        }
        public abstract class Figure
        {
            public abstract string Distinct();
            public abstract double Area();
            public override string ToString()
            {
                return $"{GetType().Name}: {Distinct()}, Площадь = {Area()}";
            }


        }
        public class Triangle : Figure
        {
            private int[] sides;
            public int a { get; }
            public int b { get; }
            public int c { get; }

            public Triangle(int[] sides)
            {
                if (sides.Length != 3 || !IsValidTriangle(sides))
                {
                    this.sides = new int[0];
                    a = b = c = 0;

                }
                else
                {
                    this.sides = Sorting(sides, 0, sides.Length - 1);
                    a = sides[0]; b = sides[1]; c = sides[2];
                }
            }
            private static bool IsValidTriangle(int[] sides)
            {
                int[] array = Sorting(sides, 0, sides.Length - 1);
                if (array[0] + array[1] > array[2])
                    return true;
                return false;
            }
            static void Swap(ref int x, ref int y)
            {
                var t = x;
                x = y;
                y = t;
            }

            //метод возвращающий индекс опорного элемента
            static int Partition(int[] array, int minIndex, int maxIndex)
            {
                var pivot = minIndex - 1;
                for (var i = minIndex; i < maxIndex; i++)
                {
                    if (array[i] < array[maxIndex])
                    {
                        pivot++;
                        Swap(ref array[pivot], ref array[i]);
                    }
                }

                pivot++;
                Swap(ref array[pivot], ref array[maxIndex]);
                return pivot;
            }

            //быстрая сортировка
            static int[] Sorting(int[] array, int minIndex, int maxIndex)
            {
                if (minIndex >= maxIndex)
                {
                    return array;
                }

                var pivotIndex = Partition(array, minIndex, maxIndex);
                Sorting(array, minIndex, pivotIndex - 1);
                Sorting(array, pivotIndex + 1, maxIndex);

                return array;
            }

            public override string Distinct()
            {
                if (sides.Length == 0)
                {
                    return "Не треугольник";
                }
                else if (a == b && b == c)
                {
                    return "Равносторонний";
                }
                else if (a == b || b == c || a == c)
                {
                    return "Равнобердренный";
                }
                return "Разносторонний";
            }

            public override double Area()
            {
                if (sides.Length == 0)
                {
                    return 0;
                }
                double p = (a + b + c) / 2.0;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            public override string ToString()
            {
                if (sides.Length == 0)
                {
                    return "не валидный треугольник";

                }
                return $"Type - Triangle, subtype = {Distinct()}, a = {a}, b = {b}, c = {c}, площадь = {Area()}";
            }
        }
        public class Circle : Figure
        {
            public double Radius1 { get; }
            public double Radius2 { get; }

            public Circle(double radius1, double radius2)
            {
                Radius1 = radius1;
                Radius2 = radius2;
            }

            public override string Distinct()
            {
                //если равны тогда круг, иначе эллипс
                return Radius1 == Radius2 ? "Круг" : "Элллипс";
            }
            public override double Area()
            {
                return Math.PI * Radius1 * Radius2;
            }

            public override string ToString()
            {
                return $"Type - {Distinct()}, радиус 1 = {Radius1}, радиус 2 = {Radius2}, площадь = {Area()}";
            }
        }
        public class Fourangle : Figure
        {
            public double Side1 { get; }
            public double Side2 { get; }

            public Fourangle(double side1, double side2)
            {
                Side1 = side1;
                Side2 = side2;
            }

            public override string Distinct()
            {
                return Side1 == Side2 ? "Квадрат" : "Прямоуголник";
            }

            public override double Area()
            {
                return Side1 * Side2;
            }

            public override string ToString()
            {
                return $"Type - {Distinct()}, сторона 1 = {Side1}, сторона 2 = {Side2}, площадь = {Area()}";
            }
        }
    }
}

