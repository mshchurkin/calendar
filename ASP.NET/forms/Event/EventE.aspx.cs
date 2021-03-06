﻿/*flexberryautogenerated="true"*/

namespace IIS.calendar
{
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Web.Controls;
    using ICSSoft.STORMNET.Web.AjaxControls;
    using System;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.LINQProvider;

    public partial class EventE : BaseEditForm<Event>
    {
        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public EventE()
            : base(Event.Views.EventE)
        {
        }

        /// <summary>
        /// Путь до формы.
        /// </summary>
        public static string FormPath
        {
            get { return "~/forms/Event/EventE.aspx"; }
        }

        /// <summary>
        /// Вызывается самым первым в Page_Load.
        /// </summary>
        protected override void Preload()
        {
            //формирование вида контролов DatePicker
            ctrlEndDate.OnlyDate = false;
            ctrlStartDate.OnlyDate = false;
            ctrlStartDate.DateFormat = "dd/MM/yyyy";
            ctrlEndDate.DateFormat = "dd/MM/yyyy";
            ctrlStartDate.Value = DateTime.Today;
            ctrlEndDate.Value = DateTime.Today;
        }

        /// <summary>
        /// Здесь лучше всего писать бизнес-логику, оперируя только объектом данных.
        /// </summary>
        protected override void PreApplyToControls()
        {
            
        }

        /// <summary>
        /// Здесь лучше всего изменять свойства контролов на странице,
        /// которые не обрабатываются WebBinder.
        /// </summary>
        protected override void PostApplyToControls()
        {
            //блокирование изменения типа повтора если элемент редактируется
            if (IsObjectCreated == false)
            {
                ctrlRepeatType.SelectedValue = "Не повторять";
                ctrlRepeatType.Enabled = false;
            }
            Page.Validate();
        }

        /// <summary>
        /// Вызывается самым последним в Page_Load.
        /// </summary>
        protected override void Postload()
        {
        }

        /// <summary>
        /// Валидация объекта для сохранения.
        /// </summary>
        /// <returns>true - продолжать сохранение, иначе - прекратить.</returns>
        protected override bool PreSaveObject()
        {
            return base.PreSaveObject();
        }

        /// <summary>
        /// Нетривиальная логика сохранения объекта.
        /// </summary>
        /// <returns>Объект данных, который сохранился.</returns>
        protected override DataObject SaveObject()
        {
            //изменение поведения сохранения объекта в зависимости от выбранного элемента списка
            switch (ctrlRepeatType.SelectedValue)
            {
                case ("Не повторять"):
                    {
                        return base.SaveObject();
                    } break;
                case ("Ежедневно"):
                    {
                        IIS.calendar.EventCreator.EveryDayCreator(ctrlName.Text.ToString(), ctrlType.SelectedValue.ToString(), ctrlComment.Text.ToString(), ctrlStartDate.Value, ctrlEndDate.Value, RepeatStartDate.Value, RepeatEndDate.Value, ctrlPlace.Text.ToString());
                      Redirect();//переход на списковую форму
                      return null;
                    }break;
                case ("Еженедельно"):
                    {
                        IIS.calendar.EventCreator.EveryWeekCreator(ctrlName.Text.ToString(), ctrlType.SelectedValue.ToString(), ctrlComment.Text.ToString(), ctrlStartDate.Value, ctrlEndDate.Value, RepeatStartDate.Value, RepeatEndDate.Value, ctrlPlace.Text.ToString());
                        Redirect();
                        return null;
                    } break;
                case ("Ежемесячно"):
                    {
                        IIS.calendar.EventCreator.EveryMonthCreator(ctrlName.Text.ToString(), ctrlType.SelectedValue.ToString(), ctrlComment.Text.ToString(), ctrlStartDate.Value, ctrlEndDate.Value, RepeatStartDate.Value, RepeatEndDate.Value, ctrlPlace.Text.ToString());
                        Redirect();
                        return null;
                    } break;
                case ("Ежегодно"):
                    {
                        IIS.calendar.EventCreator.EveryYearCreator(ctrlName.Text.ToString(), ctrlType.SelectedValue.ToString(), ctrlComment.Text.ToString(), ctrlStartDate.Value, ctrlEndDate.Value, RepeatStartDate.Value, RepeatEndDate.Value, ctrlPlace.Text.ToString());
                        Redirect();
                        return null;
                    } break;
                    return null;
            }
            return null;
        }
        protected void Redirect()
        {
            Response.Redirect("~/forms/Event/EventL.aspx");
        }
    }
}