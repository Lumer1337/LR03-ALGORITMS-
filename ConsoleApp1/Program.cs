using ConsoleApp1;
using System;
using System.Text;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {

                Console.WriteLine("Плешаков И.С. 6203-020302D 3 лабораторная работа");
                Console.WriteLine("Создание массива из 7 элементов:");

                LLVLoop mass1 = new LLVLoop();
                LinkedListVector mass2 = new LinkedListVector();
                LinkedListVector mass3 = new LinkedListVector();
                for (int i = 0; i < 7; i++)
                {
                    Console.Write(i + " элемент = ");
                    int elemmass = Convert.ToInt32(Console.ReadLine());
                    mass1.DobavlenieKonec(elemmass);
                    mass2.DobavlenieKonec(elemmass);
                    mass3.DobavlenieKonec(elemmass);
                }


                Console.WriteLine("Задание 1:");
                Console.WriteLine("Начальный узел: " + mass1.Loop().next.value);      //O(n)
                Console.WriteLine();

                Console.WriteLine("Задание 2:");
                Console.WriteLine("Массив до удаления одинаковых элементов: " + mass2);
                mass2.DeleteCopies();
                Console.WriteLine("Массив после удаления одинаковых элементов: " + mass2);
                Console.WriteLine();

                Console.WriteLine("Задание 3:");
                Console.WriteLine(mass3);
                Console.Write("Введите номер элемента с конца = ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(a + " элемент с конца: " + mass3.PerehodKElementFromTheEnd(a).value);
        }   
    }
}

