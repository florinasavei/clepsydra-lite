using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClepsydraLite.DAL;
using ClepsydraLite.DAL.Entities;
using ClepsydraLite.DAL.Entities.Shop;
using ClepsydraLite.DAL.Entities.Supplier;
using ClepsydraLite.DAL.Models.Shop;
using ClepsydraLite.DAL.Services;
using ClepsydraLite.DAL.Models.Supplier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClepsydraLite.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Shop")]
    public class ShopController : ControllerBase
    {
        private readonly IShopRepository _shopRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SupplierController> _logger;

        public ShopController(ILogger<SupplierController> logger, IShopRepository shopRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _shopRepository = shopRepository ?? throw new ArgumentException(nameof(shopRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShopDto>> GetShops()
        {
            try
            {
                var shopsEntities = _shopRepository.GetShops();

                return Ok(_mapper.Map<IEnumerable<ShopDto>>(shopsEntities));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while getting shops", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpGet("{id}", Name = "GetShop")]
        public ActionResult<ShopDto> GetShop(int id)
        {
            var supplier = _shopRepository.GetShop(id);

            if (supplier == null)
            {
                _logger.LogInformation($"Supplier with id {id} was not found");
                return NotFound();
            }

            return Ok(_mapper.Map<ShopDto>(supplier));
        }

        [HttpPost]
        public ActionResult<ShopDto> CreateShop([FromBody] ShopForCreationDto shop)
        {
            if (shop.Description == shop.Name)
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

            var shopToSave = _mapper.Map<ShopCore>(shop);

            _shopRepository.AddShop(shopToSave);

            _shopRepository.Save();

            ShopDto savedShop = _mapper.Map<ShopDto>(shopToSave);

            return CreatedAtRoute("GetShop", new
            {
                id = savedShop.Id
            }, savedShop);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateShop(int id,
            [FromBody] ShopForCreationDto shop)
        {

            if (shop.Description == shop.Name)
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

            var shopEntity = _shopRepository.GetShop(id);

            if (shopEntity == null)
            {
                _logger.LogInformation($"Show with id {id} was not found");
                return NotFound();
            }

            _mapper.Map(shop, shopEntity);
            _shopRepository.UpdateShop(shopEntity);
            _shopRepository.Save();

            return NoContent(); // according to REST standards, HTTP PUT should return NoContent
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShop(int id)
        {

            var shopEntity = _shopRepository.GetShop(id);
            if (shopEntity == null)
            {
                _logger.LogInformation($"Supplier with id {id} was not found");
                return NotFound();
            }

            _shopRepository.DeleteShop(shopEntity);
            _shopRepository.Save();

            return NoContent();
        }

    }

}
