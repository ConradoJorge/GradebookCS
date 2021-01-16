using System;
using System.Collections.Generic;

namespace GradeBook

{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Conrado's Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }



        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.Write("Please Enter a grade between 0.0 and 100.0 or press 'q' to exit. >>: ");
                var input = Console.ReadLine();

                if (input == "q" || input == "Q")
                {
                    break;
                }
                try
                {

                    var grade = double.Parse(input);
                    book.AddGrade(grade);

                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);

                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void  OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A Grade was added!");
        }

    }
}