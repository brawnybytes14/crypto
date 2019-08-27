using Crypto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypto
{
    public class CryptoDbContext : DbContext
    {
        public DbSet<History> Histories { get; set; }
        public DbSet<ApiKey> ApiKeys { get; set; }

        public CryptoDbContext(DbContextOptions<CryptoDbContext> options) : base(options)
        {

        }
    }
}
