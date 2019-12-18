using Microsoft.EntityFrameworkCore;
using MVC_EF.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_EF.DBContext
{
    public class ProdutosDBContext : System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<Produtos> produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}