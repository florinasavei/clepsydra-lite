using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClepsydraLite.DAL.Common;

namespace ClepsydraLite.DAL.Entities.Supplier
{
    public class SupplierProductOfferPrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public PriceType PriceType { get; set; }

        public decimal PriceValue { get; set; }
        
        [ForeignKey("SupplierProductOfferId")]
        public SupplierProductOffer SupplierProductOffer { get; set; }
        public int SupplierProductOfferId { get; set; }
      
    }
}