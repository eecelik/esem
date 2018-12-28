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
        public string Price { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public Account Account { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
    }
}
