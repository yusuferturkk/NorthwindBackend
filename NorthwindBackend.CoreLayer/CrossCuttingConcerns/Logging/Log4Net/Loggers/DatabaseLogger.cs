﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.CoreLayer.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class DatabaseLogger : LoggerServiceBase
    {
        public DatabaseLogger() : base("DatabaseLogger")
        {
        }
    }
}
