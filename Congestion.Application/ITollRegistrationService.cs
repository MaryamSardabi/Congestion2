﻿using CongestionDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congestion.Application
{
    public interface ITollRegistrationService
    {
        Task AddTollRegistraionAsync(int cityId, int congestionId, string tag, CancellationToken ct);      

    }
}
