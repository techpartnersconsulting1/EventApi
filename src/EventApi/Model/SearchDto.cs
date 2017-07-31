using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Api.Event.Model
{
    public class SearchDto
    {
        public string State { get; set; } = string.Empty;
        public string SchoolId { get; set; } = string.Empty;

        public string SchoolDistrictId { get; set; } = string.Empty;

        public string userId { get; set; } = string.Empty;
        

    }
}
