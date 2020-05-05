using System.ComponentModel.DataAnnotations;

namespace ClepsydraLite.DAL.Models.Supplier.Category.ProductOffer.ProductPrice
{
    public class SupplierProductPriceOfferForUpdateDto: SupplierProductOfferForManipulationDto
    {
        [Required]
        public override  string Description
        {
            get => base.Description;
            set => base.Description = value;
        }
    }
}
