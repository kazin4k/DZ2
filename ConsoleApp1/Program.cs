using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace ConsoleApp1
{
    internal class Program
    {
        enum Bank
        {
            Tekuschi = 200,
            Sberegatel = 500
        }

        struct info
        {
            public long nomer;
            public string tip;
            public int balans;
            public void OutPut()
            {
                Console.WriteLine("Номер:{0}, Тип:{1}, Баланс:{2}", nomer, tip, balans);
            }
        }

        struct rabotnik
        {
            public string name;
            public enum VUZ
            {
                KGU,
                KAI,
                KXTI
            }
            public VUZ vuz;
            public void OutPut()
            {
                Console.WriteLine($"Имя:{name} ВУЗ:{vuz}");
            }
        }

        struct user
        {
            public string name;
            public string gorod;
            public int age;
            public int pin;
            public void OutPut()
            {
                Console.WriteLine($"Имя: {name}\r\nГород: {gorod}\r\nВозраст: {age}\r\nPIN: {pin}");
            }
        }

        struct drink
        {
            public string name;
            public double grad;
            public drink(string Name, double Grad)
            {
                name = Name;
                grad = Grad;
            }
        }

        struct student
        {
            public string name;
            public string familia;
            public int id;
            public DateTime birth;
            public char category;
            public double v;
            public drink drink;
            public student(string Name, string Familia, int Id, DateTime Birth, char Category, double V, drink Drink)
            {
                name = Name;
                familia = Familia;
                id = Id;
                birth = Birth;
                category = Category;
                v = V;
                drink = Drink;
            }

            public double Valc()
            {
                return v * (drink.grad / 100);
            }
            public double Spirt(double volume)
            {
                return (Valc() / volume) * 100;
            }


        }
        static void Main(string[] args)
        {
            //3.1
            Console.WriteLine("Задание 3.1");
            Bank bank = Bank.Tekuschi;
            Bank bank1 = Bank.Sberegatel;

            Console.WriteLine("Текущий = {0}, Сберегательный = {1}", (int)bank, (int)bank1);

            //3.2
            Console.WriteLine("Задание 3.2");
            info inform = new info();
            inform.nomer = 88005353535;
            inform.tip = "Кредитная";
            inform.balans = 100;
            inform.OutPut();

            //3.3
            Console.WriteLine("Задание 3.3");
            rabotnik rabota = new rabotnik
            {
                name = "Игорь",
                vuz = rabotnik.VUZ.KXTI
            };
            rabota.OutPut();

            //3.4
            Console.WriteLine("Задание 3.4");
            Console.WriteLine($"byte – {byte.MaxValue} – {byte.MinValue}\r\n" +
                  $"sbyte – {sbyte.MaxValue} – {sbyte.MinValue}\r\n" +
                  $"short – {short.MaxValue} – {short.MinValue}\r\n" +
                  $"ushort – {ushort.MaxValue} – {ushort.MinValue}\r\n" +
                  $"int – {int.MaxValue} – {int.MinValue}\r\n" +
                  $"uint – {uint.MaxValue} – {uint.MinValue}\r\n" +
                  $"long – {long.MaxValue} – {long.MinValue}\r\n" +
                  $"ulong – {ulong.MaxValue} – {ulong.MinValue}\r\n" +
                  $"float – {float.MaxValue} – {float.MinValue}\r\n" +
                  $"double – {double.MaxValue} – {double.MinValue}\r\n" +
                  $"decimal – {decimal.MaxValue} – {decimal.MinValue}\r\n" +
                  $"char – '{char.MaxValue}' – '{char.MinValue}'\r\n" +
                  $"bool – {true} – {false}");

            //3.5
            Console.WriteLine("Задание 3.5");
            user usles = new user();
            Console.WriteLine("Введите имя: ");
            usles.name = Console.ReadLine();
            Console.WriteLine("Введите город: ");
            usles.gorod = Console.ReadLine();
            Console.WriteLine("Сколько вам лет: ");
            usles.age = int.Parse(Console.ReadLine());
            usles.pin = int.Parse(Console.ReadLine());
            usles.OutPut();
            
            //3.6
            Console.WriteLine("Задание 3.6");
            string stroka = Console.ReadLine();
            char[] chars = stroka.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsUpper(chars[i]))
                {
                    chars[i] = char.ToLower(chars[i]);
                }
                else if (char.IsLower(chars[i]))
                {
                    chars[i] = char.ToUpper(chars[i]);
                }
            }
            string result = new string(chars);
            Console.WriteLine(result);
            
            //3.7
            Console.WriteLine("Задание 3.7");
            string str = Console.ReadLine();
            string podstr = Console.ReadLine();
            int res = (str.Length - str.Replace(podstr, "").Length)/podstr.Length;
            Console.WriteLine(res);

            //3.8
            Console.WriteLine("Задание 3.8");
            Console.Write("Введите стандартную цену бутылки: ");
            string nPI = Console.ReadLine();
            Console.Write("Введите скидку: ");
            string sPI = Console.ReadLine();
            Console.Write("Введите стоимость отпуска: ");
            string hPI = Console.ReadLine();
            int nP, sP, hP;

            if (int.TryParse(nPI, out nP) &&
                int.TryParse(sPI, out sP) &&
                int.TryParse(hPI, out hP))
            {
                int dis = (nP * sP) / 100;
                int Bottle = nP - dis;

                if (Bottle <= 0)
                {
                    Console.WriteLine("Скидка не покрывает стоимость бутылки");
                    return;
                }

                int bottle = hP / Bottle;

                Console.WriteLine($"Необходимо купить бутылок: {bottle}");
            }
            else
            {
                Console.WriteLine("Пожалуйста, введите целые числа");
            }

            //3.9
            Console.WriteLine("Задание 3.9");
            drink vodka = new drink("Водка", 40);
            drink beer = new drink("Пиво", 5);
            drink wine = new drink("Вино", 12);
            drink whiskey = new drink("Виски", 40);
            drink champagne = new drink("Шампанское", 12);

            student[] students = new student[5];
            students[0] = new student("Иванов", "Иван", 1, new DateTime(2000, 1, 1), 'a', 1000, vodka);
            students[1] = new student("Петров", "Петр", 2, new DateTime(1999, 5, 15), 'b', 1500, beer);
            students[2] = new student("Прокофьев", "Руслан", 3, new DateTime(2001, 10, 20), 'c', 500, wine);
            students[3] = new student("Кузнецов", "Алексей", 4, new DateTime(1998, 3, 30), 'd', 2000, whiskey);
            students[4] = new student("Смирнов", "Сергей", 5, new DateTime(1997, 12, 12), 'b', 800, champagne);

            double volume = 0;
            double alcvolume = 0;

            foreach (var student in students)
            {
                volume += student.v;
                alcvolume += student.Valc();
            }

            Console.WriteLine($"Общий объем выпитой жидкости: {volume} мл");
            Console.WriteLine($"Общий объем алкоголя: {alcvolume} мл");
            Console.WriteLine();

            foreach (var student in students)
            {
                double proc = student.Spirt(volume);
                Console.WriteLine($"{student.name} {student.familia}:");
                Console.WriteLine($"  Объем выпитого алкоголя: {student.Valc()} мл");
                Console.WriteLine($"  Процент алкоголя от общего объема: {proc:F2}%");
                Console.WriteLine();
                Console.ReadKey();
            }

        }   
    }
}
