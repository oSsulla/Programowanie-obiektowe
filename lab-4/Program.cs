using System;

namespace lab_4
{
    enum Degree
    {
        A = 50,
        B = 45,
        C = 35,
        D = 30,
        E = 25,
        F = 20,
        G = 15
    }
    class Program
    {

        public static double Convert(Degree degree)
        {
            return degree switch
            {
                Degree.A => 5.0,
                Degree.B => 4.5,
                Degree.C => 4.0,
                Degree.D => 3.5,
                Degree.E => 3.0,
                Degree.F => 2.0,
                _ => 1.0
            };
        }

        public static string DegreeType(Degree degree)
        {
            return degree switch
            {
                Degree.A or Degree.B or Degree.C or Degree.E => "Pozytywna",
                _ => "Negatywna"
            };
        }

        public static Degree GetDegree(int points)
        {
            return points switch
            {
                > 90           => Degree.A,
                > 80 and <= 90 => Degree.B,
                > 70 and <= 80 => Degree.C,
                > 60 and <= 70 => Degree.D,
                > 50 and <= 60 => Degree.E,
                _ => Degree.F
            };
        }

        public static (string, bool)[] Egzams((string name, int points, char egzam)[] egzamInfo)
        {
            (string, bool)[] result = new (string, bool)[egzamInfo.Length];
            int i = 0;
            foreach (var item in egzamInfo)
            {
                result[i++] = (item.name,
                    item switch
                    {
                        { points: > 20, egzam: 'C'} => true,
                        { points: > 30, egzam: 'A'} => true,
                        _ => false
                    }
                    );
            }
            return result;
        }

        record Student (string Name, int Ects);

        static void Main(string[] args)
        {
            Degree studentDegree = Degree.F;
            Console.WriteLine((int)studentDegree);
            foreach (string name in Enum.GetNames<Degree>())
            {
                Console.WriteLine(name);
            }
            foreach (int value in Enum.GetValues<Degree>())
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("Wpisz ocenę");
            string str = Console.ReadLine();
            try
            {
                studentDegree = Enum.Parse<Degree>(str);
                Console.WriteLine($"Wpisałeś ocenę {studentDegree} {(int)studentDegree}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("nieznana ocena");
            }
            Student student = new Student("Karol", 23);
            Console.WriteLine(student);
        }
    }
}
