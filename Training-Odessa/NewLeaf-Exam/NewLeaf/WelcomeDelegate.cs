using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLeaf
{
    public delegate void DelegateMessage();

    class Publisher
    {
        public event DelegateMessage eventOnTrigger;
        public void Trigger()
        {
            eventOnTrigger();
        }
    }
    class Subsciber
    {
        public void Subscribe(Publisher publisherObject)
        {
            DelegateMessage delegateobject = new DelegateMessage(DisplayWelcome);
            publisherObject.eventOnTrigger += delegateobject;
        }
        public void DisplayWelcome()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Welcome DON JOSE");
            Console.WriteLine("Current Time is {0}:{1} {2}", (DateTime.Now.Hour > 12 ? DateTime.Now.Hour-12 : DateTime.Now.Hour), DateTime.Now.Minute, (DateTime.Now.Hour > 12 ? "PM" : "AM"));
            if ((DateTime.Now.Hour>=0 && DateTime.Now.Hour<4 )|| (DateTime.Now.Hour >= 20 && DateTime.Now.Hour < 24))
                Console.WriteLine("We Wish You a Very Warm Good Night");
            else if (DateTime.Now.Hour >=4 && DateTime.Now.Hour < 12)
                Console.WriteLine("We Wish You a Very Warm Good Morning");
            else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour <20)
                Console.WriteLine("We Wish You a Very Warm Good Afternoon");
            Console.ReadKey();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }
        
    }
}
