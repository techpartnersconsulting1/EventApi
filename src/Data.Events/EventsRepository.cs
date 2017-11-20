using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;

namespace Data.Events
{
    public class EventsRepository : IEventsRepository
    {
        public EventsRepository(string ConnectionString)
        {
            OptionsConString = ConnectionString;
        }

        private string OptionsConString { get; }

        public EventDtoList Search(SearchDto dto)
        {
            var eventList = new EventDtoList();

            // Provide the query string with a parameter placeholder.
            var queryString = "[dbo].[sp_AdmGetEvents]";

            using (var connection = new SqlConnection(OptionsConString))
            {
                // Create the Command and Parameter objects.
                using (var command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@SchoolID",
                            DbType = DbType.Int32,
                            Value = Convert.ToInt32(dto.SchoolId)
                        });
                        command.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@SchoolDistrictID",
                            DbType = DbType.Int32,
                            Value = Convert.ToInt32(dto.SchoolDistrictId)
                        });
                        command.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@Email",
                            DbType = DbType.String,
                            Value = dto.userId
                        });
                        var scalar = command.ExecuteScalar() as string;
                        if (!string.IsNullOrWhiteSpace(scalar))
                        {
                            var jObj = JObject.Parse(scalar);
                            var jDto = jObj["dto"];
                            if (jDto != null)
                            {
                                var jarray = jDto["events"] as JArray;
                                var list = jarray?.ToObject<List<EventDto>>();
                                if (list != null)
                                    eventList.Events.AddRange(list);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return eventList;
        }

        public string Save(EventDto dto)
        {
            var queryString = "[dbo].[sp_AdmAddEvent]";
            using (var connection = new SqlConnection(OptionsConString))
            {
                // Create the Command and Parameter objects.
                using (var command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        var serializedEventDto = JObject.FromObject(dto).ToString();
                        command.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@EventData",
                            DbType = DbType.String,
                            Value = serializedEventDto
                        });
                        var scalar = command.ExecuteScalar();
                        var output = scalar as string;
                        if (output == null)
                            throw new Exception("Unknown error");
                        if (!output.Contains("{"))
                            throw new Exception(output);
                        return output;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
    }
}