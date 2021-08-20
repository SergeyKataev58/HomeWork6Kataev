using System;

namespace HomeWork6Kataev
{
    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;
        //public int Cours { get; set; }
        //public int Age { get; set; }
        //public String Name { get; set; }

        public override string ToString()
        {
            return $"{lastName}; {firstName}; {university};{faculty}; {course};{department}; {group};{age}; { city}";
        }

        static Random r = new Random();
        public static Student GetStudent()
        {
            return new Student()
            {
                lastName = $"Имя_{Guid.NewGuid().ToString().Substring(0, 10)}",
                firstName = $"Фамилия_{Guid.NewGuid().ToString().Substring(0, 10)}",
                university = $"Универ_{Guid.NewGuid().ToString().Substring(0, 5)}",
                faculty = $"Фак_{Guid.NewGuid().ToString().Substring(0, 4)}",
                course = r.Next(1, 7),
                department = $"department_{Guid.NewGuid().ToString().Substring(0, 10)}",
                group = r.Next(1, 4),
                age = r.Next(17, 24),
                city = $"Город_{Guid.NewGuid().ToString().Substring(0, 7)}\n"
            };
        }




    }
}
