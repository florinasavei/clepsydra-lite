namespace ClepsydraLite.DAL.Models.Supplier.Category.ProductOffer
{
    public class SupplierProductOfferDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int SupplierId { get; set; }
    }
}
