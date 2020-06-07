using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstMigrationManyToMany.Model
{
    class ContextInitializer:DropCreateDatabaseAlways<FootballContext>
    {
        protected override void Seed(FootballContext context)
        {
            Player pl1 = new Player { Name = "Роналду", Age = 31, Position = "Нападающий" };
            Player pl2 = new Player { Name = "Месси", Age = 28, Position = "Нападающий" };
            Player pl3 = new Player { Name = "Хави", Age = 34, Position = "Полузащитник" };
            context.Players.AddRange(new List<Player> { pl1, pl2, pl3 });
            context.SaveChanges();
            Team t1 = new Team { Name = "Барселона",Country="Испания" };
            t1.Players.Add(pl2);
            t1.Players.Add(pl3);
            Team t2 = new Team { Name = "Реал Мадрид",Country="Испания" };
            t2.Players.Add(pl1);
            context.Teams.Add(t1);
            context.Teams.Add(t2);
            context.SaveChanges();
        }
    }
}
