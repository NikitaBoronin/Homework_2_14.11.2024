using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Homework_from_file_Boronin_09_421
{
    /// <summary>
    /// Структура Напитка, содержит название и процент алкоголя
    /// </summary>
    struct Drink
    {
        public string Name;
        public double AlcoholContent;  // Процент алкоголя (например, 0.2 для водки)

        public Drink(string name, double alcoholContent)
        {
            Name = name;
            AlcoholContent = alcoholContent;
        }
    }
    /// <summary>
    /// Структура Студента, содержит фамилию, имя, id, дату рождения, категорию алкоголизма, напиток который пьет студент
    /// (реализация идет через другую структуру Drink)
    /// и содержит объем выпитого напитка
    /// </summary>
    struct Student
    {
        public string Surname;
        public string Name;
        public int Id;
        public int DateOfBirth;
        public char CategoryOfAlcoholism; // Категория алкоголизма: 'a', 'b', 'c', 'd'
        public Drink FavoriteDrink;      // Напиток, который пьет студент
        public double VolumeDrink;       // Объем выпитого напитка в литрах

        
        public double CalculateAlcoholConsumed()
        {
            return VolumeDrink * FavoriteDrink.AlcoholContent;
        }

        
        public Student(string name, string surname, int id, int dateOfBirth, char categoryOfAlcoholism, Drink favoriteDrink, double volumeDrink)
        {
            Name = name;
            Surname = surname;
            Id = id;
            DateOfBirth = dateOfBirth;
            CategoryOfAlcoholism = categoryOfAlcoholism;
            FavoriteDrink = favoriteDrink;
            VolumeDrink = volumeDrink; 
        }
    }


    internal class Program
    {

        static void Main(string[] args)
        {
            // Задание 1
            Console.WriteLine("\n 1 Задание\n");
            Console.WriteLine($"sbyte - max: {sbyte.MaxValue} - min: {sbyte.MinValue}");
            Console.WriteLine($"byte - max: {byte.MaxValue} - min: {byte.MinValue}");
            Console.WriteLine($"short - max: {short.MaxValue} - min: {short.MinValue}");
            Console.WriteLine($"ushort - max: {ushort.MaxValue} - min: {ushort.MinValue}");
            Console.WriteLine($"int - max: {int.MaxValue} - min: {int.MinValue}");
            Console.WriteLine($"uint - max: {uint.MaxValue} - min: {uint.MinValue}");
            Console.WriteLine($"long - max: {long.MaxValue} - min: {long.MinValue}");
            Console.WriteLine($"ulong - max: {ulong.MaxValue} - min: {ulong.MinValue}");
            Console.WriteLine($"float - max: {float.MaxValue} - min: {float.MinValue}");
            Console.WriteLine($"double - max: {double.MaxValue} - min: {double.MinValue}");
            Console.WriteLine($"decimal - max: {decimal.MaxValue} - min: {decimal.MinValue}");

            // 2 задание
            Console.WriteLine("\n 2 Задание\n");
            int age;
            Console.WriteLine("Напишите ваше имя: ");
            string name = Console.ReadLine();

            Console.WriteLine("Напишите ваш город: ");
            string city = Console.ReadLine();

            Console.WriteLine("Введите ваш возраст: ");
            bool age_try = int.TryParse(Console.ReadLine(), out age);

            
            if (!age_try || age < 0)
            {
                Console.WriteLine("Некорректный ввод возраста. Пожалуйста, введите положительное число.");
                // здесь завершение, но не хочу чтобы выкидывало.
            }

            Console.WriteLine("Введите ваш PIN-код: (4 цифры)");
            int PIN_kod;
            bool try_Pinkod = int.TryParse(Console.ReadLine(), out PIN_kod);

            
            if (!try_Pinkod || PIN_kod < 1000 || PIN_kod > 9999)
            {
                Console.WriteLine("Некорректный ввод PIN-кода. Пожалуйста, введите 4 цифры.");
                // здесь завершение, но не хочу чтобы выкидывало.
            }

            
            (string Name, int Age, string City, int Pin_kodd) userInfo = (Name: name, Age: age, City: city, Pin_kodd: PIN_kod);

           
            Console.WriteLine($"Имя: {userInfo.Name}, Возраст: {userInfo.Age}, Город: {userInfo.City}, PIN-код: {userInfo.Pin_kodd}");

            // 3 Задание
            Console.WriteLine("\n 3 Задание\n");
            Console.WriteLine("Введите любой текст (вводите не цифры): ");
            int check;
            string user_answer = Console.ReadLine();
            bool try_check = int.TryParse(user_answer, out check);

            
            if (try_check)
            {
                Console.WriteLine("Вы ввели цифры!\nНужно вводить текст!");
            }
            else
            {
                string result = "";
                foreach (char element in user_answer)
                {
                    if (char.IsUpper(element))
                    {
                        result += char.ToLower(element);
                    }
                    else if (char.IsLower(element))
                    {
                        result += char.ToUpper(element);
                    }
                    else
                    {
                        result += element;
                    }
                }
                Console.WriteLine($"Преобразованная строка: {result}");
            }


            // 4 Задание
            Console.WriteLine("\n 4 Задание\n");
            Console.WriteLine("Описание: Задача будет описывать сколько раз в Основном тексте встречается подстрока\n которую пользователь укажет 2 вводом.\n");
            Console.WriteLine("Введите строку(текст Основной): ");
            string string_user = Console.ReadLine();
            Console.WriteLine("Введите подстроку(текст по этому слову будет поиск):");
            string substring = Console.ReadLine();

            int count = 0;
            int index = 0;

            while ((index = string_user.IndexOf(substring, index)) != -1)
            {
                count++;
                index += substring.Length; 
            }

            Console.WriteLine($"Подстрока '{substring}' встречается {count} раз(а) в строке.");

            // 5 Задача
            Console.WriteLine("\n 5 Задание\n");
            double normPrice = 200; 
            Console.WriteLine("Введите какой процент вам нужен(введите число): \n5% - 1\n10% - 2\n15% - 3\n20% - 4\n25% - 5\n30% - 6");

            int answerr_user;
            bool isValidInput = int.TryParse(Console.ReadLine(), out answerr_user);

            if (!isValidInput || answerr_user < 1 || answerr_user > 6)
            {
                Console.WriteLine("Ошибка! Введите корректное значение от 1 до 6.");
                // здесь завершение, но не хочу чтобы выкидывало.
            }

            double procent = 0;

            // Определяем процент скидки
            switch (answerr_user)
            {
                case 1:
                    procent = 0.05;
                    break;
                case 2:
                    procent = 0.1;
                    break;
                case 3:
                    procent = 0.15;
                    break;
                case 4:
                    procent = 0.2;
                    break;
                case 5:
                    procent = 0.25;
                    break;
                case 6:
                    procent = 0.3;
                    break;
            }

            double salePrice = normPrice * (1 - procent);
            double econom_of_bottle = normPrice - salePrice;

            Console.WriteLine("Введите стоимость вашего отпуска:");
            double holidayPrice;
            bool isHolidayPriceValid = double.TryParse(Console.ReadLine(), out holidayPrice);

            if (!isHolidayPriceValid || holidayPrice <= 0)
            {
                Console.WriteLine("Ошибка! Введите корректную стоимость отпуска.");
                // здесь завершение, но не хочу чтобы выкидывало.
            }

            double number_of_bottles_needed = holidayPrice / econom_of_bottle;
            int bottlesNeeded = (int)Math.Floor(number_of_bottles_needed);

            Console.WriteLine($"Чтобы возместить отпуск потребуется {bottlesNeeded} бутылок.");
            // 6 Задание
            Console.WriteLine("\n 6 Задание\n");
            Drink beer = new Drink("Beer", 0.1);   // Пиво, 10% алкоголя
            Drink vodka = new Drink("Vodka", 0.4);  // Водка, 40% алкоголя
            Drink rum = new Drink("Rum", 0.2);     // Ром, 20% алкоголя

            
            Student student1 = new Student("Дима", "Орлов", 1123, 2006, 'a', beer, 4);   
            Student student2 = new Student("Савели", "Китов", 1442, 2002, 'b', rum, 3);   
            Student student3 = new Student("Вася", "Миронов", 3921, 1993, 'c', vodka, 1); 
            Student student4 = new Student("Тим", "Шейн", 1343, 1998, 'd', rum, 1);       
            Student student5 = new Student("Ким", "Торонтов", 9923, 2000, 'b', beer, 2);   

            
            double totalDrinkVolume = student1.VolumeDrink + student2.VolumeDrink + student3.VolumeDrink + student4.VolumeDrink + student5.VolumeDrink;
            double totalAlcoholVolume = student1.CalculateAlcoholConsumed() + student2.CalculateAlcoholConsumed() + student3.CalculateAlcoholConsumed() + student4.CalculateAlcoholConsumed() + student5.CalculateAlcoholConsumed();

            
            Console.WriteLine($"Общий объем выпитой жидкости: {totalDrinkVolume} литров");
            Console.WriteLine($"Общий объем алкоголя: {totalAlcoholVolume} литров");

            
            PrintStudentInfo(student1, totalDrinkVolume, totalAlcoholVolume);
            PrintStudentInfo(student2, totalDrinkVolume, totalAlcoholVolume);
            PrintStudentInfo(student3, totalDrinkVolume, totalAlcoholVolume);
            PrintStudentInfo(student4, totalDrinkVolume, totalAlcoholVolume);
            PrintStudentInfo(student5, totalDrinkVolume, totalAlcoholVolume);
            Console.WriteLine("\nКонец программы!");
        }

        
        static void PrintStudentInfo(Student student, double totalDrinkVolume, double totalAlcoholVolume)
        {
            double drinkPercentage = (student.VolumeDrink / totalDrinkVolume) * 100; 
            double alcoholPercentage = (student.CalculateAlcoholConsumed() / totalAlcoholVolume) * 100; 
            Console.WriteLine($"{student.Name} {student.Surname} выпил {drinkPercentage:F2}% от общего объема жидкости и {alcoholPercentage:F2}% от общего объема алкоголя.");
        }
        
    

    }
}
