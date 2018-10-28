using MvvmCross.Plugin.Messenger;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmCrossDemo.Core.Infrastructure.Messages
{
    public class LaunchTimeMessage : MvxMessage
    {
        public LaunchTimeMessage(object sender, TimeSpan timeSpan) : base(sender)
        {
            TimeSpan = timeSpan;
        }

        public TimeSpan TimeSpan { get; }
    }
}
