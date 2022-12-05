using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositires;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class WalksController : Controller
    {
        private readonly IwalkRepository walkRepository;
        private readonly IMapper mapper;
        public WalksController(IwalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walks = await walkRepository.GetAllAsync();
            var walksDTO = mapper.Map<List<Model.DTO.Walks>>(walks);
            return Ok(walksDTO);
        }


        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkAsync")]
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            var Walk = await walkRepository.GetAsync(id);
            if (Walk == null)
            {
                return NotFound();
            }
            var walkoneDTO = mapper.Map<Model.DTO.Walks>(Walk);
            // var regionDTO = mapper.Map<List<Model.DTO.Region>>(region);
            return Ok(walkoneDTO);

        }



        [HttpPost]

        public async Task<IActionResult> AddWalksAsync(Model.DTO.AddWalkRequest addWalkRequest)
        {
            //Request DTo to Domain
            var walk = new Model.Domain.Walk()
            {
                Name = addWalkRequest.Name,
                length = addWalkRequest.length,
                RegionID = addWalkRequest.RegionID ,
                WalkDifficultyID = addWalkRequest.WalkDifficultyID,
               
            };


            //pass to repo
            walk = await walkRepository.AddAsync(walk);

            //convert to DTO 
            var walkDTO = new Model.DTO.Walks()
            {
                ID = walk.ID,
                Name = walk.Name,
                length = walk.length,
                RegionID = walk.RegionID,
                WalkDifficultyID = walk.WalkDifficultyID,               
            };
            return CreatedAtAction(nameof(GetWalkAsync), new { id = walkDTO.ID }, walkDTO);

        }



        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalksAsync([FromRoute] Guid id, [FromBody] Model.DTO.AddWalkRequest addWalkRequest)
        {
            //Request DTo to Domain
            var walk = new Model.Domain.Walk()
            {
                Name = addWalkRequest.Name,
                length = addWalkRequest.length,
                RegionID = addWalkRequest.RegionID,
                WalkDifficultyID = addWalkRequest.WalkDifficultyID,

            };


            //pass to repo
            walk = await walkRepository.UpdateAsync(id,walk);

            //convert to DTO 
            var walkDTO = new Model.DTO.Walks()
            {
                ID = walk.ID,
                Name = walk.Name,
                length = walk.length,
                RegionID = walk.RegionID,
                WalkDifficultyID = walk.WalkDifficultyID,
            };
            return Ok(walkDTO);

        }



        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var walk = await walkRepository.DeleteAsync(id);

            if (walk == null)
            {
                return NotFound();
            }

            //region = await regionRepository.DeleteAsync(id);
            var walkoneDTO = mapper.Map<Model.DTO.Walks>(walk);
            // var regionDTO = mapper.Map<List<Model.DTO.Region>>(region);
            return Ok(walkoneDTO);

        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
