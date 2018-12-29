using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product : IEntity
    {
        public int Id { get; private set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string LongLat { get; set; }
        public int AccountId { get; set; }
        public string City { get; set; }
        public string FormattedAddress { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
