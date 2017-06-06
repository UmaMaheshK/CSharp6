using System;
using System.ComponentModel;
using System.Threading.Tasks;
using static System.Console;

namespace CSharp6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stringinterpolation();
            //new AwaitInCatchAndFinalyBlock().Div(10, 0);
            //Task.Factory.StartNew(() => new AwaitInCatchAndFinalyBlock().Div(10, 0));
            //UsingStatic();
            ExceptionFilters();
        }
        public static void ExceptionFilters()
        {
            Random random = new Random();
            var randomExceptions = random.Next(400, 405);
            WriteLine("Generated exception: " + randomExceptions);
            Write("Exception type: ");

            try
            {
                throw new Exception(randomExceptions.ToString());
            }
            catch (Exception ex) when (ex.Message.Equals("400"))
            {
                Write("Bad Request");
            }
            catch (Exception ex) when (ex.Message.Equals("401"))
            {
                Write("Unauthorized");
            }
            catch (Exception ex) when (ex.Message.Equals("402"))
            {
                Write("Payment Required");
            }
            catch (Exception ex) when (ex.Message.Equals("403"))
            {
                Write("Forbidden");
            }
            catch (Exception ex) when (ex.Message.Equals("404"))
            {
                Write("Not Found");
            }
            finally
            {
                ReadLine();
            }
        }
        public static void UsingStatic()
        {
            WriteLine($"my Company is {0}", "Dhanush Infotech");
        }
        public static void Stringinterpolation()
        {
            string firstName, lastName;
            Console.Write("Please enter first name :=");
            firstName = Console.ReadLine();

            Console.Write("Please enter last name :=");
            lastName = Console.ReadLine();
            //C# 5.0
            Console.WriteLine("My fist name is {0}\nMy last name {1}", firstName, lastName);

            //C# 6.0
            Console.WriteLine($"My fist name is {firstName}\nMy last name {lastName}");

            var p = new { Name = "Uma", Age = 32 };
            var s = $"{p.Name,20} is {p.Age:D3} year{{s}} old.";
            Console.WriteLine(s);
        }
    }
    class Movie : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public double Rating { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            //if (handler != null)
            //{
            //    handler(this, new PropertyChangedEventArgs(name));
            //}
 
            /* Null propagation syntax */
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    public class AwaitInCatchAndFinalyBlock
    {
        public async void Div(int value1, int value2)
        {
            try
            {
                int res = value1 / value2;
                Console.WriteLine("Div : {0}", res);
            }
            catch (Exception ex)
            {
                await asyncMethodForCatch();
            }
            finally
            {
                await asyncMethodForFinally();
            }
        }
        private async Task asyncMethodForFinally()
        {
            //Console.WriteLine("Method from async finally Method !!");
            await Task.Run(() => { Console.WriteLine("Method from async finally Method !!"); });
        }

        private async Task asyncMethodForCatch()
        {
            //Console.WriteLine("Method from async Catch Method !!");
            await Task.Run(() => { Console.WriteLine("Method from async Catch Method !!"); });
        }
    }
}