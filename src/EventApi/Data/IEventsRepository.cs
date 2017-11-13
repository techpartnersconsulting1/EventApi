using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Api.Event.Model;

namespace School.Api.Event.Data
{
    public interface IEventsRepository
    {
        EventDtoList Search(SearchDto dto);
        string Save(SaveRequestDto dto);
    }
}
