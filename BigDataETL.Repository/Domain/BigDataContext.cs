using BigDataETL.Repository.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigDataETL.Repository.Domain
{
    public class BigDataContext(DbContextOptions<BigDataContext> options) : DbContext(options)
    {
        public DbSet<Flight> Flights { get; set; }
    }
}
