using Microsoft.EntityFrameworkCore;
using MOS_CBT_CoreMgt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOS_CBT_CoreMgt.Services
{
    public class CbtCoreContext : DbContext
    {
        public CbtCoreContext(DbContextOptions<CbtCoreContext> options) :base(options)
        { }
        public DbSet<Course> Course { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<AnswerModel> AnswerModels { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>().HasKey(m => m.id);
            builder.Entity<Profile>().HasKey(m => m.id);
            // builder.Entity.
            base.OnModelCreating(builder);
        }
    }
}
