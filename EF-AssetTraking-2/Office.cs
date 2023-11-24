using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_AssetTraking_2
{
    internal class Office
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Asset> Asset { get; set; }
    }
}
