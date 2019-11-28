﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tzkt.Api.Models
{
    public class SystemOperation : IOperation
    {
        public string Type => "system";

        public int Id { get; set; }

        public int Level { get; set; }

        public DateTime Timestamp { get; set; }

        public string Hash { get; set; }

        public string Kind { get; set; }

        public Alias Account { get; set; }

        public long BalanceChange { get; set; }
    }
}
