using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Event_Demo
{
    class Alarm_Publisher
    {
        public event  TimeToRise  RingAlarm;

        public void Trigger()
        {
            Console.WriteLine("Enter the Time");
            int time = Convert.ToInt32(Console.ReadLine());
            if (time==7)
            {
                RingAlarm();
            }
        }
    }
}
