namespace ClepsydraLite.DAL.Models.Supplier.Category.ProductOffer.ProductPrice
{
    public class SupplierProductPriceOfferDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int SupplierId { get; set; }
    }
}
