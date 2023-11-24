using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_AssetTraking_2
{
    internal class Asset
    {
        public int Id { get; set; }
        public string AssetType { get; set; }
        public string Brand { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Price { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
    }
}
