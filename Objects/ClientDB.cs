﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IIS.calendar
{
    using System;
    using System.Xml;
    using ICSSoft.STORMNET;
    
    
    // *** Start programmer edit section *** (Using statements)

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Client DB.
    /// </summary>
    // *** Start programmer edit section *** (ClientDB CustomAttributes)

    // *** End programmer edit section *** (ClientDB CustomAttributes)
    [ClassStorage("STORMAG")]
    [AutoAltered()]
    [Caption("Участники")]
    [AccessType(ICSSoft.STORMNET.AccessType.none)]
    [View("ClientDBE", new string[] {
            "Name as \'Имя\'"})]
    [View("ClientDBL", new string[] {
            "Name as \'Имя\'"})]
    public class ClientDB : ICSSoft.STORMNET.DataObject
    {
        
        private string fName;
        
        // *** Start programmer edit section *** (ClientDB CustomMembers)

        // *** End programmer edit section *** (ClientDB CustomMembers)

        
        /// <summary>
        /// Name.
        /// </summary>
        // *** Start programmer edit section *** (ClientDB.Name CustomAttributes)

        // *** End programmer edit section *** (ClientDB.Name CustomAttributes)
        [StrLen(80)]
        public virtual string Name
        {
            get
            {
                // *** Start programmer edit section *** (ClientDB.Name Get start)

                // *** End programmer edit section *** (ClientDB.Name Get start)
                string result = this.fName;
                // *** Start programmer edit section *** (ClientDB.Name Get end)

                // *** End programmer edit section *** (ClientDB.Name Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (ClientDB.Name Set start)

                // *** End programmer edit section *** (ClientDB.Name Set start)
                this.fName = value;
                // *** Start programmer edit section *** (ClientDB.Name Set end)

                // *** End programmer edit section *** (ClientDB.Name Set end)
            }
        }
        
        /// <summary>
        /// Class views container.
        /// </summary>
        public class Views
        {
            
            /// <summary>
            /// "ClientDBE" view.
            /// </summary>
            public static ICSSoft.STORMNET.View ClientDBE
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("ClientDBE", typeof(IIS.calendar.ClientDB));
                }
            }
            
            /// <summary>
            /// "ClientDBL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View ClientDBL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("ClientDBL", typeof(IIS.calendar.ClientDB));
                }
            }
        }
    }
}