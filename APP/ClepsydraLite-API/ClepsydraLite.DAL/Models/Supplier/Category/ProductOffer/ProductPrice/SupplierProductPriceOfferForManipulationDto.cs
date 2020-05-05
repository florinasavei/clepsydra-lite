using System.ComponentModel.DataAnnotations;

namespace ClepsydraLite.DAL.Models.Supplier.Category.ProductOffer.ProductPrice
{
    public abstract class SupplierProductPriceOfferForManipulationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1500)]
        public virtual string Description { get; set; }
    }
}