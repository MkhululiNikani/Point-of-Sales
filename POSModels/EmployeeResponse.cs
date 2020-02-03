using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModels
{
    public class EmployeeResponse
    {
        public string date_time { get; set; }
        public string version { get; set; }
        public string error_type { get; set; }
        public string message { get; set; }

        [JsonProperty]
        public List<Employee> data { get; set; }
    }
}