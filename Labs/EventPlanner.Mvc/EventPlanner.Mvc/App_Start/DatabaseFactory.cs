using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventPlanner;
using EventPlanner.Memory;

namespace EventPlanner.Mvc.App_Start
{
    public static class DatabaseFactory
    {
        private static IEventDatabase _databse = new MemoryEventDatabase().SeedDatabase();

        private static MemoryEventDatabase SeedDatabase( this MemoryEventDatabase mmd)
        {
            mmd.AddRange(new List<ScheduledEvent>{
                new ScheduledEvent(){
                    Description = "",
                    Id = 1,
                    Name = "Start Event",
                    StartDate = new DateTime(2018, 6, 20),
                    EndDate = DateTime.Today,
                    IsPublic = true},
                new ScheduledEvent(){
                    Description = "Day Born",
                    Id = 2,
                    Name = "Birthday",
                    StartDate = new DateTime(1991, 6, 20),
                    EndDate = new DateTime(1991, 6, 20),
                    IsPublic = false},
                new ScheduledEvent(){
                    Description = "Upcoming B-Day",
                    Id = 3,
                    Name = "30th Birthday",
                    StartDate = new DateTime(2019, 6, 20),
                    EndDate = new DateTime(2019, 6, 20),
                    IsPublic = false},
        });

            return mmd;
        }

        private static List<ScheduledEvent> AddRange(this MemoryEventDatabase mmd, List<ScheduledEvent> evts )
        {
            List<ScheduledEvent> rtnEvents = new List<ScheduledEvent>();

            evts.ForEach(evt => rtnEvents.Add(mmd.Add(evt)));

            return rtnEvents;
        }

        public static IEventDatabase Database { get
            { return _databse; }
            private set { _databse = value; }
             }
    }
}