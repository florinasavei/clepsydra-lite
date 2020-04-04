using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClepsydraLite.DAL.Entities.Supplier
{
    public class SupplierProductCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public ICollection<SupplierProductOffer> SupplierProductOffer { get; } = new List<SupplierProductOffer>();

        [ForeignKey("SupplierCoreId")]
        public SupplierCore SupplierCore { get; set; }
        public int SupplierCoreId { get; set; }
    }
}