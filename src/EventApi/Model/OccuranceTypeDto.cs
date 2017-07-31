using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Api.Event.Model
{
    public class OccuranceTypeDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }

    public class OccuranceTypeList
    {
        public List<OccuranceTypeDto> OccurenceTypes = new List<OccuranceTypeDto>();
    }
}
