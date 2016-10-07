using ICSSoft.STORMNET.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IIS.calendar
{
    /// <summary>
    /// Класс создания повторяющихся событий
    /// </summary>
    public class EventCreator
    {

        static MSSQLDataService sq = (MSSQLDataService)DataServiceProvider.DataService;

        /// <summary>
        /// Создание ежедневного события
        /// </summary>
        /// <param name="Имя"></param>
        /// <param name="Тип события"></param>
        /// <param name="Коментарий"></param>
        /// <param name="Начало события"></param>
        /// <param name="Конец собтия"></param>
        /// <param name="Начало повторения"></param>
        /// <param name="Конец повторения"></param>
        /// <param name="Место"></param>
        public static void EveryDayCreator(string Name, string Type, string Comment, DateTime DayStart, DateTime DayEnd, DateTime RepeatStartDate, DateTime RepeatEndDate, string Place)
        {
            if (DayEnd.DayOfYear - DayStart.DayOfYear != 0)
                if (DayStart < RepeatStartDate)
                    if (RepeatEndDate < DayEnd)
                    {
                        throw new Exception("Событие вне промежутков повтора");
                    }
                    else
                    {
                        DateTime dayStart = DayStart.Date;
                        DateTime dayEnd = DayEnd.Date;
                        for (int i = RepeatStartDate.DayOfYear; i <= RepeatEndDate.DayOfYear; i++)
                        {
                            Event e = new Event
                            {
                                Name = Name,
                                StartDate = dayStart,
                                EndDate = dayEnd,
                                Comment = Comment,
                                Place = Place,
                                Type = Type,
                            };
                            dayStart = dayStart.AddDays(1.0);
                            dayEnd = dayEnd.AddDays(1.0);
                            sq.UpdateObject(e);
                        }
                    }
        }
        /// <summary>
        /// Создание еженедельного события
        /// </summary>
        /// <param name="Имя"></param>
        /// <param name="Тип события"></param>
        /// <param name="Коментарий"></param>
        /// <param name="Начало события"></param>
        /// <param name="Конец собтия"></param>
        /// <param name="Начало повторения"></param>
        /// <param name="Конец повторения"></param>
        /// <param name="Место"></param>
        public static void EveryWeekCreator(string Name, string Type, string Comment, DateTime DayStart, DateTime DayEnd, DateTime RepeatStartDate, DateTime RepeatEndDate, string Place)
        {
            if (DayEnd.DayOfYear - DayStart.DayOfYear>7)
                if (DayStart < RepeatStartDate)
                    if (RepeatEndDate < DayEnd)
                    {
                        throw new Exception("Событие вне промежутков повтора");
                    }
                    else
                    {
                        DateTime dayStart = DayStart.Date;
                        DateTime dayEnd = DayEnd.Date;
                        for (int i = RepeatStartDate.DayOfYear/7; i <= RepeatEndDate.DayOfYear/7; i++)
                        {
                            Event e = new Event
                            {
                                Name = Name,
                                StartDate = dayStart,
                                EndDate = dayEnd,
                                Comment = Comment,
                                Place = Place,
                                Type = Type,
                            };
                            dayStart = dayStart.AddDays(7.0);
                            dayEnd = dayEnd.AddDays(7.0);
                            sq.UpdateObject(e);
                        }
                    }
        }
        /// <summary>
        /// Создание ежемесячного события
        /// </summary>
        /// <param name="Имя"></param>
        /// <param name="Тип события"></param>
        /// <param name="Коментарий"></param>
        /// <param name="Начало события"></param>
        /// <param name="Конец собтия"></param>
        /// <param name="Начало повторения"></param>
        /// <param name="Конец повторения"></param>
        /// <param name="Место"></param>
        public static void EveryMonthCreator(string Name, string Type, string Comment, DateTime DayStart, DateTime DayEnd, DateTime RepeatStartDate, DateTime RepeatEndDate, string Place)
        {
            if (DayEnd.DayOfYear - DayStart.DayOfYear > 28)
                if (DayStart < RepeatStartDate)
                    if (RepeatEndDate < DayEnd)
                    {
                        throw new Exception("Событие вне промежутков повтора");
                    }
                    else
                    {
                        DateTime dayStart = DayStart.Date;
                        DateTime dayEnd = DayEnd.Date;
                        for (int i = RepeatStartDate.Month; i <= RepeatEndDate.Month; i++)
                        {
                            Event e = new Event
                            {
                                Name = Name,
                                StartDate = dayStart,
                                EndDate = dayEnd,
                                Comment = Comment,
                                Place = Place,
                                Type = Type,
                            };
                            dayStart = dayStart.AddMonths(1);
                            dayEnd = dayEnd.AddMonths(1);
                            sq.UpdateObject(e);
                        }
                    }
        }
        /// <summary>
        /// Создание ежегодного события
        /// </summary>
        /// <param name="Имя"></param>
        /// <param name="Тип события"></param>
        /// <param name="Коментарий"></param>
        /// <param name="Начало события"></param>
        /// <param name="Конец собтия"></param>
        /// <param name="Начало повторения"></param>
        /// <param name="Конец повторения"></param>
        /// <param name="Место"></param>
        public static void EveryYearCreator(string Name, string Type, string Comment, DateTime DayStart, DateTime DayEnd, DateTime RepeatStartDate, DateTime RepeatEndDate, string Place)
        {
            if (DayEnd.DayOfYear - DayStart.DayOfYear > 365)
                if (DayStart < RepeatStartDate)
                    if (RepeatEndDate < DayEnd)
                    {
                        throw new Exception("Событие вне промежутков повтора");
                    }
                    else
                    {
                        DateTime dayStart = DayStart.Date;
                        DateTime dayEnd = DayEnd.Date;
                        for (int i = RepeatStartDate.Year; i <= RepeatEndDate.Year; i++)
                        {
                            Event e = new Event
                            {
                                Name = Name,
                                StartDate = dayStart,
                                EndDate = dayEnd,
                                Comment = Comment,
                                Place = Place,
                                Type = Type,
                            };
                            dayStart = dayStart.AddYears(1);
                            dayEnd = dayEnd.AddYears(1);
                            sq.UpdateObject(e);
                        }
                    }
        }

    }
}