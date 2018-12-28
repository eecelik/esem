using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PublishedProduct : IEntity
    {
        public int Id { get; private set; }
        public int ProductId { get; set; }
        public int AccountId { get; set; }
    }
}
