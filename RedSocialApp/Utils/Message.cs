using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RedSocialApp.Utils
{
    class Message : ValueChangedMessage<string>
    {
        public Message(string value) : base(value)
        {

        }
    }
}