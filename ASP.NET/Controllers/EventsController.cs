using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.FunctionalLanguage;
using ICSSoft.STORMNET.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;

namespace IIS.calendar.Controllers
{
    public class EventModel
    {
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
        public string title { get; set; }
        public string color { get; set; }
        public string type { get; set; }
    }
    /// <summary>
    /// Контроллер выдачи событий в календарь
    /// </summary>
    public class EventsController : ApiController
    {
        // GET api/<controller>
        /// <summary>
        /// Получение всех элементов
        /// </summary>
        /// <param name="Номер месяца"></param>
        /// <returns></returns>
        public IEnumerable<EventModel> GetEvents()//int MonthNumber)
        {
            //var langdef = ExternalLangDef.LanguageDef;
            //var ml=LoadingCustomizationStruct.GetSimpleStruct(typeof (Event),Event.Views.EventL);
            //ml.LimitFunction=langdef.GetFunction(langdef.funcEQ, langdef.GetFunction("MonthPart", new VariableDef(langdef.DateTimeType,"StartDate")),MonthNumber);//выдача только отображаемых 
            MSSQLDataService sq = (MSSQLDataService)DataServiceProvider.DataService;
            IEnumerable <Event> events= sq.LoadObjects(Event.Views.EventL).Cast<Event>();//выгрузка данных из бд
            IEnumerable<EventModel> listEvents = events.Select(_event => new EventModel
            {
                title = _event.Name,
                start = _event.StartDate,
                end = _event.EndDate,
                type=_event.Type,

            });// формирования списка для передачи на форму
            List<EventModel>ColoredList=listEvents.ToList();
            for (int i = 0; i < ColoredList.Count; i++)
            {
                if (ColoredList[i].type == "Задача")
                    ColoredList[i].color = "brown";
                else if (ColoredList[i].type == "Встреча")
                    ColoredList[i].color = "red";
                else if (ColoredList[i].type == "Рабочее совещание")
                    ColoredList[i].color = "green";
                else
                    ColoredList[i].color = "blue";
            }
            return ColoredList;//возврат событий с цветами по типу события
        }
        // GET api/<controller>/5
        

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}