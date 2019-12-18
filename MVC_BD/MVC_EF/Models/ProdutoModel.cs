using AutoMapper;
using MVC_EF.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_EF.Models
{
    public class ProdutoModel
    {
        EstudoEntities _context = new EstudoEntities();
        public ProdutoModel()
        {

        }

        public List<Produto> RetornaProdutos()
        {
            List<Produto> produtos;
            using (var context = new EstudoEntities())
            {
                produtos = context.Produtos.ToList();
            }
            return produtos;
        }
    }
}