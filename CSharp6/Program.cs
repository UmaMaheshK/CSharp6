using System;

namespace CSharp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Stringinterpolation();
        }
        public static void Stringinterpolation()
        {
            string firstName, lastName;
            Console.Write("Please enter first name :=");
            firstName = Console.ReadLine();

            Console.Write("Please enter last name :=");
            lastName = Console.ReadLine();
            Console.WriteLine($"My fist name is {firstName}\nMy last name {lastName}");
        }
    }
}
