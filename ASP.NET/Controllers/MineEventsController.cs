using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.FunctionalLanguage;
using ICSSoft.STORMNET.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IIS.calendar.Controllers
{
    /// Возврат событий определенного пользователя
    public class MineEventsController : ApiController
    {
        // GET api/<controller>

        /// <summary>
        /// Возврат событий определенного пользователя
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EventModel> GetMine()
        {
            //var langdef = ExternalLangDef.LanguageDef;
            //var ml = LoadingCustomizationStruct.GetSimpleStruct(typeof(Member), Member.Views.MemberE);
            //ml.LimitFunction = langdef.GetFunction(langdef.funcEQ, langdef.GetFunction("ClientEQ", new VariableDef(langdef., "")), );
            MSSQLDataService sq = (MSSQLDataService)DataServiceProvider.DataService;
            IEnumerable<ClientDB> c = sq.LoadObjects(ClientDB.Views.ClientDBL).Cast<ClientDB>();
            IEnumerable<ClientDB> cl = (from ce in c
                                        where ce.Name == WebApplication.UserName.username
                                        select ce);
            IEnumerable<Event> events = sq.LoadObjects(Event.Views.EventL).Cast<Event>();
            //IEnumerable<ICSSoft.STORMNET.DataObject[]> m = (from e in events
            //                                                select e.Member.GetAllObjects());
            //IEnumerable<Event> myEvents = (from e in events
            //                               where e.Member.GetByKey(cl.First().__PrimaryKey)==cl.First().__PrimaryKey
            //                               select e);
            IEnumerable<EventModel> listEvents = events.Select(_event => new EventModel
            {
                title = _event.Name,
                start = _event.StartDate,
                end = _event.EndDate,
            });
            List<EventModel> ColoredList = listEvents.ToList();
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
            return ColoredList;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

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