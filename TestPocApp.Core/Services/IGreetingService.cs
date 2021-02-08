using System;
using System.Collections.Generic;
using System.Text;

namespace TestPocApp.Core.Services
{
    public interface IGreetingService
    {
        string GetGreetingText(string name);
    }
}
