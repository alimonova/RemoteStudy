﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Models
{
    public class TokenSettings
    {
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
    }
}
