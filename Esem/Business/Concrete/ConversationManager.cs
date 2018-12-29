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
        private IProductDal productDal;

        public ConversationManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public List<string> GetMessages(int fromId, int toId)
        {
            List<Product> conversations = productDal.GetList().Where(x => x.CategoryId == fromId && x.AccountId == toId).ToList();

            List<string> messages = new List<string>();
            foreach (Product conversation in conversations)
            {
                messages.Add(conversation.Description);
            }

            return messages;
        }

        public void SendMessage(string fromId, string toId, string message)
        {
            throw new NotImplementedException();
        }
    }
}
