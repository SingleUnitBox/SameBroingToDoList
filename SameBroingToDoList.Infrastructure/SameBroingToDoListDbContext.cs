using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SameBroingToDoList.Domain.Entities;
using SameBroingToDoList.Infrastructure.Persistence.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Infrastructure
{
    public class SameBroingToDoListDbContext : DbContext
    {
        public SameBroingToDoListDbContext(DbContextOptions<SameBroingToDoListDbContext> dbContextOptions)
            : base(dbContextOptions)
        {           
        }
        public DbSet<ToDoList> ToDoLists { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var toDoListConfiguration = new ToDoListConfiguration();
        }
    }
}
