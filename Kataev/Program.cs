using System;
using System.Collections.Generic;
using System.IO;

namespace Student
{
    class Program
    {

        static int AgeCompare(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
        {
            return String.Compare(st1.age.ToString(), st2.age.ToString());          // Сравниваем две строки
        }

        static int CourceAndAgeCompare(Student st1, Student st2)
        {
            if (st1.course > st2.course)
                return 1;
            if (st1.course < st2.course)
                return -1;
            if (st1.age > st2.age)
                return 1;
            if (st1.age < st2.age)
                return -1;
            return 0;
        }

        static void Main(string[] args)
        {
            int magistr5 = 0;
            int magistr6 = 0;
            List<Student> list = new List<Student>();                             // Создаем список студентов
            DateTime dt = DateTime.Now;
            Dictionary<int, int> cousreFrequency = new Dictionary<int, int>();
            StreamReader sr = new StreamReader("C:\\Users\\Сергей\\source\\repos\\HomeWork6Kataev\\HomeWork6Kataev\\bin\\Debug\\net5.0\\Student.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new Student(s[0], s[1], s[2], s[3], int.Parse(s[4]), s[5], int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    // Одновременно подсчитываем количество магистров пятого и шестого курсов
                    if (int.Parse(s[4]) == 5) magistr5++; 
                    else 
                    if (int.Parse(s[4]) == 6) magistr6++;
                    if (int.Parse(s[7]) > 17 && int.Parse(s[7]) < 21)
                    {
                        if (cousreFrequency.ContainsKey(int.Parse(s[6])))
                            cousreFrequency[int.Parse(s[6])] += 1;
                        else
                            cousreFrequency.Add(int.Parse(s[6]), 1);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Магистров пятого курса:{0}", magistr5);
            Console.WriteLine("Магистров шестого курса:{0}", magistr6);
            Console.WriteLine("\nПокажем сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся.");
            ICollection<int> keys = cousreFrequency.Keys;
            String result = String.Format("{0,-10} {1,-10}\n", "Курс", "Количество студентов");
            foreach (int key in keys)
                result += String.Format("{0,-10} {1,-10:N0}\n",
                                   key, cousreFrequency[key]);
            Console.WriteLine($"\n{result}");

            //list.Sort(new Comparison<Student>(AgeCompare));
            //Console.WriteLine("Отсортируем студентов по возрасту: ");
            //foreach (var v in list) Console.WriteLine($"{v.firstName} {v.age}");

            //list.Sort(new Comparison<Student>(CourceAndAgeCompare));
            //Console.WriteLine("\nОтсортируем студентов по курсу и возрасту возрасту: ");
            //foreach (var v in list) Console.WriteLine($"{v.firstName}, курс {v.course}, возраст {v.age}");

            //Console.WriteLine(DateTime.Now - dt);
            Console.ReadKey();
        }
    }

}