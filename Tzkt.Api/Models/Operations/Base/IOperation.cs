﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tzkt.Api.Models
{
    public interface IOperation
    {
        string Type { get; }

        int Id { get; }

        int Level { get; }

        DateTime Timestamp { get; }

        string Hash { get; }
    }
}
