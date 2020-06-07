using EasyWeightLoss.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyWeightLoss.DAL.EFInfrastructure
{
    class UserConfiguration:EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(key => key.ClientId);
            Property(col => col.Login).HasColumnName("Nickname");
            Property(log => log.Login).IsRequired().HasMaxLength(10);
            Map(m => { m.Properties(p => new { p.ClientId, p.Login, p.Password }); m.ToTable("Clients"); }).
                Map(m =>
                {
                    m.Properties(p => new { p.ClientId, p.Age, p.Sex, p.ActivityLevel }); m.ToTable("ClientProfiles");
                });
            HasMany(u => u.Roles).WithMany(r => r.Users)
                .Map(m => { m.ToTable("ClientRoles"); m.MapLeftKey("ClientId"); m.MapRightKey("RoleId"); });
        }
    }
}
