using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmCrossDemo.Core.Services
{
    public class GreetingService: IGreetingService
    {
        public string GetGreetingText(string name)
        {
            return $"Hello World, {name}.";
        }
    }
}
