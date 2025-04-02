using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataTransferObject
{
    public class RevenueSourceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsVisible { get; set; }

        public int DisplayOrder { get; set; }
    }
}
