using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using EstoqueFacil.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace EstoqueFacil.Banco
{
    public class Connection : DbContext
    {
        public DbSet<Produto> tbl_Produtos { get; set; }

        private string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EstoqueFacil;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connection);
            //loga todos as chamadas do EF ao BD
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Debug);

        }
    }
}