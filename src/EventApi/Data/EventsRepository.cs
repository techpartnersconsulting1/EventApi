using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using School.Api.Event.Model;
using School.Api.Event.Services;

namespace School.Api.Event.Data
{
    public class EventsRepository : IEventsRepository
    {
        private ConfigOptions OptionsConString { get; }

        public EventsRepository(IOptions<ConfigOptions> optionsAccessor)
        {
            OptionsConString = optionsAccessor.Value;
        }

        public EventDtoList Search(SearchDto dto)
        {
            var eventList = new EventDtoList();

            // Provide the query string with a parameter placeholder.
            string queryString = "[dbo].[sp_AdmGetEvents]";

            using (SqlConnection connection = new SqlConnection(OptionsConString.ConnectionString))
            {
                // Create the Command and Parameter objects.
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter { ParameterName = "@SchoolID", DbType = DbType.Int32, Value = Convert.ToInt32(dto.SchoolId) });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@SchoolDistrictID", DbType = DbType.Int32, Value = Convert.ToInt32(dto.SchoolDistrictId) });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@Email", DbType = DbType.String, Value = dto.userId });
                        var dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            var jsonStr = dr["dto"] as string;
                            if (!string.IsNullOrWhiteSpace(jsonStr))
                            {
                                var jarray = JArray.Parse(jsonStr);
                                var list = jarray.ToObject<List<EventDto>>();
                                eventList.Events.AddRange(list);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return eventList;
        }

        public EventDto Save(SaveRequestDto dto)
        {
            // Provide the query string with a parameter placeholder.
            string queryString = "[dbo].[sp_AdmAddEvent]";

            using (SqlConnection connection = new SqlConnection(OptionsConString.ConnectionString))
            {
                // Create the Command and Parameter objects.
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter { ParameterName = "@id", DbType = DbType.String, Value = dto.EventDto.Id });
                        //command.Parameters.Add(new SqlParameter { ParameterName = "@FirstName", DbType = DbType.String, Value = dto.Request.Fname });
                        //command.Parameters.Add(new SqlParameter { ParameterName = "@LastName", DbType = DbType.String, Value = dto.Request.Lname });
                        //command.Parameters.Add(new SqlParameter { ParameterName = "@UserTypeId", DbType = DbType.Decimal, Value = Convert.ToDecimal(dto.Request.UserTypeId, CultureInfo.InvariantCulture) });
                        //command.Parameters.Add(new SqlParameter { ParameterName = "@SchoolID", DbType = DbType.Int32, Value = Convert.ToInt32(dto.Request.SchoolId) });
                        //command.Parameters.Add(new SqlParameter { ParameterName = "@SchoolDistrictID", DbType = DbType.Int32, Value = Convert.ToInt32(dto.Request.SchooldistrictId) });
                        //command.Parameters.Add(new SqlParameter { ParameterName = "@IsActive", DbType = DbType.String, Value = dto.Request.IsActive });
                        var dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            EventDto eventDto = new EventDto();
                            //eventDto.Fname = dr["FirstName"].ToString();
                            //eventDto.Lname = dr["LastName"].ToString();
                            //eventDto.UserIdEmail = dr["Email"].ToString();
                            //eventDto.SchooldistrictId = dr["SchoolDistrictID"].ToString();
                            //eventDto.SchoolId = dr["SchoolID"].ToString();

                            //eventDto.UserTypeId = dr["UserType"].ToString(); //"Superuser_School"
                            //eventDto.Id = dr["userid"].ToString();
                            //eventDto.IsActive = dto.Request.IsActive;
                            return eventDto;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                return null;
            }
        }
    }
}
