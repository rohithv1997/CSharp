using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Event_Demo
{
    class Student_Subscriber
    {
        public void Subscribe(Alarm_Publisher alarm)
        {
            TimeToRise del1 = new TimeToRise(WakeUp);

            alarm.RingAlarm += del1;
        }
        public void WakeUp()
        {
            Console.WriteLine("Get Ready Go to School");
        }
    }
}
