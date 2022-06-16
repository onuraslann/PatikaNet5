﻿using System;

namespace Patika.WebApi.Services
{
    public class DbLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] - : " + message);
        }
    }
}
