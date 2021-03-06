﻿using AndersonCRMEntity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AndersonCRMContext
{
    public class Context : DbContext
    {

        public Context() : base("AndersonCRM")
        {
            Database.SetInitializer(new DBInitializer());

            if (Database.Exists())
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());
            }
            else
            {
                Database.SetInitializer(new DBInitializer());
            }
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public DbSet<ECompany> Companies { get; set; }
        public DbSet<EDepartment> Departments { get; set; }
        public DbSet<EEmployee> Employees { get; set; }
        public DbSet<EPeripheral> Peripherals { get; set; }
        public DbSet<EPosition> Positions { get; set; }
        public DbSet<EPeripheralHistory> PeripheralHistories { get; set; }

    }
}
