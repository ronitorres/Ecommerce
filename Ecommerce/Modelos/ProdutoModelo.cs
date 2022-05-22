using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Modelos
{
    public class Produto
    {

        public string Id { get; set; }
        public string Codigo { get; set; }
        public string  Nome { get; set; }
        public double  PrecoUnitario { get; set; }
        public string IMG { get; set; }

    }
}
