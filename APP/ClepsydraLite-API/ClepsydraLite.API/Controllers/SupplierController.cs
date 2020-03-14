using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClepsydraLite.DAL;
using ClepsydraLite.DAL.Entities;
using ClepsydraLite.DAL.Services;
using ClepsydraLite.DAL.Models.Supplier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClepsydraLite.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly IShopRepository _shopRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SupplierController> _logger;

        public SupplierController(ILogger<SupplierController> logger, IShopRepository shopRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _shopRepository = shopRepository ?? throw new ArgumentException(nameof(shopRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetSuppliers()
        {
            try
            {
                var pointsOfInterestForCity = _shopRepository.GetSuppliers();

                return Ok(_mapper.Map<IEnumerable<SupplierDto>>(pointsOfInterestForCity));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while getting suppliers", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpGet("{id}", Name = "GetSupplier")]
        public IActionResult GetSupplier(int id)
        {
            var supplier = _shopRepository.GetSupplier(id);

            if (supplier == null)
            {
                _logger.LogInformation($"Supplier with id {id} was not found");
                return NotFound();
            }

            return Ok(_mapper.Map<SupplierDto>(supplier));
        }

        [HttpPost]
        public IActionResult CreateSupplier([FromBody] SupplierForCreationDto supplier)
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

            var supplierToSave = _mapper.Map<Supplier>(supplier);

            _shopRepository.AddSupplier(supplierToSave);

            _shopRepository.Save();

            SupplierDto savedSupplier = _mapper.Map<SupplierDto>(supplierToSave);

            return CreatedAtRoute("GetSupplier", new
            {
                id = savedSupplier.Id
            }, savedSupplier);

        }

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
