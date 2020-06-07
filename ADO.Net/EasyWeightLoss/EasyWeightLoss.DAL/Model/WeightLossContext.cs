using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EasyWeightLoss.DAL.EFInfrastructure;

namespace EasyWeightLoss.DAL.Model
{
    public class WeightLossContext:DbContext
    {
        static WeightLossContext()
        {
            Database.SetInitializer<WeightLossContext>(new DbInitializer());
        }
        public WeightLossContext():base()
        { }
        public WeightLossContext(string connect):base(connect)
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasKey(key => key.ClientId);
            //modelBuilder.Entity<User>().Property(col => col.Login).HasColumnName("Nickname");
            //modelBuilder.Entity<User>().Property(log => log.Login).IsRequired().HasMaxLength(10);
            //modelBuilder.Entity<User>().Map(m => { m.Properties(p => new { p.ClientId, p.Login, p.Password }); m.ToTable("Clients"); }).
            //    Map(m =>
            //    {
            //        m.Properties(p => new { p.ClientId, p.Age, p.Sex, p.ActivityLevel }); m.ToTable("ClientProfiles");
            //    });
            //modelBuilder.Entity<User>().HasMany(u => u.Roles).WithMany(r => r.Users)
            //    .Map(m => { m.ToTable("ClientRoles");m.MapLeftKey("ClientId");m.MapRightKey("RoleId");});
            modelBuilder.Configurations.Add(new UserConfiguration());
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<DailyCalories> DailyCalories { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Product> Products { get; set; }  
    }
}
