using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Examen_ADO.NET_Task4_Tereshchenko.Model
{
    class DogShelterContext:DbContext
    {
        public DogShelterContext():base()
        { }
        public DogShelterContext(string connect):base(connect)
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breed>().ToTable("Kinds");
            modelBuilder.Entity<Breed>().Property(key => key.BreedId).HasColumnName("Id");
            modelBuilder.Entity<Breed>().Property(breed => breed.Breedname).HasColumnName("NameKind");
            modelBuilder.Entity<Dog>().Property(name => name.DogName).HasColumnName("Nickname");
            modelBuilder.Entity<Dog>().Property(kind => kind.BreedId).HasColumnName("KindId");
        }
        public virtual DbSet<Breed> Breeds { get; set; }
        public virtual DbSet<Dog> Dogs { get; set; }
    }
}
