using System;
using System.Collections.Generic;

namespace lab_6
{
    class Student: IComparable<Student>
    {
        public string Name { get; set; }
        public int Ects { get; set; }

        public int CompareTo(Student other)
        {
            return Name.CompareTo(other.Name);
        }
        public override bool Equals(object obj)
        {
            Console.WriteLine("Student Equals");
            return obj is Student student &&
                   Name == student.Name &&
                   Ects == student.Ects;
        }

        public override int GetHashCode()
        {
            Console.WriteLine("Student HashCode");
            return HashCode.Combine(Name, Ects);
        }

        public override string ToString()
        {
            return $"Name = {Name}, Ects = {Ects}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ICollection<string> names = new List<string>();
            names.Add("Ewa");
            names.Add("Karol");
            names.Add("Robert");
            Console.WriteLine(names.Contains("Karol"));
            names.Remove("Ewa");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("------------------------------------");
            
            ICollection<Student> students = new List<Student>();
            students.Add(new Student() { Name = "Karol", Ects = 15 });
            students.Add(new Student() { Name = "Robert", Ects = 17 });
            students.Add(new Student() { Name = "Ewa", Ects = 12 });
            Console.WriteLine(students.Contains(new Student() { Name = "Ewa", Ects = 12 }));
            students.Remove(new Student() { Name = "Ewa", Ects = 12 });
            foreach (Student student in students)
            {
                Console.WriteLine(student.Name + " " + student.Ects);
            }
            List<Student> list = (List<Student>)students;
            Console.WriteLine(list[0]);
            list.Insert(0, new Student() { Name = "Ania", Ects = 45 });
            
            int index = list.IndexOf(new Student() { Name = "Karol", Ects = 15 });
            Console.WriteLine(index);
            
            ISet<string> setNames = new HashSet<string>();
            setNames.Add("Ewa");
            setNames.Add("Karol");
            setNames.Add("Robert");
            setNames.Add("Robert");
            Console.WriteLine(string.Join(", ", setNames));
            Console.WriteLine("------------------------------------");

            ISet<Student> studentGroup = new HashSet<Student>();
            studentGroup.Add(list[0]);
            studentGroup.Add(list[1]);
            studentGroup.Add(list[2]);
            studentGroup.Add(new Student() { Name = "Ania", Ects = 45 });
            foreach (Student student in studentGroup)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("--------------Contains--------------");
            Console.WriteLine(studentGroup.Contains(list[2]));
            list.Add(new Student { Name = "Ela", Ects = 56 });
            list.Add(new Student { Name = "Marek", Ects = 16 });
            List<Student> result = new List<Student>();
            
            //Console.WriteLine("-----------jak nie robic-----------");
            //foreach (Student student in list)
            //{
            //    if (studentGroup.Contains(student))
            //    {
            //        result.Add(student);
            //    }
            //}
            
            Console.WriteLine("--------------jak robic--------------");

            ISet<Student> commonSet = new HashSet<Student>(studentGroup);
            commonSet.IntersectWith(list);
            Console.WriteLine(string.Join(", ", commonSet));
            ISet<Student> sortedSet = new SortedSet<Student>(studentGroup);
            sortedSet.Add(new Student() { Name = "Ewa", Ects = 34 });
            foreach (Student s in sortedSet)
            {
                Console.WriteLine(s);
            }

            Dictionary<Student, List<string>> phones = new Dictionary<Student, List<string>>();
            phones[list[0]] = new List<string>();
            phones[list[0]].Add("757636432");
            foreach (var item in phones)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            Console.WriteLine(string.Join(", ", phones.Keys));
            Console.WriteLine(string.Join(", ", phones.Values));
        }
    }
}
