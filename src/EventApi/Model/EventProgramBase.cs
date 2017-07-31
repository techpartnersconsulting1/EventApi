using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace School.Api.Event.Model
{
 


    public class EventAssociation
    {
        public string EventType { get; set; } = string.Empty;
        public List<string> GradeIds = new List<string>();
        public List<string> ClassIds = new List<string>();
        public List<string> SchoolIds = new List<string>();
        public List<string> SchoolDistrictIds = new List<string>();



    }

    public class EventDtoList
    {
        public List<EventDto> Events = new List<EventDto>();

    }
    public class EventDto
    {
        //public EventType EventType { get; set; } = new EventType();
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LocationVenue { get; set; } = string.Empty;
        public OccuranceTypeDto OccuranceType { get; set; } = new OccuranceTypeDto();
        public string NeedStudentEnrollment { get; set; } = string.Empty;
        public string  IsActive { get; set; } = string.Empty;
        public string CreateDate { get; set; } = string.Empty;
        public string CreateUser { get; set; } = string.Empty;
        public string UpdateUser { get; set; } = string.Empty;
        public string UpdateDate { get; set; } = string.Empty;

        public List<ScheduleDto> Schedules { get; set; } = new List<ScheduleDto>();
        public EventAssociationDto Association = new EventAssociationDto();


    }




    public class ScheduleDto
    {
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;

        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;

       

        public List<string> WeekDays { get; set; } = new List<string>();
    }

    public class EventAssociationDto
    {
        public EventTypeDto EventType { get; set; } = new EventTypeDto();
        public List<string> GradeIds = new List<string>();
        public List<string> ClassIds = new List<string>();
        public List<string> SchoolIds = new List<string>();
        public List<string> SchoolDistrictIds = new List<string>();






    }



    public class EventSearchDto 
        {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;

        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;

        public string LocationVenue { get; set; } = string.Empty;




    }



}
