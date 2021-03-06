﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IConversationService
    {
        void SendMessage(int fromId, int toId, string text);
        List<Message> GetMessages(int fromId, int toId);
    }
}
