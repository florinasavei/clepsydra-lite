using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClepsydraLite.DAL;
using ClepsydraLite.DAL.Entities;
using ClepsydraLite.DAL.Entities.Supplier;
using ClepsydraLite.DAL.Services;
using ClepsydraLite.DAL.Models.Supplier;
using ClepsydraLite.DAL.Models.Supplier.Category;
using ClepsydraLite.DAL.Models.Supplier.Category.ProductOffer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClepsydraLite.API.Controllers
{
    [ApiController]
    [Route("api/supplier/{supplierId}/SupplierProductCategory/{supplierProductCategoryId}/SupplierProductOffer/{supplierProductId}/[controller]")]
    public class SupplierProductPriceOfferController : ControllerBase
    {
        private readonly IShopRepository _shopRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SupplierController> _logger;

        public SupplierProductPriceOfferController(ILogger<SupplierController> logger, IShopRepository shopRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _shopRepository = shopRepository ?? throw new ArgumentException(nameof(shopRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<SupplierProductOfferDto>> GetProductPricesFromCategoryForSuppliers(int supplierId, int supplierProductCategoryId, int supplierProductId)
        {
            if (!_shopRepository.SupplierExists(supplierId))
            {
                _logger.LogInformation($"Supplier with id {supplierId} was not found");
                return NotFound();
            }

            try
            {
                var productCategoriesForSupplier = _shopRepository.GetProductPricesForSupplier(supplierId, supplierProductCategoryId, supplierProductId);
                return Ok(_mapper.Map<IEnumerable<SupplierProductOfferDto>>(productCategoriesForSupplier));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while getting suppliers", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpGet("{priceId}", Name = "GetProductPriceFromCategoryForSupplier")]
        public ActionResult<SupplierProductOfferDto> GetProductPriceFromCategoryForSupplier(int supplierId, int supplierProductCategoryId, int supplierProductId, int priceId)
        {
            var supplier = _shopRepository.GetProductPriceForSupplier(supplierId, supplierProductCategoryId, supplierProductId, priceId);

            if (supplier == null)
            {
                _logger.LogInformation($"Supplier with id {supplierId} was not found");
                return NotFound();
            }

            return Ok(_mapper.Map<SupplierProductOfferDto>(supplier));
        }

        [HttpPost]
        public ActionResult<SupplierProductOfferDto> CreateProductPriceInCategoryForSupplier(int supplierId, int supplierProductCategoryId, int supplierProductId,
            [FromBody] SupplierProductOfferForCreationDto supplierProductCategory)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productCategoryToSave = _mapper.Map<SupplierProductOffer>(supplierProductCategory);

            _shopRepository.AddProductToCategoryToSupplier(supplierId, supplierProductCategoryId, productCategoryToSave);

            _shopRepository.Save();

            var savedSupplierCategory = _mapper.Map<SupplierProductOfferDto>(productCategoryToSave);

            return CreatedAtRoute("GetProductPriceFromCategoryForSupplier", new
            {
                supplierId = supplierId,
                supplierProductCategoryId = supplierProductCategoryId,
                productId = savedSupplierCategory.Id
            }, savedSupplierCategory);

        }

        [HttpPut("{priceId}")]
        public IActionResult UpdateProductPriceInCategoryForSupplier(int supplierId, int supplierProductCategoryId, int productId,
            [FromBody] SupplierProductOfferForCreationDto productCategory)
        {

            if (!_shopRepository.SupplierExists(supplierId))
            {
                return NotFound();
            }

            var supplierProductCategoryFromRepo = _shopRepository.GetProductFromCategoryForSupplier(supplierId, supplierProductCategoryId, productId);

            if (supplierProductCategoryFromRepo == null)
            {
                return NotFound();
            }

            // map the entity to a SupplierProductCategoryForUpdateDto
            // apply the updated field values to that dto
            // map the SupplierProductCategoryForUpdateDto back to an entity

            _mapper.Map(productCategory, supplierProductCategoryFromRepo);
            _shopRepository.UpdateProductForSupplierProductCategory(supplierProductCategoryFromRepo);
            _shopRepository.Save();

            return NoContent();
        }

        [HttpDelete("{priceId}")]
        public IActionResult DeleteProductPriceInCategoryForSupplier(int supplierId, int supplierProductCategoryId, int productId)
        {

            var supplierEntity = _shopRepository.GetSupplier(supplierId);
            if (supplierEntity == null)
            {
                _logger.LogInformation($"Supplier with id {supplierId} was not found");
                return NotFound();
            }

            var supplierProductCategoryEntity = _shopRepository.GetProductFromCategoryForSupplier(supplierId, supplierProductCategoryId, productId);
            if (supplierProductCategoryEntity == null)
            {
                _logger.LogInformation($"Supplier with id {supplierId} does not have a product category with the id {supplierProductCategoryId}");
                return NotFound();
            }

            _shopRepository.DeleteProductFromCategoryForSupplier(supplierProductCategoryEntity);
            _shopRepository.Save();

            return NoContent();
        }

    }

}
