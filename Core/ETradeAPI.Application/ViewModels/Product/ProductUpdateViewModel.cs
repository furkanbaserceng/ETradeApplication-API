using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.ViewModels.Product
{
    public class ProductUpdateViewModel
    {

        public string Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Stock { get; set; }
        public float Price { get; set; }

    }
}
