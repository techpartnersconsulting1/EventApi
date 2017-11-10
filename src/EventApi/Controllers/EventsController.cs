using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Api.Event.Data;
using School.Api.Event.Model;


namespace EventApi.Controllers
{
    [Route("v1/[controller]")]
    [Produces("application/json")]
    public class EventsController : Controller
    {
        private IEventsRepository Repository
        {
            get;
        }


        [HttpPost]
        [Route("Search")]
        public IActionResult Search([FromBody] SearchRequest request)
        {
            ObjectResult result = null;
            try
            {
                Response<EventDtoList> resp = new Response<EventDtoList>();
                var foundList = Repository.Search(request.Request);
                resp.SetDto(foundList);
                resp.Message = "Data retrieved.";
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                ErrorResponse errResp = new ErrorResponse();
                ExceptionDetails errDt = new ExceptionDetails();
                errDt.Message = ex.StackTrace;

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
                Response<EventDto> resp = new Response<EventDto>();
                var dto = Repository.Save(request.Request);
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
                list.EventTypes.Add(new EventTypeDto {Id = "1", Name = "School" });
                list.EventTypes.Add(new EventTypeDto { Id = "2", Name = "Grade" });
                list.EventTypes.Add(new EventTypeDto { Id = "3", Name = "Class" });
                list.EventTypes.Add(new EventTypeDto { Id = "4", Name = "School District" });
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
                list.OccurenceTypes.Add(new OccuranceTypeDto { Id= "1" ,Name= "Weekly" });
                list.OccurenceTypes.Add(new OccuranceTypeDto { Id = "2", Name = "One Time" });
                list.OccurenceTypes.Add(new OccuranceTypeDto { Id = "3", Name = "Custom" });

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
