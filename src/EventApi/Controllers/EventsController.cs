using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Api.Event.Model;


namespace EventApi.Controllers
{
    [Route("v1/[controller]")]
    [Produces("application/json")]
    public class EventsController : Controller
    {
        // GET api/values
        [HttpPost]
        [Route("Search")]
        public IActionResult Search([FromBody] SearchRequest request)
        {
           
            
            ObjectResult result = null;
            try
            {
                Response<EventDtoList> resp = new Response<EventDtoList>();
                // dto = new School.Api.Event.Model.EventDto();
                EventDtoList list = new School.Api.Event.Model.EventDtoList();
                EventDto dto1 = new EventDto();
                dto1.Id = "123";
                dto1.Name = "Test1";
                dto1.LocationVenue = "Class room";
                dto1.NeedStudentEnrollment = "No";
                dto1.OccuranceType = new OccuranceTypeDto { Id = "One Time", Name = "One Time" };
                dto1.IsActive = "Active";
                dto1.Schedules = new List<ScheduleDto>();
                dto1.Schedules.Add(new ScheduleDto { StartDate = "08/27/2017", EndDate = "08/27/2017", StartTime = "11:00 AM", EndTime = "12:00 PM" });
                dto1.Association = new EventAssociationDto();
                dto1.Association.EventType = new School.Api.Event.Model.EventTypeDto { Id = "1", Name = "Class" }; 
                dto1.Association.ClassIds = new List<string> { "1" };
                list.Events.Add(dto1);
                resp.SetDto(list);
                resp.Message = "Data retrieved.";
                result = new OkObjectResult(resp);
                
                
            }
            catch (Exception ex)
            {
                ErrorResponse errResp = new School.Api.Event.Model.ErrorResponse();
                ExceptionDetails errDt = new School.Api.Event.Model.ExceptionDetails();
                errDt.Message = ex.StackTrace;

                errResp.SetException(errDt);
                result = StatusCode(500, errResp);

            }
            return result;

        }


        // GET api/values
        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody] SaveRequest request)
        {
            
            ObjectResult result = null;
            try
            {
                Response<EventDto> resp = new Response<EventDto>();
                EventDto dto = new School.Api.Event.Model.EventDto();
                resp.SetDto(dto);
                resp.Message = "Saved.";
                result = new OkObjectResult(resp);

            }
            catch (Exception ex)
            {
                ErrorResponse errResp = new School.Api.Event.Model.ErrorResponse();
                ExceptionDetails errDt = new School.Api.Event.Model.ExceptionDetails();
                errDt.Message = ex.StackTrace;

                errResp.SetException(errDt);
                result = StatusCode(500, errResp);

            }
            return result;

        }


        // GET api/values
        [HttpGet]
        [Route("EventTypes")]
        public IActionResult GetAllEventTypes()
        {
           
           
            ObjectResult result = null;
            try
            {
                Response<EventTypesDtoList> resp = new Response<EventTypesDtoList>();
                EventTypesDtoList list = new EventTypesDtoList();
                list.EventTypes.Add(new EventTypeDto {Id = "School", Name = "School" });
                list.EventTypes.Add(new EventTypeDto { Id = "Grade", Name = "Grade" });
                list.EventTypes.Add(new EventTypeDto { Id = "Class", Name = "Class" });
                list.EventTypes.Add(new EventTypeDto { Id = "School District", Name = "School District" });
                resp.SetDto(list);
                resp.Message = "Data retrieved.";
                result =  new OkObjectResult(resp);
            }
            catch(Exception ex)
            {
                ErrorResponse errResp = new School.Api.Event.Model.ErrorResponse();
                ExceptionDetails errDt = new School.Api.Event.Model.ExceptionDetails();
                errDt.Message = ex.StackTrace;

                errResp.SetException(errDt);
                result =  StatusCode(500, errResp);

            }

            return result;

        }

        // GET api/values
        [HttpGet]
        [Route("ActiveTypes")]
        public IActionResult ActiveTypes()
        {


            ObjectResult result = null;
            try
            {
                Response<ActiveTypesDtoList> resp = new Response<ActiveTypesDtoList>();
                ActiveTypesDtoList list = new ActiveTypesDtoList();
                list.ActiveTypes.Add(new ActiveTypesDto { Name = "Active" ,Id = "Active" });
                list.ActiveTypes.Add(new ActiveTypesDto { Name = "InActive" , Id = "InActive" });

                resp.SetDto(list);
                resp.Message = "Data retrieved.";
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                ErrorResponse errResp = new School.Api.Event.Model.ErrorResponse();
                ExceptionDetails errDt = new School.Api.Event.Model.ExceptionDetails();
                errDt.Message = ex.StackTrace;

                errResp.SetException(errDt);
                result = StatusCode(500, errResp);

            }

            return result;

        }



        // GET api/values
        [HttpGet]
        [Route("OccuranceTypes")]
        public IActionResult OccuranceTypes()
        {


            ObjectResult result = null;
            try
            {
                Response<OccuranceTypeList> resp = new Response<OccuranceTypeList>();
                OccuranceTypeList list = new School.Api.Event.Model.OccuranceTypeList();
                list.OccurenceTypes.Add(new OccuranceTypeDto { Id= "Weekly", Name= "Weekly" });
                list.OccurenceTypes.Add(new OccuranceTypeDto { Id = "One Time", Name = "One Time" });
                list.OccurenceTypes.Add(new OccuranceTypeDto { Id = "Custom", Name = "Custom" });

                resp.SetDto(list);
                resp.Message = "Data retrieved.";
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                ErrorResponse errResp = new School.Api.Event.Model.ErrorResponse();
                ExceptionDetails errDt = new School.Api.Event.Model.ExceptionDetails();
                errDt.Message = ex.StackTrace;

                errResp.SetException(errDt);
                result = StatusCode(500, errResp);

            }

            return result;

        }





    }
}
