using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClepsydraLite.DAL.Entities.Supplier
{
    public class SupplierProductOffer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public string BarCode { get; set; }
        
        public ICollection<SupplierProductOfferPrice> SupplierProductPriceOffers { get; set; } = new List<SupplierProductOfferPrice>();

        [ForeignKey("SupplierProductCategoryId")]
        public SupplierProductCategory SupplierProductCategory { get; set; }
        public int SupplierProductCategoryId { get; set; }


    }
}