using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace School.Api.Event.Model
{
    public class EventType
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string NotificationTemplate { get; set; } = string.Empty;
        public string CreateDate { get; set; } = string.Empty;
        public string CreateUser { get; set; } = string.Empty;
        public string UpdateUser { get; set; } = string.Empty;
        public string UpdateDate { get; set; } = string.Empty;
        public string IsActive { get; set; } = string.Empty;
    }


    public class EventTypeDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
     
    }

    public class EventTypesDtoList
    {
        public List<EventTypeDto> EventTypes { get; set; } = new List<EventTypeDto>();

    }



}
