using System;
using System.Collections.Generic;
using System.Text;

namespace TestPocApp.Core.Services
{
    public class GreetingService: IGreetingService
    {
        public string GetGreetingText(string name)
        {
            return $"Hello World, {name}.";
        }
    }
}
