using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IConversationService
    {
        void SendMessage(string fromId, string toId, string message);
        List<string> GetMessages(int fromId, int toId);
    }
}
