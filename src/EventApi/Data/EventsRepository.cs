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

        public string Save(SaveRequestDto dto)
        {
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
                        var serializedEventDto = JObject.FromObject(dto.EventDto).ToString();
                        command.Parameters.Add(new SqlParameter { ParameterName = "@EventData", DbType = DbType.String, Value = serializedEventDto });
                        var scalar = command.ExecuteScalar();
                        var output = scalar as string;
                        if (output == null)
                        {
                            throw new Exception("Unknown error");
                        }
                        if (!output.Contains("{"))
                        {
                            // consider it as error message
                            throw new Exception(output);
                        }
                        return output;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
