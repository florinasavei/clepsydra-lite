using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClepsydraLite.DAL.Entities.Supplier
{
    public class SupplierCore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Telephone { get; set; }

        public ICollection<SupplierProductCategory> SupplierProductCategories { get; } = new List<SupplierProductCategory>();


    }
}