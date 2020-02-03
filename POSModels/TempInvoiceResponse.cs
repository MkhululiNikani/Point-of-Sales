﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModels
{
    public class TempInvoiceResponse
    {
        public string date_time { get; set; }
        public string version { get; set; }
        public string error_type { get; set; }
        public string message { get; set; }

        [JsonProperty]
        public List<TempInvoice> data { get; set; }
    }
}

