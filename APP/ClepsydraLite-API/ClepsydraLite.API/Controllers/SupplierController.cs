using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClepsydraLite.DAL;
using ClepsydraLite.DAL.Entities;
using ClepsydraLite.DAL.Services;
using  ClepsydraLite.DAL.Models.Supplier;
using Microsoft.AspNetCore.Mvc;

namespace ClepsydraLite.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController: ControllerBase
    {
        private readonly IShopRepository _shopRepository;
        private readonly IMapper _mapper;

        public SupplierController(IShopRepository shopRepository, IMapper mapper)
        {
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
                //_logger.LogCritical($"Error while getting points of interest for City Id {cityId}", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpGet("{id}", Name = "GetSupplier")]
        public IActionResult GetPointsOfInterest(int cityId, int id)
        {
            var pointOfInterestForCity = _shopRepository.GetSupplier(id);

            if (pointOfInterestForCity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SupplierDto>(pointOfInterestForCity));
        }

        [HttpPost]
        public IActionResult CreatePointOfInterest([FromBody] SupplierForCreationDto supplier)
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

            var finalSupplier = _mapper.Map<Supplier>(supplier);

            _shopRepository.AddSupplier(finalSupplier);

            _shopRepository.Save();

            var createdPointOfInterestToReturn = _mapper.Map<SupplierDto>(finalSupplier);

            return CreatedAtRoute("GetSupplier", new
            {
                id = createdPointOfInterestToReturn.Id
            }, createdPointOfInterestToReturn);

        }
    }

}
