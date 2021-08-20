using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeWork6Kataev
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                sb.Append(Student.GetStudent());
            }
            File.WriteAllText("Student.csv", sb.ToString(),Encoding.UTF8);

            
        }


    }
}

