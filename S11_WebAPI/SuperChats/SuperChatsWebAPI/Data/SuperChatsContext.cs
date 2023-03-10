using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperChatsWebAPI.Models;

namespace SuperChatsWebAPI.Data
{
    public class SuperChatsContext : DbContext
    {
        public SuperChatsContext (DbContextOptions<SuperChatsContext> options)
            : base(options)
        {
        }

        public DbSet<Cat> Cat { get; set; } = default!;

        public DbSet<SuperChatsWebAPI.Models.Villager> Villager { get; set; }
    }
}
