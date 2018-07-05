using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmCrossDemo.Core.Services
{
    public interface IGreetingService
    {
        string GetGreetingText(string name);
    }
}
