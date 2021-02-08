using System;
using System.Collections.Generic;
using System.Text;

namespace TestPocApp.Core.Services
{
    public class AccountService : IAccountService
    {
        public string GetGreetingText(string name)
        {
            return $"Hello World, {name}.";
        }
    }
}

