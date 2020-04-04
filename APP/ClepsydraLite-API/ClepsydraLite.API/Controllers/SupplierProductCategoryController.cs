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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClepsydraLite.API.Controllers
{
    [ApiController]
    [Route("api/supplier/{supplierId}/[controller]")]
    public class SupplierProductCategoryController : ControllerBase
    {
        private readonly IShopRepository _shopRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SupplierController> _logger;

        public SupplierProductCategoryController(ILogger<SupplierController> logger, IShopRepository shopRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _shopRepository = shopRepository ?? throw new ArgumentException(nameof(shopRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetProductCategoriesForSuppliers(int supplierId)
        {
            if (!_shopRepository.SupplierExists(supplierId))
            {
                return NotFound();
            }

            try
            {
                var productCategoriesForSupplier = _shopRepository.GetProductCategoriesForSupplier(supplierId);
                return Ok(_mapper.Map<IEnumerable<SupplierProductCategoryDto>>(productCategoriesForSupplier));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while getting suppliers", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpGet("{supplierCategoryId}", Name = "GetProductCategoryForSupplier")]
        public IActionResult GetProductCategoryForSupplier(int supplierId, int supplierCategoryId)
        {
            var supplier = _shopRepository.GetProductCategoryForSupplier(supplierId, supplierCategoryId);

            if (supplier == null)
            {
                _logger.LogInformation($"Supplier with id {supplierId} was not found");
                return NotFound();
            }

            return Ok(_mapper.Map<SupplierProductCategoryDto>(supplier));
        }

        [HttpPost]
        public IActionResult CreateProductCategoryForSupplier(int supplierId, [FromBody] SupplierProductCategoryForCreationDto supplierProductCategory)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productCategoryToSave = _mapper.Map<SupplierProductCategory>(supplierProductCategory);

            _shopRepository.AddProductCategoryToSupplier(supplierId, productCategoryToSave);

            _shopRepository.Save();

            var savedSupplierCategory = _mapper.Map<SupplierProductCategoryDto>(productCategoryToSave);

            return CreatedAtRoute("GetProductCategoryForSupplier", new
            {
                supplierId = supplierId,
                supplierCategoryId = savedSupplierCategory.Id
            }, savedSupplierCategory);

        }

        //TODO: finish implementation
        [HttpPut("{id}")]
        public IActionResult UpdateSupplier(int id,
            [FromBody] SupplierForCreationDto supplier)
        {

            if (supplier.Description == supplier.Name)
            {
                ModelState.AddModelError(
                    "Description",
                    "The provided description should be different from the name."
                );
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplierEntity = _shopRepository.GetSupplier(id);

            if (supplierEntity == null)
            {
                _logger.LogInformation($"Supplier with id {id} was not found");
                return NotFound();
            }

            _mapper.Map(supplier, supplierEntity);
            _shopRepository.UpdateSupplier(supplierEntity);
            _shopRepository.Save();

            return NoContent();
        }

        //TODO: finish implementation
        [HttpDelete("{id}")]
        public IActionResult DeleteSupplier(int id)
        {

            var supplierEntity = _shopRepository.GetSupplier(id);
            if (supplierEntity == null)
            {
                _logger.LogInformation($"Supplier with id {id} was not found");
                return NotFound();
            }

            _shopRepository.DeleteSupplier(supplierEntity);
            _shopRepository.Save();

            return NoContent();
        }

    }

}
