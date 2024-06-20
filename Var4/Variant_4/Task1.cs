using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Variant_4
{
        public class Task1
        {
            private Triangle[] triangles;
            public Task1(Triangle[] triangles)
            {
                this.triangles = triangles;
            }
            public override string ToString()
            {
                string s = "";
                for (int i = 0; i < triangles.Length; i++)
                {
                    s += triangles[i].ToString() + "\n";
                }
                return s;
            }


            public void Sorting()
            {
                Array.Sort(triangles, (t1, t2) => t1.Area().CompareTo(t2.Area()));
            }
            public struct Triangle
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

                public string Distinct()
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

                public double Area()
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
        }
    }
