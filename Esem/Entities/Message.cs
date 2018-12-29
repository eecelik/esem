using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Message : IEntity
    {
        public int Id { get; set; }
        public int ConversationId { get; set; }
        public DateTime? SentDate { get; set; }
    }
}
