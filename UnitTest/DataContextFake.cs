using Api_Calender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    internal class DataContextFake:IDataContext
    {
        public List<Event> events { get; set; }
        

        public DataContextFake()
        {
            events = new List<Event>();
            events.Add(new Event
            {
                Id =12,
                Title = "event 3",
                Start = new DateTime(2023, 09, 16),
                End = new DateTime(2023, 09, 14)
            });
            events.Add(new Event { Id = 2, Title = "default" });


        }
    }
}
