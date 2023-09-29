using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.Model;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;


namespace TransportModel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Clients> Clients { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Instruction> Instruction { get; set; }
        public DbSet<InstructionProduct> InstructionProduct { get; set; }
       // public DbSet<TransportScheduled> TransportScheduled { get; set; }
        public DbSet<Transporter> Transporters { get; set; }


    }
}
