using System;
using Data.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using School.Api.Event.Model;
using School.Api.Event.Services;

namespace EventApi.Controllers
{
    [Route("v1/[controller]")]
    [Produces("application/json")]
    public class EventsController : Controller
    {
        private IEventsRepository Repository { get; }

        public EventsController(IOptions<ConfigOptions> opt)
        {
            var connString = opt.Value.ConnectionString;
            Repository = new EventsRepository(connString);
        }

        [HttpPost]
        [Route("Search")]
        public IActionResult Search([FromBody] SearchRequest request)
        {
            ObjectResult result = null;
            try
            {
                var resp = new Response<EventDtoList>();
                var foundList = Repository.Search(request.Request);
                resp.SetDto(foundList);
                resp.Message = "Data retrieved.";
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                var errDt = new ExceptionDetails {Message = ex.StackTrace};
                var errResp = new ErrorResponse();
                errResp.SetException(errDt);
                result = StatusCode(500, errResp);
            }
            return result;
        }


        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody] SaveRequest request)
        {
            ObjectResult result = null;
            try
            {
                var resp = new Response<EventDto>();
                var jsonResp = Repository.Save(request.Request.EventDto);
                var jobj = JObject.Parse(jsonResp);
                var newEvent = jobj.ToObject<EventDto>();
                resp.SetDto(newEvent);
                resp.Message = "Event saved.";
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                var errResp = new ErrorResponse();
                var errDt = new ExceptionDetails();
                errDt.Message = ex.StackTrace;

                errResp.SetException(errDt);
                result = StatusCode(500, errResp);
            }
            return result;
        }


        [HttpGet]
        [Route("EventTypes")]
        public IActionResult GetAllEventTypes()
        {
            ObjectResult result = null;
            try
            {
                var resp = new Response<EventTypesDtoList>();
                var list = new EventTypesDtoList();
                list.EventTypes.Add(new EventTypeDto {Id = "School", Name = "School"});
                list.EventTypes.Add(new EventTypeDto {Id = "Grade", Name = "Grade"});
                list.EventTypes.Add(new EventTypeDto {Id = "Class", Name = "Class"});
                list.EventTypes.Add(new EventTypeDto {Id = "School District", Name = "School District"});
                resp.SetDto(list);
                resp.Message = "Data retrieved.";
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                var errResp = new ErrorResponse();
                var errDt = new ExceptionDetails();
                errDt.Message = ex.StackTrace;

                errResp.SetException(errDt);
                result = StatusCode(500, errResp);
            }

            return result;
        }

        [HttpGet]
        [Route("ActiveTypes")]
        public IActionResult ActiveTypes()
        {
            ObjectResult result = null;
            try
            {
                var resp = new Response<ActiveTypesDtoList>();
                var list = new ActiveTypesDtoList();
                list.ActiveTypes.Add(new ActiveTypesDto {Name = "Active", Id = "Active"});
                list.ActiveTypes.Add(new ActiveTypesDto {Name = "InActive", Id = "InActive"});

                resp.SetDto(list);
                resp.Message = "Data retrieved.";
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                var errResp = new ErrorResponse();
                var errDt = new ExceptionDetails();
                errDt.Message = ex.StackTrace;

                errResp.SetException(errDt);
                result = StatusCode(500, errResp);
            }

            return result;
        }


        [HttpGet]
        [Route("OccuranceTypes")]
        public IActionResult OccuranceTypes()
        {
            ObjectResult result = null;
            try
            {
                var resp = new Response<OccuranceTypeList>();
                var list = new OccuranceTypeList();
                list.OccurenceTypes.Add(new OccuranceTypeDto {Id = "Weekly", Name = "Weekly"});
                list.OccurenceTypes.Add(new OccuranceTypeDto {Id = "One Time", Name = "One Time"});
                list.OccurenceTypes.Add(new OccuranceTypeDto {Id = "Custom", Name = "Custom"});

                resp.SetDto(list);
                resp.Message = "Data retrieved.";
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                var errResp = new ErrorResponse();
                var errDt = new ExceptionDetails();
                errDt.Message = ex.StackTrace;

                errResp.SetException(errDt);
                result = StatusCode(500, errResp);
            }

            return result;
        }
    }
}