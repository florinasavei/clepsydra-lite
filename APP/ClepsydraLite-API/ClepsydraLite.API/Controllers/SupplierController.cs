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

        //todo: finish route
        [HttpPost]
        public IActionResult CreatePointOfInterest(int cityId, [FromBody] SupplierForCreationDto pointOfInterest)
        {

            if (pointOfInterest.Description == pointOfInterest.Name)
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


            if (!_shopRepository.SupplierExists(cityId))
            {
                return NotFound();
            }


            var finalPointOfInterest = _mapper.Map<Supplier>(pointOfInterest);

            //city.PointsOfInterest.Add(finalPointOfInterest);

            _shopRepository.AddSupplier(cityId, finalPointOfInterest);

            _shopRepository.Save();

            var createdPointOfInterestToReturn = _mapper.Map<SupplierDto>(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest", new
            {
                cityId = cityId,
                id = createdPointOfInterestToReturn.Id
            }, createdPointOfInterestToReturn);

        }
    }

}
