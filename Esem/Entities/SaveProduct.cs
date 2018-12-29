using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SaveProduct : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AccountId { get; set; }
    }
}
