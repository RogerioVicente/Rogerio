using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_EF.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int IdCategoria { get; set; }
        public decimal PrecoProduto { get; set; }
        public string ImagemProduto { get; set; }
    }
}