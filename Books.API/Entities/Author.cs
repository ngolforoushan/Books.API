using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Books.API.Entities
{
    [Table("Author")]
    public class Author
    {
        public Author()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
        }

        [Key] public Guid Id { get; set; }

        [Required] [MaxLength(150)] [NotNull] public string FirstName { get; set; }

        [Required] [MaxLength(150)] public string LastName { get; set; }
    }
}
