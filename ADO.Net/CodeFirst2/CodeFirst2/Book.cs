namespace CodeFirst2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int Pages { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
