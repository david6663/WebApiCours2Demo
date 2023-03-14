using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperChatsWebAPI.Models;

namespace SuperChatsWebAPI.Data
{
    public class SuperChatsContext : IdentityDbContext<User>
    {
        public SuperChatsContext (DbContextOptions<SuperChatsContext> options)
            : base(options)
        {
        }

        public DbSet<Cat> Cat { get; set; } = default!;

        public DbSet<SuperChatsWebAPI.Models.Villager> Villager { get; set; }
    }
}
