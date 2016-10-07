using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventAdderTestProject
{
    [TestClass]
    public class EventAdderTest
    {
        [TestMethod]
        public void EveryDayAdderTester()
        {
            DateTime DayStart=DateTime.Today;
            DateTime DayEnd= DayStart.AddDays(2.00);
            DateTime RepeatDayStart=DateTime.Today;
            DateTime RepeatDayEnd= DayStart.AddDays(5.00);
            IIS.calendar.EventCreator.EveryDayCreator("Check", "Встреча", "Check", DayStart, DayEnd, RepeatDayStart, RepeatDayEnd, "Place");
     
        }
    }
}
