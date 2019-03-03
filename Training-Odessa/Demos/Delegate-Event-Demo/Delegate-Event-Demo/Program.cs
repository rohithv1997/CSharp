using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Event_Demo
{
    public delegate void TimeToRise();
    class Program
    {
        static void Main(string[] args)
        {
            Alarm_Publisher casio = new Alarm_Publisher();
            Student_Subscriber don = new Student_Subscriber();
            don.Subscribe(casio);
            casio.Trigger();
        }
    }
}
