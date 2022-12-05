using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model.DTO;
using WebApplication1.Repositires;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RegionController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        public RegionController(IRegionRepository regionRepository,IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        public IMapper Mapper { get; }

        [HttpGet]
        public async Task<IActionResult> GetAllRegion()
        {
            var region = await regionRepository.GetAllAsync();
            var regionDTO = mapper.Map<List<Model.DTO.Region>>(region);
            return Ok(regionDTO);
        }


        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepository.GetAsync(id);
            if (region == null)
            {
                return NotFound();
            }
           var regionaloneDTO = mapper.Map<Model.DTO.Region>(region);
               // var regionDTO = mapper.Map<List<Model.DTO.Region>>(region);
                return Ok(regionaloneDTO);
           
        }


        [HttpPost]     
        
        public async Task<IActionResult> AddRegionAsync(Model.DTO.AddRegionRequest addRegionRequest)
        {
            //Request DTo to Domain
            var region = new Model.Domain.Region()
             { 
            code = addRegionRequest.code,
            Area = addRegionRequest.Area,
            Name= addRegionRequest.Name,
            Lat= addRegionRequest.Lat,
            Long= addRegionRequest.Long,
            populatiom= addRegionRequest.populatiom
            };
               

            //pass to repo
            region = await regionRepository.AddAsync(region);

            //convert to DTO 
            var RegionDTO = new Model.DTO.Region()
            {
                ID = region.ID,
                code = region.code,
                Area = region.Area,
                Name = region.Name,
                Lat = region.Lat,
                Long = region.Long,
                populatiom = region.populatiom
            };
            return CreatedAtAction(nameof(GetRegionAsync), new { id = RegionDTO.ID },RegionDTO);

        }

        [HttpDelete]
        [Route("{id:guid}")]        
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var region = await regionRepository.DeleteAsync(id);
           
            if (region == null)
            {
                return NotFound();
            }

            //region = await regionRepository.DeleteAsync(id);
            var regionaloneDTO = mapper.Map<Model.DTO.Region>(region);
            // var regionDTO = mapper.Map<List<Model.DTO.Region>>(region);
            return Ok(regionaloneDTO);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute]Guid id,[FromBody] Model.DTO.AddRegionRequest addRegionRequest)
        {
            var region = new Model.Domain.Region()
            {
                code = addRegionRequest.code,
                Area = addRegionRequest.Area,
                Name = addRegionRequest.Name,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                populatiom = addRegionRequest.populatiom
            };


            //pass to repo
            region = await regionRepository.UpdateAsync(id,region);

            if (region == null)
            { 
              return NotFound();
            }
            //convert to DTO 
            var RegionDTO = new Model.DTO.Region()
            {
                ID = region.ID,
                code = region.code,
                Area = region.Area,
                Name = region.Name,
                Lat = region.Lat,
                Long = region.Long,
                populatiom = region.populatiom
            };

            return Ok(RegionDTO);
           
        }

    }
}
