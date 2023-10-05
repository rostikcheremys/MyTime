using System;

namespace Program
{
    internal class Program
    {
        public static void Main()
        {
            Console.Write("Enter the time separated by spaces: ");
            string time = Console.ReadLine();
            
            string[] data = time.Split(' ');

            int hour = int.Parse(data[0]);
            int minute = int.Parse(data[1]);
            int second = int.Parse(data[2]);

            try
            {
                MyTime t = new MyTime(hour, minute, second);

                Console.WriteLine($"Time: {t}");
                Console.WriteLine($"\nSeconds since midnight: {t.TimeSinceMidnight()}");
                
                Console.WriteLine("\nAdd one second: ");
                t.AddOneSecond();
                Console.WriteLine(t.ToString());
                
                Console.WriteLine("\nAdd one minute: ");
                t.AddOneMinute();
                Console.WriteLine(t.ToString());
                
                Console.WriteLine("\nAdd one hour: ");
                t.AddOneHour();
                Console.WriteLine(t.ToString());
                
                MyTime tSecond = new MyTime(12, 0, 0);
                
                Console.WriteLine($"\nDifference between 12:00 and {t} is {t.Difference(tSecond)} seconds");
                
                Console.Write("\nHow many seconds do you want to add: ");
                
                int s = Convert.ToInt32(Console.ReadLine());
                t.AddSeconds(s);
                Console.WriteLine($"New time after adding {s} seconds: {t}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}