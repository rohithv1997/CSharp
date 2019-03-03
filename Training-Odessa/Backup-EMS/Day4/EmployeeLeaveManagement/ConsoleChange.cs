using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveManagement
{
    public static class ConsoleChange
    {
        static int i = 0, ch;
        static ConsoleColor bg;
        static ConsoleColor fg = ConsoleColor.White;
        static public void cc()
        {

            Console.WriteLine("1.Change Background Color\n2.Change Foreground Color\nEnter Choice: ");
            ch = Convert.ToInt32(Console.ReadLine());
            if (ch == 1)
            {
                i = 0;
                Console.WriteLine("Pick any color.");
                foreach (var item in Enum.GetValues(typeof(ConsoleColor)))
                {
                    Console.WriteLine(i + "." + item);
                    i++;
                }
                bg = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Console.ReadLine().ToString());
                Console.BackgroundColor = bg;
            }
            else if (ch == 2)
            {
                i = 0;
                Console.WriteLine("Pick any color.");
                foreach (var item in Enum.GetValues(typeof(ConsoleColor)))
                {
                    Console.WriteLine(i + "." + item);
                    i++;
                }
                fg = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Console.ReadLine().ToString());
                Console.ForegroundColor = fg;
            }
            Console.Clear();
        }
    }
}
