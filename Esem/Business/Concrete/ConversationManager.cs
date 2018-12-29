using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ConversationManager : IConversationService
    {
        private IConversationDal conversationDal;
        private IMessageDal messageDal;

        public ConversationManager(IConversationDal conversationDal, IMessageDal messageDal)
        {
            this.conversationDal = conversationDal;
            this.messageDal = messageDal;
        }

        public List<Message> GetMessages(int fromId, int toId)
        {
            Conversation conversation = conversationDal.Get(x => x.FromUserId == fromId && x.ToUserId == toId);

            return messageDal.GetList(x => x.ConversationId == conversation.Id);
        }

        public void SendMessage(int fromId, int toId, string text)
        {
            Conversation conversation = conversationDal.Get(x => x.FromUserId == fromId && x.ToUserId == toId);

            Message message = new Message() { ConversationId = conversation.Id, SentDate = DateTime.Now };
            messageDal.Add(message);
        }
    }
}
